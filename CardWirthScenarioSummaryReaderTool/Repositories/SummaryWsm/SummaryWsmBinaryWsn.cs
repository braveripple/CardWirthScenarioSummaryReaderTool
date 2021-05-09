using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryWsm
{
    internal sealed class SummaryWsmBinaryWsn : SummaryWsmBinaryZip
    {

        public SummaryWsmBinaryWsn(FileInfo scenarioWsnFile) : base(scenarioWsnFile)
        {
        }

        public new SummaryWsmBinary Get()
        {
            return base.Get();
        }
    }

}