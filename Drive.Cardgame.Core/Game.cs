using Drive.Cardgame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core
{
    public class Game
    {
        public object[] Players { get; set; }
        public ICard[] DrawPile { get; set; }
        public ICard[] DiscardPile { get; set; }

        public void StartGame()
        {
            DrawPile = InitDeck();
            DrawPile = InitDeck();
            DrawPile = InitDeck();
            DrawPile = InitDeck();
            //shuffle deck and populate drawpile
            //make sure enough players are created
        }

        public void Turn()
        {
            //check win state
            //draw card - player
            //play card - 
            //if played card is safety, draw again
            //check to see if player has 6 cards in his hand
                //its ok if player has less cards, as long as draw pile is empty
        }

        public ICard[] InitDeck()
        {
            List<ICard> cards = new List<ICard>();
            cards.AddRange(InitDistanceCards());
            cards.AddRange(InitSafetyCards());
            cards.AddRange(InitRemedyCards());
            cards.AddRange(InitHazardCards());

            return Shuffle(cards.ToArray());
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

        public ICard[] Shuffle(ICard[] deck)
        {
            var rng = new Random();
            int n = deck.Length;
            while(n > 1)
            {
                int k = rng.Next(n--);
                ICard temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }

            return deck;
        }
    }
}
