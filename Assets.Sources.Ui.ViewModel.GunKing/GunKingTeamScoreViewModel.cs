using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GunKing;

[GameUiTest]
public class GunKingTeamScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSelfNeedKill;

	private Text _oSelfNeedKillText;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oSelfPhase;

	private Image _oSelfPhaseImage;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private GameObject _oWeapon4;

	private GameObject _oWeapon5;

	private GameObject _oWeapon6;

	private GameObject _oWeapon7;

	private GameObject _oWeapon8;

	private GameObject _oSelfIcon;

	private RectTransform _oSelfIconRectTransform;

	private GameObject _oGunKingBack;

	private RectTransform _oGunKingBackRectTransform;

	private GameObject _oGunKingName;

	private Text _oGunKingNameText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/gunking";

	private string _resourceAssetName = "GunKingTeamScore";

	public string SelfNeedKillString
	{
		get
		{
			if (_oSelfNeedKillText != null)
			{
				return _oSelfNeedKillText.text;
			}
			return null;
		}
		set
		{
			if (SelfNeedKillString != value && _oSelfNeedKillText != null)
			{
				_oSelfNeedKillText.text = value;
			}
		}
	}

	public string MinutesString
	{
		get
		{
			if (_oMinutesText != null)
			{
				return _oMinutesText.text;
			}
			return null;
		}
		set
		{
			if (MinutesString != value && _oMinutesText != null)
			{
				_oMinutesText.text = value;
			}
		}
	}

	public string SecondsString
	{
		get
		{
			if (_oSecondsText != null)
			{
				return _oSecondsText.text;
			}
			return null;
		}
		set
		{
			if (SecondsString != value && _oSecondsText != null)
			{
				_oSecondsText.text = value;
			}
		}
	}

	public float SelfPhaseFillamount
	{
		get
		{
			if (_oSelfPhaseImage != null)
			{
				return _oSelfPhaseImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SelfPhaseFillamount != value && _oSelfPhaseImage != null)
			{
				_oSelfPhaseImage.fillAmount = value;
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

	public bool SelfIconShow
	{
		get
		{
			if (_oSelfIcon != null)
			{
				return _oSelfIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfIconShow != value && _oSelfIcon != null)
			{
				_oSelfIcon.SetObjectActive(value);
			}
		}
	}

	public Vector3 SelfIconPosition
	{
		get
		{
			if (_oSelfIconRectTransform != null)
			{
				return _oSelfIconRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SelfIconPosition != value && _oSelfIconRectTransform != null)
			{
				_oSelfIconRectTransform.localPosition = value;
			}
		}
	}

	public bool GunKingBackShow
	{
		get
		{
			if (_oGunKingBack != null)
			{
				return _oGunKingBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GunKingBackShow != value && _oGunKingBack != null)
			{
				_oGunKingBack.SetObjectActive(value);
			}
		}
	}

	public Vector3 GunKingBackPosition
	{
		get
		{
			if (_oGunKingBackRectTransform != null)
			{
				return _oGunKingBackRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (GunKingBackPosition != value && _oGunKingBackRectTransform != null)
			{
				_oGunKingBackRectTransform.localPosition = value;
			}
		}
	}

	public string GunKingNameString
	{
		get
		{
			if (_oGunKingNameText != null)
			{
				return _oGunKingNameText.text;
			}
			return null;
		}
		set
		{
			if (GunKingNameString != value && _oGunKingNameText != null)
			{
				_oGunKingNameText.text = value;
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
			case "SelfNeedKill":
				_oSelfNeedKill = transform.gameObject;
				_oSelfNeedKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "SelfPhase":
				_oSelfPhase = transform.gameObject;
				_oSelfPhaseImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon1":
				_oWeapon1 = transform.gameObject;
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				break;
			case "Weapon4":
				_oWeapon4 = transform.gameObject;
				break;
			case "Weapon5":
				_oWeapon5 = transform.gameObject;
				break;
			case "Weapon6":
				_oWeapon6 = transform.gameObject;
				break;
			case "Weapon7":
				_oWeapon7 = transform.gameObject;
				break;
			case "Weapon8":
				_oWeapon8 = transform.gameObject;
				break;
			case "SelfIcon":
				_oSelfIcon = transform.gameObject;
				_oSelfIconRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "GunKingBack":
				_oGunKingBack = transform.gameObject;
				_oGunKingBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "GunKingName":
				_oGunKingName = transform.gameObject;
				_oGunKingNameText = transform.gameObject.GetComponent<Text>();
				break;
			}
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
