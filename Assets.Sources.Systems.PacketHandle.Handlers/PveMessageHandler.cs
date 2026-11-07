using Assets.Sources.Constant;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PveMessageHandler : ApcPacketHandler<PveMessageData>
{
	private BattleRoomContext _battleRoomContext;

	private MessageContext _messageContext;

	public PveMessageHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 71;
	}

	public override void Handle(PveMessageData data)
	{
		_messageContext.pveMessage.PveMessageData = data;
		if (!string.IsNullOrEmpty(data.PlayerName))
		{
			_messageContext.pveUIMessage.PlayerName = data.PlayerName;
		}
		if (data.Type == TowerDefenseMessageType.RELIVEPLAYER)
		{
			_messageContext.pveUIMessage.Reliveteammate = true;
		}
		else if (data.Type == TowerDefenseMessageType.KILLBOSS)
		{
			_messageContext.pveUIMessage.KillBoss = true;
		}
		else if (data.Type == TowerDefenseMessageType.COPYWEAPON)
		{
			_messageContext.pveUIMessage.Weaponname = data.WeaponName;
			_messageContext.pveUIMessage.Permancentweapon = data.Permanent;
			_messageContext.pveUIMessage.Copyweapon = true;
		}
		RpgTipsEventData rpgTipsEventData = new RpgTipsEventData();
		RpgTipsEventData rpgTipsEventData2 = new RpgTipsEventData();
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (RuleUtilty.IsRpg(raceType))
		{
			TowerDefenseMessageType type = data.Type;
			if (type == TowerDefenseMessageType.GAMESTART)
			{
				if (RuleUtilty.IsSneakRule(raceType))
				{
					rpgTipsEventData.TypeId = -2529;
					rpgTipsEventData.Time1 = data.Time;
				}
				else if (RuleUtilty.IsRpgProtectMode(raceType))
				{
					rpgTipsEventData.TypeId = -2523;
					rpgTipsEventData.Time1 = data.Time;
				}
				else if (raceType == 18000)
				{
					rpgTipsEventData.TypeId = -12601;
					rpgTipsEventData.Time1 = data.Time;
				}
				else if (RuleUtilty.IsRpgTower(raceType))
				{
					rpgTipsEventData.TypeId = -2523;
					rpgTipsEventData.Time1 = data.Time;
				}
				else if (RuleUtilty.IsRpgTreasureBoss(raceType))
				{
					rpgTipsEventData.TypeId = -2523;
					rpgTipsEventData.Time1 = 0;
				}
				else if (RuleUtilty.IsBaseRun(raceType))
				{
					rpgTipsEventData.TypeId = -2522;
					rpgTipsEventData.Time1 = data.Time;
				}
				else
				{
					rpgTipsEventData.TypeId = -2522;
					rpgTipsEventData.Time1 = data.Time;
				}
				if (!RuleUtilty.IsMultipleRpg(raceType))
				{
					if (RuleUtilty.IsRpgShiLian(raceType) || RuleUtilty.IsRpgWuJin(raceType))
					{
						rpgTipsEventData2.TypeId = -2525;
						rpgTipsEventData2.Time1 = data.Time;
					}
					else
					{
						switch (raceType)
						{
						case 18000:
							rpgTipsEventData2.TypeId = -12602;
							rpgTipsEventData2.Time1 = data.Time;
							break;
						case 18001:
							rpgTipsEventData2.TypeId = -2526;
							rpgTipsEventData2.Time1 = 0;
							break;
						default:
							if (!RuleUtilty.IsBaseRun(raceType))
							{
								if (RuleUtilty.IsRpgTreasureBoss(raceType))
								{
									rpgTipsEventData2.Time1 = 0;
								}
								else if (raceType != 18605)
								{
									rpgTipsEventData2.TypeId = -2526;
									rpgTipsEventData2.Time1 = data.Time;
								}
							}
							break;
						case 18009:
							break;
						}
					}
				}
			}
		}
		if (rpgTipsEventData.TypeId == 0)
		{
			switch (data.Type)
			{
			case TowerDefenseMessageType.ONTRRIGER:
				rpgTipsEventData.TypeId = -2500;
				break;
			case TowerDefenseMessageType.DOORBREAK:
				rpgTipsEventData.TypeId = -2501;
				break;
			case TowerDefenseMessageType.LASTONEMNOTICE:
				rpgTipsEventData.TypeId = -2502;
				rpgTipsEventData.Time1 = 59;
				break;
			case TowerDefenseMessageType.LASTFIVEMNOTICE:
				rpgTipsEventData.TypeId = -2503;
				rpgTipsEventData.Time1 = 59;
				break;
			case TowerDefenseMessageType.ENEMYRETREAT:
				rpgTipsEventData.TypeId = -2505;
				break;
			case TowerDefenseMessageType.ENEMYWAVE:
				rpgTipsEventData.TypeId = -2506;
				rpgTipsEventData.Time1 = data.Wave;
				break;
			case TowerDefenseMessageType.DOORINACTIVE:
				rpgTipsEventData.TypeId = -2507;
				break;
			case TowerDefenseMessageType.FIRSTAID:
				rpgTipsEventData.TypeId = -2508;
				break;
			case TowerDefenseMessageType.FIRSTAIDREADY:
				rpgTipsEventData.TypeId = -2509;
				break;
			case TowerDefenseMessageType.GAMESTART:
			{
				switch (raceType)
				{
				case 1002:
					rpgTipsEventData.TypeId = -2520;
					break;
				case 1003:
					rpgTipsEventData.TypeId = -2521;
					break;
				case 1005:
					rpgTipsEventData.TypeId = -2522;
					break;
				default:
					if (RuleUtilty.IsRpgSpecailMode(raceType))
					{
						rpgTipsEventData.TypeId = -2522;
					}
					else
					{
						rpgTipsEventData.TypeId = -2519;
					}
					break;
				}
				if (RuleUtilty.IsRpgSpecailMode(raceType))
				{
					rpgTipsEventData2.TypeId = -2526;
				}
				else
				{
					rpgTipsEventData2.TypeId = -2524;
				}
				int time2 = (rpgTipsEventData2.Time1 = data.Time);
				rpgTipsEventData.Time1 = time2;
				break;
			}
			case TowerDefenseMessageType.BOSSBEFALL:
				rpgTipsEventData.TypeId = -2512;
				rpgTipsEventData.Time1 = data.Wave;
				break;
			case TowerDefenseMessageType.INDANGER:
				rpgTipsEventData.TypeId = -2513;
				break;
			case TowerDefenseMessageType.MOREZOMBIE:
				rpgTipsEventData.TypeId = -2514;
				break;
			case TowerDefenseMessageType.LIGHTNINGBOUNDREADY:
				rpgTipsEventData.TypeId = -2515;
				break;
			case TowerDefenseMessageType.NOTENOUGHGP:
				rpgTipsEventData.TypeId = -2516;
				break;
			case TowerDefenseMessageType.NOTENOUGHMONEY:
				rpgTipsEventData.TypeId = -2517;
				break;
			case TowerDefenseMessageType.READY:
				rpgTipsEventData.TypeId = -2518;
				break;
			}
		}
		if (rpgTipsEventData.TypeId != 0)
		{
			_messageContext.gameTipsShow.TipsEvent.Add(rpgTipsEventData);
			_messageContext.gameTipsShow.TipsEvent.Add(rpgTipsEventData2);
			NotifyManager.ForceInvoke(14);
		}
	}
}
