using Microsoft.Extensions.Logging;
using System;

namespace LoggerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ILogger logger = new Logger.AppLogger<Program>("C://Logs//Logger.db");
            try
            {
                logger.LogInformation("To jest pierwsza informacja");
                throw new DivideByZeroException("Nie dziel przez zero");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ojojjoj");
            }
        }
    }
}
