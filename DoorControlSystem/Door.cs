using System;
using System.Net.Sockets;

namespace DoorControlSystem
{
    public class Door : IDoor
    {
        public DoorControl Control { get; set; }
        public bool DoorIsOpen { get; set; } = false;
        public void Open()
        {
            if (DoorIsOpen == false)
            {
                DoorIsOpen = true;
                Console.WriteLine("Door Opened");
                Control.DoorOpened();
            }
            else
            {
                Console.WriteLine("Door couldnt open");
            }
        }
        public void Close()
        {
            if (DoorIsOpen == true)
            {
                DoorIsOpen = false;
                Control.DoorClosed();
            }
            Console.WriteLine("Door Close");
        }
    }
}