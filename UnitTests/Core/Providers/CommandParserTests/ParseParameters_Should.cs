using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Client.Core.Factories;
using Client.Core.Providers;

namespace UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnsListOfParameters_WhenInputIsCorrect()
        {
            string correctInput = "user bai pesho 3605064939 7392640203 0886427483";
            List<string> subset = new List<String>() { "bai", "pesho", "3605064939", "7392640203", "0886427483" };
            var factoryMock = new Mock<ICommandFactory>();
            var commandParserMock = new CommandParser(factoryMock.Object);

            //Act
            var result = commandParserMock.ParseParameters(correctInput);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(subset[i], result[i]);
            }
        }
    }
}
