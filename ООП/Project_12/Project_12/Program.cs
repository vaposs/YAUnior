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
    }

    class Zoo
    {
        private Aviary _aviary = new Aviary();
        private int _numberAviary = 0;
        private int _firstElementDictionary = 1;
        private Dictionary<int, List<Animal>> _animalsDictionary = new Dictionary<int, List<Animal>>();

        public void Work()
        {
            const ConsoleKey KeyExit = ConsoleKey.Escape;
            const ConsoleKey MoveUpCommand = ConsoleKey.UpArrow;
            const ConsoleKey MoveDownCommand = ConsoleKey.DownArrow;

            ConsoleKey move;
            bool work = true;

            CreateAnimalDictionary();

            while (work)
            {
                Console.WriteLine("Для передвижения в зоопарке стрелки верх(⇧) и вниз(⇩), для выхода нажмите ESC:");

                move = MovingZoo();
                Console.Clear();

                switch (move)
                {
                    case MoveUpCommand:
                        PressUpArrow();
                        break;
                    case MoveDownCommand:
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
            _animalsDictionary.Add(1, _aviary.CreateAnimalsList());
            _animalsDictionary.Add(2, _aviary.CreateAnimalsList());
            _animalsDictionary.Add(3, _aviary.CreateAnimalsList());
            _animalsDictionary.Add(4, _aviary.CreateAnimalsList());
            _animalsDictionary.Add(5, _aviary.CreateAnimalsList());
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
        private int _animalInAviary = 4;
        private AnimalCreator _animalCreator = new AnimalCreator();

        public List<Animal> CreateAnimalsList()
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < _animalInAviary; i++)
            {
                animals.Add(_animalCreator.GetAnimal());
            }

            return animals;
        }
    }

    class AnimalCreator
    {
        const string _FirstAviary = "Вольер_1";
        const string _SecondAviary = "Вольер_2";
        const string _ThirdAviary = "Вольер_3";
        const string _FourthAviary = "Вольер_4";
        const string _FifthAviary = "Вольер_5";

        private int _firstType = 4;
        private int _secondType = 8;
        private int _thirdType = 12;
        private int _fourthType = 16;

        private int _indexNumber = 1;
        private int _randomNumber;

        public Animal GetAnimal()
        {
            _indexNumber++;
            return new Animal(GetName(), GetAnimalVoice(), GetGender(), GetType());
        }

        private string GetName()
        {
            string[] nameAnimal = new string[]
            {
                "петух", "курица", "утка","соловей",
                "корова", "мыш", "собака", "кот",
                "лев", "волк", "свинья", "коза",
                "барашек", "сова", "уж", "осел",
                "павлин", "ежик", "лягушка", "лошадь"
            };

            _randomNumber = UserUtils.GenerateRandomNumber(0, nameAnimal.Length);

            return nameAnimal[_randomNumber];
        }

        private string GetAnimalVoice()
        {
            string[] voice = new string[]
            {
                "кукареку", "ко-ко-ко", "кря-кря", "уиииии",
                "мууу", "пи-пи", "гав-гав", "мяуууу",
                "агрррр", "авууууу", "хрю-хрю", "меееее",
                "бееее", "ухуууу", "шшшшшш", "иааа",
                 "ааааа", "фыр-фыр", "ква-ква", "иго-го"
            };
            return voice[_randomNumber];
        }

        private string GetGender()
        {
            string[] gender = new string[] { "male", "female" };

            return gender[UserUtils.GenerateRandomNumber(0, gender.Length)];
        }

        private string GetType()
        {
            if (_indexNumber <= _firstType)
            {
                return _FirstAviary;
            }
            else if (_indexNumber > _firstType && _indexNumber <= _secondType)
            {
                return _SecondAviary;
            }
            else if (_indexNumber > _secondType && _indexNumber <= _thirdType)
            {
                return _ThirdAviary;
            }
            else if (_indexNumber > _thirdType && _indexNumber <= _fourthType)
            {
                return _FourthAviary;
            }
            else
            {
                return _FifthAviary;
            }
        }
    }

    class Animal
    {
        public Animal(string name, string voice, string gender, string type)
        {
            Name = name;
            Voice = voice;
            Gender = gender;
            Type = type;
        }

        public string Name { get; private set; }
        public string Voice { get; private set; }
        public string Gender { get; private set; }
        public string Type { get; private set; }

        public void ShowInfo()
        {
            Console.Write(Name + "\t");
            Console.Write(Gender + "\t");
            Console.Write(Voice + "\t");
            Console.WriteLine(Type);
        }
    }
}

//5) Вольер может содержать список животных, которые в нем находятся.
//Но создавать животных для вольера - это не его ответственность.
//Это может сделать или Зоопарк или отдельный класс, генерирующий животных для вольера.
