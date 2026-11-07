using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgStarWalkerInfoHandler : ApcPacketHandler<HeJiTabData>
{
	private GameRuleContext _context;

	public RpgStarWalkerInfoHandler(Contexts contexts)
	{
		_context = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1213;
	}

	public override void Handle(HeJiTabData data)
	{
		if (_context.rpgStarWalker.mixtureDatas == null)
		{
			_context.rpgStarWalker.mixtureDatas = new List<HeJiTabKeyData>();
		}
		_context.rpgStarWalker.mixtureDatas.Clear();
		int count = data.List.Count;
		for (int i = 0; i < count; i++)
		{
			HeJiTabKeyData heJiTabKeyData = new HeJiTabKeyData();
			heJiTabKeyData.Id = data.List[i].Id;
			heJiTabKeyData.Name = data.List[i].Name;
			heJiTabKeyData.Desc = data.List[i].Desc;
			heJiTabKeyData.Icon = data.List[i].Icon;
			heJiTabKeyData.Quality = data.List[i].Quality;
			_context.rpgStarWalker.mixtureDatas.Add(heJiTabKeyData);
		}
	}
}
