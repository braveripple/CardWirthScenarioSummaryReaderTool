
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Enums
{
    /// <summary>
    /// シナリオの格納形式
    /// </summary>
    public enum ContainerType
    {
        /// <summary>
        /// 未設定
        /// </summary>
        None = 0,

        /// <summary>
        /// ディレクトリ
        /// </summary>
        Directory,

        /// <summary>
        /// ZIP
        /// </summary>
        ZipFile,

        /// <summary>
        /// CAB
        /// </summary>
        CabFile,

        /// <summary>
        /// WSN
        /// </summary>
        WsnFile
    }

}