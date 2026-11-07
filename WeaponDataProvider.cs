using Assets.Sources.Components.Time;

public class WeaponDataProvider : IWeaponDataProvider, IDataProvider
{
	private WeaponContext _weaponContext;

	private WeaponEntity _currentWeapon;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	public void Init(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
		_currentWeapon = _weaponContext.currentWeaponEntity;
	}

	public int GetKill()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.Kill;
		}
		return 0;
	}

	public int GetPower()
	{
		if (_currentWeapon != null && _currentWeapon.hasPower)
		{
			return _currentWeapon.power.Power;
		}
		return 0;
	}

	public int GetPower2()
	{
		if (_currentWeapon != null && _currentWeapon.hasPower)
		{
			return _currentWeapon.power.Power2;
		}
		return 0;
	}

	public int GetMaxPower()
	{
		if (_currentWeapon != null && _currentWeapon.hasPower)
		{
			return _currentWeapon.power.MaxPower;
		}
		return 0;
	}

	public int GetMaxPower2()
	{
		if (_currentWeapon != null && _currentWeapon.hasPower)
		{
			return _currentWeapon.power.MaxPower2;
		}
		return 0;
	}

	public int GetRpgMaxPower()
	{
		if (_currentWeapon != null && _currentWeapon.hasPower)
		{
			return _currentWeapon.power.RpgMaxPower;
		}
		return 0;
	}

	public int GetClip()
	{
		if (_currentWeapon != null && _currentWeapon.hasClip)
		{
			return _currentWeapon.clip.Clip;
		}
		return 0;
	}

	public int GetClip2()
	{
		if (_currentWeapon != null && _currentWeapon.hasClip)
		{
			return _currentWeapon.clip.Clip2;
		}
		return 0;
	}

	public int GetCarryClip()
	{
		if (_currentWeapon != null && _currentWeapon.hasClip)
		{
			return _currentWeapon.clip.CarryClip;
		}
		return 0;
	}

	public int GetCarryClip2()
	{
		if (_currentWeapon != null && _currentWeapon.hasClip)
		{
			return _currentWeapon.clip.CarryClip2;
		}
		return 0;
	}

	public long GetWeaponTimer1()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.WeaponTimer1;
		}
		return 0L;
	}

	public long GetNextSkillTimer()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.NextSkillTimer;
		}
		return 0L;
	}

	public int GetNextAttackTimer()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return (int)_currentWeapon.basicInfo.Data.NextAttackTimer;
		}
		return 0;
	}

	public int GetWeaponFlag()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.WeaponFlag;
		}
		return 0;
	}

	public int GetIcon1()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.Icon1;
		}
		return 0;
	}

	public int GetIcon2()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.Icon2;
		}
		return 0;
	}

	public int GetMaxIcon1()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.MaxIcon1;
		}
		return 0;
	}

	public int GetMaxIcon2()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.MaxIcon2;
		}
		return 0;
	}

	public int GetNextSecondaryAttackTimer()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return (int)_currentWeapon.basicInfo.Data.NextSecondaryAttackTimer;
		}
		return 0;
	}

	public int GetWeaponCd()
	{
		int raceType = 0;
		int subRaceType = 0;
		if (_battleRoomContext != null && _battleRoomContext.hasRoomData)
		{
			raceType = _battleRoomContext.roomData.Data.RaceType;
			subRaceType = _battleRoomContext.roomData.Data.SubRaceType;
		}
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo && _currentWeapon.basicInfo.Info.CdTimeLogic != null)
		{
			return _currentWeapon.basicInfo.Info.CdTimeLogic.GetCdTime(_currentWeapon.basicInfo.Data.WeaponName, raceType, subRaceType);
		}
		return 10000;
	}

	public int GetWeaponFov()
	{
		return 0;
	}

	public bool IsHoldWeapon(string a)
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.WeaponName.Equals(a);
		}
		return false;
	}

	public bool GetSpecalMode()
	{
		if (_currentWeapon != null && _currentWeapon.hasBasicInfo)
		{
			return _currentWeapon.basicInfo.Data.SpecialMode;
		}
		return false;
	}

	public int GetWeaponOwnerId()
	{
		return 0;
	}
}
