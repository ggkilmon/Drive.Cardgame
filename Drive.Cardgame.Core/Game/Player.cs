using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Game
{
    public class Player
    {
        public string Name { get; set; }
        public Tableau Board { get; set; }
        public List<ICard> CardsInHand { get; set; }
        public int TotalDistance { get; set; }

        public Player(string name)
        {
            Board = new Tableau();
            Name = name;
            CardsInHand = new List<ICard>();
        }

        public ICard RemoveCardFromHand(ICard cardToPlay)
        {
            var card = CardsInHand.FirstOrDefault(c => c.GetType() == cardToPlay.GetType());
            if (card != null)
            {
                CardsInHand.Remove(card);
                return card;
            }

            return null;
        }
    }
}
