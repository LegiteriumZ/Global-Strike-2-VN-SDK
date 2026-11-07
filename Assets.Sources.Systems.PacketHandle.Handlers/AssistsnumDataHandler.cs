using Assets.Scripts.Utility.Sound;
using NotifyEvent;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class AssistsnumDataHandler : ApcPacketHandler<object>
{
	public AssistsnumDataHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 28;
	}

	public override void Handle(object data)
	{
		NotifyManager.ForceInvoke(35);
		MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound(AutoSoundEventType.Zhugong);
	}
}
