using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class PhotonDeformationViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImageBG;

	private Image _oImageBGImage;

	private GameObject _oPart1;

	private GameObject _oPart2;

	private GameObject _oPart3;

	private GameObject _oPart4;

	private Image _oPartImage1;

	private Image _oPartImage2;

	private Image _oPartImage3;

	private Image _oPartImage4;

	private EventTrigger _oPartEventTrigger1;

	private EventTrigger _oPartEventTrigger2;

	private EventTrigger _oPartEventTrigger3;

	private EventTrigger _oPartEventTrigger4;

	private GameObject _oSelectedIcon1;

	private GameObject _oSelectedIcon2;

	private GameObject _oSelectedIcon3;

	private GameObject _oSelectedIcon4;

	private Image _oSelectedIconImage1;

	private Image _oSelectedIconImage2;

	private Image _oSelectedIconImage3;

	private Image _oSelectedIconImage4;

	private GameObject _oWeaponIcon1;

	private GameObject _oWeaponIcon2;

	private GameObject _oWeaponIcon3;

	private GameObject _oWeaponIcon4;

	private Image _oWeaponIconImage1;

	private Image _oWeaponIconImage2;

	private Image _oWeaponIconImage3;

	private Image _oWeaponIconImage4;

	private GameObject _oForbidIcon1;

	private GameObject _oForbidIcon2;

	private GameObject _oForbidIcon3;

	private GameObject _oForbidIcon4;

	private Image _oForbidIconImage1;

	private Image _oForbidIconImage2;

	private Image _oForbidIconImage3;

	private Image _oForbidIconImage4;

	private GameObject _oPartType1;

	private GameObject _oPartType2;

	private GameObject _oPartType3;

	private GameObject _oPartType4;

	private Image _oPartTypeImage1;

	private Image _oPartTypeImage2;

	private Image _oPartTypeImage3;

	private Image _oPartTypeImage4;

	private GameObject _oWeaponName;

	private Image _oWeaponNameImage;

	private GameObject _oWeaponImage;

	private Image _oWeaponImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "PhotonDeformation";

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

	public Sprite ImageBGSprite
	{
		get
		{
			if (_oImageBGImage != null)
			{
				return _oImageBGImage.sprite;
			}
			return null;
		}
		set
		{
			if (ImageBGSprite != value && _oImageBGImage != null)
			{
				_oImageBGImage.sprite = value;
			}
		}
	}

	public GameObject PartObj1 => _oPart1;

	public GameObject PartObj2 => _oPart2;

	public GameObject PartObj3 => _oPart3;

	public GameObject PartObj4 => _oPart4;

	public Sprite PartSprite1
	{
		get
		{
			if (_oPartImage1 != null)
			{
				return _oPartImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PartSprite1 != value && _oPartImage1 != null)
			{
				_oPartImage1.sprite = value;
			}
		}
	}

	public Sprite PartSprite2
	{
		get
		{
			if (_oPartImage2 != null)
			{
				return _oPartImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PartSprite2 != value && _oPartImage2 != null)
			{
				_oPartImage2.sprite = value;
			}
		}
	}

	public Sprite PartSprite3
	{
		get
		{
			if (_oPartImage3 != null)
			{
				return _oPartImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PartSprite3 != value && _oPartImage3 != null)
			{
				_oPartImage3.sprite = value;
			}
		}
	}

	public Sprite PartSprite4
	{
		get
		{
			if (_oPartImage4 != null)
			{
				return _oPartImage4.sprite;
			}
			return null;
		}
		set
		{
			if (PartSprite4 != value && _oPartImage4 != null)
			{
				_oPartImage4.sprite = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers1
	{
		get
		{
			if (_oPartEventTrigger1 != null)
			{
				return _oPartEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers1 != value && _oPartEventTrigger1 != null)
			{
				_oPartEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers2
	{
		get
		{
			if (_oPartEventTrigger2 != null)
			{
				return _oPartEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers2 != value && _oPartEventTrigger2 != null)
			{
				_oPartEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers3
	{
		get
		{
			if (_oPartEventTrigger3 != null)
			{
				return _oPartEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers3 != value && _oPartEventTrigger3 != null)
			{
				_oPartEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PartTriggers4
	{
		get
		{
			if (_oPartEventTrigger4 != null)
			{
				return _oPartEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (PartTriggers4 != value && _oPartEventTrigger4 != null)
			{
				_oPartEventTrigger4.triggers = value;
			}
		}
	}

	public GameObject SelectedIconObj1 => _oSelectedIcon1;

	public GameObject SelectedIconObj2 => _oSelectedIcon2;

	public GameObject SelectedIconObj3 => _oSelectedIcon3;

	public GameObject SelectedIconObj4 => _oSelectedIcon4;

	public bool SelectedIconShow1
	{
		get
		{
			if (_oSelectedIcon1 != null)
			{
				return _oSelectedIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow1 != value && _oSelectedIcon1 != null)
			{
				_oSelectedIcon1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow2
	{
		get
		{
			if (_oSelectedIcon2 != null)
			{
				return _oSelectedIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow2 != value && _oSelectedIcon2 != null)
			{
				_oSelectedIcon2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow3
	{
		get
		{
			if (_oSelectedIcon3 != null)
			{
				return _oSelectedIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow3 != value && _oSelectedIcon3 != null)
			{
				_oSelectedIcon3.SetObjectActive(value);
			}
		}
	}

	public bool SelectedIconShow4
	{
		get
		{
			if (_oSelectedIcon4 != null)
			{
				return _oSelectedIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedIconShow4 != value && _oSelectedIcon4 != null)
			{
				_oSelectedIcon4.SetObjectActive(value);
			}
		}
	}

	public Sprite SelectedIconSprite1
	{
		get
		{
			if (_oSelectedIconImage1 != null)
			{
				return _oSelectedIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SelectedIconSprite1 != value && _oSelectedIconImage1 != null)
			{
				_oSelectedIconImage1.sprite = value;
			}
		}
	}

	public Sprite SelectedIconSprite2
	{
		get
		{
			if (_oSelectedIconImage2 != null)
			{
				return _oSelectedIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SelectedIconSprite2 != value && _oSelectedIconImage2 != null)
			{
				_oSelectedIconImage2.sprite = value;
			}
		}
	}

	public Sprite SelectedIconSprite3
	{
		get
		{
			if (_oSelectedIconImage3 != null)
			{
				return _oSelectedIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SelectedIconSprite3 != value && _oSelectedIconImage3 != null)
			{
				_oSelectedIconImage3.sprite = value;
			}
		}
	}

	public Sprite SelectedIconSprite4
	{
		get
		{
			if (_oSelectedIconImage4 != null)
			{
				return _oSelectedIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SelectedIconSprite4 != value && _oSelectedIconImage4 != null)
			{
				_oSelectedIconImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite1
	{
		get
		{
			if (_oWeaponIconImage1 != null)
			{
				return _oWeaponIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite1 != value && _oWeaponIconImage1 != null)
			{
				_oWeaponIconImage1.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite2
	{
		get
		{
			if (_oWeaponIconImage2 != null)
			{
				return _oWeaponIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite2 != value && _oWeaponIconImage2 != null)
			{
				_oWeaponIconImage2.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite3
	{
		get
		{
			if (_oWeaponIconImage3 != null)
			{
				return _oWeaponIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite3 != value && _oWeaponIconImage3 != null)
			{
				_oWeaponIconImage3.sprite = value;
			}
		}
	}

	public Sprite WeaponIconSprite4
	{
		get
		{
			if (_oWeaponIconImage4 != null)
			{
				return _oWeaponIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponIconSprite4 != value && _oWeaponIconImage4 != null)
			{
				_oWeaponIconImage4.sprite = value;
			}
		}
	}

	public bool ForbidIconShow1
	{
		get
		{
			if (_oForbidIcon1 != null)
			{
				return _oForbidIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow1 != value && _oForbidIcon1 != null)
			{
				_oForbidIcon1.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow2
	{
		get
		{
			if (_oForbidIcon2 != null)
			{
				return _oForbidIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow2 != value && _oForbidIcon2 != null)
			{
				_oForbidIcon2.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow3
	{
		get
		{
			if (_oForbidIcon3 != null)
			{
				return _oForbidIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow3 != value && _oForbidIcon3 != null)
			{
				_oForbidIcon3.SetObjectActive(value);
			}
		}
	}

	public bool ForbidIconShow4
	{
		get
		{
			if (_oForbidIcon4 != null)
			{
				return _oForbidIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ForbidIconShow4 != value && _oForbidIcon4 != null)
			{
				_oForbidIcon4.SetObjectActive(value);
			}
		}
	}

	public Sprite ForbidIconSprite1
	{
		get
		{
			if (_oForbidIconImage1 != null)
			{
				return _oForbidIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ForbidIconSprite1 != value && _oForbidIconImage1 != null)
			{
				_oForbidIconImage1.sprite = value;
			}
		}
	}

	public Sprite ForbidIconSprite2
	{
		get
		{
			if (_oForbidIconImage2 != null)
			{
				return _oForbidIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ForbidIconSprite2 != value && _oForbidIconImage2 != null)
			{
				_oForbidIconImage2.sprite = value;
			}
		}
	}

	public Sprite ForbidIconSprite3
	{
		get
		{
			if (_oForbidIconImage3 != null)
			{
				return _oForbidIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ForbidIconSprite3 != value && _oForbidIconImage3 != null)
			{
				_oForbidIconImage3.sprite = value;
			}
		}
	}

	public Sprite ForbidIconSprite4
	{
		get
		{
			if (_oForbidIconImage4 != null)
			{
				return _oForbidIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ForbidIconSprite4 != value && _oForbidIconImage4 != null)
			{
				_oForbidIconImage4.sprite = value;
			}
		}
	}

	public Sprite PartTypeSprite1
	{
		get
		{
			if (_oPartTypeImage1 != null)
			{
				return _oPartTypeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PartTypeSprite1 != value && _oPartTypeImage1 != null)
			{
				_oPartTypeImage1.sprite = value;
			}
		}
	}

	public Sprite PartTypeSprite2
	{
		get
		{
			if (_oPartTypeImage2 != null)
			{
				return _oPartTypeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PartTypeSprite2 != value && _oPartTypeImage2 != null)
			{
				_oPartTypeImage2.sprite = value;
			}
		}
	}

	public Sprite PartTypeSprite3
	{
		get
		{
			if (_oPartTypeImage3 != null)
			{
				return _oPartTypeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PartTypeSprite3 != value && _oPartTypeImage3 != null)
			{
				_oPartTypeImage3.sprite = value;
			}
		}
	}

	public Sprite PartTypeSprite4
	{
		get
		{
			if (_oPartTypeImage4 != null)
			{
				return _oPartTypeImage4.sprite;
			}
			return null;
		}
		set
		{
			if (PartTypeSprite4 != value && _oPartTypeImage4 != null)
			{
				_oPartTypeImage4.sprite = value;
			}
		}
	}

	public Sprite WeaponNameSprite
	{
		get
		{
			if (_oWeaponNameImage != null)
			{
				return _oWeaponNameImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponNameSprite != value && _oWeaponNameImage != null)
			{
				_oWeaponNameImage.sprite = value;
			}
		}
	}

	public Sprite WeaponImageSprite
	{
		get
		{
			if (_oWeaponImageImage != null)
			{
				return _oWeaponImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponImageSprite != value && _oWeaponImageImage != null)
			{
				_oWeaponImageImage.sprite = value;
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
			case "ImageBG":
				_oImageBG = transform.gameObject;
				_oImageBGImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Part1":
				_oPart1 = transform.gameObject;
				_oPartImage1 = transform.gameObject.GetComponent<Image>();
				_oPartEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part2":
				_oPart2 = transform.gameObject;
				_oPartImage2 = transform.gameObject.GetComponent<Image>();
				_oPartEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part3":
				_oPart3 = transform.gameObject;
				_oPartImage3 = transform.gameObject.GetComponent<Image>();
				_oPartEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Part4":
				_oPart4 = transform.gameObject;
				_oPartImage4 = transform.gameObject.GetComponent<Image>();
				_oPartEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "SelectedIcon1":
				_oSelectedIcon1 = transform.gameObject;
				_oSelectedIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectedIcon2":
				_oSelectedIcon2 = transform.gameObject;
				_oSelectedIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectedIcon3":
				_oSelectedIcon3 = transform.gameObject;
				_oSelectedIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectedIcon4":
				_oSelectedIcon4 = transform.gameObject;
				_oSelectedIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon1":
				_oWeaponIcon1 = transform.gameObject;
				_oWeaponIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon2":
				_oWeaponIcon2 = transform.gameObject;
				_oWeaponIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon3":
				_oWeaponIcon3 = transform.gameObject;
				_oWeaponIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponIcon4":
				_oWeaponIcon4 = transform.gameObject;
				_oWeaponIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "ForbidIcon1":
				_oForbidIcon1 = transform.gameObject;
				_oForbidIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "ForbidIcon2":
				_oForbidIcon2 = transform.gameObject;
				_oForbidIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "ForbidIcon3":
				_oForbidIcon3 = transform.gameObject;
				_oForbidIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "ForbidIcon4":
				_oForbidIcon4 = transform.gameObject;
				_oForbidIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "PartType1":
				_oPartType1 = transform.gameObject;
				_oPartTypeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "PartType2":
				_oPartType2 = transform.gameObject;
				_oPartTypeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "PartType3":
				_oPartType3 = transform.gameObject;
				_oPartTypeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "PartType4":
				_oPartType4 = transform.gameObject;
				_oPartTypeImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponName":
				_oWeaponName = transform.gameObject;
				_oWeaponNameImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponImage":
				_oWeaponImage = transform.gameObject;
				_oWeaponImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public GameObject GetPartObj(int index)
	{
		return index switch
		{
			1 => PartObj1, 
			2 => PartObj2, 
			3 => PartObj3, 
			4 => PartObj4, 
			_ => null, 
		};
	}

	public Sprite GetPartSprite(int index)
	{
		return index switch
		{
			1 => PartSprite1, 
			2 => PartSprite2, 
			3 => PartSprite3, 
			4 => PartSprite4, 
			_ => null, 
		};
	}

	public void SetPartSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PartSprite1 = value;
			break;
		case 2:
			PartSprite2 = value;
			break;
		case 3:
			PartSprite3 = value;
			break;
		case 4:
			PartSprite4 = value;
			break;
		}
	}

	public List<EventTrigger.Entry> GetPartTriggers(int index)
	{
		return index switch
		{
			1 => PartTriggers1, 
			2 => PartTriggers2, 
			3 => PartTriggers3, 
			4 => PartTriggers4, 
			_ => null, 
		};
	}

	public void SetPartTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			PartTriggers1 = value;
			break;
		case 2:
			PartTriggers2 = value;
			break;
		case 3:
			PartTriggers3 = value;
			break;
		case 4:
			PartTriggers4 = value;
			break;
		}
	}

	public GameObject GetSelectedIconObj(int index)
	{
		return index switch
		{
			1 => SelectedIconObj1, 
			2 => SelectedIconObj2, 
			3 => SelectedIconObj3, 
			4 => SelectedIconObj4, 
			_ => null, 
		};
	}

	public bool GetSelectedIconShow(int index)
	{
		return index switch
		{
			1 => SelectedIconShow1, 
			2 => SelectedIconShow2, 
			3 => SelectedIconShow3, 
			4 => SelectedIconShow4, 
			_ => false, 
		};
	}

	public void SetSelectedIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedIconShow1 = value;
			break;
		case 2:
			SelectedIconShow2 = value;
			break;
		case 3:
			SelectedIconShow3 = value;
			break;
		case 4:
			SelectedIconShow4 = value;
			break;
		}
	}

	public Sprite GetSelectedIconSprite(int index)
	{
		return index switch
		{
			1 => SelectedIconSprite1, 
			2 => SelectedIconSprite2, 
			3 => SelectedIconSprite3, 
			4 => SelectedIconSprite4, 
			_ => null, 
		};
	}

	public void SetSelectedIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SelectedIconSprite1 = value;
			break;
		case 2:
			SelectedIconSprite2 = value;
			break;
		case 3:
			SelectedIconSprite3 = value;
			break;
		case 4:
			SelectedIconSprite4 = value;
			break;
		}
	}

	public Sprite GetWeaponIconSprite(int index)
	{
		return index switch
		{
			1 => WeaponIconSprite1, 
			2 => WeaponIconSprite2, 
			3 => WeaponIconSprite3, 
			4 => WeaponIconSprite4, 
			_ => null, 
		};
	}

	public void SetWeaponIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeaponIconSprite1 = value;
			break;
		case 2:
			WeaponIconSprite2 = value;
			break;
		case 3:
			WeaponIconSprite3 = value;
			break;
		case 4:
			WeaponIconSprite4 = value;
			break;
		}
	}

	public bool GetForbidIconShow(int index)
	{
		return index switch
		{
			1 => ForbidIconShow1, 
			2 => ForbidIconShow2, 
			3 => ForbidIconShow3, 
			4 => ForbidIconShow4, 
			_ => false, 
		};
	}

	public void SetForbidIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ForbidIconShow1 = value;
			break;
		case 2:
			ForbidIconShow2 = value;
			break;
		case 3:
			ForbidIconShow3 = value;
			break;
		case 4:
			ForbidIconShow4 = value;
			break;
		}
	}

	public Sprite GetForbidIconSprite(int index)
	{
		return index switch
		{
			1 => ForbidIconSprite1, 
			2 => ForbidIconSprite2, 
			3 => ForbidIconSprite3, 
			4 => ForbidIconSprite4, 
			_ => null, 
		};
	}

	public void SetForbidIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ForbidIconSprite1 = value;
			break;
		case 2:
			ForbidIconSprite2 = value;
			break;
		case 3:
			ForbidIconSprite3 = value;
			break;
		case 4:
			ForbidIconSprite4 = value;
			break;
		}
	}

	public Sprite GetPartTypeSprite(int index)
	{
		return index switch
		{
			1 => PartTypeSprite1, 
			2 => PartTypeSprite2, 
			3 => PartTypeSprite3, 
			4 => PartTypeSprite4, 
			_ => null, 
		};
	}

	public void SetPartTypeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PartTypeSprite1 = value;
			break;
		case 2:
			PartTypeSprite2 = value;
			break;
		case 3:
			PartTypeSprite3 = value;
			break;
		case 4:
			PartTypeSprite4 = value;
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
