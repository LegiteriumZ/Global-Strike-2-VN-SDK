using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;

public class PlayerBaseShowEffectRenderSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _effectGroup;

	private IBattleRoom _battleRoomAdapter;

	public PlayerBaseShowEffectRenderSystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_effectGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.PlayerBaseShowRender).NoneOf(PlayerMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _effectGroup)
		{
			if (item.hasPlayerBaseShowRender && item.playerBaseShowRender.Render != null)
			{
				item.playerBaseShowRender.Render.Render(item, _battleRoomAdapter);
			}
		}
	}
}
