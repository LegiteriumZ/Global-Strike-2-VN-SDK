using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BigHead;

public class BigHeadMessageModel : AbstractModel, IPlaybackSystem
{
	private BigheadmessageViewModel _viewModel;

	private static AssetInfo _heromaxAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/message/heromax.png");

	private static AssetInfo _waitultimatetimecomeonAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/message/waitultimatetimecomeon.png");

	private static AssetInfo _selfleaderAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/message/selfleader.png");

	private static AssetInfo _waitchangeheroAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/message/waitchangehero.png");

	private static AssetInfo _nearleaderAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/message/nearleader.png");

	private ActiveChip _messageImageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BigheadmessageViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadMessage_Type, SetType, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadMessage_BigHeadKingNum, SetBigHeadKingNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadMessage_MaxHeroNum, SetMaxHeroNum, null, initinvoke: true);
		NotifyManager.MakeNotify(56, UiIEventCondition.Get_bigHeadProgress_Lv, SetLv, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadMessage_CanChangeHero, SetCanChangeHero, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadMessage_WateHeroDebut, SetWateHeroDebut, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSkill_HasAuraSpeedBonus, SetHasAuraSpeedBonus, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		UpdateBigheadGrowupData();
	}

	private void SetHasAuraSpeedBonus(bool arg1, bool arg2)
	{
		UpdateBigheadGrowupData();
	}

	private void SetWateHeroDebut(bool arg1, bool arg2)
	{
		UpdateBigheadGrowupData();
	}

	private void SetCanChangeHero(bool arg1, bool arg2)
	{
		UpdateBigheadGrowupData();
	}

	private void SetLv(int arg1, int arg2)
	{
		UpdateBigheadGrowupData();
	}

	private void SetMaxHeroNum(int arg1, int arg2)
	{
		_viewModel.MaxHeroTextString = StringCache.IntToString(arg2);
	}

	private void SetBigHeadKingNum(int arg1, int arg2)
	{
		_viewModel.HaveBigheadTextString = StringCache.IntToString(arg2);
	}

	private void UpdateBigheadGrowupData()
	{
		_viewModel.ChangeHeroImageShow = false;
		int bigHeadProgress_Lv = UiIEventCondition.Get_bigHeadProgress_Lv();
		if (UiIEventCondition.Get_uiMyPlayer_IsDead() && UiIEventCondition.Get_bigHeadMessage_LastTime())
		{
			_viewModel.BigheadMessageImageShow = false;
		}
		else if (bigHeadProgress_Lv == 6)
		{
			SetType(BigHeadMessageType.BIGHEADKING, BigHeadMessageType.SELFLEAD);
			_viewModel.HaveBigheadImageShow = false;
		}
		else if (UiIEventCondition.Get_bigHeadMessage_CanChangeHero())
		{
			SetType(BigHeadMessageType.BIGHEADKING, BigHeadMessageType.CANHERODEBUT);
		}
		else if (bigHeadProgress_Lv == 5 && UiIEventCondition.Get_bigHeadMessage_WateHeroDebut())
		{
			SetType(BigHeadMessageType.BIGHEADKING, BigHeadMessageType.WATEHERODEBUT);
		}
		else if (UiIEventCondition.Get_uiSkill_HasAuraSpeedBonus())
		{
			SetType(BigHeadMessageType.BIGHEADKING, BigHeadMessageType.NEARLEAD);
		}
		else
		{
			_viewModel.BigheadMessageImageShow = false;
		}
	}

	private void SetType(BigHeadMessageType ov, BigHeadMessageType type)
	{
		if (!UiIEventCondition.Get_bigHeadMessage_Changed())
		{
			return;
		}
		switch (type)
		{
		case BigHeadMessageType.MAXHERO:
			_viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(_heromaxAsset, delegate(Sprite v)
			{
				_viewModel.MessageImageSprite = v;
				_viewModel.MessageImageNtvsize();
			});
			_messageImageActiveChip.Time = 3000;
			break;
		case BigHeadMessageType.LASTTIME:
			_viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(_waitultimatetimecomeonAsset, delegate(Sprite v)
			{
				_viewModel.MessageImageSprite = v;
				_viewModel.MessageImageNtvsize();
			});
			_messageImageActiveChip.Time = 3000;
			break;
		case BigHeadMessageType.CANHERODEBUT:
			_viewModel.ChangeHeroImageShow = true;
			break;
		case BigHeadMessageType.SELFLEAD:
			_viewModel.BigheadMessageImageShow = true;
			_viewModel.BigheadMessageImageSprite = this.GetLoader().RetriveSprite(_selfleaderAsset, delegate(Sprite v)
			{
				_viewModel.BigheadMessageImageSprite = v;
				_viewModel.BigheadMessageImageNtvsize();
			});
			break;
		case BigHeadMessageType.WATEHERODEBUT:
			_viewModel.BigheadMessageImageShow = true;
			_viewModel.BigheadMessageImageSprite = this.GetLoader().RetriveSprite(_waitchangeheroAsset, delegate(Sprite v)
			{
				_viewModel.BigheadMessageImageSprite = v;
				_viewModel.BigheadMessageImageNtvsize();
			});
			break;
		case BigHeadMessageType.NEARLEAD:
			_viewModel.BigheadMessageImageShow = true;
			_viewModel.BigheadMessageImageSprite = this.GetLoader().RetriveSprite(_nearleaderAsset, delegate(Sprite v)
			{
				_viewModel.BigheadMessageImageSprite = v;
				_viewModel.BigheadMessageImageNtvsize();
			});
			break;
		case BigHeadMessageType.HERODEBUT:
		case BigHeadMessageType.BIGHEADKING:
		case BigHeadMessageType.SHOWTREATMENT:
		case BigHeadMessageType.SHOWHERO:
			break;
		}
	}

	private void InitChips()
	{
		_messageImageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.MessageImageShow = _messageImageActiveChip.Update(_timeComponent);
	}
}
