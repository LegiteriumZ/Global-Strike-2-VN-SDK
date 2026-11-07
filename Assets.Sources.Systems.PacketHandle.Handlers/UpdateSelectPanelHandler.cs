using NetData;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UpdateSelectPanelHandler : ApcPacketHandler<SelectItemList>
{
	private GameRuleContext _gameRuleContext;

	public UpdateSelectPanelHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 215;
	}

	public override void Handle(SelectItemList data)
	{
		_gameRuleContext.selectNodeData.SelectItemList = data;
		_gameRuleContext.selectNodeData.ReceivedtTime = UnityEngine.Time.timeSinceLevelLoad;
	}
}
