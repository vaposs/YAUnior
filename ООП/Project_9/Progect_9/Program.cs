using System;
using System.Collections.Generic;

namespace Progect_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Work();
        }
    }

    class UserUtils
    {
        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            Random randomNumber = new Random();

            return randomNumber.Next(minNumber, maxNumber);
        }
    }

    class Shop
    {
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private List<Product> _products = new List<Product>();
        private int _currentIndex = 1;
        private Buyer _tempBuyer;

        public void Work()
        {
            bool isNextBuyer;
            bool isWork = true;

            CreatStoreAssortment();
            CreationQueueBuyers();
            CreateBasketBuyers();

            while (isWork)
            {
                Console.WriteLine("\nВы видите в очереди:\n");
                ShowQueueBuyers();

                if (_buyers.Count > 0)
                {
                    _tempBuyer = _buyers.Dequeue();
                    Console.WriteLine();
                    _tempBuyer.ShowStats();
                    _tempBuyer.ShowBasket();

                    isNextBuyer = false;

                    while (isNextBuyer == false)
                    {
                        if (_tempBuyer.Money >= _tempBuyer.GetSummBusket())
                        {
                            isNextBuyer = true;
                            Console.WriteLine($"покупатель {_tempBuyer.Id} оплату произвел, следущий ...");
                        }
                        else
                        {
                            Console.WriteLine("Монет для оплаты не достаочно, исключаем случайный товар с корзины");
                            _tempBuyer.ExcludeRandomProduct();
                        }
                    }
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Очередь закончилась.");
                    isWork = false;
                }
            }

            Console.ReadKey();
            Console.WriteLine("конец програмы");
        }

        public void CreateBasketBuyers()
        {
            foreach (Buyer buyer in _buyers)
            {
                for (int i = 0; i < buyer.CreatSizeBasket(); i++)
                {
                    buyer.TakeProductInBasket(GivetRandomProduct());
                }
            }
        }

        public Product GivetRandomProduct()
        {
            return _products[UserUtils.GenerateRandomNumber(0, _products.Count)];
        }

        public void ShowQueueBuyers()
        {
            foreach (Buyer buyer in _buyers)
            {
                buyer.ShowStats();
            }
        }

        private void CreationQueueBuyers()
        {
            int minBuyersInQueue = 3;
            int maxBuyersInQueue = 10;
            int minMoneyBuyer = 300;
            int maxMoneyBuyer = 700;
            int buyersInQueue;
            Buyer tempBuyer;

            buyersInQueue = UserUtils.GenerateRandomNumber(minBuyersInQueue, maxBuyersInQueue);

            for (int i = 0; i < buyersInQueue; i++)
            {
                tempBuyer = new Buyer(_currentIndex++, UserUtils.GenerateRandomNumber(minMoneyBuyer, maxMoneyBuyer));
                tempBuyer.TakeProductInBasket(GivetRandomProduct());
                _buyers.Enqueue(tempBuyer);
            }
        }

        private void CreatStoreAssortment()
        {
            int minStoreAssortment = 10;
            int maxStoreAssortment = 100;
            string productName = "товар_";
            int sizeStoreAssortment = UserUtils.GenerateRandomNumber(minStoreAssortment,maxStoreAssortment);
            string[] productNames = new string[sizeStoreAssortment];

            for (int i = 0; i < sizeStoreAssortment; i++)
            {
                productNames[i] = productName + i.ToString(); 
            }

            for (int i = 0; i < productNames.Length; i++)
            {
                _products.Add(new Product(productNames[i]));
            }
        }
    }

    class Buyer
    {
        private List<Product> _basket = new List<Product>();

        public Buyer(int id, int money)
        {
            Id = id;
            Money = money;
        }

        public int Id { get; private set; }
        public int Money { get; private set; }

        public void ShowBasket()
        {
            foreach (Product product in _basket)
            {
                product.ShowInfo();
            }
        } 

        public void ShowStats()
        {
            Console.WriteLine($"ID посетителя - {Id}, в кошельке - {Money}, сумма чека покупателя - {GetSummBusket()}");
        } 

        public void TakeProductInBasket(Product product) 
        {
            _basket.Add(product);
        }

        public int CreatSizeBasket()
        {
            int minSizeBasket = 5;
            int maxSizeBasket = 15;

            int sizeBasket = UserUtils.GenerateRandomNumber(minSizeBasket,maxSizeBasket);

            return sizeBasket;
        } 

        public int GetSummBusket()
        {
            int summ = 0;

            foreach (Product product in _basket)
            {
                summ += product.Value;
            }

            return summ;
        } 

        public void ExcludeRandomProduct()
        {
            int productNumderForExclude = UserUtils.GenerateRandomNumber(0, _basket.Count);
            Console.WriteLine($"Продукт {_basket[productNumderForExclude].Name} исключен из корзины");
            _basket.RemoveAt(productNumderForExclude);
        }
    }

    class Product
    {
        public Product(string name)
        {
            Name = name;
            Value = RandomValueProduct();
        }

        public string Name { get;private set; }
        public int Value { get; private set; }

        public void ShowInfo() 
        {
            Console.Write(Name + "\t\t\t");
            Console.WriteLine(Value);
        }

        private int RandomValueProduct() 
        {
            int minValue = 10;
            int maxValue = 100;

            return UserUtils.GenerateRandomNumber(minValue, maxValue);
        }
    }
}
