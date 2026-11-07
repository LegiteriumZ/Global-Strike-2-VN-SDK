using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;

public class gunFightModelBagPreviewProvider : IgunFightModelBagPreviewProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	private ISSJJTimer _timer;

	public gunFightModelBagPreviewProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTSHOWBAG", out _timer);
	}

	public bool IsShow()
	{
		return _timer != null;
	}

	public string SetWeaponView(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.WeaponList == null || _gameRuleContext.gunFightData.WeaponList.Count == 0)
		{
			return "";
		}
		return string.Format("/weapon/{0}/ui/{0}", _gameRuleContext.gunFightData.WeaponList[index]);
	}

	public string SetWeaponName(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.WeaponList == null || _gameRuleContext.gunFightData.WeaponList.Count == 0)
		{
			return "";
		}
		return _gameRuleContext.gunFightData.WeaponList[index];
	}

	public bool IsShowView(int index)
	{
		if (_timer == null)
		{
			return false;
		}
		return _timer.LeftTime < 5000;
	}
}
