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
public class RpgTowerLevelUpTypeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oLevelUp;

	private EventTrigger _oLevelUpEventTrigger;

	private Button _oLevelUpButton;

	private GameObject _oSale;

	private EventTrigger _oSaleEventTrigger;

	private Button _oSaleButton;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private Button _oCloseButton;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerLevelUpType";

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

	public List<EventTrigger.Entry> LevelUpTriggers
	{
		get
		{
			if (_oLevelUpEventTrigger != null)
			{
				return _oLevelUpEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (LevelUpTriggers != value && _oLevelUpEventTrigger != null)
			{
				_oLevelUpEventTrigger.triggers = value;
			}
		}
	}

	public bool LevelUpButtonable
	{
		get
		{
			if (_oLevelUpButton != null)
			{
				return _oLevelUpButton.interactable;
			}
			return true;
		}
		set
		{
			if (LevelUpButtonable != value && _oLevelUpButton != null)
			{
				_oLevelUpButton.interactable = value;
			}
		}
	}

	public List<EventTrigger.Entry> SaleTriggers
	{
		get
		{
			if (_oSaleEventTrigger != null)
			{
				return _oSaleEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (SaleTriggers != value && _oSaleEventTrigger != null)
			{
				_oSaleEventTrigger.triggers = value;
			}
		}
	}

	public bool SaleButtonable
	{
		get
		{
			if (_oSaleButton != null)
			{
				return _oSaleButton.interactable;
			}
			return true;
		}
		set
		{
			if (SaleButtonable != value && _oSaleButton != null)
			{
				_oSaleButton.interactable = value;
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
			case "LevelUp":
				_oLevelUp = transform.gameObject;
				_oLevelUpEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oLevelUpButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Sale":
				_oSale = transform.gameObject;
				_oSaleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oSaleButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCloseButton = transform.gameObject.GetComponent<Button>();
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

	private void CreateLevelUpTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(LevelUpTriggers, eventId, callback);
	}

	private void RemoveLevelUpTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(LevelUpTriggers, eventId);
	}

	private void CreateSaleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SaleTriggers, eventId, callback);
	}

	private void RemoveSaleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SaleTriggers, eventId);
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
