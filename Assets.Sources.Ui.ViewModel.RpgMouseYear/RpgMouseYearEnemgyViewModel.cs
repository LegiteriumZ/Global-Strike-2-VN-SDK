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

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearEnemgyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oUp;

	private Image _oUpImage;

	private GameObject _oLvDown1;

	private GameObject _oLvDown2;

	private GameObject _oLvDown3;

	private GameObject _oLvDown4;

	private GameObject _oLvUp1;

	private GameObject _oLvUp2;

	private GameObject _oLvUp3;

	private GameObject _oLvUp4;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearEnemgy";

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

	public float UpFillamount
	{
		get
		{
			if (_oUpImage != null)
			{
				return _oUpImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (UpFillamount != value && _oUpImage != null)
			{
				_oUpImage.fillAmount = value;
			}
		}
	}

	public bool LvDownShow1
	{
		get
		{
			if (_oLvDown1 != null)
			{
				return _oLvDown1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvDownShow1 != value && _oLvDown1 != null)
			{
				_oLvDown1.SetObjectActive(value);
			}
		}
	}

	public bool LvDownShow2
	{
		get
		{
			if (_oLvDown2 != null)
			{
				return _oLvDown2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvDownShow2 != value && _oLvDown2 != null)
			{
				_oLvDown2.SetObjectActive(value);
			}
		}
	}

	public bool LvDownShow3
	{
		get
		{
			if (_oLvDown3 != null)
			{
				return _oLvDown3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvDownShow3 != value && _oLvDown3 != null)
			{
				_oLvDown3.SetObjectActive(value);
			}
		}
	}

	public bool LvDownShow4
	{
		get
		{
			if (_oLvDown4 != null)
			{
				return _oLvDown4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvDownShow4 != value && _oLvDown4 != null)
			{
				_oLvDown4.SetObjectActive(value);
			}
		}
	}

	public bool LvUpShow1
	{
		get
		{
			if (_oLvUp1 != null)
			{
				return _oLvUp1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvUpShow1 != value && _oLvUp1 != null)
			{
				_oLvUp1.SetObjectActive(value);
			}
		}
	}

	public bool LvUpShow2
	{
		get
		{
			if (_oLvUp2 != null)
			{
				return _oLvUp2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvUpShow2 != value && _oLvUp2 != null)
			{
				_oLvUp2.SetObjectActive(value);
			}
		}
	}

	public bool LvUpShow3
	{
		get
		{
			if (_oLvUp3 != null)
			{
				return _oLvUp3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvUpShow3 != value && _oLvUp3 != null)
			{
				_oLvUp3.SetObjectActive(value);
			}
		}
	}

	public bool LvUpShow4
	{
		get
		{
			if (_oLvUp4 != null)
			{
				return _oLvUp4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvUpShow4 != value && _oLvUp4 != null)
			{
				_oLvUp4.SetObjectActive(value);
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
			case "Up":
				_oUp = transform.gameObject;
				_oUpImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LvDown1":
				_oLvDown1 = transform.gameObject;
				break;
			case "LvDown2":
				_oLvDown2 = transform.gameObject;
				break;
			case "LvDown3":
				_oLvDown3 = transform.gameObject;
				break;
			case "LvDown4":
				_oLvDown4 = transform.gameObject;
				break;
			case "LvUp1":
				_oLvUp1 = transform.gameObject;
				break;
			case "LvUp2":
				_oLvUp2 = transform.gameObject;
				break;
			case "LvUp3":
				_oLvUp3 = transform.gameObject;
				break;
			case "LvUp4":
				_oLvUp4 = transform.gameObject;
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

	public bool GetLvDownShow(int index)
	{
		return index switch
		{
			1 => LvDownShow1, 
			2 => LvDownShow2, 
			3 => LvDownShow3, 
			4 => LvDownShow4, 
			_ => false, 
		};
	}

	public void SetLvDownShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LvDownShow1 = value;
			break;
		case 2:
			LvDownShow2 = value;
			break;
		case 3:
			LvDownShow3 = value;
			break;
		case 4:
			LvDownShow4 = value;
			break;
		}
	}

	public bool GetLvUpShow(int index)
	{
		return index switch
		{
			1 => LvUpShow1, 
			2 => LvUpShow2, 
			3 => LvUpShow3, 
			4 => LvUpShow4, 
			_ => false, 
		};
	}

	public void SetLvUpShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LvUpShow1 = value;
			break;
		case 2:
			LvUpShow2 = value;
			break;
		case 3:
			LvUpShow3 = value;
			break;
		case 4:
			LvUpShow4 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
