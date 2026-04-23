using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue = 100;
    [SerializeField] private int _value = 100;

    public void ApplyDamage(int amount)
    {
        _value -= amount;

        if (_value < 0)
        {
            _value = 0;
        }
    }

    public void SetDead()
    {
        _value = 0;
    }

    public void Reset()
    {
        _value = _maxValue;
    }

    public int Get()
    {
        return _value;
    }

    public bool IsDead()
    {
        return _value <= 0;
    }
}