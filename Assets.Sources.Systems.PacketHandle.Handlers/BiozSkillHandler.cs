using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BiozSkillHandler : ApcPacketHandler<NBioZDiffSkillData>
{
	private GameRuleContext _gameRuleContext;

	public BiozSkillHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1109;
	}

	public override void Handle(NBioZDiffSkillData data)
	{
		Contexts.sharedInstance.message.bioZInit.nBioZDiffSkillData = data;
		NotifyManager.ForceInvoke(128);
	}
}
