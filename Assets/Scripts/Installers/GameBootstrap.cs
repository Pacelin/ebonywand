using UnityEngine;
using Zenject;

public class GameBootstrap : MonoInstaller
{
	public override void InstallBindings()
	{
		Cursor.visible = false;
	}
}
