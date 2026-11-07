using Assets.Sources.Framework;
using Assets.Sources.Info.Sound;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GoldExplode;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeBuyWeaponModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetBattleRoomContext, ISetMessageContext, IKeyboardResponder, ICursorControl, ISetGameRuleContext
{
	private GoldexplodebuyweaponViewModel _viewModel;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GoldexplodebuyweaponViewModel();
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		base.DoSubscribe();
		InitButtonCallbacks();
		_viewModel.SelectWeaponTypePanelShow = true;
		_viewModel.SelectWeaponPanelShow = false;
		base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype1.png", delegate(Sprite v)
		{
			_viewModel.TypeImageSprite1 = v;
		});
		base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype4.png", delegate(Sprite v)
		{
			_viewModel.TypeImageSprite4 = v;
		});
		base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype5.png", delegate(Sprite v)
		{
			_viewModel.TypeImageSprite5 = v;
		});
		if (_battleRoomContext.roomData.Data.RaceType == 61)
		{
			base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype2-1.png", delegate(Sprite v)
			{
				_viewModel.TypeImageSprite2 = v;
			});
			base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype3-1.png", delegate(Sprite v)
			{
				_viewModel.TypeImageSprite3 = v;
			});
		}
		else
		{
			base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype2.png", delegate(Sprite v)
			{
				_viewModel.TypeImageSprite2 = v;
			});
			base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/weapontype3.png", delegate(Sprite v)
			{
				_viewModel.TypeImageSprite3 = v;
			});
		}
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetIndexString(i + 1, (i + 1).ToString());
		}
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				OnBuyWeapon();
				UpdateVisible();
				UpdateTimer();
				UpdateWeaponImage();
				UpdateMoney();
			}
		}
	}

	private void OnBuyWeapon()
	{
		if (UiIEventCondition.Get_buyPanelData_WeaponType() == -1 && _viewModel.SelectWeaponPanelShow)
		{
			if (_viewModel.AutoCloseCheckOkShow)
			{
				_viewModel.PanelShow = false;
			}
			else
			{
				ShowWeaponTypePanel();
			}
		}
	}

	private void UpdateVisible()
	{
		if (!UiIEventCondition.Get_goldExplodeBuyAreaData_InBuyArea() || _playerContext.myPlayerEntity.basicInfo.IsDead)
		{
			_viewModel.PanelShow = false;
		}
	}

	private float GetBuyTime()
	{
		if (_battleRoomContext.sectionTime.SectionStartTimeClient <= 0)
		{
			return 0f;
		}
		return (float)(UiIEventCondition.Get_goldExplodeBuyAreaData_BuyTime() - _battleRoomContext.sectionTime.Passed) * 0.001f;
	}

	private void UpdateTimer()
	{
		float buyTime = GetBuyTime();
		if (buyTime < 0f)
		{
			_viewModel.PanelShow = false;
		}
		else
		{
			_viewModel.TimeTextString = StringCache.IntToStringD2((int)buyTime);
		}
	}

	private void UpdateMoney()
	{
		PlayerInfoData playerInfo = _playerContext.myPlayerEntity.GetPlayerInfo();
		if (playerInfo != null)
		{
			_viewModel.MoneyTextString = playerInfo.Money.ToString();
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.B)
		{
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				return false;
			}
			if (!UiIEventCondition.Get_goldExplodeBuyAreaData_InBuyArea())
			{
				return false;
			}
			if (GetBuyTime() <= 0f)
			{
				return false;
			}
			_viewModel.PanelShow = !_viewModel.PanelShow;
			if (_viewModel.PanelShow)
			{
				ShowWeaponTypePanel();
			}
		}
		if (_viewModel.PanelShow)
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha0))
			{
				ShowWeaponTypePanel();
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha1))
			{
				if (_viewModel.SelectWeaponTypePanelShow)
				{
					ShowWeaponPanel(1);
				}
				else
				{
					SelectWeapon(1);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				if (_viewModel.SelectWeaponTypePanelShow)
				{
					ShowWeaponPanel(2);
				}
				else
				{
					SelectWeapon(2);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha3) && key.CheckEqualKeyCode(KeyCode.Alpha3))
			{
				if (_viewModel.SelectWeaponTypePanelShow)
				{
					ShowWeaponPanel(3);
				}
				else
				{
					SelectWeapon(3);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha4))
			{
				if (_viewModel.SelectWeaponTypePanelShow)
				{
					ShowWeaponPanel(4);
				}
				else
				{
					SelectWeapon(4);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha5))
			{
				if (_viewModel.SelectWeaponTypePanelShow)
				{
					ShowWeaponPanel(5);
				}
				else
				{
					SelectWeapon(5);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha6))
			{
				if (!_viewModel.SelectWeaponTypePanelShow)
				{
					SelectWeapon(6);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha7))
			{
				if (!_viewModel.SelectWeaponTypePanelShow)
				{
					SelectWeapon(7);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.Alpha8))
			{
				if (!_viewModel.SelectWeaponTypePanelShow)
				{
					SelectWeapon(8);
				}
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.E))
			{
				SetGiveWeaponIndex();
				return true;
			}
			if (key.CheckEqualKeyCode(KeyCode.N))
			{
				SetOneKeyBuyIndex();
				return true;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
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

	public int GetCursorState()
	{
		if (!_viewModel.PanelShow)
		{
			return 0;
		}
		return 64;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitButtonCallbacks()
	{
		_viewModel.AutoCloseCheckClicked.AddListener(OnAutoCloseCheckClickClickListener);
		_viewModel.AutoCloseCheckOkClicked.AddListener(OnAutoCloseCheckOkClickClickListener);
		_viewModel.SelectTypeCloseButtonClicked.AddListener(ClosePanel);
		_viewModel.SelectCloseButtonClicked.AddListener(ClosePanel);
		_viewModel.ReturnButtonClicked.AddListener(ShowWeaponTypePanel);
		_viewModel.GiveButtonClicked.AddListener(SetGiveWeaponIndex);
		_viewModel.OneKeyButtonClicked.AddListener(SetOneKeyBuyIndex);
		_viewModel.WeaponTypeSlotClicked1.AddListener(delegate
		{
			ShowWeaponPanel(1);
		});
		_viewModel.WeaponTypeSlotClicked2.AddListener(delegate
		{
			ShowWeaponPanel(2);
		});
		_viewModel.WeaponTypeSlotClicked3.AddListener(delegate
		{
			ShowWeaponPanel(3);
		});
		_viewModel.WeaponTypeSlotClicked4.AddListener(delegate
		{
			ShowWeaponPanel(4);
		});
		_viewModel.WeaponTypeSlotClicked5.AddListener(delegate
		{
			ShowWeaponPanel(5);
		});
		_viewModel.WeaponLuckyClicked1.AddListener(delegate
		{
			SelectWeapon(1);
		});
		_viewModel.WeaponLuckyClicked2.AddListener(delegate
		{
			SelectWeapon(2);
		});
		_viewModel.WeaponLuckyClicked3.AddListener(delegate
		{
			SelectWeapon(3);
		});
		_viewModel.WeaponLuckyClicked4.AddListener(delegate
		{
			SelectWeapon(4);
		});
		_viewModel.WeaponLuckyClicked5.AddListener(delegate
		{
			SelectWeapon(5);
		});
		_viewModel.WeaponLuckyClicked6.AddListener(delegate
		{
			SelectWeapon(6);
		});
		_viewModel.WeaponLuckyClicked7.AddListener(delegate
		{
			SelectWeapon(7);
		});
		_viewModel.WeaponLuckyClicked8.AddListener(delegate
		{
			SelectWeapon(8);
		});
		_viewModel.WeaponCommonClicked1.AddListener(delegate
		{
			SelectWeapon(1);
		});
		_viewModel.WeaponCommonClicked2.AddListener(delegate
		{
			SelectWeapon(2);
		});
		_viewModel.WeaponCommonClicked3.AddListener(delegate
		{
			SelectWeapon(3);
		});
		_viewModel.WeaponCommonClicked4.AddListener(delegate
		{
			SelectWeapon(4);
		});
		_viewModel.WeaponCommonClicked5.AddListener(delegate
		{
			SelectWeapon(5);
		});
		_viewModel.WeaponCommonClicked6.AddListener(delegate
		{
			SelectWeapon(6);
		});
		_viewModel.WeaponCommonClicked7.AddListener(delegate
		{
			SelectWeapon(7);
		});
		_viewModel.WeaponCommonClicked8.AddListener(delegate
		{
			SelectWeapon(8);
		});
	}

	public bool CanBuySelectWeapon()
	{
		PlayerInfoData playerInfo = _playerContext.myPlayerEntity.GetPlayerInfo();
		if (playerInfo == null)
		{
			return false;
		}
		BuyItem buyItem = UiIEventCondition.Get_buyPanelData_PanelData().Panel[UiIEventCondition.Get_buyPanelData_WeaponType() - 1].ItemList[UiIEventCondition.Get_buyPanelData_WeaponIndex() - 1];
		if (playerInfo.Money < buyItem.Price)
		{
			_messageContext.blastMessageData.Type = C4MessageType.NOMONEY;
			_messageContext.blastMessageData.GoldMessageChanged = true;
			NotifyManager.ForceInvoke(25);
			return false;
		}
		return true;
	}

	private void SetOneKeyBuyIndex()
	{
		_gameRuleContext.buyPanelData.WeaponType = 0;
		_gameRuleContext.buyPanelData.WeaponIndex = 0;
		_viewModel.PanelShow = false;
	}

	private void SetGiveWeaponIndex()
	{
		_gameRuleContext.buyPanelData.GiveWeaponIndex = TacticsSoundModel.Instance.GoldExploadeUIStartIndex + Random.Range(0, TacticsSoundModel.Instance.GoldExploadeUILength);
		_viewModel.PanelShow = false;
	}

	private void SelectWeapon(int index)
	{
		BuyItemList buyItemList = UiIEventCondition.Get_buyPanelData_PanelData().Panel[UiIEventCondition.Get_buyPanelData_WeaponType() - 1];
		if (index <= buyItemList.ItemList.Count && !(buyItemList.ItemList[index - 1].Weapon == ""))
		{
			_gameRuleContext.buyPanelData.WeaponIndex = index;
			if (!CanBuySelectWeapon())
			{
				_gameRuleContext.buyPanelData.WeaponIndex = -1;
			}
			else if (_viewModel.AutoCloseCheckOkShow)
			{
				_viewModel.PanelShow = false;
			}
		}
	}

	private void ShowWeaponPanel(int type)
	{
		if (!_gameRuleContext.hasBuyPanelData)
		{
			return;
		}
		_gameRuleContext.buyPanelData.WeaponType = type;
		_viewModel.SelectWeaponTypePanelShow = false;
		_viewModel.SelectWeaponPanelShow = true;
		BuyItemList buyItemList = UiIEventCondition.Get_buyPanelData_PanelData().Panel[UiIEventCondition.Get_buyPanelData_WeaponType() - 1];
		int i;
		for (i = 0; i < buyItemList.ItemList.Count; i++)
		{
			BuyItem buyItem = buyItemList.ItemList[i];
			if (string.IsNullOrEmpty(buyItem.Weapon))
			{
				_viewModel.SetWeaponSlotShow(i + 1, value: false);
				continue;
			}
			if (buyItem.Lucky)
			{
				_viewModel.SetWeaponLuckyShow(i + 1, value: true);
				_viewModel.SetWeaponCommonShow(i + 1, value: false);
			}
			else
			{
				_viewModel.SetWeaponLuckyShow(i + 1, value: false);
				_viewModel.SetWeaponCommonShow(i + 1, value: true);
			}
			_viewModel.SetWeaponSlotShow(i + 1, value: true);
			_viewModel.SetWeaponImageShow(i + 1, value: true);
			_viewModel.SetWeaponNameString(i + 1, LanguageUtils.GetWeaponCnName(buyItem.Weapon));
			_viewModel.SetWeaponGoldString(i + 1, buyItem.Price.ToString());
		}
		for (; i < 8; i++)
		{
			_viewModel.SetWeaponSlotShow(i + 1, value: false);
		}
	}

	private void UpdateWeaponImage()
	{
		if (UiIEventCondition.Get_buyPanelData_WeaponType() < 0 || !_viewModel.SelectWeaponPanelShow)
		{
			return;
		}
		PlayerInfoData playerInfo = _playerContext.myPlayerEntity.GetPlayerInfo();
		if (playerInfo == null)
		{
			return;
		}
		BuyItemList buyItemList = UiIEventCondition.Get_buyPanelData_PanelData().Panel[UiIEventCondition.Get_buyPanelData_WeaponType() - 1];
		for (int j = 0; j < buyItemList.ItemList.Count; j++)
		{
			BuyItem buyItem = buyItemList.ItemList[j];
			_viewModel.SetWeaponIndexString(j + 1, (j + 1).ToString());
			if (buyItem.Weapon == "c4_defuser" || buyItem.Weapon == "armor" || buyItem.Weapon == "armor_head")
			{
				int i2 = j;
				base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldExplodeModel/buyweapon/" + buyItem.Weapon + ".png", delegate(Sprite v)
				{
					_viewModel.SetWeaponImageSprite(i2 + 1, v);
				});
			}
			else if (!string.IsNullOrEmpty(buyItem.Weapon))
			{
				int i1 = j;
				base.Loader.RetriveSprite("weapon/" + buyItem.Weapon, "Assets/Res/Assets/weapon/" + buyItem.Weapon + "/ui/" + buyItem.Weapon + "-2.png", delegate(Sprite v)
				{
					_viewModel.SetWeaponImageSprite(i1 + 1, v);
				});
			}
			if (playerInfo.Money >= buyItem.Price)
			{
				_viewModel.SetWeaponGoldTextcolor(j + 1, Color.yellow);
			}
			else
			{
				_viewModel.SetWeaponGoldTextcolor(j + 1, Color.red);
			}
		}
	}

	private void ShowWeaponTypePanel()
	{
		if (_gameRuleContext.hasBuyPanelData)
		{
			_gameRuleContext.buyPanelData.WeaponType = -1;
			_gameRuleContext.buyPanelData.WeaponIndex = -1;
			_gameRuleContext.buyPanelData.GiveWeaponIndex = -1;
			_viewModel.SelectWeaponTypePanelShow = true;
			_viewModel.SelectWeaponPanelShow = false;
		}
	}

	private void ClosePanel()
	{
		_viewModel.PanelShow = false;
	}

	private void OnAutoCloseCheckOkClickClickListener()
	{
		_viewModel.AutoCloseCheckOkShow = false;
	}

	private void OnAutoCloseCheckClickClickListener()
	{
		_viewModel.AutoCloseCheckOkShow = true;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
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
