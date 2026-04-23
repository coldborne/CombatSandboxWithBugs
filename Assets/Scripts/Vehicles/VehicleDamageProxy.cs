using Combat;
using UnityEngine;

namespace Vehicles
{
    public class VehicleDamageProxy : MonoBehaviour
    {
        [SerializeField] private VehicleModel _damageModel;
        [SerializeField] private VehicleModuleType _targetModuleType = VehicleModuleType.Engine;

        public void ApplyDamage(int damageAmount, DamageType damageType)
        {
            _damageModel.ApplyDamageToModule(_targetModuleType, damageAmount);
        }
    }
}