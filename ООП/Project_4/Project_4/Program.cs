using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string namePlayer;

            Console.Write("Введите имя игрока - ");

            namePlayer = Console.ReadLine();
            Player player = new Player(namePlayer);

            Game game = new Game();
            game.Play(player);
        }
    }

    class Game
    {
        private Deck _deck = new Deck();
        private List<Card> deck = new List<Card>();

        public void Play(Player player)
        {
            const string da = "1";
            const string no = "2";
            bool isGameOver = true;
            _deck.DeckBuilding(deck);

            while (isGameOver)
            {
                if (deck.Count == 0)
                {
                    player.GiveCard(_deck.TakeCard(deck));
                    player.ShowCards();
                    Console.WriteLine(player.ShowScore());

                }
                else
                {
                    Console.WriteLine("карту?");
                    Console.WriteLine($"{da}. да ");
                    Console.WriteLine($"{no}. нет ");

                    string command = Console.ReadLine();
                    Console.Clear();

                    switch (command.ToLower())
                    {
                        case da:
                            isGameOver = PrintGame(player);
                            break;

                        case no:
                            isGameOver = false;
                            break;
                    }
                }
            }

            Console.WriteLine("конец");
            Console.ReadKey();
        }

        public bool PrintGame(Player player)
        {
            const int MaxScore = 21;

            player.GiveCard(_deck.TakeCard(deck));
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

        public void GiveCard(Card newCard)
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
        private string[] _rankCard = new string[] { "Ace", "King", "Queen", "Jack", "Ten", "Nine", "Eght", "Seven", "Six", "Five", "Four", "Three", "Two" };
        private char[] _suitCard = new char[] { '♦', '♥', '♣', '♠' };
        private int[] _valueCard = new int[] { 11, 4, 3, 2, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public void DeckBuilding(List<Card> deck)
        {
            const int MaxCards = 52;

            int numberCardRank;
            int numberCardSuit;
            int valueCard = 0;
            string nameCard = "";
            bool isRepick;

            Random randomNumber = new Random();

            for(int i = 0; i < MaxCards; i++)
            {
                isRepick = true;

                while (isRepick)
                {
                    numberCardRank = randomNumber.Next(13);
                    numberCardSuit = randomNumber.Next(4);
                    valueCard = _valueCard[numberCardRank];
                    nameCard = ($"{_rankCard[numberCardRank]}-{_suitCard[numberCardSuit]}");

                    if (deck.Count == 0)
                    {
                        isRepick = false;
                    }
                    else
                    {
                        isRepick = false;

                        foreach (Card card in deck)
                        {
                            if (nameCard == card.Name)
                            {
                                isRepick = true;
                            }
                        }
                    }
                }

                deck.Add(new Card(nameCard,valueCard));
            }
        }

        public Card TakeCard(List<Card> deck)
        {
            Random randomCard = new Random();

            return deck[randomCard.Next(deck.Count)];
        }

        public void ShowDeck(List<Card> deck)
        {
            foreach (Card card in deck)
            {
                Console.WriteLine($"{card.Name} - {card.Value}");
            }
        }
    }
}