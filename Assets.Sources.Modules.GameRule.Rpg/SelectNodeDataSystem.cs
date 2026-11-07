using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.GameRule.Rpg;

public class SelectNodeDataSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public SelectNodeDataSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		SelectItemList selectItemList = _gameRuleContext.selectNodeData.SelectItemList;
		if (selectItemList == null)
		{
			return;
		}
		for (int i = 0; i < selectItemList.ItemList.Count; i++)
		{
			if (selectItemList.ItemList[i].Locked)
			{
				selectItemList.ItemList[i].LockLeftTime -= _timeComponent.FrameInterval;
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsRpgPvp();
	}
}
