using Assets.Libs.ForAce;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AceClientHandler : ApcPacketHandler<TssSdkAntiSendDataInfo>
{
	public AceClientHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 999;
	}

	public override void Handle(TssSdkAntiSendDataInfo data)
	{
		this.InfoFormat("AntiData {0}, AccountInfo {1}", data.AntiData, data.AccountInfo);
		MonoBehaviourSingleton<AceClientManager>.Instance.ReceiveData(data.AntiData, data.AccountInfo);
	}
}
