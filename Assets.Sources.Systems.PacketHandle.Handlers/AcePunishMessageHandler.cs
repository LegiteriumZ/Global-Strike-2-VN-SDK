using I2.Loc;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcePunishMessageHandler : ApcPacketHandler<AcePunishData>
{
	private readonly ChatContext _chatContext;

	public AcePunishMessageHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 603;
	}

	public override void Handle(AcePunishData data)
	{
		_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"{2}\" type=\"{0}\" ><body>{1}</body></message>", "battle_all", ScriptLocalization.Get("ACE_PUNISH_MESSAGE"), data.PlayerName));
	}
}
