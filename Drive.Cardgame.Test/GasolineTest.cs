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
    public class GasolineTest
    {
        [TestMethod]
        public void PlayGasoline_NoOutOfGas()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Gasoline();

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlay);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.OutOfGas.ToString()) == 1);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Gasoline.ToString()) == 1);
        }

        [TestMethod]
        public void PlayGasoline_OutOfGas()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Gasoline();

            g.CurrentPlayer.Board.CardsInPlay.Add(new OutOfGas());

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Hazard.OutOfGas.ToString()) == 1);
            Assert.IsFalse(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Gasoline.ToString()) == 1);
        }
    }
}
