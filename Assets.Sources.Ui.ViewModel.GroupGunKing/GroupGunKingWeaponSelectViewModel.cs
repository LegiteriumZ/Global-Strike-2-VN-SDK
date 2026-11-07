using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GroupGunKing;

[GameUiTest]
public class GroupGunKingWeaponSelectViewModel : ViewModelBase, IUiViewModel
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

	private RectTransform _oWeaponRectTransform1;

	private RectTransform _oWeaponRectTransform2;

	private RectTransform _oWeaponRectTransform3;

	private RectTransform _oWeaponRectTransform4;

	private RectTransform _oWeaponRectTransform5;

	private Image _oWeaponImage1;

	private Image _oWeaponImage2;

	private Image _oWeaponImage3;

	private Image _oWeaponImage4;

	private Image _oWeaponImage5;

	private GameObject _oSecondWeaponItem1;

	private GameObject _oSecondWeaponItem2;

	private GameObject _oSecondWeaponItem3;

	private GameObject _oSecondWeaponItem4;

	private GameObject _oSecondWeaponItem5;

	private GameObject _oSecondWeapon1;

	private GameObject _oSecondWeapon2;

	private GameObject _oSecondWeapon3;

	private GameObject _oSecondWeapon4;

	private GameObject _oSecondWeapon5;

	private RectTransform _oSecondWeaponRectTransform1;

	private RectTransform _oSecondWeaponRectTransform2;

	private RectTransform _oSecondWeaponRectTransform3;

	private RectTransform _oSecondWeaponRectTransform4;

	private RectTransform _oSecondWeaponRectTransform5;

	private Image _oSecondWeaponImage1;

	private Image _oSecondWeaponImage2;

	private Image _oSecondWeaponImage3;

	private Image _oSecondWeaponImage4;

	private Image _oSecondWeaponImage5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/groupgunking";

	private string _resourceAssetName = "GroupGunKingWeaponSelect";

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

	public Vector3 WeaponPosition1
	{
		get
		{
			if (_oWeaponRectTransform1 != null)
			{
				return _oWeaponRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponPosition1 != value && _oWeaponRectTransform1 != null)
			{
				_oWeaponRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 WeaponPosition2
	{
		get
		{
			if (_oWeaponRectTransform2 != null)
			{
				return _oWeaponRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponPosition2 != value && _oWeaponRectTransform2 != null)
			{
				_oWeaponRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 WeaponPosition3
	{
		get
		{
			if (_oWeaponRectTransform3 != null)
			{
				return _oWeaponRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponPosition3 != value && _oWeaponRectTransform3 != null)
			{
				_oWeaponRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 WeaponPosition4
	{
		get
		{
			if (_oWeaponRectTransform4 != null)
			{
				return _oWeaponRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponPosition4 != value && _oWeaponRectTransform4 != null)
			{
				_oWeaponRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 WeaponPosition5
	{
		get
		{
			if (_oWeaponRectTransform5 != null)
			{
				return _oWeaponRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponPosition5 != value && _oWeaponRectTransform5 != null)
			{
				_oWeaponRectTransform5.localPosition = value;
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

	public bool SecondWeaponItemShow1
	{
		get
		{
			if (_oSecondWeaponItem1 != null)
			{
				return _oSecondWeaponItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondWeaponItemShow1 != value && _oSecondWeaponItem1 != null)
			{
				_oSecondWeaponItem1.SetObjectActive(value);
			}
		}
	}

	public bool SecondWeaponItemShow2
	{
		get
		{
			if (_oSecondWeaponItem2 != null)
			{
				return _oSecondWeaponItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondWeaponItemShow2 != value && _oSecondWeaponItem2 != null)
			{
				_oSecondWeaponItem2.SetObjectActive(value);
			}
		}
	}

	public bool SecondWeaponItemShow3
	{
		get
		{
			if (_oSecondWeaponItem3 != null)
			{
				return _oSecondWeaponItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondWeaponItemShow3 != value && _oSecondWeaponItem3 != null)
			{
				_oSecondWeaponItem3.SetObjectActive(value);
			}
		}
	}

	public bool SecondWeaponItemShow4
	{
		get
		{
			if (_oSecondWeaponItem4 != null)
			{
				return _oSecondWeaponItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondWeaponItemShow4 != value && _oSecondWeaponItem4 != null)
			{
				_oSecondWeaponItem4.SetObjectActive(value);
			}
		}
	}

	public bool SecondWeaponItemShow5
	{
		get
		{
			if (_oSecondWeaponItem5 != null)
			{
				return _oSecondWeaponItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondWeaponItemShow5 != value && _oSecondWeaponItem5 != null)
			{
				_oSecondWeaponItem5.SetObjectActive(value);
			}
		}
	}

	public Vector3 SecondWeaponPosition1
	{
		get
		{
			if (_oSecondWeaponRectTransform1 != null)
			{
				return _oSecondWeaponRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SecondWeaponPosition1 != value && _oSecondWeaponRectTransform1 != null)
			{
				_oSecondWeaponRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 SecondWeaponPosition2
	{
		get
		{
			if (_oSecondWeaponRectTransform2 != null)
			{
				return _oSecondWeaponRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SecondWeaponPosition2 != value && _oSecondWeaponRectTransform2 != null)
			{
				_oSecondWeaponRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 SecondWeaponPosition3
	{
		get
		{
			if (_oSecondWeaponRectTransform3 != null)
			{
				return _oSecondWeaponRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SecondWeaponPosition3 != value && _oSecondWeaponRectTransform3 != null)
			{
				_oSecondWeaponRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 SecondWeaponPosition4
	{
		get
		{
			if (_oSecondWeaponRectTransform4 != null)
			{
				return _oSecondWeaponRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SecondWeaponPosition4 != value && _oSecondWeaponRectTransform4 != null)
			{
				_oSecondWeaponRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 SecondWeaponPosition5
	{
		get
		{
			if (_oSecondWeaponRectTransform5 != null)
			{
				return _oSecondWeaponRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SecondWeaponPosition5 != value && _oSecondWeaponRectTransform5 != null)
			{
				_oSecondWeaponRectTransform5.localPosition = value;
			}
		}
	}

	public Sprite SecondWeaponSprite1
	{
		get
		{
			if (_oSecondWeaponImage1 != null)
			{
				return _oSecondWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SecondWeaponSprite1 != value && _oSecondWeaponImage1 != null)
			{
				_oSecondWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite SecondWeaponSprite2
	{
		get
		{
			if (_oSecondWeaponImage2 != null)
			{
				return _oSecondWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SecondWeaponSprite2 != value && _oSecondWeaponImage2 != null)
			{
				_oSecondWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite SecondWeaponSprite3
	{
		get
		{
			if (_oSecondWeaponImage3 != null)
			{
				return _oSecondWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SecondWeaponSprite3 != value && _oSecondWeaponImage3 != null)
			{
				_oSecondWeaponImage3.sprite = value;
			}
		}
	}

	public Sprite SecondWeaponSprite4
	{
		get
		{
			if (_oSecondWeaponImage4 != null)
			{
				return _oSecondWeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SecondWeaponSprite4 != value && _oSecondWeaponImage4 != null)
			{
				_oSecondWeaponImage4.sprite = value;
			}
		}
	}

	public Sprite SecondWeaponSprite5
	{
		get
		{
			if (_oSecondWeaponImage5 != null)
			{
				return _oSecondWeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SecondWeaponSprite5 != value && _oSecondWeaponImage5 != null)
			{
				_oSecondWeaponImage5.sprite = value;
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
				_oWeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon2":
				_oWeapon2 = transform.gameObject;
				_oWeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon3":
				_oWeapon3 = transform.gameObject;
				_oWeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon4":
				_oWeapon4 = transform.gameObject;
				_oWeaponRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon5":
				_oWeapon5 = transform.gameObject;
				_oWeaponRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondWeaponItem1":
				_oSecondWeaponItem1 = transform.gameObject;
				break;
			case "SecondWeaponItem2":
				_oSecondWeaponItem2 = transform.gameObject;
				break;
			case "SecondWeaponItem3":
				_oSecondWeaponItem3 = transform.gameObject;
				break;
			case "SecondWeaponItem4":
				_oSecondWeaponItem4 = transform.gameObject;
				break;
			case "SecondWeaponItem5":
				_oSecondWeaponItem5 = transform.gameObject;
				break;
			case "SecondWeapon1":
				_oSecondWeapon1 = transform.gameObject;
				_oSecondWeaponRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oSecondWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondWeapon2":
				_oSecondWeapon2 = transform.gameObject;
				_oSecondWeaponRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oSecondWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondWeapon3":
				_oSecondWeapon3 = transform.gameObject;
				_oSecondWeaponRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oSecondWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondWeapon4":
				_oSecondWeapon4 = transform.gameObject;
				_oSecondWeaponRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oSecondWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SecondWeapon5":
				_oSecondWeapon5 = transform.gameObject;
				_oSecondWeaponRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oSecondWeaponImage5 = transform.gameObject.GetComponent<Image>();
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

	public Vector3 GetWeaponPosition(int index)
	{
		return index switch
		{
			1 => WeaponPosition1, 
			2 => WeaponPosition2, 
			3 => WeaponPosition3, 
			4 => WeaponPosition4, 
			5 => WeaponPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetWeaponPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			WeaponPosition1 = value;
			break;
		case 2:
			WeaponPosition2 = value;
			break;
		case 3:
			WeaponPosition3 = value;
			break;
		case 4:
			WeaponPosition4 = value;
			break;
		case 5:
			WeaponPosition5 = value;
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

	public bool GetSecondWeaponItemShow(int index)
	{
		return index switch
		{
			1 => SecondWeaponItemShow1, 
			2 => SecondWeaponItemShow2, 
			3 => SecondWeaponItemShow3, 
			4 => SecondWeaponItemShow4, 
			5 => SecondWeaponItemShow5, 
			_ => false, 
		};
	}

	public void SetSecondWeaponItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SecondWeaponItemShow1 = value;
			break;
		case 2:
			SecondWeaponItemShow2 = value;
			break;
		case 3:
			SecondWeaponItemShow3 = value;
			break;
		case 4:
			SecondWeaponItemShow4 = value;
			break;
		case 5:
			SecondWeaponItemShow5 = value;
			break;
		}
	}

	public Vector3 GetSecondWeaponPosition(int index)
	{
		return index switch
		{
			1 => SecondWeaponPosition1, 
			2 => SecondWeaponPosition2, 
			3 => SecondWeaponPosition3, 
			4 => SecondWeaponPosition4, 
			5 => SecondWeaponPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetSecondWeaponPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			SecondWeaponPosition1 = value;
			break;
		case 2:
			SecondWeaponPosition2 = value;
			break;
		case 3:
			SecondWeaponPosition3 = value;
			break;
		case 4:
			SecondWeaponPosition4 = value;
			break;
		case 5:
			SecondWeaponPosition5 = value;
			break;
		}
	}

	public Sprite GetSecondWeaponSprite(int index)
	{
		return index switch
		{
			1 => SecondWeaponSprite1, 
			2 => SecondWeaponSprite2, 
			3 => SecondWeaponSprite3, 
			4 => SecondWeaponSprite4, 
			5 => SecondWeaponSprite5, 
			_ => null, 
		};
	}

	public void SetSecondWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SecondWeaponSprite1 = value;
			break;
		case 2:
			SecondWeaponSprite2 = value;
			break;
		case 3:
			SecondWeaponSprite3 = value;
			break;
		case 4:
			SecondWeaponSprite4 = value;
			break;
		case 5:
			SecondWeaponSprite5 = value;
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
