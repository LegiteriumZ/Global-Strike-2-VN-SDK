using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SceneItemInfoListHandler : ApcPacketHandler<PeekabooItemListTmpData>
{
	private BattleRoomContext _battleRoomContext;

	public SceneItemInfoListHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 74;
	}

	public override void Handle(PeekabooItemListTmpData data)
	{
		foreach (PeekabooItemTmpData item in data.List)
		{
			string fileName = item.FileName;
			if (!_battleRoomContext.sceneItemInfo.ScneItemInfoDict.TryGetValue(fileName, out var value))
			{
				value = new Dictionary<int, PeekabooItemTmpData>();
				_battleRoomContext.sceneItemInfo.ScneItemInfoDict.Add(fileName, value);
			}
			int key = 0;
			if (item.BoundIndexSpecified)
			{
				key = item.BoundIndex;
			}
			value[key] = item;
		}
	}
}
