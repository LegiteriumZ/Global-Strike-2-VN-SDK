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
public class RpgTowerLevelUpTypeMenuViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTitle;

	private Text _oTitleText;

	private GameObject _oLevelUpHavePerson;

	private EventTrigger _oLevelUpHavePersonEventTrigger;

	private Button _oLevelUpHavePersonButton;

	private GameObject _oSale;

	private EventTrigger _oSaleEventTrigger;

	private GameObject _oMove;

	private EventTrigger _oMoveEventTrigger;

	private GameObject _oLevelUpNoPerson;

	private EventTrigger _oLevelUpNoPersonEventTrigger;

	private Button _oLevelUpNoPersonButton;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerLevelUpTypeMenu";

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

	public List<EventTrigger.Entry> LevelUpHavePersonTriggers
	{
		get
		{
			if (_oLevelUpHavePersonEventTrigger != null)
			{
				return _oLevelUpHavePersonEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (LevelUpHavePersonTriggers != value && _oLevelUpHavePersonEventTrigger != null)
			{
				_oLevelUpHavePersonEventTrigger.triggers = value;
			}
		}
	}

	public bool LevelUpHavePersonButtonable
	{
		get
		{
			if (_oLevelUpHavePersonButton != null)
			{
				return _oLevelUpHavePersonButton.interactable;
			}
			return true;
		}
		set
		{
			if (LevelUpHavePersonButtonable != value && _oLevelUpHavePersonButton != null)
			{
				_oLevelUpHavePersonButton.interactable = value;
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

	public List<EventTrigger.Entry> MoveTriggers
	{
		get
		{
			if (_oMoveEventTrigger != null)
			{
				return _oMoveEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (MoveTriggers != value && _oMoveEventTrigger != null)
			{
				_oMoveEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> LevelUpNoPersonTriggers
	{
		get
		{
			if (_oLevelUpNoPersonEventTrigger != null)
			{
				return _oLevelUpNoPersonEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (LevelUpNoPersonTriggers != value && _oLevelUpNoPersonEventTrigger != null)
			{
				_oLevelUpNoPersonEventTrigger.triggers = value;
			}
		}
	}

	public bool LevelUpNoPersonButtonable
	{
		get
		{
			if (_oLevelUpNoPersonButton != null)
			{
				return _oLevelUpNoPersonButton.interactable;
			}
			return true;
		}
		set
		{
			if (LevelUpNoPersonButtonable != value && _oLevelUpNoPersonButton != null)
			{
				_oLevelUpNoPersonButton.interactable = value;
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
			case "LevelUpHavePerson":
				_oLevelUpHavePerson = transform.gameObject;
				_oLevelUpHavePersonEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oLevelUpHavePersonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Sale":
				_oSale = transform.gameObject;
				_oSaleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Move":
				_oMove = transform.gameObject;
				_oMoveEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "LevelUpNoPerson":
				_oLevelUpNoPerson = transform.gameObject;
				_oLevelUpNoPersonEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oLevelUpNoPersonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
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

	private void CreateLevelUpHavePersonTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(LevelUpHavePersonTriggers, eventId, callback);
	}

	private void RemoveLevelUpHavePersonTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(LevelUpHavePersonTriggers, eventId);
	}

	private void CreateSaleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SaleTriggers, eventId, callback);
	}

	private void RemoveSaleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SaleTriggers, eventId);
	}

	private void CreateMoveTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(MoveTriggers, eventId, callback);
	}

	private void RemoveMoveTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(MoveTriggers, eventId);
	}

	private void CreateLevelUpNoPersonTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(LevelUpNoPersonTriggers, eventId, callback);
	}

	private void RemoveLevelUpNoPersonTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(LevelUpNoPersonTriggers, eventId);
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
