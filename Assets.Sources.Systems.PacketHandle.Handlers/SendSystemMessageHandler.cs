using I2.Loc;
using NetData;
using SSJJBase.Utility;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SendSystemMessageHandler : ApcPacketHandler<SystemMessageEventData>
{
	private ChatContext _chatContext;

	public SendSystemMessageHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 118;
	}

	public override void Handle(SystemMessageEventData data)
	{
		string text = null;
		switch (data.TypeId)
		{
		case 1:
			text = PrintfUtility.Printf(ScriptLocalization.Get("PlayerUseRpgSliver"), new string[2] { data.Args1, data.Args2 });
			break;
		case 2:
			text = PrintfUtility.Printf(ScriptLocalization.Get("PlayerUseRpgFuHuoBi"), new string[3] { data.Args1, data.Args2, data.Args3 });
			break;
		case 3:
			text = $"当前击中路障ID:{data.Args1}";
			break;
		case 4:
			text = $"攻击伤害:{data.Args1} + {data.Args2} 类型 {data.Args3}";
			break;
		case 5:
			text = $"[调试:{data.Args1}]";
			break;
		case 6:
			text = PrintfUtility.Printf(ScriptLocalization.Get("RELIVE_HELP"), new string[2] { data.Args1, data.Args2 });
			break;
		case 7:
			text = data.Args1;
			break;
		}
		if (!string.IsNullOrEmpty(text) && _chatContext.hasChatJobHistroy)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"\" type=\"{0}\" ><body>{1}</body></message>", "system", text));
		}
	}
}
