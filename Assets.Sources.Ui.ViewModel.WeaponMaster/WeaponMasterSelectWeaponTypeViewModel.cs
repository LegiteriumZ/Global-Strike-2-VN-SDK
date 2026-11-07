using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.WeaponMaster;

[GameUiTest]
public class WeaponMasterSelectWeaponTypeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _oType1;

	private GameObject _oType2;

	private GameObject _oType3;

	private GameObject _oType4;

	private GameObject _oType5;

	private Image _oTypeImage1;

	private Image _oTypeImage2;

	private Image _oTypeImage3;

	private Image _oTypeImage4;

	private Image _oTypeImage5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weaponmaster";

	private string _resourceAssetName = "WeaponMasterSelectWeaponType";

	private IUiViewModel _uiViewModelImplementation;

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
			}
		}
	}

	public Sprite TypeSprite1
	{
		get
		{
			if (_oTypeImage1 != null)
			{
				return _oTypeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TypeSprite1 != value && _oTypeImage1 != null)
			{
				_oTypeImage1.sprite = value;
			}
		}
	}

	public Sprite TypeSprite2
	{
		get
		{
			if (_oTypeImage2 != null)
			{
				return _oTypeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TypeSprite2 != value && _oTypeImage2 != null)
			{
				_oTypeImage2.sprite = value;
			}
		}
	}

	public Sprite TypeSprite3
	{
		get
		{
			if (_oTypeImage3 != null)
			{
				return _oTypeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (TypeSprite3 != value && _oTypeImage3 != null)
			{
				_oTypeImage3.sprite = value;
			}
		}
	}

	public Sprite TypeSprite4
	{
		get
		{
			if (_oTypeImage4 != null)
			{
				return _oTypeImage4.sprite;
			}
			return null;
		}
		set
		{
			if (TypeSprite4 != value && _oTypeImage4 != null)
			{
				_oTypeImage4.sprite = value;
			}
		}
	}

	public Sprite TypeSprite5
	{
		get
		{
			if (_oTypeImage5 != null)
			{
				return _oTypeImage5.sprite;
			}
			return null;
		}
		set
		{
			if (TypeSprite5 != value && _oTypeImage5 != null)
			{
				_oTypeImage5.sprite = value;
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Type1":
				_oType1 = transform.gameObject;
				_oTypeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type2":
				_oType2 = transform.gameObject;
				_oTypeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type3":
				_oType3 = transform.gameObject;
				_oTypeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type4":
				_oType4 = transform.gameObject;
				_oTypeImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Type5":
				_oType5 = transform.gameObject;
				_oTypeImage5 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public Sprite GetTypeSprite(int index)
	{
		return index switch
		{
			1 => TypeSprite1, 
			2 => TypeSprite2, 
			3 => TypeSprite3, 
			4 => TypeSprite4, 
			5 => TypeSprite5, 
			_ => null, 
		};
	}

	public void SetTypeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TypeSprite1 = value;
			break;
		case 2:
			TypeSprite2 = value;
			break;
		case 3:
			TypeSprite3 = value;
			break;
		case 4:
			TypeSprite4 = value;
			break;
		case 5:
			TypeSprite5 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
