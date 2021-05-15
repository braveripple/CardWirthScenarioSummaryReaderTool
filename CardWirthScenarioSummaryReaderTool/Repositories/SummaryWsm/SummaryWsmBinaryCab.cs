using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using Microsoft.Deployment.Compression.Cab;
using System.IO;
using System.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryWsm
{
    internal sealed class SummaryWsmBinaryCab : ISummaryWsmBinaryRepository
    {
        private readonly FileInfo _scenarioCabFile;

        public SummaryWsmBinaryCab(FileInfo scenarioCabFile)
        {
            _scenarioCabFile = scenarioCabFile;
        }

        public SummaryWsmBinary Get()
        {
            return GetSummaryWsmBinary();
        }

        private SummaryWsmBinary GetSummaryWsmBinary()
        {
            var cabInfo = new CabInfo(_scenarioCabFile.FullName);
            var summaryWsmFiles = cabInfo.GetFiles()
                    .Where(e => e.Name.Equals("Summary.wsm"))
                    .OrderBy(e => e.FullName);
            if (!summaryWsmFiles.Any())
            {
                throw new FileNotFoundException("Summary.wsm file not found");
            }

            var summaryFile = summaryWsmFiles.ElementAt(0);

            return new SummaryWsmBinary(GetBinaryData(summaryFile), GetSummaryMetaData(summaryFile));
        }
        private static byte[] GetBinaryData(CabFileInfo summaryFile)
        {
            using (var stream = summaryFile.OpenRead())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    var data = memoryStream.ToArray();
                    return data;
                }
            }
        }
        private static SummaryMetaData GetSummaryMetaData(CabFileInfo summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime, summaryFile.Length);
        }
    }

}