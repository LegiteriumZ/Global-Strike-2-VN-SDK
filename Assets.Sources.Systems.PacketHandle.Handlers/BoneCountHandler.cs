using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BoneCountHandler : ApcPacketHandler<BoneCount>
{
	private GameRuleContext _gameRuleContext;

	public BoneCountHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 235;
	}

	public override void Handle(BoneCount data)
	{
		_gameRuleContext.teamRaceUi.TotalBones = data.TeamCount;
		_gameRuleContext.teamRaceUi.PersonBones = data.MyCount;
	}
}
