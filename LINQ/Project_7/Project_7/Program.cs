using System;
using System.Collections.Generic;
using System.Linq;

namespace Priject_7
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
        CreatorSoldier _creatorSoldier = new CreatorSoldier();
        List<Soldier> _soldiersFirst = new List<Soldier>();
        List<Soldier> _soldiersSecond = new List<Soldier>();

        public void Work()
        {
            char charSort = 'Б';

            CreateListSoldier(_soldiersFirst);
            CreateListSoldier(_soldiersSecond);

            Console.WriteLine("Первый список до сортировки");
            Show(_soldiersFirst);

            Console.WriteLine("\nВторой список до сортировки");
            Show(_soldiersSecond);

            var filterList = _soldiersFirst.Where(soldier => soldier.Name.Contains(charSort));
            _soldiersSecond = _soldiersSecond.Union(filterList).ToList();
            _soldiersFirst = _soldiersFirst.Except(filterList).ToList();

            Console.WriteLine("\nПервый список после сортировки");
            Show(_soldiersFirst);

            Console.WriteLine("\nВторой список послу сортировки");
            Show(_soldiersSecond);
        }

        private void CreateListSoldier(List<Soldier> soldiers)
        {
            int minSuspects = 10;
            int maxSuspects = 15;
            int countSuspects = UserUtils.GenerateRandomNumber(minSuspects, maxSuspects);

            for (int i = 0; i < countSuspects; i++)
            {
                soldiers.Add(_creatorSoldier.Creator());
            }
        }

        private void Show(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name} - {soldier.Rank} - {soldier.Weapon} - {soldier.TimeMilitaryService}");
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
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string rank, int timeMilitaryService)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            TimeMilitaryService = timeMilitaryService;
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int TimeMilitaryService { get; private set; }
    }

    class CreatorSoldier
    {
        public CreatorSoldier()
        {
            Names = new string[] { "Вася", "Петя", "Слава", "Степа", "Бильбо", "Миша", "Боря" };
            Weapon = new string[] { "нож", "пистолет", "винтовка", "пулемет", "гранатомет", "граната" };
            Rank = new string[] { "рядовой", "ефрейтор", "сержант", "лейтинант", "майор", "генерал" };
            TimeMilitaryService = GetTimeMilitaryService();
        }

        public string[] Names { get; private set; }
        public string[] Weapon { get; private set; }
        public string[] Rank { get; private set; }
        public int TimeMilitaryService { get; private set; }

        public Soldier Creator()
        {
            return new Soldier(GetName(), GetWeapon(), GetRank(), GetTimeMilitaryService());
        }

        private string GetName()
        {
            return Names[UserUtils.GenerateRandomNumber(0, Names.Length)];
        }

        private string GetWeapon()
        {
            return Weapon[UserUtils.GenerateRandomNumber(0, Weapon.Length)];
        }

        private string GetRank()
        {
            return Rank[UserUtils.GenerateRandomNumber(0, Rank.Length)];
        }

        private int GetTimeMilitaryService()
        {
            int minTime = 90;
            int maxTime = 720;

            return UserUtils.GenerateRandomNumber(minTime, maxTime);
        }
    }
}