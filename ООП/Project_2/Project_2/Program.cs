using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player();


            Console.WriteLine("рисуем карту");
        }

        public void Draw()
        {

        }
    }

    class Player
    {
        private int _positionX = 0;
        private int _positionY = 0;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public Player()
        {

        }

        public void ShowPosition()
        {
            Console.WriteLine("позиция игрока");
        }

    }
}

//Создать класс игрока, у которого есть поля с его положением в x,y. 
//Создать класс отрисовщик, с методом, который отрисует игрока. 
//Попрактиковаться в работе со свойствами.