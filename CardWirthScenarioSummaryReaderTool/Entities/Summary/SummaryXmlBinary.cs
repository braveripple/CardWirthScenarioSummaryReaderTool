namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary
{
    /// <summary>
    /// Summary.xmlのバイナリ情報
    /// </summary>
    internal sealed class SummaryXmlBinary
    {
        /// <summary>
        /// Summary.xmlのテキストデータ
        /// </summary>
        public string XmlText { get; }

        /// <summary>
        /// Summary.xmlのファイルメタ情報
        /// </summary>
        public SummaryMetaData SummaryMetaData { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlText"></param>
        /// <param name="summaryMetaData"></param>
        public SummaryXmlBinary(string xmlText, SummaryMetaData summaryMetaData)
        {
            XmlText = xmlText;
            SummaryMetaData = summaryMetaData;
        }
    }
}