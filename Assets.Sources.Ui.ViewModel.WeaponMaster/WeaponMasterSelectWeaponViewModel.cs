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
public class WeaponMasterSelectWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private GameObject _oWeapon4;

	private GameObject _oWeapon5;

	private GameObject _oImage1;

	private GameObject _oImage2;

	private GameObject _oImage3;

	private GameObject _oImage4;

	private GameObject _oImage5;

	private Image _oImageImage1;

	private Image _oImageImage2;

	private Image _oImageImage3;

	private Image _oImageImage4;

	private Image _oImageImage5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weaponmaster";

	private string _resourceAssetName = "WeaponMasterSelectWeapon";

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

	public bool WeaponShow1
	{
		get
		{
			if (_oWeapon1 != null)
			{
				return _oWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow1 != value && _oWeapon1 != null)
			{
				_oWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow2
	{
		get
		{
			if (_oWeapon2 != null)
			{
				return _oWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow2 != value && _oWeapon2 != null)
			{
				_oWeapon2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow3
	{
		get
		{
			if (_oWeapon3 != null)
			{
				return _oWeapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow3 != value && _oWeapon3 != null)
			{
				_oWeapon3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow4
	{
		get
		{
			if (_oWeapon4 != null)
			{
				return _oWeapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow4 != value && _oWeapon4 != null)
			{
				_oWeapon4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow5
	{
		get
		{
			if (_oWeapon5 != null)
			{
				return _oWeapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow5 != value && _oWeapon5 != null)
			{
				_oWeapon5.SetObjectActive(value);
			}
		}
	}

	public Sprite ImageSprite1
	{
		get
		{
			if (_oImageImage1 != null)
			{
				return _oImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite1 != value && _oImageImage1 != null)
			{
				_oImageImage1.sprite = value;
			}
		}
	}

	public Sprite ImageSprite2
	{
		get
		{
			if (_oImageImage2 != null)
			{
				return _oImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite2 != value && _oImageImage2 != null)
			{
				_oImageImage2.sprite = value;
			}
		}
	}

	public Sprite ImageSprite3
	{
		get
		{
			if (_oImageImage3 != null)
			{
				return _oImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite3 != value && _oImageImage3 != null)
			{
				_oImageImage3.sprite = value;
			}
		}
	}

	public Sprite ImageSprite4
	{
		get
		{
			if (_oImageImage4 != null)
			{
				return _oImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite4 != value && _oImageImage4 != null)
			{
				_oImageImage4.sprite = value;
			}
		}
	}

	public Sprite ImageSprite5
	{
		get
		{
			if (_oImageImage5 != null)
			{
				return _oImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite5 != value && _oImageImage5 != null)
			{
				_oImageImage5.sprite = value;
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
			case "Weapon1":
				_oWeapon1 = transform.gameObject;
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				break;
			case "Weapon4":
				_oWeapon4 = transform.gameObject;
				break;
			case "Weapon5":
				_oWeapon5 = transform.gameObject;
				break;
			case "Image1":
				_oImage1 = transform.gameObject;
				_oImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image2":
				_oImage2 = transform.gameObject;
				_oImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image3":
				_oImage3 = transform.gameObject;
				_oImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image4":
				_oImage4 = transform.gameObject;
				_oImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image5":
				_oImage5 = transform.gameObject;
				_oImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetWeaponShow(int index)
	{
		return index switch
		{
			1 => WeaponShow1, 
			2 => WeaponShow2, 
			3 => WeaponShow3, 
			4 => WeaponShow4, 
			5 => WeaponShow5, 
			_ => false, 
		};
	}

	public void SetWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponShow1 = value;
			break;
		case 2:
			WeaponShow2 = value;
			break;
		case 3:
			WeaponShow3 = value;
			break;
		case 4:
			WeaponShow4 = value;
			break;
		case 5:
			WeaponShow5 = value;
			break;
		}
	}

	public Sprite GetImageSprite(int index)
	{
		return index switch
		{
			1 => ImageSprite1, 
			2 => ImageSprite2, 
			3 => ImageSprite3, 
			4 => ImageSprite4, 
			5 => ImageSprite5, 
			_ => null, 
		};
	}

	public void SetImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ImageSprite1 = value;
			break;
		case 2:
			ImageSprite2 = value;
			break;
		case 3:
			ImageSprite3 = value;
			break;
		case 4:
			ImageSprite4 = value;
			break;
		case 5:
			ImageSprite5 = value;
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
