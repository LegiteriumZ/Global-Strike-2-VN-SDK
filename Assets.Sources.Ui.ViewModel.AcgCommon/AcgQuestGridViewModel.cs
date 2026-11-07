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
public class AcgQuestGridViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oAcgQuestGrid;

	private RectTransform _oAcgQuestGridRectTransform;

	private GameObject _oCleared;

	private GameObject _oNotCleared;

	private GameObject _oQuestName;

	private Text _oQuestNameText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgquestgrid";

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

	public bool AcgQuestGridShow
	{
		get
		{
			if (_oAcgQuestGrid != null)
			{
				return _oAcgQuestGrid.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AcgQuestGridShow != value && _oAcgQuestGrid != null)
			{
				_oAcgQuestGrid.SetObjectActive(value);
			}
		}
	}

	public Vector2 AcgQuestGridAnchoredposition
	{
		get
		{
			if (_oAcgQuestGridRectTransform != null)
			{
				return _oAcgQuestGridRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (AcgQuestGridAnchoredposition != value && _oAcgQuestGridRectTransform != null)
			{
				_oAcgQuestGridRectTransform.anchoredPosition = value;
			}
		}
	}

	public bool ClearedShow
	{
		get
		{
			if (_oCleared != null)
			{
				return _oCleared.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ClearedShow != value && _oCleared != null)
			{
				_oCleared.SetObjectActive(value);
			}
		}
	}

	public bool NotClearedShow
	{
		get
		{
			if (_oNotCleared != null)
			{
				return _oNotCleared.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NotClearedShow != value && _oNotCleared != null)
			{
				_oNotCleared.SetObjectActive(value);
			}
		}
	}

	public string QuestNameString
	{
		get
		{
			if (_oQuestNameText != null)
			{
				return _oQuestNameText.text;
			}
			return null;
		}
		set
		{
			if (QuestNameString != value && _oQuestNameText != null)
			{
				_oQuestNameText.text = value;
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
			case "AcgQuestGrid":
				_oAcgQuestGrid = transform.gameObject;
				_oAcgQuestGridRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Cleared":
				_oCleared = transform.gameObject;
				break;
			case "NotCleared":
				_oNotCleared = transform.gameObject;
				break;
			case "QuestName":
				_oQuestName = transform.gameObject;
				_oQuestNameText = transform.gameObject.GetComponent<Text>();
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
