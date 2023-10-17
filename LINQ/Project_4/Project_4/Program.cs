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
            CreateListPlayer();
            Console.WriteLine("Изначальный список игроков:");
            ShowPlayers(_players);

            List<Player> sortedStrenght =  SortStrenght(_topPlayer);
            Console.WriteLine("\nТоп 3 по силе:");
            ShowPlayers(sortedStrenght);

            List<Player> sortedLevels = SortLevel(_topPlayer);
            Console.WriteLine("\nТоп 3 по левелу:");
            ShowPlayers(sortedLevels);
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

        private List<Player> SortStrenght(int topPlayer)
        {
            List<Player> sortedList = new List<Player>();

            var filterPlayer = _players.OrderByDescending(player => player.Strength);
            List<Player> players = filterPlayer.ToList();

            for (int i = 0; i < topPlayer; i++)
            {
                sortedList.Add(players[i]);
            }

            return sortedList;
        }

        private List<Player> SortLevel(int topPlayer)
        {
            List<Player> sortedList = new List<Player>();

            var filterPlayer = _players.OrderByDescending(player => player.Level);
            List<Player> players = filterPlayer.ToList();

            for (int i = 0; i < topPlayer; i++)
            {
                sortedList.Add(players[i]);
            }

            return sortedList;
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