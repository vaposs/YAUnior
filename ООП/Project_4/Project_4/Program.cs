using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.GameBegin();
        }
    }

    class Game
    {
        public void GameBegin()
        {
            int countPlayer;
            Dictionary<int, string> deck = new Dictionary<int, string>()
            {
                {1,"Ace-Diamonds"},
                {2,"Ace-Hearts"},
                {3,"Ace-Clubs"},
                {4,"Ace-Spades"},
                {5,"King-Diamonds"},
                {6,"King-Hearts"},
                {7,"King-Clubs"},
                {8,"King-Spades"},
                {9,"Queen-Diamonds"},
                {10,"Queen-Hearts"},
                {11,"Queen-Clubs"},
                {12,"Queen-Spades"},
                {13,"Jack-Diamonds"},
                {14,"Jack-Hearts"},
                {15,"Jack-Clubs"},
                {16,"Jack-Spades"},
                {17,"Ten-Diamonds"},
                {18,"Ten-Hearts"},
                {19,"Ten-Clubs"},
                {20,"Ten-Spades"},
                {21,"Nine-Diamonds"},
                {22,"Nine-Hearts"},
                {23,"Nine-Clubs"},
                {24,"Nine-Spades"},
                {25,"Eght-Diamonds"},
                {26,"Eght-Hearts"},
                {27,"Eght-Clubs"},
                {28,"Eght-Spades"},
                {29,"Seven-Diamonds"},
                {30,"Seven-Hearts"},
                {31,"Seven-Clubs"},
                {32,"Seven-Spades"},
                {33,"Six-Diamonds"},
                {34,"Six-Hearts"},
                {35,"Six-Clubs"},
                {36,"Six-Spades"},
                {37,"Five-Diamonds"},
                {38,"Five-Hearts"},
                {39,"Five-Clubs"},
                {40,"Five-Spades"},
                {41,"Four-Diamonds"},
                {42,"Four-Hearts"},
                {43,"Four-Clubs"},
                {44,"Four-Spades"},
                {45,"Three-Diamonds"},
                {46,"Three-Hearts"},
                {47,"Three-Clubs"},
                {48,"Three-Spades"},
                {49,"Two-Diamonds"},
                {50,"Two-Hearts"},
                {51,"Two-Clubs"},
                {52,"Two-Spades"}
            };
            bool[] inDeck = new bool[52];

            //Console.WriteLine("Введите количесво игроков за столом (от 2 до 6) - ");
            //countPlayer = GetNumber();

            while (true)
            {
                TakeCard(inDeck,deck);
                Print(inDeck);
            }

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

        private void TakeCard(bool[] inDeck, Dictionary<int,string> deck)
        {
            string nameCard;
            int minNubmer = 1;
            int countCard = 52;
            int cardIndex;
            Random random = new Random();

            cardIndex = random.Next() % countCard;
            while(inDeck[cardIndex] == true)
            {
                cardIndex = random.Next() % countCard;
            }

            Console.WriteLine(cardIndex);
            inDeck[cardIndex - 1] = true;
            deck.TryGetValue(cardIndex, out nameCard);
            Console.WriteLine(nameCard);


        }

        public void Print(bool[] inDeck)
        {
            for (int i = 0; i < inDeck.Length; i++)
            {
                Console.Write(inDeck[i] + " ");
            }
            Console.WriteLine("\n");
        }

    }

    class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        private string Suit { get; set; }
        private string Rank { get; set; }

        public int ValueCard(string suit)
        {
            bool value = false;
            int values = 0;

            Dictionary<string, int> card = new Dictionary<string, int>()
            {
                { "Ace",11},
                { "King",4},
                { "Queen",3},
                { "Jack",2},
                {"Ten",10},
                { "nine",9},
                { "eght",8},
                { "seven",7},
                { "six",6},
                { "five",5},
                { "four",4},
                { "three",3},
                { "two",2}
            };

            value = card.TryGetValue(suit, out values);

            return values;
        }
    }

    class Player
    {
        public Player(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public int Number { get; private set; }
        public string Name { get; private set; }
    }

    class Deck
    {

    }
}

/* создать колоду карт ---------------------------------------------------------
 * создать выбор количеста игроков за столом
 * создать добавления карт ботам
 * создать подбор карт игроку
 * создать логическую концовку игры
  



suit - масть карты
Diamonds(Бубы / Алмазы)
Hearts(Черви / Сердца)
Clubs(Трефы / Клубы)
Spades(Пики / Лопаты)

rank - ранг карты
Ace(Туз)
Jack(Валет / Джек)
Queen(Дама / Королева(
King(Король)
ten
nine
eght
seven
six
five
four
three
two

Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт (может быть как выбор пользователя, 
так и количество сколько карт надо взять). После выводиться вся информация о вытянутых картах.
Возможные классы: Карта, Колода, Игрок.

*/
