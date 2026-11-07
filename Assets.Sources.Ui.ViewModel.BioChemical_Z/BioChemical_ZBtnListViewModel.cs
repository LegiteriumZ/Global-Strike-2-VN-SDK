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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZBtnListViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _obtnIcon1;

	private GameObject _obtnIcon2;

	private GameObject _obtnIcon3;

	private GameObject _obtnIcon4;

	private GameObject _obtnIcon5;

	private GameObject _oSkillCount;

	private Text _oSkillCountText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zbtnlist";

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

	public bool btnIconShow1
	{
		get
		{
			if (_obtnIcon1 != null)
			{
				return _obtnIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow1 != value && _obtnIcon1 != null)
			{
				_obtnIcon1.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow2
	{
		get
		{
			if (_obtnIcon2 != null)
			{
				return _obtnIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow2 != value && _obtnIcon2 != null)
			{
				_obtnIcon2.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow3
	{
		get
		{
			if (_obtnIcon3 != null)
			{
				return _obtnIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow3 != value && _obtnIcon3 != null)
			{
				_obtnIcon3.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow4
	{
		get
		{
			if (_obtnIcon4 != null)
			{
				return _obtnIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow4 != value && _obtnIcon4 != null)
			{
				_obtnIcon4.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow5
	{
		get
		{
			if (_obtnIcon5 != null)
			{
				return _obtnIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow5 != value && _obtnIcon5 != null)
			{
				_obtnIcon5.SetObjectActive(value);
			}
		}
	}

	public string SkillCountString
	{
		get
		{
			if (_oSkillCountText != null)
			{
				return _oSkillCountText.text;
			}
			return null;
		}
		set
		{
			if (SkillCountString != value && _oSkillCountText != null)
			{
				_oSkillCountText.text = value;
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
			case "btnIcon1":
				_obtnIcon1 = transform.gameObject;
				break;
			case "btnIcon2":
				_obtnIcon2 = transform.gameObject;
				break;
			case "btnIcon3":
				_obtnIcon3 = transform.gameObject;
				break;
			case "btnIcon4":
				_obtnIcon4 = transform.gameObject;
				break;
			case "btnIcon5":
				_obtnIcon5 = transform.gameObject;
				break;
			case "SkillCount":
				_oSkillCount = transform.gameObject;
				_oSkillCountText = transform.gameObject.GetComponent<Text>();
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

	public bool GetbtnIconShow(int index)
	{
		return index switch
		{
			1 => btnIconShow1, 
			2 => btnIconShow2, 
			3 => btnIconShow3, 
			4 => btnIconShow4, 
			5 => btnIconShow5, 
			_ => false, 
		};
	}

	public void SetbtnIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			btnIconShow1 = value;
			break;
		case 2:
			btnIconShow2 = value;
			break;
		case 3:
			btnIconShow3 = value;
			break;
		case 4:
			btnIconShow4 = value;
			break;
		case 5:
			btnIconShow5 = value;
			break;
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
