using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBCCreditParser.Model
{

    /// <summary>
    /// SMBCのCSVデータを表します。
    /// </summary>
    public class SMBCCSV
    {
        /// <summary>
        /// CSV行データ
        /// </summary>
        public List<SMBCCSVItem> Items { get; set; }

        public SMBCCSV()
        {
            Items = new List<SMBCCSVItem>();
        }
    }

    /// <summary>
    /// SMBCのCSVデータの1行のデータを表します。
    /// </summary>
    public class SMBCCSVItem
    {
        /// <summary>
        /// ご利用日
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// ご利用店名
        /// </summary>
        public string StoreName { get; set; }
        
        /// <summary>
        /// ご利用金額
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 支払区分
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 今回の支払回数
        /// </summary>
        public string PaymentCount { get; set; }

        /// <summary>
        /// お支払い金額
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 現地通貨額
        /// </summary>
        public decimal? ForeignAmount { get; set; }

        /// <summary>
        /// 通貨の略称名
        /// </summary>
        public string? ForeignCurrency { get; set; }

        /// <summary>
        /// 換算レート
        /// </summary>
        public decimal? ForeignCurrencyRate { get; set; }

        /// <summary>
        /// 換算日
        /// </summary>
        public DateTime? ForeignCurrencyRateDate { get; set; }
        
        public SMBCCSVItem()
        {
            throw new NotImplementedException();
        }
    }
}
