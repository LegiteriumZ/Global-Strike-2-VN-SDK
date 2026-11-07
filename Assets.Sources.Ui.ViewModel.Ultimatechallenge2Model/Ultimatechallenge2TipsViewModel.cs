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

namespace Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2TipsViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oL_Message0;

	private GameObject _oL_Message1;

	private GameObject _oL_Message2;

	private GameObject _oL_Message3;

	private GameObject _oL_Message4;

	private Text _oL_MessageText0;

	private Text _oL_MessageText1;

	private Text _oL_MessageText2;

	private Text _oL_MessageText3;

	private Text _oL_MessageText4;

	private GameObject _ouiList_0;

	private GameObject _ouiList_1;

	private GameObject _ouiList_2;

	private GameObject _ouiList_3;

	private GameObject _ouiList_4;

	private GameObject _ouiList_name_0;

	private GameObject _ouiList_name_1;

	private GameObject _ouiList_name_2;

	private GameObject _ouiList_name_3;

	private GameObject _ouiList_name_4;

	private Text _ouiList_name_Text0;

	private Text _ouiList_name_Text1;

	private Text _ouiList_name_Text2;

	private Text _ouiList_name_Text3;

	private Text _ouiList_name_Text4;

	private GameObject _oImage_item_icon_0;

	private GameObject _oImage_item_icon_1;

	private GameObject _oImage_item_icon_2;

	private GameObject _oImage_item_icon_3;

	private GameObject _oImage_item_icon_4;

	private Image _oImage_item_icon_Image0;

	private Image _oImage_item_icon_Image1;

	private Image _oImage_item_icon_Image2;

	private Image _oImage_item_icon_Image3;

	private Image _oImage_item_icon_Image4;

	private GameObject _omessage_text_1;

	private GameObject _omessage_text_2;

	private GameObject _omessage_text_3;

	private Text _omessage_text_Text1;

	private Text _omessage_text_Text2;

	private Text _omessage_text_Text3;

	private GameObject _owait_info;

	private GameObject _o_Number_wait_info_time_FreeCanvas_max;

	private Text _o_Number_wait_info_time_FreeCanvas_maxText;

	private GameObject _o_Number_wait_info_time_FreeCanvas_;

	private Text _o_Number_wait_info_time_FreeCanvas_Text;

	private GameObject _o_Number_wait_info_player_FreeCanvas_;

	private Text _o_Number_wait_info_player_FreeCanvas_Text;

	private GameObject _o_Number_wait_info_player_FreeCanvas_max;

	private Text _o_Number_wait_info_player_FreeCanvas_maxText;

	private GameObject _otakeOffTips;

	private GameObject _otakeOffCountDown;

	private GameObject _o_Number_takeOffCountDown_FreeUI_FreeCanvas_;

	private Text _o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text;

	private GameObject _odamageUI;

	private GameObject _ofrogRefreshCountDown;

	private GameObject _ofrogRefreshCountDown_Time;

	private Text _ofrogRefreshCountDown_TimeText;

	private GameObject _ofrogDecreaseCountDown;

	private GameObject _ofrogDecreaseCountDown_Time;

	private Text _ofrogDecreaseCountDown_TimeText;

	private GameObject _omoveToNewArea;

	private GameObject _osafeAreaDecrease;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge2model";

	private string _resourceAssetName = "ultimatechallenge2tips";

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

	public string L_MessageString0
	{
		get
		{
			if (_oL_MessageText0 != null)
			{
				return _oL_MessageText0.text;
			}
			return null;
		}
		set
		{
			if (L_MessageString0 != value && _oL_MessageText0 != null)
			{
				_oL_MessageText0.text = value;
			}
		}
	}

	public string L_MessageString1
	{
		get
		{
			if (_oL_MessageText1 != null)
			{
				return _oL_MessageText1.text;
			}
			return null;
		}
		set
		{
			if (L_MessageString1 != value && _oL_MessageText1 != null)
			{
				_oL_MessageText1.text = value;
			}
		}
	}

	public string L_MessageString2
	{
		get
		{
			if (_oL_MessageText2 != null)
			{
				return _oL_MessageText2.text;
			}
			return null;
		}
		set
		{
			if (L_MessageString2 != value && _oL_MessageText2 != null)
			{
				_oL_MessageText2.text = value;
			}
		}
	}

	public string L_MessageString3
	{
		get
		{
			if (_oL_MessageText3 != null)
			{
				return _oL_MessageText3.text;
			}
			return null;
		}
		set
		{
			if (L_MessageString3 != value && _oL_MessageText3 != null)
			{
				_oL_MessageText3.text = value;
			}
		}
	}

	public string L_MessageString4
	{
		get
		{
			if (_oL_MessageText4 != null)
			{
				return _oL_MessageText4.text;
			}
			return null;
		}
		set
		{
			if (L_MessageString4 != value && _oL_MessageText4 != null)
			{
				_oL_MessageText4.text = value;
			}
		}
	}

	public bool uiList_Show0
	{
		get
		{
			if (_ouiList_0 != null)
			{
				return _ouiList_0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (uiList_Show0 != value && _ouiList_0 != null)
			{
				_ouiList_0.SetObjectActive(value);
			}
		}
	}

	public bool uiList_Show1
	{
		get
		{
			if (_ouiList_1 != null)
			{
				return _ouiList_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (uiList_Show1 != value && _ouiList_1 != null)
			{
				_ouiList_1.SetObjectActive(value);
			}
		}
	}

	public bool uiList_Show2
	{
		get
		{
			if (_ouiList_2 != null)
			{
				return _ouiList_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (uiList_Show2 != value && _ouiList_2 != null)
			{
				_ouiList_2.SetObjectActive(value);
			}
		}
	}

	public bool uiList_Show3
	{
		get
		{
			if (_ouiList_3 != null)
			{
				return _ouiList_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (uiList_Show3 != value && _ouiList_3 != null)
			{
				_ouiList_3.SetObjectActive(value);
			}
		}
	}

	public bool uiList_Show4
	{
		get
		{
			if (_ouiList_4 != null)
			{
				return _ouiList_4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (uiList_Show4 != value && _ouiList_4 != null)
			{
				_ouiList_4.SetObjectActive(value);
			}
		}
	}

	public string uiList_name_String0
	{
		get
		{
			if (_ouiList_name_Text0 != null)
			{
				return _ouiList_name_Text0.text;
			}
			return null;
		}
		set
		{
			if (uiList_name_String0 != value && _ouiList_name_Text0 != null)
			{
				_ouiList_name_Text0.text = value;
			}
		}
	}

	public string uiList_name_String1
	{
		get
		{
			if (_ouiList_name_Text1 != null)
			{
				return _ouiList_name_Text1.text;
			}
			return null;
		}
		set
		{
			if (uiList_name_String1 != value && _ouiList_name_Text1 != null)
			{
				_ouiList_name_Text1.text = value;
			}
		}
	}

	public string uiList_name_String2
	{
		get
		{
			if (_ouiList_name_Text2 != null)
			{
				return _ouiList_name_Text2.text;
			}
			return null;
		}
		set
		{
			if (uiList_name_String2 != value && _ouiList_name_Text2 != null)
			{
				_ouiList_name_Text2.text = value;
			}
		}
	}

	public string uiList_name_String3
	{
		get
		{
			if (_ouiList_name_Text3 != null)
			{
				return _ouiList_name_Text3.text;
			}
			return null;
		}
		set
		{
			if (uiList_name_String3 != value && _ouiList_name_Text3 != null)
			{
				_ouiList_name_Text3.text = value;
			}
		}
	}

	public string uiList_name_String4
	{
		get
		{
			if (_ouiList_name_Text4 != null)
			{
				return _ouiList_name_Text4.text;
			}
			return null;
		}
		set
		{
			if (uiList_name_String4 != value && _ouiList_name_Text4 != null)
			{
				_ouiList_name_Text4.text = value;
			}
		}
	}

	public Sprite Image_item_icon_Sprite0
	{
		get
		{
			if (_oImage_item_icon_Image0 != null)
			{
				return _oImage_item_icon_Image0.sprite;
			}
			return null;
		}
		set
		{
			if (Image_item_icon_Sprite0 != value && _oImage_item_icon_Image0 != null)
			{
				_oImage_item_icon_Image0.sprite = value;
			}
		}
	}

	public Sprite Image_item_icon_Sprite1
	{
		get
		{
			if (_oImage_item_icon_Image1 != null)
			{
				return _oImage_item_icon_Image1.sprite;
			}
			return null;
		}
		set
		{
			if (Image_item_icon_Sprite1 != value && _oImage_item_icon_Image1 != null)
			{
				_oImage_item_icon_Image1.sprite = value;
			}
		}
	}

	public Sprite Image_item_icon_Sprite2
	{
		get
		{
			if (_oImage_item_icon_Image2 != null)
			{
				return _oImage_item_icon_Image2.sprite;
			}
			return null;
		}
		set
		{
			if (Image_item_icon_Sprite2 != value && _oImage_item_icon_Image2 != null)
			{
				_oImage_item_icon_Image2.sprite = value;
			}
		}
	}

	public Sprite Image_item_icon_Sprite3
	{
		get
		{
			if (_oImage_item_icon_Image3 != null)
			{
				return _oImage_item_icon_Image3.sprite;
			}
			return null;
		}
		set
		{
			if (Image_item_icon_Sprite3 != value && _oImage_item_icon_Image3 != null)
			{
				_oImage_item_icon_Image3.sprite = value;
			}
		}
	}

	public Sprite Image_item_icon_Sprite4
	{
		get
		{
			if (_oImage_item_icon_Image4 != null)
			{
				return _oImage_item_icon_Image4.sprite;
			}
			return null;
		}
		set
		{
			if (Image_item_icon_Sprite4 != value && _oImage_item_icon_Image4 != null)
			{
				_oImage_item_icon_Image4.sprite = value;
			}
		}
	}

	public string message_text_String1
	{
		get
		{
			if (_omessage_text_Text1 != null)
			{
				return _omessage_text_Text1.text;
			}
			return null;
		}
		set
		{
			if (message_text_String1 != value && _omessage_text_Text1 != null)
			{
				_omessage_text_Text1.text = value;
			}
		}
	}

	public string message_text_String2
	{
		get
		{
			if (_omessage_text_Text2 != null)
			{
				return _omessage_text_Text2.text;
			}
			return null;
		}
		set
		{
			if (message_text_String2 != value && _omessage_text_Text2 != null)
			{
				_omessage_text_Text2.text = value;
			}
		}
	}

	public string message_text_String3
	{
		get
		{
			if (_omessage_text_Text3 != null)
			{
				return _omessage_text_Text3.text;
			}
			return null;
		}
		set
		{
			if (message_text_String3 != value && _omessage_text_Text3 != null)
			{
				_omessage_text_Text3.text = value;
			}
		}
	}

	public bool wait_infoShow
	{
		get
		{
			if (_owait_info != null)
			{
				return _owait_info.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (wait_infoShow != value && _owait_info != null)
			{
				_owait_info.SetObjectActive(value);
			}
		}
	}

	public string _Number_wait_info_time_FreeCanvas_maxString
	{
		get
		{
			if (_o_Number_wait_info_time_FreeCanvas_maxText != null)
			{
				return _o_Number_wait_info_time_FreeCanvas_maxText.text;
			}
			return null;
		}
		set
		{
			if (_Number_wait_info_time_FreeCanvas_maxString != value && _o_Number_wait_info_time_FreeCanvas_maxText != null)
			{
				_o_Number_wait_info_time_FreeCanvas_maxText.text = value;
			}
		}
	}

	public string _Number_wait_info_time_FreeCanvas_String
	{
		get
		{
			if (_o_Number_wait_info_time_FreeCanvas_Text != null)
			{
				return _o_Number_wait_info_time_FreeCanvas_Text.text;
			}
			return null;
		}
		set
		{
			if (_Number_wait_info_time_FreeCanvas_String != value && _o_Number_wait_info_time_FreeCanvas_Text != null)
			{
				_o_Number_wait_info_time_FreeCanvas_Text.text = value;
			}
		}
	}

	public string _Number_wait_info_player_FreeCanvas_String
	{
		get
		{
			if (_o_Number_wait_info_player_FreeCanvas_Text != null)
			{
				return _o_Number_wait_info_player_FreeCanvas_Text.text;
			}
			return null;
		}
		set
		{
			if (_Number_wait_info_player_FreeCanvas_String != value && _o_Number_wait_info_player_FreeCanvas_Text != null)
			{
				_o_Number_wait_info_player_FreeCanvas_Text.text = value;
			}
		}
	}

	public string _Number_wait_info_player_FreeCanvas_maxString
	{
		get
		{
			if (_o_Number_wait_info_player_FreeCanvas_maxText != null)
			{
				return _o_Number_wait_info_player_FreeCanvas_maxText.text;
			}
			return null;
		}
		set
		{
			if (_Number_wait_info_player_FreeCanvas_maxString != value && _o_Number_wait_info_player_FreeCanvas_maxText != null)
			{
				_o_Number_wait_info_player_FreeCanvas_maxText.text = value;
			}
		}
	}

	public bool takeOffTipsShow
	{
		get
		{
			if (_otakeOffTips != null)
			{
				return _otakeOffTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (takeOffTipsShow != value && _otakeOffTips != null)
			{
				_otakeOffTips.SetObjectActive(value);
			}
		}
	}

	public bool takeOffCountDownShow
	{
		get
		{
			if (_otakeOffCountDown != null)
			{
				return _otakeOffCountDown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (takeOffCountDownShow != value && _otakeOffCountDown != null)
			{
				_otakeOffCountDown.SetObjectActive(value);
			}
		}
	}

	public string _Number_takeOffCountDown_FreeUI_FreeCanvas_String
	{
		get
		{
			if (_o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text != null)
			{
				return _o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text.text;
			}
			return null;
		}
		set
		{
			if (_Number_takeOffCountDown_FreeUI_FreeCanvas_String != value && _o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text != null)
			{
				_o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text.text = value;
			}
		}
	}

	public bool damageUIShow
	{
		get
		{
			if (_odamageUI != null)
			{
				return _odamageUI.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (damageUIShow != value && _odamageUI != null)
			{
				_odamageUI.SetObjectActive(value);
			}
		}
	}

	public bool frogRefreshCountDownShow
	{
		get
		{
			if (_ofrogRefreshCountDown != null)
			{
				return _ofrogRefreshCountDown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (frogRefreshCountDownShow != value && _ofrogRefreshCountDown != null)
			{
				_ofrogRefreshCountDown.SetObjectActive(value);
			}
		}
	}

	public string frogRefreshCountDown_TimeString
	{
		get
		{
			if (_ofrogRefreshCountDown_TimeText != null)
			{
				return _ofrogRefreshCountDown_TimeText.text;
			}
			return null;
		}
		set
		{
			if (frogRefreshCountDown_TimeString != value && _ofrogRefreshCountDown_TimeText != null)
			{
				_ofrogRefreshCountDown_TimeText.text = value;
			}
		}
	}

	public bool frogDecreaseCountDownShow
	{
		get
		{
			if (_ofrogDecreaseCountDown != null)
			{
				return _ofrogDecreaseCountDown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (frogDecreaseCountDownShow != value && _ofrogDecreaseCountDown != null)
			{
				_ofrogDecreaseCountDown.SetObjectActive(value);
			}
		}
	}

	public string frogDecreaseCountDown_TimeString
	{
		get
		{
			if (_ofrogDecreaseCountDown_TimeText != null)
			{
				return _ofrogDecreaseCountDown_TimeText.text;
			}
			return null;
		}
		set
		{
			if (frogDecreaseCountDown_TimeString != value && _ofrogDecreaseCountDown_TimeText != null)
			{
				_ofrogDecreaseCountDown_TimeText.text = value;
			}
		}
	}

	public bool moveToNewAreaShow
	{
		get
		{
			if (_omoveToNewArea != null)
			{
				return _omoveToNewArea.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (moveToNewAreaShow != value && _omoveToNewArea != null)
			{
				_omoveToNewArea.SetObjectActive(value);
			}
		}
	}

	public bool safeAreaDecreaseShow
	{
		get
		{
			if (_osafeAreaDecrease != null)
			{
				return _osafeAreaDecrease.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (safeAreaDecreaseShow != value && _osafeAreaDecrease != null)
			{
				_osafeAreaDecrease.SetObjectActive(value);
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
			case "L_Message0":
				_oL_Message0 = transform.gameObject;
				_oL_MessageText0 = transform.gameObject.GetComponent<Text>();
				break;
			case "L_Message1":
				_oL_Message1 = transform.gameObject;
				_oL_MessageText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "L_Message2":
				_oL_Message2 = transform.gameObject;
				_oL_MessageText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "L_Message3":
				_oL_Message3 = transform.gameObject;
				_oL_MessageText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "L_Message4":
				_oL_Message4 = transform.gameObject;
				_oL_MessageText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "uiList_0":
				_ouiList_0 = transform.gameObject;
				break;
			case "uiList_1":
				_ouiList_1 = transform.gameObject;
				break;
			case "uiList_2":
				_ouiList_2 = transform.gameObject;
				break;
			case "uiList_3":
				_ouiList_3 = transform.gameObject;
				break;
			case "uiList_4":
				_ouiList_4 = transform.gameObject;
				break;
			case "uiList_name_0":
				_ouiList_name_0 = transform.gameObject;
				_ouiList_name_Text0 = transform.gameObject.GetComponent<Text>();
				break;
			case "uiList_name_1":
				_ouiList_name_1 = transform.gameObject;
				_ouiList_name_Text1 = transform.gameObject.GetComponent<Text>();
				break;
			case "uiList_name_2":
				_ouiList_name_2 = transform.gameObject;
				_ouiList_name_Text2 = transform.gameObject.GetComponent<Text>();
				break;
			case "uiList_name_3":
				_ouiList_name_3 = transform.gameObject;
				_ouiList_name_Text3 = transform.gameObject.GetComponent<Text>();
				break;
			case "uiList_name_4":
				_ouiList_name_4 = transform.gameObject;
				_ouiList_name_Text4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Image_item_icon_0":
				_oImage_item_icon_0 = transform.gameObject;
				_oImage_item_icon_Image0 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image_item_icon_1":
				_oImage_item_icon_1 = transform.gameObject;
				_oImage_item_icon_Image1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image_item_icon_2":
				_oImage_item_icon_2 = transform.gameObject;
				_oImage_item_icon_Image2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image_item_icon_3":
				_oImage_item_icon_3 = transform.gameObject;
				_oImage_item_icon_Image3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image_item_icon_4":
				_oImage_item_icon_4 = transform.gameObject;
				_oImage_item_icon_Image4 = transform.gameObject.GetComponent<Image>();
				break;
			case "message_text_1":
				_omessage_text_1 = transform.gameObject;
				_omessage_text_Text1 = transform.gameObject.GetComponent<Text>();
				break;
			case "message_text_2":
				_omessage_text_2 = transform.gameObject;
				_omessage_text_Text2 = transform.gameObject.GetComponent<Text>();
				break;
			case "message_text_3":
				_omessage_text_3 = transform.gameObject;
				_omessage_text_Text3 = transform.gameObject.GetComponent<Text>();
				break;
			case "wait_info":
				_owait_info = transform.gameObject;
				break;
			case "_Number_wait_info_time_FreeCanvas_max":
				_o_Number_wait_info_time_FreeCanvas_max = transform.gameObject;
				_o_Number_wait_info_time_FreeCanvas_maxText = transform.gameObject.GetComponent<Text>();
				break;
			case "_Number_wait_info_time_FreeCanvas_":
				_o_Number_wait_info_time_FreeCanvas_ = transform.gameObject;
				_o_Number_wait_info_time_FreeCanvas_Text = transform.gameObject.GetComponent<Text>();
				break;
			case "_Number_wait_info_player_FreeCanvas_":
				_o_Number_wait_info_player_FreeCanvas_ = transform.gameObject;
				_o_Number_wait_info_player_FreeCanvas_Text = transform.gameObject.GetComponent<Text>();
				break;
			case "_Number_wait_info_player_FreeCanvas_max":
				_o_Number_wait_info_player_FreeCanvas_max = transform.gameObject;
				_o_Number_wait_info_player_FreeCanvas_maxText = transform.gameObject.GetComponent<Text>();
				break;
			case "takeOffTips":
				_otakeOffTips = transform.gameObject;
				break;
			case "takeOffCountDown":
				_otakeOffCountDown = transform.gameObject;
				break;
			case "_Number_takeOffCountDown_FreeUI_FreeCanvas_":
				_o_Number_takeOffCountDown_FreeUI_FreeCanvas_ = transform.gameObject;
				_o_Number_takeOffCountDown_FreeUI_FreeCanvas_Text = transform.gameObject.GetComponent<Text>();
				break;
			case "damageUI":
				_odamageUI = transform.gameObject;
				break;
			case "frogRefreshCountDown":
				_ofrogRefreshCountDown = transform.gameObject;
				break;
			case "frogRefreshCountDown_Time":
				_ofrogRefreshCountDown_Time = transform.gameObject;
				_ofrogRefreshCountDown_TimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "frogDecreaseCountDown":
				_ofrogDecreaseCountDown = transform.gameObject;
				break;
			case "frogDecreaseCountDown_Time":
				_ofrogDecreaseCountDown_Time = transform.gameObject;
				_ofrogDecreaseCountDown_TimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "moveToNewArea":
				_omoveToNewArea = transform.gameObject;
				break;
			case "safeAreaDecrease":
				_osafeAreaDecrease = transform.gameObject;
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

	public string GetL_MessageString(int index)
	{
		return index switch
		{
			0 => L_MessageString0, 
			1 => L_MessageString1, 
			2 => L_MessageString2, 
			3 => L_MessageString3, 
			4 => L_MessageString4, 
			_ => null, 
		};
	}

	public void SetL_MessageString(int index, string value)
	{
		switch (index)
		{
		case 0:
			L_MessageString0 = value;
			break;
		case 1:
			L_MessageString1 = value;
			break;
		case 2:
			L_MessageString2 = value;
			break;
		case 3:
			L_MessageString3 = value;
			break;
		case 4:
			L_MessageString4 = value;
			break;
		}
	}

	public int GetL_MessageCount()
	{
		return 4;
	}

	public bool GetuiList_Show(int index)
	{
		return index switch
		{
			0 => uiList_Show0, 
			1 => uiList_Show1, 
			2 => uiList_Show2, 
			3 => uiList_Show3, 
			4 => uiList_Show4, 
			_ => false, 
		};
	}

	public void SetuiList_Show(int index, bool value)
	{
		switch (index)
		{
		case 0:
			uiList_Show0 = value;
			break;
		case 1:
			uiList_Show1 = value;
			break;
		case 2:
			uiList_Show2 = value;
			break;
		case 3:
			uiList_Show3 = value;
			break;
		case 4:
			uiList_Show4 = value;
			break;
		}
	}

	public int GetuiList_Count()
	{
		return 4;
	}

	public string GetuiList_name_String(int index)
	{
		return index switch
		{
			0 => uiList_name_String0, 
			1 => uiList_name_String1, 
			2 => uiList_name_String2, 
			3 => uiList_name_String3, 
			4 => uiList_name_String4, 
			_ => null, 
		};
	}

	public void SetuiList_name_String(int index, string value)
	{
		switch (index)
		{
		case 0:
			uiList_name_String0 = value;
			break;
		case 1:
			uiList_name_String1 = value;
			break;
		case 2:
			uiList_name_String2 = value;
			break;
		case 3:
			uiList_name_String3 = value;
			break;
		case 4:
			uiList_name_String4 = value;
			break;
		}
	}

	public int GetuiList_name_Count()
	{
		return 4;
	}

	public Sprite GetImage_item_icon_Sprite(int index)
	{
		return index switch
		{
			0 => Image_item_icon_Sprite0, 
			1 => Image_item_icon_Sprite1, 
			2 => Image_item_icon_Sprite2, 
			3 => Image_item_icon_Sprite3, 
			4 => Image_item_icon_Sprite4, 
			_ => null, 
		};
	}

	public void SetImage_item_icon_Sprite(int index, Sprite value)
	{
		switch (index)
		{
		case 0:
			Image_item_icon_Sprite0 = value;
			break;
		case 1:
			Image_item_icon_Sprite1 = value;
			break;
		case 2:
			Image_item_icon_Sprite2 = value;
			break;
		case 3:
			Image_item_icon_Sprite3 = value;
			break;
		case 4:
			Image_item_icon_Sprite4 = value;
			break;
		}
	}

	public int GetImage_item_icon_Count()
	{
		return 4;
	}

	public string Getmessage_text_String(int index)
	{
		return index switch
		{
			1 => message_text_String1, 
			2 => message_text_String2, 
			3 => message_text_String3, 
			_ => null, 
		};
	}

	public void Setmessage_text_String(int index, string value)
	{
		switch (index)
		{
		case 1:
			message_text_String1 = value;
			break;
		case 2:
			message_text_String2 = value;
			break;
		case 3:
			message_text_String3 = value;
			break;
		}
	}

	public int Getmessage_text_Count()
	{
		return 3;
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
