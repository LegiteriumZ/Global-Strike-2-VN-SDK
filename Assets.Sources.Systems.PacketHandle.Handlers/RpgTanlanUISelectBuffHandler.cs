using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanUISelectBuffHandler : ApcPacketHandler<TanLanReadyBuffListData>
{
	private RpgTanlanComponent tanlan;

	public RpgTanlanUISelectBuffHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlan;
	}

	public override int MethodId()
	{
		return 1203;
	}

	public override void Handle(TanLanReadyBuffListData data)
	{
		tanlan.SelectBuffList = data.BuffList;
		tanlan.CanRefreshBuffCount = data.CanRefreshBuffCount;
		tanlan.SelectBuffChange = true;
	}
}
