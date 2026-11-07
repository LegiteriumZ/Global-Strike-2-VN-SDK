using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.RpgGroup;

[GameUiTest]
public class RpgGroupWaitPlayerViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _oTotalTime;

	private Text _oTotalTimeText;

	private GameObject _oPlayer;

	private Text _oPlayerText;

	private GameObject _oTotalPlayer;

	private Text _oTotalPlayerText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpggroup";

	private string _resourceAssetName = "RpgGroupWaitPlayer";

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public string TimeString
	{
		get
		{
			if (_oTimeText != null)
			{
				return _oTimeText.text;
			}
			return null;
		}
		set
		{
			if (TimeString != value && _oTimeText != null)
			{
				_oTimeText.text = value;
			}
		}
	}

	public string TotalTimeString
	{
		get
		{
			if (_oTotalTimeText != null)
			{
				return _oTotalTimeText.text;
			}
			return null;
		}
		set
		{
			if (TotalTimeString != value && _oTotalTimeText != null)
			{
				_oTotalTimeText.text = value;
			}
		}
	}

	public string PlayerString
	{
		get
		{
			if (_oPlayerText != null)
			{
				return _oPlayerText.text;
			}
			return null;
		}
		set
		{
			if (PlayerString != value && _oPlayerText != null)
			{
				_oPlayerText.text = value;
			}
		}
	}

	public string TotalPlayerString
	{
		get
		{
			if (_oTotalPlayerText != null)
			{
				return _oTotalPlayerText.text;
			}
			return null;
		}
		set
		{
			if (TotalPlayerString != value && _oTotalPlayerText != null)
			{
				_oTotalPlayerText.text = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalTime":
				_oTotalTime = transform.gameObject;
				_oTotalTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "Player":
				_oPlayer = transform.gameObject;
				_oPlayerText = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalPlayer":
				_oTotalPlayer = transform.gameObject;
				_oTotalPlayerText = transform.gameObject.GetComponent<Text>();
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
