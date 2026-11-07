using Assets.Sources.Components.Time;
using NetData;

public class freeRpg_107000ModelChooseModeProvider : IfreeRpg_107000ModelChooseModeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelChooseModeProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsShowChooseMode()
	{
		return _gameRuleContext.mystery.IsShowSelectMode;
	}

	public float GoNewModel()
	{
		StringData message = new StringData
		{
			Data = "1"
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(118, message);
		return 0f;
	}

	public float CancelGoMode()
	{
		_gameRuleContext.mystery.IsShowSelectMode = false;
		return 0f;
	}
}
