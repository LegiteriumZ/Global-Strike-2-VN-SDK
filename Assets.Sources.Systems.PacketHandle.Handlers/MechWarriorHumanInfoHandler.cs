using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class MechWarriorHumanInfoHandler : ApcPacketHandler<MechHumanLvUpData>
{
	private GameRuleContext _gameRuleContext;

	public MechWarriorHumanInfoHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 93;
	}

	public override void Handle(MechHumanLvUpData data)
	{
		_gameRuleContext.mechwarriorHumanEnergyData.CurrentEnergy = data.Energy;
		_gameRuleContext.mechwarriorHumanEnergyData.MaxEnergy = data.MaxEnergy;
	}
}
