using System.Collections.Generic;
using UnityEngine;
using Logger = Core.Logger;

namespace Vehicles
{
    public class VehicleModel : MonoBehaviour
    {
        private List<VehicleModule> _modules;

        private Logger _logger;

        private void Awake()
        {
            _modules = new List<VehicleModule>();
            Health health = GetComponent<Health>();
            VehicleModule engine = new VehicleModule(VehicleModuleType.Engine, health);
            _modules.Add(engine);
        }

        public void Initialize(Logger logger)
        {
            _logger = logger;
        }

        public void ApplyDamageToModule(VehicleModuleType moduleType, int damageAmount)
        {
            VehicleModule module = GetModule(moduleType);

            if (module == null)
            {
                _logger.LogWarning("Module not found: " + moduleType);
                return;
            }

            module.ApplyDamage(damageAmount);
            _logger.LogInfo("Damage applied to module: " + moduleType);

            if (module.IsDestroyed())
            {
                _logger.LogWarning("Module destroyed: " + moduleType);
            }
        }

        public bool IsModuleDestroyed(VehicleModuleType moduleType)
        {
            VehicleModule module = GetModule(moduleType);
            return module != null && module.IsDestroyed();
        }

        public void ResetAllModules()
        {
            foreach (VehicleModule module in _modules)
            {
                module.Reset();
            }
        }

        private VehicleModule GetModule(VehicleModuleType moduleType)
        {
            foreach (VehicleModule module in _modules)
            {
                if (module.GetModuleType() == moduleType)
                {
                    return module;
                }
            }

            return null;
        }
    }
}