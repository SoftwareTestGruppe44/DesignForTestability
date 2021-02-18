namespace ECSLegacy
{
    public interface IWindow
    {
        bool WindowOpen { get; }
        void Open() { }
        void Close() { }
    }
}