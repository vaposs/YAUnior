using System;
using System.Collections.Generic;
using System.Linq;

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
        private static bool[] s_boolValues = { false, true };

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static bool GenerateRandomBool()
        {
            return s_boolValues[GenerateRandomNumber(0, s_boolValues.Length)];
        }
    }

    class CarService
    {
        private const string YesCommand = "да";
        private const int RefusalPenalty = 500;
        private const int PenaltyPerDetail = 100;
        private const int MinCarsInQueue = 3;
        private const int MaxCarsInQueue = 6;

        private Stock _stock;
        private Dictionary<string, int> _repairPrices;
        private Queue<Car> _cars = new Queue<Car>();
        private int _money = 2000;

        private DetailsFactory _detailsFactory;

        public CarService()
        {
            _detailsFactory = new DetailsFactory();
            InitializeRepairPrices();
            _stock = new Stock(_detailsFactory.CreateAllDetailTypes());
            CreateCarsQueue();
        }

        public void Work()
        {
            while (_cars.Count > 0 && _money > 0)
            {
                Console.Clear();
                ShowServiceStatus();

                Car currentCar = _cars.Peek();
                Console.WriteLine($"\nМашина {currentCar.Id} на ремонте:");
                currentCar.ShowDetails();

                if (AskForRepairRefusal())
                {
                    HandleRefusal(currentCar);
                    continue;
                }

                RepairCar(currentCar);
            }

            ShowFinalResult();
        }

        private bool AskForRepairRefusal()
        {
            Console.WriteLine($"\nОтказаться от ремонта? ({YesCommand}/нет)");
            string input = Console.ReadLine()?.ToLower();
            return input == YesCommand;
        }

        private void HandleRefusal(Car car)
        {
            if (car.GetFixedDetailsCount() == 0)
            {
                _money -= RefusalPenalty;
                Console.WriteLine($"\nОтказ до ремонта. Штраф: {RefusalPenalty}");
            }
            else
            {
                int unfixedCount = car.GetBrokenDetailsCount();
                int penalty = unfixedCount * PenaltyPerDetail;
                _money -= penalty;
                Console.WriteLine($"\nОтказ во время ремонта. Штраф за {unfixedCount} непочиненных деталей: {penalty}");
            }

            _cars.Dequeue();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        private void RepairCar(Car car)
        {
            Detail brokenDetail = car.GetFirstBrokenDetail();

            if (brokenDetail == null)
            {
                CompleteRepair(car);
                return;
            }

            Console.WriteLine($"\nНеобходимо заменить: {brokenDetail.Name}");

            Detail detailFromStock = _stock.TakeDetail(brokenDetail.Name);

            if (detailFromStock == null)
            {
                HandleMissingDetail(brokenDetail);
            }
            else
            {
                ReplaceDetail(car, brokenDetail, detailFromStock);
            }

            if (car.IsFullyRepaired())
            {
                CompleteRepair(car);
            }
        }

        private void ReplaceDetail(Car car, Detail oldDetail, Detail newDetail)
        {
            car.ReplaceDetail(oldDetail, newDetail);
            int repairCost = _repairPrices[oldDetail.Name];
            _money += repairCost;

            Console.WriteLine($"Деталь {oldDetail.Name} заменена. Получено: {repairCost}");
        }

        private void HandleMissingDetail(Detail brokenDetail)
        {
            int penalty = _repairPrices[brokenDetail.Name];
            _money -= penalty;
            Console.WriteLine($"Детали {brokenDetail.Name} нет на складе. Штраф: {penalty}");
        }

        private void CompleteRepair(Car car)
        {
            Console.WriteLine($"\nМашина {car.Id} полностью отремонтирована!");
            _cars.Dequeue();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        private void ShowServiceStatus()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("            АВТОСЕРВИС");
            Console.WriteLine("======================================");
            Console.WriteLine($"Баланс: {_money} руб.");
            Console.WriteLine($"Очередь машин: {_cars.Count}");
            Console.WriteLine($"Детали на складе: {_stock.GetDetailsCount()}");
            Console.WriteLine("--------------------------------------");

            _stock.ShowDetails();
            Console.WriteLine("--------------------------------------");
            ShowRepairPrices();
        }

        private void InitializeRepairPrices()
        {
            _repairPrices = new Dictionary<string, int>
            {
                ["Engine"] = 500,
                ["Starter"] = 300,
                ["Generator"] = 350,
                ["ElectronicUnit"] = 400,
                ["Injector"] = 250,
                ["Wheel"] = 200,
                ["Body"] = 600,
                ["Glass"] = 300
            };
        }

        private void ShowRepairPrices()
        {
            Console.WriteLine("Стоимость ремонта деталей:");
            foreach (var price in _repairPrices)
            {
                Console.WriteLine($"  {price.Key}: {price.Value} руб.");
            }
        }

        private void CreateCarsQueue()
        {
            int carsCount = UserUtils.GenerateRandomNumber(MinCarsInQueue, MaxCarsInQueue + 1);

            for (int i = 1; i <= carsCount; i++)
            {
                _cars.Enqueue(new Car(i, _detailsFactory.CreateRandomDetailsSet()));
            }
        }

        private void ShowFinalResult()
        {
            Console.Clear();
            Console.WriteLine("======================================");

            if (_money <= 0)
            {
                Console.WriteLine("АВТОСЕРВИС ОБАНКРОТИЛСЯ!");
            }
            else
            {
                Console.WriteLine("РАБОЧИЙ ДЕНЬ ЗАВЕРШЕН");
                Console.WriteLine($"Итоговый баланс: {_money} руб.");
            }

            Console.WriteLine("======================================");
            Console.ReadKey();
        }
    }

    class Stock
    {
        private List<Detail> _details;

        public Stock(List<Detail> details)
        {
            _details = new List<Detail>(details);
        }

        public Detail TakeDetail(string detailName)
        {
            Detail foundDetail = _details.FirstOrDefault(detail => detail.Name == detailName);

            if (foundDetail != null)
            {
                _details.Remove(foundDetail);
            }

            return foundDetail;
        }

        public void ShowDetails()
        {
            if (_details.Count == 0)
            {
                Console.WriteLine("Склад пуст");
                return;
            }

            Console.WriteLine("Детали на складе:");
            var groupedDetails = _details.GroupBy(detail => detail.Name)
                                         .Select(group => new { Name = group.Key, Count = group.Count() });

            foreach (var detailGroup in groupedDetails)
            {
                Console.WriteLine($"  {detailGroup.Name}: {detailGroup.Count} шт.");
            }
        }

        public int GetDetailsCount()
        {
            return _details.Count;
        }
    }

    class Car
    {
        private List<Detail> _details;

        public int Id { get; private set; }

        public Car(int id, List<Detail> details)
        {
            Id = id;
            _details = new List<Detail>(details);
        }

        public IReadOnlyList<Detail> Details => _details.AsReadOnly();

        public void ShowDetails()
        {
            Console.WriteLine($"Состояние машины {Id}:");

            var detailsGroups = _details.GroupBy(detail => detail.Name)
                                        .Select(group => new {
                                            Name = group.Key,
                                            Total = group.Count(),
                                            Broken = group.Count(detail => detail.IsBroken)
                                        });

            foreach (var detailGroup in detailsGroups)
            {
                string status = detailGroup.Broken == 0 ? "✓" : $"✗ ({detailGroup.Broken} сломано)";
                Console.WriteLine($"  {detailGroup.Name}: {detailGroup.Total} шт. {status}");
            }
        }

        public Detail GetFirstBrokenDetail()
        {
            return _details.FirstOrDefault(detail => detail.IsBroken);
        }

        public int GetBrokenDetailsCount()
        {
            return _details.Count(detail => detail.IsBroken);
        }

        public int GetFixedDetailsCount()
        {
            return _details.Count(detail => !detail.IsBroken);
        }

        public bool IsFullyRepaired()
        {
            return _details.All(detail => !detail.IsBroken);
        }

        public void ReplaceDetail(Detail oldDetail, Detail newDetail)
        {
            int index = _details.FindIndex(detail => detail == oldDetail);

            if (index != -1)
            {
                _details[index] = newDetail;
            }
        }
    }

    class Detail
    {
        public Detail(string name, bool isBroken)
        {
            Name = name;
            IsBroken = isBroken;
        }

        public string Name { get; private set; }
        public bool IsBroken { get; private set; }
    }

    class DetailsFactory
    {
        private List<Detail> _availableDetailTypes;

        public DetailsFactory()
        {
            _availableDetailTypes = new List<Detail>
            {
                new Detail("Engine", false),
                new Detail("Starter", false),
                new Detail("Generator", false),
                new Detail("ElectronicUnit", false),
                new Detail("Injector", false),
                new Detail("Wheel", false),
                new Detail("Body", false),
                new Detail("Glass", false)
            };
        }

        public List<Detail> CreateAllDetailTypes()
        {
            List<Detail> details = new List<Detail>();

            foreach (Detail detailType in _availableDetailTypes)
            {
                details.Add(new Detail(detailType.Name, isBroken: false));
            }

            return details;
        }

        public List<Detail> CreateRandomDetailsSet()
        {
            List<Detail> details = new List<Detail>();
            int minCopies = 1;
            int maxCopies = 4;

            foreach (Detail detailType in _availableDetailTypes)
            {
                int copies = UserUtils.GenerateRandomNumber(minCopies, maxCopies);

                for (int i = 0; i < copies; i++)
                {
                    bool isBroken = UserUtils.GenerateRandomBool();
                    details.Add(new Detail(detailType.Name, isBroken));
                }
            }

            return details;
        }
    }
}
