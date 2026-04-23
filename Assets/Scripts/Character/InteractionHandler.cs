using Core;
using UnityEngine;
using Vehicles;
using Logger = Core.Logger;

namespace Character
{
    public class InteractionHandler : MonoBehaviour
    {
        private Player _character;
        private Logger _logger;

        public void Initialize(Player player, Logger logger)
        {
            _character = player;
            _logger = logger;
        }

        public void TryInteract()
        {
            if (_character.IsInsideVehicle())
            {
                Vehicle currentVehicle = _character.GetCurrentVehicle();

                if (currentVehicle != null)
                {
                    currentVehicle.Exit(_character);
                }

                return;
            }

            Collider[] colliders = Physics.OverlapSphere(
                _character.transform.position,
                GameConstants.InteractionRadius);

            foreach (Collider collider in colliders)
            {
                Vehicle vehicle = collider.GetComponent<Vehicle>();

                if (vehicle != null)
                {
                    _character.EnterVehicle(vehicle);
                    return;
                }
            }

            _logger.LogInfo("No interactable object found.");
        }
    }
}