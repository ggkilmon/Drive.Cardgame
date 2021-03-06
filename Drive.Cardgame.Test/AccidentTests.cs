﻿using Drive.Cardgame.Core.Cards;
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
    public class AccidentTests
    {
        [TestMethod]
        public void PlayAccident_RemoveRoll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Accident();

            g.Players[1].Board.CardsInPlay.Add(new Roll());

            bool canPlay = g.PlayCard(g.Players[1], card);

            Assert.IsTrue(canPlay);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
        }

        [TestMethod]
        public void PlayAccident_NoRoll()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Accident();

            bool canPlay = g.PlayCard(g.Players[1], card);

            Assert.IsFalse(canPlay);
            Assert.IsFalse(g.Players[1].Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
        }
    }
}
