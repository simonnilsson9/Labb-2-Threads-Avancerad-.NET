namespace Labb_2__Threads_Avancerad_.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race();

            race.AddCar(new Car("Ferrari"));
            race.AddCar(new Car("Lamborghini"));
            race.AddCar(new Car("Bugatti"));

            Console.WriteLine("Type 'status' to get current race status, or 'exit' to quit the program\n");
            Thread raceThread = new Thread(race.StartRace);
            raceThread.Start();

            while (raceThread.IsAlive)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "status")
                {
                    race.CheckRaceStatus();
                }
                else if (input.ToLower() == "exit")
                {
                    break; 
                }
                
            }

            raceThread.Join();
            

        }
    }
}
