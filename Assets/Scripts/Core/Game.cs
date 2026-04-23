using Character;
using UnityEngine;
using Vehicles;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Vehicle _vehicle;

        private Logger _logger;

        private void Awake()
        {
            _logger = new Logger();
        }

        private void Start()
        {
            _player.Initialize(_logger);
            _vehicle.Initialize(_logger);
        }
    }
}