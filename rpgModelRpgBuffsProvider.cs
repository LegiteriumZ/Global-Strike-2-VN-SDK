using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class rpgModelRpgBuffsProvider : IrpgModelRpgBuffsProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected List<SkillBuffData> _rpgBuffList;

	public rpgModelRpgBuffsProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_rpgBuffList == null && _gameRuleContext.hasRpgBuffs && _gameRuleContext.rpgBuffs.RpgBuffsList != null)
		{
			_rpgBuffList = _gameRuleContext.rpgBuffs.RpgBuffsList;
		}
	}

	public bool IsShow(int index)
	{
		if (_rpgBuffList == null)
		{
			return false;
		}
		return index < _rpgBuffList.Count;
	}

	public string SetImage(int index)
	{
		if (_rpgBuffList == null)
		{
			return "";
		}
		if (index < _rpgBuffList.Count)
		{
			return "/ui/GameGUIRes/halfLoadedRes/rpgplayerbuffer/" + _rpgBuffList[index].Skillid;
		}
		return "";
	}

	public bool IsTextShow(int index)
	{
		if (_rpgBuffList == null)
		{
			return false;
		}
		return index < _rpgBuffList.Count;
	}

	public string SetText(int index)
	{
		if (_rpgBuffList == null)
		{
			return "";
		}
		if (index < _rpgBuffList.Count)
		{
			return "Lv." + _rpgBuffList[index].Active;
		}
		return "";
	}
}
