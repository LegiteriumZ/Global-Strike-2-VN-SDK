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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_Z_Shop_SkllViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBioChemical_Z_Shop_Skll;

	private RectTransform _oBioChemical_Z_Shop_SkllRectTransform;

	private GameObject _oShow;

	private GameObject _ol_1_skill1;

	private GameObject _ol_1_skill2;

	private GameObject _ol_1_skill3;

	private GameObject _ol_1_skill4;

	private GameObject _ol_1_skill5;

	private GameObject _ol_1_skill6;

	private GameObject _ol_1_skill7;

	private GameObject _ol_1_skill8;

	private GameObject _ol_1_skill9;

	private GameObject _ol_1_skill10;

	private GameObject _ol_1_skill11;

	private GameObject _ol_1_skill12;

	private GameObject _ol_1_skill13;

	private GameObject _ol_1_skill14;

	private GameObject _ol_1_skill15;

	private GameObject _ol_1_skill16;

	private GameObject _ol_1_skill17;

	private GameObject _ol_1_skill18;

	private GameObject _ol_1_skill19;

	private GameObject _ol_1_skill20;

	private GameObject _ol_1_skill21;

	private GameObject _ol_1_skill22;

	private GameObject _ol_1_skill23;

	private GameObject _ol_1_skill24;

	private GameObject _ol_1_skill25;

	private GameObject _ol_1_skill26;

	private GameObject _ol_1_skill27;

	private GameObject _ol_1_skill28;

	private GameObject _ol_1_skill29;

	private GameObject _ol_1_skill30;

	private GameObject _ol_1_skill31;

	private GameObject _ol_1_skill32;

	private GameObject _ol_1_skill33;

	private GameObject _ol_1_skill34;

	private GameObject _ol_1_skill35;

	private GameObject _ol_1_skill36;

	private GameObject _ol_1_skill37;

	private GameObject _ol_1_skill38;

	private GameObject _ol_1_skill39;

	private GameObject _ol_1_skill40;

	private GameObject _ol_1_skill41;

	private EventTrigger _ol_1_skillEventTrigger1;

	private EventTrigger _ol_1_skillEventTrigger2;

	private EventTrigger _ol_1_skillEventTrigger3;

	private EventTrigger _ol_1_skillEventTrigger4;

	private EventTrigger _ol_1_skillEventTrigger5;

	private EventTrigger _ol_1_skillEventTrigger6;

	private EventTrigger _ol_1_skillEventTrigger7;

	private EventTrigger _ol_1_skillEventTrigger8;

	private EventTrigger _ol_1_skillEventTrigger9;

	private EventTrigger _ol_1_skillEventTrigger10;

	private EventTrigger _ol_1_skillEventTrigger11;

	private EventTrigger _ol_1_skillEventTrigger12;

	private EventTrigger _ol_1_skillEventTrigger13;

	private EventTrigger _ol_1_skillEventTrigger14;

	private EventTrigger _ol_1_skillEventTrigger15;

	private EventTrigger _ol_1_skillEventTrigger16;

	private EventTrigger _ol_1_skillEventTrigger17;

	private EventTrigger _ol_1_skillEventTrigger18;

	private EventTrigger _ol_1_skillEventTrigger19;

	private EventTrigger _ol_1_skillEventTrigger20;

	private EventTrigger _ol_1_skillEventTrigger21;

	private EventTrigger _ol_1_skillEventTrigger22;

	private EventTrigger _ol_1_skillEventTrigger23;

	private EventTrigger _ol_1_skillEventTrigger24;

	private EventTrigger _ol_1_skillEventTrigger25;

	private EventTrigger _ol_1_skillEventTrigger26;

	private EventTrigger _ol_1_skillEventTrigger27;

	private EventTrigger _ol_1_skillEventTrigger28;

	private EventTrigger _ol_1_skillEventTrigger29;

	private EventTrigger _ol_1_skillEventTrigger30;

	private EventTrigger _ol_1_skillEventTrigger31;

	private EventTrigger _ol_1_skillEventTrigger32;

	private EventTrigger _ol_1_skillEventTrigger33;

	private EventTrigger _ol_1_skillEventTrigger34;

	private EventTrigger _ol_1_skillEventTrigger35;

	private EventTrigger _ol_1_skillEventTrigger36;

	private EventTrigger _ol_1_skillEventTrigger37;

	private EventTrigger _ol_1_skillEventTrigger38;

	private EventTrigger _ol_1_skillEventTrigger39;

	private EventTrigger _ol_1_skillEventTrigger40;

	private EventTrigger _ol_1_skillEventTrigger41;

	private GameObject _ol_1_Iconbg1;

	private GameObject _ol_1_Iconbg2;

	private GameObject _ol_1_Iconbg3;

	private GameObject _ol_1_Iconbg4;

	private GameObject _ol_1_Iconbg5;

	private GameObject _ol_1_Iconbg6;

	private GameObject _ol_1_Iconbg7;

	private GameObject _ol_1_Iconbg8;

	private GameObject _ol_1_Iconbg9;

	private GameObject _ol_1_Iconbg10;

	private GameObject _ol_1_Iconbg11;

	private GameObject _ol_1_Iconbg12;

	private GameObject _ol_1_Iconbg13;

	private GameObject _ol_1_Iconbg14;

	private GameObject _ol_1_Iconbg15;

	private GameObject _ol_1_Iconbg16;

	private GameObject _ol_1_Iconbg17;

	private GameObject _ol_1_Iconbg18;

	private GameObject _ol_1_Iconbg19;

	private GameObject _ol_1_Iconbg20;

	private GameObject _ol_1_Iconbg21;

	private GameObject _ol_1_Iconbg22;

	private GameObject _ol_1_Iconbg23;

	private GameObject _ol_1_Iconbg24;

	private GameObject _ol_1_Iconbg25;

	private GameObject _ol_1_Iconbg26;

	private GameObject _ol_1_Iconbg27;

	private GameObject _ol_1_Iconbg28;

	private GameObject _ol_1_Iconbg29;

	private GameObject _ol_1_Iconbg30;

	private GameObject _ol_1_Iconbg31;

	private GameObject _ol_1_Iconbg32;

	private GameObject _ol_1_Iconbg33;

	private GameObject _ol_1_Iconbg34;

	private GameObject _ol_1_Iconbg35;

	private GameObject _ol_1_Iconbg36;

	private GameObject _ol_1_Iconbg37;

	private GameObject _ol_1_Iconbg38;

	private GameObject _ol_1_Iconbg39;

	private GameObject _ol_1_Iconbg40;

	private GameObject _ol_1_Iconbg41;

	private Image _ol_1_IconbgImage1;

	private Image _ol_1_IconbgImage2;

	private Image _ol_1_IconbgImage3;

	private Image _ol_1_IconbgImage4;

	private Image _ol_1_IconbgImage5;

	private Image _ol_1_IconbgImage6;

	private Image _ol_1_IconbgImage7;

	private Image _ol_1_IconbgImage8;

	private Image _ol_1_IconbgImage9;

	private Image _ol_1_IconbgImage10;

	private Image _ol_1_IconbgImage11;

	private Image _ol_1_IconbgImage12;

	private Image _ol_1_IconbgImage13;

	private Image _ol_1_IconbgImage14;

	private Image _ol_1_IconbgImage15;

	private Image _ol_1_IconbgImage16;

	private Image _ol_1_IconbgImage17;

	private Image _ol_1_IconbgImage18;

	private Image _ol_1_IconbgImage19;

	private Image _ol_1_IconbgImage20;

	private Image _ol_1_IconbgImage21;

	private Image _ol_1_IconbgImage22;

	private Image _ol_1_IconbgImage23;

	private Image _ol_1_IconbgImage24;

	private Image _ol_1_IconbgImage25;

	private Image _ol_1_IconbgImage26;

	private Image _ol_1_IconbgImage27;

	private Image _ol_1_IconbgImage28;

	private Image _ol_1_IconbgImage29;

	private Image _ol_1_IconbgImage30;

	private Image _ol_1_IconbgImage31;

	private Image _ol_1_IconbgImage32;

	private Image _ol_1_IconbgImage33;

	private Image _ol_1_IconbgImage34;

	private Image _ol_1_IconbgImage35;

	private Image _ol_1_IconbgImage36;

	private Image _ol_1_IconbgImage37;

	private Image _ol_1_IconbgImage38;

	private Image _ol_1_IconbgImage39;

	private Image _ol_1_IconbgImage40;

	private Image _ol_1_IconbgImage41;

	private GameObject _ol_1_Icon1;

	private GameObject _ol_1_Icon2;

	private GameObject _ol_1_Icon3;

	private GameObject _ol_1_Icon4;

	private GameObject _ol_1_Icon5;

	private GameObject _ol_1_Icon6;

	private GameObject _ol_1_Icon7;

	private GameObject _ol_1_Icon8;

	private GameObject _ol_1_Icon9;

	private GameObject _ol_1_Icon10;

	private GameObject _ol_1_Icon11;

	private GameObject _ol_1_Icon12;

	private GameObject _ol_1_Icon13;

	private GameObject _ol_1_Icon14;

	private GameObject _ol_1_Icon15;

	private GameObject _ol_1_Icon16;

	private GameObject _ol_1_Icon17;

	private GameObject _ol_1_Icon18;

	private GameObject _ol_1_Icon19;

	private GameObject _ol_1_Icon20;

	private GameObject _ol_1_Icon21;

	private GameObject _ol_1_Icon22;

	private GameObject _ol_1_Icon23;

	private GameObject _ol_1_Icon24;

	private GameObject _ol_1_Icon25;

	private GameObject _ol_1_Icon26;

	private GameObject _ol_1_Icon27;

	private GameObject _ol_1_Icon28;

	private GameObject _ol_1_Icon29;

	private GameObject _ol_1_Icon30;

	private GameObject _ol_1_Icon31;

	private GameObject _ol_1_Icon32;

	private GameObject _ol_1_Icon33;

	private GameObject _ol_1_Icon34;

	private GameObject _ol_1_Icon35;

	private GameObject _ol_1_Icon36;

	private GameObject _ol_1_Icon37;

	private GameObject _ol_1_Icon38;

	private GameObject _ol_1_Icon39;

	private GameObject _ol_1_Icon40;

	private GameObject _ol_1_Icon41;

	private Image _ol_1_IconImage1;

	private Image _ol_1_IconImage2;

	private Image _ol_1_IconImage3;

	private Image _ol_1_IconImage4;

	private Image _ol_1_IconImage5;

	private Image _ol_1_IconImage6;

	private Image _ol_1_IconImage7;

	private Image _ol_1_IconImage8;

	private Image _ol_1_IconImage9;

	private Image _ol_1_IconImage10;

	private Image _ol_1_IconImage11;

	private Image _ol_1_IconImage12;

	private Image _ol_1_IconImage13;

	private Image _ol_1_IconImage14;

	private Image _ol_1_IconImage15;

	private Image _ol_1_IconImage16;

	private Image _ol_1_IconImage17;

	private Image _ol_1_IconImage18;

	private Image _ol_1_IconImage19;

	private Image _ol_1_IconImage20;

	private Image _ol_1_IconImage21;

	private Image _ol_1_IconImage22;

	private Image _ol_1_IconImage23;

	private Image _ol_1_IconImage24;

	private Image _ol_1_IconImage25;

	private Image _ol_1_IconImage26;

	private Image _ol_1_IconImage27;

	private Image _ol_1_IconImage28;

	private Image _ol_1_IconImage29;

	private Image _ol_1_IconImage30;

	private Image _ol_1_IconImage31;

	private Image _ol_1_IconImage32;

	private Image _ol_1_IconImage33;

	private Image _ol_1_IconImage34;

	private Image _ol_1_IconImage35;

	private Image _ol_1_IconImage36;

	private Image _ol_1_IconImage37;

	private Image _ol_1_IconImage38;

	private Image _ol_1_IconImage39;

	private Image _ol_1_IconImage40;

	private Image _ol_1_IconImage41;

	private GameObject _ol_1_Name1;

	private GameObject _ol_1_Name2;

	private GameObject _ol_1_Name3;

	private GameObject _ol_1_Name4;

	private GameObject _ol_1_Name5;

	private GameObject _ol_1_Name6;

	private GameObject _ol_1_Name7;

	private GameObject _ol_1_Name8;

	private GameObject _ol_1_Name9;

	private GameObject _ol_1_Name10;

	private GameObject _ol_1_Name11;

	private GameObject _ol_1_Name12;

	private GameObject _ol_1_Name13;

	private GameObject _ol_1_Name14;

	private GameObject _ol_1_Name15;

	private GameObject _ol_1_Name16;

	private GameObject _ol_1_Name17;

	private GameObject _ol_1_Name18;

	private GameObject _ol_1_Name19;

	private GameObject _ol_1_Name20;

	private GameObject _ol_1_Name21;

	private GameObject _ol_1_Name22;

	private GameObject _ol_1_Name23;

	private GameObject _ol_1_Name24;

	private GameObject _ol_1_Name25;

	private GameObject _ol_1_Name26;

	private GameObject _ol_1_Name27;

	private GameObject _ol_1_Name28;

	private GameObject _ol_1_Name29;

	private GameObject _ol_1_Name30;

	private GameObject _ol_1_Name31;

	private GameObject _ol_1_Name32;

	private GameObject _ol_1_Name33;

	private GameObject _ol_1_Name34;

	private GameObject _ol_1_Name35;

	private GameObject _ol_1_Name36;

	private GameObject _ol_1_Name37;

	private GameObject _ol_1_Name38;

	private GameObject _ol_1_Name39;

	private GameObject _ol_1_Name40;

	private GameObject _ol_1_Name41;

	private Text _ol_1_NameText1;

	private Text _ol_1_NameText2;

	private Text _ol_1_NameText3;

	private Text _ol_1_NameText4;

	private Text _ol_1_NameText5;

	private Text _ol_1_NameText6;

	private Text _ol_1_NameText7;

	private Text _ol_1_NameText8;

	private Text _ol_1_NameText9;

	private Text _ol_1_NameText10;

	private Text _ol_1_NameText11;

	private Text _ol_1_NameText12;

	private Text _ol_1_NameText13;

	private Text _ol_1_NameText14;

	private Text _ol_1_NameText15;

	private Text _ol_1_NameText16;

	private Text _ol_1_NameText17;

	private Text _ol_1_NameText18;

	private Text _ol_1_NameText19;

	private Text _ol_1_NameText20;

	private Text _ol_1_NameText21;

	private Text _ol_1_NameText22;

	private Text _ol_1_NameText23;

	private Text _ol_1_NameText24;

	private Text _ol_1_NameText25;

	private Text _ol_1_NameText26;

	private Text _ol_1_NameText27;

	private Text _ol_1_NameText28;

	private Text _ol_1_NameText29;

	private Text _ol_1_NameText30;

	private Text _ol_1_NameText31;

	private Text _ol_1_NameText32;

	private Text _ol_1_NameText33;

	private Text _ol_1_NameText34;

	private Text _ol_1_NameText35;

	private Text _ol_1_NameText36;

	private Text _ol_1_NameText37;

	private Text _ol_1_NameText38;

	private Text _ol_1_NameText39;

	private Text _ol_1_NameText40;

	private Text _ol_1_NameText41;

	private GameObject _oshop_r;

	private Button _oshop_rButton;

	private GameObject _oclose;

	private Button _ocloseButton;

	private GameObject _omsg;

	private RectTransform _omsgRectTransform;

	private Image _omsgImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_z_shop_skll";

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

	public Vector3 BioChemical_Z_Shop_SkllPosition
	{
		get
		{
			if (_oBioChemical_Z_Shop_SkllRectTransform != null)
			{
				return _oBioChemical_Z_Shop_SkllRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BioChemical_Z_Shop_SkllPosition != value && _oBioChemical_Z_Shop_SkllRectTransform != null)
			{
				_oBioChemical_Z_Shop_SkllRectTransform.localPosition = value;
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

	public bool l_1_skillShow1
	{
		get
		{
			if (_ol_1_skill1 != null)
			{
				return _ol_1_skill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow1 != value && _ol_1_skill1 != null)
			{
				_ol_1_skill1.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow2
	{
		get
		{
			if (_ol_1_skill2 != null)
			{
				return _ol_1_skill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow2 != value && _ol_1_skill2 != null)
			{
				_ol_1_skill2.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow3
	{
		get
		{
			if (_ol_1_skill3 != null)
			{
				return _ol_1_skill3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow3 != value && _ol_1_skill3 != null)
			{
				_ol_1_skill3.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow4
	{
		get
		{
			if (_ol_1_skill4 != null)
			{
				return _ol_1_skill4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow4 != value && _ol_1_skill4 != null)
			{
				_ol_1_skill4.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow5
	{
		get
		{
			if (_ol_1_skill5 != null)
			{
				return _ol_1_skill5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow5 != value && _ol_1_skill5 != null)
			{
				_ol_1_skill5.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow6
	{
		get
		{
			if (_ol_1_skill6 != null)
			{
				return _ol_1_skill6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow6 != value && _ol_1_skill6 != null)
			{
				_ol_1_skill6.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow7
	{
		get
		{
			if (_ol_1_skill7 != null)
			{
				return _ol_1_skill7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow7 != value && _ol_1_skill7 != null)
			{
				_ol_1_skill7.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow8
	{
		get
		{
			if (_ol_1_skill8 != null)
			{
				return _ol_1_skill8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow8 != value && _ol_1_skill8 != null)
			{
				_ol_1_skill8.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow9
	{
		get
		{
			if (_ol_1_skill9 != null)
			{
				return _ol_1_skill9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow9 != value && _ol_1_skill9 != null)
			{
				_ol_1_skill9.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow10
	{
		get
		{
			if (_ol_1_skill10 != null)
			{
				return _ol_1_skill10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow10 != value && _ol_1_skill10 != null)
			{
				_ol_1_skill10.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow11
	{
		get
		{
			if (_ol_1_skill11 != null)
			{
				return _ol_1_skill11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow11 != value && _ol_1_skill11 != null)
			{
				_ol_1_skill11.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow12
	{
		get
		{
			if (_ol_1_skill12 != null)
			{
				return _ol_1_skill12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow12 != value && _ol_1_skill12 != null)
			{
				_ol_1_skill12.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow13
	{
		get
		{
			if (_ol_1_skill13 != null)
			{
				return _ol_1_skill13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow13 != value && _ol_1_skill13 != null)
			{
				_ol_1_skill13.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow14
	{
		get
		{
			if (_ol_1_skill14 != null)
			{
				return _ol_1_skill14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow14 != value && _ol_1_skill14 != null)
			{
				_ol_1_skill14.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow15
	{
		get
		{
			if (_ol_1_skill15 != null)
			{
				return _ol_1_skill15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow15 != value && _ol_1_skill15 != null)
			{
				_ol_1_skill15.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow16
	{
		get
		{
			if (_ol_1_skill16 != null)
			{
				return _ol_1_skill16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow16 != value && _ol_1_skill16 != null)
			{
				_ol_1_skill16.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow17
	{
		get
		{
			if (_ol_1_skill17 != null)
			{
				return _ol_1_skill17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow17 != value && _ol_1_skill17 != null)
			{
				_ol_1_skill17.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow18
	{
		get
		{
			if (_ol_1_skill18 != null)
			{
				return _ol_1_skill18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow18 != value && _ol_1_skill18 != null)
			{
				_ol_1_skill18.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow19
	{
		get
		{
			if (_ol_1_skill19 != null)
			{
				return _ol_1_skill19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow19 != value && _ol_1_skill19 != null)
			{
				_ol_1_skill19.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow20
	{
		get
		{
			if (_ol_1_skill20 != null)
			{
				return _ol_1_skill20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow20 != value && _ol_1_skill20 != null)
			{
				_ol_1_skill20.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow21
	{
		get
		{
			if (_ol_1_skill21 != null)
			{
				return _ol_1_skill21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow21 != value && _ol_1_skill21 != null)
			{
				_ol_1_skill21.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow22
	{
		get
		{
			if (_ol_1_skill22 != null)
			{
				return _ol_1_skill22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow22 != value && _ol_1_skill22 != null)
			{
				_ol_1_skill22.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow23
	{
		get
		{
			if (_ol_1_skill23 != null)
			{
				return _ol_1_skill23.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow23 != value && _ol_1_skill23 != null)
			{
				_ol_1_skill23.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow24
	{
		get
		{
			if (_ol_1_skill24 != null)
			{
				return _ol_1_skill24.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow24 != value && _ol_1_skill24 != null)
			{
				_ol_1_skill24.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow25
	{
		get
		{
			if (_ol_1_skill25 != null)
			{
				return _ol_1_skill25.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow25 != value && _ol_1_skill25 != null)
			{
				_ol_1_skill25.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow26
	{
		get
		{
			if (_ol_1_skill26 != null)
			{
				return _ol_1_skill26.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow26 != value && _ol_1_skill26 != null)
			{
				_ol_1_skill26.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow27
	{
		get
		{
			if (_ol_1_skill27 != null)
			{
				return _ol_1_skill27.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow27 != value && _ol_1_skill27 != null)
			{
				_ol_1_skill27.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow28
	{
		get
		{
			if (_ol_1_skill28 != null)
			{
				return _ol_1_skill28.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow28 != value && _ol_1_skill28 != null)
			{
				_ol_1_skill28.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow29
	{
		get
		{
			if (_ol_1_skill29 != null)
			{
				return _ol_1_skill29.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow29 != value && _ol_1_skill29 != null)
			{
				_ol_1_skill29.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow30
	{
		get
		{
			if (_ol_1_skill30 != null)
			{
				return _ol_1_skill30.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow30 != value && _ol_1_skill30 != null)
			{
				_ol_1_skill30.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow31
	{
		get
		{
			if (_ol_1_skill31 != null)
			{
				return _ol_1_skill31.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow31 != value && _ol_1_skill31 != null)
			{
				_ol_1_skill31.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow32
	{
		get
		{
			if (_ol_1_skill32 != null)
			{
				return _ol_1_skill32.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow32 != value && _ol_1_skill32 != null)
			{
				_ol_1_skill32.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow33
	{
		get
		{
			if (_ol_1_skill33 != null)
			{
				return _ol_1_skill33.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow33 != value && _ol_1_skill33 != null)
			{
				_ol_1_skill33.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow34
	{
		get
		{
			if (_ol_1_skill34 != null)
			{
				return _ol_1_skill34.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow34 != value && _ol_1_skill34 != null)
			{
				_ol_1_skill34.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow35
	{
		get
		{
			if (_ol_1_skill35 != null)
			{
				return _ol_1_skill35.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow35 != value && _ol_1_skill35 != null)
			{
				_ol_1_skill35.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow36
	{
		get
		{
			if (_ol_1_skill36 != null)
			{
				return _ol_1_skill36.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow36 != value && _ol_1_skill36 != null)
			{
				_ol_1_skill36.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow37
	{
		get
		{
			if (_ol_1_skill37 != null)
			{
				return _ol_1_skill37.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow37 != value && _ol_1_skill37 != null)
			{
				_ol_1_skill37.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow38
	{
		get
		{
			if (_ol_1_skill38 != null)
			{
				return _ol_1_skill38.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow38 != value && _ol_1_skill38 != null)
			{
				_ol_1_skill38.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow39
	{
		get
		{
			if (_ol_1_skill39 != null)
			{
				return _ol_1_skill39.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow39 != value && _ol_1_skill39 != null)
			{
				_ol_1_skill39.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow40
	{
		get
		{
			if (_ol_1_skill40 != null)
			{
				return _ol_1_skill40.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow40 != value && _ol_1_skill40 != null)
			{
				_ol_1_skill40.SetObjectActive(value);
			}
		}
	}

	public bool l_1_skillShow41
	{
		get
		{
			if (_ol_1_skill41 != null)
			{
				return _ol_1_skill41.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_skillShow41 != value && _ol_1_skill41 != null)
			{
				_ol_1_skill41.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers1
	{
		get
		{
			if (_ol_1_skillEventTrigger1 != null)
			{
				return _ol_1_skillEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers1 != value && _ol_1_skillEventTrigger1 != null)
			{
				_ol_1_skillEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers2
	{
		get
		{
			if (_ol_1_skillEventTrigger2 != null)
			{
				return _ol_1_skillEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers2 != value && _ol_1_skillEventTrigger2 != null)
			{
				_ol_1_skillEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers3
	{
		get
		{
			if (_ol_1_skillEventTrigger3 != null)
			{
				return _ol_1_skillEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers3 != value && _ol_1_skillEventTrigger3 != null)
			{
				_ol_1_skillEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers4
	{
		get
		{
			if (_ol_1_skillEventTrigger4 != null)
			{
				return _ol_1_skillEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers4 != value && _ol_1_skillEventTrigger4 != null)
			{
				_ol_1_skillEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers5
	{
		get
		{
			if (_ol_1_skillEventTrigger5 != null)
			{
				return _ol_1_skillEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers5 != value && _ol_1_skillEventTrigger5 != null)
			{
				_ol_1_skillEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers6
	{
		get
		{
			if (_ol_1_skillEventTrigger6 != null)
			{
				return _ol_1_skillEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers6 != value && _ol_1_skillEventTrigger6 != null)
			{
				_ol_1_skillEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers7
	{
		get
		{
			if (_ol_1_skillEventTrigger7 != null)
			{
				return _ol_1_skillEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers7 != value && _ol_1_skillEventTrigger7 != null)
			{
				_ol_1_skillEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers8
	{
		get
		{
			if (_ol_1_skillEventTrigger8 != null)
			{
				return _ol_1_skillEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers8 != value && _ol_1_skillEventTrigger8 != null)
			{
				_ol_1_skillEventTrigger8.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers9
	{
		get
		{
			if (_ol_1_skillEventTrigger9 != null)
			{
				return _ol_1_skillEventTrigger9.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers9 != value && _ol_1_skillEventTrigger9 != null)
			{
				_ol_1_skillEventTrigger9.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers10
	{
		get
		{
			if (_ol_1_skillEventTrigger10 != null)
			{
				return _ol_1_skillEventTrigger10.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers10 != value && _ol_1_skillEventTrigger10 != null)
			{
				_ol_1_skillEventTrigger10.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers11
	{
		get
		{
			if (_ol_1_skillEventTrigger11 != null)
			{
				return _ol_1_skillEventTrigger11.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers11 != value && _ol_1_skillEventTrigger11 != null)
			{
				_ol_1_skillEventTrigger11.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers12
	{
		get
		{
			if (_ol_1_skillEventTrigger12 != null)
			{
				return _ol_1_skillEventTrigger12.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers12 != value && _ol_1_skillEventTrigger12 != null)
			{
				_ol_1_skillEventTrigger12.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers13
	{
		get
		{
			if (_ol_1_skillEventTrigger13 != null)
			{
				return _ol_1_skillEventTrigger13.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers13 != value && _ol_1_skillEventTrigger13 != null)
			{
				_ol_1_skillEventTrigger13.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers14
	{
		get
		{
			if (_ol_1_skillEventTrigger14 != null)
			{
				return _ol_1_skillEventTrigger14.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers14 != value && _ol_1_skillEventTrigger14 != null)
			{
				_ol_1_skillEventTrigger14.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers15
	{
		get
		{
			if (_ol_1_skillEventTrigger15 != null)
			{
				return _ol_1_skillEventTrigger15.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers15 != value && _ol_1_skillEventTrigger15 != null)
			{
				_ol_1_skillEventTrigger15.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers16
	{
		get
		{
			if (_ol_1_skillEventTrigger16 != null)
			{
				return _ol_1_skillEventTrigger16.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers16 != value && _ol_1_skillEventTrigger16 != null)
			{
				_ol_1_skillEventTrigger16.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers17
	{
		get
		{
			if (_ol_1_skillEventTrigger17 != null)
			{
				return _ol_1_skillEventTrigger17.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers17 != value && _ol_1_skillEventTrigger17 != null)
			{
				_ol_1_skillEventTrigger17.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers18
	{
		get
		{
			if (_ol_1_skillEventTrigger18 != null)
			{
				return _ol_1_skillEventTrigger18.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers18 != value && _ol_1_skillEventTrigger18 != null)
			{
				_ol_1_skillEventTrigger18.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers19
	{
		get
		{
			if (_ol_1_skillEventTrigger19 != null)
			{
				return _ol_1_skillEventTrigger19.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers19 != value && _ol_1_skillEventTrigger19 != null)
			{
				_ol_1_skillEventTrigger19.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers20
	{
		get
		{
			if (_ol_1_skillEventTrigger20 != null)
			{
				return _ol_1_skillEventTrigger20.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers20 != value && _ol_1_skillEventTrigger20 != null)
			{
				_ol_1_skillEventTrigger20.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers21
	{
		get
		{
			if (_ol_1_skillEventTrigger21 != null)
			{
				return _ol_1_skillEventTrigger21.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers21 != value && _ol_1_skillEventTrigger21 != null)
			{
				_ol_1_skillEventTrigger21.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers22
	{
		get
		{
			if (_ol_1_skillEventTrigger22 != null)
			{
				return _ol_1_skillEventTrigger22.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers22 != value && _ol_1_skillEventTrigger22 != null)
			{
				_ol_1_skillEventTrigger22.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers23
	{
		get
		{
			if (_ol_1_skillEventTrigger23 != null)
			{
				return _ol_1_skillEventTrigger23.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers23 != value && _ol_1_skillEventTrigger23 != null)
			{
				_ol_1_skillEventTrigger23.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers24
	{
		get
		{
			if (_ol_1_skillEventTrigger24 != null)
			{
				return _ol_1_skillEventTrigger24.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers24 != value && _ol_1_skillEventTrigger24 != null)
			{
				_ol_1_skillEventTrigger24.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers25
	{
		get
		{
			if (_ol_1_skillEventTrigger25 != null)
			{
				return _ol_1_skillEventTrigger25.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers25 != value && _ol_1_skillEventTrigger25 != null)
			{
				_ol_1_skillEventTrigger25.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers26
	{
		get
		{
			if (_ol_1_skillEventTrigger26 != null)
			{
				return _ol_1_skillEventTrigger26.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers26 != value && _ol_1_skillEventTrigger26 != null)
			{
				_ol_1_skillEventTrigger26.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers27
	{
		get
		{
			if (_ol_1_skillEventTrigger27 != null)
			{
				return _ol_1_skillEventTrigger27.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers27 != value && _ol_1_skillEventTrigger27 != null)
			{
				_ol_1_skillEventTrigger27.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers28
	{
		get
		{
			if (_ol_1_skillEventTrigger28 != null)
			{
				return _ol_1_skillEventTrigger28.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers28 != value && _ol_1_skillEventTrigger28 != null)
			{
				_ol_1_skillEventTrigger28.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers29
	{
		get
		{
			if (_ol_1_skillEventTrigger29 != null)
			{
				return _ol_1_skillEventTrigger29.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers29 != value && _ol_1_skillEventTrigger29 != null)
			{
				_ol_1_skillEventTrigger29.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers30
	{
		get
		{
			if (_ol_1_skillEventTrigger30 != null)
			{
				return _ol_1_skillEventTrigger30.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers30 != value && _ol_1_skillEventTrigger30 != null)
			{
				_ol_1_skillEventTrigger30.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers31
	{
		get
		{
			if (_ol_1_skillEventTrigger31 != null)
			{
				return _ol_1_skillEventTrigger31.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers31 != value && _ol_1_skillEventTrigger31 != null)
			{
				_ol_1_skillEventTrigger31.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers32
	{
		get
		{
			if (_ol_1_skillEventTrigger32 != null)
			{
				return _ol_1_skillEventTrigger32.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers32 != value && _ol_1_skillEventTrigger32 != null)
			{
				_ol_1_skillEventTrigger32.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers33
	{
		get
		{
			if (_ol_1_skillEventTrigger33 != null)
			{
				return _ol_1_skillEventTrigger33.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers33 != value && _ol_1_skillEventTrigger33 != null)
			{
				_ol_1_skillEventTrigger33.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers34
	{
		get
		{
			if (_ol_1_skillEventTrigger34 != null)
			{
				return _ol_1_skillEventTrigger34.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers34 != value && _ol_1_skillEventTrigger34 != null)
			{
				_ol_1_skillEventTrigger34.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers35
	{
		get
		{
			if (_ol_1_skillEventTrigger35 != null)
			{
				return _ol_1_skillEventTrigger35.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers35 != value && _ol_1_skillEventTrigger35 != null)
			{
				_ol_1_skillEventTrigger35.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers36
	{
		get
		{
			if (_ol_1_skillEventTrigger36 != null)
			{
				return _ol_1_skillEventTrigger36.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers36 != value && _ol_1_skillEventTrigger36 != null)
			{
				_ol_1_skillEventTrigger36.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers37
	{
		get
		{
			if (_ol_1_skillEventTrigger37 != null)
			{
				return _ol_1_skillEventTrigger37.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers37 != value && _ol_1_skillEventTrigger37 != null)
			{
				_ol_1_skillEventTrigger37.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers38
	{
		get
		{
			if (_ol_1_skillEventTrigger38 != null)
			{
				return _ol_1_skillEventTrigger38.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers38 != value && _ol_1_skillEventTrigger38 != null)
			{
				_ol_1_skillEventTrigger38.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers39
	{
		get
		{
			if (_ol_1_skillEventTrigger39 != null)
			{
				return _ol_1_skillEventTrigger39.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers39 != value && _ol_1_skillEventTrigger39 != null)
			{
				_ol_1_skillEventTrigger39.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers40
	{
		get
		{
			if (_ol_1_skillEventTrigger40 != null)
			{
				return _ol_1_skillEventTrigger40.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers40 != value && _ol_1_skillEventTrigger40 != null)
			{
				_ol_1_skillEventTrigger40.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> l_1_skillTriggers41
	{
		get
		{
			if (_ol_1_skillEventTrigger41 != null)
			{
				return _ol_1_skillEventTrigger41.triggers;
			}
			return null;
		}
		set
		{
			if (l_1_skillTriggers41 != value && _ol_1_skillEventTrigger41 != null)
			{
				_ol_1_skillEventTrigger41.triggers = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite1
	{
		get
		{
			if (_ol_1_IconbgImage1 != null)
			{
				return _ol_1_IconbgImage1.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite1 != value && _ol_1_IconbgImage1 != null)
			{
				_ol_1_IconbgImage1.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite2
	{
		get
		{
			if (_ol_1_IconbgImage2 != null)
			{
				return _ol_1_IconbgImage2.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite2 != value && _ol_1_IconbgImage2 != null)
			{
				_ol_1_IconbgImage2.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite3
	{
		get
		{
			if (_ol_1_IconbgImage3 != null)
			{
				return _ol_1_IconbgImage3.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite3 != value && _ol_1_IconbgImage3 != null)
			{
				_ol_1_IconbgImage3.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite4
	{
		get
		{
			if (_ol_1_IconbgImage4 != null)
			{
				return _ol_1_IconbgImage4.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite4 != value && _ol_1_IconbgImage4 != null)
			{
				_ol_1_IconbgImage4.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite5
	{
		get
		{
			if (_ol_1_IconbgImage5 != null)
			{
				return _ol_1_IconbgImage5.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite5 != value && _ol_1_IconbgImage5 != null)
			{
				_ol_1_IconbgImage5.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite6
	{
		get
		{
			if (_ol_1_IconbgImage6 != null)
			{
				return _ol_1_IconbgImage6.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite6 != value && _ol_1_IconbgImage6 != null)
			{
				_ol_1_IconbgImage6.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite7
	{
		get
		{
			if (_ol_1_IconbgImage7 != null)
			{
				return _ol_1_IconbgImage7.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite7 != value && _ol_1_IconbgImage7 != null)
			{
				_ol_1_IconbgImage7.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite8
	{
		get
		{
			if (_ol_1_IconbgImage8 != null)
			{
				return _ol_1_IconbgImage8.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite8 != value && _ol_1_IconbgImage8 != null)
			{
				_ol_1_IconbgImage8.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite9
	{
		get
		{
			if (_ol_1_IconbgImage9 != null)
			{
				return _ol_1_IconbgImage9.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite9 != value && _ol_1_IconbgImage9 != null)
			{
				_ol_1_IconbgImage9.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite10
	{
		get
		{
			if (_ol_1_IconbgImage10 != null)
			{
				return _ol_1_IconbgImage10.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite10 != value && _ol_1_IconbgImage10 != null)
			{
				_ol_1_IconbgImage10.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite11
	{
		get
		{
			if (_ol_1_IconbgImage11 != null)
			{
				return _ol_1_IconbgImage11.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite11 != value && _ol_1_IconbgImage11 != null)
			{
				_ol_1_IconbgImage11.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite12
	{
		get
		{
			if (_ol_1_IconbgImage12 != null)
			{
				return _ol_1_IconbgImage12.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite12 != value && _ol_1_IconbgImage12 != null)
			{
				_ol_1_IconbgImage12.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite13
	{
		get
		{
			if (_ol_1_IconbgImage13 != null)
			{
				return _ol_1_IconbgImage13.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite13 != value && _ol_1_IconbgImage13 != null)
			{
				_ol_1_IconbgImage13.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite14
	{
		get
		{
			if (_ol_1_IconbgImage14 != null)
			{
				return _ol_1_IconbgImage14.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite14 != value && _ol_1_IconbgImage14 != null)
			{
				_ol_1_IconbgImage14.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite15
	{
		get
		{
			if (_ol_1_IconbgImage15 != null)
			{
				return _ol_1_IconbgImage15.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite15 != value && _ol_1_IconbgImage15 != null)
			{
				_ol_1_IconbgImage15.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite16
	{
		get
		{
			if (_ol_1_IconbgImage16 != null)
			{
				return _ol_1_IconbgImage16.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite16 != value && _ol_1_IconbgImage16 != null)
			{
				_ol_1_IconbgImage16.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite17
	{
		get
		{
			if (_ol_1_IconbgImage17 != null)
			{
				return _ol_1_IconbgImage17.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite17 != value && _ol_1_IconbgImage17 != null)
			{
				_ol_1_IconbgImage17.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite18
	{
		get
		{
			if (_ol_1_IconbgImage18 != null)
			{
				return _ol_1_IconbgImage18.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite18 != value && _ol_1_IconbgImage18 != null)
			{
				_ol_1_IconbgImage18.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite19
	{
		get
		{
			if (_ol_1_IconbgImage19 != null)
			{
				return _ol_1_IconbgImage19.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite19 != value && _ol_1_IconbgImage19 != null)
			{
				_ol_1_IconbgImage19.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite20
	{
		get
		{
			if (_ol_1_IconbgImage20 != null)
			{
				return _ol_1_IconbgImage20.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite20 != value && _ol_1_IconbgImage20 != null)
			{
				_ol_1_IconbgImage20.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite21
	{
		get
		{
			if (_ol_1_IconbgImage21 != null)
			{
				return _ol_1_IconbgImage21.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite21 != value && _ol_1_IconbgImage21 != null)
			{
				_ol_1_IconbgImage21.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite22
	{
		get
		{
			if (_ol_1_IconbgImage22 != null)
			{
				return _ol_1_IconbgImage22.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite22 != value && _ol_1_IconbgImage22 != null)
			{
				_ol_1_IconbgImage22.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite23
	{
		get
		{
			if (_ol_1_IconbgImage23 != null)
			{
				return _ol_1_IconbgImage23.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite23 != value && _ol_1_IconbgImage23 != null)
			{
				_ol_1_IconbgImage23.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite24
	{
		get
		{
			if (_ol_1_IconbgImage24 != null)
			{
				return _ol_1_IconbgImage24.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite24 != value && _ol_1_IconbgImage24 != null)
			{
				_ol_1_IconbgImage24.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite25
	{
		get
		{
			if (_ol_1_IconbgImage25 != null)
			{
				return _ol_1_IconbgImage25.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite25 != value && _ol_1_IconbgImage25 != null)
			{
				_ol_1_IconbgImage25.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite26
	{
		get
		{
			if (_ol_1_IconbgImage26 != null)
			{
				return _ol_1_IconbgImage26.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite26 != value && _ol_1_IconbgImage26 != null)
			{
				_ol_1_IconbgImage26.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite27
	{
		get
		{
			if (_ol_1_IconbgImage27 != null)
			{
				return _ol_1_IconbgImage27.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite27 != value && _ol_1_IconbgImage27 != null)
			{
				_ol_1_IconbgImage27.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite28
	{
		get
		{
			if (_ol_1_IconbgImage28 != null)
			{
				return _ol_1_IconbgImage28.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite28 != value && _ol_1_IconbgImage28 != null)
			{
				_ol_1_IconbgImage28.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite29
	{
		get
		{
			if (_ol_1_IconbgImage29 != null)
			{
				return _ol_1_IconbgImage29.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite29 != value && _ol_1_IconbgImage29 != null)
			{
				_ol_1_IconbgImage29.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite30
	{
		get
		{
			if (_ol_1_IconbgImage30 != null)
			{
				return _ol_1_IconbgImage30.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite30 != value && _ol_1_IconbgImage30 != null)
			{
				_ol_1_IconbgImage30.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite31
	{
		get
		{
			if (_ol_1_IconbgImage31 != null)
			{
				return _ol_1_IconbgImage31.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite31 != value && _ol_1_IconbgImage31 != null)
			{
				_ol_1_IconbgImage31.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite32
	{
		get
		{
			if (_ol_1_IconbgImage32 != null)
			{
				return _ol_1_IconbgImage32.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite32 != value && _ol_1_IconbgImage32 != null)
			{
				_ol_1_IconbgImage32.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite33
	{
		get
		{
			if (_ol_1_IconbgImage33 != null)
			{
				return _ol_1_IconbgImage33.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite33 != value && _ol_1_IconbgImage33 != null)
			{
				_ol_1_IconbgImage33.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite34
	{
		get
		{
			if (_ol_1_IconbgImage34 != null)
			{
				return _ol_1_IconbgImage34.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite34 != value && _ol_1_IconbgImage34 != null)
			{
				_ol_1_IconbgImage34.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite35
	{
		get
		{
			if (_ol_1_IconbgImage35 != null)
			{
				return _ol_1_IconbgImage35.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite35 != value && _ol_1_IconbgImage35 != null)
			{
				_ol_1_IconbgImage35.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite36
	{
		get
		{
			if (_ol_1_IconbgImage36 != null)
			{
				return _ol_1_IconbgImage36.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite36 != value && _ol_1_IconbgImage36 != null)
			{
				_ol_1_IconbgImage36.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite37
	{
		get
		{
			if (_ol_1_IconbgImage37 != null)
			{
				return _ol_1_IconbgImage37.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite37 != value && _ol_1_IconbgImage37 != null)
			{
				_ol_1_IconbgImage37.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite38
	{
		get
		{
			if (_ol_1_IconbgImage38 != null)
			{
				return _ol_1_IconbgImage38.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite38 != value && _ol_1_IconbgImage38 != null)
			{
				_ol_1_IconbgImage38.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite39
	{
		get
		{
			if (_ol_1_IconbgImage39 != null)
			{
				return _ol_1_IconbgImage39.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite39 != value && _ol_1_IconbgImage39 != null)
			{
				_ol_1_IconbgImage39.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite40
	{
		get
		{
			if (_ol_1_IconbgImage40 != null)
			{
				return _ol_1_IconbgImage40.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite40 != value && _ol_1_IconbgImage40 != null)
			{
				_ol_1_IconbgImage40.sprite = value;
			}
		}
	}

	public Sprite l_1_IconbgSprite41
	{
		get
		{
			if (_ol_1_IconbgImage41 != null)
			{
				return _ol_1_IconbgImage41.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconbgSprite41 != value && _ol_1_IconbgImage41 != null)
			{
				_ol_1_IconbgImage41.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite1
	{
		get
		{
			if (_ol_1_IconImage1 != null)
			{
				return _ol_1_IconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite1 != value && _ol_1_IconImage1 != null)
			{
				_ol_1_IconImage1.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite2
	{
		get
		{
			if (_ol_1_IconImage2 != null)
			{
				return _ol_1_IconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite2 != value && _ol_1_IconImage2 != null)
			{
				_ol_1_IconImage2.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite3
	{
		get
		{
			if (_ol_1_IconImage3 != null)
			{
				return _ol_1_IconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite3 != value && _ol_1_IconImage3 != null)
			{
				_ol_1_IconImage3.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite4
	{
		get
		{
			if (_ol_1_IconImage4 != null)
			{
				return _ol_1_IconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite4 != value && _ol_1_IconImage4 != null)
			{
				_ol_1_IconImage4.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite5
	{
		get
		{
			if (_ol_1_IconImage5 != null)
			{
				return _ol_1_IconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite5 != value && _ol_1_IconImage5 != null)
			{
				_ol_1_IconImage5.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite6
	{
		get
		{
			if (_ol_1_IconImage6 != null)
			{
				return _ol_1_IconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite6 != value && _ol_1_IconImage6 != null)
			{
				_ol_1_IconImage6.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite7
	{
		get
		{
			if (_ol_1_IconImage7 != null)
			{
				return _ol_1_IconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite7 != value && _ol_1_IconImage7 != null)
			{
				_ol_1_IconImage7.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite8
	{
		get
		{
			if (_ol_1_IconImage8 != null)
			{
				return _ol_1_IconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite8 != value && _ol_1_IconImage8 != null)
			{
				_ol_1_IconImage8.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite9
	{
		get
		{
			if (_ol_1_IconImage9 != null)
			{
				return _ol_1_IconImage9.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite9 != value && _ol_1_IconImage9 != null)
			{
				_ol_1_IconImage9.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite10
	{
		get
		{
			if (_ol_1_IconImage10 != null)
			{
				return _ol_1_IconImage10.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite10 != value && _ol_1_IconImage10 != null)
			{
				_ol_1_IconImage10.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite11
	{
		get
		{
			if (_ol_1_IconImage11 != null)
			{
				return _ol_1_IconImage11.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite11 != value && _ol_1_IconImage11 != null)
			{
				_ol_1_IconImage11.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite12
	{
		get
		{
			if (_ol_1_IconImage12 != null)
			{
				return _ol_1_IconImage12.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite12 != value && _ol_1_IconImage12 != null)
			{
				_ol_1_IconImage12.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite13
	{
		get
		{
			if (_ol_1_IconImage13 != null)
			{
				return _ol_1_IconImage13.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite13 != value && _ol_1_IconImage13 != null)
			{
				_ol_1_IconImage13.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite14
	{
		get
		{
			if (_ol_1_IconImage14 != null)
			{
				return _ol_1_IconImage14.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite14 != value && _ol_1_IconImage14 != null)
			{
				_ol_1_IconImage14.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite15
	{
		get
		{
			if (_ol_1_IconImage15 != null)
			{
				return _ol_1_IconImage15.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite15 != value && _ol_1_IconImage15 != null)
			{
				_ol_1_IconImage15.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite16
	{
		get
		{
			if (_ol_1_IconImage16 != null)
			{
				return _ol_1_IconImage16.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite16 != value && _ol_1_IconImage16 != null)
			{
				_ol_1_IconImage16.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite17
	{
		get
		{
			if (_ol_1_IconImage17 != null)
			{
				return _ol_1_IconImage17.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite17 != value && _ol_1_IconImage17 != null)
			{
				_ol_1_IconImage17.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite18
	{
		get
		{
			if (_ol_1_IconImage18 != null)
			{
				return _ol_1_IconImage18.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite18 != value && _ol_1_IconImage18 != null)
			{
				_ol_1_IconImage18.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite19
	{
		get
		{
			if (_ol_1_IconImage19 != null)
			{
				return _ol_1_IconImage19.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite19 != value && _ol_1_IconImage19 != null)
			{
				_ol_1_IconImage19.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite20
	{
		get
		{
			if (_ol_1_IconImage20 != null)
			{
				return _ol_1_IconImage20.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite20 != value && _ol_1_IconImage20 != null)
			{
				_ol_1_IconImage20.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite21
	{
		get
		{
			if (_ol_1_IconImage21 != null)
			{
				return _ol_1_IconImage21.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite21 != value && _ol_1_IconImage21 != null)
			{
				_ol_1_IconImage21.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite22
	{
		get
		{
			if (_ol_1_IconImage22 != null)
			{
				return _ol_1_IconImage22.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite22 != value && _ol_1_IconImage22 != null)
			{
				_ol_1_IconImage22.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite23
	{
		get
		{
			if (_ol_1_IconImage23 != null)
			{
				return _ol_1_IconImage23.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite23 != value && _ol_1_IconImage23 != null)
			{
				_ol_1_IconImage23.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite24
	{
		get
		{
			if (_ol_1_IconImage24 != null)
			{
				return _ol_1_IconImage24.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite24 != value && _ol_1_IconImage24 != null)
			{
				_ol_1_IconImage24.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite25
	{
		get
		{
			if (_ol_1_IconImage25 != null)
			{
				return _ol_1_IconImage25.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite25 != value && _ol_1_IconImage25 != null)
			{
				_ol_1_IconImage25.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite26
	{
		get
		{
			if (_ol_1_IconImage26 != null)
			{
				return _ol_1_IconImage26.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite26 != value && _ol_1_IconImage26 != null)
			{
				_ol_1_IconImage26.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite27
	{
		get
		{
			if (_ol_1_IconImage27 != null)
			{
				return _ol_1_IconImage27.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite27 != value && _ol_1_IconImage27 != null)
			{
				_ol_1_IconImage27.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite28
	{
		get
		{
			if (_ol_1_IconImage28 != null)
			{
				return _ol_1_IconImage28.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite28 != value && _ol_1_IconImage28 != null)
			{
				_ol_1_IconImage28.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite29
	{
		get
		{
			if (_ol_1_IconImage29 != null)
			{
				return _ol_1_IconImage29.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite29 != value && _ol_1_IconImage29 != null)
			{
				_ol_1_IconImage29.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite30
	{
		get
		{
			if (_ol_1_IconImage30 != null)
			{
				return _ol_1_IconImage30.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite30 != value && _ol_1_IconImage30 != null)
			{
				_ol_1_IconImage30.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite31
	{
		get
		{
			if (_ol_1_IconImage31 != null)
			{
				return _ol_1_IconImage31.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite31 != value && _ol_1_IconImage31 != null)
			{
				_ol_1_IconImage31.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite32
	{
		get
		{
			if (_ol_1_IconImage32 != null)
			{
				return _ol_1_IconImage32.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite32 != value && _ol_1_IconImage32 != null)
			{
				_ol_1_IconImage32.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite33
	{
		get
		{
			if (_ol_1_IconImage33 != null)
			{
				return _ol_1_IconImage33.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite33 != value && _ol_1_IconImage33 != null)
			{
				_ol_1_IconImage33.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite34
	{
		get
		{
			if (_ol_1_IconImage34 != null)
			{
				return _ol_1_IconImage34.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite34 != value && _ol_1_IconImage34 != null)
			{
				_ol_1_IconImage34.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite35
	{
		get
		{
			if (_ol_1_IconImage35 != null)
			{
				return _ol_1_IconImage35.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite35 != value && _ol_1_IconImage35 != null)
			{
				_ol_1_IconImage35.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite36
	{
		get
		{
			if (_ol_1_IconImage36 != null)
			{
				return _ol_1_IconImage36.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite36 != value && _ol_1_IconImage36 != null)
			{
				_ol_1_IconImage36.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite37
	{
		get
		{
			if (_ol_1_IconImage37 != null)
			{
				return _ol_1_IconImage37.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite37 != value && _ol_1_IconImage37 != null)
			{
				_ol_1_IconImage37.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite38
	{
		get
		{
			if (_ol_1_IconImage38 != null)
			{
				return _ol_1_IconImage38.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite38 != value && _ol_1_IconImage38 != null)
			{
				_ol_1_IconImage38.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite39
	{
		get
		{
			if (_ol_1_IconImage39 != null)
			{
				return _ol_1_IconImage39.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite39 != value && _ol_1_IconImage39 != null)
			{
				_ol_1_IconImage39.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite40
	{
		get
		{
			if (_ol_1_IconImage40 != null)
			{
				return _ol_1_IconImage40.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite40 != value && _ol_1_IconImage40 != null)
			{
				_ol_1_IconImage40.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite41
	{
		get
		{
			if (_ol_1_IconImage41 != null)
			{
				return _ol_1_IconImage41.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite41 != value && _ol_1_IconImage41 != null)
			{
				_ol_1_IconImage41.sprite = value;
			}
		}
	}

	public string l_1_NameString1
	{
		get
		{
			if (_ol_1_NameText1 != null)
			{
				return _ol_1_NameText1.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString1 != value && _ol_1_NameText1 != null)
			{
				_ol_1_NameText1.text = value;
			}
		}
	}

	public string l_1_NameString2
	{
		get
		{
			if (_ol_1_NameText2 != null)
			{
				return _ol_1_NameText2.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString2 != value && _ol_1_NameText2 != null)
			{
				_ol_1_NameText2.text = value;
			}
		}
	}

	public string l_1_NameString3
	{
		get
		{
			if (_ol_1_NameText3 != null)
			{
				return _ol_1_NameText3.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString3 != value && _ol_1_NameText3 != null)
			{
				_ol_1_NameText3.text = value;
			}
		}
	}

	public string l_1_NameString4
	{
		get
		{
			if (_ol_1_NameText4 != null)
			{
				return _ol_1_NameText4.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString4 != value && _ol_1_NameText4 != null)
			{
				_ol_1_NameText4.text = value;
			}
		}
	}

	public string l_1_NameString5
	{
		get
		{
			if (_ol_1_NameText5 != null)
			{
				return _ol_1_NameText5.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString5 != value && _ol_1_NameText5 != null)
			{
				_ol_1_NameText5.text = value;
			}
		}
	}

	public string l_1_NameString6
	{
		get
		{
			if (_ol_1_NameText6 != null)
			{
				return _ol_1_NameText6.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString6 != value && _ol_1_NameText6 != null)
			{
				_ol_1_NameText6.text = value;
			}
		}
	}

	public string l_1_NameString7
	{
		get
		{
			if (_ol_1_NameText7 != null)
			{
				return _ol_1_NameText7.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString7 != value && _ol_1_NameText7 != null)
			{
				_ol_1_NameText7.text = value;
			}
		}
	}

	public string l_1_NameString8
	{
		get
		{
			if (_ol_1_NameText8 != null)
			{
				return _ol_1_NameText8.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString8 != value && _ol_1_NameText8 != null)
			{
				_ol_1_NameText8.text = value;
			}
		}
	}

	public string l_1_NameString9
	{
		get
		{
			if (_ol_1_NameText9 != null)
			{
				return _ol_1_NameText9.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString9 != value && _ol_1_NameText9 != null)
			{
				_ol_1_NameText9.text = value;
			}
		}
	}

	public string l_1_NameString10
	{
		get
		{
			if (_ol_1_NameText10 != null)
			{
				return _ol_1_NameText10.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString10 != value && _ol_1_NameText10 != null)
			{
				_ol_1_NameText10.text = value;
			}
		}
	}

	public string l_1_NameString11
	{
		get
		{
			if (_ol_1_NameText11 != null)
			{
				return _ol_1_NameText11.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString11 != value && _ol_1_NameText11 != null)
			{
				_ol_1_NameText11.text = value;
			}
		}
	}

	public string l_1_NameString12
	{
		get
		{
			if (_ol_1_NameText12 != null)
			{
				return _ol_1_NameText12.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString12 != value && _ol_1_NameText12 != null)
			{
				_ol_1_NameText12.text = value;
			}
		}
	}

	public string l_1_NameString13
	{
		get
		{
			if (_ol_1_NameText13 != null)
			{
				return _ol_1_NameText13.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString13 != value && _ol_1_NameText13 != null)
			{
				_ol_1_NameText13.text = value;
			}
		}
	}

	public string l_1_NameString14
	{
		get
		{
			if (_ol_1_NameText14 != null)
			{
				return _ol_1_NameText14.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString14 != value && _ol_1_NameText14 != null)
			{
				_ol_1_NameText14.text = value;
			}
		}
	}

	public string l_1_NameString15
	{
		get
		{
			if (_ol_1_NameText15 != null)
			{
				return _ol_1_NameText15.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString15 != value && _ol_1_NameText15 != null)
			{
				_ol_1_NameText15.text = value;
			}
		}
	}

	public string l_1_NameString16
	{
		get
		{
			if (_ol_1_NameText16 != null)
			{
				return _ol_1_NameText16.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString16 != value && _ol_1_NameText16 != null)
			{
				_ol_1_NameText16.text = value;
			}
		}
	}

	public string l_1_NameString17
	{
		get
		{
			if (_ol_1_NameText17 != null)
			{
				return _ol_1_NameText17.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString17 != value && _ol_1_NameText17 != null)
			{
				_ol_1_NameText17.text = value;
			}
		}
	}

	public string l_1_NameString18
	{
		get
		{
			if (_ol_1_NameText18 != null)
			{
				return _ol_1_NameText18.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString18 != value && _ol_1_NameText18 != null)
			{
				_ol_1_NameText18.text = value;
			}
		}
	}

	public string l_1_NameString19
	{
		get
		{
			if (_ol_1_NameText19 != null)
			{
				return _ol_1_NameText19.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString19 != value && _ol_1_NameText19 != null)
			{
				_ol_1_NameText19.text = value;
			}
		}
	}

	public string l_1_NameString20
	{
		get
		{
			if (_ol_1_NameText20 != null)
			{
				return _ol_1_NameText20.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString20 != value && _ol_1_NameText20 != null)
			{
				_ol_1_NameText20.text = value;
			}
		}
	}

	public string l_1_NameString21
	{
		get
		{
			if (_ol_1_NameText21 != null)
			{
				return _ol_1_NameText21.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString21 != value && _ol_1_NameText21 != null)
			{
				_ol_1_NameText21.text = value;
			}
		}
	}

	public string l_1_NameString22
	{
		get
		{
			if (_ol_1_NameText22 != null)
			{
				return _ol_1_NameText22.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString22 != value && _ol_1_NameText22 != null)
			{
				_ol_1_NameText22.text = value;
			}
		}
	}

	public string l_1_NameString23
	{
		get
		{
			if (_ol_1_NameText23 != null)
			{
				return _ol_1_NameText23.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString23 != value && _ol_1_NameText23 != null)
			{
				_ol_1_NameText23.text = value;
			}
		}
	}

	public string l_1_NameString24
	{
		get
		{
			if (_ol_1_NameText24 != null)
			{
				return _ol_1_NameText24.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString24 != value && _ol_1_NameText24 != null)
			{
				_ol_1_NameText24.text = value;
			}
		}
	}

	public string l_1_NameString25
	{
		get
		{
			if (_ol_1_NameText25 != null)
			{
				return _ol_1_NameText25.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString25 != value && _ol_1_NameText25 != null)
			{
				_ol_1_NameText25.text = value;
			}
		}
	}

	public string l_1_NameString26
	{
		get
		{
			if (_ol_1_NameText26 != null)
			{
				return _ol_1_NameText26.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString26 != value && _ol_1_NameText26 != null)
			{
				_ol_1_NameText26.text = value;
			}
		}
	}

	public string l_1_NameString27
	{
		get
		{
			if (_ol_1_NameText27 != null)
			{
				return _ol_1_NameText27.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString27 != value && _ol_1_NameText27 != null)
			{
				_ol_1_NameText27.text = value;
			}
		}
	}

	public string l_1_NameString28
	{
		get
		{
			if (_ol_1_NameText28 != null)
			{
				return _ol_1_NameText28.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString28 != value && _ol_1_NameText28 != null)
			{
				_ol_1_NameText28.text = value;
			}
		}
	}

	public string l_1_NameString29
	{
		get
		{
			if (_ol_1_NameText29 != null)
			{
				return _ol_1_NameText29.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString29 != value && _ol_1_NameText29 != null)
			{
				_ol_1_NameText29.text = value;
			}
		}
	}

	public string l_1_NameString30
	{
		get
		{
			if (_ol_1_NameText30 != null)
			{
				return _ol_1_NameText30.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString30 != value && _ol_1_NameText30 != null)
			{
				_ol_1_NameText30.text = value;
			}
		}
	}

	public string l_1_NameString31
	{
		get
		{
			if (_ol_1_NameText31 != null)
			{
				return _ol_1_NameText31.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString31 != value && _ol_1_NameText31 != null)
			{
				_ol_1_NameText31.text = value;
			}
		}
	}

	public string l_1_NameString32
	{
		get
		{
			if (_ol_1_NameText32 != null)
			{
				return _ol_1_NameText32.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString32 != value && _ol_1_NameText32 != null)
			{
				_ol_1_NameText32.text = value;
			}
		}
	}

	public string l_1_NameString33
	{
		get
		{
			if (_ol_1_NameText33 != null)
			{
				return _ol_1_NameText33.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString33 != value && _ol_1_NameText33 != null)
			{
				_ol_1_NameText33.text = value;
			}
		}
	}

	public string l_1_NameString34
	{
		get
		{
			if (_ol_1_NameText34 != null)
			{
				return _ol_1_NameText34.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString34 != value && _ol_1_NameText34 != null)
			{
				_ol_1_NameText34.text = value;
			}
		}
	}

	public string l_1_NameString35
	{
		get
		{
			if (_ol_1_NameText35 != null)
			{
				return _ol_1_NameText35.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString35 != value && _ol_1_NameText35 != null)
			{
				_ol_1_NameText35.text = value;
			}
		}
	}

	public string l_1_NameString36
	{
		get
		{
			if (_ol_1_NameText36 != null)
			{
				return _ol_1_NameText36.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString36 != value && _ol_1_NameText36 != null)
			{
				_ol_1_NameText36.text = value;
			}
		}
	}

	public string l_1_NameString37
	{
		get
		{
			if (_ol_1_NameText37 != null)
			{
				return _ol_1_NameText37.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString37 != value && _ol_1_NameText37 != null)
			{
				_ol_1_NameText37.text = value;
			}
		}
	}

	public string l_1_NameString38
	{
		get
		{
			if (_ol_1_NameText38 != null)
			{
				return _ol_1_NameText38.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString38 != value && _ol_1_NameText38 != null)
			{
				_ol_1_NameText38.text = value;
			}
		}
	}

	public string l_1_NameString39
	{
		get
		{
			if (_ol_1_NameText39 != null)
			{
				return _ol_1_NameText39.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString39 != value && _ol_1_NameText39 != null)
			{
				_ol_1_NameText39.text = value;
			}
		}
	}

	public string l_1_NameString40
	{
		get
		{
			if (_ol_1_NameText40 != null)
			{
				return _ol_1_NameText40.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString40 != value && _ol_1_NameText40 != null)
			{
				_ol_1_NameText40.text = value;
			}
		}
	}

	public string l_1_NameString41
	{
		get
		{
			if (_ol_1_NameText41 != null)
			{
				return _ol_1_NameText41.text;
			}
			return null;
		}
		set
		{
			if (l_1_NameString41 != value && _ol_1_NameText41 != null)
			{
				_ol_1_NameText41.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent shop_rClicked
	{
		get
		{
			if (_oshop_rButton != null)
			{
				return _oshop_rButton.onClick;
			}
			return null;
		}
		set
		{
			if (shop_rClicked != value && _oshop_rButton != null)
			{
				_oshop_rButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent closeClicked
	{
		get
		{
			if (_ocloseButton != null)
			{
				return _ocloseButton.onClick;
			}
			return null;
		}
		set
		{
			if (closeClicked != value && _ocloseButton != null)
			{
				_ocloseButton.onClick = value;
			}
		}
	}

	public bool msgShow
	{
		get
		{
			if (_omsg != null)
			{
				return _omsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (msgShow != value && _omsg != null)
			{
				_omsg.SetObjectActive(value);
			}
		}
	}

	public Vector3 msgPosition
	{
		get
		{
			if (_omsgRectTransform != null)
			{
				return _omsgRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (msgPosition != value && _omsgRectTransform != null)
			{
				_omsgRectTransform.localPosition = value;
			}
		}
	}

	public Sprite msgSprite
	{
		get
		{
			if (_omsgImage != null)
			{
				return _omsgImage.sprite;
			}
			return null;
		}
		set
		{
			if (msgSprite != value && _omsgImage != null)
			{
				_omsgImage.sprite = value;
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
			case "BioChemical_Z_Shop_Skll":
				_oBioChemical_Z_Shop_Skll = transform.gameObject;
				_oBioChemical_Z_Shop_SkllRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "l_1_skill1":
				_ol_1_skill1 = transform.gameObject;
				_ol_1_skillEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill2":
				_ol_1_skill2 = transform.gameObject;
				_ol_1_skillEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill3":
				_ol_1_skill3 = transform.gameObject;
				_ol_1_skillEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill4":
				_ol_1_skill4 = transform.gameObject;
				_ol_1_skillEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill5":
				_ol_1_skill5 = transform.gameObject;
				_ol_1_skillEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill6":
				_ol_1_skill6 = transform.gameObject;
				_ol_1_skillEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill7":
				_ol_1_skill7 = transform.gameObject;
				_ol_1_skillEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill8":
				_ol_1_skill8 = transform.gameObject;
				_ol_1_skillEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill9":
				_ol_1_skill9 = transform.gameObject;
				_ol_1_skillEventTrigger9 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill10":
				_ol_1_skill10 = transform.gameObject;
				_ol_1_skillEventTrigger10 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill11":
				_ol_1_skill11 = transform.gameObject;
				_ol_1_skillEventTrigger11 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill12":
				_ol_1_skill12 = transform.gameObject;
				_ol_1_skillEventTrigger12 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill13":
				_ol_1_skill13 = transform.gameObject;
				_ol_1_skillEventTrigger13 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill14":
				_ol_1_skill14 = transform.gameObject;
				_ol_1_skillEventTrigger14 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill15":
				_ol_1_skill15 = transform.gameObject;
				_ol_1_skillEventTrigger15 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill16":
				_ol_1_skill16 = transform.gameObject;
				_ol_1_skillEventTrigger16 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill17":
				_ol_1_skill17 = transform.gameObject;
				_ol_1_skillEventTrigger17 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill18":
				_ol_1_skill18 = transform.gameObject;
				_ol_1_skillEventTrigger18 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill19":
				_ol_1_skill19 = transform.gameObject;
				_ol_1_skillEventTrigger19 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill20":
				_ol_1_skill20 = transform.gameObject;
				_ol_1_skillEventTrigger20 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill21":
				_ol_1_skill21 = transform.gameObject;
				_ol_1_skillEventTrigger21 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill22":
				_ol_1_skill22 = transform.gameObject;
				_ol_1_skillEventTrigger22 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill23":
				_ol_1_skill23 = transform.gameObject;
				_ol_1_skillEventTrigger23 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill24":
				_ol_1_skill24 = transform.gameObject;
				_ol_1_skillEventTrigger24 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill25":
				_ol_1_skill25 = transform.gameObject;
				_ol_1_skillEventTrigger25 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill26":
				_ol_1_skill26 = transform.gameObject;
				_ol_1_skillEventTrigger26 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill27":
				_ol_1_skill27 = transform.gameObject;
				_ol_1_skillEventTrigger27 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill28":
				_ol_1_skill28 = transform.gameObject;
				_ol_1_skillEventTrigger28 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill29":
				_ol_1_skill29 = transform.gameObject;
				_ol_1_skillEventTrigger29 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill30":
				_ol_1_skill30 = transform.gameObject;
				_ol_1_skillEventTrigger30 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill31":
				_ol_1_skill31 = transform.gameObject;
				_ol_1_skillEventTrigger31 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill32":
				_ol_1_skill32 = transform.gameObject;
				_ol_1_skillEventTrigger32 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill33":
				_ol_1_skill33 = transform.gameObject;
				_ol_1_skillEventTrigger33 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill34":
				_ol_1_skill34 = transform.gameObject;
				_ol_1_skillEventTrigger34 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill35":
				_ol_1_skill35 = transform.gameObject;
				_ol_1_skillEventTrigger35 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill36":
				_ol_1_skill36 = transform.gameObject;
				_ol_1_skillEventTrigger36 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill37":
				_ol_1_skill37 = transform.gameObject;
				_ol_1_skillEventTrigger37 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill38":
				_ol_1_skill38 = transform.gameObject;
				_ol_1_skillEventTrigger38 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill39":
				_ol_1_skill39 = transform.gameObject;
				_ol_1_skillEventTrigger39 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill40":
				_ol_1_skill40 = transform.gameObject;
				_ol_1_skillEventTrigger40 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_skill41":
				_ol_1_skill41 = transform.gameObject;
				_ol_1_skillEventTrigger41 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "l_1_Iconbg1":
				_ol_1_Iconbg1 = transform.gameObject;
				_ol_1_IconbgImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg2":
				_ol_1_Iconbg2 = transform.gameObject;
				_ol_1_IconbgImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg3":
				_ol_1_Iconbg3 = transform.gameObject;
				_ol_1_IconbgImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg4":
				_ol_1_Iconbg4 = transform.gameObject;
				_ol_1_IconbgImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg5":
				_ol_1_Iconbg5 = transform.gameObject;
				_ol_1_IconbgImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg6":
				_ol_1_Iconbg6 = transform.gameObject;
				_ol_1_IconbgImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg7":
				_ol_1_Iconbg7 = transform.gameObject;
				_ol_1_IconbgImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg8":
				_ol_1_Iconbg8 = transform.gameObject;
				_ol_1_IconbgImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg9":
				_ol_1_Iconbg9 = transform.gameObject;
				_ol_1_IconbgImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg10":
				_ol_1_Iconbg10 = transform.gameObject;
				_ol_1_IconbgImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg11":
				_ol_1_Iconbg11 = transform.gameObject;
				_ol_1_IconbgImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg12":
				_ol_1_Iconbg12 = transform.gameObject;
				_ol_1_IconbgImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg13":
				_ol_1_Iconbg13 = transform.gameObject;
				_ol_1_IconbgImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg14":
				_ol_1_Iconbg14 = transform.gameObject;
				_ol_1_IconbgImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg15":
				_ol_1_Iconbg15 = transform.gameObject;
				_ol_1_IconbgImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg16":
				_ol_1_Iconbg16 = transform.gameObject;
				_ol_1_IconbgImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg17":
				_ol_1_Iconbg17 = transform.gameObject;
				_ol_1_IconbgImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg18":
				_ol_1_Iconbg18 = transform.gameObject;
				_ol_1_IconbgImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg19":
				_ol_1_Iconbg19 = transform.gameObject;
				_ol_1_IconbgImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg20":
				_ol_1_Iconbg20 = transform.gameObject;
				_ol_1_IconbgImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg21":
				_ol_1_Iconbg21 = transform.gameObject;
				_ol_1_IconbgImage21 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg22":
				_ol_1_Iconbg22 = transform.gameObject;
				_ol_1_IconbgImage22 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg23":
				_ol_1_Iconbg23 = transform.gameObject;
				_ol_1_IconbgImage23 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg24":
				_ol_1_Iconbg24 = transform.gameObject;
				_ol_1_IconbgImage24 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg25":
				_ol_1_Iconbg25 = transform.gameObject;
				_ol_1_IconbgImage25 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg26":
				_ol_1_Iconbg26 = transform.gameObject;
				_ol_1_IconbgImage26 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg27":
				_ol_1_Iconbg27 = transform.gameObject;
				_ol_1_IconbgImage27 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg28":
				_ol_1_Iconbg28 = transform.gameObject;
				_ol_1_IconbgImage28 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg29":
				_ol_1_Iconbg29 = transform.gameObject;
				_ol_1_IconbgImage29 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg30":
				_ol_1_Iconbg30 = transform.gameObject;
				_ol_1_IconbgImage30 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg31":
				_ol_1_Iconbg31 = transform.gameObject;
				_ol_1_IconbgImage31 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg32":
				_ol_1_Iconbg32 = transform.gameObject;
				_ol_1_IconbgImage32 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg33":
				_ol_1_Iconbg33 = transform.gameObject;
				_ol_1_IconbgImage33 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg34":
				_ol_1_Iconbg34 = transform.gameObject;
				_ol_1_IconbgImage34 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg35":
				_ol_1_Iconbg35 = transform.gameObject;
				_ol_1_IconbgImage35 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg36":
				_ol_1_Iconbg36 = transform.gameObject;
				_ol_1_IconbgImage36 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg37":
				_ol_1_Iconbg37 = transform.gameObject;
				_ol_1_IconbgImage37 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg38":
				_ol_1_Iconbg38 = transform.gameObject;
				_ol_1_IconbgImage38 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg39":
				_ol_1_Iconbg39 = transform.gameObject;
				_ol_1_IconbgImage39 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg40":
				_ol_1_Iconbg40 = transform.gameObject;
				_ol_1_IconbgImage40 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Iconbg41":
				_ol_1_Iconbg41 = transform.gameObject;
				_ol_1_IconbgImage41 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon1":
				_ol_1_Icon1 = transform.gameObject;
				_ol_1_IconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon2":
				_ol_1_Icon2 = transform.gameObject;
				_ol_1_IconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon3":
				_ol_1_Icon3 = transform.gameObject;
				_ol_1_IconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon4":
				_ol_1_Icon4 = transform.gameObject;
				_ol_1_IconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon5":
				_ol_1_Icon5 = transform.gameObject;
				_ol_1_IconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon6":
				_ol_1_Icon6 = transform.gameObject;
				_ol_1_IconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon7":
				_ol_1_Icon7 = transform.gameObject;
				_ol_1_IconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon8":
				_ol_1_Icon8 = transform.gameObject;
				_ol_1_IconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon9":
				_ol_1_Icon9 = transform.gameObject;
				_ol_1_IconImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon10":
				_ol_1_Icon10 = transform.gameObject;
				_ol_1_IconImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon11":
				_ol_1_Icon11 = transform.gameObject;
				_ol_1_IconImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon12":
				_ol_1_Icon12 = transform.gameObject;
				_ol_1_IconImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon13":
				_ol_1_Icon13 = transform.gameObject;
				_ol_1_IconImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon14":
				_ol_1_Icon14 = transform.gameObject;
				_ol_1_IconImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon15":
				_ol_1_Icon15 = transform.gameObject;
				_ol_1_IconImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon16":
				_ol_1_Icon16 = transform.gameObject;
				_ol_1_IconImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon17":
				_ol_1_Icon17 = transform.gameObject;
				_ol_1_IconImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon18":
				_ol_1_Icon18 = transform.gameObject;
				_ol_1_IconImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon19":
				_ol_1_Icon19 = transform.gameObject;
				_ol_1_IconImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon20":
				_ol_1_Icon20 = transform.gameObject;
				_ol_1_IconImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon21":
				_ol_1_Icon21 = transform.gameObject;
				_ol_1_IconImage21 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon22":
				_ol_1_Icon22 = transform.gameObject;
				_ol_1_IconImage22 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon23":
				_ol_1_Icon23 = transform.gameObject;
				_ol_1_IconImage23 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon24":
				_ol_1_Icon24 = transform.gameObject;
				_ol_1_IconImage24 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon25":
				_ol_1_Icon25 = transform.gameObject;
				_ol_1_IconImage25 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon26":
				_ol_1_Icon26 = transform.gameObject;
				_ol_1_IconImage26 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon27":
				_ol_1_Icon27 = transform.gameObject;
				_ol_1_IconImage27 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon28":
				_ol_1_Icon28 = transform.gameObject;
				_ol_1_IconImage28 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon29":
				_ol_1_Icon29 = transform.gameObject;
				_ol_1_IconImage29 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon30":
				_ol_1_Icon30 = transform.gameObject;
				_ol_1_IconImage30 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon31":
				_ol_1_Icon31 = transform.gameObject;
				_ol_1_IconImage31 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon32":
				_ol_1_Icon32 = transform.gameObject;
				_ol_1_IconImage32 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon33":
				_ol_1_Icon33 = transform.gameObject;
				_ol_1_IconImage33 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon34":
				_ol_1_Icon34 = transform.gameObject;
				_ol_1_IconImage34 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon35":
				_ol_1_Icon35 = transform.gameObject;
				_ol_1_IconImage35 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon36":
				_ol_1_Icon36 = transform.gameObject;
				_ol_1_IconImage36 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon37":
				_ol_1_Icon37 = transform.gameObject;
				_ol_1_IconImage37 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon38":
				_ol_1_Icon38 = transform.gameObject;
				_ol_1_IconImage38 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon39":
				_ol_1_Icon39 = transform.gameObject;
				_ol_1_IconImage39 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon40":
				_ol_1_Icon40 = transform.gameObject;
				_ol_1_IconImage40 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon41":
				_ol_1_Icon41 = transform.gameObject;
				_ol_1_IconImage41 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Name1":
				_ol_1_Name1 = transform.gameObject;
				_ol_1_NameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name2":
				_ol_1_Name2 = transform.gameObject;
				_ol_1_NameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name3":
				_ol_1_Name3 = transform.gameObject;
				_ol_1_NameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name4":
				_ol_1_Name4 = transform.gameObject;
				_ol_1_NameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name5":
				_ol_1_Name5 = transform.gameObject;
				_ol_1_NameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name6":
				_ol_1_Name6 = transform.gameObject;
				_ol_1_NameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name7":
				_ol_1_Name7 = transform.gameObject;
				_ol_1_NameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name8":
				_ol_1_Name8 = transform.gameObject;
				_ol_1_NameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name9":
				_ol_1_Name9 = transform.gameObject;
				_ol_1_NameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name10":
				_ol_1_Name10 = transform.gameObject;
				_ol_1_NameText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name11":
				_ol_1_Name11 = transform.gameObject;
				_ol_1_NameText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name12":
				_ol_1_Name12 = transform.gameObject;
				_ol_1_NameText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name13":
				_ol_1_Name13 = transform.gameObject;
				_ol_1_NameText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name14":
				_ol_1_Name14 = transform.gameObject;
				_ol_1_NameText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name15":
				_ol_1_Name15 = transform.gameObject;
				_ol_1_NameText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name16":
				_ol_1_Name16 = transform.gameObject;
				_ol_1_NameText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name17":
				_ol_1_Name17 = transform.gameObject;
				_ol_1_NameText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name18":
				_ol_1_Name18 = transform.gameObject;
				_ol_1_NameText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name19":
				_ol_1_Name19 = transform.gameObject;
				_ol_1_NameText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name20":
				_ol_1_Name20 = transform.gameObject;
				_ol_1_NameText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name21":
				_ol_1_Name21 = transform.gameObject;
				_ol_1_NameText21 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name22":
				_ol_1_Name22 = transform.gameObject;
				_ol_1_NameText22 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name23":
				_ol_1_Name23 = transform.gameObject;
				_ol_1_NameText23 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name24":
				_ol_1_Name24 = transform.gameObject;
				_ol_1_NameText24 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name25":
				_ol_1_Name25 = transform.gameObject;
				_ol_1_NameText25 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name26":
				_ol_1_Name26 = transform.gameObject;
				_ol_1_NameText26 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name27":
				_ol_1_Name27 = transform.gameObject;
				_ol_1_NameText27 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name28":
				_ol_1_Name28 = transform.gameObject;
				_ol_1_NameText28 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name29":
				_ol_1_Name29 = transform.gameObject;
				_ol_1_NameText29 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name30":
				_ol_1_Name30 = transform.gameObject;
				_ol_1_NameText30 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name31":
				_ol_1_Name31 = transform.gameObject;
				_ol_1_NameText31 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name32":
				_ol_1_Name32 = transform.gameObject;
				_ol_1_NameText32 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name33":
				_ol_1_Name33 = transform.gameObject;
				_ol_1_NameText33 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name34":
				_ol_1_Name34 = transform.gameObject;
				_ol_1_NameText34 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name35":
				_ol_1_Name35 = transform.gameObject;
				_ol_1_NameText35 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name36":
				_ol_1_Name36 = transform.gameObject;
				_ol_1_NameText36 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name37":
				_ol_1_Name37 = transform.gameObject;
				_ol_1_NameText37 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name38":
				_ol_1_Name38 = transform.gameObject;
				_ol_1_NameText38 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name39":
				_ol_1_Name39 = transform.gameObject;
				_ol_1_NameText39 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name40":
				_ol_1_Name40 = transform.gameObject;
				_ol_1_NameText40 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_Name41":
				_ol_1_Name41 = transform.gameObject;
				_ol_1_NameText41 = transform.gameObject.GetComponent<Text>();
				break;
			case "shop_r":
				_oshop_r = transform.gameObject;
				_oshop_rButton = transform.gameObject.GetComponent<Button>();
				break;
			case "close":
				_oclose = transform.gameObject;
				_ocloseButton = transform.gameObject.GetComponent<Button>();
				break;
			case "msg":
				_omsg = transform.gameObject;
				_omsgRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_omsgImage = transform.gameObject.GetComponent<Image>();
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

	public bool Getl_1_skillShow(int index)
	{
		return index switch
		{
			1 => l_1_skillShow1, 
			2 => l_1_skillShow2, 
			3 => l_1_skillShow3, 
			4 => l_1_skillShow4, 
			5 => l_1_skillShow5, 
			6 => l_1_skillShow6, 
			7 => l_1_skillShow7, 
			8 => l_1_skillShow8, 
			9 => l_1_skillShow9, 
			10 => l_1_skillShow10, 
			11 => l_1_skillShow11, 
			12 => l_1_skillShow12, 
			13 => l_1_skillShow13, 
			14 => l_1_skillShow14, 
			15 => l_1_skillShow15, 
			16 => l_1_skillShow16, 
			17 => l_1_skillShow17, 
			18 => l_1_skillShow18, 
			19 => l_1_skillShow19, 
			20 => l_1_skillShow20, 
			21 => l_1_skillShow21, 
			22 => l_1_skillShow22, 
			23 => l_1_skillShow23, 
			24 => l_1_skillShow24, 
			25 => l_1_skillShow25, 
			26 => l_1_skillShow26, 
			27 => l_1_skillShow27, 
			28 => l_1_skillShow28, 
			29 => l_1_skillShow29, 
			30 => l_1_skillShow30, 
			31 => l_1_skillShow31, 
			32 => l_1_skillShow32, 
			33 => l_1_skillShow33, 
			34 => l_1_skillShow34, 
			35 => l_1_skillShow35, 
			36 => l_1_skillShow36, 
			37 => l_1_skillShow37, 
			38 => l_1_skillShow38, 
			39 => l_1_skillShow39, 
			40 => l_1_skillShow40, 
			41 => l_1_skillShow41, 
			_ => false, 
		};
	}

	public void Setl_1_skillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			l_1_skillShow1 = value;
			break;
		case 2:
			l_1_skillShow2 = value;
			break;
		case 3:
			l_1_skillShow3 = value;
			break;
		case 4:
			l_1_skillShow4 = value;
			break;
		case 5:
			l_1_skillShow5 = value;
			break;
		case 6:
			l_1_skillShow6 = value;
			break;
		case 7:
			l_1_skillShow7 = value;
			break;
		case 8:
			l_1_skillShow8 = value;
			break;
		case 9:
			l_1_skillShow9 = value;
			break;
		case 10:
			l_1_skillShow10 = value;
			break;
		case 11:
			l_1_skillShow11 = value;
			break;
		case 12:
			l_1_skillShow12 = value;
			break;
		case 13:
			l_1_skillShow13 = value;
			break;
		case 14:
			l_1_skillShow14 = value;
			break;
		case 15:
			l_1_skillShow15 = value;
			break;
		case 16:
			l_1_skillShow16 = value;
			break;
		case 17:
			l_1_skillShow17 = value;
			break;
		case 18:
			l_1_skillShow18 = value;
			break;
		case 19:
			l_1_skillShow19 = value;
			break;
		case 20:
			l_1_skillShow20 = value;
			break;
		case 21:
			l_1_skillShow21 = value;
			break;
		case 22:
			l_1_skillShow22 = value;
			break;
		case 23:
			l_1_skillShow23 = value;
			break;
		case 24:
			l_1_skillShow24 = value;
			break;
		case 25:
			l_1_skillShow25 = value;
			break;
		case 26:
			l_1_skillShow26 = value;
			break;
		case 27:
			l_1_skillShow27 = value;
			break;
		case 28:
			l_1_skillShow28 = value;
			break;
		case 29:
			l_1_skillShow29 = value;
			break;
		case 30:
			l_1_skillShow30 = value;
			break;
		case 31:
			l_1_skillShow31 = value;
			break;
		case 32:
			l_1_skillShow32 = value;
			break;
		case 33:
			l_1_skillShow33 = value;
			break;
		case 34:
			l_1_skillShow34 = value;
			break;
		case 35:
			l_1_skillShow35 = value;
			break;
		case 36:
			l_1_skillShow36 = value;
			break;
		case 37:
			l_1_skillShow37 = value;
			break;
		case 38:
			l_1_skillShow38 = value;
			break;
		case 39:
			l_1_skillShow39 = value;
			break;
		case 40:
			l_1_skillShow40 = value;
			break;
		case 41:
			l_1_skillShow41 = value;
			break;
		}
	}

	private void Createl_1_skillTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers1, eventId, callback);
	}

	private void Removel_1_skillTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers1, eventId);
	}

	private void Createl_1_skillTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers2, eventId, callback);
	}

	private void Removel_1_skillTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers2, eventId);
	}

	private void Createl_1_skillTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers3, eventId, callback);
	}

	private void Removel_1_skillTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers3, eventId);
	}

	private void Createl_1_skillTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers4, eventId, callback);
	}

	private void Removel_1_skillTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers4, eventId);
	}

	private void Createl_1_skillTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers5, eventId, callback);
	}

	private void Removel_1_skillTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers5, eventId);
	}

	private void Createl_1_skillTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers6, eventId, callback);
	}

	private void Removel_1_skillTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers6, eventId);
	}

	private void Createl_1_skillTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers7, eventId, callback);
	}

	private void Removel_1_skillTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers7, eventId);
	}

	private void Createl_1_skillTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers8, eventId, callback);
	}

	private void Removel_1_skillTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers8, eventId);
	}

	private void Createl_1_skillTriggers9Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers9, eventId, callback);
	}

	private void Removel_1_skillTriggers9Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers9, eventId);
	}

	private void Createl_1_skillTriggers10Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers10, eventId, callback);
	}

	private void Removel_1_skillTriggers10Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers10, eventId);
	}

	private void Createl_1_skillTriggers11Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers11, eventId, callback);
	}

	private void Removel_1_skillTriggers11Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers11, eventId);
	}

	private void Createl_1_skillTriggers12Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers12, eventId, callback);
	}

	private void Removel_1_skillTriggers12Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers12, eventId);
	}

	private void Createl_1_skillTriggers13Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers13, eventId, callback);
	}

	private void Removel_1_skillTriggers13Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers13, eventId);
	}

	private void Createl_1_skillTriggers14Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers14, eventId, callback);
	}

	private void Removel_1_skillTriggers14Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers14, eventId);
	}

	private void Createl_1_skillTriggers15Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers15, eventId, callback);
	}

	private void Removel_1_skillTriggers15Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers15, eventId);
	}

	private void Createl_1_skillTriggers16Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers16, eventId, callback);
	}

	private void Removel_1_skillTriggers16Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers16, eventId);
	}

	private void Createl_1_skillTriggers17Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers17, eventId, callback);
	}

	private void Removel_1_skillTriggers17Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers17, eventId);
	}

	private void Createl_1_skillTriggers18Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers18, eventId, callback);
	}

	private void Removel_1_skillTriggers18Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers18, eventId);
	}

	private void Createl_1_skillTriggers19Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers19, eventId, callback);
	}

	private void Removel_1_skillTriggers19Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers19, eventId);
	}

	private void Createl_1_skillTriggers20Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers20, eventId, callback);
	}

	private void Removel_1_skillTriggers20Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers20, eventId);
	}

	private void Createl_1_skillTriggers21Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers21, eventId, callback);
	}

	private void Removel_1_skillTriggers21Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers21, eventId);
	}

	private void Createl_1_skillTriggers22Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers22, eventId, callback);
	}

	private void Removel_1_skillTriggers22Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers22, eventId);
	}

	private void Createl_1_skillTriggers23Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers23, eventId, callback);
	}

	private void Removel_1_skillTriggers23Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers23, eventId);
	}

	private void Createl_1_skillTriggers24Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers24, eventId, callback);
	}

	private void Removel_1_skillTriggers24Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers24, eventId);
	}

	private void Createl_1_skillTriggers25Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers25, eventId, callback);
	}

	private void Removel_1_skillTriggers25Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers25, eventId);
	}

	private void Createl_1_skillTriggers26Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers26, eventId, callback);
	}

	private void Removel_1_skillTriggers26Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers26, eventId);
	}

	private void Createl_1_skillTriggers27Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers27, eventId, callback);
	}

	private void Removel_1_skillTriggers27Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers27, eventId);
	}

	private void Createl_1_skillTriggers28Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers28, eventId, callback);
	}

	private void Removel_1_skillTriggers28Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers28, eventId);
	}

	private void Createl_1_skillTriggers29Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers29, eventId, callback);
	}

	private void Removel_1_skillTriggers29Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers29, eventId);
	}

	private void Createl_1_skillTriggers30Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers30, eventId, callback);
	}

	private void Removel_1_skillTriggers30Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers30, eventId);
	}

	private void Createl_1_skillTriggers31Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers31, eventId, callback);
	}

	private void Removel_1_skillTriggers31Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers31, eventId);
	}

	private void Createl_1_skillTriggers32Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers32, eventId, callback);
	}

	private void Removel_1_skillTriggers32Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers32, eventId);
	}

	private void Createl_1_skillTriggers33Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers33, eventId, callback);
	}

	private void Removel_1_skillTriggers33Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers33, eventId);
	}

	private void Createl_1_skillTriggers34Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers34, eventId, callback);
	}

	private void Removel_1_skillTriggers34Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers34, eventId);
	}

	private void Createl_1_skillTriggers35Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers35, eventId, callback);
	}

	private void Removel_1_skillTriggers35Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers35, eventId);
	}

	private void Createl_1_skillTriggers36Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers36, eventId, callback);
	}

	private void Removel_1_skillTriggers36Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers36, eventId);
	}

	private void Createl_1_skillTriggers37Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers37, eventId, callback);
	}

	private void Removel_1_skillTriggers37Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers37, eventId);
	}

	private void Createl_1_skillTriggers38Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers38, eventId, callback);
	}

	private void Removel_1_skillTriggers38Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers38, eventId);
	}

	private void Createl_1_skillTriggers39Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers39, eventId, callback);
	}

	private void Removel_1_skillTriggers39Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers39, eventId);
	}

	private void Createl_1_skillTriggers40Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers40, eventId, callback);
	}

	private void Removel_1_skillTriggers40Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers40, eventId);
	}

	private void Createl_1_skillTriggers41Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(l_1_skillTriggers41, eventId, callback);
	}

	private void Removel_1_skillTriggers41Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(l_1_skillTriggers41, eventId);
	}

	public List<EventTrigger.Entry> Getl_1_skillTriggers(int index)
	{
		return index switch
		{
			1 => l_1_skillTriggers1, 
			2 => l_1_skillTriggers2, 
			3 => l_1_skillTriggers3, 
			4 => l_1_skillTriggers4, 
			5 => l_1_skillTriggers5, 
			6 => l_1_skillTriggers6, 
			7 => l_1_skillTriggers7, 
			8 => l_1_skillTriggers8, 
			9 => l_1_skillTriggers9, 
			10 => l_1_skillTriggers10, 
			11 => l_1_skillTriggers11, 
			12 => l_1_skillTriggers12, 
			13 => l_1_skillTriggers13, 
			14 => l_1_skillTriggers14, 
			15 => l_1_skillTriggers15, 
			16 => l_1_skillTriggers16, 
			17 => l_1_skillTriggers17, 
			18 => l_1_skillTriggers18, 
			19 => l_1_skillTriggers19, 
			20 => l_1_skillTriggers20, 
			21 => l_1_skillTriggers21, 
			22 => l_1_skillTriggers22, 
			23 => l_1_skillTriggers23, 
			24 => l_1_skillTriggers24, 
			25 => l_1_skillTriggers25, 
			26 => l_1_skillTriggers26, 
			27 => l_1_skillTriggers27, 
			28 => l_1_skillTriggers28, 
			29 => l_1_skillTriggers29, 
			30 => l_1_skillTriggers30, 
			31 => l_1_skillTriggers31, 
			32 => l_1_skillTriggers32, 
			33 => l_1_skillTriggers33, 
			34 => l_1_skillTriggers34, 
			35 => l_1_skillTriggers35, 
			36 => l_1_skillTriggers36, 
			37 => l_1_skillTriggers37, 
			38 => l_1_skillTriggers38, 
			39 => l_1_skillTriggers39, 
			40 => l_1_skillTriggers40, 
			41 => l_1_skillTriggers41, 
			_ => null, 
		};
	}

	public void Setl_1_skillTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			l_1_skillTriggers1 = value;
			break;
		case 2:
			l_1_skillTriggers2 = value;
			break;
		case 3:
			l_1_skillTriggers3 = value;
			break;
		case 4:
			l_1_skillTriggers4 = value;
			break;
		case 5:
			l_1_skillTriggers5 = value;
			break;
		case 6:
			l_1_skillTriggers6 = value;
			break;
		case 7:
			l_1_skillTriggers7 = value;
			break;
		case 8:
			l_1_skillTriggers8 = value;
			break;
		case 9:
			l_1_skillTriggers9 = value;
			break;
		case 10:
			l_1_skillTriggers10 = value;
			break;
		case 11:
			l_1_skillTriggers11 = value;
			break;
		case 12:
			l_1_skillTriggers12 = value;
			break;
		case 13:
			l_1_skillTriggers13 = value;
			break;
		case 14:
			l_1_skillTriggers14 = value;
			break;
		case 15:
			l_1_skillTriggers15 = value;
			break;
		case 16:
			l_1_skillTriggers16 = value;
			break;
		case 17:
			l_1_skillTriggers17 = value;
			break;
		case 18:
			l_1_skillTriggers18 = value;
			break;
		case 19:
			l_1_skillTriggers19 = value;
			break;
		case 20:
			l_1_skillTriggers20 = value;
			break;
		case 21:
			l_1_skillTriggers21 = value;
			break;
		case 22:
			l_1_skillTriggers22 = value;
			break;
		case 23:
			l_1_skillTriggers23 = value;
			break;
		case 24:
			l_1_skillTriggers24 = value;
			break;
		case 25:
			l_1_skillTriggers25 = value;
			break;
		case 26:
			l_1_skillTriggers26 = value;
			break;
		case 27:
			l_1_skillTriggers27 = value;
			break;
		case 28:
			l_1_skillTriggers28 = value;
			break;
		case 29:
			l_1_skillTriggers29 = value;
			break;
		case 30:
			l_1_skillTriggers30 = value;
			break;
		case 31:
			l_1_skillTriggers31 = value;
			break;
		case 32:
			l_1_skillTriggers32 = value;
			break;
		case 33:
			l_1_skillTriggers33 = value;
			break;
		case 34:
			l_1_skillTriggers34 = value;
			break;
		case 35:
			l_1_skillTriggers35 = value;
			break;
		case 36:
			l_1_skillTriggers36 = value;
			break;
		case 37:
			l_1_skillTriggers37 = value;
			break;
		case 38:
			l_1_skillTriggers38 = value;
			break;
		case 39:
			l_1_skillTriggers39 = value;
			break;
		case 40:
			l_1_skillTriggers40 = value;
			break;
		case 41:
			l_1_skillTriggers41 = value;
			break;
		}
	}

	private void Createl_1_skillTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(Getl_1_skillTriggers(index), eventId, callback);
	}

	private void Removel_1_skillTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(Getl_1_skillTriggers(index), eventId);
	}

	public Sprite Getl_1_IconbgSprite(int index)
	{
		return index switch
		{
			1 => l_1_IconbgSprite1, 
			2 => l_1_IconbgSprite2, 
			3 => l_1_IconbgSprite3, 
			4 => l_1_IconbgSprite4, 
			5 => l_1_IconbgSprite5, 
			6 => l_1_IconbgSprite6, 
			7 => l_1_IconbgSprite7, 
			8 => l_1_IconbgSprite8, 
			9 => l_1_IconbgSprite9, 
			10 => l_1_IconbgSprite10, 
			11 => l_1_IconbgSprite11, 
			12 => l_1_IconbgSprite12, 
			13 => l_1_IconbgSprite13, 
			14 => l_1_IconbgSprite14, 
			15 => l_1_IconbgSprite15, 
			16 => l_1_IconbgSprite16, 
			17 => l_1_IconbgSprite17, 
			18 => l_1_IconbgSprite18, 
			19 => l_1_IconbgSprite19, 
			20 => l_1_IconbgSprite20, 
			21 => l_1_IconbgSprite21, 
			22 => l_1_IconbgSprite22, 
			23 => l_1_IconbgSprite23, 
			24 => l_1_IconbgSprite24, 
			25 => l_1_IconbgSprite25, 
			26 => l_1_IconbgSprite26, 
			27 => l_1_IconbgSprite27, 
			28 => l_1_IconbgSprite28, 
			29 => l_1_IconbgSprite29, 
			30 => l_1_IconbgSprite30, 
			31 => l_1_IconbgSprite31, 
			32 => l_1_IconbgSprite32, 
			33 => l_1_IconbgSprite33, 
			34 => l_1_IconbgSprite34, 
			35 => l_1_IconbgSprite35, 
			36 => l_1_IconbgSprite36, 
			37 => l_1_IconbgSprite37, 
			38 => l_1_IconbgSprite38, 
			39 => l_1_IconbgSprite39, 
			40 => l_1_IconbgSprite40, 
			41 => l_1_IconbgSprite41, 
			_ => null, 
		};
	}

	public void Setl_1_IconbgSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			l_1_IconbgSprite1 = value;
			break;
		case 2:
			l_1_IconbgSprite2 = value;
			break;
		case 3:
			l_1_IconbgSprite3 = value;
			break;
		case 4:
			l_1_IconbgSprite4 = value;
			break;
		case 5:
			l_1_IconbgSprite5 = value;
			break;
		case 6:
			l_1_IconbgSprite6 = value;
			break;
		case 7:
			l_1_IconbgSprite7 = value;
			break;
		case 8:
			l_1_IconbgSprite8 = value;
			break;
		case 9:
			l_1_IconbgSprite9 = value;
			break;
		case 10:
			l_1_IconbgSprite10 = value;
			break;
		case 11:
			l_1_IconbgSprite11 = value;
			break;
		case 12:
			l_1_IconbgSprite12 = value;
			break;
		case 13:
			l_1_IconbgSprite13 = value;
			break;
		case 14:
			l_1_IconbgSprite14 = value;
			break;
		case 15:
			l_1_IconbgSprite15 = value;
			break;
		case 16:
			l_1_IconbgSprite16 = value;
			break;
		case 17:
			l_1_IconbgSprite17 = value;
			break;
		case 18:
			l_1_IconbgSprite18 = value;
			break;
		case 19:
			l_1_IconbgSprite19 = value;
			break;
		case 20:
			l_1_IconbgSprite20 = value;
			break;
		case 21:
			l_1_IconbgSprite21 = value;
			break;
		case 22:
			l_1_IconbgSprite22 = value;
			break;
		case 23:
			l_1_IconbgSprite23 = value;
			break;
		case 24:
			l_1_IconbgSprite24 = value;
			break;
		case 25:
			l_1_IconbgSprite25 = value;
			break;
		case 26:
			l_1_IconbgSprite26 = value;
			break;
		case 27:
			l_1_IconbgSprite27 = value;
			break;
		case 28:
			l_1_IconbgSprite28 = value;
			break;
		case 29:
			l_1_IconbgSprite29 = value;
			break;
		case 30:
			l_1_IconbgSprite30 = value;
			break;
		case 31:
			l_1_IconbgSprite31 = value;
			break;
		case 32:
			l_1_IconbgSprite32 = value;
			break;
		case 33:
			l_1_IconbgSprite33 = value;
			break;
		case 34:
			l_1_IconbgSprite34 = value;
			break;
		case 35:
			l_1_IconbgSprite35 = value;
			break;
		case 36:
			l_1_IconbgSprite36 = value;
			break;
		case 37:
			l_1_IconbgSprite37 = value;
			break;
		case 38:
			l_1_IconbgSprite38 = value;
			break;
		case 39:
			l_1_IconbgSprite39 = value;
			break;
		case 40:
			l_1_IconbgSprite40 = value;
			break;
		case 41:
			l_1_IconbgSprite41 = value;
			break;
		}
	}

	public Sprite Getl_1_IconSprite(int index)
	{
		return index switch
		{
			1 => l_1_IconSprite1, 
			2 => l_1_IconSprite2, 
			3 => l_1_IconSprite3, 
			4 => l_1_IconSprite4, 
			5 => l_1_IconSprite5, 
			6 => l_1_IconSprite6, 
			7 => l_1_IconSprite7, 
			8 => l_1_IconSprite8, 
			9 => l_1_IconSprite9, 
			10 => l_1_IconSprite10, 
			11 => l_1_IconSprite11, 
			12 => l_1_IconSprite12, 
			13 => l_1_IconSprite13, 
			14 => l_1_IconSprite14, 
			15 => l_1_IconSprite15, 
			16 => l_1_IconSprite16, 
			17 => l_1_IconSprite17, 
			18 => l_1_IconSprite18, 
			19 => l_1_IconSprite19, 
			20 => l_1_IconSprite20, 
			21 => l_1_IconSprite21, 
			22 => l_1_IconSprite22, 
			23 => l_1_IconSprite23, 
			24 => l_1_IconSprite24, 
			25 => l_1_IconSprite25, 
			26 => l_1_IconSprite26, 
			27 => l_1_IconSprite27, 
			28 => l_1_IconSprite28, 
			29 => l_1_IconSprite29, 
			30 => l_1_IconSprite30, 
			31 => l_1_IconSprite31, 
			32 => l_1_IconSprite32, 
			33 => l_1_IconSprite33, 
			34 => l_1_IconSprite34, 
			35 => l_1_IconSprite35, 
			36 => l_1_IconSprite36, 
			37 => l_1_IconSprite37, 
			38 => l_1_IconSprite38, 
			39 => l_1_IconSprite39, 
			40 => l_1_IconSprite40, 
			41 => l_1_IconSprite41, 
			_ => null, 
		};
	}

	public void Setl_1_IconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			l_1_IconSprite1 = value;
			break;
		case 2:
			l_1_IconSprite2 = value;
			break;
		case 3:
			l_1_IconSprite3 = value;
			break;
		case 4:
			l_1_IconSprite4 = value;
			break;
		case 5:
			l_1_IconSprite5 = value;
			break;
		case 6:
			l_1_IconSprite6 = value;
			break;
		case 7:
			l_1_IconSprite7 = value;
			break;
		case 8:
			l_1_IconSprite8 = value;
			break;
		case 9:
			l_1_IconSprite9 = value;
			break;
		case 10:
			l_1_IconSprite10 = value;
			break;
		case 11:
			l_1_IconSprite11 = value;
			break;
		case 12:
			l_1_IconSprite12 = value;
			break;
		case 13:
			l_1_IconSprite13 = value;
			break;
		case 14:
			l_1_IconSprite14 = value;
			break;
		case 15:
			l_1_IconSprite15 = value;
			break;
		case 16:
			l_1_IconSprite16 = value;
			break;
		case 17:
			l_1_IconSprite17 = value;
			break;
		case 18:
			l_1_IconSprite18 = value;
			break;
		case 19:
			l_1_IconSprite19 = value;
			break;
		case 20:
			l_1_IconSprite20 = value;
			break;
		case 21:
			l_1_IconSprite21 = value;
			break;
		case 22:
			l_1_IconSprite22 = value;
			break;
		case 23:
			l_1_IconSprite23 = value;
			break;
		case 24:
			l_1_IconSprite24 = value;
			break;
		case 25:
			l_1_IconSprite25 = value;
			break;
		case 26:
			l_1_IconSprite26 = value;
			break;
		case 27:
			l_1_IconSprite27 = value;
			break;
		case 28:
			l_1_IconSprite28 = value;
			break;
		case 29:
			l_1_IconSprite29 = value;
			break;
		case 30:
			l_1_IconSprite30 = value;
			break;
		case 31:
			l_1_IconSprite31 = value;
			break;
		case 32:
			l_1_IconSprite32 = value;
			break;
		case 33:
			l_1_IconSprite33 = value;
			break;
		case 34:
			l_1_IconSprite34 = value;
			break;
		case 35:
			l_1_IconSprite35 = value;
			break;
		case 36:
			l_1_IconSprite36 = value;
			break;
		case 37:
			l_1_IconSprite37 = value;
			break;
		case 38:
			l_1_IconSprite38 = value;
			break;
		case 39:
			l_1_IconSprite39 = value;
			break;
		case 40:
			l_1_IconSprite40 = value;
			break;
		case 41:
			l_1_IconSprite41 = value;
			break;
		}
	}

	public string Getl_1_NameString(int index)
	{
		return index switch
		{
			1 => l_1_NameString1, 
			2 => l_1_NameString2, 
			3 => l_1_NameString3, 
			4 => l_1_NameString4, 
			5 => l_1_NameString5, 
			6 => l_1_NameString6, 
			7 => l_1_NameString7, 
			8 => l_1_NameString8, 
			9 => l_1_NameString9, 
			10 => l_1_NameString10, 
			11 => l_1_NameString11, 
			12 => l_1_NameString12, 
			13 => l_1_NameString13, 
			14 => l_1_NameString14, 
			15 => l_1_NameString15, 
			16 => l_1_NameString16, 
			17 => l_1_NameString17, 
			18 => l_1_NameString18, 
			19 => l_1_NameString19, 
			20 => l_1_NameString20, 
			21 => l_1_NameString21, 
			22 => l_1_NameString22, 
			23 => l_1_NameString23, 
			24 => l_1_NameString24, 
			25 => l_1_NameString25, 
			26 => l_1_NameString26, 
			27 => l_1_NameString27, 
			28 => l_1_NameString28, 
			29 => l_1_NameString29, 
			30 => l_1_NameString30, 
			31 => l_1_NameString31, 
			32 => l_1_NameString32, 
			33 => l_1_NameString33, 
			34 => l_1_NameString34, 
			35 => l_1_NameString35, 
			36 => l_1_NameString36, 
			37 => l_1_NameString37, 
			38 => l_1_NameString38, 
			39 => l_1_NameString39, 
			40 => l_1_NameString40, 
			41 => l_1_NameString41, 
			_ => null, 
		};
	}

	public void Setl_1_NameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			l_1_NameString1 = value;
			break;
		case 2:
			l_1_NameString2 = value;
			break;
		case 3:
			l_1_NameString3 = value;
			break;
		case 4:
			l_1_NameString4 = value;
			break;
		case 5:
			l_1_NameString5 = value;
			break;
		case 6:
			l_1_NameString6 = value;
			break;
		case 7:
			l_1_NameString7 = value;
			break;
		case 8:
			l_1_NameString8 = value;
			break;
		case 9:
			l_1_NameString9 = value;
			break;
		case 10:
			l_1_NameString10 = value;
			break;
		case 11:
			l_1_NameString11 = value;
			break;
		case 12:
			l_1_NameString12 = value;
			break;
		case 13:
			l_1_NameString13 = value;
			break;
		case 14:
			l_1_NameString14 = value;
			break;
		case 15:
			l_1_NameString15 = value;
			break;
		case 16:
			l_1_NameString16 = value;
			break;
		case 17:
			l_1_NameString17 = value;
			break;
		case 18:
			l_1_NameString18 = value;
			break;
		case 19:
			l_1_NameString19 = value;
			break;
		case 20:
			l_1_NameString20 = value;
			break;
		case 21:
			l_1_NameString21 = value;
			break;
		case 22:
			l_1_NameString22 = value;
			break;
		case 23:
			l_1_NameString23 = value;
			break;
		case 24:
			l_1_NameString24 = value;
			break;
		case 25:
			l_1_NameString25 = value;
			break;
		case 26:
			l_1_NameString26 = value;
			break;
		case 27:
			l_1_NameString27 = value;
			break;
		case 28:
			l_1_NameString28 = value;
			break;
		case 29:
			l_1_NameString29 = value;
			break;
		case 30:
			l_1_NameString30 = value;
			break;
		case 31:
			l_1_NameString31 = value;
			break;
		case 32:
			l_1_NameString32 = value;
			break;
		case 33:
			l_1_NameString33 = value;
			break;
		case 34:
			l_1_NameString34 = value;
			break;
		case 35:
			l_1_NameString35 = value;
			break;
		case 36:
			l_1_NameString36 = value;
			break;
		case 37:
			l_1_NameString37 = value;
			break;
		case 38:
			l_1_NameString38 = value;
			break;
		case 39:
			l_1_NameString39 = value;
			break;
		case 40:
			l_1_NameString40 = value;
			break;
		case 41:
			l_1_NameString41 = value;
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
