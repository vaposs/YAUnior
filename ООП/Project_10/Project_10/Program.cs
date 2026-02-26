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

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }

    class SquadFactory
    {
        private const int MinFighterType = 1;
        private const int MaxFighterType = 4;

        private List<Fighter> _fighterTemplates;

        public SquadFactory(List<Fighter> fighterTemplates)
        {
            _fighterTemplates = fighterTemplates;
        }

        public Squad CreateSquad()
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

    class War
    {
        private List<Fighter> _fighterTemplates = new List<Fighter>();
        private List<Squad> _squads = new List<Squad>();
        private SquadFactory _squadFactory;

        public War()
        {
            _fighterTemplates.Add(new RegularSoldier("Обычный солдат", 100, 15, 5));
            _fighterTemplates.Add(new Sniper("Снайпер", 80, 30, 3));
            _fighterTemplates.Add(new AreaAttacker("Гранатометчик", 90, 12, 7));
            _fighterTemplates.Add(new RandomAreaAttacker("Пулеметчик", 110, 10, 10));

            _squadFactory = new SquadFactory(_fighterTemplates);
        }

        public void Begin()
        {
            Console.WriteLine("Добро пожаловать в симулятор боя!");

            for (int i = 0; i < 2; i++)
            {
                _squads.Add(_squadFactory.CreateSquad());
            }

            Battle();
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
    }

    class Squad
    {
        private List<Fighter> _fighters = new List<Fighter>();

        public Squad(string name)
        {
            Name = name;
        }

        public string Name { get; }

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
        protected string _Name;
        protected string _Type;
        protected int _Health;
        protected int _Damage;
        protected int _Armor;

        public Fighter(string name, string type, int health, int damage, int armor)
        {
            _Name = name;
            _Type = type;
            _Health = health;
            _Damage = damage;
            _Armor = armor;
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Type
        {
            get { return _Type; }
        }

        public int Health
        {
            get { return _Health; }
        }

        public void SetName(string name)
        {
            _Name = name;
        }

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - _Armor);
            int healthAfterDamage = _Health - actualDamage;

            if (healthAfterDamage < 0)
            {
                healthAfterDamage = 0;
            }

            _Health = healthAfterDamage;

            Console.WriteLine($"{_Name} получил {actualDamage} урона. Осталось здоровья: {_Health}");
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
            : this(soldier.Name, soldier.Health, soldier._Damage, soldier._Armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            int index = UserUtils.GenerateRandomNumber(0, enemyFighters.Count);
            Fighter target = enemyFighters[index];

            Console.WriteLine($"{Name} атакует {target.Name}");
            target.TakeDamage(_Damage);
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
            : this(sniper.Name, sniper.Health, sniper._Damage, sniper._Armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            int index = UserUtils.GenerateRandomNumber(0, enemyFighters.Count);
            Fighter target = enemyFighters[index];

            int actualDamage = (int)(_Damage * DamageMultiplier);
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
            : this(attacker.Name, attacker.Health, attacker._Damage, attacker._Armor)
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
                    randomIndex = UserUtils.GenerateRandomNumber(0, enemyFighters.Count);
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
                target.TakeDamage(_Damage);
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
            : this(attacker.Name, attacker.Health, attacker._Damage, attacker._Armor)
        {
        }

        public override void Attack(List<Fighter> enemyFighters)
        {
            if (enemyFighters.Count == 0)
            {
                return;
            }

            int attacks = UserUtils.GenerateRandomNumber(MinTargets, MaxTargets + 1);

            Console.WriteLine($"{Name} (пулеметчик) делает {attacks} выстрелов очередью!");

            for (int i = 0; i < attacks; i++)
            {
                if (enemyFighters.Count == 0)
                {
                    break;
                }

                int index = UserUtils.GenerateRandomNumber(0, enemyFighters.Count);
                Fighter target = enemyFighters[index];
                Console.WriteLine($"  Выстрел {i + 1} -> {target.Name}");
                target.TakeDamage(_Damage);
            }
        }

        public override Fighter Clone()
        {
            return new RandomAreaAttacker(this);
        }
    }
}
