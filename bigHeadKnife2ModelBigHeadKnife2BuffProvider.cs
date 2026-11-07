using Assets.Sources.Components.Time;

public class bigHeadKnife2ModelBigHeadKnife2BuffProvider : IbigHeadKnife2ModelBigHeadKnife2BuffProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	public bigHeadKnife2ModelBigHeadKnife2BuffProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetProgress()
	{
		if (_timeContext.hasCommonTimer && _timeContext.commonTimer.CommonTimer.TryGetValue("BIGHEADKNIFE2BUFF", out var value))
		{
			return 1f - (float)value.LeftTime / (float)value.Length;
		}
		return 1f;
	}
}
