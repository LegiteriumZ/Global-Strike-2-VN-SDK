using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class NewbieGuideFlagHandler : ApcPacketHandler<IntData>
{
	private GameRuleContext _gameRuleContext;

	public NewbieGuideFlagHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 14;
	}

	public override void Handle(IntData data)
	{
		_gameRuleContext.newbieGuideData.NewbieGuideModel.NewbieGuideFlag = data.Data;
	}
}
