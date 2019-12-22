using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class Remedy : BaseCard, ICard
    {
        public Remedy()
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
