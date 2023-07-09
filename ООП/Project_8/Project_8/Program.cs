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
        Fighter _firstFighter;
        Fighter _secondFighter;

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
            bool endRound = true;
            int normalAtackFirstFighter = _firstFighter.Atack;
            int normalAtackSecondFighter = _secondFighter.Atack;
            int normalArmorFirstFighter = _firstFighter.Armor;
            int normalArmorSecondFighter = _secondFighter.Armor;

            while (endRound)
            {
                specialHitFirstFighter = RandomPercentage();
                specialHitSecondFighter = RandomPercentage();
                Console.Clear();

                if(_firstFighter.isPasiveskil == true)
                {
                    _firstFighter.Ability();
                }
                else
                {
                    if(specialHitFirstFighter < 30)
                    {
                        _firstFighter.Ability();
                    }
                    else
                    {
                        _secondFighter.TakeDamage(Damage(_firstFighter.Atack, _secondFighter.Armor));
                    }
                }

                if(_secondFighter.isPasiveskil == true)
                {
                    _secondFighter.Ability();
                }
                else
                {
                    if(specialHitSecondFighter < 30)
                    {
                        _secondFighter.Ability();
                    }
                    else
                    {
                        _firstFighter.TakeDamage(Damage(_secondFighter.Atack, _secondFighter.Armor));
                    }
                }

                _firstFighter.NormalArmorAtack(normalAtackFirstFighter, normalArmorFirstFighter);
                _secondFighter.NormalArmorAtack(normalAtackSecondFighter, normalArmorSecondFighter);

                PrintBar(_firstFighter.Health);
                ShowStats(_firstFighter);
                PrintBar(_secondFighter.Health);
                ShowStats(_secondFighter);

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

                Console.ReadKey();
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

        private int Damage(int atack, int armor)
        {
            int damage;

            damage = atack - armor;

            if (damage <= 0)
            {
                damage = 1;
            }

            return damage;
        } 

        private Fighter FighterChoice()
        {
            const string FirstFighter = "1";
            const string SecondFighter = "2";
            const string ThirdFighter = "3";
            const string FourthFighter = "4";
            const string FifthFighter = "5";

            bool isRightChoice = true;
            Fighter fighter = null;

            while (isRightChoice)
            {
                Console.WriteLine($"{FirstFighter}. Щитоносец (Блок щитом)");
                Console.WriteLine($"{SecondFighter}. Варвар (Неистовый крик)");
                Console.WriteLine($"{ThirdFighter}. Паладин (Божетвенный свет)");
                Console.WriteLine($"{FourthFighter}. Плут (Критический удар)");
                Console.WriteLine($"{FifthFighter}. Ренджер (Двойной удар)\n");
                Console.Write("Боец под номеров - ");

                string command = Console.ReadLine();

                isRightChoice = false;

                switch (command.ToLower())
                {
                    case FirstFighter:
                        fighter = CreatingFighterInfantryman();
                        break;

                    case SecondFighter:
                        fighter = CreateFighterBarbarian();
                        break;

                    case ThirdFighter:
                        fighter = CreateFighterPaladin();
                        break;

                    case FourthFighter:
                        fighter = CreateFighterTramp();
                        break;

                    case FifthFighter:
                        fighter = CreateFighterRanger();
                        break;

                    default:
                        isRightChoice = true;
                        Console.WriteLine("Не верный ввод, повторите");
                        break;
                }
            }

            return fighter;
        } 

        private Fighter CreatingFighterInfantryman()
        {
            int heathInfantryman = 100;
            int armorInfantryman = 0;
            int atackInfantryman = 5;
            bool isPasiveskil = false;

            return new Infantryman(heathInfantryman, armorInfantryman, atackInfantryman, isPasiveskil);
        } 

        private Fighter CreateFighterBarbarian()
        {
            int heathBarbarian = 80;
            int armorBarbarian = 4;
            int atackBarbarian = 13;
            bool isPasiveskil = false;

            return new Barbarian(heathBarbarian, armorBarbarian, atackBarbarian, isPasiveskil);
        } 

        private Fighter CreateFighterPaladin()
        {
            int heathPaladin = 110;
            int armorPaladin = 5;
            int atackPaladin = 13;
            bool isPasiveskil = true;

            return new Paladin(heathPaladin, armorPaladin, atackPaladin, isPasiveskil);
        } 

        private Fighter CreateFighterTramp()
        {
            int heathTramp = 75;
            int armorTramp = 0;
            int atackTramp = 17;
            bool isPasiveskil = false;

            return new Tramp(heathTramp, armorTramp, atackTramp, isPasiveskil);
        } 

        private Fighter CreateFighterRanger()
        {
            int heathRanger = 90;
            int armorRanger = 4;
            int atackRanger = 13;
            bool isPasiveskil = false;

            return new Ranger(heathRanger, armorRanger, atackRanger, isPasiveskil);
        } 

        private void PrintBar( int number)
        {
            int xpBar = 110;
            char[] healtBar = new char[xpBar];

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
    }

    abstract class Fighter
    {
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public int Atack { get; private set; }
        public bool isPasiveskil { get; private set; }

        public Fighter(int health, int armor, int atack, bool isPasivskil)
        {
            Health = health;
            Armor = armor;
            Atack = atack;
            isPasiveskil = isPasivskil;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void NormalArmorAtack(int normalAtack, int normalArmor)
        {
            Atack = normalAtack;
            Armor = normalArmor;
        }

        public void BarbarianAbiliti(int damageIncreaseFactor)
        {
            Atack = Atack + damageIncreaseFactor;
        }

        public void GraceGods(int atack)
        {
            int percentageVampirism = 25;
            int percentageAll = 100;

            Health += atack / percentageVampirism * percentageAll;
        }

        public void CritDamage(int atack)
        {
            int criticalDamageMultiplier = 3;
            Atack = atack * criticalDamageMultiplier;
        }

        public void DoubleAtack(int atack)
        {
            Atack = Atack + Atack;
        }

        public abstract void Ability();
    }

    class Infantryman : Fighter
    {
        public Infantryman(int health, int armor, int atack, bool isPasiveskil) : base(health, armor, atack, isPasiveskil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Блок щитом");
            if(isPasiveskil == false)
            {
                ShieldBlock();
            }
        }

        private void ShieldBlock()
        {
            int damage = 0;

            TakeDamage(damage);
        }
    }

    class Barbarian : Fighter
    {
        private int _damageIncreaseFactor = 3;

        public Barbarian(int health, int armor, int atack, bool isPasiveskil) : base(health, armor, atack, isPasiveskil)
        {

        }

        public override void Ability()
        {
            if (isPasiveskil == false)
            {
                Console.WriteLine("Прирост урона");
                BarbarianAbiliti(_damageIncreaseFactor);
            }
        }
    }

    class Paladin : Fighter
    {
        public Paladin(int health, int armor, int atack, bool isPasiveskil) : base(health, armor, atack, isPasiveskil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Милость богов, раны затягиваются");
            GraceGods(Atack);
        }
    }

    class Tramp : Fighter
    {
        public Tramp(int health, int armor, int atack, bool isPasiveskil) : base(health, armor, atack, isPasiveskil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Вы наносите критический урон");
            CritDamage(Atack);
        }
    }

    class Ranger : Fighter
    {
        public Ranger(int health, int armor, int atack, bool isPasiveskil) : base(health, armor, atack, isPasiveskil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("Вы наносите двойной удар");
            DoubleAtack(Atack);
        }
    }
}