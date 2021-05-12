using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.GetScenarioSummaryのテスト<br />
    /// <see cref="CardWirthScenario.GetScenarioSummary(string)"/><br />
    /// </summary>
    public class GetScenarioSummaryTest : ScenarioSummaryTestBase
    {
        public GetScenarioSummaryTest() : base("テストデータ/")
        {
        }

        [Theory(DisplayName = "Classic形式のシナリオの解析")]
        [InlineData(@"ゴブリンの洞窟", ContainerType.Directory)]
        [InlineData(@"ゴブリンの洞窟.cab", ContainerType.CabFile)]
        [InlineData(@"ゴブリンの洞窟.zip", ContainerType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟.wsn", ContainerType.WsnFile)]
        public void TestClassic(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Classic, scenarioSummary.ScenarioType);
            Assert.Equal("ゴブリンの洞窟", scenarioSummary.Name);
            Assert.Equal(1, scenarioSummary.LevelMin);
            Assert.Equal(3, scenarioSummary.LevelMax);
            Assert.Equal("齋藤 洋", scenarioSummary.Author);
            Assert.Equal("　町外れの洞窟にゴブリンと思しき妖魔が\r\n住み着いた。夜間に洞窟から抜け出しては\r\n近隣の畑や民家を荒らし、旅人を襲って荷\r\n物を奪うなど、大きな被害が出ている。\r\n\r\n　近隣に住む農民達は共同で金を出し合い\r\n冒険者を雇ってゴブリン退治を依頼するこ\r\nとを決定した…\r\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryWsm>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "Next形式のシナリオの解析")]
        [InlineData(@"ゴブリンの洞窟Next", ContainerType.Directory)]
        [InlineData(@"ゴブリンの洞窟Next.cab", ContainerType.CabFile)]
        [InlineData(@"ゴブリンの洞窟Next.zip", ContainerType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟Next.wsn", ContainerType.WsnFile)]
        public void TestNext(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Next, scenarioSummary.ScenarioType);
            Assert.Equal("ゴブリンの洞窟", scenarioSummary.Name);
            // NextシナリオはstartAreaId以降の情報が取れないので対象レベルは0になる
            Assert.Equal(0, scenarioSummary.LevelMin);
            Assert.Equal(0, scenarioSummary.LevelMax);
            Assert.Equal("齋藤 洋", scenarioSummary.Author);
            Assert.Equal("　町外れの洞窟にゴブリンと思しき妖魔が\r\n住み着いた。夜間に洞窟から抜け出しては\r\n近隣の畑や民家を荒らし、旅人を襲って荷\r\n物を奪うなど、大きな被害が出ている。\r\n\r\n　近隣に住む農民達は共同で金を出し合い\r\n冒険者を雇ってゴブリン退治を依頼するこ\r\nとを決定した…\r\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryWsm>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "WSN形式のシナリオの解析")]
        [InlineData(@"ゴブリンの洞窟Wsn", ContainerType.Directory)]
        [InlineData(@"ゴブリンの洞窟Wsn.cab", ContainerType.CabFile)]
        [InlineData(@"ゴブリンの洞窟Wsn.zip", ContainerType.ZipFile)]
        [InlineData(@"ゴブリンの洞窟Wsn.wsn", ContainerType.WsnFile)]
        public void TestWsn(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "正常系/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Wsn, scenarioSummary.ScenarioType);
            Assert.Equal("ゴブリンの洞窟", scenarioSummary.Name);
            Assert.Equal(1, scenarioSummary.LevelMin);
            Assert.Equal(3, scenarioSummary.LevelMax);
            Assert.Equal("齋藤 洋", scenarioSummary.Author);
            // WSN形式のDescriptionの改行コードはLF。
            Assert.Equal("　町外れの洞窟にゴブリンと思しき妖魔が\n住み着いた。夜間に洞窟から抜け出しては\n近隣の畑や民家を荒らし、旅人を襲って荷\n物を奪うなど、大きな被害が出ている。\n\n　近隣に住む農民達は共同で金を出し合い\n冒険者を雇ってゴブリン退治を依頼するこ\nとを決定した…\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryXml>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "シナリオが見つからなかったとき例外を返すテスト")]
        [InlineData(@"そんなシナリオはない")]
        public void TestScenarioNotFoundException(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/", filename));
            var ex = Assert.Throws<ScenarioNotFoundException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "未対応のシナリオ格納形式、またはファイル拡張子がない場合例外を返すテスト")]
        [InlineData(@"ゴブリンの洞窟")]
        [InlineData(@"ゴブリンの洞窟.xxx")]
        [InlineData(@"ゴブリンの洞窟Next")]
        [InlineData(@"ゴブリンの洞窟Next.xxx")]
        [InlineData(@"ゴブリンの洞窟Wsn")]
        [InlineData(@"ゴブリンの洞窟Wsn.xxx")]
        public void TestUnsupportedContainerTypeException(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/UnsupportedContainerTypeException/", filename));
            var ex = Assert.Throws<UnsupportedContainerTypeException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summaryファイルがない場合例外を返すテスト")]
        [InlineData(@"ゴブリンの洞窟Empty")]
        [InlineData(@"ゴブリンの洞窟Empty.cab")]
        [InlineData(@"ゴブリンの洞窟Empty.zip")]
        [InlineData(@"ゴブリンの洞窟Empty.wsn")]
        public void TestSummaryFileNotFound(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/InvalidScenarioException/SummaryFileNotFound/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summary.wsmファイルの中身が空の場合例外を返すテスト")]
        [InlineData(@"ゴブリンの洞窟Invalid")]
        [InlineData(@"ゴブリンの洞窟Invalid.cab")]
        [InlineData(@"ゴブリンの洞窟Invalid.zip")]
        [InlineData(@"ゴブリンの洞窟Invalid.wsn")]
        public void TestSummaryWsmReadFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/InvalidScenarioException/SummaryWsmInvalid/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summary.xmlファイルの中身が空の場合例外を返すテスト")]
        [InlineData(@"ゴブリンの洞窟Invalid")]
        [InlineData(@"ゴブリンの洞窟Invalid.cab")]
        [InlineData(@"ゴブリンの洞窟Invalid.zip")]
        [InlineData(@"ゴブリンの洞窟Invalid.wsn")]
        public void TestSummaryXmlReadFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/InvalidScenarioException/SummaryXmlInvalid/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "パスワード付きZIPは例外を返すテスト")]
        [InlineData(@"ゴブリンの洞窟Password.zip")]
        [InlineData(@"ゴブリンの洞窟Password.wsn")]
        public void TestPasswordedZipFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "異常系/InvalidScenarioException/PasswordedZip/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }
    }
}
