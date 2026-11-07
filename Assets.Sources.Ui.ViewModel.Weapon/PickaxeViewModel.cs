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

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class PickaxeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _odunBg1;

	private GameObject _odunBg2;

	private GameObject _odunBg3;

	private GameObject _odunBg4;

	private GameObject _odunBg5;

	private GameObject _odun1;

	private GameObject _odun2;

	private GameObject _odun3;

	private GameObject _odun4;

	private GameObject _odun5;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Pickaxe";

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

	public Vector3 ShowPosition
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShowPosition != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localPosition = value;
			}
		}
	}

	public bool dunBgShow1
	{
		get
		{
			if (_odunBg1 != null)
			{
				return _odunBg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunBgShow1 != value && _odunBg1 != null)
			{
				_odunBg1.SetObjectActive(value);
			}
		}
	}

	public bool dunBgShow2
	{
		get
		{
			if (_odunBg2 != null)
			{
				return _odunBg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunBgShow2 != value && _odunBg2 != null)
			{
				_odunBg2.SetObjectActive(value);
			}
		}
	}

	public bool dunBgShow3
	{
		get
		{
			if (_odunBg3 != null)
			{
				return _odunBg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunBgShow3 != value && _odunBg3 != null)
			{
				_odunBg3.SetObjectActive(value);
			}
		}
	}

	public bool dunBgShow4
	{
		get
		{
			if (_odunBg4 != null)
			{
				return _odunBg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunBgShow4 != value && _odunBg4 != null)
			{
				_odunBg4.SetObjectActive(value);
			}
		}
	}

	public bool dunBgShow5
	{
		get
		{
			if (_odunBg5 != null)
			{
				return _odunBg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunBgShow5 != value && _odunBg5 != null)
			{
				_odunBg5.SetObjectActive(value);
			}
		}
	}

	public bool dunShow1
	{
		get
		{
			if (_odun1 != null)
			{
				return _odun1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow1 != value && _odun1 != null)
			{
				_odun1.SetObjectActive(value);
			}
		}
	}

	public bool dunShow2
	{
		get
		{
			if (_odun2 != null)
			{
				return _odun2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow2 != value && _odun2 != null)
			{
				_odun2.SetObjectActive(value);
			}
		}
	}

	public bool dunShow3
	{
		get
		{
			if (_odun3 != null)
			{
				return _odun3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow3 != value && _odun3 != null)
			{
				_odun3.SetObjectActive(value);
			}
		}
	}

	public bool dunShow4
	{
		get
		{
			if (_odun4 != null)
			{
				return _odun4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow4 != value && _odun4 != null)
			{
				_odun4.SetObjectActive(value);
			}
		}
	}

	public bool dunShow5
	{
		get
		{
			if (_odun5 != null)
			{
				return _odun5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow5 != value && _odun5 != null)
			{
				_odun5.SetObjectActive(value);
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "dunBg1":
				_odunBg1 = transform.gameObject;
				break;
			case "dunBg2":
				_odunBg2 = transform.gameObject;
				break;
			case "dunBg3":
				_odunBg3 = transform.gameObject;
				break;
			case "dunBg4":
				_odunBg4 = transform.gameObject;
				break;
			case "dunBg5":
				_odunBg5 = transform.gameObject;
				break;
			case "dun1":
				_odun1 = transform.gameObject;
				break;
			case "dun2":
				_odun2 = transform.gameObject;
				break;
			case "dun3":
				_odun3 = transform.gameObject;
				break;
			case "dun4":
				_odun4 = transform.gameObject;
				break;
			case "dun5":
				_odun5 = transform.gameObject;
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

	public bool GetdunBgShow(int index)
	{
		return index switch
		{
			1 => dunBgShow1, 
			2 => dunBgShow2, 
			3 => dunBgShow3, 
			4 => dunBgShow4, 
			5 => dunBgShow5, 
			_ => false, 
		};
	}

	public void SetdunBgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			dunBgShow1 = value;
			break;
		case 2:
			dunBgShow2 = value;
			break;
		case 3:
			dunBgShow3 = value;
			break;
		case 4:
			dunBgShow4 = value;
			break;
		case 5:
			dunBgShow5 = value;
			break;
		}
	}

	public int GetdunBgCount()
	{
		return 5;
	}

	public bool GetdunShow(int index)
	{
		return index switch
		{
			1 => dunShow1, 
			2 => dunShow2, 
			3 => dunShow3, 
			4 => dunShow4, 
			5 => dunShow5, 
			_ => false, 
		};
	}

	public void SetdunShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			dunShow1 = value;
			break;
		case 2:
			dunShow2 = value;
			break;
		case 3:
			dunShow3 = value;
			break;
		case 4:
			dunShow4 = value;
			break;
		case 5:
			dunShow5 = value;
			break;
		}
	}

	public int GetdunCount()
	{
		return 5;
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
