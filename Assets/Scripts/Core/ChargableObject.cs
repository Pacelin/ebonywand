using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ChargableObject : MonoBehaviour
{
    public PowerTypeUnityEvent OnPowerTypeChanged = new PowerTypeUnityEvent();
    public PowerType Power { get; private set; }

    [Header("Charge Settings")]
    [field: SerializeField] public PowerType CanBeChargedBy;
    [Space]
    [SerializeField] private PowerType _powerOnAwake;

	private void Start()
	{
        Charge(_powerOnAwake);
	}

	public void Charge(PowerType powerType)
    {
        if (powerType == PowerType.No ||
            powerType == PowerType.Both ||
            CanBeChargedBy == PowerType.No ||
            Power == powerType) return;

        if (CanBeChargedBy == PowerType.Both)
        {
            if (Power == PowerType.No)
                Power = powerType;
            else
                Power = PowerType.No;
        }
        else
        {
            if (CanBeChargedBy != powerType) return;
            Power = powerType;
        }

        if (Power == PowerType.No) SetNoPower();
        else if (Power == PowerType.Plus) SetPlus();
        else if (Power == PowerType.Minus) SetMinus();
    }

    protected abstract void SetMinus();
	protected abstract void SetPlus();
	protected abstract void SetNoPower();
}
