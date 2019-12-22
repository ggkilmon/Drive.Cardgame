using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards.Interfaces
{
    public interface ICard
    {
        void Init(string name, int value, Enum type);
        bool CanPlayCard(List<ICard> cardsInPlay);
        void RemoveAffectedCardsFromPlay(List<ICard> cardsInPlay);
        string ToString();
        string GetCardType();
    }
}
