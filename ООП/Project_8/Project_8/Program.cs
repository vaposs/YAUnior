using System;
using System.Collections.Generic;

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
        private Fighter _firstFighter;
        private Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();
        private int _maxHealthPointsBar = 0;
        private bool _changeHealthPoints = false;
        
        public Fight()
        {
            _fighters.Add(new Infantryman("Infantryman", 150, 8, 7, 0, false));
            _fighters.Add(new Barbarian("Barbarian", 120,6,10, 3, true));
            _fighters.Add(new Paladin("Paladin", 130,0,8, 0, true));
            _fighters.Add(new Tramp("Tramp", 85,3,2, 0, false));
            _fighters.Add(new Ranger("Ranger", 90,5,2, 0, false));
        }

        public void Play()
        {
            Console.WriteLine("Добро пожаловать на арену.");
            Console.WriteLine("Выберите первого бойца.");
            _firstFighter = FighterChoice();

            Console.WriteLine("Выберите второго бойца.");
            _secondFighter = FighterChoice();

            Fighting();

            Console.ReadKey();
        }

        private void Fighting()
        {
            int normalFirstFighterDamage = _firstFighter.Atack;
            int normalFirstFighterArmore = _firstFighter.Armor;
            int normalSecondFighterDamage = _secondFighter.Atack;
            int normalSecondFighterArmore = _secondFighter.Armor;

            bool endRound = true;

            while (endRound)
            {
                _firstFighter.DealDamage(_secondFighter);
                _secondFighter.DealDamage(_firstFighter);

                endRound = IsGameOver(_firstFighter, _secondFighter, endRound);

                if (_firstFighter.HasPassviveSkill == false)
                {
                    _firstFighter.NormalizeDamageArmor(normalFirstFighterDamage, normalFirstFighterArmore);
                }

                if (_secondFighter.HasPassviveSkill == false)
                {
                    _secondFighter.NormalizeDamageArmor(normalSecondFighterDamage, normalSecondFighterArmore);

                }

                PrintHealBar(_firstFighter.Health);
                ShowStats(_firstFighter);
                PrintHealBar(_secondFighter.Health);
                ShowStats(_secondFighter);
                Console.ReadKey();
            }
        }

        private bool IsGameOver(Fighter firstFighter, Fighter secondFighter, bool endRound)
        {
            if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
            {
                if (firstFighter.Health <= 0 && secondFighter.Health <= 0)
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

                endRound = false;
            }

            return endRound;
        }
        
        private void ShowStatsInChose(Fighter fighter)
        {
            Console.WriteLine($"{fighter.Name}\t\t HP = {fighter.Health}\t ATK = {fighter.Atack} \t ARM = {fighter.Armor}");
        }

        private void ShowAllFighter()
        {
            int index = 1;

            foreach (Fighter fighter in _fighters)
            {
                Console.Write($"{index++}. ");
                ShowStatsInChose(fighter);
            }
        }

        private void ShowStats(Fighter fighter)
        {
            Console.WriteLine($"{fighter.GetType().Name}\t XP = {fighter.Health}\t ATK = {fighter.Atack}");
        }  

        private Fighter FighterChoice()
        {
            bool isRightChoice = true;
            Fighter fighter = null;

            while (isRightChoice)
            {
                ShowAllFighter();
                Console.Write("Боец под номеров - ");

                int command = GetNumber();

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

        private void PrintHealBar( int number)
        {
            if (_firstFighter.Health >= _secondFighter.Health && _changeHealthPoints == false)
            {
                _maxHealthPointsBar = _firstFighter.Health;
                _changeHealthPoints = true;
            }
            else if (_secondFighter.Health > _firstFighter.Health && _changeHealthPoints == false)
            {
                _maxHealthPointsBar = _secondFighter.Health;
                _changeHealthPoints = true;
            }
            
            char[] healtBar = new char[_maxHealthPointsBar];

            Console.Write("[");

            for (int i = 1; i < healtBar.Length - 1; i++)
            {
                if (i <= number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('o');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("o");
                }
                Console.ResetColor();
            }

            Console.Write("]");
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
        }
    }

    abstract class Fighter
    {
        private int _specialHitChance = 30;
        private int specialHitFighter;

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Atack { get; protected set; }
        public int Cooldawn { get; protected set; }
        public bool HasPassviveSkill { get; protected set; }

        public Fighter(string name, int health, int armor, int atack,int cooldawn, bool hasPassviveSkill)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Atack = atack;
            Cooldawn = cooldawn;
            HasPassviveSkill = hasPassviveSkill;
        }
        
        public void DealDamage(Fighter enemy)
        {
            if (HasPassviveSkill == false)
            {
                specialHitFighter = GenerateRandomNumber();

                if (specialHitFighter >= _specialHitChance)
                {
                    UseAbility();
                    enemy.TakeDamage(Atack);
                }
                else
                {
                    enemy.TakeDamage(Atack);
                }
            }
            else
            {
                UseAbility();
                enemy.TakeDamage(Atack);
            }
        }

        private int GenerateRandomNumber()
        {
            int minNumber = 0;
            int maxNumber = 100;
            Random random = new Random();

            return random.Next(minNumber, maxNumber);
        }

        public void NormalizeDamageArmor(int normalAtack, int normalArmor)
        {
            Armor = normalArmor;
            Atack = normalAtack;
        }

        public abstract void UseAbility();

        public abstract Fighter Clone();

        private void TakeDamage(int damage)
        {
            if (Armor >= damage)
            {
                damage = 1;
                Health -= damage;
            }
            else
            {
                Health -= damage - Armor;
            }
        }
    }

    class Infantryman : Fighter
    {
        int _shieldStrike = 15;

        public Infantryman(string name, int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Удар щитом");
            Atack = _shieldStrike;
        }

        public override Fighter Clone()
        {
            return new Infantryman(Name, Health, Armor, Atack, Cooldawn, HasPassviveSkill);
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian(string name, int health, int armor, int atack,int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            if (Cooldawn > 0)
            {
                Console.WriteLine("накопления ярости");
                ++Atack;
                Cooldawn = 0;
            }
            else
            {
                Cooldawn++;
            }
        }

        public override Fighter Clone()
        {
            return new Barbarian(Name, Health, Armor, Atack, Cooldawn, HasPassviveSkill);
        }
    }

    class Paladin : Fighter
    {
        private int _maxHealth;

        public Paladin(string name, int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {
            _maxHealth = Health;
        }

        public override void UseAbility()
        {
            Console.WriteLine("божественные прикосновение");

            if(_maxHealth - 3 > Health)
            {
                Health += 3;
            }
            else
            {
                Health = _maxHealth;
            }
        }

        public override Fighter Clone()
        {
            return new Paladin(Name, Health, Armor, Atack, Cooldawn, HasPassviveSkill);   
        }
    }

    class Tramp : Fighter
    {
        public Tramp(string name, int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Подлый удар");
            Atack = Atack + Atack;
        }

        public override Fighter Clone()
        {
            return new Tramp(Name, Health, Armor, Atack, Cooldawn, HasPassviveSkill);
        }
    }

    class Ranger : Fighter
    {
        private int _armorAbility = 100;

        public Ranger(string name, int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Cлытся с тенями");
            Armor = _armorAbility;
        }

        public override Fighter Clone()
        {
            return new Ranger(Name, Health, Armor, Atack, Cooldawn, HasPassviveSkill);
        }
    }
}