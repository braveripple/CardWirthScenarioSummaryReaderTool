﻿
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary
{
    /// <summary>
    /// フラグ情報
    /// </summary>
    public sealed class Flag
    {
        /// <summary>
        /// フラグ名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// デフォルト値
        /// </summary>
        public bool Default { get; }

        /// <summary>
        /// TRUEの場合の値
        /// </summary>
        public string TrueValue { get; }

        /// <summary>
        /// FALSEの場合の値
        /// </summary>
        public string FalseValue { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        public Flag(string name, bool defaultValue, string trueValue, string falseValue)
        {
            Name = name;
            Default = defaultValue;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

    }
}