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

        public void StartGame()
        {
            _currentPlayerIndex = 0;
            Deck = new Deck();

            DrawPile = Deck.BuildShuffledDeck();
            Players = InitPlayers();
            InitGame();
            DealToPlayers(Players, DrawPile, NUMBER_OF_CARDS_PER_HAND);

            CurrentPlayer = Players[_currentPlayerIndex % 2];
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

        public void PlayCard(ICard cardPlayed)
        {
            //can the card be played?
        }

        public void EndTurn()
        {
            CurrentPlayer = Players[_currentPlayerIndex++ % 2];
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

        
    }
}
