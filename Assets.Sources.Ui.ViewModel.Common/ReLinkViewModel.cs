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
public class ReLinkViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oDisconnectText;

	private Text _oDisconnectTextText;

	private GameObject _oReLinkCountText;

	private Text _oReLinkCountTextText;

	private GameObject _oReLinkTimeText;

	private Text _oReLinkTimeTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ReLink";

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

	public string DisconnectTextString
	{
		get
		{
			if (_oDisconnectTextText != null)
			{
				return _oDisconnectTextText.text;
			}
			return null;
		}
		set
		{
			if (DisconnectTextString != value && _oDisconnectTextText != null)
			{
				_oDisconnectTextText.text = value;
			}
		}
	}

	public string ReLinkCountTextString
	{
		get
		{
			if (_oReLinkCountTextText != null)
			{
				return _oReLinkCountTextText.text;
			}
			return null;
		}
		set
		{
			if (ReLinkCountTextString != value && _oReLinkCountTextText != null)
			{
				_oReLinkCountTextText.text = value;
			}
		}
	}

	public string ReLinkTimeTextString
	{
		get
		{
			if (_oReLinkTimeTextText != null)
			{
				return _oReLinkTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (ReLinkTimeTextString != value && _oReLinkTimeTextText != null)
			{
				_oReLinkTimeTextText.text = value;
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
			case "DisconnectText":
				_oDisconnectText = transform.gameObject;
				_oDisconnectTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ReLinkCountText":
				_oReLinkCountText = transform.gameObject;
				_oReLinkCountTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ReLinkTimeText":
				_oReLinkTimeText = transform.gameObject;
				_oReLinkTimeTextText = transform.gameObject.GetComponent<Text>();
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
