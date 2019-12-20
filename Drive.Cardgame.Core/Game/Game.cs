using Drive.Cardgame.Core.Cards;
using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Game
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public Stack<ICard> DrawPile { get; set; }
        public Stack<ICard> DiscardPile { get; set; }
        public Deck Deck { get; set; }
        public const int NUMBER_OF_CARDS_PER_HAND = 6;
        private int _endGameDistance;
        private int _currentPlayerIndex;
        private int _numberOfPlayers;

        public void StartGame(int numberOfPlayers = 2)
        {
            _currentPlayerIndex = 0;
            _numberOfPlayers = numberOfPlayers;
            Deck = new Deck();

            DrawPile = Deck.BuildShuffledDeck();
            Players = InitPlayers(_numberOfPlayers);
            InitGame();
            DealToPlayers(Players, DrawPile, NUMBER_OF_CARDS_PER_HAND);

            CurrentPlayer = Players[_currentPlayerIndex % _numberOfPlayers];
        }

        public void PlayGame()
        {
            
        }

        public void StartTurn()
        {
            if (!IsEndOfGame())
            {
                ICard drawnCard = Deck.DrawCard(DrawPile);
                CurrentPlayer.CardsInHand.Add(drawnCard);
            }
            //check win state
            //draw card - player
            //play card - 
            //if played card is safety, draw again
            //check to see if player has 6 cards in his hand
                //its ok if player has less cards, as long as draw pile is empty
        }

        public bool PlayCard(Player player, ICard cardPlayed)
        {
            var cardsInPlay = player.Board.CardsInPlay;
            bool canPlayDistance = CanPlayDistanceCard(cardsInPlay, cardPlayed);
            bool canPlaySafety = false;
            bool canPlayRemedy = false;
            bool canPlayHazard = false;

            if (canPlayDistance 
                || canPlaySafety
                || canPlayRemedy
                || canPlayHazard) {
                cardsInPlay.Add(cardPlayed);
                return true;
            }

            return false;
        }

        public void EndTurn()
        {
            CurrentPlayer = Players[_currentPlayerIndex++ % _numberOfPlayers];
        }

        public bool IsEndOfGame()
        {
            return 
                CurrentPlayer.TotalDistance == _endGameDistance
                || !Players.Any(p => p.CardsInHand.Count() > 0);
        }

        public void InitGame()
        {
            _endGameDistance = Players.Length < 4 ? 700 : 1000;
        }

        public Player[] InitPlayers(int count = 2)
        {
            List<Player> players = new List<Player>();
            for (var i = 0; i < count; i++)
            {
                players.Add(new Player($"Player {i + 1}"));
            }

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

        public bool CanPlayDistanceCard(List<ICard> cardsInPlay, ICard cardPlayed)
        {
            if (cardPlayed is Distance)
            {
                //cannot play a distance card without first playing roll
                if (!cardsInPlay.Any(c => c.GetName() == "Roll"))
                {
                    return false;
                }

                //cannot play cards more than 50 when speed limit is present
                if (cardsInPlay.Any(c => c.GetName() == "Speed Limit"))
                {
                    if ((cardPlayed as Distance).Value > 50)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
