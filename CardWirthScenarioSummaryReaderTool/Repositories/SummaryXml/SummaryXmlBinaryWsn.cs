using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Repositories.SummaryXml
{
    internal sealed class SummaryXmlBinaryWsn : SummaryXmlBinaryZip
    {

        public SummaryXmlBinaryWsn(FileInfo ScenarioWsnFile) : base(ScenarioWsnFile)
        {
        }

    }

}