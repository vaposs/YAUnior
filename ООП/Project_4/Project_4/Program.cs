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
        private List<Card> _allDeck = new List<Card>();

        public void Play(Player player)
        {
            const string nextCard = "1";
            const string stopGame = "2";
            bool isNotGameOver = true;
            _deck.Building(_allDeck);
            _deck.Shuffle(_allDeck);

            while (isNotGameOver)
            {
                if (_allDeck.Count == 0)
                {
                    player.GiveCard(_deck.TakeCard(_allDeck));
                    player.ShowCards();
                    Console.WriteLine(player.ShowScore());
                }
                else
                {
                    Console.WriteLine("карту?");
                    Console.WriteLine($"{nextCard}. да ");
                    Console.WriteLine($"{stopGame}. нет ");

                    string command = Console.ReadLine();
                    Console.Clear();

                    switch (command.ToLower())
                    {
                        case nextCard:
                            isNotGameOver = NextRound(player);
                            break;

                        case stopGame:
                            isNotGameOver = false;
                            break;
                    }
                }
            }

            Console.WriteLine("конец");
            Console.ReadKey();
        }

        public bool NextRound(Player player)
        {
            const int MaxScore = 21;

            player.GiveCard(_deck.TakeCard(_allDeck));
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
                    deck.Add(new Card(nameCard,valueCard[j]));
                }
            }
        }

        public void Shuffle(List<Card> cards)
        {
            Card temporaryCard;
            Card temporaryCard2;
            int randNumber;
            Random randomCard = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                randNumber = randomCard.Next(cards.Count);
                temporaryCard = cards[i];
                temporaryCard2 = cards[randNumber];
                cards[i] = temporaryCard2;
                cards[randNumber] = temporaryCard;
            }
        }

        public Card TakeCard(List<Card> deck)
        {
            int randomNumber;
            Random randomCard = new Random();
            randomNumber = randomCard.Next(deck.Count);
            Card tempCard = deck[randomNumber];
            deck.RemoveAt(randomNumber);
            return tempCard;
        }

        public void Show(List<Card> deck)
        {
            int number = 1;

            foreach (Card card in deck)
            {
                Console.WriteLine($"{number++}. {card.Name} - {card.Value}");
            }
        }
    }
}