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
        private int _SpecialHitChance = 30;

        Fighter _firstFighter;
        Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();
        private int _maxHpBar = 0;
        private bool _changeHP = false;
        
        public Fight()
        {
            _fighters.Add(new Infantryman("Infantryman", 150, 8, 7, 0, false));
            _fighters.Add(new Barbarian("Barbarian", 120,6,10, 0, true));
            _fighters.Add(new Paladin("Paladin", 130,0,8, 0, true));
            _fighters.Add(new Tramp("Tramp", 85,3,14, 0, false));
            _fighters.Add(new Ranger("Ranger", 90,5,13, 0, false));
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

        public void Fighting()
        {
            int specialHitFirstFighter;
            int specialHitSecondFighter;
            int normalFirstFighterDamage = _firstFighter.Atack;
            int normalFirstFighterArmore = _firstFighter.Armor;
            int normalSecondFighterDamage = _secondFighter.Atack;
            int normalSecondFighterArmore = _secondFighter.Armor;

            bool endRound = true;

            while (endRound)
            {
                if (_firstFighter.IsPasiveSkil == false)
                {
                    specialHitFirstFighter = GenerateRandomNumber();

                    if (specialHitFirstFighter >= _SpecialHitChance)
                    {
                        _firstFighter.UseAbility();
                        _secondFighter.TakeDamage(_firstFighter.Atack);
                        _secondFighter.MakeDamage(_firstFighter);
                    }
                    else
                    {
                        _secondFighter.TakeDamage(_firstFighter.Atack);
                        _secondFighter.MakeDamage(_firstFighter);
                    }
                }
                else
                {
                    _firstFighter.UseAbility();
                    _secondFighter.TakeDamage(_firstFighter.Atack);
                    _secondFighter.MakeDamage(_firstFighter);
                }

                if (_secondFighter.IsPasiveSkil == false)
                {
                    specialHitSecondFighter = GenerateRandomNumber();

                    if (specialHitSecondFighter >= _SpecialHitChance)
                    {
                        _secondFighter.UseAbility();
                        _firstFighter.TakeDamage(_secondFighter.Atack);
                        _firstFighter.MakeDamage(_secondFighter);
                    }
                    else
                    {
                        _firstFighter.TakeDamage(_secondFighter.Atack);
                        _firstFighter.MakeDamage(_secondFighter);
                    }
                }
                else
                {
                    _secondFighter.UseAbility();
                    _firstFighter.TakeDamage(_secondFighter.Atack);
                    _firstFighter.MakeDamage(_secondFighter);
                }

                if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
                {
                    endRound = false;

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

                if (_firstFighter.IsPasiveSkil == false)
                {
                    _firstFighter.NormalizeDamageArmor(_firstFighter, normalFirstFighterDamage, normalFirstFighterArmore);
                }

                if (_secondFighter.IsPasiveSkil == false)
                {
                    _secondFighter.NormalizeDamageArmor(_secondFighter, normalSecondFighterDamage, normalSecondFighterArmore);

                }

                PrintBar(_firstFighter.Health);
                ShowStats(_firstFighter);
                PrintBar(_secondFighter.Health);
                ShowStats(_secondFighter);
                Console.ReadKey();
            }
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

        private int GenerateRandomNumber()
        {
            int minNumber = 0;
            int maxNumber = 100;
            Random random = new Random();

            return random.Next(minNumber, maxNumber);
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

        private void PrintBar( int number)
        {
            if (_firstFighter.Health >= _secondFighter.Health && _changeHP == false)
            {
                _maxHpBar = _firstFighter.Health;
                _changeHP = true;
            }
            else if (_secondFighter.Health > _firstFighter.Health && _changeHP == false)
            {
                _maxHpBar = _secondFighter.Health;
                _changeHP = true;
            }
            
            char[] healtBar = new char[_maxHpBar];

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
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Atack { get; protected set; }
        public int CoolDawn { get; protected set; }
        public bool IsPasiveSkil { get; protected set; }

        public Fighter(string name, int health, int armor, int atack,int cooldawn, bool isPasivSkil)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Atack = atack;
            CoolDawn = cooldawn;
            IsPasiveSkil = isPasivSkil;
        }
        
        public void MakeDamage(Fighter fighter)
        {
            if (Atack - fighter.Armor >= 0)
            {
                fighter.Health -= Atack - Armor;
            }
            else
            {
                fighter.Health--;
            }
        }

        public void TakeDamage(int damage)
        {
            if(Armor >= damage)
            {
                damage = 1;
                Health -= damage;
            }
            else
            {
                Health -= damage - Armor;
            }
        }

        public void NormalizeDamageArmor(Fighter fighter, int normalAtack, int normalArmor)
        {
            fighter.Armor = normalArmor;
            fighter.Atack = normalAtack;
        }

        public abstract void UseAbility();

        public abstract Fighter Clone();
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
            return new Infantryman(Name, Health, Armor, Atack, CoolDawn, IsPasiveSkil);
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian(string name, int health, int armor, int atack,int cooldawn, bool isPasiveSkil) : base(name, health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            if (CoolDawn > 0)
            {
                Console.WriteLine("накопления ярости");
                ++Atack;
                CoolDawn = 0;
            }
            else
            {
                CoolDawn++;
            }
        }

        public override Fighter Clone()
        {
            return new Barbarian(Name, Health, Armor, Atack, CoolDawn, IsPasiveSkil);
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
            return new Paladin(Name, Health, Armor, Atack, CoolDawn, IsPasiveSkil);   
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
            return new Tramp(Name, Health, Armor, Atack, CoolDawn, IsPasiveSkil);
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
            return new Ranger(Name, Health, Armor, Atack, CoolDawn, IsPasiveSkil);
        }
    }
}