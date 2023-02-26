using System;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(50,1,5,10,50, 50);

            player.ShowStats();
        }
    }

    class Player
    {
        public int Health;
        public int Armor;
        public int Damage;
        public int Speed;
        public int Hanger;
        public int Thirst;

        public Player(int health, int armor, int damage, int speed, int hanger, int thirst)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
            Speed = speed;
            Hanger = hanger;
            Thirst = thirst;

        }

        public void ShowStats()
        {
            Console.WriteLine($"Жизни - {Health}.\nЗащита - {Armor}.\nУрон - {Damage}.\nСкорость - {Speed}.\nГолод - {Hanger}.\nЖажда - {Thirst}.\n");
        }
    }
}
