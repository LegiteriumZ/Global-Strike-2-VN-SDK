using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UnLockCameraHandler : ApcPacketHandler<ResetYawData>
{
	private UserCommandContext _userCommandContext;

	public UnLockCameraHandler(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
	}

	public override int MethodId()
	{
		return 34;
	}

	public override void Handle(ResetYawData data)
	{
		UserCommandEntity commandsEntity = _userCommandContext.commandsEntity;
		if (commandsEntity != null && commandsEntity.hasLockCamera)
		{
			commandsEntity.RemoveLockCamera();
		}
	}
}
