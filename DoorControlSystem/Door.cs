namespace DoorControlSystem
{
    public class Door : IDoor
    {

        public bool DoorIsOpen { get; private set; } = false;

        public void Open()
        {
            DoorIsOpen = true;
        }

        public void Close()
        {
            DoorIsOpen = false;
        }
    }
}