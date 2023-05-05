using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLlibrary
{
    public static class GameLogic
    {
        public static bool PlaceShip(PlayerInfo PlayerInfo, string location) 
        {
            (string letter, int number) = getRowAndColumn(location);
            var isLocationValid = PlayerInfo.ShotGrids.Any(x => x.SpotLetter == letter && x.SpotNumber == number);
            var isSpotAvailable = PlayerInfo.ShipLocations.Any(x => x.SpotLetter != letter && x.SpotNumber != number);
            if (isLocationValid && isSpotAvailable)
            {
                PlayerInfo.ShipLocations.Add(new GridSpot(letter, number, eSpotStatus.Ship));
            }


            return isLocationValid && isSpotAvailable;
        }

        private static (string row, int number) getRowAndColumn(string location)
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
