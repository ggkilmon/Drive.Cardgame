using Drive.Cardgame.Core;
using Drive.Cardgame.Core.Cards.Interfaces;
using Drive.Cardgame.Core.Game;
using System;
using System.Linq;

namespace Drive.Cardgame.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.StartGame();
            do
            {
                Player p = g.CurrentPlayer;
                Console.WriteLine($"Current Player is: {p.Name}");
                Console.Write("Start Turn - <Enter>");
                Console.ReadLine();

                g.StartTurn();
                Console.WriteLine($"Drew card, cards in hand: {string.Join(", ", p.CardsInHand)}");
                Console.WriteLine("Play card - <Name>: ");
                string cardName = Console.ReadLine();

                //ICard playCard = p.CardsInHand.FirstOrDefault(c => c.GetName() == cardName);
                //g.PlayCard(playCard);



                g.EndTurn();
            } while (!g.IsEndOfGame());
        }
    }
}
