using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class OutOfGas : Hazard
    {
        public OutOfGas()
        {
            Name = "Out of Gas";
            Type = CardType.Hazard.OutOfGas;
            Score = 0;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
        }
    }
}
