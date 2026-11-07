using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.BulletHole;

public class BulletHolePlayBackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _bulletHoleObjects;

	public BulletHolePlayBackSystem(Contexts contexts)
	{
	}

	public void OnPlayback()
	{
	}
}
