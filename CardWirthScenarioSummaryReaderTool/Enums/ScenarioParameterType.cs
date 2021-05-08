
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Enums
{
    /// <summary>
    /// シナリオ形式<br />
    /// シナリオ判定APIのパラメーター用<br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType)"/><br />
    /// <see cref="CardWirthScenario.IsScenarioSummary(string, ScenarioParameterType, ContainerParameterType)"/><br />
    /// </summary>
    public enum ScenarioParameterType
    {
        /// <summary>
        /// クラシック形式、NEXT形式、WSN形式のいずれか
        /// </summary>
        Any = 0,

        /// <summary>
        /// クラシック形式
        /// </summary>
        Classic,

        /// <summary>
        /// NEXT景色
        /// </summary>
        Next,

        /// <summary>
        /// WSN形式
        /// </summary>
        Wsn
    }
}