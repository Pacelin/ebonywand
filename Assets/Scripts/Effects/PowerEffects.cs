using DigitalRuby.LightningBolt;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

public class PowerEffects : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Light2D _light;
	[Space]
	[SerializeField] private ParticleSystem _particle1;
	[SerializeField] private ParticleSystem _particle2;
	[Space]
	[SerializeField] private LightningBoltScript _lightningBolt1;
	[SerializeField] private LightningBoltScript _lightningBolt2;
	[SerializeField] private LineRenderer _lightningBoltLine1;
	[SerializeField] private LineRenderer _lightningBoltLine2;

	[Header("Settings")]
	[SerializeField] private AnimationCurve _lightIntensityCurve;
	[Space]
	[SerializeField] private AnimationCurve _particlesRateCurve1;
	[SerializeField] private AnimationCurve _particlesRateCurve2;
	[Space]
	[SerializeField] private Vector3 _boltAnchorFrom;
	[SerializeField] private Vector3 _boltAnchorTo;
	[SerializeField] private AnimationCurve _boltAnimationTimeCurve;
	[Space]
	[SerializeField] private Color _boltColorFrom;
	[SerializeField] private Color _boltColorTo;

	private ParticleSystem.EmissionModule _emissionModule1;
	private ParticleSystem.EmissionModule _emissionModule2;

	private float _boltAnimationTime;

	[Inject] private WandPresenter _wandPresenter;

	private void Awake()
	{
		_emissionModule1 = _particle1.emission;
		_emissionModule2 = _particle2.emission;

		UpdateEffects(0);
	}
		
	private void OnEnable()
	{
		StartCoroutine(BoltAnimation());
		_wandPresenter.OnWandPowerPercentChanged.AddListener(UpdateEffects);
	}
	private void OnDisable()
	{
		_wandPresenter.OnWandPowerPercentChanged.RemoveListener(UpdateEffects);
	}

	private void UpdateEffects(float powerPercent)
	{
		_light.intensity = _lightIntensityCurve.Evaluate(powerPercent);

		_boltAnimationTime = _boltAnimationTimeCurve.Evaluate(powerPercent);

		var boltColor = Color.Lerp(_boltColorFrom, _boltColorTo, powerPercent);
		_lightningBoltLine1.startColor = boltColor;
		_lightningBoltLine1.endColor = boltColor;
		_lightningBoltLine2.startColor = boltColor;
		_lightningBoltLine2.endColor = boltColor;

		_emissionModule1.rateOverTime = 
			new ParticleSystem.MinMaxCurve(_particlesRateCurve1.Evaluate(powerPercent));
		_emissionModule2.rateOverTime =
			new ParticleSystem.MinMaxCurve(_particlesRateCurve2.Evaluate(powerPercent));
	}

	private IEnumerator BoltAnimation()
	{
		while(true)
		{
			for (float t = 0; t < _boltAnimationTime; t += Time.deltaTime)
			{
				var pos1 = Vector3.Lerp(_boltAnchorFrom, _boltAnchorTo, t / _boltAnimationTime);
				var pos2 = Vector3.Lerp(_boltAnchorTo, _boltAnchorFrom, t / _boltAnimationTime);
				_lightningBolt1.StartObject.transform.localPosition = pos1;
				_lightningBolt1.EndObject.transform.localPosition = pos2;
				_lightningBolt2.StartObject.transform.localPosition = pos2;
				_lightningBolt2.EndObject.transform.localPosition = pos1;
				yield return null;
			}
				
			for (float t = 0; t < _boltAnimationTime; t += Time.deltaTime)
			{
				var pos1 = Vector3.Lerp(_boltAnchorFrom, _boltAnchorTo, t / _boltAnimationTime);
				var pos2 = Vector3.Lerp(_boltAnchorTo, _boltAnchorFrom, t / _boltAnimationTime);
				_lightningBolt1.StartObject.transform.localPosition = pos2;
				_lightningBolt1.EndObject.transform.localPosition = pos1;
				_lightningBolt2.StartObject.transform.localPosition = pos1;
				_lightningBolt2.EndObject.transform.localPosition = pos2;
				yield return null;
			}
		}
	}
}