using System;
using System.Collections.Generic;

//1) Пересмотрите новую лекцию 07:41:49 - СТАТИКА ЭТО ПЛОХО и избавьтесь от статических методов (кроме Main) . Перенесите логику меню и
//товарообмена в класс Магазин в методы Work и Trade.
//
//2) много лишних пусты строк - Пустые строки НЕ ставятся с прилегающей внутренней стороны фигурных скобок - https://trello.com/c/RE1sLWs7 .
//
//3) MinMoney и MaxMoney - это переменные, а не константы .
//
//4) По условию задачи покупатель может только купить, но не продать товар, а продавец - только продать, но не купить товар .
//
//5) У торгующих сторон есть сходные данные (деньги, список товаров, метод показывающий товары), которые лучше вынести в родительский класс .

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

            Trade(player);
        }

        public void Trade(Player player)
        {
            const string ShowGoodsCommand = "1";
            const string BuyGoodCommand = "2";
            const string SealGoodCommand = "3";
            const string ExitGame = "4";
            const int MinMoney = 100;
            const int MaxMoney = 500;

            bool isTrade = true;


            Random moreMoney = new Random();
            Dealer dealer = new Dealer("Traider", moreMoney.Next(MinMoney, MaxMoney));

            Console.WriteLine($"Вы подошли в прилавку торговца {dealer.Name} и смотрите на товары.");
            dealer.CreateGoods();

            while (isTrade)
            {

                Console.WriteLine($"\nДенег у торговца - {dealer.Money}, денег у вас - {player.Money}");

                Console.WriteLine($"{ShowGoodsCommand}. Показать товары и инвентарь игрока: ");
                Console.WriteLine($"{BuyGoodCommand}. Купить.");
                Console.WriteLine($"{SealGoodCommand}. Продать.");
                Console.WriteLine($"{ExitGame}. Выход");
                Console.Write("Введите номер команды - ");

                string command;
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ShowGoodsCommand:
                        ShowGoods(dealer, player);
                        break;

                    case BuyGoodCommand:
                        BuyGoods(dealer,player);
                        break;

                    case SealGoodCommand:
                        SaleGoods(dealer, player);
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

        void ShowGoods(Dealer dealer, Player player)
        {
            dealer.ShowGoods();
            player.ShowInventar();
        }

        void BuyGoods(Dealer dealer, Player player)
        {
            if(dealer.CountGoods() == 0)
            {
                Console.WriteLine($"У {dealer.Name} не осталось товара");
            }
            else
            {
                player.BuyItem(dealer.SaleItem());
            }
        }

        void SaleGoods(Dealer dealer, Player player)
        {
            if (player.CountGoods() == 0)
            {
                Console.WriteLine($"У {player.Name} не осталось товара");
            }
            else
            {
                dealer.BuyItem(player.SaleItem());
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
            //SortGoods();
            Console.WriteLine($"{Name} товары");
            PrintFirstLine();
            foreach (Item item in _goods)
            {
                Console.Write(indexNumber + ". ");
                item.ShowInfo();
                indexNumber++;
            }
        }

        public Item SaleItem() 
        {
            int itemNumber;
            Item tempItem;
            Console.Write("Введите номер товара для покупки - ");
            itemNumber = GetPositiveNumber();

            tempItem = _goods[itemNumber - 1];
            _goods.RemoveAt(itemNumber - 1);
            SallingPlus(tempItem);

            return tempItem;
        }

        public int CountGoods()
        {
            return _goods.Count;
        }

        public void BuyItem(Item item)
        {
            if ((Money - item.Value) >= 0)
            {
                SallingMinus(item);
                _goods.Add(item);
            }
            else
            {
                Console.WriteLine("не достаточно денег");
            }
        }

        private void PrintFirstLine()
        {
            const string nameGoods = "Название товара";
            const string tierGoods = "Уровень товара";
            const string valueGoods = "Стоимость товара";

            Console.WriteLine($"{nameGoods}\t\t{tierGoods}\t\t{valueGoods}");
        }

        /*private void SortGoods()
        {
            List<int> temp = new List<int>();
            List<Item> templGoods = new List<Item>();

            foreach (var item in _goods)
            {
                Console.WriteLine($"{item.Name}-{item.Tier}-{item.Value}");
            }

            for (int i = 0; i < _goods.Count; i++)
            {
                temp.Add(_goods[i].Tier);
            }

            temp.Sort();

            for (int i = 0; i < _goods.Count; i++)
            {
                for (int j = 0; j < _goods.Count; j++)
                {
                    if (temp[i] == _goods[j].Tier)
                    {
                        templGoods.Add(_goods[j]);
                    }
                }
            }

            _goods = templGoods;
        } дорабатываю */

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

        private void SallingPlus(Item item)
        {
            Money += item.Value;
        }

        private void SallingMinus(Item item)
        {
            Money -= item.Value;
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

        public Item SaleItem()
        {
            int itemNumber;
            Item tempItem;
            Console.Write("Введите номер товара для покупки - ");
            itemNumber = GetPositiveNumber();

            tempItem = _inventar[itemNumber - 1];
            _inventar.RemoveAt(itemNumber - 1);
            SallingPlus(tempItem);
            return tempItem;
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

        private void SallingMinus(Item item)
        {
             Money -= item.Value;
        }

        private void SallingPlus(Item item)
        {
            Money += item.Value;
        }
    }
}