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

        public static int GetPositiveNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isNumber = int.TryParse(line, out number);

                if (isNumber)
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

    class Shop
    {
        Queue<Buyer> _buyers = new Queue<Buyer>();
        List<Product> _products = new List<Product>();
        int _currentIndex = 1;
        Buyer tempBuyer;

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
                    tempBuyer = _buyers.Dequeue();
                    Console.WriteLine();
                    tempBuyer.ShowStatsBuyer();
                    tempBuyer.ShowBasket();

                    isNextBuyer = false;

                    while (isNextBuyer == false)
                    {
                        if (tempBuyer.Money >= tempBuyer.GetSummBusket())
                        {
                            isNextBuyer = true;
                            Console.WriteLine($"покупатель {tempBuyer.Id} оплату произвел, следущий ...");
                        }
                        else
                        {
                            Console.WriteLine("Монет для оплаты не достаочно, исключаем случайный товар с корзины");
                            tempBuyer.ExcludeRandomProduct();
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
                tempBuyer.TakeProductInBasket(GivetProduct());
                _buyers.Enqueue(tempBuyer);
            }
        }

        private void CreatStoreAssortment()
        {
            string[] productName =
            {
                "товар_01", "товар_02", "товар_03", "товар_04", "товар_05",
                "товар_06", "товар_07", "товар_08", "товар_09", "товар_10",
                "товар_11", "товар_12", "товар_13", "товар_14", "товар_15",
                "товар_16", "товар_17", "товар_18", "товар_19", "товар_20",
                "товар_21", "товар_22", "товар_23", "товар_24", "товар_25",
            };

            for (int i = 0; i < productName.Length; i++)
            {
                _products.Add(new Product(productName[i]));
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Product temporaryProduct;
            Product temporaryProduct2;
            int randomNumber;

            for (int i = 0; i < _products.Count; i++)
            {
                randomNumber = UserUtils.GenerateRandomNumber(0, _products.Count);
                temporaryProduct = _products[i];
                temporaryProduct2 = _products[randomNumber];
                _products[i] = temporaryProduct2;
                _products[randomNumber] = temporaryProduct;
            }
        }

        public Product GivetProduct()
        {
            return _products[UserUtils.GenerateRandomNumber(0,_products.Count)];
        }

        public void ShowQueueBuyers()
        {
            foreach (Buyer buyer in _buyers)
            {
                buyer.ShowStatsBuyer();
            }
        }

        public void CreateBasketBuyers()
        {
            foreach (Buyer buyer in _buyers)
            {
                for (int i = 0; i < buyer.TakeSizeBasket(); i++)
                {
                    buyer.TakeProductInBasket(GivetProduct());
                }
            }
        }
    }

    class Buyer
    {
        List<Product> _basket = new List<Product>();

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

        public void ShowStatsBuyer()
        {
            Console.WriteLine($"ID посетителя - {Id}, в кошельке - {Money}, сумма чека покупателя - {GetSummBusket()}");
        } 

        public void TakeProductInBasket(Product product) 
        {
            _basket.Add(product);
        }

        public int TakeSizeBasket()
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
            Value = ValueProduct();
        }

        public string Name { get;private set; }
        public int Value { get; private set; }

        public void ShowInfo() 
        {
            Console.Write(Name + "\t\t\t");
            Console.WriteLine(Value);
        }

        private int ValueProduct() 
        {
            int minValue = 10;
            int maxValue = 100;

            return UserUtils.GenerateRandomNumber(minValue, maxValue);
        }
    }
}
