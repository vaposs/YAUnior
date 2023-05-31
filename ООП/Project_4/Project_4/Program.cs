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
            bool isGameOver = true;
            int i = 0;
            string namePlayer;

            Console.WriteLine("Начнем игру");
            Console.Write("Введите имя игрока - ");

            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer);

            while (isGameOver)
            {
                Console.Clear();
                Card card = _deck.GiveCard();
                player.TakeCard(card);
                player.ShowCards();
                Console.WriteLine();

                if (player.ShowScore() > 21)
                {
                    Console.WriteLine($"перебор,{namePlayer} набрал {player.ShowScore()}");
                    isGameOver = false;
                }
                else
                {
                    Console.Write(player.ShowScore());
                    Console.WriteLine();
                    _deck.ShowStatus();
                }

                Console.ReadKey();
            }

            Console.WriteLine("конец");
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

        public int ShowScore()
        {
            int _score = 0;

            foreach (Card card in _cards)
            {
                _score += card.Score();
            }

            return _score;
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

        public int Score()
        {
            return ValueCard;
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
                if (inDeck[numberCard] == false)
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
            foreach (bool status in inDeck)
            {
                Console.Write(status + " ");
            }
        }
    }
}