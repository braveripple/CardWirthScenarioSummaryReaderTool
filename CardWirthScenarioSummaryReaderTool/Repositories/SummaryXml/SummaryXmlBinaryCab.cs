using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using Microsoft.Deployment.Compression.Cab;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml
{
    internal sealed class SummaryXmlBinaryCab : ISummaryXmlBinaryRepository
    {
        private readonly FileInfo _scenarioCabFile;

        public SummaryXmlBinaryCab(FileInfo cabFile)
        {
            _scenarioCabFile = cabFile;
        }

        public SummaryXmlBinary Get()
        {
            return GetSummaryXmlBinary();
        }

        private SummaryXmlBinary GetSummaryXmlBinary()
        {
            var cabInfo = new CabInfo(_scenarioCabFile.FullName);
            var summaryXmlFiles = GetSummaryXmlFiles(cabInfo);
            if (!summaryXmlFiles.Any())
            {
                throw new FileNotFoundException("Summary.xml file not found");
            }
            var summaryFile = summaryXmlFiles.ElementAt(0);
            if (summaryFile.FullName.Split('/').Length >= 2)
            {
                // TODO:アーカイブの中のSummaryファイルの階層が深すぎる場合、何か対応を入れるか考え中
            }
            return new SummaryXmlBinary(GetXmlText(summaryFile), GetSummaryMetaData(summaryFile));
        }
        private static IEnumerable<CabFileInfo> GetSummaryXmlFiles(CabInfo cabInfo)
        {
            return cabInfo.GetFiles()
                .Where(e => e.Name.Equals("Summary.xml"))
                .OrderBy(e => e.FullName);
        }
        private static string GetXmlText(CabFileInfo summaryFile)
        {
            using (var stream = summaryFile.OpenRead())
            {
                var sr = new StreamReader(stream);
                var xmlText = sr.ReadToEnd();
                return xmlText;
            }
        }

        private static SummaryMetaData GetSummaryMetaData(CabFileInfo summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime, summaryFile.Length);
        }

    }

}