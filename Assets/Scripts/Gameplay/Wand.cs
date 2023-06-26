using System;
using UnityEngine;

public class Wand
{
    public event Action OnBurst;
    public event Action OnCanBurst;
    public event Action OnCannotBurst;
    public event Action<float> OnPowerPercentChanged;

    public WandData Data => _data;
    public float Power => _power;
    public float PowerPercent => _power / _data.PowerCapacity;

	private WandData _data;
    private float _power;
    private bool _canBurst;

    public Wand(WandData data)
    {
        _data = data;
        _power = 0;
    }

    public void ProducePower(float multiplier)
    {
        _power = Mathf.Min(_data.PowerCapacity, _power + _data.PowerProduce * multiplier);

        OnPowerPercentChanged?.Invoke(PowerPercent);

        if (_canBurst || _power < _data.PowerBurstMinimum) return;

		_canBurst = true;
		OnCanBurst?.Invoke();
	}

    public void ConsumpPower(float multiplier)
    {
        _power = Mathf.Max(0, _power - _data.PowerConsumption * multiplier);
		
        OnPowerPercentChanged?.Invoke(PowerPercent);

        if (!_canBurst || _power >= _data.PowerBurstMinimum) return;

        _canBurst = false;
        OnCannotBurst?.Invoke();
	}

    public void Burst()
    {
        if (_power >= _data.PowerBurstMinimum)
        {
            _power = 0;
            OnBurst?.Invoke();
        }
    }
}
