using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UpdateValueHandler : ApcPacketHandler<UpdateValueData>
{
	private readonly GameRuleContext _gameRuleContext;

	public UpdateValueHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 115;
	}

	public override void Handle(UpdateValueData data)
	{
		if (data.Type == ValueType.ENEGERXP)
		{
			_gameRuleContext.rpgSkillStateData.CurrentXpEnergy = data.Value;
			_gameRuleContext.rpgSkillStateData.TotalXpEnergy = data.MaxValue;
			_gameRuleContext.rpgSkillStateData.IsXpEnergyAddByKill = false;
		}
		else if (data.Type == ValueType.ENEGERXPBYKILL)
		{
			_gameRuleContext.rpgSkillStateData.CurrentXpEnergy = data.Value;
			_gameRuleContext.rpgSkillStateData.TotalXpEnergy = data.MaxValue;
			_gameRuleContext.rpgSkillStateData.IsXpEnergyAddByKill = true;
		}
		else if (data.Type == ValueType.CANCHANGEBAGCOUNT)
		{
			_gameRuleContext.rpgSkillStateData.CanChangeBagCount = data.Value;
		}
		else if (data.Type == ValueType.LASTDEFENDERMONEY)
		{
			_gameRuleContext.rpgSkillStateData.Money = data.Value;
		}
		else if (data.Type == ValueType.TEAMRACEFUHUOBI)
		{
			_gameRuleContext.rpgSkillStateData.Item = data.Value;
		}
		else if (data.Type == ValueType.RPGTOWERMONEY)
		{
			_gameRuleContext.rpgSkillStateData.RpgTowerMoney = data.Value;
		}
		else if (data.Type == ValueType.RPGLOOTMONEY)
		{
			_gameRuleContext.rpgCommon.Max = data.MaxValue;
			_gameRuleContext.rpgCommon.Current = data.Value;
		}
	}
}
