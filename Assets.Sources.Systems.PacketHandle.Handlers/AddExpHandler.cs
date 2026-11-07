using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AddExpHandler : ApcPacketHandler<AddExpData>
{
	private GameRuleContext _gameRuleContext;

	public AddExpHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 67;
	}

	public override void Handle(AddExpData data)
	{
		_gameRuleContext.addExpData.AddExp = data.AddExp;
		_gameRuleContext.addExpData.CurrentExp = data.Exp;
		_gameRuleContext.addExpData.MaxExp = data.MaxExp;
		_gameRuleContext.addExpData.Dirty = true;
	}
}
