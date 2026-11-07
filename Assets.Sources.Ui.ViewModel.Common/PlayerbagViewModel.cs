using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerbagViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBagTipRoot;

	private GameObject _oBagOpenTip;

	private Image _oBagOpenTipImage;

	private GameObject _oBagIndex1;

	private GameObject _oBagIndex2;

	private GameObject _oBagIndex3;

	private GameObject _oBagIndex4;

	private GameObject _oBagIndex5;

	private Image _oBagIndexImage1;

	private Image _oBagIndexImage2;

	private Image _oBagIndexImage3;

	private Image _oBagIndexImage4;

	private Image _oBagIndexImage5;

	private GameObject _oBagOpenedPanel;

	private GameObject _oNofirstWeapon;

	private Image _oNofirstWeaponImage;

	private GameObject _oNosecondaryWeapon;

	private Image _oNosecondaryWeaponImage;

	private GameObject _oNomeleeWeapon;

	private Image _oNomeleeWeaponImage;

	private GameObject _oNobombWeapon1;

	private GameObject _oNobombWeapon2;

	private GameObject _oNobombWeapon3;

	private Image _oNobombWeaponImage1;

	private Image _oNobombWeaponImage2;

	private Image _oNobombWeaponImage3;

	private GameObject _oFirstWeapon;

	private Image _oFirstWeaponImage;

	private GameObject _oSecondaryWeapon;

	private Image _oSecondaryWeaponImage;

	private GameObject _oMeleeWeapon;

	private Image _oMeleeWeaponImage;

	private GameObject _oBombWeapon1;

	private GameObject _oBombWeapon2;

	private GameObject _oBombWeapon3;

	private Image _oBombWeaponImage1;

	private Image _oBombWeaponImage2;

	private Image _oBombWeaponImage3;

	private GameObject _oSlot1;

	private GameObject _oSlot2;

	private GameObject _oSlot3;

	private GameObject _oSlot4;

	private GameObject _oSlot5;

	private EventTrigger _oSlotEventTrigger1;

	private EventTrigger _oSlotEventTrigger2;

	private EventTrigger _oSlotEventTrigger3;

	private EventTrigger _oSlotEventTrigger4;

	private EventTrigger _oSlotEventTrigger5;

	private Button _oSlotButton1;

	private Button _oSlotButton2;

	private Button _oSlotButton3;

	private Button _oSlotButton4;

	private Button _oSlotButton5;

	private GameObject _oSelectedSlot1;

	private GameObject _oSelectedSlot2;

	private GameObject _oSelectedSlot3;

	private GameObject _oSelectedSlot4;

	private GameObject _oSelectedSlot5;

	private EventTrigger _oSelectedSlotEventTrigger1;

	private EventTrigger _oSelectedSlotEventTrigger2;

	private EventTrigger _oSelectedSlotEventTrigger3;

	private EventTrigger _oSelectedSlotEventTrigger4;

	private EventTrigger _oSelectedSlotEventTrigger5;

	private Button _oSelectedSlotButton1;

	private Button _oSelectedSlotButton2;

	private Button _oSelectedSlotButton3;

	private Button _oSelectedSlotButton4;

	private Button _oSelectedSlotButton5;

	private GameObject _oWeaponChangeRuleTip;

	private Image _oWeaponChangeRuleTipImage;

	private GameObject _oWeaponChangeKeyTip;

	private Image _oWeaponChangeKeyTipImage;

	private GameObject _oRpgChangeBack;

	private Image _oRpgChangeBackImage;

	private GameObject _oChangeCount;

	private Text _oChangeCountText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Playerbag";

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public bool BagTipRootShow
	{
		get
		{
			if (_oBagTipRoot != null)
			{
				return _oBagTipRoot.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BagTipRootShow != value && _oBagTipRoot != null)
			{
				_oBagTipRoot.SetObjectActive(value);
			}
		}
	}

	public Sprite BagOpenTipSprite
	{
		get
		{
			if (_oBagOpenTipImage != null)
			{
				return _oBagOpenTipImage.sprite;
			}
			return null;
		}
		set
		{
			if (BagOpenTipSprite != value && _oBagOpenTipImage != null)
			{
				_oBagOpenTipImage.sprite = value;
			}
		}
	}

	public bool BagIndexEnabled1
	{
		get
		{
			if (_oBagIndexImage1 != null)
			{
				return _oBagIndexImage1.enabled;
			}
			return false;
		}
		set
		{
			if (BagIndexEnabled1 != value && _oBagIndexImage1 != null)
			{
				_oBagIndexImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BagIndexEnabled2
	{
		get
		{
			if (_oBagIndexImage2 != null)
			{
				return _oBagIndexImage2.enabled;
			}
			return false;
		}
		set
		{
			if (BagIndexEnabled2 != value && _oBagIndexImage2 != null)
			{
				_oBagIndexImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BagIndexEnabled3
	{
		get
		{
			if (_oBagIndexImage3 != null)
			{
				return _oBagIndexImage3.enabled;
			}
			return false;
		}
		set
		{
			if (BagIndexEnabled3 != value && _oBagIndexImage3 != null)
			{
				_oBagIndexImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BagIndexEnabled4
	{
		get
		{
			if (_oBagIndexImage4 != null)
			{
				return _oBagIndexImage4.enabled;
			}
			return false;
		}
		set
		{
			if (BagIndexEnabled4 != value && _oBagIndexImage4 != null)
			{
				_oBagIndexImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BagIndexEnabled5
	{
		get
		{
			if (_oBagIndexImage5 != null)
			{
				return _oBagIndexImage5.enabled;
			}
			return false;
		}
		set
		{
			if (BagIndexEnabled5 != value && _oBagIndexImage5 != null)
			{
				_oBagIndexImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BagOpenedPanelShow
	{
		get
		{
			if (_oBagOpenedPanel != null)
			{
				return _oBagOpenedPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BagOpenedPanelShow != value && _oBagOpenedPanel != null)
			{
				_oBagOpenedPanel.SetObjectActive(value);
			}
		}
	}

	public bool NofirstWeaponShow
	{
		get
		{
			if (_oNofirstWeapon != null)
			{
				return _oNofirstWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NofirstWeaponShow != value && _oNofirstWeapon != null)
			{
				_oNofirstWeapon.SetObjectActive(value);
			}
		}
	}

	public Sprite NofirstWeaponSprite
	{
		get
		{
			if (_oNofirstWeaponImage != null)
			{
				return _oNofirstWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (NofirstWeaponSprite != value && _oNofirstWeaponImage != null)
			{
				_oNofirstWeaponImage.sprite = value;
			}
		}
	}

	public bool NosecondaryWeaponShow
	{
		get
		{
			if (_oNosecondaryWeapon != null)
			{
				return _oNosecondaryWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NosecondaryWeaponShow != value && _oNosecondaryWeapon != null)
			{
				_oNosecondaryWeapon.SetObjectActive(value);
			}
		}
	}

	public Sprite NosecondaryWeaponSprite
	{
		get
		{
			if (_oNosecondaryWeaponImage != null)
			{
				return _oNosecondaryWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (NosecondaryWeaponSprite != value && _oNosecondaryWeaponImage != null)
			{
				_oNosecondaryWeaponImage.sprite = value;
			}
		}
	}

	public bool NomeleeWeaponShow
	{
		get
		{
			if (_oNomeleeWeapon != null)
			{
				return _oNomeleeWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NomeleeWeaponShow != value && _oNomeleeWeapon != null)
			{
				_oNomeleeWeapon.SetObjectActive(value);
			}
		}
	}

	public Sprite NomeleeWeaponSprite
	{
		get
		{
			if (_oNomeleeWeaponImage != null)
			{
				return _oNomeleeWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (NomeleeWeaponSprite != value && _oNomeleeWeaponImage != null)
			{
				_oNomeleeWeaponImage.sprite = value;
			}
		}
	}

	public bool NobombWeaponShow1
	{
		get
		{
			if (_oNobombWeapon1 != null)
			{
				return _oNobombWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow1 != value && _oNobombWeapon1 != null)
			{
				_oNobombWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow2
	{
		get
		{
			if (_oNobombWeapon2 != null)
			{
				return _oNobombWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow2 != value && _oNobombWeapon2 != null)
			{
				_oNobombWeapon2.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow3
	{
		get
		{
			if (_oNobombWeapon3 != null)
			{
				return _oNobombWeapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow3 != value && _oNobombWeapon3 != null)
			{
				_oNobombWeapon3.SetObjectActive(value);
			}
		}
	}

	public Sprite NobombWeaponSprite1
	{
		get
		{
			if (_oNobombWeaponImage1 != null)
			{
				return _oNobombWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (NobombWeaponSprite1 != value && _oNobombWeaponImage1 != null)
			{
				_oNobombWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite NobombWeaponSprite2
	{
		get
		{
			if (_oNobombWeaponImage2 != null)
			{
				return _oNobombWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (NobombWeaponSprite2 != value && _oNobombWeaponImage2 != null)
			{
				_oNobombWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite NobombWeaponSprite3
	{
		get
		{
			if (_oNobombWeaponImage3 != null)
			{
				return _oNobombWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (NobombWeaponSprite3 != value && _oNobombWeaponImage3 != null)
			{
				_oNobombWeaponImage3.sprite = value;
			}
		}
	}

	public bool FirstWeaponEnabled
	{
		get
		{
			if (_oFirstWeaponImage != null)
			{
				return _oFirstWeaponImage.enabled;
			}
			return false;
		}
		set
		{
			if (FirstWeaponEnabled != value && _oFirstWeaponImage != null)
			{
				_oFirstWeaponImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite FirstWeaponSprite
	{
		get
		{
			if (_oFirstWeaponImage != null)
			{
				return _oFirstWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (FirstWeaponSprite != value && _oFirstWeaponImage != null)
			{
				_oFirstWeaponImage.sprite = value;
			}
		}
	}

	public bool SecondaryWeaponEnabled
	{
		get
		{
			if (_oSecondaryWeaponImage != null)
			{
				return _oSecondaryWeaponImage.enabled;
			}
			return false;
		}
		set
		{
			if (SecondaryWeaponEnabled != value && _oSecondaryWeaponImage != null)
			{
				_oSecondaryWeaponImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite SecondaryWeaponSprite
	{
		get
		{
			if (_oSecondaryWeaponImage != null)
			{
				return _oSecondaryWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (SecondaryWeaponSprite != value && _oSecondaryWeaponImage != null)
			{
				_oSecondaryWeaponImage.sprite = value;
			}
		}
	}

	public bool MeleeWeaponEnabled
	{
		get
		{
			if (_oMeleeWeaponImage != null)
			{
				return _oMeleeWeaponImage.enabled;
			}
			return false;
		}
		set
		{
			if (MeleeWeaponEnabled != value && _oMeleeWeaponImage != null)
			{
				_oMeleeWeaponImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite MeleeWeaponSprite
	{
		get
		{
			if (_oMeleeWeaponImage != null)
			{
				return _oMeleeWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (MeleeWeaponSprite != value && _oMeleeWeaponImage != null)
			{
				_oMeleeWeaponImage.sprite = value;
			}
		}
	}

	public bool BombWeaponEnabled1
	{
		get
		{
			if (_oBombWeaponImage1 != null)
			{
				return _oBombWeaponImage1.enabled;
			}
			return false;
		}
		set
		{
			if (BombWeaponEnabled1 != value && _oBombWeaponImage1 != null)
			{
				_oBombWeaponImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BombWeaponEnabled2
	{
		get
		{
			if (_oBombWeaponImage2 != null)
			{
				return _oBombWeaponImage2.enabled;
			}
			return false;
		}
		set
		{
			if (BombWeaponEnabled2 != value && _oBombWeaponImage2 != null)
			{
				_oBombWeaponImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool BombWeaponEnabled3
	{
		get
		{
			if (_oBombWeaponImage3 != null)
			{
				return _oBombWeaponImage3.enabled;
			}
			return false;
		}
		set
		{
			if (BombWeaponEnabled3 != value && _oBombWeaponImage3 != null)
			{
				_oBombWeaponImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite BombWeaponSprite1
	{
		get
		{
			if (_oBombWeaponImage1 != null)
			{
				return _oBombWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BombWeaponSprite1 != value && _oBombWeaponImage1 != null)
			{
				_oBombWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite BombWeaponSprite2
	{
		get
		{
			if (_oBombWeaponImage2 != null)
			{
				return _oBombWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BombWeaponSprite2 != value && _oBombWeaponImage2 != null)
			{
				_oBombWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite BombWeaponSprite3
	{
		get
		{
			if (_oBombWeaponImage3 != null)
			{
				return _oBombWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BombWeaponSprite3 != value && _oBombWeaponImage3 != null)
			{
				_oBombWeaponImage3.sprite = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers1
	{
		get
		{
			if (_oSlotEventTrigger1 != null)
			{
				return _oSlotEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers1 != value && _oSlotEventTrigger1 != null)
			{
				_oSlotEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers2
	{
		get
		{
			if (_oSlotEventTrigger2 != null)
			{
				return _oSlotEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers2 != value && _oSlotEventTrigger2 != null)
			{
				_oSlotEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers3
	{
		get
		{
			if (_oSlotEventTrigger3 != null)
			{
				return _oSlotEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers3 != value && _oSlotEventTrigger3 != null)
			{
				_oSlotEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers4
	{
		get
		{
			if (_oSlotEventTrigger4 != null)
			{
				return _oSlotEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers4 != value && _oSlotEventTrigger4 != null)
			{
				_oSlotEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers5
	{
		get
		{
			if (_oSlotEventTrigger5 != null)
			{
				return _oSlotEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers5 != value && _oSlotEventTrigger5 != null)
			{
				_oSlotEventTrigger5.triggers = value;
			}
		}
	}

	public bool SlotButtonable1
	{
		get
		{
			if (_oSlotButton1 != null)
			{
				return _oSlotButton1.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable1 != value && _oSlotButton1 != null)
			{
				_oSlotButton1.interactable = value;
			}
		}
	}

	public bool SlotButtonable2
	{
		get
		{
			if (_oSlotButton2 != null)
			{
				return _oSlotButton2.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable2 != value && _oSlotButton2 != null)
			{
				_oSlotButton2.interactable = value;
			}
		}
	}

	public bool SlotButtonable3
	{
		get
		{
			if (_oSlotButton3 != null)
			{
				return _oSlotButton3.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable3 != value && _oSlotButton3 != null)
			{
				_oSlotButton3.interactable = value;
			}
		}
	}

	public bool SlotButtonable4
	{
		get
		{
			if (_oSlotButton4 != null)
			{
				return _oSlotButton4.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable4 != value && _oSlotButton4 != null)
			{
				_oSlotButton4.interactable = value;
			}
		}
	}

	public bool SlotButtonable5
	{
		get
		{
			if (_oSlotButton5 != null)
			{
				return _oSlotButton5.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable5 != value && _oSlotButton5 != null)
			{
				_oSlotButton5.interactable = value;
			}
		}
	}

	public bool SelectedSlotShow1
	{
		get
		{
			if (_oSelectedSlot1 != null)
			{
				return _oSelectedSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow1 != value && _oSelectedSlot1 != null)
			{
				_oSelectedSlot1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow2
	{
		get
		{
			if (_oSelectedSlot2 != null)
			{
				return _oSelectedSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow2 != value && _oSelectedSlot2 != null)
			{
				_oSelectedSlot2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow3
	{
		get
		{
			if (_oSelectedSlot3 != null)
			{
				return _oSelectedSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow3 != value && _oSelectedSlot3 != null)
			{
				_oSelectedSlot3.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow4
	{
		get
		{
			if (_oSelectedSlot4 != null)
			{
				return _oSelectedSlot4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow4 != value && _oSelectedSlot4 != null)
			{
				_oSelectedSlot4.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow5
	{
		get
		{
			if (_oSelectedSlot5 != null)
			{
				return _oSelectedSlot5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow5 != value && _oSelectedSlot5 != null)
			{
				_oSelectedSlot5.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers1
	{
		get
		{
			if (_oSelectedSlotEventTrigger1 != null)
			{
				return _oSelectedSlotEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers1 != value && _oSelectedSlotEventTrigger1 != null)
			{
				_oSelectedSlotEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers2
	{
		get
		{
			if (_oSelectedSlotEventTrigger2 != null)
			{
				return _oSelectedSlotEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers2 != value && _oSelectedSlotEventTrigger2 != null)
			{
				_oSelectedSlotEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers3
	{
		get
		{
			if (_oSelectedSlotEventTrigger3 != null)
			{
				return _oSelectedSlotEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers3 != value && _oSelectedSlotEventTrigger3 != null)
			{
				_oSelectedSlotEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers4
	{
		get
		{
			if (_oSelectedSlotEventTrigger4 != null)
			{
				return _oSelectedSlotEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers4 != value && _oSelectedSlotEventTrigger4 != null)
			{
				_oSelectedSlotEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers5
	{
		get
		{
			if (_oSelectedSlotEventTrigger5 != null)
			{
				return _oSelectedSlotEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers5 != value && _oSelectedSlotEventTrigger5 != null)
			{
				_oSelectedSlotEventTrigger5.triggers = value;
			}
		}
	}

	public bool SelectedSlotButtonable1
	{
		get
		{
			if (_oSelectedSlotButton1 != null)
			{
				return _oSelectedSlotButton1.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable1 != value && _oSelectedSlotButton1 != null)
			{
				_oSelectedSlotButton1.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable2
	{
		get
		{
			if (_oSelectedSlotButton2 != null)
			{
				return _oSelectedSlotButton2.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable2 != value && _oSelectedSlotButton2 != null)
			{
				_oSelectedSlotButton2.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable3
	{
		get
		{
			if (_oSelectedSlotButton3 != null)
			{
				return _oSelectedSlotButton3.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable3 != value && _oSelectedSlotButton3 != null)
			{
				_oSelectedSlotButton3.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable4
	{
		get
		{
			if (_oSelectedSlotButton4 != null)
			{
				return _oSelectedSlotButton4.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable4 != value && _oSelectedSlotButton4 != null)
			{
				_oSelectedSlotButton4.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable5
	{
		get
		{
			if (_oSelectedSlotButton5 != null)
			{
				return _oSelectedSlotButton5.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable5 != value && _oSelectedSlotButton5 != null)
			{
				_oSelectedSlotButton5.interactable = value;
			}
		}
	}

	public bool WeaponChangeRuleTipShow
	{
		get
		{
			if (_oWeaponChangeRuleTip != null)
			{
				return _oWeaponChangeRuleTip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponChangeRuleTipShow != value && _oWeaponChangeRuleTip != null)
			{
				_oWeaponChangeRuleTip.SetObjectActive(value);
			}
		}
	}

	public Sprite WeaponChangeRuleTipSprite
	{
		get
		{
			if (_oWeaponChangeRuleTipImage != null)
			{
				return _oWeaponChangeRuleTipImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponChangeRuleTipSprite != value && _oWeaponChangeRuleTipImage != null)
			{
				_oWeaponChangeRuleTipImage.sprite = value;
			}
		}
	}

	public Sprite WeaponChangeKeyTipSprite
	{
		get
		{
			if (_oWeaponChangeKeyTipImage != null)
			{
				return _oWeaponChangeKeyTipImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponChangeKeyTipSprite != value && _oWeaponChangeKeyTipImage != null)
			{
				_oWeaponChangeKeyTipImage.sprite = value;
			}
		}
	}

	public bool RpgChangeBackShow
	{
		get
		{
			if (_oRpgChangeBack != null)
			{
				return _oRpgChangeBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgChangeBackShow != value && _oRpgChangeBack != null)
			{
				_oRpgChangeBack.SetObjectActive(value);
			}
		}
	}

	public Sprite RpgChangeBackSprite
	{
		get
		{
			if (_oRpgChangeBackImage != null)
			{
				return _oRpgChangeBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (RpgChangeBackSprite != value && _oRpgChangeBackImage != null)
			{
				_oRpgChangeBackImage.sprite = value;
			}
		}
	}

	public string ChangeCountString
	{
		get
		{
			if (_oChangeCountText != null)
			{
				return _oChangeCountText.text;
			}
			return null;
		}
		set
		{
			if (ChangeCountString != value && _oChangeCountText != null)
			{
				_oChangeCountText.text = value;
			}
		}
	}

	public string ResourceBundleName
	{
		get
		{
			return _resourceBundleName;
		}
		set
		{
			_resourceBundleName = value;
		}
	}

	public string ResourceAssetName
	{
		get
		{
			return _resourceAssetName;
		}
		set
		{
			_resourceAssetName = value;
		}
	}

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public bool IsInited => _viewGameObject != null;

	public void CreateBinding(GameObject instance)
	{
		_viewGameObject = instance;
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "BagTipRoot":
				_oBagTipRoot = transform.gameObject;
				break;
			case "BagOpenTip":
				_oBagOpenTip = transform.gameObject;
				_oBagOpenTipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BagIndex1":
				_oBagIndex1 = transform.gameObject;
				_oBagIndexImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "BagIndex2":
				_oBagIndex2 = transform.gameObject;
				_oBagIndexImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BagIndex3":
				_oBagIndex3 = transform.gameObject;
				_oBagIndexImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "BagIndex4":
				_oBagIndex4 = transform.gameObject;
				_oBagIndexImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "BagIndex5":
				_oBagIndex5 = transform.gameObject;
				_oBagIndexImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "BagOpenedPanel":
				_oBagOpenedPanel = transform.gameObject;
				break;
			case "NofirstWeapon":
				_oNofirstWeapon = transform.gameObject;
				_oNofirstWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NosecondaryWeapon":
				_oNosecondaryWeapon = transform.gameObject;
				_oNosecondaryWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NomeleeWeapon":
				_oNomeleeWeapon = transform.gameObject;
				_oNomeleeWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NobombWeapon1":
				_oNobombWeapon1 = transform.gameObject;
				_oNobombWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "NobombWeapon2":
				_oNobombWeapon2 = transform.gameObject;
				_oNobombWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "NobombWeapon3":
				_oNobombWeapon3 = transform.gameObject;
				_oNobombWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "FirstWeapon":
				_oFirstWeapon = transform.gameObject;
				_oFirstWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondaryWeapon":
				_oSecondaryWeapon = transform.gameObject;
				_oSecondaryWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MeleeWeapon":
				_oMeleeWeapon = transform.gameObject;
				_oMeleeWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BombWeapon1":
				_oBombWeapon1 = transform.gameObject;
				_oBombWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "BombWeapon2":
				_oBombWeapon2 = transform.gameObject;
				_oBombWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BombWeapon3":
				_oBombWeapon3 = transform.gameObject;
				_oBombWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Slot1":
				_oSlot1 = transform.gameObject;
				_oSlotEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot2":
				_oSlot2 = transform.gameObject;
				_oSlotEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot3":
				_oSlot3 = transform.gameObject;
				_oSlotEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot4":
				_oSlot4 = transform.gameObject;
				_oSlotEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot5":
				_oSlot5 = transform.gameObject;
				_oSlotEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot1":
				_oSelectedSlot1 = transform.gameObject;
				_oSelectedSlotEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot2":
				_oSelectedSlot2 = transform.gameObject;
				_oSelectedSlotEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot3":
				_oSelectedSlot3 = transform.gameObject;
				_oSelectedSlotEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot4":
				_oSelectedSlot4 = transform.gameObject;
				_oSelectedSlotEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot5":
				_oSelectedSlot5 = transform.gameObject;
				_oSelectedSlotEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponChangeRuleTip":
				_oWeaponChangeRuleTip = transform.gameObject;
				_oWeaponChangeRuleTipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponChangeKeyTip":
				_oWeaponChangeKeyTip = transform.gameObject;
				_oWeaponChangeKeyTipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "RpgChangeBack":
				_oRpgChangeBack = transform.gameObject;
				_oRpgChangeBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ChangeCount":
				_oChangeCount = transform.gameObject;
				_oChangeCountText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetBagIndexEnabled(int index)
	{
		return index switch
		{
			1 => BagIndexEnabled1, 
			2 => BagIndexEnabled2, 
			3 => BagIndexEnabled3, 
			4 => BagIndexEnabled4, 
			5 => BagIndexEnabled5, 
			_ => false, 
		};
	}

	public void SetBagIndexEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BagIndexEnabled1 = value;
			break;
		case 2:
			BagIndexEnabled2 = value;
			break;
		case 3:
			BagIndexEnabled3 = value;
			break;
		case 4:
			BagIndexEnabled4 = value;
			break;
		case 5:
			BagIndexEnabled5 = value;
			break;
		}
	}

	public bool GetNobombWeaponShow(int index)
	{
		return index switch
		{
			1 => NobombWeaponShow1, 
			2 => NobombWeaponShow2, 
			3 => NobombWeaponShow3, 
			_ => false, 
		};
	}

	public void SetNobombWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NobombWeaponShow1 = value;
			break;
		case 2:
			NobombWeaponShow2 = value;
			break;
		case 3:
			NobombWeaponShow3 = value;
			break;
		}
	}

	public Sprite GetNobombWeaponSprite(int index)
	{
		return index switch
		{
			1 => NobombWeaponSprite1, 
			2 => NobombWeaponSprite2, 
			3 => NobombWeaponSprite3, 
			_ => null, 
		};
	}

	public void SetNobombWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			NobombWeaponSprite1 = value;
			break;
		case 2:
			NobombWeaponSprite2 = value;
			break;
		case 3:
			NobombWeaponSprite3 = value;
			break;
		}
	}

	public void FirstWeaponNtvsize()
	{
		if (_oFirstWeaponImage != null)
		{
			_oFirstWeaponImage.SetNativeSize();
		}
	}

	public void SecondaryWeaponNtvsize()
	{
		if (_oSecondaryWeaponImage != null)
		{
			_oSecondaryWeaponImage.SetNativeSize();
		}
	}

	public void MeleeWeaponNtvsize()
	{
		if (_oMeleeWeaponImage != null)
		{
			_oMeleeWeaponImage.SetNativeSize();
		}
	}

	public bool GetBombWeaponEnabled(int index)
	{
		return index switch
		{
			1 => BombWeaponEnabled1, 
			2 => BombWeaponEnabled2, 
			3 => BombWeaponEnabled3, 
			_ => false, 
		};
	}

	public void SetBombWeaponEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BombWeaponEnabled1 = value;
			break;
		case 2:
			BombWeaponEnabled2 = value;
			break;
		case 3:
			BombWeaponEnabled3 = value;
			break;
		}
	}

	public Sprite GetBombWeaponSprite(int index)
	{
		return index switch
		{
			1 => BombWeaponSprite1, 
			2 => BombWeaponSprite2, 
			3 => BombWeaponSprite3, 
			_ => null, 
		};
	}

	public void SetBombWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BombWeaponSprite1 = value;
			break;
		case 2:
			BombWeaponSprite2 = value;
			break;
		case 3:
			BombWeaponSprite3 = value;
			break;
		}
	}

	public void BombWeaponNtvsize1()
	{
		if (_oBombWeaponImage1 != null)
		{
			_oBombWeaponImage1.SetNativeSize();
		}
	}

	public void BombWeaponNtvsize2()
	{
		if (_oBombWeaponImage2 != null)
		{
			_oBombWeaponImage2.SetNativeSize();
		}
	}

	public void BombWeaponNtvsize3()
	{
		if (_oBombWeaponImage3 != null)
		{
			_oBombWeaponImage3.SetNativeSize();
		}
	}

	public void CallBombWeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			BombWeaponNtvsize1();
			break;
		case 2:
			BombWeaponNtvsize2();
			break;
		case 3:
			BombWeaponNtvsize3();
			break;
		}
	}

	public List<EventTrigger.Entry> GetSlotTriggers(int index)
	{
		return index switch
		{
			1 => SlotTriggers1, 
			2 => SlotTriggers2, 
			3 => SlotTriggers3, 
			4 => SlotTriggers4, 
			5 => SlotTriggers5, 
			_ => null, 
		};
	}

	public void SetSlotTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SlotTriggers1 = value;
			break;
		case 2:
			SlotTriggers2 = value;
			break;
		case 3:
			SlotTriggers3 = value;
			break;
		case 4:
			SlotTriggers4 = value;
			break;
		case 5:
			SlotTriggers5 = value;
			break;
		}
	}

	public bool GetSlotButtonable(int index)
	{
		return index switch
		{
			1 => SlotButtonable1, 
			2 => SlotButtonable2, 
			3 => SlotButtonable3, 
			4 => SlotButtonable4, 
			5 => SlotButtonable5, 
			_ => true, 
		};
	}

	public void SetSlotButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlotButtonable1 = value;
			break;
		case 2:
			SlotButtonable2 = value;
			break;
		case 3:
			SlotButtonable3 = value;
			break;
		case 4:
			SlotButtonable4 = value;
			break;
		case 5:
			SlotButtonable5 = value;
			break;
		}
	}

	public bool GetSelectedSlotShow(int index)
	{
		return index switch
		{
			1 => SelectedSlotShow1, 
			2 => SelectedSlotShow2, 
			3 => SelectedSlotShow3, 
			4 => SelectedSlotShow4, 
			5 => SelectedSlotShow5, 
			_ => false, 
		};
	}

	public void SetSelectedSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotShow1 = value;
			break;
		case 2:
			SelectedSlotShow2 = value;
			break;
		case 3:
			SelectedSlotShow3 = value;
			break;
		case 4:
			SelectedSlotShow4 = value;
			break;
		case 5:
			SelectedSlotShow5 = value;
			break;
		}
	}

	public List<EventTrigger.Entry> GetSelectedSlotTriggers(int index)
	{
		return index switch
		{
			1 => SelectedSlotTriggers1, 
			2 => SelectedSlotTriggers2, 
			3 => SelectedSlotTriggers3, 
			4 => SelectedSlotTriggers4, 
			5 => SelectedSlotTriggers5, 
			_ => null, 
		};
	}

	public void SetSelectedSlotTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotTriggers1 = value;
			break;
		case 2:
			SelectedSlotTriggers2 = value;
			break;
		case 3:
			SelectedSlotTriggers3 = value;
			break;
		case 4:
			SelectedSlotTriggers4 = value;
			break;
		case 5:
			SelectedSlotTriggers5 = value;
			break;
		}
	}

	public bool GetSelectedSlotButtonable(int index)
	{
		return index switch
		{
			1 => SelectedSlotButtonable1, 
			2 => SelectedSlotButtonable2, 
			3 => SelectedSlotButtonable3, 
			4 => SelectedSlotButtonable4, 
			5 => SelectedSlotButtonable5, 
			_ => true, 
		};
	}

	public void SetSelectedSlotButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotButtonable1 = value;
			break;
		case 2:
			SelectedSlotButtonable2 = value;
			break;
		case 3:
			SelectedSlotButtonable3 = value;
			break;
		case 4:
			SelectedSlotButtonable4 = value;
			break;
		case 5:
			SelectedSlotButtonable5 = value;
			break;
		}
	}

	public bool IsPropertyExist(string name)
	{
		return true;
	}

	public Transform GetParentLinkNode()
	{
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetObjectActive(isVisible);
		}
	}

	public EventTrigger.Entry CreateTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = eventId
		};
		entry.callback.AddListener(callback);
		triggers?.Add(entry);
		return entry;
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
