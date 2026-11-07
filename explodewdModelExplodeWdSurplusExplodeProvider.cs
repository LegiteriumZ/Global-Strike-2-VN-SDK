using Assets.Sources.Components.Time;

public class explodewdModelExplodeWdSurplusExplodeProvider : IexplodewdModelExplodeWdSurplusExplodeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private string _branchUrl;

	private int _number;

	public explodewdModelExplodeWdSurplusExplodeProvider(Contexts contexts)
	{
		_branchUrl = "1";
		_number = 1;
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.hasExplodewdData && _gameRuleContext.explodewdData.SurplusData != null)
		{
			_branchUrl = _gameRuleContext.explodewdData.SurplusData.Time1.ToString();
			_number = _gameRuleContext.explodewdData.SurplusData.Time2;
		}
	}

	public string getBranchUrl()
	{
		return $"/ui/GameGUIRes/explodewdModel/message/{_branchUrl}";
	}

	public float getNumber()
	{
		return _number;
	}
}
