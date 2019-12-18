using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public abstract class BaseCard
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }
}
