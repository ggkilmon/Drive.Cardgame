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
            cards.AddRange(InitCardInstances<TwoHundredKilometers>(4, "200 km", 200, CardType.Distance.TwoHundredKilometers));

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

            cards.AddRange(InitCardInstances<Remedy>(6, "Repairs", 0, CardType.Remedy.Repairs));
            cards.AddRange(InitCardInstances<Remedy>(6, "Gasoline", 0, CardType.Remedy.Gasoline));
            cards.AddRange(InitCardInstances<Spare>(6, "Spare", 0, CardType.Remedy.Spare));
            cards.AddRange(InitCardInstances<EndOfLimit>(6, "End of Limit", 0, CardType.Remedy.EndOfLimit));
            cards.AddRange(InitCardInstances<Roll>(14, "Roll", 0, CardType.Remedy.Roll));

            return cards.ToArray();
        }

        private ICard[] InitHazardCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.AddRange(InitCardInstances<Accident>(3, "Accident", 0, CardType.Hazard.Accident));
            cards.AddRange(InitCardInstances<OutOfGas>(3, "Out of Gas", 0, CardType.Hazard.OutOfGas));
            cards.AddRange(InitCardInstances<FlatTire>(3, "Flat Tire", 0, CardType.Hazard.FlatTire));
            cards.AddRange(InitCardInstances<SpeedLimit>(4, "Speed Limit", 0, CardType.Hazard.SpeedLimit));
            cards.AddRange(InitCardInstances<Hazard>(5, "Stop", 0, CardType.Hazard.Stop));

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
    }
}
