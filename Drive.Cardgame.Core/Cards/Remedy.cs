using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Remedy cardPlayed = this;

            if (Type.ToString() == CardType.Remedy.Roll.ToString())
            {
                //if there aren't any cards in play, its ok to play a roll
                if (cardsInPlay.Count() > 0)
                {
                    //if there is a roll already in play
                    if (cardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()))
                    {
                        return false;
                    }
                }                
            }

            return true;
        }

        public void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay)
        {
            Remedy cardPlayed = this;

            if (Type.ToString() == CardType.Remedy.Roll.ToString())
            {
                if (cardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.Stop.ToString()))
                {
                    var stop = cardsInPlay.FirstOrDefault(c => c.GetCardType() == CardType.Hazard.Stop.ToString());
                    cardsInPlay.Remove(stop);
                }
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
