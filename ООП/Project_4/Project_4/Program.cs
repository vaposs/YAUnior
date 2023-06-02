using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Played();
        }
    }

    class Game
    {
        private Deck _deck = new Deck();

        public void Played()
        {
            const int MaxScore = 21; 
            bool isGameOver = true;
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

                if (player.ShowScore() > MaxScore)
                {
                    Console.Write($"перебор,{namePlayer} набрал {player.ShowScore()}");
                    isGameOver = false;
                }
                else
                {
                    Console.Write(player.ShowScore());
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
            }
        }

        public int ShowScore()
        {
            int score = 0;

            foreach (Card card in _cards)
            {
                score += card.Scored();
            }

            return score;
        }
    }

    class Card
    {
        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }

        private string Name { get; set; }
        private int Value { get; set; }

        public string ReturnName()
        {
            return Name;
        }

        public int Scored()
        {
            return Value;
        }

        public void ShowName()
        {
            Console.WriteLine(Name);
        }
    }

    class Deck
    {
        private List<Card> _inDeck = new List<Card>();

        private string[] rank = new string[] {"Ace", "King", "Queen", "Jack", "Ten", "Nine", "Eght", "Seven", "Six", "Five", "Four", "Three", "Two"};
        private char[] suit = new char[] { '♦', '♥', '♣', '♠' };
        private int[] value = new int[] { 11, 4, 3, 2, 10, 9, 8, 7, 6, 5, 4, 3, 2 }; 

        public Card GiveCard()
        {
            int numberCardRank;
            int numberCardSuit;
            int valueCard = 0;
            string nameCard = "";
            bool isRepick = true;

            while (isRepick)
            {
                Random randomNumber = new Random();

                numberCardRank = randomNumber.Next(rank.Length);
                numberCardSuit = randomNumber.Next(suit.Length);
                valueCard = value[numberCardRank];
                nameCard = ($"{rank[numberCardRank]}-{suit[numberCardSuit]}");

                if (_inDeck.Count == 0)
                {
                    return new Card(nameCard, valueCard);
                }
                else
                {
                    foreach (Card card in _inDeck)
                    {
                        if (card.ReturnName() != nameCard)
                        {
                            isRepick = false;
                        }
                    }
                }
            }

            return new Card(nameCard, valueCard);
        }
    }
}