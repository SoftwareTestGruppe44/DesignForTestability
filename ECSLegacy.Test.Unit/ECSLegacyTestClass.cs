using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using NUnit.Framework;

namespace ECSLegacy.Test.Unit
{
    public class ECSLegacyTestClass
    {
        private ECS _ecsSystem;
        private FakeHeater _heater;
        private FakeTempSensor _tempSensor;

        [SetUp]
        public void Setup()
        {
            _tempSensor = new FakeTempSensor();
            _heater = new FakeHeater();
            _ecsSystem = new ECS(10, _tempSensor, _heater);
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

        [Category("Regulate")]
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

        [Category("Regulate")]
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
    }
}