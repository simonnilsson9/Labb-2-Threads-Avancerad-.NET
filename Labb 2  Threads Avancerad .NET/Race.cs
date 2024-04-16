using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2__Threads_Avancerad_.NET
{
    
    internal class Race
    {
        public List<Car> cars = new List<Car>();
        public double RaceDistance = 5000.0;
        public int EventInterval = 30;
        public Dictionary<string, TimeSpan> finishTimes = new Dictionary<string, TimeSpan>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void StartRace()
        {
            List<Thread> threads = new List<Thread>();
            DateTime startTime = DateTime.Now;

            foreach (Car car in cars)
            {
                Thread thread = new Thread(() => RunRace(car, startTime));
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            
        }

        public void RunRace(Car car, DateTime startTime)
        {
            int secondsPassed = 0;
            Console.WriteLine($"The car: {car.CarName} has started the race!");

            while (car.DistanceTraveled < RaceDistance)
            {
                Thread.Sleep(1000);
                secondsPassed += 1;
                car.DistanceTraveled += car.Speed / 3600.0 * 1000;

                if (secondsPassed % EventInterval == 0)
                {
                    car.RandomEvent();
                }

                if (car.DistanceTraveled >= RaceDistance)
                {
                    TimeSpan finishTime = DateTime.Now - startTime;
                    lock (finishTimes)
                    {
                        finishTimes[car.CarName] = finishTime;
                    }
                    Console.WriteLine($"\nThe car: {car.CarName} has finished the race!");
                    if (finishTimes.Count == 1)
                    {
                        Console.WriteLine($"{car.CarName} wins the race!");
                    }
                    if (finishTimes.Count == cars.Count)
                    {
                        Console.WriteLine("Race has been completed.");
                        DisplayResults();
                    }
                    break;
                }               
            }
        }

        public void CheckRaceStatus()
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"\nCar: {car.CarName}\nDistance: {Math.Round(car.DistanceTraveled)} meters\nSpeed: {car.Speed} km/h");
            }
        }

        public void DisplayResults()
        {
            var sortedResults = finishTimes.OrderBy(ft => ft.Value).ToList();
            Console.WriteLine("\nRace Results:");
            for (int i = 0; i < sortedResults.Count; i++)
            {
                string place = $"{i + 1}: {sortedResults[i].Key}, Time: {sortedResults[i].Value.TotalSeconds} seconds";
                Console.WriteLine(place);
            }
        }
    }
}
