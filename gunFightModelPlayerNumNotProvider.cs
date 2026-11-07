using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;

public class gunFightModelPlayerNumNotProvider : IgunFightModelPlayerNumNotProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	private ISSJJTimer _timer;

	public gunFightModelPlayerNumNotProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTPLAYERNUMNOT", out _timer);
	}

	public float SetPlayerNum(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.AlivePlayer == null || _gameRuleContext.gunFightData.NotAlivePlayer.Count == 0)
		{
			return 0f;
		}
		return _gameRuleContext.gunFightData.NotAlivePlayer[index];
	}

	public bool IsShow()
	{
		return _timer != null;
	}
}
