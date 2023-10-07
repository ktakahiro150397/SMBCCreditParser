using SMBCCreditParser.Model;
using NLog;

namespace SMBCCreditParser.Core
{
	public class SMBCCSVRepository
	{
		private Logger _logger = LogManager.GetCurrentClassLogger();

		public SMBCCSVRepository()
		{
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
		public SMBCCSV GetSMBCCSV(Stream stream) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// テキスト文字列から、SMBCのCSVデータをパースして返します。
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public SMBCCSV GetSMBCCSV(string content) {
			throw new NotImplementedException();
		}
    }
}

