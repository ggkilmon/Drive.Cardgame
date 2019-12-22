using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class Safety : BaseCard, ICard
    {
        public bool IsCoupeForre { get; set; }
        public Enum Type { get; set; }

        public Safety()
        {
            IsCoupeForre = false;
            Score = 100;
        }

        public void Init(string name, int value, Enum type)
        {
            Name = name;
            Type = type;
        }

        public void CoupeFourre()
        {
            IsCoupeForre = true;
            Score += 300;
        }

        public bool CanPlayCard(List<ICard> cardsInPlay)
        {
            throw new NotImplementedException();
        }

        string ICard.GetCardType()
        {
            return Type.ToString();
        }

        public void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            throw new NotImplementedException();
        }
    }
}
