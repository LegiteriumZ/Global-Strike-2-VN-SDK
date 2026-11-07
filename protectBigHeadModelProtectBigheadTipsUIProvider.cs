using Assets.Sources.Components.Time;

public class protectBigHeadModelProtectBigheadTipsUIProvider : IprotectBigHeadModelProtectBigheadTipsUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public protectBigHeadModelProtectBigheadTipsUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.protectBigHeadCareer.tipShowTime > 0f)
		{
			_gameRuleContext.protectBigHeadCareer.tipShowTime -= time.FrameInterval;
		}
	}

	public bool tipShow()
	{
		return _gameRuleContext.protectBigHeadCareer.tipShowTime > 0f;
	}
}
