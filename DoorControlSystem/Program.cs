using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DoorControlSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlarm alarm = new Alarm();
            IDoor door = new Door();
            IEntryNotification notification = new EntryNotification();
            IUserValidation userValidation = new UserValidation();
            userValidation.AddId(10);
            DoorControl control = new DoorControl(alarm,door,notification,userValidation);
            door.DoorIsOpen = false;
            control.RequestEntry(10);
            Thread.Sleep(10);
            control.RequestEntry(15);


        }
    }
}
