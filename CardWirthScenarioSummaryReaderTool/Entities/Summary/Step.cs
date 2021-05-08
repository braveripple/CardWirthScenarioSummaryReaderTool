
namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary
{
    /// <summary>
    /// ステップ情報
    /// </summary>
    public sealed class Step
    {
        /// <summary>
        /// ステップ名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// デフォルト値
        /// </summary>
        public int DefaultValue { get; }

        /// <summary>
        /// ステップの内容
        /// </summary>
        public string[] Values { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <param name="values"></param>
        public Step(string name, int defaultValue, string[] values)
        {
            Name = name;
            DefaultValue = defaultValue;
            Values = values;
        }
    }

}