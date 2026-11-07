using Assets.Scripts.Utility;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ShowServerDebugErrorMessageHandler : ApcPacketHandler<ServerDebugErrorMessageData>
{
	public override int MethodId()
	{
		return 105;
	}

	public override void Handle(ServerDebugErrorMessageData data)
	{
		if (UiMessageTipManager.Instance != null)
		{
			UiMessageTipManager.Instance.ShowMessage(data.Message, 2f);
		}
	}
}
