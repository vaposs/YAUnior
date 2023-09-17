using System;
using System.Collections.Generic;
using System.IO;

//Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать, к какому вольеру подойти.
//
//При приближении к вольеру, пользователю выводится информация о том, что это за вольер, сколько животных там обитает, их пол и какой звук издает животное.

//Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.

// создать розширяемость количества вольеров

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
        string _animalsInfo;
        string[] _animalsDataTable;
        List<Animal> _animals = new List<Animal>();
        List<Animal> _birdsAviary = new List<Animal>();
        List<Animal> _amphibiansAviary = new List<Animal>();
        List<Animal> _reptilesAviary = new List<Animal>();
        List<Animal> _mammalsAviary = new List<Animal>();
        List<Animal> _fishsAviary = new List<Animal>();
        int _numberAviary = 0;

        public void Work()
        {
            //ConsoleKey move;
            //const ConsoleKey KeyExit = ConsoleKey.Escape;
            //bool work = true;

            InputAnimalInfo();
            FillingCharacteristicsAnimal();
            CreateAnimals();
            AllocationAnimalsAviary();

            Console.WriteLine($"{_animals.Count} +++++");

            /*

            Console.WriteLine("птицы");

            foreach (Animal animal in _birdsAviary)
            {
                animal.ShowInfo();
            }

            Console.WriteLine("амфибии");

            foreach (Animal animal in _amphibiansAviary)
            {
                animal.ShowInfo();
            }

            Console.WriteLine("рептилии");

            foreach (Animal animal in _reptilesAviary)
            {
                animal.ShowInfo();
            }

            Console.WriteLine("хордовые");

            foreach (Animal animal in _mammalsAviary)
            {
                animal.ShowInfo();
            }

            Console.WriteLine("рыбы");

            foreach (Animal animal in _fishsAviary)
            {
                animal.ShowInfo();
            }

            /*

            while(work)
            {
                Console.WriteLine("Для передвижения в зоопарке стрелки верх(⇧) и вниз(⇩), для выхода нажмите ESC:");

                move = MovingZoo();

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

            */
        }

        private void InputAnimalInfo()  // прочитали информацию с файла записали в строку
        {
            string filePath = "/Users/walter/GitHub/YAUnior/ООП/Project_12/Project_12/animals_info.txt";
            StreamReader animalsInfoDocument = new StreamReader(filePath);
            _animalsInfo = animalsInfoDocument.ReadToEnd();

            Console.WriteLine(_animalsInfo);
        }

        private void FillingCharacteristicsAnimal()  // создали масив строк характеристик животных
        {
            _animalsDataTable = _animalsInfo.Split('\n');
        }

        private void CreateAnimals()  // создали животных
        {
            string[] animalInfo;
            int indexName = 0;
            int indexVoice = 1;
            int indexGender = 2;
            int indexType = 3;

            for (int i = 0; i < _animalsDataTable.Length; i++)
            {
                animalInfo = _animalsDataTable[i].Split('_');
                _animals.Add(new Animal(animalInfo[indexName], animalInfo[indexVoice], animalInfo[indexGender], animalInfo[indexType]));
            }

            Console.WriteLine(_animals.Count + "верх");
        }

        private ConsoleKey MovingZoo()
        {
            ConsoleKey consoleKey;

            return consoleKey = Console.ReadKey().Key;
        }  // считывает нажатую кнопку с клавиатуры

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
                        Console.WriteLine("что то пошло не так (AllocationAnimalsAviary)");
                        break;
                }
            }

        } // распределения животных по вольерам

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
        }  // вывод на екран животных в вольере

        private void ShowAnimal(List<Animal> animals)
        {
            Console.WriteLine($"вы подошли к вольеру с {animals.GetType()}, здесь {animals.Count} животных");

            foreach (Animal animal in animals)
            {
                animal.ShowInfo();
            }
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
            NumberAviary();
            ShowAnimalAviary(_numberAviary);
        }

        private void DownArrow()
        {
            NumberAviary();
            ShowAnimalAviary(_numberAviary);
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
            Console.Write(Name + "\t\t");
            Console.Write(Gender + "\t");
            Console.Write(AnimalVoice + "\t");
            Console.WriteLine(Type);
        }
    }
}