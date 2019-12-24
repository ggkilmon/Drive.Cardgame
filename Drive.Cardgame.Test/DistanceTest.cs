using Drive.Cardgame.Core.Cards;
using Drive.Cardgame.Core.Cards.Distances;
using Drive.Cardgame.Core.Cards.Hazards;
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
    public class DistanceTest
    {
        [TestMethod]
        public void PlayDistance_NoRoll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "25 km", Value = 25, Type = CardType.Distance.TwentyFiveKilometers };

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlayDistance);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_WithRoll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "25 km", Value = 25, Type = CardType.Distance.TwentyFiveKilometers };
            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_WithSpeedLimit_Under50()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "50 km", Value = 50, Type = CardType.Distance.FiftyKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());
            g.CurrentPlayer.Board.CardsInPlay.Add(new SpeedLimit());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_WithSpeedLimit_Over50()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "100 km", Value = 100, Type = CardType.Distance.OneHundredKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());
            g.CurrentPlayer.Board.CardsInPlay.Add(new SpeedLimit());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlayDistance);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_NoSpeedLimit_Under50()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "25 km", Value = 25, Type = CardType.Distance.TwentyFiveKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_NoSpeedLimit_Over50()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "100 km", Value = 100, Type = CardType.Distance.OneHundredKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }
    }
}
