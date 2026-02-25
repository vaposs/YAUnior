using System;
using System.Collections.Generic;
using System.Threading;

namespace Project_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.Play();
        }
    }

    class Arena
    {
        private List<Fighter> _availableFighters = new List<Fighter>();
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public Arena()
        {
            InitializeFighters();
        }

        private void InitializeFighters()
        {
            _availableFighters.Add(new Gladiator("Гладиатор", 120, 5, 8));
            _availableFighters.Add(new Berserk("Берсерк", 140, 3, 10));
            _availableFighters.Add(new Warrior("Воин", 150, 8, 6));
            _availableFighters.Add(new Mage("Маг", 90, 2, 12));
            _availableFighters.Add(new Assassin("Ассасин", 100, 4, 9));
        }

        public void Play()
        {
            const string MenuViewFight = "1";
            const string MenuExit = "2";

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("      ДОБРО ПОЖАЛОВАТЬ В КОЛИЗЕЙ");
                Console.WriteLine("======================================");
                Console.WriteLine($"{MenuViewFight}. Посмотреть бой");
                Console.WriteLine($"{MenuExit}. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case MenuViewFight:
                        Start();
                        break;
                    case MenuExit:
                        isRunning = false;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Start()
        {
            Console.Clear();
            Console.WriteLine("=== ВЫБОР БОЙЦОВ ===");

            Console.WriteLine("\nВыберите первого бойца:");
            _firstFighter = ChooseFighter();

            Console.WriteLine("\nВыберите второго бойца:");
            _secondFighter = ChooseFighter();

            Console.Clear();
            Console.WriteLine("=== БОЙ НАЧИНАЕТСЯ ===");
            Console.WriteLine($"{_firstFighter.Name} VS {_secondFighter.Name}");
            Console.WriteLine("Нажмите любую клавишу для начала боя...");
            Console.ReadKey();

            ConductBattle();

            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private Fighter ChooseFighter()
        {
            ShowAllFighters();
            Console.Write("Введите номер бойца: ");

            int choice = UserUtils.GetPositiveNumber();

            while (choice > _availableFighters.Count)
            {
                Console.WriteLine($"Неверный номер. Введите число от 1 до {_availableFighters.Count}");
                choice = UserUtils.GetPositiveNumber();
            }

            return _availableFighters[choice - 1].Clone();
        }

        private void ShowAllFighters()
        {
            Console.WriteLine("\nДоступные бойцы:");
            for (int i = 0; i < _availableFighters.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _availableFighters[i].ShowStats();
            }
        }

        private void ConductBattle()
        {
            int round = 1;
            bool battleActive = true;

            while (battleActive)
            {
                Console.Clear();
                Console.WriteLine($"=== РАУНД {round} ===\n");

                bool firstAttacks = UserUtils.GenerateRandomNumber(0, 2) == 0;

                if (firstAttacks)
                {
                    ExecuteAttack(_firstFighter, _secondFighter);

                    if (_secondFighter.Health > 0)
                    {
                        ExecuteAttack(_secondFighter, _firstFighter);
                    }
                }
                else
                {
                    ExecuteAttack(_secondFighter, _firstFighter);

                    if (_firstFighter.Health > 0)
                    {
                        ExecuteAttack(_firstFighter, _secondFighter);
                    }
                }

                Console.WriteLine("\n--- ТЕКУЩЕЕ СОСТОЯНИЕ ---");
                _firstFighter.ShowFullStats();
                _secondFighter.ShowFullStats();

                if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
                {
                    battleActive = false;
                    ShowBattleResult();
                }
                else
                {
                    Console.WriteLine("\nНажмите любую клавишу для следующего раунда...");
                    Console.ReadKey();
                }

                round++;
            }
        }

        private void ExecuteAttack(Fighter attacker, IDamageable defender)
        {
            if (attacker.Health <= 0) return;

            Console.Write($"{attacker.Name} атакует");
            attacker.Attack(defender);
        }

        private void ShowBattleResult()
        {
            Console.WriteLine("\n=== БОЙ ОКОНЧЕН ===");

            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine("НИЧЬЯ! Оба бойца пали в бою!");
            }
            else if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($"ПОБЕДИТЕЛЬ: {_secondFighter.Name}");
            }
            else
            {
                Console.WriteLine($"ПОБЕДИТЕЛЬ: {_firstFighter.Name}");
            }
        }
    }

    abstract class Fighter : IDamageable
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Armor { get; private set; }
        public int Damage { get; private set; }

        public Fighter(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Armor = armor;
            Damage = damage;
        }

        protected void DecreaseHealth(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }

        protected void IncreaseHealth(int amount)
        {
            Health = Math.Min(MaxHealth, Health + amount);
        }

        public abstract void Attack(IDamageable target);

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Armor);
            DecreaseHealth(actualDamage);
            Console.WriteLine($"{Name} получает {actualDamage} урона (заблокировано {Armor})");
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"{Name}: ♥{Health}/{MaxHealth} | ⚔{Damage} | 🛡{Armor}");
        }

        public virtual void ShowFullStats()
        {
            Console.WriteLine($"{Name}: Здоровье {Health}/{MaxHealth}, Урон {Damage}, Броня {Armor}");
        }

        public abstract Fighter Clone();
    }

    class Gladiator : Fighter
    {
        private const int DoubleDamageChance = 30;
        private const int CriticalMultiplier = 2;

        private int _doubleDamageChance;

        public Gladiator(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _doubleDamageChance = DoubleDamageChance;
        }

        public override void Attack(IDamageable target)
        {
            int currentDamage = Damage;

            if (UserUtils.IsChanceSuccessful(_doubleDamageChance))
            {
                currentDamage *= CriticalMultiplier;
                Console.Write($" [КРИТИЧЕСКИЙ УДАР!]");
            }

            Console.WriteLine($" наносит {currentDamage} урона");
            target.TakeDamage(currentDamage);
        }

        public override Fighter Clone()
        {
            return new Gladiator(Name, MaxHealth, Armor, Damage);
        }
    }

    class Berserk : Fighter
    {
        private const int DoubleAttackThreshold = 3;

        private int _attackCount;
        private int _doubleAttackThreshold;

        public Berserk(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _attackCount = 0;
            _doubleAttackThreshold = DoubleAttackThreshold;
        }

        public override void Attack(IDamageable target)
        {
            _attackCount++;
            int currentDamage = Damage;

            if (_attackCount % _doubleAttackThreshold == 0)
            {
                Console.Write($" [ДВОЙНОЙ УДАР!]");
                target.TakeDamage(currentDamage);
                target.TakeDamage(currentDamage);
                Console.WriteLine($" наносит два удара по {currentDamage} урона");
            }
            else
            {
                Console.WriteLine($" наносит {currentDamage} урона");
                target.TakeDamage(currentDamage);
            }
        }

        public override Fighter Clone()
        {
            return new Berserk(Name, MaxHealth, Armor, Damage);
        }
    }

    class Warrior : Fighter
    {
        private const int MaxRage = 100;
        private const int RagePerHit = 15;
        private const int HealAmount = 20;

        private int _rage;
        private int _maxRage;
        private int _ragePerHit;
        private int _healAmount;

        public Warrior(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _rage = 0;
            _maxRage = MaxRage;
            _ragePerHit = RagePerHit;
            _healAmount = HealAmount;
        }

        public override void Attack(IDamageable target)
        {
            Console.WriteLine($" наносит {Damage} урона");
            target.TakeDamage(Damage);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            _rage += _ragePerHit;
            Console.WriteLine($"{Name} накапливает ярость: {_rage}/{_maxRage}");

            if (_rage >= _maxRage)
            {
                IncreaseHealth(_healAmount);
                _rage = 0;
                Console.WriteLine($"{Name} ИСПОЛЬЗУЕТ ЛЕЧЕНИЕ! +{_healAmount} здоровья");
            }
        }

        public override Fighter Clone()
        {
            return new Warrior(Name, MaxHealth, Armor, Damage);
        }
    }

    class Mage : Fighter
    {
        private const int MaxMana = 50;
        private const int ManaCost = 15;
        private const int ManaRegen = 5;
        private const int FireballMultiplier = 2;

        private int _mana;
        private int _maxMana;
        private int _manaCost;
        private int _manaRegen;
        private int _fireballDamage;
        private int _fireballMultiplier;

        public Mage(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _maxMana = MaxMana;
            _mana = _maxMana;
            _manaCost = ManaCost;
            _manaRegen = ManaRegen;
            _fireballMultiplier = FireballMultiplier;
            _fireballDamage = damage * _fireballMultiplier;
        }

        public override void Attack(IDamageable target)
        {
            _mana = Math.Min(_maxMana, _mana + _manaRegen);
            int currentDamage = Damage;

            if (_mana >= _manaCost)
            {
                _mana -= _manaCost;
                Console.Write($" [ОГНЕННЫЙ ШАР! Мана: {_mana}/{_maxMana}]");
                currentDamage = _fireballDamage;
            }
            else
            {
                Console.Write($" (мало маны: {_mana}/{_maxMana})");
            }

            Console.WriteLine($" наносит {currentDamage} урона");
            target.TakeDamage(currentDamage);
        }

        public override Fighter Clone()
        {
            return new Mage(Name, MaxHealth, Armor, Damage);
        }
    }

    class Assassin : Fighter
    {
        private const int DodgeChance = 25;

        private int _dodgeChance;

        public Assassin(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _dodgeChance = DodgeChance;
        }

        public override void Attack(IDamageable target)
        {
            Console.WriteLine($" наносит {Damage} урона");
            target.TakeDamage(Damage);
        }

        public override void TakeDamage(int damage)
        {
            if (UserUtils.IsChanceSuccessful(_dodgeChance))
            {
                Console.WriteLine($"{Name} УКЛОНЯЕТСЯ от атаки!");
                return;
            }

            base.TakeDamage(damage);
        }

        public override Fighter Clone()
        {
            return new Assassin(Name, MaxHealth, Armor, Damage);
        }
    }

    interface IDamageable
    {
        void TakeDamage(int damage);
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }

        public static bool IsChanceSuccessful(int chancePercent)
        {
            return GenerateRandomNumber(0, 100) < chancePercent;
        }

        public static int GetPositiveNumber()
        {
            string userInputString;
            bool isCorrectNumber;
            int number = 0;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                userInputString = Console.ReadLine();
                isCorrectNumber = int.TryParse(userInputString, out number);

                if (isCorrectNumber && number > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.Write("Неверный ввод. Введите положительное число: ");
                }
            }

            return number;
        }
    }
}
