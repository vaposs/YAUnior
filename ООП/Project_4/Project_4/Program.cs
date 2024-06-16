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
        private List<Card> _mainDeck;
        private string namePlayer;

        public void Play()
        {
            const string NextCard = "1";
            const string StopGame = "2";

            Console.Write("Введите имя игрока - ");
            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer);

            bool isNotGameOver = true;
            _mainDeck = _deck.Building();
            
            while (isNotGameOver)
            {
                if (_mainDeck.Count == 0)
                {
                    player.TakeCard(_deck.GiveCard());
                    player.ShowCards();
                    Console.WriteLine(player.ShowScore());
                }
                else
                {
                    Console.WriteLine("карту?");
                    Console.WriteLine($"{NextCard}. да ");
                    Console.WriteLine($"{StopGame}. нет ");

                    string command = Console.ReadLine();
                    Console.Clear();

                    switch (command.ToLower())
                    {
                        case NextCard:
                            isNotGameOver = PlayNextRound(player);
                            break;

                        case StopGame:
                            isNotGameOver = false;
                            break;
                    }
                }
            }

            Console.WriteLine("конец");
            Console.ReadKey();
        }

        private bool PlayNextRound(Player player)
        {
            const int MaxScore = 21;

            player.TakeCard(_deck.GiveCard());
            player.ShowCards();

            if (player.ShowScore() > MaxScore)
            {
                Console.WriteLine($"перебор");
                Console.WriteLine(player.ShowScore());
                return false;
            }
            else
            {
                Console.WriteLine(player.ShowScore());
                return true;
            }
        }
    }

    class Player
    {
        private List<Card> _cardsInHand = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void ShowCards()
        {
            foreach (Card card in _cardsInHand)
            {
                Console.WriteLine(card.Name);
            }
        }//--

        public int ShowScore()
        {
            int score = 0;

            foreach (Card card in _cardsInHand)
            {
                score += card.Value;
            }

            return score;
        }//---

        public void TakeCard(Card newCard)
        {
            _cardsInHand.Add(newCard);
        }// ---
    }

    class Card
    {
        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public int Value { get; private set; }
    } // --

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> Building()
        {
            string[] rankCard = new string[] { "Ace", "King", "Queen", "Jack", "Ten", "Nine", "Eght", "Seven", "Six", "Five", "Four", "Three", "Two" };
            char[] suitCard = new char[] { '♦', '♥', '♣', '♠' };
            int[] valueCard = new int[] { 11, 4, 3, 2, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string nameCard = "";

            for (int i = 0; i < suitCard.Length; i++)
            {
                for (int j = 0; j < rankCard.Length; j++)
                {
                    nameCard = $"{rankCard[j]}-{suitCard[i]}";
                    _cards.Add(new Card(nameCard, valueCard[j]));
                }
            }

            Shuffle();
            
            return _cards;
        } // --

        public Card GiveCard()
        {
            int randomNumber;
            Random randomCard = new Random();
            randomNumber = randomCard.Next(_cards.Count);
            Card tempCard = _cards[randomNumber];
            _cards.Remove(_cards[randomNumber]);
            return tempCard;
        }

        private void Shuffle()
        {
            Card temporaryCard;
            Card temporaryCard2;
            int randNumber;
            Random randomCard = new Random();

            for (int i = 0; i < _cards.Count; i++)
            {
                randNumber = randomCard.Next(_cards.Count);
                temporaryCard = _cards[i];
                temporaryCard2 = _cards[randNumber];
                _cards[i] = temporaryCard2;
                _cards[randNumber] = temporaryCard;
            }
        } // ----
    }
}