using System;
using System.Collections.Generic;

namespace Project_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.Work();
        }
    }

    class UserUtils
    {
        const string _GreenColor = "green";
        const string _YellowColor = "yellow";
        const string _RedColor = "red";
        const string _BlueColor = "blue";
        const string _WhiteColor = "white";

        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static int GetPositiveNumber()
        {
            string readName;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                readName = Console.ReadLine();
                isCorrectNumber = int.TryParse(readName, out number);

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

        public static void Draw(string color)
        {
            switch (color)
            {
                case _GreenColor:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case _YellowColor:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case _RedColor:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case _BlueColor:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case _WhiteColor:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }


            char[,] fishPicture = new char[,]
            {
                {' ',' ',' ',' ',' ','/','`','·','.','¸',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ','/','¸','.','.','¸','`',':',' ',' ',' ',' ',' ',' ',' ',' '},
                {'¸','.','·','´',' ',' ','¸',' ',' ',' ','`','·','.','¸','.',',','·','´',')' },
                {':',' ','©',' ',')',':','´',';',' ',' ',' ',' ',' ',' ','¸',' ',' ','{',' ',},
                {' ','`','·','.','¸',' ','`','·',' ',' ','¸','.','·','´',' ','`','·','¸',')'},
                {' ',' ',' ',' ',' ','`','`','´','´','´',' ',' ',' ',' ',' ',' ',' ',' ',' '}
            };

            for (int i = 0; i < fishPicture.GetLength(0); i++)
            {
                for (int j = 0; j < fishPicture.GetLength(1); j++)
                {
                    Console.Write(fishPicture[i, j]);
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public static string GenerateRandomColor()
        {
            string[] color = new string[]
            {
                _GreenColor, _YellowColor, _RedColor, _BlueColor, _WhiteColor
            };

            int indexColor = UserUtils.GenerateRandomNumber(0, color.Length);

            return color[indexColor];
        }

        public static string InputName()
        {
            Console.Write("придумайте имя рыбке - ");
            return Console.ReadLine();
        }
    }

    class Aquarium
    {
        private const string Wait = "1";
        private const string Add = "2";
        private const string Remove = "3";
        private const string Exit = "4";


        private int _maxCountFish = 10;
        private List<Fish> _fishs = new List<Fish>();
        private int _countDay = 1;

        public void Work()
        {
            string waitNexDayCommand = "1";
            string addFishCommand = "2";
            string removeDeadFishCommand = "3";
            string exitCommand = "4";
            bool isNextDay = true;

            while (isNextDay)
            {
                ShowFishInAquarium();
                WaitNextDay();
                
                Console.WriteLine($"День {_countDay}");
                Console.WriteLine("вы стоите перед аквариумом, что вы хотите сделать:");
                Console.WriteLine($"{waitNexDayCommand}. ждать следущего дня");
                Console.WriteLine($"{addFishCommand}. добавить рыбку");
                Console.WriteLine($"{removeDeadFishCommand}. убрать мертвых рыб");
                Console.WriteLine($"{exitCommand}. выход");
                Console.Write("\nВведите номер команды - ");

                string command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                {
                    case Wait:
                        _countDay++;
                        Console.WriteLine("ждем");
                        break;
                    case Add:
                        AddFish();
                        break;
                    case Remove:
                        RemoveDeadFishs();
                       break;
                    case Exit:
                        Console.WriteLine("вышли");
                        isNextDay = false;
                        break;
                    default:
                        Console.WriteLine("неверная команда, но день все равно потерян");
                        _countDay++;
                        break;
                }
            }
        }

        private void ShowFishInAquarium()
        {
            int index = 1;

            foreach (Fish fish in _fishs)
            {
                UserUtils.Draw(fish.Color);
            }

            foreach (Fish fish in _fishs)
            {
                Console.Write($"{index++}.");
                fish.ShowInfo();
            }
        }

        private void RemoveDeadFishs()
        {
            for (int i = 0; i < _fishs.Count; i++)
            {
                if(_fishs[i].IsAlive == false)
                {
                    _fishs.Remove(_fishs[i]);
                    i--;
                }
            }
        }

        private void AddFish()
        {
            if(_fishs.Count >= _maxCountFish)
            {
                Console.WriteLine("Аквариум переполен");
            }
            else
            {
                _fishs.Add(new Fish());
            }
        }

        private void WaitNextDay()
        {
            foreach (Fish fish in _fishs)
            {
                fish.WaitOneDay();
            }
        }
    }

    class Fish
    {
        private int _ageFish = 0;
        private int _minRandomAgeFish = 4;
        private int _maxRandomAgeFish = 20;

        public Fish()
        {
            Name = UserUtils.InputName();
            Age = _ageFish;
            MaxAge = UserUtils.GenerateRandomNumber(_minRandomAgeFish, _maxRandomAgeFish);
            Color = UserUtils.GenerateRandomColor();
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public int MaxAge { get; protected set; }
        public string Color { get; protected set; }

        public bool IsAlive => Age < MaxAge;

        public void WaitOneDay()
        {
            Age++;

            if(Age >= MaxAge)
            {
                Age = MaxAge;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, текущий/максимальный возраст - {Age}/{MaxAge}, цвет - {Color}, жива/мертва - {IsAlive}");
        }
    }
}
