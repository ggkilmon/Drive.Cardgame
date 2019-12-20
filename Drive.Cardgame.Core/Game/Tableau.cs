using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Game
{
    public class Tableau
    {
        public Tableau()
        {
            CardsInPlay = new List<ICard>();
        }

        public List<ICard> CardsInPlay { get; set; }
    }
}
