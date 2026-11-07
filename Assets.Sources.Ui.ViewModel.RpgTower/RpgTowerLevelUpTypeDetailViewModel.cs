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

namespace Assets.Sources.Ui.ViewModel.RpgTower;

[GameUiTest]
public class RpgTowerLevelUpTypeDetailViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private GameObject _oTypeTitle;

	private Image _oTypeTitleImage;

	private GameObject _oPage;

	private Text _oPageText;

	private GameObject _oBeforeSingle;

	private EventTrigger _oBeforeSingleEventTrigger;

	private Button _oBeforeSingleButton;

	private GameObject _oNextSingle;

	private EventTrigger _oNextSingleEventTrigger;

	private Button _oNextSingleButton;

	private GameObject _oBeforeAll;

	private EventTrigger _oBeforeAllEventTrigger;

	private Button _oBeforeAllButton;

	private GameObject _oNextAll;

	private EventTrigger _oNextAllEventTrigger;

	private Button _oNextAllButton;

	private GameObject _oComfirm;

	private EventTrigger _oComfirmEventTrigger;

	private GameObject _oCancel;

	private EventTrigger _oCancelEventTrigger;

	private Button _oCancelButton;

	private GameObject _oContent;

	private VerticalLayoutGroup _oContentVerticalLayoutGroup;

	private GameObject _oType1;

	private GameObject _oType2;

	private GameObject _oType3;

	private GameObject _oSkillTypeDes1;

	private GameObject _oSkillTypeDes2;

	private GameObject _oSkillTypeDes3;

	private GameObject _oSkillTypeDes4;

	private GameObject _oSkillTypeDes5;

	private GameObject _oSkillTypeDes6;

	private GameObject _oSkillTypeDes7;

	private GameObject _oSkillTypeDes8;

	private GameObject _oSkillTypeDes9;

	private GameObject _oSkillTypeDes10;

	private GameObject _oSkillTypeDes11;

	private GameObject _oSkillTypeDes12;

	private GameObject _oSkillTypeDes13;

	private GameObject _oSkillTypeDes14;

	private GameObject _oSkillTypeDes15;

	private GameObject _oSkillTypeDes16;

	private GameObject _oSkillTypeDes17;

	private GameObject _oSkillTypeDes18;

	private GameObject _oSkillTypeDes19;

	private GameObject _oSkillTypeDes20;

	private GameObject _oSkillTypeDes21;

	private GameObject _oSkillTypeDes22;

	private GameObject _oSkillTypeDes23;

	private GameObject _oSkillTypeDes24;

	private GameObject _oSkillTypeDes25;

	private GameObject _oSkillTypeDes26;

	private GameObject _oSkillTypeDes27;

	private GameObject _oSkillTypeDes28;

	private GameObject _oSkillTypeDes29;

	private GameObject _oSkillTypeDes30;

	private GameObject _oSkillTypeDes31;

	private GameObject _oSkillTypeDes32;

	private GameObject _oSkillTypeDes33;

	private GameObject _oSkillTypeDes34;

	private Text _oSkillTypeDesText1;

	private Text _oSkillTypeDesText2;

	private Text _oSkillTypeDesText3;

	private Text _oSkillTypeDesText4;

	private Text _oSkillTypeDesText5;

	private Text _oSkillTypeDesText6;

	private Text _oSkillTypeDesText7;

	private Text _oSkillTypeDesText8;

	private Text _oSkillTypeDesText9;

	private Text _oSkillTypeDesText10;

	private Text _oSkillTypeDesText11;

	private Text _oSkillTypeDesText12;

	private Text _oSkillTypeDesText13;

	private Text _oSkillTypeDesText14;

	private Text _oSkillTypeDesText15;

	private Text _oSkillTypeDesText16;

	private Text _oSkillTypeDesText17;

	private Text _oSkillTypeDesText18;

	private Text _oSkillTypeDesText19;

	private Text _oSkillTypeDesText20;

	private Text _oSkillTypeDesText21;

	private Text _oSkillTypeDesText22;

	private Text _oSkillTypeDesText23;

	private Text _oSkillTypeDesText24;

	private Text _oSkillTypeDesText25;

	private Text _oSkillTypeDesText26;

	private Text _oSkillTypeDesText27;

	private Text _oSkillTypeDesText28;

	private Text _oSkillTypeDesText29;

	private Text _oSkillTypeDesText30;

	private Text _oSkillTypeDesText31;

	private Text _oSkillTypeDesText32;

	private Text _oSkillTypeDesText33;

	private Text _oSkillTypeDesText34;

	private GameObject _oCost;

	private Text _oCostText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerLevelUpTypeDetail";

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

	public List<EventTrigger.Entry> CloseTriggers
	{
		get
		{
			if (_oCloseEventTrigger != null)
			{
				return _oCloseEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseTriggers != value && _oCloseEventTrigger != null)
			{
				_oCloseEventTrigger.triggers = value;
			}
		}
	}

	public Sprite TypeTitleSprite
	{
		get
		{
			if (_oTypeTitleImage != null)
			{
				return _oTypeTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TypeTitleSprite != value && _oTypeTitleImage != null)
			{
				_oTypeTitleImage.sprite = value;
			}
		}
	}

	public Image TypeTitleImage
	{
		get
		{
			if (_oTypeTitleImage != null)
			{
				return _oTypeTitleImage;
			}
			return null;
		}
		set
		{
			if (TypeTitleImage != value && _oTypeTitleImage != null)
			{
				_oTypeTitleImage = value;
			}
		}
	}

	public string PageString
	{
		get
		{
			if (_oPageText != null)
			{
				return _oPageText.text;
			}
			return null;
		}
		set
		{
			if (PageString != value && _oPageText != null)
			{
				_oPageText.text = value;
			}
		}
	}

	public bool BeforeSingleShow
	{
		get
		{
			if (_oBeforeSingle != null)
			{
				return _oBeforeSingle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BeforeSingleShow != value && _oBeforeSingle != null)
			{
				_oBeforeSingle.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> BeforeSingleTriggers
	{
		get
		{
			if (_oBeforeSingleEventTrigger != null)
			{
				return _oBeforeSingleEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (BeforeSingleTriggers != value && _oBeforeSingleEventTrigger != null)
			{
				_oBeforeSingleEventTrigger.triggers = value;
			}
		}
	}

	public bool BeforeSingleButtonable
	{
		get
		{
			if (_oBeforeSingleButton != null)
			{
				return _oBeforeSingleButton.interactable;
			}
			return true;
		}
		set
		{
			if (BeforeSingleButtonable != value && _oBeforeSingleButton != null)
			{
				_oBeforeSingleButton.interactable = value;
			}
		}
	}

	public bool NextSingleShow
	{
		get
		{
			if (_oNextSingle != null)
			{
				return _oNextSingle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NextSingleShow != value && _oNextSingle != null)
			{
				_oNextSingle.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> NextSingleTriggers
	{
		get
		{
			if (_oNextSingleEventTrigger != null)
			{
				return _oNextSingleEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (NextSingleTriggers != value && _oNextSingleEventTrigger != null)
			{
				_oNextSingleEventTrigger.triggers = value;
			}
		}
	}

	public bool NextSingleButtonable
	{
		get
		{
			if (_oNextSingleButton != null)
			{
				return _oNextSingleButton.interactable;
			}
			return true;
		}
		set
		{
			if (NextSingleButtonable != value && _oNextSingleButton != null)
			{
				_oNextSingleButton.interactable = value;
			}
		}
	}

	public bool BeforeAllShow
	{
		get
		{
			if (_oBeforeAll != null)
			{
				return _oBeforeAll.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BeforeAllShow != value && _oBeforeAll != null)
			{
				_oBeforeAll.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> BeforeAllTriggers
	{
		get
		{
			if (_oBeforeAllEventTrigger != null)
			{
				return _oBeforeAllEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (BeforeAllTriggers != value && _oBeforeAllEventTrigger != null)
			{
				_oBeforeAllEventTrigger.triggers = value;
			}
		}
	}

	public bool BeforeAllButtonable
	{
		get
		{
			if (_oBeforeAllButton != null)
			{
				return _oBeforeAllButton.interactable;
			}
			return true;
		}
		set
		{
			if (BeforeAllButtonable != value && _oBeforeAllButton != null)
			{
				_oBeforeAllButton.interactable = value;
			}
		}
	}

	public bool NextAllShow
	{
		get
		{
			if (_oNextAll != null)
			{
				return _oNextAll.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NextAllShow != value && _oNextAll != null)
			{
				_oNextAll.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> NextAllTriggers
	{
		get
		{
			if (_oNextAllEventTrigger != null)
			{
				return _oNextAllEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (NextAllTriggers != value && _oNextAllEventTrigger != null)
			{
				_oNextAllEventTrigger.triggers = value;
			}
		}
	}

	public bool NextAllButtonable
	{
		get
		{
			if (_oNextAllButton != null)
			{
				return _oNextAllButton.interactable;
			}
			return true;
		}
		set
		{
			if (NextAllButtonable != value && _oNextAllButton != null)
			{
				_oNextAllButton.interactable = value;
			}
		}
	}

	public List<EventTrigger.Entry> ComfirmTriggers
	{
		get
		{
			if (_oComfirmEventTrigger != null)
			{
				return _oComfirmEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ComfirmTriggers != value && _oComfirmEventTrigger != null)
			{
				_oComfirmEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CancelTriggers
	{
		get
		{
			if (_oCancelEventTrigger != null)
			{
				return _oCancelEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CancelTriggers != value && _oCancelEventTrigger != null)
			{
				_oCancelEventTrigger.triggers = value;
			}
		}
	}

	public bool CancelButtonable
	{
		get
		{
			if (_oCancelButton != null)
			{
				return _oCancelButton.interactable;
			}
			return true;
		}
		set
		{
			if (CancelButtonable != value && _oCancelButton != null)
			{
				_oCancelButton.interactable = value;
			}
		}
	}

	public float ContentVspacing
	{
		get
		{
			if (_oContentVerticalLayoutGroup != null)
			{
				return _oContentVerticalLayoutGroup.spacing;
			}
			return 0f;
		}
		set
		{
			if (ContentVspacing != value && _oContentVerticalLayoutGroup != null)
			{
				_oContentVerticalLayoutGroup.spacing = value;
			}
		}
	}

	public bool TypeShow1
	{
		get
		{
			if (_oType1 != null)
			{
				return _oType1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow1 != value && _oType1 != null)
			{
				_oType1.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow2
	{
		get
		{
			if (_oType2 != null)
			{
				return _oType2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow2 != value && _oType2 != null)
			{
				_oType2.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow3
	{
		get
		{
			if (_oType3 != null)
			{
				return _oType3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow3 != value && _oType3 != null)
			{
				_oType3.SetObjectActive(value);
			}
		}
	}

	public string SkillTypeDesString1
	{
		get
		{
			if (_oSkillTypeDesText1 != null)
			{
				return _oSkillTypeDesText1.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString1 != value && _oSkillTypeDesText1 != null)
			{
				_oSkillTypeDesText1.text = value;
			}
		}
	}

	public string SkillTypeDesString2
	{
		get
		{
			if (_oSkillTypeDesText2 != null)
			{
				return _oSkillTypeDesText2.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString2 != value && _oSkillTypeDesText2 != null)
			{
				_oSkillTypeDesText2.text = value;
			}
		}
	}

	public string SkillTypeDesString3
	{
		get
		{
			if (_oSkillTypeDesText3 != null)
			{
				return _oSkillTypeDesText3.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString3 != value && _oSkillTypeDesText3 != null)
			{
				_oSkillTypeDesText3.text = value;
			}
		}
	}

	public string SkillTypeDesString4
	{
		get
		{
			if (_oSkillTypeDesText4 != null)
			{
				return _oSkillTypeDesText4.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString4 != value && _oSkillTypeDesText4 != null)
			{
				_oSkillTypeDesText4.text = value;
			}
		}
	}

	public string SkillTypeDesString5
	{
		get
		{
			if (_oSkillTypeDesText5 != null)
			{
				return _oSkillTypeDesText5.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString5 != value && _oSkillTypeDesText5 != null)
			{
				_oSkillTypeDesText5.text = value;
			}
		}
	}

	public string SkillTypeDesString6
	{
		get
		{
			if (_oSkillTypeDesText6 != null)
			{
				return _oSkillTypeDesText6.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString6 != value && _oSkillTypeDesText6 != null)
			{
				_oSkillTypeDesText6.text = value;
			}
		}
	}

	public string SkillTypeDesString7
	{
		get
		{
			if (_oSkillTypeDesText7 != null)
			{
				return _oSkillTypeDesText7.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString7 != value && _oSkillTypeDesText7 != null)
			{
				_oSkillTypeDesText7.text = value;
			}
		}
	}

	public string SkillTypeDesString8
	{
		get
		{
			if (_oSkillTypeDesText8 != null)
			{
				return _oSkillTypeDesText8.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString8 != value && _oSkillTypeDesText8 != null)
			{
				_oSkillTypeDesText8.text = value;
			}
		}
	}

	public string SkillTypeDesString9
	{
		get
		{
			if (_oSkillTypeDesText9 != null)
			{
				return _oSkillTypeDesText9.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString9 != value && _oSkillTypeDesText9 != null)
			{
				_oSkillTypeDesText9.text = value;
			}
		}
	}

	public string SkillTypeDesString10
	{
		get
		{
			if (_oSkillTypeDesText10 != null)
			{
				return _oSkillTypeDesText10.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString10 != value && _oSkillTypeDesText10 != null)
			{
				_oSkillTypeDesText10.text = value;
			}
		}
	}

	public string SkillTypeDesString11
	{
		get
		{
			if (_oSkillTypeDesText11 != null)
			{
				return _oSkillTypeDesText11.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString11 != value && _oSkillTypeDesText11 != null)
			{
				_oSkillTypeDesText11.text = value;
			}
		}
	}

	public string SkillTypeDesString12
	{
		get
		{
			if (_oSkillTypeDesText12 != null)
			{
				return _oSkillTypeDesText12.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString12 != value && _oSkillTypeDesText12 != null)
			{
				_oSkillTypeDesText12.text = value;
			}
		}
	}

	public string SkillTypeDesString13
	{
		get
		{
			if (_oSkillTypeDesText13 != null)
			{
				return _oSkillTypeDesText13.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString13 != value && _oSkillTypeDesText13 != null)
			{
				_oSkillTypeDesText13.text = value;
			}
		}
	}

	public string SkillTypeDesString14
	{
		get
		{
			if (_oSkillTypeDesText14 != null)
			{
				return _oSkillTypeDesText14.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString14 != value && _oSkillTypeDesText14 != null)
			{
				_oSkillTypeDesText14.text = value;
			}
		}
	}

	public string SkillTypeDesString15
	{
		get
		{
			if (_oSkillTypeDesText15 != null)
			{
				return _oSkillTypeDesText15.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString15 != value && _oSkillTypeDesText15 != null)
			{
				_oSkillTypeDesText15.text = value;
			}
		}
	}

	public string SkillTypeDesString16
	{
		get
		{
			if (_oSkillTypeDesText16 != null)
			{
				return _oSkillTypeDesText16.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString16 != value && _oSkillTypeDesText16 != null)
			{
				_oSkillTypeDesText16.text = value;
			}
		}
	}

	public string SkillTypeDesString17
	{
		get
		{
			if (_oSkillTypeDesText17 != null)
			{
				return _oSkillTypeDesText17.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString17 != value && _oSkillTypeDesText17 != null)
			{
				_oSkillTypeDesText17.text = value;
			}
		}
	}

	public string SkillTypeDesString18
	{
		get
		{
			if (_oSkillTypeDesText18 != null)
			{
				return _oSkillTypeDesText18.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString18 != value && _oSkillTypeDesText18 != null)
			{
				_oSkillTypeDesText18.text = value;
			}
		}
	}

	public string SkillTypeDesString19
	{
		get
		{
			if (_oSkillTypeDesText19 != null)
			{
				return _oSkillTypeDesText19.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString19 != value && _oSkillTypeDesText19 != null)
			{
				_oSkillTypeDesText19.text = value;
			}
		}
	}

	public string SkillTypeDesString20
	{
		get
		{
			if (_oSkillTypeDesText20 != null)
			{
				return _oSkillTypeDesText20.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString20 != value && _oSkillTypeDesText20 != null)
			{
				_oSkillTypeDesText20.text = value;
			}
		}
	}

	public string SkillTypeDesString21
	{
		get
		{
			if (_oSkillTypeDesText21 != null)
			{
				return _oSkillTypeDesText21.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString21 != value && _oSkillTypeDesText21 != null)
			{
				_oSkillTypeDesText21.text = value;
			}
		}
	}

	public string SkillTypeDesString22
	{
		get
		{
			if (_oSkillTypeDesText22 != null)
			{
				return _oSkillTypeDesText22.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString22 != value && _oSkillTypeDesText22 != null)
			{
				_oSkillTypeDesText22.text = value;
			}
		}
	}

	public string SkillTypeDesString23
	{
		get
		{
			if (_oSkillTypeDesText23 != null)
			{
				return _oSkillTypeDesText23.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString23 != value && _oSkillTypeDesText23 != null)
			{
				_oSkillTypeDesText23.text = value;
			}
		}
	}

	public string SkillTypeDesString24
	{
		get
		{
			if (_oSkillTypeDesText24 != null)
			{
				return _oSkillTypeDesText24.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString24 != value && _oSkillTypeDesText24 != null)
			{
				_oSkillTypeDesText24.text = value;
			}
		}
	}

	public string SkillTypeDesString25
	{
		get
		{
			if (_oSkillTypeDesText25 != null)
			{
				return _oSkillTypeDesText25.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString25 != value && _oSkillTypeDesText25 != null)
			{
				_oSkillTypeDesText25.text = value;
			}
		}
	}

	public string SkillTypeDesString26
	{
		get
		{
			if (_oSkillTypeDesText26 != null)
			{
				return _oSkillTypeDesText26.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString26 != value && _oSkillTypeDesText26 != null)
			{
				_oSkillTypeDesText26.text = value;
			}
		}
	}

	public string SkillTypeDesString27
	{
		get
		{
			if (_oSkillTypeDesText27 != null)
			{
				return _oSkillTypeDesText27.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString27 != value && _oSkillTypeDesText27 != null)
			{
				_oSkillTypeDesText27.text = value;
			}
		}
	}

	public string SkillTypeDesString28
	{
		get
		{
			if (_oSkillTypeDesText28 != null)
			{
				return _oSkillTypeDesText28.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString28 != value && _oSkillTypeDesText28 != null)
			{
				_oSkillTypeDesText28.text = value;
			}
		}
	}

	public string SkillTypeDesString29
	{
		get
		{
			if (_oSkillTypeDesText29 != null)
			{
				return _oSkillTypeDesText29.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString29 != value && _oSkillTypeDesText29 != null)
			{
				_oSkillTypeDesText29.text = value;
			}
		}
	}

	public string SkillTypeDesString30
	{
		get
		{
			if (_oSkillTypeDesText30 != null)
			{
				return _oSkillTypeDesText30.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString30 != value && _oSkillTypeDesText30 != null)
			{
				_oSkillTypeDesText30.text = value;
			}
		}
	}

	public string SkillTypeDesString31
	{
		get
		{
			if (_oSkillTypeDesText31 != null)
			{
				return _oSkillTypeDesText31.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString31 != value && _oSkillTypeDesText31 != null)
			{
				_oSkillTypeDesText31.text = value;
			}
		}
	}

	public string SkillTypeDesString32
	{
		get
		{
			if (_oSkillTypeDesText32 != null)
			{
				return _oSkillTypeDesText32.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString32 != value && _oSkillTypeDesText32 != null)
			{
				_oSkillTypeDesText32.text = value;
			}
		}
	}

	public string SkillTypeDesString33
	{
		get
		{
			if (_oSkillTypeDesText33 != null)
			{
				return _oSkillTypeDesText33.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString33 != value && _oSkillTypeDesText33 != null)
			{
				_oSkillTypeDesText33.text = value;
			}
		}
	}

	public string SkillTypeDesString34
	{
		get
		{
			if (_oSkillTypeDesText34 != null)
			{
				return _oSkillTypeDesText34.text;
			}
			return null;
		}
		set
		{
			if (SkillTypeDesString34 != value && _oSkillTypeDesText34 != null)
			{
				_oSkillTypeDesText34.text = value;
			}
		}
	}

	public string CostString
	{
		get
		{
			if (_oCostText != null)
			{
				return _oCostText.text;
			}
			return null;
		}
		set
		{
			if (CostString != value && _oCostText != null)
			{
				_oCostText.text = value;
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
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TypeTitle":
				_oTypeTitle = transform.gameObject;
				_oTypeTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Page":
				_oPage = transform.gameObject;
				_oPageText = transform.gameObject.GetComponent<Text>();
				break;
			case "BeforeSingle":
				_oBeforeSingle = transform.gameObject;
				_oBeforeSingleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oBeforeSingleButton = transform.gameObject.GetComponent<Button>();
				break;
			case "NextSingle":
				_oNextSingle = transform.gameObject;
				_oNextSingleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oNextSingleButton = transform.gameObject.GetComponent<Button>();
				break;
			case "BeforeAll":
				_oBeforeAll = transform.gameObject;
				_oBeforeAllEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oBeforeAllButton = transform.gameObject.GetComponent<Button>();
				break;
			case "NextAll":
				_oNextAll = transform.gameObject;
				_oNextAllEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oNextAllButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Comfirm":
				_oComfirm = transform.gameObject;
				_oComfirmEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Cancel":
				_oCancel = transform.gameObject;
				_oCancelEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCancelButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Content":
				_oContent = transform.gameObject;
				_oContentVerticalLayoutGroup = transform.gameObject.GetComponent<VerticalLayoutGroup>();
				break;
			case "Type1":
				_oType1 = transform.gameObject;
				break;
			case "Type2":
				_oType2 = transform.gameObject;
				break;
			case "Type3":
				_oType3 = transform.gameObject;
				break;
			case "SkillTypeDes1":
				_oSkillTypeDes1 = transform.gameObject;
				_oSkillTypeDesText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes2":
				_oSkillTypeDes2 = transform.gameObject;
				_oSkillTypeDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes3":
				_oSkillTypeDes3 = transform.gameObject;
				_oSkillTypeDesText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes4":
				_oSkillTypeDes4 = transform.gameObject;
				_oSkillTypeDesText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes5":
				_oSkillTypeDes5 = transform.gameObject;
				_oSkillTypeDesText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes6":
				_oSkillTypeDes6 = transform.gameObject;
				_oSkillTypeDesText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes7":
				_oSkillTypeDes7 = transform.gameObject;
				_oSkillTypeDesText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes8":
				_oSkillTypeDes8 = transform.gameObject;
				_oSkillTypeDesText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes9":
				_oSkillTypeDes9 = transform.gameObject;
				_oSkillTypeDesText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes10":
				_oSkillTypeDes10 = transform.gameObject;
				_oSkillTypeDesText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes11":
				_oSkillTypeDes11 = transform.gameObject;
				_oSkillTypeDesText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes12":
				_oSkillTypeDes12 = transform.gameObject;
				_oSkillTypeDesText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes13":
				_oSkillTypeDes13 = transform.gameObject;
				_oSkillTypeDesText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes14":
				_oSkillTypeDes14 = transform.gameObject;
				_oSkillTypeDesText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes15":
				_oSkillTypeDes15 = transform.gameObject;
				_oSkillTypeDesText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes16":
				_oSkillTypeDes16 = transform.gameObject;
				_oSkillTypeDesText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes17":
				_oSkillTypeDes17 = transform.gameObject;
				_oSkillTypeDesText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes18":
				_oSkillTypeDes18 = transform.gameObject;
				_oSkillTypeDesText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes19":
				_oSkillTypeDes19 = transform.gameObject;
				_oSkillTypeDesText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes20":
				_oSkillTypeDes20 = transform.gameObject;
				_oSkillTypeDesText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes21":
				_oSkillTypeDes21 = transform.gameObject;
				_oSkillTypeDesText21 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes22":
				_oSkillTypeDes22 = transform.gameObject;
				_oSkillTypeDesText22 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes23":
				_oSkillTypeDes23 = transform.gameObject;
				_oSkillTypeDesText23 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes24":
				_oSkillTypeDes24 = transform.gameObject;
				_oSkillTypeDesText24 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes25":
				_oSkillTypeDes25 = transform.gameObject;
				_oSkillTypeDesText25 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes26":
				_oSkillTypeDes26 = transform.gameObject;
				_oSkillTypeDesText26 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes27":
				_oSkillTypeDes27 = transform.gameObject;
				_oSkillTypeDesText27 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes28":
				_oSkillTypeDes28 = transform.gameObject;
				_oSkillTypeDesText28 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes29":
				_oSkillTypeDes29 = transform.gameObject;
				_oSkillTypeDesText29 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes30":
				_oSkillTypeDes30 = transform.gameObject;
				_oSkillTypeDesText30 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes31":
				_oSkillTypeDes31 = transform.gameObject;
				_oSkillTypeDesText31 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes32":
				_oSkillTypeDes32 = transform.gameObject;
				_oSkillTypeDesText32 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes33":
				_oSkillTypeDes33 = transform.gameObject;
				_oSkillTypeDesText33 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTypeDes34":
				_oSkillTypeDes34 = transform.gameObject;
				_oSkillTypeDesText34 = transform.gameObject.GetComponent<Text>();
				break;
			case "Cost":
				_oCost = transform.gameObject;
				_oCostText = transform.gameObject.GetComponent<Text>();
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

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
	}

	private void CreateBeforeSingleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BeforeSingleTriggers, eventId, callback);
	}

	private void RemoveBeforeSingleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BeforeSingleTriggers, eventId);
	}

	private void CreateNextSingleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(NextSingleTriggers, eventId, callback);
	}

	private void RemoveNextSingleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(NextSingleTriggers, eventId);
	}

	private void CreateBeforeAllTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BeforeAllTriggers, eventId, callback);
	}

	private void RemoveBeforeAllTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BeforeAllTriggers, eventId);
	}

	private void CreateNextAllTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(NextAllTriggers, eventId, callback);
	}

	private void RemoveNextAllTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(NextAllTriggers, eventId);
	}

	private void CreateComfirmTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ComfirmTriggers, eventId, callback);
	}

	private void RemoveComfirmTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ComfirmTriggers, eventId);
	}

	private void CreateCancelTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CancelTriggers, eventId, callback);
	}

	private void RemoveCancelTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CancelTriggers, eventId);
	}

	public void ContentVlayoutupdate()
	{
		if (_oContentVerticalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oContent.GetComponent<RectTransform>());
		}
	}

	public bool GetTypeShow(int index)
	{
		return index switch
		{
			1 => TypeShow1, 
			2 => TypeShow2, 
			3 => TypeShow3, 
			_ => false, 
		};
	}

	public void SetTypeShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TypeShow1 = value;
			break;
		case 2:
			TypeShow2 = value;
			break;
		case 3:
			TypeShow3 = value;
			break;
		}
	}

	public int GetTypeCount()
	{
		return 3;
	}

	public string GetSkillTypeDesString(int index)
	{
		return index switch
		{
			1 => SkillTypeDesString1, 
			2 => SkillTypeDesString2, 
			3 => SkillTypeDesString3, 
			4 => SkillTypeDesString4, 
			5 => SkillTypeDesString5, 
			6 => SkillTypeDesString6, 
			7 => SkillTypeDesString7, 
			8 => SkillTypeDesString8, 
			9 => SkillTypeDesString9, 
			10 => SkillTypeDesString10, 
			11 => SkillTypeDesString11, 
			12 => SkillTypeDesString12, 
			13 => SkillTypeDesString13, 
			14 => SkillTypeDesString14, 
			15 => SkillTypeDesString15, 
			16 => SkillTypeDesString16, 
			17 => SkillTypeDesString17, 
			18 => SkillTypeDesString18, 
			19 => SkillTypeDesString19, 
			20 => SkillTypeDesString20, 
			21 => SkillTypeDesString21, 
			22 => SkillTypeDesString22, 
			23 => SkillTypeDesString23, 
			24 => SkillTypeDesString24, 
			25 => SkillTypeDesString25, 
			26 => SkillTypeDesString26, 
			27 => SkillTypeDesString27, 
			28 => SkillTypeDesString28, 
			29 => SkillTypeDesString29, 
			30 => SkillTypeDesString30, 
			31 => SkillTypeDesString31, 
			32 => SkillTypeDesString32, 
			33 => SkillTypeDesString33, 
			34 => SkillTypeDesString34, 
			_ => null, 
		};
	}

	public void SetSkillTypeDesString(int index, string value)
	{
		switch (index)
		{
		case 1:
			SkillTypeDesString1 = value;
			break;
		case 2:
			SkillTypeDesString2 = value;
			break;
		case 3:
			SkillTypeDesString3 = value;
			break;
		case 4:
			SkillTypeDesString4 = value;
			break;
		case 5:
			SkillTypeDesString5 = value;
			break;
		case 6:
			SkillTypeDesString6 = value;
			break;
		case 7:
			SkillTypeDesString7 = value;
			break;
		case 8:
			SkillTypeDesString8 = value;
			break;
		case 9:
			SkillTypeDesString9 = value;
			break;
		case 10:
			SkillTypeDesString10 = value;
			break;
		case 11:
			SkillTypeDesString11 = value;
			break;
		case 12:
			SkillTypeDesString12 = value;
			break;
		case 13:
			SkillTypeDesString13 = value;
			break;
		case 14:
			SkillTypeDesString14 = value;
			break;
		case 15:
			SkillTypeDesString15 = value;
			break;
		case 16:
			SkillTypeDesString16 = value;
			break;
		case 17:
			SkillTypeDesString17 = value;
			break;
		case 18:
			SkillTypeDesString18 = value;
			break;
		case 19:
			SkillTypeDesString19 = value;
			break;
		case 20:
			SkillTypeDesString20 = value;
			break;
		case 21:
			SkillTypeDesString21 = value;
			break;
		case 22:
			SkillTypeDesString22 = value;
			break;
		case 23:
			SkillTypeDesString23 = value;
			break;
		case 24:
			SkillTypeDesString24 = value;
			break;
		case 25:
			SkillTypeDesString25 = value;
			break;
		case 26:
			SkillTypeDesString26 = value;
			break;
		case 27:
			SkillTypeDesString27 = value;
			break;
		case 28:
			SkillTypeDesString28 = value;
			break;
		case 29:
			SkillTypeDesString29 = value;
			break;
		case 30:
			SkillTypeDesString30 = value;
			break;
		case 31:
			SkillTypeDesString31 = value;
			break;
		case 32:
			SkillTypeDesString32 = value;
			break;
		case 33:
			SkillTypeDesString33 = value;
			break;
		case 34:
			SkillTypeDesString34 = value;
			break;
		}
	}

	public int GetSkillTypeDesCount()
	{
		return 34;
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
