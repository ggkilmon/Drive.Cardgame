using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive.Cardgame.Core.Cards.Interfaces;

namespace Drive.Cardgame.Core.Cards.Remedies
{
    public class Spare : Remedy
    {
        public Spare()
        {
            Name = "Spare";
            Type = CardType.Remedy.Spare;
            Score = 0;
        }

        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {
                if (!cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.FlatTire.ToString()))
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

            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.FlatTire.ToString()))
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Hazard.FlatTire.ToString());
                cardsInPlay.Remove(card);
            }
        }
    }
}
