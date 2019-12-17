using Drive.Cardgame.Core.Interfaces;
using System;

namespace Drive.Cardgame.Core
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
