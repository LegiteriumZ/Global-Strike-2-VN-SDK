using Assets.Scripts.Utility.Sound;
using Assets.Sources.Chat;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Chat;
using Assets.Sources.Constant;
using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlayerLogoutHandler : ApcPacketHandler<PlayerLogoutData>
{
	private BattleRoomContext _battleRoomContext;

	private ChatContext _chatContext;

	public PlayerLogoutHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 10;
	}

	public override void Handle(PlayerLogoutData data)
	{
		LobbyInfoComponent lobbyInfo = _battleRoomContext.lobbyInfo;
		if (lobbyInfo.Id2CidDic.TryGetValue(data.Id, out var value))
		{
			lobbyInfo.Cid2IdDic.Remove(value);
			lobbyInfo.Cid2NameDic.Remove(value);
			lobbyInfo.Cid2CountryCodeDic.Remove(value);
			lobbyInfo.Id2CidDic.Remove(data.Id);
			MonoBehaviourSingleton<AutoSoundManager>.Instance.RemovePlayerAutoSoundInfo(value);
			_battleRoomContext.playerInfo.StatusDatas.Remove(value);
		}
		if (data.IsBot)
		{
			return;
		}
		if (lobbyInfo.NotBotPlayerEntityLoginInList.Contains(data.Id))
		{
			lobbyInfo.NotBotPlayerEntiyLoginOutList.Add(data.Id);
			lobbyInfo.NotBotPlayerEntityLoginInList.Remove(data.Id);
		}
		if (_chatContext.hasChatJobHistroy)
		{
			ChatJobHistroyComponent chatJobHistroy = _chatContext.chatJobHistroy;
			ChatHononaryData chatHononaryData = default(ChatHononaryData);
			chatHononaryData.PlayerName = data.Name;
			chatHononaryData.HeroWeapon = data.HeroWeapon;
			chatHononaryData.LegendWeapon = data.LegendWeapon;
			chatHononaryData.IsObserver = data.IsObserver;
			chatHononaryData.Id = data.Id;
			chatHononaryData.Team = 2;
			chatHononaryData.Changed = true;
			chatHononaryData.MsgType = "playerlogout";
			if (!data.IsObserver && !RuleUtilty.IsPersonlKillInfo(_battleRoomContext.roomData.Data.RaceType))
			{
				chatHononaryData.Team = data.Team;
			}
			chatHononaryData.AlphaData.RemainTime = 5000;
			chatHononaryData.AlphaData.AlphaRemainTime = 100;
			_battleRoomContext.playerInfo.DeleteOneKillInfo(data.Id);
			chatJobHistroy.Tips.Group.Insert(0, chatHononaryData);
			if (chatJobHistroy.Tips.Group.Count > 4)
			{
				chatJobHistroy.Tips.Group.RemoveAt(chatJobHistroy.Tips.Group.Count - 1);
			}
			chatJobHistroy.Tips.Mark = true;
		}
	}
}
