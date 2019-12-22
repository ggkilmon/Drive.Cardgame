﻿using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class Distance : BaseCard, ICard
    {
        public Distance()
        {
            base.Score = 1;
        }

        public int Value { get; set; }

        public new int Score { get { return Value * base.Score; } }

        public bool CanPlayCard(List<ICard> cardsInPlay)
        {
            Distance cardPlayed = this;

            //cannot play a distance card without first playing roll
            if (!cardsInPlay.Any(c => c.GetName() == "Roll"))
            {
                return false;
            }

            //cannot play cards more than 50 when speed limit is present
            if (cardsInPlay.Any(c => c.GetName() == "Speed Limit"))
            {
                if (cardPlayed.Value > 50)
                {
                    return false;
                }
            }

            //cannot play more than 2 200 cards
            if (cardPlayed.GetName() == "200 km"
                && cardsInPlay.Where(c => c.GetName() == "200 km").Count() >= 2)
            {
                return false;
            }

            return true;
        }

        public void Init(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
