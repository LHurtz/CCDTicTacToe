using System;
using System.IO;

namespace TicTacToe
{
    public static class MoveLog
    {
        private static string logFileName;

        internal static string StartNewLog()
        {
            var creationTime = DateTime.Now.ToLocalTime();
            logFileName = $"{creationTime.Year}{creationTime.Month}{creationTime.Day}{creationTime.Hour}{creationTime.Minute}{creationTime.Second}.log";

            return logFileName; 
        }

        internal static void WriteMove((int x, int y) coordinates)
        {
            var line = $"{coordinates.x};{coordinates.y}";
            File.AppendAllLines(logFileName, new []{line});
        }
    }
}
