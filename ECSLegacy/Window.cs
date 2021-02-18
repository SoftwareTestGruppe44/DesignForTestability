using System.Dynamic;

namespace ECSLegacy
{
    public class Window : IWindow
    {
        private IConsole _console;
        public bool WindowOpen { get; private set; } = false;

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
            WindowOpen = true;

        }

        public void Close()
        {
            _console.WriteLine("Window is closed");
            WindowOpen = false;
        }
    }
}