using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class CrazyBigheadmessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCtChangeHead;

	private GameObject _oTChangeHead;

	private GameObject _oInCrazyTimeMessage;

	private GameObject _oOutCrazyTimeMessage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "CrazyBigheadmessage";

	private List<RectTransform> _holdPosTrans;

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

	public bool CtChangeHeadShow
	{
		get
		{
			if (_oCtChangeHead != null)
			{
				return _oCtChangeHead.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtChangeHeadShow != value && _oCtChangeHead != null)
			{
				_oCtChangeHead.SetObjectActive(value);
			}
		}
	}

	public bool TChangeHeadShow
	{
		get
		{
			if (_oTChangeHead != null)
			{
				return _oTChangeHead.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TChangeHeadShow != value && _oTChangeHead != null)
			{
				_oTChangeHead.SetObjectActive(value);
			}
		}
	}

	public bool InCrazyTimeMessageShow
	{
		get
		{
			if (_oInCrazyTimeMessage != null)
			{
				return _oInCrazyTimeMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (InCrazyTimeMessageShow != value && _oInCrazyTimeMessage != null)
			{
				_oInCrazyTimeMessage.SetObjectActive(value);
			}
		}
	}

	public bool OutCrazyTimeMessageShow
	{
		get
		{
			if (_oOutCrazyTimeMessage != null)
			{
				return _oOutCrazyTimeMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OutCrazyTimeMessageShow != value && _oOutCrazyTimeMessage != null)
			{
				_oOutCrazyTimeMessage.SetObjectActive(value);
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
			case "CtChangeHead":
				_oCtChangeHead = transform.gameObject;
				break;
			case "TChangeHead":
				_oTChangeHead = transform.gameObject;
				break;
			case "InCrazyTimeMessage":
				_oInCrazyTimeMessage = transform.gameObject;
				break;
			case "OutCrazyTimeMessage":
				_oOutCrazyTimeMessage = transform.gameObject;
				break;
			}
		}
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
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
			UnityEngine.Object.Destroy(_viewGameObject);
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		return _holdPosTrans;
	}
}
