using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BioHumChosePanelHandler : ApcPacketHandler<IntData>
{
	private GameRuleContext _context;

	public BioHumChosePanelHandler(Contexts contexts)
	{
		_context = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 613;
	}

	public override void Handle(IntData data)
	{
		_context.bioUnionBaseData.SelectTeamPanelShow = true;
	}
}
