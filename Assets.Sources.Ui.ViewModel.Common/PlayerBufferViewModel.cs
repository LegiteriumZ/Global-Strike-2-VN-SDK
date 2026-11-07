using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerBufferViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private CanvasGroup _oPanelCanvasGroup;

	private GameObject _oBuff1;

	private GameObject _oBuff2;

	private GameObject _oBuff3;

	private GameObject _oBuff4;

	private GameObject _oBuff5;

	private GameObject _oBuff6;

	private GameObject _oBuff7;

	private GameObject _oBuff8;

	private GameObject _oBuff9;

	private GameObject _oBuff10;

	private GameObject _oBuff11;

	private GameObject _oBuff12;

	private GameObject _oBuff13;

	private GameObject _oBuff14;

	private Image _oBuffImage1;

	private Image _oBuffImage2;

	private Image _oBuffImage3;

	private Image _oBuffImage4;

	private Image _oBuffImage5;

	private Image _oBuffImage6;

	private Image _oBuffImage7;

	private Image _oBuffImage8;

	private Image _oBuffImage9;

	private Image _oBuffImage10;

	private Image _oBuffImage11;

	private Image _oBuffImage12;

	private Image _oBuffImage13;

	private Image _oBuffImage14;

	private GameObject _oNum1;

	private GameObject _oNum2;

	private GameObject _oNum3;

	private GameObject _oNum4;

	private GameObject _oNum5;

	private GameObject _oNum6;

	private GameObject _oNum7;

	private GameObject _oNum8;

	private GameObject _oNum9;

	private GameObject _oNum10;

	private GameObject _oNum11;

	private GameObject _oNum12;

	private GameObject _oNum13;

	private GameObject _oNum14;

	private Text _oNumText1;

	private Text _oNumText2;

	private Text _oNumText3;

	private Text _oNumText4;

	private Text _oNumText5;

	private Text _oNumText6;

	private Text _oNumText7;

	private Text _oNumText8;

	private Text _oNumText9;

	private Text _oNumText10;

	private Text _oNumText11;

	private Text _oNumText12;

	private Text _oNumText13;

	private Text _oNumText14;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "PlayerBuffer";

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

	public float PanelAlpha
	{
		get
		{
			if (_oPanelCanvasGroup != null)
			{
				return _oPanelCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (PanelAlpha != value && _oPanelCanvasGroup != null)
			{
				_oPanelCanvasGroup.alpha = value;
			}
		}
	}

	public bool BuffShow1
	{
		get
		{
			if (_oBuff1 != null)
			{
				return _oBuff1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow1 != value && _oBuff1 != null)
			{
				_oBuff1.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow2
	{
		get
		{
			if (_oBuff2 != null)
			{
				return _oBuff2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow2 != value && _oBuff2 != null)
			{
				_oBuff2.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow3
	{
		get
		{
			if (_oBuff3 != null)
			{
				return _oBuff3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow3 != value && _oBuff3 != null)
			{
				_oBuff3.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow4
	{
		get
		{
			if (_oBuff4 != null)
			{
				return _oBuff4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow4 != value && _oBuff4 != null)
			{
				_oBuff4.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow5
	{
		get
		{
			if (_oBuff5 != null)
			{
				return _oBuff5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow5 != value && _oBuff5 != null)
			{
				_oBuff5.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow6
	{
		get
		{
			if (_oBuff6 != null)
			{
				return _oBuff6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow6 != value && _oBuff6 != null)
			{
				_oBuff6.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow7
	{
		get
		{
			if (_oBuff7 != null)
			{
				return _oBuff7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow7 != value && _oBuff7 != null)
			{
				_oBuff7.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow8
	{
		get
		{
			if (_oBuff8 != null)
			{
				return _oBuff8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow8 != value && _oBuff8 != null)
			{
				_oBuff8.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow9
	{
		get
		{
			if (_oBuff9 != null)
			{
				return _oBuff9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow9 != value && _oBuff9 != null)
			{
				_oBuff9.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow10
	{
		get
		{
			if (_oBuff10 != null)
			{
				return _oBuff10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow10 != value && _oBuff10 != null)
			{
				_oBuff10.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow11
	{
		get
		{
			if (_oBuff11 != null)
			{
				return _oBuff11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow11 != value && _oBuff11 != null)
			{
				_oBuff11.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow12
	{
		get
		{
			if (_oBuff12 != null)
			{
				return _oBuff12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow12 != value && _oBuff12 != null)
			{
				_oBuff12.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow13
	{
		get
		{
			if (_oBuff13 != null)
			{
				return _oBuff13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow13 != value && _oBuff13 != null)
			{
				_oBuff13.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow14
	{
		get
		{
			if (_oBuff14 != null)
			{
				return _oBuff14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow14 != value && _oBuff14 != null)
			{
				_oBuff14.SetObjectActive(value);
			}
		}
	}

	public Sprite BuffSprite1
	{
		get
		{
			if (_oBuffImage1 != null)
			{
				return _oBuffImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite1 != value && _oBuffImage1 != null)
			{
				_oBuffImage1.sprite = value;
			}
		}
	}

	public Sprite BuffSprite2
	{
		get
		{
			if (_oBuffImage2 != null)
			{
				return _oBuffImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite2 != value && _oBuffImage2 != null)
			{
				_oBuffImage2.sprite = value;
			}
		}
	}

	public Sprite BuffSprite3
	{
		get
		{
			if (_oBuffImage3 != null)
			{
				return _oBuffImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite3 != value && _oBuffImage3 != null)
			{
				_oBuffImage3.sprite = value;
			}
		}
	}

	public Sprite BuffSprite4
	{
		get
		{
			if (_oBuffImage4 != null)
			{
				return _oBuffImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite4 != value && _oBuffImage4 != null)
			{
				_oBuffImage4.sprite = value;
			}
		}
	}

	public Sprite BuffSprite5
	{
		get
		{
			if (_oBuffImage5 != null)
			{
				return _oBuffImage5.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite5 != value && _oBuffImage5 != null)
			{
				_oBuffImage5.sprite = value;
			}
		}
	}

	public Sprite BuffSprite6
	{
		get
		{
			if (_oBuffImage6 != null)
			{
				return _oBuffImage6.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite6 != value && _oBuffImage6 != null)
			{
				_oBuffImage6.sprite = value;
			}
		}
	}

	public Sprite BuffSprite7
	{
		get
		{
			if (_oBuffImage7 != null)
			{
				return _oBuffImage7.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite7 != value && _oBuffImage7 != null)
			{
				_oBuffImage7.sprite = value;
			}
		}
	}

	public Sprite BuffSprite8
	{
		get
		{
			if (_oBuffImage8 != null)
			{
				return _oBuffImage8.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite8 != value && _oBuffImage8 != null)
			{
				_oBuffImage8.sprite = value;
			}
		}
	}

	public Sprite BuffSprite9
	{
		get
		{
			if (_oBuffImage9 != null)
			{
				return _oBuffImage9.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite9 != value && _oBuffImage9 != null)
			{
				_oBuffImage9.sprite = value;
			}
		}
	}

	public Sprite BuffSprite10
	{
		get
		{
			if (_oBuffImage10 != null)
			{
				return _oBuffImage10.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite10 != value && _oBuffImage10 != null)
			{
				_oBuffImage10.sprite = value;
			}
		}
	}

	public Sprite BuffSprite11
	{
		get
		{
			if (_oBuffImage11 != null)
			{
				return _oBuffImage11.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite11 != value && _oBuffImage11 != null)
			{
				_oBuffImage11.sprite = value;
			}
		}
	}

	public Sprite BuffSprite12
	{
		get
		{
			if (_oBuffImage12 != null)
			{
				return _oBuffImage12.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite12 != value && _oBuffImage12 != null)
			{
				_oBuffImage12.sprite = value;
			}
		}
	}

	public Sprite BuffSprite13
	{
		get
		{
			if (_oBuffImage13 != null)
			{
				return _oBuffImage13.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite13 != value && _oBuffImage13 != null)
			{
				_oBuffImage13.sprite = value;
			}
		}
	}

	public Sprite BuffSprite14
	{
		get
		{
			if (_oBuffImage14 != null)
			{
				return _oBuffImage14.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite14 != value && _oBuffImage14 != null)
			{
				_oBuffImage14.sprite = value;
			}
		}
	}

	public string NumString1
	{
		get
		{
			if (_oNumText1 != null)
			{
				return _oNumText1.text;
			}
			return null;
		}
		set
		{
			if (NumString1 != value && _oNumText1 != null)
			{
				_oNumText1.text = value;
			}
		}
	}

	public string NumString2
	{
		get
		{
			if (_oNumText2 != null)
			{
				return _oNumText2.text;
			}
			return null;
		}
		set
		{
			if (NumString2 != value && _oNumText2 != null)
			{
				_oNumText2.text = value;
			}
		}
	}

	public string NumString3
	{
		get
		{
			if (_oNumText3 != null)
			{
				return _oNumText3.text;
			}
			return null;
		}
		set
		{
			if (NumString3 != value && _oNumText3 != null)
			{
				_oNumText3.text = value;
			}
		}
	}

	public string NumString4
	{
		get
		{
			if (_oNumText4 != null)
			{
				return _oNumText4.text;
			}
			return null;
		}
		set
		{
			if (NumString4 != value && _oNumText4 != null)
			{
				_oNumText4.text = value;
			}
		}
	}

	public string NumString5
	{
		get
		{
			if (_oNumText5 != null)
			{
				return _oNumText5.text;
			}
			return null;
		}
		set
		{
			if (NumString5 != value && _oNumText5 != null)
			{
				_oNumText5.text = value;
			}
		}
	}

	public string NumString6
	{
		get
		{
			if (_oNumText6 != null)
			{
				return _oNumText6.text;
			}
			return null;
		}
		set
		{
			if (NumString6 != value && _oNumText6 != null)
			{
				_oNumText6.text = value;
			}
		}
	}

	public string NumString7
	{
		get
		{
			if (_oNumText7 != null)
			{
				return _oNumText7.text;
			}
			return null;
		}
		set
		{
			if (NumString7 != value && _oNumText7 != null)
			{
				_oNumText7.text = value;
			}
		}
	}

	public string NumString8
	{
		get
		{
			if (_oNumText8 != null)
			{
				return _oNumText8.text;
			}
			return null;
		}
		set
		{
			if (NumString8 != value && _oNumText8 != null)
			{
				_oNumText8.text = value;
			}
		}
	}

	public string NumString9
	{
		get
		{
			if (_oNumText9 != null)
			{
				return _oNumText9.text;
			}
			return null;
		}
		set
		{
			if (NumString9 != value && _oNumText9 != null)
			{
				_oNumText9.text = value;
			}
		}
	}

	public string NumString10
	{
		get
		{
			if (_oNumText10 != null)
			{
				return _oNumText10.text;
			}
			return null;
		}
		set
		{
			if (NumString10 != value && _oNumText10 != null)
			{
				_oNumText10.text = value;
			}
		}
	}

	public string NumString11
	{
		get
		{
			if (_oNumText11 != null)
			{
				return _oNumText11.text;
			}
			return null;
		}
		set
		{
			if (NumString11 != value && _oNumText11 != null)
			{
				_oNumText11.text = value;
			}
		}
	}

	public string NumString12
	{
		get
		{
			if (_oNumText12 != null)
			{
				return _oNumText12.text;
			}
			return null;
		}
		set
		{
			if (NumString12 != value && _oNumText12 != null)
			{
				_oNumText12.text = value;
			}
		}
	}

	public string NumString13
	{
		get
		{
			if (_oNumText13 != null)
			{
				return _oNumText13.text;
			}
			return null;
		}
		set
		{
			if (NumString13 != value && _oNumText13 != null)
			{
				_oNumText13.text = value;
			}
		}
	}

	public string NumString14
	{
		get
		{
			if (_oNumText14 != null)
			{
				return _oNumText14.text;
			}
			return null;
		}
		set
		{
			if (NumString14 != value && _oNumText14 != null)
			{
				_oNumText14.text = value;
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
				_oPanelCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Buff1":
				_oBuff1 = transform.gameObject;
				_oBuffImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff2":
				_oBuff2 = transform.gameObject;
				_oBuffImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff3":
				_oBuff3 = transform.gameObject;
				_oBuffImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff4":
				_oBuff4 = transform.gameObject;
				_oBuffImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff5":
				_oBuff5 = transform.gameObject;
				_oBuffImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff6":
				_oBuff6 = transform.gameObject;
				_oBuffImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff7":
				_oBuff7 = transform.gameObject;
				_oBuffImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff8":
				_oBuff8 = transform.gameObject;
				_oBuffImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff9":
				_oBuff9 = transform.gameObject;
				_oBuffImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff10":
				_oBuff10 = transform.gameObject;
				_oBuffImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff11":
				_oBuff11 = transform.gameObject;
				_oBuffImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff12":
				_oBuff12 = transform.gameObject;
				_oBuffImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff13":
				_oBuff13 = transform.gameObject;
				_oBuffImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff14":
				_oBuff14 = transform.gameObject;
				_oBuffImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "Num1":
				_oNum1 = transform.gameObject;
				_oNumText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num2":
				_oNum2 = transform.gameObject;
				_oNumText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num3":
				_oNum3 = transform.gameObject;
				_oNumText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num4":
				_oNum4 = transform.gameObject;
				_oNumText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num5":
				_oNum5 = transform.gameObject;
				_oNumText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num6":
				_oNum6 = transform.gameObject;
				_oNumText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num7":
				_oNum7 = transform.gameObject;
				_oNumText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num8":
				_oNum8 = transform.gameObject;
				_oNumText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num9":
				_oNum9 = transform.gameObject;
				_oNumText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num10":
				_oNum10 = transform.gameObject;
				_oNumText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num11":
				_oNum11 = transform.gameObject;
				_oNumText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num12":
				_oNum12 = transform.gameObject;
				_oNumText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num13":
				_oNum13 = transform.gameObject;
				_oNumText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "Num14":
				_oNum14 = transform.gameObject;
				_oNumText14 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetBuffShow(int index)
	{
		return index switch
		{
			1 => BuffShow1, 
			2 => BuffShow2, 
			3 => BuffShow3, 
			4 => BuffShow4, 
			5 => BuffShow5, 
			6 => BuffShow6, 
			7 => BuffShow7, 
			8 => BuffShow8, 
			9 => BuffShow9, 
			10 => BuffShow10, 
			11 => BuffShow11, 
			12 => BuffShow12, 
			13 => BuffShow13, 
			14 => BuffShow14, 
			_ => false, 
		};
	}

	public void SetBuffShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BuffShow1 = value;
			break;
		case 2:
			BuffShow2 = value;
			break;
		case 3:
			BuffShow3 = value;
			break;
		case 4:
			BuffShow4 = value;
			break;
		case 5:
			BuffShow5 = value;
			break;
		case 6:
			BuffShow6 = value;
			break;
		case 7:
			BuffShow7 = value;
			break;
		case 8:
			BuffShow8 = value;
			break;
		case 9:
			BuffShow9 = value;
			break;
		case 10:
			BuffShow10 = value;
			break;
		case 11:
			BuffShow11 = value;
			break;
		case 12:
			BuffShow12 = value;
			break;
		case 13:
			BuffShow13 = value;
			break;
		case 14:
			BuffShow14 = value;
			break;
		}
	}

	public Sprite GetBuffSprite(int index)
	{
		return index switch
		{
			1 => BuffSprite1, 
			2 => BuffSprite2, 
			3 => BuffSprite3, 
			4 => BuffSprite4, 
			5 => BuffSprite5, 
			6 => BuffSprite6, 
			7 => BuffSprite7, 
			8 => BuffSprite8, 
			9 => BuffSprite9, 
			10 => BuffSprite10, 
			11 => BuffSprite11, 
			12 => BuffSprite12, 
			13 => BuffSprite13, 
			14 => BuffSprite14, 
			_ => null, 
		};
	}

	public void SetBuffSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BuffSprite1 = value;
			break;
		case 2:
			BuffSprite2 = value;
			break;
		case 3:
			BuffSprite3 = value;
			break;
		case 4:
			BuffSprite4 = value;
			break;
		case 5:
			BuffSprite5 = value;
			break;
		case 6:
			BuffSprite6 = value;
			break;
		case 7:
			BuffSprite7 = value;
			break;
		case 8:
			BuffSprite8 = value;
			break;
		case 9:
			BuffSprite9 = value;
			break;
		case 10:
			BuffSprite10 = value;
			break;
		case 11:
			BuffSprite11 = value;
			break;
		case 12:
			BuffSprite12 = value;
			break;
		case 13:
			BuffSprite13 = value;
			break;
		case 14:
			BuffSprite14 = value;
			break;
		}
	}

	public string GetNumString(int index)
	{
		return index switch
		{
			1 => NumString1, 
			2 => NumString2, 
			3 => NumString3, 
			4 => NumString4, 
			5 => NumString5, 
			6 => NumString6, 
			7 => NumString7, 
			8 => NumString8, 
			9 => NumString9, 
			10 => NumString10, 
			11 => NumString11, 
			12 => NumString12, 
			13 => NumString13, 
			14 => NumString14, 
			_ => null, 
		};
	}

	public void SetNumString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NumString1 = value;
			break;
		case 2:
			NumString2 = value;
			break;
		case 3:
			NumString3 = value;
			break;
		case 4:
			NumString4 = value;
			break;
		case 5:
			NumString5 = value;
			break;
		case 6:
			NumString6 = value;
			break;
		case 7:
			NumString7 = value;
			break;
		case 8:
			NumString8 = value;
			break;
		case 9:
			NumString9 = value;
			break;
		case 10:
			NumString10 = value;
			break;
		case 11:
			NumString11 = value;
			break;
		case 12:
			NumString12 = value;
			break;
		case 13:
			NumString13 = value;
			break;
		case 14:
			NumString14 = value;
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
