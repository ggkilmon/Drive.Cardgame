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
    public class RollTest
    {
        [TestMethod]
        public void PlayRoll_NoCardsInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Roll();

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()));
        }

        [TestMethod]
        public void PlayRoll_StopInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Roll();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Stop());

            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.Stop.ToString()));

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()));
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == CardType.Hazard.Stop.ToString()));
        }

        [TestMethod]
        public void PlayRoll_RollAlreadyInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Roll();

            g.CurrentPlayer.Board.CardsInPlay.Add(new Roll());

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlay);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
        }
    }
}
