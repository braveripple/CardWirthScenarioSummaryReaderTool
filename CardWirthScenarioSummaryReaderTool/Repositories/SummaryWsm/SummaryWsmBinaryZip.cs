using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections.Generic;
using System.IO;
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
            using (var scenarioArchive = new ZipFile(new FileStream(_scenarioZipFile.FullName, FileMode.Open, FileAccess.Read)))
            {
                var summaryWsmFiles = new List<ZipEntry>();
                foreach (ZipEntry ze in scenarioArchive)
                {
                    if (ze.IsDirectory) continue;
                    if (ze.Name.EndsWith("Summary.wsm"))
                    {
                        summaryWsmFiles.Add(ze);
                    }
                }
                if (!summaryWsmFiles.Any())
                {
                    throw new FileNotFoundException("Summary.wsm file not found");
                }
                var summaryFile = summaryWsmFiles.ElementAt(0);
                if (summaryFile.IsCrypted)
                {
                    throw new InvalidScenarioException($"Because ‘{_scenarioZipFile.FullName}’ is a zip file with a password, it cannot be parsed.");
                }

                using (var stream = scenarioArchive.GetInputStream(summaryFile))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        return new SummaryWsmBinary(memoryStream.ToArray(), GetSummaryMetaData(summaryFile));
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