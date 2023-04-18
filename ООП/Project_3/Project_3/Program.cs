using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddPlayerCommand = "add";
            const string ChangeStatusPlayerCommand = "print";
            const string DeletePlayerCommand = "delete";
            const string ExitProgramCommand = "exit";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n");
                Console.WriteLine($"1.{AddPlayerCommand}");
                Console.WriteLine($"2.{ChangeStatusPlayerCommand}");
                Console.WriteLine($"3.{DeletePlayerCommand}");
                Console.WriteLine($"6.{ExitProgramCommand}");

                Console.Write("\nВведите команду - ");

                string command;

                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddPlayerCommand:
                        Console.WriteLine("добавить игрок");
                        break;

                    case ChangeStatusPlayerCommand:
                        Console.WriteLine("бан/розбан игрока");
                        break;

                    case DeletePlayerCommand:
                        Console.WriteLine("удалить досье");
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;
                }
            }
        }

        static void AddPlayerCommand()
        {
            
        }

        static void ChangeStatusPlayerCommand()
        {
            // ------------------------
        }

        static void DeletePlayerCommand()
        {
            // ------------------------
        }
    }
}

class Player
{
    private int _number;
    private string _name;
    private int _lvl = 1;
    private bool _ban = false;

    public Player(int number, string name, int lvl, bool ban)
    {
        number = _number;
        name = _name;
        lvl = _lvl;
        ban = _ban;
    }
}


//Реализовать базу данных игроков и методы для работы с ней. 
//У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool). 
//Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
//Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса. Но нужен класс,
//который содержит игроков и её можно назвать "База данных".
