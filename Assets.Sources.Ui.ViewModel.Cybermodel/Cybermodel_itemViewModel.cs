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

namespace Assets.Sources.Ui.ViewModel.Cybermodel;

[GameUiTest]
public class Cybermodel_itemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oitem1;

	private GameObject _oitem2;

	private GameObject _oitem3;

	private GameObject _oitem4;

	private GameObject _oitem5;

	private GameObject _oitem6;

	private GameObject _oitem7;

	private GameObject _oitem8;

	private GameObject _oitem9;

	private GameObject _oitem10;

	private GameObject _oitem11;

	private GameObject _oitem12;

	private GameObject _oitem13;

	private GameObject _oitem14;

	private GameObject _oitem15;

	private GameObject _oitem16;

	private GameObject _oitem17;

	private GameObject _oitem18;

	private GameObject _oitem19;

	private GameObject _oitem20;

	private Text _oitemText1;

	private Text _oitemText2;

	private Text _oitemText3;

	private Text _oitemText4;

	private Text _oitemText5;

	private Text _oitemText6;

	private Text _oitemText7;

	private Text _oitemText8;

	private Text _oitemText9;

	private Text _oitemText10;

	private Text _oitemText11;

	private Text _oitemText12;

	private Text _oitemText13;

	private Text _oitemText14;

	private Text _oitemText15;

	private Text _oitemText16;

	private Text _oitemText17;

	private Text _oitemText18;

	private Text _oitemText19;

	private Text _oitemText20;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/cybermodel";

	private string _resourceAssetName = "cybermodel_item";

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

	public bool itemShow1
	{
		get
		{
			if (_oitem1 != null)
			{
				return _oitem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow1 != value && _oitem1 != null)
			{
				_oitem1.SetObjectActive(value);
			}
		}
	}

	public bool itemShow2
	{
		get
		{
			if (_oitem2 != null)
			{
				return _oitem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow2 != value && _oitem2 != null)
			{
				_oitem2.SetObjectActive(value);
			}
		}
	}

	public bool itemShow3
	{
		get
		{
			if (_oitem3 != null)
			{
				return _oitem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow3 != value && _oitem3 != null)
			{
				_oitem3.SetObjectActive(value);
			}
		}
	}

	public bool itemShow4
	{
		get
		{
			if (_oitem4 != null)
			{
				return _oitem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow4 != value && _oitem4 != null)
			{
				_oitem4.SetObjectActive(value);
			}
		}
	}

	public bool itemShow5
	{
		get
		{
			if (_oitem5 != null)
			{
				return _oitem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow5 != value && _oitem5 != null)
			{
				_oitem5.SetObjectActive(value);
			}
		}
	}

	public bool itemShow6
	{
		get
		{
			if (_oitem6 != null)
			{
				return _oitem6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow6 != value && _oitem6 != null)
			{
				_oitem6.SetObjectActive(value);
			}
		}
	}

	public bool itemShow7
	{
		get
		{
			if (_oitem7 != null)
			{
				return _oitem7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow7 != value && _oitem7 != null)
			{
				_oitem7.SetObjectActive(value);
			}
		}
	}

	public bool itemShow8
	{
		get
		{
			if (_oitem8 != null)
			{
				return _oitem8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow8 != value && _oitem8 != null)
			{
				_oitem8.SetObjectActive(value);
			}
		}
	}

	public bool itemShow9
	{
		get
		{
			if (_oitem9 != null)
			{
				return _oitem9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow9 != value && _oitem9 != null)
			{
				_oitem9.SetObjectActive(value);
			}
		}
	}

	public bool itemShow10
	{
		get
		{
			if (_oitem10 != null)
			{
				return _oitem10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow10 != value && _oitem10 != null)
			{
				_oitem10.SetObjectActive(value);
			}
		}
	}

	public bool itemShow11
	{
		get
		{
			if (_oitem11 != null)
			{
				return _oitem11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow11 != value && _oitem11 != null)
			{
				_oitem11.SetObjectActive(value);
			}
		}
	}

	public bool itemShow12
	{
		get
		{
			if (_oitem12 != null)
			{
				return _oitem12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow12 != value && _oitem12 != null)
			{
				_oitem12.SetObjectActive(value);
			}
		}
	}

	public bool itemShow13
	{
		get
		{
			if (_oitem13 != null)
			{
				return _oitem13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow13 != value && _oitem13 != null)
			{
				_oitem13.SetObjectActive(value);
			}
		}
	}

	public bool itemShow14
	{
		get
		{
			if (_oitem14 != null)
			{
				return _oitem14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow14 != value && _oitem14 != null)
			{
				_oitem14.SetObjectActive(value);
			}
		}
	}

	public bool itemShow15
	{
		get
		{
			if (_oitem15 != null)
			{
				return _oitem15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow15 != value && _oitem15 != null)
			{
				_oitem15.SetObjectActive(value);
			}
		}
	}

	public bool itemShow16
	{
		get
		{
			if (_oitem16 != null)
			{
				return _oitem16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow16 != value && _oitem16 != null)
			{
				_oitem16.SetObjectActive(value);
			}
		}
	}

	public bool itemShow17
	{
		get
		{
			if (_oitem17 != null)
			{
				return _oitem17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow17 != value && _oitem17 != null)
			{
				_oitem17.SetObjectActive(value);
			}
		}
	}

	public bool itemShow18
	{
		get
		{
			if (_oitem18 != null)
			{
				return _oitem18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow18 != value && _oitem18 != null)
			{
				_oitem18.SetObjectActive(value);
			}
		}
	}

	public bool itemShow19
	{
		get
		{
			if (_oitem19 != null)
			{
				return _oitem19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow19 != value && _oitem19 != null)
			{
				_oitem19.SetObjectActive(value);
			}
		}
	}

	public bool itemShow20
	{
		get
		{
			if (_oitem20 != null)
			{
				return _oitem20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (itemShow20 != value && _oitem20 != null)
			{
				_oitem20.SetObjectActive(value);
			}
		}
	}

	public string itemString1
	{
		get
		{
			if (_oitemText1 != null)
			{
				return _oitemText1.text;
			}
			return null;
		}
		set
		{
			if (itemString1 != value && _oitemText1 != null)
			{
				_oitemText1.text = value;
			}
		}
	}

	public string itemString2
	{
		get
		{
			if (_oitemText2 != null)
			{
				return _oitemText2.text;
			}
			return null;
		}
		set
		{
			if (itemString2 != value && _oitemText2 != null)
			{
				_oitemText2.text = value;
			}
		}
	}

	public string itemString3
	{
		get
		{
			if (_oitemText3 != null)
			{
				return _oitemText3.text;
			}
			return null;
		}
		set
		{
			if (itemString3 != value && _oitemText3 != null)
			{
				_oitemText3.text = value;
			}
		}
	}

	public string itemString4
	{
		get
		{
			if (_oitemText4 != null)
			{
				return _oitemText4.text;
			}
			return null;
		}
		set
		{
			if (itemString4 != value && _oitemText4 != null)
			{
				_oitemText4.text = value;
			}
		}
	}

	public string itemString5
	{
		get
		{
			if (_oitemText5 != null)
			{
				return _oitemText5.text;
			}
			return null;
		}
		set
		{
			if (itemString5 != value && _oitemText5 != null)
			{
				_oitemText5.text = value;
			}
		}
	}

	public string itemString6
	{
		get
		{
			if (_oitemText6 != null)
			{
				return _oitemText6.text;
			}
			return null;
		}
		set
		{
			if (itemString6 != value && _oitemText6 != null)
			{
				_oitemText6.text = value;
			}
		}
	}

	public string itemString7
	{
		get
		{
			if (_oitemText7 != null)
			{
				return _oitemText7.text;
			}
			return null;
		}
		set
		{
			if (itemString7 != value && _oitemText7 != null)
			{
				_oitemText7.text = value;
			}
		}
	}

	public string itemString8
	{
		get
		{
			if (_oitemText8 != null)
			{
				return _oitemText8.text;
			}
			return null;
		}
		set
		{
			if (itemString8 != value && _oitemText8 != null)
			{
				_oitemText8.text = value;
			}
		}
	}

	public string itemString9
	{
		get
		{
			if (_oitemText9 != null)
			{
				return _oitemText9.text;
			}
			return null;
		}
		set
		{
			if (itemString9 != value && _oitemText9 != null)
			{
				_oitemText9.text = value;
			}
		}
	}

	public string itemString10
	{
		get
		{
			if (_oitemText10 != null)
			{
				return _oitemText10.text;
			}
			return null;
		}
		set
		{
			if (itemString10 != value && _oitemText10 != null)
			{
				_oitemText10.text = value;
			}
		}
	}

	public string itemString11
	{
		get
		{
			if (_oitemText11 != null)
			{
				return _oitemText11.text;
			}
			return null;
		}
		set
		{
			if (itemString11 != value && _oitemText11 != null)
			{
				_oitemText11.text = value;
			}
		}
	}

	public string itemString12
	{
		get
		{
			if (_oitemText12 != null)
			{
				return _oitemText12.text;
			}
			return null;
		}
		set
		{
			if (itemString12 != value && _oitemText12 != null)
			{
				_oitemText12.text = value;
			}
		}
	}

	public string itemString13
	{
		get
		{
			if (_oitemText13 != null)
			{
				return _oitemText13.text;
			}
			return null;
		}
		set
		{
			if (itemString13 != value && _oitemText13 != null)
			{
				_oitemText13.text = value;
			}
		}
	}

	public string itemString14
	{
		get
		{
			if (_oitemText14 != null)
			{
				return _oitemText14.text;
			}
			return null;
		}
		set
		{
			if (itemString14 != value && _oitemText14 != null)
			{
				_oitemText14.text = value;
			}
		}
	}

	public string itemString15
	{
		get
		{
			if (_oitemText15 != null)
			{
				return _oitemText15.text;
			}
			return null;
		}
		set
		{
			if (itemString15 != value && _oitemText15 != null)
			{
				_oitemText15.text = value;
			}
		}
	}

	public string itemString16
	{
		get
		{
			if (_oitemText16 != null)
			{
				return _oitemText16.text;
			}
			return null;
		}
		set
		{
			if (itemString16 != value && _oitemText16 != null)
			{
				_oitemText16.text = value;
			}
		}
	}

	public string itemString17
	{
		get
		{
			if (_oitemText17 != null)
			{
				return _oitemText17.text;
			}
			return null;
		}
		set
		{
			if (itemString17 != value && _oitemText17 != null)
			{
				_oitemText17.text = value;
			}
		}
	}

	public string itemString18
	{
		get
		{
			if (_oitemText18 != null)
			{
				return _oitemText18.text;
			}
			return null;
		}
		set
		{
			if (itemString18 != value && _oitemText18 != null)
			{
				_oitemText18.text = value;
			}
		}
	}

	public string itemString19
	{
		get
		{
			if (_oitemText19 != null)
			{
				return _oitemText19.text;
			}
			return null;
		}
		set
		{
			if (itemString19 != value && _oitemText19 != null)
			{
				_oitemText19.text = value;
			}
		}
	}

	public string itemString20
	{
		get
		{
			if (_oitemText20 != null)
			{
				return _oitemText20.text;
			}
			return null;
		}
		set
		{
			if (itemString20 != value && _oitemText20 != null)
			{
				_oitemText20.text = value;
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
			case "item1":
				_oitem1 = transform.gameObject;
				_oitemText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "item2":
				_oitem2 = transform.gameObject;
				_oitemText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "item3":
				_oitem3 = transform.gameObject;
				_oitemText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "item4":
				_oitem4 = transform.gameObject;
				_oitemText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "item5":
				_oitem5 = transform.gameObject;
				_oitemText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "item6":
				_oitem6 = transform.gameObject;
				_oitemText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "item7":
				_oitem7 = transform.gameObject;
				_oitemText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "item8":
				_oitem8 = transform.gameObject;
				_oitemText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "item9":
				_oitem9 = transform.gameObject;
				_oitemText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "item10":
				_oitem10 = transform.gameObject;
				_oitemText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "item11":
				_oitem11 = transform.gameObject;
				_oitemText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "item12":
				_oitem12 = transform.gameObject;
				_oitemText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "item13":
				_oitem13 = transform.gameObject;
				_oitemText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "item14":
				_oitem14 = transform.gameObject;
				_oitemText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "item15":
				_oitem15 = transform.gameObject;
				_oitemText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "item16":
				_oitem16 = transform.gameObject;
				_oitemText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "item17":
				_oitem17 = transform.gameObject;
				_oitemText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "item18":
				_oitem18 = transform.gameObject;
				_oitemText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "item19":
				_oitem19 = transform.gameObject;
				_oitemText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "item20":
				_oitem20 = transform.gameObject;
				_oitemText20 = transform.gameObject.GetComponent<Text>();
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

	public bool GetitemShow(int index)
	{
		return index switch
		{
			1 => itemShow1, 
			2 => itemShow2, 
			3 => itemShow3, 
			4 => itemShow4, 
			5 => itemShow5, 
			6 => itemShow6, 
			7 => itemShow7, 
			8 => itemShow8, 
			9 => itemShow9, 
			10 => itemShow10, 
			11 => itemShow11, 
			12 => itemShow12, 
			13 => itemShow13, 
			14 => itemShow14, 
			15 => itemShow15, 
			16 => itemShow16, 
			17 => itemShow17, 
			18 => itemShow18, 
			19 => itemShow19, 
			20 => itemShow20, 
			_ => false, 
		};
	}

	public void SetitemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			itemShow1 = value;
			break;
		case 2:
			itemShow2 = value;
			break;
		case 3:
			itemShow3 = value;
			break;
		case 4:
			itemShow4 = value;
			break;
		case 5:
			itemShow5 = value;
			break;
		case 6:
			itemShow6 = value;
			break;
		case 7:
			itemShow7 = value;
			break;
		case 8:
			itemShow8 = value;
			break;
		case 9:
			itemShow9 = value;
			break;
		case 10:
			itemShow10 = value;
			break;
		case 11:
			itemShow11 = value;
			break;
		case 12:
			itemShow12 = value;
			break;
		case 13:
			itemShow13 = value;
			break;
		case 14:
			itemShow14 = value;
			break;
		case 15:
			itemShow15 = value;
			break;
		case 16:
			itemShow16 = value;
			break;
		case 17:
			itemShow17 = value;
			break;
		case 18:
			itemShow18 = value;
			break;
		case 19:
			itemShow19 = value;
			break;
		case 20:
			itemShow20 = value;
			break;
		}
	}

	public int GetitemCount()
	{
		return 20;
	}

	public string GetitemString(int index)
	{
		return index switch
		{
			1 => itemString1, 
			2 => itemString2, 
			3 => itemString3, 
			4 => itemString4, 
			5 => itemString5, 
			6 => itemString6, 
			7 => itemString7, 
			8 => itemString8, 
			9 => itemString9, 
			10 => itemString10, 
			11 => itemString11, 
			12 => itemString12, 
			13 => itemString13, 
			14 => itemString14, 
			15 => itemString15, 
			16 => itemString16, 
			17 => itemString17, 
			18 => itemString18, 
			19 => itemString19, 
			20 => itemString20, 
			_ => null, 
		};
	}

	public void SetitemString(int index, string value)
	{
		switch (index)
		{
		case 1:
			itemString1 = value;
			break;
		case 2:
			itemString2 = value;
			break;
		case 3:
			itemString3 = value;
			break;
		case 4:
			itemString4 = value;
			break;
		case 5:
			itemString5 = value;
			break;
		case 6:
			itemString6 = value;
			break;
		case 7:
			itemString7 = value;
			break;
		case 8:
			itemString8 = value;
			break;
		case 9:
			itemString9 = value;
			break;
		case 10:
			itemString10 = value;
			break;
		case 11:
			itemString11 = value;
			break;
		case 12:
			itemString12 = value;
			break;
		case 13:
			itemString13 = value;
			break;
		case 14:
			itemString14 = value;
			break;
		case 15:
			itemString15 = value;
			break;
		case 16:
			itemString16 = value;
			break;
		case 17:
			itemString17 = value;
			break;
		case 18:
			itemString18 = value;
			break;
		case 19:
			itemString19 = value;
			break;
		case 20:
			itemString20 = value;
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
