using System;
using System.Collections.Generic;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        private string Suit { get; set; }
        private string Rank { get; set; }

        public int ValueCard(string suit)
        {
            bool value = false;
            int values = 0;

            Dictionary<string, int> card = new Dictionary<string, int>()
            {
                { "Ace",11},
                { "King",4},
                { "Queen",3},
                { "Jack",2},
                {"Ten",10},
                { "nine",9},
                { "eght",8},
                { "seven",7},
                { "six",6},
                { "five",5},
                { "four",4},
                { "three",3},
                { "two",2}
            };

            value = card.TryGetValue(suit, out values);

            return values;
        }
    }

    class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        private string Name { get; set; }
    }

    class Deck
    {

    }
}

/*
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
Joker(Джокер)

*/


//Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт (может быть как выбор пользователя, 
//так и количество сколько карт надо взять). После выводиться вся информация о вытянутых картах.
//Возможные классы: Карта, Колода, Игрок.
