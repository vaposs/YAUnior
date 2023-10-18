using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_4
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
        private List<Player> _players = new List<Player>();
        private int _topPlayer = 3;

        public void Work()
        {
            string strenghtName = "силе";
            string levelName = "левелу";

            CreateListPlayer();
            Console.WriteLine("Изначальный список игроков:");
            ShowPlayers(_players);

            Console.WriteLine($"\nТоп {_topPlayer} по {strenghtName}:");
            ShowPlayers(TakeTopStrenght(_topPlayer));

            Console.WriteLine($"\nТоп {_topPlayer} по {levelName}:");
            ShowPlayers(TakeTopLevel(_topPlayer));
        }

        private void CreateListPlayer()
        {
            int minPlayers = 8;
            int maxPlayers = 15;
            int countPlayers = UserUtils.GenerateRandomNumber(minPlayers, maxPlayers);

            for (int i = 0; i < countPlayers; i++)
            {
                _players.Add(new Player());
            }
        }

        private void ShowPlayers(List<Player> players)
        {
            int index = 1;

            Console.WriteLine("  ИМЯ\tЛЕВЕЛ\tСИЛА");

            foreach (Player player in players)
            {
                Console.WriteLine($"{index++}.{player.Name} - {player.Level} - {player.Strength}");
            }
        }

        private List<Player> TakeTopStrenght(int topPlayer)
        {
            return _players.OrderByDescending(player => player.Strength).Take(topPlayer).ToList();
        }

        private List<Player> TakeTopLevel(int topPlayer)
        {
            return _players.OrderByDescending(player => player.Level).Take(topPlayer).ToList();
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

    class Player
    {
        private int _minLevel = 1;
        private int _maxLevel = 100;
        private int _minStrength = 1;
        private int _maxStrength = 100;

        public Player()
        {
            Name = GetName();
            Level = UserUtils.GenerateRandomNumber(_minLevel, _maxLevel);
            Strength = UserUtils.GenerateRandomNumber(_minStrength, _maxStrength);
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        private string GetName()
        {
            string[] names = new string[] { "Петя", "Филя", "Семен", "Вася", "Степа" };

            return names[UserUtils.GenerateRandomNumber(0, names.Length)];
        }
    }
}