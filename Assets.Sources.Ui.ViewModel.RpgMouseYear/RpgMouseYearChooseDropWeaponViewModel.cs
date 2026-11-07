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

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearChooseDropWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oChooseAll;

	private GameObject _oWeaponName1;

	private GameObject _oWeaponName2;

	private GameObject _oWeaponName3;

	private Text _oWeaponNameText1;

	private Text _oWeaponNameText2;

	private Text _oWeaponNameText3;

	private GameObject _oChoose1;

	private GameObject _oChoose2;

	private GameObject _oChoose3;

	private EventTrigger _oChooseEventTrigger1;

	private EventTrigger _oChooseEventTrigger2;

	private EventTrigger _oChooseEventTrigger3;

	private Button _oChooseButton1;

	private Button _oChooseButton2;

	private Button _oChooseButton3;

	private GameObject _oScoll1;

	private GameObject _oScoll2;

	private GameObject _oScoll3;

	private RectTransform _oScollRectTransform1;

	private RectTransform _oScollRectTransform2;

	private RectTransform _oScollRectTransform3;

	private GameObject _oType1Weapon1;

	private GameObject _oType1Weapon2;

	private GameObject _oType1Weapon3;

	private GameObject _oType1Weapon4;

	private GameObject _oType1Weapon5;

	private RectTransform _oType1WeaponRectTransform1;

	private RectTransform _oType1WeaponRectTransform2;

	private RectTransform _oType1WeaponRectTransform3;

	private RectTransform _oType1WeaponRectTransform4;

	private RectTransform _oType1WeaponRectTransform5;

	private Image _oType1WeaponImage1;

	private Image _oType1WeaponImage2;

	private Image _oType1WeaponImage3;

	private Image _oType1WeaponImage4;

	private Image _oType1WeaponImage5;

	private GameObject _oType2Weapon1;

	private GameObject _oType2Weapon2;

	private GameObject _oType2Weapon3;

	private GameObject _oType2Weapon4;

	private GameObject _oType2Weapon5;

	private RectTransform _oType2WeaponRectTransform1;

	private RectTransform _oType2WeaponRectTransform2;

	private RectTransform _oType2WeaponRectTransform3;

	private RectTransform _oType2WeaponRectTransform4;

	private RectTransform _oType2WeaponRectTransform5;

	private Image _oType2WeaponImage1;

	private Image _oType2WeaponImage2;

	private Image _oType2WeaponImage3;

	private Image _oType2WeaponImage4;

	private Image _oType2WeaponImage5;

	private GameObject _oType3Weapon1;

	private GameObject _oType3Weapon2;

	private GameObject _oType3Weapon3;

	private GameObject _oType3Weapon4;

	private GameObject _oType3Weapon5;

	private RectTransform _oType3WeaponRectTransform1;

	private RectTransform _oType3WeaponRectTransform2;

	private RectTransform _oType3WeaponRectTransform3;

	private RectTransform _oType3WeaponRectTransform4;

	private RectTransform _oType3WeaponRectTransform5;

	private Image _oType3WeaponImage1;

	private Image _oType3WeaponImage2;

	private Image _oType3WeaponImage3;

	private Image _oType3WeaponImage4;

	private Image _oType3WeaponImage5;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private Button _oCloseButton;

	private GameObject _oType1;

	private GameObject _oType2;

	private GameObject _oType3;

	private GameObject _oType4;

	private Image _oTypeImage1;

	private Image _oTypeImage2;

	private Image _oTypeImage3;

	private Image _oTypeImage4;

	private EventTrigger _oTypeEventTrigger1;

	private EventTrigger _oTypeEventTrigger2;

	private EventTrigger _oTypeEventTrigger3;

	private EventTrigger _oTypeEventTrigger4;

	private Button _oTypeButton1;

	private Button _oTypeButton2;

	private Button _oTypeButton3;

	private Button _oTypeButton4;

	private GameObject _oTypeChoose1;

	private GameObject _oTypeChoose2;

	private GameObject _oTypeChoose3;

	private GameObject _oTypeChoose4;

	private GameObject _oStart;

	private EventTrigger _oStartEventTrigger;

	private Button _oStartButton;

	private GameObject _oChooseType;

	private GameObject _oChooseTypeShadow1;

	private GameObject _oChooseTypeShadow2;

	private GameObject _oChooseTypeShadow3;

	private GameObject _oChooseTypeShadow4;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private RectTransform _oWeaponRectTransform1;

	private RectTransform _oWeaponRectTransform2;

	private RectTransform _oWeaponRectTransform3;

	private Image _oWeaponImage1;

	private Image _oWeaponImage2;

	private Image _oWeaponImage3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearChooseDropWeapon";

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

	public bool ChooseAllShow
	{
		get
		{
			if (_oChooseAll != null)
			{
				return _oChooseAll.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseAllShow != value && _oChooseAll != null)
			{
				_oChooseAll.SetObjectActive(value);
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

	public bool ChooseShow1
	{
		get
		{
			if (_oChoose1 != null)
			{
				return _oChoose1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow1 != value && _oChoose1 != null)
			{
				_oChoose1.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow2
	{
		get
		{
			if (_oChoose2 != null)
			{
				return _oChoose2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow2 != value && _oChoose2 != null)
			{
				_oChoose2.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow3
	{
		get
		{
			if (_oChoose3 != null)
			{
				return _oChoose3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow3 != value && _oChoose3 != null)
			{
				_oChoose3.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers1
	{
		get
		{
			if (_oChooseEventTrigger1 != null)
			{
				return _oChooseEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers1 != value && _oChooseEventTrigger1 != null)
			{
				_oChooseEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers2
	{
		get
		{
			if (_oChooseEventTrigger2 != null)
			{
				return _oChooseEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers2 != value && _oChooseEventTrigger2 != null)
			{
				_oChooseEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers3
	{
		get
		{
			if (_oChooseEventTrigger3 != null)
			{
				return _oChooseEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers3 != value && _oChooseEventTrigger3 != null)
			{
				_oChooseEventTrigger3.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent ChooseClicked1
	{
		get
		{
			if (_oChooseButton1 != null)
			{
				return _oChooseButton1.onClick;
			}
			return null;
		}
		set
		{
			if (ChooseClicked1 != value && _oChooseButton1 != null)
			{
				_oChooseButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ChooseClicked2
	{
		get
		{
			if (_oChooseButton2 != null)
			{
				return _oChooseButton2.onClick;
			}
			return null;
		}
		set
		{
			if (ChooseClicked2 != value && _oChooseButton2 != null)
			{
				_oChooseButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ChooseClicked3
	{
		get
		{
			if (_oChooseButton3 != null)
			{
				return _oChooseButton3.onClick;
			}
			return null;
		}
		set
		{
			if (ChooseClicked3 != value && _oChooseButton3 != null)
			{
				_oChooseButton3.onClick = value;
			}
		}
	}

	public bool ChooseButtonable1
	{
		get
		{
			if (_oChooseButton1 != null)
			{
				return _oChooseButton1.interactable;
			}
			return true;
		}
		set
		{
			if (ChooseButtonable1 != value && _oChooseButton1 != null)
			{
				_oChooseButton1.interactable = value;
			}
		}
	}

	public bool ChooseButtonable2
	{
		get
		{
			if (_oChooseButton2 != null)
			{
				return _oChooseButton2.interactable;
			}
			return true;
		}
		set
		{
			if (ChooseButtonable2 != value && _oChooseButton2 != null)
			{
				_oChooseButton2.interactable = value;
			}
		}
	}

	public bool ChooseButtonable3
	{
		get
		{
			if (_oChooseButton3 != null)
			{
				return _oChooseButton3.interactable;
			}
			return true;
		}
		set
		{
			if (ChooseButtonable3 != value && _oChooseButton3 != null)
			{
				_oChooseButton3.interactable = value;
			}
		}
	}

	public GameObject ScollObj1 => _oScoll1;

	public GameObject ScollObj2 => _oScoll2;

	public GameObject ScollObj3 => _oScoll3;

	public Vector3 ScollPosition1
	{
		get
		{
			if (_oScollRectTransform1 != null)
			{
				return _oScollRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScollPosition1 != value && _oScollRectTransform1 != null)
			{
				_oScollRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 ScollPosition2
	{
		get
		{
			if (_oScollRectTransform2 != null)
			{
				return _oScollRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScollPosition2 != value && _oScollRectTransform2 != null)
			{
				_oScollRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 ScollPosition3
	{
		get
		{
			if (_oScollRectTransform3 != null)
			{
				return _oScollRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScollPosition3 != value && _oScollRectTransform3 != null)
			{
				_oScollRectTransform3.localPosition = value;
			}
		}
	}

	public GameObject Type1WeaponObj1 => _oType1Weapon1;

	public GameObject Type1WeaponObj2 => _oType1Weapon2;

	public GameObject Type1WeaponObj3 => _oType1Weapon3;

	public GameObject Type1WeaponObj4 => _oType1Weapon4;

	public GameObject Type1WeaponObj5 => _oType1Weapon5;

	public Vector3 Type1WeaponPosition1
	{
		get
		{
			if (_oType1WeaponRectTransform1 != null)
			{
				return _oType1WeaponRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponPosition1 != value && _oType1WeaponRectTransform1 != null)
			{
				_oType1WeaponRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 Type1WeaponPosition2
	{
		get
		{
			if (_oType1WeaponRectTransform2 != null)
			{
				return _oType1WeaponRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponPosition2 != value && _oType1WeaponRectTransform2 != null)
			{
				_oType1WeaponRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 Type1WeaponPosition3
	{
		get
		{
			if (_oType1WeaponRectTransform3 != null)
			{
				return _oType1WeaponRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponPosition3 != value && _oType1WeaponRectTransform3 != null)
			{
				_oType1WeaponRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 Type1WeaponPosition4
	{
		get
		{
			if (_oType1WeaponRectTransform4 != null)
			{
				return _oType1WeaponRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponPosition4 != value && _oType1WeaponRectTransform4 != null)
			{
				_oType1WeaponRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 Type1WeaponPosition5
	{
		get
		{
			if (_oType1WeaponRectTransform5 != null)
			{
				return _oType1WeaponRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponPosition5 != value && _oType1WeaponRectTransform5 != null)
			{
				_oType1WeaponRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 Type1WeaponScale1
	{
		get
		{
			if (_oType1WeaponRectTransform1 != null)
			{
				return _oType1WeaponRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponScale1 != value && _oType1WeaponRectTransform1 != null)
			{
				_oType1WeaponRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 Type1WeaponScale2
	{
		get
		{
			if (_oType1WeaponRectTransform2 != null)
			{
				return _oType1WeaponRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponScale2 != value && _oType1WeaponRectTransform2 != null)
			{
				_oType1WeaponRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 Type1WeaponScale3
	{
		get
		{
			if (_oType1WeaponRectTransform3 != null)
			{
				return _oType1WeaponRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponScale3 != value && _oType1WeaponRectTransform3 != null)
			{
				_oType1WeaponRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 Type1WeaponScale4
	{
		get
		{
			if (_oType1WeaponRectTransform4 != null)
			{
				return _oType1WeaponRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponScale4 != value && _oType1WeaponRectTransform4 != null)
			{
				_oType1WeaponRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 Type1WeaponScale5
	{
		get
		{
			if (_oType1WeaponRectTransform5 != null)
			{
				return _oType1WeaponRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type1WeaponScale5 != value && _oType1WeaponRectTransform5 != null)
			{
				_oType1WeaponRectTransform5.localScale = value;
			}
		}
	}

	public Sprite Type1WeaponSprite1
	{
		get
		{
			if (_oType1WeaponImage1 != null)
			{
				return _oType1WeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (Type1WeaponSprite1 != value && _oType1WeaponImage1 != null)
			{
				_oType1WeaponImage1.sprite = value;
			}
		}
	}

	public Sprite Type1WeaponSprite2
	{
		get
		{
			if (_oType1WeaponImage2 != null)
			{
				return _oType1WeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (Type1WeaponSprite2 != value && _oType1WeaponImage2 != null)
			{
				_oType1WeaponImage2.sprite = value;
			}
		}
	}

	public Sprite Type1WeaponSprite3
	{
		get
		{
			if (_oType1WeaponImage3 != null)
			{
				return _oType1WeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (Type1WeaponSprite3 != value && _oType1WeaponImage3 != null)
			{
				_oType1WeaponImage3.sprite = value;
			}
		}
	}

	public Sprite Type1WeaponSprite4
	{
		get
		{
			if (_oType1WeaponImage4 != null)
			{
				return _oType1WeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (Type1WeaponSprite4 != value && _oType1WeaponImage4 != null)
			{
				_oType1WeaponImage4.sprite = value;
			}
		}
	}

	public Sprite Type1WeaponSprite5
	{
		get
		{
			if (_oType1WeaponImage5 != null)
			{
				return _oType1WeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (Type1WeaponSprite5 != value && _oType1WeaponImage5 != null)
			{
				_oType1WeaponImage5.sprite = value;
			}
		}
	}

	public Image Type1WeaponImage1
	{
		get
		{
			if (_oType1WeaponImage1 != null)
			{
				return _oType1WeaponImage1;
			}
			return null;
		}
		set
		{
			if (Type1WeaponImage1 != value && _oType1WeaponImage1 != null)
			{
				_oType1WeaponImage1 = value;
			}
		}
	}

	public Image Type1WeaponImage2
	{
		get
		{
			if (_oType1WeaponImage2 != null)
			{
				return _oType1WeaponImage2;
			}
			return null;
		}
		set
		{
			if (Type1WeaponImage2 != value && _oType1WeaponImage2 != null)
			{
				_oType1WeaponImage2 = value;
			}
		}
	}

	public Image Type1WeaponImage3
	{
		get
		{
			if (_oType1WeaponImage3 != null)
			{
				return _oType1WeaponImage3;
			}
			return null;
		}
		set
		{
			if (Type1WeaponImage3 != value && _oType1WeaponImage3 != null)
			{
				_oType1WeaponImage3 = value;
			}
		}
	}

	public Image Type1WeaponImage4
	{
		get
		{
			if (_oType1WeaponImage4 != null)
			{
				return _oType1WeaponImage4;
			}
			return null;
		}
		set
		{
			if (Type1WeaponImage4 != value && _oType1WeaponImage4 != null)
			{
				_oType1WeaponImage4 = value;
			}
		}
	}

	public Image Type1WeaponImage5
	{
		get
		{
			if (_oType1WeaponImage5 != null)
			{
				return _oType1WeaponImage5;
			}
			return null;
		}
		set
		{
			if (Type1WeaponImage5 != value && _oType1WeaponImage5 != null)
			{
				_oType1WeaponImage5 = value;
			}
		}
	}

	public GameObject Type2WeaponObj1 => _oType2Weapon1;

	public GameObject Type2WeaponObj2 => _oType2Weapon2;

	public GameObject Type2WeaponObj3 => _oType2Weapon3;

	public GameObject Type2WeaponObj4 => _oType2Weapon4;

	public GameObject Type2WeaponObj5 => _oType2Weapon5;

	public Vector3 Type2WeaponPosition1
	{
		get
		{
			if (_oType2WeaponRectTransform1 != null)
			{
				return _oType2WeaponRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponPosition1 != value && _oType2WeaponRectTransform1 != null)
			{
				_oType2WeaponRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 Type2WeaponPosition2
	{
		get
		{
			if (_oType2WeaponRectTransform2 != null)
			{
				return _oType2WeaponRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponPosition2 != value && _oType2WeaponRectTransform2 != null)
			{
				_oType2WeaponRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 Type2WeaponPosition3
	{
		get
		{
			if (_oType2WeaponRectTransform3 != null)
			{
				return _oType2WeaponRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponPosition3 != value && _oType2WeaponRectTransform3 != null)
			{
				_oType2WeaponRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 Type2WeaponPosition4
	{
		get
		{
			if (_oType2WeaponRectTransform4 != null)
			{
				return _oType2WeaponRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponPosition4 != value && _oType2WeaponRectTransform4 != null)
			{
				_oType2WeaponRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 Type2WeaponPosition5
	{
		get
		{
			if (_oType2WeaponRectTransform5 != null)
			{
				return _oType2WeaponRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponPosition5 != value && _oType2WeaponRectTransform5 != null)
			{
				_oType2WeaponRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 Type2WeaponScale1
	{
		get
		{
			if (_oType2WeaponRectTransform1 != null)
			{
				return _oType2WeaponRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponScale1 != value && _oType2WeaponRectTransform1 != null)
			{
				_oType2WeaponRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 Type2WeaponScale2
	{
		get
		{
			if (_oType2WeaponRectTransform2 != null)
			{
				return _oType2WeaponRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponScale2 != value && _oType2WeaponRectTransform2 != null)
			{
				_oType2WeaponRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 Type2WeaponScale3
	{
		get
		{
			if (_oType2WeaponRectTransform3 != null)
			{
				return _oType2WeaponRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponScale3 != value && _oType2WeaponRectTransform3 != null)
			{
				_oType2WeaponRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 Type2WeaponScale4
	{
		get
		{
			if (_oType2WeaponRectTransform4 != null)
			{
				return _oType2WeaponRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponScale4 != value && _oType2WeaponRectTransform4 != null)
			{
				_oType2WeaponRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 Type2WeaponScale5
	{
		get
		{
			if (_oType2WeaponRectTransform5 != null)
			{
				return _oType2WeaponRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type2WeaponScale5 != value && _oType2WeaponRectTransform5 != null)
			{
				_oType2WeaponRectTransform5.localScale = value;
			}
		}
	}

	public Sprite Type2WeaponSprite1
	{
		get
		{
			if (_oType2WeaponImage1 != null)
			{
				return _oType2WeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (Type2WeaponSprite1 != value && _oType2WeaponImage1 != null)
			{
				_oType2WeaponImage1.sprite = value;
			}
		}
	}

	public Sprite Type2WeaponSprite2
	{
		get
		{
			if (_oType2WeaponImage2 != null)
			{
				return _oType2WeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (Type2WeaponSprite2 != value && _oType2WeaponImage2 != null)
			{
				_oType2WeaponImage2.sprite = value;
			}
		}
	}

	public Sprite Type2WeaponSprite3
	{
		get
		{
			if (_oType2WeaponImage3 != null)
			{
				return _oType2WeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (Type2WeaponSprite3 != value && _oType2WeaponImage3 != null)
			{
				_oType2WeaponImage3.sprite = value;
			}
		}
	}

	public Sprite Type2WeaponSprite4
	{
		get
		{
			if (_oType2WeaponImage4 != null)
			{
				return _oType2WeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (Type2WeaponSprite4 != value && _oType2WeaponImage4 != null)
			{
				_oType2WeaponImage4.sprite = value;
			}
		}
	}

	public Sprite Type2WeaponSprite5
	{
		get
		{
			if (_oType2WeaponImage5 != null)
			{
				return _oType2WeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (Type2WeaponSprite5 != value && _oType2WeaponImage5 != null)
			{
				_oType2WeaponImage5.sprite = value;
			}
		}
	}

	public Image Type2WeaponImage1
	{
		get
		{
			if (_oType2WeaponImage1 != null)
			{
				return _oType2WeaponImage1;
			}
			return null;
		}
		set
		{
			if (Type2WeaponImage1 != value && _oType2WeaponImage1 != null)
			{
				_oType2WeaponImage1 = value;
			}
		}
	}

	public Image Type2WeaponImage2
	{
		get
		{
			if (_oType2WeaponImage2 != null)
			{
				return _oType2WeaponImage2;
			}
			return null;
		}
		set
		{
			if (Type2WeaponImage2 != value && _oType2WeaponImage2 != null)
			{
				_oType2WeaponImage2 = value;
			}
		}
	}

	public Image Type2WeaponImage3
	{
		get
		{
			if (_oType2WeaponImage3 != null)
			{
				return _oType2WeaponImage3;
			}
			return null;
		}
		set
		{
			if (Type2WeaponImage3 != value && _oType2WeaponImage3 != null)
			{
				_oType2WeaponImage3 = value;
			}
		}
	}

	public Image Type2WeaponImage4
	{
		get
		{
			if (_oType2WeaponImage4 != null)
			{
				return _oType2WeaponImage4;
			}
			return null;
		}
		set
		{
			if (Type2WeaponImage4 != value && _oType2WeaponImage4 != null)
			{
				_oType2WeaponImage4 = value;
			}
		}
	}

	public Image Type2WeaponImage5
	{
		get
		{
			if (_oType2WeaponImage5 != null)
			{
				return _oType2WeaponImage5;
			}
			return null;
		}
		set
		{
			if (Type2WeaponImage5 != value && _oType2WeaponImage5 != null)
			{
				_oType2WeaponImage5 = value;
			}
		}
	}

	public GameObject Type3WeaponObj1 => _oType3Weapon1;

	public GameObject Type3WeaponObj2 => _oType3Weapon2;

	public GameObject Type3WeaponObj3 => _oType3Weapon3;

	public GameObject Type3WeaponObj4 => _oType3Weapon4;

	public GameObject Type3WeaponObj5 => _oType3Weapon5;

	public Vector3 Type3WeaponPosition1
	{
		get
		{
			if (_oType3WeaponRectTransform1 != null)
			{
				return _oType3WeaponRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponPosition1 != value && _oType3WeaponRectTransform1 != null)
			{
				_oType3WeaponRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 Type3WeaponPosition2
	{
		get
		{
			if (_oType3WeaponRectTransform2 != null)
			{
				return _oType3WeaponRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponPosition2 != value && _oType3WeaponRectTransform2 != null)
			{
				_oType3WeaponRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 Type3WeaponPosition3
	{
		get
		{
			if (_oType3WeaponRectTransform3 != null)
			{
				return _oType3WeaponRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponPosition3 != value && _oType3WeaponRectTransform3 != null)
			{
				_oType3WeaponRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 Type3WeaponPosition4
	{
		get
		{
			if (_oType3WeaponRectTransform4 != null)
			{
				return _oType3WeaponRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponPosition4 != value && _oType3WeaponRectTransform4 != null)
			{
				_oType3WeaponRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 Type3WeaponPosition5
	{
		get
		{
			if (_oType3WeaponRectTransform5 != null)
			{
				return _oType3WeaponRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponPosition5 != value && _oType3WeaponRectTransform5 != null)
			{
				_oType3WeaponRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 Type3WeaponScale1
	{
		get
		{
			if (_oType3WeaponRectTransform1 != null)
			{
				return _oType3WeaponRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponScale1 != value && _oType3WeaponRectTransform1 != null)
			{
				_oType3WeaponRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 Type3WeaponScale2
	{
		get
		{
			if (_oType3WeaponRectTransform2 != null)
			{
				return _oType3WeaponRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponScale2 != value && _oType3WeaponRectTransform2 != null)
			{
				_oType3WeaponRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 Type3WeaponScale3
	{
		get
		{
			if (_oType3WeaponRectTransform3 != null)
			{
				return _oType3WeaponRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponScale3 != value && _oType3WeaponRectTransform3 != null)
			{
				_oType3WeaponRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 Type3WeaponScale4
	{
		get
		{
			if (_oType3WeaponRectTransform4 != null)
			{
				return _oType3WeaponRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponScale4 != value && _oType3WeaponRectTransform4 != null)
			{
				_oType3WeaponRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 Type3WeaponScale5
	{
		get
		{
			if (_oType3WeaponRectTransform5 != null)
			{
				return _oType3WeaponRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (Type3WeaponScale5 != value && _oType3WeaponRectTransform5 != null)
			{
				_oType3WeaponRectTransform5.localScale = value;
			}
		}
	}

	public Sprite Type3WeaponSprite1
	{
		get
		{
			if (_oType3WeaponImage1 != null)
			{
				return _oType3WeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (Type3WeaponSprite1 != value && _oType3WeaponImage1 != null)
			{
				_oType3WeaponImage1.sprite = value;
			}
		}
	}

	public Sprite Type3WeaponSprite2
	{
		get
		{
			if (_oType3WeaponImage2 != null)
			{
				return _oType3WeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (Type3WeaponSprite2 != value && _oType3WeaponImage2 != null)
			{
				_oType3WeaponImage2.sprite = value;
			}
		}
	}

	public Sprite Type3WeaponSprite3
	{
		get
		{
			if (_oType3WeaponImage3 != null)
			{
				return _oType3WeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (Type3WeaponSprite3 != value && _oType3WeaponImage3 != null)
			{
				_oType3WeaponImage3.sprite = value;
			}
		}
	}

	public Sprite Type3WeaponSprite4
	{
		get
		{
			if (_oType3WeaponImage4 != null)
			{
				return _oType3WeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (Type3WeaponSprite4 != value && _oType3WeaponImage4 != null)
			{
				_oType3WeaponImage4.sprite = value;
			}
		}
	}

	public Sprite Type3WeaponSprite5
	{
		get
		{
			if (_oType3WeaponImage5 != null)
			{
				return _oType3WeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (Type3WeaponSprite5 != value && _oType3WeaponImage5 != null)
			{
				_oType3WeaponImage5.sprite = value;
			}
		}
	}

	public Image Type3WeaponImage1
	{
		get
		{
			if (_oType3WeaponImage1 != null)
			{
				return _oType3WeaponImage1;
			}
			return null;
		}
		set
		{
			if (Type3WeaponImage1 != value && _oType3WeaponImage1 != null)
			{
				_oType3WeaponImage1 = value;
			}
		}
	}

	public Image Type3WeaponImage2
	{
		get
		{
			if (_oType3WeaponImage2 != null)
			{
				return _oType3WeaponImage2;
			}
			return null;
		}
		set
		{
			if (Type3WeaponImage2 != value && _oType3WeaponImage2 != null)
			{
				_oType3WeaponImage2 = value;
			}
		}
	}

	public Image Type3WeaponImage3
	{
		get
		{
			if (_oType3WeaponImage3 != null)
			{
				return _oType3WeaponImage3;
			}
			return null;
		}
		set
		{
			if (Type3WeaponImage3 != value && _oType3WeaponImage3 != null)
			{
				_oType3WeaponImage3 = value;
			}
		}
	}

	public Image Type3WeaponImage4
	{
		get
		{
			if (_oType3WeaponImage4 != null)
			{
				return _oType3WeaponImage4;
			}
			return null;
		}
		set
		{
			if (Type3WeaponImage4 != value && _oType3WeaponImage4 != null)
			{
				_oType3WeaponImage4 = value;
			}
		}
	}

	public Image Type3WeaponImage5
	{
		get
		{
			if (_oType3WeaponImage5 != null)
			{
				return _oType3WeaponImage5;
			}
			return null;
		}
		set
		{
			if (Type3WeaponImage5 != value && _oType3WeaponImage5 != null)
			{
				_oType3WeaponImage5 = value;
			}
		}
	}

	public bool CloseShow
	{
		get
		{
			if (_oClose != null)
			{
				return _oClose.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CloseShow != value && _oClose != null)
			{
				_oClose.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> CloseTriggers
	{
		get
		{
			if (_oCloseEventTrigger != null)
			{
				return _oCloseEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseTriggers != value && _oCloseEventTrigger != null)
			{
				_oCloseEventTrigger.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent CloseClicked
	{
		get
		{
			if (_oCloseButton != null)
			{
				return _oCloseButton.onClick;
			}
			return null;
		}
		set
		{
			if (CloseClicked != value && _oCloseButton != null)
			{
				_oCloseButton.onClick = value;
			}
		}
	}

	public bool CloseButtonable
	{
		get
		{
			if (_oCloseButton != null)
			{
				return _oCloseButton.interactable;
			}
			return true;
		}
		set
		{
			if (CloseButtonable != value && _oCloseButton != null)
			{
				_oCloseButton.interactable = value;
			}
		}
	}

	public bool TypeShow1
	{
		get
		{
			if (_oType1 != null)
			{
				return _oType1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow1 != value && _oType1 != null)
			{
				_oType1.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow2
	{
		get
		{
			if (_oType2 != null)
			{
				return _oType2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow2 != value && _oType2 != null)
			{
				_oType2.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow3
	{
		get
		{
			if (_oType3 != null)
			{
				return _oType3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow3 != value && _oType3 != null)
			{
				_oType3.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow4
	{
		get
		{
			if (_oType4 != null)
			{
				return _oType4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow4 != value && _oType4 != null)
			{
				_oType4.SetObjectActive(value);
			}
		}
	}

	public Image TypeImage1
	{
		get
		{
			if (_oTypeImage1 != null)
			{
				return _oTypeImage1;
			}
			return null;
		}
		set
		{
			if (TypeImage1 != value && _oTypeImage1 != null)
			{
				_oTypeImage1 = value;
			}
		}
	}

	public Image TypeImage2
	{
		get
		{
			if (_oTypeImage2 != null)
			{
				return _oTypeImage2;
			}
			return null;
		}
		set
		{
			if (TypeImage2 != value && _oTypeImage2 != null)
			{
				_oTypeImage2 = value;
			}
		}
	}

	public Image TypeImage3
	{
		get
		{
			if (_oTypeImage3 != null)
			{
				return _oTypeImage3;
			}
			return null;
		}
		set
		{
			if (TypeImage3 != value && _oTypeImage3 != null)
			{
				_oTypeImage3 = value;
			}
		}
	}

	public Image TypeImage4
	{
		get
		{
			if (_oTypeImage4 != null)
			{
				return _oTypeImage4;
			}
			return null;
		}
		set
		{
			if (TypeImage4 != value && _oTypeImage4 != null)
			{
				_oTypeImage4 = value;
			}
		}
	}

	public List<EventTrigger.Entry> TypeTriggers1
	{
		get
		{
			if (_oTypeEventTrigger1 != null)
			{
				return _oTypeEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (TypeTriggers1 != value && _oTypeEventTrigger1 != null)
			{
				_oTypeEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TypeTriggers2
	{
		get
		{
			if (_oTypeEventTrigger2 != null)
			{
				return _oTypeEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (TypeTriggers2 != value && _oTypeEventTrigger2 != null)
			{
				_oTypeEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TypeTriggers3
	{
		get
		{
			if (_oTypeEventTrigger3 != null)
			{
				return _oTypeEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (TypeTriggers3 != value && _oTypeEventTrigger3 != null)
			{
				_oTypeEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TypeTriggers4
	{
		get
		{
			if (_oTypeEventTrigger4 != null)
			{
				return _oTypeEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (TypeTriggers4 != value && _oTypeEventTrigger4 != null)
			{
				_oTypeEventTrigger4.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent TypeClicked1
	{
		get
		{
			if (_oTypeButton1 != null)
			{
				return _oTypeButton1.onClick;
			}
			return null;
		}
		set
		{
			if (TypeClicked1 != value && _oTypeButton1 != null)
			{
				_oTypeButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent TypeClicked2
	{
		get
		{
			if (_oTypeButton2 != null)
			{
				return _oTypeButton2.onClick;
			}
			return null;
		}
		set
		{
			if (TypeClicked2 != value && _oTypeButton2 != null)
			{
				_oTypeButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent TypeClicked3
	{
		get
		{
			if (_oTypeButton3 != null)
			{
				return _oTypeButton3.onClick;
			}
			return null;
		}
		set
		{
			if (TypeClicked3 != value && _oTypeButton3 != null)
			{
				_oTypeButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent TypeClicked4
	{
		get
		{
			if (_oTypeButton4 != null)
			{
				return _oTypeButton4.onClick;
			}
			return null;
		}
		set
		{
			if (TypeClicked4 != value && _oTypeButton4 != null)
			{
				_oTypeButton4.onClick = value;
			}
		}
	}

	public bool TypeButtonable1
	{
		get
		{
			if (_oTypeButton1 != null)
			{
				return _oTypeButton1.interactable;
			}
			return true;
		}
		set
		{
			if (TypeButtonable1 != value && _oTypeButton1 != null)
			{
				_oTypeButton1.interactable = value;
			}
		}
	}

	public bool TypeButtonable2
	{
		get
		{
			if (_oTypeButton2 != null)
			{
				return _oTypeButton2.interactable;
			}
			return true;
		}
		set
		{
			if (TypeButtonable2 != value && _oTypeButton2 != null)
			{
				_oTypeButton2.interactable = value;
			}
		}
	}

	public bool TypeButtonable3
	{
		get
		{
			if (_oTypeButton3 != null)
			{
				return _oTypeButton3.interactable;
			}
			return true;
		}
		set
		{
			if (TypeButtonable3 != value && _oTypeButton3 != null)
			{
				_oTypeButton3.interactable = value;
			}
		}
	}

	public bool TypeButtonable4
	{
		get
		{
			if (_oTypeButton4 != null)
			{
				return _oTypeButton4.interactable;
			}
			return true;
		}
		set
		{
			if (TypeButtonable4 != value && _oTypeButton4 != null)
			{
				_oTypeButton4.interactable = value;
			}
		}
	}

	public bool TypeChooseShow1
	{
		get
		{
			if (_oTypeChoose1 != null)
			{
				return _oTypeChoose1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeChooseShow1 != value && _oTypeChoose1 != null)
			{
				_oTypeChoose1.SetObjectActive(value);
			}
		}
	}

	public bool TypeChooseShow2
	{
		get
		{
			if (_oTypeChoose2 != null)
			{
				return _oTypeChoose2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeChooseShow2 != value && _oTypeChoose2 != null)
			{
				_oTypeChoose2.SetObjectActive(value);
			}
		}
	}

	public bool TypeChooseShow3
	{
		get
		{
			if (_oTypeChoose3 != null)
			{
				return _oTypeChoose3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeChooseShow3 != value && _oTypeChoose3 != null)
			{
				_oTypeChoose3.SetObjectActive(value);
			}
		}
	}

	public bool TypeChooseShow4
	{
		get
		{
			if (_oTypeChoose4 != null)
			{
				return _oTypeChoose4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeChooseShow4 != value && _oTypeChoose4 != null)
			{
				_oTypeChoose4.SetObjectActive(value);
			}
		}
	}

	public bool StartShow
	{
		get
		{
			if (_oStart != null)
			{
				return _oStart.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StartShow != value && _oStart != null)
			{
				_oStart.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> StartTriggers
	{
		get
		{
			if (_oStartEventTrigger != null)
			{
				return _oStartEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (StartTriggers != value && _oStartEventTrigger != null)
			{
				_oStartEventTrigger.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent StartClicked
	{
		get
		{
			if (_oStartButton != null)
			{
				return _oStartButton.onClick;
			}
			return null;
		}
		set
		{
			if (StartClicked != value && _oStartButton != null)
			{
				_oStartButton.onClick = value;
			}
		}
	}

	public bool StartButtonable
	{
		get
		{
			if (_oStartButton != null)
			{
				return _oStartButton.interactable;
			}
			return true;
		}
		set
		{
			if (StartButtonable != value && _oStartButton != null)
			{
				_oStartButton.interactable = value;
			}
		}
	}

	public bool ChooseTypeShow
	{
		get
		{
			if (_oChooseType != null)
			{
				return _oChooseType.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseTypeShow != value && _oChooseType != null)
			{
				_oChooseType.SetObjectActive(value);
			}
		}
	}

	public bool ChooseTypeShadowShow1
	{
		get
		{
			if (_oChooseTypeShadow1 != null)
			{
				return _oChooseTypeShadow1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseTypeShadowShow1 != value && _oChooseTypeShadow1 != null)
			{
				_oChooseTypeShadow1.SetObjectActive(value);
			}
		}
	}

	public bool ChooseTypeShadowShow2
	{
		get
		{
			if (_oChooseTypeShadow2 != null)
			{
				return _oChooseTypeShadow2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseTypeShadowShow2 != value && _oChooseTypeShadow2 != null)
			{
				_oChooseTypeShadow2.SetObjectActive(value);
			}
		}
	}

	public bool ChooseTypeShadowShow3
	{
		get
		{
			if (_oChooseTypeShadow3 != null)
			{
				return _oChooseTypeShadow3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseTypeShadowShow3 != value && _oChooseTypeShadow3 != null)
			{
				_oChooseTypeShadow3.SetObjectActive(value);
			}
		}
	}

	public bool ChooseTypeShadowShow4
	{
		get
		{
			if (_oChooseTypeShadow4 != null)
			{
				return _oChooseTypeShadow4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseTypeShadowShow4 != value && _oChooseTypeShadow4 != null)
			{
				_oChooseTypeShadow4.SetObjectActive(value);
			}
		}
	}

	public Vector3 WeaponScale1
	{
		get
		{
			if (_oWeaponRectTransform1 != null)
			{
				return _oWeaponRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale1 != value && _oWeaponRectTransform1 != null)
			{
				_oWeaponRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale2
	{
		get
		{
			if (_oWeaponRectTransform2 != null)
			{
				return _oWeaponRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale2 != value && _oWeaponRectTransform2 != null)
			{
				_oWeaponRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale3
	{
		get
		{
			if (_oWeaponRectTransform3 != null)
			{
				return _oWeaponRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale3 != value && _oWeaponRectTransform3 != null)
			{
				_oWeaponRectTransform3.localScale = value;
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
			case "ChooseAll":
				_oChooseAll = transform.gameObject;
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
			case "Choose1":
				_oChoose1 = transform.gameObject;
				_oChooseEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oChooseButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Choose2":
				_oChoose2 = transform.gameObject;
				_oChooseEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oChooseButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Choose3":
				_oChoose3 = transform.gameObject;
				_oChooseEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oChooseButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Scoll1":
				_oScoll1 = transform.gameObject;
				_oScollRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Scoll2":
				_oScoll2 = transform.gameObject;
				_oScollRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Scoll3":
				_oScoll3 = transform.gameObject;
				_oScollRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Type1Weapon1":
				_oType1Weapon1 = transform.gameObject;
				_oType1WeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oType1WeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type1Weapon2":
				_oType1Weapon2 = transform.gameObject;
				_oType1WeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oType1WeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type1Weapon3":
				_oType1Weapon3 = transform.gameObject;
				_oType1WeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oType1WeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type1Weapon4":
				_oType1Weapon4 = transform.gameObject;
				_oType1WeaponRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oType1WeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type1Weapon5":
				_oType1Weapon5 = transform.gameObject;
				_oType1WeaponRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oType1WeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2Weapon1":
				_oType2Weapon1 = transform.gameObject;
				_oType2WeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oType2WeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2Weapon2":
				_oType2Weapon2 = transform.gameObject;
				_oType2WeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oType2WeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2Weapon3":
				_oType2Weapon3 = transform.gameObject;
				_oType2WeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oType2WeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2Weapon4":
				_oType2Weapon4 = transform.gameObject;
				_oType2WeaponRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oType2WeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2Weapon5":
				_oType2Weapon5 = transform.gameObject;
				_oType2WeaponRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oType2WeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3Weapon1":
				_oType3Weapon1 = transform.gameObject;
				_oType3WeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oType3WeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3Weapon2":
				_oType3Weapon2 = transform.gameObject;
				_oType3WeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oType3WeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3Weapon3":
				_oType3Weapon3 = transform.gameObject;
				_oType3WeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oType3WeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3Weapon4":
				_oType3Weapon4 = transform.gameObject;
				_oType3WeaponRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oType3WeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3Weapon5":
				_oType3Weapon5 = transform.gameObject;
				_oType3WeaponRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oType3WeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCloseButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Type1":
				_oType1 = transform.gameObject;
				_oTypeImage1 = transform.gameObject.GetComponent<Image>();
				_oTypeEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oTypeButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Type2":
				_oType2 = transform.gameObject;
				_oTypeImage2 = transform.gameObject.GetComponent<Image>();
				_oTypeEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oTypeButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Type3":
				_oType3 = transform.gameObject;
				_oTypeImage3 = transform.gameObject.GetComponent<Image>();
				_oTypeEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oTypeButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Type4":
				_oType4 = transform.gameObject;
				_oTypeImage4 = transform.gameObject.GetComponent<Image>();
				_oTypeEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				_oTypeButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "TypeChoose1":
				_oTypeChoose1 = transform.gameObject;
				break;
			case "TypeChoose2":
				_oTypeChoose2 = transform.gameObject;
				break;
			case "TypeChoose3":
				_oTypeChoose3 = transform.gameObject;
				break;
			case "TypeChoose4":
				_oTypeChoose4 = transform.gameObject;
				break;
			case "Start":
				_oStart = transform.gameObject;
				_oStartEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oStartButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ChooseType":
				_oChooseType = transform.gameObject;
				break;
			case "ChooseTypeShadow1":
				_oChooseTypeShadow1 = transform.gameObject;
				break;
			case "ChooseTypeShadow2":
				_oChooseTypeShadow2 = transform.gameObject;
				break;
			case "ChooseTypeShadow3":
				_oChooseTypeShadow3 = transform.gameObject;
				break;
			case "ChooseTypeShadow4":
				_oChooseTypeShadow4 = transform.gameObject;
				break;
			case "Weapon1":
				_oWeapon1 = transform.gameObject;
				_oWeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				_oWeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				_oWeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage3 = transform.gameObject.GetComponent<Image>();
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

	public string GetWeaponNameString(int index)
	{
		return index switch
		{
			1 => WeaponNameString1, 
			2 => WeaponNameString2, 
			3 => WeaponNameString3, 
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
		}
	}

	public int GetWeaponNameCount()
	{
		return 3;
	}

	public bool GetChooseShow(int index)
	{
		return index switch
		{
			1 => ChooseShow1, 
			2 => ChooseShow2, 
			3 => ChooseShow3, 
			_ => false, 
		};
	}

	public void SetChooseShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ChooseShow1 = value;
			break;
		case 2:
			ChooseShow2 = value;
			break;
		case 3:
			ChooseShow3 = value;
			break;
		}
	}

	public int GetChooseCount()
	{
		return 3;
	}

	private void CreateChooseTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers1, eventId, callback);
	}

	private void RemoveChooseTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers1, eventId);
	}

	private void CreateChooseTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers2, eventId, callback);
	}

	private void RemoveChooseTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers2, eventId);
	}

	private void CreateChooseTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers3, eventId, callback);
	}

	private void RemoveChooseTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers3, eventId);
	}

	public List<EventTrigger.Entry> GetChooseTriggers(int index)
	{
		return index switch
		{
			1 => ChooseTriggers1, 
			2 => ChooseTriggers2, 
			3 => ChooseTriggers3, 
			_ => null, 
		};
	}

	public void SetChooseTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			ChooseTriggers1 = value;
			break;
		case 2:
			ChooseTriggers2 = value;
			break;
		case 3:
			ChooseTriggers3 = value;
			break;
		}
	}

	private void CreateChooseTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetChooseTriggers(index), eventId, callback);
	}

	private void RemoveChooseTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetChooseTriggers(index), eventId);
	}

	public Button.ButtonClickedEvent GetChooseClicked(int index)
	{
		return index switch
		{
			1 => ChooseClicked1, 
			2 => ChooseClicked2, 
			3 => ChooseClicked3, 
			_ => null, 
		};
	}

	public void SetChooseClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			ChooseClicked1 = value;
			break;
		case 2:
			ChooseClicked2 = value;
			break;
		case 3:
			ChooseClicked3 = value;
			break;
		}
	}

	public bool GetChooseButtonable(int index)
	{
		return index switch
		{
			1 => ChooseButtonable1, 
			2 => ChooseButtonable2, 
			3 => ChooseButtonable3, 
			_ => true, 
		};
	}

	public void SetChooseButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ChooseButtonable1 = value;
			break;
		case 2:
			ChooseButtonable2 = value;
			break;
		case 3:
			ChooseButtonable3 = value;
			break;
		}
	}

	public GameObject GetScollObj(int index)
	{
		return index switch
		{
			1 => ScollObj1, 
			2 => ScollObj2, 
			3 => ScollObj3, 
			_ => null, 
		};
	}

	public int GetScollCount()
	{
		return 3;
	}

	public Vector3 GetScollPosition(int index)
	{
		return index switch
		{
			1 => ScollPosition1, 
			2 => ScollPosition2, 
			3 => ScollPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetScollPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			ScollPosition1 = value;
			break;
		case 2:
			ScollPosition2 = value;
			break;
		case 3:
			ScollPosition3 = value;
			break;
		}
	}

	public GameObject GetType1WeaponObj(int index)
	{
		return index switch
		{
			1 => Type1WeaponObj1, 
			2 => Type1WeaponObj2, 
			3 => Type1WeaponObj3, 
			4 => Type1WeaponObj4, 
			5 => Type1WeaponObj5, 
			_ => null, 
		};
	}

	public int GetType1WeaponCount()
	{
		return 5;
	}

	public Vector3 GetType1WeaponPosition(int index)
	{
		return index switch
		{
			1 => Type1WeaponPosition1, 
			2 => Type1WeaponPosition2, 
			3 => Type1WeaponPosition3, 
			4 => Type1WeaponPosition4, 
			5 => Type1WeaponPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType1WeaponPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type1WeaponPosition1 = value;
			break;
		case 2:
			Type1WeaponPosition2 = value;
			break;
		case 3:
			Type1WeaponPosition3 = value;
			break;
		case 4:
			Type1WeaponPosition4 = value;
			break;
		case 5:
			Type1WeaponPosition5 = value;
			break;
		}
	}

	public Vector3 GetType1WeaponScale(int index)
	{
		return index switch
		{
			1 => Type1WeaponScale1, 
			2 => Type1WeaponScale2, 
			3 => Type1WeaponScale3, 
			4 => Type1WeaponScale4, 
			5 => Type1WeaponScale5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType1WeaponScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type1WeaponScale1 = value;
			break;
		case 2:
			Type1WeaponScale2 = value;
			break;
		case 3:
			Type1WeaponScale3 = value;
			break;
		case 4:
			Type1WeaponScale4 = value;
			break;
		case 5:
			Type1WeaponScale5 = value;
			break;
		}
	}

	public Sprite GetType1WeaponSprite(int index)
	{
		return index switch
		{
			1 => Type1WeaponSprite1, 
			2 => Type1WeaponSprite2, 
			3 => Type1WeaponSprite3, 
			4 => Type1WeaponSprite4, 
			5 => Type1WeaponSprite5, 
			_ => null, 
		};
	}

	public void SetType1WeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			Type1WeaponSprite1 = value;
			break;
		case 2:
			Type1WeaponSprite2 = value;
			break;
		case 3:
			Type1WeaponSprite3 = value;
			break;
		case 4:
			Type1WeaponSprite4 = value;
			break;
		case 5:
			Type1WeaponSprite5 = value;
			break;
		}
	}

	public Image GetType1WeaponImage(int index)
	{
		return index switch
		{
			1 => Type1WeaponImage1, 
			2 => Type1WeaponImage2, 
			3 => Type1WeaponImage3, 
			4 => Type1WeaponImage4, 
			5 => Type1WeaponImage5, 
			_ => null, 
		};
	}

	public void SetType1WeaponImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			Type1WeaponImage1 = value;
			break;
		case 2:
			Type1WeaponImage2 = value;
			break;
		case 3:
			Type1WeaponImage3 = value;
			break;
		case 4:
			Type1WeaponImage4 = value;
			break;
		case 5:
			Type1WeaponImage5 = value;
			break;
		}
	}

	public void Type1WeaponNtvsize1()
	{
		if (_oType1WeaponImage1 != null)
		{
			_oType1WeaponImage1.SetNativeSize();
		}
	}

	public void Type1WeaponNtvsize2()
	{
		if (_oType1WeaponImage2 != null)
		{
			_oType1WeaponImage2.SetNativeSize();
		}
	}

	public void Type1WeaponNtvsize3()
	{
		if (_oType1WeaponImage3 != null)
		{
			_oType1WeaponImage3.SetNativeSize();
		}
	}

	public void Type1WeaponNtvsize4()
	{
		if (_oType1WeaponImage4 != null)
		{
			_oType1WeaponImage4.SetNativeSize();
		}
	}

	public void Type1WeaponNtvsize5()
	{
		if (_oType1WeaponImage5 != null)
		{
			_oType1WeaponImage5.SetNativeSize();
		}
	}

	public void CallType1WeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			Type1WeaponNtvsize1();
			break;
		case 2:
			Type1WeaponNtvsize2();
			break;
		case 3:
			Type1WeaponNtvsize3();
			break;
		case 4:
			Type1WeaponNtvsize4();
			break;
		case 5:
			Type1WeaponNtvsize5();
			break;
		}
	}

	public GameObject GetType2WeaponObj(int index)
	{
		return index switch
		{
			1 => Type2WeaponObj1, 
			2 => Type2WeaponObj2, 
			3 => Type2WeaponObj3, 
			4 => Type2WeaponObj4, 
			5 => Type2WeaponObj5, 
			_ => null, 
		};
	}

	public int GetType2WeaponCount()
	{
		return 5;
	}

	public Vector3 GetType2WeaponPosition(int index)
	{
		return index switch
		{
			1 => Type2WeaponPosition1, 
			2 => Type2WeaponPosition2, 
			3 => Type2WeaponPosition3, 
			4 => Type2WeaponPosition4, 
			5 => Type2WeaponPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType2WeaponPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type2WeaponPosition1 = value;
			break;
		case 2:
			Type2WeaponPosition2 = value;
			break;
		case 3:
			Type2WeaponPosition3 = value;
			break;
		case 4:
			Type2WeaponPosition4 = value;
			break;
		case 5:
			Type2WeaponPosition5 = value;
			break;
		}
	}

	public Vector3 GetType2WeaponScale(int index)
	{
		return index switch
		{
			1 => Type2WeaponScale1, 
			2 => Type2WeaponScale2, 
			3 => Type2WeaponScale3, 
			4 => Type2WeaponScale4, 
			5 => Type2WeaponScale5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType2WeaponScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type2WeaponScale1 = value;
			break;
		case 2:
			Type2WeaponScale2 = value;
			break;
		case 3:
			Type2WeaponScale3 = value;
			break;
		case 4:
			Type2WeaponScale4 = value;
			break;
		case 5:
			Type2WeaponScale5 = value;
			break;
		}
	}

	public Sprite GetType2WeaponSprite(int index)
	{
		return index switch
		{
			1 => Type2WeaponSprite1, 
			2 => Type2WeaponSprite2, 
			3 => Type2WeaponSprite3, 
			4 => Type2WeaponSprite4, 
			5 => Type2WeaponSprite5, 
			_ => null, 
		};
	}

	public void SetType2WeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			Type2WeaponSprite1 = value;
			break;
		case 2:
			Type2WeaponSprite2 = value;
			break;
		case 3:
			Type2WeaponSprite3 = value;
			break;
		case 4:
			Type2WeaponSprite4 = value;
			break;
		case 5:
			Type2WeaponSprite5 = value;
			break;
		}
	}

	public Image GetType2WeaponImage(int index)
	{
		return index switch
		{
			1 => Type2WeaponImage1, 
			2 => Type2WeaponImage2, 
			3 => Type2WeaponImage3, 
			4 => Type2WeaponImage4, 
			5 => Type2WeaponImage5, 
			_ => null, 
		};
	}

	public void SetType2WeaponImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			Type2WeaponImage1 = value;
			break;
		case 2:
			Type2WeaponImage2 = value;
			break;
		case 3:
			Type2WeaponImage3 = value;
			break;
		case 4:
			Type2WeaponImage4 = value;
			break;
		case 5:
			Type2WeaponImage5 = value;
			break;
		}
	}

	public void Type2WeaponNtvsize1()
	{
		if (_oType2WeaponImage1 != null)
		{
			_oType2WeaponImage1.SetNativeSize();
		}
	}

	public void Type2WeaponNtvsize2()
	{
		if (_oType2WeaponImage2 != null)
		{
			_oType2WeaponImage2.SetNativeSize();
		}
	}

	public void Type2WeaponNtvsize3()
	{
		if (_oType2WeaponImage3 != null)
		{
			_oType2WeaponImage3.SetNativeSize();
		}
	}

	public void Type2WeaponNtvsize4()
	{
		if (_oType2WeaponImage4 != null)
		{
			_oType2WeaponImage4.SetNativeSize();
		}
	}

	public void Type2WeaponNtvsize5()
	{
		if (_oType2WeaponImage5 != null)
		{
			_oType2WeaponImage5.SetNativeSize();
		}
	}

	public void CallType2WeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			Type2WeaponNtvsize1();
			break;
		case 2:
			Type2WeaponNtvsize2();
			break;
		case 3:
			Type2WeaponNtvsize3();
			break;
		case 4:
			Type2WeaponNtvsize4();
			break;
		case 5:
			Type2WeaponNtvsize5();
			break;
		}
	}

	public GameObject GetType3WeaponObj(int index)
	{
		return index switch
		{
			1 => Type3WeaponObj1, 
			2 => Type3WeaponObj2, 
			3 => Type3WeaponObj3, 
			4 => Type3WeaponObj4, 
			5 => Type3WeaponObj5, 
			_ => null, 
		};
	}

	public int GetType3WeaponCount()
	{
		return 5;
	}

	public Vector3 GetType3WeaponPosition(int index)
	{
		return index switch
		{
			1 => Type3WeaponPosition1, 
			2 => Type3WeaponPosition2, 
			3 => Type3WeaponPosition3, 
			4 => Type3WeaponPosition4, 
			5 => Type3WeaponPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType3WeaponPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type3WeaponPosition1 = value;
			break;
		case 2:
			Type3WeaponPosition2 = value;
			break;
		case 3:
			Type3WeaponPosition3 = value;
			break;
		case 4:
			Type3WeaponPosition4 = value;
			break;
		case 5:
			Type3WeaponPosition5 = value;
			break;
		}
	}

	public Vector3 GetType3WeaponScale(int index)
	{
		return index switch
		{
			1 => Type3WeaponScale1, 
			2 => Type3WeaponScale2, 
			3 => Type3WeaponScale3, 
			4 => Type3WeaponScale4, 
			5 => Type3WeaponScale5, 
			_ => Vector3.zero, 
		};
	}

	public void SetType3WeaponScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			Type3WeaponScale1 = value;
			break;
		case 2:
			Type3WeaponScale2 = value;
			break;
		case 3:
			Type3WeaponScale3 = value;
			break;
		case 4:
			Type3WeaponScale4 = value;
			break;
		case 5:
			Type3WeaponScale5 = value;
			break;
		}
	}

	public Sprite GetType3WeaponSprite(int index)
	{
		return index switch
		{
			1 => Type3WeaponSprite1, 
			2 => Type3WeaponSprite2, 
			3 => Type3WeaponSprite3, 
			4 => Type3WeaponSprite4, 
			5 => Type3WeaponSprite5, 
			_ => null, 
		};
	}

	public void SetType3WeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			Type3WeaponSprite1 = value;
			break;
		case 2:
			Type3WeaponSprite2 = value;
			break;
		case 3:
			Type3WeaponSprite3 = value;
			break;
		case 4:
			Type3WeaponSprite4 = value;
			break;
		case 5:
			Type3WeaponSprite5 = value;
			break;
		}
	}

	public Image GetType3WeaponImage(int index)
	{
		return index switch
		{
			1 => Type3WeaponImage1, 
			2 => Type3WeaponImage2, 
			3 => Type3WeaponImage3, 
			4 => Type3WeaponImage4, 
			5 => Type3WeaponImage5, 
			_ => null, 
		};
	}

	public void SetType3WeaponImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			Type3WeaponImage1 = value;
			break;
		case 2:
			Type3WeaponImage2 = value;
			break;
		case 3:
			Type3WeaponImage3 = value;
			break;
		case 4:
			Type3WeaponImage4 = value;
			break;
		case 5:
			Type3WeaponImage5 = value;
			break;
		}
	}

	public void Type3WeaponNtvsize1()
	{
		if (_oType3WeaponImage1 != null)
		{
			_oType3WeaponImage1.SetNativeSize();
		}
	}

	public void Type3WeaponNtvsize2()
	{
		if (_oType3WeaponImage2 != null)
		{
			_oType3WeaponImage2.SetNativeSize();
		}
	}

	public void Type3WeaponNtvsize3()
	{
		if (_oType3WeaponImage3 != null)
		{
			_oType3WeaponImage3.SetNativeSize();
		}
	}

	public void Type3WeaponNtvsize4()
	{
		if (_oType3WeaponImage4 != null)
		{
			_oType3WeaponImage4.SetNativeSize();
		}
	}

	public void Type3WeaponNtvsize5()
	{
		if (_oType3WeaponImage5 != null)
		{
			_oType3WeaponImage5.SetNativeSize();
		}
	}

	public void CallType3WeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			Type3WeaponNtvsize1();
			break;
		case 2:
			Type3WeaponNtvsize2();
			break;
		case 3:
			Type3WeaponNtvsize3();
			break;
		case 4:
			Type3WeaponNtvsize4();
			break;
		case 5:
			Type3WeaponNtvsize5();
			break;
		}
	}

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
	}

	public bool GetTypeShow(int index)
	{
		return index switch
		{
			1 => TypeShow1, 
			2 => TypeShow2, 
			3 => TypeShow3, 
			4 => TypeShow4, 
			_ => false, 
		};
	}

	public void SetTypeShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TypeShow1 = value;
			break;
		case 2:
			TypeShow2 = value;
			break;
		case 3:
			TypeShow3 = value;
			break;
		case 4:
			TypeShow4 = value;
			break;
		}
	}

	public int GetTypeCount()
	{
		return 4;
	}

	public Image GetTypeImage(int index)
	{
		return index switch
		{
			1 => TypeImage1, 
			2 => TypeImage2, 
			3 => TypeImage3, 
			4 => TypeImage4, 
			_ => null, 
		};
	}

	public void SetTypeImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			TypeImage1 = value;
			break;
		case 2:
			TypeImage2 = value;
			break;
		case 3:
			TypeImage3 = value;
			break;
		case 4:
			TypeImage4 = value;
			break;
		}
	}

	private void CreateTypeTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TypeTriggers1, eventId, callback);
	}

	private void RemoveTypeTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TypeTriggers1, eventId);
	}

	private void CreateTypeTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TypeTriggers2, eventId, callback);
	}

	private void RemoveTypeTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TypeTriggers2, eventId);
	}

	private void CreateTypeTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TypeTriggers3, eventId, callback);
	}

	private void RemoveTypeTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TypeTriggers3, eventId);
	}

	private void CreateTypeTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TypeTriggers4, eventId, callback);
	}

	private void RemoveTypeTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TypeTriggers4, eventId);
	}

	public List<EventTrigger.Entry> GetTypeTriggers(int index)
	{
		return index switch
		{
			1 => TypeTriggers1, 
			2 => TypeTriggers2, 
			3 => TypeTriggers3, 
			4 => TypeTriggers4, 
			_ => null, 
		};
	}

	public void SetTypeTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			TypeTriggers1 = value;
			break;
		case 2:
			TypeTriggers2 = value;
			break;
		case 3:
			TypeTriggers3 = value;
			break;
		case 4:
			TypeTriggers4 = value;
			break;
		}
	}

	private void CreateTypeTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetTypeTriggers(index), eventId, callback);
	}

	private void RemoveTypeTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetTypeTriggers(index), eventId);
	}

	public Button.ButtonClickedEvent GetTypeClicked(int index)
	{
		return index switch
		{
			1 => TypeClicked1, 
			2 => TypeClicked2, 
			3 => TypeClicked3, 
			4 => TypeClicked4, 
			_ => null, 
		};
	}

	public void SetTypeClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			TypeClicked1 = value;
			break;
		case 2:
			TypeClicked2 = value;
			break;
		case 3:
			TypeClicked3 = value;
			break;
		case 4:
			TypeClicked4 = value;
			break;
		}
	}

	public bool GetTypeButtonable(int index)
	{
		return index switch
		{
			1 => TypeButtonable1, 
			2 => TypeButtonable2, 
			3 => TypeButtonable3, 
			4 => TypeButtonable4, 
			_ => true, 
		};
	}

	public void SetTypeButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TypeButtonable1 = value;
			break;
		case 2:
			TypeButtonable2 = value;
			break;
		case 3:
			TypeButtonable3 = value;
			break;
		case 4:
			TypeButtonable4 = value;
			break;
		}
	}

	public bool GetTypeChooseShow(int index)
	{
		return index switch
		{
			1 => TypeChooseShow1, 
			2 => TypeChooseShow2, 
			3 => TypeChooseShow3, 
			4 => TypeChooseShow4, 
			_ => false, 
		};
	}

	public void SetTypeChooseShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TypeChooseShow1 = value;
			break;
		case 2:
			TypeChooseShow2 = value;
			break;
		case 3:
			TypeChooseShow3 = value;
			break;
		case 4:
			TypeChooseShow4 = value;
			break;
		}
	}

	public int GetTypeChooseCount()
	{
		return 4;
	}

	private void CreateStartTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(StartTriggers, eventId, callback);
	}

	private void RemoveStartTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(StartTriggers, eventId);
	}

	public bool GetChooseTypeShadowShow(int index)
	{
		return index switch
		{
			1 => ChooseTypeShadowShow1, 
			2 => ChooseTypeShadowShow2, 
			3 => ChooseTypeShadowShow3, 
			4 => ChooseTypeShadowShow4, 
			_ => false, 
		};
	}

	public void SetChooseTypeShadowShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ChooseTypeShadowShow1 = value;
			break;
		case 2:
			ChooseTypeShadowShow2 = value;
			break;
		case 3:
			ChooseTypeShadowShow3 = value;
			break;
		case 4:
			ChooseTypeShadowShow4 = value;
			break;
		}
	}

	public int GetChooseTypeShadowCount()
	{
		return 4;
	}

	public Vector3 GetWeaponScale(int index)
	{
		return index switch
		{
			1 => WeaponScale1, 
			2 => WeaponScale2, 
			3 => WeaponScale3, 
			_ => Vector3.zero, 
		};
	}

	public void SetWeaponScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			WeaponScale1 = value;
			break;
		case 2:
			WeaponScale2 = value;
			break;
		case 3:
			WeaponScale3 = value;
			break;
		}
	}

	public int GetWeaponCount()
	{
		return 3;
	}

	public Sprite GetWeaponSprite(int index)
	{
		return index switch
		{
			1 => WeaponSprite1, 
			2 => WeaponSprite2, 
			3 => WeaponSprite3, 
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
