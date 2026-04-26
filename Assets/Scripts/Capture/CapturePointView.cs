using TMPro;
using UnityEngine;

namespace Capture
{
    public class CapturePointView : MonoBehaviour
    {
        [SerializeField] private CapturePoint _capturePoint;
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            float progress = _capturePoint.GetCaptureProgress();
            int percent = Mathf.RoundToInt(progress * 100.0f);

            Debug.Log(percent);
            _text.text = percent + "%";
        }
    }
}