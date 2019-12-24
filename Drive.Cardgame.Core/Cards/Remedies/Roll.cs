using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Remedies
{
    public class Roll : Remedy
    {
        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {
                //if there aren't any cards in play, its ok to play a roll
                if (cardsInPlay.Count() > 0)
                {
                    //if there is a roll already in play
                    if (cardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            base.RemoveAffectedCardsFromPlay(cardsInPlay);
            
            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.Stop.ToString()))
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Hazard.Stop.ToString());
                cardsInPlay.Remove(card);
            }
        }
    }
}
