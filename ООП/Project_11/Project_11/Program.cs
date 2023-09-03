using System;
using System.Collections.Generic;

namespace Project_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.WatchTheFish();
        }
    }

    class Aquarium
    {
        private int _maxCountFish = 3;

        private List<Fish> _fishs = new List<Fish>();
        private List<Fish> _fishInAquarium = new List<Fish>();
        private int _countDay = 1;

        public Aquarium()
        {
            _fishs.Add(new Fish1("fish_1", 1, 5, "green", true));
            _fishs.Add(new Fish2("fish_2", 1, 9, "yellow", true));
            _fishs.Add(new Fish3("fish_3", 1, 12, "red", true));
            _fishs.Add(new Fish4("fish_4", 1, 15, "blu", true));
            _fishs.Add(new Fish5("fish_5", 1, 17, "white", true));
        }

        public void WatchTheFish()
        {
            const string WaitNexDayString = "ждать следущего дня";
            const string WaitNexDayCommand = "1";
            const string AddFishString = "добавить рыбку";
            const string AddFishCommand = "2";
            const string RemoveDeadFishString = "убрать мертвых рыб";
            const string RemoveDeadFishCommand = "3";
            const string ExitString = "выход";
            const string ExitCommand = "4";

            bool isNextDay = true;

            while (isNextDay)
            {
                ShowFishInAquarium();
                foreach (Fish fish in _fishInAquarium)
                {
                    fish.OneDay();
                }

                Console.WriteLine($"День {_countDay}");
                Console.WriteLine("вы стоите перед аквариумом, что вы хотите сделать:");
                Console.WriteLine($"{WaitNexDayCommand}.{WaitNexDayString}");
                Console.WriteLine($"{AddFishCommand}.{AddFishString}");
                Console.WriteLine($"{RemoveDeadFishCommand}.{RemoveDeadFishString}");
                Console.WriteLine($"{ExitCommand}.{ExitString}");
                Console.Write("\nВведите номер команды - ");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case WaitNexDayCommand:
                        _countDay++;
                        Console.WriteLine("ждем");
                        break;
                    case AddFishCommand:
                        AddFish();
                        break;
                    case RemoveDeadFishCommand:
                        RemoveDeadFish();
                       break;
                    case ExitCommand:
                        Console.WriteLine("вышли");
                        isNextDay = false;
                        break;
                    default:
                        Console.WriteLine("неверная команда");
                        break;
                }

                Console.Clear();
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

        private void RemoveDeadFish()
        {
            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                if(_fishInAquarium[i].IsAlive == false)
                {
                    _fishInAquarium.Remove(_fishInAquarium[i]);
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
                _fishInAquarium.Add(FishChoice());
            }
        }

        private void ShowAllFish()
        {
            foreach (Fish fish in _fishs)
            {
                fish.ShowInfo();
            }
        }

        private Fish FishChoice()
        {
            bool isRightChoice = true;
            Fish fish = null;

            while (isRightChoice)
            {
                ShowAllFish();
                Console.Write("Рыбка под номеров - ");

                int command = GetNumber();

                if (--command > _fishs.Count)
                {
                    Console.WriteLine("неверный ввод числа");
                }
                else
                {
                    fish = _fishs[command].Clone();
                    isRightChoice = false;
                }
            }

            return fish;
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
                        Console.Write("Неверный ввод. Число меньше нуля.");
                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.Write("Неверный ввод.");
                }
            }

            return number;
        }

    }

    abstract class Fish
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public int MaxAge { get; protected set; }
        public string Color { get; protected set; }
        public bool IsAlive { get; protected set; }

        public Fish(string name, int age, int maxAge, string color, bool isAlive)
        {
            Name = name;
            Age = age;
            MaxAge = maxAge;
            Color = color;
            IsAlive = isAlive;
        }

        public void OneDay()
        {
            Age++;
            if(Age >= MaxAge)
            {
                Age = MaxAge;
                IsDead();
            }
        }

        private void IsDead()
        {
            IsAlive = false;
        }

        public void Draw(string color)
        {
            switch (color)
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blu":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "white":
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

        public abstract Fish Clone();

    }

    class Fish1 : Fish 
    {
        public Fish1(string name, int age, int maxAge, string color, bool isAlive) : base(name, age, maxAge, color, isAlive)
        {

        }

        private Fish1(Fish1 fish1) : this(fish1.Name, fish1.Age, fish1.MaxAge, fish1.Color, fish1.IsAlive)
        {

        }

        public override Fish Clone()
        {
            return new Fish1("fish_1", 1, 5, "green", true);
        }
    }

    class Fish2 : Fish
    {
        public Fish2(string name, int age, int maxAge, string color, bool isAlive) : base(name, age, maxAge, color, isAlive)
        {

        }

        private Fish2(Fish2 fish2) : this(fish2.Name, fish2.Age, fish2.MaxAge, fish2.Color, fish2.IsAlive)
        {

        }

        public override Fish Clone()
        {
            return new Fish2("fish_2", 1, 9, "yellow", true);
        }
    }

    class Fish3 : Fish
    {
        public Fish3(string name, int age, int maxAge, string color, bool isAlive) : base(name, age, maxAge, color, isAlive)
        {

        }

        private Fish3(Fish3 fish3) : this(fish3.Name, fish3.Age, fish3.MaxAge, fish3.Color, fish3.IsAlive)
        {

        }

        public override Fish Clone()
        {
            return new Fish3("fish_3", 1, 12, "red", true);
        }
    }

    class Fish4 : Fish
    {
        public Fish4(string name, int age, int maxAge, string color, bool isAlive) : base(name, age, maxAge, color, isAlive)
        {

        }

        private Fish4(Fish4 fish4) : this(fish4.Name, fish4.Age, fish4.MaxAge, fish4.Color, fish4.IsAlive)
        {

        }

        public override Fish Clone()
        {
            return new Fish4("fish_4", 1, 15, "blu", true);
        }
    }

    class Fish5 : Fish
    {
        public Fish5(string name, int age, int maxAge, string color, bool isAlive) : base(name, age, maxAge, color, isAlive)
        {

        }

        private Fish5(Fish5 fish5) : this(fish5.Name, fish5.Age, fish5.MaxAge, fish5.Color, fish5.IsAlive)
        {

        }

        public override Fish Clone()
        {
            return new Fish5("fish_5", 1, 17, "white", true);
        }
    }

}
