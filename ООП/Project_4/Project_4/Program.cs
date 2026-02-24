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
        private Deck _deck = new Deck();
        private List<Card> _mainDeck;
        private string _namePlayer;
        private Dictionary<string, int> _cardValues;

        public Game()
        {
            InitializeCardValues();
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

        public void Play()
        {
            const string NextCard = "1";
            const string StopGame = "2";

            Console.Write("Введите имя игрока - ");
            _namePlayer = Console.ReadLine();
            Player player = new Player(_namePlayer);

            bool isNotGameOver = true;
            _mainDeck = _deck.BuildDeck(_cardValues);

            while (isNotGameOver)
            {
                if (_mainDeck.Count == 0)
                {
                    player.TakeCard(_deck.GiveCard());
                    player.ShowCards();
                    Console.WriteLine(player.ShowScore(_cardValues));
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

            if (player.ShowScore(_cardValues) > MaxScore)
            {
                Console.WriteLine($"перебор");
                Console.WriteLine(player.ShowScore(_cardValues));
                return false;
            }
            else
            {
                Console.WriteLine(player.ShowScore(_cardValues));
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

        public int ShowScore(Dictionary<string, int> cardValues)
        {
            int score = 0;

            foreach (Card card in _cardsInHand)
            {
                string rank = card.Name.Split('-')[0];
                if (cardValues.ContainsKey(rank))
                {
                    score += cardValues[rank];
                }
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
        public Card(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> BuildDeck(Dictionary<string, int> cardValues)
        {
            _cards.Clear();

            string[] rankCard = new string[] { "Ace", "King", "Queen", "Jack", "Ten", "Nine", "Eight", "Seven", "Six", "Five", "Four", "Three", "Two" };
            char[] suitCard = new char[] { '♦', '♥', '♣', '♠' };
            string nameCard = "";

            for (int i = 0; i < suitCard.Length; i++)
            {
                for (int j = 0; j < rankCard.Length; j++)
                {
                    if (cardValues.ContainsKey(rankCard[j]))
                    {
                        nameCard = $"{rankCard[j]}-{suitCard[i]}";
                        _cards.Add(new Card(nameCard));
                    }
                }
            }

            Shuffle();

            return _cards.ToList();
        }

        public Card GiveCard()
        {
            if (_cards.Count == 0)
                return null;

            Card tempCard = _cards[0];
            _cards.RemoveAt(0);
            return tempCard;
        }

        private void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int randomNumber = random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[randomNumber];
                _cards[randomNumber] = temp;
            }
        }
    }
}
