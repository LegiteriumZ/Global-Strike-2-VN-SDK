using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTowerLevelUpTypeHandler : ApcPacketHandler<RpgTowerArgsData>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgTowerLevelUpTypeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 304;
	}

	public override void Handle(RpgTowerArgsData data)
	{
		_gameRuleContext.rpgTower.TowerType = (TowerType)data.ShowType;
		_gameRuleContext.rpgTower.TowerId = data.TowerId;
		if (_gameRuleContext.rpgTower.LevelUpTypeDics == null)
		{
			_gameRuleContext.rpgTower.LevelUpTypeDics = new List<Dictionary<string, int>>();
		}
		_gameRuleContext.rpgTower.LevelUpTypeDics.Clear();
		_gameRuleContext.rpgTower.LevelUpTypeDes = data.StrList;
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeDetail;
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
			_gameRuleContext.rpgTower.LevelUpTypeDics.Add(dictionary);
		}
	}
}
