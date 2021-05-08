using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Exceptions
{
    /// <summary>
    /// シナリオが未対応の格納形式のときに投げる例外<br />
    /// </summary>
    public sealed class UnsupportedContainerTypeException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UnsupportedContainerTypeException()
            : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public UnsupportedContainerTypeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public UnsupportedContainerTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
