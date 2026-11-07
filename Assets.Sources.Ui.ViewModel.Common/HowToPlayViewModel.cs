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
public class HowToPlayViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _omechWarrior2;

	private Image _omechWarriorImage2;

	private GameObject _oOk;

	private EventTrigger _oOkEventTrigger;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "HowToPlay";

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

	public bool mechWarriorShow2
	{
		get
		{
			if (_omechWarrior2 != null)
			{
				return _omechWarrior2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mechWarriorShow2 != value && _omechWarrior2 != null)
			{
				_omechWarrior2.SetObjectActive(value);
			}
		}
	}

	public Sprite mechWarriorSprite2
	{
		get
		{
			if (_omechWarriorImage2 != null)
			{
				return _omechWarriorImage2.sprite;
			}
			return null;
		}
		set
		{
			if (mechWarriorSprite2 != value && _omechWarriorImage2 != null)
			{
				_omechWarriorImage2.sprite = value;
			}
		}
	}

	public List<EventTrigger.Entry> OkTriggers
	{
		get
		{
			if (_oOkEventTrigger != null)
			{
				return _oOkEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (OkTriggers != value && _oOkEventTrigger != null)
			{
				_oOkEventTrigger.triggers = value;
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
			case "mechWarrior2":
				_omechWarrior2 = transform.gameObject;
				_omechWarriorImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Ok":
				_oOk = transform.gameObject;
				_oOkEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			}
		}
	}

	public bool GetmechWarriorShow(int index)
	{
		if (index == 2)
		{
			return mechWarriorShow2;
		}
		return false;
	}

	public void SetmechWarriorShow(int index, bool value)
	{
		if (index == 2)
		{
			mechWarriorShow2 = value;
		}
	}

	public Sprite GetmechWarriorSprite(int index)
	{
		if (index == 2)
		{
			return mechWarriorSprite2;
		}
		return null;
	}

	public void SetmechWarriorSprite(int index, Sprite value)
	{
		if (index == 2)
		{
			mechWarriorSprite2 = value;
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
