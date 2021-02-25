using NSubstitute;
using NUnit.Framework;

namespace ECSLegacy.Test.Unit
{
    public class ECSTestClassNSubstitute
    {
        private ECS _ecsSystem;
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private IWindow _window;

        [SetUp]
        public void Setup()
        {
            _tempSensor = Substitute.For<ITempSensor>();
            _heater = Substitute.For<IHeater>();
            _window = Substitute.For<IWindow>();
            _ecsSystem = new ECS(10, 100, _tempSensor, _heater, _window);
        }
        [Category("GetCurTemp")]
        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-10)]
        public void GetCurTemp_ChangeTemperatureAndGet_ReturnCorrectTemp(int temp)
        {
            //Arrange
            _tempSensor.GetTemp().Returns(temp);
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
            _tempSensor.GetTemp().Returns(temp);
            _ecsSystem.SetThreshold(threshold);
            
            //Act
            _ecsSystem.Regulate();
            //Assert
            _heater.Received(1).TurnOff();
        }
        [Category("Regulate")]
        [TestCase(8, 10)]
        [TestCase(-4, 0)]
        [TestCase(-10, -5)]
        public void Regulate_TemperatureUnderThreshold_ECSTurnOnHeater(int temp, int threshold)
        {
            //Arrange
            _tempSensor.GetTemp().Returns(temp);
            _ecsSystem.SetThreshold(threshold);
            //Act
            _ecsSystem.Regulate();
            //Assert
            _heater.Received(1).TurnOn();
        }

    }
}