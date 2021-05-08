using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryWsm
{
    internal class SummaryWsmBinaryZip : ISummaryWsmBinaryRepository
    {

        private readonly FileInfo _scenarioZipFile;

        public SummaryWsmBinaryZip(FileInfo scenarioZipFile)
        {
            _scenarioZipFile = scenarioZipFile;
        }

        public SummaryWsmBinary Get()
        {
            return GetSummaryWsmBinary();
        }
        protected SummaryWsmBinary GetSummaryWsmBinary()
        {
            using (var scenarioArchive = ZipFile.OpenRead(_scenarioZipFile.FullName))
            {
                var summaryWsmFiles = GetSummaryWsmFiles(scenarioArchive);
                if (!summaryWsmFiles.Any())
                {
                    throw new FileNotFoundException("Summary.wsm file not found");
                }
                var summaryFile = summaryWsmFiles.ElementAt(0);
                if (summaryFile.FullName.Split('/').Length >= 2)
                {
                    // TODO:アーカイブの中のSummaryファイルの階層が深すぎる場合、何か対応を入れるか考え中
                }
                return new SummaryWsmBinary(GetBinaryData(summaryFile), GetSummaryMetaData(summaryFile));
            }
        }

        private IEnumerable<ZipArchiveEntry> GetSummaryWsmFiles(ZipArchive scenarioArchive)
        {
            return scenarioArchive.Entries
                .Where(e => e.Name.Equals("Summary.wsm"))
                .OrderBy(e => e.FullName);
        }

        private static byte[] GetBinaryData(ZipArchiveEntry scenarioArcive)
        {
            using (var stream = scenarioArcive.Open())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    var data = memoryStream.ToArray();
                    return data;
                }
            }
        }
        private static SummaryMetaData GetSummaryMetaData(ZipArchiveEntry summaryFile)
        {
            return new SummaryMetaData(summaryFile.LastWriteTime.DateTime, summaryFile.Length);
        }


    }

}