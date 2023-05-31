using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }

    class Game
    {
        private Deck _deck = new Deck();

        public void Play()
        {
            string namePlayer;

            Console.WriteLine("Начнем игру");
            Console.Write("Введите имя игрока - ");

            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer);

            //------------------------------создали ирока
            while (true)
            {
                Card card = _deck.GiveCard();
                player.TakeCard(card);
                player.ShowCards();
                _deck.ShowStatus();
                
                Console.ReadKey();
            }
            

        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowCards()
        {
            foreach (Card card in _cards)
            {
                card.ShowName();
                Console.WriteLine();
            }
        }
    }

    class Card
    {
        public Card(string name, int valueCard)
        {
            Name = name;
            ValueCard = valueCard;
        }

        private string Name { get; set; }
        private int ValueCard { get; set; }

        public void ShowName()
        {
            Console.Write(Name);
        }
    }

    class Deck
    {
        private Dictionary<int, string> deck = new Dictionary<int, string>()
        {  
            {1,"Ace-♦"},
            {2,"Ace-♥"},
            {3,"Ace-♣"},
            {4,"Ace-♠"},
            {5,"King-♦"},
            {6,"King-♥"},
            {7,"King-♣"},
            {8,"King-♠"},
            {9,"Queen-♦"},
            {10,"Queen-♥"},
            {11,"Queen-♣"},
            {12,"Queen-♠"},
            {13,"Jack-♦"},
            {14,"Jack-♥"},
            {15,"Jack-♣"},
            {16,"Jack-♠"},
            {17,"Ten-♦"},
            {18,"Ten-♥"},
            {19,"Ten-♣"},
            {20,"Ten-♠"},
            {21,"Nine-♦"},
            {22,"Nine-♥"},
            {23,"Nine-♣"},
            {24,"Nine-♠"},
            {25,"Eght-♦"},
            {26,"Eght-♥"},
            {27,"Eght-♣"},
            {28,"Eght-♠"},
            {29,"Seven-♦"},
            {30,"Seven-♥"},
            {31,"Seven-♣"},
            {32,"Seven-♠"},
            {33,"Six-♦"},
            {34,"Six-♥"},
            {35,"Six-♣"},
            {36,"Six-♠"},
            {37,"Five-♦"},
            {38,"Five-♥"},
            {39,"Five-♣"},
            {40,"Five-♠"},
            {41,"Four-♦"},
            {42,"Four-♥"},
            {43,"Four-♣"},
            {44,"Four-♠"},
            {45,"Three-♦"},
            {46,"Three-♥"},
            {47,"Three-♣"},
            {48,"Three-♠"},
            {49,"Two-♦"},
            {50,"Two-♥"},
            {51,"Two-♣"},
            {52,"Two-♠"}
        };
        private bool[] inDeck = new bool[52];
        private Dictionary<string, int> card = new Dictionary<string, int>()
        {
            { "Ace", 11 },
            { "King", 4 },
            { "Queen", 3 },
            { "Jack", 2 },
            { "Ten", 10 },
            { "Nine", 9 },
            { "Eght", 8 },
            { "Seven", 7 },
            { "Six", 6 },
            { "Five", 5 },
            { "Four", 4 },
            { "Three", 3 },
            { "Two", 2 }
        };

        public Card GiveCard()
        {
            int numberCard = 0;
            int valueCard;
            string nameCard;
            bool repick = true;

            Random randomCard = new Random();

            while (repick)
            {
                numberCard = randomCard.Next() % deck.Count;
                if(inDeck[numberCard] == false)
                {
                    repick = false;
                    inDeck[numberCard] = true;
                }
            }

            deck.TryGetValue(numberCard, out nameCard);

            string[] templeString = nameCard.Split('-');
            card.TryGetValue(templeString[0], out valueCard);

            return new Card(nameCard, valueCard);
        }

        public void ShowStatus()
        {
            foreach (bool i in inDeck)
            {
                Console.Write(i + " ");
            }
        }
    }
}

/*

            // беру карту
            // рисую карту
            // считаю очки карты
            // прорисовка карт

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


/* создать колоду карт ---------------------------------------------------------
 * создать выбор количеста игроков за столом
 * создать добавления карт ботам
 * создать подбор карт игроку
 * создать логическую концовку игры

Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт (может быть как выбор пользователя, 
так и количество сколько карт надо взять). После выводиться вся информация о вытянутых картах.
Возможные классы: Карта, Колода, Игрок.

*/
