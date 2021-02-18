namespace ECSLegacy.Test.Unit
{
    public class FakeHeater : IHeater
    {
        private IConsole _console;
        public bool HeaterOn { get; private set; }

        public FakeHeater()
        {
            _console = new Console();
        }
        public FakeHeater(IConsole console)
        {
            _console = console;

        }

        public void TurnOn()
        {
            _console.WriteLine("Fake Heater is on");
            HeaterOn = true;
        }

        public void TurnOff()
        {
            _console.WriteLine("Fake Heater is off");
            HeaterOn = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}