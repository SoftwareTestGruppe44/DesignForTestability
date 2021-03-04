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
            _ecsSystem = new ECS(10, 20,_tempSensor, _heater, _window);
        }

        [Category("Set/Get Threshold")] 
        [TestCase(Int32.MaxValue)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Int32.MinValue)]
        public void SetAndGetThreshold_ChangeThreshold_ThresholdChanged(int threshold)
        {
            //Arrange
            //Act
            _ecsSystem.SetThreshold(threshold);
            //Assert
            Assert.AreEqual(_ecsSystem.GetThreshold(), threshold);
        }


        [Category("GetCurTemp")]
        [TestCase(Int32.MaxValue)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Int32.MinValue)]
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
        [TestCase(0, -1)]
        [TestCase(20, 0)]
        [TestCase(-4, -5)]
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
        [TestCase(9, 10)]
        [TestCase(0, 1)]
        [TestCase(-1, 0)]
        [TestCase(-6, -5)]
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