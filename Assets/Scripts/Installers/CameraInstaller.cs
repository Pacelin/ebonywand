using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(Camera.main).AsSingle();
    }
}