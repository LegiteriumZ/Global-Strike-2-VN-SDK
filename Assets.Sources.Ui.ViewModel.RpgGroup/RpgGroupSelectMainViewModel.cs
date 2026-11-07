using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.RpgGroup;

[GameUiTest]
public class RpgGroupSelectMainViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oCell1;

	private GameObject _oCell2;

	private GameObject _oCell3;

	private GameObject _oCell4;

	private GameObject _oCell5;

	private GameObject _oCell6;

	private GameObject _oCell7;

	private GameObject _oCell8;

	private Button _oCellButton1;

	private Button _oCellButton2;

	private Button _oCellButton3;

	private Button _oCellButton4;

	private Button _oCellButton5;

	private Button _oCellButton6;

	private Button _oCellButton7;

	private Button _oCellButton8;

	private GameObject _oCellIcon1;

	private GameObject _oCellIcon2;

	private GameObject _oCellIcon3;

	private GameObject _oCellIcon4;

	private GameObject _oCellIcon5;

	private GameObject _oCellIcon6;

	private GameObject _oCellIcon7;

	private GameObject _oCellIcon8;

	private Image _oCellIconImage1;

	private Image _oCellIconImage2;

	private Image _oCellIconImage3;

	private Image _oCellIconImage4;

	private Image _oCellIconImage5;

	private Image _oCellIconImage6;

	private Image _oCellIconImage7;

	private Image _oCellIconImage8;

	private GameObject _oCellIndex1;

	private GameObject _oCellIndex2;

	private GameObject _oCellIndex3;

	private GameObject _oCellIndex4;

	private GameObject _oCellIndex5;

	private GameObject _oCellIndex6;

	private GameObject _oCellIndex7;

	private GameObject _oCellIndex8;

	private Text _oCellIndexText1;

	private Text _oCellIndexText2;

	private Text _oCellIndexText3;

	private Text _oCellIndexText4;

	private Text _oCellIndexText5;

	private Text _oCellIndexText6;

	private Text _oCellIndexText7;

	private Text _oCellIndexText8;

	private GameObject _oCellName1;

	private GameObject _oCellName2;

	private GameObject _oCellName3;

	private GameObject _oCellName4;

	private GameObject _oCellName5;

	private GameObject _oCellName6;

	private GameObject _oCellName7;

	private GameObject _oCellName8;

	private Text _oCellNameText1;

	private Text _oCellNameText2;

	private Text _oCellNameText3;

	private Text _oCellNameText4;

	private Text _oCellNameText5;

	private Text _oCellNameText6;

	private Text _oCellNameText7;

	private Text _oCellNameText8;

	private GameObject _oCellMoney1;

	private GameObject _oCellMoney2;

	private GameObject _oCellMoney3;

	private GameObject _oCellMoney4;

	private GameObject _oCellMoney5;

	private GameObject _oCellMoney6;

	private GameObject _oCellMoney7;

	private GameObject _oCellMoney8;

	private Text _oCellMoneyText1;

	private Text _oCellMoneyText2;

	private Text _oCellMoneyText3;

	private Text _oCellMoneyText4;

	private Text _oCellMoneyText5;

	private Text _oCellMoneyText6;

	private Text _oCellMoneyText7;

	private Text _oCellMoneyText8;

	private GameObject _oCellLock1;

	private GameObject _oCellLock2;

	private GameObject _oCellLock3;

	private GameObject _oCellLock4;

	private GameObject _oCellLock5;

	private GameObject _oCellLock6;

	private GameObject _oCellLock7;

	private GameObject _oCellLock8;

	private GameObject _oCellMinute1;

	private GameObject _oCellMinute2;

	private GameObject _oCellMinute3;

	private GameObject _oCellMinute4;

	private GameObject _oCellMinute5;

	private GameObject _oCellMinute6;

	private GameObject _oCellMinute7;

	private GameObject _oCellMinute8;

	private Text _oCellMinuteText1;

	private Text _oCellMinuteText2;

	private Text _oCellMinuteText3;

	private Text _oCellMinuteText4;

	private Text _oCellMinuteText5;

	private Text _oCellMinuteText6;

	private Text _oCellMinuteText7;

	private Text _oCellMinuteText8;

	private GameObject _oCellSecond1;

	private GameObject _oCellSecond2;

	private GameObject _oCellSecond3;

	private GameObject _oCellSecond4;

	private GameObject _oCellSecond5;

	private GameObject _oCellSecond6;

	private GameObject _oCellSecond7;

	private GameObject _oCellSecond8;

	private Text _oCellSecondText1;

	private Text _oCellSecondText2;

	private Text _oCellSecondText3;

	private Text _oCellSecondText4;

	private Text _oCellSecondText5;

	private Text _oCellSecondText6;

	private Text _oCellSecondText7;

	private Text _oCellSecondText8;

	private GameObject _oCloseBtn;

	private Button _oCloseBtnButton;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpggroup";

	private string _resourceAssetName = "RpgGroupSelectMain";

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

	public bool CellShow1
	{
		get
		{
			if (_oCell1 != null)
			{
				return _oCell1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow1 != value && _oCell1 != null)
			{
				_oCell1.SetObjectActive(value);
			}
		}
	}

	public bool CellShow2
	{
		get
		{
			if (_oCell2 != null)
			{
				return _oCell2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow2 != value && _oCell2 != null)
			{
				_oCell2.SetObjectActive(value);
			}
		}
	}

	public bool CellShow3
	{
		get
		{
			if (_oCell3 != null)
			{
				return _oCell3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow3 != value && _oCell3 != null)
			{
				_oCell3.SetObjectActive(value);
			}
		}
	}

	public bool CellShow4
	{
		get
		{
			if (_oCell4 != null)
			{
				return _oCell4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow4 != value && _oCell4 != null)
			{
				_oCell4.SetObjectActive(value);
			}
		}
	}

	public bool CellShow5
	{
		get
		{
			if (_oCell5 != null)
			{
				return _oCell5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow5 != value && _oCell5 != null)
			{
				_oCell5.SetObjectActive(value);
			}
		}
	}

	public bool CellShow6
	{
		get
		{
			if (_oCell6 != null)
			{
				return _oCell6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow6 != value && _oCell6 != null)
			{
				_oCell6.SetObjectActive(value);
			}
		}
	}

	public bool CellShow7
	{
		get
		{
			if (_oCell7 != null)
			{
				return _oCell7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow7 != value && _oCell7 != null)
			{
				_oCell7.SetObjectActive(value);
			}
		}
	}

	public bool CellShow8
	{
		get
		{
			if (_oCell8 != null)
			{
				return _oCell8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow8 != value && _oCell8 != null)
			{
				_oCell8.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked1
	{
		get
		{
			if (_oCellButton1 != null)
			{
				return _oCellButton1.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked1 != value && _oCellButton1 != null)
			{
				_oCellButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked2
	{
		get
		{
			if (_oCellButton2 != null)
			{
				return _oCellButton2.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked2 != value && _oCellButton2 != null)
			{
				_oCellButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked3
	{
		get
		{
			if (_oCellButton3 != null)
			{
				return _oCellButton3.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked3 != value && _oCellButton3 != null)
			{
				_oCellButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked4
	{
		get
		{
			if (_oCellButton4 != null)
			{
				return _oCellButton4.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked4 != value && _oCellButton4 != null)
			{
				_oCellButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked5
	{
		get
		{
			if (_oCellButton5 != null)
			{
				return _oCellButton5.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked5 != value && _oCellButton5 != null)
			{
				_oCellButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked6
	{
		get
		{
			if (_oCellButton6 != null)
			{
				return _oCellButton6.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked6 != value && _oCellButton6 != null)
			{
				_oCellButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked7
	{
		get
		{
			if (_oCellButton7 != null)
			{
				return _oCellButton7.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked7 != value && _oCellButton7 != null)
			{
				_oCellButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CellClicked8
	{
		get
		{
			if (_oCellButton8 != null)
			{
				return _oCellButton8.onClick;
			}
			return null;
		}
		set
		{
			if (CellClicked8 != value && _oCellButton8 != null)
			{
				_oCellButton8.onClick = value;
			}
		}
	}

	public Sprite CellIconSprite1
	{
		get
		{
			if (_oCellIconImage1 != null)
			{
				return _oCellIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite1 != value && _oCellIconImage1 != null)
			{
				_oCellIconImage1.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite2
	{
		get
		{
			if (_oCellIconImage2 != null)
			{
				return _oCellIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite2 != value && _oCellIconImage2 != null)
			{
				_oCellIconImage2.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite3
	{
		get
		{
			if (_oCellIconImage3 != null)
			{
				return _oCellIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite3 != value && _oCellIconImage3 != null)
			{
				_oCellIconImage3.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite4
	{
		get
		{
			if (_oCellIconImage4 != null)
			{
				return _oCellIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite4 != value && _oCellIconImage4 != null)
			{
				_oCellIconImage4.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite5
	{
		get
		{
			if (_oCellIconImage5 != null)
			{
				return _oCellIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite5 != value && _oCellIconImage5 != null)
			{
				_oCellIconImage5.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite6
	{
		get
		{
			if (_oCellIconImage6 != null)
			{
				return _oCellIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite6 != value && _oCellIconImage6 != null)
			{
				_oCellIconImage6.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite7
	{
		get
		{
			if (_oCellIconImage7 != null)
			{
				return _oCellIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite7 != value && _oCellIconImage7 != null)
			{
				_oCellIconImage7.sprite = value;
			}
		}
	}

	public Sprite CellIconSprite8
	{
		get
		{
			if (_oCellIconImage8 != null)
			{
				return _oCellIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (CellIconSprite8 != value && _oCellIconImage8 != null)
			{
				_oCellIconImage8.sprite = value;
			}
		}
	}

	public string CellIndexString1
	{
		get
		{
			if (_oCellIndexText1 != null)
			{
				return _oCellIndexText1.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString1 != value && _oCellIndexText1 != null)
			{
				_oCellIndexText1.text = value;
			}
		}
	}

	public string CellIndexString2
	{
		get
		{
			if (_oCellIndexText2 != null)
			{
				return _oCellIndexText2.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString2 != value && _oCellIndexText2 != null)
			{
				_oCellIndexText2.text = value;
			}
		}
	}

	public string CellIndexString3
	{
		get
		{
			if (_oCellIndexText3 != null)
			{
				return _oCellIndexText3.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString3 != value && _oCellIndexText3 != null)
			{
				_oCellIndexText3.text = value;
			}
		}
	}

	public string CellIndexString4
	{
		get
		{
			if (_oCellIndexText4 != null)
			{
				return _oCellIndexText4.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString4 != value && _oCellIndexText4 != null)
			{
				_oCellIndexText4.text = value;
			}
		}
	}

	public string CellIndexString5
	{
		get
		{
			if (_oCellIndexText5 != null)
			{
				return _oCellIndexText5.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString5 != value && _oCellIndexText5 != null)
			{
				_oCellIndexText5.text = value;
			}
		}
	}

	public string CellIndexString6
	{
		get
		{
			if (_oCellIndexText6 != null)
			{
				return _oCellIndexText6.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString6 != value && _oCellIndexText6 != null)
			{
				_oCellIndexText6.text = value;
			}
		}
	}

	public string CellIndexString7
	{
		get
		{
			if (_oCellIndexText7 != null)
			{
				return _oCellIndexText7.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString7 != value && _oCellIndexText7 != null)
			{
				_oCellIndexText7.text = value;
			}
		}
	}

	public string CellIndexString8
	{
		get
		{
			if (_oCellIndexText8 != null)
			{
				return _oCellIndexText8.text;
			}
			return null;
		}
		set
		{
			if (CellIndexString8 != value && _oCellIndexText8 != null)
			{
				_oCellIndexText8.text = value;
			}
		}
	}

	public string CellNameString1
	{
		get
		{
			if (_oCellNameText1 != null)
			{
				return _oCellNameText1.text;
			}
			return null;
		}
		set
		{
			if (CellNameString1 != value && _oCellNameText1 != null)
			{
				_oCellNameText1.text = value;
			}
		}
	}

	public string CellNameString2
	{
		get
		{
			if (_oCellNameText2 != null)
			{
				return _oCellNameText2.text;
			}
			return null;
		}
		set
		{
			if (CellNameString2 != value && _oCellNameText2 != null)
			{
				_oCellNameText2.text = value;
			}
		}
	}

	public string CellNameString3
	{
		get
		{
			if (_oCellNameText3 != null)
			{
				return _oCellNameText3.text;
			}
			return null;
		}
		set
		{
			if (CellNameString3 != value && _oCellNameText3 != null)
			{
				_oCellNameText3.text = value;
			}
		}
	}

	public string CellNameString4
	{
		get
		{
			if (_oCellNameText4 != null)
			{
				return _oCellNameText4.text;
			}
			return null;
		}
		set
		{
			if (CellNameString4 != value && _oCellNameText4 != null)
			{
				_oCellNameText4.text = value;
			}
		}
	}

	public string CellNameString5
	{
		get
		{
			if (_oCellNameText5 != null)
			{
				return _oCellNameText5.text;
			}
			return null;
		}
		set
		{
			if (CellNameString5 != value && _oCellNameText5 != null)
			{
				_oCellNameText5.text = value;
			}
		}
	}

	public string CellNameString6
	{
		get
		{
			if (_oCellNameText6 != null)
			{
				return _oCellNameText6.text;
			}
			return null;
		}
		set
		{
			if (CellNameString6 != value && _oCellNameText6 != null)
			{
				_oCellNameText6.text = value;
			}
		}
	}

	public string CellNameString7
	{
		get
		{
			if (_oCellNameText7 != null)
			{
				return _oCellNameText7.text;
			}
			return null;
		}
		set
		{
			if (CellNameString7 != value && _oCellNameText7 != null)
			{
				_oCellNameText7.text = value;
			}
		}
	}

	public string CellNameString8
	{
		get
		{
			if (_oCellNameText8 != null)
			{
				return _oCellNameText8.text;
			}
			return null;
		}
		set
		{
			if (CellNameString8 != value && _oCellNameText8 != null)
			{
				_oCellNameText8.text = value;
			}
		}
	}

	public string CellMoneyString1
	{
		get
		{
			if (_oCellMoneyText1 != null)
			{
				return _oCellMoneyText1.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString1 != value && _oCellMoneyText1 != null)
			{
				_oCellMoneyText1.text = value;
			}
		}
	}

	public string CellMoneyString2
	{
		get
		{
			if (_oCellMoneyText2 != null)
			{
				return _oCellMoneyText2.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString2 != value && _oCellMoneyText2 != null)
			{
				_oCellMoneyText2.text = value;
			}
		}
	}

	public string CellMoneyString3
	{
		get
		{
			if (_oCellMoneyText3 != null)
			{
				return _oCellMoneyText3.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString3 != value && _oCellMoneyText3 != null)
			{
				_oCellMoneyText3.text = value;
			}
		}
	}

	public string CellMoneyString4
	{
		get
		{
			if (_oCellMoneyText4 != null)
			{
				return _oCellMoneyText4.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString4 != value && _oCellMoneyText4 != null)
			{
				_oCellMoneyText4.text = value;
			}
		}
	}

	public string CellMoneyString5
	{
		get
		{
			if (_oCellMoneyText5 != null)
			{
				return _oCellMoneyText5.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString5 != value && _oCellMoneyText5 != null)
			{
				_oCellMoneyText5.text = value;
			}
		}
	}

	public string CellMoneyString6
	{
		get
		{
			if (_oCellMoneyText6 != null)
			{
				return _oCellMoneyText6.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString6 != value && _oCellMoneyText6 != null)
			{
				_oCellMoneyText6.text = value;
			}
		}
	}

	public string CellMoneyString7
	{
		get
		{
			if (_oCellMoneyText7 != null)
			{
				return _oCellMoneyText7.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString7 != value && _oCellMoneyText7 != null)
			{
				_oCellMoneyText7.text = value;
			}
		}
	}

	public string CellMoneyString8
	{
		get
		{
			if (_oCellMoneyText8 != null)
			{
				return _oCellMoneyText8.text;
			}
			return null;
		}
		set
		{
			if (CellMoneyString8 != value && _oCellMoneyText8 != null)
			{
				_oCellMoneyText8.text = value;
			}
		}
	}

	public bool CellLockShow1
	{
		get
		{
			if (_oCellLock1 != null)
			{
				return _oCellLock1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow1 != value && _oCellLock1 != null)
			{
				_oCellLock1.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow2
	{
		get
		{
			if (_oCellLock2 != null)
			{
				return _oCellLock2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow2 != value && _oCellLock2 != null)
			{
				_oCellLock2.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow3
	{
		get
		{
			if (_oCellLock3 != null)
			{
				return _oCellLock3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow3 != value && _oCellLock3 != null)
			{
				_oCellLock3.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow4
	{
		get
		{
			if (_oCellLock4 != null)
			{
				return _oCellLock4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow4 != value && _oCellLock4 != null)
			{
				_oCellLock4.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow5
	{
		get
		{
			if (_oCellLock5 != null)
			{
				return _oCellLock5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow5 != value && _oCellLock5 != null)
			{
				_oCellLock5.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow6
	{
		get
		{
			if (_oCellLock6 != null)
			{
				return _oCellLock6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow6 != value && _oCellLock6 != null)
			{
				_oCellLock6.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow7
	{
		get
		{
			if (_oCellLock7 != null)
			{
				return _oCellLock7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow7 != value && _oCellLock7 != null)
			{
				_oCellLock7.SetObjectActive(value);
			}
		}
	}

	public bool CellLockShow8
	{
		get
		{
			if (_oCellLock8 != null)
			{
				return _oCellLock8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellLockShow8 != value && _oCellLock8 != null)
			{
				_oCellLock8.SetObjectActive(value);
			}
		}
	}

	public string CellMinuteString1
	{
		get
		{
			if (_oCellMinuteText1 != null)
			{
				return _oCellMinuteText1.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString1 != value && _oCellMinuteText1 != null)
			{
				_oCellMinuteText1.text = value;
			}
		}
	}

	public string CellMinuteString2
	{
		get
		{
			if (_oCellMinuteText2 != null)
			{
				return _oCellMinuteText2.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString2 != value && _oCellMinuteText2 != null)
			{
				_oCellMinuteText2.text = value;
			}
		}
	}

	public string CellMinuteString3
	{
		get
		{
			if (_oCellMinuteText3 != null)
			{
				return _oCellMinuteText3.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString3 != value && _oCellMinuteText3 != null)
			{
				_oCellMinuteText3.text = value;
			}
		}
	}

	public string CellMinuteString4
	{
		get
		{
			if (_oCellMinuteText4 != null)
			{
				return _oCellMinuteText4.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString4 != value && _oCellMinuteText4 != null)
			{
				_oCellMinuteText4.text = value;
			}
		}
	}

	public string CellMinuteString5
	{
		get
		{
			if (_oCellMinuteText5 != null)
			{
				return _oCellMinuteText5.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString5 != value && _oCellMinuteText5 != null)
			{
				_oCellMinuteText5.text = value;
			}
		}
	}

	public string CellMinuteString6
	{
		get
		{
			if (_oCellMinuteText6 != null)
			{
				return _oCellMinuteText6.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString6 != value && _oCellMinuteText6 != null)
			{
				_oCellMinuteText6.text = value;
			}
		}
	}

	public string CellMinuteString7
	{
		get
		{
			if (_oCellMinuteText7 != null)
			{
				return _oCellMinuteText7.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString7 != value && _oCellMinuteText7 != null)
			{
				_oCellMinuteText7.text = value;
			}
		}
	}

	public string CellMinuteString8
	{
		get
		{
			if (_oCellMinuteText8 != null)
			{
				return _oCellMinuteText8.text;
			}
			return null;
		}
		set
		{
			if (CellMinuteString8 != value && _oCellMinuteText8 != null)
			{
				_oCellMinuteText8.text = value;
			}
		}
	}

	public string CellSecondString1
	{
		get
		{
			if (_oCellSecondText1 != null)
			{
				return _oCellSecondText1.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString1 != value && _oCellSecondText1 != null)
			{
				_oCellSecondText1.text = value;
			}
		}
	}

	public string CellSecondString2
	{
		get
		{
			if (_oCellSecondText2 != null)
			{
				return _oCellSecondText2.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString2 != value && _oCellSecondText2 != null)
			{
				_oCellSecondText2.text = value;
			}
		}
	}

	public string CellSecondString3
	{
		get
		{
			if (_oCellSecondText3 != null)
			{
				return _oCellSecondText3.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString3 != value && _oCellSecondText3 != null)
			{
				_oCellSecondText3.text = value;
			}
		}
	}

	public string CellSecondString4
	{
		get
		{
			if (_oCellSecondText4 != null)
			{
				return _oCellSecondText4.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString4 != value && _oCellSecondText4 != null)
			{
				_oCellSecondText4.text = value;
			}
		}
	}

	public string CellSecondString5
	{
		get
		{
			if (_oCellSecondText5 != null)
			{
				return _oCellSecondText5.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString5 != value && _oCellSecondText5 != null)
			{
				_oCellSecondText5.text = value;
			}
		}
	}

	public string CellSecondString6
	{
		get
		{
			if (_oCellSecondText6 != null)
			{
				return _oCellSecondText6.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString6 != value && _oCellSecondText6 != null)
			{
				_oCellSecondText6.text = value;
			}
		}
	}

	public string CellSecondString7
	{
		get
		{
			if (_oCellSecondText7 != null)
			{
				return _oCellSecondText7.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString7 != value && _oCellSecondText7 != null)
			{
				_oCellSecondText7.text = value;
			}
		}
	}

	public string CellSecondString8
	{
		get
		{
			if (_oCellSecondText8 != null)
			{
				return _oCellSecondText8.text;
			}
			return null;
		}
		set
		{
			if (CellSecondString8 != value && _oCellSecondText8 != null)
			{
				_oCellSecondText8.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent CloseBtnClicked
	{
		get
		{
			if (_oCloseBtnButton != null)
			{
				return _oCloseBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (CloseBtnClicked != value && _oCloseBtnButton != null)
			{
				_oCloseBtnButton.onClick = value;
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
			case "Cell1":
				_oCell1 = transform.gameObject;
				_oCellButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell2":
				_oCell2 = transform.gameObject;
				_oCellButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell3":
				_oCell3 = transform.gameObject;
				_oCellButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell4":
				_oCell4 = transform.gameObject;
				_oCellButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell5":
				_oCell5 = transform.gameObject;
				_oCellButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell6":
				_oCell6 = transform.gameObject;
				_oCellButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell7":
				_oCell7 = transform.gameObject;
				_oCellButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "Cell8":
				_oCell8 = transform.gameObject;
				_oCellButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "CellIcon1":
				_oCellIcon1 = transform.gameObject;
				_oCellIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon2":
				_oCellIcon2 = transform.gameObject;
				_oCellIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon3":
				_oCellIcon3 = transform.gameObject;
				_oCellIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon4":
				_oCellIcon4 = transform.gameObject;
				_oCellIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon5":
				_oCellIcon5 = transform.gameObject;
				_oCellIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon6":
				_oCellIcon6 = transform.gameObject;
				_oCellIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon7":
				_oCellIcon7 = transform.gameObject;
				_oCellIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIcon8":
				_oCellIcon8 = transform.gameObject;
				_oCellIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "CellIndex1":
				_oCellIndex1 = transform.gameObject;
				_oCellIndexText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex2":
				_oCellIndex2 = transform.gameObject;
				_oCellIndexText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex3":
				_oCellIndex3 = transform.gameObject;
				_oCellIndexText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex4":
				_oCellIndex4 = transform.gameObject;
				_oCellIndexText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex5":
				_oCellIndex5 = transform.gameObject;
				_oCellIndexText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex6":
				_oCellIndex6 = transform.gameObject;
				_oCellIndexText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex7":
				_oCellIndex7 = transform.gameObject;
				_oCellIndexText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellIndex8":
				_oCellIndex8 = transform.gameObject;
				_oCellIndexText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName1":
				_oCellName1 = transform.gameObject;
				_oCellNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName2":
				_oCellName2 = transform.gameObject;
				_oCellNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName3":
				_oCellName3 = transform.gameObject;
				_oCellNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName4":
				_oCellName4 = transform.gameObject;
				_oCellNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName5":
				_oCellName5 = transform.gameObject;
				_oCellNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName6":
				_oCellName6 = transform.gameObject;
				_oCellNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName7":
				_oCellName7 = transform.gameObject;
				_oCellNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellName8":
				_oCellName8 = transform.gameObject;
				_oCellNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney1":
				_oCellMoney1 = transform.gameObject;
				_oCellMoneyText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney2":
				_oCellMoney2 = transform.gameObject;
				_oCellMoneyText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney3":
				_oCellMoney3 = transform.gameObject;
				_oCellMoneyText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney4":
				_oCellMoney4 = transform.gameObject;
				_oCellMoneyText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney5":
				_oCellMoney5 = transform.gameObject;
				_oCellMoneyText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney6":
				_oCellMoney6 = transform.gameObject;
				_oCellMoneyText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney7":
				_oCellMoney7 = transform.gameObject;
				_oCellMoneyText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMoney8":
				_oCellMoney8 = transform.gameObject;
				_oCellMoneyText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellLock1":
				_oCellLock1 = transform.gameObject;
				break;
			case "CellLock2":
				_oCellLock2 = transform.gameObject;
				break;
			case "CellLock3":
				_oCellLock3 = transform.gameObject;
				break;
			case "CellLock4":
				_oCellLock4 = transform.gameObject;
				break;
			case "CellLock5":
				_oCellLock5 = transform.gameObject;
				break;
			case "CellLock6":
				_oCellLock6 = transform.gameObject;
				break;
			case "CellLock7":
				_oCellLock7 = transform.gameObject;
				break;
			case "CellLock8":
				_oCellLock8 = transform.gameObject;
				break;
			case "CellMinute1":
				_oCellMinute1 = transform.gameObject;
				_oCellMinuteText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute2":
				_oCellMinute2 = transform.gameObject;
				_oCellMinuteText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute3":
				_oCellMinute3 = transform.gameObject;
				_oCellMinuteText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute4":
				_oCellMinute4 = transform.gameObject;
				_oCellMinuteText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute5":
				_oCellMinute5 = transform.gameObject;
				_oCellMinuteText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute6":
				_oCellMinute6 = transform.gameObject;
				_oCellMinuteText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute7":
				_oCellMinute7 = transform.gameObject;
				_oCellMinuteText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellMinute8":
				_oCellMinute8 = transform.gameObject;
				_oCellMinuteText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond1":
				_oCellSecond1 = transform.gameObject;
				_oCellSecondText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond2":
				_oCellSecond2 = transform.gameObject;
				_oCellSecondText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond3":
				_oCellSecond3 = transform.gameObject;
				_oCellSecondText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond4":
				_oCellSecond4 = transform.gameObject;
				_oCellSecondText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond5":
				_oCellSecond5 = transform.gameObject;
				_oCellSecondText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond6":
				_oCellSecond6 = transform.gameObject;
				_oCellSecondText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond7":
				_oCellSecond7 = transform.gameObject;
				_oCellSecondText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CellSecond8":
				_oCellSecond8 = transform.gameObject;
				_oCellSecondText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CloseBtn":
				_oCloseBtn = transform.gameObject;
				_oCloseBtnButton = transform.gameObject.GetComponent<Button>();
				break;
			}
		}
	}

	public bool GetCellShow(int index)
	{
		return index switch
		{
			1 => CellShow1, 
			2 => CellShow2, 
			3 => CellShow3, 
			4 => CellShow4, 
			5 => CellShow5, 
			6 => CellShow6, 
			7 => CellShow7, 
			8 => CellShow8, 
			_ => false, 
		};
	}

	public void SetCellShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CellShow1 = value;
			break;
		case 2:
			CellShow2 = value;
			break;
		case 3:
			CellShow3 = value;
			break;
		case 4:
			CellShow4 = value;
			break;
		case 5:
			CellShow5 = value;
			break;
		case 6:
			CellShow6 = value;
			break;
		case 7:
			CellShow7 = value;
			break;
		case 8:
			CellShow8 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetCellClicked(int index)
	{
		return index switch
		{
			1 => CellClicked1, 
			2 => CellClicked2, 
			3 => CellClicked3, 
			4 => CellClicked4, 
			5 => CellClicked5, 
			6 => CellClicked6, 
			7 => CellClicked7, 
			8 => CellClicked8, 
			_ => null, 
		};
	}

	public void SetCellClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			CellClicked1 = value;
			break;
		case 2:
			CellClicked2 = value;
			break;
		case 3:
			CellClicked3 = value;
			break;
		case 4:
			CellClicked4 = value;
			break;
		case 5:
			CellClicked5 = value;
			break;
		case 6:
			CellClicked6 = value;
			break;
		case 7:
			CellClicked7 = value;
			break;
		case 8:
			CellClicked8 = value;
			break;
		}
	}

	public Sprite GetCellIconSprite(int index)
	{
		return index switch
		{
			1 => CellIconSprite1, 
			2 => CellIconSprite2, 
			3 => CellIconSprite3, 
			4 => CellIconSprite4, 
			5 => CellIconSprite5, 
			6 => CellIconSprite6, 
			7 => CellIconSprite7, 
			8 => CellIconSprite8, 
			_ => null, 
		};
	}

	public void SetCellIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			CellIconSprite1 = value;
			break;
		case 2:
			CellIconSprite2 = value;
			break;
		case 3:
			CellIconSprite3 = value;
			break;
		case 4:
			CellIconSprite4 = value;
			break;
		case 5:
			CellIconSprite5 = value;
			break;
		case 6:
			CellIconSprite6 = value;
			break;
		case 7:
			CellIconSprite7 = value;
			break;
		case 8:
			CellIconSprite8 = value;
			break;
		}
	}

	public string GetCellIndexString(int index)
	{
		return index switch
		{
			1 => CellIndexString1, 
			2 => CellIndexString2, 
			3 => CellIndexString3, 
			4 => CellIndexString4, 
			5 => CellIndexString5, 
			6 => CellIndexString6, 
			7 => CellIndexString7, 
			8 => CellIndexString8, 
			_ => null, 
		};
	}

	public void SetCellIndexString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CellIndexString1 = value;
			break;
		case 2:
			CellIndexString2 = value;
			break;
		case 3:
			CellIndexString3 = value;
			break;
		case 4:
			CellIndexString4 = value;
			break;
		case 5:
			CellIndexString5 = value;
			break;
		case 6:
			CellIndexString6 = value;
			break;
		case 7:
			CellIndexString7 = value;
			break;
		case 8:
			CellIndexString8 = value;
			break;
		}
	}

	public string GetCellNameString(int index)
	{
		return index switch
		{
			1 => CellNameString1, 
			2 => CellNameString2, 
			3 => CellNameString3, 
			4 => CellNameString4, 
			5 => CellNameString5, 
			6 => CellNameString6, 
			7 => CellNameString7, 
			8 => CellNameString8, 
			_ => null, 
		};
	}

	public void SetCellNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CellNameString1 = value;
			break;
		case 2:
			CellNameString2 = value;
			break;
		case 3:
			CellNameString3 = value;
			break;
		case 4:
			CellNameString4 = value;
			break;
		case 5:
			CellNameString5 = value;
			break;
		case 6:
			CellNameString6 = value;
			break;
		case 7:
			CellNameString7 = value;
			break;
		case 8:
			CellNameString8 = value;
			break;
		}
	}

	public string GetCellMoneyString(int index)
	{
		return index switch
		{
			1 => CellMoneyString1, 
			2 => CellMoneyString2, 
			3 => CellMoneyString3, 
			4 => CellMoneyString4, 
			5 => CellMoneyString5, 
			6 => CellMoneyString6, 
			7 => CellMoneyString7, 
			8 => CellMoneyString8, 
			_ => null, 
		};
	}

	public void SetCellMoneyString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CellMoneyString1 = value;
			break;
		case 2:
			CellMoneyString2 = value;
			break;
		case 3:
			CellMoneyString3 = value;
			break;
		case 4:
			CellMoneyString4 = value;
			break;
		case 5:
			CellMoneyString5 = value;
			break;
		case 6:
			CellMoneyString6 = value;
			break;
		case 7:
			CellMoneyString7 = value;
			break;
		case 8:
			CellMoneyString8 = value;
			break;
		}
	}

	public bool GetCellLockShow(int index)
	{
		return index switch
		{
			1 => CellLockShow1, 
			2 => CellLockShow2, 
			3 => CellLockShow3, 
			4 => CellLockShow4, 
			5 => CellLockShow5, 
			6 => CellLockShow6, 
			7 => CellLockShow7, 
			8 => CellLockShow8, 
			_ => false, 
		};
	}

	public void SetCellLockShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CellLockShow1 = value;
			break;
		case 2:
			CellLockShow2 = value;
			break;
		case 3:
			CellLockShow3 = value;
			break;
		case 4:
			CellLockShow4 = value;
			break;
		case 5:
			CellLockShow5 = value;
			break;
		case 6:
			CellLockShow6 = value;
			break;
		case 7:
			CellLockShow7 = value;
			break;
		case 8:
			CellLockShow8 = value;
			break;
		}
	}

	public string GetCellMinuteString(int index)
	{
		return index switch
		{
			1 => CellMinuteString1, 
			2 => CellMinuteString2, 
			3 => CellMinuteString3, 
			4 => CellMinuteString4, 
			5 => CellMinuteString5, 
			6 => CellMinuteString6, 
			7 => CellMinuteString7, 
			8 => CellMinuteString8, 
			_ => null, 
		};
	}

	public void SetCellMinuteString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CellMinuteString1 = value;
			break;
		case 2:
			CellMinuteString2 = value;
			break;
		case 3:
			CellMinuteString3 = value;
			break;
		case 4:
			CellMinuteString4 = value;
			break;
		case 5:
			CellMinuteString5 = value;
			break;
		case 6:
			CellMinuteString6 = value;
			break;
		case 7:
			CellMinuteString7 = value;
			break;
		case 8:
			CellMinuteString8 = value;
			break;
		}
	}

	public string GetCellSecondString(int index)
	{
		return index switch
		{
			1 => CellSecondString1, 
			2 => CellSecondString2, 
			3 => CellSecondString3, 
			4 => CellSecondString4, 
			5 => CellSecondString5, 
			6 => CellSecondString6, 
			7 => CellSecondString7, 
			8 => CellSecondString8, 
			_ => null, 
		};
	}

	public void SetCellSecondString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CellSecondString1 = value;
			break;
		case 2:
			CellSecondString2 = value;
			break;
		case 3:
			CellSecondString3 = value;
			break;
		case 4:
			CellSecondString4 = value;
			break;
		case 5:
			CellSecondString5 = value;
			break;
		case 6:
			CellSecondString6 = value;
			break;
		case 7:
			CellSecondString7 = value;
			break;
		case 8:
			CellSecondString8 = value;
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
