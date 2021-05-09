using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions
{
    /// <summary>
    /// シナリオのパスがファイルシステム上に見つからなかったとき投げる例外<br />
    /// </summary>
    public sealed class ScenarioNotFoundException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ScenarioNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public ScenarioNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ScenarioNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
