using SMBCCreditParser.Model;
using NLog;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace SMBCCreditParser.Core
{
	public class SMBCCSVRepository
	{
		private Logger _logger = LogManager.GetCurrentClassLogger();

		public SMBCCSVRepository()
		{
			// Shift-JISを登録
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

		/// <summary>
		/// 与えられたファイルの内容から、SMBCのCSVデータをパースして返します。
		/// </summary>
		/// <param name="fileInfo"></param>
		/// <returns></returns>
		public SMBCCSV GetSMBCCSV(FileInfo fileInfo) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// CSVストリームから、SMBCのCSVデータをパースして返します。
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public SMBCCSV GetSMBCCSV(Stream stream,Encoding? encode = null) {

			Encoding parseEncode = Encoding.GetEncoding("shift_jis");
            if (encode != null)
			{
				parseEncode = encode;
			}

			var ret = new SMBCCSV();

            using (var parser = new TextFieldParser(stream,parseEncode)) {
				parser.TextFieldType = FieldType.Delimited;
				parser.SetDelimiters(",");

				string[] currentRow;
				while (!parser.EndOfData) {
					try
					{
						currentRow = parser.ReadFields()!;

						if(currentRow.Length == 3)
						{
							_logger.Debug("支払い手段についての情報行のため取り込みスキップ：{@currentRow}",currentRow);
							continue;
						}
						else if(currentRow.Length != 7) {
                            _logger.Error("行データの項目数が不正です。行番号:{parser.LineNumber}, エラーデータ:{@currentRow}",parser.LineNumber,currentRow);

                            // 7つ以外はフォーマットエラー
                            throw new ApplicationException($"行データの項目数が不正です。行番号:{parser.LineNumber},	エラーデータ:{currentRow}");
						}

						var addData = new SMBCCSVItem();

                        // データを割り当て
                        var addDataDetail = new SMBCCSVItemDetail();

                        addDataDetail.Date = DateTime.Parse(currentRow[0]);
                        addDataDetail.StoreName = currentRow[1];
						addDataDetail.Amount = decimal.Parse(currentRow[2]);
						addDataDetail.PaymentType = currentRow[3];
						addDataDetail.PaymentCount = currentRow[4];
						addDataDetail.PaymentAmount = decimal.Parse(currentRow[5]);

                        // 備考・外貨情報
                        var foreignCurrencyInfo = currentRow[6].Split('　');
                        if (foreignCurrencyInfo.Length == 4) {
                            // 外貨情報
                            addDataDetail.ForeignAmount = decimal.Parse(foreignCurrencyInfo[0]);
							addDataDetail.ForeignCurrency = foreignCurrencyInfo[1];
							addDataDetail.ForeignCurrencyRate = decimal.Parse(foreignCurrencyInfo[2]);

							var rateDateInfo = foreignCurrencyInfo[3].Split(' ');
                            addDataDetail.ForeignCurrencyRateDate = new DateTime(addDataDetail.Date.Year, int.Parse(rateDateInfo[0]), int.Parse(rateDateInfo[1]));
						}
						else {
                            // 備考
                            addDataDetail.Note = currentRow[6];
                        }

						addData.Details.Add(addDataDetail);

						ret.Items.Add(addData);
					}catch(MalformedLineException malformEx) {
						_logger.Error(malformEx);
						throw;
					}
				}
			}
			return ret;
		}

		/// <summary>
		/// テキスト文字列から、SMBCのCSVデータをパースして返します。
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public SMBCCSV GetSMBCCSV(string content, Encoding? encode = null) {
            Encoding parseEncode = Encoding.GetEncoding("shift_jis");
            if (encode != null)
            {
                parseEncode = encode;
            }

			// 文字列をメモリストリームに変換
			var strStream = new MemoryStream(parseEncode.GetBytes(content));
			
			return GetSMBCCSV(strStream, encode);
		}
    }
}

