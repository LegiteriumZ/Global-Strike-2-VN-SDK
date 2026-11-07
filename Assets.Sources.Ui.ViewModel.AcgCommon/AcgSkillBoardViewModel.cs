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

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgSkillBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCharacterReady;

	private Image _oCharacterReadyImage;

	private GameObject _oCharacterCooling;

	private Image _oCharacterCoolingImage;

	private GameObject _oCharacterProgress;

	private Image _oCharacterProgressImage;

	private GameObject _oCharacterSilence;

	private GameObject _oCharacterTime;

	private Text _oCharacterTimeText;

	private GameObject _oCharacterEnergy;

	private Text _oCharacterEnergyText;

	private GameObject _oWeaponReady;

	private Image _oWeaponReadyImage;

	private GameObject _oWeaponCooling;

	private Image _oWeaponCoolingImage;

	private GameObject _oWeaponProgress;

	private Image _oWeaponProgressImage;

	private GameObject _oWeaponSilence;

	private GameObject _oWeaponTime;

	private Text _oWeaponTimeText;

	private GameObject _oWeaponEnergy;

	private Text _oWeaponEnergyText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgskillboard";

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

	public bool CharacterReadyShow
	{
		get
		{
			if (_oCharacterReady != null)
			{
				return _oCharacterReady.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CharacterReadyShow != value && _oCharacterReady != null)
			{
				_oCharacterReady.SetObjectActive(value);
			}
		}
	}

	public Image CharacterReadyImage
	{
		get
		{
			if (_oCharacterReadyImage != null)
			{
				return _oCharacterReadyImage;
			}
			return null;
		}
		set
		{
			if (CharacterReadyImage != value && _oCharacterReadyImage != null)
			{
				_oCharacterReadyImage = value;
			}
		}
	}

	public bool CharacterCoolingShow
	{
		get
		{
			if (_oCharacterCooling != null)
			{
				return _oCharacterCooling.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CharacterCoolingShow != value && _oCharacterCooling != null)
			{
				_oCharacterCooling.SetObjectActive(value);
			}
		}
	}

	public Image CharacterCoolingImage
	{
		get
		{
			if (_oCharacterCoolingImage != null)
			{
				return _oCharacterCoolingImage;
			}
			return null;
		}
		set
		{
			if (CharacterCoolingImage != value && _oCharacterCoolingImage != null)
			{
				_oCharacterCoolingImage = value;
			}
		}
	}

	public float CharacterProgressFillamount
	{
		get
		{
			if (_oCharacterProgressImage != null)
			{
				return _oCharacterProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CharacterProgressFillamount != value && _oCharacterProgressImage != null)
			{
				_oCharacterProgressImage.fillAmount = value;
			}
		}
	}

	public bool CharacterSilenceShow
	{
		get
		{
			if (_oCharacterSilence != null)
			{
				return _oCharacterSilence.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CharacterSilenceShow != value && _oCharacterSilence != null)
			{
				_oCharacterSilence.SetObjectActive(value);
			}
		}
	}

	public bool CharacterTimeShow
	{
		get
		{
			if (_oCharacterTime != null)
			{
				return _oCharacterTime.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CharacterTimeShow != value && _oCharacterTime != null)
			{
				_oCharacterTime.SetObjectActive(value);
			}
		}
	}

	public string CharacterTimeString
	{
		get
		{
			if (_oCharacterTimeText != null)
			{
				return _oCharacterTimeText.text;
			}
			return null;
		}
		set
		{
			if (CharacterTimeString != value && _oCharacterTimeText != null)
			{
				_oCharacterTimeText.text = value;
			}
		}
	}

	public string CharacterEnergyString
	{
		get
		{
			if (_oCharacterEnergyText != null)
			{
				return _oCharacterEnergyText.text;
			}
			return null;
		}
		set
		{
			if (CharacterEnergyString != value && _oCharacterEnergyText != null)
			{
				_oCharacterEnergyText.text = value;
			}
		}
	}

	public bool WeaponReadyShow
	{
		get
		{
			if (_oWeaponReady != null)
			{
				return _oWeaponReady.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponReadyShow != value && _oWeaponReady != null)
			{
				_oWeaponReady.SetObjectActive(value);
			}
		}
	}

	public Image WeaponReadyImage
	{
		get
		{
			if (_oWeaponReadyImage != null)
			{
				return _oWeaponReadyImage;
			}
			return null;
		}
		set
		{
			if (WeaponReadyImage != value && _oWeaponReadyImage != null)
			{
				_oWeaponReadyImage = value;
			}
		}
	}

	public bool WeaponCoolingShow
	{
		get
		{
			if (_oWeaponCooling != null)
			{
				return _oWeaponCooling.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponCoolingShow != value && _oWeaponCooling != null)
			{
				_oWeaponCooling.SetObjectActive(value);
			}
		}
	}

	public Image WeaponCoolingImage
	{
		get
		{
			if (_oWeaponCoolingImage != null)
			{
				return _oWeaponCoolingImage;
			}
			return null;
		}
		set
		{
			if (WeaponCoolingImage != value && _oWeaponCoolingImage != null)
			{
				_oWeaponCoolingImage = value;
			}
		}
	}

	public float WeaponProgressFillamount
	{
		get
		{
			if (_oWeaponProgressImage != null)
			{
				return _oWeaponProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (WeaponProgressFillamount != value && _oWeaponProgressImage != null)
			{
				_oWeaponProgressImage.fillAmount = value;
			}
		}
	}

	public bool WeaponSilenceShow
	{
		get
		{
			if (_oWeaponSilence != null)
			{
				return _oWeaponSilence.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponSilenceShow != value && _oWeaponSilence != null)
			{
				_oWeaponSilence.SetObjectActive(value);
			}
		}
	}

	public bool WeaponTimeShow
	{
		get
		{
			if (_oWeaponTime != null)
			{
				return _oWeaponTime.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponTimeShow != value && _oWeaponTime != null)
			{
				_oWeaponTime.SetObjectActive(value);
			}
		}
	}

	public string WeaponTimeString
	{
		get
		{
			if (_oWeaponTimeText != null)
			{
				return _oWeaponTimeText.text;
			}
			return null;
		}
		set
		{
			if (WeaponTimeString != value && _oWeaponTimeText != null)
			{
				_oWeaponTimeText.text = value;
			}
		}
	}

	public string WeaponEnergyString
	{
		get
		{
			if (_oWeaponEnergyText != null)
			{
				return _oWeaponEnergyText.text;
			}
			return null;
		}
		set
		{
			if (WeaponEnergyString != value && _oWeaponEnergyText != null)
			{
				_oWeaponEnergyText.text = value;
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
			case "CharacterReady":
				_oCharacterReady = transform.gameObject;
				_oCharacterReadyImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CharacterCooling":
				_oCharacterCooling = transform.gameObject;
				_oCharacterCoolingImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CharacterProgress":
				_oCharacterProgress = transform.gameObject;
				_oCharacterProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CharacterSilence":
				_oCharacterSilence = transform.gameObject;
				break;
			case "CharacterTime":
				_oCharacterTime = transform.gameObject;
				_oCharacterTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "CharacterEnergy":
				_oCharacterEnergy = transform.gameObject;
				_oCharacterEnergyText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponReady":
				_oWeaponReady = transform.gameObject;
				_oWeaponReadyImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponCooling":
				_oWeaponCooling = transform.gameObject;
				_oWeaponCoolingImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponProgress":
				_oWeaponProgress = transform.gameObject;
				_oWeaponProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponSilence":
				_oWeaponSilence = transform.gameObject;
				break;
			case "WeaponTime":
				_oWeaponTime = transform.gameObject;
				_oWeaponTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponEnergy":
				_oWeaponEnergy = transform.gameObject;
				_oWeaponEnergyText = transform.gameObject.GetComponent<Text>();
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
