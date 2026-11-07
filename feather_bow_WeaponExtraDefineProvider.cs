using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

public class feather_bow_WeaponExtraDefineProvider : Abstractfeather_bow_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	private PlayerEntity _player;

	public override void OnFrame(TimeComponent time)
	{
		_weapon = _weaponContext.currentWeaponEntity;
		_player = _playerContext.cameraOwnerEntity;
	}

	public override float getProgress()
	{
		if (_weapon == null || !_weapon.hasAttack || !_player.hasClientTime)
		{
			return 0f;
		}
		return (_weapon.attack.NextSecondaryAttackTimer - (float)_player.clientTime.ClientTime) / 25000f;
	}

	public override bool isShow()
	{
		if (!_battleRoomContext.hasRoomData || _weapon == null || !_weapon.hasAttack || !_player.hasClientTime)
		{
			return false;
		}
		if (RuleUtilty.IsBioMode(_battleRoomContext.roomData.Data.RaceType) || RuleUtilty.IsBigHeadModel(_battleRoomContext.roomData.Data.RaceType) || RuleUtilty.IsPveModel(_battleRoomContext.roomData.Data.RaceType))
		{
			if (_weapon.hasBasicInfo && _weapon.basicInfo.Data.WeaponName != "feather_bow")
			{
				return false;
			}
			if (_weapon.hasSpecial && (_weapon.special.EffectLevel & 4) == 0)
			{
				return false;
			}
			return _weapon.attack.NextSecondaryAttackTimer - (float)_player.clientTime.ClientTime > 0f;
		}
		return false;
	}
}
