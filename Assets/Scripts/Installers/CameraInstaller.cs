using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraController _controller;

	public override void InstallBindings()
    {
        Container.BindInstance(_camera).AsSingle().NonLazy();
        Container.BindInstance(_controller).AsSingle().NonLazy();
    }
}