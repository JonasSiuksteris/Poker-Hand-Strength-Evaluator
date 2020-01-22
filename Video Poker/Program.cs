using System;
using System.Collections.Generic;

namespace Video_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var hand = new Hand();

            const int cardsInHand = 5;
            int option;
            var removedCards = 0;

            Console.WriteLine("Video Poker");
            Console.WriteLine();
            Console.WriteLine("Dealt hand:");

            hand.AddCards(deck.DrawCards(cardsInHand));
            hand.ShowHand();

            Console.WriteLine();
            Console.WriteLine("Do you want to replace cards?(1 - Yes 2 - No)");
            while (!int.TryParse(Console.ReadLine(), out option) || !(option == 1 || option == 2))
                Console.WriteLine("Try again");
            Console.WriteLine();

            while (option == 1 && hand.CardsCount() > 0)
            {
                int index;

                hand.ShowHand();
                Console.WriteLine();
                Console.WriteLine("Which card you want to replace?(From 1 to " + hand.CardsCount() + ")");
                while (!int.TryParse(Console.ReadLine(), out index) || !(index >= 1))
                    Console.WriteLine("Try again");
                Console.WriteLine();

                hand.DiscardCards(index - 1);
                removedCards++;

                if (hand.CardsCount() <= 0) continue;
                Console.WriteLine("Would you like to remove another card?(1 - Yes 2 - No)");
                while (!int.TryParse(Console.ReadLine(), out option) || !(option == 1 || option == 2))
                    Console.WriteLine("Try again");
                Console.WriteLine();
            }

            hand.AddCards(deck.DrawCards(removedCards));

            Console.WriteLine("Final hand: ");
            Console.WriteLine();
            hand.ShowHand();
            Console.WriteLine("You scored : " + HandEvaluation.Evaluate(hand.GetHand()));
        }
    }
}
