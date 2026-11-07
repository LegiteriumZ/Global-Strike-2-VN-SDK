using Assets.Sources.Framework;
using SSJJUserCmd;

public class PlayerEffectLevelUpdateInitSystem : IPredicateSystem
{
	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	public string LastErrorMsg { get; private set; }

	public PlayerEffectLevelUpdateInitSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_playerContext = contexts.player;
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.hasBasicInfo && _playerContext.cameraOwnerEntity.basicInfo.Current != null && _weaponContext.currentWeaponEntity != null && _weaponContext.currentWeaponEntity.hasSpecial)
		{
			_playerContext.cameraOwnerEntity.basicInfo.Current.CurrentWeaponEffectLevel = _weaponContext.currentWeaponEntity.special.EffectLevel;
		}
	}

	public void SavePredicationState(int cmdSeq)
	{
	}

	public bool HasPredicatonError(int cmdSeq)
	{
		return false;
	}

	public void OnPredicatoinError(int cmdSeq)
	{
	}

	public void OnPredicatoinSucc(int cmdSeq)
	{
	}

	public bool ShouldResetAll()
	{
		return false;
	}
}
