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

namespace Assets.Sources.Ui.ViewModel.RpgTower;

[GameUiTest]
public class RpgTowerSaleViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTitle;

	private Text _oTitleText;

	private GameObject _oComfirm;

	private EventTrigger _oComfirmEventTrigger;

	private Button _oComfirmButton;

	private GameObject _oCancel;

	private EventTrigger _oCancelEventTrigger;

	private Button _oCancelButton;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private Button _oCloseButton;

	private GameObject _oDes;

	private Text _oDesText;

	private GameObject _oCost;

	private Text _oCostText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerSale";

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

	public string TitleString
	{
		get
		{
			if (_oTitleText != null)
			{
				return _oTitleText.text;
			}
			return null;
		}
		set
		{
			if (TitleString != value && _oTitleText != null)
			{
				_oTitleText.text = value;
			}
		}
	}

	public List<EventTrigger.Entry> ComfirmTriggers
	{
		get
		{
			if (_oComfirmEventTrigger != null)
			{
				return _oComfirmEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ComfirmTriggers != value && _oComfirmEventTrigger != null)
			{
				_oComfirmEventTrigger.triggers = value;
			}
		}
	}

	public bool ComfirmButtonable
	{
		get
		{
			if (_oComfirmButton != null)
			{
				return _oComfirmButton.interactable;
			}
			return true;
		}
		set
		{
			if (ComfirmButtonable != value && _oComfirmButton != null)
			{
				_oComfirmButton.interactable = value;
			}
		}
	}

	public List<EventTrigger.Entry> CancelTriggers
	{
		get
		{
			if (_oCancelEventTrigger != null)
			{
				return _oCancelEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CancelTriggers != value && _oCancelEventTrigger != null)
			{
				_oCancelEventTrigger.triggers = value;
			}
		}
	}

	public bool CancelButtonable
	{
		get
		{
			if (_oCancelButton != null)
			{
				return _oCancelButton.interactable;
			}
			return true;
		}
		set
		{
			if (CancelButtonable != value && _oCancelButton != null)
			{
				_oCancelButton.interactable = value;
			}
		}
	}

	public List<EventTrigger.Entry> CloseTriggers
	{
		get
		{
			if (_oCloseEventTrigger != null)
			{
				return _oCloseEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseTriggers != value && _oCloseEventTrigger != null)
			{
				_oCloseEventTrigger.triggers = value;
			}
		}
	}

	public bool CloseButtonable
	{
		get
		{
			if (_oCloseButton != null)
			{
				return _oCloseButton.interactable;
			}
			return true;
		}
		set
		{
			if (CloseButtonable != value && _oCloseButton != null)
			{
				_oCloseButton.interactable = value;
			}
		}
	}

	public string DesString
	{
		get
		{
			if (_oDesText != null)
			{
				return _oDesText.text;
			}
			return null;
		}
		set
		{
			if (DesString != value && _oDesText != null)
			{
				_oDesText.text = value;
			}
		}
	}

	public string CostString
	{
		get
		{
			if (_oCostText != null)
			{
				return _oCostText.text;
			}
			return null;
		}
		set
		{
			if (CostString != value && _oCostText != null)
			{
				_oCostText.text = value;
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
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleText = transform.gameObject.GetComponent<Text>();
				break;
			case "Comfirm":
				_oComfirm = transform.gameObject;
				_oComfirmEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oComfirmButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Cancel":
				_oCancel = transform.gameObject;
				_oCancelEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCancelButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCloseButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Des":
				_oDes = transform.gameObject;
				_oDesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Cost":
				_oCost = transform.gameObject;
				_oCostText = transform.gameObject.GetComponent<Text>();
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

	private void CreateComfirmTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ComfirmTriggers, eventId, callback);
	}

	private void RemoveComfirmTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ComfirmTriggers, eventId);
	}

	private void CreateCancelTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CancelTriggers, eventId, callback);
	}

	private void RemoveCancelTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CancelTriggers, eventId);
	}

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
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
