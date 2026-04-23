using Character;
using UnityEngine;

namespace Vehicles
{
    public class VehicleSeat : MonoBehaviour
    {
        private Player _driver;

        public bool TryOccupyDriverSeat(Player driver)
        {
            if (_driver != null)
            {
                return false;
            }

            _driver = driver;
            return true;
        }

        public void ClearDriverSeat()
        {
            _driver = null;
        }

        public bool IsDriverSeatOccupied()
        {
            return _driver != null;
        }
    }
}