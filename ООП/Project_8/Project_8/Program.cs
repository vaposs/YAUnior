using System;
using System.Collections.Generic;
using System.Threading;

namespace Project_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Fight fight = new Fight();
            fight.Play();
        }
    }

    class Fight
    {
        private List<Fighter> _availableFighters = new List<Fighter>();
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public Fight()
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
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("      ДОБРО ПОЖАЛОВАТЬ В КОЛИЗЕЙ");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Посмотреть бой");
                Console.WriteLine("2. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Start();
                        break;
                    case "2":
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
        protected string _name;
        protected int _health;
        protected int _maxHealth;
        protected int _armor;
        protected int _damage;

        protected int _specialCounter;
        protected int _specialValue;

        public Fighter(string name, int health, int armor, int damage)
        {
            _name = name;
            _health = health;
            _maxHealth = health;
            _armor = armor;
            _damage = damage;
            _specialCounter = 0;
        }

        public string Name => _name;
        public int Health => _health;

        public abstract void Attack(IDamageable target);

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - _armor);
            _health = Math.Max(0, _health - actualDamage);
            Console.WriteLine($"{_name} получает {actualDamage} урона (заблокировано {_armor})");
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"{_name}: ♥{_health}/{_maxHealth} | ⚔{_damage} | 🛡{_armor}");
        }

        public virtual void ShowFullStats()
        {
            Console.WriteLine($"{_name}: Здоровье {_health}/{_maxHealth}, Урон {_damage}, Броня {_armor}");
        }

        public abstract Fighter Clone();
    }

    class Gladiator : Fighter
    {
        private int _doubleDamageChance = 30;

        public Gladiator(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
        }

        public override void Attack(IDamageable target)
        {
            int currentDamage = _damage;
            int chance = UserUtils.GenerateRandomNumber(0, 100);

            if (chance < _doubleDamageChance)
            {
                currentDamage *= 2;
                Console.Write($" [КРИТИЧЕСКИЙ УДАР!]");
            }

            Console.WriteLine($" наносит {currentDamage} урона");
            target.TakeDamage(currentDamage);
        }

        public override Fighter Clone()
        {
            return new Gladiator(_name, _maxHealth, _armor, _damage);
        }
    }

    class Berserk : Fighter
    {
        private int _attackCount = 0;
        private int _doubleAttackThreshold = 3;

        public Berserk(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
        }

        public override void Attack(IDamageable target)
        {
            _attackCount++;
            int currentDamage = _damage;

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
            return new Berserk(_name, _maxHealth, _armor, _damage);
        }
    }

    class Warrior : Fighter
    {
        private int _rage = 0;
        private int _maxRage = 100;
        private int _ragePerHit = 15;
        private int _healAmount = 20;

        public Warrior(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
        }

        public override void Attack(IDamageable target)
        {
            Console.WriteLine($" наносит {_damage} урона");
            target.TakeDamage(_damage);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            _rage += _ragePerHit;
            Console.WriteLine($"{_name} накапливает ярость: {_rage}/{_maxRage}");

            if (_rage >= _maxRage)
            {
                _health = Math.Min(_maxHealth, _health + _healAmount);
                _rage = 0;
                Console.WriteLine($"{_name} ИСПОЛЬЗУЕТ ЛЕЧЕНИЕ! +{_healAmount} здоровья");
            }
        }

        public override Fighter Clone()
        {
            return new Warrior(_name, _maxHealth, _armor, _damage);
        }
    }

    class Mage : Fighter
    {
        private int _mana;
        private int _maxMana = 50;
        private int _manaCost = 15;
        private int _fireballDamage;

        public Mage(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _mana = _maxMana;
            _fireballDamage = damage * 2;
        }

        public override void Attack(IDamageable target)
        {
            _mana = Math.Min(_maxMana, _mana + 5);

            if (_mana >= _manaCost)
            {
                _mana -= _manaCost;
                Console.Write($" [ОГНЕННЫЙ ШАР! Мана: {_mana}/{_maxMana}]");
                Console.WriteLine($" наносит {_fireballDamage} урона");
                target.TakeDamage(_fireballDamage);
            }
            else
            {
                Console.WriteLine($" наносит {_damage} урона (мало маны: {_mana}/{_maxMana})");
                target.TakeDamage(_damage);
            }
        }

        public override Fighter Clone()
        {
            return new Mage(_name, _maxHealth, _armor, _damage);
        }
    }

    class Assassin : Fighter
    {
        private int _dodgeChance = 25;

        public Assassin(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
        }

        public override void Attack(IDamageable target)
        {
            Console.WriteLine($" наносит {_damage} урона");
            target.TakeDamage(_damage);
        }

        public override void TakeDamage(int damage)
        {
            int chance = UserUtils.GenerateRandomNumber(0, 100);

            if (chance < _dodgeChance)
            {
                Console.WriteLine($"{_name} УКЛОНЯЕТСЯ от атаки!");
                return;
            }

            base.TakeDamage(damage);
        }

        public override Fighter Clone()
        {
            return new Assassin(_name, _maxHealth, _armor, _damage);
        }
    }

    interface IDamageable
    {
        void TakeDamage(int damage);
    }

    class UserUtils
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
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
