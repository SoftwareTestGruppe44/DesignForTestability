namespace ECSLegacy.Test.Unit
{
    public class FakeConsole : IConsole
    {
        public string ConsoleLine;
        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
            ConsoleLine = line;
        }
    }
}