using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class CommontacticssoundViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private EventTrigger _oShowEventTrigger;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oSelect1;

	private GameObject _oSelect2;

	private GameObject _oSelect3;

	private GameObject _oSelect4;

	private GameObject _oSelect5;

	private GameObject _oSelect6;

	private GameObject _oSelect7;

	private GameObject _oSelect8;

	private EventTrigger _oSelectEventTrigger1;

	private EventTrigger _oSelectEventTrigger2;

	private EventTrigger _oSelectEventTrigger3;

	private EventTrigger _oSelectEventTrigger4;

	private EventTrigger _oSelectEventTrigger5;

	private EventTrigger _oSelectEventTrigger6;

	private EventTrigger _oSelectEventTrigger7;

	private EventTrigger _oSelectEventTrigger8;

	private GameObject _oSelected1;

	private GameObject _oSelected2;

	private GameObject _oSelected3;

	private GameObject _oSelected4;

	private GameObject _oSelected5;

	private GameObject _oSelected6;

	private GameObject _oSelected7;

	private GameObject _oSelected8;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private GameObject _oIcon4;

	private GameObject _oIcon5;

	private GameObject _oIcon6;

	private GameObject _oIcon7;

	private GameObject _oIcon8;

	private GameObject _oText1;

	private GameObject _oText2;

	private GameObject _oText3;

	private GameObject _oText4;

	private GameObject _oText5;

	private GameObject _oText6;

	private GameObject _oText7;

	private GameObject _oText8;

	private Text _oTextText1;

	private Text _oTextText2;

	private Text _oTextText3;

	private Text _oTextText4;

	private Text _oTextText5;

	private Text _oTextText6;

	private Text _oTextText7;

	private Text _oTextText8;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _oLeftTips;

	private Image _oLeftTipsImage;

	private GameObject _oRightTips;

	private Image _oRightTipsImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "commontacticssound";

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

	public GameObject ShowObj => _oShow;

	public bool ShowRootshow
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
			if (ShowRootshow == value || !(_oShow != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oShow.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oShow.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ShowTriggers
	{
		get
		{
			if (_oShowEventTrigger != null)
			{
				return _oShowEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ShowTriggers != value && _oShowEventTrigger != null)
			{
				_oShowEventTrigger.triggers = value;
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public Image BackImage
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage;
			}
			return null;
		}
		set
		{
			if (BackImage != value && _oBackImage != null)
			{
				_oBackImage = value;
			}
		}
	}

	public GameObject SelectObj1 => _oSelect1;

	public GameObject SelectObj2 => _oSelect2;

	public GameObject SelectObj3 => _oSelect3;

	public GameObject SelectObj4 => _oSelect4;

	public GameObject SelectObj5 => _oSelect5;

	public GameObject SelectObj6 => _oSelect6;

	public GameObject SelectObj7 => _oSelect7;

	public GameObject SelectObj8 => _oSelect8;

	public List<EventTrigger.Entry> SelectTriggers1
	{
		get
		{
			if (_oSelectEventTrigger1 != null)
			{
				return _oSelectEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers1 != value && _oSelectEventTrigger1 != null)
			{
				_oSelectEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers2
	{
		get
		{
			if (_oSelectEventTrigger2 != null)
			{
				return _oSelectEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers2 != value && _oSelectEventTrigger2 != null)
			{
				_oSelectEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers3
	{
		get
		{
			if (_oSelectEventTrigger3 != null)
			{
				return _oSelectEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers3 != value && _oSelectEventTrigger3 != null)
			{
				_oSelectEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers4
	{
		get
		{
			if (_oSelectEventTrigger4 != null)
			{
				return _oSelectEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers4 != value && _oSelectEventTrigger4 != null)
			{
				_oSelectEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers5
	{
		get
		{
			if (_oSelectEventTrigger5 != null)
			{
				return _oSelectEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers5 != value && _oSelectEventTrigger5 != null)
			{
				_oSelectEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers6
	{
		get
		{
			if (_oSelectEventTrigger6 != null)
			{
				return _oSelectEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers6 != value && _oSelectEventTrigger6 != null)
			{
				_oSelectEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers7
	{
		get
		{
			if (_oSelectEventTrigger7 != null)
			{
				return _oSelectEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers7 != value && _oSelectEventTrigger7 != null)
			{
				_oSelectEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectTriggers8
	{
		get
		{
			if (_oSelectEventTrigger8 != null)
			{
				return _oSelectEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (SelectTriggers8 != value && _oSelectEventTrigger8 != null)
			{
				_oSelectEventTrigger8.triggers = value;
			}
		}
	}

	public bool SelectedShow1
	{
		get
		{
			if (_oSelected1 != null)
			{
				return _oSelected1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow1 != value && _oSelected1 != null)
			{
				_oSelected1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow2
	{
		get
		{
			if (_oSelected2 != null)
			{
				return _oSelected2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow2 != value && _oSelected2 != null)
			{
				_oSelected2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow3
	{
		get
		{
			if (_oSelected3 != null)
			{
				return _oSelected3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow3 != value && _oSelected3 != null)
			{
				_oSelected3.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow4
	{
		get
		{
			if (_oSelected4 != null)
			{
				return _oSelected4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow4 != value && _oSelected4 != null)
			{
				_oSelected4.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow5
	{
		get
		{
			if (_oSelected5 != null)
			{
				return _oSelected5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow5 != value && _oSelected5 != null)
			{
				_oSelected5.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow6
	{
		get
		{
			if (_oSelected6 != null)
			{
				return _oSelected6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow6 != value && _oSelected6 != null)
			{
				_oSelected6.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow7
	{
		get
		{
			if (_oSelected7 != null)
			{
				return _oSelected7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow7 != value && _oSelected7 != null)
			{
				_oSelected7.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow8
	{
		get
		{
			if (_oSelected8 != null)
			{
				return _oSelected8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow8 != value && _oSelected8 != null)
			{
				_oSelected8.SetObjectActive(value);
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

	public bool TextShow1
	{
		get
		{
			if (_oText1 != null)
			{
				return _oText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow1 != value && _oText1 != null)
			{
				_oText1.SetObjectActive(value);
			}
		}
	}

	public bool TextShow2
	{
		get
		{
			if (_oText2 != null)
			{
				return _oText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow2 != value && _oText2 != null)
			{
				_oText2.SetObjectActive(value);
			}
		}
	}

	public bool TextShow3
	{
		get
		{
			if (_oText3 != null)
			{
				return _oText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow3 != value && _oText3 != null)
			{
				_oText3.SetObjectActive(value);
			}
		}
	}

	public bool TextShow4
	{
		get
		{
			if (_oText4 != null)
			{
				return _oText4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow4 != value && _oText4 != null)
			{
				_oText4.SetObjectActive(value);
			}
		}
	}

	public bool TextShow5
	{
		get
		{
			if (_oText5 != null)
			{
				return _oText5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow5 != value && _oText5 != null)
			{
				_oText5.SetObjectActive(value);
			}
		}
	}

	public bool TextShow6
	{
		get
		{
			if (_oText6 != null)
			{
				return _oText6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow6 != value && _oText6 != null)
			{
				_oText6.SetObjectActive(value);
			}
		}
	}

	public bool TextShow7
	{
		get
		{
			if (_oText7 != null)
			{
				return _oText7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow7 != value && _oText7 != null)
			{
				_oText7.SetObjectActive(value);
			}
		}
	}

	public bool TextShow8
	{
		get
		{
			if (_oText8 != null)
			{
				return _oText8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow8 != value && _oText8 != null)
			{
				_oText8.SetObjectActive(value);
			}
		}
	}

	public string TextString1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.text;
			}
			return null;
		}
		set
		{
			if (TextString1 != value && _oTextText1 != null)
			{
				_oTextText1.text = value;
			}
		}
	}

	public string TextString2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.text;
			}
			return null;
		}
		set
		{
			if (TextString2 != value && _oTextText2 != null)
			{
				_oTextText2.text = value;
			}
		}
	}

	public string TextString3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.text;
			}
			return null;
		}
		set
		{
			if (TextString3 != value && _oTextText3 != null)
			{
				_oTextText3.text = value;
			}
		}
	}

	public string TextString4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.text;
			}
			return null;
		}
		set
		{
			if (TextString4 != value && _oTextText4 != null)
			{
				_oTextText4.text = value;
			}
		}
	}

	public string TextString5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.text;
			}
			return null;
		}
		set
		{
			if (TextString5 != value && _oTextText5 != null)
			{
				_oTextText5.text = value;
			}
		}
	}

	public string TextString6
	{
		get
		{
			if (_oTextText6 != null)
			{
				return _oTextText6.text;
			}
			return null;
		}
		set
		{
			if (TextString6 != value && _oTextText6 != null)
			{
				_oTextText6.text = value;
			}
		}
	}

	public string TextString7
	{
		get
		{
			if (_oTextText7 != null)
			{
				return _oTextText7.text;
			}
			return null;
		}
		set
		{
			if (TextString7 != value && _oTextText7 != null)
			{
				_oTextText7.text = value;
			}
		}
	}

	public string TextString8
	{
		get
		{
			if (_oTextText8 != null)
			{
				return _oTextText8.text;
			}
			return null;
		}
		set
		{
			if (TextString8 != value && _oTextText8 != null)
			{
				_oTextText8.text = value;
			}
		}
	}

	public Sprite TitleSprite
	{
		get
		{
			if (_oTitleImage != null)
			{
				return _oTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite != value && _oTitleImage != null)
			{
				_oTitleImage.sprite = value;
			}
		}
	}

	public bool LeftTipsShow
	{
		get
		{
			if (_oLeftTips != null)
			{
				return _oLeftTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftTipsShow != value && _oLeftTips != null)
			{
				_oLeftTips.SetObjectActive(value);
			}
		}
	}

	public Sprite LeftTipsSprite
	{
		get
		{
			if (_oLeftTipsImage != null)
			{
				return _oLeftTipsImage.sprite;
			}
			return null;
		}
		set
		{
			if (LeftTipsSprite != value && _oLeftTipsImage != null)
			{
				_oLeftTipsImage.sprite = value;
			}
		}
	}

	public bool RightTipsShow
	{
		get
		{
			if (_oRightTips != null)
			{
				return _oRightTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightTipsShow != value && _oRightTips != null)
			{
				_oRightTips.SetObjectActive(value);
			}
		}
	}

	public Sprite RightTipsSprite
	{
		get
		{
			if (_oRightTipsImage != null)
			{
				return _oRightTipsImage.sprite;
			}
			return null;
		}
		set
		{
			if (RightTipsSprite != value && _oRightTipsImage != null)
			{
				_oRightTipsImage.sprite = value;
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
				_oShowEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Select1":
				_oSelect1 = transform.gameObject;
				_oSelectEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select2":
				_oSelect2 = transform.gameObject;
				_oSelectEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select3":
				_oSelect3 = transform.gameObject;
				_oSelectEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select4":
				_oSelect4 = transform.gameObject;
				_oSelectEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select5":
				_oSelect5 = transform.gameObject;
				_oSelectEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select6":
				_oSelect6 = transform.gameObject;
				_oSelectEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select7":
				_oSelect7 = transform.gameObject;
				_oSelectEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Select8":
				_oSelect8 = transform.gameObject;
				_oSelectEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Selected1":
				_oSelected1 = transform.gameObject;
				break;
			case "Selected2":
				_oSelected2 = transform.gameObject;
				break;
			case "Selected3":
				_oSelected3 = transform.gameObject;
				break;
			case "Selected4":
				_oSelected4 = transform.gameObject;
				break;
			case "Selected5":
				_oSelected5 = transform.gameObject;
				break;
			case "Selected6":
				_oSelected6 = transform.gameObject;
				break;
			case "Selected7":
				_oSelected7 = transform.gameObject;
				break;
			case "Selected8":
				_oSelected8 = transform.gameObject;
				break;
			case "Icon1":
				_oIcon1 = transform.gameObject;
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				break;
			case "Icon4":
				_oIcon4 = transform.gameObject;
				break;
			case "Icon5":
				_oIcon5 = transform.gameObject;
				break;
			case "Icon6":
				_oIcon6 = transform.gameObject;
				break;
			case "Icon7":
				_oIcon7 = transform.gameObject;
				break;
			case "Icon8":
				_oIcon8 = transform.gameObject;
				break;
			case "Text1":
				_oText1 = transform.gameObject;
				_oTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text2":
				_oText2 = transform.gameObject;
				_oTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text3":
				_oText3 = transform.gameObject;
				_oTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text4":
				_oText4 = transform.gameObject;
				_oTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text5":
				_oText5 = transform.gameObject;
				_oTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text6":
				_oText6 = transform.gameObject;
				_oTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text7":
				_oText7 = transform.gameObject;
				_oTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text8":
				_oText8 = transform.gameObject;
				_oTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LeftTips":
				_oLeftTips = transform.gameObject;
				_oLeftTipsImage = transform.gameObject.GetComponent<Image>();
				break;
			case "RightTips":
				_oRightTips = transform.gameObject;
				_oRightTipsImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
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

	private void CreateShowTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ShowTriggers, eventId, callback);
	}

	private void RemoveShowTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ShowTriggers, eventId);
	}

	public GameObject GetSelectObj(int index)
	{
		return index switch
		{
			1 => SelectObj1, 
			2 => SelectObj2, 
			3 => SelectObj3, 
			4 => SelectObj4, 
			5 => SelectObj5, 
			6 => SelectObj6, 
			7 => SelectObj7, 
			8 => SelectObj8, 
			_ => null, 
		};
	}

	public int GetSelectCount()
	{
		return 8;
	}

	private void CreateSelectTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers1, eventId, callback);
	}

	private void RemoveSelectTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers1, eventId);
	}

	private void CreateSelectTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers2, eventId, callback);
	}

	private void RemoveSelectTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers2, eventId);
	}

	private void CreateSelectTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers3, eventId, callback);
	}

	private void RemoveSelectTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers3, eventId);
	}

	private void CreateSelectTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers4, eventId, callback);
	}

	private void RemoveSelectTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers4, eventId);
	}

	private void CreateSelectTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers5, eventId, callback);
	}

	private void RemoveSelectTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers5, eventId);
	}

	private void CreateSelectTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers6, eventId, callback);
	}

	private void RemoveSelectTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers6, eventId);
	}

	private void CreateSelectTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers7, eventId, callback);
	}

	private void RemoveSelectTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers7, eventId);
	}

	private void CreateSelectTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectTriggers8, eventId, callback);
	}

	private void RemoveSelectTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectTriggers8, eventId);
	}

	public List<EventTrigger.Entry> GetSelectTriggers(int index)
	{
		return index switch
		{
			1 => SelectTriggers1, 
			2 => SelectTriggers2, 
			3 => SelectTriggers3, 
			4 => SelectTriggers4, 
			5 => SelectTriggers5, 
			6 => SelectTriggers6, 
			7 => SelectTriggers7, 
			8 => SelectTriggers8, 
			_ => null, 
		};
	}

	public void SetSelectTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SelectTriggers1 = value;
			break;
		case 2:
			SelectTriggers2 = value;
			break;
		case 3:
			SelectTriggers3 = value;
			break;
		case 4:
			SelectTriggers4 = value;
			break;
		case 5:
			SelectTriggers5 = value;
			break;
		case 6:
			SelectTriggers6 = value;
			break;
		case 7:
			SelectTriggers7 = value;
			break;
		case 8:
			SelectTriggers8 = value;
			break;
		}
	}

	private void CreateSelectTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetSelectTriggers(index), eventId, callback);
	}

	private void RemoveSelectTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetSelectTriggers(index), eventId);
	}

	public bool GetSelectedShow(int index)
	{
		return index switch
		{
			1 => SelectedShow1, 
			2 => SelectedShow2, 
			3 => SelectedShow3, 
			4 => SelectedShow4, 
			5 => SelectedShow5, 
			6 => SelectedShow6, 
			7 => SelectedShow7, 
			8 => SelectedShow8, 
			_ => false, 
		};
	}

	public void SetSelectedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedShow1 = value;
			break;
		case 2:
			SelectedShow2 = value;
			break;
		case 3:
			SelectedShow3 = value;
			break;
		case 4:
			SelectedShow4 = value;
			break;
		case 5:
			SelectedShow5 = value;
			break;
		case 6:
			SelectedShow6 = value;
			break;
		case 7:
			SelectedShow7 = value;
			break;
		case 8:
			SelectedShow8 = value;
			break;
		}
	}

	public int GetSelectedCount()
	{
		return 8;
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

	public bool GetTextShow(int index)
	{
		return index switch
		{
			1 => TextShow1, 
			2 => TextShow2, 
			3 => TextShow3, 
			4 => TextShow4, 
			5 => TextShow5, 
			6 => TextShow6, 
			7 => TextShow7, 
			8 => TextShow8, 
			_ => false, 
		};
	}

	public void SetTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TextShow1 = value;
			break;
		case 2:
			TextShow2 = value;
			break;
		case 3:
			TextShow3 = value;
			break;
		case 4:
			TextShow4 = value;
			break;
		case 5:
			TextShow5 = value;
			break;
		case 6:
			TextShow6 = value;
			break;
		case 7:
			TextShow7 = value;
			break;
		case 8:
			TextShow8 = value;
			break;
		}
	}

	public int GetTextCount()
	{
		return 8;
	}

	public string GetTextString(int index)
	{
		return index switch
		{
			1 => TextString1, 
			2 => TextString2, 
			3 => TextString3, 
			4 => TextString4, 
			5 => TextString5, 
			6 => TextString6, 
			7 => TextString7, 
			8 => TextString8, 
			_ => null, 
		};
	}

	public void SetTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TextString1 = value;
			break;
		case 2:
			TextString2 = value;
			break;
		case 3:
			TextString3 = value;
			break;
		case 4:
			TextString4 = value;
			break;
		case 5:
			TextString5 = value;
			break;
		case 6:
			TextString6 = value;
			break;
		case 7:
			TextString7 = value;
			break;
		case 8:
			TextString8 = value;
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
