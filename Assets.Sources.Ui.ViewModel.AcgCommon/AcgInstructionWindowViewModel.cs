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

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgInstructionWindowViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oStartBack;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _oProgress;

	private Text _oProgressText;

	private GameObject _oReady;

	private GameObject _oNotReady;

	private GameObject _oTrade;

	private GameObject _oRefill;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acginstructionwindow";

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

	public bool StartBackShow
	{
		get
		{
			if (_oStartBack != null)
			{
				return _oStartBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StartBackShow != value && _oStartBack != null)
			{
				_oStartBack.SetObjectActive(value);
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

	public bool ProgressShow
	{
		get
		{
			if (_oProgress != null)
			{
				return _oProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow != value && _oProgress != null)
			{
				_oProgress.SetObjectActive(value);
			}
		}
	}

	public string ProgressString
	{
		get
		{
			if (_oProgressText != null)
			{
				return _oProgressText.text;
			}
			return null;
		}
		set
		{
			if (ProgressString != value && _oProgressText != null)
			{
				_oProgressText.text = value;
			}
		}
	}

	public bool ReadyShow
	{
		get
		{
			if (_oReady != null)
			{
				return _oReady.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReadyShow != value && _oReady != null)
			{
				_oReady.SetObjectActive(value);
			}
		}
	}

	public bool NotReadyShow
	{
		get
		{
			if (_oNotReady != null)
			{
				return _oNotReady.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NotReadyShow != value && _oNotReady != null)
			{
				_oNotReady.SetObjectActive(value);
			}
		}
	}

	public bool TradeShow
	{
		get
		{
			if (_oTrade != null)
			{
				return _oTrade.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TradeShow != value && _oTrade != null)
			{
				_oTrade.SetObjectActive(value);
			}
		}
	}

	public bool RefillShow
	{
		get
		{
			if (_oRefill != null)
			{
				return _oRefill.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RefillShow != value && _oRefill != null)
			{
				_oRefill.SetObjectActive(value);
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
			case "StartBack":
				_oStartBack = transform.gameObject;
				break;
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressText = transform.gameObject.GetComponent<Text>();
				break;
			case "Ready":
				_oReady = transform.gameObject;
				break;
			case "NotReady":
				_oNotReady = transform.gameObject;
				break;
			case "Trade":
				_oTrade = transform.gameObject;
				break;
			case "Refill":
				_oRefill = transform.gameObject;
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
}
