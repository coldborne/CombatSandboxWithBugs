using System.Collections;
using UnityEngine;

namespace Combat
{
    public class ShotTracer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _visibleDuration = 0.05f;

        private Coroutine _hideCoroutine;

        private void Awake()
        {
            _lineRenderer.enabled = false;
        }

        public void ShowTracer(Vector3 startPosition, Vector3 endPosition)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
            _lineRenderer.enabled = true;

            if (_hideCoroutine != null)
            {
                StopCoroutine(_hideCoroutine);
            }

            _hideCoroutine = StartCoroutine(HideAfterDelay());
        }

        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(_visibleDuration);

            _lineRenderer.enabled = false;
            _hideCoroutine = null;
        }
    }
}