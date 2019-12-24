using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Distances
{
    public class TwoHundredKilometers : Distance
    {
        public TwoHundredKilometers()
        {
            Name = "200 km";
            Type = CardType.Distance.TwoHundredKilometers;
            Value = 200;
        }

        public override bool CanPlayCard(List<ICard> cardsInPlay)
        {
            bool canPlayBase = base.CanPlayCard(cardsInPlay);

            if (canPlayBase)
            {
                //cannot play more than 2 200 cards
                if (cardsInPlay.Where(c => c.GetCardType() == CardType.Distance.TwoHundredKilometers.ToString()).Count() >= 2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
