using Assets.Sources.Chat;
using Assets.Sources.Components.Chat;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class WeaponJoinMessageHandler : ApcPacketHandler<WeaponJoinData>
{
	private ChatContext _chatContext;

	public WeaponJoinMessageHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 602;
	}

	public override void Handle(WeaponJoinData data)
	{
		ChatJobHistroyComponent chatJobHistroy = _chatContext.chatJobHistroy;
		foreach (WeaponJoinList weaponJoin in data.WeaponJoinList)
		{
			ChatHononaryData chatHononaryData = default(ChatHononaryData);
			chatHononaryData.PlayerName = data.PlayerName;
			chatHononaryData.WeaponName = weaponJoin.CodeName;
			chatHononaryData.AlphaData.RemainTime = 7000;
			chatHononaryData.AlphaData.AlphaRemainTime = 100;
			chatJobHistroy.Tips.Group.Insert(0, chatHononaryData);
			chatHononaryData.Changed = true;
			if (chatJobHistroy.Tips.Group.Count > 4)
			{
				chatJobHistroy.Tips.Group.RemoveAt(chatJobHistroy.Tips.Group.Count - 1);
			}
			chatJobHistroy.Tips.Mark = true;
		}
	}
}
