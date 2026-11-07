using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class WeaponMasterMessageHandler : ApcPacketHandler<MessageListData>
{
	private GameRuleContext _gameRuleContext;

	public WeaponMasterMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 120;
	}

	public override void Handle(MessageListData data)
	{
		_gameRuleContext.selectWeaponType.WeaponTypeList = data.BoolList;
	}
}
