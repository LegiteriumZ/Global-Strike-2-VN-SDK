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
public class PromiseMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessage;

	private Image _oMessageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "PromiseMessage";

	public bool MessageShow
	{
		get
		{
			if (_oMessage != null)
			{
				return _oMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow != value && _oMessage != null)
			{
				_oMessage.SetObjectActive(value);
			}
		}
	}

	public Sprite MessageSprite
	{
		get
		{
			if (_oMessageImage != null)
			{
				return _oMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MessageSprite != value && _oMessageImage != null)
			{
				_oMessageImage.sprite = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (text == "Message")
			{
				_oMessage = transform.gameObject;
				_oMessageImage = transform.gameObject.GetComponent<Image>();
			}
		}
	}

	public void MessageNtvsize()
	{
		if (_oMessageImage != null)
		{
			_oMessageImage.SetNativeSize();
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
