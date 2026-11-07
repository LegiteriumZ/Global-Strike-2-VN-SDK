using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.Finalbio;

[GameUiTest]
public class FinalbioqueenweaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oSelectWeapon1;

	private GameObject _oSelectWeapon2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/finalbio";

	private string _resourceAssetName = "Finalbioqueenweapon";

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public bool SelectWeaponShow1
	{
		get
		{
			if (_oSelectWeapon1 != null)
			{
				return _oSelectWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectWeaponShow1 != value && _oSelectWeapon1 != null)
			{
				_oSelectWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool SelectWeaponShow2
	{
		get
		{
			if (_oSelectWeapon2 != null)
			{
				return _oSelectWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectWeaponShow2 != value && _oSelectWeapon2 != null)
			{
				_oSelectWeapon2.SetObjectActive(value);
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "SelectWeapon1":
				_oSelectWeapon1 = transform.gameObject;
				break;
			case "SelectWeapon2":
				_oSelectWeapon2 = transform.gameObject;
				break;
			}
		}
	}

	public bool GetSelectWeaponShow(int index)
	{
		return index switch
		{
			1 => SelectWeaponShow1, 
			2 => SelectWeaponShow2, 
			_ => false, 
		};
	}

	public void SetSelectWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectWeaponShow1 = value;
			break;
		case 2:
			SelectWeaponShow2 = value;
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
