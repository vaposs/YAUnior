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
        private List<Card> _allDeck = new List<Card>();
        private string namePlayer;

        public void Play()
        {
            Console.Write("Введите имя игрока - ");
            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer);

            const string NextCard = "1";
            const string StopGame = "2";

            bool isNotGameOver = true;
            _deck.Building(_allDeck);
            _deck.Shuffle(_allDeck);

            while (isNotGameOver)
            {
                if (_allDeck.Count == 0)
                {
                    player.TakeCard(_deck.GiveCard(_allDeck));
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

        public bool PlayNextRound(Player player)
        {
            const int MaxScore = 21;

            player.TakeCard(_deck.GiveCard(_allDeck));
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
        }

        public int ShowScore()
        {
            int score = 0;

            foreach (Card card in _cardsInHand)
            {
                score += card.Value;
            }

            return score;
        }

        public void TakeCard(Card newCard)
        {
            _cardsInHand.Add(newCard);
        }
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
    }

    class Deck
    {
        private List<Card> localDeck = new List<Card>();

        public void Building(List<Card> deck)
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
                    localDeck.Add(new Card(nameCard, valueCard[j]));
                }
            }

            deck = localDeck;
        }

        public void Shuffle(List<Card> cards)
        {
            Card temporaryCard;
            Card temporaryCard2;
            int randNumber;
            Random randomCard = new Random();
            localDeck = cards;

            for (int i = 0; i < localDeck.Count; i++)
            {
                randNumber = randomCard.Next(localDeck.Count);
                temporaryCard = localDeck[i];
                temporaryCard2 = localDeck[randNumber];
                localDeck[i] = temporaryCard2;
                localDeck[randNumber] = temporaryCard;
            }

            cards = localDeck;
        }

        public Card GiveCard(List<Card> deck)
        {
            int randomNumber;
            Random randomCard = new Random();
            randomNumber = randomCard.Next(deck.Count);
            Card tempCard = deck[randomNumber];
            deck.RemoveAt(randomNumber);
            return tempCard;
        }
    }
}