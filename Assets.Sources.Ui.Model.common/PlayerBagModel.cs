using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.Logger;
using UnityEngine;
using UnityEngine.EventSystems;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerBagModel : AbstractModel, IPlaybackSystem, ISetPlayerBagContext, ISetPlayerContext, ISetBattleRoomContext, ISetUserCommmandContext, ICursorControl, IKeyboardResponder, ISetMessageContext
{
	public static PlayerbagViewModel ViewModelInstance;

	private PlayerbagViewModel _viewModel = new PlayerbagViewModel();

	private static int _defaultSlot = 1;

	private PlayerBagContext _playerBagContext;

	private PlayerContext _playerContext;

	private UserCommandContext _userCommandContext;

	private BattleRoomContext _battleRoomContext;

	private bool _panelOpened;

	private List<Action<bool>> _indexShowCallBackList = new List<Action<bool>>();

	private static AssetInfo _noItemAsset = new AssetInfo("ui/peekaboomodel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/selectitem/noitem.png");

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private MessageContext _messageContext;

	private bool PanelOpened
	{
		get
		{
			return _panelOpened;
		}
		set
		{
			_panelOpened = value;
			_viewModel.BagOpenedPanelShow = value;
			if (Contexts.sharedInstance.gameRule.currentRule.Rule.HasBagChangeLimit())
			{
				_viewModel.RpgChangeBackShow = value;
				_viewModel.ChangeCountString = UiIEventCondition.Get_rpgSkillStateData_CanChangeBagCount().ToString();
			}
			else
			{
				_viewModel.BagTipRootShow = !value;
				_viewModel.RpgChangeBackShow = false;
			}
			_notifyGroup.SetSuspend(!value);
		}
	}

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetPlayerBagContext(PlayerBagContext context)
	{
		_playerBagContext = context;
	}

	public void SetUserCommandContext(UserCommandContext context)
	{
		_userCommandContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		base.Initialize();
		ViewModelInstance = _viewModel;
	}

	protected override void OnGameobjectInitialized()
	{
		InitBagIndex();
		base.OnGameobjectInitialized();
		PanelOpened = false;
		_viewModel.SelectedSlotShow1 = false;
		_viewModel.SelectedSlotShow2 = false;
		_viewModel.SelectedSlotShow3 = false;
		_viewModel.SelectedSlotShow4 = false;
		_viewModel.SelectedSlotShow5 = false;
		InitEventTrigger();
		if (Contexts.sharedInstance.gameRule.currentRule.Rule.HasBagChangeLimit())
		{
			_viewModel.BagTipRootShow = false;
			_viewModel.RpgChangeBackShow = false;
			_viewModel.RpgChangeBackSprite = base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/bag/LoadGunRemainTime.png", delegate(Sprite sprite)
			{
				_viewModel.RpgChangeBackSprite = sprite;
			});
			_viewModel.WeaponChangeRuleTipShow = false;
		}
		else
		{
			_viewModel.BagTipRootShow = true;
			_viewModel.RpgChangeBackShow = false;
			_viewModel.WeaponChangeRuleTipShow = true;
		}
		base.Loader.RetriveSprite("ui/halfloadedres/newbieGuide", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/newbieGuide/openbag.png", delegate(Sprite sprite)
		{
			_viewModel.BagOpenTipSprite = sprite;
		});
		base.Loader.RetriveSprite("ui/halfloadedres/newbieGuide", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/newbieGuide/bagweaponclose.png", delegate(Sprite sprite)
		{
			_viewModel.WeaponChangeRuleTipSprite = sprite;
		});
		base.Loader.RetriveSprite("ui/halfloadedres/newbieGuide", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/newbieGuide/bagweapon.png", delegate(Sprite sprite)
		{
			_viewModel.WeaponChangeKeyTipSprite = sprite;
		});
	}

	private void InitEventTrigger()
	{
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers1, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers2, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers3, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(3);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers4, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(4);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers5, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(5);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers1, EventTriggerType.PointerUp, delegate
		{
			SelectBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers2, EventTriggerType.PointerUp, delegate
		{
			SelectBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers3, EventTriggerType.PointerUp, delegate
		{
			SelectBag(3);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers4, EventTriggerType.PointerUp, delegate
		{
			SelectBag(4);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers5, EventTriggerType.PointerUp, delegate
		{
			SelectBag(5);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers1, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers2, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers3, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(3);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers4, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(4);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers5, EventTriggerType.PointerEnter, delegate
		{
			ShowBag(5);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers1, EventTriggerType.PointerUp, delegate
		{
			SelectBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers2, EventTriggerType.PointerUp, delegate
		{
			SelectBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers3, EventTriggerType.PointerUp, delegate
		{
			SelectBag(3);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers4, EventTriggerType.PointerUp, delegate
		{
			SelectBag(4);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers5, EventTriggerType.PointerUp, delegate
		{
			SelectBag(5);
		});
	}

	private void InitBagIndex()
	{
		_indexShowCallBackList.Clear();
		_indexShowCallBackList.Add(delegate(bool show)
		{
			PlayerbagViewModel viewModel5 = _viewModel;
			bool selectedSlotShow5 = (_viewModel.BagIndexEnabled1 = show);
			viewModel5.SelectedSlotShow1 = selectedSlotShow5;
		});
		_indexShowCallBackList.Add(delegate(bool show)
		{
			PlayerbagViewModel viewModel4 = _viewModel;
			bool selectedSlotShow4 = (_viewModel.BagIndexEnabled2 = show);
			viewModel4.SelectedSlotShow2 = selectedSlotShow4;
		});
		_indexShowCallBackList.Add(delegate(bool show)
		{
			PlayerbagViewModel viewModel3 = _viewModel;
			bool selectedSlotShow3 = (_viewModel.BagIndexEnabled3 = show);
			viewModel3.SelectedSlotShow3 = selectedSlotShow3;
		});
		_indexShowCallBackList.Add(delegate(bool show)
		{
			PlayerbagViewModel viewModel2 = _viewModel;
			bool selectedSlotShow2 = (_viewModel.BagIndexEnabled4 = show);
			viewModel2.SelectedSlotShow4 = selectedSlotShow2;
		});
		_indexShowCallBackList.Add(delegate(bool show)
		{
			PlayerbagViewModel viewModel = _viewModel;
			bool selectedSlotShow = (_viewModel.BagIndexEnabled5 = show);
			viewModel.SelectedSlotShow5 = selectedSlotShow;
		});
	}

	private void ShowBag(int id)
	{
		_defaultSlot = id;
		PreviewBag(id);
	}

	private void PreviewBag(int id)
	{
		PlayerBagEntity entityWithBagId = _playerBagContext.GetEntityWithBagId(id);
		RefreshSelectedBag(entityWithBagId);
	}

	private void SelectBag(int id)
	{
		if (_playerBagContext.GetEntityWithBagId(id) == null)
		{
			return;
		}
		if (_playerContext.myPlayerEntity.basicInfo.Current.CanChangeBag)
		{
			if (!Contexts.sharedInstance.gameRule.currentRule.Rule.IsPve())
			{
				PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
				ChatContext chat = Contexts.sharedInstance.chat;
				TimeContext time = Contexts.sharedInstance.time;
				if (id != _defaultSlot && myPlayerEntity.basicInfo.Current.NextChangeBagTimer > time.time.ServerTime)
				{
					chat.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "prompt", string.Format(ScriptLocalization.Get("NO_CHANGE_BAG"))));
				}
			}
			_userCommandContext.input.Bag = id;
		}
		PanelOpened = false;
	}

	private void SetCurrentBagId(int ov, int id)
	{
		for (int i = 0; i < _indexShowCallBackList.Count; i++)
		{
			Action<bool> action = _indexShowCallBackList[i];
			if (action != null)
			{
				action(i == id - 1);
				continue;
			}
			throw new Exception($"_indexShowCallBackList is null at {i}");
		}
	}

	private void RefreshSelectedBag(PlayerBagEntity entity)
	{
		if (entity == null)
		{
			return;
		}
		if (entity.basicInfo == null)
		{
			this.LogError("basicInfo is null!!");
			return;
		}
		if (entity.basicInfo.Data == null)
		{
			this.LogError("Data is null!!");
			return;
		}
		SetWeaponSprite(entity.basicInfo.Data.FirstWeapon, delegate(Sprite sprite)
		{
			_viewModel.FirstWeaponSprite = sprite;
			_viewModel.FirstWeaponEnabled = sprite != null;
			if (sprite != null)
			{
				_viewModel.FirstWeaponNtvsize();
			}
			_viewModel.NofirstWeaponShow = sprite == null;
			_viewModel.NofirstWeaponSprite = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NofirstWeaponSprite = v;
			});
		});
		SetWeaponSprite(entity.basicInfo.Data.SecondaryWeapon, delegate(Sprite sprite)
		{
			_viewModel.SecondaryWeaponSprite = sprite;
			_viewModel.SecondaryWeaponEnabled = sprite != null;
			if (sprite != null)
			{
				_viewModel.SecondaryWeaponNtvsize();
			}
			_viewModel.NosecondaryWeaponShow = sprite == null;
			_viewModel.NosecondaryWeaponSprite = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NosecondaryWeaponSprite = v;
			});
		});
		SetWeaponSprite(entity.basicInfo.Data.MeleeWeapon, delegate(Sprite sprite)
		{
			_viewModel.MeleeWeaponSprite = sprite;
			_viewModel.MeleeWeaponEnabled = sprite != null;
			if (sprite != null)
			{
				_viewModel.MeleeWeaponNtvsize();
			}
			_viewModel.NomeleeWeaponShow = sprite == null;
			_viewModel.NomeleeWeaponSprite = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NomeleeWeaponSprite = v;
			});
		});
		SetWeaponSprite(entity.basicInfo.Data.BombWeapons0, delegate(Sprite sprite)
		{
			_viewModel.BombWeaponSprite1 = sprite;
			_viewModel.BombWeaponEnabled1 = sprite != null;
			if (sprite != null)
			{
				_viewModel.BombWeaponNtvsize1();
			}
			_viewModel.NobombWeaponShow1 = sprite == null;
			_viewModel.NobombWeaponSprite1 = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NobombWeaponSprite1 = v;
			});
		});
		SetWeaponSprite(entity.basicInfo.Data.BombWeapons1, delegate(Sprite sprite)
		{
			_viewModel.BombWeaponSprite2 = sprite;
			_viewModel.BombWeaponEnabled2 = sprite != null;
			if (sprite != null)
			{
				_viewModel.BombWeaponNtvsize2();
			}
			_viewModel.NobombWeaponShow2 = sprite == null;
			_viewModel.NobombWeaponSprite2 = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NobombWeaponSprite2 = v;
			});
		});
		SetWeaponSprite(entity.basicInfo.Data.BombWeapons2, delegate(Sprite sprite)
		{
			_viewModel.BombWeaponSprite3 = sprite;
			_viewModel.BombWeaponEnabled3 = sprite != null;
			if (sprite != null)
			{
				_viewModel.BombWeaponNtvsize3();
			}
			_viewModel.NobombWeaponShow3 = sprite == null;
			_viewModel.NobombWeaponSprite3 = this.GetLoader().RetriveSprite(_noItemAsset, delegate(Sprite v)
			{
				_viewModel.NobombWeaponSprite3 = v;
			});
		});
	}

	private void SetWeaponSprite(BaseWeaponData data, Action<Sprite> setSprite)
	{
		if (data != null)
		{
			if (!string.IsNullOrEmpty(data.WeaponName))
			{
				IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(data.WeaponName);
				if (weaponInfo != null)
				{
					this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(data.WeaponSkinName), setSprite);
				}
			}
		}
		else
		{
			setSprite(null);
		}
	}

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiBag_CanChangeBag, SetCanChangeBag, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiBag_CurrentBagId, SetCurrentBagId, null, initinvoke: true);
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_PlayerBag_HasBag1, SetHasBag1, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_PlayerBag_HasBag2, SetHasBag2, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_PlayerBag_HasBag3, SetHasBag3, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_PlayerBag_HasBag4, SetHasBag4, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_PlayerBag_HasBag5, SetHasBag5, null, initinvoke: true));
	}

	private void SetHasBag1(bool arg1, bool arg2)
	{
		PlayerbagViewModel viewModel = _viewModel;
		bool slotButtonable = (_viewModel.SelectedSlotButtonable1 = arg2);
		viewModel.SlotButtonable1 = slotButtonable;
	}

	private void SetHasBag2(bool arg1, bool arg2)
	{
		PlayerbagViewModel viewModel = _viewModel;
		bool slotButtonable = (_viewModel.SelectedSlotButtonable2 = arg2);
		viewModel.SlotButtonable2 = slotButtonable;
	}

	private void SetHasBag3(bool arg1, bool arg2)
	{
		PlayerbagViewModel viewModel = _viewModel;
		bool slotButtonable = (_viewModel.SelectedSlotButtonable3 = arg2);
		viewModel.SlotButtonable3 = slotButtonable;
	}

	private void SetHasBag4(bool arg1, bool arg2)
	{
		PlayerbagViewModel viewModel = _viewModel;
		bool slotButtonable = (_viewModel.SelectedSlotButtonable4 = arg2);
		viewModel.SlotButtonable4 = slotButtonable;
	}

	private void SetHasBag5(bool arg1, bool arg2)
	{
		PlayerbagViewModel viewModel = _viewModel;
		bool slotButtonable = (_viewModel.SelectedSlotButtonable5 = arg2);
		viewModel.SlotButtonable5 = slotButtonable;
	}

	private void SetCanChangeBag(bool ov, bool v)
	{
		_viewModel.ShowShow = v;
		if (!v)
		{
			PanelOpened = false;
		}
	}

	public int GetCursorState()
	{
		if (!_panelOpened || !_viewModel.ShowShow)
		{
			return 0;
		}
		return 4;
	}

	public int GetForbidButtons()
	{
		return 175;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.B)
		{
			if (_battleRoomContext.roomData.Data.RaceType == 18018)
			{
				return false;
			}
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				return false;
			}
			if (UiIEventCondition.Get_RoomData_IsStrike())
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CURRENTCHANNEL_CANNOT_CHANGE_WEAPONBAG"), 1000);
				NotifyManager.ForceInvoke(38);
				return false;
			}
			IGameRule rule = Contexts.sharedInstance.gameRule.currentRule.Rule;
			if (!_playerContext.myPlayerEntity.basicInfo.Current.CanChangeBag)
			{
				if (rule.IsPve())
				{
					if (rule.IsGeneralPve())
					{
						if (RuleUtilty.IsMultipleRpg(_battleRoomContext.roomData.Data.RaceType))
						{
							_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CurrentCannotChangeWeaponbag"), 1000);
							NotifyManager.ForceInvoke(38);
						}
						else
						{
							_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CannotChangedWeaponNocount"), 1000);
							NotifyManager.ForceInvoke(38);
						}
					}
					else
					{
						_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CannotChangedWeaponNoinair"), 1000);
						NotifyManager.ForceInvoke(38);
					}
				}
				return false;
			}
			if ((_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.EV_CAN_NOT_CHANGE_BAG.ID) || _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID)) && _playerContext.cameraOwnerEntity.hasSkill)
			{
				float num = (float)(_playerContext.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.EV_CAN_NOT_CHANGE_BAG.ID].Number - _playerContext.cameraOwnerEntity.clientTime.ClientTime) / 1000f;
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CAN_NOT_CHANGE_BAG").Replace("%s", num.ToString("0.0")), 1000);
				NotifyManager.ForceInvoke(38);
				return false;
			}
			PanelOpened = !PanelOpened;
			if (PanelOpened)
			{
				_defaultSlot = _playerContext.myPlayerEntity.basicInfo.Current.CurrentBagId;
				_viewModel.SetSelectedSlotShow(_defaultSlot, value: true);
				_viewModel.SetBagIndexEnabled(_defaultSlot, value: true);
				ShowBag(_defaultSlot);
			}
			else
			{
				PanelOpened = false;
			}
		}
		if (PanelOpened)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 5)
			{
				SelectBag(alphaOrKeypadDiff);
				PanelOpened = true;
				return true;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (PanelOpened && key.GetAlphaOrKeypadDiff() >= 1 && key.GetAlphaOrKeypadDiff() <= 5)
		{
			PanelOpened = false;
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
