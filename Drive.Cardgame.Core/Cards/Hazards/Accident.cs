using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class Accident : Hazard
    {
        public Accident()
        {
            Name = "Accident";
            Type = CardType.Hazard.Accident;
            Score = 0;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
        }
    }
}
