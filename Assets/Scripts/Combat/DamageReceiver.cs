using Vehicles;

namespace Combat
{
    using UnityEngine;

    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private VehicleDamageProxy _vehicleDamageProxy;

        public void ApplyDamage(int damageAmount, DamageType damageType)
        {
            if (_playerHealth != null)
            {
                _playerHealth.ApplyDamage(damageAmount);
                return;
            }

            if (_vehicleDamageProxy != null)
            {
                _vehicleDamageProxy.ApplyDamage(damageAmount, damageType);
            }
        }
    }
}