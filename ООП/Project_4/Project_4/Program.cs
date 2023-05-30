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
            int numberCard;
            int valueCard;
            string nameCard;

            Random randomCard = new Random();
            numberCard = randomCard.Next() % deck.Count;
            deck.TryGetValue(numberCard,out nameCard);
            string[] templeString = nameCard.Split('-');
            card.TryGetValue(templeString[0], out valueCard);

            return new Card(nameCard, valueCard);
        }
    }
}

/*

            // беру карту
            // рисую карту
            // считаю очки карты


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

/* создать колоду карт ---------------------------------------------------------
 * создать выбор количеста игроков за столом
 * создать добавления карт ботам
 * создать подбор карт игроку
 * создать логическую концовку игры
  
 -------------------- розделения имени


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
