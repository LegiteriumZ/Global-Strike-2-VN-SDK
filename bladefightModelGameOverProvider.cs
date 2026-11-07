using Assets.Sources.Components.Time;

public class bladefightModelGameOverProvider : IbladefightModelGameOverProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelGameOverProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameRuleContext.bladeFightGameOverData.time -= time.FrameInterval;
	}

	public bool isReturnLobby()
	{
		return _gameRuleContext.bladeFightGameOverData.ranking <= 2;
	}

	public bool isShow()
	{
		return _gameRuleContext.bladeFightGameOverData.time > 0;
	}

	public bool isWin()
	{
		return _gameRuleContext.bladeFightGameOverData.ranking == 1;
	}

	public float getRanking()
	{
		return _gameRuleContext.bladeFightGameOverData.ranking;
	}

	public float getKillNum()
	{
		return _gameRuleContext.bladeFightGameOverData.killNum;
	}

	public float getDamage()
	{
		return _gameRuleContext.bladeFightGameOverData.damage;
	}

	public float getReturnLobbyTime()
	{
		return _gameRuleContext.bladeFightGameOverData.time / 1000;
	}
}
