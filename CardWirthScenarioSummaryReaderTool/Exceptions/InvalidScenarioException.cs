using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions
{
    /// <summary>
    /// 不正なシナリオのとき投げる例外<br />
    /// Summaryファイルが見つからなかったり<br />
    /// Summaryファイルの読み込み中に例外が発生した場合はすべてこの例外で対応する<br />
    /// </summary>
    public sealed class InvalidScenarioException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InvalidScenarioException()
            : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public InvalidScenarioException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidScenarioException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
