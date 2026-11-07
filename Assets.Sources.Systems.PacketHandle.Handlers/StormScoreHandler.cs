using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class StormScoreHandler : ApcPacketHandler<StormScoreData>
{
	private GameRuleContext _gameRuleContext;

	public StormScoreHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 220;
	}

	public override void Handle(StormScoreData data)
	{
		if (_gameRuleContext.weaponPendantDrop.Time <= 0 || string.IsNullOrEmpty(_gameRuleContext.weaponPendantDrop.PendantId))
		{
			_gameRuleContext.weaponPendantDrop.IsStormScore = true;
			_gameRuleContext.weaponPendantDrop.Count = data.Score;
			_gameRuleContext.weaponPendantDrop.Time = 3000;
			_gameRuleContext.weaponPendantDrop.Quality = 0;
		}
	}
}
