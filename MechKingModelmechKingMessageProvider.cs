using Assets.Sources.Components.Time;

public class MechKingModelmechKingMessageProvider : ImechKingModelmechKingMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int SHOW_TIME;

	private int SHOW_TIME_HUAMN;

	public MechKingModelmechKingMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		SHOW_TIME -= time.FrameInterval;
		SHOW_TIME_HUAMN -= time.FrameInterval;
	}

	public bool isShowHuamn()
	{
		if (_gameRuleContext.mechKingData._showmessagehuamn)
		{
			_gameRuleContext.mechKingData._showmessagehuamn = false;
			SHOW_TIME_HUAMN = 3000;
		}
		return SHOW_TIME_HUAMN > 0;
	}

	public bool isShowMech()
	{
		if (_gameRuleContext.mechKingData._showmessagemech)
		{
			_gameRuleContext.mechKingData._showmessagemech = false;
			SHOW_TIME = 3000;
		}
		return SHOW_TIME > 0;
	}
}
