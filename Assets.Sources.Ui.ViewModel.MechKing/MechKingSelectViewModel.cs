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

namespace Assets.Sources.Ui.ViewModel.MechKing;

[GameUiTest]
public class MechKingSelectViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oSelected1;

	private GameObject _oSelected2;

	private GameObject _oNohave1;

	private GameObject _oNohave2;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/mechking";

	private string _resourceAssetName = "mechkingselect";

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

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow1
	{
		get
		{
			if (_oSelected1 != null)
			{
				return _oSelected1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow1 != value && _oSelected1 != null)
			{
				_oSelected1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow2
	{
		get
		{
			if (_oSelected2 != null)
			{
				return _oSelected2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow2 != value && _oSelected2 != null)
			{
				_oSelected2.SetObjectActive(value);
			}
		}
	}

	public bool NohaveShow1
	{
		get
		{
			if (_oNohave1 != null)
			{
				return _oNohave1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohaveShow1 != value && _oNohave1 != null)
			{
				_oNohave1.SetObjectActive(value);
			}
		}
	}

	public bool NohaveShow2
	{
		get
		{
			if (_oNohave2 != null)
			{
				return _oNohave2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohaveShow2 != value && _oNohave2 != null)
			{
				_oNohave2.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "Selected1":
				_oSelected1 = transform.gameObject;
				break;
			case "Selected2":
				_oSelected2 = transform.gameObject;
				break;
			case "Nohave1":
				_oNohave1 = transform.gameObject;
				break;
			case "Nohave2":
				_oNohave2 = transform.gameObject;
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
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

	public bool GetSelectedShow(int index)
	{
		return index switch
		{
			1 => SelectedShow1, 
			2 => SelectedShow2, 
			_ => false, 
		};
	}

	public void SetSelectedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedShow1 = value;
			break;
		case 2:
			SelectedShow2 = value;
			break;
		}
	}

	public int GetSelectedCount()
	{
		return 2;
	}

	public bool GetNohaveShow(int index)
	{
		return index switch
		{
			1 => NohaveShow1, 
			2 => NohaveShow2, 
			_ => false, 
		};
	}

	public void SetNohaveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NohaveShow1 = value;
			break;
		case 2:
			NohaveShow2 = value;
			break;
		}
	}

	public int GetNohaveCount()
	{
		return 2;
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
