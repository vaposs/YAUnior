using System;
using System.Collections.Generic;

namespace Project_12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AnimalCreator animalCreator = new AnimalCreator();
            Zoo zoo = new Zoo(animalCreator);
            zoo.Work();
            Console.ReadKey();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minInclusive, int maxExclusive)
        {
            return s_random.Next(minInclusive, maxExclusive);
        }
    }

    class Animal
    {
        private const string MaleGender = "male";
        private const string FemaleGender = "female";

        public Animal(string name, string voice, string gender, string aviaryType)
        {
            Name = name;
            Voice = voice;
            Gender = gender;
            AviaryType = aviaryType;
        }

        public string Name { get; private set; }
        public string Voice { get; private set; }
        public string Gender { get; private set; }
        public string AviaryType { get; private set; }

        public void ShowInfo()
        {
            string genderDisplay = (Gender == MaleGender) ? "Самец" : "Самка";
            Console.Write($"{Name,-15}");
            Console.Write($"{genderDisplay,-10}");
            Console.WriteLine($"{Voice}");
        }
    }

    class AnimalCreator
    {
        private const string AviaryPredators = "Хищники";
        private const string AviaryHerbivores = "Травоядные";
        private const string AviaryBirds = "Птицы";
        private const string AviaryRodents = "Грызуны";
        private const string AviaryPrimates = "Приматы";
        private const string UnknownAnimal = "Неизвестное животное";
        private const string DefaultVoice = "Издает звуки";
        private const string MaleGender = "male";
        private const string FemaleGender = "female";

        private Dictionary<string, string[]> _animalsByAviary;
        private Dictionary<string, string[]> _voicesByAnimal;

        public AnimalCreator()
        {
            InitializeAnimals();
            InitializeVoices();
        }

        private void InitializeAnimals()
        {
            _animalsByAviary = new Dictionary<string, string[]>
            {
                [AviaryPredators] = new string[] { "Лев", "Тигр", "Волк", "Медведь", "Рысь" },
                [AviaryHerbivores] = new string[] { "Зебра", "Жираф", "Слон", "Олень", "Антилопа" },
                [AviaryBirds] = new string[] { "Орел", "Попугай", "Сова", "Пингвин", "Фламинго" },
                [AviaryRodents] = new string[] { "Бобер", "Белка", "Хомяк", "Суслик", "Дикобраз" },
                [AviaryPrimates] = new string[] { "Шимпанзе", "Горилла", "Орангутан", "Лемур", "Мартышка" }
            };
        }

        private void InitializeVoices()
        {
            _voicesByAnimal = new Dictionary<string, string[]>
            {
                ["Лев"] = new string[] { "РРРРР", "Рычит", "Грозно рычит" },
                ["Тигр"] = new string[] { "Р-Р-Р", "Тигриный рык", "Рычит" },
                ["Волк"] = new string[] { "Аууууу", "Воет", "У-у-у" },
                ["Медведь"] = new string[] { "У-у-у", "Ревёт", "Рычит" },
                ["Рысь"] = new string[] { "Мурлыкает", "Фыркает", "Рычит" },
                ["Зебра"] = new string[] { "И-го-го", "Ржёт", "Фыркает" },
                ["Жираф"] = new string[] { "Мычит", "Издает низкие звуки", "Фыркает" },
                ["Слон"] = new string[] { "Ту-у-у", "Трубит", "У-у-у" },
                ["Олень"] = new string[] { "Мекает", "Блеет", "Ревёт" },
                ["Антилопа"] = new string[] { "Фыркает", "Издает звуки тревоги", "Мычит" },
                ["Орел"] = new string[] { "Клекчет", "Криии", "Клекот" },
                ["Попугай"] = new string[] { "Привет!", "Караул!", "Повторяет" },
                ["Сова"] = new string[] { "Уху-ху", "Ухает", "Х-х-х" },
                ["Пингвин"] = new string[] { "Кричит", "Издает звуки", "Гогочет" },
                ["Фламинго"] = new string[] { "Курлычет", "Издает звуки", "Кричит" },
                ["Бобер"] = new string[] { "Стучит зубами", "Пищит", "Фыркает" },
                ["Белка"] = new string[] { "Цок-цок", "Пищит", "Цокает" },
                ["Хомяк"] = new string[] { "Пищит", "Шуршит", "Фыркает" },
                ["Суслик"] = new string[] { "Свистит", "Пищит", "Цокает" },
                ["Дикобраз"] = new string[] { "Фыркает", "Шуршит иголками", "Пыхтит" },
                ["Шимпанзе"] = new string[] { "У-у-у-а-а-а", "Кричит", "Ухает" },
                ["Горилла"] = new string[] { "Бьет себя в грудь", "Рычит", "У-у-у" },
                ["Орангутан"] = new string[] { "Издает звуки", "Кричит", "Хрюкает" },
                ["Лемур"] = new string[] { "Кричит", "Мурлыкает", "Издает звуки" },
                ["Мартышка"] = new string[] { "И-и-и", "Визжит", "Кричит" }
            };
        }

        public Animal CreateAnimal(string aviaryName)
        {
            string animalName = GenerateRandomAnimalName(aviaryName);
            string voice = GenerateRandomVoice(animalName);
            string gender = GenerateRandomGender();

            return new Animal(animalName, voice, gender, aviaryName);
        }

        private string GenerateRandomAnimalName(string aviaryName)
        {
            if (_animalsByAviary.TryGetValue(aviaryName, out string[] animals))
            {
                int randomIndex = UserUtils.GenerateRandomNumber(0, animals.Length);
                return animals[randomIndex];
            }
            return UnknownAnimal;
        }

        private string GenerateRandomVoice(string animalName)
        {
            if (_voicesByAnimal.TryGetValue(animalName, out string[] voices))
            {
                int randomIndex = UserUtils.GenerateRandomNumber(0, voices.Length);
                return voices[randomIndex];
            }
            return DefaultVoice;
        }

        private string GenerateRandomGender()
        {
            string[] genders = new string[] { MaleGender, FemaleGender };
            int randomIndex = UserUtils.GenerateRandomNumber(0, genders.Length);
            return genders[randomIndex];
        }
    }

    class Aviary
    {
        private const int MinAnimalsInAviary = 2;
        private const int MaxAnimalsInAviary = 7; 

        private List<Animal> _animals;

        public Aviary(string name, List<Animal> animals)
        {
            Name = name;
            _animals = animals ?? new List<Animal>();
        }

        public string Name { get; private set; }
        public int AnimalCount => _animals.Count;

        public void ShowInfo()
        {
            Console.WriteLine($"=== Вольер: {Name} ===");
            Console.WriteLine($"Количество животных: {AnimalCount}");

            if (AnimalCount == 0)
            {
                Console.WriteLine("В вольере пока нет животных.");
                return;
            }

            Console.WriteLine("\nСписок животных:");
            Console.WriteLine("Имя\t\tПол\t\tЗвук");
            Console.WriteLine(new string('-', 40));

            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }

            int maleCount = 0;
            int femaleCount = 0;

            foreach (Animal animal in _animals)
            {
                if (animal.Gender == "male")
                    maleCount++;
                else
                    femaleCount++;
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Самцов: {maleCount}, Самок: {femaleCount}");
        }
    }

    class Zoo
    {
        private const int ExitCommandNumber = 0;
        private const string ExitCommandString = "0";

        private List<Aviary> _aviaries;
        private AnimalCreator _animalCreator;
        private bool _isWorking = true;
        private int _minCountAnimal = 2;
        private int _maxCountAnimal = 7;

        public Zoo(AnimalCreator animalCreator)
        {
            _animalCreator = animalCreator;
            _aviaries = new List<Aviary>();
        }

        public void Work()
        {
            CreateAviariesWithAnimals();
            ShowMainMenu();
        }

        private void CreateAviariesWithAnimals()
        {
            string[] aviaryNames = { "Хищники", "Травоядные", "Птицы", "Грызуны", "Приматы" };

            foreach (string name in aviaryNames)
            {
                List<Animal> animalsForAviary = GenerateAnimalsForAviary(name);
                Aviary newAviary = new Aviary(name, animalsForAviary);
                _aviaries.Add(newAviary);
            }
        }

        private List<Animal> GenerateAnimalsForAviary(string aviaryName)
        {
            List<Animal> animals = new List<Animal>();
            int animalCount = UserUtils.GenerateRandomNumber(_minCountAnimal, _maxCountAnimal);

            for (int i = 0; i < animalCount; i++)
            {
                Animal newAnimal = _animalCreator.CreateAnimal(aviaryName);
                animals.Add(newAnimal);
            }
            return animals;
        }

        private void ShowMainMenu()
        {
            if (_isWorking == false)
                return;

            Console.Clear();
            Console.WriteLine("=== Добро пожаловать в зоопарк ===");
            ShowAviaryMenu();

            Console.WriteLine($"\n{ExitCommandNumber} - выход");
            Console.Write("Выберите номер вольера: ");

            string input = Console.ReadLine();

            if (input == ExitCommandString)
            {
                _isWorking = false;
                Console.WriteLine("До свидания!");
                return;
            }

            if (int.TryParse(input, out int aviaryNumber))
            {
                if (aviaryNumber >= 1 && aviaryNumber <= _aviaries.Count)
                {
                    ShowAviaryInfo(aviaryNumber - 1);
                }
                else
                {
                    Console.WriteLine($"Вольера с номером {aviaryNumber} не существует!");
                    Console.ReadKey();
                    ShowMainMenu();
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод! Введите номер вольера.");
                Console.ReadKey();
                ShowMainMenu();
            }
        }

        private void ShowAviaryMenu()
        {
            Console.WriteLine("\nДоступные вольеры:");
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_aviaries[i].Name}");
            }
        }

        private void ShowAviaryInfo(int aviaryIndex)
        {
            Console.Clear();
            _aviaries[aviaryIndex].ShowInfo();
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            ShowMainMenu();
        }
    }
}
