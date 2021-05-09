using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities
{
    /// <summary>
    /// シナリオ格納場所（ディレクトリまたはアーカイブ）のメタ情報クラス
    /// </summary>
    internal sealed class ScenarioMetaData
    {
        /// <summary>
        /// シナリオ格納タイプ
        /// </summary>
        public ContainerType ContainerType { get; }

        /// <summary>
        /// シナリオ格納場所の更新日時
        /// </summary>
        public DateTime LastWriteTime { get; }

        /// <summary>
        /// シナリオ格納場所の絶対パス
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="containerType"></param>
        /// <param name="lastWriteTime"></param>
        /// <param name="fullName"></param>
        public ScenarioMetaData(ContainerType containerType, DateTime lastWriteTime, string fullName)
        {
            ContainerType = containerType;
            LastWriteTime = lastWriteTime;
            FullName = fullName;
        }
    }
}
