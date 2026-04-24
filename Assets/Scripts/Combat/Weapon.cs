using System.Collections;
using Combat;
using Core;
using UnityEngine;
using Logger = Core.Logger;

namespace Character
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private Inventory _inventory;
        private PlayerStateMachine _stateMachine;
        private Logger _logger;
        private Coroutine _reloadCoroutine;

        public void Initialize(Inventory inventory, PlayerStateMachine stateMachine, Logger logger)
        {
            _inventory = inventory;
            _stateMachine = stateMachine;
            _logger = logger;
        }

        public void TryFire()
        {
            if (_stateMachine.GetState() == CharacterState.Reloading)
            {
                _logger.LogWarning("Cannot fire while reloading.");
                return;
            }

            _inventory.ConsumeAmmoFromMagazine();
            _logger.LogInfo("Weapon fired.");

            bool isHit = Physics.Raycast(_firePoint.position,
                _firePoint.forward,
                out RaycastHit hit,
                GameConstants.FireDistance);

            if (isHit)
            {
                DamageReceiver damageReceiver = hit.collider.GetComponent<DamageReceiver>();

                if (damageReceiver != null)
                {
                    damageReceiver.ApplyDamage(25, DamageType.Bullet);
                    _logger.LogInfo("Weapon dealt damage.");
                }
            }
        }

        public void TryStartReload()
        {
            if (_inventory.HasAmmoForReload() == false)
            {
                _logger.LogWarning("Reload is not possible.");
                return;
            }

            if (_reloadCoroutine != null)
            {
                return;
            }

            _reloadCoroutine = StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            _stateMachine.TrySetState(CharacterState.Reloading);
            _logger.LogInfo("Reload started.");

            yield return new WaitForSeconds(GameConstants.ReloadDurationSecondCount);

            _inventory.ReloadMagazine();

            if (_stateMachine.GetState() != CharacterState.InsideVehicle)
            {
                _stateMachine.TrySetState(CharacterState.Idle);
            }

            _logger.LogInfo("Reload completed.");
            _reloadCoroutine = null;
        }

        public void CancelReload()
        {
            if (_reloadCoroutine != null)
            {
                StopCoroutine(_reloadCoroutine);
                _reloadCoroutine = null;
            }

            if (_stateMachine.GetState() == CharacterState.Reloading)
            {
                _stateMachine.TrySetState(CharacterState.Idle);
            }

            _logger.LogInfo("Reload cancelled.");
        }
    }
}