using System.Collections.Generic;
using System.Text;
using Assets.Sources.Chat;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.BattleServer;
using Assets.Sources.Components.Chat;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using NetData;
using SSJJBase.SimpleJson;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlayerLoginHandler : ApcPacketHandler<PlayerLoginData>
{
	private BattleRoomContext _battleRoomContext;

	private ChatContext _chatContext;

	private BattleServerComponent _battleServerComponent;

	private Dictionary<string, string> _playercache = new Dictionary<string, string>();

	public PlayerLoginHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_chatContext = contexts.chat;
		_battleServerComponent = contexts.battleServer.battleServer;
	}

	public override int MethodId()
	{
		return 9;
	}

	public override void Handle(PlayerLoginData data)
	{
		LobbyInfoComponent lobbyInfo = _battleRoomContext.lobbyInfo;
		lobbyInfo.Id2CidDic[data.Id] = data.CharacterId;
		lobbyInfo.Cid2IdDic[data.CharacterId] = data.Id;
		lobbyInfo.Cid2NameDic[data.CharacterId] = data.PlayerName;
		lobbyInfo.Cid2CountryCodeDic[data.CharacterId] = data.CountryCode;
		if (data.IsBot)
		{
			return;
		}
		if (!lobbyInfo.NotBotPlayerEntityLoginInList.Contains(data.Id))
		{
			lobbyInfo.NotBotPlayerEntityLoginInList.Add(data.Id);
		}
		if (_chatContext.hasChatJobHistroy)
		{
			ChatJobHistroyComponent chatJobHistroy = _chatContext.chatJobHistroy;
			ChatHononaryData chatHononaryData = default(ChatHononaryData);
			chatHononaryData.Wait = 0;
			chatHononaryData.PlayerName = data.PlayerName;
			chatHononaryData.HeroWeapon = data.HeroWeapon;
			chatHononaryData.LegendWeapon = data.LegendWeapon;
			chatHononaryData.IsObserver = data.IsObserver;
			chatHononaryData.Cid = data.CharacterId;
			chatHononaryData.Id = data.Id;
			chatHononaryData.VipLevel = data.VipLv;
			chatHononaryData.Team = 2;
			chatHononaryData.Changed = true;
			chatHononaryData.MsgType = "playerlogin";
			if (!data.IsObserver && !RuleUtilty.IsPersonlKillInfo(_battleRoomContext.roomData.Data.RaceType))
			{
				chatHononaryData.Team = data.Team;
			}
			chatHononaryData.AlphaData.RemainTime = 5000;
			chatHononaryData.AlphaData.AlphaRemainTime = 100;
			_battleRoomContext.playerInfo.VipLevels[data.PlayerName] = data.VipLv;
			if (_battleRoomContext.playerInfo.CurrKillNums.ContainsKey(data.Id))
			{
				_battleRoomContext.playerInfo.CurrKillNums[data.Id] = data.CurKillNum;
			}
			_battleRoomContext.playerInfo.DeleteOneKillInfo(data.Id);
			if (data.Show)
			{
				chatJobHistroy.Tips.Group.Insert(0, chatHononaryData);
			}
			if (chatJobHistroy.Tips.Group.Count > 4)
			{
				chatJobHistroy.Tips.Group.RemoveAt(chatJobHistroy.Tips.Group.Count - 1);
			}
			chatJobHistroy.Tips.Mark = true;
			UnityProxyData unityProxyData = new UnityProxyData
			{
				Type = UnityProxyType.CALLMSG,
				Func = "getFriendlyFlag",
				Key = TplManager.Instance.GameBootConfig.Sign
			};
			_playercache["Cid"] = data.CharacterId.ToString();
			_playercache["PlayerName"] = data.PlayerName;
			unityProxyData.Params.Add(Encoding.Default.GetBytes(JsonEncoder.Encode(_playercache)));
			_battleServerComponent.Server.SendTcpMessage(23, unityProxyData);
		}
	}
}
