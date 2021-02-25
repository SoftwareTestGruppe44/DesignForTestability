namespace DoorControlSystem
{
    public interface IDoor
    {
        public DoorControl Control { get; set; }
        public bool DoorIsOpen { get; set; }
        bool Open();
        bool Close();
    }
}