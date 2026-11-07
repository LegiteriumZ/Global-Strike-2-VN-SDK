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
public class BioChemical_ZEndDesViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _ocLevel1;

	private GameObject _ocLevel2;

	private Text _ocLevelText1;

	private Text _ocLevelText2;

	private GameObject _oeNum1;

	private GameObject _oeNum2;

	private Text _oeNumText1;

	private Text _oeNumText2;

	private GameObject _oicon1;

	private GameObject _oicon2;

	private Image _oiconImage1;

	private Image _oiconImage2;

	private GameObject _olevel1;

	private GameObject _olevel2;

	private Text _olevelText1;

	private Text _olevelText2;

	private GameObject _ojs1;

	private GameObject _ojs2;

	private Text _ojsText1;

	private Text _ojsText2;

	private GameObject _oname1;

	private GameObject _oname2;

	private Text _onameText1;

	private Text _onameText2;

	private GameObject _owin;

	private GameObject _olose;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zenddes";

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

	public string cLevelString1
	{
		get
		{
			if (_ocLevelText1 != null)
			{
				return _ocLevelText1.text;
			}
			return null;
		}
		set
		{
			if (cLevelString1 != value && _ocLevelText1 != null)
			{
				_ocLevelText1.text = value;
			}
		}
	}

	public string cLevelString2
	{
		get
		{
			if (_ocLevelText2 != null)
			{
				return _ocLevelText2.text;
			}
			return null;
		}
		set
		{
			if (cLevelString2 != value && _ocLevelText2 != null)
			{
				_ocLevelText2.text = value;
			}
		}
	}

	public string eNumString1
	{
		get
		{
			if (_oeNumText1 != null)
			{
				return _oeNumText1.text;
			}
			return null;
		}
		set
		{
			if (eNumString1 != value && _oeNumText1 != null)
			{
				_oeNumText1.text = value;
			}
		}
	}

	public string eNumString2
	{
		get
		{
			if (_oeNumText2 != null)
			{
				return _oeNumText2.text;
			}
			return null;
		}
		set
		{
			if (eNumString2 != value && _oeNumText2 != null)
			{
				_oeNumText2.text = value;
			}
		}
	}

	public Sprite iconSprite1
	{
		get
		{
			if (_oiconImage1 != null)
			{
				return _oiconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (iconSprite1 != value && _oiconImage1 != null)
			{
				_oiconImage1.sprite = value;
			}
		}
	}

	public Sprite iconSprite2
	{
		get
		{
			if (_oiconImage2 != null)
			{
				return _oiconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (iconSprite2 != value && _oiconImage2 != null)
			{
				_oiconImage2.sprite = value;
			}
		}
	}

	public string levelString1
	{
		get
		{
			if (_olevelText1 != null)
			{
				return _olevelText1.text;
			}
			return null;
		}
		set
		{
			if (levelString1 != value && _olevelText1 != null)
			{
				_olevelText1.text = value;
			}
		}
	}

	public string levelString2
	{
		get
		{
			if (_olevelText2 != null)
			{
				return _olevelText2.text;
			}
			return null;
		}
		set
		{
			if (levelString2 != value && _olevelText2 != null)
			{
				_olevelText2.text = value;
			}
		}
	}

	public string jsString1
	{
		get
		{
			if (_ojsText1 != null)
			{
				return _ojsText1.text;
			}
			return null;
		}
		set
		{
			if (jsString1 != value && _ojsText1 != null)
			{
				_ojsText1.text = value;
			}
		}
	}

	public string jsString2
	{
		get
		{
			if (_ojsText2 != null)
			{
				return _ojsText2.text;
			}
			return null;
		}
		set
		{
			if (jsString2 != value && _ojsText2 != null)
			{
				_ojsText2.text = value;
			}
		}
	}

	public string nameString1
	{
		get
		{
			if (_onameText1 != null)
			{
				return _onameText1.text;
			}
			return null;
		}
		set
		{
			if (nameString1 != value && _onameText1 != null)
			{
				_onameText1.text = value;
			}
		}
	}

	public string nameString2
	{
		get
		{
			if (_onameText2 != null)
			{
				return _onameText2.text;
			}
			return null;
		}
		set
		{
			if (nameString2 != value && _onameText2 != null)
			{
				_onameText2.text = value;
			}
		}
	}

	public bool winShow
	{
		get
		{
			if (_owin != null)
			{
				return _owin.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (winShow != value && _owin != null)
			{
				_owin.SetObjectActive(value);
			}
		}
	}

	public bool loseShow
	{
		get
		{
			if (_olose != null)
			{
				return _olose.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (loseShow != value && _olose != null)
			{
				_olose.SetObjectActive(value);
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
			case "cLevel1":
				_ocLevel1 = transform.gameObject;
				_ocLevelText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "cLevel2":
				_ocLevel2 = transform.gameObject;
				_ocLevelText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "eNum1":
				_oeNum1 = transform.gameObject;
				_oeNumText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "eNum2":
				_oeNum2 = transform.gameObject;
				_oeNumText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "icon1":
				_oicon1 = transform.gameObject;
				_oiconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "icon2":
				_oicon2 = transform.gameObject;
				_oiconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "level1":
				_olevel1 = transform.gameObject;
				_olevelText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "level2":
				_olevel2 = transform.gameObject;
				_olevelText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "js1":
				_ojs1 = transform.gameObject;
				_ojsText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "js2":
				_ojs2 = transform.gameObject;
				_ojsText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "name1":
				_oname1 = transform.gameObject;
				_onameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "name2":
				_oname2 = transform.gameObject;
				_onameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "win":
				_owin = transform.gameObject;
				break;
			case "lose":
				_olose = transform.gameObject;
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

	public string GetcLevelString(int index)
	{
		return index switch
		{
			1 => cLevelString1, 
			2 => cLevelString2, 
			_ => null, 
		};
	}

	public void SetcLevelString(int index, string value)
	{
		switch (index)
		{
		case 1:
			cLevelString1 = value;
			break;
		case 2:
			cLevelString2 = value;
			break;
		}
	}

	public int GetcLevelCount()
	{
		return 2;
	}

	public string GeteNumString(int index)
	{
		return index switch
		{
			1 => eNumString1, 
			2 => eNumString2, 
			_ => null, 
		};
	}

	public void SeteNumString(int index, string value)
	{
		switch (index)
		{
		case 1:
			eNumString1 = value;
			break;
		case 2:
			eNumString2 = value;
			break;
		}
	}

	public int GeteNumCount()
	{
		return 2;
	}

	public Sprite GeticonSprite(int index)
	{
		return index switch
		{
			1 => iconSprite1, 
			2 => iconSprite2, 
			_ => null, 
		};
	}

	public void SeticonSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			iconSprite1 = value;
			break;
		case 2:
			iconSprite2 = value;
			break;
		}
	}

	public int GeticonCount()
	{
		return 2;
	}

	public string GetlevelString(int index)
	{
		return index switch
		{
			1 => levelString1, 
			2 => levelString2, 
			_ => null, 
		};
	}

	public void SetlevelString(int index, string value)
	{
		switch (index)
		{
		case 1:
			levelString1 = value;
			break;
		case 2:
			levelString2 = value;
			break;
		}
	}

	public int GetlevelCount()
	{
		return 2;
	}

	public string GetjsString(int index)
	{
		return index switch
		{
			1 => jsString1, 
			2 => jsString2, 
			_ => null, 
		};
	}

	public void SetjsString(int index, string value)
	{
		switch (index)
		{
		case 1:
			jsString1 = value;
			break;
		case 2:
			jsString2 = value;
			break;
		}
	}

	public int GetjsCount()
	{
		return 2;
	}

	public string GetnameString(int index)
	{
		return index switch
		{
			1 => nameString1, 
			2 => nameString2, 
			_ => null, 
		};
	}

	public void SetnameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			nameString1 = value;
			break;
		case 2:
			nameString2 = value;
			break;
		}
	}

	public int GetnameCount()
	{
		return 2;
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
