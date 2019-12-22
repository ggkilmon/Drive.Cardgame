using Drive.Cardgame.Core.Cards;
using Drive.Cardgame.Core.Cards.Interfaces;
using Drive.Cardgame.Core.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive.Cardgame.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void CreatePlayers()
        {
            Game g = new Game();
            Player[] players = g.InitPlayers();

            Assert.IsNotNull(players);
            Assert.IsTrue(players.Length == 2);
            Assert.IsFalse(string.IsNullOrEmpty(players[0].Name));
            Assert.IsFalse(string.IsNullOrEmpty(players[1].Name));
        }

        [TestMethod]
        public void CreatePlayers4()
        {
            Game g = new Game();
            Player[] players = g.InitPlayers(4);

            Assert.IsNotNull(players);
            Assert.IsTrue(players.Length == 4);
            Assert.IsFalse(string.IsNullOrEmpty(players[0].Name));
            Assert.IsFalse(string.IsNullOrEmpty(players[1].Name));
            Assert.IsFalse(string.IsNullOrEmpty(players[2].Name));
            Assert.IsFalse(string.IsNullOrEmpty(players[3].Name));
        }

        [TestMethod]
        public void DealToPlayers()
        {
            Deck d = new Deck();
            Stack<ICard> shuffledDeck = d.BuildShuffledDeck();
            
            Game g = new Game();
            Player[] players = g.InitPlayers(2);
            g.DealToPlayers(players, shuffledDeck, 6);

            Assert.IsTrue(shuffledDeck.Count == 106 - 12);
            Assert.IsTrue(players[0].CardsInHand.Count == 6);
            Assert.IsTrue(players[1].CardsInHand.Count == 6);
        }

        [TestMethod]
        public void DealToPlayers4()
        {
            Deck d = new Deck();
            Stack<ICard> shuffledDeck = d.BuildShuffledDeck();

            Game g = new Game();
            Player[] players = g.InitPlayers(4);
            g.DealToPlayers(players, shuffledDeck, 6);

            Assert.IsTrue(shuffledDeck.Count == 106 - 24);
            Assert.IsTrue(players[0].CardsInHand.Count == 6);
            Assert.IsTrue(players[1].CardsInHand.Count == 6);
            Assert.IsTrue(players[2].CardsInHand.Count == 6);
            Assert.IsTrue(players[3].CardsInHand.Count == 6);
        }

        [TestMethod]
        public void StartGame_2Players()
        {
            Game g = new Game();
            g.StartGame();

            Assert.IsTrue(g.Players.Length == 2);
            Assert.IsTrue(g.DrawPile.Count == 106 - 12);
            Assert.AreEqual(g.Players[0], g.CurrentPlayer);
        }

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
            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });

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

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });
            g.CurrentPlayer.Board.CardsInPlay.Add(new Hazard() { Name = "Speed Limit", Score = 0, Type = CardType.Hazard.SpeedLimit });

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

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });
            g.CurrentPlayer.Board.CardsInPlay.Add(new Hazard() { Name = "Speed Limit", Score = 0, Type = CardType.Hazard.SpeedLimit });

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

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });

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

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == card.GetCardType()));
        }

        [TestMethod]
        public void PlayDistance_0_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 1);
        }

        [TestMethod]
        public void PlayDistance_1_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });
            g.CurrentPlayer.Board.CardsInPlay.Add(new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers });

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 2);
        }

        [TestMethod]
        public void PlayDistance_2_200()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });
            g.CurrentPlayer.Board.CardsInPlay.Add(new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers });
            g.CurrentPlayer.Board.CardsInPlay.Add(new Distance() { Name = "200 km", Value = 200, Type = CardType.Distance.TwoHundredKilometers });

            bool canPlayDistance = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlayDistance);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == card.GetCardType()) == 2);
        }

        [TestMethod]
        public void PlayRoll_NoCardsInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll };

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsTrue(canPlay);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Any(c => c.GetCardType() == CardType.Remedy.Roll.ToString()));
        }

        [TestMethod]
        public void PlayRoll_StopInPlay()
        {
            Game g = new Game();
            g.StartGame();
            ICard card = new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Hazard() { Name = "Stop", Score = 0, Type = CardType.Hazard.Stop });

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
            ICard card = new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll };

            g.CurrentPlayer.Board.CardsInPlay.Add(new Remedy() { Name = "Roll", Score = 0, Type = CardType.Remedy.Roll });

            bool canPlay = g.PlayCard(g.CurrentPlayer, card);

            Assert.IsFalse(canPlay);
            Assert.IsTrue(g.CurrentPlayer.Board.CardsInPlay.Count(c => c.GetCardType() == CardType.Remedy.Roll.ToString()) == 1);
        }
    }
}
