using Assets.Sources.Free.Data;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UpdateExpHandler : ApcPacketHandler<ExpData>
{
	public override int MethodId()
	{
		return 66;
	}

	public override void Handle(ExpData data)
	{
		GameModelLocator.GetInstance().GameModel.ProfitModel.profitDataChanged(data);
	}
}
