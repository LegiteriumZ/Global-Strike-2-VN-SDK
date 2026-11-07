using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class MechWarriorInfoHandler : ApcPacketHandler<MechWarriorLvUpData>
{
	private GameRuleContext _gameRuleContext;

	public MechWarriorInfoHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 94;
	}

	public override void Handle(MechWarriorLvUpData data)
	{
		if (data.ChargeEffect)
		{
			_gameRuleContext.mechwarriorHeroGrowupData.EnergyPlayerName = data.ChargeName;
			NotifyManager.ForceInvoke(62);
			_gameRuleContext.mechwarriorHeroGrowupData.GetEnergy = data.ChargeEffect;
			NotifyManager.ForceInvoke(63);
		}
		else
		{
			_gameRuleContext.mechwarriorHeroGrowupData.CurrentEnergy = data.Energy;
			_gameRuleContext.mechwarriorHeroGrowupData.MaxEnergy = data.MaxEnergy;
			_gameRuleContext.mechwarriorHeroGrowupData.EnergySpeed = data.EnergySpeed;
			_gameRuleContext.mechwarriorHeroGrowupData.CurrentExp = data.Exp;
			_gameRuleContext.mechwarriorHeroGrowupData.MaxExp = data.MaxExp;
			_gameRuleContext.mechwarriorHeroGrowupData.Lv = data.Lv;
		}
	}
}
