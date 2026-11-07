using System.Collections.Generic;
using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Timer;
using I2.Loc;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Modules.GameRule.Pve;

public class HpProgressDataSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private bool _isGeneralPve;

	private bool _isAcg;

	private bool _showGateUnderAttack;

	private bool _showHp;

	private SceneObjectContext _sceneObjectContext;

	private MessageContext _messageContext;

	private TimeComponent _timeComponent;

	private TimeContext _timeContext;

	private SSJJTimer _hpTimer;

	private SSJJTimer _ShieldHpTimer;

	private long _homeHp;

	private float _totalHpPercent;

	private int HP;

	public HpProgressDataSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_isGeneralPve = contexts.gameRule.currentRule.Rule.IsGeneralPve();
		_isAcg = contexts.gameRule.currentRule.Rule.IsAcg();
		_showHp = contexts.gameRule.currentRule.Rule.IsShowTargetHp();
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_messageContext = contexts.message;
		_timeComponent = contexts.time.time;
		_timeContext = contexts.time;
		_hpTimer = new SSJJTimer(1000);
		_showGateUnderAttack = _gameRuleContext.currentRule.Rule.IsShowGateUnderAttack();
	}

	public bool NeedStart(Contexts contexts)
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (!_gameRuleContext.currentRule.Rule.IsPve() && raceType != 28 && !RuleUtilty.IsMultipleRpg(raceType))
		{
			return _gameRuleContext.currentRule.Rule.IsAcg();
		}
		return true;
	}

	public void OnPlayback()
	{
		UpdateBossHp();
		UpdateEliteHp();
		UpdateBotHp(_timeComponent.FrameInterval);
		UpdateHomeHp();
		UpdateTarget();
		UpdateEliteTarget();
		UpdateTargetAddLife();
		if (_isAcg)
		{
			UpdateAcgTargetHp();
		}
	}

	private void UpdateEliteTarget()
	{
		if (_gameRuleContext.hpProgressData.EliteTargetId == 0 || _gameRuleContext.hpProgressData.BotId > 0)
		{
			return;
		}
		int eliteTargetId = _gameRuleContext.hpProgressData.EliteTargetId;
		_gameRuleContext.hpProgressData.EliteTargetId = 0;
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(eliteTargetId);
		if (entityWithEntityId != null)
		{
			int eliteId = _gameRuleContext.hpProgressData.EliteId;
			_gameRuleContext.hpProgressData.EliteId = eliteTargetId;
			NotifyManager.ForceInvoke(17);
			if (eliteId != eliteTargetId)
			{
				SetEliteData(entityWithEntityId);
			}
		}
	}

	private void UpdateTarget()
	{
		if (_gameRuleContext.hpProgressData.TargetId == 0)
		{
			return;
		}
		int targetId = _gameRuleContext.hpProgressData.TargetId;
		_gameRuleContext.hpProgressData.TargetId = 0;
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(targetId);
		if (entityWithEntityId == null)
		{
			return;
		}
		if (entityWithEntityId.basicInfo.Current.IsBot)
		{
			if (_isGeneralPve)
			{
				if (entityWithEntityId.basicInfo.Current.BotQuality > 2)
				{
					int bossId = _gameRuleContext.hpProgressData.BossId;
					_gameRuleContext.hpProgressData.BossId = targetId;
					NotifyManager.ForceInvoke(18);
					if (bossId != targetId)
					{
						SetBossData(entityWithEntityId);
					}
					return;
				}
				if (entityWithEntityId.basicInfo.Current.BotQuality > 0)
				{
					int eliteId = _gameRuleContext.hpProgressData.EliteId;
					_gameRuleContext.hpProgressData.EliteId = targetId;
					NotifyManager.ForceInvoke(17);
					if (eliteId != targetId)
					{
						SetEliteData(entityWithEntityId);
					}
					return;
				}
				int botId = _gameRuleContext.hpProgressData.BotId;
				_gameRuleContext.hpProgressData.BotId = targetId;
				NotifyManager.ForceInvoke(16);
				_gameRuleContext.hpProgressData.BotShowTime = 3000;
				if (botId != targetId)
				{
					SetBotData(entityWithEntityId);
				}
			}
			else if (_isAcg)
			{
				if (entityWithEntityId.basicInfo.Current.BotQuality != 0)
				{
					int acgTargetId = _gameRuleContext.hpProgressData.AcgTargetId;
					_gameRuleContext.hpProgressData.AcgTargetId = targetId;
					NotifyManager.ForceInvoke(100);
					if (acgTargetId != targetId)
					{
						SetAcgTargetData(entityWithEntityId);
					}
				}
			}
			else
			{
				int botId2 = _gameRuleContext.hpProgressData.BotId;
				_gameRuleContext.hpProgressData.BotId = targetId;
				NotifyManager.ForceInvoke(16);
				_gameRuleContext.hpProgressData.BotShowTime = 3000;
				if (botId2 != targetId)
				{
					SetBotData(entityWithEntityId);
				}
			}
		}
		else if (_showHp)
		{
			int botId3 = _gameRuleContext.hpProgressData.BotId;
			_gameRuleContext.hpProgressData.BotId = targetId;
			NotifyManager.ForceInvoke(16);
			_gameRuleContext.hpProgressData.BotShowTime = 3000;
			if (botId3 != targetId)
			{
				SetBotData(entityWithEntityId);
			}
		}
	}

	private void UpdateAcgTargetHp()
	{
		if (_gameRuleContext.hpProgressData.AcgTargetId == 0)
		{
			return;
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.AcgTargetId);
		if (entityWithEntityId == null)
		{
			_gameRuleContext.hpProgressData.AcgTargetId = 0;
			return;
		}
		if (entityWithEntityId.IsDead())
		{
			_gameRuleContext.hpProgressData.AcgTargetHpPercent = 0f;
			_gameRuleContext.hpProgressData.BotId = 0;
			return;
		}
		_gameRuleContext.hpProgressData.AcgTargetHpPercent = (float)entityWithEntityId.basicInfo.Current.Hp / (float)entityWithEntityId.basicInfo.Current.MaxHp;
		if (!_timeContext.commonTimer.CommonTimer.ContainsKey("ACGHPDAMAGED") || _gameRuleContext.hpProgressData.AcgLastTargetId != _gameRuleContext.hpProgressData.AcgTargetId)
		{
			_gameRuleContext.hpProgressData.AcgTargetHpDamagePercent = _gameRuleContext.hpProgressData.AcgTargetHpPercent;
			_hpTimer.ResetTimer();
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACGHPDAMAGED", _hpTimer);
		}
		_gameRuleContext.hpProgressData.AcgLastHp = entityWithEntityId.basicInfo.Current.Hp;
		_gameRuleContext.hpProgressData.AcgTargetShieldHpPercent = (float)entityWithEntityId.basicInfo.Current.ShieldHp / (float)entityWithEntityId.basicInfo.Current.ShieldMaxHp;
		_gameRuleContext.hpProgressData.AcgLastTargetId = _gameRuleContext.hpProgressData.AcgTargetId;
	}

	private void SetAcgTargetData(PlayerEntity targetPlayer)
	{
		_gameRuleContext.hpProgressData.AcgTargetName = targetPlayer.basicInfo.PlayerName;
		_gameRuleContext.hpProgressData.AcgTargetCareer = targetPlayer.basicInfo.Current.Career;
		_gameRuleContext.hpProgressData.AcgTargetLevel = targetPlayer.basicInfo.Current.BotLv;
		_gameRuleContext.hpProgressData.AcgTarget = (HpProgressDataComponent.AcgTargetType)targetPlayer.basicInfo.Current.BotQuality;
		_gameRuleContext.hpProgressData.AcgLastHp = targetPlayer.basicInfo.Current.Hp;
		_gameRuleContext.hpProgressData.AcgTargetElement = targetPlayer.basicInfo.Current.Elemental;
		_gameRuleContext.hpProgressData.AcgTargetAttributes = _gameRuleContext.acgEnemyInfo.AcgEnemyAttribute[targetPlayer.basicInfo.Current.Id];
	}

	private void UpdateHomeHp()
	{
		if (_gameRuleContext.hpProgressData.HomeId == 0)
		{
			return;
		}
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.HomeId);
		long num = 0L;
		long num2 = 0L;
		if (entityWithEntityId != null)
		{
			num = entityWithEntityId.pveTower.Data.Hp;
			num2 = entityWithEntityId.pveTower.Data.MaxHp;
		}
		else
		{
			PlayerEntity entityWithEntityId2 = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.HomeId);
			if (entityWithEntityId2 == null || entityWithEntityId2.GetCareer() == PlayerCareerConstantUtility.Rpg10500002)
			{
				_gameRuleContext.hpProgressData.HomeHpPercent = 0f;
				return;
			}
			num = entityWithEntityId2.basicInfo.Current.Hp;
			num2 = entityWithEntityId2.basicInfo.Current.MaxHp;
		}
		_gameRuleContext.hpProgressData.HomeHpPercent = ((num2 > 0) ? ((float)num / (float)num2) : 0f);
		if (_homeHp != num && num != num2)
		{
			_homeHp = num;
			if (_showGateUnderAttack)
			{
				_messageContext.gameTipsShow.TipsEvent.Add(new RpgTipsEventData
				{
					TypeId = -2528
				});
				NotifyManager.ForceInvoke(14);
			}
		}
	}

	private void UpdateTargetAddLife()
	{
		if (_gameRuleContext.hpProgressData.BossId != 0)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.BossId);
			if (entityWithEntityId != null)
			{
				_ = entityWithEntityId.basicInfo.Current.ExtraLifeMax;
				_totalHpPercent = (float)entityWithEntityId.basicInfo.Current.Hp / (float)entityWithEntityId.basicInfo.Current.MaxHp;
				_gameRuleContext.hpProgressData.BossHpPercent = _totalHpPercent;
				_gameRuleContext.hpProgressData.BossHudunPercent = ((entityWithEntityId.basicInfo.Current.MaxHudun > 0) ? ((float)entityWithEntityId.basicInfo.Current.Hudun / (float)entityWithEntityId.basicInfo.Current.MaxHudun) : 0f);
				_gameRuleContext.hpProgressData.BossZhuangjiaPercent = ((entityWithEntityId.basicInfo.Current.MaxZhuangjia > 0) ? ((float)entityWithEntityId.basicInfo.Current.Zhuangjia / (float)entityWithEntityId.basicInfo.Current.MaxZhuangjia) : 0f);
				_gameRuleContext.hpProgressData.lifeBarSeq = entityWithEntityId.basicInfo.Current.LifeBarSeq;
				_gameRuleContext.hpProgressData.BossMaxHudun = entityWithEntityId.basicInfo.Current.MaxHudun;
				_gameRuleContext.hpProgressData.BossMaxZhuangjia = entityWithEntityId.basicInfo.Current.MaxZhuangjia;
				_gameRuleContext.hpProgressData.BossMaxHp = entityWithEntityId.basicInfo.Current.MaxHp;
				_gameRuleContext.hpProgressData.BossHudun = entityWithEntityId.basicInfo.Current.Hudun;
				_gameRuleContext.hpProgressData.BossZhuangjia = entityWithEntityId.basicInfo.Current.Zhuangjia;
				_gameRuleContext.hpProgressData.BossHp = entityWithEntityId.basicInfo.Current.Hp;
				_gameRuleContext.hpProgressData.isLock = entityWithEntityId.basicInfo.Current.IsLockBlood;
				_gameRuleContext.hpProgressData.lockPercent = entityWithEntityId.basicInfo.Current.LockBloodPercent;
				_gameRuleContext.hpProgressData.currentLifeBarSeq = entityWithEntityId.basicInfo.Current.CurrentLifeBarSeq;
				_gameRuleContext.hpProgressData.CritDefHp = entityWithEntityId.basicInfo.Current.CritDefHp;
				_gameRuleContext.hpProgressData.CritDefHpPercent = (float)entityWithEntityId.basicInfo.Current.CritDefHp / (float)entityWithEntityId.basicInfo.Current.CritDefMaxHp;
				_gameRuleContext.hpProgressData.CritDefMaxHp = entityWithEntityId.basicInfo.Current.CritDefMaxHp;
				_gameRuleContext.hpProgressData.CritRateDefHpPercent = (float)entityWithEntityId.basicInfo.Current.CritRateDefHp / (float)entityWithEntityId.basicInfo.Current.CritRateDefMaxHp;
				_gameRuleContext.hpProgressData.CritRateDefHp = entityWithEntityId.basicInfo.Current.CritRateDefHp;
				_gameRuleContext.hpProgressData.CritRateDefMaxHp = entityWithEntityId.basicInfo.Current.CritRateDefMaxHp;
				_gameRuleContext.hpProgressData.IsCritDefBreak = entityWithEntityId.basicInfo.Current.IsCritDefBreak;
				_gameRuleContext.hpProgressData.IsCritRateDefBreak = entityWithEntityId.basicInfo.Current.IsCritRateDefBreak;
			}
		}
	}

	private void UpdateBossHp()
	{
		if (_gameRuleContext.hpProgressData.BossId == 0)
		{
			return;
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.BossId);
		if (entityWithEntityId == null)
		{
			if (!RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
			{
				_gameRuleContext.hpProgressData.BossId = 0;
			}
			for (int i = 0; i < _gameRuleContext.hpProgressData.BossRuoDian.Count; i++)
			{
				_gameRuleContext.hpProgressData.BossRuoDian[i].Texture = "";
			}
			return;
		}
		_gameRuleContext.hpProgressData.ExtraLife = entityWithEntityId.basicInfo.Current.ExtraLife;
		int num = entityWithEntityId.basicInfo.Current.ExtraLife % 5;
		float bossCurPercent = (float)entityWithEntityId.basicInfo.Current.Hp / (float)entityWithEntityId.basicInfo.Current.MaxHp;
		switch (num)
		{
		case 4:
			_gameRuleContext.hpProgressData.BossHpProgressImage = "bossHp5";
			_gameRuleContext.hpProgressData.BossHpBackImage = "bossHp4";
			_gameRuleContext.hpProgressData.BossCurPercent = bossCurPercent;
			break;
		case 3:
			_gameRuleContext.hpProgressData.BossHpProgressImage = "bossHp4";
			_gameRuleContext.hpProgressData.BossHpBackImage = "bossHp3";
			_gameRuleContext.hpProgressData.BossCurPercent = bossCurPercent;
			break;
		case 2:
			_gameRuleContext.hpProgressData.BossHpProgressImage = "bossHp3";
			_gameRuleContext.hpProgressData.BossHpBackImage = "bossHp2";
			_gameRuleContext.hpProgressData.BossCurPercent = bossCurPercent;
			break;
		case 1:
			_gameRuleContext.hpProgressData.BossHpProgressImage = "bossHp2";
			_gameRuleContext.hpProgressData.BossHpBackImage = "bossHp1";
			_gameRuleContext.hpProgressData.BossCurPercent = bossCurPercent;
			break;
		case 0:
			_gameRuleContext.hpProgressData.BossHpProgressImage = "bossHp1";
			if (entityWithEntityId.basicInfo.Current.ExtraLife > 0)
			{
				_gameRuleContext.hpProgressData.BossHpBackImage = "bossHp5";
			}
			else
			{
				_gameRuleContext.hpProgressData.BossHpBackImage = "";
			}
			_gameRuleContext.hpProgressData.BossCurPercent = bossCurPercent;
			break;
		}
		_gameRuleContext.hpProgressData.BossShieldPercent = ((entityWithEntityId.basicInfo.Current.ShieldMaxHp > 0) ? ((float)entityWithEntityId.basicInfo.Current.ShieldHp / (float)entityWithEntityId.basicInfo.Current.ShieldMaxHp) : 0f);
		if (entityWithEntityId.basicInfo.Current.WeakNessHost == null)
		{
			return;
		}
		List<WeaknessData> weakList = entityWithEntityId.basicInfo.Current.WeakNessHost.WeakList;
		int j = 0;
		if (weakList != null)
		{
			for (; j < weakList.Count; j++)
			{
				_gameRuleContext.hpProgressData.BossRuoDian[j].HpPercent = ((weakList[j].HpMax > 0) ? ((float)weakList[j].Hp / (float)weakList[j].HpMax) : 0f);
				_gameRuleContext.hpProgressData.BossRuoDian[j].Texture = "fuwen" + weakList[j].Res;
			}
			if (weakList.Count == 5)
			{
				_gameRuleContext.hpProgressData.BossRuoDian[0].Texture = "";
			}
		}
		for (; j < _gameRuleContext.hpProgressData.BossRuoDian.Count; j++)
		{
			_gameRuleContext.hpProgressData.BossRuoDian[j].Texture = "";
		}
	}

	private void UpdateEliteHp()
	{
		if (_gameRuleContext.hpProgressData.EliteId != 0)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.EliteId);
			if (entityWithEntityId == null)
			{
				_gameRuleContext.hpProgressData.EliteId = 0;
			}
			else
			{
				_gameRuleContext.hpProgressData.EliteHpPercent = (float)entityWithEntityId.basicInfo.Current.Hp / (float)entityWithEntityId.basicInfo.Current.MaxHp;
			}
		}
	}

	private void UpdateBotHp(int frameInterval)
	{
		if (_gameRuleContext.hpProgressData.BotId != 0)
		{
			_gameRuleContext.hpProgressData.BotShowTime -= frameInterval;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.BotId);
			if (entityWithEntityId == null)
			{
				_gameRuleContext.hpProgressData.BotId = 0;
			}
			else if (entityWithEntityId.IsDead() || _gameRuleContext.hpProgressData.BotShowTime <= 0)
			{
				_gameRuleContext.hpProgressData.BotHpPercent = 0f;
				_gameRuleContext.hpProgressData.BotId = 0;
			}
			else
			{
				_gameRuleContext.hpProgressData.BotHpPercent = (float)entityWithEntityId.basicInfo.Current.Hp / (float)entityWithEntityId.basicInfo.Current.MaxHp;
			}
		}
	}

	private void SetBotData(PlayerEntity targetPlayer)
	{
		_gameRuleContext.hpProgressData.BotName = targetPlayer.basicInfo.PlayerName;
		_gameRuleContext.hpProgressData.BotLevel = targetPlayer.basicInfo.Current.BotLv;
		GetAttribute(_gameRuleContext.hpProgressData.BotAttribute, targetPlayer.basicInfo.Current);
		_gameRuleContext.hpProgressData.BotRaceInfo = GetRaceInfo(targetPlayer);
		_gameRuleContext.hpProgressData.titleid = targetPlayer.basicInfo.Current.TitleId;
	}

	private void SetEliteData(PlayerEntity targetPlayer)
	{
		_gameRuleContext.hpProgressData.EliteName = targetPlayer.basicInfo.PlayerName;
		_gameRuleContext.hpProgressData.EliteLevel = targetPlayer.basicInfo.Current.BotLv;
		GetAttribute(_gameRuleContext.hpProgressData.EliteAttribute, targetPlayer.basicInfo.Current);
		_gameRuleContext.hpProgressData.EliteRaceInfo = GetRaceInfo(targetPlayer);
	}

	private void SetBossData(PlayerEntity targetPlayer)
	{
		_gameRuleContext.hpProgressData.BossName = targetPlayer.basicInfo.PlayerName;
		_gameRuleContext.hpProgressData.BossCareer = targetPlayer.basicInfo.Current.Career;
		_gameRuleContext.hpProgressData.BossType = targetPlayer.basicInfo.Current.BotQuality;
		_gameRuleContext.hpProgressData.BossLevel = targetPlayer.basicInfo.Current.BotLv;
		GetAttribute(_gameRuleContext.hpProgressData.BossAttribute, targetPlayer.basicInfo.Current);
		_gameRuleContext.hpProgressData.BossRaceInfo = GetRaceInfo(targetPlayer);
		_gameRuleContext.hpProgressData.CritHpBgName = CritHpBgName(targetPlayer);
	}

	private void GetAttribute(string[] attribute, PlayerEntityData data)
	{
		int i = 0;
		attribute[i++] = GetPhysicsReduce((int)data.AdrrNum);
		attribute[i++] = GetEnergyReduce((int)data.MdrrNum);
		for (; i < 2; i++)
		{
			attribute[i] = "";
		}
		i = 2;
		if (data.MdrrNumBreak >= data.AdrrNumBreak && data.MdrrNumBreak > 0f)
		{
			attribute[i++] = ScriptLocalization.Get("MDRRNUMBREAK_STRING");
		}
		else if (data.MdrrNumBreak < data.AdrrNumBreak)
		{
			attribute[i++] = ScriptLocalization.Get("ADRRNUMBREAK_STRING");
		}
		for (; i < 4; i++)
		{
			attribute[i] = "";
		}
		i = 4;
		attribute[i++] = GetCritDef(data.CritDef);
		attribute[i++] = GetCritRateDef(data.CritRateDef);
		for (; i < 6; i++)
		{
			attribute[i] = "";
		}
	}

	private List<string> GetRaceInfo(PlayerEntity targetPlayer)
	{
		List<string> list = new List<string>();
		FlagInfoData flagInfo = targetPlayer.basicInfo.Current.FlagInfo;
		if (flagInfo != null)
		{
			byte[] context = flagInfo.Context;
			if (context != null)
			{
				for (int i = 0; i < 18; i++)
				{
					int num = i / 8;
					if (num < context.Length)
					{
						byte num2 = context[num];
						int num3 = i % 8;
						int num4 = 1 << num3;
						if ((num2 & num4) > 0)
						{
							list.Add(ScriptLocalization.Get("raceName" + i));
						}
					}
				}
			}
		}
		return list;
	}

	private string CritHpBgName(PlayerEntity targetPlayer)
	{
		if (targetPlayer.basicInfo.Current.CritRateDefMaxHp > 0 && targetPlayer.basicInfo.Current.CritDefMaxHp > 0)
		{
			return "bg1";
		}
		if (targetPlayer.basicInfo.Current.CritRateDefMaxHp > 0)
		{
			return "bg2";
		}
		return "bg0";
	}

	private string GetEnergyIncrease(float value)
	{
		int num = (int)(value * 1000f);
		if (num == 0)
		{
			return "";
		}
		if (num <= 400)
		{
			return "hujia1";
		}
		if (num <= 600)
		{
			return "hujia2";
		}
		if (num <= 999)
		{
			return "hujia3";
		}
		return "";
	}

	private string GetPhysicsIncrease(float value)
	{
		int num = (int)(value * 1000f);
		if (num == 0)
		{
			return "";
		}
		if (num <= 400)
		{
			return "hujia1";
		}
		if (num <= 600)
		{
			return "hujia2";
		}
		if (num <= 999)
		{
			return "hujia3";
		}
		return "";
	}

	private string GetPhysicsReduce(int physicsReduceInt)
	{
		if (physicsReduceInt == 0)
		{
			return "";
		}
		if (physicsReduceInt <= 400)
		{
			return "hujia1";
		}
		if (physicsReduceInt <= 600)
		{
			return "hujia2";
		}
		if (physicsReduceInt <= 999)
		{
			return "hujia3";
		}
		return "";
	}

	private string GetEnergyReduce(int energyReduceInt)
	{
		if (energyReduceInt == 0)
		{
			return "";
		}
		if (energyReduceInt <= 400)
		{
			return "lichang1";
		}
		if (energyReduceInt <= 600)
		{
			return "lichang2";
		}
		if (energyReduceInt <= 999)
		{
			return "lichang3";
		}
		return "";
	}

	private string GetCritDef(float critDef)
	{
		if (0f >= critDef)
		{
			return "";
		}
		if (critDef <= 0.5f)
		{
			return "critDef1";
		}
		if (critDef <= 1f)
		{
			return "critDef2";
		}
		if (critDef <= 2f)
		{
			return "critDef3";
		}
		return "critDef4";
	}

	private string GetCritRateDef(float critRateDef)
	{
		if (0f >= critRateDef)
		{
			return "";
		}
		if (critRateDef <= 1f)
		{
			return "critRateDef1";
		}
		if (critRateDef <= 3f)
		{
			return "critRateDef2";
		}
		if (critRateDef <= 6f)
		{
			return "critRateDef3";
		}
		return "critRateDef4";
	}
}
