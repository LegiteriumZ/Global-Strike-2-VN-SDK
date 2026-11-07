using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;

public class PlayerViewBaseShowEffectRenderSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _effectGroup;

	private IBattleRoom _battleRoomAdapter;

	public PlayerViewBaseShowEffectRenderSystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_effectGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.PlayerViewBaseShowRender, PlayerMatcher.FirstPersonUnityObjects).NoneOf(PlayerMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _effectGroup)
		{
			if (item.hasPlayerViewBaseShowRender && item.playerViewBaseShowRender.Render != null)
			{
				item.playerViewBaseShowRender.Render.Render(item, _battleRoomAdapter);
			}
		}
	}
}
