using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SendAllSceneItemEntityDataHandler : ApcPacketHandler<SceneItemEntityListData>
{
	private MessageContext _context;

	public SendAllSceneItemEntityDataHandler(Contexts context)
	{
		_context = context.message;
	}

	public override int MethodId()
	{
		return 77;
	}

	public override void Handle(SceneItemEntityListData data)
	{
		_context.peekabooMessageData.sceneItemListChanged = true;
		Dictionary<int, SceneItemEntityData> dictionary = _context.peekabooMessageData.sceneItems;
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, SceneItemEntityData>();
			_context.peekabooMessageData.sceneItems = dictionary;
		}
		else
		{
			dictionary.Clear();
		}
		foreach (SceneItemEntityData item in data.List)
		{
			dictionary[item.Id] = item;
		}
	}
}
