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
public class StrokeAnalysisViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oKillInfo;

	private GameObject _oKillerName;

	private Text _oKillerNameText;

	private GameObject _oWeapon;

	private RectTransform _oWeaponRectTransform;

	private Image _oWeaponImage;

	private GameObject _oWeaponName;

	private Text _oWeaponNameText;

	private GameObject _oVictimName1;

	private GameObject _oVictimName2;

	private GameObject _oVictimName3;

	private GameObject _oVictimName4;

	private GameObject _oVictimName5;

	private GameObject _oVictimName6;

	private Text _oVictimNameText1;

	private Text _oVictimNameText2;

	private Text _oVictimNameText3;

	private Text _oVictimNameText4;

	private Text _oVictimNameText5;

	private Text _oVictimNameText6;

	private GameObject _oKillIcon1;

	private GameObject _oKillIcon2;

	private GameObject _oKillIcon3;

	private GameObject _oKillIcon4;

	private GameObject _oKillIcon5;

	private GameObject _oKillIcon6;

	private Image _oKillIconImage1;

	private Image _oKillIconImage2;

	private Image _oKillIconImage3;

	private Image _oKillIconImage4;

	private Image _oKillIconImage5;

	private Image _oKillIconImage6;

	private GameObject _oDamage1;

	private GameObject _oDamage2;

	private GameObject _oDamage3;

	private GameObject _oDamage4;

	private GameObject _oDamage5;

	private GameObject _oDamage6;

	private Text _oDamageText1;

	private Text _oDamageText2;

	private Text _oDamageText3;

	private Text _oDamageText4;

	private Text _oDamageText5;

	private Text _oDamageText6;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "StrokeAnalysis";

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

	public bool KillInfoShow
	{
		get
		{
			if (_oKillInfo != null)
			{
				return _oKillInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillInfoShow != value && _oKillInfo != null)
			{
				_oKillInfo.SetObjectActive(value);
			}
		}
	}

	public string KillerNameString
	{
		get
		{
			if (_oKillerNameText != null)
			{
				return _oKillerNameText.text;
			}
			return null;
		}
		set
		{
			if (KillerNameString != value && _oKillerNameText != null)
			{
				_oKillerNameText.text = value;
			}
		}
	}

	public Vector3 WeaponScale
	{
		get
		{
			if (_oWeaponRectTransform != null)
			{
				return _oWeaponRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale != value && _oWeaponRectTransform != null)
			{
				_oWeaponRectTransform.localScale = value;
			}
		}
	}

	public Sprite WeaponSprite
	{
		get
		{
			if (_oWeaponImage != null)
			{
				return _oWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite != value && _oWeaponImage != null)
			{
				_oWeaponImage.sprite = value;
			}
		}
	}

	public string WeaponNameString
	{
		get
		{
			if (_oWeaponNameText != null)
			{
				return _oWeaponNameText.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString != value && _oWeaponNameText != null)
			{
				_oWeaponNameText.text = value;
			}
		}
	}

	public bool VictimNameShow1
	{
		get
		{
			if (_oVictimName1 != null)
			{
				return _oVictimName1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow1 != value && _oVictimName1 != null)
			{
				_oVictimName1.SetObjectActive(value);
			}
		}
	}

	public bool VictimNameShow2
	{
		get
		{
			if (_oVictimName2 != null)
			{
				return _oVictimName2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow2 != value && _oVictimName2 != null)
			{
				_oVictimName2.SetObjectActive(value);
			}
		}
	}

	public bool VictimNameShow3
	{
		get
		{
			if (_oVictimName3 != null)
			{
				return _oVictimName3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow3 != value && _oVictimName3 != null)
			{
				_oVictimName3.SetObjectActive(value);
			}
		}
	}

	public bool VictimNameShow4
	{
		get
		{
			if (_oVictimName4 != null)
			{
				return _oVictimName4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow4 != value && _oVictimName4 != null)
			{
				_oVictimName4.SetObjectActive(value);
			}
		}
	}

	public bool VictimNameShow5
	{
		get
		{
			if (_oVictimName5 != null)
			{
				return _oVictimName5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow5 != value && _oVictimName5 != null)
			{
				_oVictimName5.SetObjectActive(value);
			}
		}
	}

	public bool VictimNameShow6
	{
		get
		{
			if (_oVictimName6 != null)
			{
				return _oVictimName6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VictimNameShow6 != value && _oVictimName6 != null)
			{
				_oVictimName6.SetObjectActive(value);
			}
		}
	}

	public string VictimNameString1
	{
		get
		{
			if (_oVictimNameText1 != null)
			{
				return _oVictimNameText1.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString1 != value && _oVictimNameText1 != null)
			{
				_oVictimNameText1.text = value;
			}
		}
	}

	public string VictimNameString2
	{
		get
		{
			if (_oVictimNameText2 != null)
			{
				return _oVictimNameText2.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString2 != value && _oVictimNameText2 != null)
			{
				_oVictimNameText2.text = value;
			}
		}
	}

	public string VictimNameString3
	{
		get
		{
			if (_oVictimNameText3 != null)
			{
				return _oVictimNameText3.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString3 != value && _oVictimNameText3 != null)
			{
				_oVictimNameText3.text = value;
			}
		}
	}

	public string VictimNameString4
	{
		get
		{
			if (_oVictimNameText4 != null)
			{
				return _oVictimNameText4.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString4 != value && _oVictimNameText4 != null)
			{
				_oVictimNameText4.text = value;
			}
		}
	}

	public string VictimNameString5
	{
		get
		{
			if (_oVictimNameText5 != null)
			{
				return _oVictimNameText5.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString5 != value && _oVictimNameText5 != null)
			{
				_oVictimNameText5.text = value;
			}
		}
	}

	public string VictimNameString6
	{
		get
		{
			if (_oVictimNameText6 != null)
			{
				return _oVictimNameText6.text;
			}
			return null;
		}
		set
		{
			if (VictimNameString6 != value && _oVictimNameText6 != null)
			{
				_oVictimNameText6.text = value;
			}
		}
	}

	public bool KillIconEnabled1
	{
		get
		{
			if (_oKillIconImage1 != null)
			{
				return _oKillIconImage1.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled1 != value && _oKillIconImage1 != null)
			{
				_oKillIconImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool KillIconEnabled2
	{
		get
		{
			if (_oKillIconImage2 != null)
			{
				return _oKillIconImage2.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled2 != value && _oKillIconImage2 != null)
			{
				_oKillIconImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool KillIconEnabled3
	{
		get
		{
			if (_oKillIconImage3 != null)
			{
				return _oKillIconImage3.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled3 != value && _oKillIconImage3 != null)
			{
				_oKillIconImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool KillIconEnabled4
	{
		get
		{
			if (_oKillIconImage4 != null)
			{
				return _oKillIconImage4.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled4 != value && _oKillIconImage4 != null)
			{
				_oKillIconImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool KillIconEnabled5
	{
		get
		{
			if (_oKillIconImage5 != null)
			{
				return _oKillIconImage5.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled5 != value && _oKillIconImage5 != null)
			{
				_oKillIconImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool KillIconEnabled6
	{
		get
		{
			if (_oKillIconImage6 != null)
			{
				return _oKillIconImage6.enabled;
			}
			return false;
		}
		set
		{
			if (KillIconEnabled6 != value && _oKillIconImage6 != null)
			{
				_oKillIconImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public string DamageString1
	{
		get
		{
			if (_oDamageText1 != null)
			{
				return _oDamageText1.text;
			}
			return null;
		}
		set
		{
			if (DamageString1 != value && _oDamageText1 != null)
			{
				_oDamageText1.text = value;
			}
		}
	}

	public string DamageString2
	{
		get
		{
			if (_oDamageText2 != null)
			{
				return _oDamageText2.text;
			}
			return null;
		}
		set
		{
			if (DamageString2 != value && _oDamageText2 != null)
			{
				_oDamageText2.text = value;
			}
		}
	}

	public string DamageString3
	{
		get
		{
			if (_oDamageText3 != null)
			{
				return _oDamageText3.text;
			}
			return null;
		}
		set
		{
			if (DamageString3 != value && _oDamageText3 != null)
			{
				_oDamageText3.text = value;
			}
		}
	}

	public string DamageString4
	{
		get
		{
			if (_oDamageText4 != null)
			{
				return _oDamageText4.text;
			}
			return null;
		}
		set
		{
			if (DamageString4 != value && _oDamageText4 != null)
			{
				_oDamageText4.text = value;
			}
		}
	}

	public string DamageString5
	{
		get
		{
			if (_oDamageText5 != null)
			{
				return _oDamageText5.text;
			}
			return null;
		}
		set
		{
			if (DamageString5 != value && _oDamageText5 != null)
			{
				_oDamageText5.text = value;
			}
		}
	}

	public string DamageString6
	{
		get
		{
			if (_oDamageText6 != null)
			{
				return _oDamageText6.text;
			}
			return null;
		}
		set
		{
			if (DamageString6 != value && _oDamageText6 != null)
			{
				_oDamageText6.text = value;
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
			case "KillInfo":
				_oKillInfo = transform.gameObject;
				break;
			case "KillerName":
				_oKillerName = transform.gameObject;
				_oKillerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponName":
				_oWeaponName = transform.gameObject;
				_oWeaponNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName1":
				_oVictimName1 = transform.gameObject;
				_oVictimNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName2":
				_oVictimName2 = transform.gameObject;
				_oVictimNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName3":
				_oVictimName3 = transform.gameObject;
				_oVictimNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName4":
				_oVictimName4 = transform.gameObject;
				_oVictimNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName5":
				_oVictimName5 = transform.gameObject;
				_oVictimNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "VictimName6":
				_oVictimName6 = transform.gameObject;
				_oVictimNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillIcon1":
				_oKillIcon1 = transform.gameObject;
				_oKillIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillIcon2":
				_oKillIcon2 = transform.gameObject;
				_oKillIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillIcon3":
				_oKillIcon3 = transform.gameObject;
				_oKillIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillIcon4":
				_oKillIcon4 = transform.gameObject;
				_oKillIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillIcon5":
				_oKillIcon5 = transform.gameObject;
				_oKillIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillIcon6":
				_oKillIcon6 = transform.gameObject;
				_oKillIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Damage1":
				_oDamage1 = transform.gameObject;
				_oDamageText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Damage2":
				_oDamage2 = transform.gameObject;
				_oDamageText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Damage3":
				_oDamage3 = transform.gameObject;
				_oDamageText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Damage4":
				_oDamage4 = transform.gameObject;
				_oDamageText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Damage5":
				_oDamage5 = transform.gameObject;
				_oDamageText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Damage6":
				_oDamage6 = transform.gameObject;
				_oDamageText6 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void WeaponNtvsize()
	{
		if (_oWeaponImage != null)
		{
			_oWeaponImage.SetNativeSize();
		}
	}

	public bool GetVictimNameShow(int index)
	{
		return index switch
		{
			1 => VictimNameShow1, 
			2 => VictimNameShow2, 
			3 => VictimNameShow3, 
			4 => VictimNameShow4, 
			5 => VictimNameShow5, 
			6 => VictimNameShow6, 
			_ => false, 
		};
	}

	public void SetVictimNameShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			VictimNameShow1 = value;
			break;
		case 2:
			VictimNameShow2 = value;
			break;
		case 3:
			VictimNameShow3 = value;
			break;
		case 4:
			VictimNameShow4 = value;
			break;
		case 5:
			VictimNameShow5 = value;
			break;
		case 6:
			VictimNameShow6 = value;
			break;
		}
	}

	public string GetVictimNameString(int index)
	{
		return index switch
		{
			1 => VictimNameString1, 
			2 => VictimNameString2, 
			3 => VictimNameString3, 
			4 => VictimNameString4, 
			5 => VictimNameString5, 
			6 => VictimNameString6, 
			_ => null, 
		};
	}

	public void SetVictimNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			VictimNameString1 = value;
			break;
		case 2:
			VictimNameString2 = value;
			break;
		case 3:
			VictimNameString3 = value;
			break;
		case 4:
			VictimNameString4 = value;
			break;
		case 5:
			VictimNameString5 = value;
			break;
		case 6:
			VictimNameString6 = value;
			break;
		}
	}

	public bool GetKillIconEnabled(int index)
	{
		return index switch
		{
			1 => KillIconEnabled1, 
			2 => KillIconEnabled2, 
			3 => KillIconEnabled3, 
			4 => KillIconEnabled4, 
			5 => KillIconEnabled5, 
			6 => KillIconEnabled6, 
			_ => false, 
		};
	}

	public void SetKillIconEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			KillIconEnabled1 = value;
			break;
		case 2:
			KillIconEnabled2 = value;
			break;
		case 3:
			KillIconEnabled3 = value;
			break;
		case 4:
			KillIconEnabled4 = value;
			break;
		case 5:
			KillIconEnabled5 = value;
			break;
		case 6:
			KillIconEnabled6 = value;
			break;
		}
	}

	public string GetDamageString(int index)
	{
		return index switch
		{
			1 => DamageString1, 
			2 => DamageString2, 
			3 => DamageString3, 
			4 => DamageString4, 
			5 => DamageString5, 
			6 => DamageString6, 
			_ => null, 
		};
	}

	public void SetDamageString(int index, string value)
	{
		switch (index)
		{
		case 1:
			DamageString1 = value;
			break;
		case 2:
			DamageString2 = value;
			break;
		case 3:
			DamageString3 = value;
			break;
		case 4:
			DamageString4 = value;
			break;
		case 5:
			DamageString5 = value;
			break;
		case 6:
			DamageString6 = value;
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
