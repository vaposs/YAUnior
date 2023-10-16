using System;
using System.Collections.Generic;

// для коректной проверки работоспособности нуно поиграться с количеством деталей на складе и количеством клиентов

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

        public static bool GenerateRandomBool()
        {
            return s_random.Next(2) < 1;
        }
    }

    class CarService
    {
        private Stock _stock = new Stock();
        private Dictionary<string, int> _worksPrices;
        private Queue<Client> _clients = new Queue<Client>();
        private int _moneyServise = 1000;

        public void Work()
        {
            Client currentClient;
            Detail brokenDetail;
            Detail detail;
            bool bankrupt = false;
            int costPart;

            CreatePriceWork();
            GreateQueueClients();
            _stock.Create();


            while (_clients.Count > 0)
            {
                Console.WriteLine($"Баланс автосервиса : {_moneyServise}");
                ShowQueue();
                ShowPrice();
                currentClient = _clients.Dequeue();
                currentClient.ShowInfo();
                currentClient.Car.ShowDetails();
                //_stock.ShowParts();   //  для коректного отображения включить!

                while (currentClient.Car.NeedRepair() == true)
                {
                    brokenDetail = currentClient.Car.GetBrokenDetail();
                    detail = _stock.GetDetail(brokenDetail.Name);
                    _worksPrices.TryGetValue(brokenDetail.Name, out costPart);

                    if (detail == null)
                    {
                        Console.Write($"\n{brokenDetail.Name} закончилась на складе ");
                        Console.Write($"автосервис выплатил штраф {costPart}");
                        _moneyServise -= costPart;
                    }
                    else
                    {
                        Console.Write($"\n{brokenDetail.Name} отремонтирована");

                        _moneyServise += costPart;
                    }

                    currentClient.Car.GhangeStatus(brokenDetail);

                    if (_moneyServise < 0)
                    {
                        Console.WriteLine("\nБАНКРОТ");
                        Console.ReadKey();
                        bankrupt = true;
                        break;
                    }
                }

                if(bankrupt == true)
                {
                    break;
                }

                Console.WriteLine("\n\nавтомобиль после ремонта:");
                currentClient.Car.ShowDetails();
                Console.WriteLine("нажмите любую кнопку для продолжения ...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Деньги автосервиса - {_moneyServise}");
            Console.WriteLine("конец");
            Console.ReadKey();
        }

        private void CreatePriceWork()
        {
            _worksPrices = new Dictionary<string, int>()
            {
                ["Engine"] = 100,
                ["Starter"] = 100,
                ["Generator"] = 100,
                ["ElectronicUnit"] = 100,
                ["Injector"] = 100,
                ["Wheel"] = 100,
                ["Body"] = 100,
                ["Glass"] = 100
            };
        }

        private void ShowPrice()
        {
            int index = 1;

            foreach (var namePrise in _worksPrices)
            {
                Console.WriteLine($"{index++}.{namePrise.Key} - {namePrise.Value}");
            }
        }

        private void GreateQueueClients()
        {
            int minimumClients = 8;
            int maximumClients = 15;

            int quentClient = UserUtils.GenerateRandomNumber(minimumClients, maximumClients);

            for (int i = 1; i < quentClient; i++)
            {
                _clients.Enqueue(new Client(i));
            }
        }

        private void ShowQueue()
        {
            Console.WriteLine($"Клиентов в очереди - {_clients.Count}\n");
        }
    }

    class Stock
    {
        private List<Detail> _details = new List<Detail>();
        private StockDetailsFactory _stockDetailsFactory = new StockDetailsFactory();

        public void Create()
        {
            int minPartsStock = 10;
            int maxPartsStock = 30;

            _stockDetailsFactory.Create();

            int partsStock = UserUtils.GenerateRandomNumber(minPartsStock,maxPartsStock);

            for (int i = 0; i < partsStock; i++)
            {
                _details.Add(_stockDetailsFactory.GetDetail());
            }
        }

        public void ShowParts()
        {
            Console.WriteLine("\nДетали на складе:");
            foreach (Detail detail in _details)
            {
                Console.WriteLine($"{detail.Name}");
            }
        }

        public Detail GetDetail(string detailName)
        {
            Detail detailGet = null;

            foreach (Detail detail in _details)
            {
                if (detail.Name == detailName)
                {
                    detailGet = detail;
                    _details.Remove(detail);
                    return detailGet;
                }
            }

            return detailGet;
        }
    }

    class Client
    {
        public Client(int number)
        {
            Number = number;
            List<Detail> details = CreateDetails();
            Car = new Car(details);
        }

        private List<Detail> CreateDetails()
        {
            List<Detail> details = new List<Detail>();

            details.Add(new Detail("Engine", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Starter", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Generator", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("ElectronicUnit", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Injector", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Wheel", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Body", UserUtils.GenerateRandomBool()));
            details.Add(new Detail("Glass", UserUtils.GenerateRandomBool()));

            return details;
        }

        public int Number { get; private set; }
        public Car Car { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"\nклиент под номером - {Number}");
        } // вывели номер клиента
    }

    class Car
    {
        public Car(List<Detail> details)
        {
            Details = details;
        }

        public List<Detail> Details { get; private set; }

        public void ShowDetails()
        {
            foreach (Detail detail in Details)
            {
                Console.Write($"{detail.Name} - ");
                detail.ShowStatus();
            }

            Console.WriteLine();
        }

        public bool NeedRepair()
        {
            foreach (Detail detail in Details)
            {
                if(detail.Status == false)
                {
                    return true;
                }
            }

            return false;
        }

        public Detail GetBrokenDetail()
        {
            foreach (Detail detail in Details)
            {
                if (detail.Status == false)
                {
                    return detail;
                }
            }

            return null;
        }

        public void GhangeStatus(Detail inputDetail)
        {
            foreach (Detail detail in Details)
            {
                if (detail.Name == inputDetail.Name)
                {
                    detail.GhangeStatus();
                }
            }
        }
    }

    class Detail
    {
        public Detail(string name, bool status)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; private set; }
        public bool Status { get; private set; }

        public void ShowStatus()
        {
            if(Status == true)
            {
                Console.Write("целая\n");
            }
            else
            {
                Console.Write("сломаная\n");
            }
        }

        public void GhangeStatus()
        {
            Status = true;
        }
    }

    class StockDetailsFactory
    {
        private List<Detail> _spareParts = new List<Detail>();

        public void Create()
        {
            _spareParts.Add(new Detail("Engine", true));
            _spareParts.Add(new Detail("Starter", true));
            _spareParts.Add(new Detail("Generator", true));
            _spareParts.Add(new Detail("ElectronicUnit", true));
            _spareParts.Add(new Detail("Injector", true));
            _spareParts.Add(new Detail("Wheel", true));
            _spareParts.Add(new Detail("Body", true));
            _spareParts.Add(new Detail("Glass", true));

        }

        public Detail GetDetail()
        {
            return _spareParts[UserUtils.GenerateRandomNumber(0,_spareParts.Count)];
        } // возврящаем детать
        
    }

}