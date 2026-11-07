using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponFirePlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _viewEntities;

	private IGroup<PlayerEntity> _thirdEntities;

	private WeaponContext _weaponContext;

	private TimeComponent _time;

	public PlayerWeaponFirePlaybackSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_time = contexts.time.time;
		_viewEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.CurrentWeapon, PlayerMatcher.BasicInfo));
		_thirdEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.CurrentWeapon));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity viewEntity in _viewEntities)
		{
			if (viewEntity.firstPersonUnityObjects.LeftFireRemainTime > 0)
			{
				viewEntity.firstPersonUnityObjects.LeftFireRemainTime -= _time.FrameInterval;
			}
			if (viewEntity.firstPersonUnityObjects.RightFireRemainTime > 0)
			{
				viewEntity.firstPersonUnityObjects.RightFireRemainTime -= _time.FrameInterval;
			}
		}
		foreach (PlayerEntity thirdEntity in _thirdEntities)
		{
			if (thirdEntity.thirdPersonUnityObjects.LeftFireRemainTime > 0)
			{
				thirdEntity.thirdPersonUnityObjects.LeftFireRemainTime -= _time.FrameInterval;
			}
			if (thirdEntity.thirdPersonUnityObjects.RightFireRemainTime > 0)
			{
				thirdEntity.thirdPersonUnityObjects.RightFireRemainTime -= _time.FrameInterval;
			}
		}
	}
}
