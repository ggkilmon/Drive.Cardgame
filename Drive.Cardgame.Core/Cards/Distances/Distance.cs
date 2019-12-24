using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Distances
{
    public class Distance : BaseCard, ICard
    {
        public Distance()
        {
            base.Score = 1;
            
        }

        public int Value { get; set; }
        public Enum Type { get;set; }

        public new int Score { get { return Value * base.Score; } }

        public virtual bool CanPlayCard(List<ICard> cardsInPlay)
        {
            Distance cardPlayed = this;

            //cannot play a distance card without first playing roll
            if (!cardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()))
            {
                return false;
            }

            //cannot play cards more than 50 when speed limit is present
            if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.SpeedLimit.ToString()))
            {
                if (cardPlayed.Value > 50)
                {
                    return false;
                }
            }

            return true;
        }

        public void Init(string name, int value, Enum type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            //don't need to remove cards from play
        }

        string ICard.GetCardType()
        {
            return this.Type.ToString();
        }
    }
}
