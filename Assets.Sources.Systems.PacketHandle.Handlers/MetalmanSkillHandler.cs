using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class MetalmanSkillHandler : ApcPacketHandler<MetalmanSkillData>
{
	private GameRuleContext _gameRuleContext;

	public MetalmanSkillHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 84;
	}

	public override void Handle(MetalmanSkillData data)
	{
		_gameRuleContext.metalmanSkillData.AddMp = data.AddMp;
		_gameRuleContext.metalmanSkillData.Mp = data.Mp;
	}
}
