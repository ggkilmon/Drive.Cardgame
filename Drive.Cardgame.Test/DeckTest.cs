using Drive.Cardgame.Core.Cards;
using Drive.Cardgame.Core.Cards.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drive.Cardgame.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckIsCreated()
        {
            Deck d = new Deck();
            ICard[] deck = d.BuildDeck();

            Assert.IsTrue(deck.Length == 106);
        }

        [TestMethod]
        public void DeckIsShuffled()
        {
            Deck d = new Deck();
            ICard[] deck = d.BuildDeck();
            ICard[] shuffledDeck = d.Shuffle(deck);

            Assert.IsFalse(
                deck[0] == shuffledDeck[0] &&
                deck[1] == shuffledDeck[1] &&
                deck[2] == shuffledDeck[2]
                );
        }

        [TestMethod]
        public void DeckShuffledDifferentEachTime()
        {
            Deck d = new Deck();
            ICard[] deck = d.BuildDeck();
            ICard[] shuffledDeck1 = d.Shuffle(deck);
            ICard[] shuffledDeck2 = d.Shuffle(deck);

            Assert.IsFalse(
                shuffledDeck1[0] == shuffledDeck2[0] &&
                shuffledDeck1[1] == shuffledDeck2[1] &&
                shuffledDeck1[2] == shuffledDeck2[2]
                );
        }

        [TestMethod]
        public void DeckDrawCard()
        {
            Deck d = new Deck();
            Stack<ICard> deck = d.BuildShuffledDeck();

            Assert.IsTrue(deck.Count == 106);
            
            ICard drawnCard = d.DrawCard(deck);
            
            Assert.IsTrue(deck.Count == 105);
            Assert.IsNotNull(drawnCard);            
        }
    }
}
