using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.EntityDestroy;

public class PlayerEntityDestroySystem : IEntityDestroySystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerEntityDestroySystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Destroy));
	}

	public void OnEntityDestroy()
	{
		foreach (PlayerEntity item in _group)
		{
			item.Destroy();
		}
	}
}
