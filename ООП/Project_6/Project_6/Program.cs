using System;
using System.Collections.Generic;

namespace Project_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dealer dealer = new Dealer("asd");
            dealer.CreateGoods();
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
            Console.Write(Name + " - ");
            Console.Write(Tier + " - ");
            Console.WriteLine(Value);
        }

        public int ToTier()
        {
            return Tier;
        }
    }

    class Dealer
    {
        private List<Item> _goods = new List<Item>();

        public Dealer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        private string NameItem()
        {
            Random randomName = new Random();

            string[] tools = {
                "молоток", "лопата","топор",
                "кирка", "меч", "лук", "посох",
                "лопата", "нагрудник", "наручи",
                "поножья", "шлем", "штаны"
            };
            string nameItem = "";

            nameItem = tools[randomName.Next(0,13)];
            return nameItem;
        }

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

            Console.Write("Введите количество товаров у торговца - ");
            countItem = GetNumber();

            for (int i = 0; i < countItem; i++)
            {
                tierItem = randomNumber.Next(MinRandomTier, MaxRandomTier);
                valueItem = randomNumber.Next(MinRandomValue, MaxRandomValue) * tierItem;
                _goods.Add(new Item(NameItem(),tierItem,valueItem));
            }

            ShowGoods();
            Console.ReadKey();
        }

        private int GetNumber()
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

        private void ShowGoods()
        {
            int indexNumber = 1;
            SortGoods();

            foreach (Item item in _goods)
            {
                Console.Write(indexNumber + ". ");
                item.ShowInfo();
                indexNumber++;
            }
        }

        private void SortGoods()
        {
            List<int> temp = new List<int>(_goods.Count);
            List<Item> templGoods = new List<Item>(_goods.Count);

            for (int i = 0; i < _goods.Count; i++)
            {
                temp.Add(_goods[i].ToTier());
            }

            temp.Sort();

            for (int i = 0; i < _goods.Count; i++)
            {
                for (int j = 0; j < _goods.Count; j++)
                {
                    if (temp[i] == _goods[j].Tier)
                    {
                        templGoods.Add(_goods[i]);
                    }
                }
            }

            _goods = templGoods;
        }

        public Item SealItem()
        {
            int itemNumber = 0;
            ShowGoods();
            Console.WriteLine("Введите номер товара для покупки - ");
            itemNumber = GetNumber();

            return _goods[itemNumber];
        }
    }

    class Player
    {
        private List<Item> _inventar = new List<Item>();

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void BuyItem(Item item)
        {
            _inventar.Add(item);
        }

        public void SeelItem()
        {

        }
    }
}

// - покупка продажа предметов


// методы покупки продажи выводы всего инвенторя 


//Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.
//После продажи товар переходит к вам, и вы можете также посмотреть свои вещи. 

