namespace ECSLegacy
{
    public interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
}