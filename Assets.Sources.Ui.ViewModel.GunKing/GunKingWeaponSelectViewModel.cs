using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GunKing;

[GameUiTest]
public class GunKingWeaponSelectViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _oWeaponItem1;

	private GameObject _oWeaponItem2;

	private GameObject _oWeaponItem3;

	private GameObject _oWeaponItem4;

	private GameObject _oWeaponItem5;

	private Image _oWeaponItemImage1;

	private Image _oWeaponItemImage2;

	private Image _oWeaponItemImage3;

	private Image _oWeaponItemImage4;

	private Image _oWeaponItemImage5;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private GameObject _oWeapon4;

	private GameObject _oWeapon5;

	private Image _oWeaponImage1;

	private Image _oWeaponImage2;

	private Image _oWeaponImage3;

	private Image _oWeaponImage4;

	private Image _oWeaponImage5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/gunking";

	private string _resourceAssetName = "GunKingWeaponSelect";

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

	public string TimeString
	{
		get
		{
			if (_oTimeText != null)
			{
				return _oTimeText.text;
			}
			return null;
		}
		set
		{
			if (TimeString != value && _oTimeText != null)
			{
				_oTimeText.text = value;
			}
		}
	}

	public bool WeaponItemShow1
	{
		get
		{
			if (_oWeaponItem1 != null)
			{
				return _oWeaponItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponItemShow1 != value && _oWeaponItem1 != null)
			{
				_oWeaponItem1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponItemShow2
	{
		get
		{
			if (_oWeaponItem2 != null)
			{
				return _oWeaponItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponItemShow2 != value && _oWeaponItem2 != null)
			{
				_oWeaponItem2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponItemShow3
	{
		get
		{
			if (_oWeaponItem3 != null)
			{
				return _oWeaponItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponItemShow3 != value && _oWeaponItem3 != null)
			{
				_oWeaponItem3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponItemShow4
	{
		get
		{
			if (_oWeaponItem4 != null)
			{
				return _oWeaponItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponItemShow4 != value && _oWeaponItem4 != null)
			{
				_oWeaponItem4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponItemShow5
	{
		get
		{
			if (_oWeaponItem5 != null)
			{
				return _oWeaponItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponItemShow5 != value && _oWeaponItem5 != null)
			{
				_oWeaponItem5.SetObjectActive(value);
			}
		}
	}

	public Sprite WeaponItemSprite1
	{
		get
		{
			if (_oWeaponItemImage1 != null)
			{
				return _oWeaponItemImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponItemSprite1 != value && _oWeaponItemImage1 != null)
			{
				_oWeaponItemImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponItemSprite2
	{
		get
		{
			if (_oWeaponItemImage2 != null)
			{
				return _oWeaponItemImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponItemSprite2 != value && _oWeaponItemImage2 != null)
			{
				_oWeaponItemImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponItemSprite3
	{
		get
		{
			if (_oWeaponItemImage3 != null)
			{
				return _oWeaponItemImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponItemSprite3 != value && _oWeaponItemImage3 != null)
			{
				_oWeaponItemImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponItemSprite4
	{
		get
		{
			if (_oWeaponItemImage4 != null)
			{
				return _oWeaponItemImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponItemSprite4 != value && _oWeaponItemImage4 != null)
			{
				_oWeaponItemImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponItemSprite5
	{
		get
		{
			if (_oWeaponItemImage5 != null)
			{
				return _oWeaponItemImage5.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponItemSprite5 != value && _oWeaponItemImage5 != null)
			{
				_oWeaponItemImage5.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite1
	{
		get
		{
			if (_oWeaponImage1 != null)
			{
				return _oWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite1 != value && _oWeaponImage1 != null)
			{
				_oWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite2
	{
		get
		{
			if (_oWeaponImage2 != null)
			{
				return _oWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite2 != value && _oWeaponImage2 != null)
			{
				_oWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite3
	{
		get
		{
			if (_oWeaponImage3 != null)
			{
				return _oWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite3 != value && _oWeaponImage3 != null)
			{
				_oWeaponImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite4
	{
		get
		{
			if (_oWeaponImage4 != null)
			{
				return _oWeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite4 != value && _oWeaponImage4 != null)
			{
				_oWeaponImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponSprite5
	{
		get
		{
			if (_oWeaponImage5 != null)
			{
				return _oWeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite5 != value && _oWeaponImage5 != null)
			{
				_oWeaponImage5.sprite = value;
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
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponItem1":
				_oWeaponItem1 = transform.gameObject;
				_oWeaponItemImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponItem2":
				_oWeaponItem2 = transform.gameObject;
				_oWeaponItemImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponItem3":
				_oWeaponItem3 = transform.gameObject;
				_oWeaponItemImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponItem4":
				_oWeaponItem4 = transform.gameObject;
				_oWeaponItemImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponItem5":
				_oWeaponItem5 = transform.gameObject;
				_oWeaponItemImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon1":
				_oWeapon1 = transform.gameObject;
				_oWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				_oWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				_oWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon4":
				_oWeapon4 = transform.gameObject;
				_oWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon5":
				_oWeapon5 = transform.gameObject;
				_oWeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetWeaponItemShow(int index)
	{
		return index switch
		{
			1 => WeaponItemShow1, 
			2 => WeaponItemShow2, 
			3 => WeaponItemShow3, 
			4 => WeaponItemShow4, 
			5 => WeaponItemShow5, 
			_ => false, 
		};
	}

	public void SetWeaponItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponItemShow1 = value;
			break;
		case 2:
			WeaponItemShow2 = value;
			break;
		case 3:
			WeaponItemShow3 = value;
			break;
		case 4:
			WeaponItemShow4 = value;
			break;
		case 5:
			WeaponItemShow5 = value;
			break;
		}
	}

	public Sprite GetWeaponItemSprite(int index)
	{
		return index switch
		{
			1 => WeaponItemSprite1, 
			2 => WeaponItemSprite2, 
			3 => WeaponItemSprite3, 
			4 => WeaponItemSprite4, 
			5 => WeaponItemSprite5, 
			_ => null, 
		};
	}

	public void SetWeaponItemSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponItemSprite1 = value;
			break;
		case 2:
			WeaponItemSprite2 = value;
			break;
		case 3:
			WeaponItemSprite3 = value;
			break;
		case 4:
			WeaponItemSprite4 = value;
			break;
		case 5:
			WeaponItemSprite5 = value;
			break;
		}
	}

	public Sprite GetWeaponSprite(int index)
	{
		return index switch
		{
			1 => WeaponSprite1, 
			2 => WeaponSprite2, 
			3 => WeaponSprite3, 
			4 => WeaponSprite4, 
			5 => WeaponSprite5, 
			_ => null, 
		};
	}

	public void SetWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponSprite1 = value;
			break;
		case 2:
			WeaponSprite2 = value;
			break;
		case 3:
			WeaponSprite3 = value;
			break;
		case 4:
			WeaponSprite4 = value;
			break;
		case 5:
			WeaponSprite5 = value;
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
