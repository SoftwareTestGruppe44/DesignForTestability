using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace ECSLegacy.Test.Unit
{
    public class HeaterTestClass
    {
        private IHeater _heater;
        private FakeConsole _fakeConsole;
        [SetUp]
        public void Setup()
        {
            _fakeConsole = new FakeConsole();
            _heater = new Heater(_fakeConsole);
        }

        [Test]
        public void TurnOn_TurnOn_HeaterHasBeenTurnedOn()
        {
            //Arrange
            //Act
            _heater.TurnOn();
            //Assert
            Assert.AreEqual(_fakeConsole.ConsoleLine, "Heater is on");
        }

        [Test]
        public void TurnOff_TurnOff_HeaterHasBeenTurnedOff()
        {
            //Arrange
            //Act
            _heater.TurnOff();
            //Assert
            Assert.AreEqual(_fakeConsole.ConsoleLine, "Heater is off");
        }
    }
}