using Assets.Sources.Components.Time;
using NetData;

public class bladeStrongholdNewModelMessageUIProvider : IbladeStrongholdNewModelMessageUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladeStrongholdNewModelMessageUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool showOccup()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.OCCUPYING || _gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.CHANGEOCCUPY))
		{
			return true;
		}
		return false;
	}

	public bool showVisible()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && _gameRuleContext.bladeStrongholdNewData.data.State > StrongholdState.LOCKED)
		{
			return true;
		}
		return false;
	}

	public string changeImage()
	{
		string text = "occupying";
		int team = Contexts.sharedInstance.player.myPlayerEntity.GetTeam();
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			if (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.UNLOCKING)
			{
				text = "unlocking";
			}
			if (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.WAITINGOCCUPY)
			{
				text = "waitoccupy";
			}
			if (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.OCCUPYING || _gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.CHANGEOCCUPY)
			{
				text = ((_gameRuleContext.bladeStrongholdNewData.data.Occupy != team) ? "occupying" : "ouroccupying");
			}
			if (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.OCCUPIED || _gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.WAITFINISH)
			{
				text = ((_gameRuleContext.bladeStrongholdNewData.data.Occupy != team) ? "attack" : "defense");
			}
			return "/ui/GameGUIRes/bladeStrongholdNewModel/message/" + text;
		}
		return "";
	}

	public bool showTime()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && _gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.WAITFINISH)
		{
			return true;
		}
		return false;
	}

	public float showOccupProgress()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && _gameRuleContext.bladeStrongholdNewData.data.AllTime > 0)
		{
			return 1f - (float)_gameRuleContext.bladeStrongholdNewData.data.RemainTime / (float)_gameRuleContext.bladeStrongholdNewData.data.AllTime;
		}
		return 0f;
	}

	public bool IsshowNum()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && _gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.UNLOCKING)
		{
			return true;
		}
		return false;
	}

	public float showNum()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && _gameRuleContext.bladeStrongholdNewData.data.RemainTime > 0)
		{
			return _gameRuleContext.bladeStrongholdNewData.data.RemainTime / 1000;
		}
		return 0f;
	}
}
