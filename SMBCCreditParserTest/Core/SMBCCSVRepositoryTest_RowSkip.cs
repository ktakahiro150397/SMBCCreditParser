﻿using System;
using SMBCCreditParser.Core;

namespace SMBCCreditParserTest.Core
{

    /// <summary>
    /// CSVデータのスキップすべき行を確認
    /// </summary>
    [TestClass]
    public class SMBCCSVRepositoryTest_RowSkip
    {
        private SMBCCSVRepository _repo = new SMBCCSVRepository();

        private const string propTestContent = """
			やね　いも　様,4980-03**-****-****,三井住友カードデビュープラスＶＩＳＡ
			2023/08/08,OPENAI (OPENAI.COM ),5540,１,１,554,3.80　USD　145.980　08 08
			""";

        private const string propTestContent_Note = """
			やね　いも　様,4980-03**-****-****,三井住友カードデビュープラスＶＩＳＡ
			2023/08/13,セブン−イレブン／ｉＤ,129,１,１,129,ｾﾌﾞﾝｲﾚﾌﾞﾝﾊ-ﾄｲﾝJRｱ/ID
			""";

        public SMBCCSVRepositoryTest_RowSkip() {
        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_データ件数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(1, actual.Items.Count);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_1_ご利用日()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(new DateTime(2023, 8, 8), actual.Items[0].Date);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_2_ご利用店名()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("OPENAI (OPENAI.COM )", actual.Items[0].StoreName);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_3_ご利用金額()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(5540M, actual.Items[0].Amount);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_4_支払い区分()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("１", actual.Items[0].PaymentType);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_5_今回回数()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("１", actual.Items[0].PaymentCount);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_6_お支払い金額()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(554M, actual.Items[0].PaymentAmount);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報あり_備考()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("", actual.Items[0].Note);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報あり_1_現地通貨額()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(3.8M, actual.Items[0].ForeignAmount);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報あり_2_略称名()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual("USD", actual.Items[0].ForeignCurrency);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報あり_3_換算レート()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(145.98M, actual.Items[0].ForeignCurrencyRate);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報あり_4_換算日()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent);

            // Assert
            Assert.AreEqual(new DateTime(2023,8,8), actual.Items[0].ForeignCurrencyRateDate);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報なし_備考()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_Note);

            // Assert
            Assert.AreEqual("ｾﾌﾞﾝｲﾚﾌﾞﾝﾊ-ﾄｲﾝJRｱ/ID", actual.Items[0].Note);

        }


        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報なし_1_現地通貨額()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_Note);

            // Assert
            Assert.IsNull(actual.Items[0].ForeignAmount);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報なし_2_略称名()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_Note);

            // Assert
            Assert.IsNull(actual.Items[0].ForeignCurrency);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報なし_3_換算レート()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_Note);

            // Assert
            Assert.IsNull(actual.Items[0].ForeignCurrencyRate);

        }

        [TestMethod]
        public void 行スキップデータ_プロパティ確認_7_外貨情報なし4_換算日()
        {
            // Act
            var actual = _repo.GetSMBCCSV(propTestContent_Note);

            // Assert
            Assert.IsNull( actual.Items[0].ForeignCurrencyRateDate);

        }


    }

}