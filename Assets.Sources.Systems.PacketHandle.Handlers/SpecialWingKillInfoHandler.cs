using I2.Loc;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SpecialWingKillInfoHandler : ApcPacketHandler<JuLongAbroadInfo>
{
	private ChatContext _chatContext;

	public SpecialWingKillInfoHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 282;
	}

	public override void Handle(JuLongAbroadInfo data)
	{
		_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("USEWEAPON_KILL_PLAYER_NUMBER_JULONG") + "</body></message>", "hononary1", data.KillPlayerName, data.BeKillPlayerName, data.KillNum));
	}
}
