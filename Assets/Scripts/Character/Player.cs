using Core;
using Logic;
using UnityEngine;
using Vehicles;
using Logger = Core.Logger;

namespace Character
{
    public class Player : MonoBehaviour
    {
        private const float Epsilon = 0.01f;

        [SerializeField] private PlayerStateMachine _stateMachine;
        [SerializeField] private Health _health;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private InteractionHandler _interactionHandler;
        [SerializeField] private InputReader _inputReader;

        private Logger _logger;
        private Vehicle _currentVehicle;

        public void Initialize(Logger logger)
        {
            _logger = logger;

            _weapon.Initialize(_inventory, _stateMachine, _logger);
            _interactionHandler.Initialize(this, _logger);
        }

        private void Update()
        {
            if (_stateMachine.GetState() == CharacterState.Dead)
            {
                return;
            }

            HandleMovementInput();
        }

        private void OnEnable()
        {
            _inputReader.InteractionButtonPressed += HandleInteractionInput;
        }

        private void OnDisable()
        {
            _inputReader.InteractionButtonPressed -= HandleInteractionInput;
        }

        private void HandleMovementInput()
        {
            if (_stateMachine.GetState() == CharacterState.InsideVehicle)
            {
                return;
            }

            float horizontalInput = _inputReader.GetHorizontalInput();
            float verticalInput = _inputReader.GetVerticalInput();

            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
            transform.Translate(movement * (GameConstants.PlayerMoveSpeed * Time.deltaTime));

            if (movement.sqrMagnitude > Epsilon)
            {
                _stateMachine.TrySetState(CharacterState.Moving);
            }
            else if (_stateMachine.GetState() == CharacterState.Moving)
            {
                _stateMachine.TrySetState(CharacterState.Idle);
            }
        }

        private void HandleInteractionInput()
        {
            if (_stateMachine.GetState() == CharacterState.Dead)
            {
                return;
            }

            _interactionHandler.TryInteract();
        }

        private void Fire()
        {
            if (_stateMachine.GetState() == CharacterState.InsideVehicle)
            {
                return;
            }

            _weapon.TryFire();
        }

        private void Reload()
        {
            if (_stateMachine.GetState() == CharacterState.InsideVehicle)
            {
                return;
            }

            _weapon.TryStartReload();
        }

        public void EnterVehicle(Vehicle vehicle)
        {
            _logger.LogInfo("Player is entering vehicle.");

            _stateMachine.TrySetState(CharacterState.EnteringVehicle);
            _currentVehicle = vehicle;
            vehicle.TryEnter(this);

            _stateMachine.TrySetState(CharacterState.InsideVehicle);
        }

        public void ExitVehicle(Vector3 exitPosition)
        {
            _logger.LogInfo("Player is exiting vehicle.");

            _stateMachine.TrySetState(CharacterState.ExitingVehicle);
            _currentVehicle = null;
            transform.position = exitPosition;
            _stateMachine.TrySetState(CharacterState.Idle);
        }

        public void Die()
        {
            _health.SetDead();
            _stateMachine.TrySetState(CharacterState.Dead);
            _logger.LogInfo("Player died.");
        }

        public bool IsDead()
        {
            return _stateMachine.GetState() == CharacterState.Dead || _health.IsDead();
        }

        public bool IsReloading()
        {
            return _stateMachine.GetState() == CharacterState.Reloading;
        }

        public bool IsInsideVehicle()
        {
            return _stateMachine.GetState() == CharacterState.InsideVehicle;
        }

        public void ForceMoveTo(Vector3 targetPosition)
        {
            transform.position = targetPosition;
        }

        public Vehicle GetCurrentVehicle()
        {
            return _currentVehicle;
        }

        public string GetState()
        {
            return _stateMachine.GetState().ToString();
        }

        public int GetAmmoInMagazine()
        {
            return _inventory.GetAmmoInMagazine();
        }

        public int GetReservedAmmo()
        {
            return _inventory.GetReservedAmmo();
        }
    }
}