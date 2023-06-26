using UnityEngine;

[CreateAssetMenu()]
public class WandData : ScriptableObject
{
	[field: SerializeField] public Sprite Sprite { get; private set; }
	[field: SerializeField] public float PowerCapacity { get; private set; }
	[field: SerializeField] public float PowerBurstMinimum { get; private set; }
	[field: SerializeField] public float PowerConsumption { get; private set; }
	[field: SerializeField] public float PowerProduce { get; private set; }
	[field: SerializeField] public PowerType PowerType { get; private set; }
}