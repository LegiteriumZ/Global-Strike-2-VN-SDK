using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class Rpg6005BossXuliHandler : ApcPacketHandler<BossXuliProcessData>
{
	private GameRuleContext _gameRuleContext;

	public Rpg6005BossXuliHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 280;
	}

	public override void Handle(BossXuliProcessData data)
	{
		_gameRuleContext.rpg6005.show = data.Show;
		if (data.Show)
		{
			_gameRuleContext.rpg6005.currentProcessValue = data.Value;
			_gameRuleContext.rpg6005.maxProcessValue = data.MaxValue;
		}
	}
}
