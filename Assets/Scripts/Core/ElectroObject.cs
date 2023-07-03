using PathCreation.Examples;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ElectroObject : ChargableObject
{
	public UnityEvent OnCharge;

	protected override void SetMinus()
	{
		OnCharge?.Invoke();
		Power = PowerType.No;
	}

	protected override void SetPlus() { }
	protected override void SetNoPower() { }
}
