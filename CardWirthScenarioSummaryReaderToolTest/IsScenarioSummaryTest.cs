using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.IsScenarioSummaryのテスト<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ContainerParameterType)"/><br />
    /// </summary>
    public class IsScenarioSummaryTest : ScenarioSummaryTestBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IsScenarioSummaryTest() : base("テストデータ/")
        {
        }

        [Theory(DisplayName = "シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟", ScenarioParameterType.Classic, ContainerParameterType.Directory)]
        [InlineData(@"ゴブリンの洞窟.cab", ScenarioParameterType.Classic, ContainerParameterType.CabFile)]
        [InlineData(@"ゴブリンの洞窟.zip", ScenarioParameterType.Classic, ContainerParameterType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟.wsn", ScenarioParameterType.Classic, ContainerParameterType.WsnFile)]
        [InlineData(@"ゴブリンの洞窟Next", ScenarioParameterType.Next, ContainerParameterType.Directory)]
        [InlineData(@"ゴブリンの洞窟Next.cab", ScenarioParameterType.Next, ContainerParameterType.CabFile)]
        [InlineData(@"ゴブリンの洞窟Next.zip", ScenarioParameterType.Next, ContainerParameterType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟Next.wsn", ScenarioParameterType.Next, ContainerParameterType.WsnFile)]
        [InlineData(@"ゴブリンの洞窟Wsn", ScenarioParameterType.Wsn, ContainerParameterType.Directory)]
        [InlineData(@"ゴブリンの洞窟Wsn.cab", ScenarioParameterType.Wsn, ContainerParameterType.CabFile)]
        [InlineData(@"ゴブリンの洞窟Wsn.zip", ScenarioParameterType.Wsn, ContainerParameterType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟Wsn.wsn", ScenarioParameterType.Wsn, ContainerParameterType.WsnFile)]
        public void IsScenarioTest(string path, ScenarioParameterType scenarioParameterType, ContainerParameterType containerParameterType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, scenarioParameterType, containerParameterType));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Any));

        }

        [Theory(DisplayName = "Classic形式シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟")]
        [InlineData(@"ゴブリンの洞窟.cab")]
        [InlineData(@"ゴブリンの洞窟.zip")]
        [InlineData(@"ゴブリンの洞窟.wsn")]
        public void IsClassicScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "NEXT形式シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟Next")]
        [InlineData(@"ゴブリンの洞窟Next.cab")]
        [InlineData(@"ゴブリンの洞窟Next.zip")]
        [InlineData(@"ゴブリンの洞窟Next.wsn")]
        public void IsNextScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "WSN形式シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟Wsn")]
        [InlineData(@"ゴブリンの洞窟Wsn.cab")]
        [InlineData(@"ゴブリンの洞窟Wsn.zip")]
        [InlineData(@"ゴブリンの洞窟Wsn.wsn")]
        public void IsWsnScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "ディレクトリ格納シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟")]
        [InlineData(@"ゴブリンの洞窟Next")]
        [InlineData(@"ゴブリンの洞窟Wsn")]
        public void IsDirectoryScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ZIP格納シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟.zip")]
        [InlineData(@"ゴブリンの洞窟Next.zip")]
        [InlineData(@"ゴブリンの洞窟Wsn.zip")]
        public void IsZipFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "CAB格納シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟.cab")]
        [InlineData(@"ゴブリンの洞窟Next.cab")]
        [InlineData(@"ゴブリンの洞窟Wsn.cab")]
        public void IsCabFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "WSN格納シナリオの判定")]
        [InlineData(@"ゴブリンの洞窟.wsn")]
        [InlineData(@"ゴブリンの洞窟Next.wsn")]
        [InlineData(@"ゴブリンの洞窟Wsn.wsn")]
        public void IsWsnFileScenarioTest(string filename)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", filename));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "シナリオが見つからなかったときFalseを返すテスト")]
        [InlineData(@"異常系/そんなシナリオはない")]
        public void IsNotScenarioTest1(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(!File.Exists(fullName) && !Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }

        [Theory(DisplayName = "その他の異常系はすべてFalseを返すテスト")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟.xxx")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟Next")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟Next.xxx")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟Wsn")]
        [InlineData(@"異常系/UnsupportedContainerTypeException/ゴブリンの洞窟Wsn.xxx")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryFileNotFound/ゴブリンの洞窟Empty")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryFileNotFound/ゴブリンの洞窟Empty.cab")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryFileNotFound/ゴブリンの洞窟Empty.zip")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryFileNotFound/ゴブリンの洞窟Empty.wsn")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryWsmInvalid/ゴブリンの洞窟Invalid")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryWsmInvalid/ゴブリンの洞窟Invalid.cab")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryWsmInvalid/ゴブリンの洞窟Invalid.zip")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryWsmInvalid/ゴブリンの洞窟Invalid.wsn")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryXmlInvalid/ゴブリンの洞窟Invalid")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryXmlInvalid/ゴブリンの洞窟Invalid.cab")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryXmlInvalid/ゴブリンの洞窟Invalid.zip")]
        [InlineData(@"異常系/InvalidScenarioException/SummaryXmlInvalid/ゴブリンの洞窟Invalid.wsn")]
        public void IsNotScenarioTest2(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(File.Exists(fullName) || Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }
    }
}
