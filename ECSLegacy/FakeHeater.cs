using System;
using System.Collections.Generic;
using System.Text;

namespace ECSLegacy
{
    class FakeHeater : IHeater
    {
        public void TurnOn()
        {
            System.Console.WriteLine("Fake Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Fake Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
