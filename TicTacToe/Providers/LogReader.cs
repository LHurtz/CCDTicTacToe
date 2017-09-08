using System.Collections.Generic;
using System.IO;

namespace TicTacToe.Providers
{
    internal static class LogReader
    {
        public static List<(int x, int y)> ReadReplayFile(string fileName)
        {
            var fileLines = File.ReadAllLines(fileName);

            var coordinates = ParseCoordinatesFromFileLines(fileLines);

            return coordinates;
        }

        internal static List<(int x, int y)> ParseCoordinatesFromFileLines(string[] fileLines)
        {
            var coordinates = new List<(int x, int y)>();

            foreach (var line in fileLines)
            {
                var separator = new[] {';'};
                var values = line.Split(separator);

                var x = int.Parse(values[0]);
                var y = int.Parse(values[1]);

                var coordinate = (x, y);

                coordinates.Add(coordinate);
            }

            return coordinates;
        }
    }
}