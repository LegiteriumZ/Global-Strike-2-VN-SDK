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

namespace Assets.Sources.Ui.ViewModel.HomeLandModel;

[GameUiTest]
public class HomeLandModelRentViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _obg1;

	private GameObject _obg2;

	private GameObject _obg3;

	private GameObject _obg4;

	private GameObject _obg5;

	private GameObject _obg6;

	private GameObject _obg7;

	private GameObject _obg8;

	private GameObject _obg9;

	private GameObject _obg10;

	private GameObject _or_btn1;

	private GameObject _or_btn2;

	private Button _or_btnButton1;

	private Button _or_btnButton2;

	private GameObject _ol_btn1;

	private GameObject _ol_btn2;

	private Button _ol_btnButton1;

	private Button _ol_btnButton2;

	private GameObject _opag;

	private Text _opagText;

	private GameObject _oz_num;

	private Text _oz_numText;

	private GameObject _oy_num;

	private Text _oy_numText;

	private GameObject _oplayerName1;

	private GameObject _oplayerName2;

	private GameObject _oplayerName3;

	private GameObject _oplayerName4;

	private GameObject _oplayerName5;

	private GameObject _oplayerName6;

	private GameObject _oplayerName7;

	private GameObject _oplayerName8;

	private GameObject _oplayerName9;

	private GameObject _oplayerName10;

	private Text _oplayerNameText1;

	private Text _oplayerNameText2;

	private Text _oplayerNameText3;

	private Text _oplayerNameText4;

	private Text _oplayerNameText5;

	private Text _oplayerNameText6;

	private Text _oplayerNameText7;

	private Text _oplayerNameText8;

	private Text _oplayerNameText9;

	private Text _oplayerNameText10;

	private GameObject _oweaponName1;

	private GameObject _oweaponName2;

	private GameObject _oweaponName3;

	private GameObject _oweaponName4;

	private GameObject _oweaponName5;

	private GameObject _oweaponName6;

	private GameObject _oweaponName7;

	private GameObject _oweaponName8;

	private GameObject _oweaponName9;

	private GameObject _oweaponName10;

	private Text _oweaponNameText1;

	private Text _oweaponNameText2;

	private Text _oweaponNameText3;

	private Text _oweaponNameText4;

	private Text _oweaponNameText5;

	private Text _oweaponNameText6;

	private Text _oweaponNameText7;

	private Text _oweaponNameText8;

	private Text _oweaponNameText9;

	private Text _oweaponNameText10;

	private GameObject _orentTime1;

	private GameObject _orentTime2;

	private GameObject _orentTime3;

	private GameObject _orentTime4;

	private GameObject _orentTime5;

	private GameObject _orentTime6;

	private GameObject _orentTime7;

	private GameObject _orentTime8;

	private GameObject _orentTime9;

	private GameObject _orentTime10;

	private Text _orentTimeText1;

	private Text _orentTimeText2;

	private Text _orentTimeText3;

	private Text _orentTimeText4;

	private Text _orentTimeText5;

	private Text _orentTimeText6;

	private Text _orentTimeText7;

	private Text _orentTimeText8;

	private Text _orentTimeText9;

	private Text _orentTimeText10;

	private GameObject _oclone_btn;

	private Button _oclone_btnButton;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/homelandmodel";

	private string _resourceAssetName = "homelandmodelrent";

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

	public bool bgShow1
	{
		get
		{
			if (_obg1 != null)
			{
				return _obg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow1 != value && _obg1 != null)
			{
				_obg1.SetObjectActive(value);
			}
		}
	}

	public bool bgShow2
	{
		get
		{
			if (_obg2 != null)
			{
				return _obg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow2 != value && _obg2 != null)
			{
				_obg2.SetObjectActive(value);
			}
		}
	}

	public bool bgShow3
	{
		get
		{
			if (_obg3 != null)
			{
				return _obg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow3 != value && _obg3 != null)
			{
				_obg3.SetObjectActive(value);
			}
		}
	}

	public bool bgShow4
	{
		get
		{
			if (_obg4 != null)
			{
				return _obg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow4 != value && _obg4 != null)
			{
				_obg4.SetObjectActive(value);
			}
		}
	}

	public bool bgShow5
	{
		get
		{
			if (_obg5 != null)
			{
				return _obg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow5 != value && _obg5 != null)
			{
				_obg5.SetObjectActive(value);
			}
		}
	}

	public bool bgShow6
	{
		get
		{
			if (_obg6 != null)
			{
				return _obg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow6 != value && _obg6 != null)
			{
				_obg6.SetObjectActive(value);
			}
		}
	}

	public bool bgShow7
	{
		get
		{
			if (_obg7 != null)
			{
				return _obg7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow7 != value && _obg7 != null)
			{
				_obg7.SetObjectActive(value);
			}
		}
	}

	public bool bgShow8
	{
		get
		{
			if (_obg8 != null)
			{
				return _obg8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow8 != value && _obg8 != null)
			{
				_obg8.SetObjectActive(value);
			}
		}
	}

	public bool bgShow9
	{
		get
		{
			if (_obg9 != null)
			{
				return _obg9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow9 != value && _obg9 != null)
			{
				_obg9.SetObjectActive(value);
			}
		}
	}

	public bool bgShow10
	{
		get
		{
			if (_obg10 != null)
			{
				return _obg10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow10 != value && _obg10 != null)
			{
				_obg10.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent r_btnClicked1
	{
		get
		{
			if (_or_btnButton1 != null)
			{
				return _or_btnButton1.onClick;
			}
			return null;
		}
		set
		{
			if (r_btnClicked1 != value && _or_btnButton1 != null)
			{
				_or_btnButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_btnClicked2
	{
		get
		{
			if (_or_btnButton2 != null)
			{
				return _or_btnButton2.onClick;
			}
			return null;
		}
		set
		{
			if (r_btnClicked2 != value && _or_btnButton2 != null)
			{
				_or_btnButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_btnClicked1
	{
		get
		{
			if (_ol_btnButton1 != null)
			{
				return _ol_btnButton1.onClick;
			}
			return null;
		}
		set
		{
			if (l_btnClicked1 != value && _ol_btnButton1 != null)
			{
				_ol_btnButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_btnClicked2
	{
		get
		{
			if (_ol_btnButton2 != null)
			{
				return _ol_btnButton2.onClick;
			}
			return null;
		}
		set
		{
			if (l_btnClicked2 != value && _ol_btnButton2 != null)
			{
				_ol_btnButton2.onClick = value;
			}
		}
	}

	public string pagString
	{
		get
		{
			if (_opagText != null)
			{
				return _opagText.text;
			}
			return null;
		}
		set
		{
			if (pagString != value && _opagText != null)
			{
				_opagText.text = value;
			}
		}
	}

	public string z_numString
	{
		get
		{
			if (_oz_numText != null)
			{
				return _oz_numText.text;
			}
			return null;
		}
		set
		{
			if (z_numString != value && _oz_numText != null)
			{
				_oz_numText.text = value;
			}
		}
	}

	public string y_numString
	{
		get
		{
			if (_oy_numText != null)
			{
				return _oy_numText.text;
			}
			return null;
		}
		set
		{
			if (y_numString != value && _oy_numText != null)
			{
				_oy_numText.text = value;
			}
		}
	}

	public string playerNameString1
	{
		get
		{
			if (_oplayerNameText1 != null)
			{
				return _oplayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (playerNameString1 != value && _oplayerNameText1 != null)
			{
				_oplayerNameText1.text = value;
			}
		}
	}

	public string playerNameString2
	{
		get
		{
			if (_oplayerNameText2 != null)
			{
				return _oplayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (playerNameString2 != value && _oplayerNameText2 != null)
			{
				_oplayerNameText2.text = value;
			}
		}
	}

	public string playerNameString3
	{
		get
		{
			if (_oplayerNameText3 != null)
			{
				return _oplayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (playerNameString3 != value && _oplayerNameText3 != null)
			{
				_oplayerNameText3.text = value;
			}
		}
	}

	public string playerNameString4
	{
		get
		{
			if (_oplayerNameText4 != null)
			{
				return _oplayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (playerNameString4 != value && _oplayerNameText4 != null)
			{
				_oplayerNameText4.text = value;
			}
		}
	}

	public string playerNameString5
	{
		get
		{
			if (_oplayerNameText5 != null)
			{
				return _oplayerNameText5.text;
			}
			return null;
		}
		set
		{
			if (playerNameString5 != value && _oplayerNameText5 != null)
			{
				_oplayerNameText5.text = value;
			}
		}
	}

	public string playerNameString6
	{
		get
		{
			if (_oplayerNameText6 != null)
			{
				return _oplayerNameText6.text;
			}
			return null;
		}
		set
		{
			if (playerNameString6 != value && _oplayerNameText6 != null)
			{
				_oplayerNameText6.text = value;
			}
		}
	}

	public string playerNameString7
	{
		get
		{
			if (_oplayerNameText7 != null)
			{
				return _oplayerNameText7.text;
			}
			return null;
		}
		set
		{
			if (playerNameString7 != value && _oplayerNameText7 != null)
			{
				_oplayerNameText7.text = value;
			}
		}
	}

	public string playerNameString8
	{
		get
		{
			if (_oplayerNameText8 != null)
			{
				return _oplayerNameText8.text;
			}
			return null;
		}
		set
		{
			if (playerNameString8 != value && _oplayerNameText8 != null)
			{
				_oplayerNameText8.text = value;
			}
		}
	}

	public string playerNameString9
	{
		get
		{
			if (_oplayerNameText9 != null)
			{
				return _oplayerNameText9.text;
			}
			return null;
		}
		set
		{
			if (playerNameString9 != value && _oplayerNameText9 != null)
			{
				_oplayerNameText9.text = value;
			}
		}
	}

	public string playerNameString10
	{
		get
		{
			if (_oplayerNameText10 != null)
			{
				return _oplayerNameText10.text;
			}
			return null;
		}
		set
		{
			if (playerNameString10 != value && _oplayerNameText10 != null)
			{
				_oplayerNameText10.text = value;
			}
		}
	}

	public string weaponNameString1
	{
		get
		{
			if (_oweaponNameText1 != null)
			{
				return _oweaponNameText1.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString1 != value && _oweaponNameText1 != null)
			{
				_oweaponNameText1.text = value;
			}
		}
	}

	public string weaponNameString2
	{
		get
		{
			if (_oweaponNameText2 != null)
			{
				return _oweaponNameText2.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString2 != value && _oweaponNameText2 != null)
			{
				_oweaponNameText2.text = value;
			}
		}
	}

	public string weaponNameString3
	{
		get
		{
			if (_oweaponNameText3 != null)
			{
				return _oweaponNameText3.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString3 != value && _oweaponNameText3 != null)
			{
				_oweaponNameText3.text = value;
			}
		}
	}

	public string weaponNameString4
	{
		get
		{
			if (_oweaponNameText4 != null)
			{
				return _oweaponNameText4.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString4 != value && _oweaponNameText4 != null)
			{
				_oweaponNameText4.text = value;
			}
		}
	}

	public string weaponNameString5
	{
		get
		{
			if (_oweaponNameText5 != null)
			{
				return _oweaponNameText5.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString5 != value && _oweaponNameText5 != null)
			{
				_oweaponNameText5.text = value;
			}
		}
	}

	public string weaponNameString6
	{
		get
		{
			if (_oweaponNameText6 != null)
			{
				return _oweaponNameText6.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString6 != value && _oweaponNameText6 != null)
			{
				_oweaponNameText6.text = value;
			}
		}
	}

	public string weaponNameString7
	{
		get
		{
			if (_oweaponNameText7 != null)
			{
				return _oweaponNameText7.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString7 != value && _oweaponNameText7 != null)
			{
				_oweaponNameText7.text = value;
			}
		}
	}

	public string weaponNameString8
	{
		get
		{
			if (_oweaponNameText8 != null)
			{
				return _oweaponNameText8.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString8 != value && _oweaponNameText8 != null)
			{
				_oweaponNameText8.text = value;
			}
		}
	}

	public string weaponNameString9
	{
		get
		{
			if (_oweaponNameText9 != null)
			{
				return _oweaponNameText9.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString9 != value && _oweaponNameText9 != null)
			{
				_oweaponNameText9.text = value;
			}
		}
	}

	public string weaponNameString10
	{
		get
		{
			if (_oweaponNameText10 != null)
			{
				return _oweaponNameText10.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString10 != value && _oweaponNameText10 != null)
			{
				_oweaponNameText10.text = value;
			}
		}
	}

	public string rentTimeString1
	{
		get
		{
			if (_orentTimeText1 != null)
			{
				return _orentTimeText1.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString1 != value && _orentTimeText1 != null)
			{
				_orentTimeText1.text = value;
			}
		}
	}

	public string rentTimeString2
	{
		get
		{
			if (_orentTimeText2 != null)
			{
				return _orentTimeText2.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString2 != value && _orentTimeText2 != null)
			{
				_orentTimeText2.text = value;
			}
		}
	}

	public string rentTimeString3
	{
		get
		{
			if (_orentTimeText3 != null)
			{
				return _orentTimeText3.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString3 != value && _orentTimeText3 != null)
			{
				_orentTimeText3.text = value;
			}
		}
	}

	public string rentTimeString4
	{
		get
		{
			if (_orentTimeText4 != null)
			{
				return _orentTimeText4.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString4 != value && _orentTimeText4 != null)
			{
				_orentTimeText4.text = value;
			}
		}
	}

	public string rentTimeString5
	{
		get
		{
			if (_orentTimeText5 != null)
			{
				return _orentTimeText5.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString5 != value && _orentTimeText5 != null)
			{
				_orentTimeText5.text = value;
			}
		}
	}

	public string rentTimeString6
	{
		get
		{
			if (_orentTimeText6 != null)
			{
				return _orentTimeText6.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString6 != value && _orentTimeText6 != null)
			{
				_orentTimeText6.text = value;
			}
		}
	}

	public string rentTimeString7
	{
		get
		{
			if (_orentTimeText7 != null)
			{
				return _orentTimeText7.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString7 != value && _orentTimeText7 != null)
			{
				_orentTimeText7.text = value;
			}
		}
	}

	public string rentTimeString8
	{
		get
		{
			if (_orentTimeText8 != null)
			{
				return _orentTimeText8.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString8 != value && _orentTimeText8 != null)
			{
				_orentTimeText8.text = value;
			}
		}
	}

	public string rentTimeString9
	{
		get
		{
			if (_orentTimeText9 != null)
			{
				return _orentTimeText9.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString9 != value && _orentTimeText9 != null)
			{
				_orentTimeText9.text = value;
			}
		}
	}

	public string rentTimeString10
	{
		get
		{
			if (_orentTimeText10 != null)
			{
				return _orentTimeText10.text;
			}
			return null;
		}
		set
		{
			if (rentTimeString10 != value && _orentTimeText10 != null)
			{
				_orentTimeText10.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent clone_btnClicked
	{
		get
		{
			if (_oclone_btnButton != null)
			{
				return _oclone_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (clone_btnClicked != value && _oclone_btnButton != null)
			{
				_oclone_btnButton.onClick = value;
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
			case "bg1":
				_obg1 = transform.gameObject;
				break;
			case "bg2":
				_obg2 = transform.gameObject;
				break;
			case "bg3":
				_obg3 = transform.gameObject;
				break;
			case "bg4":
				_obg4 = transform.gameObject;
				break;
			case "bg5":
				_obg5 = transform.gameObject;
				break;
			case "bg6":
				_obg6 = transform.gameObject;
				break;
			case "bg7":
				_obg7 = transform.gameObject;
				break;
			case "bg8":
				_obg8 = transform.gameObject;
				break;
			case "bg9":
				_obg9 = transform.gameObject;
				break;
			case "bg10":
				_obg10 = transform.gameObject;
				break;
			case "r_btn1":
				_or_btn1 = transform.gameObject;
				_or_btnButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_btn2":
				_or_btn2 = transform.gameObject;
				_or_btnButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_btn1":
				_ol_btn1 = transform.gameObject;
				_ol_btnButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_btn2":
				_ol_btn2 = transform.gameObject;
				_ol_btnButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "pag":
				_opag = transform.gameObject;
				_opagText = transform.gameObject.GetComponent<Text>();
				break;
			case "z_num":
				_oz_num = transform.gameObject;
				_oz_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "y_num":
				_oy_num = transform.gameObject;
				_oy_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName1":
				_oplayerName1 = transform.gameObject;
				_oplayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName2":
				_oplayerName2 = transform.gameObject;
				_oplayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName3":
				_oplayerName3 = transform.gameObject;
				_oplayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName4":
				_oplayerName4 = transform.gameObject;
				_oplayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName5":
				_oplayerName5 = transform.gameObject;
				_oplayerNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName6":
				_oplayerName6 = transform.gameObject;
				_oplayerNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName7":
				_oplayerName7 = transform.gameObject;
				_oplayerNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName8":
				_oplayerName8 = transform.gameObject;
				_oplayerNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName9":
				_oplayerName9 = transform.gameObject;
				_oplayerNameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "playerName10":
				_oplayerName10 = transform.gameObject;
				_oplayerNameText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName1":
				_oweaponName1 = transform.gameObject;
				_oweaponNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName2":
				_oweaponName2 = transform.gameObject;
				_oweaponNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName3":
				_oweaponName3 = transform.gameObject;
				_oweaponNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName4":
				_oweaponName4 = transform.gameObject;
				_oweaponNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName5":
				_oweaponName5 = transform.gameObject;
				_oweaponNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName6":
				_oweaponName6 = transform.gameObject;
				_oweaponNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName7":
				_oweaponName7 = transform.gameObject;
				_oweaponNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName8":
				_oweaponName8 = transform.gameObject;
				_oweaponNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName9":
				_oweaponName9 = transform.gameObject;
				_oweaponNameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponName10":
				_oweaponName10 = transform.gameObject;
				_oweaponNameText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime1":
				_orentTime1 = transform.gameObject;
				_orentTimeText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime2":
				_orentTime2 = transform.gameObject;
				_orentTimeText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime3":
				_orentTime3 = transform.gameObject;
				_orentTimeText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime4":
				_orentTime4 = transform.gameObject;
				_orentTimeText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime5":
				_orentTime5 = transform.gameObject;
				_orentTimeText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime6":
				_orentTime6 = transform.gameObject;
				_orentTimeText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime7":
				_orentTime7 = transform.gameObject;
				_orentTimeText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime8":
				_orentTime8 = transform.gameObject;
				_orentTimeText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime9":
				_orentTime9 = transform.gameObject;
				_orentTimeText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "rentTime10":
				_orentTime10 = transform.gameObject;
				_orentTimeText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "clone_btn":
				_oclone_btn = transform.gameObject;
				_oclone_btnButton = transform.gameObject.GetComponent<Button>();
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

	public bool GetbgShow(int index)
	{
		return index switch
		{
			1 => bgShow1, 
			2 => bgShow2, 
			3 => bgShow3, 
			4 => bgShow4, 
			5 => bgShow5, 
			6 => bgShow6, 
			7 => bgShow7, 
			8 => bgShow8, 
			9 => bgShow9, 
			10 => bgShow10, 
			_ => false, 
		};
	}

	public void SetbgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			bgShow1 = value;
			break;
		case 2:
			bgShow2 = value;
			break;
		case 3:
			bgShow3 = value;
			break;
		case 4:
			bgShow4 = value;
			break;
		case 5:
			bgShow5 = value;
			break;
		case 6:
			bgShow6 = value;
			break;
		case 7:
			bgShow7 = value;
			break;
		case 8:
			bgShow8 = value;
			break;
		case 9:
			bgShow9 = value;
			break;
		case 10:
			bgShow10 = value;
			break;
		}
	}

	public int GetbgCount()
	{
		return 10;
	}

	public Button.ButtonClickedEvent Getr_btnClicked(int index)
	{
		return index switch
		{
			1 => r_btnClicked1, 
			2 => r_btnClicked2, 
			_ => null, 
		};
	}

	public void Setr_btnClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			r_btnClicked1 = value;
			break;
		case 2:
			r_btnClicked2 = value;
			break;
		}
	}

	public int Getr_btnCount()
	{
		return 2;
	}

	public Button.ButtonClickedEvent Getl_btnClicked(int index)
	{
		return index switch
		{
			1 => l_btnClicked1, 
			2 => l_btnClicked2, 
			_ => null, 
		};
	}

	public void Setl_btnClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			l_btnClicked1 = value;
			break;
		case 2:
			l_btnClicked2 = value;
			break;
		}
	}

	public int Getl_btnCount()
	{
		return 2;
	}

	public string GetplayerNameString(int index)
	{
		return index switch
		{
			1 => playerNameString1, 
			2 => playerNameString2, 
			3 => playerNameString3, 
			4 => playerNameString4, 
			5 => playerNameString5, 
			6 => playerNameString6, 
			7 => playerNameString7, 
			8 => playerNameString8, 
			9 => playerNameString9, 
			10 => playerNameString10, 
			_ => null, 
		};
	}

	public void SetplayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			playerNameString1 = value;
			break;
		case 2:
			playerNameString2 = value;
			break;
		case 3:
			playerNameString3 = value;
			break;
		case 4:
			playerNameString4 = value;
			break;
		case 5:
			playerNameString5 = value;
			break;
		case 6:
			playerNameString6 = value;
			break;
		case 7:
			playerNameString7 = value;
			break;
		case 8:
			playerNameString8 = value;
			break;
		case 9:
			playerNameString9 = value;
			break;
		case 10:
			playerNameString10 = value;
			break;
		}
	}

	public int GetplayerNameCount()
	{
		return 10;
	}

	public string GetweaponNameString(int index)
	{
		return index switch
		{
			1 => weaponNameString1, 
			2 => weaponNameString2, 
			3 => weaponNameString3, 
			4 => weaponNameString4, 
			5 => weaponNameString5, 
			6 => weaponNameString6, 
			7 => weaponNameString7, 
			8 => weaponNameString8, 
			9 => weaponNameString9, 
			10 => weaponNameString10, 
			_ => null, 
		};
	}

	public void SetweaponNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			weaponNameString1 = value;
			break;
		case 2:
			weaponNameString2 = value;
			break;
		case 3:
			weaponNameString3 = value;
			break;
		case 4:
			weaponNameString4 = value;
			break;
		case 5:
			weaponNameString5 = value;
			break;
		case 6:
			weaponNameString6 = value;
			break;
		case 7:
			weaponNameString7 = value;
			break;
		case 8:
			weaponNameString8 = value;
			break;
		case 9:
			weaponNameString9 = value;
			break;
		case 10:
			weaponNameString10 = value;
			break;
		}
	}

	public int GetweaponNameCount()
	{
		return 10;
	}

	public string GetrentTimeString(int index)
	{
		return index switch
		{
			1 => rentTimeString1, 
			2 => rentTimeString2, 
			3 => rentTimeString3, 
			4 => rentTimeString4, 
			5 => rentTimeString5, 
			6 => rentTimeString6, 
			7 => rentTimeString7, 
			8 => rentTimeString8, 
			9 => rentTimeString9, 
			10 => rentTimeString10, 
			_ => null, 
		};
	}

	public void SetrentTimeString(int index, string value)
	{
		switch (index)
		{
		case 1:
			rentTimeString1 = value;
			break;
		case 2:
			rentTimeString2 = value;
			break;
		case 3:
			rentTimeString3 = value;
			break;
		case 4:
			rentTimeString4 = value;
			break;
		case 5:
			rentTimeString5 = value;
			break;
		case 6:
			rentTimeString6 = value;
			break;
		case 7:
			rentTimeString7 = value;
			break;
		case 8:
			rentTimeString8 = value;
			break;
		case 9:
			rentTimeString9 = value;
			break;
		case 10:
			rentTimeString10 = value;
			break;
		}
	}

	public int GetrentTimeCount()
	{
		return 10;
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
