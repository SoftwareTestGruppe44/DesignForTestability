using NUnit.Framework;

namespace ECSLegacy.Test.Unit
{
    public class TempSensorTestClass
    {
        private ITempSensor _tempSensor;

        [SetUp]
        public void Setup()
        {
            _tempSensor = new TempSensor();
        }

        [Test]
        public void GetTemp_GetCurrentTemp_IsWithinCorrectInterval()
        {
            //Arrange
            bool correct = true;
            //Act
            for (int i = 0; i < 100; i++)
            {
                var temp = _tempSensor.GetTemp();
                correct = correct && (temp >= -5 && temp <= 45);
            }
            //Assert
            Assert.IsTrue(correct);
        }
    }
}