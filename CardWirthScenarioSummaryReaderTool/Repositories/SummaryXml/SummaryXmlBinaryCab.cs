using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
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
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private static SummaryMetaData GetSummaryMetaData(CabFileInfo summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime, summaryFile.Length);
        }

    }

}