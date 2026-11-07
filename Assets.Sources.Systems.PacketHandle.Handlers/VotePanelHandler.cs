using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class VotePanelHandler : ApcPacketHandler<VotePanel>
{
	private GameRuleContext _gameRuleContext;

	public VotePanelHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 133;
	}

	public override void Handle(VotePanel data)
	{
		_gameRuleContext.kickOut.yetVisible = false;
		_gameRuleContext.kickOut.voteVisible = true;
		_gameRuleContext.kickOut.isResult = false;
		_gameRuleContext.kickOut.votePanel = data;
		_gameRuleContext.kickOut.showTime = 0;
	}
}
