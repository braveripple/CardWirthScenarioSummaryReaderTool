using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.IsScenarioSummary‚ÌƒeƒXƒg<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ContainerParameterType)"/><br />
    /// </summary>
    public class IsScenarioSummaryTest : ScenarioSummaryTestBase
    {
        /// <summary>
        /// ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        /// </summary>
        public IsScenarioSummaryTest() : base("ƒeƒXƒgƒf[ƒ^/")
        {
        }

        [Theory(DisplayName = "ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA", ScenarioParameterType.Classic, ContainerParameterType.Directory)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.cab", ScenarioParameterType.Classic, ContainerParameterType.CabFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.zip", ScenarioParameterType.Classic, ContainerParameterType.ZipFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.wsn", ScenarioParameterType.Classic, ContainerParameterType.WsnFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext", ScenarioParameterType.Next, ContainerParameterType.Directory)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.cab", ScenarioParameterType.Next, ContainerParameterType.CabFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.zip", ScenarioParameterType.Next, ContainerParameterType.ZipFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.wsn", ScenarioParameterType.Next, ContainerParameterType.WsnFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn", ScenarioParameterType.Wsn, ContainerParameterType.Directory)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.cab", ScenarioParameterType.Wsn, ContainerParameterType.CabFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.zip", ScenarioParameterType.Wsn, ContainerParameterType.ZipFile)]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.wsn", ScenarioParameterType.Wsn, ContainerParameterType.WsnFile)]
        public void IsScenarioTest(string path, ScenarioParameterType scenarioParameterType, ContainerParameterType containerParameterType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, scenarioParameterType, containerParameterType));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Any));

        }

        [Theory(DisplayName = "ClassicŒ`®ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.cab")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.zip")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.wsn")]
        public void IsClassicScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "NEXTŒ`®ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.cab")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.zip")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.wsn")]
        public void IsNextScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "WSNŒ`®ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.cab")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.zip")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.wsn")]
        public void IsWsnScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "ƒfƒBƒŒƒNƒgƒŠŠi”[ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn")]
        public void IsDirectoryScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ZIPŠi”[ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.zip")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.zip")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.zip")]
        public void IsZipFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "CABŠi”[ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.cab")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.cab")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.cab")]
        public void IsCabFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "WSNŠi”[ƒVƒiƒŠƒI‚Ì”»’è")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒA.wsn")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒANext.wsn")]
        [InlineData(@"ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.wsn")]
        public void IsWsnFileScenarioTest(string filename)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³íŒn/", filename));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ƒVƒiƒŠƒI‚ªŒ©‚Â‚©‚ç‚È‚©‚Á‚½‚Æ‚«False‚ğ•Ô‚·ƒeƒXƒg")]
        [InlineData(@"ˆÙíŒn/‚»‚ñ‚ÈƒVƒiƒŠƒI‚Í‚È‚¢")]
        public void IsNotScenarioTest1(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(!File.Exists(fullName) && !Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }

        [Theory(DisplayName = "‚»‚Ì‘¼‚ÌˆÙíŒn‚Í‚·‚×‚ÄFalse‚ğ•Ô‚·ƒeƒXƒg")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒA")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒA.xxx")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒANext")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒANext.xxx")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒAWsn")]
        [InlineData(@"ˆÙíŒn/UnsupportedContainerTypeException/ƒSƒuƒŠƒ“‚Ì“´ŒAWsn.xxx")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryFileNotFound/ƒSƒuƒŠƒ“‚Ì“´ŒAEmpty")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryFileNotFound/ƒSƒuƒŠƒ“‚Ì“´ŒAEmpty.cab")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryFileNotFound/ƒSƒuƒŠƒ“‚Ì“´ŒAEmpty.zip")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryFileNotFound/ƒSƒuƒŠƒ“‚Ì“´ŒAEmpty.wsn")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryWsmInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryWsmInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.cab")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryWsmInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.zip")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryWsmInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.wsn")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryXmlInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryXmlInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.cab")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryXmlInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.zip")]
        [InlineData(@"ˆÙíŒn/InvalidScenarioException/SummaryXmlInvalid/ƒSƒuƒŠƒ“‚Ì“´ŒAInvalid.wsn")]
        public void IsNotScenarioTest2(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(File.Exists(fullName) || Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }
    }
}
