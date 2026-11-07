using System.Collections.Generic;
using Assets.Sources.Components.Time;

public class rpgModelextraordinaryProvider : IrpgModelextraordinaryProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private Dictionary<int, string> atfTable = new Dictionary<int, string>();

	private List<string> atfList = new List<string>();

	private List<int> valueList = new List<int>();

	private List<int> showList = new List<int>();

	private PlayerContext _playerContext;

	public rpgModelextraordinaryProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		atfTable.Add(1, "/ui/GameGUIRes/rpgModel/extraordinary/BeDamageDecBuff");
		atfTable.Add(2, "/ui/GameGUIRes/rpgModel/extraordinary/BeAttackCritDecBuff");
		atfTable.Add(3, "/ui/GameGUIRes/rpgModel/extraordinary/BeAttackCritRatioDecBuff");
		atfTable.Add(4, "/ui/GameGUIRes/rpgModel/extraordinary/RecoveDecHaloBuff");
		atfTable.Add(5, "/ui/GameGUIRes/rpgModel/extraordinary/DamageAddBuff");
		atfTable.Add(6, "/ui/GameGUIRes/rpgModel/extraordinary/extraHpDamageBuff");
	}

	public void OnFrame(TimeComponent time)
	{
		showList.Clear();
		if (_playerContext != null && _playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.basicInfo != null && _playerContext.myPlayerEntity.basicInfo.Current.AntiBuffs != null)
		{
			for (int i = 0; i < _playerContext.myPlayerEntity.basicInfo.Current.AntiBuffs.Entrys.Count; i++)
			{
				showList.Add(i);
				atfList.Add(atfTable[_playerContext.myPlayerEntity.basicInfo.Current.AntiBuffs.Entrys[i].Key]);
				valueList.Add(_playerContext.myPlayerEntity.basicInfo.Current.AntiBuffs.Entrys[i].Value);
			}
		}
	}

	public string SetImage(int index)
	{
		if (showList.Count > index)
		{
			return atfList[showList[index]];
		}
		return "";
	}

	public float SetValue(int index)
	{
		if (showList.Count > index)
		{
			return valueList[showList[index]];
		}
		return index;
	}

	public bool SetShow(int index)
	{
		if (showList.Count > index)
		{
			return true;
		}
		return false;
	}
}
