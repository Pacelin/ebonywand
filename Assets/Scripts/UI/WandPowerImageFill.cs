using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class WandPowerImageFill : MonoBehaviour
{
	[Inject] private WandPresenter _presenter;
	
	private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
	}
	private void OnEnable()
	{
		_presenter.Wand.OnPowerPercentChanged += Wand_OnPowerPercentChanged;
	}

	private void OnDisable()
	{
		_presenter.Wand.OnPowerPercentChanged -= Wand_OnPowerPercentChanged;
	}

	private void Wand_OnPowerPercentChanged(float percent)
	{
		_image.fillAmount = percent;
	}
}