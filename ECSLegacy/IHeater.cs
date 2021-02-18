namespace ECSLegacy
{
    public interface IHeater
    {
        bool HeaterOn { get; }
        void TurnOn();
        void TurnOff();
        bool RunSelfTest();
    }
}
