using System;
using System.Collections.Generic;

namespace Video_Poker
{
    public class Card
    {
        public CardRank CardNumber { get; }
        public CardSuit CardSuit { get; }

        public Card(CardRank cardNumber, CardSuit cardSuit)
        {
            CardNumber = cardNumber;
            CardSuit = cardSuit;
        }

        public void PrintCard()
        {
            Console.WriteLine((CardRank) CardNumber + " of " + (CardSuit) CardSuit);
        }
    }
}