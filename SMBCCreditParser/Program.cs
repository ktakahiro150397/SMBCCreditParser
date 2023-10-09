using NLog;

namespace SMBCCreditParser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Logger _logger = LogManager.GetCurrentClassLogger();

            _logger.Trace("Trace ログです。");
            _logger.Debug("Debug ログです。");
            _logger.Info("Info ログです。");
            _logger.Warn("Warn ログです。");
            _logger.Error("Error ログです。");
            _logger.Fatal("Fatal ログです。");
        }
    }
}