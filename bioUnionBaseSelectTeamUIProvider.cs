using Assets.Sources.Components.Time;

public class bioUnionBaseSelectTeamUIProvider : IbioUnionBaseSelectTeamUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playeContext;

	protected BattleServerContext _battleServer;

	private int mouseOverIndex = -1;

	public bioUnionBaseSelectTeamUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playeContext = contexts.player;
		_battleServer = contexts.battleServer;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkRootShow()
	{
		if (!_playeContext.myPlayerEntity.HasState(131072))
		{
			return false;
		}
		return _gameRuleContext.bioUnionBaseData.SelectTeamPanelShow;
	}

	public float clickHandleByIndex(int index)
	{
		_battleServer.battleServer.Server.SendTcpMessage(161, index + 1);
		_gameRuleContext.bioUnionBaseData.SelectTeamPanelShow = false;
		return 0f;
	}

	public bool checkOverShow(int index)
	{
		return mouseOverIndex == index;
	}

	public float mouseOver0()
	{
		mouseOverIndex = 0;
		return 0f;
	}

	public float mouseOut0()
	{
		mouseOverIndex = -1;
		return 0f;
	}

	public float mouseOver1()
	{
		mouseOverIndex = 1;
		return 0f;
	}

	public float mouseOut1()
	{
		mouseOverIndex = -1;
		return 0f;
	}
}
