using Drive.Cardgame.Core.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Utility
{
    public static class Extensions
    {
        public static Stack<ICard> ToStack(this ICard[] cards)
        {
            Stack<ICard> convertedDeck = new Stack<ICard>();
            for (var i = cards.Length - 1; i >= 0; i--)
            {
                convertedDeck.Push(cards[i]);
            }

            return convertedDeck;
        }
    }
}
