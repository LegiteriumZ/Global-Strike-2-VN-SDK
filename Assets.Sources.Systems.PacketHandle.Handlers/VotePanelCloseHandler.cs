using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class VotePanelCloseHandler : ApcPacketHandler<CloseVotePanel>
{
	private GameRuleContext _gameRuleContext;

	public VotePanelCloseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 135;
	}

	public override void Handle(CloseVotePanel data)
	{
		_gameRuleContext.kickOut.voteVisible = false;
	}
}
