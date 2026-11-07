using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class MechCharageMessageHandler : ApcPacketHandler<MechWarriorChargeGiftData>
{
	private GameRuleContext _gameRuleContext;

	public MechCharageMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 101;
	}

	public override void Handle(MechWarriorChargeGiftData data)
	{
		_gameRuleContext.mechwarriorHumanEnergyData.ChangeGiftType = data.Type;
		_gameRuleContext.mechwarriorHumanEnergyData.ChangeGiftTime = data.Time;
	}
}
