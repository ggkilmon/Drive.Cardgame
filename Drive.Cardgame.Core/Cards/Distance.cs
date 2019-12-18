using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
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

        public void Init(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
