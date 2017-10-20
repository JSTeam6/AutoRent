using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client.Core.Factories;
using Moq;
using Client.Core.Providers;

namespace UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {

        [TestMethod]
        public void InvokesCreateCommand_WhenParametersAreCorrect()
        {
            //Arrange
            string correctInput = "listcars sofia suv";
            var factoryMock = new Mock<ICommandFactory>();
            var commandParserMock = new CommandParser(factoryMock.Object);

            //Act
            commandParserMock.ParseCommand(correctInput);

            //Arrange
            factoryMock.Verify(m => m.GetCommand(correctInput.Split(' ')[0]), Times.Once());
        }
    }
}
