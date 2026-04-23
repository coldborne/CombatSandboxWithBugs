using System;
using UnityEngine;

namespace Logic
{
    public class InputReader : MonoBehaviour
    {
        private readonly string Vertical = nameof(Vertical);
        private readonly string Horizontal = nameof(Horizontal);

        public event Action InteractionButtonPressed;
        public event Action FireButtonPressed;
        public event Action ReloadButtonPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractionButtonPressed?.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                FireButtonPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadButtonPressed?.Invoke();
            }
        }

        public float GetHorizontalInput()
        {
            return Input.GetAxis(Horizontal);
        }

        public float GetVerticalInput()
        {
            return Input.GetAxis(Vertical);
        }
    }
}