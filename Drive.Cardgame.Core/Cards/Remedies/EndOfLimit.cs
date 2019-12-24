using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Remedies
{
    public class EndOfLimit : Remedy
    {
        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {
                //can only play if there is a speed limit
                if (!cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.SpeedLimit.ToString()))
                {
                    return false;
                }
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

            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.SpeedLimit.ToString()))
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Hazard.SpeedLimit.ToString());
                cardsInPlay.Remove(card);
            }
        }
    }
}
