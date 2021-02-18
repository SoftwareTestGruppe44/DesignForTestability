namespace ECSLegacy
{
    public class Heater : IHeater
    {
        private IConsole _console;

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
        }

        public void TurnOff()
        {
            _console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}