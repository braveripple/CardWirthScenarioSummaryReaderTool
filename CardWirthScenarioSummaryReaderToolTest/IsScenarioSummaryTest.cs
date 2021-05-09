using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.IsScenarioSummary�̃e�X�g<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ContainerParameterType)"/><br />
    /// </summary>
    public class IsScenarioSummaryTest : ScenarioSummaryTestBase
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public IsScenarioSummaryTest() : base("�e�X�g�f�[�^/")
        {
        }

        [Theory(DisplayName = "�V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A", ScenarioParameterType.Classic, ContainerParameterType.Directory)]
        [InlineData(@"�S�u�����̓��A.cab", ScenarioParameterType.Classic, ContainerParameterType.CabFile)]
        [InlineData(@"�S�u�����̓��A.zip", ScenarioParameterType.Classic, ContainerParameterType.ZipFile)]
        [InlineData(@"�S�u�����̓��A.wsn", ScenarioParameterType.Classic, ContainerParameterType.WsnFile)]
        [InlineData(@"�S�u�����̓��ANext", ScenarioParameterType.Next, ContainerParameterType.Directory)]
        [InlineData(@"�S�u�����̓��ANext.cab", ScenarioParameterType.Next, ContainerParameterType.CabFile)]
        [InlineData(@"�S�u�����̓��ANext.zip", ScenarioParameterType.Next, ContainerParameterType.ZipFile)]
        [InlineData(@"�S�u�����̓��ANext.wsn", ScenarioParameterType.Next, ContainerParameterType.WsnFile)]
        [InlineData(@"�S�u�����̓��AWsn", ScenarioParameterType.Wsn, ContainerParameterType.Directory)]
        [InlineData(@"�S�u�����̓��AWsn.cab", ScenarioParameterType.Wsn, ContainerParameterType.CabFile)]
        [InlineData(@"�S�u�����̓��AWsn.zip", ScenarioParameterType.Wsn, ContainerParameterType.ZipFile)]
        [InlineData(@"�S�u�����̓��AWsn.wsn", ScenarioParameterType.Wsn, ContainerParameterType.WsnFile)]
        public void IsScenarioTest(string path, ScenarioParameterType scenarioParameterType, ContainerParameterType containerParameterType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, scenarioParameterType, containerParameterType));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Any));

        }

        [Theory(DisplayName = "Classic�`���V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A")]
        [InlineData(@"�S�u�����̓��A.cab")]
        [InlineData(@"�S�u�����̓��A.zip")]
        [InlineData(@"�S�u�����̓��A.wsn")]
        public void IsClassicScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "NEXT�`���V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��ANext")]
        [InlineData(@"�S�u�����̓��ANext.cab")]
        [InlineData(@"�S�u�����̓��ANext.zip")]
        [InlineData(@"�S�u�����̓��ANext.wsn")]
        public void IsNextScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "WSN�`���V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��AWsn")]
        [InlineData(@"�S�u�����̓��AWsn.cab")]
        [InlineData(@"�S�u�����̓��AWsn.zip")]
        [InlineData(@"�S�u�����̓��AWsn.wsn")]
        public void IsWsnScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next, ContainerParameterType.Any));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn, ContainerParameterType.Any));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Classic));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Next));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Wsn));

        }

        [Theory(DisplayName = "�f�B���N�g���i�[�V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A")]
        [InlineData(@"�S�u�����̓��ANext")]
        [InlineData(@"�S�u�����̓��AWsn")]
        public void IsDirectoryScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "ZIP�i�[�V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A.zip")]
        [InlineData(@"�S�u�����̓��ANext.zip")]
        [InlineData(@"�S�u�����̓��AWsn.zip")]
        public void IsZipFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "CAB�i�[�V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A.cab")]
        [InlineData(@"�S�u�����̓��ANext.cab")]
        [InlineData(@"�S�u�����̓��AWsn.cab")]
        public void IsCabFileScenarioTest(string path)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", path));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "WSN�i�[�V�i���I�̔���")]
        [InlineData(@"�S�u�����̓��A.wsn")]
        [InlineData(@"�S�u�����̓��ANext.wsn")]
        [InlineData(@"�S�u�����̓��AWsn.wsn")]
        public void IsWsnFileScenarioTest(string filename)
        {

            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", filename));

            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.ZipFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.CabFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ScenarioParameterType.Any, ContainerParameterType.WsnFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.Directory));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.CabFile));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.ZipFile));
            Assert.True(CardWirthScenario.IsScenarioSummary(fullName, ContainerParameterType.WsnFile));

        }

        [Theory(DisplayName = "�V�i���I��������Ȃ������Ƃ�False��Ԃ��e�X�g")]
        [InlineData(@"�ُ�n/����ȃV�i���I�͂Ȃ�")]
        public void IsNotScenarioTest1(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(!File.Exists(fullName) && !Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }

        [Theory(DisplayName = "���̑��ُ̈�n�͂��ׂ�False��Ԃ��e�X�g")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��A")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��A.xxx")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��ANext")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��ANext.xxx")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��AWsn")]
        [InlineData(@"�ُ�n/UnsupportedContainerTypeException/�S�u�����̓��AWsn.xxx")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryFileNotFound/�S�u�����̓��AEmpty")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryFileNotFound/�S�u�����̓��AEmpty.cab")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryFileNotFound/�S�u�����̓��AEmpty.zip")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryFileNotFound/�S�u�����̓��AEmpty.wsn")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryWsmInvalid/�S�u�����̓��AInvalid")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryWsmInvalid/�S�u�����̓��AInvalid.cab")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryWsmInvalid/�S�u�����̓��AInvalid.zip")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryWsmInvalid/�S�u�����̓��AInvalid.wsn")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryXmlInvalid/�S�u�����̓��AInvalid")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryXmlInvalid/�S�u�����̓��AInvalid.cab")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryXmlInvalid/�S�u�����̓��AInvalid.zip")]
        [InlineData(@"�ُ�n/InvalidScenarioException/SummaryXmlInvalid/�S�u�����̓��AInvalid.wsn")]
        public void IsNotScenarioTest2(string path)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, path));
            Assert.True(File.Exists(fullName) || Directory.Exists(fullName));
            Assert.False(CardWirthScenario.IsScenarioSummary(fullName));
        }
    }
}
