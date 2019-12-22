using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Interfaces
{
    public interface ICard
    {
        void Init(string name, int value);
        bool CanPlayCard(List<ICard> cardsInPlay);
        string ToString();
        string GetName();
    }
}
