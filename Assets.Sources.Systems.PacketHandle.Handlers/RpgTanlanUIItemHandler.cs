using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanUIItemHandler : ApcPacketHandler<TanLanReadyItemAllData>
{
	private RpgTanlanComponent tanlan;

	public RpgTanlanUIItemHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlan;
	}

	public override int MethodId()
	{
		return 1202;
	}

	public override void Handle(TanLanReadyItemAllData data)
	{
		tanlan.ItemList = data.ItemList;
		tanlan.ItemChange = true;
	}
}
