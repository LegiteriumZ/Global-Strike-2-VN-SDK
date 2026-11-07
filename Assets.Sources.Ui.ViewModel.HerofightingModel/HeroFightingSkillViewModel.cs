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

namespace Assets.Sources.Ui.ViewModel.HerofightingModel;

[GameUiTest]
public class HeroFightingSkillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oskilli1;

	private GameObject _oskilli2;

	private GameObject _oskilli3;

	private Image _oskilliImage1;

	private Image _oskilliImage2;

	private Image _oskilliImage3;

	private GameObject _oskillp1;

	private GameObject _oskillp2;

	private GameObject _oskillp3;

	private Image _oskillpImage1;

	private Image _oskillpImage2;

	private Image _oskillpImage3;

	private GameObject _oskillk1;

	private GameObject _oskillk2;

	private GameObject _oskillk3;

	private Image _oskillkImage1;

	private Image _oskillkImage2;

	private Image _oskillkImage3;

	private GameObject _oTimer;

	private GameObject _otimep;

	private Image _otimepImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/herofightingmodel";

	private string _resourceAssetName = "herofightingskill";

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

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool skilliShow1
	{
		get
		{
			if (_oskilli1 != null)
			{
				return _oskilli1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliShow1 != value && _oskilli1 != null)
			{
				_oskilli1.SetObjectActive(value);
			}
		}
	}

	public bool skilliShow2
	{
		get
		{
			if (_oskilli2 != null)
			{
				return _oskilli2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliShow2 != value && _oskilli2 != null)
			{
				_oskilli2.SetObjectActive(value);
			}
		}
	}

	public bool skilliShow3
	{
		get
		{
			if (_oskilli3 != null)
			{
				return _oskilli3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliShow3 != value && _oskilli3 != null)
			{
				_oskilli3.SetObjectActive(value);
			}
		}
	}

	public Sprite skilliSprite1
	{
		get
		{
			if (_oskilliImage1 != null)
			{
				return _oskilliImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skilliSprite1 != value && _oskilliImage1 != null)
			{
				_oskilliImage1.sprite = value;
			}
		}
	}

	public Sprite skilliSprite2
	{
		get
		{
			if (_oskilliImage2 != null)
			{
				return _oskilliImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skilliSprite2 != value && _oskilliImage2 != null)
			{
				_oskilliImage2.sprite = value;
			}
		}
	}

	public Sprite skilliSprite3
	{
		get
		{
			if (_oskilliImage3 != null)
			{
				return _oskilliImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skilliSprite3 != value && _oskilliImage3 != null)
			{
				_oskilliImage3.sprite = value;
			}
		}
	}

	public float skillpFillamount1
	{
		get
		{
			if (_oskillpImage1 != null)
			{
				return _oskillpImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (skillpFillamount1 != value && _oskillpImage1 != null)
			{
				_oskillpImage1.fillAmount = value;
			}
		}
	}

	public float skillpFillamount2
	{
		get
		{
			if (_oskillpImage2 != null)
			{
				return _oskillpImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (skillpFillamount2 != value && _oskillpImage2 != null)
			{
				_oskillpImage2.fillAmount = value;
			}
		}
	}

	public float skillpFillamount3
	{
		get
		{
			if (_oskillpImage3 != null)
			{
				return _oskillpImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (skillpFillamount3 != value && _oskillpImage3 != null)
			{
				_oskillpImage3.fillAmount = value;
			}
		}
	}

	public Sprite skillkSprite1
	{
		get
		{
			if (_oskillkImage1 != null)
			{
				return _oskillkImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillkSprite1 != value && _oskillkImage1 != null)
			{
				_oskillkImage1.sprite = value;
			}
		}
	}

	public Sprite skillkSprite2
	{
		get
		{
			if (_oskillkImage2 != null)
			{
				return _oskillkImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillkSprite2 != value && _oskillkImage2 != null)
			{
				_oskillkImage2.sprite = value;
			}
		}
	}

	public Sprite skillkSprite3
	{
		get
		{
			if (_oskillkImage3 != null)
			{
				return _oskillkImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillkSprite3 != value && _oskillkImage3 != null)
			{
				_oskillkImage3.sprite = value;
			}
		}
	}

	public bool TimerShow
	{
		get
		{
			if (_oTimer != null)
			{
				return _oTimer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimerShow != value && _oTimer != null)
			{
				_oTimer.SetObjectActive(value);
			}
		}
	}

	public float timepFillamount
	{
		get
		{
			if (_otimepImage != null)
			{
				return _otimepImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (timepFillamount != value && _otimepImage != null)
			{
				_otimepImage.fillAmount = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "skilli1":
				_oskilli1 = transform.gameObject;
				_oskilliImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skilli2":
				_oskilli2 = transform.gameObject;
				_oskilliImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "skilli3":
				_oskilli3 = transform.gameObject;
				_oskilliImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillp1":
				_oskillp1 = transform.gameObject;
				_oskillpImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillp2":
				_oskillp2 = transform.gameObject;
				_oskillpImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillp3":
				_oskillp3 = transform.gameObject;
				_oskillpImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillk1":
				_oskillk1 = transform.gameObject;
				_oskillkImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillk2":
				_oskillk2 = transform.gameObject;
				_oskillkImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillk3":
				_oskillk3 = transform.gameObject;
				_oskillkImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Timer":
				_oTimer = transform.gameObject;
				break;
			case "timep":
				_otimep = transform.gameObject;
				_otimepImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetskilliShow(int index)
	{
		return index switch
		{
			1 => skilliShow1, 
			2 => skilliShow2, 
			3 => skilliShow3, 
			_ => false, 
		};
	}

	public void SetskilliShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skilliShow1 = value;
			break;
		case 2:
			skilliShow2 = value;
			break;
		case 3:
			skilliShow3 = value;
			break;
		}
	}

	public int GetskilliCount()
	{
		return 3;
	}

	public Sprite GetskilliSprite(int index)
	{
		return index switch
		{
			1 => skilliSprite1, 
			2 => skilliSprite2, 
			3 => skilliSprite3, 
			_ => null, 
		};
	}

	public void SetskilliSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skilliSprite1 = value;
			break;
		case 2:
			skilliSprite2 = value;
			break;
		case 3:
			skilliSprite3 = value;
			break;
		}
	}

	public float GetskillpFillamount(int index)
	{
		return index switch
		{
			1 => skillpFillamount1, 
			2 => skillpFillamount2, 
			3 => skillpFillamount3, 
			_ => 0f, 
		};
	}

	public void SetskillpFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			skillpFillamount1 = value;
			break;
		case 2:
			skillpFillamount2 = value;
			break;
		case 3:
			skillpFillamount3 = value;
			break;
		}
	}

	public int GetskillpCount()
	{
		return 3;
	}

	public Sprite GetskillkSprite(int index)
	{
		return index switch
		{
			1 => skillkSprite1, 
			2 => skillkSprite2, 
			3 => skillkSprite3, 
			_ => null, 
		};
	}

	public void SetskillkSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillkSprite1 = value;
			break;
		case 2:
			skillkSprite2 = value;
			break;
		case 3:
			skillkSprite3 = value;
			break;
		}
	}

	public int GetskillkCount()
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
