using Drive.Cardgame.Core.Cards.Distances;
using Drive.Cardgame.Core.Cards.Interfaces;
using Drive.Cardgame.Core.Cards.Remedies;
using Drive.Cardgame.Core.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Test
{
    [TestClass]
    public class TwoHundredKilometersTest
    {
        [TestMethod]
        public void PlayDistance_0_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new TwoHundredKilometers();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 1);
        }

        [TestMethod]
        public void PlayDistance_1_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new TwoHundredKilometers();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());
            g.CurrentPlayer.Board.CardsInPlay.Add(new TwoHundredKilometers());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 2);
        }

        [TestMethod]
        public void PlayDistance_2_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new TwoHundredKilometers();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());
            g.CurrentPlayer.Board.CardsInPlay.Add(new TwoHundredKilometers());
            g.CurrentPlayer.Board.CardsInPlay.Add(new TwoHundredKilometers());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 2);
        }
    }
}
