using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanUIALLHandler : ApcPacketHandler<TanLanReadyUIData>
{
	private RpgTanlanComponent tanlan;

	public RpgTanlanUIALLHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlan;
	}

	public override int MethodId()
	{
		return 1200;
	}

	public override void Handle(TanLanReadyUIData data)
	{
		tanlan.IsUIShow = true;
		tanlan.ItemChange = true;
		tanlan.WeightChange = true;
		tanlan.SelectBuffChange = true;
		tanlan.UIEndServerTime = data.BackWinTime;
		tanlan.labelSuccessShow = data.IsWin;
		tanlan.ItemList = data.ItemBag.ItemList;
		tanlan.NextCanAwardList = data.NextCanAwardList.ItemList;
		tanlan.SelectBuffList = data.SelectBuffList.BuffList;
		tanlan.CurBuffList = data.CurBuffList.BuffList;
		tanlan.CurrentWeight = data.WeightData.CurrentWeight;
		tanlan.TotalWeight = data.WeightData.TotalWeight;
		tanlan.CanRefreshBuffCount = data.SelectBuffList.CanRefreshBuffCount;
		tanlan.LeftDropCount = data.LeftDropCount;
	}
}
