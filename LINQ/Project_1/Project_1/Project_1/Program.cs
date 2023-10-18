using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Database database = new Database();

            database.Work();
            Console.WriteLine("Конец");
            Console.ReadKey();
        }
    }

    class Database
    {
        private SuspectCreator SuspectCreator = new SuspectCreator();
        private List<Suspect> _suspects = new List<Suspect>();
        private string[] _nationals;

        public void Work()
        {
            CreateListSuspect();
            _nationals = SuspectCreator.GetAllNational();

            Console.WriteLine($"Количество подозреаемых - {_suspects.Count}");
            ShowSuspect(_suspects);

            Console.WriteLine("Результат поиска:");
            ShowSuspect(FilterSuspects());
        }

        private List<Suspect> FilterSuspects()
        {
            Console.WriteLine("введите параметры поиска:");
            int height = GetSearchParameterHeight();
            int weight = GetSearchParameterWeight();
            string national = GetSearchParameterNational(_nationals);

            var filterSuspects = from Suspect suspect in _suspects
                                 where suspect.Height == height
                                        && suspect.Weight == weight
                                        && suspect.Nationality == national
                                        && suspect.Detained == false
                                 select suspect;

            return filterSuspects.ToList();
        }

        private int GetSearchParameterHeight()
        {
            Console.Write($"Введите рост подозреваемого ({GetMinHeihtg()}/{GetMaxHeihtg()}) - ");
            return UserUtils.GetPositiveNumber();
        }

        private int GetSearchParameterWeight()
        {
            Console.Write($"Введите вес подозреваемого ({GetMinWeight()}/{GetMaxWeight()}) - ");
            return UserUtils.GetPositiveNumber();
        }

        private string GetSearchParameterNational(string[] nationals)
        {
            string choceDetective = "";
            bool isGoodChoce = true;

            while (isGoodChoce)
            {
                foreach (string national in nationals)
                {
                    Console.Write(national + ", ");
                }

                Console.Write("\nвведите национальность подозреваемого из представленого списка:");
                choceDetective = Console.ReadLine();

                foreach (string national in nationals)
                {
                    if (national == choceDetective)
                    {
                        isGoodChoce = false;
                        break;
                    }
                }
            }

            return choceDetective;
        }

        private void CreateListSuspect()
        {
            int minSuspects = 100;
            int maxSuspects = 150;
            int countSuspects = UserUtils.GenerateRandomNumber(minSuspects, maxSuspects);

            for (int i = 0; i < countSuspects; i++)
            {
                _suspects.Add(SuspectCreator.Creator());
            }
        }

        private void ShowSuspect(List<Suspect> suspects)
        {
            int index = 1;

            foreach (Suspect suspect in suspects)
            {
                string status = (suspect.Detained == true) ? "задержан" : "на свободе";
                Console.WriteLine($"{index}.{suspect.Name} - {status} - {suspect.Height}/{suspect.Weight} - {suspect.Nationality}");
                index++;
            }
        }

        private int GetMaxHeihtg()
        {
            var maxHeight = _suspects.Max(suspect => suspect.Height);

            return maxHeight;
        }

        private int GetMinHeihtg()
        {
            var maxHeight = _suspects.Min(suspect => suspect.Height);

            return maxHeight;
        }

        private int GetMaxWeight()
        {
            var maxWeight = _suspects.Max(suspect => suspect.Weight);

            return maxWeight;
        }

        private int GetMinWeight()
        {
            var maxWeight = _suspects.Min(suspect => suspect.Weight);

            return maxWeight;
        }
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber)
        {
            return s_random.Next(minRandomNumber, maxRandomNumber);
        }

        public static bool GenerateRandomBool()
        {
            bool[] logic = { true, false };

            return logic[s_random.Next(0, logic.Length)];
        }

        public static int GetPositiveNumber()
        {
            string readName;
            bool isConversionSucceeded = true;
            int number = 0;

            while (isConversionSucceeded)
            {
                readName = Console.ReadLine();

                if (int.TryParse(readName, out number))
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

    class Suspect
    {
        public Suspect(string name, int height, int weight, string national, bool detained)
        {
            Name = name;
            Detained = detained;
            Height = height;
            Weight = weight;
            Nationality = national;
        }

        public string Name { get; private set; }
        public bool Detained { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }


    }

    class SuspectCreator
    {
        private string[] _nationals = new string[] { "HKG", "GRL", "GEO", "DNK", "UK" };

        public Suspect Creator()
        {
            return new Suspect(GetName(), GetHeight(), GetWeight(), GetNationality(), UserUtils.GenerateRandomBool());
        }

        private string GetNationality()
        {
            return _nationals[UserUtils.GenerateRandomNumber(0, _nationals.Length)];
        }

        private string GetName()
        {
            string[] names = new string[] { "Петя", "Филя", "Семен", "Вася", "Степа" };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }

        private int GetHeight()
        {
            int minHeight = 150;
            int maxHeight = 220;

            return UserUtils.GenerateRandomNumber(minHeight, maxHeight);
        }

        private int GetWeight()
        {
            int minWeight = 55;
            int maxWeight = 100;

            return UserUtils.GenerateRandomNumber(minWeight, maxWeight);
        }

        public string[] GetAllNational()
        {
            return _nationals;
        }
    }
}
