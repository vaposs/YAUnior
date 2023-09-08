using System;
using System.Collections.Generic;

//1.Переменные именуются с маленькой буквы, только приватные поля с символа _ и маленькой буквы (исключение - константы), приватные статические поля с
//  маленькой буквы s, символа_ (s_) и маленькой буквы, а всё остальное с большой буквы.  - не нашел где у меня переменная именнована не верно. просьа указать номер строки.
//
//2. Классы, конструкторы, методы, циклы, условия отделяются от остального кода пустой строкой с двух сторон. Перед } и после
//{ пустые строки не нужны. Более 1 пустой строки подряд быть не должно. Подробнее все примеры разобраны
//здесь: https://ijunior-knowledge-base.gitbook.io/baza-znanii-yayunior/c/pustye-stroki    - точно так же, просьа указать номер строки где ошибка.
//
//5. Damage = Damage + Damage; - с каждым использованием, урон увеличится в 2.  - все верно. так и задумано. Увеличивается на 1 ход, а потом методом ResetStats сбрасывается отбратно

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

    class UserUtils
    {
        static private Random _random = new Random();

        public static int GenerateRandomNumber()
        {
            int minNumber = 0;
            int maxNumber = 100;

            return _random.Next(minNumber, maxNumber);
        }

        public static int GetPositiveNumber()
        {
            string userInputString;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                userInputString = Console.ReadLine();
                isCorrectNumber = int.TryParse(userInputString, out number);

                if (isCorrectNumber)
                {
                    if (number < 1)
                    {
                        Console.Write("Неверный ввод. Число меньше единици. Повторите ввод - ");
                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.Write("Неверный ввод. Повторите ввод - ");
                }
            }

            return number;
        }
    }

    class Fight
    {
        private Fighter _firstFighter;
        private Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();

        public Fight()
        {
            _fighters.Add(new Infantryman());
            _fighters.Add(new Barbarian());
            _fighters.Add(new Paladin());
            _fighters.Add(new Tramp());
            _fighters.Add(new Ranger());
        }

        public void Play()
        {
            Console.WriteLine("Добро пожаловать на арену.");
            Console.WriteLine("Выберите первого бойца.");
            _firstFighter = ChoiceFighter();
            _firstFighter.SaveStats();
            Console.WriteLine("Выберите второго бойца.");
            _secondFighter = ChoiceFighter();
            _secondFighter.SaveStats();

            Duel();

            Console.ReadKey();
        }

        private void Duel()
        {
            while (IsGameOver())
            {
                _firstFighter.Atack(_secondFighter);
                _secondFighter.Atack(_firstFighter);
                _firstFighter.ShowStats();
                _secondFighter.ShowStats();
                Console.ReadKey();
            }

            IsWinner();
        }

        private bool IsGameOver()
        {
            bool endRound = true;

            if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
            {
                endRound = false;
            }

            return endRound;
        }

        private void IsWinner()
        {
            if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
            {
                if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
                {
                    Console.WriteLine("Боевая ничья");
                }
                else if (_firstFighter.Health <= 0)
                {
                    Console.WriteLine($"Бой окончен, победил {_secondFighter.Name}");
                }
                else
                {
                    Console.WriteLine($"Бой окончен, победил {_firstFighter.Name}");
                }

            }
        }
        
        private void ShowAllFighter()
        {
            int numberFighter = 1;

            foreach (Fighter fighter in _fighters)
            {
                Console.Write($"{numberFighter++}. ");
                fighter.ShowStatsInChose();
            }
        }

        private Fighter ChoiceFighter()
        {
            bool isRightChoice = true;
            Fighter fighter = null;

            while (isRightChoice)
            {
                ShowAllFighter();
                Console.Write("Боец под номеров - ");

                int command = UserUtils.GetPositiveNumber();

                if(--command > _fighters.Count)
                {
                    Console.WriteLine("неверный ввод числа");
                }
                else
                {
                    fighter = _fighters[command].Clone();
                    isRightChoice = false;
                }
            }

            return fighter;
        } 
    }

    abstract class Fighter
    {
        private int _specialHitChance = 30;
        private int _specialHitFighter;
        private int _minimalDamage = 1;
        private int _normalDamag;
        private int _normalArmor;

        public Fighter(string name, int health, int armor, int damage, int cooldawn, bool hasPassviveSkill)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
            Cooldawn = cooldawn;
            HasPassviveSkill = hasPassviveSkill;
        }

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Damage { get; protected set; }
        public int Cooldawn { get; protected set; }
        public bool HasPassviveSkill { get; protected set; }
        
        public void Atack(Fighter enemy)
        {
            if (HasPassviveSkill == false)
            {
                _specialHitFighter = UserUtils.GenerateRandomNumber();

                if (_specialHitFighter >= _specialHitChance)
                {
                    UseAbility();
                }
            }
            else
            {
                UseAbility();
            }

            enemy.TakeDamage(Damage);
            ResetStats(_normalDamag, _normalArmor);
        }

        public void ResetStats(int normalAtack, int normalArmor)
        {
            Armor = normalArmor;
            Damage = normalAtack;
        }

        protected abstract void UseAbility();

        public abstract Fighter Clone();

        public void ShowStatsInChose()
        {
            Console.WriteLine($"{Name}\t\t HP = {Health}\t ATK = {Damage} \t ARM = {Armor}");
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}\t XP = {Health}\t ATK = {Damage}");
        }

        public void SaveStats()
        {
            _normalDamag = Damage;
            _normalArmor = Armor;
        }

        private void TakeDamage(int damage)
        {
            if (Armor >= damage)
            {
                damage = _minimalDamage;
                Health -= damage;
            }
            else
            {
                Health -= damage - Armor;
            }

            if (Health < 0)
            {
                Health = 0;
            }
        }
    }

    class Infantryman : Fighter
    {
        int _shieldStrike = 15;

        public Infantryman() : base("Infantryman", 150, 8, 7, 0, false)
        {

        }

        protected override void UseAbility()
        {
            Console.WriteLine("Удар щитом");
            Damage = _shieldStrike;
        }

        public override Fighter Clone()
        {
            return new Infantryman();
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian() : base("Barbarian", 120, 6, 10, 3, true)
        {

        }

        protected override void UseAbility()
        {
            if (Cooldawn > 0)
            {
                Console.WriteLine("накопления ярости");
                ++Damage;
                Cooldawn = 0;
            }
            else
            {
                Cooldawn++;
            }
        }

        public override Fighter Clone()
        {
            return new Barbarian();
        }
    }

    class Paladin : Fighter
    {
        private int _maxHealth;
        private int _healingSize = 3;

        public Paladin() : base("Paladin", 130, 0, 8, 0, true)
        {
            _maxHealth = Health;
        }

        protected override void UseAbility()
        {
            Console.WriteLine("божественные прикосновение");

            if(_maxHealth - _healingSize > Health)
            {
                Health += _healingSize;
            }
            else
            {
                Health = _maxHealth;
            }
        }

        public override Fighter Clone()
        {
            return new Paladin();   
        }
    }

    class Tramp : Fighter
    {
        public Tramp() : base("Tramp", 85, 3, 8, 0, false)
        {

        }

        protected override void UseAbility()
        {
            Console.WriteLine("Подлый удар");
            Damage = Damage + Damage;
        }

        public override Fighter Clone()
        {
            return new Tramp();
        }
    }

    class Ranger : Fighter
    {
        private int _armorAbility = 100;

        public Ranger() : base("Ranger", 90, 5, 2, 0, false)
        {

        }

        protected override void UseAbility()
        {
            Console.WriteLine("Cлытся с тенями");
            Armor = _armorAbility;
        }

        public override Fighter Clone()
        {
            return new Ranger();
        }
    }
}