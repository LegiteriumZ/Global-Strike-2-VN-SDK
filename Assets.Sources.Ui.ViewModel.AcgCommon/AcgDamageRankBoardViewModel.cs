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
public class AcgDamageRankBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oFolded;

	private EventTrigger _oFoldedEventTrigger;

	private Button _oFoldedButton;

	private GameObject _oExtended;

	private EventTrigger _oExtendedEventTrigger;

	private Button _oExtendedButton;

	private GameObject _oGrid;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgdamagerankboard";

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

	public bool FoldedShow
	{
		get
		{
			if (_oFolded != null)
			{
				return _oFolded.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FoldedShow != value && _oFolded != null)
			{
				_oFolded.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> FoldedTriggers
	{
		get
		{
			if (_oFoldedEventTrigger != null)
			{
				return _oFoldedEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (FoldedTriggers != value && _oFoldedEventTrigger != null)
			{
				_oFoldedEventTrigger.triggers = value;
			}
		}
	}

	public Button FoldedButton
	{
		get
		{
			if (_oFoldedButton != null)
			{
				return _oFoldedButton;
			}
			return null;
		}
		set
		{
			if (FoldedButton != value && _oFoldedButton != null)
			{
				_oFoldedButton = value;
			}
		}
	}

	public bool ExtendedShow
	{
		get
		{
			if (_oExtended != null)
			{
				return _oExtended.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtendedShow != value && _oExtended != null)
			{
				_oExtended.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ExtendedTriggers
	{
		get
		{
			if (_oExtendedEventTrigger != null)
			{
				return _oExtendedEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ExtendedTriggers != value && _oExtendedEventTrigger != null)
			{
				_oExtendedEventTrigger.triggers = value;
			}
		}
	}

	public Button ExtendedButton
	{
		get
		{
			if (_oExtendedButton != null)
			{
				return _oExtendedButton;
			}
			return null;
		}
		set
		{
			if (ExtendedButton != value && _oExtendedButton != null)
			{
				_oExtendedButton = value;
			}
		}
	}

	public GameObject GridObj => _oGrid;

	public bool GridShow
	{
		get
		{
			if (_oGrid != null)
			{
				return _oGrid.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GridShow != value && _oGrid != null)
			{
				_oGrid.SetObjectActive(value);
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
			case "Folded":
				_oFolded = transform.gameObject;
				_oFoldedEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oFoldedButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Extended":
				_oExtended = transform.gameObject;
				_oExtendedEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oExtendedButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				break;
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
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

	private void CreateFoldedTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(FoldedTriggers, eventId, callback);
	}

	private void RemoveFoldedTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(FoldedTriggers, eventId);
	}

	private void CreateExtendedTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ExtendedTriggers, eventId, callback);
	}

	private void RemoveExtendedTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ExtendedTriggers, eventId);
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
