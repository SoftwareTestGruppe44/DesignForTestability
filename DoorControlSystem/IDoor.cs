namespace DoorControlSystem
{
    public interface IDoor
    {
        public DoorControl Control { get; set; }
        public bool DoorIsOpen { get; set; }
        void Open();
        void Close();
    }
}