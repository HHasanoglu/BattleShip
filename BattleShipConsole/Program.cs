using BattleShipLlibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            PlayerInfo activePlayer = creatPlayer("Player 1");
            PlayerInfo opponent = creatPlayer("Player 2");
            PlayerInfo winner = null;

            Console.WriteLine(activePlayer.displayShotGrid());
            recordPlayerShot(activePlayer, opponent);

            Console.ReadLine();
        }

        private static void recordPlayerShot(PlayerInfo activePlayer, PlayerInfo opponent)
        {
            var shot = AskForShot(activePlayer);
            (string row,int column)=GameLogic.getRowAndColumn(shot);
            GameLogic.ValidateLocation(activePlayer, row, column);

        }

        private static string AskForShot(PlayerInfo activePlayer)
        {
            Console.WriteLine($"{activePlayer.Name}: Please take Your Shot");
            var shot = Console.ReadLine();
            return shot;
        }

        private static PlayerInfo creatPlayer(string player)
        {
            Console.WriteLine($"Player Information for {player}");

            //Asking for the Player Name
            var name = AskingForName();

            //Create the Player and its grid
            var playerInfo = new PlayerInfo(name);

            //Ask for the Placement of the Ship
            placeShips(playerInfo);

            Console.Clear();

            return playerInfo;
        }

        private static void placeShips(PlayerInfo playerInfo)
        {
            do
            {
                Console.Write($"Where do you want to place your ship {playerInfo.ShipLocations.Count + 1}:");
                var location = Console.ReadLine();
                try
                {
                    GameLogic.PlaceShip(playerInfo, location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (playerInfo.ShipLocations.Count < 5);
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the BattleShip Game");
            Console.WriteLine("Created By Hamid Hassanzada");
            Console.WriteLine();
        }

        private static string AskingForName()
        {
            Console.Write("Enter Your name: ");
            return Console.ReadLine();
        }
    }
}
