using System.IO;
using System.Text;

namespace BraveRipple.CardWirthScenarioSummaryReaderToolTest
{
    public class ScenarioSummaryTestBase
    {
        public string TestDirPath { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="testDirPath"></param>
        public ScenarioSummaryTestBase(string testDirPath)
        {
            // このコードがないとSummary.wsmのSJISデータの読み取りでエラーになるので入れる
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // テストデータをプロジェクトフォルダ直下に置いているので
            // ビルド前イベントでプロジェクトフォルダのパスを書いたファイルを出力し、それを参照している
            if (File.Exists("ProjectDirPath.txt"))
            {
                using var sr = new StreamReader("ProjectDirPath.txt");
                var projectDirPath = sr.ReadLine().Trim();
                TestDirPath = Path.Combine(projectDirPath, testDirPath);
            }
        }
    }
}