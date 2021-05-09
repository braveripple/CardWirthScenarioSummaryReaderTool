using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Readers
{
    /// <summary>
    /// Summary.xmlのバイナリ情報読み取りクラス
    /// </summary>
    internal sealed class SummaryXmlBinaryReader
    {
        private readonly SummaryXmlBinary _summaryXmlBinary;
        private readonly XDocument _summaryXml;
        private readonly XElement _summaryTag;
        private readonly XElement _propertyTag;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="summaryXmlBinary"></param>
        public SummaryXmlBinaryReader(SummaryXmlBinary summaryXmlBinary)
        {
            _summaryXmlBinary = summaryXmlBinary;
            try
            {
                _summaryXml = XDocument.Parse(_summaryXmlBinary.XmlText);
                _summaryTag = _summaryXml.Root;
                if (_summaryTag.Name != "Summary")
                {
                    // Summaryタグは必須
                    throw new Exception("The Summary.xml file is missing the Summary tag.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // /Summary/Propertyが無ければ作成する
            _propertyTag = _summaryTag.Element("Property");
            if (_propertyTag == null)
            {
                _summaryTag.Add(new XElement("Property"));
            }
        }

        /// <summary>
        /// コンストラクタで設定したバイナリ情報を読み取り、解析情報を取得する
        /// </summary>
        /// <returns></returns>
        public SummaryXml Read()
        {
            return new SummaryXml(
                   this.ReadName(),
                   this.ReadImagePaths(),
                   this.ReadDescription(),
                   this.ReadAuthor(),
                   this.ReadRequiredCoupons(),
                   this.ReadRequiredCouponCount(),
                   this.ReadDataVersion(),
                   this.ReadStartAreaId(),
                   this.ReadStepCount(),
                   this.ReadSteps(),
                   this.ReadFlagCount(),
                   this.ReadFlags(),
                   this.ReadLevelMin(),
                   this.ReadLevelMax(),
                   _summaryXmlBinary.SummaryMetaData.LastWriteTime,
                   _summaryXmlBinary.SummaryMetaData.Length);
        }

        private string ReadName()
        {
            var nameTag = _propertyTag.Element("Name");
            return (nameTag == null ? "" : (string)nameTag);
        }

        private string[] ReadImagePaths()
        {
            return _propertyTag.Descendants("ImagePath").Select(x => x.Value).ToArray();
        }

        private string ReadDescription()
        {
            var descriptionTag = _propertyTag.Element("Description");
            if (descriptionTag == null)
            {
                return "";
            }
            var description = (string)descriptionTag;
            return Regex.Unescape(description);
        }

        private string ReadAuthor()
        {
            var authorTag = _propertyTag.Element("Author");
            return authorTag == null ? "" : (string)authorTag;
        }

        private string ReadRequiredCoupons()
        {
            var requiredCouponsTag = _propertyTag.Element("RequiredCoupons");
            return requiredCouponsTag == null ? "" : (string)requiredCouponsTag;
        }

        private int ReadRequiredCouponCount()
        {
            var requiredCouponsTag = _propertyTag.Element("RequiredCoupons");
            return requiredCouponsTag == null ? 0 : (int)requiredCouponsTag.Attribute("number");
        }
        private int ReadStartAreaId()
        {
            var startAreaIdTag = _propertyTag.Element("StartAreaId");
            return startAreaIdTag == null ? 0 : (int)startAreaIdTag;
        }

        private int ReadDataVersion()
        {
            return (int)_summaryTag.Attribute("dataVersion");
        }

        private int ReadStepCount()
        {
            var stepsTag = _summaryTag.Element("Steps");
            return stepsTag == null ? 0 : stepsTag.Elements("Step").Count();
        }

        private Step[] ReadSteps()
        {
            var stepsTag = _summaryTag.Element("Steps");
            if (stepsTag == null)
            {
                return Array.Empty<Step>();
            }
            return stepsTag.Elements("Step").Select(x => new Step(
                (string)x.Element("Name"),
                (int)x.Attribute("default"),
                x.Elements("Value").Select(y => y.Value).ToArray()
            )).ToArray();
        }

        private int ReadFlagCount()
        {
            var flagsTag = _summaryTag.Element("Flags");
            return flagsTag == null ? 0 : flagsTag.Elements("Flag").Count();
        }

        private Flag[] ReadFlags()
        {
            var flagsTag = _summaryTag.Element("Flags");
            if (flagsTag == null)
            {
                return Array.Empty<Flag>();
            }
            return flagsTag.Elements("Flag").Select(x => new Flag(
                (string)x.Element("Name"),
                (bool)x.Attribute("default"),
                (string)x.Element("True"),
                (string)x.Element("False")
            )).ToArray();
        }

        private int ReadLevelMin()
        {
            var levelTag = _propertyTag.Element("Level");
            return levelTag == null ? 0 : (int)levelTag.Attribute("min");
        }

        private int ReadLevelMax()
        {
            var levelTag = _propertyTag.Element("Level");
            return levelTag == null ? 0 : (int)levelTag.Attribute("max");
        }

    }

}