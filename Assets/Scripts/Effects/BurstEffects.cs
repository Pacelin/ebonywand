using UnityEngine;
using Zenject;

public class BurstEffects : MonoBehaviour
{
	[SerializeField] private ParticleSystem[] _particles;

	[Inject] private WandPresenter _wandPresenter;

	private void OnEnable() =>
		_wandPresenter.OnWandBurst.AddListener(Burst);
	private void OnDisable() =>
		_wandPresenter.OnWandBurst.RemoveListener(Burst);

	private void Burst()
	{
		foreach (var particle in _particles)
			particle.Play();
	}
}