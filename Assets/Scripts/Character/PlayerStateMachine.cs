using UnityEngine;

namespace Character
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private CharacterState _currentState = CharacterState.Idle;

        public CharacterState GetState()
        {
            return _currentState;
        }

        public bool TrySetState(CharacterState newState)
        {
            if (_currentState == CharacterState.Dead && newState != CharacterState.Dead)
            {
                return false;
            }

            _currentState = newState;
            return true;
        }
    }
}