using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UpdateMpHandler : ApcPacketHandler<UpdateMpData>
{
	private readonly GameRuleContext _gameRuleContext;

	public UpdateMpHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 68;
	}

	public override void Handle(UpdateMpData data)
	{
		_gameRuleContext.tdSkillStateData.CurrentMp = data.Mp;
		_gameRuleContext.tdSkillStateData.TotalMp = data.MaxMp;
	}
}
