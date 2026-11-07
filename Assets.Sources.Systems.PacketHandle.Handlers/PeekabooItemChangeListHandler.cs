using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PeekabooItemChangeListHandler : ApcPacketHandler<SceneItemVisibleListData>
{
	private GameRuleContext _gameRuleContext;

	private MessageContext _msgContext;

	public PeekabooItemChangeListHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_msgContext = contexts.message;
	}

	public override int MethodId()
	{
		return 82;
	}

	public override void Handle(SceneItemVisibleListData data)
	{
		_msgContext.peekabooMessageData.notCanSeeList = data.NotSeeList;
	}
}
