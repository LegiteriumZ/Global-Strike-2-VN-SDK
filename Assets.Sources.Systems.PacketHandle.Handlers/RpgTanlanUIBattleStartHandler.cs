using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanUIBattleStartHandler : ApcPacketHandler<IntData>
{
	private RpgTanlanComponent tanlan;

	public RpgTanlanUIBattleStartHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlan;
	}

	public override int MethodId()
	{
		return 1204;
	}

	public override void Handle(IntData data)
	{
		tanlan.IsUIShow = false;
	}
}
