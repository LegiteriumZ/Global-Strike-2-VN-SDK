using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BiozSkillListHandler : ApcPacketHandler<NBioZDiffSkillData>
{
	private GameRuleContext _gameRuleContext;

	public BiozSkillListHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1110;
	}

	public override void Handle(NBioZDiffSkillData data)
	{
		Contexts.sharedInstance.message.bioZInit.nBioZPlayerAllSkillData = data;
		NotifyManager.ForceInvoke(131);
	}
}
