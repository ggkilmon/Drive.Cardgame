using System;
using System.Collections.Generic;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class Stop : Hazard
    {
        public Stop()
        {
            Name = "Stop";
            Type = CardType.Hazard.Stop;
            Score = 0;
        }

        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {

            }
            else
            {
                return canPlayBase;
            }

            return true;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
        }
    }
}
