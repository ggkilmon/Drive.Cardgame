using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class FlatTire : Hazard
    {
        public FlatTire()
        {
            Name = "Flat Tire";
            Type = CardType.Hazard.FlatTire;
            Score = 0;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
        }
    }
}
