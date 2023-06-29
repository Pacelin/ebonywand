using Zenject;

public class ChatInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new Chat()).AsSingle();
    }
}