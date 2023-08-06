using System;
using System.Collections.Generic;

//Написать программу администрирования супермаркетом.
//В супермаркете есть очередь клиентов.
//У каждого клиента в корзине есть товары, также у клиентов есть деньги.
//Клиент, когда подходит на кассу, получает итоговую сумму покупки и старается её оплатить. 
//Если оплатить клиент не может, то он рандомный товар из корзины выкидывает до тех пор, пока его денег
//не хватит для оплаты. 
//Клиентов можно делать ограниченное число на старте программы.
//Супермаркет содержит список товаров, из которых клиент выбирает товары для покупки.


//создать список покупателей (Queue) 10 штук
// - у каждого корзина с набором товаров и запас денег

//создаем магазин с надором товаров (+- 20 штук)



namespace Progect_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Work();
            Console.ReadKey();
        }
    }

    class UserUtils
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            Random randomNumber = new Random();

            return randomNumber.Next(min, max);
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

        public void Work()// нужно выполнить проверку на суму чека и сколько денег у покупателя и если денег нет, уведомить об етом и удалят случайный товар
        {
            Buyer tempBuyer;
            bool isWork = true;
            CreatStoreAssortment();
            CreationQueueBuyers();

            while (isWork)
            {
                if (_buyers.Count > 1)
                {
                    tempBuyer = _buyers.Dequeue();
                    tempBuyer.ShowStatsBuyer();
                    tempBuyer.ShowBasket();
                }
                else
                {
                    Console.WriteLine("Очередь закончилась.");
                    isWork = false;
                }
            }
        }// ????????

        private void CreationQueueBuyers()
        {
            const int MinBuyersInQueue = 3;
            const int MaxBuyersInQueue = 10;
            const int MinMoneyBuyer = 500;
            const int MaxMoneyBuyer = 1000;

            int buyersInQueue;
            Buyer tempBuyer;

            buyersInQueue = UserUtils.GenerateRandomNumber(MinBuyersInQueue, MaxBuyersInQueue);

            for (int i = 0; i < buyersInQueue; i++)
            {
                tempBuyer = new Buyer(_currentIndex++, UserUtils.GenerateRandomNumber(MinMoneyBuyer, MaxMoneyBuyer));
                tempBuyer.TakeProductInBasket(GivetProduct());
                _buyers.Enqueue(tempBuyer);
            }
        }// создаю очередь посетителей и формирую их корзины

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
        }// создаю асортимент товара

        private void Shuffle()
        {
            Product temporaryProduct;
            Product temporaryProduct2;
            int randNumber;
            Random randomCard = new Random();

            for (int i = 0; i < _products.Count; i++)
            {
                randNumber = randomCard.Next(_products.Count);
                temporaryProduct = _products[i];
                temporaryProduct2 = _products[randNumber];
                _products[i] = temporaryProduct2;
                _products[randNumber] = temporaryProduct;
            }
        } // перемешиваю товар в слуайной последовательности

        public Product GivetProduct() // отдаю товар из магазина
        {
            return _products[UserUtils.GenerateRandomNumber(0,_products.Count)];
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

        public void TakeProductInBasket(Product product) // заполняю корзину покупателя случайными товарами
        {
            const int MinProductInBusket = 1;
            const int MaxProductInBusket = 15;

            int basketSize = UserUtils.GenerateRandomNumber(MinProductInBusket, MaxProductInBusket);

            for (int i = 0; i < basketSize; i++)
            {
               _basket.Add(product);
            }
        }

        public void ShowBasket()
        {
            foreach (Product product in _basket)
            {
                product.ShowInfo();
            }
        } // вывод на екран купленых товаров

        public void ShowStatsBuyer()
        {
            Console.WriteLine($"ID посетителя - {Id}, в кошельке - {Money}");
        } // вывод на екран информации о покупателе
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

        public void ShowInfo() // вывод на екран информации о товаре
        {
            Console.Write(Name + "\t\t\t");
            Console.WriteLine(Value);
        }

        private int ValueProduct() // присвоение случайной стоимости товара
        {
            int minValue = 10;
            int maxValue = 100;

            return UserUtils.GenerateRandomNumber(minValue, maxValue);
        }
    }
}
