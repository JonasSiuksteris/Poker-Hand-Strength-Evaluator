using System;
using System.Collections.Generic;
using System.Linq;

namespace Video_Poker
{
    public static class HandEvaluation
    {
        public static int Evaluate(List<Card> cards)
        {
            cards = cards.OrderBy(c => c.CardNumber).ToList();

            if (RoyalFlush(cards))
                return 800;
            if (StraightFlush(cards))
                return 50;
            if (FourOfAKind(cards))
                return 25;
            if (FullHouse(cards))
                return 9;
            if (Flush(cards))
                return 6;
            if (Straight(cards))
                return 4;
            if (ThreeOfAKind(cards))
                return 3;
            if (TwoPair(cards))
                return 2;
            return JacksOrBetter(cards) ? 1 : 0;
        }

        private static bool JacksOrBetter(List<Card> cards)
        {
            return cards.Any(card => new[] { CardRank.Jack, CardRank.Queen, CardRank.King, CardRank.Ace }.Contains(card.CardNumber));
        }

        private static bool TwoPair(List<Card> cards)
        {
            return cards.GroupBy(c => c.CardNumber)
                       .Count(c => c.Count() == 2) == 2;
        }

        private static bool ThreeOfAKind(List<Card> cards)
        {
            return cards.GroupBy(c => c.CardNumber)
                       .Count(c => c.Count() == 3) == 1;
        }

        private static bool Straight(List<Card> cards)
        {
            for (var i = 1; i < cards.Count; i++)
            {
                if (i == 1 && cards.First().CardNumber == CardRank.Ace && cards.Last().CardNumber == CardRank.King) continue;
                if (cards[i].CardNumber - 1 != cards[i - 1].CardNumber)
                    return false;
            }

            return true;
        }

        private static bool Flush(List<Card> cards)
        {
            return cards.GroupBy(c => c.CardSuit)
                       .Count(c => c.Count() == 5) == 1;
        }

        private static bool FullHouse(List<Card> cards)
        {
            return cards.GroupBy(c => c.CardNumber)
                .All(c => c.Count() == 3 || c.Count() == 2);
            
        }

        private static bool FourOfAKind(List<Card> cards)
        {
            return cards.GroupBy(c => c.CardNumber)
                       .Count(c => c.Count() == 4) == 1;
        }

        private static bool StraightFlush(List<Card> cards)
        {
            return Straight(cards) && Flush(cards);
        }

        private static bool RoyalFlush(List<Card> cards)
        {
            return cards[0].CardNumber == CardRank.Ace && cards[1].CardNumber == CardRank.Ten && cards[2].CardNumber == CardRank.Jack
                   && cards[3].CardNumber == CardRank.Queen && cards[4].CardNumber == CardRank.King && Flush(cards);
        }
    }
}