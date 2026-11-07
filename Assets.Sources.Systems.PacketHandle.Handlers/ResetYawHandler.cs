using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ResetYawHandler : ApcPacketHandler<ResetYawData>
{
	private UserCommandContext _userCommandContext;

	public ResetYawHandler(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
	}

	public override int MethodId()
	{
		return 21;
	}

	public override void Handle(ResetYawData data)
	{
		UserCommandEntity commandsEntity = _userCommandContext.commandsEntity;
		if (commandsEntity != null)
		{
			commandsEntity.ReplaceResetYaw(data.Yaw);
			if (data.PitchSpecified)
			{
				commandsEntity.ReplaceResetPitch(data.Pitch);
			}
		}
	}
}
