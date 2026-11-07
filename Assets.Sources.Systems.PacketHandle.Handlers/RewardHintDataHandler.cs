using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RewardHintDataHandler : ApcPacketHandler<RewardHintData>
{
	private readonly GameRuleContext _gameRuleContext;

	public RewardHintDataHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 121;
	}

	public override void Handle(RewardHintData data)
	{
		_gameRuleContext.rpgTaskTarget.Wave = data.Wave;
		_gameRuleContext.rpgTaskTarget.MasteryCoin = data.MasteryCoin;
		_gameRuleContext.rpgTaskTarget.Obsidian = data.Obsidian;
	}
}
