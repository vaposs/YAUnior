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
        private List<Suspect> _suspects = new List<Suspect>();

        private List<string> _nationals;

        public void Work()
        {
            CreateListSuspect();
            _nationals = CreateListNationals();

            Console.WriteLine($"Количество подозреаемых - {_suspects.Count}");
            ShowSuspect(); //-- вывод изначального списка

            Console.WriteLine("введите параметры поиска:");
            
            int height = GetSearchParameterHeight();
            int weight = GetSearchParameterWeight();
            string national = GetSearchParameterNational();

            var filterSuspects = from Suspect suspect in _suspects
                                 where suspect.Height == height
                                 where suspect.Weight == weight
                                 where suspect.Nationality == national
                                 where suspect.Detained == false
                                 select suspect;

            int index = 1;
            Console.WriteLine(filterSuspects.Count());

            foreach (var suspect1 in filterSuspects)
            {
                string status = GetText(suspect1.Detained);
                Console.WriteLine($"{index}.{suspect1.Name} - {status} - {suspect1.Height}/{suspect1.Weight} - {suspect1.Nationality}");
                index++;
            }
        }

        private int GetSearchParameterHeight()
        {
            Console.Write("Введите рост подозреваемого (150/220) - ");
            return UserUtils.GetPositiveNumber();
        }

        private int GetSearchParameterWeight()
        {
            Console.Write("Введите вес подозреваемого (55/100) - ");
            return UserUtils.GetPositiveNumber();
        }

        private string GetSearchParameterNational()
        {
            string choceDetective = "";
            bool goodChoce = true;


            while (goodChoce)
            {
                foreach (string national in _nationals)
                {
                    Console.Write(national + ", ");
                }

                Console.Write("\nвведите национальность подозреваемого из представленого списка:");

                choceDetective = Console.ReadLine();

                foreach (string national in _nationals)
                {
                    if (national == choceDetective)
                    {
                        goodChoce = false;
                        break;
                    }
                }
            }

            return choceDetective;
        }

        private List<string> CreateListNationals()
        {
            List<string> nationals = new List<string>();
            bool repick;

            foreach (Suspect suspect in _suspects)
            {
                repick = false;

                if(nationals.Count < 1)
                {
                    nationals.Add(suspect.Nationality);
                    repick = true;
                }
                else
                {
                    foreach (string national in nationals)
                    {
                        if(suspect.Nationality == national)
                        {
                            repick = true;
                        }
                    }
                }

                if (repick == false)
                {
                    nationals.Add(suspect.Nationality);
                }
            }

            return nationals;
        }

        private void CreateListSuspect()
        {
            int minSuspects = 10000;
            int maxSuspects = 15000;


            for (int i = 0; i < UserUtils.GenerateRandomNumber(minSuspects, maxSuspects); i++)
            {
                _suspects.Add(new Suspect());
            }

        }

        private void ShowSuspect()
        {
            int index = 1;

            foreach (Suspect suspect in _suspects)
            {
                string status = GetText(suspect.Detained);

                Console.WriteLine($"{index}.{suspect.Name} - {status} - {suspect.Height}/{suspect.Weight} - {suspect.Nationality}");
                index++;
            }
        }

        private string GetText(bool status)
        {
            if(status == true)
            {
                return "задержан";
            }
            else
            {
                return "на свободе";
            }
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
            return s_random.Next(2) < 1;
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
    }

    class Suspect
    {
        public Suspect()
        {
            Name = GetName();
            Detained = UserUtils.GenerateRandomBool();
            Height = GetHeight();
            Weight = GetWeight();
            Nationality = GetNationality();
        }

        public string Name { get; private set; }
        public bool Detained { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

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

        private string GetNationality()
        {
            string[] names = new string[] { "HKG", "GRL", "GEO", "DNK", "UK" };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }



    }

}
