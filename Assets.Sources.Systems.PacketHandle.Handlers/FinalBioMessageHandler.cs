using Assets.Sources.Components.Message.FinalBio;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class FinalBioMessageHandler : ApcPacketHandler<FinalBioMessageData>
{
	private MessageContext _messageContext;

	public FinalBioMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 59;
	}

	public override void Handle(FinalBioMessageData data)
	{
		if (!_messageContext.hasFinalBioMessageData)
		{
			_messageContext.SetFinalBioMessageData(newVariantsGrowupChanged: false, newChangeHumanityChanged: false, newSuperbioVariantsChanged: false, FinalBioMessageType.GENERATION, 0, FinalBioMessageType.GENERATION, 0, 0);
		}
		FinalBioMessageDataComponent finalBioMessageData = _messageContext.finalBioMessageData;
		if (data.Type == FinalBioMessageType.GENERATION || data.Type == FinalBioMessageType.FRAGMENTATION || data.Type == FinalBioMessageType.INTERRUPT)
		{
			finalBioMessageData.VariantsGrowupType = data.Type;
			finalBioMessageData.VariantsGrowupTime = data.Time;
			finalBioMessageData.VariantsGrowupChanged = true;
			NotifyManager.ForceInvoke(5);
		}
		else if (data.Type == FinalBioMessageType.PLAYERGETANTIDOTE || data.Type == FinalBioMessageType.PLAYERUSEANTIDOTE)
		{
			finalBioMessageData.ChangeHumanityType = data.Type;
			finalBioMessageData.ChangeHumanityTime = data.Time;
			finalBioMessageData.AntidoteNum = data.Num;
			if (data.Type == FinalBioMessageType.FRAGMENTATION)
			{
				finalBioMessageData.SuperbioVariantsChanged = true;
				NotifyManager.ForceInvoke(61);
				return;
			}
			finalBioMessageData.SuperbioVariantsChanged = true;
			NotifyManager.ForceInvoke(61);
			finalBioMessageData.ChangeHumanityChanged = true;
			NotifyManager.ForceInvoke(28);
		}
	}
}
