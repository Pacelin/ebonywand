using UnityEngine;

public class WandPresenter : MonoBehaviour
{
	public Wand Wand { get; private set; }

	[SerializeField] private KeyCode _burstKeyCode = KeyCode.Mouse1;
	[SerializeField] private SpriteRenderer _wandRenderer;
	[SerializeField] private WandActivator _wandCursor;

	private void Update()
	{
		Wand.ConsumpPower(Time.deltaTime);

		if (Input.GetKeyDown(_burstKeyCode))
			Wand.Burst();
	}

	public void SetWand(Wand wand)
	{
		Wand = wand;
		_wandRenderer.sprite = Wand.Data.Sprite;
	}
}