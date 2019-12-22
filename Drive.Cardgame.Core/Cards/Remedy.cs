using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class Remedy : BaseCard, ICard
    {
        public Enum Type { get; set; }

        public Remedy()
        {
            Score = 0;
        }

        public bool CanPlayCard(List<ICard> cardsInPlay)
        {
            throw new NotImplementedException();
        }

        public void Init(string name, int value, Enum type)
        {
            Name = name;
        }

        string ICard.GetCardType()
        {
            return Type.ToString();
        }
    }
}
