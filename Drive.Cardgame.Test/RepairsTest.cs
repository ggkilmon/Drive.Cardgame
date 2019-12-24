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
    public class RepairsTest
    {
        [TestMethod]
        public void PlayRepairs_RemoveAccident()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Repairs();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Accident());

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.Accident.ToString()) == 1);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Repairs.ToString()) == 1);
        }

        [TestMethod]
        public void PlayRepairs_NoAccident()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Repairs();

            bool canPlay = g.PlayCard(g.Players[1], card);

            Assert.IsFalse(canPlay);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.Accident.ToString()) == 1);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Repairs.ToString()) == 1);
        }
    }
}
