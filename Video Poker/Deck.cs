using System;
using System.Collections.Generic;
using System.Linq;

namespace Video_Poker
{
    public class Deck
    {
        private Queue<Card> _deck = new Queue<Card>();
        private const int MaxCardRank = 13;
        private const int MaxCardColor = 4;

        public Deck()
        {
            foreach (CardRank cardRank in Enum.GetValues(typeof(CardRank)))
            {
                foreach (CardSuit cardSuit in Enum.GetValues(typeof(CardSuit)))
                {
                    _deck.Enqueue(new Card(cardRank, cardSuit));
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            var rand = new Random();
            _deck = new Queue<Card>(_deck.OrderBy(a => rand.Next()));
        }

        public List<Card> DrawCards(int number)
        {
            return Enumerable.Range(0, number).Select(i => _deck.Dequeue()).ToList();
        }
    }
}