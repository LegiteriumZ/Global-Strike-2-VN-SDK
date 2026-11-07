using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BroadcastScoreDatahandler : ApcPacketHandler<BroadcastScoreData>
{
	private readonly GameRuleContext _gameRuleContext;

	public BroadcastScoreDatahandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 4;
	}

	public override void Handle(BroadcastScoreData data)
	{
		_gameRuleContext.broadcastScore.Team1Score = data.Team1Score;
		_gameRuleContext.broadcastScore.Team2Score = data.Team2Score;
		_gameRuleContext.broadcastScore.CurrentScore = data.CurrentScore;
		_gameRuleContext.broadcastScore.WinScore = data.WinScore;
		_gameRuleContext.broadcastScore.Team1Kill = data.Team1Kill;
		_gameRuleContext.broadcastScore.Team2Kill = data.Team2Kill;
	}
}
