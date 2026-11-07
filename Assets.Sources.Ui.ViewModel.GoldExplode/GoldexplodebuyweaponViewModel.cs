using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GoldExplode;

[GameUiTest]
public class GoldexplodebuyweaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _oMoneyText;

	private Text _oMoneyTextText;

	private GameObject _oAutoCloseCheck;

	private Button _oAutoCloseCheckButton;

	private GameObject _oAutoCloseCheckOk;

	private Button _oAutoCloseCheckOkButton;

	private GameObject _oGiveButton;

	private Button _oGiveButtonButton;

	private GameObject _oOneKeyButton;

	private Button _oOneKeyButtonButton;

	private GameObject _oSelectWeaponTypePanel;

	private GameObject _oSelectTypeCloseButton;

	private Button _oSelectTypeCloseButtonButton;

	private GameObject _oWeaponTypeSlot1;

	private GameObject _oWeaponTypeSlot2;

	private GameObject _oWeaponTypeSlot3;

	private GameObject _oWeaponTypeSlot4;

	private GameObject _oWeaponTypeSlot5;

	private Button _oWeaponTypeSlotButton1;

	private Button _oWeaponTypeSlotButton2;

	private Button _oWeaponTypeSlotButton3;

	private Button _oWeaponTypeSlotButton4;

	private Button _oWeaponTypeSlotButton5;

	private GameObject _oTypeImage1;

	private GameObject _oTypeImage2;

	private GameObject _oTypeImage3;

	private GameObject _oTypeImage4;

	private GameObject _oTypeImage5;

	private Image _oTypeImageImage1;

	private Image _oTypeImageImage2;

	private Image _oTypeImageImage3;

	private Image _oTypeImageImage4;

	private Image _oTypeImageImage5;

	private GameObject _oIndex1;

	private GameObject _oIndex2;

	private GameObject _oIndex3;

	private GameObject _oIndex4;

	private GameObject _oIndex5;

	private Text _oIndexText1;

	private Text _oIndexText2;

	private Text _oIndexText3;

	private Text _oIndexText4;

	private Text _oIndexText5;

	private GameObject _oSelectWeaponPanel;

	private GameObject _oSelectCloseButton;

	private Button _oSelectCloseButtonButton;

	private GameObject _oReturnButton;

	private Button _oReturnButtonButton;

	private GameObject _oWeaponSlot1;

	private GameObject _oWeaponSlot2;

	private GameObject _oWeaponSlot3;

	private GameObject _oWeaponSlot4;

	private GameObject _oWeaponSlot5;

	private GameObject _oWeaponSlot6;

	private GameObject _oWeaponSlot7;

	private GameObject _oWeaponSlot8;

	private GameObject _oWeaponCommon1;

	private GameObject _oWeaponCommon2;

	private GameObject _oWeaponCommon3;

	private GameObject _oWeaponCommon4;

	private GameObject _oWeaponCommon5;

	private GameObject _oWeaponCommon6;

	private GameObject _oWeaponCommon7;

	private GameObject _oWeaponCommon8;

	private Button _oWeaponCommonButton1;

	private Button _oWeaponCommonButton2;

	private Button _oWeaponCommonButton3;

	private Button _oWeaponCommonButton4;

	private Button _oWeaponCommonButton5;

	private Button _oWeaponCommonButton6;

	private Button _oWeaponCommonButton7;

	private Button _oWeaponCommonButton8;

	private GameObject _oWeaponLucky1;

	private GameObject _oWeaponLucky2;

	private GameObject _oWeaponLucky3;

	private GameObject _oWeaponLucky4;

	private GameObject _oWeaponLucky5;

	private GameObject _oWeaponLucky6;

	private GameObject _oWeaponLucky7;

	private GameObject _oWeaponLucky8;

	private Button _oWeaponLuckyButton1;

	private Button _oWeaponLuckyButton2;

	private Button _oWeaponLuckyButton3;

	private Button _oWeaponLuckyButton4;

	private Button _oWeaponLuckyButton5;

	private Button _oWeaponLuckyButton6;

	private Button _oWeaponLuckyButton7;

	private Button _oWeaponLuckyButton8;

	private GameObject _oWeaponImage1;

	private GameObject _oWeaponImage2;

	private GameObject _oWeaponImage3;

	private GameObject _oWeaponImage4;

	private GameObject _oWeaponImage5;

	private GameObject _oWeaponImage6;

	private GameObject _oWeaponImage7;

	private GameObject _oWeaponImage8;

	private Image _oWeaponImageImage1;

	private Image _oWeaponImageImage2;

	private Image _oWeaponImageImage3;

	private Image _oWeaponImageImage4;

	private Image _oWeaponImageImage5;

	private Image _oWeaponImageImage6;

	private Image _oWeaponImageImage7;

	private Image _oWeaponImageImage8;

	private GameObject _oWeaponName1;

	private GameObject _oWeaponName2;

	private GameObject _oWeaponName3;

	private GameObject _oWeaponName4;

	private GameObject _oWeaponName5;

	private GameObject _oWeaponName6;

	private GameObject _oWeaponName7;

	private GameObject _oWeaponName8;

	private Text _oWeaponNameText1;

	private Text _oWeaponNameText2;

	private Text _oWeaponNameText3;

	private Text _oWeaponNameText4;

	private Text _oWeaponNameText5;

	private Text _oWeaponNameText6;

	private Text _oWeaponNameText7;

	private Text _oWeaponNameText8;

	private GameObject _oWeaponIndex1;

	private GameObject _oWeaponIndex2;

	private GameObject _oWeaponIndex3;

	private GameObject _oWeaponIndex4;

	private GameObject _oWeaponIndex5;

	private GameObject _oWeaponIndex6;

	private GameObject _oWeaponIndex7;

	private GameObject _oWeaponIndex8;

	private Text _oWeaponIndexText1;

	private Text _oWeaponIndexText2;

	private Text _oWeaponIndexText3;

	private Text _oWeaponIndexText4;

	private Text _oWeaponIndexText5;

	private Text _oWeaponIndexText6;

	private Text _oWeaponIndexText7;

	private Text _oWeaponIndexText8;

	private GameObject _oWeaponGold1;

	private GameObject _oWeaponGold2;

	private GameObject _oWeaponGold3;

	private GameObject _oWeaponGold4;

	private GameObject _oWeaponGold5;

	private GameObject _oWeaponGold6;

	private GameObject _oWeaponGold7;

	private GameObject _oWeaponGold8;

	private Text _oWeaponGoldText1;

	private Text _oWeaponGoldText2;

	private Text _oWeaponGoldText3;

	private Text _oWeaponGoldText4;

	private Text _oWeaponGoldText5;

	private Text _oWeaponGoldText6;

	private Text _oWeaponGoldText7;

	private Text _oWeaponGoldText8;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/goldexplode";

	private string _resourceAssetName = "Goldexplodebuyweapon";

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
			}
		}
	}

	public string MoneyTextString
	{
		get
		{
			if (_oMoneyTextText != null)
			{
				return _oMoneyTextText.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString != value && _oMoneyTextText != null)
			{
				_oMoneyTextText.text = value;
			}
		}
	}

	public bool AutoCloseCheckShow
	{
		get
		{
			if (_oAutoCloseCheck != null)
			{
				return _oAutoCloseCheck.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AutoCloseCheckShow != value && _oAutoCloseCheck != null)
			{
				_oAutoCloseCheck.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent AutoCloseCheckClicked
	{
		get
		{
			if (_oAutoCloseCheckButton != null)
			{
				return _oAutoCloseCheckButton.onClick;
			}
			return null;
		}
		set
		{
			if (AutoCloseCheckClicked != value && _oAutoCloseCheckButton != null)
			{
				_oAutoCloseCheckButton.onClick = value;
			}
		}
	}

	public bool AutoCloseCheckOkShow
	{
		get
		{
			if (_oAutoCloseCheckOk != null)
			{
				return _oAutoCloseCheckOk.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AutoCloseCheckOkShow != value && _oAutoCloseCheckOk != null)
			{
				_oAutoCloseCheckOk.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent AutoCloseCheckOkClicked
	{
		get
		{
			if (_oAutoCloseCheckOkButton != null)
			{
				return _oAutoCloseCheckOkButton.onClick;
			}
			return null;
		}
		set
		{
			if (AutoCloseCheckOkClicked != value && _oAutoCloseCheckOkButton != null)
			{
				_oAutoCloseCheckOkButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent GiveButtonClicked
	{
		get
		{
			if (_oGiveButtonButton != null)
			{
				return _oGiveButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (GiveButtonClicked != value && _oGiveButtonButton != null)
			{
				_oGiveButtonButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent OneKeyButtonClicked
	{
		get
		{
			if (_oOneKeyButtonButton != null)
			{
				return _oOneKeyButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (OneKeyButtonClicked != value && _oOneKeyButtonButton != null)
			{
				_oOneKeyButtonButton.onClick = value;
			}
		}
	}

	public bool SelectWeaponTypePanelShow
	{
		get
		{
			if (_oSelectWeaponTypePanel != null)
			{
				return _oSelectWeaponTypePanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectWeaponTypePanelShow != value && _oSelectWeaponTypePanel != null)
			{
				_oSelectWeaponTypePanel.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent SelectTypeCloseButtonClicked
	{
		get
		{
			if (_oSelectTypeCloseButtonButton != null)
			{
				return _oSelectTypeCloseButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (SelectTypeCloseButtonClicked != value && _oSelectTypeCloseButtonButton != null)
			{
				_oSelectTypeCloseButtonButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponTypeSlotClicked1
	{
		get
		{
			if (_oWeaponTypeSlotButton1 != null)
			{
				return _oWeaponTypeSlotButton1.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponTypeSlotClicked1 != value && _oWeaponTypeSlotButton1 != null)
			{
				_oWeaponTypeSlotButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponTypeSlotClicked2
	{
		get
		{
			if (_oWeaponTypeSlotButton2 != null)
			{
				return _oWeaponTypeSlotButton2.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponTypeSlotClicked2 != value && _oWeaponTypeSlotButton2 != null)
			{
				_oWeaponTypeSlotButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponTypeSlotClicked3
	{
		get
		{
			if (_oWeaponTypeSlotButton3 != null)
			{
				return _oWeaponTypeSlotButton3.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponTypeSlotClicked3 != value && _oWeaponTypeSlotButton3 != null)
			{
				_oWeaponTypeSlotButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponTypeSlotClicked4
	{
		get
		{
			if (_oWeaponTypeSlotButton4 != null)
			{
				return _oWeaponTypeSlotButton4.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponTypeSlotClicked4 != value && _oWeaponTypeSlotButton4 != null)
			{
				_oWeaponTypeSlotButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponTypeSlotClicked5
	{
		get
		{
			if (_oWeaponTypeSlotButton5 != null)
			{
				return _oWeaponTypeSlotButton5.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponTypeSlotClicked5 != value && _oWeaponTypeSlotButton5 != null)
			{
				_oWeaponTypeSlotButton5.onClick = value;
			}
		}
	}

	public Sprite TypeImageSprite1
	{
		get
		{
			if (_oTypeImageImage1 != null)
			{
				return _oTypeImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TypeImageSprite1 != value && _oTypeImageImage1 != null)
			{
				_oTypeImageImage1.sprite = value;
			}
		}
	}

	public Sprite TypeImageSprite2
	{
		get
		{
			if (_oTypeImageImage2 != null)
			{
				return _oTypeImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TypeImageSprite2 != value && _oTypeImageImage2 != null)
			{
				_oTypeImageImage2.sprite = value;
			}
		}
	}

	public Sprite TypeImageSprite3
	{
		get
		{
			if (_oTypeImageImage3 != null)
			{
				return _oTypeImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (TypeImageSprite3 != value && _oTypeImageImage3 != null)
			{
				_oTypeImageImage3.sprite = value;
			}
		}
	}

	public Sprite TypeImageSprite4
	{
		get
		{
			if (_oTypeImageImage4 != null)
			{
				return _oTypeImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (TypeImageSprite4 != value && _oTypeImageImage4 != null)
			{
				_oTypeImageImage4.sprite = value;
			}
		}
	}

	public Sprite TypeImageSprite5
	{
		get
		{
			if (_oTypeImageImage5 != null)
			{
				return _oTypeImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (TypeImageSprite5 != value && _oTypeImageImage5 != null)
			{
				_oTypeImageImage5.sprite = value;
			}
		}
	}

	public string IndexString1
	{
		get
		{
			if (_oIndexText1 != null)
			{
				return _oIndexText1.text;
			}
			return null;
		}
		set
		{
			if (IndexString1 != value && _oIndexText1 != null)
			{
				_oIndexText1.text = value;
			}
		}
	}

	public string IndexString2
	{
		get
		{
			if (_oIndexText2 != null)
			{
				return _oIndexText2.text;
			}
			return null;
		}
		set
		{
			if (IndexString2 != value && _oIndexText2 != null)
			{
				_oIndexText2.text = value;
			}
		}
	}

	public string IndexString3
	{
		get
		{
			if (_oIndexText3 != null)
			{
				return _oIndexText3.text;
			}
			return null;
		}
		set
		{
			if (IndexString3 != value && _oIndexText3 != null)
			{
				_oIndexText3.text = value;
			}
		}
	}

	public string IndexString4
	{
		get
		{
			if (_oIndexText4 != null)
			{
				return _oIndexText4.text;
			}
			return null;
		}
		set
		{
			if (IndexString4 != value && _oIndexText4 != null)
			{
				_oIndexText4.text = value;
			}
		}
	}

	public string IndexString5
	{
		get
		{
			if (_oIndexText5 != null)
			{
				return _oIndexText5.text;
			}
			return null;
		}
		set
		{
			if (IndexString5 != value && _oIndexText5 != null)
			{
				_oIndexText5.text = value;
			}
		}
	}

	public bool SelectWeaponPanelShow
	{
		get
		{
			if (_oSelectWeaponPanel != null)
			{
				return _oSelectWeaponPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectWeaponPanelShow != value && _oSelectWeaponPanel != null)
			{
				_oSelectWeaponPanel.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent SelectCloseButtonClicked
	{
		get
		{
			if (_oSelectCloseButtonButton != null)
			{
				return _oSelectCloseButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (SelectCloseButtonClicked != value && _oSelectCloseButtonButton != null)
			{
				_oSelectCloseButtonButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ReturnButtonClicked
	{
		get
		{
			if (_oReturnButtonButton != null)
			{
				return _oReturnButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (ReturnButtonClicked != value && _oReturnButtonButton != null)
			{
				_oReturnButtonButton.onClick = value;
			}
		}
	}

	public bool WeaponSlotShow1
	{
		get
		{
			if (_oWeaponSlot1 != null)
			{
				return _oWeaponSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow1 != value && _oWeaponSlot1 != null)
			{
				_oWeaponSlot1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow2
	{
		get
		{
			if (_oWeaponSlot2 != null)
			{
				return _oWeaponSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow2 != value && _oWeaponSlot2 != null)
			{
				_oWeaponSlot2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow3
	{
		get
		{
			if (_oWeaponSlot3 != null)
			{
				return _oWeaponSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow3 != value && _oWeaponSlot3 != null)
			{
				_oWeaponSlot3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow4
	{
		get
		{
			if (_oWeaponSlot4 != null)
			{
				return _oWeaponSlot4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow4 != value && _oWeaponSlot4 != null)
			{
				_oWeaponSlot4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow5
	{
		get
		{
			if (_oWeaponSlot5 != null)
			{
				return _oWeaponSlot5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow5 != value && _oWeaponSlot5 != null)
			{
				_oWeaponSlot5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow6
	{
		get
		{
			if (_oWeaponSlot6 != null)
			{
				return _oWeaponSlot6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow6 != value && _oWeaponSlot6 != null)
			{
				_oWeaponSlot6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow7
	{
		get
		{
			if (_oWeaponSlot7 != null)
			{
				return _oWeaponSlot7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow7 != value && _oWeaponSlot7 != null)
			{
				_oWeaponSlot7.SetObjectActive(value);
			}
		}
	}

	public bool WeaponSlotShow8
	{
		get
		{
			if (_oWeaponSlot8 != null)
			{
				return _oWeaponSlot8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSlotShow8 != value && _oWeaponSlot8 != null)
			{
				_oWeaponSlot8.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow1
	{
		get
		{
			if (_oWeaponCommon1 != null)
			{
				return _oWeaponCommon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow1 != value && _oWeaponCommon1 != null)
			{
				_oWeaponCommon1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow2
	{
		get
		{
			if (_oWeaponCommon2 != null)
			{
				return _oWeaponCommon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow2 != value && _oWeaponCommon2 != null)
			{
				_oWeaponCommon2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow3
	{
		get
		{
			if (_oWeaponCommon3 != null)
			{
				return _oWeaponCommon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow3 != value && _oWeaponCommon3 != null)
			{
				_oWeaponCommon3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow4
	{
		get
		{
			if (_oWeaponCommon4 != null)
			{
				return _oWeaponCommon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow4 != value && _oWeaponCommon4 != null)
			{
				_oWeaponCommon4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow5
	{
		get
		{
			if (_oWeaponCommon5 != null)
			{
				return _oWeaponCommon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow5 != value && _oWeaponCommon5 != null)
			{
				_oWeaponCommon5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow6
	{
		get
		{
			if (_oWeaponCommon6 != null)
			{
				return _oWeaponCommon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow6 != value && _oWeaponCommon6 != null)
			{
				_oWeaponCommon6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow7
	{
		get
		{
			if (_oWeaponCommon7 != null)
			{
				return _oWeaponCommon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow7 != value && _oWeaponCommon7 != null)
			{
				_oWeaponCommon7.SetObjectActive(value);
			}
		}
	}

	public bool WeaponCommonShow8
	{
		get
		{
			if (_oWeaponCommon8 != null)
			{
				return _oWeaponCommon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCommonShow8 != value && _oWeaponCommon8 != null)
			{
				_oWeaponCommon8.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked1
	{
		get
		{
			if (_oWeaponCommonButton1 != null)
			{
				return _oWeaponCommonButton1.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked1 != value && _oWeaponCommonButton1 != null)
			{
				_oWeaponCommonButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked2
	{
		get
		{
			if (_oWeaponCommonButton2 != null)
			{
				return _oWeaponCommonButton2.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked2 != value && _oWeaponCommonButton2 != null)
			{
				_oWeaponCommonButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked3
	{
		get
		{
			if (_oWeaponCommonButton3 != null)
			{
				return _oWeaponCommonButton3.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked3 != value && _oWeaponCommonButton3 != null)
			{
				_oWeaponCommonButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked4
	{
		get
		{
			if (_oWeaponCommonButton4 != null)
			{
				return _oWeaponCommonButton4.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked4 != value && _oWeaponCommonButton4 != null)
			{
				_oWeaponCommonButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked5
	{
		get
		{
			if (_oWeaponCommonButton5 != null)
			{
				return _oWeaponCommonButton5.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked5 != value && _oWeaponCommonButton5 != null)
			{
				_oWeaponCommonButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked6
	{
		get
		{
			if (_oWeaponCommonButton6 != null)
			{
				return _oWeaponCommonButton6.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked6 != value && _oWeaponCommonButton6 != null)
			{
				_oWeaponCommonButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked7
	{
		get
		{
			if (_oWeaponCommonButton7 != null)
			{
				return _oWeaponCommonButton7.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked7 != value && _oWeaponCommonButton7 != null)
			{
				_oWeaponCommonButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponCommonClicked8
	{
		get
		{
			if (_oWeaponCommonButton8 != null)
			{
				return _oWeaponCommonButton8.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponCommonClicked8 != value && _oWeaponCommonButton8 != null)
			{
				_oWeaponCommonButton8.onClick = value;
			}
		}
	}

	public bool WeaponLuckyShow1
	{
		get
		{
			if (_oWeaponLucky1 != null)
			{
				return _oWeaponLucky1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow1 != value && _oWeaponLucky1 != null)
			{
				_oWeaponLucky1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow2
	{
		get
		{
			if (_oWeaponLucky2 != null)
			{
				return _oWeaponLucky2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow2 != value && _oWeaponLucky2 != null)
			{
				_oWeaponLucky2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow3
	{
		get
		{
			if (_oWeaponLucky3 != null)
			{
				return _oWeaponLucky3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow3 != value && _oWeaponLucky3 != null)
			{
				_oWeaponLucky3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow4
	{
		get
		{
			if (_oWeaponLucky4 != null)
			{
				return _oWeaponLucky4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow4 != value && _oWeaponLucky4 != null)
			{
				_oWeaponLucky4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow5
	{
		get
		{
			if (_oWeaponLucky5 != null)
			{
				return _oWeaponLucky5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow5 != value && _oWeaponLucky5 != null)
			{
				_oWeaponLucky5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow6
	{
		get
		{
			if (_oWeaponLucky6 != null)
			{
				return _oWeaponLucky6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow6 != value && _oWeaponLucky6 != null)
			{
				_oWeaponLucky6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow7
	{
		get
		{
			if (_oWeaponLucky7 != null)
			{
				return _oWeaponLucky7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow7 != value && _oWeaponLucky7 != null)
			{
				_oWeaponLucky7.SetObjectActive(value);
			}
		}
	}

	public bool WeaponLuckyShow8
	{
		get
		{
			if (_oWeaponLucky8 != null)
			{
				return _oWeaponLucky8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponLuckyShow8 != value && _oWeaponLucky8 != null)
			{
				_oWeaponLucky8.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked1
	{
		get
		{
			if (_oWeaponLuckyButton1 != null)
			{
				return _oWeaponLuckyButton1.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked1 != value && _oWeaponLuckyButton1 != null)
			{
				_oWeaponLuckyButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked2
	{
		get
		{
			if (_oWeaponLuckyButton2 != null)
			{
				return _oWeaponLuckyButton2.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked2 != value && _oWeaponLuckyButton2 != null)
			{
				_oWeaponLuckyButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked3
	{
		get
		{
			if (_oWeaponLuckyButton3 != null)
			{
				return _oWeaponLuckyButton3.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked3 != value && _oWeaponLuckyButton3 != null)
			{
				_oWeaponLuckyButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked4
	{
		get
		{
			if (_oWeaponLuckyButton4 != null)
			{
				return _oWeaponLuckyButton4.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked4 != value && _oWeaponLuckyButton4 != null)
			{
				_oWeaponLuckyButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked5
	{
		get
		{
			if (_oWeaponLuckyButton5 != null)
			{
				return _oWeaponLuckyButton5.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked5 != value && _oWeaponLuckyButton5 != null)
			{
				_oWeaponLuckyButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked6
	{
		get
		{
			if (_oWeaponLuckyButton6 != null)
			{
				return _oWeaponLuckyButton6.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked6 != value && _oWeaponLuckyButton6 != null)
			{
				_oWeaponLuckyButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked7
	{
		get
		{
			if (_oWeaponLuckyButton7 != null)
			{
				return _oWeaponLuckyButton7.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked7 != value && _oWeaponLuckyButton7 != null)
			{
				_oWeaponLuckyButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent WeaponLuckyClicked8
	{
		get
		{
			if (_oWeaponLuckyButton8 != null)
			{
				return _oWeaponLuckyButton8.onClick;
			}
			return null;
		}
		set
		{
			if (WeaponLuckyClicked8 != value && _oWeaponLuckyButton8 != null)
			{
				_oWeaponLuckyButton8.onClick = value;
			}
		}
	}

	public bool WeaponImageShow1
	{
		get
		{
			if (_oWeaponImage1 != null)
			{
				return _oWeaponImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow1 != value && _oWeaponImage1 != null)
			{
				_oWeaponImage1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow2
	{
		get
		{
			if (_oWeaponImage2 != null)
			{
				return _oWeaponImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow2 != value && _oWeaponImage2 != null)
			{
				_oWeaponImage2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow3
	{
		get
		{
			if (_oWeaponImage3 != null)
			{
				return _oWeaponImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow3 != value && _oWeaponImage3 != null)
			{
				_oWeaponImage3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow4
	{
		get
		{
			if (_oWeaponImage4 != null)
			{
				return _oWeaponImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow4 != value && _oWeaponImage4 != null)
			{
				_oWeaponImage4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow5
	{
		get
		{
			if (_oWeaponImage5 != null)
			{
				return _oWeaponImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow5 != value && _oWeaponImage5 != null)
			{
				_oWeaponImage5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow6
	{
		get
		{
			if (_oWeaponImage6 != null)
			{
				return _oWeaponImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow6 != value && _oWeaponImage6 != null)
			{
				_oWeaponImage6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow7
	{
		get
		{
			if (_oWeaponImage7 != null)
			{
				return _oWeaponImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow7 != value && _oWeaponImage7 != null)
			{
				_oWeaponImage7.SetObjectActive(value);
			}
		}
	}

	public bool WeaponImageShow8
	{
		get
		{
			if (_oWeaponImage8 != null)
			{
				return _oWeaponImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponImageShow8 != value && _oWeaponImage8 != null)
			{
				_oWeaponImage8.SetObjectActive(value);
			}
		}
	}

	public Sprite WeaponImageSprite1
	{
		get
		{
			if (_oWeaponImageImage1 != null)
			{
				return _oWeaponImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite1 != value && _oWeaponImageImage1 != null)
			{
				_oWeaponImageImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite2
	{
		get
		{
			if (_oWeaponImageImage2 != null)
			{
				return _oWeaponImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite2 != value && _oWeaponImageImage2 != null)
			{
				_oWeaponImageImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite3
	{
		get
		{
			if (_oWeaponImageImage3 != null)
			{
				return _oWeaponImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite3 != value && _oWeaponImageImage3 != null)
			{
				_oWeaponImageImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite4
	{
		get
		{
			if (_oWeaponImageImage4 != null)
			{
				return _oWeaponImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite4 != value && _oWeaponImageImage4 != null)
			{
				_oWeaponImageImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite5
	{
		get
		{
			if (_oWeaponImageImage5 != null)
			{
				return _oWeaponImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite5 != value && _oWeaponImageImage5 != null)
			{
				_oWeaponImageImage5.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite6
	{
		get
		{
			if (_oWeaponImageImage6 != null)
			{
				return _oWeaponImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite6 != value && _oWeaponImageImage6 != null)
			{
				_oWeaponImageImage6.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite7
	{
		get
		{
			if (_oWeaponImageImage7 != null)
			{
				return _oWeaponImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite7 != value && _oWeaponImageImage7 != null)
			{
				_oWeaponImageImage7.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite8
	{
		get
		{
			if (_oWeaponImageImage8 != null)
			{
				return _oWeaponImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite8 != value && _oWeaponImageImage8 != null)
			{
				_oWeaponImageImage8.sprite = value;
			}
		}
	}

	public string WeaponNameString1
	{
		get
		{
			if (_oWeaponNameText1 != null)
			{
				return _oWeaponNameText1.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString1 != value && _oWeaponNameText1 != null)
			{
				_oWeaponNameText1.text = value;
			}
		}
	}

	public string WeaponNameString2
	{
		get
		{
			if (_oWeaponNameText2 != null)
			{
				return _oWeaponNameText2.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString2 != value && _oWeaponNameText2 != null)
			{
				_oWeaponNameText2.text = value;
			}
		}
	}

	public string WeaponNameString3
	{
		get
		{
			if (_oWeaponNameText3 != null)
			{
				return _oWeaponNameText3.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString3 != value && _oWeaponNameText3 != null)
			{
				_oWeaponNameText3.text = value;
			}
		}
	}

	public string WeaponNameString4
	{
		get
		{
			if (_oWeaponNameText4 != null)
			{
				return _oWeaponNameText4.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString4 != value && _oWeaponNameText4 != null)
			{
				_oWeaponNameText4.text = value;
			}
		}
	}

	public string WeaponNameString5
	{
		get
		{
			if (_oWeaponNameText5 != null)
			{
				return _oWeaponNameText5.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString5 != value && _oWeaponNameText5 != null)
			{
				_oWeaponNameText5.text = value;
			}
		}
	}

	public string WeaponNameString6
	{
		get
		{
			if (_oWeaponNameText6 != null)
			{
				return _oWeaponNameText6.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString6 != value && _oWeaponNameText6 != null)
			{
				_oWeaponNameText6.text = value;
			}
		}
	}

	public string WeaponNameString7
	{
		get
		{
			if (_oWeaponNameText7 != null)
			{
				return _oWeaponNameText7.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString7 != value && _oWeaponNameText7 != null)
			{
				_oWeaponNameText7.text = value;
			}
		}
	}

	public string WeaponNameString8
	{
		get
		{
			if (_oWeaponNameText8 != null)
			{
				return _oWeaponNameText8.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString8 != value && _oWeaponNameText8 != null)
			{
				_oWeaponNameText8.text = value;
			}
		}
	}

	public string WeaponIndexString1
	{
		get
		{
			if (_oWeaponIndexText1 != null)
			{
				return _oWeaponIndexText1.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString1 != value && _oWeaponIndexText1 != null)
			{
				_oWeaponIndexText1.text = value;
			}
		}
	}

	public string WeaponIndexString2
	{
		get
		{
			if (_oWeaponIndexText2 != null)
			{
				return _oWeaponIndexText2.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString2 != value && _oWeaponIndexText2 != null)
			{
				_oWeaponIndexText2.text = value;
			}
		}
	}

	public string WeaponIndexString3
	{
		get
		{
			if (_oWeaponIndexText3 != null)
			{
				return _oWeaponIndexText3.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString3 != value && _oWeaponIndexText3 != null)
			{
				_oWeaponIndexText3.text = value;
			}
		}
	}

	public string WeaponIndexString4
	{
		get
		{
			if (_oWeaponIndexText4 != null)
			{
				return _oWeaponIndexText4.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString4 != value && _oWeaponIndexText4 != null)
			{
				_oWeaponIndexText4.text = value;
			}
		}
	}

	public string WeaponIndexString5
	{
		get
		{
			if (_oWeaponIndexText5 != null)
			{
				return _oWeaponIndexText5.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString5 != value && _oWeaponIndexText5 != null)
			{
				_oWeaponIndexText5.text = value;
			}
		}
	}

	public string WeaponIndexString6
	{
		get
		{
			if (_oWeaponIndexText6 != null)
			{
				return _oWeaponIndexText6.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString6 != value && _oWeaponIndexText6 != null)
			{
				_oWeaponIndexText6.text = value;
			}
		}
	}

	public string WeaponIndexString7
	{
		get
		{
			if (_oWeaponIndexText7 != null)
			{
				return _oWeaponIndexText7.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString7 != value && _oWeaponIndexText7 != null)
			{
				_oWeaponIndexText7.text = value;
			}
		}
	}

	public string WeaponIndexString8
	{
		get
		{
			if (_oWeaponIndexText8 != null)
			{
				return _oWeaponIndexText8.text;
			}
			return null;
		}
		set
		{
			if (WeaponIndexString8 != value && _oWeaponIndexText8 != null)
			{
				_oWeaponIndexText8.text = value;
			}
		}
	}

	public string WeaponGoldString1
	{
		get
		{
			if (_oWeaponGoldText1 != null)
			{
				return _oWeaponGoldText1.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString1 != value && _oWeaponGoldText1 != null)
			{
				_oWeaponGoldText1.text = value;
			}
		}
	}

	public string WeaponGoldString2
	{
		get
		{
			if (_oWeaponGoldText2 != null)
			{
				return _oWeaponGoldText2.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString2 != value && _oWeaponGoldText2 != null)
			{
				_oWeaponGoldText2.text = value;
			}
		}
	}

	public string WeaponGoldString3
	{
		get
		{
			if (_oWeaponGoldText3 != null)
			{
				return _oWeaponGoldText3.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString3 != value && _oWeaponGoldText3 != null)
			{
				_oWeaponGoldText3.text = value;
			}
		}
	}

	public string WeaponGoldString4
	{
		get
		{
			if (_oWeaponGoldText4 != null)
			{
				return _oWeaponGoldText4.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString4 != value && _oWeaponGoldText4 != null)
			{
				_oWeaponGoldText4.text = value;
			}
		}
	}

	public string WeaponGoldString5
	{
		get
		{
			if (_oWeaponGoldText5 != null)
			{
				return _oWeaponGoldText5.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString5 != value && _oWeaponGoldText5 != null)
			{
				_oWeaponGoldText5.text = value;
			}
		}
	}

	public string WeaponGoldString6
	{
		get
		{
			if (_oWeaponGoldText6 != null)
			{
				return _oWeaponGoldText6.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString6 != value && _oWeaponGoldText6 != null)
			{
				_oWeaponGoldText6.text = value;
			}
		}
	}

	public string WeaponGoldString7
	{
		get
		{
			if (_oWeaponGoldText7 != null)
			{
				return _oWeaponGoldText7.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString7 != value && _oWeaponGoldText7 != null)
			{
				_oWeaponGoldText7.text = value;
			}
		}
	}

	public string WeaponGoldString8
	{
		get
		{
			if (_oWeaponGoldText8 != null)
			{
				return _oWeaponGoldText8.text;
			}
			return null;
		}
		set
		{
			if (WeaponGoldString8 != value && _oWeaponGoldText8 != null)
			{
				_oWeaponGoldText8.text = value;
			}
		}
	}

	public Color WeaponGoldTextcolor1
	{
		get
		{
			if (_oWeaponGoldText1 != null)
			{
				return _oWeaponGoldText1.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor1 != value && _oWeaponGoldText1 != null)
			{
				_oWeaponGoldText1.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor2
	{
		get
		{
			if (_oWeaponGoldText2 != null)
			{
				return _oWeaponGoldText2.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor2 != value && _oWeaponGoldText2 != null)
			{
				_oWeaponGoldText2.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor3
	{
		get
		{
			if (_oWeaponGoldText3 != null)
			{
				return _oWeaponGoldText3.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor3 != value && _oWeaponGoldText3 != null)
			{
				_oWeaponGoldText3.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor4
	{
		get
		{
			if (_oWeaponGoldText4 != null)
			{
				return _oWeaponGoldText4.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor4 != value && _oWeaponGoldText4 != null)
			{
				_oWeaponGoldText4.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor5
	{
		get
		{
			if (_oWeaponGoldText5 != null)
			{
				return _oWeaponGoldText5.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor5 != value && _oWeaponGoldText5 != null)
			{
				_oWeaponGoldText5.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor6
	{
		get
		{
			if (_oWeaponGoldText6 != null)
			{
				return _oWeaponGoldText6.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor6 != value && _oWeaponGoldText6 != null)
			{
				_oWeaponGoldText6.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor7
	{
		get
		{
			if (_oWeaponGoldText7 != null)
			{
				return _oWeaponGoldText7.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor7 != value && _oWeaponGoldText7 != null)
			{
				_oWeaponGoldText7.color = value;
			}
		}
	}

	public Color WeaponGoldTextcolor8
	{
		get
		{
			if (_oWeaponGoldText8 != null)
			{
				return _oWeaponGoldText8.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponGoldTextcolor8 != value && _oWeaponGoldText8 != null)
			{
				_oWeaponGoldText8.color = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText":
				_oMoneyText = transform.gameObject;
				_oMoneyTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "AutoCloseCheck":
				_oAutoCloseCheck = transform.gameObject;
				_oAutoCloseCheckButton = transform.gameObject.GetComponent<Button>();
				break;
			case "AutoCloseCheckOk":
				_oAutoCloseCheckOk = transform.gameObject;
				_oAutoCloseCheckOkButton = transform.gameObject.GetComponent<Button>();
				break;
			case "GiveButton":
				_oGiveButton = transform.gameObject;
				_oGiveButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "OneKeyButton":
				_oOneKeyButton = transform.gameObject;
				_oOneKeyButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectWeaponTypePanel":
				_oSelectWeaponTypePanel = transform.gameObject;
				break;
			case "SelectTypeCloseButton":
				_oSelectTypeCloseButton = transform.gameObject;
				_oSelectTypeCloseButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponTypeSlot1":
				_oWeaponTypeSlot1 = transform.gameObject;
				_oWeaponTypeSlotButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponTypeSlot2":
				_oWeaponTypeSlot2 = transform.gameObject;
				_oWeaponTypeSlotButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponTypeSlot3":
				_oWeaponTypeSlot3 = transform.gameObject;
				_oWeaponTypeSlotButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponTypeSlot4":
				_oWeaponTypeSlot4 = transform.gameObject;
				_oWeaponTypeSlotButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponTypeSlot5":
				_oWeaponTypeSlot5 = transform.gameObject;
				_oWeaponTypeSlotButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "TypeImage1":
				_oTypeImage1 = transform.gameObject;
				_oTypeImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "TypeImage2":
				_oTypeImage2 = transform.gameObject;
				_oTypeImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "TypeImage3":
				_oTypeImage3 = transform.gameObject;
				_oTypeImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "TypeImage4":
				_oTypeImage4 = transform.gameObject;
				_oTypeImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TypeImage5":
				_oTypeImage5 = transform.gameObject;
				_oTypeImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Index1":
				_oIndex1 = transform.gameObject;
				_oIndexText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Index2":
				_oIndex2 = transform.gameObject;
				_oIndexText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Index3":
				_oIndex3 = transform.gameObject;
				_oIndexText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Index4":
				_oIndex4 = transform.gameObject;
				_oIndexText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Index5":
				_oIndex5 = transform.gameObject;
				_oIndexText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "SelectWeaponPanel":
				_oSelectWeaponPanel = transform.gameObject;
				break;
			case "SelectCloseButton":
				_oSelectCloseButton = transform.gameObject;
				_oSelectCloseButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ReturnButton":
				_oReturnButton = transform.gameObject;
				_oReturnButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponSlot1":
				_oWeaponSlot1 = transform.gameObject;
				break;
			case "WeaponSlot2":
				_oWeaponSlot2 = transform.gameObject;
				break;
			case "WeaponSlot3":
				_oWeaponSlot3 = transform.gameObject;
				break;
			case "WeaponSlot4":
				_oWeaponSlot4 = transform.gameObject;
				break;
			case "WeaponSlot5":
				_oWeaponSlot5 = transform.gameObject;
				break;
			case "WeaponSlot6":
				_oWeaponSlot6 = transform.gameObject;
				break;
			case "WeaponSlot7":
				_oWeaponSlot7 = transform.gameObject;
				break;
			case "WeaponSlot8":
				_oWeaponSlot8 = transform.gameObject;
				break;
			case "WeaponCommon1":
				_oWeaponCommon1 = transform.gameObject;
				_oWeaponCommonButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon2":
				_oWeaponCommon2 = transform.gameObject;
				_oWeaponCommonButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon3":
				_oWeaponCommon3 = transform.gameObject;
				_oWeaponCommonButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon4":
				_oWeaponCommon4 = transform.gameObject;
				_oWeaponCommonButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon5":
				_oWeaponCommon5 = transform.gameObject;
				_oWeaponCommonButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon6":
				_oWeaponCommon6 = transform.gameObject;
				_oWeaponCommonButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon7":
				_oWeaponCommon7 = transform.gameObject;
				_oWeaponCommonButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponCommon8":
				_oWeaponCommon8 = transform.gameObject;
				_oWeaponCommonButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky1":
				_oWeaponLucky1 = transform.gameObject;
				_oWeaponLuckyButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky2":
				_oWeaponLucky2 = transform.gameObject;
				_oWeaponLuckyButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky3":
				_oWeaponLucky3 = transform.gameObject;
				_oWeaponLuckyButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky4":
				_oWeaponLucky4 = transform.gameObject;
				_oWeaponLuckyButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky5":
				_oWeaponLucky5 = transform.gameObject;
				_oWeaponLuckyButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky6":
				_oWeaponLucky6 = transform.gameObject;
				_oWeaponLuckyButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky7":
				_oWeaponLucky7 = transform.gameObject;
				_oWeaponLuckyButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponLucky8":
				_oWeaponLucky8 = transform.gameObject;
				_oWeaponLuckyButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponImage1":
				_oWeaponImage1 = transform.gameObject;
				_oWeaponImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage2":
				_oWeaponImage2 = transform.gameObject;
				_oWeaponImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage3":
				_oWeaponImage3 = transform.gameObject;
				_oWeaponImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage4":
				_oWeaponImage4 = transform.gameObject;
				_oWeaponImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage5":
				_oWeaponImage5 = transform.gameObject;
				_oWeaponImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage6":
				_oWeaponImage6 = transform.gameObject;
				_oWeaponImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage7":
				_oWeaponImage7 = transform.gameObject;
				_oWeaponImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage8":
				_oWeaponImage8 = transform.gameObject;
				_oWeaponImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponName1":
				_oWeaponName1 = transform.gameObject;
				_oWeaponNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName2":
				_oWeaponName2 = transform.gameObject;
				_oWeaponNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName3":
				_oWeaponName3 = transform.gameObject;
				_oWeaponNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName4":
				_oWeaponName4 = transform.gameObject;
				_oWeaponNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName5":
				_oWeaponName5 = transform.gameObject;
				_oWeaponNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName6":
				_oWeaponName6 = transform.gameObject;
				_oWeaponNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName7":
				_oWeaponName7 = transform.gameObject;
				_oWeaponNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponName8":
				_oWeaponName8 = transform.gameObject;
				_oWeaponNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex1":
				_oWeaponIndex1 = transform.gameObject;
				_oWeaponIndexText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex2":
				_oWeaponIndex2 = transform.gameObject;
				_oWeaponIndexText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex3":
				_oWeaponIndex3 = transform.gameObject;
				_oWeaponIndexText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex4":
				_oWeaponIndex4 = transform.gameObject;
				_oWeaponIndexText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex5":
				_oWeaponIndex5 = transform.gameObject;
				_oWeaponIndexText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex6":
				_oWeaponIndex6 = transform.gameObject;
				_oWeaponIndexText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex7":
				_oWeaponIndex7 = transform.gameObject;
				_oWeaponIndexText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIndex8":
				_oWeaponIndex8 = transform.gameObject;
				_oWeaponIndexText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold1":
				_oWeaponGold1 = transform.gameObject;
				_oWeaponGoldText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold2":
				_oWeaponGold2 = transform.gameObject;
				_oWeaponGoldText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold3":
				_oWeaponGold3 = transform.gameObject;
				_oWeaponGoldText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold4":
				_oWeaponGold4 = transform.gameObject;
				_oWeaponGoldText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold5":
				_oWeaponGold5 = transform.gameObject;
				_oWeaponGoldText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold6":
				_oWeaponGold6 = transform.gameObject;
				_oWeaponGoldText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold7":
				_oWeaponGold7 = transform.gameObject;
				_oWeaponGoldText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponGold8":
				_oWeaponGold8 = transform.gameObject;
				_oWeaponGoldText8 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public Button.ButtonClickedEvent GetWeaponTypeSlotClicked(int index)
	{
		return index switch
		{
			1 => WeaponTypeSlotClicked1, 
			2 => WeaponTypeSlotClicked2, 
			3 => WeaponTypeSlotClicked3, 
			4 => WeaponTypeSlotClicked4, 
			5 => WeaponTypeSlotClicked5, 
			_ => null, 
		};
	}

	public void SetWeaponTypeSlotClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			WeaponTypeSlotClicked1 = value;
			break;
		case 2:
			WeaponTypeSlotClicked2 = value;
			break;
		case 3:
			WeaponTypeSlotClicked3 = value;
			break;
		case 4:
			WeaponTypeSlotClicked4 = value;
			break;
		case 5:
			WeaponTypeSlotClicked5 = value;
			break;
		}
	}

	public Sprite GetTypeImageSprite(int index)
	{
		return index switch
		{
			1 => TypeImageSprite1, 
			2 => TypeImageSprite2, 
			3 => TypeImageSprite3, 
			4 => TypeImageSprite4, 
			5 => TypeImageSprite5, 
			_ => null, 
		};
	}

	public void SetTypeImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TypeImageSprite1 = value;
			break;
		case 2:
			TypeImageSprite2 = value;
			break;
		case 3:
			TypeImageSprite3 = value;
			break;
		case 4:
			TypeImageSprite4 = value;
			break;
		case 5:
			TypeImageSprite5 = value;
			break;
		}
	}

	public string GetIndexString(int index)
	{
		return index switch
		{
			1 => IndexString1, 
			2 => IndexString2, 
			3 => IndexString3, 
			4 => IndexString4, 
			5 => IndexString5, 
			_ => null, 
		};
	}

	public void SetIndexString(int index, string value)
	{
		switch (index)
		{
		case 1:
			IndexString1 = value;
			break;
		case 2:
			IndexString2 = value;
			break;
		case 3:
			IndexString3 = value;
			break;
		case 4:
			IndexString4 = value;
			break;
		case 5:
			IndexString5 = value;
			break;
		}
	}

	public bool GetWeaponSlotShow(int index)
	{
		return index switch
		{
			1 => WeaponSlotShow1, 
			2 => WeaponSlotShow2, 
			3 => WeaponSlotShow3, 
			4 => WeaponSlotShow4, 
			5 => WeaponSlotShow5, 
			6 => WeaponSlotShow6, 
			7 => WeaponSlotShow7, 
			8 => WeaponSlotShow8, 
			_ => false, 
		};
	}

	public void SetWeaponSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponSlotShow1 = value;
			break;
		case 2:
			WeaponSlotShow2 = value;
			break;
		case 3:
			WeaponSlotShow3 = value;
			break;
		case 4:
			WeaponSlotShow4 = value;
			break;
		case 5:
			WeaponSlotShow5 = value;
			break;
		case 6:
			WeaponSlotShow6 = value;
			break;
		case 7:
			WeaponSlotShow7 = value;
			break;
		case 8:
			WeaponSlotShow8 = value;
			break;
		}
	}

	public bool GetWeaponCommonShow(int index)
	{
		return index switch
		{
			1 => WeaponCommonShow1, 
			2 => WeaponCommonShow2, 
			3 => WeaponCommonShow3, 
			4 => WeaponCommonShow4, 
			5 => WeaponCommonShow5, 
			6 => WeaponCommonShow6, 
			7 => WeaponCommonShow7, 
			8 => WeaponCommonShow8, 
			_ => false, 
		};
	}

	public void SetWeaponCommonShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponCommonShow1 = value;
			break;
		case 2:
			WeaponCommonShow2 = value;
			break;
		case 3:
			WeaponCommonShow3 = value;
			break;
		case 4:
			WeaponCommonShow4 = value;
			break;
		case 5:
			WeaponCommonShow5 = value;
			break;
		case 6:
			WeaponCommonShow6 = value;
			break;
		case 7:
			WeaponCommonShow7 = value;
			break;
		case 8:
			WeaponCommonShow8 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetWeaponCommonClicked(int index)
	{
		return index switch
		{
			1 => WeaponCommonClicked1, 
			2 => WeaponCommonClicked2, 
			3 => WeaponCommonClicked3, 
			4 => WeaponCommonClicked4, 
			5 => WeaponCommonClicked5, 
			6 => WeaponCommonClicked6, 
			7 => WeaponCommonClicked7, 
			8 => WeaponCommonClicked8, 
			_ => null, 
		};
	}

	public void SetWeaponCommonClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			WeaponCommonClicked1 = value;
			break;
		case 2:
			WeaponCommonClicked2 = value;
			break;
		case 3:
			WeaponCommonClicked3 = value;
			break;
		case 4:
			WeaponCommonClicked4 = value;
			break;
		case 5:
			WeaponCommonClicked5 = value;
			break;
		case 6:
			WeaponCommonClicked6 = value;
			break;
		case 7:
			WeaponCommonClicked7 = value;
			break;
		case 8:
			WeaponCommonClicked8 = value;
			break;
		}
	}

	public bool GetWeaponLuckyShow(int index)
	{
		return index switch
		{
			1 => WeaponLuckyShow1, 
			2 => WeaponLuckyShow2, 
			3 => WeaponLuckyShow3, 
			4 => WeaponLuckyShow4, 
			5 => WeaponLuckyShow5, 
			6 => WeaponLuckyShow6, 
			7 => WeaponLuckyShow7, 
			8 => WeaponLuckyShow8, 
			_ => false, 
		};
	}

	public void SetWeaponLuckyShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponLuckyShow1 = value;
			break;
		case 2:
			WeaponLuckyShow2 = value;
			break;
		case 3:
			WeaponLuckyShow3 = value;
			break;
		case 4:
			WeaponLuckyShow4 = value;
			break;
		case 5:
			WeaponLuckyShow5 = value;
			break;
		case 6:
			WeaponLuckyShow6 = value;
			break;
		case 7:
			WeaponLuckyShow7 = value;
			break;
		case 8:
			WeaponLuckyShow8 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetWeaponLuckyClicked(int index)
	{
		return index switch
		{
			1 => WeaponLuckyClicked1, 
			2 => WeaponLuckyClicked2, 
			3 => WeaponLuckyClicked3, 
			4 => WeaponLuckyClicked4, 
			5 => WeaponLuckyClicked5, 
			6 => WeaponLuckyClicked6, 
			7 => WeaponLuckyClicked7, 
			8 => WeaponLuckyClicked8, 
			_ => null, 
		};
	}

	public void SetWeaponLuckyClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			WeaponLuckyClicked1 = value;
			break;
		case 2:
			WeaponLuckyClicked2 = value;
			break;
		case 3:
			WeaponLuckyClicked3 = value;
			break;
		case 4:
			WeaponLuckyClicked4 = value;
			break;
		case 5:
			WeaponLuckyClicked5 = value;
			break;
		case 6:
			WeaponLuckyClicked6 = value;
			break;
		case 7:
			WeaponLuckyClicked7 = value;
			break;
		case 8:
			WeaponLuckyClicked8 = value;
			break;
		}
	}

	public bool GetWeaponImageShow(int index)
	{
		return index switch
		{
			1 => WeaponImageShow1, 
			2 => WeaponImageShow2, 
			3 => WeaponImageShow3, 
			4 => WeaponImageShow4, 
			5 => WeaponImageShow5, 
			6 => WeaponImageShow6, 
			7 => WeaponImageShow7, 
			8 => WeaponImageShow8, 
			_ => false, 
		};
	}

	public void SetWeaponImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponImageShow1 = value;
			break;
		case 2:
			WeaponImageShow2 = value;
			break;
		case 3:
			WeaponImageShow3 = value;
			break;
		case 4:
			WeaponImageShow4 = value;
			break;
		case 5:
			WeaponImageShow5 = value;
			break;
		case 6:
			WeaponImageShow6 = value;
			break;
		case 7:
			WeaponImageShow7 = value;
			break;
		case 8:
			WeaponImageShow8 = value;
			break;
		}
	}

	public Sprite GetWeaponImageSprite(int index)
	{
		return index switch
		{
			1 => WeaponImageSprite1, 
			2 => WeaponImageSprite2, 
			3 => WeaponImageSprite3, 
			4 => WeaponImageSprite4, 
			5 => WeaponImageSprite5, 
			6 => WeaponImageSprite6, 
			7 => WeaponImageSprite7, 
			8 => WeaponImageSprite8, 
			_ => null, 
		};
	}

	public void SetWeaponImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponImageSprite1 = value;
			break;
		case 2:
			WeaponImageSprite2 = value;
			break;
		case 3:
			WeaponImageSprite3 = value;
			break;
		case 4:
			WeaponImageSprite4 = value;
			break;
		case 5:
			WeaponImageSprite5 = value;
			break;
		case 6:
			WeaponImageSprite6 = value;
			break;
		case 7:
			WeaponImageSprite7 = value;
			break;
		case 8:
			WeaponImageSprite8 = value;
			break;
		}
	}

	public string GetWeaponNameString(int index)
	{
		return index switch
		{
			1 => WeaponNameString1, 
			2 => WeaponNameString2, 
			3 => WeaponNameString3, 
			4 => WeaponNameString4, 
			5 => WeaponNameString5, 
			6 => WeaponNameString6, 
			7 => WeaponNameString7, 
			8 => WeaponNameString8, 
			_ => null, 
		};
	}

	public void SetWeaponNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			WeaponNameString1 = value;
			break;
		case 2:
			WeaponNameString2 = value;
			break;
		case 3:
			WeaponNameString3 = value;
			break;
		case 4:
			WeaponNameString4 = value;
			break;
		case 5:
			WeaponNameString5 = value;
			break;
		case 6:
			WeaponNameString6 = value;
			break;
		case 7:
			WeaponNameString7 = value;
			break;
		case 8:
			WeaponNameString8 = value;
			break;
		}
	}

	public string GetWeaponIndexString(int index)
	{
		return index switch
		{
			1 => WeaponIndexString1, 
			2 => WeaponIndexString2, 
			3 => WeaponIndexString3, 
			4 => WeaponIndexString4, 
			5 => WeaponIndexString5, 
			6 => WeaponIndexString6, 
			7 => WeaponIndexString7, 
			8 => WeaponIndexString8, 
			_ => null, 
		};
	}

	public void SetWeaponIndexString(int index, string value)
	{
		switch (index)
		{
		case 1:
			WeaponIndexString1 = value;
			break;
		case 2:
			WeaponIndexString2 = value;
			break;
		case 3:
			WeaponIndexString3 = value;
			break;
		case 4:
			WeaponIndexString4 = value;
			break;
		case 5:
			WeaponIndexString5 = value;
			break;
		case 6:
			WeaponIndexString6 = value;
			break;
		case 7:
			WeaponIndexString7 = value;
			break;
		case 8:
			WeaponIndexString8 = value;
			break;
		}
	}

	public string GetWeaponGoldString(int index)
	{
		return index switch
		{
			1 => WeaponGoldString1, 
			2 => WeaponGoldString2, 
			3 => WeaponGoldString3, 
			4 => WeaponGoldString4, 
			5 => WeaponGoldString5, 
			6 => WeaponGoldString6, 
			7 => WeaponGoldString7, 
			8 => WeaponGoldString8, 
			_ => null, 
		};
	}

	public void SetWeaponGoldString(int index, string value)
	{
		switch (index)
		{
		case 1:
			WeaponGoldString1 = value;
			break;
		case 2:
			WeaponGoldString2 = value;
			break;
		case 3:
			WeaponGoldString3 = value;
			break;
		case 4:
			WeaponGoldString4 = value;
			break;
		case 5:
			WeaponGoldString5 = value;
			break;
		case 6:
			WeaponGoldString6 = value;
			break;
		case 7:
			WeaponGoldString7 = value;
			break;
		case 8:
			WeaponGoldString8 = value;
			break;
		}
	}

	public Color GetWeaponGoldTextcolor(int index)
	{
		return index switch
		{
			1 => WeaponGoldTextcolor1, 
			2 => WeaponGoldTextcolor2, 
			3 => WeaponGoldTextcolor3, 
			4 => WeaponGoldTextcolor4, 
			5 => WeaponGoldTextcolor5, 
			6 => WeaponGoldTextcolor6, 
			7 => WeaponGoldTextcolor7, 
			8 => WeaponGoldTextcolor8, 
			_ => Color.white, 
		};
	}

	public void SetWeaponGoldTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			WeaponGoldTextcolor1 = value;
			break;
		case 2:
			WeaponGoldTextcolor2 = value;
			break;
		case 3:
			WeaponGoldTextcolor3 = value;
			break;
		case 4:
			WeaponGoldTextcolor4 = value;
			break;
		case 5:
			WeaponGoldTextcolor5 = value;
			break;
		case 6:
			WeaponGoldTextcolor6 = value;
			break;
		case 7:
			WeaponGoldTextcolor7 = value;
			break;
		case 8:
			WeaponGoldTextcolor8 = value;
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
