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
            var correct = true;
            var min = false;
            var max = false;
            //Act
            for (var i = 0; i < 1000000; i++)
            {
                var temp = _tempSensor.GetTemp();
                correct = correct && (temp >= -5 && temp < 45);
                if (temp == -5)
                {
                    min = true;
                }
                if (temp == 44)
                {
                    max = true;
                }
            }
            //Assert
            Assert.IsTrue(correct&&min&&max);
        }
    }
}