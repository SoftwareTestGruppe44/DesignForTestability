using System;

namespace ECSLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ecs = new ECS(28);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
