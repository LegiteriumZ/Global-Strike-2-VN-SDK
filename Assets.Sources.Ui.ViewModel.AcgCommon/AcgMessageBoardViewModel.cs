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
public class AcgMessageBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oMessageBack0;

	private GameObject _oMessageBack1;

	private GameObject _oMessageBack2;

	private GameObject _oMessageBack3;

	private GameObject _oMessage0;

	private GameObject _oMessage1;

	private GameObject _oMessage2;

	private GameObject _oMessage3;

	private Text _oMessageText0;

	private Text _oMessageText1;

	private Text _oMessageText2;

	private Text _oMessageText3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgmessageboard";

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

	public bool MessageBackShow0
	{
		get
		{
			if (_oMessageBack0 != null)
			{
				return _oMessageBack0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageBackShow0 != value && _oMessageBack0 != null)
			{
				_oMessageBack0.SetObjectActive(value);
			}
		}
	}

	public bool MessageBackShow1
	{
		get
		{
			if (_oMessageBack1 != null)
			{
				return _oMessageBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageBackShow1 != value && _oMessageBack1 != null)
			{
				_oMessageBack1.SetObjectActive(value);
			}
		}
	}

	public bool MessageBackShow2
	{
		get
		{
			if (_oMessageBack2 != null)
			{
				return _oMessageBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageBackShow2 != value && _oMessageBack2 != null)
			{
				_oMessageBack2.SetObjectActive(value);
			}
		}
	}

	public bool MessageBackShow3
	{
		get
		{
			if (_oMessageBack3 != null)
			{
				return _oMessageBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageBackShow3 != value && _oMessageBack3 != null)
			{
				_oMessageBack3.SetObjectActive(value);
			}
		}
	}

	public string MessageString0
	{
		get
		{
			if (_oMessageText0 != null)
			{
				return _oMessageText0.text;
			}
			return null;
		}
		set
		{
			if (MessageString0 != value && _oMessageText0 != null)
			{
				_oMessageText0.text = value;
			}
		}
	}

	public string MessageString1
	{
		get
		{
			if (_oMessageText1 != null)
			{
				return _oMessageText1.text;
			}
			return null;
		}
		set
		{
			if (MessageString1 != value && _oMessageText1 != null)
			{
				_oMessageText1.text = value;
			}
		}
	}

	public string MessageString2
	{
		get
		{
			if (_oMessageText2 != null)
			{
				return _oMessageText2.text;
			}
			return null;
		}
		set
		{
			if (MessageString2 != value && _oMessageText2 != null)
			{
				_oMessageText2.text = value;
			}
		}
	}

	public string MessageString3
	{
		get
		{
			if (_oMessageText3 != null)
			{
				return _oMessageText3.text;
			}
			return null;
		}
		set
		{
			if (MessageString3 != value && _oMessageText3 != null)
			{
				_oMessageText3.text = value;
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
			case "MessageBack0":
				_oMessageBack0 = transform.gameObject;
				break;
			case "MessageBack1":
				_oMessageBack1 = transform.gameObject;
				break;
			case "MessageBack2":
				_oMessageBack2 = transform.gameObject;
				break;
			case "MessageBack3":
				_oMessageBack3 = transform.gameObject;
				break;
			case "Message0":
				_oMessage0 = transform.gameObject;
				_oMessageText0 = transform.gameObject.GetComponent<Text>();
				break;
			case "Message1":
				_oMessage1 = transform.gameObject;
				_oMessageText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Message2":
				_oMessage2 = transform.gameObject;
				_oMessageText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Message3":
				_oMessage3 = transform.gameObject;
				_oMessageText3 = transform.gameObject.GetComponent<Text>();
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

	public bool GetMessageBackShow(int index)
	{
		return index switch
		{
			0 => MessageBackShow0, 
			1 => MessageBackShow1, 
			2 => MessageBackShow2, 
			3 => MessageBackShow3, 
			_ => false, 
		};
	}

	public void SetMessageBackShow(int index, bool value)
	{
		switch (index)
		{
		case 0:
			MessageBackShow0 = value;
			break;
		case 1:
			MessageBackShow1 = value;
			break;
		case 2:
			MessageBackShow2 = value;
			break;
		case 3:
			MessageBackShow3 = value;
			break;
		}
	}

	public int GetMessageBackCount()
	{
		return 3;
	}

	public string GetMessageString(int index)
	{
		return index switch
		{
			0 => MessageString0, 
			1 => MessageString1, 
			2 => MessageString2, 
			3 => MessageString3, 
			_ => null, 
		};
	}

	public void SetMessageString(int index, string value)
	{
		switch (index)
		{
		case 0:
			MessageString0 = value;
			break;
		case 1:
			MessageString1 = value;
			break;
		case 2:
			MessageString2 = value;
			break;
		case 3:
			MessageString3 = value;
			break;
		}
	}

	public int GetMessageCount()
	{
		return 3;
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
