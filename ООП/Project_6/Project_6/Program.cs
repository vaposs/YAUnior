using System;
using System.Collections.Generic;

namespace Project_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int money = 0;
            string name = "";

            Player player = new Player(name, money);
            new Shop().Work(player);
        }
    }

    class UserUtils
     { 
        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            Random random = new Random();

            return random.Next(minRandomNumber, maxRandomNumber);
        }

        public static int GetPositiveNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isCorrectNumber = int.TryParse(line, out number);

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

    abstract class Human
    {
        protected List<Product> Products = new List<Product>();

        public string Name { get; protected set; }
        public int Money { get; protected set; }

        public Human(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public int GetCountProduct()
        {
            return Products.Count;
        }

        public void ShowProduct()
        {
            int indexNumber = 1;
            PrintFirstLine();

            if (Products.Count < 1)
            {
                Console.WriteLine("товаров нет\n");
            }
            else
            {
                foreach (Product product in Products)
                {
                    Console.Write(indexNumber + ". ");
                    product.ShowInfo();
                    indexNumber++;
                }
            }
        }

        private void PrintFirstLine()
        {
            const string NameProducts = "Название товара";
            const string TierProducts = "Качество товара";
            const string ValueProducts = "Стоимость товара";

            Console.WriteLine($"{NameProducts}\t\t{TierProducts}\t\t{ValueProducts}");
        }
    }

    class Dealer : Human
    {
        public Dealer(string name, int money) : base(name, money)
        {
            CreateProducts();
        }

        public bool VerifyProductAvailability(int productNumber)
        {
            return productNumber <= Products.Count;
        }

        public Product ReturnProduct(int productNumber)
        {
            return Products[productNumber];
        }

        public Product SellProduct(int numberProduct)
        {
            Product tempProduct = Products[numberProduct];
            Products.RemoveAt(numberProduct);
            Money += tempProduct.Value;
            return tempProduct;
        }

        private string GenerateNameProducts()
        {
            Random randomName = new Random();
            string nameProduct = "";

            string[] tools = {
                "молоток", "лопата","топор",
                "кирка", "меч  ", "лук  ", "посох",
                "лифчик", "нагрудник", "наручи",
                "поножья", "шлем ", "штаны"
            };

            nameProduct = tools[randomName.Next(0, tools.Length)];
            return nameProduct;
        }

        private void CreateProducts()
        {
            int minRandomTier = 1;
            int maxRandomTier = 5;
            int minRandomPrice = 1;
            int maxRandomPrice = 10;
            int productCount;
            int tierProduct;
            int valueProduct;

            Console.Write("Сколько товаров вы видите на прилавке - ");
            productCount = UserUtils.GetPositiveNumber();

            for (int i = 0; i < productCount; i++)
            {
                tierProduct = UserUtils.GenerateRandomNumber(minRandomTier, maxRandomTier);
                valueProduct = UserUtils.GenerateRandomNumber(minRandomPrice, maxRandomPrice) * tierProduct;
                Products.Add(new Product(GenerateNameProducts(), tierProduct, valueProduct));
            }
        }
    }

    class Player: Human
    {
        public Player(string name, int money) : base(name, money)
        {
            Name = SetName();
            Money = SetMoney();
        }

        public void BuyProduct(Product product)
        {
            Products.Add(product);
            Money -= product.Value;
        }

        public bool CanBuy(Product product)
        {
            return Money >= product.Value;
        }

        private string SetName()
        {
            string name;

            Console.Write("Введите имя - ");
            return Name = Console.ReadLine();
        }

        private int SetMoney()
        {
            Console.Write("Введите количество монет в кармане - ");
            int money = UserUtils.GetPositiveNumber();

            return money;
        }
    }
    
    class Shop
    {
        public void Work(Player player)
        {
            const string BuyProductCommand = "1";
            const string ExitGameCommand = "2";

            int minMoney = 100;
            int maxMoney = 500;
            bool isTradeDeal = true;

            int moneyInTraider = UserUtils.GenerateRandomNumber(minMoney,maxMoney);
            Dealer dealer = new Dealer("Traider", moneyInTraider);

            Console.WriteLine($"Вы подошли в прилавку торговца {dealer.Name} и смотрите на товары.");

            while (isTradeDeal)
            {
                string command;

                Console.WriteLine($"\nДенег у торговца - {dealer.Money}, денег у вас - {player.Money}");
                dealer.ShowProduct();
                Console.WriteLine($"\nТовары {player.Name}");
                player.ShowProduct();
                Console.WriteLine($"{BuyProductCommand}. Купить.");
                Console.WriteLine($"{ExitGameCommand}. Выход");
                Console.Write("Введите номер команды - ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case BuyProductCommand:
                        TransferProduct(dealer, player);
                        break;

                    case ExitGameCommand:
                        isTradeDeal = false;
                        break;

                    default:
                        Console.WriteLine("Не верная команда.\n");
                        break;
                }
            }
        }

        private void TransferProduct(Dealer dealer, Player player)
        {
            if (dealer.GetCountProduct() == 0)
            {
                Console.WriteLine($"У {dealer.Name} не осталось товаров");
            }
            else
            {
                Trade(dealer, player);
            }
        }

        private void Trade(Dealer dealer, Player player)
        {
            Product tempProduct;
            int productNumber;
            bool suitableNumber = true;

            while (suitableNumber)
            {
                Console.Write("Введите номер товара для покупки - ");
                productNumber = UserUtils.GetPositiveNumber() - 1;

                if (dealer.VerifyProductAvailability(productNumber) == true)
                {
                    if (player.CanBuy(dealer.ReturnProduct(productNumber)))
                    {
                        player.BuyProduct(dealer.SellProduct(productNumber));
                    }
                    else
                    {
                        Console.WriteLine("не зватает монет для покупки");
                    }

                    suitableNumber = false;
                }
                else
                {
                    Console.WriteLine("такого товара нету");
                }
            }
        }
    }

    class Product
    {
        public Product(string name, int tier, int value)
        {
            Name = name;
            Tier = tier;
            Value = value;
        }

        public string Name { get; private set; }
        public int Tier { get; private set; }
        public int Value { get; private set; }

        public void ShowInfo()
        {
            Console.Write(Name + "\t\t\t");
            Console.Write(Tier + "\t\t");
            Console.WriteLine(Value);
        }
    }
}