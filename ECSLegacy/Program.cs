using System;

namespace ECSLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            ITempSensor tempsensor = new TempSensor();
            IHeater heater = new Heater();
            var ecs = new ECS(28, tempsensor, heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
