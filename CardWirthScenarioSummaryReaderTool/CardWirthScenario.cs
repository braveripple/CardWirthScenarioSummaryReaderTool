using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Readers;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryWsm;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml;
using System;
using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool
{
    /// <summary>
    /// CardWirthScenarioSummaryReaderToolのAPIクラス
    /// </summary>
    public static class CardWirthScenario
    {
        /// <summary>
        /// パスからシナリオ情報を取得する
        /// </summary>
        /// <param name="path">シナリオのディレクトリ、またはアーカイブファイルの絶対パス</param>
        /// <returns>シナリオ情報</returns>
        public static ScenarioSummary GetScenarioSummary(string path)
        {

            var scenarioMetaData = GetScenarioMetaData(path);

            // Summary.wsmを取りに行く
            SummaryWsmBinary wsmBinary;
            try
            {
                wsmBinary = GetSummaryWsmBinary(scenarioMetaData);
            }
            catch (FileNotFoundException)
            {
                wsmBinary = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Summary.xmlを取りに行く
            SummaryXmlBinary xmlBinary;
            try
            {
                xmlBinary = GetSummaryXmlBinary(scenarioMetaData);
            }
            catch (FileNotFoundException)
            {
                xmlBinary = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Summary.wsmもSummary.xmlも見つからない場合は例外を投げる
            if (wsmBinary == null && xmlBinary == null)
            {
                throw new InvalidScenarioException($"The Summary file (Summary.wsm, Summary.xml) was not found in the path '{path}'.");
            }

            // 複数のSummaryファイルが見つかった時はSummary.wsmを優先する
            if (wsmBinary != null)
            {
                try
                {
                    using (SummaryWsmBinaryReader wsmReader = new SummaryWsmBinaryReader(wsmBinary))
                    {
                        SummaryWsm summaryWsm = wsmReader.Read();

                        ScenarioSummary scenarioSummary = ConvertToScenarioSummary(summaryWsm, scenarioMetaData);
                        return scenarioSummary;
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidScenarioException($"Failed to read Summary.wsm with path '{path}'.", ex);
                }

            }
            else
            {
                try
                {
                    var xmlReader = new SummaryXmlBinaryReader(xmlBinary);
                    var summaryXml = xmlReader.Read();

                    var scenarioSummary = ConvertToScenarioSummary(summaryXml, scenarioMetaData);
                    return scenarioSummary;
                }
                catch (Exception ex)
                {
                    throw new InvalidScenarioException($"Failed to read Summary.xml with path '{path}'.", ex);
                }

            }
        }

        private static ScenarioMetaData GetScenarioMetaData(string path)
        {
            if (File.Exists(path))
            {
                var fi = new FileInfo(path);
                var extension = Path.GetExtension(path);
                switch (extension.ToLower())
                {
                    case ".zip":
                        return new ScenarioMetaData(ContainerType.ZipFile, fi.LastWriteTime, fi.FullName); ;
                    case ".cab":
                        return new ScenarioMetaData(ContainerType.CabFile, fi.LastWriteTime, fi.FullName); ;
                    case ".wsn":
                        return new ScenarioMetaData(ContainerType.WsnFile, fi.LastWriteTime, fi.FullName); ;
                    default:
                        throw new UnsupportedContainerTypeException($"The extension '{extension}' in the path '{path}' is an unsupported scenario container type.");
                }
            }
            else if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);
                return new ScenarioMetaData(ContainerType.Directory, di.LastWriteTime, di.FullName);
            }
            else
            {
                throw new ScenarioNotFoundException($"Could not find path '{path}'.");
            }
        }

        private static SummaryWsmBinary GetSummaryWsmBinary(ScenarioMetaData scenarioMetaData)
        {
            return CreateSummaryWsmBinaryRepository(scenarioMetaData).Get();
        }

        private static ISummaryWsmBinaryRepository CreateSummaryWsmBinaryRepository(ScenarioMetaData scenarioMetaData)
        {
            switch (scenarioMetaData.ContainerType)
            {
                case ContainerType.Directory:
                    DirectoryInfo directory = new DirectoryInfo(scenarioMetaData.FullName);
                    return new SummaryWsmBinaryDirectory(directory);
                case ContainerType.ZipFile:
                    FileInfo zipFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryWsmBinaryZip(zipFile);
                case ContainerType.CabFile:
                    FileInfo cabFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryWsmBinaryCab(cabFile);
                case ContainerType.WsnFile:
                    FileInfo wsnFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryWsmBinaryWsn(wsnFile);
                default:
                    throw new Exception();
            }
        }

        private static SummaryXmlBinary GetSummaryXmlBinary(ScenarioMetaData scenarioMetaData)
        {
            return CreateSummaryXmlBinaryRepository(scenarioMetaData).Get();
        }

        private static ISummaryXmlBinaryRepository CreateSummaryXmlBinaryRepository(ScenarioMetaData scenarioMetaData)
        {
            switch (scenarioMetaData.ContainerType)
            {
                case ContainerType.Directory:
                    DirectoryInfo directory = new DirectoryInfo(scenarioMetaData.FullName);
                    return new SummaryXmlBinaryDirectory(directory);
                case ContainerType.ZipFile:
                    FileInfo zipFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryXmlBinaryZip(zipFile);
                case ContainerType.CabFile:
                    FileInfo cabFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryXmlBinaryCab(cabFile);
                case ContainerType.WsnFile:
                    FileInfo wsnFile = new FileInfo(scenarioMetaData.FullName);
                    return new SummaryXmlBinaryWsn(wsnFile);
                default:
                    throw new Exception();
            }
        }


        private static ScenarioSummary ConvertToScenarioSummary(ISummary summary, ScenarioMetaData scenarioMetaData)
        {
            return new ScenarioSummary(GetScenarioType(summary),
                                       scenarioMetaData.ContainerType,
                                       summary.LevelMin,
                                       summary.LevelMax,
                                       summary.Name,
                                       summary.Author,
                                       summary.Description,
                                       summary,
                                       scenarioMetaData.LastWriteTime,
                                       scenarioMetaData.FullName);
        }

        private static ScenarioType GetScenarioType(ISummary summary)
        {
            if (summary is SummaryXml)
            {
                return ScenarioType.Wsn;
            }
            else if (summary is SummaryWsm)
            {
                if (summary.DataVersion >= 7)
                {
                    return ScenarioType.Next;
                }
                else
                {
                    return ScenarioType.Classic;
                }
            }
            else
            {
                return ScenarioType.None;
            }
        }

        /// <summary>
        /// パスが指定したシナリオ形式のシナリオかどうか判定する
        /// </summary>
        /// <param name="path">シナリオのディレクトリ、またはアーカイブファイルの絶対パス</param>
        /// <param name="scenarioType">シナリオ形式</param>
        /// <returns>シナリオの場合true, シナリオでない場合false</returns>
        public static bool IsScenarioSummary(string path, ScenarioParameterType scenarioType)
        {
            return IsScenarioSummary(path, scenarioType, ContainerParameterType.Any);
        }

        /// <summary>
        /// パスが指定したシナリオ格納形式のシナリオかどうか判定する
        /// </summary>
        /// <param name="path">シナリオのディレクトリ、またはアーカイブファイルの絶対パス</param>
        /// <param name="containerType">シナリオ格納形式</param>
        /// <returns>シナリオの場合true, シナリオでない場合false</returns>
        public static bool IsScenarioSummary(string path, ContainerParameterType containerType)
        {
            return IsScenarioSummary(path, ScenarioParameterType.Any, containerType);
        }

        /// <summary>
        /// パスが指定したシナリオ形式とシナリオ格納形式のシナリオかどうか判定する
        /// </summary>
        /// <param name="path">シナリオのディレクトリ、またはアーカイブファイルの絶対パス</param>
        /// <param name="scenarioType">シナリオ形式。未指定またはAnyの場合はすべてのシナリオ形式が対象</param>
        /// <param name="containerType">シナリオ格納形式。未指定またはAnyの場合はすべてのシナリオ格納形式が対象</param>
        /// <returns>シナリオの場合true, シナリオでない場合false</returns>
        public static bool IsScenarioSummary(string path,
                                             ScenarioParameterType scenarioType = ScenarioParameterType.Any,
                                             ContainerParameterType containerType = ContainerParameterType.Any)
        {
            try
            {
                var scenarioSummary = GetScenarioSummary(path);
                if (scenarioType != ScenarioParameterType.Any)
                {
                    var scenarioType2 = ConvertToScenarioType(scenarioType);
                    if (scenarioType2 != scenarioSummary.ScenarioType)
                    {
                        return false;
                    }
                }
                if (containerType != ContainerParameterType.Any)
                {
                    var containerType2 = ConvertToContainerType(containerType);
                    if (containerType2 != scenarioSummary.ContainerType)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// <see cref="Enums.ScenarioParameterType"/>を<see cref="Enums.ScenarioType"/>に変換する
        /// </summary>
        /// <param name="scenarioParameterType">シナリオ形式</param>
        /// <returns></returns>
        private static ScenarioType ConvertToScenarioType(ScenarioParameterType scenarioParameterType)
        {
            return Enum.TryParse(scenarioParameterType.ToString(), true, out ScenarioType convertedScenariotType)
                ? convertedScenariotType
                : ScenarioType.None;
        }

        /// <summary>
        /// <see cref="Enums.ContainerParameterType"/>を<see cref="Enums.ContainerType"/>に変換する
        /// </summary>
        /// <param name="containerParameterType">シナリオ格納形式</param>
        /// <returns></returns>
        private static ContainerType ConvertToContainerType(ContainerParameterType containerParameterType)
        {
            return Enum.TryParse(containerParameterType.ToString(), true, out ContainerType convertedContainerType)
                ? convertedContainerType
                : ContainerType.None;
        }

    }
}
