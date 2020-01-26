using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_Poker;

namespace VideoPoker.UnitTests
{
    [TestClass]
    public class HandEvaluationTests
    {
        [TestMethod]
        public void Evaluate_RoyalFlush_Returns800()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.King, CardSuit.Clubs),
                new Card(CardRank.Ten, CardSuit.Clubs),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Queen, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Clubs)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(800, result);
        }

        [TestMethod]
        public void Evaluate_StraightFlush_Returns50()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Six, CardSuit.Diamonds),
                new Card(CardRank.Eight, CardSuit.Diamonds),
                new Card(CardRank.Ten, CardSuit.Diamonds),
                new Card(CardRank.Seven, CardSuit.Diamonds),
                new Card(CardRank.Nine, CardSuit.Diamonds)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Evaluate_FourOfAKind_Returns25()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Jack, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.Jack, CardSuit.Hearts),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Nine, CardSuit.Diamonds)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void Evaluate_FullHouse_Returns9()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Seven, CardSuit.Diamonds),
                new Card(CardRank.Seven, CardSuit.Spades),
                new Card(CardRank.Seven, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Evaluate_Flush_Returns6()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.Five, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Jack, CardSuit.Diamonds),
                new Card(CardRank.Nine, CardSuit.Diamonds)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Evaluate_Straight_Returns4()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Five, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Diamonds),
                new Card(CardRank.Three, CardSuit.Hearts)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Evaluate_ThreeOfAKind_Returns3()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Seven, CardSuit.Spades),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Seven, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Diamonds),
                new Card(CardRank.Three, CardSuit.Hearts)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Evaluate_TwoPair_Returns2()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Seven, CardSuit.Spades),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.King, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Diamonds),
                new Card(CardRank.Three, CardSuit.Hearts)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Evaluate_JacksOrBetter_Returns1()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Jack, CardSuit.Spades),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Five, CardSuit.Diamonds),
                new Card(CardRank.Ten, CardSuit.Hearts)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Evaluate_Nothing_Returns0()
        {
            var hand = new List<Card>
            {
                new Card(CardRank.Three, CardSuit.Spades),
                new Card(CardRank.Seven, CardSuit.Clubs),
                new Card(CardRank.Two, CardSuit.Spades),
                new Card(CardRank.Five, CardSuit.Diamonds),
                new Card(CardRank.Ten, CardSuit.Hearts)
            };

            var result = HandEvaluation.Evaluate(hand);

            Assert.AreEqual(0, result);
        }
    }
}
