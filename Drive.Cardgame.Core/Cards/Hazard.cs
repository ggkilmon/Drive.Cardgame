using Drive.Cardgame.Core.Cards.Interfaces;
using System;

namespace Drive.Cardgame.Core.Cards
{
    public class Hazard : BaseCard, ICard
    {
        public Hazard()
        {
            Score = 0;
        }

        public void Init(string name, int value)
        {
            Name = name;
        }
    }
}
