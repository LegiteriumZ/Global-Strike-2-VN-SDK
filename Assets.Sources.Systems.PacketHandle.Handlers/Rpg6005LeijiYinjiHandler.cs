using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class Rpg6005LeijiYinjiHandler : ApcPacketHandler<LeijiYinjiData>
{
	private GameRuleContext _gameRuleContext;

	public Rpg6005LeijiYinjiHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 281;
	}

	public override void Handle(LeijiYinjiData data)
	{
		_gameRuleContext.rpg6005.leiyinShow = data.Show;
		_gameRuleContext.rpg6005.leiyinCengshu = data.Cengshu;
	}
}
