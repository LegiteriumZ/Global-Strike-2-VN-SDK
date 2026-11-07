using System;
using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Message.Common;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.UIChip;
using Assets.Sources.Utils.Ui;
using Assets.Sources.Utils.Weapon;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PvetdmessageModel : UIUpdateModel, TdQueue<ImgTxtShowCmd>.ISamePriorityProcess, ISetGameRuleContext, ISetMessageContext
{
	private PvetdmessageViewModel _viewModel;

	private bool _achievementInit;

	private float _rollOffset = -1f;

	private bool _bossVoidBall;

	private bool _sectionEnd;

	private TdQueue<ImgTxtShowCmd> _topUiQueue;

	private TdQueue<ImgTxtShowCmd> _centerUiQueue;

	private TdQueue<ImgTxtShowCmd> _downUiQueue;

	private int _aimAtLast;

	private bool _goldenSetRelive;

	private bool _petSetRelive;

	private int _energyNest = 5000;

	private bool _bossBattleTriggered;

	private int wave;

	private System.Random _random;

	private ChipGroup _topGroup;

	private ChipGroup _centerGroup;

	private ChipGroup _downGroup;

	private FloatChip _allShowAlphaChip = new FloatChip();

	private PingPongChip _textShowOffsetChip = new PingPongChip();

	private float _rolltime;

	private GameRuleContext _gameRuleContext;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PvetdmessageViewModel();
		_viewModel.bossShow = false;
		_topUiQueue = new TdQueue<ImgTxtShowCmd>(this);
		_centerUiQueue = new TdQueue<ImgTxtShowCmd>(this);
		_downUiQueue = new TdQueue<ImgTxtShowCmd>(this);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_pveMessage_PveMessageData, SetPveMessageData, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_HomeHpPercent, SetHomeHpPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveIncentiveView_Dirty, UpdateIncentiveMsg, null, initinvoke: true);
		NotifyManager.MakeNotify(1, UiIEventCondition.Get_pveUIMessage_MsgId, UpdateUiMsg);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveIncentiveTypeView_AchievementType, UpdateAchivement);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		_downUiQueue.Clear();
		_centerUiQueue.Clear();
		_topUiQueue.Clear();
		NotifyManager.RemoveUnused();
	}

	private void SetHomeHpPercent(float ov, float percent)
	{
		if (percent > 0f && percent < 1f)
		{
			TdQueue<ImgTxtShowCmd> topUiQueue = _topUiQueue;
			ImgTxtShowCmd item = new ImgTxtShowCmd
			{
				ResComponent = "messageImage"
			};
			if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 1002)
			{
				item.ResKey = "gateunderattack";
			}
			else
			{
				item.ResKey = "gateunderattack02";
			}
			item.Time = 5000;
			topUiQueue.Enqueue(item, 1);
		}
	}

	private void SetWeaponStateWhenReady()
	{
		_messageContext.pveUIMessage.CanBuyWeapon = true;
	}

	private void SetWeaponStateWhenReadyDone()
	{
		_messageContext.pveUIMessage.CanBuyWeapon = false;
	}

	private void SetDefaultWave()
	{
		_viewModel.wavetextAnchoredposition = new Vector2(124f, -211f);
	}

	private void SetBossFailWave()
	{
		_viewModel.wavetextAnchoredposition = new Vector2(200f, -211f);
	}

	private void SetLastfivemnotice(int frameinterval)
	{
		if (_random == null)
		{
			_random = new System.Random(Time.frameCount % 100);
		}
		_viewModel.countDownRandomTextString = _random.Next(0, 100).ToString();
	}

	private void SetStartfivemnoticeDone()
	{
		_viewModel.countDownSecondTextShow = true;
		_viewModel.countDownRandomTextShow = true;
	}

	private void SetLastfivemnoticeDone()
	{
		_viewModel.countDownSecondTextShow = false;
		_viewModel.countDownRandomTextShow = false;
	}

	public void Leave(TdQueue<ImgTxtShowCmd> queue, ref ImgTxtShowCmd olddata)
	{
		if (queue == _topUiQueue)
		{
			_topGroup.JumpTo(base.Loader, _viewModel, ref olddata, 2f);
			_topGroup.Reset(_viewModel, ref olddata, finish: true);
		}
		else if (queue == _centerUiQueue)
		{
			_centerGroup.JumpTo(base.Loader, _viewModel, ref olddata, 2f);
			_centerGroup.Reset(_viewModel, ref olddata, finish: true);
		}
		else if (queue == _downUiQueue)
		{
			_downGroup.JumpTo(base.Loader, _viewModel, ref olddata, 2f);
			_downGroup.Reset(_viewModel, ref olddata, finish: true);
		}
	}

	public void Refresh(TdQueue<ImgTxtShowCmd> queue, ref ImgTxtShowCmd olddata)
	{
		if (queue == _topUiQueue)
		{
			_topGroup.Reset(_viewModel, ref olddata, finish: true);
		}
		else if (queue == _centerUiQueue)
		{
			_centerGroup.Reset(_viewModel, ref olddata, finish: true);
		}
		else if (queue == _downUiQueue)
		{
			_downGroup.Reset(_viewModel, ref olddata, finish: true);
		}
	}

	public void Pause(TdQueue<ImgTxtShowCmd> queue, ref ImgTxtShowCmd olddata)
	{
		if (queue == _topUiQueue)
		{
			_topGroup.PauseOld(_viewModel, ref olddata);
		}
		else if (queue == _centerUiQueue)
		{
			_centerGroup.PauseOld(_viewModel, ref olddata);
		}
		else if (queue == _downUiQueue)
		{
			_downGroup.PauseOld(_viewModel, ref olddata);
		}
	}

	public void QueueNewData(TdQueue<ImgTxtShowCmd> queue, ref ImgTxtShowCmd newdata)
	{
		if (queue == _topUiQueue)
		{
			_topGroup.Init(_viewModel, ref newdata);
		}
		else if (queue == _centerUiQueue)
		{
			_centerGroup.Init(_viewModel, ref newdata);
		}
		else if (queue == _downUiQueue)
		{
			_downGroup.Init(_viewModel, ref newdata);
		}
	}

	public bool QueueDataReplace(TdQueue<ImgTxtShowCmd> queue, ref ImgTxtShowCmd old, ref ImgTxtShowCmd newdata)
	{
		ImgTxtShowCmd imgTxtShowCmd = queue.Peek();
		if (newdata.Priority == imgTxtShowCmd.Priority)
		{
			if (queue == _topUiQueue)
			{
				_topGroup.Init(_viewModel, ref newdata);
				return true;
			}
			if (queue == _centerUiQueue)
			{
				_centerGroup.Init(_viewModel, ref newdata);
				return true;
			}
			if (queue == _downUiQueue)
			{
				_downGroup.Init(_viewModel, ref newdata);
				return true;
			}
		}
		return true;
	}

	private void InitChips()
	{
		_topGroup = new ChipGroup();
		_centerGroup = new ChipGroup();
		_downGroup = new ChipGroup();
		_allShowAlphaChip.Start = 0f;
		_allShowAlphaChip.Target = 1f;
		_allShowAlphaChip.Step = 1f;
		_allShowAlphaChip.Time = 500f;
		_textShowOffsetChip.Start = 0.5f;
		_textShowOffsetChip.Target = 1f;
		_textShowOffsetChip.Step = 1f;
		_textShowOffsetChip.Time = 1000f;
	}

	protected override void GameUpdate(int frameInterval)
	{
		if (_energyNest > 0)
		{
			_energyNest -= frameInterval;
		}
		if (_topUiQueue.Count > 0)
		{
			ImgTxtShowCmd cmd = _topUiQueue.Peek();
			_topUiQueue.TimePassForLater(frameInterval);
			if (_topGroup.DoStep(base.Loader, frameInterval, ref cmd, _viewModel))
			{
				_topUiQueue.Dequeue();
			}
		}
		if (_centerUiQueue.Count > 0)
		{
			ImgTxtShowCmd cmd2 = _centerUiQueue.Peek();
			_centerUiQueue.TimePassForLater(frameInterval);
			if (_centerGroup.DoStep(base.Loader, frameInterval, ref cmd2, _viewModel))
			{
				_centerUiQueue.Dequeue();
			}
		}
		if (_downUiQueue.Count > 0)
		{
			ImgTxtShowCmd cmd3 = _downUiQueue.Peek();
			_downUiQueue.TimePassForLater(frameInterval);
			if (_downGroup.DoStep(base.Loader, frameInterval, ref cmd3, _viewModel))
			{
				_downUiQueue.Dequeue();
			}
		}
	}

	public override void OnPlayback()
	{
		base.OnPlayback();
		if (!_viewModel.IsInited)
		{
			return;
		}
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (!_viewModel.bossShow)
		{
			UpdateAmmoTip();
			CheckDeath();
		}
		if (!_bossBattleTriggered)
		{
			if (Contexts.sharedInstance.player.GetEntityWithEntityId(UiIEventCondition.Get_hpProgressData_BossId()) != null)
			{
				if (RuleUtilty.IsNeedBossWarning(raceType))
				{
					BeginFinalBossBattle();
				}
				else if (raceType == 1004)
				{
					BeginFinalBossBattle();
				}
				_bossBattleTriggered = true;
			}
		}
		else if (raceType != 1004)
		{
			UpdateBossVoidBall();
			UpdateBossSectionEnd();
		}
	}

	private void SetMessageData(GameMessageData ov, GameMessageData data)
	{
		if (data != null && data.Type == GameMessageType.SHOWNEXTBATTLE)
		{
			_downUiQueue.Clear();
			_centerUiQueue.Clear();
			_topUiQueue.Clear();
		}
	}

	private void UpdateBossVoidBall()
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(UiIEventCondition.Get_hpProgressData_BossId());
		if (entityWithEntityId == null)
		{
			return;
		}
		if ((entityWithEntityId.state.StateFlag & 1) == 1)
		{
			int time = 300;
			if (!_bossVoidBall || !_topUiQueue.ContainsPriority(2))
			{
				if (!_bossVoidBall)
				{
					_bossVoidBall = true;
					time = 1;
				}
				int priority = 2;
				_topUiQueue.Enqueue(new ImgTxtShowCmd
				{
					ResComponent = "messageImage",
					ResKey = "attackvoidball",
					Time = time,
					OriginSize = new Vector2(1350f, 84f),
					TargetSize = new Vector2(900f, 56f),
					SizeTime = 300
				}, priority);
			}
		}
		else
		{
			_bossVoidBall = false;
		}
	}

	private void UpdateBossSectionEnd()
	{
		if (Contexts.sharedInstance.battleRoom.sectionTime.SectionTime <= 0 && !_sectionEnd)
		{
			_sectionEnd = true;
			int priority = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				ResComponent = "messageImage",
				ResKey = "bossrampage",
				Time = 5000,
				OriginSize = new Vector2(1350f, 90f),
				TargetSize = new Vector2(900f, 60f),
				SizeTime = 300
			}, priority);
		}
	}

	private void BeginFinalBossBattle()
	{
		_topUiQueue.Enqueue(new ImgTxtShowCmd
		{
			Time = 5000,
			ResKey = "bossbattle",
			ResComponent = "messageImage",
			UpdateEvent = UpdateBossBattle,
			StartEvent = HideBattleUi,
			EndEvent = RecoveryBattleUi
		}, 0);
	}

	private void HideBattleUi()
	{
		_viewModel.warningupShow = true;
		_viewModel.warningdownShow = true;
		_viewModel.bossShow = true;
		_viewModel.messageImageShow = false;
		_viewModel.selfMessageImageShow = false;
		_viewModel.stateImageShow = false;
		_viewModel.wavetextShow = false;
		_viewModel.countDownRandomTextShow = false;
		_viewModel.countDownSecondTextShow = false;
		_viewModel.countDowntextShow = false;
		_viewModel.nameImageShow = false;
		_viewModel.relivetxtShow = false;
		_viewModel.leveltextShow = false;
		_viewModel.readytextShow = false;
		_gameRuleContext.hpProgressData.ShowBossHp = false;
		_viewModel.bossObj.HideEverythingExceptGameObject();
	}

	private void RecoveryBattleUi()
	{
		_viewModel.warningupShow = false;
		_viewModel.warningdownShow = false;
		_viewModel.bossShow = false;
		Color messageImageColor = _viewModel.messageImageColor;
		messageImageColor.a = 1f;
		_viewModel.messageImageColor = messageImageColor;
		_viewModel.bossObj.RecoveryEverything();
		_gameRuleContext.hpProgressData.ShowBossHp = true;
	}

	private void CheckDeath()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		bool flag = false;
		if ((raceType != 1004) ? (_aimAtLast != 0 || _goldenSetRelive || _petSetRelive) : (_aimAtLast != 0 || _goldenSetRelive))
		{
			UpdateDeath();
			PlayerEntity playerEntity = ((_aimAtLast != 0) ? Contexts.sharedInstance.player.GetEntityWithEntityId(_aimAtLast) : null);
			if (playerEntity == null || !playerEntity.IsDead())
			{
				_aimAtLast = 0;
				_goldenSetRelive = false;
				_petSetRelive = false;
			}
		}
		else
		{
			ImgTxtShowCmd imgTxtShowCmd = _centerUiQueue.Peek();
			if ((imgTxtShowCmd.Priority == 4 || imgTxtShowCmd.Priority == 5) && imgTxtShowCmd.Time == 35)
			{
				_centerUiQueue.Dequeue();
			}
		}
	}

	private void UpdateDeath()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(_aimAtLast);
		bool flag = entityWithEntityId != null && myPlayerEntity != entityWithEntityId;
		int reliveGp = myPlayerEntity.GetPlayerInfo().ReliveGp;
		if (flag)
		{
			reliveGp = entityWithEntityId.GetPlayerInfo().ReliveGp;
		}
		int priority = 4;
		if (_goldenSetRelive || reliveGp > 0 || _petSetRelive)
		{
			string text = null;
			bool flag2 = true;
			if (!flag)
			{
				priority = 5;
				if (_goldenSetRelive)
				{
					text = "goldensetrelive";
					flag2 = false;
				}
				else if (_petSetRelive)
				{
					text = "ClickYReliveByPet";
					flag2 = false;
				}
				else
				{
					text = "relivemyself";
				}
			}
			else
			{
				text = "reliveteammate";
			}
			TdQueue<ImgTxtShowCmd> centerUiQueue = _centerUiQueue;
			ImgTxtShowCmd item = new ImgTxtShowCmd
			{
				ResComponent = "selfMessageImage",
				ResKey = text,
				Time = 35
			};
			if (flag2)
			{
				item.AlwaysText = reliveGp.ToString();
				item.TextComponent = "relivetxt";
			}
			centerUiQueue.Enqueue(item, priority);
		}
		else
		{
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				ResComponent = "selfMessageImage",
				ResKey = "cannotrelive",
				Time = 35
			}, priority);
		}
	}

	private void UpdateUiMsg(int old, int msgId)
	{
		if (msgId >= 0)
		{
			DoUiImageUpdate(msgId, null);
		}
	}

	private void UpdateAchivement(int old, int type)
	{
		if (!_achievementInit || _viewModel.IsInited)
		{
			_achievementInit = true;
			return;
		}
		int priority = 1;
		TdQueue<ImgTxtShowCmd> topUiQueue = _topUiQueue;
		switch (type)
		{
		case 0:
		{
			ImgTxtShowCmd item3 = default(ImgTxtShowCmd);
			item3.Time = 5000;
			item3.ResKey = "getmoremoney";
			item3.ResComponent = "messageImage";
			item3.SizeComponent = "messageImage";
			item3.OriginSize = new Vector2(1350f, 168f);
			item3.TargetSize = new Vector2(900f, 112f);
			item3.SizeTime = 500;
			topUiQueue.Enqueue(item3, priority);
			break;
		}
		case 1:
		{
			ImgTxtShowCmd item2 = default(ImgTxtShowCmd);
			item2.Time = 5000;
			item2.ResKey = "getnoammunication";
			item2.ResComponent = "messageImage";
			item2.SizeComponent = "messageImage";
			item2.OriginSize = new Vector2(1350f, 168f);
			item2.TargetSize = new Vector2(900f, 112f);
			item2.SizeTime = 500;
			topUiQueue.Enqueue(item2, priority);
			break;
		}
		case 2:
		{
			ImgTxtShowCmd item = default(ImgTxtShowCmd);
			item.Time = 5000;
			item.ResKey = "getmorespeed";
			item.ResComponent = "messageImage";
			item.SizeComponent = "messageImage";
			item.OriginSize = new Vector2(1350f, 168f);
			item.TargetSize = new Vector2(900f, 112f);
			item.SizeTime = 500;
			topUiQueue.Enqueue(item, priority);
			break;
		}
		}
	}

	private void UpdateIncentiveMsg(bool old, bool newval)
	{
		if (newval)
		{
			int priority = 0;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResKey = "getbonustask",
				ResComponent = "messageImage",
				SizeComponent = "messageImage",
				OriginSize = new Vector2(1350f, 168f),
				TargetSize = new Vector2(900f, 112f),
				SizeTime = 500
			}, priority);
		}
		_gameRuleContext.pveIncentiveView.Dirty = false;
	}

	private void SetPveMessageData(PveMessageData ov, PveMessageData msg)
	{
		if (msg != null)
		{
			if (msg.Wave != 0)
			{
				wave = msg.Wave;
			}
			DoUiImageUpdate((int)msg.Type, msg);
		}
	}

	protected void UpdateAmmoTip()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		PlayerBagContext playerBag = Contexts.sharedInstance.playerBag;
		if (myPlayerEntity != null && playerBag != null && playerBag.currentBagEntity != null && myPlayerEntity.hasCurrentWeapon)
		{
			WeaponEntity weaponAtSlot = WeaponUtility.GetWeaponAtSlot(myPlayerEntity, playerBag.currentBagEntity.bagId.Value, myPlayerEntity.currentWeapon.Weapon, myPlayerEntity.currentWeapon.Index);
			if (weaponAtSlot != null && weaponAtSlot.clip.CarryClip == 0 && weaponAtSlot.clip.Clip == 0 && myPlayerEntity.currentWeapon.Weapon >= 1 && myPlayerEntity.currentWeapon.Weapon <= 2 && (!NoBulletTipsSystem._noBulletIgnore.Contains(weaponAtSlot.basicInfo.Data.WeaponName) || !weaponAtSlot.hasSpecial || !weaponAtSlot.special.SpecialMode))
			{
				DoUiImageUpdate(19, null);
			}
		}
	}

	private void DoUiImageUpdate(int msgId, PveMessageData msg)
	{
		int num = -1;
		switch ((TowerDefenseMessageType)msgId)
		{
		case TowerDefenseMessageType.BIOBOMB:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 2000,
				ResKey = "biobomb",
				ResComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.BIOTHUMB:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 2000,
				ResKey = "biothump",
				ResComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.SWORDSEELVE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 2000,
				ResKey = "sword",
				ResComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.PARTICLE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResKey = "particletrace",
				ResComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.ATTACKGATE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResKey = "attackgate",
				ResComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.GAMESTART:
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			num = ((raceType == 1003 || raceType == 1004) ? 2 : 0);
			TdQueue<ImgTxtShowCmd> topUiQueue = _topUiQueue;
			ImgTxtShowCmd item = new ImgTxtShowCmd
			{
				Time = msg.Time
			};
			switch (raceType)
			{
			case 1002:
				item.ResKey = "gamestart";
				break;
			case 1003:
				item.ResKey = "gamestart03";
				break;
			case 1005:
				item.ResKey = "gamestart04";
				break;
			case 1004:
				item.ResKey = "gamestart";
				break;
			default:
				item.ResKey = "gamestart";
				break;
			}
			item.ResComponent = "messageImage";
			item.TextComponent = "countDowntext";
			item.FontRes = 190.ToString();
			item.OriginText = msg.Time / 1000;
			item.TargetText = 0;
			topUiQueue.Enqueue(item, num);
			num = 5;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = msg.Time,
				ResKey = "changeweapon",
				ResComponent = "selfMessageImage"
			}, num);
			break;
		}
		case TowerDefenseMessageType.READY:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 10000,
				ResComponent = "messageImage",
				ResKey = "ready",
				TextComponent = "readytext",
				OriginText = 10,
				TargetText = 0,
				FontRes = 190.ToString()
			}, num);
			num = 5;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 10000,
				ResComponent = "selfMessageImage",
				ResKey = "readytime",
				StartEvent = SetWeaponStateWhenReady,
				EndEvent = SetWeaponStateWhenReadyDone
			}, num);
			break;
		case TowerDefenseMessageType.ENEMYWAVE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "enemywave",
				TextComponent = "wavetext",
				AlwaysText = wave.ToString(),
				FontRes = 200.ToString(),
				StartEvent = SetDefaultWave
			}, num);
			break;
		case TowerDefenseMessageType.BOSSBEFALL:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 4000,
				ResComponent = "messageImage",
				ResKey = "highlevelthreat",
				TextComponent = "wavetext",
				AlwaysText = wave.ToString(),
				FontRes = 200.ToString(),
				StartEvent = SetBossFailWave
			}, num);
			break;
		case TowerDefenseMessageType.MOREZOMBIE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "largewaveenemy",
				OriginSize = new Vector2(1350f, 82.5f),
				TargetSize = new Vector2(900f, 55f),
				SizeTime = 300,
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.ENEMYELIMINATED:
		{
			num = 1;
			TdQueue<ImgTxtShowCmd> topUiQueue2 = _topUiQueue;
			ImgTxtShowCmd item2 = new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage"
			};
			switch (Contexts.sharedInstance.battleRoom.roomData.Data.PveLevel)
			{
			case 0:
				item2.ResKey = "enemyeliminatednormal";
				break;
			case 1:
				item2.ResKey = "enemyeliminatednormal";
				break;
			case 2:
				item2.ResKey = "enemyeliminateddifficult";
				break;
			case 3:
				item2.ResKey = "enemyeliminatednightmare";
				break;
			}
			topUiQueue2.Enqueue(item2, num);
			break;
		}
		case TowerDefenseMessageType.ENEMYRETREAT:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "enemyretreat"
			}, num);
			break;
		case TowerDefenseMessageType.DEATHGRASP:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "deathgrasp"
			}, num);
			break;
		case TowerDefenseMessageType.TITANJUMPATTACK:
			num = 2;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "overwhelming"
			}, num);
			break;
		case TowerDefenseMessageType.TITANRUSH:
			num = 2;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "massiveshock"
			}, num);
			break;
		case TowerDefenseMessageType.TITANMISSILE:
			num = 2;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "artilleryattack"
			}, num);
			break;
		case TowerDefenseMessageType.GETENERGY:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "collectenergysuccess",
				OriginSize = new Vector2(1350f, 90f),
				TargetSize = new Vector2(900f, 60f),
				SizeTime = 300,
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.DOORINACTIVE:
			if (_energyNest <= 0)
			{
				num = 1;
				_topUiQueue.Enqueue(new ImgTxtShowCmd
				{
					Time = 2000,
					ResComponent = "messageImage",
					ResKey = "cannotattackenergynest"
				}, num);
				_energyNest = 5000;
			}
			break;
		case TowerDefenseMessageType.ONTRRIGER:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "bigthreat",
				OriginSize = new Vector2(1350f, 97.5f),
				TargetSize = new Vector2(900f, 65f),
				SizeTime = 300,
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.DOORACTIVE:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3600000,
				ResComponent = "messageImage",
				ResKey = "energynestdown"
			}, num);
			break;
		case TowerDefenseMessageType.DOORBREAK:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "messageImage",
				ResKey = "bigthreat",
				OriginSize = new Vector2(1350f, 97.5f),
				TargetSize = new Vector2(900f, 65f),
				SizeTime = 300,
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.LASTFIVEMNOTICE:
			if (!_bossBattleTriggered)
			{
				num = 2;
				_topUiQueue.Enqueue(new ImgTxtShowCmd
				{
					Time = 59000,
					ResComponent = "messageImage",
					ResKey = "count5minutes",
					TextComponent = "countDownSecondText",
					FontRes = 200.ToString(),
					OriginText = 59,
					TargetText = 0,
					StartEvent = SetStartfivemnoticeDone,
					UpdateEvent = SetLastfivemnotice,
					EndEvent = SetLastfivemnoticeDone
				}, num);
			}
			break;
		case TowerDefenseMessageType.LASTONEMNOTICE:
			if (!_bossBattleTriggered)
			{
				num = 1;
				_topUiQueue.Enqueue(new ImgTxtShowCmd
				{
					Time = 59000,
					ResComponent = "messageImage",
					ResKey = "count1minute",
					TextComponent = "countDownSecondText",
					FontRes = 200.ToString(),
					OriginText = 59,
					TargetText = 0,
					StartEvent = SetStartfivemnoticeDone,
					UpdateEvent = SetLastfivemnotice,
					EndEvent = SetLastfivemnoticeDone
				}, num);
			}
			break;
		case TowerDefenseMessageType.YOUAREUNDERATTACK:
			num = 0;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "selfMessageImage",
				ResKey = "youareunderattack"
			}, num);
			break;
		case TowerDefenseMessageType.UPGRADE:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "upgrade",
				TextComponent = "leveltext",
				AlwaysText = msg.Lv.ToString(),
				FontRes = 210.ToString()
			}, num);
			if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 1002 && msg.Lv == 1)
			{
				num = 1;
				_topUiQueue.Enqueue(new ImgTxtShowCmd
				{
					Time = 5000,
					ResComponent = "messageImage",
					ResKey = "communicationdown"
				}, num);
			}
			break;
		case TowerDefenseMessageType.AMMUNITIONSUPPLY:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "ammunitionsupply"
			}, num);
			break;
		case TowerDefenseMessageType.BREASTWALL:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "breastwall"
			}, num);
			break;
		case TowerDefenseMessageType.LIGHTNINGBOUND:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "lightningbound"
			}, num);
			break;
		case TowerDefenseMessageType.FIRSTAID:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "firstaid"
			}, num);
			break;
		case TowerDefenseMessageType.AMMUNITIONSUPPLYREADY:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "ammunitionsupplyready"
			}, num);
			break;
		case TowerDefenseMessageType.BREASTWALLREADY:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "breastwallready"
			}, num);
			break;
		case TowerDefenseMessageType.LIGHTNINGBOUNDREADY:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "lightningboundready"
			}, num);
			break;
		case TowerDefenseMessageType.FIRSTAIDREADY:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "selfMessageImage",
				ResKey = "firstaidready"
			}, num);
			break;
		case TowerDefenseMessageType.OUTOFAMMO:
			num = 4;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 400,
				ResComponent = "selfMessageImage",
				ResKey = "outofammo"
			}, num);
			break;
		case TowerDefenseMessageType.NEARENERGYDEVICE:
			num = 3;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 300,
				ResComponent = "selfMessageImage",
				ResKey = "collectenergy"
			}, num);
			break;
		case TowerDefenseMessageType.PICKUPSCENEWEAPON:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 300,
				ResComponent = "selfMessageImage",
				ResKey = "pickupweapon"
			}, num);
			break;
		case TowerDefenseMessageType.STARNOTENOUGH:
			num = 2;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "selfMessageImage",
				ResKey = "starnotenough"
			}, num);
			break;
		case TowerDefenseMessageType.CHAOSHENGBO:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "selfMessageImage",
				ResKey = "ultrasound"
			}, num);
			break;
		case TowerDefenseMessageType.ZUZHOU:
			num = 1;
			_centerUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "selfMessageImage",
				ResKey = "curse"
			}, num);
			break;
		case TowerDefenseMessageType.AIMATDEADTEAMMATE:
			_aimAtLast = msg.PlayerId;
			_goldenSetRelive = false;
			_petSetRelive = false;
			break;
		case TowerDefenseMessageType.GOLDWEAPONRELIVE:
			_aimAtLast = Contexts.sharedInstance.player.myPlayerEntity.GetId();
			_goldenSetRelive = true;
			_petSetRelive = false;
			break;
		case TowerDefenseMessageType.PETRELIVE:
			_aimAtLast = Contexts.sharedInstance.player.myPlayerEntity.GetId();
			_petSetRelive = true;
			_goldenSetRelive = false;
			break;
		case TowerDefenseMessageType.RELOADAMMO:
			num = 2;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 500,
				ResComponent = "stateImage",
				ResKey = "reloadammo"
			}, num);
			break;
		case TowerDefenseMessageType.LEARNSKILL:
			num = 2;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 500,
				ResComponent = "stateImage",
				ResKey = "shoppingarea"
			}, num);
			break;
		case TowerDefenseMessageType.INDANGER:
			num = 0;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 2000,
				ResComponent = "stateImage",
				ResKey = "indanger"
			}, num);
			break;
		case TowerDefenseMessageType.NOTENOUGHMONEY:
			num = 1;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "stateImage",
				ResKey = "notenoughmoney"
			}, num);
			break;
		case TowerDefenseMessageType.NOTENOUGHGP:
			num = 1;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 3000,
				ResComponent = "stateImage",
				ResKey = "notenoughgp"
			}, num);
			break;
		case TowerDefenseMessageType.GIVENFIRSTAID:
			num = 4;
			_viewModel.nameImageShow = true;
			_viewModel.nameImageAnchoredposition = new Vector2(-19f, 0f);
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 300,
				ResComponent = "stateImage",
				ResKey = "givenfirstaid"
			}, num);
			break;
		case TowerDefenseMessageType.BECURSE:
			num = 1;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 6500,
				ResComponent = "stateImage",
				ResKey = "cursehit"
			}, num);
			break;
		case TowerDefenseMessageType.CLEARZHIZHULUANQUICKLY:
			num = 1;
			_downUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 4700,
				ResComponent = "stateImage",
				ResKey = "killalleggs",
				OriginSize = new Vector2(1536f, 192f),
				TargetSize = new Vector2(1024f, 128f),
				SizeComponent = "stateImage",
				SizeTime = 300
			}, num);
			break;
		case TowerDefenseMessageType.HEIGHTLEVELWARNING:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "highrankthreat",
				SizeTime = 300,
				OriginSize = new Vector2(1536f, 192f),
				TargetSize = new Vector2(1024f, 128f),
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.BOSSKUANGLUANG:
			num = 1;
			_topUiQueue.Enqueue(new ImgTxtShowCmd
			{
				Time = 5000,
				ResComponent = "messageImage",
				ResKey = "bossrampage",
				SizeTime = 300,
				OriginSize = new Vector2(1350f, 90f),
				TargetSize = new Vector2(900f, 60f),
				SizeComponent = "messageImage"
			}, num);
			break;
		case TowerDefenseMessageType.TEAMMATEKILLED:
		case TowerDefenseMessageType.KILLBOSS:
		case TowerDefenseMessageType.RELIVEPLAYER:
		case TowerDefenseMessageType.WEAPONFLASH:
		case TowerDefenseMessageType.MONEYNOTENOUGH:
		case TowerDefenseMessageType.COPYWEAPON:
		case TowerDefenseMessageType.YINBAODAN:
		case TowerDefenseMessageType.UPDATEZHIZHULJUANNUM:
		case TowerDefenseMessageType.SHOWBOSSWARNING:
			break;
		}
	}

	private void UpdateBossBattle(int frameInterval)
	{
		if (_rollOffset < 0f)
		{
			_rollOffset = 0f;
			playerBossBattleSound();
			return;
		}
		float rolltime = _rolltime;
		RollImage rollImage = _viewModel.UI.Get<RollImage>("warningupImage");
		RollImage rollImage2 = _viewModel.UI.Get<RollImage>("warningdownImage");
		float num = 0.0008f * (float)frameInterval;
		rollImage.RollXAmount = (rollImage.RollXAmount + num) % 1f;
		rollImage2.RollXAmount = Mathf.Max(0f, rollImage2.RollXAmount - num);
		_rolltime += num;
		if (rollImage2.RollXAmount - num < 0f)
		{
			rollImage2.RollXAmount = 1f;
		}
		if (_rolltime % 190f < rolltime % 190f)
		{
			playerBossBattleSound();
		}
		_allShowAlphaChip.Update(frameInterval);
		Color color = new Color(1f, 1f, 1f, _allShowAlphaChip.Value);
		_viewModel.warningupColor = color;
		_viewModel.warningdownColor = color;
		float num2 = _textShowOffsetChip.Update(frameInterval);
		color.a *= num2;
		_viewModel.messageImageColor = color;
	}

	private void playerBossBattleSound()
	{
		AssetInfo info = new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/bossbattle.mp3");
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, info, GameSoundManager.Config.AsideVolume);
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
