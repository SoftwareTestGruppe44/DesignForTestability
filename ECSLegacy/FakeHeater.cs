﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECSLegacy
{
    public class FakeHeater : IHeater
    {
        public bool HeaterOn { get; private set; }
        
        public void TurnOn()
        {
            System.Console.WriteLine("Fake Heater is on");
            HeaterOn = true;
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Fake Heater is off");
            HeaterOn = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
