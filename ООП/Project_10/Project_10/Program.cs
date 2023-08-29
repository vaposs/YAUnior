using System;
using System.Collections.Generic;

//Есть 2 взвода. 1 взвод страны один, 2 взвод страны два.
//Каждый взвод внутри имеет солдат.
//Нужно написать программу, которая будет моделировать бой этих взводов.
//Каждый боец - это уникальная единица, он может иметь уникальные способности или же уникальные характеристики, такие как повышенная сила.
//Побеждает та страна, во взводе которой остались выжившие бойцы.
//Не важно, какой будет бой, рукопашный, стрелковый.


// создавать 2 очереди рандомных бойцов и они сражаются между собой
// при хп бойца 0 <= выводить его из очереди в брать другого
// если у отряда закончились бойци он проиграл
// создать способности бойцов


namespace Project_10
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            War war = new War();

            war.Begin();
        }
    }

    class War
    {
        Fighter _firstTeamFighter;
        Fighter _secondTeamFighter;
        private List<Fighter> _fighters = new List<Fighter>();
        private Queue<Fighter> _firstTeamFighters = new Queue<Fighter>();
        private Queue<Fighter> _secondTeamFighters = new Queue<Fighter>();
        private int _sizeTeam = 0;

        public War()
        {
            _fighters.Add(new Shooter("Shooter", 100, 10));
            _fighters.Add(new Engineer("Engineer", 100, 10));
            _fighters.Add(new Grenadier("Grenadier", 100, 10));
            _fighters.Add(new Gunner("Gunner", 100, 10));
            _fighters.Add(new Tankman("Tankman", 100, 10));
        }

        public void Begin()
        {

        }

        private void CreateTwoTeams()
        {

        }

        private int GetNumber()
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
        }// ввод числа с клавиатуры

        private int GenerateRandomNumber(int minRandomNumber, int maxRandomNumber) // генерация случайного числа
        {
            Random random = new Random();

            return random.Next(minRandomNumber, maxRandomNumber);
        }
    }

    abstract class Fighter
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Atack { get; protected set; }

        public Fighter(string name, int health, int atack)
        {
            Name = name;
            Health = health;
            Atack = atack;
        }

        public int MakeDamage()
        {
            return Atack;
        }

        public void TakeDamage(int atack)
        {
            Health -= atack;
        }

        public abstract void Ability();

        public abstract Fighter Clone();
    }

    class Shooter : Fighter
    {
        public Shooter(string name, int health,  int atack) : base(name ,health, atack)
        {

        }

        private Shooter(Shooter shooter) : this(shooter.Name, shooter.Health, shooter.Atack)
        {

        }

        public override void Ability()
        {
            // - ДОРАБОТАТЬ
        }

        public override Fighter Clone()
        {
            return new Shooter(this);
        }
    }

    class Engineer : Fighter
    {
        public Engineer(string name, int health, int atack) : base(name, health, atack)
        {

        }

        private Engineer(Engineer engineer) : this(engineer.Name, engineer.Health, engineer.Atack)
        {

        }

        public override void Ability()
        {
            // - ДОРАБОТАТЬ
        }

        public override Fighter Clone()
        {
            return new Engineer(this);
        }
    }

    class Grenadier : Fighter
    {
        public Grenadier(string name, int health, int atack) : base(name, health, atack)
        {

        }

        private Grenadier(Grenadier grenadier) : this(grenadier.Name, grenadier.Health, grenadier.Atack)
        {

        }

        public override void Ability()
        {
            // - ДОРАБОТАТЬ
        }

        public override Fighter Clone()
        {
            return new Grenadier(this);
        }
    }

    class Gunner : Fighter
    {
        public Gunner(string name, int health, int atack) : base(name, health, atack)
        {

        }

        private Gunner(Gunner gunner) : this(gunner.Name, gunner.Health, gunner.Atack)
        {

        }

        public override void Ability()
        {
            // - ДОРАБОТАТЬ
        }

        public override Fighter Clone()
        {
            return new Gunner(this);
        }
    }

    class Tankman : Fighter
    {
        public Tankman(string name, int health, int atack) : base(name, health, atack)
        {

        }

        private Tankman(Tankman tankman) : this(tankman.Name, tankman.Health, tankman.Atack)
        {

        }

        public override void Ability()
        {
            // - ДОРАБОТАТЬ
        }

        public override Fighter Clone()
        {
            return new Tankman(this);
        }
    }
}
