using System;
using System.Collections.Generic;
using System.Linq;

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
        private const int MaxScore = 21;
        private const string NextCard = "1";
        private const string StopGame = "2";

        private Deck _deck;
        private Player _player;
        private Dictionary<string, int> _cardValues;

        public Game()
        {
            _deck = new Deck();
            InitializeCardValues();
        }

        public void Play()
        {
            Console.Write("Введите имя игрока - ");
            string playerName = Console.ReadLine();
            _player = new Player(playerName);

            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("Взять карту?");
                Console.WriteLine($"{NextCard}. да");
                Console.WriteLine($"{StopGame}. нет");

                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case NextCard:
                        isPlaying = PlayNextRound();
                        break;

                    case StopGame:
                        isPlaying = false;
                        break;
                }
            }

            Console.WriteLine("Игра окончена");
            ShowFinalResult();
            Console.ReadKey();
        }

        private bool PlayNextRound()
        {
            Card card = _deck.DrawCard();

            if (card == null)
            {
                Console.WriteLine("В колоде закончились карты!");
                return false;
            }

            _player.TakeCard(card);
            ShowCurrentState();

            int currentScore = _player.GetScore(_cardValues);

            if (currentScore > MaxScore)
            {
                Console.WriteLine($"Перебор! Ваш счет: {currentScore}");
                return false;
            }

            return true;
        }

        private void ShowCurrentState()
        {
            Console.WriteLine($"Карты игрока {_player.Name}:");
            _player.ShowCards();
            Console.WriteLine($"Текущий счет: {_player.GetScore(_cardValues)}");
            Console.WriteLine();
        }

        private void ShowFinalResult()
        {
            int finalScore = _player.GetScore(_cardValues);
            Console.WriteLine($"Итоговый счет игрока {_player.Name}: {finalScore}");
            Console.WriteLine("Ваши карты:");
            _player.ShowCards();
        }

        private void InitializeCardValues()
        {
            _cardValues = new Dictionary<string, int>
            {
                ["Ace"] = 11,
                ["King"] = 4,
                ["Queen"] = 3,
                ["Jack"] = 2,
                ["Ten"] = 10,
                ["Nine"] = 9,
                ["Eight"] = 8,
                ["Seven"] = 7,
                ["Six"] = 6,
                ["Five"] = 5,
                ["Four"] = 4,
                ["Three"] = 3,
                ["Two"] = 2
            };
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void TakeCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowCards()
        {
            foreach (Card card in _hand)
            {
                Console.WriteLine(card);
            }
        }

        public int GetScore(Dictionary<string, int> cardValues)
        {
            int score = 0;

            foreach (Card card in _hand)
            {
                if (cardValues.ContainsKey(card.Rank))
                {
                    score += cardValues[card.Rank];
                }
            }

            return score;
        }
    }

    class Card
    {
        public Card(string rank, char suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public string Rank { get; }
        public char Suit { get; }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private Random _random = new Random();

        public Deck()
        {
            CreateDeck();
            Shuffle();
        }

        private void CreateDeck()
        {
            string[] ranks = { "Ace", "King", "Queen", "Jack", "Ten", "Nine",
                              "Eight", "Seven", "Six", "Five", "Four", "Three", "Two" };
            char[] suits = { '♦', '♥', '♣', '♠' };

            foreach (char suit in suits)
            {
                foreach (string rank in ranks)
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
        }

        public Card DrawCard()
        {
            if (_cards.Count == 0)
                return null;

            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        private void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int randomIndex = _random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }
        }
    }
}
