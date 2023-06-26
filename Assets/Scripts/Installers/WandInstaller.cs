using UnityEngine;
using Zenject;

public class WandInstaller : MonoInstaller
{
	[SerializeField] private WandData _ebonyWandData;
	[SerializeField] private WandData _glassWandData;
	[SerializeField] private WandPresenter _wandPresenter;
	[SerializeField] private WandSwitcher _wandSwitcher;
	[SerializeField] private WandActivator _wandCursor;

	public override void InstallBindings()
	{
		Container.BindInstance(new EbonyWand(_ebonyWandData)).AsSingle();
		Container.BindInstance(new GlassWand(_glassWandData)).AsSingle();
		Container.BindInstance(_wandPresenter).AsSingle();
		Container.BindInstance(_wandSwitcher).AsSingle();
		Container.BindInstance(_wandCursor).AsSingle();
	}
}