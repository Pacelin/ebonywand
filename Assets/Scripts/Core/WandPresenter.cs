using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class WandPresenter : MonoBehaviour
{
	public Wand ActiveWand { get; private set; }

	[SerializeField] private SpriteRenderer _wandRenderer;

	[Header("Events")]
	public FloatUnityEvent OnWandPowerPercentChanged = new FloatUnityEvent();
	public BoolUnityEvent OnWandBurstableChanged = new BoolUnityEvent();
	public UnityEvent OnWandBurst = new UnityEvent();

	[Inject] private EbonyWand _ebonyWand;
	[Inject] private GlassWand _glassWand;
	
	private void Awake() => ActiveWand = _ebonyWand;

	private void OnEnable() => Subscribe(ActiveWand);
	private void OnDisable() =>	Unsubscribe(ActiveWand);

	private void Update() => ActiveWand.ConsumpPower(Time.deltaTime);

	public void SwitchWand()
	{
		Unsubscribe(ActiveWand);
		
		ActiveWand = ActiveWand == _ebonyWand ? _glassWand : _ebonyWand;
		_wandRenderer.sprite = ActiveWand.Data.Sprite;
		
		Subscribe(ActiveWand);
	}

	private void Subscribe(Wand wand)
	{
		wand.OnPowerPercentChanged += Wand_OnPowerPercentChanged;
		wand.OnBurst += Wand_OnBurst;
		wand.OnBurstableChanged += Wand_OnBurstableChanged;
	}

	private void Unsubscribe(Wand wand)
	{
		wand.OnPowerPercentChanged -= Wand_OnPowerPercentChanged;
		wand.OnBurst -= Wand_OnBurst;
		wand.OnBurstableChanged -= Wand_OnBurstableChanged;
	}

	private void Wand_OnBurstableChanged(bool burstable) => OnWandBurstableChanged.Invoke(burstable);
	private void Wand_OnBurst() => OnWandBurst.Invoke();
	private void Wand_OnPowerPercentChanged(float precent) => OnWandPowerPercentChanged.Invoke(precent);
}