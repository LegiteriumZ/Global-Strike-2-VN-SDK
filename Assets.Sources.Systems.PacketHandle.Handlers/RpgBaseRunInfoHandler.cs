using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgBaseRunInfoHandler : ApcPacketHandler<BaseRunSpeedUIData>
{
	public RpgBaseRunInfoHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 1113;
	}

	public override void Handle(BaseRunSpeedUIData data)
	{
		Contexts.sharedInstance.gameRule.rpgBaseRunData.Visible = data.Visible;
		Contexts.sharedInstance.gameRule.rpgBaseRunData.IconId = data.IconId;
		Contexts.sharedInstance.gameRule.rpgBaseRunData.CurTime = data.CurTime;
		Contexts.sharedInstance.gameRule.rpgBaseRunData.TotalTime = data.TotalTime;
		Contexts.sharedInstance.gameRule.rpgBaseRunData.IconNum = data.IconNum;
		Contexts.sharedInstance.gameRule.rpgBaseRunData.TimeEnable = data.Enable;
	}
}
