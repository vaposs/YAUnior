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

    class UserUtils
    {
        public static int GenerateRandomNumber()
        {
            int minNumber = 0;
            int maxNumber = 100;

            Random random = new Random();

            return random.Next(minNumber, maxNumber);
        }

        public static int GetPositiveNumber()
        {
            string playerCommand;
            bool isConversionSucceeded = true;
            bool isCorrectNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                playerCommand = Console.ReadLine();
                isCorrectNumber = int.TryParse(playerCommand, out number);

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
        private int _maximumFrameLength;


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
            _firstFighter = ChoiceFighter();

            Console.WriteLine("Выберите второго бойца.");
            _secondFighter = ChoiceFighter();

            Fighting();

            Console.ReadKey();
        }

        private void Fighting()
        {
            int normalFirstFighterDamage = _firstFighter.Damage;
            int normalFirstFighterArmore = _firstFighter.Armor;
            int normalSecondFighterDamage = _secondFighter.Damage;
            int normalSecondFighterArmore = _secondFighter.Armor;

            
            while (IsGameOver(_firstFighter, _secondFighter))
            {
                _firstFighter.Atack(_secondFighter);
                _secondFighter.Atack(_firstFighter);

                if (_firstFighter.HasPassviveSkill == false)
                {
                    _firstFighter.NormalizeDamageArmor(normalFirstFighterDamage, normalFirstFighterArmore);
                }

                if (_secondFighter.HasPassviveSkill == false)
                {
                    _secondFighter.NormalizeDamageArmor(normalSecondFighterDamage, normalSecondFighterArmore);

                }

                _firstFighter.ShowStats();
                _secondFighter.ShowStats();
                Console.ReadKey();
            }
        }

        private bool IsGameOver(Fighter firstFighter, Fighter secondFighter)
        {
            bool endRound = true;

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

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Damage { get; protected set; }
        public int Cooldawn { get; protected set; }
        public bool HasPassviveSkill { get; protected set; }

        public Fighter(string name, int health, int armor, int damage,int cooldawn, bool hasPassviveSkill)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
            Cooldawn = cooldawn;
            HasPassviveSkill = hasPassviveSkill;
        }
        
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
        }

        public void NormalizeDamageArmor(int normalAtack, int normalArmor)
        {
            Armor = normalArmor;
            Damage = normalAtack;
        }

        public abstract void UseAbility();

        public abstract Fighter Clone();

        public void ShowStatsInChose()
        {
            Console.WriteLine($"{Name}\t\t HP = {Health}\t ATK = {Damage} \t ARM = {Armor}");
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}\t XP = {Health}\t ATK = {Damage}");
        }

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

            if (Health < 0)
            {
                Health = 0;
            }
        }
    }

    class Infantryman : Fighter
    {
        int _shieldStrike = 15;

        public Infantryman(string name, int health, int armor, int damage, int cooldawn, bool isPasiveSkil) : base(name, health, armor, damage, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Удар щитом");
            Damage = _shieldStrike;
        }

        public override Fighter Clone()
        {
            return new Infantryman(Name, Health, Armor, Damage, Cooldawn, HasPassviveSkill);
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian(string name, int health, int armor, int damage,int cooldawn, bool isPasiveSkil) : base(name, health, armor, damage, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
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
            return new Barbarian(Name, Health, Armor, Damage, Cooldawn, HasPassviveSkill);
        }
    }

    class Paladin : Fighter
    {
        private int _maxHealth;
        private int _recoveryIndex = 3;

        public Paladin(string name, int health, int armor, int damage, int cooldawn, bool isPasiveSkil) : base(name, health, armor, damage, cooldawn, isPasiveSkil)
        {
            _maxHealth = Health;
        }

        public override void UseAbility()
        {
            Console.WriteLine("божественные прикосновение");

            if(_maxHealth - _recoveryIndex > Health)
            {
                Health += _recoveryIndex;
            }
            else
            {
                Health = _maxHealth;
            }
        }

        public override Fighter Clone()
        {
            return new Paladin(Name, Health, Armor, Damage, Cooldawn, HasPassviveSkill);   
        }
    }

    class Tramp : Fighter
    {
        public Tramp(string name, int health, int armor, int damage, int cooldawn, bool isPasiveSkil) : base(name, health, armor, damage, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Подлый удар");
            Damage = Damage + Damage;
        }

        public override Fighter Clone()
        {
            return new Tramp(Name, Health, Armor, Damage, Cooldawn, HasPassviveSkill);
        }
    }

    class Ranger : Fighter
    {
        private int _armorAbility = 100;

        public Ranger(string name, int health, int armor, int damage, int cooldawn, bool isPasiveSkil) : base(name, health, armor, damage, cooldawn, isPasiveSkil)
        {

        }

        public override void UseAbility()
        {
            Console.WriteLine("Cлытся с тенями");
            Armor = _armorAbility;
        }

        public override Fighter Clone()
        {
            return new Ranger(Name, Health, Armor, Damage, Cooldawn, HasPassviveSkill);
        }
    }
}