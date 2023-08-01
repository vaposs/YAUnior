using System;
using System.Collections.Generic;

namespace Project_6
{
    class UserUtils
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            Random randomNumber = new Random();

            return randomNumber.Next(min, max);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string namePlayer;
            int moneyPlayer = 100;

            Console.Write("Введите имя - ");
            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer, moneyPlayer);
            Shop shop = new Shop();

            shop.Work(player);
        }
    }

    class Dealer: Human
    {
        private Item _itemForSeel;

        public Dealer(string name, int money) : base(name, money)
        {

        }

        public void CreateGoods()
        {
            const int MinRandomTier = 1;
            const int MaxRandomTier = 5;
            const int MinRandomValue = 1;
            const int MaxRandomValue = 10;

            int itemsCount;
            int tierItem;
            int valueItem;


            Console.Write("Сколько товаров вы видите на прилавке - ");
            itemsCount = GetPositiveNumber();

            for (int i = 0; i < itemsCount; i++)
            {
                tierItem = UserUtils.GenerateRandomNumber(MinRandomTier, MaxRandomTier);
                valueItem = UserUtils.GenerateRandomNumber(MinRandomValue, MaxRandomValue) * tierItem;
                Items.Add(new Item(Fill(),tierItem,valueItem));
            }
        }

        public Item TakeItem()
        {
            return _itemForSeel;
        }

        public Item SaleItem(Item item)
        {
            SallingPlus(item);
            Items.Remove(item);
            return item;
        }

        public Item ItemForSeel()
        {
            int itemNumber = 0;
            bool suitableNumber = true;


            while (suitableNumber)
            {
                Console.Write("Введите номер товара для покупки - ");
                itemNumber = GetPositiveNumber();

                if (itemNumber < 1 || itemNumber > Items.Count)
                {
                    Console.WriteLine("неверное число");
                }
                else
                {
                    suitableNumber = false;
                }
            }

            _itemForSeel = Items[itemNumber - 1];

            return _itemForSeel;
        }

        private void SallingPlus(Item item)
        {
            Money += item.Value;
        }
         
        private int GetPositiveNumber()
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

        private string Fill()
        {
            Random randomName = new Random();
            string nameItem = "";

            string[] tools = {
                "молоток", "лопата","топор",
                "кирка", "меч  ", "лук  ", "посох",
                "лопата", "нагрудник", "наручи",
                "поножья", "шлем ", "штаны"
            };

            nameItem = tools[randomName.Next(0, tools.Length)];
            return nameItem;
        }
    }

    class Player: Human
    {
        public Player(string name, int money) : base(name, money)
        {

        }

        public void BuyItem(Item item)
        {
            SallingMinus(item);
            Items.Add(item);
        }

        public bool CanBuy(Player player, Dealer dealer)
        {
            Item itemForBuy = dealer.ItemForSeel();
            bool isBuy;

            if (player.Money - itemForBuy.Value >= 0)
            {
                return isBuy = true;
            }
            else
            {
                return isBuy = false;
            }
        }

        private void SallingMinus(Item item)
        {
             Money -= item.Value;
        }
    }
    
    abstract class Human
    {
        protected List<Item> Items = new List<Item>();

        public string Name { get; protected set; }
        public int Money { get; protected set; }

        public Human(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public int CountGoods()
        {
            return Items.Count;
        }

        public void ShowGoods()
        {
            int indexNumber = 1;
            PrintFirstLine();

            if (Items.Count < 1)
            {
                Console.WriteLine("товаров нет\n");
            }
            else
            {
                foreach (Item item in Items)
                {
                    Console.Write(indexNumber + ". ");
                    item.ShowInfo();
                    indexNumber++;
                }
            }
        }

        private void PrintFirstLine()
        {
            const string NameGoods = "Название товара";
            const string TierGoods = "Уровень товара";
            const string ValueGoods = "Стоимость товара";

            Console.WriteLine($"{NameGoods}\t\t{TierGoods}\t\t{ValueGoods}");
        }
    }

    class Shop
    {
        public void Work(Player player)
        {
            const string BuyGoodCommand = "1";
            const string ExitGameCommand = "2";

            int minMoney = 100;
            int maxMoney = 500;
            bool isTrade = true;

            int moneyInTraider = UserUtils.GenerateRandomNumber(minMoney,maxMoney);
            Dealer dealer = new Dealer("Traider", moneyInTraider);

            Console.WriteLine($"Вы подошли в прилавку торговца {dealer.Name} и смотрите на товары.");
            dealer.CreateGoods();

            while (isTrade)
            {
                string command;

                Console.WriteLine($"\nДенег у торговца - {dealer.Money}, денег у вас - {player.Money}");
                dealer.ShowGoods();
                Console.WriteLine($"\nТовары {player.Name}");
                player.ShowGoods();
                Console.WriteLine($"{BuyGoodCommand}. Купить.");
                Console.WriteLine($"{ExitGameCommand}. Выход");
                Console.Write("Введите номер команды - ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case BuyGoodCommand:
                        TransferProduct(dealer, player);
                        break;

                    case ExitGameCommand:
                        isTrade = false;
                        break;

                    default:
                        Console.WriteLine("Не верная команда.\n");
                        break;
                }
            }
        }

        private void TransferProduct(Dealer dealer, Player player)
        {
            if (dealer.CountGoods() == 0)
            {
                Console.WriteLine($"У {dealer.Name} не осталось товаров");
            }
            else
            {
                if (player.CanBuy(player, dealer) == false)
                {
                    Console.WriteLine("у игрока не хватает монет");
                }
                else
                {
                    player.BuyItem(dealer.SaleItem(dealer.TakeItem()));
                }
            }
        }
    }

    class Item
    {
        public Item(string name, int tier, int value)
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