namespace ECSLegacy
{
    public class Window : IWindow
    {
        private IConsole _console;

        public Window()
        {
            _console = new Console();
        }

        public Window(IConsole console)
        {
            _console = console;
        }

        public void Open()
        {
            _console.WriteLine("Window is open");
        }

        public void Close()
        {
            _console.WriteLine("Window is closed");
        }
    }
}