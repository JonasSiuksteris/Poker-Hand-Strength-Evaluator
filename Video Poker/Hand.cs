using System.Collections.Generic;

namespace Video_Poker
{
    public class Hand
    {
        private readonly List<Card> _hand = new List<Card>();

        public void AddCards(Card card)
        {
            _hand.Add(card);
        }

        public void AddCards(List<Card> card)
        {
            _hand.AddRange(card);
        }

        public void ShowHand()
        {
            foreach (var card in _hand)
            {
                card.PrintCard();
            }
        }

        public int CardsCount()
        {
            return _hand.Count;
        }

        public void DiscardCards(int index)
        {
            _hand.RemoveAt(index);
        }

        public List<Card> GetHand()
        {
            return _hand;
        }
        
    }
}