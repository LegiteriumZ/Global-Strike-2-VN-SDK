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
public class BioChemical_ZGoldViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _omoney;

	private Text _omoneyText;

	private GameObject _omoney_1;

	private GameObject _omoney_2;

	private GameObject _omoney_3;

	private GameObject _omoney_4;

	private GameObject _omoney_5;

	private GameObject _omoney_6;

	private GameObject _omoney_7;

	private GameObject _omoney_8;

	private Text _omoney_Text1;

	private Text _omoney_Text2;

	private Text _omoney_Text3;

	private Text _omoney_Text4;

	private Text _omoney_Text5;

	private Text _omoney_Text6;

	private Text _omoney_Text7;

	private Text _omoney_Text8;

	private CanvasGroup _omoney_CanvasGroup1;

	private CanvasGroup _omoney_CanvasGroup2;

	private CanvasGroup _omoney_CanvasGroup3;

	private CanvasGroup _omoney_CanvasGroup4;

	private CanvasGroup _omoney_CanvasGroup5;

	private CanvasGroup _omoney_CanvasGroup6;

	private CanvasGroup _omoney_CanvasGroup7;

	private CanvasGroup _omoney_CanvasGroup8;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zgold";

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

	public string moneyString
	{
		get
		{
			if (_omoneyText != null)
			{
				return _omoneyText.text;
			}
			return null;
		}
		set
		{
			if (moneyString != value && _omoneyText != null)
			{
				_omoneyText.text = value;
			}
		}
	}

	public GameObject money_Obj1 => _omoney_1;

	public GameObject money_Obj2 => _omoney_2;

	public GameObject money_Obj3 => _omoney_3;

	public GameObject money_Obj4 => _omoney_4;

	public GameObject money_Obj5 => _omoney_5;

	public GameObject money_Obj6 => _omoney_6;

	public GameObject money_Obj7 => _omoney_7;

	public GameObject money_Obj8 => _omoney_8;

	public bool money_Show1
	{
		get
		{
			if (_omoney_1 != null)
			{
				return _omoney_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show1 != value && _omoney_1 != null)
			{
				_omoney_1.SetObjectActive(value);
			}
		}
	}

	public bool money_Show2
	{
		get
		{
			if (_omoney_2 != null)
			{
				return _omoney_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show2 != value && _omoney_2 != null)
			{
				_omoney_2.SetObjectActive(value);
			}
		}
	}

	public bool money_Show3
	{
		get
		{
			if (_omoney_3 != null)
			{
				return _omoney_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show3 != value && _omoney_3 != null)
			{
				_omoney_3.SetObjectActive(value);
			}
		}
	}

	public bool money_Show4
	{
		get
		{
			if (_omoney_4 != null)
			{
				return _omoney_4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show4 != value && _omoney_4 != null)
			{
				_omoney_4.SetObjectActive(value);
			}
		}
	}

	public bool money_Show5
	{
		get
		{
			if (_omoney_5 != null)
			{
				return _omoney_5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show5 != value && _omoney_5 != null)
			{
				_omoney_5.SetObjectActive(value);
			}
		}
	}

	public bool money_Show6
	{
		get
		{
			if (_omoney_6 != null)
			{
				return _omoney_6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show6 != value && _omoney_6 != null)
			{
				_omoney_6.SetObjectActive(value);
			}
		}
	}

	public bool money_Show7
	{
		get
		{
			if (_omoney_7 != null)
			{
				return _omoney_7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show7 != value && _omoney_7 != null)
			{
				_omoney_7.SetObjectActive(value);
			}
		}
	}

	public bool money_Show8
	{
		get
		{
			if (_omoney_8 != null)
			{
				return _omoney_8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show8 != value && _omoney_8 != null)
			{
				_omoney_8.SetObjectActive(value);
			}
		}
	}

	public string money_String1
	{
		get
		{
			if (_omoney_Text1 != null)
			{
				return _omoney_Text1.text;
			}
			return null;
		}
		set
		{
			if (money_String1 != value && _omoney_Text1 != null)
			{
				_omoney_Text1.text = value;
			}
		}
	}

	public string money_String2
	{
		get
		{
			if (_omoney_Text2 != null)
			{
				return _omoney_Text2.text;
			}
			return null;
		}
		set
		{
			if (money_String2 != value && _omoney_Text2 != null)
			{
				_omoney_Text2.text = value;
			}
		}
	}

	public string money_String3
	{
		get
		{
			if (_omoney_Text3 != null)
			{
				return _omoney_Text3.text;
			}
			return null;
		}
		set
		{
			if (money_String3 != value && _omoney_Text3 != null)
			{
				_omoney_Text3.text = value;
			}
		}
	}

	public string money_String4
	{
		get
		{
			if (_omoney_Text4 != null)
			{
				return _omoney_Text4.text;
			}
			return null;
		}
		set
		{
			if (money_String4 != value && _omoney_Text4 != null)
			{
				_omoney_Text4.text = value;
			}
		}
	}

	public string money_String5
	{
		get
		{
			if (_omoney_Text5 != null)
			{
				return _omoney_Text5.text;
			}
			return null;
		}
		set
		{
			if (money_String5 != value && _omoney_Text5 != null)
			{
				_omoney_Text5.text = value;
			}
		}
	}

	public string money_String6
	{
		get
		{
			if (_omoney_Text6 != null)
			{
				return _omoney_Text6.text;
			}
			return null;
		}
		set
		{
			if (money_String6 != value && _omoney_Text6 != null)
			{
				_omoney_Text6.text = value;
			}
		}
	}

	public string money_String7
	{
		get
		{
			if (_omoney_Text7 != null)
			{
				return _omoney_Text7.text;
			}
			return null;
		}
		set
		{
			if (money_String7 != value && _omoney_Text7 != null)
			{
				_omoney_Text7.text = value;
			}
		}
	}

	public string money_String8
	{
		get
		{
			if (_omoney_Text8 != null)
			{
				return _omoney_Text8.text;
			}
			return null;
		}
		set
		{
			if (money_String8 != value && _omoney_Text8 != null)
			{
				_omoney_Text8.text = value;
			}
		}
	}

	public float money_Alpha1
	{
		get
		{
			if (_omoney_CanvasGroup1 != null)
			{
				return _omoney_CanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha1 != value && _omoney_CanvasGroup1 != null)
			{
				_omoney_CanvasGroup1.alpha = value;
			}
		}
	}

	public float money_Alpha2
	{
		get
		{
			if (_omoney_CanvasGroup2 != null)
			{
				return _omoney_CanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha2 != value && _omoney_CanvasGroup2 != null)
			{
				_omoney_CanvasGroup2.alpha = value;
			}
		}
	}

	public float money_Alpha3
	{
		get
		{
			if (_omoney_CanvasGroup3 != null)
			{
				return _omoney_CanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha3 != value && _omoney_CanvasGroup3 != null)
			{
				_omoney_CanvasGroup3.alpha = value;
			}
		}
	}

	public float money_Alpha4
	{
		get
		{
			if (_omoney_CanvasGroup4 != null)
			{
				return _omoney_CanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha4 != value && _omoney_CanvasGroup4 != null)
			{
				_omoney_CanvasGroup4.alpha = value;
			}
		}
	}

	public float money_Alpha5
	{
		get
		{
			if (_omoney_CanvasGroup5 != null)
			{
				return _omoney_CanvasGroup5.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha5 != value && _omoney_CanvasGroup5 != null)
			{
				_omoney_CanvasGroup5.alpha = value;
			}
		}
	}

	public float money_Alpha6
	{
		get
		{
			if (_omoney_CanvasGroup6 != null)
			{
				return _omoney_CanvasGroup6.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha6 != value && _omoney_CanvasGroup6 != null)
			{
				_omoney_CanvasGroup6.alpha = value;
			}
		}
	}

	public float money_Alpha7
	{
		get
		{
			if (_omoney_CanvasGroup7 != null)
			{
				return _omoney_CanvasGroup7.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha7 != value && _omoney_CanvasGroup7 != null)
			{
				_omoney_CanvasGroup7.alpha = value;
			}
		}
	}

	public float money_Alpha8
	{
		get
		{
			if (_omoney_CanvasGroup8 != null)
			{
				return _omoney_CanvasGroup8.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha8 != value && _omoney_CanvasGroup8 != null)
			{
				_omoney_CanvasGroup8.alpha = value;
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
			case "money":
				_omoney = transform.gameObject;
				_omoneyText = transform.gameObject.GetComponent<Text>();
				break;
			case "money_1":
				_omoney_1 = transform.gameObject;
				_omoney_Text1 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_2":
				_omoney_2 = transform.gameObject;
				_omoney_Text2 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_3":
				_omoney_3 = transform.gameObject;
				_omoney_Text3 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_4":
				_omoney_4 = transform.gameObject;
				_omoney_Text4 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_5":
				_omoney_5 = transform.gameObject;
				_omoney_Text5 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup5 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_6":
				_omoney_6 = transform.gameObject;
				_omoney_Text6 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup6 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_7":
				_omoney_7 = transform.gameObject;
				_omoney_Text7 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup7 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_8":
				_omoney_8 = transform.gameObject;
				_omoney_Text8 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup8 = transform.gameObject.GetComponent<CanvasGroup>();
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

	public GameObject Getmoney_Obj(int index)
	{
		return index switch
		{
			1 => money_Obj1, 
			2 => money_Obj2, 
			3 => money_Obj3, 
			4 => money_Obj4, 
			5 => money_Obj5, 
			6 => money_Obj6, 
			7 => money_Obj7, 
			8 => money_Obj8, 
			_ => null, 
		};
	}

	public int Getmoney_Count()
	{
		return 8;
	}

	public bool Getmoney_Show(int index)
	{
		return index switch
		{
			1 => money_Show1, 
			2 => money_Show2, 
			3 => money_Show3, 
			4 => money_Show4, 
			5 => money_Show5, 
			6 => money_Show6, 
			7 => money_Show7, 
			8 => money_Show8, 
			_ => false, 
		};
	}

	public void Setmoney_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			money_Show1 = value;
			break;
		case 2:
			money_Show2 = value;
			break;
		case 3:
			money_Show3 = value;
			break;
		case 4:
			money_Show4 = value;
			break;
		case 5:
			money_Show5 = value;
			break;
		case 6:
			money_Show6 = value;
			break;
		case 7:
			money_Show7 = value;
			break;
		case 8:
			money_Show8 = value;
			break;
		}
	}

	public string Getmoney_String(int index)
	{
		return index switch
		{
			1 => money_String1, 
			2 => money_String2, 
			3 => money_String3, 
			4 => money_String4, 
			5 => money_String5, 
			6 => money_String6, 
			7 => money_String7, 
			8 => money_String8, 
			_ => null, 
		};
	}

	public void Setmoney_String(int index, string value)
	{
		switch (index)
		{
		case 1:
			money_String1 = value;
			break;
		case 2:
			money_String2 = value;
			break;
		case 3:
			money_String3 = value;
			break;
		case 4:
			money_String4 = value;
			break;
		case 5:
			money_String5 = value;
			break;
		case 6:
			money_String6 = value;
			break;
		case 7:
			money_String7 = value;
			break;
		case 8:
			money_String8 = value;
			break;
		}
	}

	public float Getmoney_Alpha(int index)
	{
		return index switch
		{
			1 => money_Alpha1, 
			2 => money_Alpha2, 
			3 => money_Alpha3, 
			4 => money_Alpha4, 
			5 => money_Alpha5, 
			6 => money_Alpha6, 
			7 => money_Alpha7, 
			8 => money_Alpha8, 
			_ => 0f, 
		};
	}

	public void Setmoney_Alpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			money_Alpha1 = value;
			break;
		case 2:
			money_Alpha2 = value;
			break;
		case 3:
			money_Alpha3 = value;
			break;
		case 4:
			money_Alpha4 = value;
			break;
		case 5:
			money_Alpha5 = value;
			break;
		case 6:
			money_Alpha6 = value;
			break;
		case 7:
			money_Alpha7 = value;
			break;
		case 8:
			money_Alpha8 = value;
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
