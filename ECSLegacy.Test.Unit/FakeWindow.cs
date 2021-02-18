namespace ECSLegacy.Test.Unit
{
    public class FakeWindow : IWindow
    {
        public bool WindowOpen { get; private set; }

        public void Open()
        {
            System.Console.WriteLine("Window is open");
            WindowOpen = true;
        }

        public void Close()
        {
            System.Console.WriteLine("Window is closed");
            WindowOpen = false;
        }
    }
}