using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class OpenChuansongInitHandler : ApcPacketHandler<ChuanSongMessageData>
{
	private GameRuleContext _context;

	public OpenChuansongInitHandler(Contexts contexts)
	{
		_context = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 611;
	}

	public override void Handle(ChuanSongMessageData data)
	{
		_context.rpgTreasureBossData.hasInitPointData = true;
		if (_context.rpgTreasureBossData.pointDatas == null)
		{
			_context.rpgTreasureBossData.pointDatas = new List<ChuansongPointData>();
		}
		_context.rpgTreasureBossData.pointDatas.Clear();
		int count = data.AllPointList.Count;
		for (int i = 0; i < count; i++)
		{
			ChuansongPointData chuansongPointData = new ChuansongPointData();
			chuansongPointData.Id = data.AllPointList[i].Id;
			chuansongPointData.PosX = data.AllPointList[i].PosX;
			chuansongPointData.PosY = data.AllPointList[i].PosY;
			_context.rpgTreasureBossData.pointDatas.Add(chuansongPointData);
		}
	}
}
