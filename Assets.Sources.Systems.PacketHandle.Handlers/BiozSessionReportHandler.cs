using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BiozSessionReportHandler : ApcPacketHandler<NBioZSessionReport>
{
	public BiozSessionReportHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 1112;
	}

	public override void Handle(NBioZSessionReport data)
	{
		Contexts.sharedInstance.message.bioZInit.nBioZSession = data;
		NotifyManager.ForceInvoke(132);
	}
}
