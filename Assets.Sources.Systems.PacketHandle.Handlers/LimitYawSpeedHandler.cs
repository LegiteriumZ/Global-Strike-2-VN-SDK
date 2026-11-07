using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class LimitYawSpeedHandler : ApcPacketHandler<ResetYawData>
{
	private readonly UserCommandContext _userCommandContext;

	public LimitYawSpeedHandler(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
	}

	public override int MethodId()
	{
		return 130;
	}

	public override void Handle(ResetYawData data)
	{
		if (!_userCommandContext.commandsEntity.hasLimitYawSpeed)
		{
			_userCommandContext.commandsEntity.AddLimitYawSpeed(0f);
		}
		_userCommandContext.commandsEntity.limitYawSpeed.Yaw = data.Yaw;
	}
}
