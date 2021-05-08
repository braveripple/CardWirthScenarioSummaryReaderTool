using BraveRipple.CardWirthScenarioSummaryReaderTool.Enums;
using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary
{
    /// <summary>
    /// Summary.xmlの解析情報
    /// </summary>
    public sealed class SummaryXml : ISummary
    {
        /// <summary>
        /// シナリオ名
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// 貼り紙の画像ファイルの相対パス
        /// </summary>
        public string[] ImagePaths { get; }

        /// <summary>
        /// 解説
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// 制作者
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// 必要とする称号
        /// </summary>
        public string RequiredCoupons { get; }

        /// <summary>
        /// 必要とする称号の数
        /// </summary>
        public int RequiredCouponCount { get; }

        /// <summary>
        /// データバージョン
        /// </summary>
        public int DataVersion { get; }

        /// <summary>
        /// 開始エリアID
        /// </summary>
        public int StartAreaId { get; }

        /// <summary>
        /// ステップの数
        /// </summary>
        public int StepCount { get; }

        /// <summary>
        /// ステップ情報
        /// </summary>
        public Step[] Steps { get; }

        /// <summary>
        /// フラグの数
        /// </summary>
        public int FlagCount { get; }

        /// <summary>
        /// フラグ情報
        /// </summary>
        public Flag[] Flags { get; }

        /// <summary>
        /// 対象レベル下限値
        /// </summary>
        public int LevelMin { get; }

        /// <summary>
        /// 対象レベル上限値
        /// </summary>
        public int LevelMax { get; }

        /// <summary>
        /// Summary.xmlのファイル更新日時
        /// </summary>
        public DateTime LastWriteTime { get; }

        /// <summary>
        /// Summary.xmlのファイルサイズ
        /// </summary>
        public long Length { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imagePaths"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        /// <param name="requiredCoupons"></param>
        /// <param name="requiredCouponCount"></param>
        /// <param name="dataVersion"></param>
        /// <param name="startAreaId"></param>
        /// <param name="stepCount"></param>
        /// <param name="steps"></param>
        /// <param name="flagCount"></param>
        /// <param name="flags"></param>
        /// <param name="levelMin"></param>
        /// <param name="levelMax"></param>
        /// <param name="lastWriteTime"></param>
        /// <param name="length"></param>
        public SummaryXml(string name,
                          string[] imagePaths,
                          string description,
                          string author,
                          string requiredCoupons,
                          int requiredCouponCount,
                          int dataVersion,
                          int startAreaId,
                          int stepCount,
                          Step[] steps,
                          int flagCount,
                          Flag[] flags,
                          int levelMin,
                          int levelMax,
                          DateTime lastWriteTime,
                          long length)
        {
            Name = name;
            ImagePaths = imagePaths;
            Description = description;
            Author = author;
            RequiredCoupons = requiredCoupons;
            RequiredCouponCount = requiredCouponCount;
            DataVersion = dataVersion;
            StartAreaId = startAreaId;
            StepCount = stepCount;
            Steps = steps;
            FlagCount = flagCount;
            Flags = flags;
            LevelMin = levelMin;
            LevelMax = levelMax;
            LastWriteTime = lastWriteTime;
            Length = length;
        }

        /// <summary>
        /// Summaryファイルのファイル名を文字列として返します。
        /// </summary>
        /// <returns>Summaryファイル名の文字列</returns>
        public override string ToString()
        {
            return "Summary.xml";
        }
    }
}