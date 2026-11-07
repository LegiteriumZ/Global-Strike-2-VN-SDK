using System.Collections.Generic;
using System.Text;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Info.GameRule;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.SimpleJson;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CallBackRoomDataHandler : ApcPacketHandler<RoomData>
{
	private readonly BattleRoomContext _battleRoomContext;

	private readonly GameRuleContext _gameRuleContext;

	private readonly BattleServerContext _battleServerContext;

	public CallBackRoomDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_battleServerContext = contexts.battleServer;
	}

	public override int MethodId()
	{
		return 12;
	}

	public override void Handle(RoomData data)
	{
		BattleModel gameModel = GameModelLocator.GetInstance().GameModel;
		gameModel.RoomData = EntityDataExtension.CloneRoomData(data, gameModel.RoomData);
		gameModel.IsMatch = data.IsMatch;
		UIDataManager.Instance.FreeType = data.FreeType;
		_battleRoomContext.roomData.Data = EntityDataExtension.CloneRoomData(data, _battleRoomContext.roomData.Data);
		int realRaceType = RuleUtilty.GetRealRaceType(_battleRoomContext);
		if (realRaceType > 0)
		{
			_battleRoomContext.roomData.Data.RaceType = realRaceType;
		}
		_gameRuleContext.ReplaceCurrentRule(GameRuleFactory.Instance.GetGameRule(_battleRoomContext.roomData.Data.RaceType));
		GlobalProperties.Instance.Properties["RaceType"] = _battleRoomContext.roomData.Data.RaceType;
		GlobalProperties.Instance.Properties["FreeType"] = _battleRoomContext.roomData.Data.FreeType;
		InitLootList(data.RaceType, data.PveLevel);
		setBattleRaceType();
	}

	private void setBattleRaceType()
	{
		UnityProxyData unityProxyData = new UnityProxyData
		{
			Type = UnityProxyType.CALLMSG,
			Func = "setBattleRaceType",
			Key = TplManager.Instance.GameBootConfig.Sign
		};
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add("raceType", _battleRoomContext.roomData.Data.RaceType);
		unityProxyData.Params.Add(Encoding.Default.GetBytes(JsonEncoder.Encode(dictionary)));
		_battleServerContext.battleServer.Server.SendTcpMessage(23, unityProxyData);
	}

	public void InitLootList(int raceType, int pveLevel)
	{
		switch (raceType)
		{
		case 1005:
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "revolver_tube";
				_battleRoomContext.roomData.LootList[1] = "saw";
				_battleRoomContext.roomData.LootList[2] = "jackhammer";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "rpk_an";
				_battleRoomContext.roomData.LootList[1] = "ad16";
				_battleRoomContext.roomData.LootList[2] = "deagle_glory";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "beer_bottle";
				_battleRoomContext.roomData.LootList[1] = "kac_reaper2";
				_battleRoomContext.roomData.LootList[2] = "m4a1_zy";
				break;
			}
			_battleRoomContext.roomData.LootList[3] = "crystal_blue";
			return;
		case 1002:
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "mace";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "ak47_zs";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "usp_neptune";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "double_deagle_g";
			_battleRoomContext.roomData.LootList[2] = "m4";
			_battleRoomContext.roomData.LootList[3] = "crystal_blue";
			return;
		case 1004:
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "grenade_ice";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "m1887_y";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "m1911_jupiter";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "double_deagle_g";
			_battleRoomContext.roomData.LootList[2] = "double_maul";
			_battleRoomContext.roomData.LootList[3] = "crystal_blue";
			return;
		case 1003:
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "m1932_th";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "longsun";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "gloves_metal";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "double_fangs";
			_battleRoomContext.roomData.LootList[2] = "kac_reaper";
			_battleRoomContext.roomData.LootList[3] = "crystal_blue";
			return;
		case 1001:
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "jms_fight";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "m4a1_pluto";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "m500_fire";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "deagle_g";
			_battleRoomContext.roomData.LootList[2] = "scar";
			_battleRoomContext.roomData.LootList[3] = "crystal_blue";
			return;
		}
		if (RuleUtilty.IsRpgNormal(raceType))
		{
			if (pveLevel == 4)
			{
				_battleRoomContext.roomData.LootList[0] = "matrixbox";
			}
			else
			{
				_battleRoomContext.roomData.LootList[0] = "luckybox";
			}
			_battleRoomContext.roomData.LootList[1] = "EXP";
			_battleRoomContext.roomData.LootList[2] = "coin";
			_battleRoomContext.roomData.LootList[3] = "crystal_bio";
		}
		else if (RuleUtilty.IsRpgJy(raceType))
		{
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "jingyingbox";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "jingyingbox_purple";
				break;
			case 4:
				_battleRoomContext.roomData.LootList[0] = "matrixbox";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "jingyingbox_green";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "EXP";
			_battleRoomContext.roomData.LootList[2] = "coin";
			_battleRoomContext.roomData.LootList[3] = "crystal_bio";
		}
		else if (RuleUtilty.IsRpgShiLian(raceType))
		{
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "shilianbox";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "shilianbox_purple";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "shilianbox_green";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "EXP";
			_battleRoomContext.roomData.LootList[2] = "coin";
			_battleRoomContext.roomData.LootList[3] = "crystal_bio";
		}
		else if (RuleUtilty.IsRpgJueXing(raceType))
		{
			switch (pveLevel)
			{
			case 2:
				_battleRoomContext.roomData.LootList[0] = "juexingbox";
				break;
			case 3:
				_battleRoomContext.roomData.LootList[0] = "juexingbox_purple";
				break;
			default:
				_battleRoomContext.roomData.LootList[0] = "juexingbox_green";
				break;
			}
			_battleRoomContext.roomData.LootList[1] = "EXP";
			_battleRoomContext.roomData.LootList[2] = "coin";
			_battleRoomContext.roomData.LootList[3] = "";
		}
		else if (RuleUtilty.IsRpgWuJin(raceType))
		{
			_battleRoomContext.roomData.LootList[0] = "obsidian";
			_battleRoomContext.roomData.LootList[1] = "";
			_battleRoomContext.roomData.LootList[2] = "master_point";
			_battleRoomContext.roomData.LootList[3] = "";
		}
		else if (RuleUtilty.IsMultipleRpg(raceType))
		{
			_battleRoomContext.roomData.LootList[0] = "tuxihuiji";
			_battleRoomContext.roomData.LootList[1] = "";
			_battleRoomContext.roomData.LootList[2] = "";
			_battleRoomContext.roomData.LootList[3] = "";
		}
	}
}
