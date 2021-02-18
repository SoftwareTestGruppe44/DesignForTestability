namespace ECSLegacy
{
    public class Heater : IHeater
    {
        private IConsole _console;
        public bool HeaterOn { get; private set; } = false;
        public Heater()
        {
            _console = new Console();
        }
        public Heater(IConsole console)
        {
            _console = console;
            
        }
        public void TurnOn()
        {
            _console.WriteLine("Heater is on");
            HeaterOn = true;
        }

        public void TurnOff()
        {
            _console.WriteLine("Heater is off");
            HeaterOn = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}