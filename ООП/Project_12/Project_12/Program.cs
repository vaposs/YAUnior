using System;
using System.Collections.Generic;

//2. ESC замените переменной в строке. - встроке 88 ЕSC заменяется переменной. не ясен коментарий

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
        Aviary _aviary = new Aviary();
        private int _numberAviary = 0;
        private int _firstElementDictionary = 1;
        Dictionary<int, List<Animal>> _animalsDictionary = new Dictionary<int, List<Animal>>();

        public void Work()
        {
            ConsoleKey move;
            const ConsoleKey KeyExit = ConsoleKey.Escape;
            bool work = true;

            CreateAnimalDictionary();

            while (work)
            {
                Console.WriteLine("Для передвижения в зоопарке стрелки верх(⇧) и вниз(⇩), для выхода нажмите ESC:");

                move = MovingZoo();
                Console.Clear();

                switch (move)
                {
                    case ConsoleKey.UpArrow:
                        PressUpArrow();
                        break;
                    case ConsoleKey.DownArrow:
                        PressDownArrow();
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

        private void CreateAnimalDictionary()
        {
            _animalsDictionary.Add(1, _aviary.CreateAnimal());
            _animalsDictionary.Add(2, _aviary.CreateAnimal());
            _animalsDictionary.Add(3, _aviary.CreateAnimal());
            _animalsDictionary.Add(4, _aviary.CreateAnimal());
            _animalsDictionary.Add(5, _aviary.CreateAnimal());
        }

        private ConsoleKey MovingZoo()
        {
            ConsoleKey consoleKey;

            return consoleKey = Console.ReadKey().Key;
        }

        private void ChooseAviary(int numberAviary)
        {
            List<Animal> animals;
            _animalsDictionary.TryGetValue(numberAviary, out animals);
            ShowAnimal(animals);
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

        private void ChangeNumberAviary()
        {
            if(_numberAviary < _firstElementDictionary)
            {
                _numberAviary = _animalsDictionary.Count;
            }
            else if(_numberAviary > _animalsDictionary.Count)
            {
                _numberAviary = _firstElementDictionary;
            }
        }

        private void PressUpArrow()
        {
            _numberAviary--;
            ChangeNumberAviary();
            ChooseAviary(_numberAviary);
        }

        private void PressDownArrow()
        {
            _numberAviary++;
            ChangeNumberAviary();
            ChooseAviary(_numberAviary);
        }
    }

    class Aviary
    {
        const string _Bird = "bird";
        const string _Amphibian = "amphibian";
        const string _Reptile = "reptile";
        const string _Mammal = "mammal";
        const string _Fish = "fish";

        private int _indexNumber = 1;
        private int _animalInAviary = 4;

        public List<Animal> CreateAnimal()
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < _animalInAviary; i++)
            {
                animals.Add(new Animal(GetName(), GetAnimalVoice(), GetGender(), GetType()));
                _indexNumber++;
            }

            return animals;
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
            string[] gender = new string[] { "male", "female" };

            return gender[UserUtils.GenerateRandomNumber(0, gender.Length)];
        }

        private string GetType()
        {
            int firstType = 4;
            int secondType = 8;
            int thirdType = 12;
            int fourthType = 16;

            if (_indexNumber <= firstType)
            {
                return _Bird;
            }
            else if (_indexNumber > firstType && _indexNumber <= secondType)
            {
                return _Amphibian;
            }
            else if (_indexNumber > secondType && _indexNumber <= thirdType)
            {
                return _Reptile;
            }
            else if (_indexNumber > thirdType && _indexNumber <= fourthType)
            {
                return _Mammal;
            }
            else
            {
                return _Fish;
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