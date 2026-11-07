using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalcarboxylicViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oMaskImage1;

	private GameObject _oMaskImage2;

	private GameObject _oStateImage1;

	private GameObject _oStateImage2;

	private RectTransform _oStateImageRectTransform1;

	private RectTransform _oStateImageRectTransform2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalcarboxylic";

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public bool MaskImageShow1
	{
		get
		{
			if (_oMaskImage1 != null)
			{
				return _oMaskImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskImageShow1 != value && _oMaskImage1 != null)
			{
				_oMaskImage1.SetObjectActive(value);
			}
		}
	}

	public bool MaskImageShow2
	{
		get
		{
			if (_oMaskImage2 != null)
			{
				return _oMaskImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskImageShow2 != value && _oMaskImage2 != null)
			{
				_oMaskImage2.SetObjectActive(value);
			}
		}
	}

	public Quaternion StateImageRotation1
	{
		get
		{
			if (_oStateImageRectTransform1 != null)
			{
				return _oStateImageRectTransform1.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (StateImageRotation1 != value && _oStateImageRectTransform1 != null)
			{
				_oStateImageRectTransform1.localRotation = value;
			}
		}
	}

	public Quaternion StateImageRotation2
	{
		get
		{
			if (_oStateImageRectTransform2 != null)
			{
				return _oStateImageRectTransform2.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (StateImageRotation2 != value && _oStateImageRectTransform2 != null)
			{
				_oStateImageRectTransform2.localRotation = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "MaskImage1":
				_oMaskImage1 = transform.gameObject;
				break;
			case "MaskImage2":
				_oMaskImage2 = transform.gameObject;
				break;
			case "StateImage1":
				_oStateImage1 = transform.gameObject;
				_oStateImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "StateImage2":
				_oStateImage2 = transform.gameObject;
				_oStateImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			}
		}
	}

	public bool GetMaskImageShow(int index)
	{
		return index switch
		{
			1 => MaskImageShow1, 
			2 => MaskImageShow2, 
			_ => false, 
		};
	}

	public void SetMaskImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MaskImageShow1 = value;
			break;
		case 2:
			MaskImageShow2 = value;
			break;
		}
	}

	public Quaternion GetStateImageRotation(int index)
	{
		return index switch
		{
			1 => StateImageRotation1, 
			2 => StateImageRotation2, 
			_ => Quaternion.Euler(Vector3.zero), 
		};
	}

	public void SetStateImageRotation(int index, Quaternion value)
	{
		switch (index)
		{
		case 1:
			StateImageRotation1 = value;
			break;
		case 2:
			StateImageRotation2 = value;
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
