using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml
{
    internal sealed class SummaryXmlBinaryDirectory : ISummaryXmlBinaryRepository
    {
        private readonly DirectoryInfo _scenarioDirectory;

        public SummaryXmlBinaryDirectory(DirectoryInfo scenarioDirectory)
        {
            _scenarioDirectory = scenarioDirectory;
        }

        public SummaryXmlBinary Get()
        {
            return GetSummaryXmlBinary();
        }

        private SummaryXmlBinary GetSummaryXmlBinary()
        {
            var files = GetSummaryXmlFiles();
            if (files.Length == 0)
            {
                throw new FileNotFoundException("Summary.xml file not found");
            }
            var summaryFile = files[0];
            return new SummaryXmlBinary(GetXmlText(summaryFile), GetSummaryMetaData(summaryFile));

        }

        private FileInfo[] GetSummaryXmlFiles()
        {
            return _scenarioDirectory.GetFiles("Summary.Xml", SearchOption.TopDirectoryOnly);
        }

        private static string GetXmlText(FileInfo summaryFile)
        {
            using (var fs = summaryFile.OpenRead())
            {
                var sr = new StreamReader(fs);
                string xmlText = sr.ReadToEnd();
                return xmlText;
            }
        }


        private static SummaryMetaData GetSummaryMetaData(FileInfo summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime, summaryFile.Length);
        }
    }

}