using UnityEngine;
using Zenject;

public class WandInstaller : MonoInstaller
{
	[SerializeField] private WandData _ebonyWandData;
	[SerializeField] private WandData _glassWandData;

	[SerializeField] private WandPresenter _wandPresenter;
	[SerializeField] private WandActivator _wandActivator;

	public override void InstallBindings()
	{
		Container.BindInstance(new EbonyWand(_ebonyWandData)).AsSingle();
		Container.BindInstance(new GlassWand(_glassWandData)).AsSingle();
		Container.BindInstance(_wandPresenter).AsSingle();
		Container.BindInstance(_wandActivator).AsSingle();
	}
}