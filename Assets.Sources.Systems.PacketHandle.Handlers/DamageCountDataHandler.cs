using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class DamageCountDataHandler : ApcPacketHandler<DamageCountData>
{
	private MessageContext _messageContext;

	public DamageCountDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 20;
	}

	public override void Handle(DamageCountData data)
	{
		_messageContext.damageCountData.DamageDataList.Clear();
		foreach (DamageData item in data.List)
		{
			if (item.Damage != 0)
			{
				_messageContext.damageCountData.DamageDataList.Add(item);
			}
		}
		NotifyManager.ForceInvoke(36);
	}
}
