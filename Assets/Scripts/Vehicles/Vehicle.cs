using Character;
using Core;
using Logic;
using UnityEngine;
using Logger = Core.Logger;

namespace Vehicles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Vehicle : MonoBehaviour
    {
        [SerializeField] private VehicleSeat _seat;
        [SerializeField] private VehicleModel _model;
        [SerializeField] private VehicleExitResolver _exitResolver;
        [SerializeField] private InputReader _inputReader;

        private Logger _logger;
        private Player _currentDriver;

        public void Initialize(Logger logger)
        {
            _logger = logger;
            _model.Initialize(logger);
            _exitResolver.Initialize(logger);
        }

        private void Update()
        {
            if (_currentDriver == null)
            {
                return;
            }

            HandleDriving();
        }

        private void HandleDriving()
        {
            float verticalMovement = _inputReader.GetVerticalInput();

            transform.Translate(Vector3.forward * (verticalMovement * GameConstants.VehicleMoveSpeed * Time.deltaTime));
        }

        public void TryEnter(Player character)
        {
            bool hasEntered = _seat.TryOccupyDriverSeat(character);

            if (hasEntered)
            {
                _currentDriver = character;
                _logger.LogInfo("Driver seat occupied.");
            }
            else
            {
                _logger.LogWarning("Driver seat is already occupied.");
            }
        }

        public void Exit(Player character)
        {
            _seat.ClearDriverSeat();
            _currentDriver = null;
            _logger.LogInfo("Driver seat released.");

            Vector3 exitPosition = _exitResolver.ResolveExitPosition(transform.position, transform.right);
            character.ExitVehicle(exitPosition);
        }

        public bool IsModuleDestroyed(VehicleModuleType module)
        {
            return _model.IsModuleDestroyed(module);
        }
    }
}