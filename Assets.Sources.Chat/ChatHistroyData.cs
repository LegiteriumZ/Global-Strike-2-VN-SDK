using Assets.Sources.Components.Interface.Info.Chat;

namespace Assets.Sources.Chat;

public struct ChatHistroyData : IChatHistroyData
{
	public string MsgType;

	public string SenderName;

	public string SenderCid;

	public string ReceiverName;

	public string ReceiverCid;

	public string SendHead;

	public string SenderBody;

	public bool RpgVip;

	public int VipLv;

	public string PlayerCid;

	public bool Friendly;

	public string AssembleHead;

	public string AssembleRpgVipText;

	public string AssembleBody;

	public int KeepTime;

	public int Weight;

	public ChatHideAnimData AlphaData;
}
