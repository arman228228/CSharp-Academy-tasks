using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Car[] fleet = new Car[]
            {
                new Car("Ferrari", 2024),
                new Car("Mercedes", 2020),
                new Car("Porsche", 2019),
                new Car("Bugatti", 2023),
                new Car("McLaren", 2015)
            };

            bool exit = false;
            while (!exit)
            {
                Car.CarList(fleet);
                
                Console.WriteLine("Enter car number, to rent or return car or enter 0 to exit:");

                int carNumber = int.Parse(Console.ReadLine());

                if (carNumber == 0)
                {
                    exit = true;

                    Console.WriteLine("Program closed.");
                    continue;
                }

                if (carNumber < 1 || carNumber >= fleet.Length)
                {
                    Console.WriteLine("Incorrect number.");
                }

                carNumber--;
                
                bool nestedExit = false;

                while (!nestedExit)
                {
                    Console.WriteLine($"Selected car: {carNumber + 1}, enter 1 to rent. 2 to return, 3 to back");
                    
                    int process = int.Parse(Console.ReadLine());

                    switch (process)
                    {
                        case 1:
                            fleet[carNumber].RentCar();

                            break;
                        case 2:
                            fleet[carNumber].ReturnCar();

                            break;
                        case 3:
                            nestedExit = true;
                            
                            Console.WriteLine("Back.");

                            break;
                        default:
                            Console.WriteLine("Incorrect number.");
                            
                            break;
                    }
                }
            }
        }
    }
    class Car
    {
        public string Model { get;  }
        public int Year { get; }
        public bool IsRented { get; private set; }

        public Car(string model, int year, bool isRented = false)
        {
            Model = model;
            Year = year;
            IsRented = isRented;
        }
        
        public bool RentCar()
        {
            if (IsRented)
            {
                Console.WriteLine("Car already rented.");
                return false;
            }

            IsRented = true;
            
            Console.WriteLine("Car rented.");

            return true;
        }

        public bool ReturnCar()
        {
            if (!IsRented)
            {
                Console.WriteLine("Car not rented.");
                return false;
            }

            IsRented = false;

            Console.WriteLine("Car returned.");
            
            return true;
        }

        public static void CarList(Car[] fleet)
        {
            for(int i = 0; i < fleet.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Model: {fleet[i].Model}, year: {fleet[i].Year}, rented: {fleet[i].IsRented}");
            }
        }
    }
}