using I2.Loc;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class AbyssmessageHandler : ApcPacketHandler<AbyssMessageData>
{
	private ChatContext _chatContext;

	public AbyssmessageHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 214;
	}

	public override void Handle(AbyssMessageData data)
	{
		if (data.ShowChatUI)
		{
			string text = null;
			switch (data.Type)
			{
			case AbyssMessageType.RECOVERMEDCINEHASBEENUSED:
				text = ScriptLocalization.Get("RECOVERMEDCINEHASBEENUSED");
				break;
			case AbyssMessageType.ATTACKMEDCINEHASBEENUSED:
				text = ScriptLocalization.Get("ATTACKMEDCINEHASBEENUSED");
				break;
			case AbyssMessageType.SPEEDMEDCINEHASBEENUSED:
				text = ScriptLocalization.Get("SPEEDMEDCINEHASBEENUSED");
				break;
			}
			if (text != null && _chatContext.hasChatJobHistroy)
			{
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "hononary1", text));
			}
		}
	}
}
