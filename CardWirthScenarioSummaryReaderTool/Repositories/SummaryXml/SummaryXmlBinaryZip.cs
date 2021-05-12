using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml
{
    internal class SummaryXmlBinaryZip : ISummaryXmlBinaryRepository
    {

        private readonly FileInfo _scenarioZipFile;

        public SummaryXmlBinaryZip(FileInfo scenarioZipFile)
        {
            _scenarioZipFile = scenarioZipFile;
        }

        public SummaryXmlBinary Get()
        {
            return GetSummaryXmlBinary();
        }

        protected SummaryXmlBinary GetSummaryXmlBinary()
        {
            using (var scenarioArchive = new ZipFile(new FileStream(_scenarioZipFile.FullName, FileMode.Open, FileAccess.Read)))
            {
                var summaryXmlFiles = new List<ZipEntry>();
                foreach (ZipEntry ze in scenarioArchive)
                {
                    if (ze.IsDirectory) continue;
                    if (ze.Name.EndsWith("Summary.xml"))
                    {
                        summaryXmlFiles.Add(ze);
                    }
                }
                if (!summaryXmlFiles.Any())
                {
                    throw new FileNotFoundException("Summary.xml file not found");
                }
                var summaryFile = summaryXmlFiles.ElementAt(0);
                if (summaryFile.IsCrypted)
                {
                    throw new InvalidScenarioException($"Because ‘{_scenarioZipFile.FullName}’ is a zip file with a password, it cannot be parsed.");
                }

                using (var stream = scenarioArchive.GetInputStream(summaryFile))
                {
                    using (var sr = new StreamReader(stream))
                    {
                        return new SummaryXmlBinary(sr.ReadToEnd(), GetSummaryMetaData(summaryFile));
                    }
                }
            }
        }

        private static SummaryMetaData GetSummaryMetaData(ZipEntry summaryFile)
        {
            return new SummaryMetaData(summaryFile.DateTime, summaryFile.Size);
        }
    }

}