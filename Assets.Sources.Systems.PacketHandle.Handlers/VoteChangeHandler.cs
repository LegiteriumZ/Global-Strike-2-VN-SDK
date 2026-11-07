using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class VoteChangeHandler : ApcPacketHandler<VoteChange>
{
	private GameRuleContext _gameRuleContext;

	public VoteChangeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 134;
	}

	public override void Handle(VoteChange data)
	{
		_gameRuleContext.kickOut.votePanel.Agree = data.Agree;
		_gameRuleContext.kickOut.votePanel.Rejest = data.Rejest;
		_gameRuleContext.kickOut.isResult = data.IsJiesuan;
	}
}
