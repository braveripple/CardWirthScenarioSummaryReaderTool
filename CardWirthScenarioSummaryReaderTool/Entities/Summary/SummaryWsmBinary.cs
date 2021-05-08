using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary
{
    /// <summary>
    /// Summary.wsmのバイナリ情報
    /// </summary>
    internal sealed class SummaryWsmBinary
    {
        /// <summary>
        /// Summary.wsmのバイナリデータ
        /// </summary>
        public byte[] BinaryData { get; }

        /// <summary>
        /// Summary.wsmのファイルメタ情報
        /// </summary>
        public SummaryMetaData SummaryMetaData { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="binaryData"></param>
        /// <param name="summaryMetaData"></param>
        public SummaryWsmBinary(byte[] binaryData, SummaryMetaData summaryMetaData)
        {
            BinaryData = binaryData;
            SummaryMetaData = summaryMetaData;
        }
    }
}