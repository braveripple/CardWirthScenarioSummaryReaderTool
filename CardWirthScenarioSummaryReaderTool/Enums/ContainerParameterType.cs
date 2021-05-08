
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
        /// ディレクトリ、ZIP、CAB、WSNのいずれか
        /// </summary>
        Any = 0,

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