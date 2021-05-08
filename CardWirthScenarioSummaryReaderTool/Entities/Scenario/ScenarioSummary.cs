using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System;
using System.IO;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Scenario
{
    /// <summary>
    /// シナリオ概要
    /// </summary>
    public sealed class ScenarioSummary
    {
        /// <summary>
        /// シナリオ形式
        /// </summary>
        public ScenarioType ScenarioType { get; }
        
        /// <summary>
        /// 対象レベル下限値
        /// </summary>
        public int LevelMin { get; }
        
        /// <summary>
        /// 対象レベル上限値
        /// </summary>
        public int LevelMax { get; }
        
        /// <summary>
        /// シナリオ名
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// 制作者
        /// </summary>
        public string Author { get; }
        
        /// <summary>
        /// 解説
        /// </summary>
        public string Description { get; }
        
        /// <summary>
        /// Summaryファイル情報
        /// </summary>
        public ISummary SummaryInfo { get; }
        
        /// <summary>
        /// シナリオ格納形式
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
        /// <param name="scenarioType"></param>
        /// <param name="levelMin"></param>
        /// <param name="levelMax"></param>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="description"></param>
        /// <param name="summaryInfo"></param>
        /// <param name="containerType"></param>
        /// <param name="lastWriteTime"></param>
        /// <param name="fullName"></param>
        public ScenarioSummary(ScenarioType scenarioType,
                               int levelMin,
                               int levelMax,
                               string name,
                               string author,
                               string description,
                               ISummary summaryInfo,
                               ContainerType containerType,
                               DateTime lastWriteTime,
                               string fullName)
        {
            ScenarioType = scenarioType;
            LevelMin = levelMin;
            LevelMax = levelMax;
            Name = name;
            Author = author;
            Description = description;
            SummaryInfo = summaryInfo;
            ContainerType = containerType;
            LastWriteTime = lastWriteTime;
            FullName = fullName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Path.GetFileName(FullName) + "(" + Author + ")";
        }
    }
}