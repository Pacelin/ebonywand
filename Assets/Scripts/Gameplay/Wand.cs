using System;
using UnityEngine;

public class Wand
{
    public event Action<float> OnPowerPercentChanged;
    public event Action<bool> OnBurstableChanged;
    public event Action OnBurst;

    [field: SerializeField] public WandData Data { get; private set; }
    public float Power { get; private set; }
	public bool Burstable { get; private set; }

	public Wand(WandData data) => Data = data;

	public void ProducePower(float distance) =>
		SetPower(Power + Data.PowerProduce * distance);
    public void ConsumpPower(float deltaTime) =>
        SetPower(Power - Data.PowerConsumption * deltaTime);


    public void Burst()
    {
        if (Power < Data.PowerBurstMinimum) return;
        
        SetPower(0);
		OnBurst?.Invoke();
    }

    private void SetPower(float power)
    {
		Power = Mathf.Clamp(power, 0, Data.PowerCapacity);
		OnPowerPercentChanged?.Invoke(Power / Data.PowerCapacity);

        if (Burstable)
        {
            if (Power < Data.PowerBurstMinimum)
            {
                Burstable = false;
                OnBurstableChanged?.Invoke(false);
            }
        }
        else
        {
            if (Power >= Data.PowerBurstMinimum)
            {
                Burstable = true;
                OnBurstableChanged?.Invoke(true);
            }
        }
	}
}