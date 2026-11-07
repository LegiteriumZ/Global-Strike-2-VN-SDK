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

namespace Assets.Sources.Ui.ViewModel.Guofengmodel;

[GameUiTest]
public class Guofengmodel_boxViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _obox1;

	private GameObject _obox2;

	private GameObject _oprogress1;

	private GameObject _oprogress2;

	private Text _oprogressText1;

	private Text _oprogressText2;

	private GameObject _oation1_1;

	private GameObject _oation1_2;

	private GameObject _oation1_3;

	private GameObject _oation2_1;

	private GameObject _oation2_2;

	private GameObject _oation2_3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/guofengmodel";

	private string _resourceAssetName = "guofengmodel_box";

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

	public bool boxShow1
	{
		get
		{
			if (_obox1 != null)
			{
				return _obox1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boxShow1 != value && _obox1 != null)
			{
				_obox1.SetObjectActive(value);
			}
		}
	}

	public bool boxShow2
	{
		get
		{
			if (_obox2 != null)
			{
				return _obox2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boxShow2 != value && _obox2 != null)
			{
				_obox2.SetObjectActive(value);
			}
		}
	}

	public string progressString1
	{
		get
		{
			if (_oprogressText1 != null)
			{
				return _oprogressText1.text;
			}
			return null;
		}
		set
		{
			if (progressString1 != value && _oprogressText1 != null)
			{
				_oprogressText1.text = value;
			}
		}
	}

	public string progressString2
	{
		get
		{
			if (_oprogressText2 != null)
			{
				return _oprogressText2.text;
			}
			return null;
		}
		set
		{
			if (progressString2 != value && _oprogressText2 != null)
			{
				_oprogressText2.text = value;
			}
		}
	}

	public bool ation1_Show1
	{
		get
		{
			if (_oation1_1 != null)
			{
				return _oation1_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation1_Show1 != value && _oation1_1 != null)
			{
				_oation1_1.SetObjectActive(value);
			}
		}
	}

	public bool ation1_Show2
	{
		get
		{
			if (_oation1_2 != null)
			{
				return _oation1_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation1_Show2 != value && _oation1_2 != null)
			{
				_oation1_2.SetObjectActive(value);
			}
		}
	}

	public bool ation1_Show3
	{
		get
		{
			if (_oation1_3 != null)
			{
				return _oation1_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation1_Show3 != value && _oation1_3 != null)
			{
				_oation1_3.SetObjectActive(value);
			}
		}
	}

	public bool ation2_Show1
	{
		get
		{
			if (_oation2_1 != null)
			{
				return _oation2_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation2_Show1 != value && _oation2_1 != null)
			{
				_oation2_1.SetObjectActive(value);
			}
		}
	}

	public bool ation2_Show2
	{
		get
		{
			if (_oation2_2 != null)
			{
				return _oation2_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation2_Show2 != value && _oation2_2 != null)
			{
				_oation2_2.SetObjectActive(value);
			}
		}
	}

	public bool ation2_Show3
	{
		get
		{
			if (_oation2_3 != null)
			{
				return _oation2_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ation2_Show3 != value && _oation2_3 != null)
			{
				_oation2_3.SetObjectActive(value);
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
			case "box1":
				_obox1 = transform.gameObject;
				break;
			case "box2":
				_obox2 = transform.gameObject;
				break;
			case "progress1":
				_oprogress1 = transform.gameObject;
				_oprogressText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "progress2":
				_oprogress2 = transform.gameObject;
				_oprogressText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ation1_1":
				_oation1_1 = transform.gameObject;
				break;
			case "ation1_2":
				_oation1_2 = transform.gameObject;
				break;
			case "ation1_3":
				_oation1_3 = transform.gameObject;
				break;
			case "ation2_1":
				_oation2_1 = transform.gameObject;
				break;
			case "ation2_2":
				_oation2_2 = transform.gameObject;
				break;
			case "ation2_3":
				_oation2_3 = transform.gameObject;
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

	public bool GetboxShow(int index)
	{
		return index switch
		{
			1 => boxShow1, 
			2 => boxShow2, 
			_ => false, 
		};
	}

	public void SetboxShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			boxShow1 = value;
			break;
		case 2:
			boxShow2 = value;
			break;
		}
	}

	public int GetboxCount()
	{
		return 2;
	}

	public string GetprogressString(int index)
	{
		return index switch
		{
			1 => progressString1, 
			2 => progressString2, 
			_ => null, 
		};
	}

	public void SetprogressString(int index, string value)
	{
		switch (index)
		{
		case 1:
			progressString1 = value;
			break;
		case 2:
			progressString2 = value;
			break;
		}
	}

	public int GetprogressCount()
	{
		return 2;
	}

	public bool Getation1_Show(int index)
	{
		return index switch
		{
			1 => ation1_Show1, 
			2 => ation1_Show2, 
			3 => ation1_Show3, 
			_ => false, 
		};
	}

	public void Setation1_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ation1_Show1 = value;
			break;
		case 2:
			ation1_Show2 = value;
			break;
		case 3:
			ation1_Show3 = value;
			break;
		}
	}

	public int Getation1_Count()
	{
		return 3;
	}

	public bool Getation2_Show(int index)
	{
		return index switch
		{
			1 => ation2_Show1, 
			2 => ation2_Show2, 
			3 => ation2_Show3, 
			_ => false, 
		};
	}

	public void Setation2_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ation2_Show1 = value;
			break;
		case 2:
			ation2_Show2 = value;
			break;
		case 3:
			ation2_Show3 = value;
			break;
		}
	}

	public int Getation2_Count()
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
