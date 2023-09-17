using System;
using System.Collections.Generic;

namespace Project_12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            new Zoo().Work();

            Console.ReadKey();
        }
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static int GetPositiveNumber()
        {
            string userInputString;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                userInputString = Console.ReadLine();
                isCorrectNumber = int.TryParse(userInputString, out number);

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

        public static ConsoleKeyInfo Navigation()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            return consoleKey;
        }
    }

    class Zoo
    {
        int _indexNumber = 1;
        List<Animal> _animals = new List<Animal>();
        List<Animal> _birdsAviary = new List<Animal>();
        List<Animal> _amphibiansAviary = new List<Animal>();
        List<Animal> _reptilesAviary = new List<Animal>();
        List<Animal> _mammalsAviary = new List<Animal>();
        List<Animal> _fishsAviary = new List<Animal>();
        int _numberAviary = 0;

        public void Work()
        {
            ConsoleKey move;
            const ConsoleKey KeyExit = ConsoleKey.Escape;
            bool work = true;

            CreateAnimal();
            AllocationAnimalsAviary();

            while (work)
            {
                Console.WriteLine("Для передвижения в зоопарке стрелки верх(⇧) и вниз(⇩), для выхода нажмите ESC:");

                move = MovingZoo();
                Console.Clear();

                switch (move)
                {
                    case ConsoleKey.UpArrow:
                        UpArrow();
                        break;
                    case ConsoleKey.DownArrow:
                        DownArrow();
                        break;
                    case KeyExit:
                        work = false;
                        break;
                    default:
                        Console.WriteLine("неверная кнопка, повторите ввод");
                        break;
                }
            }
        }

        private ConsoleKey MovingZoo()
        {
            ConsoleKey consoleKey;

            return consoleKey = Console.ReadKey().Key;
        }

        private void AllocationAnimalsAviary()
        {
            const string Bird = "bird";
            const string Amphibian = "amphibian";
            const string Reptile = "reptile";
            const string Mammal = "mammal";
            const string Fish = "fish";

            foreach (Animal animal in _animals)
            {
                switch (animal.Type)
                {
                    case Bird:
                        _birdsAviary.Add(animal);
                        break;
                    case Amphibian:
                        _amphibiansAviary.Add(animal);
                        break;
                    case Reptile:
                        _reptilesAviary.Add(animal);
                        break;
                    case Mammal:
                        _mammalsAviary.Add(animal);
                        break;
                    case Fish:
                        _fishsAviary.Add(animal);
                        break;
                    default:
                        animal.ShowInfo();
                        Console.WriteLine("что то пошло не так (AllocationAnimalsAviary)");
                        break;
                }
            }

        }

        private void ShowAnimalAviary(int numberAviary)
        {
            const int FirstAviary = 1;
            const int SecondAviary = 2;
            const int ThirdAviary = 3;
            const int FourthAviary = 4;
            const int FifthAviary = 5;

            switch (numberAviary)
            {
                case FirstAviary:
                    ShowAnimal(_birdsAviary);
                    break;
                case SecondAviary:
                    ShowAnimal(_amphibiansAviary);
                    break;
                case ThirdAviary:
                    ShowAnimal(_reptilesAviary);
                    break;
                case FourthAviary:
                    ShowAnimal(_mammalsAviary);
                    break;
                case FifthAviary:
                    ShowAnimal(_fishsAviary);
                    break;
                default:
                    Console.WriteLine("что то пошло не так (ShowAnimalAviary)");
                    break;
            }
        }

        private void ShowAnimal(List<Animal> animals)
        {
            Console.WriteLine($"вы подошли к вольеру с {GetNameAviary(animals)}, здесь {animals.Count} животных");

            foreach (Animal animal in animals)
            {
                animal.ShowInfo();
            }
        }

        private string GetNameAviary(List<Animal> animals)
        {
            return(animals[0].Type);
        }

        private void NumberAviary()
        {
            if(_numberAviary < 1)
            {
                _numberAviary = 5;
            }
            else if(_numberAviary > 5)
            {
                _numberAviary = 1;
            }
        }

        private void UpArrow()
        {
            _numberAviary--;
            NumberAviary();
            ShowAnimalAviary(_numberAviary);
        }

        private void DownArrow()
        {
            _numberAviary++;
            NumberAviary();
            ShowAnimalAviary(_numberAviary);
        }

        private void CreateAnimal()
        {
            int animalCount = 20;

            for (int i = 0; i < animalCount; i++)
            {
                _animals.Add(new Animal(GetName(),GetAnimalVoice(), GetGender(), GetType()));
                _indexNumber++;
            }
        }

        private string GetName()
        {
            string nameAnimal = $"nameAnimal{_indexNumber}";
            return nameAnimal;
        }

        private string GetAnimalVoice()
        {
            string animalVoice = $"animalVoice{_indexNumber}";
            return animalVoice;
        }

        private string GetGender()
        {
            string gender;

            if (_indexNumber % 2 == 1)
            {
                return gender = "male";
            }
            else
            {
                return gender = "female";
            }
        }

        private string GetType()
        {
            const string Bird = "bird";
            const string Amphibian = "amphibian";
            const string Reptile = "reptile";
            const string Mammal = "mammal";
            const string Fish = "fish";

            if (_indexNumber <= 4)
            {
                return Bird;
            }
            else if (_indexNumber > 4 && _indexNumber <= 8)
            {
                return Amphibian;
            }
            else if (_indexNumber > 8 && _indexNumber <= 12)
            {
                return Reptile;
            }
            else if (_indexNumber > 12 && _indexNumber <= 16)
            {
                return Mammal;
            }
            else
            {
                return Fish;
            }
        }
    }

    class Animal
    {
        public Animal(string name, string animalVoice, string gender, string type)
        {
            Name = name;
            AnimalVoice = animalVoice;
            Gender = gender;
            Type = type;
        }

        public string Name { get; private set; }
        public string AnimalVoice { get; private set; }
        public string Gender { get; private set; }
        public string Type { get; private set; }

        public void ShowInfo()
        {
            Console.Write(Name + "\t");
            Console.Write(Gender + "\t");
            Console.Write(AnimalVoice + "\t");
            Console.WriteLine(Type);
        }
    }
}