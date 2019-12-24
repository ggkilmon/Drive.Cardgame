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
    public class StopTest
    {
        [TestMethod]
        public void PlayStop_NoRoll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Stop();
            
            bool canPlay = g.PlayCard(g.Players[1], card);

            Assert.IsFalse(canPlay);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.Stop.ToString()) == 1);
        }

        [TestMethod]
        public void PlayStop_Roll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Stop();

            g.Players[1].Board.CardsInPlay.Add(new Roll());

            bool canPlay = g.PlayCard(g.Players[1], card);

            Assert.IsTrue(canPlay);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
            Assert.IsTrue(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.Stop.ToString()) == 1);
        }
    }
}
