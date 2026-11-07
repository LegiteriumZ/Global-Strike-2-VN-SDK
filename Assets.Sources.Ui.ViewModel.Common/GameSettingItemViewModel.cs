using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class GameSettingItemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oGameSettingItem;

	private RectTransform _oGameSettingItemRectTransform;

	private GameObject _oItemBack;

	private EventTrigger _oItemBackEventTrigger;

	private GameObject _oItemTitle;

	private Text _oItemTitleText;

	private GameObject _oDropdown;

	private Dropdown _oDropdownDropdown;

	private GameObject _oSlider;

	private Slider _oSliderSlider;

	private GameObject _oMin;

	private Text _oMinText;

	private GameObject _oMax;

	private Text _oMaxText;

	private GameObject _oValueText;

	private Text _oValueTextText;

	private GameObject _oColor;

	private Dropdown _oColorDropdown;

	private GameObject _oCross;

	private Dropdown _oCrossDropdown;

	private GameObject _oNotOpened;

	private GameObject _oNotOpendText;

	private Text _oNotOpendTextText;

	private GameObject _oSeprator;

	private GameObject _oItemText;

	private Text _oItemTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "GameSettingItem";

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

	public bool GameSettingItemShow
	{
		get
		{
			if (_oGameSettingItem != null)
			{
				return _oGameSettingItem.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GameSettingItemShow != value && _oGameSettingItem != null)
			{
				_oGameSettingItem.SetObjectActive(value);
			}
		}
	}

	public Vector3 GameSettingItemSize
	{
		get
		{
			if (_oGameSettingItemRectTransform != null)
			{
				return _oGameSettingItemRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (GameSettingItemSize != value && _oGameSettingItemRectTransform != null)
			{
				_oGameSettingItemRectTransform.sizeDelta = value;
			}
		}
	}

	public bool ItemBackShow
	{
		get
		{
			if (_oItemBack != null)
			{
				return _oItemBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemBackShow != value && _oItemBack != null)
			{
				_oItemBack.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ItemBackTriggers
	{
		get
		{
			if (_oItemBackEventTrigger != null)
			{
				return _oItemBackEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ItemBackTriggers != value && _oItemBackEventTrigger != null)
			{
				_oItemBackEventTrigger.triggers = value;
			}
		}
	}

	public string ItemTitleString
	{
		get
		{
			if (_oItemTitleText != null)
			{
				return _oItemTitleText.text;
			}
			return null;
		}
		set
		{
			if (ItemTitleString != value && _oItemTitleText != null)
			{
				_oItemTitleText.text = value;
			}
		}
	}

	public bool DropdownShow
	{
		get
		{
			if (_oDropdown != null)
			{
				return _oDropdown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DropdownShow != value && _oDropdown != null)
			{
				_oDropdown.SetObjectActive(value);
			}
		}
	}

	public Dropdown.DropdownEvent DropdownDropdownchanged
	{
		get
		{
			if (_oDropdownDropdown != null)
			{
				return _oDropdownDropdown.onValueChanged;
			}
			return null;
		}
		set
		{
			if (DropdownDropdownchanged != value && _oDropdownDropdown != null)
			{
				_oDropdownDropdown.onValueChanged = value;
			}
		}
	}

	public int DropdownDropdownvalue
	{
		get
		{
			if (_oDropdownDropdown != null)
			{
				return _oDropdownDropdown.value;
			}
			return -1;
		}
		set
		{
			if (DropdownDropdownvalue != value && _oDropdownDropdown != null)
			{
				_oDropdownDropdown.value = value;
			}
		}
	}

	public List<Dropdown.OptionData> DropdownOptions
	{
		get
		{
			if (_oDropdownDropdown != null)
			{
				return _oDropdownDropdown.options;
			}
			return null;
		}
		set
		{
			if (DropdownOptions != value && _oDropdownDropdown != null)
			{
				_oDropdownDropdown.options = value;
			}
		}
	}

	public bool SliderShow
	{
		get
		{
			if (_oSlider != null)
			{
				return _oSlider.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SliderShow != value && _oSlider != null)
			{
				_oSlider.SetObjectActive(value);
			}
		}
	}

	public float SliderSlidervalue
	{
		get
		{
			if (_oSliderSlider != null)
			{
				return _oSliderSlider.value;
			}
			return 0f;
		}
		set
		{
			if (SliderSlidervalue != value && _oSliderSlider != null)
			{
				_oSliderSlider.value = value;
			}
		}
	}

	public Slider.SliderEvent SliderSliderchanged
	{
		get
		{
			if (_oSliderSlider != null)
			{
				return _oSliderSlider.onValueChanged;
			}
			return null;
		}
		set
		{
			if (SliderSliderchanged != value && _oSliderSlider != null)
			{
				_oSliderSlider.onValueChanged = value;
			}
		}
	}

	public string MinString
	{
		get
		{
			if (_oMinText != null)
			{
				return _oMinText.text;
			}
			return null;
		}
		set
		{
			if (MinString != value && _oMinText != null)
			{
				_oMinText.text = value;
			}
		}
	}

	public string MaxString
	{
		get
		{
			if (_oMaxText != null)
			{
				return _oMaxText.text;
			}
			return null;
		}
		set
		{
			if (MaxString != value && _oMaxText != null)
			{
				_oMaxText.text = value;
			}
		}
	}

	public string ValueTextString
	{
		get
		{
			if (_oValueTextText != null)
			{
				return _oValueTextText.text;
			}
			return null;
		}
		set
		{
			if (ValueTextString != value && _oValueTextText != null)
			{
				_oValueTextText.text = value;
			}
		}
	}

	public bool ColorShow
	{
		get
		{
			if (_oColor != null)
			{
				return _oColor.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ColorShow != value && _oColor != null)
			{
				_oColor.SetObjectActive(value);
			}
		}
	}

	public Dropdown.DropdownEvent ColorDropdownchanged
	{
		get
		{
			if (_oColorDropdown != null)
			{
				return _oColorDropdown.onValueChanged;
			}
			return null;
		}
		set
		{
			if (ColorDropdownchanged != value && _oColorDropdown != null)
			{
				_oColorDropdown.onValueChanged = value;
			}
		}
	}

	public int ColorDropdownvalue
	{
		get
		{
			if (_oColorDropdown != null)
			{
				return _oColorDropdown.value;
			}
			return -1;
		}
		set
		{
			if (ColorDropdownvalue != value && _oColorDropdown != null)
			{
				_oColorDropdown.value = value;
			}
		}
	}

	public bool CrossShow
	{
		get
		{
			if (_oCross != null)
			{
				return _oCross.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrossShow != value && _oCross != null)
			{
				_oCross.SetObjectActive(value);
			}
		}
	}

	public Dropdown.DropdownEvent CrossDropdownchanged
	{
		get
		{
			if (_oCrossDropdown != null)
			{
				return _oCrossDropdown.onValueChanged;
			}
			return null;
		}
		set
		{
			if (CrossDropdownchanged != value && _oCrossDropdown != null)
			{
				_oCrossDropdown.onValueChanged = value;
			}
		}
	}

	public int CrossDropdownvalue
	{
		get
		{
			if (_oCrossDropdown != null)
			{
				return _oCrossDropdown.value;
			}
			return -1;
		}
		set
		{
			if (CrossDropdownvalue != value && _oCrossDropdown != null)
			{
				_oCrossDropdown.value = value;
			}
		}
	}

	public bool NotOpenedShow
	{
		get
		{
			if (_oNotOpened != null)
			{
				return _oNotOpened.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NotOpenedShow != value && _oNotOpened != null)
			{
				_oNotOpened.SetObjectActive(value);
			}
		}
	}

	public string NotOpendTextString
	{
		get
		{
			if (_oNotOpendTextText != null)
			{
				return _oNotOpendTextText.text;
			}
			return null;
		}
		set
		{
			if (NotOpendTextString != value && _oNotOpendTextText != null)
			{
				_oNotOpendTextText.text = value;
			}
		}
	}

	public bool SepratorShow
	{
		get
		{
			if (_oSeprator != null)
			{
				return _oSeprator.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SepratorShow != value && _oSeprator != null)
			{
				_oSeprator.SetObjectActive(value);
			}
		}
	}

	public string ItemTextString
	{
		get
		{
			if (_oItemTextText != null)
			{
				return _oItemTextText.text;
			}
			return null;
		}
		set
		{
			if (ItemTextString != value && _oItemTextText != null)
			{
				_oItemTextText.text = value;
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
			case "GameSettingItem":
				_oGameSettingItem = transform.gameObject;
				_oGameSettingItemRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ItemBack":
				_oItemBack = transform.gameObject;
				_oItemBackEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "ItemTitle":
				_oItemTitle = transform.gameObject;
				_oItemTitleText = transform.gameObject.GetComponent<Text>();
				break;
			case "Dropdown":
				_oDropdown = transform.gameObject;
				_oDropdownDropdown = transform.gameObject.GetComponent<Dropdown>();
				break;
			case "Slider":
				_oSlider = transform.gameObject;
				_oSliderSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "Min":
				_oMin = transform.gameObject;
				_oMinText = transform.gameObject.GetComponent<Text>();
				break;
			case "Max":
				_oMax = transform.gameObject;
				_oMaxText = transform.gameObject.GetComponent<Text>();
				break;
			case "ValueText":
				_oValueText = transform.gameObject;
				_oValueTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Color":
				_oColor = transform.gameObject;
				_oColorDropdown = transform.gameObject.GetComponent<Dropdown>();
				break;
			case "Cross":
				_oCross = transform.gameObject;
				_oCrossDropdown = transform.gameObject.GetComponent<Dropdown>();
				break;
			case "NotOpened":
				_oNotOpened = transform.gameObject;
				break;
			case "NotOpendText":
				_oNotOpendText = transform.gameObject;
				_oNotOpendTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seprator":
				_oSeprator = transform.gameObject;
				break;
			case "ItemText":
				_oItemText = transform.gameObject;
				_oItemTextText = transform.gameObject.GetComponent<Text>();
				break;
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
			Object.Destroy(_viewGameObject);
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
