using System;
using System.Collections.Generic;

// if (_firstFighter.isPasiveskil == true) // Свойства всегда с большой буквы пишем. И каждое новое слово с большой буквы 2) _secondFighter.TakeDamage(Damage(_firstFighter.Atack, _secondFighter.Armor)); // Нужен метод атаки. У вас бойцы умеют получать урон, но не умеют атаковать. Представьте шутер, где вы не можете стрелять, но можете просто отдавать урон, а другой будет его получать. Получается не очень, обязательно нужен метод, который инициирует атаку Attack(Enemy enemy) => enemy.TakeDamage(Damage); 3) private Fighter FighterChoice() // Здесь дубляж кода, чтобы от него избавиться, сделайте вариант с хранением ссылок на бойцов в массиве -> Выбирайте оттуда по индексу нужного бойца -> Клонируете его (Будет создаваться его копия через new(), и не будет проблем со ссылками). Если сложно, советую обратить внимание на интерфейс ICloneable и его метод Clone() => return new Fighter();, реализуйте что-то похожее у себя в программе. Тогда расширяться в коде у вас будет только массив, где хранятся бойцы на выбор.


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
        private List<Fighter> _fighters = new List<Fighter>();
        private int _maxXpBar = 0;
        private bool _changeXp = false;
        private const int _SpecialHitChance = 30;

        public Fight()
        {
            _fighters.Add(new Infantryman(150, 10, 7, 3, false));
            _fighters.Add(new Barbarian(120,6,10, 0, true));
            _fighters.Add(new Paladin(130,10,8, 0, true));
            _fighters.Add(new Tramp(85,3,14, 3, false));
            _fighters.Add(new Ranger(90,5,13, 3, false));
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
                _firstFighter.NormalAtackArmor(_firstFighter, normalFirstAtack, normalFirstArmor);
                _secondFighter.NormalAtackArmor(_secondFighter, normalSecondAtack, normalSecondArmor);

                PrintBar(_firstFighter.Health);
                ShowStats(_firstFighter);
                PrintBar(_secondFighter.Health);
                ShowStats(_secondFighter);

                specialHitFirstFighter = RandomPercentage();
                specialHitSecondFighter = RandomPercentage();

                if(_firstFighter.IsPasiveSkil == false)
                {
                    if (specialHitFirstFighter >= _SpecialHitChance)
                    {
                        _firstFighter.Ability();
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

                if(_secondFighter.IsPasiveSkil == false)
                {
                    if(specialHitSecondFighter >= _SpecialHitChance)
                    {
                        _secondFighter.Ability();
                    }
                    else
                    {
                        _firstFighter.TakeDamage(_secondFighter.MakeDamage());
                    }
                }
                else
                {
                    _secondFighter.Ability();
                    _firstFighter.TakeDamage(_firstFighter.MakeDamage());
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

                Console.ReadKey();
                Console.Clear();
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
                        fighter = _fighters[command];
                        break;

                    case SecondFighter:
                        fighter = _fighters[command];
                        break;

                    case ThirdFighter:
                        fighter = _fighters[command];
                        break;

                    case FourthFighter:
                        fighter = _fighters[command];
                        break;

                    case FifthFighter:
                        fighter = _fighters[command];
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
    }

    class Infantryman : Fighter
    {
        int Shild = 100;

        public Infantryman(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("способность щита");
            ShieldBlock();
        }

        private void ShieldBlock()
        {
            Armor = Shild;
        }
    }

    class Barbarian : Fighter
    {
        public Barbarian(int health, int armor, int atack,int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("способность жажда крови");
            Bloodlust();
        }

        private void Bloodlust()
        {
            Atack++;
        }
    }

    class Paladin : Fighter
    {
        const int _BlessingCount = 3; 

        public Paladin(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("способность паладина");
            Blessing();
        }

        private void Blessing()
        {
            Health += _BlessingCount;
        }
    }

    class Tramp : Fighter
    {
        const int CritCount = 2;

        public Tramp(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("способность вора");
            CritDamage();
        }

        private void CritDamage()
        {
            Atack = Atack * CritCount;
        }
    }

    class Ranger : Fighter
    {
        public Ranger(int health, int armor, int atack, int cooldawn, bool isPasiveSkil) : base(health, armor, atack, cooldawn, isPasiveSkil)
        {

        }

        public override void Ability()
        {
            Console.WriteLine("способность ренджера");
            DoubleAtack();
        }

        private void DoubleAtack()
        {
            Atack = Atack + Atack;
        }
    }
}



 /*
using System;
using System.Collections.Generic;

namespace Gladiators
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            ConsoleKeyInfo key;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Гладиаторские бои\n");
                Console.WriteLine("Esc - Выход");
                Console.WriteLine("Any key - Выбрать бойцов\n");
                key = Console.ReadKey(true);
                Ring ring = new Ring();
                Fighter firstFighter;
                Fighter secondFighter;

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        isActive = false;
                        Console.WriteLine("\nПока! Ещё увидимся!\n");
                        break;
                    default:
                        ring.ShowAll();
                        Console.Write("Выбери первого бойца: ");
                        ring.Choose(out firstFighter);
                        ring.ShowAll();
                        Console.Write("Выбери второго бойца: ");
                        ring.Choose(out secondFighter);
                        ring.Fight(firstFighter, secondFighter);
                        break;
                }

                Console.ReadKey(true);
            }
        }
    }

    class Ring
    {
        private List<Fighter> _warriors = new List<Fighter>();

        public Ring()
        {
            _warriors.Add(new Knight("Arnold the Fearless", 1800, 100, 30));
            _warriors.Add(new Dwarf("Dworoum Goldback", 4000, 110, 15));
            _warriors.Add(new Elf("Delmuth Lorakas", 1800, 220, 20));
            _warriors.Add(new Hobbit("Hildebold Twofoot", 1300, 150, 40));
            _warriors.Add(new Orc("Zortguth V", 2200, 160, 10));
        }

        public void ShowAll()
        {
            Console.WriteLine("Список участников:");

            for (int i = 0; i < _warriors.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _warriors[i].ShowStats();
            }

            Console.WriteLine();
        }

        public void Choose(out Fighter fighter)
        {
            Random random = new Random();
            int fighterIndex = ReadInt() - 1;

            if (fighterIndex < _warriors.Count && fighterIndex >= 0)
            {
                fighter = _warriors[fighterIndex];
                _warriors.RemoveAt(fighterIndex);
            }
            else
            {
                Console.WriteLine("Выберу бойца за тебя..\n");
                fighterIndex = random.Next(0, _warriors.Count);
                fighter = _warriors[fighterIndex];
                _warriors.RemoveAt(fighterIndex);
            }

            Console.Write("Выбран боец: ");
            fighter.ShowStats();
            Console.WriteLine();
        }

        public void Fight(Fighter firstFighter, Fighter secondFighter)
        {
            float normalDamageFirst = firstFighter.Damage;
            float normalArmorFirst = firstFighter.Armor;
            float normalDamageSecond = secondFighter.Damage;
            float normalArmorSecond = secondFighter.Armor;

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                Console.WriteLine();

                if (firstFighter.Recharging == 0)
                {
                    firstFighter.UsePower();
                }

                if (firstFighter.Duration > 0)
                {
                    firstFighter.ReduceDuration();
                }
                else
                {
                    firstFighter.Normalize(firstFighter, normalDamageFirst, normalArmorFirst);
                }

                if (secondFighter.Recharging == 0)
                {
                    secondFighter.UsePower();
                }

                if (secondFighter.Duration > 0)
                {
                    secondFighter.ReduceDuration();
                }
                else
                {
                    secondFighter.Normalize(secondFighter, normalDamageSecond, normalArmorSecond);
                }

                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowStats();
                secondFighter.ShowStats();
                firstFighter.SkipTurn();
                secondFighter.SkipTurn();

                if (firstFighter.Health <= 0 && secondFighter.Health <= 0)
                {
                    Console.WriteLine("Ничья, оба погибли");
                }
                else if (firstFighter.Health <= 0)
                {
                    Console.WriteLine($"{secondFighter.Name} победил!");
                }
                else if (secondFighter.Health <= 0)
                {
                    Console.WriteLine($"{firstFighter.Name} победил!");
                }
            }
        }

        private int ReadInt()
        {
            int result;

            while (int.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Неверный ввод числа!\nНеобходимо ввести целое число.");
                Console.Write("Введите целое число: ");
            }

            return result;
        }
    }

    class Fighter
    {
        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public float Armor { get; protected set; }
        public int Recharging { get; protected set; }
        public int Duration { get; protected set; }

        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\"{Name}\"   |{Health}HP   {Damage}DMG   {Armor}ARMOR|");
        }

        public void TakeDamage(float damage)
        {
            if (Armor <= 100)
            {
                Health -= damage * (100 - Armor) / 100;
            }
        }

        public void Normalize(Fighter fighter, float normalDamage, float normalArmor)
        {
            fighter.Armor = normalArmor;
            fighter.Damage = normalDamage;
        }

        public void SkipTurn() => Recharging -= 1;

        public void ReduceDuration() => Duration -= 1;

        public virtual void UsePower() { }
    }

    class Knight : Fighter
    {
        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Помолиться\"");
            Pray();
        }

        private void Pray()
        {
            Health += 200;
            Damage *= 1.1f;
            Recharging = 2;
            Duration = 0;
        }
    }

    class Dwarf : Fighter
    {
        public Dwarf(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Топать\"");
            Stomp();
        }

        private void Stomp()
        {
            Damage *= 2.5f;
            Armor *= 0.5f;
            Recharging = 3;
            Duration = 1;
        }
    }

    class Elf : Fighter
    {
        public Elf(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Читать мысли\"");
            ReadThoughts();
        }

        private void ReadThoughts()
        {
            Armor = 100;
            Recharging = 4;
            Duration = 1;
        }
    }

    class Hobbit : Fighter
    {
        public Hobbit(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Спрятаться\"");
            Hide();
        }

        public void Hide()
        {
            Armor += 8;
            Recharging = 3;
            Duration = 2;
        }
    }

    class Orc : Fighter
    {
        public Orc(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void UsePower()
        {
            Console.WriteLine($"\t{Name} использует способность \"Рычать\"");
            Roar();
        }

        public void Roar()
        {
            Damage += 50;
            Health -= 100;
            Recharging = 2;
            Duration = 3;
        }
    }
} */