using System;

namespace DoorControlSystem
{
    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted(int id)
        {
            Console.WriteLine($"Entry granted for ID: {id}");
        }

        public void NotifyEntryDenied(int id)
        {
            Console.WriteLine($"Entry denied for ID: {id}");
        }
    }
}