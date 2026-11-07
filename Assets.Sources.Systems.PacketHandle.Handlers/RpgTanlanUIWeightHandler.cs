using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanUIWeightHandler : ApcPacketHandler<TanLanWeightData>
{
	private RpgTanlanComponent tanlan;

	public RpgTanlanUIWeightHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlan;
	}

	public override int MethodId()
	{
		return 1201;
	}

	public override void Handle(TanLanWeightData data)
	{
		tanlan.CurrentWeight = data.CurrentWeight;
		tanlan.TotalWeight = data.TotalWeight;
		tanlan.WeightChange = true;
	}
}
