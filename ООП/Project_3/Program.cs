using System;
using System.Collections.Generic;

namespace Project_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Database database = new Database();
            database.Begin();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private int _currentId = 1;

        public void Begin()
        {
            const string AddPlayerCommand = "1";
            const string BanPlayerCommand = "2";
            const string UnBanPlayerCommand = "3";
            const string DeletePlayerCommand = "4";
            const string PrintPlayerCommand = "5";
            const string ExitProgramCommand = "6";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\n{AddPlayerCommand}. Добавить игрока");
                Console.WriteLine($"{BanPlayerCommand}. Забанить игрока");
                Console.WriteLine($"{UnBanPlayerCommand}. Разбанить игрока");
                Console.WriteLine($"{DeletePlayerCommand}. Удалить игрока");
                Console.WriteLine($"{PrintPlayerCommand}. Вывести список игроков");
                Console.WriteLine($"{ExitProgramCommand}. Выход");

                Console.Write("Введите номер команды: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case AddPlayerCommand:
                        AddPlayer();
                        break;

                    case BanPlayerCommand:
                        BanPlayer();
                        break;

                    case UnBanPlayerCommand:
                        UnbanPlayer();
                        break;

                    case DeletePlayerCommand:
                        DeletePlayer();
                        break;

                    case PrintPlayerCommand:
                        ShowPlayers();
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда. Попробуйте снова.");
                        break;
                }
            }
        }

        private void AddPlayer()
        {
            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }

            int level = 1;
            bool isBanned = false;

            _players.Add(new Player(_currentId++, name, level, isBanned));
        }

        private void BanPlayer()
        {
            Console.Write("Введите ID игрока для бана: ");

            if (TryGetPlayer(out Player playerToBan))
            {
                playerToBan.Ban();
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден.");
            }
        }

        private void UnbanPlayer()
        {
            Console.Write("Введите ID игрока для разбана: ");

            if (TryGetPlayer(out Player playerToUnban))
            {
                playerToUnban.Unban();
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден.");
            }
        }

        private void DeletePlayer()
        {
            Console.Write("Введите ID игрока для удаления: ");

            if (TryGetPlayer(out Player playerToDelete))
            {
                _players.Remove(playerToDelete);
                Console.WriteLine("Игрок успешно удален.");
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден.");
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("\nID\t\tИмя\t\tУровень\t\tЗабанен");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void ShowPlayers()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список игроков пуст.");
                return;
            }

            PrintHeader();

            foreach (Player player in _players)
            {
                player.Print();
            }
        }

        private int GetPositiveNumber()
        {
            int number;
            bool isParsed;

            do
            {
                string input = Console.ReadLine();
                isParsed = int.TryParse(input, out number);

                if (!isParsed)
                {
                    Console.Write("Ошибка! Введите целое число: ");
                }
                else if (number <= 0)
                {
                    Console.Write("Ошибка! Число должно быть положительным: ");
                    isParsed = false;
                }
            }
            while (isParsed == false);

            return number;
        }

        private bool TryGetPlayer(out Player player)
        {
            player = null;
            int id = GetPositiveNumber();

            foreach (Player nextPlayer in _players)
            {
                if (nextPlayer.Id == id)
                {
                    player = nextPlayer;
                    return true;
                }
            }

            return false;
        }
    }

    class Player
    {
        public Player(int id, string name, int level, bool isBanned)
        {
            Id = id;
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Print()
        {
            Console.WriteLine($"{Id}\t\t{Name}\t\t{Level}\t\t{IsBanned}");
        }

        public void Ban()
        {
            if (IsBanned)
            {
                Console.WriteLine($"Игрок {Name} уже забанен.");
            }
            else
            {
                IsBanned = true;
                Console.WriteLine($"Игрок {Name} забанен.");
            }
        }

        public void Unban()
        {
            if (IsBanned)
            {
                IsBanned = false;
                Console.WriteLine($"Игрок {Name} разбанен.");
            }
            else
            {
                Console.WriteLine($"Игрок {Name} не находится в бане.");
            }
        }
    }
}
