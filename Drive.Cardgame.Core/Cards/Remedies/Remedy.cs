using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Remedies
{
    public class Remedy : BaseCard, ICard
    {
        public Enum Type { get; set; }

        public Remedy()
        {
            Score = 0;
        }

        public virtual bool CanPlayCard(List<ICard> cardsInPlay)
        {
            return true;
        }

        public virtual void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            Remedy cardPlayed = this;

            if (cardsInPlay.Any(c => c.GetCardType() == this.Type.ToString())   //remedies get removed
                && this.Type.ToString() != CardType.Remedy.Roll.ToString())     //except rolls stay in play
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == this.Type.ToString());
                cardsInPlay.Remove(card);
            }
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
