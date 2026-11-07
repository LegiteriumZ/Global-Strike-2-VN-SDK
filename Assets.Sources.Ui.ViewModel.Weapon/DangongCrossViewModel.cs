using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class DangongCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oDangongLeft;

	private RectTransform _oDangongLeftRectTransform;

	private GameObject _oDangongRight;

	private RectTransform _oDangongRightRectTransform;

	private GameObject _oDangongBottom;

	private RectTransform _oDangongBottomRectTransform;

	private GameObject _oDangongTop;

	private RectTransform _oDangongTopRectTransform;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "DangongCross";

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

	public Vector3 DangongLeftPosition
	{
		get
		{
			if (_oDangongLeftRectTransform != null)
			{
				return _oDangongLeftRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DangongLeftPosition != value && _oDangongLeftRectTransform != null)
			{
				_oDangongLeftRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 DangongRightPosition
	{
		get
		{
			if (_oDangongRightRectTransform != null)
			{
				return _oDangongRightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DangongRightPosition != value && _oDangongRightRectTransform != null)
			{
				_oDangongRightRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 DangongBottomPosition
	{
		get
		{
			if (_oDangongBottomRectTransform != null)
			{
				return _oDangongBottomRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DangongBottomPosition != value && _oDangongBottomRectTransform != null)
			{
				_oDangongBottomRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 DangongTopPosition
	{
		get
		{
			if (_oDangongTopRectTransform != null)
			{
				return _oDangongTopRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DangongTopPosition != value && _oDangongTopRectTransform != null)
			{
				_oDangongTopRectTransform.localPosition = value;
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
			case "DangongLeft":
				_oDangongLeft = transform.gameObject;
				_oDangongLeftRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "DangongRight":
				_oDangongRight = transform.gameObject;
				_oDangongRightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "DangongBottom":
				_oDangongBottom = transform.gameObject;
				_oDangongBottomRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "DangongTop":
				_oDangongTop = transform.gameObject;
				_oDangongTopRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			}
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
