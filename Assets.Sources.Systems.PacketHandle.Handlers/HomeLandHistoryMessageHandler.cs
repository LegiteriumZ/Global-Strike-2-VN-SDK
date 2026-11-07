using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HomeLandHistoryMessageHandler : ApcPacketHandler<HomelandHistoryData>
{
	public override int MethodId()
	{
		return 607;
	}

	public override void Handle(HomelandHistoryData data)
	{
		Contexts.sharedInstance.message.homeLandScene.listHomelandHistoryInfoData = data.List;
		NotifyManager.ForceInvoke(152);
	}
}
