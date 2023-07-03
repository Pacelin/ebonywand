using UnityEngine;

public class Indicator : MonoBehaviour
{
	public bool Enabled { get; private set; }

	[SerializeField] private GameObject _red;
	[SerializeField] private GameObject _green;

	[SerializeField] private bool _redOnAwake;

	private void Awake() => SetIndicator(_redOnAwake);
	public void Enable() => SetIndicator(false);
	public void Disable() => SetIndicator(true);

	private void SetIndicator(bool red)
	{
		_red.SetActive(red);
		_green.SetActive(!red);
		Enabled = !red;
	}
}
