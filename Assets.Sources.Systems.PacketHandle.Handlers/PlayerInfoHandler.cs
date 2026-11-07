using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlayerInfoHandler : ApcPacketHandler<PlayerInfoData>
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	public PlayerInfoHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 61;
	}

	public override void Handle(PlayerInfoData data)
	{
		_battleRoomContext.playerInfo.PlayerInfoDatas.TryGetValue(data.Cid, out var value);
		value = EntityDataExtension.ClonePlayerInfoData(data, value);
		_battleRoomContext.playerInfo.PlayerInfoDatas[value.Cid] = value;
		if (data.HasLikesFlagSpecified)
		{
			_gameRuleContext.peekabooLikes.ShowBlastLikes = data.HasLikesFlag;
		}
	}
}
