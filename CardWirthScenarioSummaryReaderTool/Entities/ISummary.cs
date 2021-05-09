using System;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities
{
    /// <summary>
    /// Summaryファイルの解析情報を扱うインターフェース
    /// </summary>
    public interface ISummary
    {
        /// <summary>
        /// シナリオ名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 解説
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 制作者
        /// </summary>
        string Author { get; }

        /// <summary>
        /// 必要とする称号
        /// </summary>
        string RequiredCoupons { get; }

        /// <summary>
        /// 必要とする称号の数
        /// </summary>
        int RequiredCouponCount { get; }

        /// <summary>
        /// データバージョン
        /// </summary>
        int DataVersion { get; }

        /// <summary>
        /// 開始エリアID
        /// </summary>
        int StartAreaId { get; }

        /// <summary>
        /// ステップの数
        /// </summary>
        int StepCount { get; }

        /// <summary>
        /// ステップ情報
        /// </summary>
        Step[] Steps { get; }

        /// <summary>
        /// フラグの数
        /// </summary>
        int FlagCount { get; }

        /// <summary>
        /// フラグ情報
        /// </summary>
        Flag[] Flags { get; }

        /// <summary>
        /// 対象レベル下限値
        /// </summary>
        int LevelMin { get; }

        /// <summary>
        /// 対象レベル上限値
        /// </summary>
        int LevelMax { get; }

        /// <summary>
        /// Summaryファイルのファイル更新日時
        /// </summary>
        DateTime LastWriteTime { get; }

        /// <summary>
        /// Summaryファイルのファイルサイズ
        /// </summary>
        long Length { get; }

    }
}