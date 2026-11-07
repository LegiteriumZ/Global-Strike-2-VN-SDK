using I2.Loc;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class WeaponAccessoryDropHandler : ApcPacketHandler<WeaponAccessoryDropData>
{
	private GameRuleContext _gameRuleContext;

	private ChatContext _chatContext;

	public WeaponAccessoryDropHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 219;
	}

	public override void Handle(WeaponAccessoryDropData data)
	{
		_gameRuleContext.weaponPendantDrop.IsStormScore = false;
		_gameRuleContext.weaponPendantDrop.PendantId = data.PendantId;
		_gameRuleContext.weaponPendantDrop.Count = data.DropCount;
		_gameRuleContext.weaponPendantDrop.Quality = data.PendantQuality;
		_gameRuleContext.weaponPendantDrop.Time = 3000;
		if (_chatContext.hasChatJobHistroy)
		{
			if (data.Drop)
			{
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "hononary1", string.Format(ScriptLocalization.Get("LOST_WEAPONPENDANT"), data.PendantName, data.DropCount)));
			}
			else
			{
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "hononary2", string.Format(ScriptLocalization.Get("GET_WEAPONPENDANT"), data.PendantName, data.DropCount)));
			}
		}
	}
}
