using Core;
using UnityEngine;
using Logger = Core.Logger;

namespace Vehicles
{
    public class VehicleExitResolver : MonoBehaviour
    {
        private Logger _logger;

        public void Initialize(Logger logger)
        {
            _logger = logger;
        }

        public Vector3 ResolveExitPosition(Vector3 vehiclePosition, Vector3 vehicleRight)
        {
            return vehiclePosition + vehicleRight * GameConstants.ExitDistance;
        }
    }
}