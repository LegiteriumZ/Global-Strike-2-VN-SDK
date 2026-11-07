using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class CommonStateProgressHandler : ApcPacketHandler<ProgressData>
{
	private GameRuleContext _gameRuleContext;

	public CommonStateProgressHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 336;
	}

	public override void Handle(ProgressData data)
	{
		_gameRuleContext.stateProgress.IsEffect = true;
		_gameRuleContext.stateProgress.Type = data.Type;
		_gameRuleContext.stateProgress.AllTime = data.Time;
		_gameRuleContext.stateProgress.CurrentTime = 0;
		_gameRuleContext.stateProgress.Detail = data.Detail;
		_gameRuleContext.stateProgress.PlayerName = data.PlayerName;
	}
}
