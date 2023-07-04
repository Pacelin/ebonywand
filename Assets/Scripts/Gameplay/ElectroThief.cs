using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class ElectroThief : MonoBehaviour
{
    [Inject] private WandPresenter _presenter;
	private void OnMouseEnter()
	{
		_presenter.ActiveWand.ResetPower();
	}
}
