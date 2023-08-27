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
        private const int _SpecialHitChance = 30;

        Fighter _firstFighter;
        Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();
        private int _maxXpBar = 0;
        private bool _changeXp = false;
        
        public Fight()
        {
            _fighters.Add(new Infantryman(150, 8, 7, 0, false));
            _fighters.Add(new Barbarian(120,6,10, 0, true));
            _fighters.Add(new Paladin(130,0,8, 0, true));
            _fighters.Add(new Tramp(85,3,14, 0, false));
            _fighters.Add(new Ranger(90,5,13, 0, false));
        }

        public void Play()
        {
            Console.WriteLine("Добро пожаловать на арену.");
            Console.WriteLine("Выберите первого бойца.");
            _firstFighter = FighterChoice();

            Console.WriteLine("Выберите второго бойца.");
            _secondFighter = FighterChoice();

            Round();

            Console.ReadKey();
        }

        public void Round()
        {
            int specialHitFirstFighter;
            int specialHitSecondFighter;
            int normalFirstAtack = _firstFighter.Atack;
            int normalFirstArmor = _firstFighter.Armor;
            int normalSecondAtack = _secondFighter.Atack;
            int normalSecondArmor = _secondFighter.Armor;

            bool endRound = true;

            while (endRound)
            {
                if(_firstFighter.IsPasiveSkil == false)
                {
                    specialHitFirstFighter = RandomPercentage();
                    Console.WriteLine(specialHitFirstFighter);
                    if (specialHitFirstFighter >= _SpecialHitChance)
                    {
                        _firstFighter.Ability();
                        _secondFighter.TakeDamage(_firstFighter.MakeDamage());
                    }
                    else
                    {
                        _secondFighter.TakeDamage(_firstFighter.MakeDamage());
                    }
                }
                else
                {
                    _firstFighter.Ability();
                    _secondFighter.TakeDamage(_firstFighter.MakeDamage());
                }

                if (_secondFighter.IsPasiveSkil == false)
                {
                    specialHitSecondFighter = RandomPercentage();
                    Console.WriteLine(specialHitSecondFighter);
                    if (specialHitSecondFighter >= _SpecialHitChance)
                    {
                        _secondFighter.Ability();
                        _firstFighter.TakeDamage(_secondFighter.MakeDamage());
                    }
                    else
                    {
                        _firstFighter.TakeDamage(_secondFighter.MakeDamage());
                    }
                }
                else
                {
                    _secondFighter.Ability();
                    _firstFighter.TakeDamage(_secondFighter.MakeDamage());
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
                        Console.WriteLine($"Бой окончен, победил {_secondFighter.GetType().Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Бой окончен, победил {_firstFighter.GetType().Name}");
                    }
                }

                if (_firstFighter.IsPasiveSkil == false)
                {
                    _firstFighter.NormalAtackArmor(_firstFighter, normalFirstAtack, normalFirstArmor);
                }

                if (_secondFighter.IsPasiveSkil == false)
                {
                    _secondFighter.NormalAtackArmor(_secondFighter, normalSecondAtack, normalSecondArmor);

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
            Console.WriteLine($"{fighter.GetType().Name}\t\t XP = {fighter.Health}\t ATK = {fighter.Atack} \t ARM = {fighter.Armor}");
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

        private int RandomPercentage()
        {
            int minNumber = 0;
            int maxNumber = 100;
            Random random = new Random();

            return random.Next(minNumber, maxNumber);
        }

        private Fighter FighterChoice()
        {
            const int FirstFighter = 0;
            const int SecondFighter = 1;
            const int ThirdFighter = 2;
            const int FourthFighter = 3;
            const int FifthFighter = 4;

            bool isRightChoice = true;
            Fighter fighter = null;

            while (isRightChoice)
            {
                ShowAllFighter();
                Console.Write("Боец под номеров - ");

                int command = GetNumber();
                isRightChoice = false;

                switch (--command)
                {
                    case FirstFighter:
                        fighter = _fighters[command].Clone();
                        break;

                    case SecondFighter:
                        fighter = _fighters[command].Clone();
                        break;

                    case ThirdFighter:
                        fighter = _fighters[command].Clone();
                        break;

                    case FourthFighter:
                        fighter = _fighters[command].Clone();
                        break;

                    case FifthFighter:
                        fighter = _fighters[command].Clone();
                        break;

                    default:
                        isRightChoice = true;
                        Console.WriteLine("Не верный ввод, повторите");
                        break;
                }
            }
            return fighter;
        } 

        private void PrintBar( int number)
        {
            if (_firstFighter.Health >= _secondFighter.Health && _changeXp == false)
            {
                _maxXpBar = _firstFighter.Health;
                _changeXp = true;
            }
            else if (_secondFighter.Health > _firstFighter.Health && _changeXp == false)
            {
                _maxXpBar = _secondFighter.Health;
                _changeXp = true;
            }
            
            char[] healtBar = new char[_maxXpBar];

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
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Atack { get; protected set; }
        public int CoolDawn { get; protected set; }
        public bool IsPasiveSkil { get; protected set; }

        public Fighter(int health, int armor, int atack,int cooldawn, bool isPasivSkil)
        {
            Health = health;
            Armor = armor;
            Atack = atack;
            CoolDawn = cooldawn;
            IsPasiveSkil = isPasivSkil;
        }
        
        public int MakeDamage()
        {
            return Atack;
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

        public void NormalAtackArmor(Fighter fighter, int normalAtack, int normalArmor)
        {
            fighter.Armor = normalArmor;
            fighter.Atack = normalAtack;
        }

        public abstract void Ability();

        public abstract Fighter Clone();
    }

    class Infantryman : Fighter
    {
        int _shieldStrike = 15;

        public Infantryman(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        private Infantryman(Infantryman infantryman):this(infantryman.Health, infantryman.Armor, infantryman.Atack, infantryman.CoolDawn, infantryman.IsPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Удар щитом");
            Atack = _shieldStrike;
        }

        public override Fighter Clone()
        {
            return new Infantryman(this);
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian(int health, int armor, int atack,int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        private Barbarian(Barbarian barbarian) : this(barbarian.Health, barbarian.Armor, barbarian.Atack, barbarian.CoolDawn, barbarian.IsPasiveSkil)
        {

        }

        public override void Ability()
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
            return new Barbarian(this);
        }
    }

    class Paladin : Fighter
    {
        private int _maxHealth;

        public Paladin(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        private Paladin(Paladin paladin) : this(paladin.Health, paladin.Armor, paladin.Atack, paladin.CoolDawn, paladin.IsPasiveSkil)
        {
            _maxHealth = Health;
        }

        public override void Ability()
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
            return new Paladin(this);   
        }
    }

    class Tramp : Fighter
    {
        public Tramp(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        private Tramp(Tramp tramp) : this(tramp.Health, tramp.Armor, tramp.Atack, tramp.CoolDawn, tramp.IsPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Подлый удар");
            Atack = Atack + Atack;
        }

        public override Fighter Clone()
        {
            return new Tramp(this);
        }
    }

    class Ranger : Fighter
    {
        private int _armorAbility = 100;

        public Ranger(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        private Ranger(Ranger ranger) : this(ranger.Health, ranger.Armor, ranger.Atack, ranger.CoolDawn, ranger.IsPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Cлытся с тенями");
            Armor = _armorAbility;
        }

        public override Fighter Clone()
        {
            return new Ranger(this);
        }
    }
}