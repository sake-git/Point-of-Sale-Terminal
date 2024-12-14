

namespace Point_of_Sale.ErrorLogging
{
    internal static class Logger
    {
        static string logFilePath = "log.txt";
        public static void LogError(string message)
        {
            using(StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine($"Exception occured at {new DateTime()} : {message}");
            }
        }
    }
}
