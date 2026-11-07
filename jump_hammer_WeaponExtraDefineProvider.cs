using Assets.Sources.Components.Time;

public class jump_hammer_WeaponExtraDefineProvider : Abstractjump_hammer_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	private PlayerEntity _player;

	private bool _show;

	private int _showInt;

	private string _showName = "TTC_000";

	private int _showTime;

	public override void OnFrame(TimeComponent time)
	{
		_weapon = _weaponContext.currentWeaponEntity;
		_player = _playerContext.cameraOwnerEntity;
		if (_show)
		{
			_showTime += time.FrameInterval;
			_showInt = _showTime / 50 % 11 + 1;
		}
	}

	public override bool isShow()
	{
		if ((_weapon.basicInfo.Data.EffectLevel & 0x20) > 0 && _weapon.basicInfo.Data.NextSkillTimer <= _player.clientTime.ClientTime)
		{
			if (_showInt == 0)
			{
				_show = true;
				_showTime = 0;
				_showInt = 1;
			}
			return true;
		}
		_showInt = 0;
		_show = false;
		return false;
	}

	public override string showImage()
	{
		if (_show && _weapon != null)
		{
			return "/weapon/" + _weapon.basicInfo.Data.WeaponName + "/ui/" + _showName + _showInt;
		}
		return "";
	}
}
