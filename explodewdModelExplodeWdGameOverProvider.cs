using Assets.Sources.Components.Time;

public class explodewdModelExplodeWdGameOverProvider : IexplodewdModelExplodeWdGameOverProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoom;

	public explodewdModelExplodeWdGameOverProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoom = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isGameOver()
	{
		return _battleRoom.gameOver.IsGameOver;
	}

	public string getGameOverUrl()
	{
		_ = _battleRoom.gameOver.IsWin;
		return "/ui/GameGUIRes/explodewdModel/gameover/win";
	}
}
