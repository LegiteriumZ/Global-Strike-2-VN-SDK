using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GroupKingOfGunKillNumHandler : ApcPacketHandler<GroupKingOfGunScoreData>
{
	private GameRuleContext _gameRuleContext;

	public GroupKingOfGunKillNumHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 49;
	}

	public override void Handle(GroupKingOfGunScoreData data)
	{
		_gameRuleContext.groupGunKingTeamScoreData.MaxKillNum = data.MaxKillNum;
		_gameRuleContext.groupGunKingTeamScoreData.Phase = data.Lv;
		_gameRuleContext.groupGunKingTeamScoreData.Team1KillNum = data.Team1KillNum;
		_gameRuleContext.groupGunKingTeamScoreData.Team2KillNum = data.Team2KillNum;
		_gameRuleContext.groupGunKingTeamScoreData.PhaseScore = data.Score;
	}
}
