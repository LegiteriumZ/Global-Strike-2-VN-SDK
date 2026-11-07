using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

public class break_star_machinegun_legend2_WeaponExtraDefineProvider : Abstractbreak_star_machinegun_legend2_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	private bool _show;

	private int _showInt;

	private string _showName = "";

	private int _showTime;

	public override void OnFrame(TimeComponent time)
	{
		_weapon = _weaponContext.currentWeaponEntity;
		if (_show)
		{
			_showTime += time.FrameInterval;
			_showInt = _showTime / 50 % 11 + 1;
		}
	}

	public override bool isShow()
	{
		if (_weapon != null && _weapon.basicInfo.Info.Name.Equals("break_star_machinegun_legend2"))
		{
			string text = ((!_weapon.special.SpecialMode) ? "jianxl" : "qiangxl");
			if (RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType) && _gameRuleContext.tdSkillStateData.CurrentMp >= _weapon.basicInfo.Data.RpgMaxPower)
			{
				if (_showName != text)
				{
					_showName = text;
					_show = true;
					_showTime = 0;
				}
				return true;
			}
			if (((RuleUtilty.IsPveModel(_battleRoomContext.roomData.Data.RaceType) && !RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType)) || RuleUtilty.IsBioMode(_battleRoomContext.roomData.Data.RaceType)) && _weapon.basicInfo.Data.Power >= _weapon.basicInfo.Data.MaxPower)
			{
				if (_showName != text)
				{
					_showName = text;
					_show = true;
					_showTime = 0;
				}
				return true;
			}
		}
		_showName = "";
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
