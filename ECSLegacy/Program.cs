using System;

namespace ECSLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            ITempSensor tempsensor = new TempSensor();
            IHeater heater = new Heater();
            IWindow window = new Window();
            var ecs = new ECS(28, 40,tempsensor, heater, window);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
