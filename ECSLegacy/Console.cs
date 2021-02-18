namespace ECSLegacy
{
    public class Console : IConsole
    {
        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}