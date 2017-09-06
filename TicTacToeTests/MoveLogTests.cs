using System;
using System.IO;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class MoveLogTests
    {
        [SetUp]
        public void Setup()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test]
        public void WriteMove_legt_LogFile_mit_korrektem_Inhalt_an()
        {
            var logFileName = MoveLog.StartNewLog();

            MoveLog.WriteMove((1, 2));

            var fileContent = File.ReadAllLines(logFileName);

            Assert.That(fileContent.Length, Is.EqualTo(1));
            Assert.That(fileContent[0], Is.EqualTo("1;2"));
        }
    }
}
