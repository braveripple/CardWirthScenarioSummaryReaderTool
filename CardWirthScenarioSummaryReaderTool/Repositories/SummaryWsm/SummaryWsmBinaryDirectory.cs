using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryWsm
{
    internal sealed class SummaryWsmBinaryDirectory : ISummaryWsmBinaryRepository
    {
        private readonly DirectoryInfo _scenarioDirectory;

        public SummaryWsmBinaryDirectory(DirectoryInfo directoryInfo)
        {
            _scenarioDirectory = directoryInfo;
        }

        public SummaryWsmBinary Get()
        {
            return GetSummaryWsmBinary();
        }

        private SummaryWsmBinary GetSummaryWsmBinary()
        {
            var files = _scenarioDirectory.GetFiles("Summary.wsm", SearchOption.TopDirectoryOnly);
            if (files.Length == 0)
            {
                throw new FileNotFoundException("Summary.wsm file not found");
            }

            var summaryFile = files[0];

            return new SummaryWsmBinary(GetBinaryData(summaryFile), GetSummaryMetaData(summaryFile));
        }

        private static byte[] GetBinaryData(FileInfo summaryFile)
        {
            using (var fs = summaryFile.OpenRead())
            {
                var data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                return data;
            }
        }
        private static SummaryMetaData GetSummaryMetaData(FileInfo summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime, summaryFile.Length);
        }

    }

}