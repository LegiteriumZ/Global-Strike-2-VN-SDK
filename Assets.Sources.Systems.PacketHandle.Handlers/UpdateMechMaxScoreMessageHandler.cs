using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UpdateMechMaxScoreMessageHandler : ApcPacketHandler<MechWarriorMaxScoreData>
{
	private GameRuleContext _gameRuleContext;

	public UpdateMechMaxScoreMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 102;
	}

	public override void Handle(MechWarriorMaxScoreData data)
	{
		_gameRuleContext.mechwarrionRankDate.NameList.Clear();
		_gameRuleContext.mechwarrionRankDate.ScoreList.Clear();
		_gameRuleContext.mechwarrionRankDate.NameList.Add(data.PlayerName1);
		_gameRuleContext.mechwarrionRankDate.ScoreList.Add(data.Score1);
		_gameRuleContext.mechwarrionRankDate.NameList.Add(data.PlayerName2);
		_gameRuleContext.mechwarrionRankDate.ScoreList.Add(data.Score2);
		NotifyManager.ForceInvoke(20);
	}
}
