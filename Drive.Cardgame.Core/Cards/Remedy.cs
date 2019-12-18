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

        public void Init(string name, int value)
        {
            Name = name;
        }
    }
}
