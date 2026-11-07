using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTowerLevelUpPropertyHandler : ApcPacketHandler<RpgTowerArgsData>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgTowerLevelUpPropertyHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 305;
	}

	public override void Handle(RpgTowerArgsData data)
	{
		_gameRuleContext.rpgTower.TowerType = (TowerType)data.ShowType;
		_gameRuleContext.rpgTower.LevelUpProterty = data.StrList;
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertyDetail;
		_gameRuleContext.rpgTower.TowerId = data.TowerId;
		if (_gameRuleContext.rpgTower.LevelUpPropDics == null)
		{
			_gameRuleContext.rpgTower.LevelUpPropDics = new List<Dictionary<string, int>>();
		}
		_gameRuleContext.rpgTower.LevelUpPropDics.Clear();
		for (int i = 0; i < data.StrList.Count; i++)
		{
			this.Info(i + " > " + data.StrList[i]);
			string[] array = data.StrList[i].Replace("{", "").Replace("}", "").Trim()
				.Split(',');
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				dictionary.Add(text.Split(':')[0], int.Parse(text.Split(':')[1]));
			}
			_gameRuleContext.rpgTower.LevelUpPropDics.Add(dictionary);
		}
	}
}
