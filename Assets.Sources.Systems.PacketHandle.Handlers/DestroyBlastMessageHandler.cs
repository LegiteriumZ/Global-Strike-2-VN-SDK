using Assets.Sources.Components.BattleRoom;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class DestroyBlastMessageHandler : ApcPacketHandler<DestroyBlastMessageData>
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	public DestroyBlastMessageHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 271;
	}

	public override void Handle(DestroyBlastMessageData data)
	{
		if (_battleRoomContext.lobbyInfo.Id2CidDic.TryGetValue(data.PlayerId, out var value))
		{
			if (!_battleRoomContext.playerInfo.PlayerInfoExtraDatas.TryGetValue(value, out var value2))
			{
				value2 = new PlayerInfoComponent.PlayerInfoExtra();
				_battleRoomContext.playerInfo.PlayerInfoExtraDatas.Add(value, value2);
			}
			value2.Numb = data.Num;
		}
	}
}
