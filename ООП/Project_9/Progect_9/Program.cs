using System;
using System.Collections.Generic;

namespace Project_9
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
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber);
        }
    }

    class Shop
    {
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private List<Product> _products = new List<Product>();
        private int _currentId = 1;

        public void Work()
        {
            CreateStoreAssortment();
            CreateQueueBuyers();
            FillBuyersBaskets();

            while (_buyers.Count > 0)
            {
                Console.WriteLine("\nВы видите в очереди:\n");
                ShowQueueBuyers();

                Buyer currentBuyer = _buyers.Dequeue();
                Console.WriteLine($"\nПокупатель {currentBuyer.Id} подходит к кассе:");
                currentBuyer.ShowStats();
                currentBuyer.ShowBasket();

                ProcessPayment(currentBuyer);

                Console.WriteLine("----------------------------------------------------------------------");
                Console.ReadKey();
            }

            Console.WriteLine("Очередь закончилась.");
            Console.WriteLine("Конец программы");
            Console.ReadKey();
        }

        private void ProcessPayment(Buyer buyer)
        {
            while (buyer.CanPay() == false)
            {
                Console.WriteLine("Денег для оплаты недостаточно. Товар возвращается в корзину...");
                buyer.MoveRandomProductFromBagToBasket();
            }

            buyer.PayForProducts();
            Console.WriteLine($"Покупатель {buyer.Id} оплатил покупки и уходит. В сумке {buyer.GetBagProductsCount()} товаров.");
        }

        private void FillBuyersBaskets()
        {
            foreach (Buyer buyer in _buyers)
            {
                int basketSize = buyer.GetRandomBasketSize();

                for (int i = 0; i < basketSize; i++)
                {
                    buyer.AddProductToBasket(GetRandomProduct());
                }
            }
        }

        private Product GetRandomProduct()
        {
            return _products[UserUtils.GenerateRandomNumber(0, _products.Count)];
        }

        private void ShowQueueBuyers()
        {
            foreach (Buyer buyer in _buyers)
            {
                buyer.ShowStats();
            }
        }

        private void CreateQueueBuyers()
        {
            int minBuyersInQueue = 3;
            int maxBuyersInQueue = 10;
            int minMoneyBuyer = 300;
            int maxMoneyBuyer = 700;

            int buyersInQueue = UserUtils.GenerateRandomNumber(minBuyersInQueue, maxBuyersInQueue);

            for (int i = 0; i < buyersInQueue; i++)
            {
                int money = UserUtils.GenerateRandomNumber(minMoneyBuyer, maxMoneyBuyer);
                Buyer buyer = new Buyer(_currentId++, money);
                _buyers.Enqueue(buyer);
            }
        }

        private void CreateStoreAssortment()
        {
            int minStoreAssortment = 10;
            int maxStoreAssortment = 100;
            string productName = "товар_";

            int storeSize = UserUtils.GenerateRandomNumber(minStoreAssortment, maxStoreAssortment);

            for (int i = 0; i < storeSize; i++)
            {
                _products.Add(new Product($"{productName}{i}"));
            }
        }
    }

    class Buyer
    {
        private List<Product> _basket = new List<Product>();
        private List<Product> _bag = new List<Product>();

        public Buyer(int id, int money)
        {
            Id = id;
            Money = money;
        }

        public int Id { get; private set; }
        public int Money { get; private set; }

        public void ShowBasket()
        {
            Console.WriteLine($"Товары в корзине (всего {_basket.Count}):");

            if (_basket.Count == 0)
            {
                Console.WriteLine("   Корзина пуста");
            }
            else
            {
                foreach (Product product in _basket)
                {
                    Console.Write("   ");
                    product.ShowInfo();
                }
            }
        }

        public void ShowBag()
        {
            Console.WriteLine($"Товары в сумке (всего {_bag.Count}):");

            if (_bag.Count == 0)
            {
                Console.WriteLine("   Сумка пуста");
            }
            else
            {
                foreach (Product product in _bag)
                {
                    Console.Write("   ");
                    product.ShowInfo();
                }
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"ID посетителя - {Id}, в кошельке - {Money} монет");
            Console.WriteLine($"Сумма чека - {GetBasketSum()}, товаров в корзине - {_basket.Count}");
        }

        public void AddProductToBasket(Product product)
        {
            _basket.Add(product);
        }

        public int GetRandomBasketSize()
        {
            int minSize = 5;
            int maxSize = 15;

            return UserUtils.GenerateRandomNumber(minSize, maxSize);
        }

        public int GetBasketSum()
        {
            int sum = 0;

            foreach (Product product in _basket)
            {
                sum += product.Value;
            }

            return sum;
        }

        public bool CanPay()
        {
            return Money >= GetBasketSum();
        }

        public void MoveRandomProductFromBagToBasket()
        {
            if (_bag.Count == 0)
            {
                Console.WriteLine("В сумке нет товаров для возврата!");
                return;
            }

            int productIndex = UserUtils.GenerateRandomNumber(0, _bag.Count);
            Product product = _bag[productIndex];
            _bag.RemoveAt(productIndex);
            _basket.Add(product);

            Console.WriteLine($"Товар {product.Name} стоимостью {product.Value} возвращен из сумки в корзину");
        }

        public void PayForProducts()
        {
            int totalCost = GetBasketSum();

            if (Money >= totalCost)
            {
                Money -= totalCost;

                _bag.AddRange(_basket);
                _basket.Clear();

                Console.WriteLine($"Покупатель {Id} оплатил {totalCost} монет. Остаток денег: {Money}");
            }
            else
            {
                Console.WriteLine($"Ошибка: недостаточно денег для оплаты! У покупателя {Money}, нужно {totalCost}");
            }
        }

        public int GetBagProductsCount()
        {
            return _bag.Count;
        }
    }

    class Product
    {
        public Product(string name)
        {
            Name = name;
            Value = GenerateRandomValue();
        }

        public string Name { get; private set; }
        public int Value { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Value} монет");
        }

        private int GenerateRandomValue()
        {
            int minValue = 10;
            int maxValue = 100;

            return UserUtils.GenerateRandomNumber(minValue, maxValue);
        }
    }
}
