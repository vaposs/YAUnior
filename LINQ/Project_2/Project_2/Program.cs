using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2
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
        private List<Prisoner> _prisoners = new List<Prisoner>();
        private PrisonerCreator _prisonerCreator = new PrisonerCreator();

        public void Work()
        {
            string crimeName = "антиправительственное";

            CreateListPrisoner();
            Console.WriteLine($"Количество заключенных - {_prisoners.Count}");
            ShowPrisoner(_prisoners);

            var prisoners = _prisoners.Where(prisoner => prisoner.CrimeName != crimeName);

            Console.WriteLine($"\nКоличество заключенных послe амнистии - {prisoners.Count()}");
            ShowPrisoner(prisoners.ToList());
        }

        private void CreateListPrisoner()
        {
            int minPrisoner = 100;
            int maxPrisoner = 150;

            for (int i = 0; i < UserUtils.GenerateRandomNumber(minPrisoner, maxPrisoner); i++)
            {
                _prisoners.Add(_prisonerCreator.Create());
            }
        }

        private void ShowPrisoner(List<Prisoner> prisoners)
        {
            int index = 1;

            foreach (Prisoner prisoner in prisoners)
            {
                Console.WriteLine($"{index}.{prisoner.Name} - {prisoner.CrimeName}");
                index++;
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
            bool[] logic = { true, false };

            return logic[s_random.Next(0, logic.Length)];
        }
    }

    class Prisoner
    {
        public Prisoner(string name, string crimeName)
        {
            Name = name;
            CrimeName = crimeName;
        }

        public string Name { get; private set; }
        public string CrimeName { get; private set; }
    }

    class PrisonerCreator
    {
        private string GetName()
        {
            string[] names = new string[] { "Петя", "Филя", "Семен", "Вася", "Степа", };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }

        public string GetCrimeName()
        {
            string[] names = new string[] { "кража", "убийство", "антиправительственное", "мошенничество", "торговля людьми" };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }

        public Prisoner Create()
        {
            return new Prisoner(GetName(), GetCrimeName());
        }
    }
}
