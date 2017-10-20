using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Client.Core.Contracts;
using Client.Commands.Contracts;
using Client.Core;

namespace UnitTests.Core
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallWriterWriteMethodWithCommandsResults_WhenInputIsCorrect()
        {
            // Arrange
            string commandInput = "choose 7";
            string exitCommand = "exit";
            string commandResult = "result";
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(commandResult);
            string expectedResult = builder.ToString();

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var commandProcessor = new Mock<ICommandProcessor>();
            var commandMock = new Mock<ICommand>();

            readerMock.SetupSequence(m => m.ReadLine()).Returns(commandInput).Returns(exitCommand);
            parserMock.Setup(m => m.ParseCommand(commandInput)).Returns(commandMock.Object);
            commandMock.Setup(m => m.Execute(It.IsAny<IList<string>>())).Returns(commandResult);

            Engine engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, commandProcessor.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(expectedResult), Times.Once());
        }
    }
}
