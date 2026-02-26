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
        private const int MinFighterType = 1;
        private const int MaxFighterType = 4;

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
            _squads.Add(CreateSquads());
            _squads.Add(CreateSquads());
            Battle();
        }

        private Squad CreateSquads()
        {
            Console.WriteLine($"\nСоздание взвода:");
            Console.Write("Введите название взвода: ");
            string squadName = Console.ReadLine();

            Console.Write("Введите количество бойцов во взводе: ");
            int squadSize = GetNumber();

            Squad squad = new Squad(squadName);

            for (int j = 0; j < squadSize; j++)
            {
                Console.WriteLine($"\nВыберите тип бойца {j + 1}:");
                Console.WriteLine($"{MinFighterType} - Обычный солдат");
                Console.WriteLine($"{MinFighterType + 1} - Снайпер (атакует одного с множителем урона)");
                Console.WriteLine($"{MinFighterType + 2} - Гранатометчик (атакует нескольких без повторений)");
                Console.WriteLine($"{MaxFighterType} - Пулеметчик (атакует нескольких с возможными повторениями)");

                int choice = GetNumber(MinFighterType, MaxFighterType);
                Fighter fighter = _fighterTemplates[choice - 1].Clone();

                Console.Write("Введите имя бойца: ");
                string fighterName = Console.ReadLine();
                fighter.SetName(fighterName);

                squad.AddFighter(fighter);
            }

            return squad;
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

                squad1.Attack(squad2.GetAliveFighters());
                squad2.Attack(squad1.GetAliveFighters());
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
            return _fighters.Any(fighter => fighter.Health > 0);
        }

        public int GetAliveCount()
        {
            return _fighters.Count(fighter => fighter.Health > 0);
        }

        public List<Fighter> GetAliveFighters()
        {
            return _fighters.Where(fighter => fighter.Health > 0).ToList();
        }

        public void Attack(List<Fighter> enemyFighters)
        {
            List<Fighter> aliveFighters = GetAliveFighters();

            if (enemyFighters.Count == 0)
            {
                return;
            }

            foreach (Fighter fighter in aliveFighters)
            {
                if (enemyFighters.Count != 0)
                {
                    fighter.Attack(enemyFighters);
                }
            }
        }

        public void RemoveDeadFighters()
        {
            _fighters = _fighters.Where(fighter => fighter.Health > 0).ToList();
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
        protected string _name;
        protected int _health;
        protected int _damage;
        protected int _armor;
        protected string _type;
        protected Random _random = new Random();

        public string Name
        {
            get { return _name; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int Health
        {
            get { return _health; }
        }

        protected Fighter(string name, string type, int health, int damage, int armor)
        {
            _name = name;
            _type = type;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - _armor);
            int healthAfterDamage = _health - actualDamage;

            if (healthAfterDamage < 0)
            {
                healthAfterDamage = 0;
            }

            _health = healthAfterDamage;

            Console.WriteLine($"{_name} получил {actualDamage} урона. Осталось здоровья: {_health}");
        }

        public abstract void Attack(List<Fighter> enemyFighters);
        public abstract Fighter Clone();
    }

    class RegularSoldier : Fighter
    {
        public RegularSoldier(string name, int health, int damage, int armor)
            : base(name, "Обычный солдат", health, damage, armor)
        {
        }

        private RegularSoldier(RegularSoldier soldier)
            : this(soldier.Name, soldier.Health, soldier._damage, soldier._armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            Fighter target = enemyFighters[_random.Next(enemyFighters.Count)];

            Console.WriteLine($"{Name} атакует {target.Name}");
            target.TakeDamage(_damage);
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
            : this(sniper.Name, sniper.Health, sniper._damage, sniper._armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            Fighter target = enemyFighters[_random.Next(enemyFighters.Count)];

            int actualDamage = (int)(_damage * DamageMultiplier);
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
            : this(attacker.Name, attacker.Health, attacker._damage, attacker._armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            int targetsCount = Math.Min(MaxTargets, enemyFighters.Count);
            List<Fighter> targets = new List<Fighter>();
            List<int> usedIndexes = new List<int>();

            for (int i = 0; i < targetsCount; i++)
            {
                int randomIndex;

                do
                {
                    randomIndex = _random.Next(enemyFighters.Count);
                }
                while (usedIndexes.Contains(randomIndex));

                usedIndexes.Add(randomIndex);
                targets.Add(enemyFighters[randomIndex]);
            }

            Console.WriteLine($"{Name} (гранатометчик) атакует по области {targetsCount} целей без повторений!");

            for (int i = 0; i < targetsCount; i++)
            {
                Fighter target = targets[i];
                Console.WriteLine($"  -> {target.Name}");
                target.TakeDamage(_damage);
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
            : this(attacker.Name, attacker.Health, attacker._damage, attacker._armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            int attacks = _random.Next(MinTargets, MaxTargets + 1);

            Console.WriteLine($"{Name} (пулеметчик) делает {attacks} выстрелов очередью!");

            for (int i = 0; i < attacks; i++)
            {
                if (enemyFighters.Count == 0)
                {
                    break;
                }

                Fighter target = enemyFighters[_random.Next(enemyFighters.Count)];
                Console.WriteLine($"  Выстрел {i + 1} -> {target.Name}");
                target.TakeDamage(_damage);
            }
        }

        public override Fighter Clone()
        {
            return new RandomAreaAttacker(this);
        }
    }
}
