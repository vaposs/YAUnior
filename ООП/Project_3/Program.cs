﻿using System;
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
}

class Database
{
    private List<Player> _players = new List<Player>();
    int _currentIndex = 1;

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
            Console.WriteLine($"{AddPlayerCommand}. Добавить игрока");
            Console.WriteLine($"{BanPlayerCommand}. Бан игпрока");
            Console.WriteLine($"{UnBanPlayerCommand}. Розбан игрока");
            Console.WriteLine($"{DeletePlayerCommand}. Удалить игрока");
            Console.WriteLine($"{PrintPlayerCommand}. Вывести список игроков");
            Console.WriteLine($"{ExitProgramCommand}. Выход");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
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
                    ShowPlayer();
                    break;

                case ExitProgramCommand:
                    isWork = false;
                    break;
            }
        }
    }

    private void AddPlayer()
    {
        int number = _currentIndex++;
        string name = Console.ReadLine();
        int lvl = 1;
        bool isBan = false;
        _players.Add(new Player(number,name,lvl,isBan));
    }

    private void BanPlayer()
    {
        Player playerForBan;

        Console.Write("Введите ID игрока для бана - ");

        playerForBan = TryGetPlayer();

        if(playerForBan == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            playerForBan.Ban();
        }
    }

    private void BanPlayer2()
    {
        if(TryGetPlayer(out Player player))
        {
            player.Ban();
            Console.WriteLine("игрок забанен");
        }
        else
        {
            Console.WriteLine("ошибка ввода данных");
        }
    }

    private void UnbanPlayer()
    {
        Player playerForUnban;

        Console.Write("Введите ID игрока для бана - ");

        playerForUnban = TryGetPlayer();

        if (playerForUnban == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            playerForUnban.Unban();
        }
    }

    private void DeletePlayer()
    {
        Player playerForDelete;

        Console.Write("Введите номер ирока для удаления - ");

        playerForDelete = TryGetPlayer();

        if (playerForDelete == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            _players.Remove(playerForDelete);
        }
    }

    private void PrintFirstLine()
    {
        Console.WriteLine("уникальный номер   |\t     имя\t   |    лвл    |    бан(true/false)    ");
    }

    private void ShowPlayer()
    {
        PrintFirstLine();

        foreach (Player player in _players)
        {
            player.Print();
        }
    }

    private int GetPositiveNumber()
    {
        string line;
        bool isConversionSucceeded = true;
        bool isNumber;
        int number = 0;

        while (isConversionSucceeded)
        {
            line = Console.ReadLine();
            isNumber = int.TryParse(line, out number);

            if (isNumber)
            {
                if (number < 0)
                {
                    Console.Write("Неверный ввод. Число меньше нуля.");
                }
                else
                {
                    isConversionSucceeded = false;
                }
            }
            else
            {
                Console.Write("Неверный ввод.");
            }
        }

        return number;
    }

    private Player TryGetPlayer()
    {
        int number = GetPositiveNumber();

        foreach (Player player in _players)
        {
            if (number == player.Number)
            {
                return player;
            }
        }

        return null;
    }

    private bool TryGetPlayer(out Player player)
    {
        player = null;

        Console.WriteLine("Введите Id игрока - ");
        int id = GetPositiveNumber();

        foreach(Player nextPlayer in _players)
        {
            if( nextPlayer.Number == id)
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
    public Player(int number, string name, int lvl, bool isBan)
    {
        Number = number;
        Name = name;
        Lvl = lvl;
        IsBan = isBan;
    }

    public int Number { get; private set; }
    public string Name { get; private set; }
    public int Lvl { get; private set; }
    public bool IsBan { get; private set; }

    public void Print()
    {
        Console.Write(Number + "\t\t");
        Console.Write(Name + "\t\t");
        Console.Write(Lvl + "\t\t");
        Console.Write(IsBan + "\n");
    }

    public void Ban()
    {
        if (IsBan == false)
        {
            Console.WriteLine("Плеер забанен");
            IsBan = true;
        }
        else
        {
            Console.WriteLine("Плеер уже забанен");
        }
    }

    public void Unban()
    {
        if (IsBan == true)
        {
            Console.WriteLine("Плеер розабанен");
            IsBan = false;
        }
        else
        {
            Console.WriteLine("Плеер уже розабанен");
        }
    }

   
}