using System;
using SMBCCreditParser.Core;

namespace SMBCCreditParserTest.Core
{

    /// <summary>
    /// CSVデータのヘッダー・詳細の読み込みをテスト
    /// </summary>
    [TestClass]
    public class SMBCCSVRepositoryTest_HeaderAndDetails
    {
        private SMBCCSVRepository _repo = new SMBCCSVRepository();

        private const string propTestContent_1_PaymentMethod = """
            やね　いも　様,4980-03**-****-****,三井住友カードデビュープラスＶＩＳＡ
            2023/08/08,OPENAI (OPENAI.COM ),5540,１,１,554,3.80　USD　145.980　08 08
            2023/07/03,ＰａｙＰａｌ決済,2280,１,１,2280,ＰＡＹＰＡＬ　＊ＧＯＯＧＬＥ　ＹＯＵＴＵ
            2023/07/23,ＡＰＰＬＥ　ＣＯＭ　ＢＩＬＬ,1980,１,１,1980,
            """;

        private const string propTestContent_2_PaymentMethod = """
            やね　いも　様,4980-03**-****-****,三井住友カードデビュープラスＶＩＳＡ
            2023/08/08,OPENAI (OPENAI.COM ),5540,１,１,554,3.80　USD　145.980　08 08
            2023/07/03,ＰａｙＰａｌ決済,2280,１,１,2280,ＰＡＹＰＡＬ　＊ＧＯＯＧＬＥ　ＹＯＵＴＵ
            2023/07/23,ＡＰＰＬＥ　ＣＯＭ　ＢＩＬＬ,1980,１,１,1980,
            やね　いも　様,6900-11**-****-****,ＡｐｐｌｅＰａｙ／ｉＤ
            2023/07/01,ローソン／ｉＤ,214,１,１,214,ﾛ-ｿﾝ ｱﾘﾉﾁﾖｳﾆﾛｳ/ID
            2023/07/30,ユニクロ／ｉＤ,1990,１,１,1990,
            """;

        public SMBCCSVRepositoryTest_HeaderAndDetails()
        {
        }

        [TestMethod]
        public void ヘッダー_詳細の読み込み_1_全体件数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_1_PaymentMethod);

            // Assert
            Assert.AreEqual(1, actual.Items.Count);
        }

        [TestMethod]
        public void ヘッダー_詳細の読み込み_1_詳細件数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_1_PaymentMethod);

            // Assert
            Assert.AreEqual(3, actual.Items[0].Details.Count);
        }

        [TestMethod]
        public void ヘッダー_詳細の読み込み_2_全体件数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_2_PaymentMethod);

            // Assert
            Assert.AreEqual(2, actual.Items.Count);
        }

        [TestMethod]
        public void ヘッダー_詳細の読み込み_2_詳細件数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_2_PaymentMethod);

            // Assert
            Assert.AreEqual(2, actual.Items[0].Details.Count);
        }

    }

}