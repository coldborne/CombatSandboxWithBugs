using UnityEngine;

namespace Character
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _inMagazineAmmo = 5;
        [SerializeField] private int _reservedAmmo = 25;
        [SerializeField] private int _magazineCapacity = 5;

        public int GetAmmoInMagazine()
        {
            return _inMagazineAmmo;
        }

        public int GetReservedAmmo()
        {
            return _reservedAmmo;
        }

        public int GetMagazineCapacity()
        {
            return _magazineCapacity;
        }

        public bool HasAmmoInMagazine()
        {
            return _inMagazineAmmo > 0;
        }

        public bool HasAmmoForReload()
        {
            return _reservedAmmo > 0 && _inMagazineAmmo < _magazineCapacity;
        }

        public void ConsumeAmmoFromMagazine()
        {
            if (_inMagazineAmmo > 0)
            {
                _inMagazineAmmo--;
            }
        }

        public void ReloadMagazine()
        {
            int neededAmmo = _magazineCapacity - _inMagazineAmmo;
            int toLoadAmmo = Mathf.Min(neededAmmo, _reservedAmmo);

            _inMagazineAmmo += toLoadAmmo;
            _reservedAmmo -= toLoadAmmo;
        }

        public void SetAmmo(int inMagazineAmmo, int reservedAmmo)
        {
            _inMagazineAmmo = inMagazineAmmo;
            _reservedAmmo = reservedAmmo;
        }

        public void ResetAmmo()
        {
            _inMagazineAmmo = _magazineCapacity;
            _reservedAmmo = 25;
        }
    }
}