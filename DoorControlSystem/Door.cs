using System;
using System.Net.Sockets;

namespace DoorControlSystem
{
    public class Door : IDoor
    {
        public DoorControl Control { get; set; }
        public bool DoorIsOpen { get; set; } = false;
        public bool Open()
        {
            if (DoorIsOpen == false) return false;
            DoorIsOpen = true;
            Control.DoorOpened();
            Console.WriteLine("Door Opened");
            return true;
        }
        public bool Close()
        {
            if (DoorIsOpen == false) return false;
            DoorIsOpen = false;
            Control.DoorClosed();
            Console.WriteLine("Door Close");
            return true;
        }
    }
}