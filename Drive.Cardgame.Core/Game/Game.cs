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
            Deck deck = new Deck();

            DrawPile = deck.BuildShuffledDeck();
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
