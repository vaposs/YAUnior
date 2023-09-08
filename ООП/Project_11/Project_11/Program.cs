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
        static Random _random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return _random.Next(minRandomNumber, maxRandomNumber);
        }

        public static int GetPositiveNumber()
        {
            string userString;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                userString = Console.ReadLine();
                isCorrectNumber = int.TryParse(userString, out number);

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

    class Aquarium
    {
        private int _maxCountFish = 10;
        private List<Fish> _fishInAquarium = new List<Fish>();
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
                foreach (Fish fish in _fishInAquarium)
                {
                    fish.WaitOneDay();
                }

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
                    case "1":
                        _countDay++;
                        Console.WriteLine("ждем");
                        break;
                    case "2":
                        AddFish();
                        break;
                    case "3":
                        RemoveDeadFishs();
                       break;
                    case "4":
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
            foreach (Fish fish in _fishInAquarium)
            {
                fish.Draw(fish.Color);
            }

            foreach (Fish fish in _fishInAquarium)
            {
                Console.Write($"{index++}.");
                fish.ShowInfo();
            }
        }

        private void RemoveDeadFishs()
        {
            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                if(_fishInAquarium[i].IsAlive == false)
                {
                    _fishInAquarium.Remove(_fishInAquarium[i]);
                    i--;
                }
            }
        }

        private void AddFish()
        {
            if(_fishInAquarium.Count >= _maxCountFish)
            {
                Console.WriteLine("Аквариум переполен");
            }
            else
            {
                _fishInAquarium.Add(new Fish());
            }
        }
    }

    class Fish
    {
        int _ageFish = 0;
        int _minRandomAgeFish = 4;
        int _maxRandomAgeFish = 20;

        public Fish()
        {
            Name = GetName();
            Age = _ageFish;
            MaxAge = UserUtils.GenerateRandomNumber(_minRandomAgeFish, _maxRandomAgeFish);
            Color = GetRandomColor();
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

        public void Draw(string color)
        {
            const string greenColor = "green";
            const string yellowColor = "yellow";
            const string redColor = "red";
            const string blueColor = "blue";
            const string whiteColor = "white";

            switch (color)
            {
                case greenColor:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case yellowColor:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case redColor:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case blueColor:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case whiteColor:
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
                    Console.Write(fishPicture[i,j]);
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, текущий/максимальный возраст - {Age}/{MaxAge}, цвет - {Color}, жива/мертва - {IsAlive}");
        }

        private string GetName()
        {
            Console.Write("придумайте имя рыбке - ");
            return Console.ReadLine();
        }

        private string GetRandomColor()
        {
            string[] color = new string[]
            {
                "green", "yellow", "red", "blue", "white"
            };

            int indexColor = UserUtils.GenerateRandomNumber(0,color.Length);

            return color[indexColor];
        }
    }
}
