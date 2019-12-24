using Drive.Cardgame.Core.Cards;
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
    public class EndOfLimitTest
    {
        [TestMethod]
        public void PlayEndOfLimit_SpeedLimitInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new EndOfLimit();

            g.CurrentPlayer.Board.CardsInPlay.Add(new SpeedLimit());

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.SpeedLimit.ToString()) == 1);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.EndOfLimit.ToString()) == 1);
        }

        [TestMethod]
        public void PlayEndOfLimit_SpeedLimitNotInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new EndOfLimit();

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlay);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.EndOfLimit.ToString()) == 1);
        }
    }
}
