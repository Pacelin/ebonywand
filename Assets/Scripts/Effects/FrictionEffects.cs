using UnityEngine;

public class FrictionEffects : MonoBehaviour
{
	[SerializeField] private ParticleSystem[] _particles;
	[SerializeField] private float _distanceMultiplier = 1;
	[SerializeField] private float _minScale = 0;
	[SerializeField] private float _maxScale = 1;

	private bool _isPlay = false;

	private void OnEnable()
	{
		WandPowerProducer.OnStartProduce += Play;
		WandPowerProducer.OnProduce += SetScale;
		WandPowerProducer.OnStopProduce += Stop;
	}

	private void OnDisable()
	{
		WandPowerProducer.OnStartProduce -= Play;
		WandPowerProducer.OnProduce += SetScale;
		WandPowerProducer.OnStopProduce -= Stop;
	}

	public void Play()
	{
		if (_isPlay) return;

		_isPlay = true;
		foreach (var particle in _particles)
			particle.Play();
	}

	public void Stop()
	{
		if (!_isPlay) return;
		
		_isPlay = false;
		foreach (var particle in _particles)
			particle.Stop();
	}

	public void SetScale(float frictionDistance)
	{	
		var power = Mathf.Clamp(frictionDistance * _distanceMultiplier, _minScale, _maxScale);
		foreach (var particle in _particles)
			particle.transform.localScale = new Vector3(power, power, power);

	}
}
