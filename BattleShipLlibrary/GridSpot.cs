using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLlibrary
{
    public class GridSpot
    {
        #region Ctor

        public GridSpot(string spotLetter, int spotNumber, eSpotStatus status)
        {
            _spotLetter = spotLetter;
            _spotNumber = spotNumber;
            _status = status;
        }

        #endregion

        #region Private Fields

        private string _spotLetter;
        private int _spotNumber;
        private eSpotStatus _status;

        #endregion

        #region Properties

        public string SpotLetter { get => _spotLetter; set => _spotLetter = value; }
        public int SpotNumber { get => _spotNumber; set => _spotNumber = value; }
        public eSpotStatus Status { get => _status; set => _status = value; }

        #endregion
    }
}
