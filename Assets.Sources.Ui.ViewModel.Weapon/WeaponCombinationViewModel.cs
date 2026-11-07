using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class WeaponCombinationViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oPart1;

	private GameObject _oPart2;

	private GameObject _oPart3;

	private GameObject _oPart4;

	private GameObject _oPart5;

	private GameObject _oPart6;

	private GameObject _oPart7;

	private GameObject _oPart8;

	private GameObject _oPart9;

	private GameObject _oPart10;

	private GameObject _oPart11;

	private GameObject _oPart12;

	private EventTrigger _oPartEventTrigger1;

	private EventTrigger _oPartEventTrigger2;

	private EventTrigger _oPartEventTrigger3;

	private EventTrigger _oPartEventTrigger4;

	private EventTrigger _oPartEventTrigger5;

	private EventTrigger _oPartEventTrigger6;

	private EventTrigger _oPartEventTrigger7;

	private EventTrigger _oPartEventTrigger8;

	private EventTrigger _oPartEventTrigger9;

	private EventTrigger _oPartEventTrigger10;

	private EventTrigger _oPartEventTrigger11;

	private EventTrigger _oPartEventTrigger12;

	private GameObject _oSelectedIcon1;

	private GameObject _oSelectedIcon2;

	private GameObject _oSelectedIcon3;

	private GameObject _oSelectedIcon4;

	private GameObject _oSelectedIcon5;

	private GameObject _oSelectedIcon6;

	private GameObject _oSelectedIcon7;

	private GameObject _oSelectedIcon8;

	private GameObject _oSelectedIcon9;

	private GameObject _oSelectedIcon10;

	private GameObject _oSelectedIcon11;

	private GameObject _oSelectedIcon12;

	private Button _oSelectedIconButton1;

	private Button _oSelectedIconButton2;

	private Button _oSelectedIconButton3;

	private Button _oSelectedIconButton4;

	private Button _oSelectedIconButton5;

	private Button _oSelectedIconButton6;

	private Button _oSelectedIconButton7;

	private Button _oSelectedIconButton8;

	private Button _oSelectedIconButton9;

	private Button _oSelectedIconButton10;

	private Button _oSelectedIconButton11;

	private Button _oSelectedIconButton12;

	private GameObject _oWeaponIcon1;

	private GameObject _oWeaponIcon2;

	private GameObject _oWeaponIcon3;

	private GameObject _oWeaponIcon4;

	private GameObject _oWeaponIcon5;

	private GameObject _oWeaponIcon6;

	private GameObject _oWeaponIcon7;

	private GameObject _oWeaponIcon8;

	private GameObject _oWeaponIcon9;

	private GameObject _oWeaponIcon10;

	private GameObject _oWeaponIcon11;

	private GameObject _oWeaponIcon12;

	private Image _oWeaponIconImage1;

	private Image _oWeaponIconImage2;

	private Image _oWeaponIconImage3;

	private Image _oWeaponIconImage4;

	private Image _oWeaponIconImage5;

	private Image _oWeaponIconImage6;

	private Image _oWeaponIconImage7;

	private Image _oWeaponIconImage8;

	private Image _oWeaponIconImage9;

	private Image _oWeaponIconImage10;

	private Image _oWeaponIconImage11;

	private Image _oWeaponIconImage12;

	private GameObject _oForbidIcon1;

	private GameObject _oForbidIcon2;

	private GameObject _oForbidIcon3;

	private GameObject _oForbidIcon4;

	private GameObject _oForbidIcon5;

	private GameObject _oForbidIcon6;

	private GameObject _oForbidIcon7;

	private GameObject _oForbidIcon8;

	private GameObject _oForbidIcon9;

	private GameObject _oForbidIcon10;

	private GameObject _oForbidIcon11;

	private GameObject _oForbidIcon12;

	private GameObject _oPvpBtn;

	private EventTrigger _oPvpBtnEventTrigger;

	private GameObject _oBioBtn;

	private EventTrigger _oBioBtnEventTrigger;

	private GameObject _oGameObject;

	private GameObject _oTipsBack;

	private RectTransform _oTipsBackRectTransform;

	private GameObject _oTips;

	private Text _oTipsText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "WeaponCombination";

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

	public List<EventTrigger.Entry> PartTriggers1
	{
		get
		{
			if (_oPartEventTrigger1 != null)
			{
				return _oPartEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers1 != value && _oPartEventTrigger1 != null)
			{
				_oPartEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers2
	{
		get
		{
			if (_oPartEventTrigger2 != null)
			{
				return _oPartEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers2 != value && _oPartEventTrigger2 != null)
			{
				_oPartEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers3
	{
		get
		{
			if (_oPartEventTrigger3 != null)
			{
				return _oPartEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers3 != value && _oPartEventTrigger3 != null)
			{
				_oPartEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers4
	{
		get
		{
			if (_oPartEventTrigger4 != null)
			{
				return _oPartEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers4 != value && _oPartEventTrigger4 != null)
			{
				_oPartEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers5
	{
		get
		{
			if (_oPartEventTrigger5 != null)
			{
				return _oPartEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers5 != value && _oPartEventTrigger5 != null)
			{
				_oPartEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers6
	{
		get
		{
			if (_oPartEventTrigger6 != null)
			{
				return _oPartEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers6 != value && _oPartEventTrigger6 != null)
			{
				_oPartEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers7
	{
		get
		{
			if (_oPartEventTrigger7 != null)
			{
				return _oPartEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers7 != value && _oPartEventTrigger7 != null)
			{
				_oPartEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers8
	{
		get
		{
			if (_oPartEventTrigger8 != null)
			{
				return _oPartEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers8 != value && _oPartEventTrigger8 != null)
			{
				_oPartEventTrigger8.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers9
	{
		get
		{
			if (_oPartEventTrigger9 != null)
			{
				return _oPartEventTrigger9.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers9 != value && _oPartEventTrigger9 != null)
			{
				_oPartEventTrigger9.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers10
	{
		get
		{
			if (_oPartEventTrigger10 != null)
			{
				return _oPartEventTrigger10.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers10 != value && _oPartEventTrigger10 != null)
			{
				_oPartEventTrigger10.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers11
	{
		get
		{
			if (_oPartEventTrigger11 != null)
			{
				return _oPartEventTrigger11.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers11 != value && _oPartEventTrigger11 != null)
			{
				_oPartEventTrigger11.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers12
	{
		get
		{
			if (_oPartEventTrigger12 != null)
			{
				return _oPartEventTrigger12.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers12 != value && _oPartEventTrigger12 != null)
			{
				_oPartEventTrigger12.triggers = value;
			}
		}
	}

	public bool SelectedIconShow1
	{
		get
		{
			if (_oSelectedIcon1 != null)
			{
				return _oSelectedIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow1 != value && _oSelectedIcon1 != null)
			{
				_oSelectedIcon1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow2
	{
		get
		{
			if (_oSelectedIcon2 != null)
			{
				return _oSelectedIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow2 != value && _oSelectedIcon2 != null)
			{
				_oSelectedIcon2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow3
	{
		get
		{
			if (_oSelectedIcon3 != null)
			{
				return _oSelectedIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow3 != value && _oSelectedIcon3 != null)
			{
				_oSelectedIcon3.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow4
	{
		get
		{
			if (_oSelectedIcon4 != null)
			{
				return _oSelectedIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow4 != value && _oSelectedIcon4 != null)
			{
				_oSelectedIcon4.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow5
	{
		get
		{
			if (_oSelectedIcon5 != null)
			{
				return _oSelectedIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow5 != value && _oSelectedIcon5 != null)
			{
				_oSelectedIcon5.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow6
	{
		get
		{
			if (_oSelectedIcon6 != null)
			{
				return _oSelectedIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow6 != value && _oSelectedIcon6 != null)
			{
				_oSelectedIcon6.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow7
	{
		get
		{
			if (_oSelectedIcon7 != null)
			{
				return _oSelectedIcon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow7 != value && _oSelectedIcon7 != null)
			{
				_oSelectedIcon7.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow8
	{
		get
		{
			if (_oSelectedIcon8 != null)
			{
				return _oSelectedIcon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow8 != value && _oSelectedIcon8 != null)
			{
				_oSelectedIcon8.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow9
	{
		get
		{
			if (_oSelectedIcon9 != null)
			{
				return _oSelectedIcon9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow9 != value && _oSelectedIcon9 != null)
			{
				_oSelectedIcon9.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow10
	{
		get
		{
			if (_oSelectedIcon10 != null)
			{
				return _oSelectedIcon10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow10 != value && _oSelectedIcon10 != null)
			{
				_oSelectedIcon10.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow11
	{
		get
		{
			if (_oSelectedIcon11 != null)
			{
				return _oSelectedIcon11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow11 != value && _oSelectedIcon11 != null)
			{
				_oSelectedIcon11.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow12
	{
		get
		{
			if (_oSelectedIcon12 != null)
			{
				return _oSelectedIcon12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow12 != value && _oSelectedIcon12 != null)
			{
				_oSelectedIcon12.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked1
	{
		get
		{
			if (_oSelectedIconButton1 != null)
			{
				return _oSelectedIconButton1.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked1 != value && _oSelectedIconButton1 != null)
			{
				_oSelectedIconButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked2
	{
		get
		{
			if (_oSelectedIconButton2 != null)
			{
				return _oSelectedIconButton2.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked2 != value && _oSelectedIconButton2 != null)
			{
				_oSelectedIconButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked3
	{
		get
		{
			if (_oSelectedIconButton3 != null)
			{
				return _oSelectedIconButton3.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked3 != value && _oSelectedIconButton3 != null)
			{
				_oSelectedIconButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked4
	{
		get
		{
			if (_oSelectedIconButton4 != null)
			{
				return _oSelectedIconButton4.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked4 != value && _oSelectedIconButton4 != null)
			{
				_oSelectedIconButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked5
	{
		get
		{
			if (_oSelectedIconButton5 != null)
			{
				return _oSelectedIconButton5.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked5 != value && _oSelectedIconButton5 != null)
			{
				_oSelectedIconButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked6
	{
		get
		{
			if (_oSelectedIconButton6 != null)
			{
				return _oSelectedIconButton6.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked6 != value && _oSelectedIconButton6 != null)
			{
				_oSelectedIconButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked7
	{
		get
		{
			if (_oSelectedIconButton7 != null)
			{
				return _oSelectedIconButton7.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked7 != value && _oSelectedIconButton7 != null)
			{
				_oSelectedIconButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked8
	{
		get
		{
			if (_oSelectedIconButton8 != null)
			{
				return _oSelectedIconButton8.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked8 != value && _oSelectedIconButton8 != null)
			{
				_oSelectedIconButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked9
	{
		get
		{
			if (_oSelectedIconButton9 != null)
			{
				return _oSelectedIconButton9.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked9 != value && _oSelectedIconButton9 != null)
			{
				_oSelectedIconButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked10
	{
		get
		{
			if (_oSelectedIconButton10 != null)
			{
				return _oSelectedIconButton10.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked10 != value && _oSelectedIconButton10 != null)
			{
				_oSelectedIconButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked11
	{
		get
		{
			if (_oSelectedIconButton11 != null)
			{
				return _oSelectedIconButton11.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked11 != value && _oSelectedIconButton11 != null)
			{
				_oSelectedIconButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SelectedIconClicked12
	{
		get
		{
			if (_oSelectedIconButton12 != null)
			{
				return _oSelectedIconButton12.onClick;
			}
			return null;
		}
		set
		{
			if (SelectedIconClicked12 != value && _oSelectedIconButton12 != null)
			{
				_oSelectedIconButton12.onClick = value;
			}
		}
	}

	public Sprite WeaponIconSprite1
	{
		get
		{
			if (_oWeaponIconImage1 != null)
			{
				return _oWeaponIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite1 != value && _oWeaponIconImage1 != null)
			{
				_oWeaponIconImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite2
	{
		get
		{
			if (_oWeaponIconImage2 != null)
			{
				return _oWeaponIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite2 != value && _oWeaponIconImage2 != null)
			{
				_oWeaponIconImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite3
	{
		get
		{
			if (_oWeaponIconImage3 != null)
			{
				return _oWeaponIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite3 != value && _oWeaponIconImage3 != null)
			{
				_oWeaponIconImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite4
	{
		get
		{
			if (_oWeaponIconImage4 != null)
			{
				return _oWeaponIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite4 != value && _oWeaponIconImage4 != null)
			{
				_oWeaponIconImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite5
	{
		get
		{
			if (_oWeaponIconImage5 != null)
			{
				return _oWeaponIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite5 != value && _oWeaponIconImage5 != null)
			{
				_oWeaponIconImage5.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite6
	{
		get
		{
			if (_oWeaponIconImage6 != null)
			{
				return _oWeaponIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite6 != value && _oWeaponIconImage6 != null)
			{
				_oWeaponIconImage6.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite7
	{
		get
		{
			if (_oWeaponIconImage7 != null)
			{
				return _oWeaponIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite7 != value && _oWeaponIconImage7 != null)
			{
				_oWeaponIconImage7.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite8
	{
		get
		{
			if (_oWeaponIconImage8 != null)
			{
				return _oWeaponIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite8 != value && _oWeaponIconImage8 != null)
			{
				_oWeaponIconImage8.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite9
	{
		get
		{
			if (_oWeaponIconImage9 != null)
			{
				return _oWeaponIconImage9.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite9 != value && _oWeaponIconImage9 != null)
			{
				_oWeaponIconImage9.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite10
	{
		get
		{
			if (_oWeaponIconImage10 != null)
			{
				return _oWeaponIconImage10.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite10 != value && _oWeaponIconImage10 != null)
			{
				_oWeaponIconImage10.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite11
	{
		get
		{
			if (_oWeaponIconImage11 != null)
			{
				return _oWeaponIconImage11.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite11 != value && _oWeaponIconImage11 != null)
			{
				_oWeaponIconImage11.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite12
	{
		get
		{
			if (_oWeaponIconImage12 != null)
			{
				return _oWeaponIconImage12.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite12 != value && _oWeaponIconImage12 != null)
			{
				_oWeaponIconImage12.sprite = value;
			}
		}
	}

	public bool ForbidIconShow1
	{
		get
		{
			if (_oForbidIcon1 != null)
			{
				return _oForbidIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow1 != value && _oForbidIcon1 != null)
			{
				_oForbidIcon1.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow2
	{
		get
		{
			if (_oForbidIcon2 != null)
			{
				return _oForbidIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow2 != value && _oForbidIcon2 != null)
			{
				_oForbidIcon2.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow3
	{
		get
		{
			if (_oForbidIcon3 != null)
			{
				return _oForbidIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow3 != value && _oForbidIcon3 != null)
			{
				_oForbidIcon3.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow4
	{
		get
		{
			if (_oForbidIcon4 != null)
			{
				return _oForbidIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow4 != value && _oForbidIcon4 != null)
			{
				_oForbidIcon4.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow5
	{
		get
		{
			if (_oForbidIcon5 != null)
			{
				return _oForbidIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow5 != value && _oForbidIcon5 != null)
			{
				_oForbidIcon5.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow6
	{
		get
		{
			if (_oForbidIcon6 != null)
			{
				return _oForbidIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow6 != value && _oForbidIcon6 != null)
			{
				_oForbidIcon6.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow7
	{
		get
		{
			if (_oForbidIcon7 != null)
			{
				return _oForbidIcon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow7 != value && _oForbidIcon7 != null)
			{
				_oForbidIcon7.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow8
	{
		get
		{
			if (_oForbidIcon8 != null)
			{
				return _oForbidIcon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow8 != value && _oForbidIcon8 != null)
			{
				_oForbidIcon8.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow9
	{
		get
		{
			if (_oForbidIcon9 != null)
			{
				return _oForbidIcon9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow9 != value && _oForbidIcon9 != null)
			{
				_oForbidIcon9.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow10
	{
		get
		{
			if (_oForbidIcon10 != null)
			{
				return _oForbidIcon10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow10 != value && _oForbidIcon10 != null)
			{
				_oForbidIcon10.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow11
	{
		get
		{
			if (_oForbidIcon11 != null)
			{
				return _oForbidIcon11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow11 != value && _oForbidIcon11 != null)
			{
				_oForbidIcon11.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow12
	{
		get
		{
			if (_oForbidIcon12 != null)
			{
				return _oForbidIcon12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow12 != value && _oForbidIcon12 != null)
			{
				_oForbidIcon12.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> PvpBtnTriggers
	{
		get
		{
			if (_oPvpBtnEventTrigger != null)
			{
				return _oPvpBtnEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (PvpBtnTriggers != value && _oPvpBtnEventTrigger != null)
			{
				_oPvpBtnEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BioBtnTriggers
	{
		get
		{
			if (_oBioBtnEventTrigger != null)
			{
				return _oBioBtnEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (BioBtnTriggers != value && _oBioBtnEventTrigger != null)
			{
				_oBioBtnEventTrigger.triggers = value;
			}
		}
	}

	public GameObject GameObjectObj => _oGameObject;

	public bool TipsBackShow
	{
		get
		{
			if (_oTipsBack != null)
			{
				return _oTipsBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsBackShow != value && _oTipsBack != null)
			{
				_oTipsBack.SetObjectActive(value);
			}
		}
	}

	public Vector3 TipsBackGposition
	{
		get
		{
			if (_oTipsBackRectTransform != null)
			{
				return _oTipsBackRectTransform.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (TipsBackGposition != value && _oTipsBackRectTransform != null)
			{
				_oTipsBackRectTransform.position = value;
			}
		}
	}

	public string TipsString
	{
		get
		{
			if (_oTipsText != null)
			{
				return _oTipsText.text;
			}
			return null;
		}
		set
		{
			if (TipsString != value && _oTipsText != null)
			{
				_oTipsText.text = value;
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
			case "Part1":
				_oPart1 = transform.gameObject;
				_oPartEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part2":
				_oPart2 = transform.gameObject;
				_oPartEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part3":
				_oPart3 = transform.gameObject;
				_oPartEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part4":
				_oPart4 = transform.gameObject;
				_oPartEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part5":
				_oPart5 = transform.gameObject;
				_oPartEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part6":
				_oPart6 = transform.gameObject;
				_oPartEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part7":
				_oPart7 = transform.gameObject;
				_oPartEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part8":
				_oPart8 = transform.gameObject;
				_oPartEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part9":
				_oPart9 = transform.gameObject;
				_oPartEventTrigger9 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part10":
				_oPart10 = transform.gameObject;
				_oPartEventTrigger10 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part11":
				_oPart11 = transform.gameObject;
				_oPartEventTrigger11 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part12":
				_oPart12 = transform.gameObject;
				_oPartEventTrigger12 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "SelectedIcon1":
				_oSelectedIcon1 = transform.gameObject;
				_oSelectedIconButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon2":
				_oSelectedIcon2 = transform.gameObject;
				_oSelectedIconButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon3":
				_oSelectedIcon3 = transform.gameObject;
				_oSelectedIconButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon4":
				_oSelectedIcon4 = transform.gameObject;
				_oSelectedIconButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon5":
				_oSelectedIcon5 = transform.gameObject;
				_oSelectedIconButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon6":
				_oSelectedIcon6 = transform.gameObject;
				_oSelectedIconButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon7":
				_oSelectedIcon7 = transform.gameObject;
				_oSelectedIconButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon8":
				_oSelectedIcon8 = transform.gameObject;
				_oSelectedIconButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon9":
				_oSelectedIcon9 = transform.gameObject;
				_oSelectedIconButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon10":
				_oSelectedIcon10 = transform.gameObject;
				_oSelectedIconButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon11":
				_oSelectedIcon11 = transform.gameObject;
				_oSelectedIconButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedIcon12":
				_oSelectedIcon12 = transform.gameObject;
				_oSelectedIconButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "WeaponIcon1":
				_oWeaponIcon1 = transform.gameObject;
				_oWeaponIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon2":
				_oWeaponIcon2 = transform.gameObject;
				_oWeaponIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon3":
				_oWeaponIcon3 = transform.gameObject;
				_oWeaponIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon4":
				_oWeaponIcon4 = transform.gameObject;
				_oWeaponIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon5":
				_oWeaponIcon5 = transform.gameObject;
				_oWeaponIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon6":
				_oWeaponIcon6 = transform.gameObject;
				_oWeaponIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon7":
				_oWeaponIcon7 = transform.gameObject;
				_oWeaponIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon8":
				_oWeaponIcon8 = transform.gameObject;
				_oWeaponIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon9":
				_oWeaponIcon9 = transform.gameObject;
				_oWeaponIconImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon10":
				_oWeaponIcon10 = transform.gameObject;
				_oWeaponIconImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon11":
				_oWeaponIcon11 = transform.gameObject;
				_oWeaponIconImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon12":
				_oWeaponIcon12 = transform.gameObject;
				_oWeaponIconImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "ForbidIcon1":
				_oForbidIcon1 = transform.gameObject;
				break;
			case "ForbidIcon2":
				_oForbidIcon2 = transform.gameObject;
				break;
			case "ForbidIcon3":
				_oForbidIcon3 = transform.gameObject;
				break;
			case "ForbidIcon4":
				_oForbidIcon4 = transform.gameObject;
				break;
			case "ForbidIcon5":
				_oForbidIcon5 = transform.gameObject;
				break;
			case "ForbidIcon6":
				_oForbidIcon6 = transform.gameObject;
				break;
			case "ForbidIcon7":
				_oForbidIcon7 = transform.gameObject;
				break;
			case "ForbidIcon8":
				_oForbidIcon8 = transform.gameObject;
				break;
			case "ForbidIcon9":
				_oForbidIcon9 = transform.gameObject;
				break;
			case "ForbidIcon10":
				_oForbidIcon10 = transform.gameObject;
				break;
			case "ForbidIcon11":
				_oForbidIcon11 = transform.gameObject;
				break;
			case "ForbidIcon12":
				_oForbidIcon12 = transform.gameObject;
				break;
			case "PvpBtn":
				_oPvpBtn = transform.gameObject;
				_oPvpBtnEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "BioBtn":
				_oBioBtn = transform.gameObject;
				_oBioBtnEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "GameObject":
				_oGameObject = transform.gameObject;
				break;
			case "TipsBack":
				_oTipsBack = transform.gameObject;
				_oTipsBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Tips":
				_oTips = transform.gameObject;
				_oTipsText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public List<EventTrigger.Entry> GetPartTriggers(int index)
	{
		return index switch
		{
			1 => PartTriggers1, 
			2 => PartTriggers2, 
			3 => PartTriggers3, 
			4 => PartTriggers4, 
			5 => PartTriggers5, 
			6 => PartTriggers6, 
			7 => PartTriggers7, 
			8 => PartTriggers8, 
			9 => PartTriggers9, 
			10 => PartTriggers10, 
			11 => PartTriggers11, 
			12 => PartTriggers12, 
			_ => null, 
		};
	}

	public void SetPartTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			PartTriggers1 = value;
			break;
		case 2:
			PartTriggers2 = value;
			break;
		case 3:
			PartTriggers3 = value;
			break;
		case 4:
			PartTriggers4 = value;
			break;
		case 5:
			PartTriggers5 = value;
			break;
		case 6:
			PartTriggers6 = value;
			break;
		case 7:
			PartTriggers7 = value;
			break;
		case 8:
			PartTriggers8 = value;
			break;
		case 9:
			PartTriggers9 = value;
			break;
		case 10:
			PartTriggers10 = value;
			break;
		case 11:
			PartTriggers11 = value;
			break;
		case 12:
			PartTriggers12 = value;
			break;
		}
	}

	public bool GetSelectedIconShow(int index)
	{
		return index switch
		{
			1 => SelectedIconShow1, 
			2 => SelectedIconShow2, 
			3 => SelectedIconShow3, 
			4 => SelectedIconShow4, 
			5 => SelectedIconShow5, 
			6 => SelectedIconShow6, 
			7 => SelectedIconShow7, 
			8 => SelectedIconShow8, 
			9 => SelectedIconShow9, 
			10 => SelectedIconShow10, 
			11 => SelectedIconShow11, 
			12 => SelectedIconShow12, 
			_ => false, 
		};
	}

	public void SetSelectedIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedIconShow1 = value;
			break;
		case 2:
			SelectedIconShow2 = value;
			break;
		case 3:
			SelectedIconShow3 = value;
			break;
		case 4:
			SelectedIconShow4 = value;
			break;
		case 5:
			SelectedIconShow5 = value;
			break;
		case 6:
			SelectedIconShow6 = value;
			break;
		case 7:
			SelectedIconShow7 = value;
			break;
		case 8:
			SelectedIconShow8 = value;
			break;
		case 9:
			SelectedIconShow9 = value;
			break;
		case 10:
			SelectedIconShow10 = value;
			break;
		case 11:
			SelectedIconShow11 = value;
			break;
		case 12:
			SelectedIconShow12 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetSelectedIconClicked(int index)
	{
		return index switch
		{
			1 => SelectedIconClicked1, 
			2 => SelectedIconClicked2, 
			3 => SelectedIconClicked3, 
			4 => SelectedIconClicked4, 
			5 => SelectedIconClicked5, 
			6 => SelectedIconClicked6, 
			7 => SelectedIconClicked7, 
			8 => SelectedIconClicked8, 
			9 => SelectedIconClicked9, 
			10 => SelectedIconClicked10, 
			11 => SelectedIconClicked11, 
			12 => SelectedIconClicked12, 
			_ => null, 
		};
	}

	public void SetSelectedIconClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			SelectedIconClicked1 = value;
			break;
		case 2:
			SelectedIconClicked2 = value;
			break;
		case 3:
			SelectedIconClicked3 = value;
			break;
		case 4:
			SelectedIconClicked4 = value;
			break;
		case 5:
			SelectedIconClicked5 = value;
			break;
		case 6:
			SelectedIconClicked6 = value;
			break;
		case 7:
			SelectedIconClicked7 = value;
			break;
		case 8:
			SelectedIconClicked8 = value;
			break;
		case 9:
			SelectedIconClicked9 = value;
			break;
		case 10:
			SelectedIconClicked10 = value;
			break;
		case 11:
			SelectedIconClicked11 = value;
			break;
		case 12:
			SelectedIconClicked12 = value;
			break;
		}
	}

	public Sprite GetWeaponIconSprite(int index)
	{
		return index switch
		{
			1 => WeaponIconSprite1, 
			2 => WeaponIconSprite2, 
			3 => WeaponIconSprite3, 
			4 => WeaponIconSprite4, 
			5 => WeaponIconSprite5, 
			6 => WeaponIconSprite6, 
			7 => WeaponIconSprite7, 
			8 => WeaponIconSprite8, 
			9 => WeaponIconSprite9, 
			10 => WeaponIconSprite10, 
			11 => WeaponIconSprite11, 
			12 => WeaponIconSprite12, 
			_ => null, 
		};
	}

	public void SetWeaponIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponIconSprite1 = value;
			break;
		case 2:
			WeaponIconSprite2 = value;
			break;
		case 3:
			WeaponIconSprite3 = value;
			break;
		case 4:
			WeaponIconSprite4 = value;
			break;
		case 5:
			WeaponIconSprite5 = value;
			break;
		case 6:
			WeaponIconSprite6 = value;
			break;
		case 7:
			WeaponIconSprite7 = value;
			break;
		case 8:
			WeaponIconSprite8 = value;
			break;
		case 9:
			WeaponIconSprite9 = value;
			break;
		case 10:
			WeaponIconSprite10 = value;
			break;
		case 11:
			WeaponIconSprite11 = value;
			break;
		case 12:
			WeaponIconSprite12 = value;
			break;
		}
	}

	public bool GetForbidIconShow(int index)
	{
		return index switch
		{
			1 => ForbidIconShow1, 
			2 => ForbidIconShow2, 
			3 => ForbidIconShow3, 
			4 => ForbidIconShow4, 
			5 => ForbidIconShow5, 
			6 => ForbidIconShow6, 
			7 => ForbidIconShow7, 
			8 => ForbidIconShow8, 
			9 => ForbidIconShow9, 
			10 => ForbidIconShow10, 
			11 => ForbidIconShow11, 
			12 => ForbidIconShow12, 
			_ => false, 
		};
	}

	public void SetForbidIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ForbidIconShow1 = value;
			break;
		case 2:
			ForbidIconShow2 = value;
			break;
		case 3:
			ForbidIconShow3 = value;
			break;
		case 4:
			ForbidIconShow4 = value;
			break;
		case 5:
			ForbidIconShow5 = value;
			break;
		case 6:
			ForbidIconShow6 = value;
			break;
		case 7:
			ForbidIconShow7 = value;
			break;
		case 8:
			ForbidIconShow8 = value;
			break;
		case 9:
			ForbidIconShow9 = value;
			break;
		case 10:
			ForbidIconShow10 = value;
			break;
		case 11:
			ForbidIconShow11 = value;
			break;
		case 12:
			ForbidIconShow12 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
