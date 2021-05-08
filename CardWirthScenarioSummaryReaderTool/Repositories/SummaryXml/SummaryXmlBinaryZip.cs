using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml
{
    internal class SummaryXmlBinaryZip : ISummaryXmlBinaryRepository
    {

        public FileInfo ScenarioZipFile { get; set; }

        public SummaryXmlBinaryZip(FileInfo scenarioZipFile)
        {
            ScenarioZipFile = scenarioZipFile;
        }

        public SummaryXmlBinary Get()
        {
            return GetSummaryXmlBinary();
        }
        protected SummaryXmlBinary GetSummaryXmlBinary()
        {
            using (ZipArchive scenarioArchive = ZipFile.OpenRead(ScenarioZipFile.FullName))
            {
                IEnumerable<ZipArchiveEntry> summaryXmlFiles = GetSummaryXmlFiles(scenarioArchive);
                if (!summaryXmlFiles.Any())
                {
                    throw new FileNotFoundException("Summary.xml file not found");
                }
                ZipArchiveEntry summaryFile = summaryXmlFiles.ElementAt(0);
                if (summaryFile.FullName.Split('/').Length >= 2)
                {
                    // TODO:アーカイブの中のSummaryファイルの階層が深すぎる場合、何か対応を入れるか考え中
                }
                return new SummaryXmlBinary(GetXmlText(summaryFile), GetSummaryMetaData(summaryFile));
            }
        }
        private static IEnumerable<ZipArchiveEntry> GetSummaryXmlFiles(ZipArchive scenarioArchive)
        {
            return scenarioArchive.Entries
                .Where(e => e.Name.Equals("Summary.xml"))
                .OrderBy(e => e.FullName);
        }

        private static string GetXmlText(ZipArchiveEntry summaryFile)
        {
            using (Stream stream = summaryFile.Open())
            {
                StreamReader streamReader = new StreamReader(stream);
                string xmlText = streamReader.ReadToEnd();
                return xmlText;
            }
        }
        private static SummaryMetaData GetSummaryMetaData(ZipArchiveEntry summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime.DateTime, summaryFile.Length);
        }
    }

}