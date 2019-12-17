using Drive.Cardgame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core
{
    public class Safety : BaseCard, ICard
    {
        public bool IsCoupeForre { get; set; }

        public Safety()
        {
            IsCoupeForre = false;
            Score = 100;
        }

        public void Init(string name, int value)
        {
            Name = name;
        }

        public void CoupeFourre()
        {
            IsCoupeForre = true;
            Score += 300;
        }
    }
}
