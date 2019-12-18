using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Game
{
    public class Player
    {
        public string Name { get; set; }
        public List<ICard> CardsInHand { get; set; }
        public int TotalDistance { get; set; }

        public Player(string name)
        {
            Name = name;
            CardsInHand = new List<ICard>();
        }
    }
}
