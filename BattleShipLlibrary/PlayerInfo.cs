using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLlibrary
{
    public class PlayerInfo
    {
        #region Ctor

        public PlayerInfo(string name)
        {
            _name = name;
            InitializeGrid();
        }

        #endregion

        #region Private Fields
        private string _name;
        private List<GridSpot> _shipLocations;
        private List<GridSpot> _shotGrids;

        public List<GridSpot> ShipLocations { get => _shipLocations; set => _shipLocations = value; }
        public List<GridSpot> ShotGrids { get => _shotGrids; set => _shotGrids = value; }

        #endregion

        #region Properties



        #endregion


        #region Private Methods
        private void InitializeGrid()
        {
            _shotGrids = new List<GridSpot>();
            _shipLocations = new List<GridSpot>();
            var letters = new List<string>() { "A", "B","C","D","E"};
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (var letter in letters)
            {
                foreach (var number in numbers)
                {
                    _shotGrids.Add(new GridSpot(letter, number, eSpotStatus.Empty));
                }
            }
        }
        #endregion
    }
}
