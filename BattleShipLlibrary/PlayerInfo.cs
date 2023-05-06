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

        #endregion

        #region Properties

        public List<GridSpot> ShipLocations { get => _shipLocations; set => _shipLocations = value; }
        public List<GridSpot> ShotGrids { get => _shotGrids; set => _shotGrids = value; }
        public string Name { get => _name; set => _name = value; }

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

        #region Public Methods
        public string displayShotGrid()
        {
            string currentRow = _shotGrids[0].SpotLetter;
            StringBuilder text = new StringBuilder();
            foreach (var gridSpot in _shotGrids)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    text.AppendLine();
                    currentRow = gridSpot.SpotLetter;
                }

                switch (gridSpot.Status)
                {
                    case eSpotStatus.Empty:
                        text.Append($" { gridSpot.SpotLetter }{ gridSpot.SpotNumber } ");
                        break;
                    case eSpotStatus.Miss:
                        text.Append(" O  ");
                        break;
                    case eSpotStatus.Hit:
                        text.Append(" X  ");
                        break;
                    default:
                        text.Append(" ?  ");
                        break;
                }
            }
            return text.ToString();
        }

        #endregion
    }
}
