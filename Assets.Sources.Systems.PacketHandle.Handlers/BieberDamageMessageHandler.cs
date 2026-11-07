using I2.Loc;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BieberDamageMessageHandler : ApcPacketHandler<BravebieberDamageData>
{
	private ChatContext _chatContext;

	public BieberDamageMessageHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 601;
	}

	public override void Handle(BravebieberDamageData data)
	{
		foreach (BravebieberDamageInfo item in data.List)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"{2}\" type=\"{0}\" ><body>{1}</body></message>", "battle_team", string.Format(ScriptLocalization.Get("BIEBER_DAMAGE_MESSAGE"), item.PlayerName, item.Damage), data.SendPlayerName));
		}
	}
}
