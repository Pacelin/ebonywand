using System;
using UnityEngine;
using Zenject;

public class WandSwitcher : MonoBehaviour
{
	public event Action<Wand, Wand> OnSwitch;

	[SerializeField] private KeyCode _switchKey = KeyCode.Q;
	[SerializeField] private bool _canSwitch;
	
	private WandPresenter _presenter;
	private EbonyWand _ebonyWand;
	private GlassWand _glassWand;

	[Inject]
	private void Construct(WandPresenter presenter, EbonyWand ebonyWand, GlassWand glassWand)
	{
		_presenter = presenter;
		_ebonyWand = ebonyWand;
		_glassWand = glassWand;

		_presenter.SetWand(_ebonyWand);
	}

	private void Update()
	{
		if (!_canSwitch || !Input.GetKeyDown(_switchKey)) return;

        if (_presenter.Wand == _ebonyWand)
        {
			_presenter.SetWand(_glassWand);
			OnSwitch?.Invoke(_ebonyWand, _glassWand);
		}
		else
		{
			_presenter.SetWand(_ebonyWand);
			OnSwitch?.Invoke(_glassWand, _ebonyWand);
		}
	}
}