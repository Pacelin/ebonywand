using UnityEngine;

[CreateAssetMenu]
public class CameraPoint : ScriptableObject
{
	[field: SerializeField] public Vector2 Position { get; private set; }
}
