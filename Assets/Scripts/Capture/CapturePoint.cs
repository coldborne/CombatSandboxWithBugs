using System.Collections.Generic;
using Character;
using Core;
using UnityEngine;
using Logger = Core.Logger;

namespace Capture
{
    public class CapturePoint : MonoBehaviour
    {
        private readonly List<Player> _playersInside = new List<Player>();

        private Logger _logger;
        private float _captureProgress;

        public void Initialize(Logger logger)
        {
            _logger = logger;
        }

        private void Update()
        {
            UpdateCapture();
        }

        private void UpdateCapture()
        {
            int activeCapturers = _playersInside.Count;

            if (activeCapturers > 0)
            {
                _captureProgress += Time.deltaTime / GameConstants.CaptureTimeSecondCount;
                _captureProgress = Mathf.Clamp01(_captureProgress);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null && _playersInside.Contains(player) == false)
            {
                _playersInside.Add(player);
                _logger.LogInfo("Player entered capture zone.");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null)
            {
                _playersInside.Remove(player);
                _logger.LogInfo("Player exited capture zone.");
            }
        }

        public float GetCaptureProgress()
        {
            return _captureProgress;
        }

        public void ResetCapture()
        {
            _captureProgress = 0.0f;
            _playersInside.Clear();
        }

        public int GetPlayersInsideCount()
        {
            return _playersInside.Count;
        }
    }
}