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
public class AcgTradeWindowViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCloseArea;

	private EventTrigger _oCloseAreaEventTrigger;

	private GameObject _oHeal;

	private EventTrigger _oHealEventTrigger;

	private GameObject _oHealPriceBack;

	private Image _oHealPriceBackImage;

	private GameObject _oHealDisabled;

	private GameObject _oHealPrice;

	private Text _oHealPriceText;

	private GameObject _oPowerUp;

	private EventTrigger _oPowerUpEventTrigger;

	private GameObject _oPowerUpPriceBack;

	private Image _oPowerUpPriceBackImage;

	private GameObject _oPowerUpDisabled;

	private GameObject _oPowerUpPrice;

	private Text _oPowerUpPriceText;

	private GameObject _oCoinNumber;

	private Text _oCoinNumberText;

	private GameObject _oCloseButton;

	private Button _oCloseButtonButton;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgtradewindow";

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

	public List<EventTrigger.Entry> CloseAreaTriggers
	{
		get
		{
			if (_oCloseAreaEventTrigger != null)
			{
				return _oCloseAreaEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseAreaTriggers != value && _oCloseAreaEventTrigger != null)
			{
				_oCloseAreaEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> HealTriggers
	{
		get
		{
			if (_oHealEventTrigger != null)
			{
				return _oHealEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (HealTriggers != value && _oHealEventTrigger != null)
			{
				_oHealEventTrigger.triggers = value;
			}
		}
	}

	public Image HealPriceBackImage
	{
		get
		{
			if (_oHealPriceBackImage != null)
			{
				return _oHealPriceBackImage;
			}
			return null;
		}
		set
		{
			if (HealPriceBackImage != value && _oHealPriceBackImage != null)
			{
				_oHealPriceBackImage = value;
			}
		}
	}

	public bool HealDisabledShow
	{
		get
		{
			if (_oHealDisabled != null)
			{
				return _oHealDisabled.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HealDisabledShow != value && _oHealDisabled != null)
			{
				_oHealDisabled.SetObjectActive(value);
			}
		}
	}

	public string HealPriceString
	{
		get
		{
			if (_oHealPriceText != null)
			{
				return _oHealPriceText.text;
			}
			return null;
		}
		set
		{
			if (HealPriceString != value && _oHealPriceText != null)
			{
				_oHealPriceText.text = value;
			}
		}
	}

	public List<EventTrigger.Entry> PowerUpTriggers
	{
		get
		{
			if (_oPowerUpEventTrigger != null)
			{
				return _oPowerUpEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (PowerUpTriggers != value && _oPowerUpEventTrigger != null)
			{
				_oPowerUpEventTrigger.triggers = value;
			}
		}
	}

	public Image PowerUpPriceBackImage
	{
		get
		{
			if (_oPowerUpPriceBackImage != null)
			{
				return _oPowerUpPriceBackImage;
			}
			return null;
		}
		set
		{
			if (PowerUpPriceBackImage != value && _oPowerUpPriceBackImage != null)
			{
				_oPowerUpPriceBackImage = value;
			}
		}
	}

	public bool PowerUpDisabledShow
	{
		get
		{
			if (_oPowerUpDisabled != null)
			{
				return _oPowerUpDisabled.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerUpDisabledShow != value && _oPowerUpDisabled != null)
			{
				_oPowerUpDisabled.SetObjectActive(value);
			}
		}
	}

	public string PowerUpPriceString
	{
		get
		{
			if (_oPowerUpPriceText != null)
			{
				return _oPowerUpPriceText.text;
			}
			return null;
		}
		set
		{
			if (PowerUpPriceString != value && _oPowerUpPriceText != null)
			{
				_oPowerUpPriceText.text = value;
			}
		}
	}

	public string CoinNumberString
	{
		get
		{
			if (_oCoinNumberText != null)
			{
				return _oCoinNumberText.text;
			}
			return null;
		}
		set
		{
			if (CoinNumberString != value && _oCoinNumberText != null)
			{
				_oCoinNumberText.text = value;
			}
		}
	}

	public Button CloseButtonButton
	{
		get
		{
			if (_oCloseButtonButton != null)
			{
				return _oCloseButtonButton;
			}
			return null;
		}
		set
		{
			if (CloseButtonButton != value && _oCloseButtonButton != null)
			{
				_oCloseButtonButton = value;
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
			case "CloseArea":
				_oCloseArea = transform.gameObject;
				_oCloseAreaEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Heal":
				_oHeal = transform.gameObject;
				_oHealEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "HealPriceBack":
				_oHealPriceBack = transform.gameObject;
				_oHealPriceBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HealDisabled":
				_oHealDisabled = transform.gameObject;
				break;
			case "HealPrice":
				_oHealPrice = transform.gameObject;
				_oHealPriceText = transform.gameObject.GetComponent<Text>();
				break;
			case "PowerUp":
				_oPowerUp = transform.gameObject;
				_oPowerUpEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "PowerUpPriceBack":
				_oPowerUpPriceBack = transform.gameObject;
				_oPowerUpPriceBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUpDisabled":
				_oPowerUpDisabled = transform.gameObject;
				break;
			case "PowerUpPrice":
				_oPowerUpPrice = transform.gameObject;
				_oPowerUpPriceText = transform.gameObject.GetComponent<Text>();
				break;
			case "CoinNumber":
				_oCoinNumber = transform.gameObject;
				_oCoinNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "CloseButton":
				_oCloseButton = transform.gameObject;
				_oCloseButtonButton = transform.gameObject.GetComponent<Button>();
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

	private void CreateCloseAreaTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseAreaTriggers, eventId, callback);
	}

	private void RemoveCloseAreaTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseAreaTriggers, eventId);
	}

	private void CreateHealTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(HealTriggers, eventId, callback);
	}

	private void RemoveHealTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(HealTriggers, eventId);
	}

	private void CreatePowerUpTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(PowerUpTriggers, eventId, callback);
	}

	private void RemovePowerUpTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(PowerUpTriggers, eventId);
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
