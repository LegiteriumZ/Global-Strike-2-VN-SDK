using Assets.Sources.Components.Time;

public class carrot_one_WeaponExtraDefineProvider : Abstractcarrot_one_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	private int remainTime = 500;

	private int _showTime;

	private int _time;

	private float _beforeTime;

	private int _showImageTime;

	private string _showImageName = "activeBg";

	private int _showImage;

	private bool _afterShowTime;

	private bool _afterGetTime;

	private int _afterTime = -1;

	private float _nowTime = 1f;

	private int _startTime = -1;

	private int _showAfterTime = -1;

	public override void OnFrame(TimeComponent time)
	{
		_weapon = _weaponContext.currentWeaponEntity;
		if (_weapon == null)
		{
			return;
		}
		if (_time != _weapon.basicInfo.Data.WeaponTimer1)
		{
			_time = (int)_weapon.basicInfo.Data.WeaponTimer1;
			_showTime = (int)_weapon.basicInfo.Data.WeaponTimer1;
			if (!_afterGetTime)
			{
				_startTime = 0;
				_afterGetTime = true;
				_afterTime = _time;
			}
		}
		_beforeTime = (float)(_showTime - _timeContext.time.ServerTime) / 24000f;
		if (_beforeTime <= 0f)
		{
			_beforeTime = 0f;
			_nowTime = 0f;
			_afterShowTime = false;
			_afterGetTime = false;
			_showAfterTime = -1;
			_showImageTime = 0;
		}
		if (_startTime >= 0)
		{
			_startTime += time.FrameInterval;
		}
		if (_startTime >= remainTime && !_afterShowTime)
		{
			_afterShowTime = true;
			_afterGetTime = false;
			_showAfterTime = _afterTime;
		}
		_showImageTime += time.FrameInterval;
		if (time.FrameInterval != 0)
		{
			_showImage = _showImageTime / time.FrameInterval % 7 + 1;
		}
	}

	public override float getProgress()
	{
		if (_showTime >= 0)
		{
			return _beforeTime;
		}
		return 1f;
	}

	public override float getProgress1()
	{
		if (_showAfterTime >= 0 && _afterShowTime)
		{
			_afterShowTime = false;
			_nowTime = (float)(_showAfterTime - _timeContext.time.ServerTime) / 24000f;
			_startTime = 0;
			if (_nowTime <= 0f)
			{
				_nowTime = 0f;
			}
		}
		return _nowTime;
	}

	public override string showImage()
	{
		if (_weapon != null)
		{
			return "/weapon/" + _weapon.basicInfo.Data.WeaponName + "/ui/" + _showImageName + _showImage;
		}
		return "";
	}
}
