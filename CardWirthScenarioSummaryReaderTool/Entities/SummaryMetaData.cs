using System;
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities
{
    /// <summary>
    /// Summaryファイルのファイルメタ情報クラス
    /// </summary>
    internal sealed class SummaryMetaData
    {
        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime LastWriteTime { get; }

        /// <summary>
        /// ファイルサイズ
        /// </summary>
        public long Length { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="lastWriteTime"></param>
        /// <param name="length"></param>
        public SummaryMetaData(DateTime lastWriteTime, long length)
        {
            LastWriteTime = lastWriteTime;
            Length = length;
        }
    }
}
