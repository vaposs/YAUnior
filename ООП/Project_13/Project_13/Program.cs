using System;
using System.Collections.Generic;

namespace Project_13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CarService carService = new CarService();

            carService.Work();
        }
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static bool GenerateRandomBool(int minRandomNumber, int maxRandomNumber)
        {
            bool result;

            if (s_random.Next(minRandomNumber, maxRandomNumber) < 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }


    class CarService
    {
        private int _serviseMoney = 1000;
        private Queue<Client> _clients = new Queue<Client>();
        private Stock _stock = new Stock();
        private Dictionary<string, int> _breakdowns = new Dictionary<string, int>();
        private Client _currentClient;

        public void Work()
        {
            CreateQueueClient();
            _stock.CreationSpareParts();
            CreateRepairPrice();

            while (_clients.Count > 0)
            {
                _currentClient = _clients.Dequeue();
                Console.WriteLine($"Деньги сервиса - {_serviseMoney}");
                ShowQueue();
                ShowRepairPrice();
                _stock.ShowPart();
                _currentClient.ShowInfo();

                Console.ReadKey();
                Console.Clear();
            }

        }

        private void CreateQueueClient()
        {
            int minPeople = 10;
            int maxPeople = 30;

            int queuePeople = UserUtils.GenerateRandomNumber(minPeople, maxPeople);

            for (int i = 1; i < queuePeople; i++)
            {
                Car car = new Car();
                _clients.Enqueue(new Client(i, car));
            }
        }

        private void ShowQueue()
        {
            Console.WriteLine($"В очереди на ремонт {_clients.Count} клиентов");
        }

        private void CreateRepairPrice()
        {
            int minRepairPrice = 10;
            int maxRepairPrice = 500;

            string[] listBreakdowns = new string[] {"запчасть двигателя", "запчасть стартера", "запчасть генератора", "запчасть електронных блоков", "запчасть инжектора", "колесо", "запчасть кузова", "стекло"};

            for (int i = 0; i < listBreakdowns.Length; i++)
            {
                _breakdowns.Add(listBreakdowns[i], UserUtils.GenerateRandomNumber(minRepairPrice, maxRepairPrice));
            }
        }

        private void ShowRepairPrice()
        {
            Console.WriteLine("Цена за ремонт:");

            foreach (var breakdown in _breakdowns)
            {
                Console.WriteLine($"{breakdown.Key} - {breakdown.Value}");
            }
        }
    }

    class Client
    {
        public Client(int number, Car tranport)
        {
            Number = number;
            Car = new Car();
        }

        public int Number { get; private set; }
        public Car Car { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"клиент под номером {Number}");
            Car.ShowBrecakdown();
        }
    }

    class Car
    {
        private int _minimalRiskBreakdown = 0;
        private int _maximumRiskBreakdown = 2;

        public Car()
        {
            Engine = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            Starter = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            Generator = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            ElectronicUnit = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            Wheel = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            Body = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
            Glass = UserUtils.GenerateRandomBool(_minimalRiskBreakdown, _maximumRiskBreakdown);
        }

        public int Number { get; private set; }
        public bool Engine { get; private set; }
        public bool Starter { get; private set; }
        public bool Generator { get; private set; }
        public bool ElectronicUnit { get; private set; }
        public bool Injector { get; private set; }
        public bool Wheel { get; private set; }
        public bool Body { get; private set; }
        public bool Glass { get; private set; }

        public void ShowBrecakdown()
        {
            Console.WriteLine($"двигатель - {Engine}\nстартер - {Starter}\nгенератор - {Generator}\nелектроника - {ElectronicUnit}\nинжектор - {Injector}\nколесо - {Wheel}\nкорпус - {Body}\nстекла - {Glass}");
        }
    }

    class Stock
    {
        Dictionary<string, int> _parts = new Dictionary<string, int>();
        string[] nameParts = new string[] {"запчасть двигателя", "запчасть стартера", "запчасть генератора", "запчасть електронных блоков", "запчасть для чистки инжектора", "колесо", "запчасть кузова", "стекло"};

        private int _minPart = 3;
        private int _maxPart = 15;

        public void CreationSpareParts()
        {
            for (int i = 0; i < nameParts.Length; i++)
            {
                _parts.Add(nameParts[i],UserUtils.GenerateRandomNumber(_minPart,_maxPart));
            }
        }

        public void ShowPart()
        {
            Console.WriteLine("\nОстаток запчастей на складе:");

            foreach (var part in _parts)
            {
                Console.WriteLine($"{part.Key} - {part.Value}");
            }

            Console.WriteLine("\n");
        }
    }
}


/*

        


        class CarService
        {
            Dictionary<string, int> _breakdowns = new Dictionary<string, int>();

            public void Work()
            {
                UserUtils.CreateListBreakdowns();
                UserUtils.CreateListPart();
                stock.CreationPart();
                CreateQueueClient();
                CreateRepairPrice();
                
                while (_clients.Count > 0) 
                {
                    currentСlient = _clients.Dequeue();
                    Console.WriteLine($"Деньги сервиса - {_serviseMoney}");
                    ShowQueue();
                    ShowPriceRepair();
                    stock.ShowPart();
                    currentСlient.ShowBreakdown();
                    if(stock.GetSparePart(currentСlient.Breakdown))
                    {
                        _serviseMoney += _breakdowns[currentСlient.Breakdown];
                    }
                    else
                    {
                        _serviseMoney -= _breakdowns[currentСlient.Breakdown];

                        if(_serviseMoney < 0)
                        {
                            Console.WriteLine("вы плохой управляющий, сервис разорился");
                            _clients.Clear();
                        }
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                if(_serviseMoney < 0)
                {
                    Console.WriteLine("вы пошли бомжевать");
                }
                else
                {
                    Console.WriteLine("На сегодня клиенты закончились, пора домой");
                }

                Console.ReadKey();
            }
            
            private void ShowPriceRepair()
            {
                Console.WriteLine("\nСтоимость ремонта:");

                foreach (var item in _breakdowns)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            } 
            
            private void CreateQueueClient()
            {
                int minPeople = 970;
                int maxPeople = 1000;

                int queuePeople = UserUtils.GenerateRandomNumber(minPeople, maxPeople);

                for (int i = 1; i < queuePeople; i++)
                {
                    _clients.Enqueue(new Client(i));
                }
            } 
            

            


        }



        

*/