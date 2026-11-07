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

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class KillmessageViewModel : ViewModelBase, IUiViewModel
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

	private GameObject _oRelive1;

	private GameObject _oRelive2;

	private GameObject _oRelive3;

	private GameObject _oRelive4;

	private GameObject _oRelive5;

	private GameObject _oRelive6;

	private GameObject _oRelive7;

	private GameObject _oRelive8;

	private Image _oReliveImage1;

	private Image _oReliveImage2;

	private Image _oReliveImage3;

	private Image _oReliveImage4;

	private Image _oReliveImage5;

	private Image _oReliveImage6;

	private Image _oReliveImage7;

	private Image _oReliveImage8;

	private GameObject _oKillCountBack1;

	private GameObject _oKillCountBack2;

	private GameObject _oKillCountBack3;

	private GameObject _oKillCountBack4;

	private GameObject _oKillCountBack5;

	private GameObject _oKillCountBack6;

	private GameObject _oKillCountBack7;

	private GameObject _oKillCountBack8;

	private Image _oKillCountBackImage1;

	private Image _oKillCountBackImage2;

	private Image _oKillCountBackImage3;

	private Image _oKillCountBackImage4;

	private Image _oKillCountBackImage5;

	private Image _oKillCountBackImage6;

	private Image _oKillCountBackImage7;

	private Image _oKillCountBackImage8;

	private GameObject _oKillCount1;

	private GameObject _oKillCount2;

	private GameObject _oKillCount3;

	private GameObject _oKillCount4;

	private GameObject _oKillCount5;

	private GameObject _oKillCount6;

	private GameObject _oKillCount7;

	private GameObject _oKillCount8;

	private Text _oKillCountText1;

	private Text _oKillCountText2;

	private Text _oKillCountText3;

	private Text _oKillCountText4;

	private Text _oKillCountText5;

	private Text _oKillCountText6;

	private Text _oKillCountText7;

	private Text _oKillCountText8;

	private GameObject _oGloryA1;

	private GameObject _oGloryA2;

	private GameObject _oGloryA3;

	private GameObject _oGloryA4;

	private GameObject _oGloryA5;

	private GameObject _oGloryA6;

	private GameObject _oGloryA7;

	private GameObject _oGloryA8;

	private Image _oGloryAImage1;

	private Image _oGloryAImage2;

	private Image _oGloryAImage3;

	private Image _oGloryAImage4;

	private Image _oGloryAImage5;

	private Image _oGloryAImage6;

	private Image _oGloryAImage7;

	private Image _oGloryAImage8;

	private GameObject _oGloryB1;

	private GameObject _oGloryB2;

	private GameObject _oGloryB3;

	private GameObject _oGloryB4;

	private GameObject _oGloryB5;

	private GameObject _oGloryB6;

	private GameObject _oGloryB7;

	private GameObject _oGloryB8;

	private Image _oGloryBImage1;

	private Image _oGloryBImage2;

	private Image _oGloryBImage3;

	private Image _oGloryBImage4;

	private Image _oGloryBImage5;

	private Image _oGloryBImage6;

	private Image _oGloryBImage7;

	private Image _oGloryBImage8;

	private GameObject _oGloryC1;

	private GameObject _oGloryC2;

	private GameObject _oGloryC3;

	private GameObject _oGloryC4;

	private GameObject _oGloryC5;

	private GameObject _oGloryC6;

	private GameObject _oGloryC7;

	private GameObject _oGloryC8;

	private Image _oGloryCImage1;

	private Image _oGloryCImage2;

	private Image _oGloryCImage3;

	private Image _oGloryCImage4;

	private Image _oGloryCImage5;

	private Image _oGloryCImage6;

	private Image _oGloryCImage7;

	private Image _oGloryCImage8;

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

	private GameObject _oAssister1;

	private GameObject _oAssister2;

	private GameObject _oAssister3;

	private GameObject _oAssister4;

	private GameObject _oAssister5;

	private GameObject _oAssister6;

	private GameObject _oAssister7;

	private GameObject _oAssister8;

	private Text _oAssisterText1;

	private Text _oAssisterText2;

	private Text _oAssisterText3;

	private Text _oAssisterText4;

	private Text _oAssisterText5;

	private Text _oAssisterText6;

	private Text _oAssisterText7;

	private Text _oAssisterText8;

	private GameObject _oAssistantType1;

	private GameObject _oAssistantType2;

	private GameObject _oAssistantType3;

	private GameObject _oAssistantType4;

	private GameObject _oAssistantType5;

	private GameObject _oAssistantType6;

	private GameObject _oAssistantType7;

	private GameObject _oAssistantType8;

	private Image _oAssistantTypeImage1;

	private Image _oAssistantTypeImage2;

	private Image _oAssistantTypeImage3;

	private Image _oAssistantTypeImage4;

	private Image _oAssistantTypeImage5;

	private Image _oAssistantTypeImage6;

	private Image _oAssistantTypeImage7;

	private Image _oAssistantTypeImage8;

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

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private GameObject _oIcon4;

	private GameObject _oIcon5;

	private GameObject _oIcon6;

	private GameObject _oIcon7;

	private GameObject _oIcon8;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private Image _oIconImage4;

	private Image _oIconImage5;

	private Image _oIconImage6;

	private Image _oIconImage7;

	private Image _oIconImage8;

	private GameObject _oPermanent1;

	private GameObject _oPermanent2;

	private GameObject _oPermanent3;

	private GameObject _oPermanent4;

	private GameObject _oPermanent5;

	private GameObject _oPermanent6;

	private GameObject _oPermanent7;

	private GameObject _oPermanent8;

	private Image _oPermanentImage1;

	private Image _oPermanentImage2;

	private Image _oPermanentImage3;

	private Image _oPermanentImage4;

	private Image _oPermanentImage5;

	private Image _oPermanentImage6;

	private Image _oPermanentImage7;

	private Image _oPermanentImage8;

	private GameObject _oName1;

	private GameObject _oName2;

	private GameObject _oName3;

	private GameObject _oName4;

	private GameObject _oName5;

	private GameObject _oName6;

	private GameObject _oName7;

	private GameObject _oName8;

	private Image _oNameImage1;

	private Image _oNameImage2;

	private Image _oNameImage3;

	private Image _oNameImage4;

	private Image _oNameImage5;

	private Image _oNameImage6;

	private Image _oNameImage7;

	private Image _oNameImage8;

	private GameObject _oLabel1;

	private GameObject _oLabel2;

	private GameObject _oLabel3;

	private GameObject _oLabel4;

	private GameObject _oLabel5;

	private GameObject _oLabel6;

	private GameObject _oLabel7;

	private GameObject _oLabel8;

	private GameObject _oModeKillBack1;

	private GameObject _oModeKillBack2;

	private GameObject _oModeKillBack3;

	private GameObject _oModeKillBack4;

	private GameObject _oModeKillBack5;

	private GameObject _oModeKillBack6;

	private GameObject _oModeKillBack7;

	private GameObject _oModeKillBack8;

	private GameObject _oModeKillCount1;

	private GameObject _oModeKillCount2;

	private GameObject _oModeKillCount3;

	private GameObject _oModeKillCount4;

	private GameObject _oModeKillCount5;

	private GameObject _oModeKillCount6;

	private GameObject _oModeKillCount7;

	private GameObject _oModeKillCount8;

	private Text _oModeKillCountText1;

	private Text _oModeKillCountText2;

	private Text _oModeKillCountText3;

	private Text _oModeKillCountText4;

	private Text _oModeKillCountText5;

	private Text _oModeKillCountText6;

	private Text _oModeKillCountText7;

	private Text _oModeKillCountText8;

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

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "killmessage";

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

	public bool ReliveShow1
	{
		get
		{
			if (_oRelive1 != null)
			{
				return _oRelive1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow1 != value && _oRelive1 != null)
			{
				_oRelive1.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow2
	{
		get
		{
			if (_oRelive2 != null)
			{
				return _oRelive2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow2 != value && _oRelive2 != null)
			{
				_oRelive2.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow3
	{
		get
		{
			if (_oRelive3 != null)
			{
				return _oRelive3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow3 != value && _oRelive3 != null)
			{
				_oRelive3.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow4
	{
		get
		{
			if (_oRelive4 != null)
			{
				return _oRelive4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow4 != value && _oRelive4 != null)
			{
				_oRelive4.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow5
	{
		get
		{
			if (_oRelive5 != null)
			{
				return _oRelive5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow5 != value && _oRelive5 != null)
			{
				_oRelive5.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow6
	{
		get
		{
			if (_oRelive6 != null)
			{
				return _oRelive6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow6 != value && _oRelive6 != null)
			{
				_oRelive6.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow7
	{
		get
		{
			if (_oRelive7 != null)
			{
				return _oRelive7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow7 != value && _oRelive7 != null)
			{
				_oRelive7.SetObjectActive(value);
			}
		}
	}

	public bool ReliveShow8
	{
		get
		{
			if (_oRelive8 != null)
			{
				return _oRelive8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveShow8 != value && _oRelive8 != null)
			{
				_oRelive8.SetObjectActive(value);
			}
		}
	}

	public Color ReliveColor1
	{
		get
		{
			if (_oReliveImage1 != null)
			{
				return _oReliveImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor1 != value && _oReliveImage1 != null)
			{
				_oReliveImage1.color = value;
			}
		}
	}

	public Color ReliveColor2
	{
		get
		{
			if (_oReliveImage2 != null)
			{
				return _oReliveImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor2 != value && _oReliveImage2 != null)
			{
				_oReliveImage2.color = value;
			}
		}
	}

	public Color ReliveColor3
	{
		get
		{
			if (_oReliveImage3 != null)
			{
				return _oReliveImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor3 != value && _oReliveImage3 != null)
			{
				_oReliveImage3.color = value;
			}
		}
	}

	public Color ReliveColor4
	{
		get
		{
			if (_oReliveImage4 != null)
			{
				return _oReliveImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor4 != value && _oReliveImage4 != null)
			{
				_oReliveImage4.color = value;
			}
		}
	}

	public Color ReliveColor5
	{
		get
		{
			if (_oReliveImage5 != null)
			{
				return _oReliveImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor5 != value && _oReliveImage5 != null)
			{
				_oReliveImage5.color = value;
			}
		}
	}

	public Color ReliveColor6
	{
		get
		{
			if (_oReliveImage6 != null)
			{
				return _oReliveImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor6 != value && _oReliveImage6 != null)
			{
				_oReliveImage6.color = value;
			}
		}
	}

	public Color ReliveColor7
	{
		get
		{
			if (_oReliveImage7 != null)
			{
				return _oReliveImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor7 != value && _oReliveImage7 != null)
			{
				_oReliveImage7.color = value;
			}
		}
	}

	public Color ReliveColor8
	{
		get
		{
			if (_oReliveImage8 != null)
			{
				return _oReliveImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (ReliveColor8 != value && _oReliveImage8 != null)
			{
				_oReliveImage8.color = value;
			}
		}
	}

	public bool KillCountBackShow1
	{
		get
		{
			if (_oKillCountBack1 != null)
			{
				return _oKillCountBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow1 != value && _oKillCountBack1 != null)
			{
				_oKillCountBack1.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow2
	{
		get
		{
			if (_oKillCountBack2 != null)
			{
				return _oKillCountBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow2 != value && _oKillCountBack2 != null)
			{
				_oKillCountBack2.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow3
	{
		get
		{
			if (_oKillCountBack3 != null)
			{
				return _oKillCountBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow3 != value && _oKillCountBack3 != null)
			{
				_oKillCountBack3.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow4
	{
		get
		{
			if (_oKillCountBack4 != null)
			{
				return _oKillCountBack4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow4 != value && _oKillCountBack4 != null)
			{
				_oKillCountBack4.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow5
	{
		get
		{
			if (_oKillCountBack5 != null)
			{
				return _oKillCountBack5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow5 != value && _oKillCountBack5 != null)
			{
				_oKillCountBack5.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow6
	{
		get
		{
			if (_oKillCountBack6 != null)
			{
				return _oKillCountBack6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow6 != value && _oKillCountBack6 != null)
			{
				_oKillCountBack6.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow7
	{
		get
		{
			if (_oKillCountBack7 != null)
			{
				return _oKillCountBack7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow7 != value && _oKillCountBack7 != null)
			{
				_oKillCountBack7.SetObjectActive(value);
			}
		}
	}

	public bool KillCountBackShow8
	{
		get
		{
			if (_oKillCountBack8 != null)
			{
				return _oKillCountBack8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountBackShow8 != value && _oKillCountBack8 != null)
			{
				_oKillCountBack8.SetObjectActive(value);
			}
		}
	}

	public Sprite KillCountBackSprite1
	{
		get
		{
			if (_oKillCountBackImage1 != null)
			{
				return _oKillCountBackImage1.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite1 != value && _oKillCountBackImage1 != null)
			{
				_oKillCountBackImage1.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite2
	{
		get
		{
			if (_oKillCountBackImage2 != null)
			{
				return _oKillCountBackImage2.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite2 != value && _oKillCountBackImage2 != null)
			{
				_oKillCountBackImage2.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite3
	{
		get
		{
			if (_oKillCountBackImage3 != null)
			{
				return _oKillCountBackImage3.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite3 != value && _oKillCountBackImage3 != null)
			{
				_oKillCountBackImage3.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite4
	{
		get
		{
			if (_oKillCountBackImage4 != null)
			{
				return _oKillCountBackImage4.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite4 != value && _oKillCountBackImage4 != null)
			{
				_oKillCountBackImage4.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite5
	{
		get
		{
			if (_oKillCountBackImage5 != null)
			{
				return _oKillCountBackImage5.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite5 != value && _oKillCountBackImage5 != null)
			{
				_oKillCountBackImage5.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite6
	{
		get
		{
			if (_oKillCountBackImage6 != null)
			{
				return _oKillCountBackImage6.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite6 != value && _oKillCountBackImage6 != null)
			{
				_oKillCountBackImage6.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite7
	{
		get
		{
			if (_oKillCountBackImage7 != null)
			{
				return _oKillCountBackImage7.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite7 != value && _oKillCountBackImage7 != null)
			{
				_oKillCountBackImage7.sprite = value;
			}
		}
	}

	public Sprite KillCountBackSprite8
	{
		get
		{
			if (_oKillCountBackImage8 != null)
			{
				return _oKillCountBackImage8.sprite;
			}
			return null;
		}
		set
		{
			if (KillCountBackSprite8 != value && _oKillCountBackImage8 != null)
			{
				_oKillCountBackImage8.sprite = value;
			}
		}
	}

	public string KillCountString1
	{
		get
		{
			if (_oKillCountText1 != null)
			{
				return _oKillCountText1.text;
			}
			return null;
		}
		set
		{
			if (KillCountString1 != value && _oKillCountText1 != null)
			{
				_oKillCountText1.text = value;
			}
		}
	}

	public string KillCountString2
	{
		get
		{
			if (_oKillCountText2 != null)
			{
				return _oKillCountText2.text;
			}
			return null;
		}
		set
		{
			if (KillCountString2 != value && _oKillCountText2 != null)
			{
				_oKillCountText2.text = value;
			}
		}
	}

	public string KillCountString3
	{
		get
		{
			if (_oKillCountText3 != null)
			{
				return _oKillCountText3.text;
			}
			return null;
		}
		set
		{
			if (KillCountString3 != value && _oKillCountText3 != null)
			{
				_oKillCountText3.text = value;
			}
		}
	}

	public string KillCountString4
	{
		get
		{
			if (_oKillCountText4 != null)
			{
				return _oKillCountText4.text;
			}
			return null;
		}
		set
		{
			if (KillCountString4 != value && _oKillCountText4 != null)
			{
				_oKillCountText4.text = value;
			}
		}
	}

	public string KillCountString5
	{
		get
		{
			if (_oKillCountText5 != null)
			{
				return _oKillCountText5.text;
			}
			return null;
		}
		set
		{
			if (KillCountString5 != value && _oKillCountText5 != null)
			{
				_oKillCountText5.text = value;
			}
		}
	}

	public string KillCountString6
	{
		get
		{
			if (_oKillCountText6 != null)
			{
				return _oKillCountText6.text;
			}
			return null;
		}
		set
		{
			if (KillCountString6 != value && _oKillCountText6 != null)
			{
				_oKillCountText6.text = value;
			}
		}
	}

	public string KillCountString7
	{
		get
		{
			if (_oKillCountText7 != null)
			{
				return _oKillCountText7.text;
			}
			return null;
		}
		set
		{
			if (KillCountString7 != value && _oKillCountText7 != null)
			{
				_oKillCountText7.text = value;
			}
		}
	}

	public string KillCountString8
	{
		get
		{
			if (_oKillCountText8 != null)
			{
				return _oKillCountText8.text;
			}
			return null;
		}
		set
		{
			if (KillCountString8 != value && _oKillCountText8 != null)
			{
				_oKillCountText8.text = value;
			}
		}
	}

	public bool GloryAShow1
	{
		get
		{
			if (_oGloryA1 != null)
			{
				return _oGloryA1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow1 != value && _oGloryA1 != null)
			{
				_oGloryA1.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow2
	{
		get
		{
			if (_oGloryA2 != null)
			{
				return _oGloryA2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow2 != value && _oGloryA2 != null)
			{
				_oGloryA2.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow3
	{
		get
		{
			if (_oGloryA3 != null)
			{
				return _oGloryA3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow3 != value && _oGloryA3 != null)
			{
				_oGloryA3.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow4
	{
		get
		{
			if (_oGloryA4 != null)
			{
				return _oGloryA4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow4 != value && _oGloryA4 != null)
			{
				_oGloryA4.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow5
	{
		get
		{
			if (_oGloryA5 != null)
			{
				return _oGloryA5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow5 != value && _oGloryA5 != null)
			{
				_oGloryA5.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow6
	{
		get
		{
			if (_oGloryA6 != null)
			{
				return _oGloryA6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow6 != value && _oGloryA6 != null)
			{
				_oGloryA6.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow7
	{
		get
		{
			if (_oGloryA7 != null)
			{
				return _oGloryA7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow7 != value && _oGloryA7 != null)
			{
				_oGloryA7.SetObjectActive(value);
			}
		}
	}

	public bool GloryAShow8
	{
		get
		{
			if (_oGloryA8 != null)
			{
				return _oGloryA8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryAShow8 != value && _oGloryA8 != null)
			{
				_oGloryA8.SetObjectActive(value);
			}
		}
	}

	public Sprite GloryASprite1
	{
		get
		{
			if (_oGloryAImage1 != null)
			{
				return _oGloryAImage1.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite1 != value && _oGloryAImage1 != null)
			{
				_oGloryAImage1.sprite = value;
			}
		}
	}

	public Sprite GloryASprite2
	{
		get
		{
			if (_oGloryAImage2 != null)
			{
				return _oGloryAImage2.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite2 != value && _oGloryAImage2 != null)
			{
				_oGloryAImage2.sprite = value;
			}
		}
	}

	public Sprite GloryASprite3
	{
		get
		{
			if (_oGloryAImage3 != null)
			{
				return _oGloryAImage3.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite3 != value && _oGloryAImage3 != null)
			{
				_oGloryAImage3.sprite = value;
			}
		}
	}

	public Sprite GloryASprite4
	{
		get
		{
			if (_oGloryAImage4 != null)
			{
				return _oGloryAImage4.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite4 != value && _oGloryAImage4 != null)
			{
				_oGloryAImage4.sprite = value;
			}
		}
	}

	public Sprite GloryASprite5
	{
		get
		{
			if (_oGloryAImage5 != null)
			{
				return _oGloryAImage5.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite5 != value && _oGloryAImage5 != null)
			{
				_oGloryAImage5.sprite = value;
			}
		}
	}

	public Sprite GloryASprite6
	{
		get
		{
			if (_oGloryAImage6 != null)
			{
				return _oGloryAImage6.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite6 != value && _oGloryAImage6 != null)
			{
				_oGloryAImage6.sprite = value;
			}
		}
	}

	public Sprite GloryASprite7
	{
		get
		{
			if (_oGloryAImage7 != null)
			{
				return _oGloryAImage7.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite7 != value && _oGloryAImage7 != null)
			{
				_oGloryAImage7.sprite = value;
			}
		}
	}

	public Sprite GloryASprite8
	{
		get
		{
			if (_oGloryAImage8 != null)
			{
				return _oGloryAImage8.sprite;
			}
			return null;
		}
		set
		{
			if (GloryASprite8 != value && _oGloryAImage8 != null)
			{
				_oGloryAImage8.sprite = value;
			}
		}
	}

	public bool GloryBShow1
	{
		get
		{
			if (_oGloryB1 != null)
			{
				return _oGloryB1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow1 != value && _oGloryB1 != null)
			{
				_oGloryB1.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow2
	{
		get
		{
			if (_oGloryB2 != null)
			{
				return _oGloryB2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow2 != value && _oGloryB2 != null)
			{
				_oGloryB2.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow3
	{
		get
		{
			if (_oGloryB3 != null)
			{
				return _oGloryB3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow3 != value && _oGloryB3 != null)
			{
				_oGloryB3.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow4
	{
		get
		{
			if (_oGloryB4 != null)
			{
				return _oGloryB4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow4 != value && _oGloryB4 != null)
			{
				_oGloryB4.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow5
	{
		get
		{
			if (_oGloryB5 != null)
			{
				return _oGloryB5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow5 != value && _oGloryB5 != null)
			{
				_oGloryB5.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow6
	{
		get
		{
			if (_oGloryB6 != null)
			{
				return _oGloryB6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow6 != value && _oGloryB6 != null)
			{
				_oGloryB6.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow7
	{
		get
		{
			if (_oGloryB7 != null)
			{
				return _oGloryB7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow7 != value && _oGloryB7 != null)
			{
				_oGloryB7.SetObjectActive(value);
			}
		}
	}

	public bool GloryBShow8
	{
		get
		{
			if (_oGloryB8 != null)
			{
				return _oGloryB8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryBShow8 != value && _oGloryB8 != null)
			{
				_oGloryB8.SetObjectActive(value);
			}
		}
	}

	public Sprite GloryBSprite1
	{
		get
		{
			if (_oGloryBImage1 != null)
			{
				return _oGloryBImage1.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite1 != value && _oGloryBImage1 != null)
			{
				_oGloryBImage1.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite2
	{
		get
		{
			if (_oGloryBImage2 != null)
			{
				return _oGloryBImage2.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite2 != value && _oGloryBImage2 != null)
			{
				_oGloryBImage2.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite3
	{
		get
		{
			if (_oGloryBImage3 != null)
			{
				return _oGloryBImage3.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite3 != value && _oGloryBImage3 != null)
			{
				_oGloryBImage3.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite4
	{
		get
		{
			if (_oGloryBImage4 != null)
			{
				return _oGloryBImage4.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite4 != value && _oGloryBImage4 != null)
			{
				_oGloryBImage4.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite5
	{
		get
		{
			if (_oGloryBImage5 != null)
			{
				return _oGloryBImage5.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite5 != value && _oGloryBImage5 != null)
			{
				_oGloryBImage5.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite6
	{
		get
		{
			if (_oGloryBImage6 != null)
			{
				return _oGloryBImage6.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite6 != value && _oGloryBImage6 != null)
			{
				_oGloryBImage6.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite7
	{
		get
		{
			if (_oGloryBImage7 != null)
			{
				return _oGloryBImage7.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite7 != value && _oGloryBImage7 != null)
			{
				_oGloryBImage7.sprite = value;
			}
		}
	}

	public Sprite GloryBSprite8
	{
		get
		{
			if (_oGloryBImage8 != null)
			{
				return _oGloryBImage8.sprite;
			}
			return null;
		}
		set
		{
			if (GloryBSprite8 != value && _oGloryBImage8 != null)
			{
				_oGloryBImage8.sprite = value;
			}
		}
	}

	public bool GloryCShow1
	{
		get
		{
			if (_oGloryC1 != null)
			{
				return _oGloryC1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow1 != value && _oGloryC1 != null)
			{
				_oGloryC1.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow2
	{
		get
		{
			if (_oGloryC2 != null)
			{
				return _oGloryC2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow2 != value && _oGloryC2 != null)
			{
				_oGloryC2.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow3
	{
		get
		{
			if (_oGloryC3 != null)
			{
				return _oGloryC3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow3 != value && _oGloryC3 != null)
			{
				_oGloryC3.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow4
	{
		get
		{
			if (_oGloryC4 != null)
			{
				return _oGloryC4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow4 != value && _oGloryC4 != null)
			{
				_oGloryC4.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow5
	{
		get
		{
			if (_oGloryC5 != null)
			{
				return _oGloryC5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow5 != value && _oGloryC5 != null)
			{
				_oGloryC5.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow6
	{
		get
		{
			if (_oGloryC6 != null)
			{
				return _oGloryC6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow6 != value && _oGloryC6 != null)
			{
				_oGloryC6.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow7
	{
		get
		{
			if (_oGloryC7 != null)
			{
				return _oGloryC7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow7 != value && _oGloryC7 != null)
			{
				_oGloryC7.SetObjectActive(value);
			}
		}
	}

	public bool GloryCShow8
	{
		get
		{
			if (_oGloryC8 != null)
			{
				return _oGloryC8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryCShow8 != value && _oGloryC8 != null)
			{
				_oGloryC8.SetObjectActive(value);
			}
		}
	}

	public Sprite GloryCSprite1
	{
		get
		{
			if (_oGloryCImage1 != null)
			{
				return _oGloryCImage1.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite1 != value && _oGloryCImage1 != null)
			{
				_oGloryCImage1.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite2
	{
		get
		{
			if (_oGloryCImage2 != null)
			{
				return _oGloryCImage2.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite2 != value && _oGloryCImage2 != null)
			{
				_oGloryCImage2.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite3
	{
		get
		{
			if (_oGloryCImage3 != null)
			{
				return _oGloryCImage3.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite3 != value && _oGloryCImage3 != null)
			{
				_oGloryCImage3.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite4
	{
		get
		{
			if (_oGloryCImage4 != null)
			{
				return _oGloryCImage4.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite4 != value && _oGloryCImage4 != null)
			{
				_oGloryCImage4.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite5
	{
		get
		{
			if (_oGloryCImage5 != null)
			{
				return _oGloryCImage5.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite5 != value && _oGloryCImage5 != null)
			{
				_oGloryCImage5.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite6
	{
		get
		{
			if (_oGloryCImage6 != null)
			{
				return _oGloryCImage6.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite6 != value && _oGloryCImage6 != null)
			{
				_oGloryCImage6.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite7
	{
		get
		{
			if (_oGloryCImage7 != null)
			{
				return _oGloryCImage7.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite7 != value && _oGloryCImage7 != null)
			{
				_oGloryCImage7.sprite = value;
			}
		}
	}

	public Sprite GloryCSprite8
	{
		get
		{
			if (_oGloryCImage8 != null)
			{
				return _oGloryCImage8.sprite;
			}
			return null;
		}
		set
		{
			if (GloryCSprite8 != value && _oGloryCImage8 != null)
			{
				_oGloryCImage8.sprite = value;
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

	public bool AssisterShow1
	{
		get
		{
			if (_oAssister1 != null)
			{
				return _oAssister1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow1 != value && _oAssister1 != null)
			{
				_oAssister1.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow2
	{
		get
		{
			if (_oAssister2 != null)
			{
				return _oAssister2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow2 != value && _oAssister2 != null)
			{
				_oAssister2.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow3
	{
		get
		{
			if (_oAssister3 != null)
			{
				return _oAssister3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow3 != value && _oAssister3 != null)
			{
				_oAssister3.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow4
	{
		get
		{
			if (_oAssister4 != null)
			{
				return _oAssister4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow4 != value && _oAssister4 != null)
			{
				_oAssister4.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow5
	{
		get
		{
			if (_oAssister5 != null)
			{
				return _oAssister5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow5 != value && _oAssister5 != null)
			{
				_oAssister5.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow6
	{
		get
		{
			if (_oAssister6 != null)
			{
				return _oAssister6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow6 != value && _oAssister6 != null)
			{
				_oAssister6.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow7
	{
		get
		{
			if (_oAssister7 != null)
			{
				return _oAssister7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow7 != value && _oAssister7 != null)
			{
				_oAssister7.SetObjectActive(value);
			}
		}
	}

	public bool AssisterShow8
	{
		get
		{
			if (_oAssister8 != null)
			{
				return _oAssister8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssisterShow8 != value && _oAssister8 != null)
			{
				_oAssister8.SetObjectActive(value);
			}
		}
	}

	public string AssisterString1
	{
		get
		{
			if (_oAssisterText1 != null)
			{
				return _oAssisterText1.text;
			}
			return null;
		}
		set
		{
			if (AssisterString1 != value && _oAssisterText1 != null)
			{
				_oAssisterText1.text = value;
			}
		}
	}

	public string AssisterString2
	{
		get
		{
			if (_oAssisterText2 != null)
			{
				return _oAssisterText2.text;
			}
			return null;
		}
		set
		{
			if (AssisterString2 != value && _oAssisterText2 != null)
			{
				_oAssisterText2.text = value;
			}
		}
	}

	public string AssisterString3
	{
		get
		{
			if (_oAssisterText3 != null)
			{
				return _oAssisterText3.text;
			}
			return null;
		}
		set
		{
			if (AssisterString3 != value && _oAssisterText3 != null)
			{
				_oAssisterText3.text = value;
			}
		}
	}

	public string AssisterString4
	{
		get
		{
			if (_oAssisterText4 != null)
			{
				return _oAssisterText4.text;
			}
			return null;
		}
		set
		{
			if (AssisterString4 != value && _oAssisterText4 != null)
			{
				_oAssisterText4.text = value;
			}
		}
	}

	public string AssisterString5
	{
		get
		{
			if (_oAssisterText5 != null)
			{
				return _oAssisterText5.text;
			}
			return null;
		}
		set
		{
			if (AssisterString5 != value && _oAssisterText5 != null)
			{
				_oAssisterText5.text = value;
			}
		}
	}

	public string AssisterString6
	{
		get
		{
			if (_oAssisterText6 != null)
			{
				return _oAssisterText6.text;
			}
			return null;
		}
		set
		{
			if (AssisterString6 != value && _oAssisterText6 != null)
			{
				_oAssisterText6.text = value;
			}
		}
	}

	public string AssisterString7
	{
		get
		{
			if (_oAssisterText7 != null)
			{
				return _oAssisterText7.text;
			}
			return null;
		}
		set
		{
			if (AssisterString7 != value && _oAssisterText7 != null)
			{
				_oAssisterText7.text = value;
			}
		}
	}

	public string AssisterString8
	{
		get
		{
			if (_oAssisterText8 != null)
			{
				return _oAssisterText8.text;
			}
			return null;
		}
		set
		{
			if (AssisterString8 != value && _oAssisterText8 != null)
			{
				_oAssisterText8.text = value;
			}
		}
	}

	public Color AssisterTextcolor1
	{
		get
		{
			if (_oAssisterText1 != null)
			{
				return _oAssisterText1.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor1 != value && _oAssisterText1 != null)
			{
				_oAssisterText1.color = value;
			}
		}
	}

	public Color AssisterTextcolor2
	{
		get
		{
			if (_oAssisterText2 != null)
			{
				return _oAssisterText2.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor2 != value && _oAssisterText2 != null)
			{
				_oAssisterText2.color = value;
			}
		}
	}

	public Color AssisterTextcolor3
	{
		get
		{
			if (_oAssisterText3 != null)
			{
				return _oAssisterText3.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor3 != value && _oAssisterText3 != null)
			{
				_oAssisterText3.color = value;
			}
		}
	}

	public Color AssisterTextcolor4
	{
		get
		{
			if (_oAssisterText4 != null)
			{
				return _oAssisterText4.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor4 != value && _oAssisterText4 != null)
			{
				_oAssisterText4.color = value;
			}
		}
	}

	public Color AssisterTextcolor5
	{
		get
		{
			if (_oAssisterText5 != null)
			{
				return _oAssisterText5.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor5 != value && _oAssisterText5 != null)
			{
				_oAssisterText5.color = value;
			}
		}
	}

	public Color AssisterTextcolor6
	{
		get
		{
			if (_oAssisterText6 != null)
			{
				return _oAssisterText6.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor6 != value && _oAssisterText6 != null)
			{
				_oAssisterText6.color = value;
			}
		}
	}

	public Color AssisterTextcolor7
	{
		get
		{
			if (_oAssisterText7 != null)
			{
				return _oAssisterText7.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor7 != value && _oAssisterText7 != null)
			{
				_oAssisterText7.color = value;
			}
		}
	}

	public Color AssisterTextcolor8
	{
		get
		{
			if (_oAssisterText8 != null)
			{
				return _oAssisterText8.color;
			}
			return Color.white;
		}
		set
		{
			if (AssisterTextcolor8 != value && _oAssisterText8 != null)
			{
				_oAssisterText8.color = value;
			}
		}
	}

	public bool AssistantTypeShow1
	{
		get
		{
			if (_oAssistantType1 != null)
			{
				return _oAssistantType1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow1 != value && _oAssistantType1 != null)
			{
				_oAssistantType1.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow2
	{
		get
		{
			if (_oAssistantType2 != null)
			{
				return _oAssistantType2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow2 != value && _oAssistantType2 != null)
			{
				_oAssistantType2.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow3
	{
		get
		{
			if (_oAssistantType3 != null)
			{
				return _oAssistantType3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow3 != value && _oAssistantType3 != null)
			{
				_oAssistantType3.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow4
	{
		get
		{
			if (_oAssistantType4 != null)
			{
				return _oAssistantType4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow4 != value && _oAssistantType4 != null)
			{
				_oAssistantType4.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow5
	{
		get
		{
			if (_oAssistantType5 != null)
			{
				return _oAssistantType5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow5 != value && _oAssistantType5 != null)
			{
				_oAssistantType5.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow6
	{
		get
		{
			if (_oAssistantType6 != null)
			{
				return _oAssistantType6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow6 != value && _oAssistantType6 != null)
			{
				_oAssistantType6.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow7
	{
		get
		{
			if (_oAssistantType7 != null)
			{
				return _oAssistantType7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow7 != value && _oAssistantType7 != null)
			{
				_oAssistantType7.SetObjectActive(value);
			}
		}
	}

	public bool AssistantTypeShow8
	{
		get
		{
			if (_oAssistantType8 != null)
			{
				return _oAssistantType8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AssistantTypeShow8 != value && _oAssistantType8 != null)
			{
				_oAssistantType8.SetObjectActive(value);
			}
		}
	}

	public Sprite AssistantTypeSprite1
	{
		get
		{
			if (_oAssistantTypeImage1 != null)
			{
				return _oAssistantTypeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite1 != value && _oAssistantTypeImage1 != null)
			{
				_oAssistantTypeImage1.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite2
	{
		get
		{
			if (_oAssistantTypeImage2 != null)
			{
				return _oAssistantTypeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite2 != value && _oAssistantTypeImage2 != null)
			{
				_oAssistantTypeImage2.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite3
	{
		get
		{
			if (_oAssistantTypeImage3 != null)
			{
				return _oAssistantTypeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite3 != value && _oAssistantTypeImage3 != null)
			{
				_oAssistantTypeImage3.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite4
	{
		get
		{
			if (_oAssistantTypeImage4 != null)
			{
				return _oAssistantTypeImage4.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite4 != value && _oAssistantTypeImage4 != null)
			{
				_oAssistantTypeImage4.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite5
	{
		get
		{
			if (_oAssistantTypeImage5 != null)
			{
				return _oAssistantTypeImage5.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite5 != value && _oAssistantTypeImage5 != null)
			{
				_oAssistantTypeImage5.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite6
	{
		get
		{
			if (_oAssistantTypeImage6 != null)
			{
				return _oAssistantTypeImage6.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite6 != value && _oAssistantTypeImage6 != null)
			{
				_oAssistantTypeImage6.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite7
	{
		get
		{
			if (_oAssistantTypeImage7 != null)
			{
				return _oAssistantTypeImage7.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite7 != value && _oAssistantTypeImage7 != null)
			{
				_oAssistantTypeImage7.sprite = value;
			}
		}
	}

	public Sprite AssistantTypeSprite8
	{
		get
		{
			if (_oAssistantTypeImage8 != null)
			{
				return _oAssistantTypeImage8.sprite;
			}
			return null;
		}
		set
		{
			if (AssistantTypeSprite8 != value && _oAssistantTypeImage8 != null)
			{
				_oAssistantTypeImage8.sprite = value;
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

	public bool IconShow1
	{
		get
		{
			if (_oIcon1 != null)
			{
				return _oIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow1 != value && _oIcon1 != null)
			{
				_oIcon1.SetObjectActive(value);
			}
		}
	}

	public bool IconShow2
	{
		get
		{
			if (_oIcon2 != null)
			{
				return _oIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow2 != value && _oIcon2 != null)
			{
				_oIcon2.SetObjectActive(value);
			}
		}
	}

	public bool IconShow3
	{
		get
		{
			if (_oIcon3 != null)
			{
				return _oIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow3 != value && _oIcon3 != null)
			{
				_oIcon3.SetObjectActive(value);
			}
		}
	}

	public bool IconShow4
	{
		get
		{
			if (_oIcon4 != null)
			{
				return _oIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow4 != value && _oIcon4 != null)
			{
				_oIcon4.SetObjectActive(value);
			}
		}
	}

	public bool IconShow5
	{
		get
		{
			if (_oIcon5 != null)
			{
				return _oIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow5 != value && _oIcon5 != null)
			{
				_oIcon5.SetObjectActive(value);
			}
		}
	}

	public bool IconShow6
	{
		get
		{
			if (_oIcon6 != null)
			{
				return _oIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow6 != value && _oIcon6 != null)
			{
				_oIcon6.SetObjectActive(value);
			}
		}
	}

	public bool IconShow7
	{
		get
		{
			if (_oIcon7 != null)
			{
				return _oIcon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow7 != value && _oIcon7 != null)
			{
				_oIcon7.SetObjectActive(value);
			}
		}
	}

	public bool IconShow8
	{
		get
		{
			if (_oIcon8 != null)
			{
				return _oIcon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow8 != value && _oIcon8 != null)
			{
				_oIcon8.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite1 != value && _oIconImage1 != null)
			{
				_oIconImage1.sprite = value;
			}
		}
	}

	public Sprite IconSprite2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite2 != value && _oIconImage2 != null)
			{
				_oIconImage2.sprite = value;
			}
		}
	}

	public Sprite IconSprite3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite3 != value && _oIconImage3 != null)
			{
				_oIconImage3.sprite = value;
			}
		}
	}

	public Sprite IconSprite4
	{
		get
		{
			if (_oIconImage4 != null)
			{
				return _oIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite4 != value && _oIconImage4 != null)
			{
				_oIconImage4.sprite = value;
			}
		}
	}

	public Sprite IconSprite5
	{
		get
		{
			if (_oIconImage5 != null)
			{
				return _oIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite5 != value && _oIconImage5 != null)
			{
				_oIconImage5.sprite = value;
			}
		}
	}

	public Sprite IconSprite6
	{
		get
		{
			if (_oIconImage6 != null)
			{
				return _oIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite6 != value && _oIconImage6 != null)
			{
				_oIconImage6.sprite = value;
			}
		}
	}

	public Sprite IconSprite7
	{
		get
		{
			if (_oIconImage7 != null)
			{
				return _oIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite7 != value && _oIconImage7 != null)
			{
				_oIconImage7.sprite = value;
			}
		}
	}

	public Sprite IconSprite8
	{
		get
		{
			if (_oIconImage8 != null)
			{
				return _oIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite8 != value && _oIconImage8 != null)
			{
				_oIconImage8.sprite = value;
			}
		}
	}

	public bool PermanentShow1
	{
		get
		{
			if (_oPermanent1 != null)
			{
				return _oPermanent1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow1 != value && _oPermanent1 != null)
			{
				_oPermanent1.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow2
	{
		get
		{
			if (_oPermanent2 != null)
			{
				return _oPermanent2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow2 != value && _oPermanent2 != null)
			{
				_oPermanent2.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow3
	{
		get
		{
			if (_oPermanent3 != null)
			{
				return _oPermanent3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow3 != value && _oPermanent3 != null)
			{
				_oPermanent3.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow4
	{
		get
		{
			if (_oPermanent4 != null)
			{
				return _oPermanent4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow4 != value && _oPermanent4 != null)
			{
				_oPermanent4.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow5
	{
		get
		{
			if (_oPermanent5 != null)
			{
				return _oPermanent5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow5 != value && _oPermanent5 != null)
			{
				_oPermanent5.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow6
	{
		get
		{
			if (_oPermanent6 != null)
			{
				return _oPermanent6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow6 != value && _oPermanent6 != null)
			{
				_oPermanent6.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow7
	{
		get
		{
			if (_oPermanent7 != null)
			{
				return _oPermanent7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow7 != value && _oPermanent7 != null)
			{
				_oPermanent7.SetObjectActive(value);
			}
		}
	}

	public bool PermanentShow8
	{
		get
		{
			if (_oPermanent8 != null)
			{
				return _oPermanent8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PermanentShow8 != value && _oPermanent8 != null)
			{
				_oPermanent8.SetObjectActive(value);
			}
		}
	}

	public Sprite PermanentSprite1
	{
		get
		{
			if (_oPermanentImage1 != null)
			{
				return _oPermanentImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite1 != value && _oPermanentImage1 != null)
			{
				_oPermanentImage1.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite2
	{
		get
		{
			if (_oPermanentImage2 != null)
			{
				return _oPermanentImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite2 != value && _oPermanentImage2 != null)
			{
				_oPermanentImage2.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite3
	{
		get
		{
			if (_oPermanentImage3 != null)
			{
				return _oPermanentImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite3 != value && _oPermanentImage3 != null)
			{
				_oPermanentImage3.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite4
	{
		get
		{
			if (_oPermanentImage4 != null)
			{
				return _oPermanentImage4.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite4 != value && _oPermanentImage4 != null)
			{
				_oPermanentImage4.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite5
	{
		get
		{
			if (_oPermanentImage5 != null)
			{
				return _oPermanentImage5.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite5 != value && _oPermanentImage5 != null)
			{
				_oPermanentImage5.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite6
	{
		get
		{
			if (_oPermanentImage6 != null)
			{
				return _oPermanentImage6.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite6 != value && _oPermanentImage6 != null)
			{
				_oPermanentImage6.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite7
	{
		get
		{
			if (_oPermanentImage7 != null)
			{
				return _oPermanentImage7.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite7 != value && _oPermanentImage7 != null)
			{
				_oPermanentImage7.sprite = value;
			}
		}
	}

	public Sprite PermanentSprite8
	{
		get
		{
			if (_oPermanentImage8 != null)
			{
				return _oPermanentImage8.sprite;
			}
			return null;
		}
		set
		{
			if (PermanentSprite8 != value && _oPermanentImage8 != null)
			{
				_oPermanentImage8.sprite = value;
			}
		}
	}

	public bool NameShow1
	{
		get
		{
			if (_oName1 != null)
			{
				return _oName1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow1 != value && _oName1 != null)
			{
				_oName1.SetObjectActive(value);
			}
		}
	}

	public bool NameShow2
	{
		get
		{
			if (_oName2 != null)
			{
				return _oName2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow2 != value && _oName2 != null)
			{
				_oName2.SetObjectActive(value);
			}
		}
	}

	public bool NameShow3
	{
		get
		{
			if (_oName3 != null)
			{
				return _oName3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow3 != value && _oName3 != null)
			{
				_oName3.SetObjectActive(value);
			}
		}
	}

	public bool NameShow4
	{
		get
		{
			if (_oName4 != null)
			{
				return _oName4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow4 != value && _oName4 != null)
			{
				_oName4.SetObjectActive(value);
			}
		}
	}

	public bool NameShow5
	{
		get
		{
			if (_oName5 != null)
			{
				return _oName5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow5 != value && _oName5 != null)
			{
				_oName5.SetObjectActive(value);
			}
		}
	}

	public bool NameShow6
	{
		get
		{
			if (_oName6 != null)
			{
				return _oName6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow6 != value && _oName6 != null)
			{
				_oName6.SetObjectActive(value);
			}
		}
	}

	public bool NameShow7
	{
		get
		{
			if (_oName7 != null)
			{
				return _oName7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow7 != value && _oName7 != null)
			{
				_oName7.SetObjectActive(value);
			}
		}
	}

	public bool NameShow8
	{
		get
		{
			if (_oName8 != null)
			{
				return _oName8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow8 != value && _oName8 != null)
			{
				_oName8.SetObjectActive(value);
			}
		}
	}

	public Sprite NameSprite1
	{
		get
		{
			if (_oNameImage1 != null)
			{
				return _oNameImage1.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite1 != value && _oNameImage1 != null)
			{
				_oNameImage1.sprite = value;
			}
		}
	}

	public Sprite NameSprite2
	{
		get
		{
			if (_oNameImage2 != null)
			{
				return _oNameImage2.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite2 != value && _oNameImage2 != null)
			{
				_oNameImage2.sprite = value;
			}
		}
	}

	public Sprite NameSprite3
	{
		get
		{
			if (_oNameImage3 != null)
			{
				return _oNameImage3.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite3 != value && _oNameImage3 != null)
			{
				_oNameImage3.sprite = value;
			}
		}
	}

	public Sprite NameSprite4
	{
		get
		{
			if (_oNameImage4 != null)
			{
				return _oNameImage4.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite4 != value && _oNameImage4 != null)
			{
				_oNameImage4.sprite = value;
			}
		}
	}

	public Sprite NameSprite5
	{
		get
		{
			if (_oNameImage5 != null)
			{
				return _oNameImage5.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite5 != value && _oNameImage5 != null)
			{
				_oNameImage5.sprite = value;
			}
		}
	}

	public Sprite NameSprite6
	{
		get
		{
			if (_oNameImage6 != null)
			{
				return _oNameImage6.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite6 != value && _oNameImage6 != null)
			{
				_oNameImage6.sprite = value;
			}
		}
	}

	public Sprite NameSprite7
	{
		get
		{
			if (_oNameImage7 != null)
			{
				return _oNameImage7.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite7 != value && _oNameImage7 != null)
			{
				_oNameImage7.sprite = value;
			}
		}
	}

	public Sprite NameSprite8
	{
		get
		{
			if (_oNameImage8 != null)
			{
				return _oNameImage8.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite8 != value && _oNameImage8 != null)
			{
				_oNameImage8.sprite = value;
			}
		}
	}

	public bool LabelShow1
	{
		get
		{
			if (_oLabel1 != null)
			{
				return _oLabel1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow1 != value && _oLabel1 != null)
			{
				_oLabel1.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow2
	{
		get
		{
			if (_oLabel2 != null)
			{
				return _oLabel2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow2 != value && _oLabel2 != null)
			{
				_oLabel2.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow3
	{
		get
		{
			if (_oLabel3 != null)
			{
				return _oLabel3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow3 != value && _oLabel3 != null)
			{
				_oLabel3.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow4
	{
		get
		{
			if (_oLabel4 != null)
			{
				return _oLabel4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow4 != value && _oLabel4 != null)
			{
				_oLabel4.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow5
	{
		get
		{
			if (_oLabel5 != null)
			{
				return _oLabel5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow5 != value && _oLabel5 != null)
			{
				_oLabel5.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow6
	{
		get
		{
			if (_oLabel6 != null)
			{
				return _oLabel6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow6 != value && _oLabel6 != null)
			{
				_oLabel6.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow7
	{
		get
		{
			if (_oLabel7 != null)
			{
				return _oLabel7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow7 != value && _oLabel7 != null)
			{
				_oLabel7.SetObjectActive(value);
			}
		}
	}

	public bool LabelShow8
	{
		get
		{
			if (_oLabel8 != null)
			{
				return _oLabel8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LabelShow8 != value && _oLabel8 != null)
			{
				_oLabel8.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow1
	{
		get
		{
			if (_oModeKillBack1 != null)
			{
				return _oModeKillBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow1 != value && _oModeKillBack1 != null)
			{
				_oModeKillBack1.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow2
	{
		get
		{
			if (_oModeKillBack2 != null)
			{
				return _oModeKillBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow2 != value && _oModeKillBack2 != null)
			{
				_oModeKillBack2.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow3
	{
		get
		{
			if (_oModeKillBack3 != null)
			{
				return _oModeKillBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow3 != value && _oModeKillBack3 != null)
			{
				_oModeKillBack3.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow4
	{
		get
		{
			if (_oModeKillBack4 != null)
			{
				return _oModeKillBack4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow4 != value && _oModeKillBack4 != null)
			{
				_oModeKillBack4.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow5
	{
		get
		{
			if (_oModeKillBack5 != null)
			{
				return _oModeKillBack5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow5 != value && _oModeKillBack5 != null)
			{
				_oModeKillBack5.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow6
	{
		get
		{
			if (_oModeKillBack6 != null)
			{
				return _oModeKillBack6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow6 != value && _oModeKillBack6 != null)
			{
				_oModeKillBack6.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow7
	{
		get
		{
			if (_oModeKillBack7 != null)
			{
				return _oModeKillBack7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow7 != value && _oModeKillBack7 != null)
			{
				_oModeKillBack7.SetObjectActive(value);
			}
		}
	}

	public bool ModeKillBackShow8
	{
		get
		{
			if (_oModeKillBack8 != null)
			{
				return _oModeKillBack8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeKillBackShow8 != value && _oModeKillBack8 != null)
			{
				_oModeKillBack8.SetObjectActive(value);
			}
		}
	}

	public string ModeKillCountString1
	{
		get
		{
			if (_oModeKillCountText1 != null)
			{
				return _oModeKillCountText1.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString1 != value && _oModeKillCountText1 != null)
			{
				_oModeKillCountText1.text = value;
			}
		}
	}

	public string ModeKillCountString2
	{
		get
		{
			if (_oModeKillCountText2 != null)
			{
				return _oModeKillCountText2.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString2 != value && _oModeKillCountText2 != null)
			{
				_oModeKillCountText2.text = value;
			}
		}
	}

	public string ModeKillCountString3
	{
		get
		{
			if (_oModeKillCountText3 != null)
			{
				return _oModeKillCountText3.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString3 != value && _oModeKillCountText3 != null)
			{
				_oModeKillCountText3.text = value;
			}
		}
	}

	public string ModeKillCountString4
	{
		get
		{
			if (_oModeKillCountText4 != null)
			{
				return _oModeKillCountText4.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString4 != value && _oModeKillCountText4 != null)
			{
				_oModeKillCountText4.text = value;
			}
		}
	}

	public string ModeKillCountString5
	{
		get
		{
			if (_oModeKillCountText5 != null)
			{
				return _oModeKillCountText5.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString5 != value && _oModeKillCountText5 != null)
			{
				_oModeKillCountText5.text = value;
			}
		}
	}

	public string ModeKillCountString6
	{
		get
		{
			if (_oModeKillCountText6 != null)
			{
				return _oModeKillCountText6.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString6 != value && _oModeKillCountText6 != null)
			{
				_oModeKillCountText6.text = value;
			}
		}
	}

	public string ModeKillCountString7
	{
		get
		{
			if (_oModeKillCountText7 != null)
			{
				return _oModeKillCountText7.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString7 != value && _oModeKillCountText7 != null)
			{
				_oModeKillCountText7.text = value;
			}
		}
	}

	public string ModeKillCountString8
	{
		get
		{
			if (_oModeKillCountText8 != null)
			{
				return _oModeKillCountText8.text;
			}
			return null;
		}
		set
		{
			if (ModeKillCountString8 != value && _oModeKillCountText8 != null)
			{
				_oModeKillCountText8.text = value;
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
			case "Relive1":
				_oRelive1 = transform.gameObject;
				_oReliveImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive2":
				_oRelive2 = transform.gameObject;
				_oReliveImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive3":
				_oRelive3 = transform.gameObject;
				_oReliveImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive4":
				_oRelive4 = transform.gameObject;
				_oReliveImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive5":
				_oRelive5 = transform.gameObject;
				_oReliveImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive6":
				_oRelive6 = transform.gameObject;
				_oReliveImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive7":
				_oRelive7 = transform.gameObject;
				_oReliveImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Relive8":
				_oRelive8 = transform.gameObject;
				_oReliveImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack1":
				_oKillCountBack1 = transform.gameObject;
				_oKillCountBackImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack2":
				_oKillCountBack2 = transform.gameObject;
				_oKillCountBackImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack3":
				_oKillCountBack3 = transform.gameObject;
				_oKillCountBackImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack4":
				_oKillCountBack4 = transform.gameObject;
				_oKillCountBackImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack5":
				_oKillCountBack5 = transform.gameObject;
				_oKillCountBackImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack6":
				_oKillCountBack6 = transform.gameObject;
				_oKillCountBackImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack7":
				_oKillCountBack7 = transform.gameObject;
				_oKillCountBackImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCountBack8":
				_oKillCountBack8 = transform.gameObject;
				_oKillCountBackImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCount1":
				_oKillCount1 = transform.gameObject;
				_oKillCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount2":
				_oKillCount2 = transform.gameObject;
				_oKillCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount3":
				_oKillCount3 = transform.gameObject;
				_oKillCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount4":
				_oKillCount4 = transform.gameObject;
				_oKillCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount5":
				_oKillCount5 = transform.gameObject;
				_oKillCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount6":
				_oKillCount6 = transform.gameObject;
				_oKillCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount7":
				_oKillCount7 = transform.gameObject;
				_oKillCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillCount8":
				_oKillCount8 = transform.gameObject;
				_oKillCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "GloryA1":
				_oGloryA1 = transform.gameObject;
				_oGloryAImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA2":
				_oGloryA2 = transform.gameObject;
				_oGloryAImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA3":
				_oGloryA3 = transform.gameObject;
				_oGloryAImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA4":
				_oGloryA4 = transform.gameObject;
				_oGloryAImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA5":
				_oGloryA5 = transform.gameObject;
				_oGloryAImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA6":
				_oGloryA6 = transform.gameObject;
				_oGloryAImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA7":
				_oGloryA7 = transform.gameObject;
				_oGloryAImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryA8":
				_oGloryA8 = transform.gameObject;
				_oGloryAImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB1":
				_oGloryB1 = transform.gameObject;
				_oGloryBImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB2":
				_oGloryB2 = transform.gameObject;
				_oGloryBImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB3":
				_oGloryB3 = transform.gameObject;
				_oGloryBImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB4":
				_oGloryB4 = transform.gameObject;
				_oGloryBImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB5":
				_oGloryB5 = transform.gameObject;
				_oGloryBImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB6":
				_oGloryB6 = transform.gameObject;
				_oGloryBImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB7":
				_oGloryB7 = transform.gameObject;
				_oGloryBImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryB8":
				_oGloryB8 = transform.gameObject;
				_oGloryBImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC1":
				_oGloryC1 = transform.gameObject;
				_oGloryCImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC2":
				_oGloryC2 = transform.gameObject;
				_oGloryCImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC3":
				_oGloryC3 = transform.gameObject;
				_oGloryCImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC4":
				_oGloryC4 = transform.gameObject;
				_oGloryCImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC5":
				_oGloryC5 = transform.gameObject;
				_oGloryCImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC6":
				_oGloryC6 = transform.gameObject;
				_oGloryCImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC7":
				_oGloryC7 = transform.gameObject;
				_oGloryCImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "GloryC8":
				_oGloryC8 = transform.gameObject;
				_oGloryCImage8 = transform.gameObject.GetComponent<Image>();
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
			case "Assister1":
				_oAssister1 = transform.gameObject;
				_oAssisterText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister2":
				_oAssister2 = transform.gameObject;
				_oAssisterText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister3":
				_oAssister3 = transform.gameObject;
				_oAssisterText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister4":
				_oAssister4 = transform.gameObject;
				_oAssisterText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister5":
				_oAssister5 = transform.gameObject;
				_oAssisterText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister6":
				_oAssister6 = transform.gameObject;
				_oAssisterText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister7":
				_oAssister7 = transform.gameObject;
				_oAssisterText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Assister8":
				_oAssister8 = transform.gameObject;
				_oAssisterText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "AssistantType1":
				_oAssistantType1 = transform.gameObject;
				_oAssistantTypeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType2":
				_oAssistantType2 = transform.gameObject;
				_oAssistantTypeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType3":
				_oAssistantType3 = transform.gameObject;
				_oAssistantTypeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType4":
				_oAssistantType4 = transform.gameObject;
				_oAssistantTypeImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType5":
				_oAssistantType5 = transform.gameObject;
				_oAssistantTypeImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType6":
				_oAssistantType6 = transform.gameObject;
				_oAssistantTypeImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType7":
				_oAssistantType7 = transform.gameObject;
				_oAssistantTypeImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "AssistantType8":
				_oAssistantType8 = transform.gameObject;
				_oAssistantTypeImage8 = transform.gameObject.GetComponent<Image>();
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
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				_oIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon4":
				_oIcon4 = transform.gameObject;
				_oIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon5":
				_oIcon5 = transform.gameObject;
				_oIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon6":
				_oIcon6 = transform.gameObject;
				_oIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon7":
				_oIcon7 = transform.gameObject;
				_oIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon8":
				_oIcon8 = transform.gameObject;
				_oIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent1":
				_oPermanent1 = transform.gameObject;
				_oPermanentImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent2":
				_oPermanent2 = transform.gameObject;
				_oPermanentImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent3":
				_oPermanent3 = transform.gameObject;
				_oPermanentImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent4":
				_oPermanent4 = transform.gameObject;
				_oPermanentImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent5":
				_oPermanent5 = transform.gameObject;
				_oPermanentImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent6":
				_oPermanent6 = transform.gameObject;
				_oPermanentImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent7":
				_oPermanent7 = transform.gameObject;
				_oPermanentImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Permanent8":
				_oPermanent8 = transform.gameObject;
				_oPermanentImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name1":
				_oName1 = transform.gameObject;
				_oNameImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name2":
				_oName2 = transform.gameObject;
				_oNameImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name3":
				_oName3 = transform.gameObject;
				_oNameImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name4":
				_oName4 = transform.gameObject;
				_oNameImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name5":
				_oName5 = transform.gameObject;
				_oNameImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name6":
				_oName6 = transform.gameObject;
				_oNameImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name7":
				_oName7 = transform.gameObject;
				_oNameImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name8":
				_oName8 = transform.gameObject;
				_oNameImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Label1":
				_oLabel1 = transform.gameObject;
				break;
			case "Label2":
				_oLabel2 = transform.gameObject;
				break;
			case "Label3":
				_oLabel3 = transform.gameObject;
				break;
			case "Label4":
				_oLabel4 = transform.gameObject;
				break;
			case "Label5":
				_oLabel5 = transform.gameObject;
				break;
			case "Label6":
				_oLabel6 = transform.gameObject;
				break;
			case "Label7":
				_oLabel7 = transform.gameObject;
				break;
			case "Label8":
				_oLabel8 = transform.gameObject;
				break;
			case "ModeKillBack1":
				_oModeKillBack1 = transform.gameObject;
				break;
			case "ModeKillBack2":
				_oModeKillBack2 = transform.gameObject;
				break;
			case "ModeKillBack3":
				_oModeKillBack3 = transform.gameObject;
				break;
			case "ModeKillBack4":
				_oModeKillBack4 = transform.gameObject;
				break;
			case "ModeKillBack5":
				_oModeKillBack5 = transform.gameObject;
				break;
			case "ModeKillBack6":
				_oModeKillBack6 = transform.gameObject;
				break;
			case "ModeKillBack7":
				_oModeKillBack7 = transform.gameObject;
				break;
			case "ModeKillBack8":
				_oModeKillBack8 = transform.gameObject;
				break;
			case "ModeKillCount1":
				_oModeKillCount1 = transform.gameObject;
				_oModeKillCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount2":
				_oModeKillCount2 = transform.gameObject;
				_oModeKillCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount3":
				_oModeKillCount3 = transform.gameObject;
				_oModeKillCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount4":
				_oModeKillCount4 = transform.gameObject;
				_oModeKillCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount5":
				_oModeKillCount5 = transform.gameObject;
				_oModeKillCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount6":
				_oModeKillCount6 = transform.gameObject;
				_oModeKillCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount7":
				_oModeKillCount7 = transform.gameObject;
				_oModeKillCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "ModeKillCount8":
				_oModeKillCount8 = transform.gameObject;
				_oModeKillCountText8 = transform.gameObject.GetComponent<Text>();
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

	public int GetMessageCount()
	{
		return 8;
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

	public bool GetReliveShow(int index)
	{
		return index switch
		{
			1 => ReliveShow1, 
			2 => ReliveShow2, 
			3 => ReliveShow3, 
			4 => ReliveShow4, 
			5 => ReliveShow5, 
			6 => ReliveShow6, 
			7 => ReliveShow7, 
			8 => ReliveShow8, 
			_ => false, 
		};
	}

	public void SetReliveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ReliveShow1 = value;
			break;
		case 2:
			ReliveShow2 = value;
			break;
		case 3:
			ReliveShow3 = value;
			break;
		case 4:
			ReliveShow4 = value;
			break;
		case 5:
			ReliveShow5 = value;
			break;
		case 6:
			ReliveShow6 = value;
			break;
		case 7:
			ReliveShow7 = value;
			break;
		case 8:
			ReliveShow8 = value;
			break;
		}
	}

	public int GetReliveCount()
	{
		return 8;
	}

	public Color GetReliveColor(int index)
	{
		return index switch
		{
			1 => ReliveColor1, 
			2 => ReliveColor2, 
			3 => ReliveColor3, 
			4 => ReliveColor4, 
			5 => ReliveColor5, 
			6 => ReliveColor6, 
			7 => ReliveColor7, 
			8 => ReliveColor8, 
			_ => Color.white, 
		};
	}

	public void SetReliveColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			ReliveColor1 = value;
			break;
		case 2:
			ReliveColor2 = value;
			break;
		case 3:
			ReliveColor3 = value;
			break;
		case 4:
			ReliveColor4 = value;
			break;
		case 5:
			ReliveColor5 = value;
			break;
		case 6:
			ReliveColor6 = value;
			break;
		case 7:
			ReliveColor7 = value;
			break;
		case 8:
			ReliveColor8 = value;
			break;
		}
	}

	public bool GetKillCountBackShow(int index)
	{
		return index switch
		{
			1 => KillCountBackShow1, 
			2 => KillCountBackShow2, 
			3 => KillCountBackShow3, 
			4 => KillCountBackShow4, 
			5 => KillCountBackShow5, 
			6 => KillCountBackShow6, 
			7 => KillCountBackShow7, 
			8 => KillCountBackShow8, 
			_ => false, 
		};
	}

	public void SetKillCountBackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			KillCountBackShow1 = value;
			break;
		case 2:
			KillCountBackShow2 = value;
			break;
		case 3:
			KillCountBackShow3 = value;
			break;
		case 4:
			KillCountBackShow4 = value;
			break;
		case 5:
			KillCountBackShow5 = value;
			break;
		case 6:
			KillCountBackShow6 = value;
			break;
		case 7:
			KillCountBackShow7 = value;
			break;
		case 8:
			KillCountBackShow8 = value;
			break;
		}
	}

	public int GetKillCountBackCount()
	{
		return 8;
	}

	public Sprite GetKillCountBackSprite(int index)
	{
		return index switch
		{
			1 => KillCountBackSprite1, 
			2 => KillCountBackSprite2, 
			3 => KillCountBackSprite3, 
			4 => KillCountBackSprite4, 
			5 => KillCountBackSprite5, 
			6 => KillCountBackSprite6, 
			7 => KillCountBackSprite7, 
			8 => KillCountBackSprite8, 
			_ => null, 
		};
	}

	public void SetKillCountBackSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			KillCountBackSprite1 = value;
			break;
		case 2:
			KillCountBackSprite2 = value;
			break;
		case 3:
			KillCountBackSprite3 = value;
			break;
		case 4:
			KillCountBackSprite4 = value;
			break;
		case 5:
			KillCountBackSprite5 = value;
			break;
		case 6:
			KillCountBackSprite6 = value;
			break;
		case 7:
			KillCountBackSprite7 = value;
			break;
		case 8:
			KillCountBackSprite8 = value;
			break;
		}
	}

	public string GetKillCountString(int index)
	{
		return index switch
		{
			1 => KillCountString1, 
			2 => KillCountString2, 
			3 => KillCountString3, 
			4 => KillCountString4, 
			5 => KillCountString5, 
			6 => KillCountString6, 
			7 => KillCountString7, 
			8 => KillCountString8, 
			_ => null, 
		};
	}

	public void SetKillCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KillCountString1 = value;
			break;
		case 2:
			KillCountString2 = value;
			break;
		case 3:
			KillCountString3 = value;
			break;
		case 4:
			KillCountString4 = value;
			break;
		case 5:
			KillCountString5 = value;
			break;
		case 6:
			KillCountString6 = value;
			break;
		case 7:
			KillCountString7 = value;
			break;
		case 8:
			KillCountString8 = value;
			break;
		}
	}

	public int GetKillCountCount()
	{
		return 8;
	}

	public bool GetGloryAShow(int index)
	{
		return index switch
		{
			1 => GloryAShow1, 
			2 => GloryAShow2, 
			3 => GloryAShow3, 
			4 => GloryAShow4, 
			5 => GloryAShow5, 
			6 => GloryAShow6, 
			7 => GloryAShow7, 
			8 => GloryAShow8, 
			_ => false, 
		};
	}

	public void SetGloryAShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GloryAShow1 = value;
			break;
		case 2:
			GloryAShow2 = value;
			break;
		case 3:
			GloryAShow3 = value;
			break;
		case 4:
			GloryAShow4 = value;
			break;
		case 5:
			GloryAShow5 = value;
			break;
		case 6:
			GloryAShow6 = value;
			break;
		case 7:
			GloryAShow7 = value;
			break;
		case 8:
			GloryAShow8 = value;
			break;
		}
	}

	public int GetGloryACount()
	{
		return 8;
	}

	public Sprite GetGloryASprite(int index)
	{
		return index switch
		{
			1 => GloryASprite1, 
			2 => GloryASprite2, 
			3 => GloryASprite3, 
			4 => GloryASprite4, 
			5 => GloryASprite5, 
			6 => GloryASprite6, 
			7 => GloryASprite7, 
			8 => GloryASprite8, 
			_ => null, 
		};
	}

	public void SetGloryASprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			GloryASprite1 = value;
			break;
		case 2:
			GloryASprite2 = value;
			break;
		case 3:
			GloryASprite3 = value;
			break;
		case 4:
			GloryASprite4 = value;
			break;
		case 5:
			GloryASprite5 = value;
			break;
		case 6:
			GloryASprite6 = value;
			break;
		case 7:
			GloryASprite7 = value;
			break;
		case 8:
			GloryASprite8 = value;
			break;
		}
	}

	public bool GetGloryBShow(int index)
	{
		return index switch
		{
			1 => GloryBShow1, 
			2 => GloryBShow2, 
			3 => GloryBShow3, 
			4 => GloryBShow4, 
			5 => GloryBShow5, 
			6 => GloryBShow6, 
			7 => GloryBShow7, 
			8 => GloryBShow8, 
			_ => false, 
		};
	}

	public void SetGloryBShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GloryBShow1 = value;
			break;
		case 2:
			GloryBShow2 = value;
			break;
		case 3:
			GloryBShow3 = value;
			break;
		case 4:
			GloryBShow4 = value;
			break;
		case 5:
			GloryBShow5 = value;
			break;
		case 6:
			GloryBShow6 = value;
			break;
		case 7:
			GloryBShow7 = value;
			break;
		case 8:
			GloryBShow8 = value;
			break;
		}
	}

	public int GetGloryBCount()
	{
		return 8;
	}

	public Sprite GetGloryBSprite(int index)
	{
		return index switch
		{
			1 => GloryBSprite1, 
			2 => GloryBSprite2, 
			3 => GloryBSprite3, 
			4 => GloryBSprite4, 
			5 => GloryBSprite5, 
			6 => GloryBSprite6, 
			7 => GloryBSprite7, 
			8 => GloryBSprite8, 
			_ => null, 
		};
	}

	public void SetGloryBSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			GloryBSprite1 = value;
			break;
		case 2:
			GloryBSprite2 = value;
			break;
		case 3:
			GloryBSprite3 = value;
			break;
		case 4:
			GloryBSprite4 = value;
			break;
		case 5:
			GloryBSprite5 = value;
			break;
		case 6:
			GloryBSprite6 = value;
			break;
		case 7:
			GloryBSprite7 = value;
			break;
		case 8:
			GloryBSprite8 = value;
			break;
		}
	}

	public bool GetGloryCShow(int index)
	{
		return index switch
		{
			1 => GloryCShow1, 
			2 => GloryCShow2, 
			3 => GloryCShow3, 
			4 => GloryCShow4, 
			5 => GloryCShow5, 
			6 => GloryCShow6, 
			7 => GloryCShow7, 
			8 => GloryCShow8, 
			_ => false, 
		};
	}

	public void SetGloryCShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GloryCShow1 = value;
			break;
		case 2:
			GloryCShow2 = value;
			break;
		case 3:
			GloryCShow3 = value;
			break;
		case 4:
			GloryCShow4 = value;
			break;
		case 5:
			GloryCShow5 = value;
			break;
		case 6:
			GloryCShow6 = value;
			break;
		case 7:
			GloryCShow7 = value;
			break;
		case 8:
			GloryCShow8 = value;
			break;
		}
	}

	public int GetGloryCCount()
	{
		return 8;
	}

	public Sprite GetGloryCSprite(int index)
	{
		return index switch
		{
			1 => GloryCSprite1, 
			2 => GloryCSprite2, 
			3 => GloryCSprite3, 
			4 => GloryCSprite4, 
			5 => GloryCSprite5, 
			6 => GloryCSprite6, 
			7 => GloryCSprite7, 
			8 => GloryCSprite8, 
			_ => null, 
		};
	}

	public void SetGloryCSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			GloryCSprite1 = value;
			break;
		case 2:
			GloryCSprite2 = value;
			break;
		case 3:
			GloryCSprite3 = value;
			break;
		case 4:
			GloryCSprite4 = value;
			break;
		case 5:
			GloryCSprite5 = value;
			break;
		case 6:
			GloryCSprite6 = value;
			break;
		case 7:
			GloryCSprite7 = value;
			break;
		case 8:
			GloryCSprite8 = value;
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

	public int GetKillTypeCount()
	{
		return 8;
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

	public bool GetAssisterShow(int index)
	{
		return index switch
		{
			1 => AssisterShow1, 
			2 => AssisterShow2, 
			3 => AssisterShow3, 
			4 => AssisterShow4, 
			5 => AssisterShow5, 
			6 => AssisterShow6, 
			7 => AssisterShow7, 
			8 => AssisterShow8, 
			_ => false, 
		};
	}

	public void SetAssisterShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AssisterShow1 = value;
			break;
		case 2:
			AssisterShow2 = value;
			break;
		case 3:
			AssisterShow3 = value;
			break;
		case 4:
			AssisterShow4 = value;
			break;
		case 5:
			AssisterShow5 = value;
			break;
		case 6:
			AssisterShow6 = value;
			break;
		case 7:
			AssisterShow7 = value;
			break;
		case 8:
			AssisterShow8 = value;
			break;
		}
	}

	public int GetAssisterCount()
	{
		return 8;
	}

	public string GetAssisterString(int index)
	{
		return index switch
		{
			1 => AssisterString1, 
			2 => AssisterString2, 
			3 => AssisterString3, 
			4 => AssisterString4, 
			5 => AssisterString5, 
			6 => AssisterString6, 
			7 => AssisterString7, 
			8 => AssisterString8, 
			_ => null, 
		};
	}

	public void SetAssisterString(int index, string value)
	{
		switch (index)
		{
		case 1:
			AssisterString1 = value;
			break;
		case 2:
			AssisterString2 = value;
			break;
		case 3:
			AssisterString3 = value;
			break;
		case 4:
			AssisterString4 = value;
			break;
		case 5:
			AssisterString5 = value;
			break;
		case 6:
			AssisterString6 = value;
			break;
		case 7:
			AssisterString7 = value;
			break;
		case 8:
			AssisterString8 = value;
			break;
		}
	}

	public Color GetAssisterTextcolor(int index)
	{
		return index switch
		{
			1 => AssisterTextcolor1, 
			2 => AssisterTextcolor2, 
			3 => AssisterTextcolor3, 
			4 => AssisterTextcolor4, 
			5 => AssisterTextcolor5, 
			6 => AssisterTextcolor6, 
			7 => AssisterTextcolor7, 
			8 => AssisterTextcolor8, 
			_ => Color.white, 
		};
	}

	public void SetAssisterTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			AssisterTextcolor1 = value;
			break;
		case 2:
			AssisterTextcolor2 = value;
			break;
		case 3:
			AssisterTextcolor3 = value;
			break;
		case 4:
			AssisterTextcolor4 = value;
			break;
		case 5:
			AssisterTextcolor5 = value;
			break;
		case 6:
			AssisterTextcolor6 = value;
			break;
		case 7:
			AssisterTextcolor7 = value;
			break;
		case 8:
			AssisterTextcolor8 = value;
			break;
		}
	}

	public bool GetAssistantTypeShow(int index)
	{
		return index switch
		{
			1 => AssistantTypeShow1, 
			2 => AssistantTypeShow2, 
			3 => AssistantTypeShow3, 
			4 => AssistantTypeShow4, 
			5 => AssistantTypeShow5, 
			6 => AssistantTypeShow6, 
			7 => AssistantTypeShow7, 
			8 => AssistantTypeShow8, 
			_ => false, 
		};
	}

	public void SetAssistantTypeShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AssistantTypeShow1 = value;
			break;
		case 2:
			AssistantTypeShow2 = value;
			break;
		case 3:
			AssistantTypeShow3 = value;
			break;
		case 4:
			AssistantTypeShow4 = value;
			break;
		case 5:
			AssistantTypeShow5 = value;
			break;
		case 6:
			AssistantTypeShow6 = value;
			break;
		case 7:
			AssistantTypeShow7 = value;
			break;
		case 8:
			AssistantTypeShow8 = value;
			break;
		}
	}

	public int GetAssistantTypeCount()
	{
		return 8;
	}

	public Sprite GetAssistantTypeSprite(int index)
	{
		return index switch
		{
			1 => AssistantTypeSprite1, 
			2 => AssistantTypeSprite2, 
			3 => AssistantTypeSprite3, 
			4 => AssistantTypeSprite4, 
			5 => AssistantTypeSprite5, 
			6 => AssistantTypeSprite6, 
			7 => AssistantTypeSprite7, 
			8 => AssistantTypeSprite8, 
			_ => null, 
		};
	}

	public void SetAssistantTypeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			AssistantTypeSprite1 = value;
			break;
		case 2:
			AssistantTypeSprite2 = value;
			break;
		case 3:
			AssistantTypeSprite3 = value;
			break;
		case 4:
			AssistantTypeSprite4 = value;
			break;
		case 5:
			AssistantTypeSprite5 = value;
			break;
		case 6:
			AssistantTypeSprite6 = value;
			break;
		case 7:
			AssistantTypeSprite7 = value;
			break;
		case 8:
			AssistantTypeSprite8 = value;
			break;
		}
	}

	public void AssistantTypeNtvsize1()
	{
		if (_oAssistantTypeImage1 != null)
		{
			_oAssistantTypeImage1.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize2()
	{
		if (_oAssistantTypeImage2 != null)
		{
			_oAssistantTypeImage2.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize3()
	{
		if (_oAssistantTypeImage3 != null)
		{
			_oAssistantTypeImage3.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize4()
	{
		if (_oAssistantTypeImage4 != null)
		{
			_oAssistantTypeImage4.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize5()
	{
		if (_oAssistantTypeImage5 != null)
		{
			_oAssistantTypeImage5.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize6()
	{
		if (_oAssistantTypeImage6 != null)
		{
			_oAssistantTypeImage6.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize7()
	{
		if (_oAssistantTypeImage7 != null)
		{
			_oAssistantTypeImage7.SetNativeSize();
		}
	}

	public void AssistantTypeNtvsize8()
	{
		if (_oAssistantTypeImage8 != null)
		{
			_oAssistantTypeImage8.SetNativeSize();
		}
	}

	public void CallAssistantTypeNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			AssistantTypeNtvsize1();
			break;
		case 2:
			AssistantTypeNtvsize2();
			break;
		case 3:
			AssistantTypeNtvsize3();
			break;
		case 4:
			AssistantTypeNtvsize4();
			break;
		case 5:
			AssistantTypeNtvsize5();
			break;
		case 6:
			AssistantTypeNtvsize6();
			break;
		case 7:
			AssistantTypeNtvsize7();
			break;
		case 8:
			AssistantTypeNtvsize8();
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

	public int GetKillerCount()
	{
		return 8;
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

	public int GetWeaponCount()
	{
		return 8;
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

	public bool GetIconShow(int index)
	{
		return index switch
		{
			1 => IconShow1, 
			2 => IconShow2, 
			3 => IconShow3, 
			4 => IconShow4, 
			5 => IconShow5, 
			6 => IconShow6, 
			7 => IconShow7, 
			8 => IconShow8, 
			_ => false, 
		};
	}

	public void SetIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			IconShow1 = value;
			break;
		case 2:
			IconShow2 = value;
			break;
		case 3:
			IconShow3 = value;
			break;
		case 4:
			IconShow4 = value;
			break;
		case 5:
			IconShow5 = value;
			break;
		case 6:
			IconShow6 = value;
			break;
		case 7:
			IconShow7 = value;
			break;
		case 8:
			IconShow8 = value;
			break;
		}
	}

	public int GetIconCount()
	{
		return 8;
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			1 => IconSprite1, 
			2 => IconSprite2, 
			3 => IconSprite3, 
			4 => IconSprite4, 
			5 => IconSprite5, 
			6 => IconSprite6, 
			7 => IconSprite7, 
			8 => IconSprite8, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		case 3:
			IconSprite3 = value;
			break;
		case 4:
			IconSprite4 = value;
			break;
		case 5:
			IconSprite5 = value;
			break;
		case 6:
			IconSprite6 = value;
			break;
		case 7:
			IconSprite7 = value;
			break;
		case 8:
			IconSprite8 = value;
			break;
		}
	}

	public void IconNtvsize1()
	{
		if (_oIconImage1 != null)
		{
			_oIconImage1.SetNativeSize();
		}
	}

	public void IconNtvsize2()
	{
		if (_oIconImage2 != null)
		{
			_oIconImage2.SetNativeSize();
		}
	}

	public void IconNtvsize3()
	{
		if (_oIconImage3 != null)
		{
			_oIconImage3.SetNativeSize();
		}
	}

	public void IconNtvsize4()
	{
		if (_oIconImage4 != null)
		{
			_oIconImage4.SetNativeSize();
		}
	}

	public void IconNtvsize5()
	{
		if (_oIconImage5 != null)
		{
			_oIconImage5.SetNativeSize();
		}
	}

	public void IconNtvsize6()
	{
		if (_oIconImage6 != null)
		{
			_oIconImage6.SetNativeSize();
		}
	}

	public void IconNtvsize7()
	{
		if (_oIconImage7 != null)
		{
			_oIconImage7.SetNativeSize();
		}
	}

	public void IconNtvsize8()
	{
		if (_oIconImage8 != null)
		{
			_oIconImage8.SetNativeSize();
		}
	}

	public void CallIconNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			IconNtvsize1();
			break;
		case 2:
			IconNtvsize2();
			break;
		case 3:
			IconNtvsize3();
			break;
		case 4:
			IconNtvsize4();
			break;
		case 5:
			IconNtvsize5();
			break;
		case 6:
			IconNtvsize6();
			break;
		case 7:
			IconNtvsize7();
			break;
		case 8:
			IconNtvsize8();
			break;
		}
	}

	public bool GetPermanentShow(int index)
	{
		return index switch
		{
			1 => PermanentShow1, 
			2 => PermanentShow2, 
			3 => PermanentShow3, 
			4 => PermanentShow4, 
			5 => PermanentShow5, 
			6 => PermanentShow6, 
			7 => PermanentShow7, 
			8 => PermanentShow8, 
			_ => false, 
		};
	}

	public void SetPermanentShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PermanentShow1 = value;
			break;
		case 2:
			PermanentShow2 = value;
			break;
		case 3:
			PermanentShow3 = value;
			break;
		case 4:
			PermanentShow4 = value;
			break;
		case 5:
			PermanentShow5 = value;
			break;
		case 6:
			PermanentShow6 = value;
			break;
		case 7:
			PermanentShow7 = value;
			break;
		case 8:
			PermanentShow8 = value;
			break;
		}
	}

	public int GetPermanentCount()
	{
		return 8;
	}

	public Sprite GetPermanentSprite(int index)
	{
		return index switch
		{
			1 => PermanentSprite1, 
			2 => PermanentSprite2, 
			3 => PermanentSprite3, 
			4 => PermanentSprite4, 
			5 => PermanentSprite5, 
			6 => PermanentSprite6, 
			7 => PermanentSprite7, 
			8 => PermanentSprite8, 
			_ => null, 
		};
	}

	public void SetPermanentSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PermanentSprite1 = value;
			break;
		case 2:
			PermanentSprite2 = value;
			break;
		case 3:
			PermanentSprite3 = value;
			break;
		case 4:
			PermanentSprite4 = value;
			break;
		case 5:
			PermanentSprite5 = value;
			break;
		case 6:
			PermanentSprite6 = value;
			break;
		case 7:
			PermanentSprite7 = value;
			break;
		case 8:
			PermanentSprite8 = value;
			break;
		}
	}

	public void PermanentNtvsize1()
	{
		if (_oPermanentImage1 != null)
		{
			_oPermanentImage1.SetNativeSize();
		}
	}

	public void PermanentNtvsize2()
	{
		if (_oPermanentImage2 != null)
		{
			_oPermanentImage2.SetNativeSize();
		}
	}

	public void PermanentNtvsize3()
	{
		if (_oPermanentImage3 != null)
		{
			_oPermanentImage3.SetNativeSize();
		}
	}

	public void PermanentNtvsize4()
	{
		if (_oPermanentImage4 != null)
		{
			_oPermanentImage4.SetNativeSize();
		}
	}

	public void PermanentNtvsize5()
	{
		if (_oPermanentImage5 != null)
		{
			_oPermanentImage5.SetNativeSize();
		}
	}

	public void PermanentNtvsize6()
	{
		if (_oPermanentImage6 != null)
		{
			_oPermanentImage6.SetNativeSize();
		}
	}

	public void PermanentNtvsize7()
	{
		if (_oPermanentImage7 != null)
		{
			_oPermanentImage7.SetNativeSize();
		}
	}

	public void PermanentNtvsize8()
	{
		if (_oPermanentImage8 != null)
		{
			_oPermanentImage8.SetNativeSize();
		}
	}

	public void CallPermanentNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			PermanentNtvsize1();
			break;
		case 2:
			PermanentNtvsize2();
			break;
		case 3:
			PermanentNtvsize3();
			break;
		case 4:
			PermanentNtvsize4();
			break;
		case 5:
			PermanentNtvsize5();
			break;
		case 6:
			PermanentNtvsize6();
			break;
		case 7:
			PermanentNtvsize7();
			break;
		case 8:
			PermanentNtvsize8();
			break;
		}
	}

	public bool GetNameShow(int index)
	{
		return index switch
		{
			1 => NameShow1, 
			2 => NameShow2, 
			3 => NameShow3, 
			4 => NameShow4, 
			5 => NameShow5, 
			6 => NameShow6, 
			7 => NameShow7, 
			8 => NameShow8, 
			_ => false, 
		};
	}

	public void SetNameShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NameShow1 = value;
			break;
		case 2:
			NameShow2 = value;
			break;
		case 3:
			NameShow3 = value;
			break;
		case 4:
			NameShow4 = value;
			break;
		case 5:
			NameShow5 = value;
			break;
		case 6:
			NameShow6 = value;
			break;
		case 7:
			NameShow7 = value;
			break;
		case 8:
			NameShow8 = value;
			break;
		}
	}

	public int GetNameCount()
	{
		return 8;
	}

	public Sprite GetNameSprite(int index)
	{
		return index switch
		{
			1 => NameSprite1, 
			2 => NameSprite2, 
			3 => NameSprite3, 
			4 => NameSprite4, 
			5 => NameSprite5, 
			6 => NameSprite6, 
			7 => NameSprite7, 
			8 => NameSprite8, 
			_ => null, 
		};
	}

	public void SetNameSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			NameSprite1 = value;
			break;
		case 2:
			NameSprite2 = value;
			break;
		case 3:
			NameSprite3 = value;
			break;
		case 4:
			NameSprite4 = value;
			break;
		case 5:
			NameSprite5 = value;
			break;
		case 6:
			NameSprite6 = value;
			break;
		case 7:
			NameSprite7 = value;
			break;
		case 8:
			NameSprite8 = value;
			break;
		}
	}

	public void NameNtvsize1()
	{
		if (_oNameImage1 != null)
		{
			_oNameImage1.SetNativeSize();
		}
	}

	public void NameNtvsize2()
	{
		if (_oNameImage2 != null)
		{
			_oNameImage2.SetNativeSize();
		}
	}

	public void NameNtvsize3()
	{
		if (_oNameImage3 != null)
		{
			_oNameImage3.SetNativeSize();
		}
	}

	public void NameNtvsize4()
	{
		if (_oNameImage4 != null)
		{
			_oNameImage4.SetNativeSize();
		}
	}

	public void NameNtvsize5()
	{
		if (_oNameImage5 != null)
		{
			_oNameImage5.SetNativeSize();
		}
	}

	public void NameNtvsize6()
	{
		if (_oNameImage6 != null)
		{
			_oNameImage6.SetNativeSize();
		}
	}

	public void NameNtvsize7()
	{
		if (_oNameImage7 != null)
		{
			_oNameImage7.SetNativeSize();
		}
	}

	public void NameNtvsize8()
	{
		if (_oNameImage8 != null)
		{
			_oNameImage8.SetNativeSize();
		}
	}

	public void CallNameNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			NameNtvsize1();
			break;
		case 2:
			NameNtvsize2();
			break;
		case 3:
			NameNtvsize3();
			break;
		case 4:
			NameNtvsize4();
			break;
		case 5:
			NameNtvsize5();
			break;
		case 6:
			NameNtvsize6();
			break;
		case 7:
			NameNtvsize7();
			break;
		case 8:
			NameNtvsize8();
			break;
		}
	}

	public bool GetLabelShow(int index)
	{
		return index switch
		{
			1 => LabelShow1, 
			2 => LabelShow2, 
			3 => LabelShow3, 
			4 => LabelShow4, 
			5 => LabelShow5, 
			6 => LabelShow6, 
			7 => LabelShow7, 
			8 => LabelShow8, 
			_ => false, 
		};
	}

	public void SetLabelShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LabelShow1 = value;
			break;
		case 2:
			LabelShow2 = value;
			break;
		case 3:
			LabelShow3 = value;
			break;
		case 4:
			LabelShow4 = value;
			break;
		case 5:
			LabelShow5 = value;
			break;
		case 6:
			LabelShow6 = value;
			break;
		case 7:
			LabelShow7 = value;
			break;
		case 8:
			LabelShow8 = value;
			break;
		}
	}

	public int GetLabelCount()
	{
		return 8;
	}

	public bool GetModeKillBackShow(int index)
	{
		return index switch
		{
			1 => ModeKillBackShow1, 
			2 => ModeKillBackShow2, 
			3 => ModeKillBackShow3, 
			4 => ModeKillBackShow4, 
			5 => ModeKillBackShow5, 
			6 => ModeKillBackShow6, 
			7 => ModeKillBackShow7, 
			8 => ModeKillBackShow8, 
			_ => false, 
		};
	}

	public void SetModeKillBackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ModeKillBackShow1 = value;
			break;
		case 2:
			ModeKillBackShow2 = value;
			break;
		case 3:
			ModeKillBackShow3 = value;
			break;
		case 4:
			ModeKillBackShow4 = value;
			break;
		case 5:
			ModeKillBackShow5 = value;
			break;
		case 6:
			ModeKillBackShow6 = value;
			break;
		case 7:
			ModeKillBackShow7 = value;
			break;
		case 8:
			ModeKillBackShow8 = value;
			break;
		}
	}

	public int GetModeKillBackCount()
	{
		return 8;
	}

	public string GetModeKillCountString(int index)
	{
		return index switch
		{
			1 => ModeKillCountString1, 
			2 => ModeKillCountString2, 
			3 => ModeKillCountString3, 
			4 => ModeKillCountString4, 
			5 => ModeKillCountString5, 
			6 => ModeKillCountString6, 
			7 => ModeKillCountString7, 
			8 => ModeKillCountString8, 
			_ => null, 
		};
	}

	public void SetModeKillCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ModeKillCountString1 = value;
			break;
		case 2:
			ModeKillCountString2 = value;
			break;
		case 3:
			ModeKillCountString3 = value;
			break;
		case 4:
			ModeKillCountString4 = value;
			break;
		case 5:
			ModeKillCountString5 = value;
			break;
		case 6:
			ModeKillCountString6 = value;
			break;
		case 7:
			ModeKillCountString7 = value;
			break;
		case 8:
			ModeKillCountString8 = value;
			break;
		}
	}

	public int GetModeKillCountCount()
	{
		return 8;
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

	public int GetVictimCount()
	{
		return 8;
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
