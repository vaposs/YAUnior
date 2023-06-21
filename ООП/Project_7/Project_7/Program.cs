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

    class Train
    {
        public Train(int numberTrain ,int railwayСarriage)
        {
            Number = numberTrain;
            RailwayСarriage = railwayСarriage;
        }

        public int Number { get; private set; }
        public int RailwayСarriage { get; private set; }
    }

    class Route
    {
        public Route(string startingStation, string endStansion , int numberPeopleWantGo, Train train, int carriage)
        {
            NumberPeopleWantGo = numberPeopleWantGo;
            StartingStation = startingStation;
            EndStansion = endStansion;
            Train = train;
            Сarriage = carriage;
        }

        public int NumberPeopleWantGo { get; private set; }
        public string StartingStation { get; private set; }
        public string EndStansion { get; private set; }
        public Train Train { get; private set; }
        public int Сarriage { get; private set; }

        public void Print()
        {
            Console.Write($"\t{StartingStation}\t\t-\t\t{EndStansion}\t\t-\t\t{NumberPeopleWantGo}\t\t-\t\t{Train.Number}\t\t-\t\t{Train.RailwayСarriage}\n");
        }
    }

    class Depot
    {
        List<Route> _route = new List<Route>();
        List<Train> _train = new List<Train>();

        public void StationControl()
        {
            const string CreateRoute = "1";
            const string Exit = "2";

            bool isWork = true;

            while(isWork)
            {
                Console.Clear();

                if (_route.Count == 0)
                {
                    Console.WriteLine("Активных маршрутов нет.\n");
                }
                else
                {
                    PrintFirstLine();
                    foreach (Route route in _route)
                    {
                        route.Print();
                    }
                }

                Console.WriteLine($"\n{CreateRoute}. Сформировать маршрут.");
                Console.WriteLine($"{Exit}. Закончить рабочий день");
                Console.Write("Введите команду - ");
                string command = Console.ReadLine();

                switch(command.ToLower())
                {
                    case CreateRoute:
                        _route.Add(CreateDirection());
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("неверная команда");
                        break;
                }
            }
        }

        private Route CreateDirection()
        {
            string[] town =
            {
                "город-q","город-w","город-e",
                "город-a","город-s","город-d",
                "город-z","город-x","город-c",
                "город-v","город-f","город-r",
            };
            string firstStation = "";
            string lastStation = "";
            int numberPeopleWantGo = 0;
            bool repick = true;
            int maxNumberPeople = 1000;

            Random random = new Random();
            numberPeopleWantGo = random.Next(maxNumberPeople);
            firstStation = town[random.Next(town.Length)];
            while (repick)
            {
                lastStation = town[random.Next(town.Length)];

                if(firstStation == lastStation)
                {
                    lastStation = town[random.Next(town.Length)];
                }
                else
                {
                    repick = false;
                }
            }
            _train.Add(CreateTrain(numberPeopleWantGo));
            Console.WriteLine(_train.Count);

            return new Route(firstStation, lastStation, numberPeopleWantGo, _train[_train.Count - 1], _train[_train.Count - 1].RailwayСarriage);
        }

        private Train CreateTrain(int numberPeopleWantGo)
        {
            int sizeСarriage = 200;
            int carriage;

            carriage = numberPeopleWantGo / sizeСarriage;

            if(numberPeopleWantGo / sizeСarriage > 0)
            {
                carriage++;
            }
            else if(carriage == 0)
            {
                carriage++;
            }

            Train tempTrain = new Train(_train.Count, carriage);

            return tempTrain;
        }

        private void PrintFirstLine()
        {
            Console.Write("Начальная станция");
            Console.Write("\t-\t");
            Console.Write("Конечная станция");
            Console.Write("\t-\t");
            Console.Write("Желающие ехать");
            Console.Write("\t\t-\t");
            Console.Write("Номер поезда");
            Console.Write("\t\t-\t");
            Console.Write("Количество вагонов\n");


        }
    }
}
