using System;
using System.Collections.Generic;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class SpeedLimit : Hazard
    {
        public SpeedLimit()
        {
            Name = "Speed Limit";
            Type = CardType.Hazard.SpeedLimit;
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
                return false;
            }

            return true;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
        }
    }
}
