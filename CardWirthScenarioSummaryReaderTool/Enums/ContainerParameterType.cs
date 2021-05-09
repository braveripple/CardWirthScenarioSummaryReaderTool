
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Enums
{
    /// <summary>
    /// シナリオの格納形式<br />
    /// シナリオ判定APIのパラメーター用<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ContainerParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// </summary>
    public enum ContainerParameterType
    {
        /// <summary>
        /// ディレクトリ、CAB、ZIP、WSNのいずれか
        /// </summary>
        Any = 0,

        /// <summary>
        /// ディレクトリ
        /// </summary>
        Directory,

        /// <summary>
        /// CAB
        /// </summary>
        CabFile,

        /// <summary>
        /// ZIP
        /// </summary>
        ZipFile,

        /// <summary>
        /// WSN
        /// </summary>
        WsnFile
    }

}