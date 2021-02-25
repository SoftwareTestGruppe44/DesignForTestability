namespace DoorControlSystem
{
    public class Door : IDoor
    {
        public bool DoorIsOpen { get; private set; } = false;
        public bool Open()
        {
            DoorIsOpen = true;
            return true;
        }
        public bool Close()
        {
            DoorIsOpen = false;
            return true;
        }
    }
}