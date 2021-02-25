using System;

namespace DoorControlSystem
{
    public class Alarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.WriteLine("*** ALARM RAISE *** ");
            Console.WriteLine("*** CALLING 911 *** ");
        }
    }
}