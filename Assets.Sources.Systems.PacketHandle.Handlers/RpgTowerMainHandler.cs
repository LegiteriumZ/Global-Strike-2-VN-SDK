using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTowerMainHandler : ApcPacketHandler<RpgTowerArgsData>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgTowerMainHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 303;
	}

	public override void Handle(RpgTowerArgsData data)
	{
		_gameRuleContext.rpgTower.TowerType = (TowerType)data.ShowType;
		_gameRuleContext.rpgTower.TowerId = data.TowerId;
		_gameRuleContext.rpgTower.SaleCost = data.SaleCost;
		_gameRuleContext.rpgTower.MoveCost = data.MoveCost;
		if (_gameRuleContext.rpgTower.TowerType == TowerType.Lampstand)
		{
			_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeMain;
		}
		else
		{
			_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertyMain;
			_gameRuleContext.rpgTower.LevelUpProtertyHealth = data.TowerInfo.Hp;
			_gameRuleContext.rpgTower.LevelUpProtertyAttackDamage = data.TowerInfo.AttackDamage;
			_gameRuleContext.rpgTower.LevelUpProtertyCdTime = data.TowerInfo.NextSkillUsingTime;
			_gameRuleContext.rpgTower.LevelUpProtertyPower = data.TowerInfo.Power;
			_gameRuleContext.rpgTower.LevelUpProtertyIsFullSkill = data.TowerInfo.SkillLv == data.TowerInfo.SkillTotalLv;
		}
		this.Info("ShowType > " + _gameRuleContext.rpgTower.TowerType);
	}
}
