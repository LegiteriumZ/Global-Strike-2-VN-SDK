using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.UltimateChallenge;

[GameUiTest]
public class UltimateKillMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private VerticalLayoutGroup _oPanelVerticalLayoutGroup;

	private GameObject _oMessage1;

	private GameObject _oMessage2;

	private GameObject _oMessage3;

	private GameObject _oMessage4;

	private GameObject _oMessage5;

	private GameObject _oMessage6;

	private GameObject _oMessage7;

	private GameObject _oMessage8;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup1;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup2;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup3;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup4;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup5;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup6;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup7;

	private HorizontalLayoutGroup _oMessageHorizontalLayoutGroup8;

	private GameObject _oKiller1;

	private GameObject _oKiller2;

	private GameObject _oKiller3;

	private GameObject _oKiller4;

	private GameObject _oKiller5;

	private GameObject _oKiller6;

	private GameObject _oKiller7;

	private GameObject _oKiller8;

	private Text _oKillerText1;

	private Text _oKillerText2;

	private Text _oKillerText3;

	private Text _oKillerText4;

	private Text _oKillerText5;

	private Text _oKillerText6;

	private Text _oKillerText7;

	private Text _oKillerText8;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private GameObject _oWeapon4;

	private GameObject _oWeapon5;

	private GameObject _oWeapon6;

	private GameObject _oWeapon7;

	private GameObject _oWeapon8;

	private Image _oWeaponImage1;

	private Image _oWeaponImage2;

	private Image _oWeaponImage3;

	private Image _oWeaponImage4;

	private Image _oWeaponImage5;

	private Image _oWeaponImage6;

	private Image _oWeaponImage7;

	private Image _oWeaponImage8;

	private GameObject _oKillType1;

	private GameObject _oKillType2;

	private GameObject _oKillType3;

	private GameObject _oKillType4;

	private GameObject _oKillType5;

	private GameObject _oKillType6;

	private GameObject _oKillType7;

	private GameObject _oKillType8;

	private Image _oKillTypeImage1;

	private Image _oKillTypeImage2;

	private Image _oKillTypeImage3;

	private Image _oKillTypeImage4;

	private Image _oKillTypeImage5;

	private Image _oKillTypeImage6;

	private Image _oKillTypeImage7;

	private Image _oKillTypeImage8;

	private GameObject _oVictim1;

	private GameObject _oVictim2;

	private GameObject _oVictim3;

	private GameObject _oVictim4;

	private GameObject _oVictim5;

	private GameObject _oVictim6;

	private GameObject _oVictim7;

	private GameObject _oVictim8;

	private Text _oVictimText1;

	private Text _oVictimText2;

	private Text _oVictimText3;

	private Text _oVictimText4;

	private Text _oVictimText5;

	private Text _oVictimText6;

	private Text _oVictimText7;

	private Text _oVictimText8;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge";

	private string _resourceAssetName = "UltimateKillMessage";

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

	public GameObject MessageObj1 => _oMessage1;

	public GameObject MessageObj2 => _oMessage2;

	public GameObject MessageObj3 => _oMessage3;

	public GameObject MessageObj4 => _oMessage4;

	public GameObject MessageObj5 => _oMessage5;

	public GameObject MessageObj6 => _oMessage6;

	public GameObject MessageObj7 => _oMessage7;

	public GameObject MessageObj8 => _oMessage8;

	public bool MessageShow1
	{
		get
		{
			if (_oMessage1 != null)
			{
				return _oMessage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow1 != value && _oMessage1 != null)
			{
				_oMessage1.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow2
	{
		get
		{
			if (_oMessage2 != null)
			{
				return _oMessage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow2 != value && _oMessage2 != null)
			{
				_oMessage2.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow3
	{
		get
		{
			if (_oMessage3 != null)
			{
				return _oMessage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow3 != value && _oMessage3 != null)
			{
				_oMessage3.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow4
	{
		get
		{
			if (_oMessage4 != null)
			{
				return _oMessage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow4 != value && _oMessage4 != null)
			{
				_oMessage4.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow5
	{
		get
		{
			if (_oMessage5 != null)
			{
				return _oMessage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow5 != value && _oMessage5 != null)
			{
				_oMessage5.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow6
	{
		get
		{
			if (_oMessage6 != null)
			{
				return _oMessage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow6 != value && _oMessage6 != null)
			{
				_oMessage6.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow7
	{
		get
		{
			if (_oMessage7 != null)
			{
				return _oMessage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow7 != value && _oMessage7 != null)
			{
				_oMessage7.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow8
	{
		get
		{
			if (_oMessage8 != null)
			{
				return _oMessage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow8 != value && _oMessage8 != null)
			{
				_oMessage8.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow1
	{
		get
		{
			if (_oKiller1 != null)
			{
				return _oKiller1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow1 != value && _oKiller1 != null)
			{
				_oKiller1.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow2
	{
		get
		{
			if (_oKiller2 != null)
			{
				return _oKiller2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow2 != value && _oKiller2 != null)
			{
				_oKiller2.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow3
	{
		get
		{
			if (_oKiller3 != null)
			{
				return _oKiller3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow3 != value && _oKiller3 != null)
			{
				_oKiller3.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow4
	{
		get
		{
			if (_oKiller4 != null)
			{
				return _oKiller4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow4 != value && _oKiller4 != null)
			{
				_oKiller4.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow5
	{
		get
		{
			if (_oKiller5 != null)
			{
				return _oKiller5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow5 != value && _oKiller5 != null)
			{
				_oKiller5.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow6
	{
		get
		{
			if (_oKiller6 != null)
			{
				return _oKiller6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow6 != value && _oKiller6 != null)
			{
				_oKiller6.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow7
	{
		get
		{
			if (_oKiller7 != null)
			{
				return _oKiller7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow7 != value && _oKiller7 != null)
			{
				_oKiller7.SetObjectActive(value);
			}
		}
	}

	public bool KillerShow8
	{
		get
		{
			if (_oKiller8 != null)
			{
				return _oKiller8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillerShow8 != value && _oKiller8 != null)
			{
				_oKiller8.SetObjectActive(value);
			}
		}
	}

	public string KillerString1
	{
		get
		{
			if (_oKillerText1 != null)
			{
				return _oKillerText1.text;
			}
			return null;
		}
		set
		{
			if (KillerString1 != value && _oKillerText1 != null)
			{
				_oKillerText1.text = value;
			}
		}
	}

	public string KillerString2
	{
		get
		{
			if (_oKillerText2 != null)
			{
				return _oKillerText2.text;
			}
			return null;
		}
		set
		{
			if (KillerString2 != value && _oKillerText2 != null)
			{
				_oKillerText2.text = value;
			}
		}
	}

	public string KillerString3
	{
		get
		{
			if (_oKillerText3 != null)
			{
				return _oKillerText3.text;
			}
			return null;
		}
		set
		{
			if (KillerString3 != value && _oKillerText3 != null)
			{
				_oKillerText3.text = value;
			}
		}
	}

	public string KillerString4
	{
		get
		{
			if (_oKillerText4 != null)
			{
				return _oKillerText4.text;
			}
			return null;
		}
		set
		{
			if (KillerString4 != value && _oKillerText4 != null)
			{
				_oKillerText4.text = value;
			}
		}
	}

	public string KillerString5
	{
		get
		{
			if (_oKillerText5 != null)
			{
				return _oKillerText5.text;
			}
			return null;
		}
		set
		{
			if (KillerString5 != value && _oKillerText5 != null)
			{
				_oKillerText5.text = value;
			}
		}
	}

	public string KillerString6
	{
		get
		{
			if (_oKillerText6 != null)
			{
				return _oKillerText6.text;
			}
			return null;
		}
		set
		{
			if (KillerString6 != value && _oKillerText6 != null)
			{
				_oKillerText6.text = value;
			}
		}
	}

	public string KillerString7
	{
		get
		{
			if (_oKillerText7 != null)
			{
				return _oKillerText7.text;
			}
			return null;
		}
		set
		{
			if (KillerString7 != value && _oKillerText7 != null)
			{
				_oKillerText7.text = value;
			}
		}
	}

	public string KillerString8
	{
		get
		{
			if (_oKillerText8 != null)
			{
				return _oKillerText8.text;
			}
			return null;
		}
		set
		{
			if (KillerString8 != value && _oKillerText8 != null)
			{
				_oKillerText8.text = value;
			}
		}
	}

	public Color KillerTextcolor1
	{
		get
		{
			if (_oKillerText1 != null)
			{
				return _oKillerText1.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor1 != value && _oKillerText1 != null)
			{
				_oKillerText1.color = value;
			}
		}
	}

	public Color KillerTextcolor2
	{
		get
		{
			if (_oKillerText2 != null)
			{
				return _oKillerText2.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor2 != value && _oKillerText2 != null)
			{
				_oKillerText2.color = value;
			}
		}
	}

	public Color KillerTextcolor3
	{
		get
		{
			if (_oKillerText3 != null)
			{
				return _oKillerText3.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor3 != value && _oKillerText3 != null)
			{
				_oKillerText3.color = value;
			}
		}
	}

	public Color KillerTextcolor4
	{
		get
		{
			if (_oKillerText4 != null)
			{
				return _oKillerText4.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor4 != value && _oKillerText4 != null)
			{
				_oKillerText4.color = value;
			}
		}
	}

	public Color KillerTextcolor5
	{
		get
		{
			if (_oKillerText5 != null)
			{
				return _oKillerText5.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor5 != value && _oKillerText5 != null)
			{
				_oKillerText5.color = value;
			}
		}
	}

	public Color KillerTextcolor6
	{
		get
		{
			if (_oKillerText6 != null)
			{
				return _oKillerText6.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor6 != value && _oKillerText6 != null)
			{
				_oKillerText6.color = value;
			}
		}
	}

	public Color KillerTextcolor7
	{
		get
		{
			if (_oKillerText7 != null)
			{
				return _oKillerText7.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor7 != value && _oKillerText7 != null)
			{
				_oKillerText7.color = value;
			}
		}
	}

	public Color KillerTextcolor8
	{
		get
		{
			if (_oKillerText8 != null)
			{
				return _oKillerText8.color;
			}
			return Color.white;
		}
		set
		{
			if (KillerTextcolor8 != value && _oKillerText8 != null)
			{
				_oKillerText8.color = value;
			}
		}
	}

	public bool WeaponShow1
	{
		get
		{
			if (_oWeapon1 != null)
			{
				return _oWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow1 != value && _oWeapon1 != null)
			{
				_oWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow2
	{
		get
		{
			if (_oWeapon2 != null)
			{
				return _oWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow2 != value && _oWeapon2 != null)
			{
				_oWeapon2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow3
	{
		get
		{
			if (_oWeapon3 != null)
			{
				return _oWeapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow3 != value && _oWeapon3 != null)
			{
				_oWeapon3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow4
	{
		get
		{
			if (_oWeapon4 != null)
			{
				return _oWeapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow4 != value && _oWeapon4 != null)
			{
				_oWeapon4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow5
	{
		get
		{
			if (_oWeapon5 != null)
			{
				return _oWeapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow5 != value && _oWeapon5 != null)
			{
				_oWeapon5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow6
	{
		get
		{
			if (_oWeapon6 != null)
			{
				return _oWeapon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow6 != value && _oWeapon6 != null)
			{
				_oWeapon6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow7
	{
		get
		{
			if (_oWeapon7 != null)
			{
				return _oWeapon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow7 != value && _oWeapon7 != null)
			{
				_oWeapon7.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow8
	{
		get
		{
			if (_oWeapon8 != null)
			{
				return _oWeapon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow8 != value && _oWeapon8 != null)
			{
				_oWeapon8.SetObjectActive(value);
			}
		}
	}

	public Sprite WeaponSprite1
	{
		get
		{
			if (_oWeaponImage1 != null)
			{
				return _oWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite1 != value && _oWeaponImage1 != null)
			{
				_oWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite2
	{
		get
		{
			if (_oWeaponImage2 != null)
			{
				return _oWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite2 != value && _oWeaponImage2 != null)
			{
				_oWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite3
	{
		get
		{
			if (_oWeaponImage3 != null)
			{
				return _oWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite3 != value && _oWeaponImage3 != null)
			{
				_oWeaponImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite4
	{
		get
		{
			if (_oWeaponImage4 != null)
			{
				return _oWeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite4 != value && _oWeaponImage4 != null)
			{
				_oWeaponImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite5
	{
		get
		{
			if (_oWeaponImage5 != null)
			{
				return _oWeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite5 != value && _oWeaponImage5 != null)
			{
				_oWeaponImage5.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite6
	{
		get
		{
			if (_oWeaponImage6 != null)
			{
				return _oWeaponImage6.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite6 != value && _oWeaponImage6 != null)
			{
				_oWeaponImage6.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite7
	{
		get
		{
			if (_oWeaponImage7 != null)
			{
				return _oWeaponImage7.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite7 != value && _oWeaponImage7 != null)
			{
				_oWeaponImage7.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite8
	{
		get
		{
			if (_oWeaponImage8 != null)
			{
				return _oWeaponImage8.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite8 != value && _oWeaponImage8 != null)
			{
				_oWeaponImage8.sprite = value;
			}
		}
	}

	public Color WeaponColor1
	{
		get
		{
			if (_oWeaponImage1 != null)
			{
				return _oWeaponImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor1 != value && _oWeaponImage1 != null)
			{
				_oWeaponImage1.color = value;
			}
		}
	}

	public Color WeaponColor2
	{
		get
		{
			if (_oWeaponImage2 != null)
			{
				return _oWeaponImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor2 != value && _oWeaponImage2 != null)
			{
				_oWeaponImage2.color = value;
			}
		}
	}

	public Color WeaponColor3
	{
		get
		{
			if (_oWeaponImage3 != null)
			{
				return _oWeaponImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor3 != value && _oWeaponImage3 != null)
			{
				_oWeaponImage3.color = value;
			}
		}
	}

	public Color WeaponColor4
	{
		get
		{
			if (_oWeaponImage4 != null)
			{
				return _oWeaponImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor4 != value && _oWeaponImage4 != null)
			{
				_oWeaponImage4.color = value;
			}
		}
	}

	public Color WeaponColor5
	{
		get
		{
			if (_oWeaponImage5 != null)
			{
				return _oWeaponImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor5 != value && _oWeaponImage5 != null)
			{
				_oWeaponImage5.color = value;
			}
		}
	}

	public Color WeaponColor6
	{
		get
		{
			if (_oWeaponImage6 != null)
			{
				return _oWeaponImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor6 != value && _oWeaponImage6 != null)
			{
				_oWeaponImage6.color = value;
			}
		}
	}

	public Color WeaponColor7
	{
		get
		{
			if (_oWeaponImage7 != null)
			{
				return _oWeaponImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor7 != value && _oWeaponImage7 != null)
			{
				_oWeaponImage7.color = value;
			}
		}
	}

	public Color WeaponColor8
	{
		get
		{
			if (_oWeaponImage8 != null)
			{
				return _oWeaponImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (WeaponColor8 != value && _oWeaponImage8 != null)
			{
				_oWeaponImage8.color = value;
			}
		}
	}

	public bool KillTypeShow1
	{
		get
		{
			if (_oKillType1 != null)
			{
				return _oKillType1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow1 != value && _oKillType1 != null)
			{
				_oKillType1.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow2
	{
		get
		{
			if (_oKillType2 != null)
			{
				return _oKillType2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow2 != value && _oKillType2 != null)
			{
				_oKillType2.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow3
	{
		get
		{
			if (_oKillType3 != null)
			{
				return _oKillType3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow3 != value && _oKillType3 != null)
			{
				_oKillType3.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow4
	{
		get
		{
			if (_oKillType4 != null)
			{
				return _oKillType4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow4 != value && _oKillType4 != null)
			{
				_oKillType4.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow5
	{
		get
		{
			if (_oKillType5 != null)
			{
				return _oKillType5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow5 != value && _oKillType5 != null)
			{
				_oKillType5.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow6
	{
		get
		{
			if (_oKillType6 != null)
			{
				return _oKillType6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow6 != value && _oKillType6 != null)
			{
				_oKillType6.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow7
	{
		get
		{
			if (_oKillType7 != null)
			{
				return _oKillType7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow7 != value && _oKillType7 != null)
			{
				_oKillType7.SetObjectActive(value);
			}
		}
	}

	public bool KillTypeShow8
	{
		get
		{
			if (_oKillType8 != null)
			{
				return _oKillType8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow8 != value && _oKillType8 != null)
			{
				_oKillType8.SetObjectActive(value);
			}
		}
	}

	public Sprite KillTypeSprite1
	{
		get
		{
			if (_oKillTypeImage1 != null)
			{
				return _oKillTypeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite1 != value && _oKillTypeImage1 != null)
			{
				_oKillTypeImage1.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite2
	{
		get
		{
			if (_oKillTypeImage2 != null)
			{
				return _oKillTypeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite2 != value && _oKillTypeImage2 != null)
			{
				_oKillTypeImage2.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite3
	{
		get
		{
			if (_oKillTypeImage3 != null)
			{
				return _oKillTypeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite3 != value && _oKillTypeImage3 != null)
			{
				_oKillTypeImage3.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite4
	{
		get
		{
			if (_oKillTypeImage4 != null)
			{
				return _oKillTypeImage4.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite4 != value && _oKillTypeImage4 != null)
			{
				_oKillTypeImage4.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite5
	{
		get
		{
			if (_oKillTypeImage5 != null)
			{
				return _oKillTypeImage5.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite5 != value && _oKillTypeImage5 != null)
			{
				_oKillTypeImage5.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite6
	{
		get
		{
			if (_oKillTypeImage6 != null)
			{
				return _oKillTypeImage6.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite6 != value && _oKillTypeImage6 != null)
			{
				_oKillTypeImage6.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite7
	{
		get
		{
			if (_oKillTypeImage7 != null)
			{
				return _oKillTypeImage7.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite7 != value && _oKillTypeImage7 != null)
			{
				_oKillTypeImage7.sprite = value;
			}
		}
	}

	public Sprite KillTypeSprite8
	{
		get
		{
			if (_oKillTypeImage8 != null)
			{
				return _oKillTypeImage8.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite8 != value && _oKillTypeImage8 != null)
			{
				_oKillTypeImage8.sprite = value;
			}
		}
	}

	public Color KillTypeColor1
	{
		get
		{
			if (_oKillTypeImage1 != null)
			{
				return _oKillTypeImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor1 != value && _oKillTypeImage1 != null)
			{
				_oKillTypeImage1.color = value;
			}
		}
	}

	public Color KillTypeColor2
	{
		get
		{
			if (_oKillTypeImage2 != null)
			{
				return _oKillTypeImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor2 != value && _oKillTypeImage2 != null)
			{
				_oKillTypeImage2.color = value;
			}
		}
	}

	public Color KillTypeColor3
	{
		get
		{
			if (_oKillTypeImage3 != null)
			{
				return _oKillTypeImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor3 != value && _oKillTypeImage3 != null)
			{
				_oKillTypeImage3.color = value;
			}
		}
	}

	public Color KillTypeColor4
	{
		get
		{
			if (_oKillTypeImage4 != null)
			{
				return _oKillTypeImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor4 != value && _oKillTypeImage4 != null)
			{
				_oKillTypeImage4.color = value;
			}
		}
	}

	public Color KillTypeColor5
	{
		get
		{
			if (_oKillTypeImage5 != null)
			{
				return _oKillTypeImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor5 != value && _oKillTypeImage5 != null)
			{
				_oKillTypeImage5.color = value;
			}
		}
	}

	public Color KillTypeColor6
	{
		get
		{
			if (_oKillTypeImage6 != null)
			{
				return _oKillTypeImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor6 != value && _oKillTypeImage6 != null)
			{
				_oKillTypeImage6.color = value;
			}
		}
	}

	public Color KillTypeColor7
	{
		get
		{
			if (_oKillTypeImage7 != null)
			{
				return _oKillTypeImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor7 != value && _oKillTypeImage7 != null)
			{
				_oKillTypeImage7.color = value;
			}
		}
	}

	public Color KillTypeColor8
	{
		get
		{
			if (_oKillTypeImage8 != null)
			{
				return _oKillTypeImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (KillTypeColor8 != value && _oKillTypeImage8 != null)
			{
				_oKillTypeImage8.color = value;
			}
		}
	}

	public bool VictimShow1
	{
		get
		{
			if (_oVictim1 != null)
			{
				return _oVictim1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow1 != value && _oVictim1 != null)
			{
				_oVictim1.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow2
	{
		get
		{
			if (_oVictim2 != null)
			{
				return _oVictim2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow2 != value && _oVictim2 != null)
			{
				_oVictim2.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow3
	{
		get
		{
			if (_oVictim3 != null)
			{
				return _oVictim3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow3 != value && _oVictim3 != null)
			{
				_oVictim3.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow4
	{
		get
		{
			if (_oVictim4 != null)
			{
				return _oVictim4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow4 != value && _oVictim4 != null)
			{
				_oVictim4.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow5
	{
		get
		{
			if (_oVictim5 != null)
			{
				return _oVictim5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow5 != value && _oVictim5 != null)
			{
				_oVictim5.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow6
	{
		get
		{
			if (_oVictim6 != null)
			{
				return _oVictim6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow6 != value && _oVictim6 != null)
			{
				_oVictim6.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow7
	{
		get
		{
			if (_oVictim7 != null)
			{
				return _oVictim7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow7 != value && _oVictim7 != null)
			{
				_oVictim7.SetObjectActive(value);
			}
		}
	}

	public bool VictimShow8
	{
		get
		{
			if (_oVictim8 != null)
			{
				return _oVictim8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimShow8 != value && _oVictim8 != null)
			{
				_oVictim8.SetObjectActive(value);
			}
		}
	}

	public string VictimString1
	{
		get
		{
			if (_oVictimText1 != null)
			{
				return _oVictimText1.text;
			}
			return null;
		}
		set
		{
			if (VictimString1 != value && _oVictimText1 != null)
			{
				_oVictimText1.text = value;
			}
		}
	}

	public string VictimString2
	{
		get
		{
			if (_oVictimText2 != null)
			{
				return _oVictimText2.text;
			}
			return null;
		}
		set
		{
			if (VictimString2 != value && _oVictimText2 != null)
			{
				_oVictimText2.text = value;
			}
		}
	}

	public string VictimString3
	{
		get
		{
			if (_oVictimText3 != null)
			{
				return _oVictimText3.text;
			}
			return null;
		}
		set
		{
			if (VictimString3 != value && _oVictimText3 != null)
			{
				_oVictimText3.text = value;
			}
		}
	}

	public string VictimString4
	{
		get
		{
			if (_oVictimText4 != null)
			{
				return _oVictimText4.text;
			}
			return null;
		}
		set
		{
			if (VictimString4 != value && _oVictimText4 != null)
			{
				_oVictimText4.text = value;
			}
		}
	}

	public string VictimString5
	{
		get
		{
			if (_oVictimText5 != null)
			{
				return _oVictimText5.text;
			}
			return null;
		}
		set
		{
			if (VictimString5 != value && _oVictimText5 != null)
			{
				_oVictimText5.text = value;
			}
		}
	}

	public string VictimString6
	{
		get
		{
			if (_oVictimText6 != null)
			{
				return _oVictimText6.text;
			}
			return null;
		}
		set
		{
			if (VictimString6 != value && _oVictimText6 != null)
			{
				_oVictimText6.text = value;
			}
		}
	}

	public string VictimString7
	{
		get
		{
			if (_oVictimText7 != null)
			{
				return _oVictimText7.text;
			}
			return null;
		}
		set
		{
			if (VictimString7 != value && _oVictimText7 != null)
			{
				_oVictimText7.text = value;
			}
		}
	}

	public string VictimString8
	{
		get
		{
			if (_oVictimText8 != null)
			{
				return _oVictimText8.text;
			}
			return null;
		}
		set
		{
			if (VictimString8 != value && _oVictimText8 != null)
			{
				_oVictimText8.text = value;
			}
		}
	}

	public Color VictimTextcolor1
	{
		get
		{
			if (_oVictimText1 != null)
			{
				return _oVictimText1.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor1 != value && _oVictimText1 != null)
			{
				_oVictimText1.color = value;
			}
		}
	}

	public Color VictimTextcolor2
	{
		get
		{
			if (_oVictimText2 != null)
			{
				return _oVictimText2.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor2 != value && _oVictimText2 != null)
			{
				_oVictimText2.color = value;
			}
		}
	}

	public Color VictimTextcolor3
	{
		get
		{
			if (_oVictimText3 != null)
			{
				return _oVictimText3.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor3 != value && _oVictimText3 != null)
			{
				_oVictimText3.color = value;
			}
		}
	}

	public Color VictimTextcolor4
	{
		get
		{
			if (_oVictimText4 != null)
			{
				return _oVictimText4.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor4 != value && _oVictimText4 != null)
			{
				_oVictimText4.color = value;
			}
		}
	}

	public Color VictimTextcolor5
	{
		get
		{
			if (_oVictimText5 != null)
			{
				return _oVictimText5.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor5 != value && _oVictimText5 != null)
			{
				_oVictimText5.color = value;
			}
		}
	}

	public Color VictimTextcolor6
	{
		get
		{
			if (_oVictimText6 != null)
			{
				return _oVictimText6.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor6 != value && _oVictimText6 != null)
			{
				_oVictimText6.color = value;
			}
		}
	}

	public Color VictimTextcolor7
	{
		get
		{
			if (_oVictimText7 != null)
			{
				return _oVictimText7.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor7 != value && _oVictimText7 != null)
			{
				_oVictimText7.color = value;
			}
		}
	}

	public Color VictimTextcolor8
	{
		get
		{
			if (_oVictimText8 != null)
			{
				return _oVictimText8.color;
			}
			return Color.white;
		}
		set
		{
			if (VictimTextcolor8 != value && _oVictimText8 != null)
			{
				_oVictimText8.color = value;
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
				_oPanelVerticalLayoutGroup = transform.gameObject.GetComponent<VerticalLayoutGroup>();
				break;
			case "Message1":
				_oMessage1 = transform.gameObject;
				_oMessageHorizontalLayoutGroup1 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message2":
				_oMessage2 = transform.gameObject;
				_oMessageHorizontalLayoutGroup2 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message3":
				_oMessage3 = transform.gameObject;
				_oMessageHorizontalLayoutGroup3 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message4":
				_oMessage4 = transform.gameObject;
				_oMessageHorizontalLayoutGroup4 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message5":
				_oMessage5 = transform.gameObject;
				_oMessageHorizontalLayoutGroup5 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message6":
				_oMessage6 = transform.gameObject;
				_oMessageHorizontalLayoutGroup6 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message7":
				_oMessage7 = transform.gameObject;
				_oMessageHorizontalLayoutGroup7 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Message8":
				_oMessage8 = transform.gameObject;
				_oMessageHorizontalLayoutGroup8 = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Killer1":
				_oKiller1 = transform.gameObject;
				_oKillerText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer2":
				_oKiller2 = transform.gameObject;
				_oKillerText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer3":
				_oKiller3 = transform.gameObject;
				_oKillerText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer4":
				_oKiller4 = transform.gameObject;
				_oKillerText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer5":
				_oKiller5 = transform.gameObject;
				_oKillerText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer6":
				_oKiller6 = transform.gameObject;
				_oKillerText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer7":
				_oKiller7 = transform.gameObject;
				_oKillerText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Killer8":
				_oKiller8 = transform.gameObject;
				_oKillerText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon1":
				_oWeapon1 = transform.gameObject;
				_oWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				_oWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				_oWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon4":
				_oWeapon4 = transform.gameObject;
				_oWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon5":
				_oWeapon5 = transform.gameObject;
				_oWeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon6":
				_oWeapon6 = transform.gameObject;
				_oWeaponImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon7":
				_oWeapon7 = transform.gameObject;
				_oWeaponImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon8":
				_oWeapon8 = transform.gameObject;
				_oWeaponImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType1":
				_oKillType1 = transform.gameObject;
				_oKillTypeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType2":
				_oKillType2 = transform.gameObject;
				_oKillTypeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType3":
				_oKillType3 = transform.gameObject;
				_oKillTypeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType4":
				_oKillType4 = transform.gameObject;
				_oKillTypeImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType5":
				_oKillType5 = transform.gameObject;
				_oKillTypeImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType6":
				_oKillType6 = transform.gameObject;
				_oKillTypeImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType7":
				_oKillType7 = transform.gameObject;
				_oKillTypeImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType8":
				_oKillType8 = transform.gameObject;
				_oKillTypeImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Victim1":
				_oVictim1 = transform.gameObject;
				_oVictimText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim2":
				_oVictim2 = transform.gameObject;
				_oVictimText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim3":
				_oVictim3 = transform.gameObject;
				_oVictimText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim4":
				_oVictim4 = transform.gameObject;
				_oVictimText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim5":
				_oVictim5 = transform.gameObject;
				_oVictimText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim6":
				_oVictim6 = transform.gameObject;
				_oVictimText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim7":
				_oVictim7 = transform.gameObject;
				_oVictimText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Victim8":
				_oVictim8 = transform.gameObject;
				_oVictimText8 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}

	public void PanelVlayoutupdate()
	{
		if (_oPanelVerticalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oPanel.GetComponent<RectTransform>());
		}
	}

	public GameObject GetMessageObj(int index)
	{
		return index switch
		{
			1 => MessageObj1, 
			2 => MessageObj2, 
			3 => MessageObj3, 
			4 => MessageObj4, 
			5 => MessageObj5, 
			6 => MessageObj6, 
			7 => MessageObj7, 
			8 => MessageObj8, 
			_ => null, 
		};
	}

	public bool GetMessageShow(int index)
	{
		return index switch
		{
			1 => MessageShow1, 
			2 => MessageShow2, 
			3 => MessageShow3, 
			4 => MessageShow4, 
			5 => MessageShow5, 
			6 => MessageShow6, 
			7 => MessageShow7, 
			8 => MessageShow8, 
			_ => false, 
		};
	}

	public void SetMessageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MessageShow1 = value;
			break;
		case 2:
			MessageShow2 = value;
			break;
		case 3:
			MessageShow3 = value;
			break;
		case 4:
			MessageShow4 = value;
			break;
		case 5:
			MessageShow5 = value;
			break;
		case 6:
			MessageShow6 = value;
			break;
		case 7:
			MessageShow7 = value;
			break;
		case 8:
			MessageShow8 = value;
			break;
		}
	}

	public void MessageHlayoutupdate1()
	{
		if (_oMessageHorizontalLayoutGroup1 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage1.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate2()
	{
		if (_oMessageHorizontalLayoutGroup2 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage2.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate3()
	{
		if (_oMessageHorizontalLayoutGroup3 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage3.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate4()
	{
		if (_oMessageHorizontalLayoutGroup4 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage4.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate5()
	{
		if (_oMessageHorizontalLayoutGroup5 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage5.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate6()
	{
		if (_oMessageHorizontalLayoutGroup6 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage6.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate7()
	{
		if (_oMessageHorizontalLayoutGroup7 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage7.GetComponent<RectTransform>());
		}
	}

	public void MessageHlayoutupdate8()
	{
		if (_oMessageHorizontalLayoutGroup8 != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oMessage8.GetComponent<RectTransform>());
		}
	}

	public void CallMessageHlayoutupdate(int index)
	{
		switch (index)
		{
		case 1:
			MessageHlayoutupdate1();
			break;
		case 2:
			MessageHlayoutupdate2();
			break;
		case 3:
			MessageHlayoutupdate3();
			break;
		case 4:
			MessageHlayoutupdate4();
			break;
		case 5:
			MessageHlayoutupdate5();
			break;
		case 6:
			MessageHlayoutupdate6();
			break;
		case 7:
			MessageHlayoutupdate7();
			break;
		case 8:
			MessageHlayoutupdate8();
			break;
		}
	}

	public bool GetKillerShow(int index)
	{
		return index switch
		{
			1 => KillerShow1, 
			2 => KillerShow2, 
			3 => KillerShow3, 
			4 => KillerShow4, 
			5 => KillerShow5, 
			6 => KillerShow6, 
			7 => KillerShow7, 
			8 => KillerShow8, 
			_ => false, 
		};
	}

	public void SetKillerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			KillerShow1 = value;
			break;
		case 2:
			KillerShow2 = value;
			break;
		case 3:
			KillerShow3 = value;
			break;
		case 4:
			KillerShow4 = value;
			break;
		case 5:
			KillerShow5 = value;
			break;
		case 6:
			KillerShow6 = value;
			break;
		case 7:
			KillerShow7 = value;
			break;
		case 8:
			KillerShow8 = value;
			break;
		}
	}

	public string GetKillerString(int index)
	{
		return index switch
		{
			1 => KillerString1, 
			2 => KillerString2, 
			3 => KillerString3, 
			4 => KillerString4, 
			5 => KillerString5, 
			6 => KillerString6, 
			7 => KillerString7, 
			8 => KillerString8, 
			_ => null, 
		};
	}

	public void SetKillerString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KillerString1 = value;
			break;
		case 2:
			KillerString2 = value;
			break;
		case 3:
			KillerString3 = value;
			break;
		case 4:
			KillerString4 = value;
			break;
		case 5:
			KillerString5 = value;
			break;
		case 6:
			KillerString6 = value;
			break;
		case 7:
			KillerString7 = value;
			break;
		case 8:
			KillerString8 = value;
			break;
		}
	}

	public Color GetKillerTextcolor(int index)
	{
		return index switch
		{
			1 => KillerTextcolor1, 
			2 => KillerTextcolor2, 
			3 => KillerTextcolor3, 
			4 => KillerTextcolor4, 
			5 => KillerTextcolor5, 
			6 => KillerTextcolor6, 
			7 => KillerTextcolor7, 
			8 => KillerTextcolor8, 
			_ => Color.white, 
		};
	}

	public void SetKillerTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			KillerTextcolor1 = value;
			break;
		case 2:
			KillerTextcolor2 = value;
			break;
		case 3:
			KillerTextcolor3 = value;
			break;
		case 4:
			KillerTextcolor4 = value;
			break;
		case 5:
			KillerTextcolor5 = value;
			break;
		case 6:
			KillerTextcolor6 = value;
			break;
		case 7:
			KillerTextcolor7 = value;
			break;
		case 8:
			KillerTextcolor8 = value;
			break;
		}
	}

	public bool GetWeaponShow(int index)
	{
		return index switch
		{
			1 => WeaponShow1, 
			2 => WeaponShow2, 
			3 => WeaponShow3, 
			4 => WeaponShow4, 
			5 => WeaponShow5, 
			6 => WeaponShow6, 
			7 => WeaponShow7, 
			8 => WeaponShow8, 
			_ => false, 
		};
	}

	public void SetWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponShow1 = value;
			break;
		case 2:
			WeaponShow2 = value;
			break;
		case 3:
			WeaponShow3 = value;
			break;
		case 4:
			WeaponShow4 = value;
			break;
		case 5:
			WeaponShow5 = value;
			break;
		case 6:
			WeaponShow6 = value;
			break;
		case 7:
			WeaponShow7 = value;
			break;
		case 8:
			WeaponShow8 = value;
			break;
		}
	}

	public Sprite GetWeaponSprite(int index)
	{
		return index switch
		{
			1 => WeaponSprite1, 
			2 => WeaponSprite2, 
			3 => WeaponSprite3, 
			4 => WeaponSprite4, 
			5 => WeaponSprite5, 
			6 => WeaponSprite6, 
			7 => WeaponSprite7, 
			8 => WeaponSprite8, 
			_ => null, 
		};
	}

	public void SetWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponSprite1 = value;
			break;
		case 2:
			WeaponSprite2 = value;
			break;
		case 3:
			WeaponSprite3 = value;
			break;
		case 4:
			WeaponSprite4 = value;
			break;
		case 5:
			WeaponSprite5 = value;
			break;
		case 6:
			WeaponSprite6 = value;
			break;
		case 7:
			WeaponSprite7 = value;
			break;
		case 8:
			WeaponSprite8 = value;
			break;
		}
	}

	public Color GetWeaponColor(int index)
	{
		return index switch
		{
			1 => WeaponColor1, 
			2 => WeaponColor2, 
			3 => WeaponColor3, 
			4 => WeaponColor4, 
			5 => WeaponColor5, 
			6 => WeaponColor6, 
			7 => WeaponColor7, 
			8 => WeaponColor8, 
			_ => Color.white, 
		};
	}

	public void SetWeaponColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			WeaponColor1 = value;
			break;
		case 2:
			WeaponColor2 = value;
			break;
		case 3:
			WeaponColor3 = value;
			break;
		case 4:
			WeaponColor4 = value;
			break;
		case 5:
			WeaponColor5 = value;
			break;
		case 6:
			WeaponColor6 = value;
			break;
		case 7:
			WeaponColor7 = value;
			break;
		case 8:
			WeaponColor8 = value;
			break;
		}
	}

	public void WeaponNtvsize1()
	{
		if (_oWeaponImage1 != null)
		{
			_oWeaponImage1.SetNativeSize();
		}
	}

	public void WeaponNtvsize2()
	{
		if (_oWeaponImage2 != null)
		{
			_oWeaponImage2.SetNativeSize();
		}
	}

	public void WeaponNtvsize3()
	{
		if (_oWeaponImage3 != null)
		{
			_oWeaponImage3.SetNativeSize();
		}
	}

	public void WeaponNtvsize4()
	{
		if (_oWeaponImage4 != null)
		{
			_oWeaponImage4.SetNativeSize();
		}
	}

	public void WeaponNtvsize5()
	{
		if (_oWeaponImage5 != null)
		{
			_oWeaponImage5.SetNativeSize();
		}
	}

	public void WeaponNtvsize6()
	{
		if (_oWeaponImage6 != null)
		{
			_oWeaponImage6.SetNativeSize();
		}
	}

	public void WeaponNtvsize7()
	{
		if (_oWeaponImage7 != null)
		{
			_oWeaponImage7.SetNativeSize();
		}
	}

	public void WeaponNtvsize8()
	{
		if (_oWeaponImage8 != null)
		{
			_oWeaponImage8.SetNativeSize();
		}
	}

	public void CallWeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			WeaponNtvsize1();
			break;
		case 2:
			WeaponNtvsize2();
			break;
		case 3:
			WeaponNtvsize3();
			break;
		case 4:
			WeaponNtvsize4();
			break;
		case 5:
			WeaponNtvsize5();
			break;
		case 6:
			WeaponNtvsize6();
			break;
		case 7:
			WeaponNtvsize7();
			break;
		case 8:
			WeaponNtvsize8();
			break;
		}
	}

	public bool GetKillTypeShow(int index)
	{
		return index switch
		{
			1 => KillTypeShow1, 
			2 => KillTypeShow2, 
			3 => KillTypeShow3, 
			4 => KillTypeShow4, 
			5 => KillTypeShow5, 
			6 => KillTypeShow6, 
			7 => KillTypeShow7, 
			8 => KillTypeShow8, 
			_ => false, 
		};
	}

	public void SetKillTypeShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			KillTypeShow1 = value;
			break;
		case 2:
			KillTypeShow2 = value;
			break;
		case 3:
			KillTypeShow3 = value;
			break;
		case 4:
			KillTypeShow4 = value;
			break;
		case 5:
			KillTypeShow5 = value;
			break;
		case 6:
			KillTypeShow6 = value;
			break;
		case 7:
			KillTypeShow7 = value;
			break;
		case 8:
			KillTypeShow8 = value;
			break;
		}
	}

	public Sprite GetKillTypeSprite(int index)
	{
		return index switch
		{
			1 => KillTypeSprite1, 
			2 => KillTypeSprite2, 
			3 => KillTypeSprite3, 
			4 => KillTypeSprite4, 
			5 => KillTypeSprite5, 
			6 => KillTypeSprite6, 
			7 => KillTypeSprite7, 
			8 => KillTypeSprite8, 
			_ => null, 
		};
	}

	public void SetKillTypeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			KillTypeSprite1 = value;
			break;
		case 2:
			KillTypeSprite2 = value;
			break;
		case 3:
			KillTypeSprite3 = value;
			break;
		case 4:
			KillTypeSprite4 = value;
			break;
		case 5:
			KillTypeSprite5 = value;
			break;
		case 6:
			KillTypeSprite6 = value;
			break;
		case 7:
			KillTypeSprite7 = value;
			break;
		case 8:
			KillTypeSprite8 = value;
			break;
		}
	}

	public Color GetKillTypeColor(int index)
	{
		return index switch
		{
			1 => KillTypeColor1, 
			2 => KillTypeColor2, 
			3 => KillTypeColor3, 
			4 => KillTypeColor4, 
			5 => KillTypeColor5, 
			6 => KillTypeColor6, 
			7 => KillTypeColor7, 
			8 => KillTypeColor8, 
			_ => Color.white, 
		};
	}

	public void SetKillTypeColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			KillTypeColor1 = value;
			break;
		case 2:
			KillTypeColor2 = value;
			break;
		case 3:
			KillTypeColor3 = value;
			break;
		case 4:
			KillTypeColor4 = value;
			break;
		case 5:
			KillTypeColor5 = value;
			break;
		case 6:
			KillTypeColor6 = value;
			break;
		case 7:
			KillTypeColor7 = value;
			break;
		case 8:
			KillTypeColor8 = value;
			break;
		}
	}

	public void KillTypeNtvsize1()
	{
		if (_oKillTypeImage1 != null)
		{
			_oKillTypeImage1.SetNativeSize();
		}
	}

	public void KillTypeNtvsize2()
	{
		if (_oKillTypeImage2 != null)
		{
			_oKillTypeImage2.SetNativeSize();
		}
	}

	public void KillTypeNtvsize3()
	{
		if (_oKillTypeImage3 != null)
		{
			_oKillTypeImage3.SetNativeSize();
		}
	}

	public void KillTypeNtvsize4()
	{
		if (_oKillTypeImage4 != null)
		{
			_oKillTypeImage4.SetNativeSize();
		}
	}

	public void KillTypeNtvsize5()
	{
		if (_oKillTypeImage5 != null)
		{
			_oKillTypeImage5.SetNativeSize();
		}
	}

	public void KillTypeNtvsize6()
	{
		if (_oKillTypeImage6 != null)
		{
			_oKillTypeImage6.SetNativeSize();
		}
	}

	public void KillTypeNtvsize7()
	{
		if (_oKillTypeImage7 != null)
		{
			_oKillTypeImage7.SetNativeSize();
		}
	}

	public void KillTypeNtvsize8()
	{
		if (_oKillTypeImage8 != null)
		{
			_oKillTypeImage8.SetNativeSize();
		}
	}

	public void CallKillTypeNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			KillTypeNtvsize1();
			break;
		case 2:
			KillTypeNtvsize2();
			break;
		case 3:
			KillTypeNtvsize3();
			break;
		case 4:
			KillTypeNtvsize4();
			break;
		case 5:
			KillTypeNtvsize5();
			break;
		case 6:
			KillTypeNtvsize6();
			break;
		case 7:
			KillTypeNtvsize7();
			break;
		case 8:
			KillTypeNtvsize8();
			break;
		}
	}

	public bool GetVictimShow(int index)
	{
		return index switch
		{
			1 => VictimShow1, 
			2 => VictimShow2, 
			3 => VictimShow3, 
			4 => VictimShow4, 
			5 => VictimShow5, 
			6 => VictimShow6, 
			7 => VictimShow7, 
			8 => VictimShow8, 
			_ => false, 
		};
	}

	public void SetVictimShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			VictimShow1 = value;
			break;
		case 2:
			VictimShow2 = value;
			break;
		case 3:
			VictimShow3 = value;
			break;
		case 4:
			VictimShow4 = value;
			break;
		case 5:
			VictimShow5 = value;
			break;
		case 6:
			VictimShow6 = value;
			break;
		case 7:
			VictimShow7 = value;
			break;
		case 8:
			VictimShow8 = value;
			break;
		}
	}

	public string GetVictimString(int index)
	{
		return index switch
		{
			1 => VictimString1, 
			2 => VictimString2, 
			3 => VictimString3, 
			4 => VictimString4, 
			5 => VictimString5, 
			6 => VictimString6, 
			7 => VictimString7, 
			8 => VictimString8, 
			_ => null, 
		};
	}

	public void SetVictimString(int index, string value)
	{
		switch (index)
		{
		case 1:
			VictimString1 = value;
			break;
		case 2:
			VictimString2 = value;
			break;
		case 3:
			VictimString3 = value;
			break;
		case 4:
			VictimString4 = value;
			break;
		case 5:
			VictimString5 = value;
			break;
		case 6:
			VictimString6 = value;
			break;
		case 7:
			VictimString7 = value;
			break;
		case 8:
			VictimString8 = value;
			break;
		}
	}

	public Color GetVictimTextcolor(int index)
	{
		return index switch
		{
			1 => VictimTextcolor1, 
			2 => VictimTextcolor2, 
			3 => VictimTextcolor3, 
			4 => VictimTextcolor4, 
			5 => VictimTextcolor5, 
			6 => VictimTextcolor6, 
			7 => VictimTextcolor7, 
			8 => VictimTextcolor8, 
			_ => Color.white, 
		};
	}

	public void SetVictimTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			VictimTextcolor1 = value;
			break;
		case 2:
			VictimTextcolor2 = value;
			break;
		case 3:
			VictimTextcolor3 = value;
			break;
		case 4:
			VictimTextcolor4 = value;
			break;
		case 5:
			VictimTextcolor5 = value;
			break;
		case 6:
			VictimTextcolor6 = value;
			break;
		case 7:
			VictimTextcolor7 = value;
			break;
		case 8:
			VictimTextcolor8 = value;
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
			UnityEngine.Object.Destroy(_viewGameObject);
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
