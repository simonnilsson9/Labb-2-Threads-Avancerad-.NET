using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2__Threads_Avancerad_.NET
{
    internal class Car
    {
        public string CarName { get; set; }
        public double DistanceTraveled { get; set; }
        public int Speed { get; set; }

        public Car(string carName)
        {
            CarName = carName;
            DistanceTraveled = 0;
            Speed = 120;
        }

        public void RandomEvent()
        {
            Random random = new Random();
            int eventProbability = random.Next(1, 51);

            if (eventProbability <= 2 && eventProbability >= 1)
            {
                Console.WriteLine($"\nThe car: {CarName} is out of gas!! You need to fill up, it will be a delay of 30 seconds.");
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
            else if (eventProbability <= 5 && eventProbability >= 3) 
            {
                Console.WriteLine($"\nThe car: {CarName} has a tire puncture!! It will need to be replaced. Delay of 20 seconds added.");
                Thread.Sleep(TimeSpan.FromSeconds(20));
            }
            else if (eventProbability <= 15 && eventProbability >= 6)
            {
                Console.WriteLine($"\nThe car: {CarName} got dirt on the windshield, clean it up! Delay of 5 seconds added.");
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            else if (eventProbability <= 25 &&  eventProbability >= 15)
            {
                Console.WriteLine($"\nThe car: {CarName} have some minor problems..., the speed decreased to {Speed-1} km/h");
                Speed -= 1;
            }
            else if (eventProbability <= 35 && eventProbability >= 25)
            {
                Console.WriteLine($"\nThe car: {CarName} got more power than we thought!! The speed increased to {Speed+1} km/h");
                Speed += 1;
            }
            else if (eventProbability <= 38 && eventProbability >= 35)
            {
                Console.WriteLine($"\nThe car: {CarName} installed TURBO to it's engine!! The speed increased dramatically to {Speed+10} km/h");
                Speed += 10;
            }
            else
            {
                Console.WriteLine($"\nThe car: {CarName} didn't have any new issues this time.");
            }
        }
    }
}
