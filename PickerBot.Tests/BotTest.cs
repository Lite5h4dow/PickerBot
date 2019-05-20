using System;
using PickerBot;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PickerBot.Tests
{
    [TestClass]
    public class BotTest
    {
        [TestMethod]
        public void TurnLeft()
        {
            var b = new Bot(0, 0, Direction.N);
            b.TurnLeft();

            Assert.Equals(0, b.X);
            Assert.Equals(0, b.Y);
            Assert.Equals(Direction.W, b.Dir);
        }

        [TestMethod]
        public void TurnRight()
        {
            var b = new Bot(0, 0, Direction.N);
            b.TurnRight();

            Assert.Equals(0, b.X);
            Assert.Equals(0, b.Y);
            Assert.Equals(Direction.E, b.Dir);
        }

        [TestMethod]
        public void CreateBot()
        {
            var b = new Bot();
            Assert.Equals(0, b.X);
            Assert.Equals(0, b.Y);
            Assert.Equals(Direction.N, b.Dir);
        }
    }
}