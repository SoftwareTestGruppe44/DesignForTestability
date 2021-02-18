using System;
using System.Collections.Generic;
using System.Text;

namespace ECSLegacy
{
    class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
