using Assets.Sources.Components.Message.Bochemical;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BioDamageHandler : ApcPacketHandler<IntData>
{
	private MessageContext _messageContext;

	public BioDamageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 26;
	}

	public override void Handle(IntData data)
	{
		if (data.Data == 0)
		{
			return;
		}
		BioDamageScoreDataComponent bioDamageScoreData = _messageContext.bioDamageScoreData;
		if (data.Data > 100)
		{
			bioDamageScoreData.HeroDamageScore = data.Data;
			NotifyManager.ForceInvoke(57);
			return;
		}
		int humanityDamageScore = data.Data - bioDamageScoreData.LastHumanityDamageScore;
		if (data.Data >= 10)
		{
			bioDamageScoreData.LastHumanityDamageScore = data.Data - 10;
			NotifyManager.ForceInvoke(58);
		}
		else
		{
			bioDamageScoreData.LastHumanityDamageScore = data.Data;
			NotifyManager.ForceInvoke(58);
		}
		bioDamageScoreData.HumanityDamageScore = humanityDamageScore;
		NotifyManager.ForceInvoke(51);
	}
}
