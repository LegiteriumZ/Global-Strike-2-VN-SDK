using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UpdateKingTreasuryCoinHandler : ApcPacketHandler<KingTreasuryCoinData>
{
	private GameRuleContext _gameRuleContext;

	public UpdateKingTreasuryCoinHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 207;
	}

	public override void Handle(KingTreasuryCoinData data)
	{
		_gameRuleContext.kingTreasuryData.Coin = data.Coin;
	}
}
