using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
