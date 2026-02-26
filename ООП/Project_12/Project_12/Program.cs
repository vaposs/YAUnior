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
        private List<Aviary> _aviaries = new List<Aviary>();
        private bool _isWorking = true;

        public void Work()
        {
            CreateAviaries();
            ShowMainMenu();
        }

        private void CreateAviaries()
        {
            _aviaries.Add(new Aviary("Хищники"));
            _aviaries.Add(new Aviary("Травоядные"));
            _aviaries.Add(new Aviary("Птицы"));
            _aviaries.Add(new Aviary("Грызуны"));
            _aviaries.Add(new Aviary("Приматы"));
        }

        private void ShowMainMenu()
        {
            if (_isWorking == false)
                return;

            Console.Clear();
            Console.WriteLine("=== Добро пожаловать в зоопарк ===");
            ShowAviaryMenu();

            Console.WriteLine($"\n0 - выход");
            Console.Write("Выберите номер вольера: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int aviaryNumber))
            {
                if (aviaryNumber == 0)
                {
                    _isWorking = false;
                    Console.WriteLine("До свидания!");
                    return;
                }
                else if (aviaryNumber >= 1 && aviaryNumber <= _aviaries.Count)
                {
                    ShowAviaryInfo(aviaryNumber - 1);
                }
                else
                {
                    Console.WriteLine("Вольера с таким номером не существует!");
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

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private AnimalCreator _animalCreator = new AnimalCreator();

        public string Name { get; private set; }

        public Aviary(string name)
        {
            Name = name;
            CreateAnimals();
        }

        private void CreateAnimals()
        {
            int animalCount = UserUtils.GenerateRandomNumber(2, 7);

            for (int i = 0; i < animalCount; i++)
            {
                _animals.Add(_animalCreator.GetAnimal(Name));
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"=== Вольер: {Name} ===");
            Console.WriteLine($"Количество животных: {_animals.Count}");
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

    class AnimalCreator
    {
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
                ["Хищники"] = new string[] { "Лев", "Тигр", "Волк", "Медведь", "Рысь" },
                ["Травоядные"] = new string[] { "Зебра", "Жираф", "Слон", "Олень", "Антилопа" },
                ["Птицы"] = new string[] { "Орел", "Попугай", "Сова", "Пингвин", "Фламинго" },
                ["Грызуны"] = new string[] { "Бобер", "Белка", "Хомяк", "Суслик", "Дикобраз" },
                ["Приматы"] = new string[] { "Шимпанзе", "Горилла", "Орангутан", "Лемур", "Мартышка" }
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

        public Animal GetAnimal(string aviaryName)
        {
            string animalName = GetRandomAnimalName(aviaryName);
            string voice = GetRandomVoice(animalName);
            string gender = GetRandomGender();

            return new Animal(animalName, voice, gender, aviaryName);
        }

        private string GetRandomAnimalName(string aviaryName)
        {
            if (_animalsByAviary.ContainsKey(aviaryName))
            {
                string[] animals = _animalsByAviary[aviaryName];
                return animals[UserUtils.GenerateRandomNumber(0, animals.Length)];
            }

            return "Неизвестное животное";
        }

        private string GetRandomVoice(string animalName)
        {
            if (_voicesByAnimal.ContainsKey(animalName))
            {
                string[] voices = _voicesByAnimal[animalName];
                return voices[UserUtils.GenerateRandomNumber(0, voices.Length)];
            }

            return "Издает звуки";
        }

        private string GetRandomGender()
        {
            string[] genders = new string[] { "male", "female" };
            return genders[UserUtils.GenerateRandomNumber(0, genders.Length)];
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
            Console.Write($"{Name,-15}");
            Console.Write($"{(Gender == "male" ? "Самец" : "Самка"),-10}");
            Console.WriteLine($"{Voice}");
        }
    }
}
