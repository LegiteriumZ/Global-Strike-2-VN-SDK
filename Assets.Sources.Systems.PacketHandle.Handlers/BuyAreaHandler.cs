using NetData;
using physics;
using physics.data;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BuyAreaHandler : ApcPacketHandler<BuyAreaListData>
{
	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	public BuyAreaHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 89;
	}

	public override void Handle(BuyAreaListData data)
	{
		_gameRuleContext.goldExplodeBuyAreaData.BuyTime = data.BuyTime;
		_gameRuleContext.goldExplodeBuyAreaData.BuyArea = data;
		IPyClipMap clipMap = _battleRoomContext.pyEngine.PyEngine.GetWorld().GetClipMap();
		for (int i = 0; i < data.Area.Count; i++)
		{
			CBuyArea cBuyArea = new CBuyArea();
			cBuyArea.min[0] = data.Area[i].Min[0];
			cBuyArea.min[1] = data.Area[i].Min[1];
			cBuyArea.min[2] = data.Area[i].Min[2];
			cBuyArea.max[0] = data.Area[i].Max[0];
			cBuyArea.max[1] = data.Area[i].Max[1];
			cBuyArea.max[2] = data.Area[i].Max[2];
			cBuyArea.buyTeam = data.Area[i].BuyTeam;
			clipMap.GetBuyAreaList().Add(cBuyArea);
		}
	}
}
