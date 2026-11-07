using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerHpBar;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Utils.Player;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerHpBar;

public class PlayerHpBarDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private IBattleRoom _battleRoomAdapter;

	public PlayerHpBarDestroySystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerHpBar));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(item.playerHpBar.Cid);
			if (playerByCid == null)
			{
				item.isDestroy = true;
			}
			else if (!PlayerHpBarEffectInfo.Instance.IsEffectOn(playerByCid, _battleRoomAdapter))
			{
				item.isDestroy = true;
			}
		}
	}
}
