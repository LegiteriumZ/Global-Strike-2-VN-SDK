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
public class MessageremindViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oMessageText;

	private Text _oMessageTextText;

	private GameObject _oBottom;

	private GameObject _oBottomText;

	private Text _oBottomTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Messageremind";

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

	public string MessageTextString
	{
		get
		{
			if (_oMessageTextText != null)
			{
				return _oMessageTextText.text;
			}
			return null;
		}
		set
		{
			if (MessageTextString != value && _oMessageTextText != null)
			{
				_oMessageTextText.text = value;
			}
		}
	}

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

	public string BottomTextString
	{
		get
		{
			if (_oBottomTextText != null)
			{
				return _oBottomTextText.text;
			}
			return null;
		}
		set
		{
			if (BottomTextString != value && _oBottomTextText != null)
			{
				_oBottomTextText.text = value;
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
			case "MessageText":
				_oMessageText = transform.gameObject;
				_oMessageTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "BottomText":
				_oBottomText = transform.gameObject;
				_oBottomTextText = transform.gameObject.GetComponent<Text>();
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
