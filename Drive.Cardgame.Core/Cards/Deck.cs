using Drive.Cardgame.Core.Cards.Interfaces;
using Drive.Cardgame.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class Deck
    {
        public Stack<ICard> BuildShuffledDeck()
        {
            ICard[] cards = BuildDeck();
            ICard[] shuffledDeck = Shuffle(cards);
            return shuffledDeck.ToStack();
        }

        public ICard[] BuildDeck()
        {
            List<ICard> cards = new List<ICard>();
            cards.AddRange(InitDistanceCards());
            cards.AddRange(InitSafetyCards());
            cards.AddRange(InitRemedyCards());
            cards.AddRange(InitHazardCards());

            return cards.ToArray();
        }

        public ICard[] Shuffle(ICard[] deck)
        {
            ICard[] shuffledDeck = new ICard[deck.Length];
            deck.CopyTo(shuffledDeck, 0);
            var rng = new Random();
            int n = shuffledDeck.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                ICard temp = shuffledDeck[n];
                shuffledDeck[n] = shuffledDeck[k];
                shuffledDeck[k] = temp;
            }

            return shuffledDeck;
        }

        public ICard DrawCard(Stack<ICard> deck)
        {
            return deck.Pop();
        }

        private ICard[] InitDistanceCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Distance>(10, "25 km", 25));
            cards.AddRange(InitCardInstances<Distance>(10, "50 km", 50));
            cards.AddRange(InitCardInstances<Distance>(10, "75 km", 75));
            cards.AddRange(InitCardInstances<Distance>(12, "100 km", 100));
            cards.AddRange(InitCardInstances<Distance>(4, "200 km", 200));

            return cards.ToArray();
        }

        private ICard[] InitSafetyCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Safety>(1, "Driving Ace", 0));
            cards.AddRange(InitCardInstances<Safety>(1, "Extra Tank", 0));
            cards.AddRange(InitCardInstances<Safety>(1, "Puncture-proof", 0));
            cards.AddRange(InitCardInstances<Safety>(1, "Right of Way", 0));

            return cards.ToArray();
        }

        private ICard[] InitRemedyCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Remedy>(6, "Repairs", 0));
            cards.AddRange(InitCardInstances<Remedy>(6, "Gasoline", 0));
            cards.AddRange(InitCardInstances<Remedy>(6, "Spare", 0));
            cards.AddRange(InitCardInstances<Remedy>(6, "End of Limit", 0));
            cards.AddRange(InitCardInstances<Remedy>(14, "Roll", 0));

            return cards.ToArray();
        }

        private ICard[] InitHazardCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Remedy>(3, "Accident", 0));
            cards.AddRange(InitCardInstances<Remedy>(3, "Out of Gas", 0));
            cards.AddRange(InitCardInstances<Remedy>(3, "Flat Tire", 0));
            cards.AddRange(InitCardInstances<Remedy>(4, "Speed Limit", 0));
            cards.AddRange(InitCardInstances<Remedy>(5, "Stop", 0));

            return cards.ToArray();
        }

        private ICard[] InitCardInstances<T>(int numberOfCards, string name, int value) where T : ICard, new()
        {
            List<ICard> cards = new List<ICard>();

            for (var i = 0; i < numberOfCards; i++)
            {
                T card = new T();
                card.Init(name, value);
                cards.Add(card);
            }

            return cards.ToArray();
        }
    }
}
