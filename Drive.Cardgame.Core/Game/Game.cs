using Drive.Cardgame.Core.Cards;
using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Game
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Stack<ICard> DrawPile { get; set; }
        public Stack<ICard> DiscardPile { get; set; }
        public const int NUMBER_OF_CARDS_PER_HAND = 6;

        public void StartGame()
        {
            DrawPile = InitDeck();
            Players = InitPlayers();
            DealToPlayers(Players, DrawPile, NUMBER_OF_CARDS_PER_HAND);
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

        public Stack<ICard> InitDeck()
        {
            List<ICard> cards = new List<ICard>();
            cards.AddRange(InitDistanceCards());
            cards.AddRange(InitSafetyCards());
            cards.AddRange(InitRemedyCards());
            cards.AddRange(InitHazardCards());

            ICard[] shuffledDeck = Shuffle(cards.ToArray());

            Stack<ICard> convertedDeck = new Stack<ICard>();
            for(var i = shuffledDeck.Length - 1; i >= 0; i--)
            {
                convertedDeck.Push(shuffledDeck[i]);
            }

            return convertedDeck;
        }

        public Player[] InitPlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));

            return players.ToArray();
        }

        public void DealToPlayers(Player[] players, Stack<ICard> deck, int numberOfCardsToDeal)
        {
            for (var i = 0; i < numberOfCardsToDeal; i++)
            {
                foreach (var player in players)
                {
                    player.CardsInHand.Add(deck.Pop());
                }
            }
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
