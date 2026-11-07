using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerAnimThreadDispatchSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _roomContext;

	private IGroup<PlayerEntity> _group;

	public PlayerAnimThreadDispatchSystem(Contexts contexts)
	{
		_roomContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.EntityId, PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnPlayback()
	{
		int raceType = _roomContext.roomData.Data.RaceType;
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity == null || !cameraOwnerEntity.hasNormalTrace || RuleUtilty.IsPve(raceType))
		{
			return;
		}
		foreach (PlayerEntity item in _group)
		{
			bool multiThreadSupport = !item.isCameraOwner && !cameraOwnerEntity.normalTrace.BulletPreliminaryTargets.Contains(item.entityId.Value);
			item.thirdPersonUnityObjects.Animator.SetMultiThreadSupport(multiThreadSupport);
		}
	}
}
