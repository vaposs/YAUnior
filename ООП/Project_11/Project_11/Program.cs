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
        public const string GreenColor = "green";
        public const string YellowColor = "yellow";
        public const string RedColor = "red";
        public const string BlueColor = "blue";
        public const string WhiteColor = "white";

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
                case GreenColor:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case YellowColor:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case RedColor:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case BlueColor:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case WhiteColor:
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
                GreenColor, YellowColor, RedColor, BlueColor, WhiteColor
            };

            int indexColor = GenerateRandomNumber(0, color.Length);

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
        private int _currentDay = 1;

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

                Console.WriteLine($"День {_currentDay}");
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
                        _currentDay++;
                        IncreaseFishAge();
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
                        _currentDay++;
                        IncreaseFishAge();
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
                string aliveStatus = fish.IsAlive ? "жива" : "мертва";
                Console.Write($"{index++}.");
                Console.WriteLine($"{fish.Name}, текущий/максимальный возраст - {fish.Age}/{fish.MaxAge}, цвет - {fish.Color}, {aliveStatus}");
            }
        }

        private void RemoveDeadFishs()
        {
            for (int i = _fishs.Count - 1; i >= 0; i--)
            {
                if (_fishs[i].IsAlive == false)
                {
                    _fishs.RemoveAt(i);
                }
            }
        }

        private void AddFish()
        {
            if (_fishs.Count >= _maxCountFish)
            {
                Console.WriteLine("Аквариум переполен");
            }
            else
            {
                _fishs.Add(new Fish());
            }
        }

        private void IncreaseFishAge()
        {
            foreach (Fish fish in _fishs)
            {
                fish.IncreaseAge();
            }
        }
    }

    class Fish
    {
        private int _minRandomAgeFish = 4;
        private int _maxRandomAgeFish = 20;

        public Fish()
        {
            Name = UserUtils.InputName();
            Age = 0;
            MaxAge = UserUtils.GenerateRandomNumber(_minRandomAgeFish, _maxRandomAgeFish);
            Color = UserUtils.GenerateRandomColor();
        }

        public string Name { get; }
        public int Age { get; private set; }
        public int MaxAge { get; }
        public string Color { get; }

        public bool IsAlive => Age < MaxAge;

        public void IncreaseAge()
        {
            if (Age < MaxAge)
            {
                Age++;
            }
        }
    }
}
