using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drive.Cardgame.Core.Cards.Hazards
{
    public class Hazard : BaseCard, ICard
    {
        public Enum Type { get; set; }

        public Hazard()
        {
            Score = 0;
        }

        public virtual bool CanPlayCard(List<ICard> cardsInPlay)
        {
            if (!cardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString())   //need to be moving to play hazard 
                && this.Type.ToString() != CardType.Hazard.SpeedLimit.ToString())           //except for speed limit
            {
                return false;
            }

            return true;
        }

        public void Init(string name, int value, Enum type)
        {
            Name = name;
            Type = type;
        }

        string ICard.GetCardType()
        {
            return Type.ToString();
        }

        public virtual void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString())    //remove roll
                && this.Type.ToString() != CardType.Hazard.SpeedLimit.ToString())           //except when speed limit
            {
                var card = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Remedy.Roll.ToString());
                cardsInPlay.Remove(card);
            }
        }
    }
}
