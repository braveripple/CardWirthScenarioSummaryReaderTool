using BraveRipple.CardWirthScenarioSummaryReaderTool;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions;
using System.IO;
using Xunit;
namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    /// <summary>
    /// CardWirthScenario.GetScenarioSummary�̃e�X�g<br />
    /// <see cref="CardWirthScenario.GetScenarioSummary(string)"/><br />
    /// </summary>
    public class GetScenarioSummaryTest : ScenarioSummaryTestBase
    {
        public GetScenarioSummaryTest() : base("�e�X�g�f�[�^/")
        {
        }

        [Theory(DisplayName = "Classic�`���̃V�i���I�̉��")]
        [InlineData(@"�S�u�����̓��A", ContainerType.Directory)]
        [InlineData(@"�S�u�����̓��A.cab", ContainerType.CabFile)]
        [InlineData(@"�S�u�����̓��A.zip", ContainerType.ZipFile)]
        [InlineData(@"�S�u�����̓��A.wsn", ContainerType.WsnFile)]
        public void TestClassic(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Classic, scenarioSummary.ScenarioType);
            Assert.Equal("�S�u�����̓��A", scenarioSummary.Name);
            Assert.Equal(1, scenarioSummary.LevelMin);
            Assert.Equal(3, scenarioSummary.LevelMax);
            Assert.Equal("�V�� �m", scenarioSummary.Author);
            Assert.Equal("�@���O��̓��A�ɃS�u�����Ǝv�����d����\r\n�Z�ݒ������B��Ԃɓ��A���甲���o���Ă�\r\n�ߗׂ̔��▯�Ƃ��r�炵�A���l���P���ĉ�\r\n����D���ȂǁA�傫�Ȕ�Q���o�Ă���B\r\n\r\n�@�ߗׂɏZ�ޔ_���B�͋����ŋ����o������\r\n�`���҂��ق��ăS�u�����ގ����˗����邱\r\n�Ƃ����肵���c\r\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryWsm>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "Next�`���̃V�i���I�̉��")]
        [InlineData(@"�S�u�����̓��ANext", ContainerType.Directory)]
        [InlineData(@"�S�u�����̓��ANext.cab", ContainerType.CabFile)]
        [InlineData(@"�S�u�����̓��ANext.zip", ContainerType.ZipFile)]
        [InlineData(@"�S�u�����̓��ANext.wsn", ContainerType.WsnFile)]
        public void TestNext(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Next, scenarioSummary.ScenarioType);
            Assert.Equal("�S�u�����̓��A", scenarioSummary.Name);
            // Next�V�i���I��startAreaId�ȍ~�̏�񂪎��Ȃ��̂őΏۃ��x����0�ɂȂ�
            Assert.Equal(0, scenarioSummary.LevelMin);
            Assert.Equal(0, scenarioSummary.LevelMax);
            Assert.Equal("�V�� �m", scenarioSummary.Author);
            Assert.Equal("�@���O��̓��A�ɃS�u�����Ǝv�����d����\r\n�Z�ݒ������B��Ԃɓ��A���甲���o���Ă�\r\n�ߗׂ̔��▯�Ƃ��r�炵�A���l���P���ĉ�\r\n����D���ȂǁA�傫�Ȕ�Q���o�Ă���B\r\n\r\n�@�ߗׂɏZ�ޔ_���B�͋����ŋ����o������\r\n�`���҂��ق��ăS�u�����ގ����˗����邱\r\n�Ƃ����肵���c\r\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryWsm>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "WSN�`���̃V�i���I�̉��")]
        [InlineData(@"�S�u�����̓��AWsn", ContainerType.Directory)]
        [InlineData(@"�S�u�����̓��AWsn.cab", ContainerType.CabFile)]
        [InlineData(@"�S�u�����̓��AWsn.zip", ContainerType.ZipFile)]
        [InlineData(@"�S�u�����̓��AWsn.wsn", ContainerType.WsnFile)]
        public void TestWsn(string filename, ContainerType containerType)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "����n/", filename));
            var scenarioSummary = CardWirthScenario.GetScenarioSummary(fullName);

            Assert.Equal(ScenarioType.Wsn, scenarioSummary.ScenarioType);
            Assert.Equal("�S�u�����̓��A", scenarioSummary.Name);
            Assert.Equal(1, scenarioSummary.LevelMin);
            Assert.Equal(3, scenarioSummary.LevelMax);
            Assert.Equal("�V�� �m", scenarioSummary.Author);
            // WSN�`����Description�̉��s�R�[�h��LF�B
            Assert.Equal("�@���O��̓��A�ɃS�u�����Ǝv�����d����\n�Z�ݒ������B��Ԃɓ��A���甲���o���Ă�\n�ߗׂ̔��▯�Ƃ��r�炵�A���l���P���ĉ�\n����D���ȂǁA�傫�Ȕ�Q���o�Ă���B\n\n�@�ߗׂɏZ�ޔ_���B�͋����ŋ����o������\n�`���҂��ق��ăS�u�����ގ����˗����邱\n�Ƃ����肵���c\n", scenarioSummary.Description);
            Assert.Equal(containerType, scenarioSummary.ContainerType);
            Assert.Equal(File.GetLastWriteTime(fullName), scenarioSummary.LastWriteTime);
            Assert.Equal(fullName, scenarioSummary.FullName);
            Assert.IsType<SummaryXml>(scenarioSummary.SummaryInfo);
        }

        [Theory(DisplayName = "�V�i���I��������Ȃ������Ƃ���O��Ԃ��e�X�g")]
        [InlineData(@"����ȃV�i���I�͂Ȃ�")]
        public void TestScenarioNotFoundException(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/", filename));
            var ex = Assert.Throws<ScenarioNotFoundException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "���Ή��̃V�i���I�i�[�`���A�܂��̓t�@�C���g���q���Ȃ��ꍇ��O��Ԃ��e�X�g")]
        [InlineData(@"�S�u�����̓��A")]
        [InlineData(@"�S�u�����̓��A.xxx")]
        [InlineData(@"�S�u�����̓��ANext")]
        [InlineData(@"�S�u�����̓��ANext.xxx")]
        [InlineData(@"�S�u�����̓��AWsn")]
        [InlineData(@"�S�u�����̓��AWsn.xxx")]
        public void TestUnsupportedContainerTypeException(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/UnsupportedContainerTypeException/", filename));
            var ex = Assert.Throws<UnsupportedContainerTypeException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summary�t�@�C�����Ȃ��ꍇ��O��Ԃ��e�X�g")]
        [InlineData(@"�S�u�����̓��AEmpty")]
        [InlineData(@"�S�u�����̓��AEmpty.cab")]
        [InlineData(@"�S�u�����̓��AEmpty.zip")]
        [InlineData(@"�S�u�����̓��AEmpty.wsn")]
        public void TestSummaryFileNotFound(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/InvalidScenarioException/SummaryFileNotFound/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summary.wsm�t�@�C���̒��g����̏ꍇ��O��Ԃ��e�X�g")]
        [InlineData(@"�S�u�����̓��AInvalid")]
        [InlineData(@"�S�u�����̓��AInvalid.cab")]
        [InlineData(@"�S�u�����̓��AInvalid.zip")]
        [InlineData(@"�S�u�����̓��AInvalid.wsn")]
        public void TestSummaryWsmReadFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/InvalidScenarioException/SummaryWsmInvalid/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "Summary.xml�t�@�C���̒��g����̏ꍇ��O��Ԃ��e�X�g")]
        [InlineData(@"�S�u�����̓��AInvalid")]
        [InlineData(@"�S�u�����̓��AInvalid.cab")]
        [InlineData(@"�S�u�����̓��AInvalid.zip")]
        [InlineData(@"�S�u�����̓��AInvalid.wsn")]
        public void TestSummaryXmlReadFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/InvalidScenarioException/SummaryXmlInvalid/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }

        [Theory(DisplayName = "�p�X���[�h�t��ZIP�͗�O��Ԃ��e�X�g")]
        [InlineData(@"�S�u�����̓��APassword.zip")]
        [InlineData(@"�S�u�����̓��APassword.wsn")]
        public void TestPasswordedZipFailed(string filename)
        {
            var fullName = Path.GetFullPath(Path.Combine(TestDirPath, "�ُ�n/InvalidScenarioException/PasswordedZip/", filename));
            var ex = Assert.Throws<InvalidScenarioException>(() =>
            {
                CardWirthScenario.GetScenarioSummary(fullName);
            });
        }
    }
}
