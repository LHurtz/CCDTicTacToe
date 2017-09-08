using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe.Providers;

namespace TicTacToeTests
{
    [TestFixture]
    public class LogReaderTests
    {
        [Test]
        public void ParseCoordinates_parsed_Zeilen_zu_Koordinaten_Tupeln()
        {
            var inputLines = new List<string>
            {
                "1;1",
                "0;1",
                "2;2"
            }.ToArray();

            var expected = new List<(int x, int y)>
            {
                (1, 1),
                (0, 1),
                (2, 2)
            };

            var result = LogReader.ParseCoordinatesFromFileLines(inputLines);

            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}