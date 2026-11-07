using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class DeadEyeMessageHandler : ApcPacketHandler<DeadEyeMessageData>
{
	private PlayerContext _playerContext;

	public DeadEyeMessageHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 225;
	}

	public override void Handle(DeadEyeMessageData data)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(data.PlayerId);
		if (entityWithEntityId != null)
		{
			if (!entityWithEntityId.hasDeadEye)
			{
				entityWithEntityId.AddDeadEye(0, 0, 0);
			}
			entityWithEntityId.deadEye.ShowFlag = data.ShowFlag;
			entityWithEntityId.deadEye.EffectTime = data.NeedTime;
			entityWithEntityId.deadEye.ServerTime = data.EndTime - data.StartTime;
		}
	}
}
