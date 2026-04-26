namespace Vehicles
{
    public class VehicleModule
    {
        private VehicleModuleType _type;
        private Health _health;

        public VehicleModule(VehicleModuleType type, Health health)
        {
            _type = type;
            _health = health;
        }

        public bool IsDestroyed()
        {
            return _health.IsDead();
        }

        public void ApplyDamage(int damageAmount)
        {
            _health.ApplyDamage(damageAmount);
        }

        public void Reset()
        {
            _health.Reset();
        }

        public VehicleModuleType GetModuleType()
        {
            return _type;
        }
    }
}