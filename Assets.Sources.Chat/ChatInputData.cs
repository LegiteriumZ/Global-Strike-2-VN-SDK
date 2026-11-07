using Assets.Sources.Components.Interface.Info.Chat;

namespace Assets.Sources.Chat;

public struct ChatInputData : IChatInputData
{
	public string SenderInputContent;

	public string SenderType;

	public string ReceiverCid;

	public string ReceiverName;
}
