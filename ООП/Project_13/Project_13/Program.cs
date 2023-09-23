using System;
using System.Collections.Generic;

// У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
// У вашего автосервиса есть баланс денег и склад деталей.
// Когда приезжает автомобиль, у него сразу ясна его поломка, и эта поломка отображается у вас в консоли вместе с ценой за починку(цена за починку складывается из цены детали + цена
// за работу).
//
// Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
// Если у вас нет нужной детали на складе, то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
// Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
// За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.
// Класс Деталь не может содержать значение “количество”. Деталь всего одна, за количество отвечает тот, кто хранит детали. При необходимости можно создать дополнительный
// класс для конкретной детали и работе с количеством.



// классы - автосервис, заказчик, статические команды
// у автосервыса ограниченый набор деталей
// 

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
            private static Random s_random = new Random();

            public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
            {
                return s_random.Next(minRandomNumber, maxRandomNumber);
            }

            public static int GetPositiveNumber()
            {
                string userInputString;
                bool isConversionSucceeded = true;
                bool isCorrectNumber;
                int number = 0;

                while (isConversionSucceeded)
                {
                    userInputString = Console.ReadLine();
                    isCorrectNumber = int.TryParse(userInputString, out number);

                    if (isCorrectNumber)
                    {
                        if (number < 1)
                        {
                            Console.Write("Неверный ввод. Число меньше единици. Повторите ввод - ");
                        }
                        else
                        {
                            isConversionSucceeded = false;
                        }
                    }
                    else
                    {
                        Console.Write("Неверный ввод. Повторите ввод - ");
                    }
                }

                return number;
            }
        }

        class CarService
        {
            Stock stock = new Stock();
            Queue<Client> _clients = new Queue<Client>();
            Dictionary<string, int> _breakdowns = new Dictionary<string, int>();

            public void Work()
            {
                stock.Creation();
                CreateQueueClient();
                CreateRepairPrice();

                ShowQueue();
                ShowPriceRepair();

                stock.ShowPart();

                Console.ReadKey();
            }
            private void ShowPriceRepair()
            {
                foreach (var item in _breakdowns)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }
            }

            private void CreateQueueClient()
            {
                int minPeople = 5;
                int maxPeople = 30;

                int queuePeople = UserUtils.GenerateRandomNumber(minPeople, maxPeople);

                for (int i = 0; i < queuePeople; i++)
                {
                    _clients.Enqueue(new Client());
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

                string[] listBreakdowns = new string[]
                {
                    "РЕМОНТ ДВИГАТЕЛЕЙ",
                    "РЕМОНТ АКПП",
                    "РЕМОНТ СТАРТЕРОВ",
                    "РЕМОНТ ГЕНЕРАТОРОВ",
                    "РЕМОНТ ЭЛЕКТРОННЫХ БЛОКОВ",
                    "ЧИСТКА ИНЖЕКТОРОВ",
                    "ШИНОМОНТАЖ",
                    "КУЗОВНОЙ РЕМОНТ ЛЮБОЙ СЛОЖНОСТИ",
                    "ЗАМЕНА СТЕКОЛ",
                    "ХИМЧИСТКА",
                    "ПОЛИРОВКА"
                };

                for (int i = 0; i < listBreakdowns.Length; i++)
                {
                    _breakdowns.Add(listBreakdowns[i], UserUtils.GenerateRandomNumber(minRepairPrice, maxRepairPrice));
                }
            }
        }

        class Client
        {
            
        }

        class Stock
        {
            Dictionary<string, int> _parts = new Dictionary<string, int>();

            private int _minPart = 3;
            private int _maxPart = 15;

            public void GetSparePart() // достаем запчасти
            {

            }

            public void ShowPart()
            {
                Console.WriteLine("остаток запчастей:");
                foreach (var part in _parts)
                {
                    Console.WriteLine($"{part.Key} в количестве - {part.Value}");
                }
            }

            public void Creation()
            {
                string[] parts = new string[]
                {
                    "запчасть двигателя",
                    "запчасть АКПП",
                    "запчасть стартера",
                    "запчасть генератора",
                    "запчасть електронных блоков",
                    "запчасть для чистки инжектора",
                    "колесо",
                    "запчасть кузова",
                    "стекло",
                    "набор для химчистки",
                    "набор для полировки"
                };

                for (int i = 0; i < parts.Length; i++)
                {
                    _parts.Add(parts[i], UserUtils.GenerateRandomNumber(_minPart, _maxPart));
                }
            }
        }
    }
}

/*
T Dequeue(): извлекает и возвращает первый элемент очереди

void Enqueue(T item): добавляет элемент в конец очереди

*/
