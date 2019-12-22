using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;

namespace Drive.Cardgame.Core.Cards
{
    public class Hazard : BaseCard, ICard
    {
        public Hazard()
        {
            Score = 0;
        }

        public bool CanPlayCard(List<ICard> cardsInPlay)
        {
            throw new NotImplementedException();
        }

        public void Init(string name, int value)
        {
            Name = name;
        }
    }
}
