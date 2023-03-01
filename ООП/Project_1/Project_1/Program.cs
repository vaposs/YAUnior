using System;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(50,1,5,10,50,50);

            player.ShowStats();
        }
    }

    class Player
    {
        private int _health;
        private int _armor;
        private int _damage;
        private int _speed;
        private int _hanger;
        private int _thirst;

        public Player(int health, int armor, int damage, int speed, int hanger, int thirst)
        {
            _health = health;
            _armor = armor;
            _damage = damage;
            _speed = speed;
            _hanger = hanger;
            _thirst = thirst;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Жизни - {_health}.\nЗащита - {_armor}.\nУрон - {_damage}.\nСкорость - {_speed}.\nГолод - {_hanger}.\nЖажда - {_thirst}.\n");
        }
    }
}
