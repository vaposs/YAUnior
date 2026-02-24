using System;
using System.Collections.Generic;

namespace Project_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Depot depot = new Depot();
            depot.StationControl();
        }
    }

    class Carriage
    {
        public Carriage(int capacity)
        {
            Сapacity = capacity;
        }

        public int Сapacity { get; private set; }
    }

    class Train
    {
        private List<Carriage> _carriages;
        private Route _route;
        private int _passengerCount;

        public Train(int number, List<Carriage> carriages, Route route, int passengerCount)
        {
            Number = number;
            _carriages = carriages;
            _route = route;
            _passengerCount = passengerCount;
        }

        public int Number { get; private set; }
        public IReadOnlyList<Carriage> Carriages => _carriages;
        public Route Route => _route;
        public int PassengerCount => _passengerCount;
        public int CarriageCount => _carriages.Count;
    }

    class Route
    {
        public Route(string startingStation, string endStation)
        {
            StartingStation = startingStation;
            EndStation = endStation;
        }

        public string StartingStation { get; private set; }
        public string EndStation { get; private set; }

        public void Print()
        {
            Console.Write($"{StartingStation}\t\t-\t\t{EndStation}");
        }
    }

    class Depot
    {
        private List<Train> _trains = new List<Train>();

        public void StationControl()
        {
            const string CreateRoute = "1";
            const string Exit = "2";

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();

                if (_trains.Count == 0)
                {
                    Console.WriteLine("Активных поездов нет.\n");
                }
                else
                {
                    PrintAllTrains();
                }

                Console.WriteLine($"\n{CreateRoute}. Сформировать поезд.");
                Console.WriteLine($"{Exit}. Закончить рабочий день");
                Console.Write("Введите команду - ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case CreateRoute:
                        CreateTrain();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
        }

        private void CreateTrain()
        {
            Route route = CreateRandomRoute();
            int passengerCount = UserUtility.GetRandomNumber(1, 1000);
            int carriageCapacity = 50;
            int carriageCount = CalculateCarriageCount(passengerCount, carriageCapacity);

            List<Carriage> carriages = new List<Carriage>();

            for (int i = 0; i < carriageCount; i++)
            {
                carriages.Add(new Carriage(carriageCapacity));
            }

            Train train = new Train(_trains.Count + 1, carriages, route, passengerCount);
            _trains.Add(train);

            Console.WriteLine($"Создан поезд #{train.Number} с {train.CarriageCount} вагонами");
            Console.WriteLine($"Маршрут: {route.StartingStation} -> {route.EndStation}");
            Console.WriteLine($"Пассажиров: {passengerCount}");
            Console.ReadKey();
        }

        private Route CreateRandomRoute()
        {
            string[] towns =
            {
                "Москва", "Санкт-Петербург", "Казань",
                "Екатеринбург", "Новосибирск", "Владивосток",
                "Сочи", "Краснодар", "Ростов-на-Дону",
                "Нижний Новгород", "Самара", "Челябинск"
            };

            string firstStation = towns[UserUtility.GetRandomNumber(0, towns.Length)];
            string lastStation;

            do
            {
                lastStation = towns[UserUtility.GetRandomNumber(0, towns.Length)];
            }
            while (firstStation == lastStation);

            return new Route(firstStation, lastStation);
        }

        private int CalculateCarriageCount(int passengerCount, int carriageCapacity)
        {
            int carriageCount = passengerCount / carriageCapacity;

            if (passengerCount % carriageCapacity != 0)
            {
                carriageCount++;
            }

            return carriageCount;
        }

        private void PrintAllTrains()
        {
            PrintHeader();

            foreach (Train train in _trains)
            {
                Console.Write($"#{train.Number}\t|\t");
                train.Route.Print();
                Console.Write($"\t|\t{train.PassengerCount}\t\t|\t{train.CarriageCount}\n");
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("Номер\t|\tМаршрут\t\t\t|\tПассажиры\t|\tВагоны");
            Console.WriteLine("--------|-----------------------|-----------------------|-----------");
        }
    }

    static class UserUtility
    {
        private static Random _random = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
