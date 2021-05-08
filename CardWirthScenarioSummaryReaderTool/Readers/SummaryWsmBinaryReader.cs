using BraveRipple.CardWirthScenarioSummaryReaderTool.Entities.Summary;
using System;
using System.IO;
using System.Text;

namespace BraveRipple.CardWirthScenarioSummaryReaderTool.Readers
{
    /// <summary>
    /// Summary.wsmのバイナリ情報読み取りクラス
    /// </summary>
    internal sealed class SummaryWsmBinaryReader : IDisposable
    {
        private readonly SummaryWsmBinary _summaryWsmBinary;
        private readonly BinaryReader _reader;

        private static readonly Encoding Encoding = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="summaryWsmBinary"></param>
        public SummaryWsmBinaryReader(SummaryWsmBinary summaryWsmBinary)
        {
            _summaryWsmBinary = summaryWsmBinary;
            _reader = new BinaryReader(new MemoryStream(_summaryWsmBinary.BinaryData));
        }

        /// <summary>
        /// コンストラクタで設定したバイナリ情報を読み取り、解析情報を取得する
        /// </summary>
        /// <returns></returns>
        public SummaryWsm Read()
        {
            byte[] image = this.ReadImage();
            string name = this.ReadName();
            string description = this.ReadDescription();
            string author = this.ReadAuthor();
            string requiredCoupons = this.ReadRequiredCoupons();
            int requiredCouponCount = this.ReadRequiredCouponCount();
            int areaVersion = this.ReadStartAreaIdAndDataVersion();
            int dataVersion = ConvertToDataVersion(areaVersion);
            int startAreaId = ConvertToStartAreaId(areaVersion);

            // これ以降の情報はNext(DataVersion7)では読めないので注意

            int stepCount = this.ReadStepCount();
            Step[] steps = this.ReadSteps(stepCount);
            int flagCount = this.ReadFlagCount();
            Flag[] flags = this.ReadFlags(flagCount);
            this.ReadUnusedData();
            int levelMin = this.ReadLevelMin(dataVersion);
            int levelMax = this.ReadLevelMax(dataVersion);

            return new SummaryWsm(image,
                                  name,
                                  description,
                                  author,
                                  requiredCoupons,
                                  requiredCouponCount,
                                  dataVersion,
                                  startAreaId,
                                  stepCount,
                                  steps,
                                  flagCount,
                                  flags,
                                  levelMin,
                                  levelMax,
                                  _summaryWsmBinary.SummaryMetaData.LastWriteTime,
                                  _summaryWsmBinary.SummaryMetaData.Length);

        }

        private byte[] ReadImage()
        {
            return ReadImageByte();

        }
        private string ReadName()
        {
            return ReadString();
        }

        private string ReadDescription()
        {
            return ReadString();
        }

        private string ReadAuthor()
        {
            return ReadString();
        }

        private string ReadRequiredCoupons()
        {
            return ReadString();
        }

        private int ReadRequiredCouponCount()
        {
            return ReadInt();
        }

        private int ReadStartAreaIdAndDataVersion()
        {
            return ReadInt();
        }

        private static int ConvertToDataVersion(int areaVersion)
        {
            if (areaVersion <= 19999)
            {
                return 0;
            }
            else if (areaVersion <= 39999)
            {
                return 2;
            }
            else if (areaVersion <= 49999)
            {
                return 4;
            }
            else
            {
                return 7;
            }
        }

        private static int ConvertToStartAreaId(int areaVersion)
        {
            if (areaVersion <= 19999)
            {
                return areaVersion - 10000;
            }
            else if (areaVersion <= 39999)
            {
                return areaVersion - 20000;
            }
            else if (areaVersion <= 49999)
            {
                return areaVersion - 40000;
            }
            else
            {
                return areaVersion - 70000;
            }
        }

        private int ReadStepCount()
        {
            return this.ReadInt();

        }

        private Step[] ReadSteps(int stepCount)
        {
            Step[] Steps = new Step[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                string StepName = this.ReadString();
                int StepDefault = this.ReadInt();

                string[] StepValues = new string[10];
                for (int j = 0; j < 10; j++)
                {
                    StepValues[j] = this.ReadString();
                }

                Step Step = new Step(StepName, StepDefault, StepValues);
                Steps[i] = Step;
            }
            return Steps;
        }

        private int ReadFlagCount()
        {
            return this.ReadInt();

        }

        private Flag[] ReadFlags(int flagCount)
        {
            Flag[] Flags = new Flag[flagCount];

            for (int i = 0; i < flagCount; i++)
            {

                string FlagName = this.ReadString();
                bool FlagDefault = this.ReadBoolean();
                string FlagTrueValue = this.ReadString();
                string FlagFalseValue = this.ReadString();

                Flag Flag = new Flag(FlagName, FlagDefault, FlagTrueValue, FlagFalseValue);
                Flags[i] = Flag;
            }

            return Flags;
        }

        private void ReadUnusedData()
        {
            this.ReadInt();
        }

        private int ReadLevelMin(int dataVersion)
        {
            return dataVersion > 0 ? this.ReadInt() : 0;
        }
        private int ReadLevelMax(int dataVersion)
        {
            return dataVersion > 0 ? this.ReadInt() : 0;
        }

        private int ReadInt()
        {
            return this.DWord();
        }

        private byte[] ReadImageByte()
        {
            int imageSize = this.DWord();
            if (imageSize == 0)
            {
                return null;
            }
            return this.Bytes(imageSize);
        }

        private string ReadString()
        {
            int stringSize = this.DWord();
            if (stringSize == 0)
            {
                return null;
            }
            byte[] rawData = this.Bytes(stringSize);
            return Encoding.GetString(rawData).TrimEnd('\0');
        }

        private bool ReadBoolean()
        {
            return this.Byte() == 1;
        }

        private int DWord()
        {
            return _reader.ReadInt32();
        }

        private int Byte()
        {
            return _reader.ReadBytes(1)[0];
        }

        private byte[] Bytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        public void Close()
        {
            _reader.Close();
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }


}