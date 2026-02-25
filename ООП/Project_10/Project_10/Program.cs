using System;
using System.Collections.Generic;
using System.Linq;

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
        private List<Fighter> _fighterTemplates = new List<Fighter>();
        private List<Squad> _squads = new List<Squad>();

        public War()
        {
            _fighterTemplates.Add(new RegularSoldier("Обычный солдат", 100, 15, 5));
            _fighterTemplates.Add(new Sniper("Снайпер", 80, 30, 3));
            _fighterTemplates.Add(new AreaAttacker("Гранатометчик", 90, 12, 7));
            _fighterTemplates.Add(new RandomAreaAttacker("Пулеметчик", 110, 10, 10));
        }

        public void Begin()
        {
            Console.WriteLine("Добро пожаловать в симулятор боя!");
            CreateTwoSquads();
            Battle();
        }

        private void CreateTwoSquads()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"\nСоздание {i + 1}-го взвода:");
                Console.Write("Введите название взвода: ");
                string squadName = Console.ReadLine();

                Console.Write("Введите количество бойцов во взводе: ");
                int squadSize = GetNumber();

                Squad squad = new Squad(squadName);

                for (int j = 0; j < squadSize; j++)
                {
                    Console.WriteLine($"\nВыберите тип бойца {j + 1}:");
                    Console.WriteLine("1 - Обычный солдат");
                    Console.WriteLine("2 - Снайпер (атакует одного с множителем урона)");
                    Console.WriteLine("3 - Гранатометчик (атакует нескольких без повторений)");
                    Console.WriteLine("4 - Пулеметчик (атакует нескольких с возможными повторениями)");

                    int choice = GetNumber(1, 4);
                    Fighter fighter = _fighterTemplates[choice - 1].Clone();

                    Console.Write("Введите имя бойца: ");
                    fighter.Name = Console.ReadLine();

                    squad.AddFighter(fighter);
                }

                _squads.Add(squad);
            }
        }

        private void Battle()
        {
            Squad squad1 = _squads[0];
            Squad squad2 = _squads[1];

            int round = 1;

            while (squad1.HasAliveFighters() && squad2.HasAliveFighters())
            {
                Console.WriteLine($"\n=== Раунд {round} ===");
                Console.WriteLine($"{squad1.Name}: {squad1.GetAliveCount()} бойцов");
                Console.WriteLine($"{squad2.Name}: {squad2.GetAliveCount()} бойцов");

                squad1.Attack(squad2);
                squad2.Attack(squad1);
                squad1.RemoveDeadFighters();
                squad2.RemoveDeadFighters();

                round++;
            }

            if (squad1.HasAliveFighters())
            {
                Console.WriteLine($"\nПобедил взвод {squad1.Name}!");
                Console.WriteLine($"Осталось бойцов: {squad1.GetAliveCount()}");
            }
            else if (squad2.HasAliveFighters())
            {
                Console.WriteLine($"\nПобедил взвод {squad2.Name}!");
                Console.WriteLine($"Осталось бойцов: {squad2.GetAliveCount()}");
            }
            else
            {
                Console.WriteLine("\nНичья! Все бойцы погибли.");
            }

            Console.WriteLine("\nВыжившие бойцы:");

            squad1.ShowAliveFighters();
            squad2.ShowAliveFighters();
        }

        private int GetNumber(int minValue = 0, int maxValue = int.MaxValue)
        {
            int number;
            bool isInputCorrect = false;
            string input;

            do
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number >= minValue && number <= maxValue)
                    {
                        isInputCorrect = true;
                    }
                    else
                    {
                        Console.Write($"Число должно быть от {minValue} до {maxValue}. Повторите ввод: ");
                    }
                }
                else
                {
                    Console.Write("Неверный ввод. Введите число: ");
                }
            }
            while (isInputCorrect == false);

            return number;
        }
    }

    class Squad
    {
        private List<Fighter> _fighters = new List<Fighter>();

        public string Name { get; }

        public Squad(string name)
        {
            Name = name;
        }

        public void AddFighter(Fighter fighter)
        {
            _fighters.Add(fighter);
        }

        public bool HasAliveFighters()
        {
            return _fighters.Any(f => f.Health > 0);
        }

        public int GetAliveCount()
        {
            return _fighters.Count(f => f.Health > 0);
        }

        public List<Fighter> GetAliveFighters()
        {
            return _fighters.Where(f => f.Health > 0).ToList();
        }

        public void Attack(Squad enemySquad)
        {
            List<Fighter> aliveFighters = GetAliveFighters();
            List<Fighter> enemyAliveFighters = enemySquad.GetAliveFighters();

            if (enemyAliveFighters.Count == 0) return;

            foreach (Fighter fighter in aliveFighters)
            {
                if (enemySquad.GetAliveCount() != 0)
                {
                    fighter.UseAbility(enemySquad);
                }
            }
        }

        public void RemoveDeadFighters()
        {
            _fighters = _fighters.Where(f => f.Health > 0).ToList();
        }

        public void ShowAliveFighters()
        {
            List<Fighter> alive = GetAliveFighters();

            if (alive.Count == 0)
            {
                Console.WriteLine($"{Name}: Нет выживших");
            }
            else
            {
                Console.WriteLine($"{Name}:");
                foreach (Fighter fighter in alive)
                {
                    Console.WriteLine($"  - {fighter.Name} ({fighter.Type}), Здоровье: {fighter.Health}");
                }
            }
        }
    }

    abstract class Fighter
    {
        public string Name { get; set; }
        public string Type { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        protected Random _random = new Random();

        protected Fighter(string name, string type, int health, int damage, int armor)
        {
            Name = name;
            Type = type;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Armor);
            Health -= actualDamage;
            Console.WriteLine($"{Name} получил {actualDamage} урона. Осталось здоровья: {Math.Max(0, Health)}");
        }

        public abstract void UseAbility(Squad enemySquad);
        public abstract Fighter Clone();
    }

    class RegularSoldier : Fighter
    {
        public RegularSoldier(string name, int health, int damage, int armor)
            : base(name, "Обычный солдат", health, damage, armor)
        {
        }

        private RegularSoldier(RegularSoldier soldier)
            : this(soldier.Name, soldier.Health, soldier.Damage, soldier.Armor)
        {
        }

        public override void UseAbility(Squad enemySquad)
        {
            List<Fighter> enemies = enemySquad.GetAliveFighters();
            if (enemies.Count == 0) return;

            Fighter target = enemies[_random.Next(enemies.Count)];

            Console.WriteLine($"{Name} атакует {target.Name}");
            target.TakeDamage(Damage);
        }

        public override Fighter Clone()
        {
            return new RegularSoldier(this);
        }
    }

    class Sniper : Fighter
    {
        private const double DamageMultiplier = 2.5;

        public Sniper(string name, int health, int damage, int armor)
            : base(name, "Снайпер", health, damage, armor)
        {
        }

        private Sniper(Sniper sniper)
            : this(sniper.Name, sniper.Health, sniper.Damage, sniper.Armor)
        {
        }

        public override void UseAbility(Squad enemySquad)
        {
            List<Fighter> enemies = enemySquad.GetAliveFighters();
            if (enemies.Count == 0) return;

            Fighter target = enemies[_random.Next(enemies.Count)];

            int actualDamage = (int)(Damage * DamageMultiplier);
            Console.WriteLine($"{Name} (снайпер) прицельно стреляет в {target.Name} с уроном {actualDamage}");
            target.TakeDamage(actualDamage);
        }

        public override Fighter Clone()
        {
            return new Sniper(this);
        }
    }

    class AreaAttacker : Fighter
    {
        private const int MaxTargets = 3;

        public AreaAttacker(string name, int health, int damage, int armor)
            : base(name, "Гранатометчик", health, damage, armor)
        {
        }

        private AreaAttacker(AreaAttacker attacker)
            : this(attacker.Name, attacker.Health, attacker.Damage, attacker.Armor)
        {
        }

        public override void UseAbility(Squad enemySquad)
        {
            List<Fighter> enemies = enemySquad.GetAliveFighters();
            if (enemies.Count == 0) return;

            int targetsCount = Math.Min(MaxTargets, enemies.Count);

            List<Fighter> shuffledEnemies = enemies.OrderBy(x => _random.Next()).ToList();

            Console.WriteLine($"{Name} (гранатометчик) атакует по области {targetsCount} целей без повторений!");

            for (int i = 0; i < targetsCount; i++)
            {
                Fighter target = shuffledEnemies[i];
                Console.WriteLine($"  -> {target.Name}");
                target.TakeDamage(Damage);
            }
        }

        public override Fighter Clone()
        {
            return new AreaAttacker(this);
        }
    }

    class RandomAreaAttacker : Fighter
    {
        private const int MaxTargets = 4;
        private const int MinTargets = 2;

        public RandomAreaAttacker(string name, int health, int damage, int armor)
            : base(name, "Пулеметчик", health, damage, armor)
        {
        }

        private RandomAreaAttacker(RandomAreaAttacker attacker)
            : this(attacker.Name, attacker.Health, attacker.Damage, attacker.Armor)
        {
        }

        public override void UseAbility(Squad enemySquad)
        {
            List<Fighter> enemies = enemySquad.GetAliveFighters();
            if (enemies.Count == 0) return;

            int attacks = _random.Next(MinTargets, MaxTargets + 1);

            Console.WriteLine($"{Name} (пулеметчик) делает {attacks} выстрелов очередью!");

            for (int i = 0; i < attacks; i++)
            {
                if (enemies.Count == 0) break;

                Fighter target = enemies[_random.Next(enemies.Count)];
                Console.WriteLine($"  Выстрел {i + 1} -> {target.Name}");
                target.TakeDamage(Damage);

                enemies = enemySquad.GetAliveFighters();
            }
        }

        public override Fighter Clone()
        {
            return new RandomAreaAttacker(this);
        }
    }
}
