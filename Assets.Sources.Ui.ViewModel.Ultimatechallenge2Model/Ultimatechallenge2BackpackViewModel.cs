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

namespace Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2BackpackViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oarmorInfo_icon;

	private Image _oarmorInfo_iconImage;

	private GameObject _oarmorInfo_red;

	private GameObject _ohelmetInfo_icon;

	private Image _ohelmetInfo_iconImage;

	private GameObject _ohelmetInfo_red;

	private GameObject _ohpInfo_icon_1;

	private GameObject _ohpInfo_icon_2;

	private GameObject _ohpInfo_icon_3;

	private Image _ohpInfo_icon_Image1;

	private Image _ohpInfo_icon_Image2;

	private Image _ohpInfo_icon_Image3;

	private GameObject _ohpInfo_num_1;

	private GameObject _ohpInfo_num_2;

	private GameObject _ohpInfo_num_3;

	private Text _ohpInfo_num_Text1;

	private Text _ohpInfo_num_Text2;

	private Text _ohpInfo_num_Text3;

	private GameObject _oskill;

	private GameObject _oButton1;

	private GameObject _oButton2;

	private GameObject _oButton3;

	private GameObject _oButton4;

	private GameObject _oButton5;

	private GameObject _oButton6;

	private EventTrigger _oButtonEventTrigger1;

	private EventTrigger _oButtonEventTrigger2;

	private EventTrigger _oButtonEventTrigger3;

	private EventTrigger _oButtonEventTrigger4;

	private EventTrigger _oButtonEventTrigger5;

	private EventTrigger _oButtonEventTrigger6;

	private GameObject _oselect1;

	private GameObject _oselect2;

	private GameObject _oselect3;

	private GameObject _oselect4;

	private GameObject _oselect5;

	private GameObject _oselect6;

	private GameObject _obackpack;

	private GameObject _oRect_weapon1;

	private GameObject _oRect_weapon2;

	private GameObject _oRect_weapon3;

	private GameObject _oRect_weapon4;

	private GameObject _oRect_weapon5;

	private GameObject _oBullet_weapon1;

	private GameObject _oBullet_weapon2;

	private Text _oBullet_weaponText1;

	private Text _oBullet_weaponText2;

	private GameObject _oName_weapon1;

	private GameObject _oName_weapon2;

	private GameObject _oName_weapon3;

	private GameObject _oName_weapon4;

	private GameObject _oName_weapon5;

	private Text _oName_weaponText1;

	private Text _oName_weaponText2;

	private Text _oName_weaponText3;

	private Text _oName_weaponText4;

	private Text _oName_weaponText5;

	private GameObject _oWeapon_Icon1;

	private GameObject _oWeapon_Icon2;

	private GameObject _oWeapon_Icon3;

	private GameObject _oWeapon_Icon4;

	private GameObject _oWeapon_Icon5;

	private Image _oWeapon_IconImage1;

	private Image _oWeapon_IconImage2;

	private Image _oWeapon_IconImage3;

	private Image _oWeapon_IconImage4;

	private Image _oWeapon_IconImage5;

	private GameObject _obag_Icon;

	private Image _obag_IconImage;

	private GameObject _obag_size_max;

	private Image _obag_size_maxImage;

	private GameObject _obag_size;

	private Image _obag_sizeImage;

	private GameObject _oScrollView_Nearby;

	private GameObject _oContent_Nearby;

	private GameObject _oScrollView_BackPack;

	private GameObject _oContent_BackPack;

	private GameObject _odefault_size;

	private Text _odefault_sizeText;

	private GameObject _oinventory_default_item;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge2model";

	private string _resourceAssetName = "ultimatechallenge2backpack";

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

	public GameObject PanelObj => _oPanel;

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

	public bool armorInfo_iconShow
	{
		get
		{
			if (_oarmorInfo_icon != null)
			{
				return _oarmorInfo_icon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (armorInfo_iconShow != value && _oarmorInfo_icon != null)
			{
				_oarmorInfo_icon.SetObjectActive(value);
			}
		}
	}

	public Sprite armorInfo_iconSprite
	{
		get
		{
			if (_oarmorInfo_iconImage != null)
			{
				return _oarmorInfo_iconImage.sprite;
			}
			return null;
		}
		set
		{
			if (armorInfo_iconSprite != value && _oarmorInfo_iconImage != null)
			{
				_oarmorInfo_iconImage.sprite = value;
			}
		}
	}

	public bool armorInfo_redShow
	{
		get
		{
			if (_oarmorInfo_red != null)
			{
				return _oarmorInfo_red.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (armorInfo_redShow != value && _oarmorInfo_red != null)
			{
				_oarmorInfo_red.SetObjectActive(value);
			}
		}
	}

	public bool helmetInfo_iconShow
	{
		get
		{
			if (_ohelmetInfo_icon != null)
			{
				return _ohelmetInfo_icon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (helmetInfo_iconShow != value && _ohelmetInfo_icon != null)
			{
				_ohelmetInfo_icon.SetObjectActive(value);
			}
		}
	}

	public Sprite helmetInfo_iconSprite
	{
		get
		{
			if (_ohelmetInfo_iconImage != null)
			{
				return _ohelmetInfo_iconImage.sprite;
			}
			return null;
		}
		set
		{
			if (helmetInfo_iconSprite != value && _ohelmetInfo_iconImage != null)
			{
				_ohelmetInfo_iconImage.sprite = value;
			}
		}
	}

	public bool helmetInfo_redShow
	{
		get
		{
			if (_ohelmetInfo_red != null)
			{
				return _ohelmetInfo_red.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (helmetInfo_redShow != value && _ohelmetInfo_red != null)
			{
				_ohelmetInfo_red.SetObjectActive(value);
			}
		}
	}

	public bool hpInfo_icon_Show1
	{
		get
		{
			if (_ohpInfo_icon_1 != null)
			{
				return _ohpInfo_icon_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpInfo_icon_Show1 != value && _ohpInfo_icon_1 != null)
			{
				_ohpInfo_icon_1.SetObjectActive(value);
			}
		}
	}

	public bool hpInfo_icon_Show2
	{
		get
		{
			if (_ohpInfo_icon_2 != null)
			{
				return _ohpInfo_icon_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpInfo_icon_Show2 != value && _ohpInfo_icon_2 != null)
			{
				_ohpInfo_icon_2.SetObjectActive(value);
			}
		}
	}

	public bool hpInfo_icon_Show3
	{
		get
		{
			if (_ohpInfo_icon_3 != null)
			{
				return _ohpInfo_icon_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpInfo_icon_Show3 != value && _ohpInfo_icon_3 != null)
			{
				_ohpInfo_icon_3.SetObjectActive(value);
			}
		}
	}

	public Sprite hpInfo_icon_Sprite1
	{
		get
		{
			if (_ohpInfo_icon_Image1 != null)
			{
				return _ohpInfo_icon_Image1.sprite;
			}
			return null;
		}
		set
		{
			if (hpInfo_icon_Sprite1 != value && _ohpInfo_icon_Image1 != null)
			{
				_ohpInfo_icon_Image1.sprite = value;
			}
		}
	}

	public Sprite hpInfo_icon_Sprite2
	{
		get
		{
			if (_ohpInfo_icon_Image2 != null)
			{
				return _ohpInfo_icon_Image2.sprite;
			}
			return null;
		}
		set
		{
			if (hpInfo_icon_Sprite2 != value && _ohpInfo_icon_Image2 != null)
			{
				_ohpInfo_icon_Image2.sprite = value;
			}
		}
	}

	public Sprite hpInfo_icon_Sprite3
	{
		get
		{
			if (_ohpInfo_icon_Image3 != null)
			{
				return _ohpInfo_icon_Image3.sprite;
			}
			return null;
		}
		set
		{
			if (hpInfo_icon_Sprite3 != value && _ohpInfo_icon_Image3 != null)
			{
				_ohpInfo_icon_Image3.sprite = value;
			}
		}
	}

	public string hpInfo_num_String1
	{
		get
		{
			if (_ohpInfo_num_Text1 != null)
			{
				return _ohpInfo_num_Text1.text;
			}
			return null;
		}
		set
		{
			if (hpInfo_num_String1 != value && _ohpInfo_num_Text1 != null)
			{
				_ohpInfo_num_Text1.text = value;
			}
		}
	}

	public string hpInfo_num_String2
	{
		get
		{
			if (_ohpInfo_num_Text2 != null)
			{
				return _ohpInfo_num_Text2.text;
			}
			return null;
		}
		set
		{
			if (hpInfo_num_String2 != value && _ohpInfo_num_Text2 != null)
			{
				_ohpInfo_num_Text2.text = value;
			}
		}
	}

	public string hpInfo_num_String3
	{
		get
		{
			if (_ohpInfo_num_Text3 != null)
			{
				return _ohpInfo_num_Text3.text;
			}
			return null;
		}
		set
		{
			if (hpInfo_num_String3 != value && _ohpInfo_num_Text3 != null)
			{
				_ohpInfo_num_Text3.text = value;
			}
		}
	}

	public bool skillShow
	{
		get
		{
			if (_oskill != null)
			{
				return _oskill.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillShow != value && _oskill != null)
			{
				_oskill.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers1
	{
		get
		{
			if (_oButtonEventTrigger1 != null)
			{
				return _oButtonEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers1 != value && _oButtonEventTrigger1 != null)
			{
				_oButtonEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers2
	{
		get
		{
			if (_oButtonEventTrigger2 != null)
			{
				return _oButtonEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers2 != value && _oButtonEventTrigger2 != null)
			{
				_oButtonEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers3
	{
		get
		{
			if (_oButtonEventTrigger3 != null)
			{
				return _oButtonEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers3 != value && _oButtonEventTrigger3 != null)
			{
				_oButtonEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers4
	{
		get
		{
			if (_oButtonEventTrigger4 != null)
			{
				return _oButtonEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers4 != value && _oButtonEventTrigger4 != null)
			{
				_oButtonEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers5
	{
		get
		{
			if (_oButtonEventTrigger5 != null)
			{
				return _oButtonEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers5 != value && _oButtonEventTrigger5 != null)
			{
				_oButtonEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ButtonTriggers6
	{
		get
		{
			if (_oButtonEventTrigger6 != null)
			{
				return _oButtonEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (ButtonTriggers6 != value && _oButtonEventTrigger6 != null)
			{
				_oButtonEventTrigger6.triggers = value;
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

	public bool selectShow4
	{
		get
		{
			if (_oselect4 != null)
			{
				return _oselect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow4 != value && _oselect4 != null)
			{
				_oselect4.SetObjectActive(value);
			}
		}
	}

	public bool selectShow5
	{
		get
		{
			if (_oselect5 != null)
			{
				return _oselect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow5 != value && _oselect5 != null)
			{
				_oselect5.SetObjectActive(value);
			}
		}
	}

	public bool selectShow6
	{
		get
		{
			if (_oselect6 != null)
			{
				return _oselect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow6 != value && _oselect6 != null)
			{
				_oselect6.SetObjectActive(value);
			}
		}
	}

	public bool backpackShow
	{
		get
		{
			if (_obackpack != null)
			{
				return _obackpack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (backpackShow != value && _obackpack != null)
			{
				_obackpack.SetObjectActive(value);
			}
		}
	}

	public GameObject Rect_weaponObj1 => _oRect_weapon1;

	public GameObject Rect_weaponObj2 => _oRect_weapon2;

	public GameObject Rect_weaponObj3 => _oRect_weapon3;

	public GameObject Rect_weaponObj4 => _oRect_weapon4;

	public GameObject Rect_weaponObj5 => _oRect_weapon5;

	public string Bullet_weaponString1
	{
		get
		{
			if (_oBullet_weaponText1 != null)
			{
				return _oBullet_weaponText1.text;
			}
			return null;
		}
		set
		{
			if (Bullet_weaponString1 != value && _oBullet_weaponText1 != null)
			{
				_oBullet_weaponText1.text = value;
			}
		}
	}

	public string Bullet_weaponString2
	{
		get
		{
			if (_oBullet_weaponText2 != null)
			{
				return _oBullet_weaponText2.text;
			}
			return null;
		}
		set
		{
			if (Bullet_weaponString2 != value && _oBullet_weaponText2 != null)
			{
				_oBullet_weaponText2.text = value;
			}
		}
	}

	public string Name_weaponString1
	{
		get
		{
			if (_oName_weaponText1 != null)
			{
				return _oName_weaponText1.text;
			}
			return null;
		}
		set
		{
			if (Name_weaponString1 != value && _oName_weaponText1 != null)
			{
				_oName_weaponText1.text = value;
			}
		}
	}

	public string Name_weaponString2
	{
		get
		{
			if (_oName_weaponText2 != null)
			{
				return _oName_weaponText2.text;
			}
			return null;
		}
		set
		{
			if (Name_weaponString2 != value && _oName_weaponText2 != null)
			{
				_oName_weaponText2.text = value;
			}
		}
	}

	public string Name_weaponString3
	{
		get
		{
			if (_oName_weaponText3 != null)
			{
				return _oName_weaponText3.text;
			}
			return null;
		}
		set
		{
			if (Name_weaponString3 != value && _oName_weaponText3 != null)
			{
				_oName_weaponText3.text = value;
			}
		}
	}

	public string Name_weaponString4
	{
		get
		{
			if (_oName_weaponText4 != null)
			{
				return _oName_weaponText4.text;
			}
			return null;
		}
		set
		{
			if (Name_weaponString4 != value && _oName_weaponText4 != null)
			{
				_oName_weaponText4.text = value;
			}
		}
	}

	public string Name_weaponString5
	{
		get
		{
			if (_oName_weaponText5 != null)
			{
				return _oName_weaponText5.text;
			}
			return null;
		}
		set
		{
			if (Name_weaponString5 != value && _oName_weaponText5 != null)
			{
				_oName_weaponText5.text = value;
			}
		}
	}

	public bool Weapon_IconShow1
	{
		get
		{
			if (_oWeapon_Icon1 != null)
			{
				return _oWeapon_Icon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Weapon_IconShow1 != value && _oWeapon_Icon1 != null)
			{
				_oWeapon_Icon1.SetObjectActive(value);
			}
		}
	}

	public bool Weapon_IconShow2
	{
		get
		{
			if (_oWeapon_Icon2 != null)
			{
				return _oWeapon_Icon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Weapon_IconShow2 != value && _oWeapon_Icon2 != null)
			{
				_oWeapon_Icon2.SetObjectActive(value);
			}
		}
	}

	public bool Weapon_IconShow3
	{
		get
		{
			if (_oWeapon_Icon3 != null)
			{
				return _oWeapon_Icon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Weapon_IconShow3 != value && _oWeapon_Icon3 != null)
			{
				_oWeapon_Icon3.SetObjectActive(value);
			}
		}
	}

	public bool Weapon_IconShow4
	{
		get
		{
			if (_oWeapon_Icon4 != null)
			{
				return _oWeapon_Icon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Weapon_IconShow4 != value && _oWeapon_Icon4 != null)
			{
				_oWeapon_Icon4.SetObjectActive(value);
			}
		}
	}

	public bool Weapon_IconShow5
	{
		get
		{
			if (_oWeapon_Icon5 != null)
			{
				return _oWeapon_Icon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Weapon_IconShow5 != value && _oWeapon_Icon5 != null)
			{
				_oWeapon_Icon5.SetObjectActive(value);
			}
		}
	}

	public Sprite Weapon_IconSprite1
	{
		get
		{
			if (_oWeapon_IconImage1 != null)
			{
				return _oWeapon_IconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (Weapon_IconSprite1 != value && _oWeapon_IconImage1 != null)
			{
				_oWeapon_IconImage1.sprite = value;
			}
		}
	}

	public Sprite Weapon_IconSprite2
	{
		get
		{
			if (_oWeapon_IconImage2 != null)
			{
				return _oWeapon_IconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (Weapon_IconSprite2 != value && _oWeapon_IconImage2 != null)
			{
				_oWeapon_IconImage2.sprite = value;
			}
		}
	}

	public Sprite Weapon_IconSprite3
	{
		get
		{
			if (_oWeapon_IconImage3 != null)
			{
				return _oWeapon_IconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (Weapon_IconSprite3 != value && _oWeapon_IconImage3 != null)
			{
				_oWeapon_IconImage3.sprite = value;
			}
		}
	}

	public Sprite Weapon_IconSprite4
	{
		get
		{
			if (_oWeapon_IconImage4 != null)
			{
				return _oWeapon_IconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (Weapon_IconSprite4 != value && _oWeapon_IconImage4 != null)
			{
				_oWeapon_IconImage4.sprite = value;
			}
		}
	}

	public Sprite Weapon_IconSprite5
	{
		get
		{
			if (_oWeapon_IconImage5 != null)
			{
				return _oWeapon_IconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (Weapon_IconSprite5 != value && _oWeapon_IconImage5 != null)
			{
				_oWeapon_IconImage5.sprite = value;
			}
		}
	}

	public bool bag_IconShow
	{
		get
		{
			if (_obag_Icon != null)
			{
				return _obag_Icon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bag_IconShow != value && _obag_Icon != null)
			{
				_obag_Icon.SetObjectActive(value);
			}
		}
	}

	public Sprite bag_IconSprite
	{
		get
		{
			if (_obag_IconImage != null)
			{
				return _obag_IconImage.sprite;
			}
			return null;
		}
		set
		{
			if (bag_IconSprite != value && _obag_IconImage != null)
			{
				_obag_IconImage.sprite = value;
			}
		}
	}

	public float bag_size_maxFillamount
	{
		get
		{
			if (_obag_size_maxImage != null)
			{
				return _obag_size_maxImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (bag_size_maxFillamount != value && _obag_size_maxImage != null)
			{
				_obag_size_maxImage.fillAmount = value;
			}
		}
	}

	public float bag_sizeFillamount
	{
		get
		{
			if (_obag_sizeImage != null)
			{
				return _obag_sizeImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (bag_sizeFillamount != value && _obag_sizeImage != null)
			{
				_obag_sizeImage.fillAmount = value;
			}
		}
	}

	public GameObject ScrollView_NearbyObj => _oScrollView_Nearby;

	public GameObject Content_NearbyObj => _oContent_Nearby;

	public GameObject ScrollView_BackPackObj => _oScrollView_BackPack;

	public GameObject Content_BackPackObj => _oContent_BackPack;

	public string default_sizeString
	{
		get
		{
			if (_odefault_sizeText != null)
			{
				return _odefault_sizeText.text;
			}
			return null;
		}
		set
		{
			if (default_sizeString != value && _odefault_sizeText != null)
			{
				_odefault_sizeText.text = value;
			}
		}
	}

	public GameObject inventory_default_itemObj => _oinventory_default_item;

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
			case "armorInfo_icon":
				_oarmorInfo_icon = transform.gameObject;
				_oarmorInfo_iconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "armorInfo_red":
				_oarmorInfo_red = transform.gameObject;
				break;
			case "helmetInfo_icon":
				_ohelmetInfo_icon = transform.gameObject;
				_ohelmetInfo_iconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "helmetInfo_red":
				_ohelmetInfo_red = transform.gameObject;
				break;
			case "hpInfo_icon_1":
				_ohpInfo_icon_1 = transform.gameObject;
				_ohpInfo_icon_Image1 = transform.gameObject.GetComponent<Image>();
				break;
			case "hpInfo_icon_2":
				_ohpInfo_icon_2 = transform.gameObject;
				_ohpInfo_icon_Image2 = transform.gameObject.GetComponent<Image>();
				break;
			case "hpInfo_icon_3":
				_ohpInfo_icon_3 = transform.gameObject;
				_ohpInfo_icon_Image3 = transform.gameObject.GetComponent<Image>();
				break;
			case "hpInfo_num_1":
				_ohpInfo_num_1 = transform.gameObject;
				_ohpInfo_num_Text1 = transform.gameObject.GetComponent<Text>();
				break;
			case "hpInfo_num_2":
				_ohpInfo_num_2 = transform.gameObject;
				_ohpInfo_num_Text2 = transform.gameObject.GetComponent<Text>();
				break;
			case "hpInfo_num_3":
				_ohpInfo_num_3 = transform.gameObject;
				_ohpInfo_num_Text3 = transform.gameObject.GetComponent<Text>();
				break;
			case "skill":
				_oskill = transform.gameObject;
				break;
			case "Button1":
				_oButton1 = transform.gameObject;
				_oButtonEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Button2":
				_oButton2 = transform.gameObject;
				_oButtonEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Button3":
				_oButton3 = transform.gameObject;
				_oButtonEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Button4":
				_oButton4 = transform.gameObject;
				_oButtonEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Button5":
				_oButton5 = transform.gameObject;
				_oButtonEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Button6":
				_oButton6 = transform.gameObject;
				_oButtonEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
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
			case "select4":
				_oselect4 = transform.gameObject;
				break;
			case "select5":
				_oselect5 = transform.gameObject;
				break;
			case "select6":
				_oselect6 = transform.gameObject;
				break;
			case "backpack":
				_obackpack = transform.gameObject;
				break;
			case "Rect_weapon1":
				_oRect_weapon1 = transform.gameObject;
				break;
			case "Rect_weapon2":
				_oRect_weapon2 = transform.gameObject;
				break;
			case "Rect_weapon3":
				_oRect_weapon3 = transform.gameObject;
				break;
			case "Rect_weapon4":
				_oRect_weapon4 = transform.gameObject;
				break;
			case "Rect_weapon5":
				_oRect_weapon5 = transform.gameObject;
				break;
			case "Bullet_weapon1":
				_oBullet_weapon1 = transform.gameObject;
				_oBullet_weaponText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Bullet_weapon2":
				_oBullet_weapon2 = transform.gameObject;
				_oBullet_weaponText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name_weapon1":
				_oName_weapon1 = transform.gameObject;
				_oName_weaponText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name_weapon2":
				_oName_weapon2 = transform.gameObject;
				_oName_weaponText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name_weapon3":
				_oName_weapon3 = transform.gameObject;
				_oName_weaponText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name_weapon4":
				_oName_weapon4 = transform.gameObject;
				_oName_weaponText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name_weapon5":
				_oName_weapon5 = transform.gameObject;
				_oName_weaponText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon_Icon1":
				_oWeapon_Icon1 = transform.gameObject;
				_oWeapon_IconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon_Icon2":
				_oWeapon_Icon2 = transform.gameObject;
				_oWeapon_IconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon_Icon3":
				_oWeapon_Icon3 = transform.gameObject;
				_oWeapon_IconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon_Icon4":
				_oWeapon_Icon4 = transform.gameObject;
				_oWeapon_IconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon_Icon5":
				_oWeapon_Icon5 = transform.gameObject;
				_oWeapon_IconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "bag_Icon":
				_obag_Icon = transform.gameObject;
				_obag_IconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "bag_size_max":
				_obag_size_max = transform.gameObject;
				_obag_size_maxImage = transform.gameObject.GetComponent<Image>();
				break;
			case "bag_size":
				_obag_size = transform.gameObject;
				_obag_sizeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ScrollView_Nearby":
				_oScrollView_Nearby = transform.gameObject;
				break;
			case "Content_Nearby":
				_oContent_Nearby = transform.gameObject;
				break;
			case "ScrollView_BackPack":
				_oScrollView_BackPack = transform.gameObject;
				break;
			case "Content_BackPack":
				_oContent_BackPack = transform.gameObject;
				break;
			case "default_size":
				_odefault_size = transform.gameObject;
				_odefault_sizeText = transform.gameObject.GetComponent<Text>();
				break;
			case "inventory_default_item":
				_oinventory_default_item = transform.gameObject;
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

	public bool GethpInfo_icon_Show(int index)
	{
		return index switch
		{
			1 => hpInfo_icon_Show1, 
			2 => hpInfo_icon_Show2, 
			3 => hpInfo_icon_Show3, 
			_ => false, 
		};
	}

	public void SethpInfo_icon_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			hpInfo_icon_Show1 = value;
			break;
		case 2:
			hpInfo_icon_Show2 = value;
			break;
		case 3:
			hpInfo_icon_Show3 = value;
			break;
		}
	}

	public int GethpInfo_icon_Count()
	{
		return 3;
	}

	public Sprite GethpInfo_icon_Sprite(int index)
	{
		return index switch
		{
			1 => hpInfo_icon_Sprite1, 
			2 => hpInfo_icon_Sprite2, 
			3 => hpInfo_icon_Sprite3, 
			_ => null, 
		};
	}

	public void SethpInfo_icon_Sprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			hpInfo_icon_Sprite1 = value;
			break;
		case 2:
			hpInfo_icon_Sprite2 = value;
			break;
		case 3:
			hpInfo_icon_Sprite3 = value;
			break;
		}
	}

	public string GethpInfo_num_String(int index)
	{
		return index switch
		{
			1 => hpInfo_num_String1, 
			2 => hpInfo_num_String2, 
			3 => hpInfo_num_String3, 
			_ => null, 
		};
	}

	public void SethpInfo_num_String(int index, string value)
	{
		switch (index)
		{
		case 1:
			hpInfo_num_String1 = value;
			break;
		case 2:
			hpInfo_num_String2 = value;
			break;
		case 3:
			hpInfo_num_String3 = value;
			break;
		}
	}

	public int GethpInfo_num_Count()
	{
		return 3;
	}

	private void CreateButtonTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers1, eventId, callback);
	}

	private void RemoveButtonTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers1, eventId);
	}

	private void CreateButtonTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers2, eventId, callback);
	}

	private void RemoveButtonTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers2, eventId);
	}

	private void CreateButtonTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers3, eventId, callback);
	}

	private void RemoveButtonTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers3, eventId);
	}

	private void CreateButtonTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers4, eventId, callback);
	}

	private void RemoveButtonTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers4, eventId);
	}

	private void CreateButtonTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers5, eventId, callback);
	}

	private void RemoveButtonTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers5, eventId);
	}

	private void CreateButtonTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ButtonTriggers6, eventId, callback);
	}

	private void RemoveButtonTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ButtonTriggers6, eventId);
	}

	public List<EventTrigger.Entry> GetButtonTriggers(int index)
	{
		return index switch
		{
			1 => ButtonTriggers1, 
			2 => ButtonTriggers2, 
			3 => ButtonTriggers3, 
			4 => ButtonTriggers4, 
			5 => ButtonTriggers5, 
			6 => ButtonTriggers6, 
			_ => null, 
		};
	}

	public void SetButtonTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			ButtonTriggers1 = value;
			break;
		case 2:
			ButtonTriggers2 = value;
			break;
		case 3:
			ButtonTriggers3 = value;
			break;
		case 4:
			ButtonTriggers4 = value;
			break;
		case 5:
			ButtonTriggers5 = value;
			break;
		case 6:
			ButtonTriggers6 = value;
			break;
		}
	}

	private void CreateButtonTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetButtonTriggers(index), eventId, callback);
	}

	private void RemoveButtonTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetButtonTriggers(index), eventId);
	}

	public int GetButtonCount()
	{
		return 6;
	}

	public bool GetselectShow(int index)
	{
		return index switch
		{
			1 => selectShow1, 
			2 => selectShow2, 
			3 => selectShow3, 
			4 => selectShow4, 
			5 => selectShow5, 
			6 => selectShow6, 
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
		case 4:
			selectShow4 = value;
			break;
		case 5:
			selectShow5 = value;
			break;
		case 6:
			selectShow6 = value;
			break;
		}
	}

	public int GetselectCount()
	{
		return 6;
	}

	public GameObject GetRect_weaponObj(int index)
	{
		return index switch
		{
			1 => Rect_weaponObj1, 
			2 => Rect_weaponObj2, 
			3 => Rect_weaponObj3, 
			4 => Rect_weaponObj4, 
			5 => Rect_weaponObj5, 
			_ => null, 
		};
	}

	public int GetRect_weaponCount()
	{
		return 5;
	}

	public string GetBullet_weaponString(int index)
	{
		return index switch
		{
			1 => Bullet_weaponString1, 
			2 => Bullet_weaponString2, 
			_ => null, 
		};
	}

	public void SetBullet_weaponString(int index, string value)
	{
		switch (index)
		{
		case 1:
			Bullet_weaponString1 = value;
			break;
		case 2:
			Bullet_weaponString2 = value;
			break;
		}
	}

	public int GetBullet_weaponCount()
	{
		return 2;
	}

	public string GetName_weaponString(int index)
	{
		return index switch
		{
			1 => Name_weaponString1, 
			2 => Name_weaponString2, 
			3 => Name_weaponString3, 
			4 => Name_weaponString4, 
			5 => Name_weaponString5, 
			_ => null, 
		};
	}

	public void SetName_weaponString(int index, string value)
	{
		switch (index)
		{
		case 1:
			Name_weaponString1 = value;
			break;
		case 2:
			Name_weaponString2 = value;
			break;
		case 3:
			Name_weaponString3 = value;
			break;
		case 4:
			Name_weaponString4 = value;
			break;
		case 5:
			Name_weaponString5 = value;
			break;
		}
	}

	public int GetName_weaponCount()
	{
		return 5;
	}

	public bool GetWeapon_IconShow(int index)
	{
		return index switch
		{
			1 => Weapon_IconShow1, 
			2 => Weapon_IconShow2, 
			3 => Weapon_IconShow3, 
			4 => Weapon_IconShow4, 
			5 => Weapon_IconShow5, 
			_ => false, 
		};
	}

	public void SetWeapon_IconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			Weapon_IconShow1 = value;
			break;
		case 2:
			Weapon_IconShow2 = value;
			break;
		case 3:
			Weapon_IconShow3 = value;
			break;
		case 4:
			Weapon_IconShow4 = value;
			break;
		case 5:
			Weapon_IconShow5 = value;
			break;
		}
	}

	public int GetWeapon_IconCount()
	{
		return 5;
	}

	public Sprite GetWeapon_IconSprite(int index)
	{
		return index switch
		{
			1 => Weapon_IconSprite1, 
			2 => Weapon_IconSprite2, 
			3 => Weapon_IconSprite3, 
			4 => Weapon_IconSprite4, 
			5 => Weapon_IconSprite5, 
			_ => null, 
		};
	}

	public void SetWeapon_IconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			Weapon_IconSprite1 = value;
			break;
		case 2:
			Weapon_IconSprite2 = value;
			break;
		case 3:
			Weapon_IconSprite3 = value;
			break;
		case 4:
			Weapon_IconSprite4 = value;
			break;
		case 5:
			Weapon_IconSprite5 = value;
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
