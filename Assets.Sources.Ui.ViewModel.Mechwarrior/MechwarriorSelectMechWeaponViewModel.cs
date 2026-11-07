using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Mechwarrior;

[GameUiTest]
public class MechwarriorSelectMechWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oSelected1;

	private GameObject _oSelected2;

	private GameObject _oSelected3;

	private GameObject _oNohave1;

	private GameObject _oNohave2;

	private GameObject _oNohave3;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorSelectMechWeapon";

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

	public bool NohaveShow1
	{
		get
		{
			if (_oNohave1 != null)
			{
				return _oNohave1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohaveShow1 != value && _oNohave1 != null)
			{
				_oNohave1.SetObjectActive(value);
			}
		}
	}

	public bool NohaveShow2
	{
		get
		{
			if (_oNohave2 != null)
			{
				return _oNohave2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohaveShow2 != value && _oNohave2 != null)
			{
				_oNohave2.SetObjectActive(value);
			}
		}
	}

	public bool NohaveShow3
	{
		get
		{
			if (_oNohave3 != null)
			{
				return _oNohave3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohaveShow3 != value && _oNohave3 != null)
			{
				_oNohave3.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
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
			case "Selected1":
				_oSelected1 = transform.gameObject;
				break;
			case "Selected2":
				_oSelected2 = transform.gameObject;
				break;
			case "Selected3":
				_oSelected3 = transform.gameObject;
				break;
			case "Nohave1":
				_oNohave1 = transform.gameObject;
				break;
			case "Nohave2":
				_oNohave2 = transform.gameObject;
				break;
			case "Nohave3":
				_oNohave3 = transform.gameObject;
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetSelectedShow(int index)
	{
		return index switch
		{
			1 => SelectedShow1, 
			2 => SelectedShow2, 
			3 => SelectedShow3, 
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
		}
	}

	public bool GetNohaveShow(int index)
	{
		return index switch
		{
			1 => NohaveShow1, 
			2 => NohaveShow2, 
			3 => NohaveShow3, 
			_ => false, 
		};
	}

	public void SetNohaveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NohaveShow1 = value;
			break;
		case 2:
			NohaveShow2 = value;
			break;
		case 3:
			NohaveShow3 = value;
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
