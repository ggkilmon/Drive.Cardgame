using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Remedies
{
    public class Gasoline : Remedy
    {
        public Gasoline()
        {
            Name = "Gasoline";
            Type = CardType.Remedy.Gasoline;
            Score = 0;
        }

        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {
                if (!cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.OutOfGas.ToString()))
                {
                    return false;
                }
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

            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.OutOfGas.ToString()))
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Hazard.OutOfGas.ToString());
                cardsInPlay.Remove(card);
            }
        }
    }
}
