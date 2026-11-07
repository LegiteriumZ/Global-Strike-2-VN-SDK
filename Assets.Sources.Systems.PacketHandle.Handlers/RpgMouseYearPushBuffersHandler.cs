using System.Collections.Generic;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearPushBuffersHandler : ApcPacketHandler<BuffPush>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearPushBuffersHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 254;
	}

	public override void Handle(BuffPush data)
	{
		Dictionary<int, int> dictionary = _gameRuleContext.mouseYear.Buffer;
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, int>();
		}
		if (dictionary.ContainsKey(data.Id))
		{
			dictionary[data.Id] = data.Value;
		}
		else
		{
			dictionary.Add(data.Id, data.Value);
		}
		NotifyManager.ForceInvoke(76);
	}
}
