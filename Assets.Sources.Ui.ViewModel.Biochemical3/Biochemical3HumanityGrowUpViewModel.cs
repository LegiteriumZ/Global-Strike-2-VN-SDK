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

namespace Assets.Sources.Ui.ViewModel.Biochemical3;

[GameUiTest]
public class Biochemical3HumanityGrowUpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oLevel1;

	private GameObject _oLevel2;

	private GameObject _oLevel3;

	private GameObject _oLevel4;

	private GameObject _oLevel5;

	private GameObject _oLevel6;

	private GameObject _oLevel7;

	private GameObject _oLevel8;

	private GameObject _oLevel9;

	private GameObject _oLevel10;

	private GameObject _oAddAttack;

	private Text _oAddAttackText;

	private GameObject _oHeroChange;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3HumanityGrowUp";

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

	public bool LevelShow1
	{
		get
		{
			if (_oLevel1 != null)
			{
				return _oLevel1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow1 != value && _oLevel1 != null)
			{
				_oLevel1.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow2
	{
		get
		{
			if (_oLevel2 != null)
			{
				return _oLevel2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow2 != value && _oLevel2 != null)
			{
				_oLevel2.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow3
	{
		get
		{
			if (_oLevel3 != null)
			{
				return _oLevel3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow3 != value && _oLevel3 != null)
			{
				_oLevel3.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow4
	{
		get
		{
			if (_oLevel4 != null)
			{
				return _oLevel4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow4 != value && _oLevel4 != null)
			{
				_oLevel4.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow5
	{
		get
		{
			if (_oLevel5 != null)
			{
				return _oLevel5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow5 != value && _oLevel5 != null)
			{
				_oLevel5.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow6
	{
		get
		{
			if (_oLevel6 != null)
			{
				return _oLevel6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow6 != value && _oLevel6 != null)
			{
				_oLevel6.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow7
	{
		get
		{
			if (_oLevel7 != null)
			{
				return _oLevel7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow7 != value && _oLevel7 != null)
			{
				_oLevel7.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow8
	{
		get
		{
			if (_oLevel8 != null)
			{
				return _oLevel8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow8 != value && _oLevel8 != null)
			{
				_oLevel8.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow9
	{
		get
		{
			if (_oLevel9 != null)
			{
				return _oLevel9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow9 != value && _oLevel9 != null)
			{
				_oLevel9.SetObjectActive(value);
			}
		}
	}

	public bool LevelShow10
	{
		get
		{
			if (_oLevel10 != null)
			{
				return _oLevel10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelShow10 != value && _oLevel10 != null)
			{
				_oLevel10.SetObjectActive(value);
			}
		}
	}

	public string AddAttackString
	{
		get
		{
			if (_oAddAttackText != null)
			{
				return _oAddAttackText.text;
			}
			return null;
		}
		set
		{
			if (AddAttackString != value && _oAddAttackText != null)
			{
				_oAddAttackText.text = value;
			}
		}
	}

	public bool HeroChangeShow
	{
		get
		{
			if (_oHeroChange != null)
			{
				return _oHeroChange.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeroChangeShow != value && _oHeroChange != null)
			{
				_oHeroChange.SetObjectActive(value);
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
			case "Level1":
				_oLevel1 = transform.gameObject;
				break;
			case "Level2":
				_oLevel2 = transform.gameObject;
				break;
			case "Level3":
				_oLevel3 = transform.gameObject;
				break;
			case "Level4":
				_oLevel4 = transform.gameObject;
				break;
			case "Level5":
				_oLevel5 = transform.gameObject;
				break;
			case "Level6":
				_oLevel6 = transform.gameObject;
				break;
			case "Level7":
				_oLevel7 = transform.gameObject;
				break;
			case "Level8":
				_oLevel8 = transform.gameObject;
				break;
			case "Level9":
				_oLevel9 = transform.gameObject;
				break;
			case "Level10":
				_oLevel10 = transform.gameObject;
				break;
			case "AddAttack":
				_oAddAttack = transform.gameObject;
				_oAddAttackText = transform.gameObject.GetComponent<Text>();
				break;
			case "HeroChange":
				_oHeroChange = transform.gameObject;
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

	public bool GetLevelShow(int index)
	{
		return index switch
		{
			1 => LevelShow1, 
			2 => LevelShow2, 
			3 => LevelShow3, 
			4 => LevelShow4, 
			5 => LevelShow5, 
			6 => LevelShow6, 
			7 => LevelShow7, 
			8 => LevelShow8, 
			9 => LevelShow9, 
			10 => LevelShow10, 
			_ => false, 
		};
	}

	public void SetLevelShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LevelShow1 = value;
			break;
		case 2:
			LevelShow2 = value;
			break;
		case 3:
			LevelShow3 = value;
			break;
		case 4:
			LevelShow4 = value;
			break;
		case 5:
			LevelShow5 = value;
			break;
		case 6:
			LevelShow6 = value;
			break;
		case 7:
			LevelShow7 = value;
			break;
		case 8:
			LevelShow8 = value;
			break;
		case 9:
			LevelShow9 = value;
			break;
		case 10:
			LevelShow10 = value;
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
