using Assets.Sources.Utils;
using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CheckGamePlusHandler : ApcPacketHandler<ImgReason>
{
	public CheckGamePlusHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 272;
	}

	public override void Handle(ImgReason data)
	{
		MonoBehaviourSingleton<ScreenShotManager>.Instance.TcpMsgScreentNow = true;
		MonoBehaviourSingleton<ScreenShotManager>.Instance.ScreenImageReason = data.Type;
	}
}
