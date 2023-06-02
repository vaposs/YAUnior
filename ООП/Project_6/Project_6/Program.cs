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
        public Item(string name, int tierItem, int value)
        {
            Name = name;
            TierItem = tierItem;
            Value = value;

        }

        public string Name { get; private set; }
        public int TierItem { get; private set; }
        public int Value { get; private set; }

        public void ShowInfo()
        {
            Console.Write(Name + " - ");
            Console.Write(TierItem + " - ");
            Console.WriteLine(Value);
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

            Console.WriteLine(_goods.Count);

            for (int i = 0; i < countItem; i++)
            {
                tierItem = randomNumber.Next(MinRandomTier, MaxRandomTier);
                valueItem = randomNumber.Next(MinRandomValue, MaxRandomValue) * tierItem;
                _goods.Add(new Item(NameItem(),tierItem,valueItem));
            }
            Console.WriteLine(_goods.Count);
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
                    if (number < 0)
                    {
                        Console.Write("Неверный ввод. Число меньше нуля. Повторите ввод - ");
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
            foreach (Item item in _goods)
            {
                item.ShowInfo();
            }
        }
    }
}

// сортировка по тиру
// создать класс игрока
// -в нем лист как инвентарь!
// -метод вывода вилимости инвенторя
// - покупка продажа предметов

// создать класс ИТЕМ
// в нем 2 параметра - имя и стоимость

// создать класс торговец
// лист ИТЕМОВ
// методы покупки продажи выводы всего инвенторя 


//Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.
//После продажи товар переходит к вам, и вы можете также посмотреть свои вещи. 

//Возможные классы – игрок, продавец, товар. 

//Вы можете сделать так, как вы видите это.
