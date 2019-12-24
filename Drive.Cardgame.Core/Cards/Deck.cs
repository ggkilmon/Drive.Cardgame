using Drive.Cardgame.Core.Cards.Distances;
using Drive.Cardgame.Core.Cards.Hazards;
using Drive.Cardgame.Core.Cards.Interfaces;
using Drive.Cardgame.Core.Cards.Remedies;
using Drive.Cardgame.Core.Cards.Safeties;
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

            cards.AddRange(InitCardInstances<Distance>(10, "25 km", 25, CardType.Distance.TwentyFiveKilometers));
            cards.AddRange(InitCardInstances<Distance>(10, "50 km", 50, CardType.Distance.FiftyKilometers));
            cards.AddRange(InitCardInstances<Distance>(10, "75 km", 75, CardType.Distance.SeventyFiveKilometers));
            cards.AddRange(InitCardInstances<Distance>(12, "100 km", 100, CardType.Distance.OneHundredKilometers));
            cards.AddRange(InitCardInstances<TwoHundredKilometers>(4));

            return cards.ToArray();
        }

        private ICard[] InitSafetyCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Safety>(1, "Driving Ace", 0, CardType.Safety.DrivingAce));
            cards.AddRange(InitCardInstances<Safety>(1, "Extra Tank", 0, CardType.Safety.ExtraTank));
            cards.AddRange(InitCardInstances<Safety>(1, "Puncture-proof", 0, CardType.Safety.PunctureProof));
            cards.AddRange(InitCardInstances<Safety>(1, "Right of Way", 0, CardType.Safety.RightOfWay));

            return cards.ToArray();
        }

        private ICard[] InitRemedyCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Repairs>(6));
            cards.AddRange(InitCardInstances<Gasoline>(6));
            cards.AddRange(InitCardInstances<Spare>(6));
            cards.AddRange(InitCardInstances<EndOfLimit>(6));
            cards.AddRange(InitCardInstances<Roll>(14));

            return cards.ToArray();
        }

        private ICard[] InitHazardCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Accident>(3));
            cards.AddRange(InitCardInstances<OutOfGas>(3));
            cards.AddRange(InitCardInstances<FlatTire>(3));
            cards.AddRange(InitCardInstances<SpeedLimit>(4));
            cards.AddRange(InitCardInstances<Stop>(5));

            return cards.ToArray();
        }

        private ICard[] InitCardInstances<T>(int numberOfCards, string name, int value, Enum type) where T : ICard, new()
        {
            List<ICard> cards = new List<ICard>();

            for (var i = 0; i < numberOfCards; i++)
            {
                T card = new T();
                card.Init(name, value, type);
                cards.Add(card);
            }

            return cards.ToArray();
        }

        private ICard[] InitCardInstances<T>(int numberOfCards) where T : ICard, new()
        {
            List<ICard> cards = new List<ICard>();

            for (var i = 0; i < numberOfCards; i++)
            {
                T card = new T();
                cards.Add(card);
            }

            return cards.ToArray();
        }
    }
}
