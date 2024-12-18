

namespace Point_of_Sale.ErrorLogging
{
    internal static class Logger
    {
        static string logFilePath = "log.txt";

        //Exception logging
        public static void LogError(Exception ex) //Log exception
        {
            using(StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine("***********************************************************");
                sw.WriteLine($"Exception occured at {DateTime.Now} : {ex.Message}");
                sw.WriteLine($"Details: {ex.StackTrace}");
                sw.WriteLine("***********************************************************");
            }
        }

        //Message log
        public static void LogError(string message) //Log Error/Message
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine($"Error occured at {DateTime.Now} : {message}");                
            }
        }
    }
}
