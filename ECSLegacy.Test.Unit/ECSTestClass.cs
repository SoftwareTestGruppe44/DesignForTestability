using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using NUnit.Framework;

namespace ECSLegacy.Test.Unit
{
    public class ECSTestClass
    {
        private ECS _ecsSystem;
        private FakeHeater _heater;
        private FakeTempSensor _tempSensor;
        private FakeWindow _window;

        [SetUp]
        public void Setup()
        {
            _tempSensor = new FakeTempSensor();
            _heater = new FakeHeater();
            _window = new FakeWindow();
            _ecsSystem = new ECS(10,20, _tempSensor, _heater, _window);
        }

        [Category("Set/Get Threshold")]
        [TestCase(15)]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-5)]
        public void SetAndGetThreshold_ChangeThreshold_ThresholdChanged(int threshold)
        {
            //Arrange
            //Act
            _ecsSystem.SetThreshold(threshold);
            //Assert
            Assert.AreEqual(_ecsSystem.GetThreshold(), threshold);
        }

        [Category("GetCurTemp")]
        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-10)]
        public void GetCurTemp_ChangeTemperatureAndGet_ReturnCorrectTemp(int temp)
        {
            //Arrange
            _tempSensor.Temp = temp;
            //Act
            //Assert
            Assert.AreEqual(_ecsSystem.GetCurTemp(), temp);
        }

        [Category("Regulate - Heater off")]
        [TestCase(10, 10), Description("Temperature is equal to threshold")]
        [TestCase(11, 10)]
        [TestCase(20, 0)]
        [TestCase(30, -5)]
        public void Regulate_TemperatureOverThreshold_ECSTurnOffHeater(int temp, int threshold)
        {
            //Arrange
            _tempSensor.Temp = temp;
            _ecsSystem.SetThreshold(threshold);
            //Act
            _ecsSystem.Regulate();
            //Assert
            Assert.AreEqual(_heater.HeaterOn, false);
        }

        [Category("Regulate - Heater on")]
        [TestCase(8, 10)]
        [TestCase(-4, 0)]
        [TestCase(-10, -5)]
        public void Regulate_TemperatureUnderThreshold_ECSTurnOnHeater(int temp, int threshold)
        {
            //Arrange
            _tempSensor.Temp = temp;
            _ecsSystem.SetThreshold(threshold);
            //Act
            _ecsSystem.Regulate();
            //Assert
            Assert.AreEqual(_heater.HeaterOn, true);
        }

        [Category("Regulate - window closed")]
        [TestCase(20), Description("temp on Threshold")]
        [TestCase(15)]
        [TestCase(0)]
        [TestCase(-10)]
        public void Regulate_TemperatureUnderWindowThreshold_ECSWindowClosed(int temp)
        {
            //Arrange
            _tempSensor.Temp = temp;

            //Act
            _ecsSystem.Regulate();
            //Assert
            Assert.AreEqual(_window.WindowOpen, false);
        }

        [Category("Regulate - window open")]
        [TestCase(25)]
        [TestCase(100)]
        public void Regulate_TemperatureOverWindowThreshold_ECSWindowOpen(int temp)
        {
            //Arrange
            _tempSensor.Temp = temp;

            //Act
            _ecsSystem.Regulate();
            //Assert
            Assert.AreEqual(_window.WindowOpen, true);
        }
    }
}