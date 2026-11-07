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
public class HeroFightingSelectViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _ohero1;

	private GameObject _ohero2;

	private GameObject _ohero3;

	private Image _oheroImage1;

	private Image _oheroImage2;

	private Image _oheroImage3;

	private GameObject _oselect1;

	private GameObject _oselect2;

	private GameObject _oselect3;

	private GameObject _oselectNum1;

	private GameObject _oselectNum2;

	private GameObject _oselectNum3;

	private Image _oselectNumImage1;

	private Image _oselectNumImage2;

	private Image _oselectNumImage3;

	private GameObject _onohero1;

	private GameObject _onohero2;

	private GameObject _onohero3;

	private GameObject _otimer;

	private Text _otimerText;

	private GameObject _oEnergy;

	private GameObject _oEnergyProgress;

	private Image _oEnergyProgressImage;

	private GameObject _oEnergyTime;

	private Text _oEnergyTimeText;

	private GameObject _oOver;

	private GameObject _ohead;

	private Image _oheadImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/herofightingmodel";

	private string _resourceAssetName = "herofightingselect";

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

	public bool heroShow1
	{
		get
		{
			if (_ohero1 != null)
			{
				return _ohero1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (heroShow1 != value && _ohero1 != null)
			{
				_ohero1.SetObjectActive(value);
			}
		}
	}

	public bool heroShow2
	{
		get
		{
			if (_ohero2 != null)
			{
				return _ohero2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (heroShow2 != value && _ohero2 != null)
			{
				_ohero2.SetObjectActive(value);
			}
		}
	}

	public bool heroShow3
	{
		get
		{
			if (_ohero3 != null)
			{
				return _ohero3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (heroShow3 != value && _ohero3 != null)
			{
				_ohero3.SetObjectActive(value);
			}
		}
	}

	public Sprite heroSprite1
	{
		get
		{
			if (_oheroImage1 != null)
			{
				return _oheroImage1.sprite;
			}
			return null;
		}
		set
		{
			if (heroSprite1 != value && _oheroImage1 != null)
			{
				_oheroImage1.sprite = value;
			}
		}
	}

	public Sprite heroSprite2
	{
		get
		{
			if (_oheroImage2 != null)
			{
				return _oheroImage2.sprite;
			}
			return null;
		}
		set
		{
			if (heroSprite2 != value && _oheroImage2 != null)
			{
				_oheroImage2.sprite = value;
			}
		}
	}

	public Sprite heroSprite3
	{
		get
		{
			if (_oheroImage3 != null)
			{
				return _oheroImage3.sprite;
			}
			return null;
		}
		set
		{
			if (heroSprite3 != value && _oheroImage3 != null)
			{
				_oheroImage3.sprite = value;
			}
		}
	}

	public bool selectShow1
	{
		get
		{
			if (_oselect1 != null)
			{
				return _oselect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow1 != value && _oselect1 != null)
			{
				_oselect1.SetObjectActive(value);
			}
		}
	}

	public bool selectShow2
	{
		get
		{
			if (_oselect2 != null)
			{
				return _oselect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow2 != value && _oselect2 != null)
			{
				_oselect2.SetObjectActive(value);
			}
		}
	}

	public bool selectShow3
	{
		get
		{
			if (_oselect3 != null)
			{
				return _oselect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow3 != value && _oselect3 != null)
			{
				_oselect3.SetObjectActive(value);
			}
		}
	}

	public Sprite selectNumSprite1
	{
		get
		{
			if (_oselectNumImage1 != null)
			{
				return _oselectNumImage1.sprite;
			}
			return null;
		}
		set
		{
			if (selectNumSprite1 != value && _oselectNumImage1 != null)
			{
				_oselectNumImage1.sprite = value;
			}
		}
	}

	public Sprite selectNumSprite2
	{
		get
		{
			if (_oselectNumImage2 != null)
			{
				return _oselectNumImage2.sprite;
			}
			return null;
		}
		set
		{
			if (selectNumSprite2 != value && _oselectNumImage2 != null)
			{
				_oselectNumImage2.sprite = value;
			}
		}
	}

	public Sprite selectNumSprite3
	{
		get
		{
			if (_oselectNumImage3 != null)
			{
				return _oselectNumImage3.sprite;
			}
			return null;
		}
		set
		{
			if (selectNumSprite3 != value && _oselectNumImage3 != null)
			{
				_oselectNumImage3.sprite = value;
			}
		}
	}

	public bool noheroShow1
	{
		get
		{
			if (_onohero1 != null)
			{
				return _onohero1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (noheroShow1 != value && _onohero1 != null)
			{
				_onohero1.SetObjectActive(value);
			}
		}
	}

	public bool noheroShow2
	{
		get
		{
			if (_onohero2 != null)
			{
				return _onohero2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (noheroShow2 != value && _onohero2 != null)
			{
				_onohero2.SetObjectActive(value);
			}
		}
	}

	public bool noheroShow3
	{
		get
		{
			if (_onohero3 != null)
			{
				return _onohero3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (noheroShow3 != value && _onohero3 != null)
			{
				_onohero3.SetObjectActive(value);
			}
		}
	}

	public string timerString
	{
		get
		{
			if (_otimerText != null)
			{
				return _otimerText.text;
			}
			return null;
		}
		set
		{
			if (timerString != value && _otimerText != null)
			{
				_otimerText.text = value;
			}
		}
	}

	public bool EnergyShow
	{
		get
		{
			if (_oEnergy != null)
			{
				return _oEnergy.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EnergyShow != value && _oEnergy != null)
			{
				_oEnergy.SetObjectActive(value);
			}
		}
	}

	public float EnergyProgressFillamount
	{
		get
		{
			if (_oEnergyProgressImage != null)
			{
				return _oEnergyProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EnergyProgressFillamount != value && _oEnergyProgressImage != null)
			{
				_oEnergyProgressImage.fillAmount = value;
			}
		}
	}

	public string EnergyTimeString
	{
		get
		{
			if (_oEnergyTimeText != null)
			{
				return _oEnergyTimeText.text;
			}
			return null;
		}
		set
		{
			if (EnergyTimeString != value && _oEnergyTimeText != null)
			{
				_oEnergyTimeText.text = value;
			}
		}
	}

	public bool OverShow
	{
		get
		{
			if (_oOver != null)
			{
				return _oOver.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OverShow != value && _oOver != null)
			{
				_oOver.SetObjectActive(value);
			}
		}
	}

	public bool headShow
	{
		get
		{
			if (_ohead != null)
			{
				return _ohead.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (headShow != value && _ohead != null)
			{
				_ohead.SetObjectActive(value);
			}
		}
	}

	public Sprite headSprite
	{
		get
		{
			if (_oheadImage != null)
			{
				return _oheadImage.sprite;
			}
			return null;
		}
		set
		{
			if (headSprite != value && _oheadImage != null)
			{
				_oheadImage.sprite = value;
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
			case "hero1":
				_ohero1 = transform.gameObject;
				_oheroImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "hero2":
				_ohero2 = transform.gameObject;
				_oheroImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "hero3":
				_ohero3 = transform.gameObject;
				_oheroImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "select1":
				_oselect1 = transform.gameObject;
				break;
			case "select2":
				_oselect2 = transform.gameObject;
				break;
			case "select3":
				_oselect3 = transform.gameObject;
				break;
			case "selectNum1":
				_oselectNum1 = transform.gameObject;
				_oselectNumImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "selectNum2":
				_oselectNum2 = transform.gameObject;
				_oselectNumImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "selectNum3":
				_oselectNum3 = transform.gameObject;
				_oselectNumImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "nohero1":
				_onohero1 = transform.gameObject;
				break;
			case "nohero2":
				_onohero2 = transform.gameObject;
				break;
			case "nohero3":
				_onohero3 = transform.gameObject;
				break;
			case "timer":
				_otimer = transform.gameObject;
				_otimerText = transform.gameObject.GetComponent<Text>();
				break;
			case "Energy":
				_oEnergy = transform.gameObject;
				break;
			case "EnergyProgress":
				_oEnergyProgress = transform.gameObject;
				_oEnergyProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyTime":
				_oEnergyTime = transform.gameObject;
				_oEnergyTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "Over":
				_oOver = transform.gameObject;
				break;
			case "head":
				_ohead = transform.gameObject;
				_oheadImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetheroShow(int index)
	{
		return index switch
		{
			1 => heroShow1, 
			2 => heroShow2, 
			3 => heroShow3, 
			_ => false, 
		};
	}

	public void SetheroShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			heroShow1 = value;
			break;
		case 2:
			heroShow2 = value;
			break;
		case 3:
			heroShow3 = value;
			break;
		}
	}

	public int GetheroCount()
	{
		return 3;
	}

	public Sprite GetheroSprite(int index)
	{
		return index switch
		{
			1 => heroSprite1, 
			2 => heroSprite2, 
			3 => heroSprite3, 
			_ => null, 
		};
	}

	public void SetheroSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			heroSprite1 = value;
			break;
		case 2:
			heroSprite2 = value;
			break;
		case 3:
			heroSprite3 = value;
			break;
		}
	}

	public bool GetselectShow(int index)
	{
		return index switch
		{
			1 => selectShow1, 
			2 => selectShow2, 
			3 => selectShow3, 
			_ => false, 
		};
	}

	public void SetselectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			selectShow1 = value;
			break;
		case 2:
			selectShow2 = value;
			break;
		case 3:
			selectShow3 = value;
			break;
		}
	}

	public int GetselectCount()
	{
		return 3;
	}

	public Sprite GetselectNumSprite(int index)
	{
		return index switch
		{
			1 => selectNumSprite1, 
			2 => selectNumSprite2, 
			3 => selectNumSprite3, 
			_ => null, 
		};
	}

	public void SetselectNumSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			selectNumSprite1 = value;
			break;
		case 2:
			selectNumSprite2 = value;
			break;
		case 3:
			selectNumSprite3 = value;
			break;
		}
	}

	public int GetselectNumCount()
	{
		return 3;
	}

	public bool GetnoheroShow(int index)
	{
		return index switch
		{
			1 => noheroShow1, 
			2 => noheroShow2, 
			3 => noheroShow3, 
			_ => false, 
		};
	}

	public void SetnoheroShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			noheroShow1 = value;
			break;
		case 2:
			noheroShow2 = value;
			break;
		case 3:
			noheroShow3 = value;
			break;
		}
	}

	public int GetnoheroCount()
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
