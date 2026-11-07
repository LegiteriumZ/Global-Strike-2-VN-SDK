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
public class HitMarkDamageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

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

	private GameObject _oPart13;

	private GameObject _oPart14;

	private GameObject _oPart15;

	private GameObject _oPart16;

	private GameObject _oPart17;

	private GameObject _oDamageNum;

	private Text _oDamageNumText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "HitMarkDamage";

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

	public Vector3 ShowPosition
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShowPosition != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localPosition = value;
			}
		}
	}

	public bool PartShow1
	{
		get
		{
			if (_oPart1 != null)
			{
				return _oPart1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow1 != value && _oPart1 != null)
			{
				_oPart1.SetObjectActive(value);
			}
		}
	}

	public bool PartShow2
	{
		get
		{
			if (_oPart2 != null)
			{
				return _oPart2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow2 != value && _oPart2 != null)
			{
				_oPart2.SetObjectActive(value);
			}
		}
	}

	public bool PartShow3
	{
		get
		{
			if (_oPart3 != null)
			{
				return _oPart3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow3 != value && _oPart3 != null)
			{
				_oPart3.SetObjectActive(value);
			}
		}
	}

	public bool PartShow4
	{
		get
		{
			if (_oPart4 != null)
			{
				return _oPart4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow4 != value && _oPart4 != null)
			{
				_oPart4.SetObjectActive(value);
			}
		}
	}

	public bool PartShow5
	{
		get
		{
			if (_oPart5 != null)
			{
				return _oPart5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow5 != value && _oPart5 != null)
			{
				_oPart5.SetObjectActive(value);
			}
		}
	}

	public bool PartShow6
	{
		get
		{
			if (_oPart6 != null)
			{
				return _oPart6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow6 != value && _oPart6 != null)
			{
				_oPart6.SetObjectActive(value);
			}
		}
	}

	public bool PartShow7
	{
		get
		{
			if (_oPart7 != null)
			{
				return _oPart7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow7 != value && _oPart7 != null)
			{
				_oPart7.SetObjectActive(value);
			}
		}
	}

	public bool PartShow8
	{
		get
		{
			if (_oPart8 != null)
			{
				return _oPart8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow8 != value && _oPart8 != null)
			{
				_oPart8.SetObjectActive(value);
			}
		}
	}

	public bool PartShow9
	{
		get
		{
			if (_oPart9 != null)
			{
				return _oPart9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow9 != value && _oPart9 != null)
			{
				_oPart9.SetObjectActive(value);
			}
		}
	}

	public bool PartShow10
	{
		get
		{
			if (_oPart10 != null)
			{
				return _oPart10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow10 != value && _oPart10 != null)
			{
				_oPart10.SetObjectActive(value);
			}
		}
	}

	public bool PartShow11
	{
		get
		{
			if (_oPart11 != null)
			{
				return _oPart11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow11 != value && _oPart11 != null)
			{
				_oPart11.SetObjectActive(value);
			}
		}
	}

	public bool PartShow12
	{
		get
		{
			if (_oPart12 != null)
			{
				return _oPart12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow12 != value && _oPart12 != null)
			{
				_oPart12.SetObjectActive(value);
			}
		}
	}

	public bool PartShow13
	{
		get
		{
			if (_oPart13 != null)
			{
				return _oPart13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow13 != value && _oPart13 != null)
			{
				_oPart13.SetObjectActive(value);
			}
		}
	}

	public bool PartShow14
	{
		get
		{
			if (_oPart14 != null)
			{
				return _oPart14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow14 != value && _oPart14 != null)
			{
				_oPart14.SetObjectActive(value);
			}
		}
	}

	public bool PartShow15
	{
		get
		{
			if (_oPart15 != null)
			{
				return _oPart15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow15 != value && _oPart15 != null)
			{
				_oPart15.SetObjectActive(value);
			}
		}
	}

	public bool PartShow16
	{
		get
		{
			if (_oPart16 != null)
			{
				return _oPart16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow16 != value && _oPart16 != null)
			{
				_oPart16.SetObjectActive(value);
			}
		}
	}

	public bool PartShow17
	{
		get
		{
			if (_oPart17 != null)
			{
				return _oPart17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PartShow17 != value && _oPart17 != null)
			{
				_oPart17.SetObjectActive(value);
			}
		}
	}

	public string DamageNumString
	{
		get
		{
			if (_oDamageNumText != null)
			{
				return _oDamageNumText.text;
			}
			return null;
		}
		set
		{
			if (DamageNumString != value && _oDamageNumText != null)
			{
				_oDamageNumText.text = value;
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Part1":
				_oPart1 = transform.gameObject;
				break;
			case "Part2":
				_oPart2 = transform.gameObject;
				break;
			case "Part3":
				_oPart3 = transform.gameObject;
				break;
			case "Part4":
				_oPart4 = transform.gameObject;
				break;
			case "Part5":
				_oPart5 = transform.gameObject;
				break;
			case "Part6":
				_oPart6 = transform.gameObject;
				break;
			case "Part7":
				_oPart7 = transform.gameObject;
				break;
			case "Part8":
				_oPart8 = transform.gameObject;
				break;
			case "Part9":
				_oPart9 = transform.gameObject;
				break;
			case "Part10":
				_oPart10 = transform.gameObject;
				break;
			case "Part11":
				_oPart11 = transform.gameObject;
				break;
			case "Part12":
				_oPart12 = transform.gameObject;
				break;
			case "Part13":
				_oPart13 = transform.gameObject;
				break;
			case "Part14":
				_oPart14 = transform.gameObject;
				break;
			case "Part15":
				_oPart15 = transform.gameObject;
				break;
			case "Part16":
				_oPart16 = transform.gameObject;
				break;
			case "Part17":
				_oPart17 = transform.gameObject;
				break;
			case "DamageNum":
				_oDamageNum = transform.gameObject;
				_oDamageNumText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetPartShow(int index)
	{
		return index switch
		{
			1 => PartShow1, 
			2 => PartShow2, 
			3 => PartShow3, 
			4 => PartShow4, 
			5 => PartShow5, 
			6 => PartShow6, 
			7 => PartShow7, 
			8 => PartShow8, 
			9 => PartShow9, 
			10 => PartShow10, 
			11 => PartShow11, 
			12 => PartShow12, 
			13 => PartShow13, 
			14 => PartShow14, 
			15 => PartShow15, 
			16 => PartShow16, 
			17 => PartShow17, 
			_ => false, 
		};
	}

	public void SetPartShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PartShow1 = value;
			break;
		case 2:
			PartShow2 = value;
			break;
		case 3:
			PartShow3 = value;
			break;
		case 4:
			PartShow4 = value;
			break;
		case 5:
			PartShow5 = value;
			break;
		case 6:
			PartShow6 = value;
			break;
		case 7:
			PartShow7 = value;
			break;
		case 8:
			PartShow8 = value;
			break;
		case 9:
			PartShow9 = value;
			break;
		case 10:
			PartShow10 = value;
			break;
		case 11:
			PartShow11 = value;
			break;
		case 12:
			PartShow12 = value;
			break;
		case 13:
			PartShow13 = value;
			break;
		case 14:
			PartShow14 = value;
			break;
		case 15:
			PartShow15 = value;
			break;
		case 16:
			PartShow16 = value;
			break;
		case 17:
			PartShow17 = value;
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
