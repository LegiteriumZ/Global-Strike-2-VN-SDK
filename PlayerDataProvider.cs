using Assets.Sources.Components.Interface.Info.EventParticle;
using Assets.Sources.Components.Time;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.PlayerAnim;

public class PlayerDataProvider : IPlayerDataProvider, IDataProvider
{
	private PlayerEntity _player;

	private WeaponContext _weaponContext;

	private WeaponEntity _currentWeapon;

	private SceneObjectEntity _scene;

	private PlayerContext _playerContext;

	public void Init(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_playerContext = contexts.player;
	}

	public void SetPlayerEntity(PlayerEntity playerEnity)
	{
		_player = playerEnity;
	}

	public void SetSceneObjectEntity(SceneObjectEntity sceneEntity)
	{
		_scene = sceneEntity;
	}

	public int EffectLevel()
	{
		if (_player != null && _player.hasBasicInfo)
		{
			return _player.GetCurrentWeaponEffectLevel();
		}
		if (_scene != null && _scene.hasSceneWeapon && _scene.sceneWeapon.Current != null)
		{
			return _scene.sceneWeapon.Current.Level;
		}
		return 0;
	}

	public void OnFrame(TimeComponent time)
	{
		_currentWeapon = _weaponContext.currentWeaponEntity;
	}

	public int ViewAnimId()
	{
		if (_player != null && _player.hasViewAnim && _player.viewAnim.ViewAnimInfo != null)
		{
			return _player.viewAnim.ViewAnimInfo.StateId;
		}
		return 0;
	}

	public int ViewAnimCurrentTime()
	{
		if (_player != null && _player.hasViewAnim && _player.viewAnim.ViewAnimInfo != null)
		{
			return _player.viewAnim.RemainTime;
		}
		return 0;
	}

	public int ViewAnimTime()
	{
		if (_player != null && _player.hasCurrentWeapon && _player.currentWeapon.WeaponInfo != null && _player.hasViewAnim && _player.viewAnim.ViewAnimInfo != null)
		{
			return PlayerAnimationUtility.GetViewAnimDuration(_player.currentWeapon.WeaponInfo, _player.viewAnim.ViewAnimInfo.StateId);
		}
		return 0;
	}

	public int TorsoAnimId()
	{
		if (_player != null && _player.hasTorseAnim && _player.torseAnim.TorsoAnimInfo != null)
		{
			return _player.torseAnim.TorsoAnimInfo.StateId;
		}
		return 0;
	}

	public int LegAnimId()
	{
		if (_player != null && _player.hasLegAnim && _player.legAnim.LegsAnimInfo != null)
		{
			return _player.legAnim.LegsAnimInfo.StateId;
		}
		return 0;
	}

	public int TorsoAnimCurrentTime()
	{
		if (_player != null && _player.hasTorseAnim)
		{
			return _player.torseAnim.EclipsedTime;
		}
		return 0;
	}

	public int LegAnimCurrentTime()
	{
		if (_player != null && _player.hasLegAnim)
		{
			return _player.legAnim.ScaledEclipsedTime;
		}
		return 0;
	}

	public bool HasStatus(string[] a)
	{
		if (_player != null)
		{
			foreach (string s in a)
			{
				if (_player.HasStatus(int.Parse(s)))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool HasStatus(int statusId)
	{
		if (_player != null)
		{
			if (_player.HasStatus(statusId))
			{
				return true;
			}
			return false;
		}
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.HasStatus(statusId))
		{
			return true;
		}
		return false;
	}

	public int getStatusNum(int statusId)
	{
		if (_player != null && _player.skill.Status.ContainsKey(statusId))
		{
			return _player.skill.Status[statusId].Number;
		}
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.skill.Status.ContainsKey(statusId))
		{
			return _playerContext.cameraOwnerEntity.skill.Status[statusId].Number;
		}
		return 0;
	}

	public float getStatusScale(int statusId)
	{
		if (_player != null && _player.skill.Status.ContainsKey(statusId))
		{
			return _player.skill.Status[statusId].Scale;
		}
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.skill.Status.ContainsKey(statusId))
		{
			return _playerContext.cameraOwnerEntity.skill.Status[statusId].Scale;
		}
		return 0f;
	}

	public bool IsLeftFiring()
	{
		if (_player != null)
		{
			if (_player.hasFirstPersonUnityObjects)
			{
				return _player.firstPersonUnityObjects.LeftFireRemainTime > 0;
			}
			if (_player.hasThirdPersonUnityObjects)
			{
				return _player.thirdPersonUnityObjects.LeftFireRemainTime > 0;
			}
		}
		return false;
	}

	public bool IsRightFiring()
	{
		if (_player != null)
		{
			if (_player.hasFirstPersonUnityObjects)
			{
				return _player.firstPersonUnityObjects.RightFireRemainTime > 0;
			}
			if (_player.hasThirdPersonUnityObjects)
			{
				return _player.thirdPersonUnityObjects.RightFireRemainTime > 0;
			}
		}
		return false;
	}

	public bool HasPlayerStateFlag(int stateFlag)
	{
		if (_player == null)
		{
			return false;
		}
		return _player.HasState(stateFlag);
	}

	public int GetPlayerId()
	{
		return 0;
	}

	public int GetPlayerHp()
	{
		return (int)_player.basicInfo.Current.Hp;
	}

	public int GetWeaponState()
	{
		return PlayerUtility.GetBowWeaponState(_player);
	}

	public bool GetEventParticle(int eventId)
	{
		if (_player.hasEventParticle && _player.eventParticle.EventParticles != null && _player.eventParticle.EventParticles.ContainsKey(eventId))
		{
			return true;
		}
		return false;
	}

	public bool GetSameLevelEventParticle(int level)
	{
		if (_player.hasEventParticle && _player.eventParticle.EventParticles != null)
		{
			_player.eventParticle.EventLevel = 0;
			foreach (IEventParticle value in _player.eventParticle.EventParticles.Values)
			{
				if (value.GetLevel() == level)
				{
					if (value.hasRestarted)
					{
						value.hasRestarted = false;
						return true;
					}
					if ((_player.eventParticle.EventLevel & (1 << value.GetLevel())) != 0)
					{
						return true;
					}
					_player.eventParticle.EventLevel |= 1 << value.GetLevel();
				}
			}
		}
		return false;
	}

	public bool GetSpecalMode()
	{
		if (_player == _playerContext.myPlayerEntity)
		{
			if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
			{
				return _currentWeapon.basicInfo.Data.SpecialMode;
			}
			return false;
		}
		return _player.GetCurrentWeaponSubType() == 2;
	}
}
