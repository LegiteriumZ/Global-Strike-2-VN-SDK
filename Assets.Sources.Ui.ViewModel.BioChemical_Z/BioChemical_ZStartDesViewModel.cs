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
public class BioChemical_ZStartDesViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oT_show;

	private GameObject _oprogress;

	private Image _oprogressImage;

	private GameObject _oTimer1;

	private GameObject _oTimer2;

	private Image _oTimerImage1;

	private Image _oTimerImage2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zstartdes";

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

	public bool T_showShow
	{
		get
		{
			if (_oT_show != null)
			{
				return _oT_show.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (T_showShow != value && _oT_show != null)
			{
				_oT_show.SetObjectActive(value);
			}
		}
	}

	public float progressFillamount
	{
		get
		{
			if (_oprogressImage != null)
			{
				return _oprogressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (progressFillamount != value && _oprogressImage != null)
			{
				_oprogressImage.fillAmount = value;
			}
		}
	}

	public bool TimerShow1
	{
		get
		{
			if (_oTimer1 != null)
			{
				return _oTimer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimerShow1 != value && _oTimer1 != null)
			{
				_oTimer1.SetObjectActive(value);
			}
		}
	}

	public bool TimerShow2
	{
		get
		{
			if (_oTimer2 != null)
			{
				return _oTimer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimerShow2 != value && _oTimer2 != null)
			{
				_oTimer2.SetObjectActive(value);
			}
		}
	}

	public Sprite TimerSprite1
	{
		get
		{
			if (_oTimerImage1 != null)
			{
				return _oTimerImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TimerSprite1 != value && _oTimerImage1 != null)
			{
				_oTimerImage1.sprite = value;
			}
		}
	}

	public Sprite TimerSprite2
	{
		get
		{
			if (_oTimerImage2 != null)
			{
				return _oTimerImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TimerSprite2 != value && _oTimerImage2 != null)
			{
				_oTimerImage2.sprite = value;
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
			case "T_show":
				_oT_show = transform.gameObject;
				break;
			case "progress":
				_oprogress = transform.gameObject;
				_oprogressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Timer1":
				_oTimer1 = transform.gameObject;
				_oTimerImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Timer2":
				_oTimer2 = transform.gameObject;
				_oTimerImage2 = transform.gameObject.GetComponent<Image>();
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

	public bool GetTimerShow(int index)
	{
		return index switch
		{
			1 => TimerShow1, 
			2 => TimerShow2, 
			_ => false, 
		};
	}

	public void SetTimerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TimerShow1 = value;
			break;
		case 2:
			TimerShow2 = value;
			break;
		}
	}

	public int GetTimerCount()
	{
		return 2;
	}

	public Sprite GetTimerSprite(int index)
	{
		return index switch
		{
			1 => TimerSprite1, 
			2 => TimerSprite2, 
			_ => null, 
		};
	}

	public void SetTimerSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TimerSprite1 = value;
			break;
		case 2:
			TimerSprite2 = value;
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
