namespace ECSLegacy.Test.Unit
{
    public class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}