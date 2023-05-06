using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLlibrary
{
    public static class GameLogic
    {
        public static void PlaceShip(PlayerInfo PlayerInfo, string location)
        {
            (string letter, int number) = getRowAndColumn(location);
            bool isLocationValid = ValidateLocation(PlayerInfo, letter, number);
            var isSpotAvailable = !PlayerInfo.ShipLocations.Any(x => x.SpotLetter == letter && x.SpotNumber == number);
            if (isLocationValid && isSpotAvailable)
            {
                PlayerInfo.ShipLocations.Add(new GridSpot(letter, number, eSpotStatus.Ship));
            }
            else
            {
                throw new ArgumentException("This was not a valid location.Plase try Again");
            }


            //return isLocationValid && isSpotAvailable;
        }

        public static bool ValidateLocation(PlayerInfo PlayerInfo, string letter, int number)
        {
            return PlayerInfo.ShotGrids.Any(x => x.SpotLetter == letter && x.SpotNumber == number);
        }

        public static (string row, int number) getRowAndColumn(string location)
        {
            string letter ;
            int number = 0;
            if (location.Length==2)
            {
                var characters=location.ToArray();
                letter = characters[0].ToString().ToUpper();
                number = int.Parse(characters[1].ToString());
            }
            else
            {
                throw new ArgumentException("Invalid Shot Type");
            }

            return (letter,number);
        }
    }
}
