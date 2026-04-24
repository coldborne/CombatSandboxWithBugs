using Character;
using UnityEngine;
using Vehicles;

namespace UI
{
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Vehicle _vehicle;

        private bool _isVisible = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                _isVisible = !_isVisible;
            }
        }

        private void OnGUI()
        {
            if (!_isVisible)
            {
                return;
            }

            GUILayout.BeginArea(new Rect(10, 10, 380, 260), GUI.skin.box);
            GUILayout.Label("=== DEBUG OVERLAY ===");
            GUILayout.Label("Player state: " + _player.GetState());
            GUILayout.Label("Is reloading: " + _player.IsReloading());
            GUILayout.Label("Inside vehicle: " + _player.IsInsideVehicle());
            GUILayout.Label("Ammo in magazine: " + _player.GetAmmoInMagazine());
            GUILayout.Label("Ammo reserve: " + _player.GetReservedAmmo());
            GUILayout.Label("Engine destroyed: " + _vehicle.IsModuleDestroyed(VehicleModuleType.Engine));
            GUILayout.EndArea();
        }
    }
}