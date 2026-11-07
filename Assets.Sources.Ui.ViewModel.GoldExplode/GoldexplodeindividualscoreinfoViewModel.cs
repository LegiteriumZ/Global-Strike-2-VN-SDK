using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GoldExplode;

[GameUiTest]
public class GoldexplodeindividualscoreinfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTeamGrid1;

	private GameObject _oTeamGrid2;

	private GameObject _oNameText1;

	private GameObject _oNameText2;

	private GameObject _oNameText3;

	private GameObject _oNameText4;

	private GameObject _oNameText5;

	private GameObject _oNameText6;

	private GameObject _oNameText7;

	private GameObject _oNameText8;

	private GameObject _oNameText9;

	private GameObject _oNameText10;

	private GameObject _oNameText11;

	private GameObject _oNameText12;

	private GameObject _oNameText13;

	private GameObject _oNameText14;

	private GameObject _oNameText15;

	private GameObject _oNameText16;

	private Text _oNameTextText1;

	private Text _oNameTextText2;

	private Text _oNameTextText3;

	private Text _oNameTextText4;

	private Text _oNameTextText5;

	private Text _oNameTextText6;

	private Text _oNameTextText7;

	private Text _oNameTextText8;

	private Text _oNameTextText9;

	private Text _oNameTextText10;

	private Text _oNameTextText11;

	private Text _oNameTextText12;

	private Text _oNameTextText13;

	private Text _oNameTextText14;

	private Text _oNameTextText15;

	private Text _oNameTextText16;

	private GameObject _oMoneyText1;

	private GameObject _oMoneyText2;

	private GameObject _oMoneyText3;

	private GameObject _oMoneyText4;

	private GameObject _oMoneyText5;

	private GameObject _oMoneyText6;

	private GameObject _oMoneyText7;

	private GameObject _oMoneyText8;

	private GameObject _oMoneyText9;

	private GameObject _oMoneyText10;

	private GameObject _oMoneyText11;

	private GameObject _oMoneyText12;

	private GameObject _oMoneyText13;

	private GameObject _oMoneyText14;

	private GameObject _oMoneyText15;

	private GameObject _oMoneyText16;

	private Text _oMoneyTextText1;

	private Text _oMoneyTextText2;

	private Text _oMoneyTextText3;

	private Text _oMoneyTextText4;

	private Text _oMoneyTextText5;

	private Text _oMoneyTextText6;

	private Text _oMoneyTextText7;

	private Text _oMoneyTextText8;

	private Text _oMoneyTextText9;

	private Text _oMoneyTextText10;

	private Text _oMoneyTextText11;

	private Text _oMoneyTextText12;

	private Text _oMoneyTextText13;

	private Text _oMoneyTextText14;

	private Text _oMoneyTextText15;

	private Text _oMoneyTextText16;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/goldexplode";

	private string _resourceAssetName = "Goldexplodeindividualscoreinfo";

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

	public GameObject TeamGridObj1 => _oTeamGrid1;

	public GameObject TeamGridObj2 => _oTeamGrid2;

	public bool NameTextShow1
	{
		get
		{
			if (_oNameText1 != null)
			{
				return _oNameText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow1 != value && _oNameText1 != null)
			{
				_oNameText1.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow2
	{
		get
		{
			if (_oNameText2 != null)
			{
				return _oNameText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow2 != value && _oNameText2 != null)
			{
				_oNameText2.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow3
	{
		get
		{
			if (_oNameText3 != null)
			{
				return _oNameText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow3 != value && _oNameText3 != null)
			{
				_oNameText3.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow4
	{
		get
		{
			if (_oNameText4 != null)
			{
				return _oNameText4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow4 != value && _oNameText4 != null)
			{
				_oNameText4.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow5
	{
		get
		{
			if (_oNameText5 != null)
			{
				return _oNameText5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow5 != value && _oNameText5 != null)
			{
				_oNameText5.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow6
	{
		get
		{
			if (_oNameText6 != null)
			{
				return _oNameText6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow6 != value && _oNameText6 != null)
			{
				_oNameText6.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow7
	{
		get
		{
			if (_oNameText7 != null)
			{
				return _oNameText7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow7 != value && _oNameText7 != null)
			{
				_oNameText7.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow8
	{
		get
		{
			if (_oNameText8 != null)
			{
				return _oNameText8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow8 != value && _oNameText8 != null)
			{
				_oNameText8.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow9
	{
		get
		{
			if (_oNameText9 != null)
			{
				return _oNameText9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow9 != value && _oNameText9 != null)
			{
				_oNameText9.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow10
	{
		get
		{
			if (_oNameText10 != null)
			{
				return _oNameText10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow10 != value && _oNameText10 != null)
			{
				_oNameText10.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow11
	{
		get
		{
			if (_oNameText11 != null)
			{
				return _oNameText11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow11 != value && _oNameText11 != null)
			{
				_oNameText11.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow12
	{
		get
		{
			if (_oNameText12 != null)
			{
				return _oNameText12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow12 != value && _oNameText12 != null)
			{
				_oNameText12.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow13
	{
		get
		{
			if (_oNameText13 != null)
			{
				return _oNameText13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow13 != value && _oNameText13 != null)
			{
				_oNameText13.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow14
	{
		get
		{
			if (_oNameText14 != null)
			{
				return _oNameText14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow14 != value && _oNameText14 != null)
			{
				_oNameText14.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow15
	{
		get
		{
			if (_oNameText15 != null)
			{
				return _oNameText15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow15 != value && _oNameText15 != null)
			{
				_oNameText15.SetObjectActive(value);
			}
		}
	}

	public bool NameTextShow16
	{
		get
		{
			if (_oNameText16 != null)
			{
				return _oNameText16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameTextShow16 != value && _oNameText16 != null)
			{
				_oNameText16.SetObjectActive(value);
			}
		}
	}

	public string NameTextString1
	{
		get
		{
			if (_oNameTextText1 != null)
			{
				return _oNameTextText1.text;
			}
			return null;
		}
		set
		{
			if (NameTextString1 != value && _oNameTextText1 != null)
			{
				_oNameTextText1.text = value;
			}
		}
	}

	public string NameTextString2
	{
		get
		{
			if (_oNameTextText2 != null)
			{
				return _oNameTextText2.text;
			}
			return null;
		}
		set
		{
			if (NameTextString2 != value && _oNameTextText2 != null)
			{
				_oNameTextText2.text = value;
			}
		}
	}

	public string NameTextString3
	{
		get
		{
			if (_oNameTextText3 != null)
			{
				return _oNameTextText3.text;
			}
			return null;
		}
		set
		{
			if (NameTextString3 != value && _oNameTextText3 != null)
			{
				_oNameTextText3.text = value;
			}
		}
	}

	public string NameTextString4
	{
		get
		{
			if (_oNameTextText4 != null)
			{
				return _oNameTextText4.text;
			}
			return null;
		}
		set
		{
			if (NameTextString4 != value && _oNameTextText4 != null)
			{
				_oNameTextText4.text = value;
			}
		}
	}

	public string NameTextString5
	{
		get
		{
			if (_oNameTextText5 != null)
			{
				return _oNameTextText5.text;
			}
			return null;
		}
		set
		{
			if (NameTextString5 != value && _oNameTextText5 != null)
			{
				_oNameTextText5.text = value;
			}
		}
	}

	public string NameTextString6
	{
		get
		{
			if (_oNameTextText6 != null)
			{
				return _oNameTextText6.text;
			}
			return null;
		}
		set
		{
			if (NameTextString6 != value && _oNameTextText6 != null)
			{
				_oNameTextText6.text = value;
			}
		}
	}

	public string NameTextString7
	{
		get
		{
			if (_oNameTextText7 != null)
			{
				return _oNameTextText7.text;
			}
			return null;
		}
		set
		{
			if (NameTextString7 != value && _oNameTextText7 != null)
			{
				_oNameTextText7.text = value;
			}
		}
	}

	public string NameTextString8
	{
		get
		{
			if (_oNameTextText8 != null)
			{
				return _oNameTextText8.text;
			}
			return null;
		}
		set
		{
			if (NameTextString8 != value && _oNameTextText8 != null)
			{
				_oNameTextText8.text = value;
			}
		}
	}

	public string NameTextString9
	{
		get
		{
			if (_oNameTextText9 != null)
			{
				return _oNameTextText9.text;
			}
			return null;
		}
		set
		{
			if (NameTextString9 != value && _oNameTextText9 != null)
			{
				_oNameTextText9.text = value;
			}
		}
	}

	public string NameTextString10
	{
		get
		{
			if (_oNameTextText10 != null)
			{
				return _oNameTextText10.text;
			}
			return null;
		}
		set
		{
			if (NameTextString10 != value && _oNameTextText10 != null)
			{
				_oNameTextText10.text = value;
			}
		}
	}

	public string NameTextString11
	{
		get
		{
			if (_oNameTextText11 != null)
			{
				return _oNameTextText11.text;
			}
			return null;
		}
		set
		{
			if (NameTextString11 != value && _oNameTextText11 != null)
			{
				_oNameTextText11.text = value;
			}
		}
	}

	public string NameTextString12
	{
		get
		{
			if (_oNameTextText12 != null)
			{
				return _oNameTextText12.text;
			}
			return null;
		}
		set
		{
			if (NameTextString12 != value && _oNameTextText12 != null)
			{
				_oNameTextText12.text = value;
			}
		}
	}

	public string NameTextString13
	{
		get
		{
			if (_oNameTextText13 != null)
			{
				return _oNameTextText13.text;
			}
			return null;
		}
		set
		{
			if (NameTextString13 != value && _oNameTextText13 != null)
			{
				_oNameTextText13.text = value;
			}
		}
	}

	public string NameTextString14
	{
		get
		{
			if (_oNameTextText14 != null)
			{
				return _oNameTextText14.text;
			}
			return null;
		}
		set
		{
			if (NameTextString14 != value && _oNameTextText14 != null)
			{
				_oNameTextText14.text = value;
			}
		}
	}

	public string NameTextString15
	{
		get
		{
			if (_oNameTextText15 != null)
			{
				return _oNameTextText15.text;
			}
			return null;
		}
		set
		{
			if (NameTextString15 != value && _oNameTextText15 != null)
			{
				_oNameTextText15.text = value;
			}
		}
	}

	public string NameTextString16
	{
		get
		{
			if (_oNameTextText16 != null)
			{
				return _oNameTextText16.text;
			}
			return null;
		}
		set
		{
			if (NameTextString16 != value && _oNameTextText16 != null)
			{
				_oNameTextText16.text = value;
			}
		}
	}

	public string MoneyTextString1
	{
		get
		{
			if (_oMoneyTextText1 != null)
			{
				return _oMoneyTextText1.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString1 != value && _oMoneyTextText1 != null)
			{
				_oMoneyTextText1.text = value;
			}
		}
	}

	public string MoneyTextString2
	{
		get
		{
			if (_oMoneyTextText2 != null)
			{
				return _oMoneyTextText2.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString2 != value && _oMoneyTextText2 != null)
			{
				_oMoneyTextText2.text = value;
			}
		}
	}

	public string MoneyTextString3
	{
		get
		{
			if (_oMoneyTextText3 != null)
			{
				return _oMoneyTextText3.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString3 != value && _oMoneyTextText3 != null)
			{
				_oMoneyTextText3.text = value;
			}
		}
	}

	public string MoneyTextString4
	{
		get
		{
			if (_oMoneyTextText4 != null)
			{
				return _oMoneyTextText4.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString4 != value && _oMoneyTextText4 != null)
			{
				_oMoneyTextText4.text = value;
			}
		}
	}

	public string MoneyTextString5
	{
		get
		{
			if (_oMoneyTextText5 != null)
			{
				return _oMoneyTextText5.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString5 != value && _oMoneyTextText5 != null)
			{
				_oMoneyTextText5.text = value;
			}
		}
	}

	public string MoneyTextString6
	{
		get
		{
			if (_oMoneyTextText6 != null)
			{
				return _oMoneyTextText6.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString6 != value && _oMoneyTextText6 != null)
			{
				_oMoneyTextText6.text = value;
			}
		}
	}

	public string MoneyTextString7
	{
		get
		{
			if (_oMoneyTextText7 != null)
			{
				return _oMoneyTextText7.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString7 != value && _oMoneyTextText7 != null)
			{
				_oMoneyTextText7.text = value;
			}
		}
	}

	public string MoneyTextString8
	{
		get
		{
			if (_oMoneyTextText8 != null)
			{
				return _oMoneyTextText8.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString8 != value && _oMoneyTextText8 != null)
			{
				_oMoneyTextText8.text = value;
			}
		}
	}

	public string MoneyTextString9
	{
		get
		{
			if (_oMoneyTextText9 != null)
			{
				return _oMoneyTextText9.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString9 != value && _oMoneyTextText9 != null)
			{
				_oMoneyTextText9.text = value;
			}
		}
	}

	public string MoneyTextString10
	{
		get
		{
			if (_oMoneyTextText10 != null)
			{
				return _oMoneyTextText10.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString10 != value && _oMoneyTextText10 != null)
			{
				_oMoneyTextText10.text = value;
			}
		}
	}

	public string MoneyTextString11
	{
		get
		{
			if (_oMoneyTextText11 != null)
			{
				return _oMoneyTextText11.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString11 != value && _oMoneyTextText11 != null)
			{
				_oMoneyTextText11.text = value;
			}
		}
	}

	public string MoneyTextString12
	{
		get
		{
			if (_oMoneyTextText12 != null)
			{
				return _oMoneyTextText12.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString12 != value && _oMoneyTextText12 != null)
			{
				_oMoneyTextText12.text = value;
			}
		}
	}

	public string MoneyTextString13
	{
		get
		{
			if (_oMoneyTextText13 != null)
			{
				return _oMoneyTextText13.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString13 != value && _oMoneyTextText13 != null)
			{
				_oMoneyTextText13.text = value;
			}
		}
	}

	public string MoneyTextString14
	{
		get
		{
			if (_oMoneyTextText14 != null)
			{
				return _oMoneyTextText14.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString14 != value && _oMoneyTextText14 != null)
			{
				_oMoneyTextText14.text = value;
			}
		}
	}

	public string MoneyTextString15
	{
		get
		{
			if (_oMoneyTextText15 != null)
			{
				return _oMoneyTextText15.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString15 != value && _oMoneyTextText15 != null)
			{
				_oMoneyTextText15.text = value;
			}
		}
	}

	public string MoneyTextString16
	{
		get
		{
			if (_oMoneyTextText16 != null)
			{
				return _oMoneyTextText16.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString16 != value && _oMoneyTextText16 != null)
			{
				_oMoneyTextText16.text = value;
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
			case "TeamGrid1":
				_oTeamGrid1 = transform.gameObject;
				break;
			case "TeamGrid2":
				_oTeamGrid2 = transform.gameObject;
				break;
			case "NameText1":
				_oNameText1 = transform.gameObject;
				_oNameTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText2":
				_oNameText2 = transform.gameObject;
				_oNameTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText3":
				_oNameText3 = transform.gameObject;
				_oNameTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText4":
				_oNameText4 = transform.gameObject;
				_oNameTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText5":
				_oNameText5 = transform.gameObject;
				_oNameTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText6":
				_oNameText6 = transform.gameObject;
				_oNameTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText7":
				_oNameText7 = transform.gameObject;
				_oNameTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText8":
				_oNameText8 = transform.gameObject;
				_oNameTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText9":
				_oNameText9 = transform.gameObject;
				_oNameTextText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText10":
				_oNameText10 = transform.gameObject;
				_oNameTextText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText11":
				_oNameText11 = transform.gameObject;
				_oNameTextText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText12":
				_oNameText12 = transform.gameObject;
				_oNameTextText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText13":
				_oNameText13 = transform.gameObject;
				_oNameTextText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText14":
				_oNameText14 = transform.gameObject;
				_oNameTextText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText15":
				_oNameText15 = transform.gameObject;
				_oNameTextText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText16":
				_oNameText16 = transform.gameObject;
				_oNameTextText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText1":
				_oMoneyText1 = transform.gameObject;
				_oMoneyTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText2":
				_oMoneyText2 = transform.gameObject;
				_oMoneyTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText3":
				_oMoneyText3 = transform.gameObject;
				_oMoneyTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText4":
				_oMoneyText4 = transform.gameObject;
				_oMoneyTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText5":
				_oMoneyText5 = transform.gameObject;
				_oMoneyTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText6":
				_oMoneyText6 = transform.gameObject;
				_oMoneyTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText7":
				_oMoneyText7 = transform.gameObject;
				_oMoneyTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText8":
				_oMoneyText8 = transform.gameObject;
				_oMoneyTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText9":
				_oMoneyText9 = transform.gameObject;
				_oMoneyTextText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText10":
				_oMoneyText10 = transform.gameObject;
				_oMoneyTextText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText11":
				_oMoneyText11 = transform.gameObject;
				_oMoneyTextText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText12":
				_oMoneyText12 = transform.gameObject;
				_oMoneyTextText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText13":
				_oMoneyText13 = transform.gameObject;
				_oMoneyTextText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText14":
				_oMoneyText14 = transform.gameObject;
				_oMoneyTextText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText15":
				_oMoneyText15 = transform.gameObject;
				_oMoneyTextText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "MoneyText16":
				_oMoneyText16 = transform.gameObject;
				_oMoneyTextText16 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public GameObject GetTeamGridObj(int index)
	{
		return index switch
		{
			1 => TeamGridObj1, 
			2 => TeamGridObj2, 
			_ => null, 
		};
	}

	public bool GetNameTextShow(int index)
	{
		return index switch
		{
			1 => NameTextShow1, 
			2 => NameTextShow2, 
			3 => NameTextShow3, 
			4 => NameTextShow4, 
			5 => NameTextShow5, 
			6 => NameTextShow6, 
			7 => NameTextShow7, 
			8 => NameTextShow8, 
			9 => NameTextShow9, 
			10 => NameTextShow10, 
			11 => NameTextShow11, 
			12 => NameTextShow12, 
			13 => NameTextShow13, 
			14 => NameTextShow14, 
			15 => NameTextShow15, 
			16 => NameTextShow16, 
			_ => false, 
		};
	}

	public void SetNameTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NameTextShow1 = value;
			break;
		case 2:
			NameTextShow2 = value;
			break;
		case 3:
			NameTextShow3 = value;
			break;
		case 4:
			NameTextShow4 = value;
			break;
		case 5:
			NameTextShow5 = value;
			break;
		case 6:
			NameTextShow6 = value;
			break;
		case 7:
			NameTextShow7 = value;
			break;
		case 8:
			NameTextShow8 = value;
			break;
		case 9:
			NameTextShow9 = value;
			break;
		case 10:
			NameTextShow10 = value;
			break;
		case 11:
			NameTextShow11 = value;
			break;
		case 12:
			NameTextShow12 = value;
			break;
		case 13:
			NameTextShow13 = value;
			break;
		case 14:
			NameTextShow14 = value;
			break;
		case 15:
			NameTextShow15 = value;
			break;
		case 16:
			NameTextShow16 = value;
			break;
		}
	}

	public string GetNameTextString(int index)
	{
		return index switch
		{
			1 => NameTextString1, 
			2 => NameTextString2, 
			3 => NameTextString3, 
			4 => NameTextString4, 
			5 => NameTextString5, 
			6 => NameTextString6, 
			7 => NameTextString7, 
			8 => NameTextString8, 
			9 => NameTextString9, 
			10 => NameTextString10, 
			11 => NameTextString11, 
			12 => NameTextString12, 
			13 => NameTextString13, 
			14 => NameTextString14, 
			15 => NameTextString15, 
			16 => NameTextString16, 
			_ => null, 
		};
	}

	public void SetNameTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NameTextString1 = value;
			break;
		case 2:
			NameTextString2 = value;
			break;
		case 3:
			NameTextString3 = value;
			break;
		case 4:
			NameTextString4 = value;
			break;
		case 5:
			NameTextString5 = value;
			break;
		case 6:
			NameTextString6 = value;
			break;
		case 7:
			NameTextString7 = value;
			break;
		case 8:
			NameTextString8 = value;
			break;
		case 9:
			NameTextString9 = value;
			break;
		case 10:
			NameTextString10 = value;
			break;
		case 11:
			NameTextString11 = value;
			break;
		case 12:
			NameTextString12 = value;
			break;
		case 13:
			NameTextString13 = value;
			break;
		case 14:
			NameTextString14 = value;
			break;
		case 15:
			NameTextString15 = value;
			break;
		case 16:
			NameTextString16 = value;
			break;
		}
	}

	public string GetMoneyTextString(int index)
	{
		return index switch
		{
			1 => MoneyTextString1, 
			2 => MoneyTextString2, 
			3 => MoneyTextString3, 
			4 => MoneyTextString4, 
			5 => MoneyTextString5, 
			6 => MoneyTextString6, 
			7 => MoneyTextString7, 
			8 => MoneyTextString8, 
			9 => MoneyTextString9, 
			10 => MoneyTextString10, 
			11 => MoneyTextString11, 
			12 => MoneyTextString12, 
			13 => MoneyTextString13, 
			14 => MoneyTextString14, 
			15 => MoneyTextString15, 
			16 => MoneyTextString16, 
			_ => null, 
		};
	}

	public void SetMoneyTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			MoneyTextString1 = value;
			break;
		case 2:
			MoneyTextString2 = value;
			break;
		case 3:
			MoneyTextString3 = value;
			break;
		case 4:
			MoneyTextString4 = value;
			break;
		case 5:
			MoneyTextString5 = value;
			break;
		case 6:
			MoneyTextString6 = value;
			break;
		case 7:
			MoneyTextString7 = value;
			break;
		case 8:
			MoneyTextString8 = value;
			break;
		case 9:
			MoneyTextString9 = value;
			break;
		case 10:
			MoneyTextString10 = value;
			break;
		case 11:
			MoneyTextString11 = value;
			break;
		case 12:
			MoneyTextString12 = value;
			break;
		case 13:
			MoneyTextString13 = value;
			break;
		case 14:
			MoneyTextString14 = value;
			break;
		case 15:
			MoneyTextString15 = value;
			break;
		case 16:
			MoneyTextString16 = value;
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
