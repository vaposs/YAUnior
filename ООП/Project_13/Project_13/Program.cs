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

        class UserUtils
        {
            private static Dictionary<string, string> s_dicrionaryBreakdowns = new Dictionary<string, string>()
            {
                    { "РЕМОНТ ДВИГАТЕЛЕЙ", "запчасть двигателя"},
                    { "РЕМОНТ АКПП", "запчасть АКПП"},
                    { "РЕМОНТ СТАРТЕРОВ", "запчасть стартера"},
                    { "РЕМОНТ ГЕНЕРАТОРОВ", "запчасть генератора"},
                    { "РЕМОНТ ЭЛЕКТРОННЫХ БЛОКОВ", "запчасть електронных блоков"},
                    { "ЧИСТКА ИНЖЕКТОРОВ", "запчасть для чистки инжектора"},
                    { "ШИНОМОНТАЖ", "колесо"},
                    { "КУЗОВНОЙ РЕМОНТ ЛЮБОЙ СЛОЖНОСТИ", "запчасть кузова"},
                    { "ЗАМЕНА СТЕКОЛ", "стекло"},
                    { "ХИМЧИСТКА","набор для химчистки"},
                    { "ПОЛИРОВКА","набор для полировки"}
            };
            private static Random s_random = new Random();
            private static List<string> s_listBreakdowns = new List<string>();
            private static List<string> s_listParts = new List<string>();

            public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
            {
                return s_random.Next(minRandomNumber, maxRandomNumber);
            }

            public static void CreateListBreakdowns()
            {
                foreach (var breakdown in s_dicrionaryBreakdowns)
                {
                    s_listBreakdowns.Add(breakdown.Key);
                }
            }

            public static List<string> GetListBreakdowns()
            {
                return s_listBreakdowns;
            }

            public static void CreateListPart()
            {
                foreach (var part in s_dicrionaryBreakdowns)
                {
                    s_listParts.Add(part.Value);
                }
            }

            public static List<string> GetListPart()
            {
                return s_listParts;
            }

            public static string GetBreakdownClient()
            {
                string breakdown = s_listBreakdowns[GenerateRandomNumber(0, s_listBreakdowns.Count)];

                return breakdown;
             }

            public static string GetNamePart(string breakdown)
            {
                s_dicrionaryBreakdowns.TryGetValue(breakdown, out string part);
                return part;
            }

        }

        class CarService
        {
            private int _serviseMoney = 1000; 
            Stock stock = new Stock();
            Queue<Client> _clients = new Queue<Client>();
            Dictionary<string, int> _breakdowns = new Dictionary<string, int>();
            Client currentСlient;

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
            
            private void ShowQueue()
            {
                Console.WriteLine($"В очереди на ремонт {_clients.Count} клиентов");
            } 
            
            private void CreateRepairPrice()
            {
                int minRepairPrice = 10;
                int maxRepairPrice = 500;

                List<string> listBreakdowns = UserUtils.GetListBreakdowns();

                for (int i = 0; i < listBreakdowns.Count; i++)
                {
                    _breakdowns.Add(listBreakdowns[i], UserUtils.GenerateRandomNumber(minRepairPrice, maxRepairPrice));
                }
            } 

        }

        class Client
        {
            public Client(int number)
            {
                Number = number;
                Breakdown = UserUtils.GetBreakdownClient();
            }

            public int Number { get; private set; }
            public string Breakdown { get; private set; }

            public void ShowBreakdown()
            {
                Console.WriteLine($"\nКлиент №{Number} с поломкой {Breakdown}");
            }
        } 

        class Stock
        {
            Dictionary<string, int> _parts = new Dictionary<string, int>();

            private int _minPart = 3;
            private int _maxPart = 15;

            public bool GetSparePart(string breakdown)
            {
                bool successfulRepair = true;
                string part = UserUtils.GetNamePart(breakdown);

                if (_parts.ContainsKey(part))
                {
                    int currentCount = _parts[part];

                    if (currentCount > 0)
                    {
                        _parts[part]--;
                    }
                    else
                    {
                        successfulRepair = false;
                        Console.WriteLine($"{part} закончилась");
                    }
                }
             
                return successfulRepair;
            }

            public void ShowPart()
            {
                Console.WriteLine("\nОстаток запчастей на складе:");
                foreach (var part in _parts)
                {
                    Console.WriteLine($"{part.Key} в количестве - {part.Value}");
                }
            } 

            public void CreationPart()
            {
                List<string> parts = UserUtils.GetListPart();

                for (int i = 0; i < parts.Count; i++)
                {
                    _parts.Add(parts[i], UserUtils.GenerateRandomNumber(_minPart, _maxPart));
                }
            }

        }
    }
}