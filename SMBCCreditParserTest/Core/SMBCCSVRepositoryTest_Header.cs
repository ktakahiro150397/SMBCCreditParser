using System;
using SMBCCreditParser.Core;

namespace SMBCCreditParserTest.Core
{

    /// <summary>
    /// CSVデータのヘッダー値を個別にテスト
    /// </summary>
    [TestClass]
    public class SMBCCSVRepositoryTest_Header
    {
        private SMBCCSVRepository _repo = new SMBCCSVRepository();

        private const string propTestContent = """
			やね　いも　様,4980-03**-****-****,三井住友カードデビュープラスＶＩＳＡ
			2023/08/08,OPENAI (OPENAI.COM ),5540,１,１,554,3.80　USD　145.980　08 08
			""";
       
        public SMBCCSVRepositoryTest_Header()
        {
        }

        [TestMethod]
        public void 正常データ_プロパティ確認_名前()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("やね　いも　様", actual.Items[0].Header.PaymentUserName);
        }

        [TestMethod]
        public void 正常データ_プロパティ確認_支払い手段の番号()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("4980-03**-****-****", actual.Items[0].Header.PaymentMethodIdentifier);
        }

        [TestMethod]
        public void 正常データ_プロパティ確認_支払い手段の名前()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("三井住友カードデビュープラスＶＩＳＡ", actual.Items[0].Header.PaymentMethodName);
        }



    }

}