using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class PowerGenerator : MonoBehaviour
{
    [Inject] private WandPresenter _presenter;

	private void OnMouseOver() =>
		_presenter.ActiveWand.SetFullPower();
}
