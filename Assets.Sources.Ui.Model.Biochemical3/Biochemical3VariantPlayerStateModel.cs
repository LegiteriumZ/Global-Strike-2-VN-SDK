using System;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3VariantPlayerStateModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetGameRuleContext, ISetMessageContext, ISetBattleRoomContext
{
	private Biochemical3VariantPlayerStateViewModel _viewModel;

	private const int GENERATION_EFFECT_TIME = 1000;

	private const int FRAGMENTATION_EFFECT_TIME = 1000;

	private SimpleNotifyGroup _group = new SimpleNotifyGroup();

	private int _moveTime;

	private FinalBioMessageType _stateType;

	private int _totalTime;

	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private MessageContext _messageContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical3VariantPlayerStateViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_messageContext.finalBioMessageData.VariantsGrowupChanged)
		{
			_messageContext.finalBioMessageData.VariantsGrowupChanged = false;
			_totalTime = _messageContext.finalBioMessageData.VariantsGrowupTime;
			_stateType = _messageContext.finalBioMessageData.VariantsGrowupType;
			_moveTime = 0;
			return;
		}
		_moveTime += _timeComponent.FrameInterval;
		if (_moveTime >= _totalTime)
		{
			if (_stateType == FinalBioMessageType.GENERATION)
			{
				_stateType = FinalBioMessageType.GENERATIONOVER;
				_totalTime = 1000;
				_moveTime = 0;
			}
			else if (FinalBioMessageType.GENERATIONOVER == _stateType)
			{
				_moveTime = 0;
			}
			else if (FinalBioMessageType.FRAGMENTATION == _stateType)
			{
				_stateType = FinalBioMessageType.FRAGMENTATIONOVER;
				_totalTime = 1000;
				_moveTime = 0;
			}
			else if (FinalBioMessageType.FRAGMENTATIONOVER == _stateType)
			{
				_stateType = FinalBioMessageType.INTERRUPT;
			}
			else if (FinalBioMessageType.INTERRUPT == _stateType)
			{
				_totalTime = int.MaxValue;
				_moveTime = 0;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetCareer, SetCareer);
		SimpleNotify.Add(GetHaveBh, SetHaveBh);
		SimpleNotify.Add(GetHaveBv, SetHaveBv);
		SimpleNotify.Add(GetBioClip, SetBioClip);
		SimpleNotify.Add(GetBioSerum, SetBioSerum);
		SimpleNotify.Add(GetHpPercent, SetHpPercent);
		SimpleNotify.Add(GetShield, SetShield);
		SimpleNotify.Add(GetLevel, SetLevel);
		SimpleNotify.Add(GetHp, SetHp);
		SimpleNotify.Add(GetElite, SetElite);
	}

	private void SetElite(bool arg1, int arg2)
	{
		_viewModel.EliteShow = arg1;
	}

	private bool GetElite(int arg1)
	{
		if (_playerContext.cameraOwnerEntity == null)
		{
			return false;
		}
		return _playerContext.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.ELITE.ID);
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.PanelShow = arg1;
		_group.SetSuspend(!arg1);
	}

	private bool GetVisible(int arg1)
	{
		if (_playerContext.isCameraOwner)
		{
			string career = _playerContext.cameraOwnerEntity.GetCareer();
			if (!PlayerCareerConstantUtility.IsHumanity(career))
			{
				return !PlayerCareerConstantUtility.IsHero(career);
			}
			return false;
		}
		return false;
	}

	private void SetHp(long arg1, int arg2)
	{
		_viewModel.HpString = StringCache.LongToString(arg1);
	}

	private long GetHp(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return cameraOwnerEntity.basicInfo.Current.Hp;
		}
		return 0L;
	}

	private void SetLevel(int arg1, int arg2)
	{
		_viewModel.LvString = arg1.ToString();
	}

	private int GetLevel(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.GeneLv ?? 0;
	}

	private void SetShield(float arg1, int arg2)
	{
		_viewModel.ShieldProgressFillamount = arg1;
	}

	private float GetShield(int arg1)
	{
		if (_battleRoomContext.roomData.Data.RaceType == 117)
		{
			return 0f;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null || myPlayerEntity.GetCareer() == "death" || myPlayerEntity.GetCareer() == "queen")
		{
			return 0f;
		}
		float num = 0f;
		if (FinalBioMessageType.GENERATIONOVER == _stateType)
		{
			num = ((_totalTime > 0) ? (_totalTime / _totalTime) : 0);
		}
		if (_stateType == FinalBioMessageType.GENERATION)
		{
			num = ((_totalTime > 0) ? ((float)_moveTime / (float)_totalTime) : 0f);
		}
		if (FinalBioMessageType.FRAGMENTATION == _stateType)
		{
			num = ((_totalTime > 0) ? ((float)(_totalTime - _moveTime) / (float)_totalTime) : 0f);
		}
		return (float)Math.Floor(163f * num) / 163f;
	}

	private void SetHpPercent(float arg1, int arg2)
	{
		_viewModel.HpProgressFillamount = arg1;
	}

	private float GetHpPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return (float)cameraOwnerEntity.basicInfo.Current.Hp / (float)cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		return 0f;
	}

	private void SetBioClip(bool arg1, int arg2)
	{
		_viewModel.BioClipShow = arg1;
	}

	private bool GetBioClip(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.BiochemicalMagazineFlag ?? false;
	}

	private void SetBioSerum(bool arg1, int arg2)
	{
		_viewModel.BioChemicalSerumShow = arg1;
	}

	private bool GetBioSerum(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.BiochemicalSerum ?? false;
	}

	private void SetHaveBv(bool arg1, int arg2)
	{
		_viewModel.HaveBvShow = arg1;
	}

	private bool GetHaveBv(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorBody ?? false;
	}

	private void SetHaveBh(bool arg1, int arg2)
	{
		_viewModel.HaveBhShow = arg1;
	}

	private bool GetHaveBh(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorHead ?? false;
	}

	private void SetCareer(string arg1, int arg2)
	{
		if (!string.IsNullOrEmpty(arg1))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.CareerSprite = sprite;
			});
			_viewModel.LvBackShow = !PlayerCareerConstantUtility.IsHumanity(arg1);
		}
	}

	private string GetCareer(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			return cameraOwnerEntity.GetCareer();
		}
		return "";
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
