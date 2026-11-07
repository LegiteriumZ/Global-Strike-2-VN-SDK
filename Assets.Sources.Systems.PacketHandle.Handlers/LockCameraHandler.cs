using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class LockCameraHandler : ApcPacketHandler<ResetYawData>
{
	private UserCommandContext _userCommandContext;

	public LockCameraHandler(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
	}

	public override int MethodId()
	{
		return 33;
	}

	public override void Handle(ResetYawData data)
	{
		UserCommandEntity commandsEntity = _userCommandContext.commandsEntity;
		if (commandsEntity != null && _userCommandContext.hasInput)
		{
			if (data.Pitch == 0f)
			{
				_userCommandContext.input.Pitch = 0f;
			}
			commandsEntity.ReplaceLockCamera(data.Yaw, data.Pitch, _userCommandContext.input.Yaw, _userCommandContext.input.Pitch);
		}
	}
}
