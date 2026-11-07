using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class KingOfGunSelfInfoHandler : ApcPacketHandler<KingOfGunScoreData>
{
	private GameRuleContext _gameRuleContext;

	public KingOfGunSelfInfoHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 46;
	}

	public override void Handle(KingOfGunScoreData data)
	{
		_gameRuleContext.gunKingTeamScoreData.SelfPhase = data.Lv;
		_gameRuleContext.gunKingTeamScoreData.SelfKillCount = data.CurKillNum;
		_gameRuleContext.gunKingTeamScoreData.SelfPhaseKillCount = data.MaxKillNum;
	}
}
