using System;
using System.Collections.Generic;

namespace Project_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string namePlayer;
            int moneyPlayer = 100;

            Console.Write("Введите имя - ");
            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer, moneyPlayer);
            Trade trade = new Trade();

            trade.Menu(player);
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

    class Dealer
    {
        private List<Item> _goods = new List<Item>();

        public Dealer(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }
        public int Money { get; private set; }

        public void CreateGoods()
        {
            const int MinRandomTier = 1;
            const int MaxRandomTier = 5;
            const int MinRandomValue = 1;
            const int MaxRandomValue = 10;

            Random randomNumber = new Random();
            int countItem;
            int tierItem;
            int valueItem;

            Console.Write("Сколько товаров вы видите на прилавке - ");
            countItem = GetPositiveNumber();

            for (int i = 0; i < countItem; i++)
            {
                tierItem = randomNumber.Next(MinRandomTier, MaxRandomTier);
                valueItem = randomNumber.Next(MinRandomValue, MaxRandomValue) * tierItem;
                _goods.Add(new Item(NameItem(),tierItem,valueItem));
            }
        }

        public void ShowGoods()
        {
            int indexNumber = 1;
            Console.WriteLine($"{Name} товары");
            PrintFirstLine();
            foreach (Item item in _goods)
            {
                Console.Write(indexNumber + ". ");
                item.ShowInfo();
                indexNumber++;
            }
        }

        public int CountGoods()
        {
            return _goods.Count;
        }

        public Item SaleItem()
        {
            int itemNumber;
            Item tempItem;
            Console.WriteLine("Введите номер товара для покупки - ");
            itemNumber = GetPositiveNumber();

            tempItem = _goods[itemNumber - 1];
            _goods.RemoveAt(itemNumber - 1);
            SallingPlus(tempItem);
            return tempItem;
        }

        private void SallingPlus(Item item)
        {
            Money += item.Value;
        }

        private void PrintFirstLine()
        {
            const string nameGoods = "Название товара";
            const string tierGoods = "Уровень товара";
            const string valueGoods = "Стоимость товара";

            Console.WriteLine($"{nameGoods}\t\t{tierGoods}\t\t{valueGoods}");
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

        private string NameItem()
        {
            Random randomName = new Random();

            string[] tools = {
                "молоток", "лопата","топор",
                "кирка", "меч  ", "лук  ", "посох",
                "лопата", "нагрудник", "наручи",
                "поножья", "шлем ", "штаны"
            };
            string nameItem = "";

            nameItem = tools[randomName.Next(0, 13)];
            return nameItem;
        }
    }

    class Player
    {
        private List<Item> _inventar = new List<Item>();

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }
        public int Money { get; private set; }

        public void BuyItem(Item item)
        {
            if ((Money - item.Value) >= 0)
            {
                SallingMinus(item);
                _inventar.Add(item);
            }
            else
            {
                Console.WriteLine("не достаточно денег");
            }
        }

        public void ShowInventar()
        {
            Console.WriteLine($"\n{Name} товары");

            if (_inventar.Count == 0)
            {
                Console.WriteLine("в карманах пусто");
            }
            else
            {
                foreach (Item item in _inventar)
                {
                    item.ShowInfo();
                }
            }
        }

        public int CountGoods()
        {
            return _inventar.Count;
        }

        private void SallingMinus(Item item)
        {
             Money -= item.Value;
        }
    }

    class Trade
    {
        public void Menu(Player player)
        {
            const string BuyGoodCommand = "1";
            const string ExitGame = "2";

            int minMoney = 100;
            int maxMoney = 500;
            bool isTrade = true;

            Random moreMoney = new Random();
            Dealer dealer = new Dealer("Traider", moreMoney.Next(minMoney, maxMoney));

            Console.WriteLine($"Вы подошли в прилавку торговца {dealer.Name} и смотрите на товары.");
            dealer.CreateGoods();

            while (isTrade)
            {
                Console.WriteLine($"\nДенег у торговца - {dealer.Money}, денег у вас - {player.Money}");
                ShowGoods(dealer, player);
                Console.WriteLine($"{BuyGoodCommand}. Купить.");
                Console.WriteLine($"{ExitGame}. Выход");
                Console.Write("Введите номер команды - ");

                string command;
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case BuyGoodCommand:
                        BuyGood(dealer, player);
                        break;

                    case ExitGame:
                        isTrade = false;
                        break;

                    default:
                        Console.WriteLine("Не верная команда.\n");
                        break;
                }
            }
        }

        private void ShowGoods(Dealer dealer, Player player)
        {
            dealer.ShowGoods();
            player.ShowInventar();
        }

        private void BuyGood(Dealer dealer, Player player)
        {
            if (dealer.CountGoods() == 0)
            {
                Console.WriteLine($"У {dealer.Name} не осталось товаров");
            }
            else
            {
                player.BuyItem(dealer.SaleItem());
            }
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
    }
}