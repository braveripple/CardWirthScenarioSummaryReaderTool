using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.IsScenarioSummaryΜeXg<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ContainerParameterType)"/><br />
    /// </summary>
    public class IsScenarioSummaryTest : ScenarioSummaryTestBase
    {
        /// <summary>
        /// RXgN^
        /// </summary>
        public IsScenarioSummaryTest() : base("eXgf[^/")
        {
        }

        [Theory(DisplayName = "ViIΜ»θ")]
        [InlineData(@"SuΜ΄A", ScenarioParameterType.Classic, ContainerParameterType.Directory)]
        [InlineData(@"SuΜ΄A.cab", ScenarioParameterType.Classic, ContainerParameterType.CabFile)]
        [InlineData(@"SuΜ΄A.zip", ScenarioParameterType.Classic, ContainerParameterType.ZipFile)]
        [InlineData(@"SuΜ΄A.wsn", ScenarioParameterType.Classic, ContainerParameterType.WsnFile)]
        [InlineData(@"SuΜ΄ANext", ScenarioParameterType.Next, ContainerParameterType.Directory)]
        [InlineData(@"SuΜ΄ANext.cab", ScenarioParameterType.Next, ContainerParameterType.CabFile)]
        [InlineData(@"SuΜ΄ANext.zip", ScenarioParameterType.Next, ContainerParameterType.ZipFile)]
        [InlineData(@"SuΜ΄ANext.wsn", ScenarioParameterType.Next, ContainerParameterType.WsnFile)]
        [InlineData(@"SuΜ΄AWsn", ScenarioParameterType.Wsn, ContainerParameterType.Directory)]
        [InlineData(@"SuΜ΄AWsn.cab", ScenarioParameterType.Wsn, ContainerParameterType.CabFile)]
        [InlineData(@"SuΜ΄AWsn.zip", ScenarioParameterType.Wsn, ContainerParameterType.ZipFile)]
        [InlineData(@"SuΜ΄AWsn.wsn", ScenarioParameterType.Wsn, ContainerParameterType.WsnFile)]
        public void IsScenarioTest(string path, ScenarioParameterType scenarioParameterType, ContainerParameterType containerParameterType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, scenarioParameterType, containerParameterType));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Any));

        }

        [Theory(DisplayName = "Classic`?ViIΜ»θ")]
        [InlineData(@"SuΜ΄A")]
        [InlineData(@"SuΜ΄A.cab")]
        [InlineData(@"SuΜ΄A.zip")]
        [InlineData(@"SuΜ΄A.wsn")]
        public void IsClassicScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "NEXT`?ViIΜ»θ")]
        [InlineData(@"SuΜ΄ANext")]
        [InlineData(@"SuΜ΄ANext.cab")]
        [InlineData(@"SuΜ΄ANext.zip")]
        [InlineData(@"SuΜ΄ANext.wsn")]
        public void IsNextScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "WSN`?ViIΜ»θ")]
        [InlineData(@"SuΜ΄AWsn")]
        [InlineData(@"SuΜ΄AWsn.cab")]
        [InlineData(@"SuΜ΄AWsn.zip")]
        [InlineData(@"SuΜ΄AWsn.wsn")]
        public void IsWsnScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "fBNgi[ViIΜ»θ")]
        [InlineData(@"SuΜ΄A")]
        [InlineData(@"SuΜ΄ANext")]
        [InlineData(@"SuΜ΄AWsn")]
        public void IsDirectoryScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ZIPi[ViIΜ»θ")]
        [InlineData(@"SuΜ΄A.zip")]
        [InlineData(@"SuΜ΄ANext.zip")]
        [InlineData(@"SuΜ΄AWsn.zip")]
        public void IsZipFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "CABi[ViIΜ»θ")]
        [InlineData(@"SuΜ΄A.cab")]
        [InlineData(@"SuΜ΄ANext.cab")]
        [InlineData(@"SuΜ΄AWsn.cab")]
        public void IsCabFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "WSNi[ViIΜ»θ")]
        [InlineData(@"SuΜ΄A.wsn")]
        [InlineData(@"SuΜ΄ANext.wsn")]
        [InlineData(@"SuΜ΄AWsn.wsn")]
        public void IsWsnFileScenarioTest(string filename)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "³νn/", filename));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ViIͺ©Β©ηΘ©Α½Ζ«FalseπΤ·eXg")]
        [InlineData(@"Ωνn/»ρΘViIΝΘ’")]
        public void IsNotScenarioTest1(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(!File.Exists(fullName) && !Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }

        [Theory(DisplayName = "»ΜΌΜΩνnΝ·ΧΔFalseπΤ·eXg")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄A")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄A.xxx")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄ANext")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄ANext.xxx")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄AWsn")]
        [InlineData(@"Ωνn/UnsupportedContainerTypeException/SuΜ΄AWsn.xxx")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryFileNotFound/SuΜ΄AEmpty")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryFileNotFound/SuΜ΄AEmpty.cab")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryFileNotFound/SuΜ΄AEmpty.zip")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryFileNotFound/SuΜ΄AEmpty.wsn")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryWsmInvalid/SuΜ΄AInvalid")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryWsmInvalid/SuΜ΄AInvalid.cab")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryWsmInvalid/SuΜ΄AInvalid.zip")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryWsmInvalid/SuΜ΄AInvalid.wsn")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryXmlInvalid/SuΜ΄AInvalid")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryXmlInvalid/SuΜ΄AInvalid.cab")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryXmlInvalid/SuΜ΄AInvalid.zip")]
        [InlineData(@"Ωνn/InvalidScenarioException/SummaryXmlInvalid/SuΜ΄AInvalid.wsn")]
        public void IsNotScenarioTest2(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(File.Exists(fullName) || Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }
    }
}
