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
public class RpgTowerLevelUpPropertyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTypeTitle;

	private Image _oTypeTitleImage;

	private GameObject _oPage;

	private Text _oPageText;

	private GameObject _oComfirm;

	private EventTrigger _oComfirmEventTrigger;

	private GameObject _oCancel;

	private EventTrigger _oCancelEventTrigger;

	private Button _oCancelButton;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private GameObject _oNextSingle;

	private EventTrigger _oNextSingleEventTrigger;

	private Button _oNextSingleButton;

	private GameObject _oBeforeAll;

	private EventTrigger _oBeforeAllEventTrigger;

	private Button _oBeforeAllButton;

	private GameObject _oBeforeSingle;

	private EventTrigger _oBeforeSingleEventTrigger;

	private Button _oBeforeSingleButton;

	private GameObject _oNextAll;

	private EventTrigger _oNextAllEventTrigger;

	private Button _oNextAllButton;

	private GameObject _oCost;

	private Text _oCostText;

	private GameObject _oCostCoin;

	private GameObject _oCommonType;

	private GameObject _oCommonSignType;

	private Image _oCommonSignTypeImage;

	private GameObject _oCommonLevelUpDes1;

	private GameObject _oCommonLevelUpDes2;

	private GameObject _oCommonLevelUpDes3;

	private Text _oCommonLevelUpDesText1;

	private Text _oCommonLevelUpDesText2;

	private Text _oCommonLevelUpDesText3;

	private GameObject _oCommonLevelUpBaiFen;

	private GameObject _oNextLevelSignType;

	private Image _oNextLevelSignTypeImage;

	private GameObject _oSpecailType;

	private GameObject _oSpecailLevelup1;

	private GameObject _oSpecailLevelup2;

	private GameObject _oSpecailLevelup3;

	private GameObject _oDiffSpecailLevelUpDes1;

	private GameObject _oDiffSpecailLevelUpDes2;

	private GameObject _oDiffSpecailLevelUpDes3;

	private Text _oDiffSpecailLevelUpDesText1;

	private Text _oDiffSpecailLevelUpDesText2;

	private Text _oDiffSpecailLevelUpDesText3;

	private GameObject _oSpecailLevelUpDes2;

	private GameObject _oSpecailLevelUpDes3;

	private Text _oSpecailLevelUpDesText2;

	private Text _oSpecailLevelUpDesText3;

	private GameObject _oNextLevelSpecailLevelup1;

	private GameObject _oNextLevelSpecailLevelup2;

	private GameObject _oNextLevelSpecailLevelup3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerLevelUpProperty";

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

	public bool ComfirmShow
	{
		get
		{
			if (_oComfirm != null)
			{
				return _oComfirm.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ComfirmShow != value && _oComfirm != null)
			{
				_oComfirm.SetObjectActive(value);
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

	public bool CostShow
	{
		get
		{
			if (_oCost != null)
			{
				return _oCost.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CostShow != value && _oCost != null)
			{
				_oCost.SetObjectActive(value);
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

	public bool CostCoinShow
	{
		get
		{
			if (_oCostCoin != null)
			{
				return _oCostCoin.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CostCoinShow != value && _oCostCoin != null)
			{
				_oCostCoin.SetObjectActive(value);
			}
		}
	}

	public bool CommonTypeShow
	{
		get
		{
			if (_oCommonType != null)
			{
				return _oCommonType.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CommonTypeShow != value && _oCommonType != null)
			{
				_oCommonType.SetObjectActive(value);
			}
		}
	}

	public Sprite CommonSignTypeSprite
	{
		get
		{
			if (_oCommonSignTypeImage != null)
			{
				return _oCommonSignTypeImage.sprite;
			}
			return null;
		}
		set
		{
			if (CommonSignTypeSprite != value && _oCommonSignTypeImage != null)
			{
				_oCommonSignTypeImage.sprite = value;
			}
		}
	}

	public string CommonLevelUpDesString1
	{
		get
		{
			if (_oCommonLevelUpDesText1 != null)
			{
				return _oCommonLevelUpDesText1.text;
			}
			return null;
		}
		set
		{
			if (CommonLevelUpDesString1 != value && _oCommonLevelUpDesText1 != null)
			{
				_oCommonLevelUpDesText1.text = value;
			}
		}
	}

	public string CommonLevelUpDesString2
	{
		get
		{
			if (_oCommonLevelUpDesText2 != null)
			{
				return _oCommonLevelUpDesText2.text;
			}
			return null;
		}
		set
		{
			if (CommonLevelUpDesString2 != value && _oCommonLevelUpDesText2 != null)
			{
				_oCommonLevelUpDesText2.text = value;
			}
		}
	}

	public string CommonLevelUpDesString3
	{
		get
		{
			if (_oCommonLevelUpDesText3 != null)
			{
				return _oCommonLevelUpDesText3.text;
			}
			return null;
		}
		set
		{
			if (CommonLevelUpDesString3 != value && _oCommonLevelUpDesText3 != null)
			{
				_oCommonLevelUpDesText3.text = value;
			}
		}
	}

	public bool CommonLevelUpBaiFenShow
	{
		get
		{
			if (_oCommonLevelUpBaiFen != null)
			{
				return _oCommonLevelUpBaiFen.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CommonLevelUpBaiFenShow != value && _oCommonLevelUpBaiFen != null)
			{
				_oCommonLevelUpBaiFen.SetObjectActive(value);
			}
		}
	}

	public Sprite NextLevelSignTypeSprite
	{
		get
		{
			if (_oNextLevelSignTypeImage != null)
			{
				return _oNextLevelSignTypeImage.sprite;
			}
			return null;
		}
		set
		{
			if (NextLevelSignTypeSprite != value && _oNextLevelSignTypeImage != null)
			{
				_oNextLevelSignTypeImage.sprite = value;
			}
		}
	}

	public bool SpecailTypeShow
	{
		get
		{
			if (_oSpecailType != null)
			{
				return _oSpecailType.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecailTypeShow != value && _oSpecailType != null)
			{
				_oSpecailType.SetObjectActive(value);
			}
		}
	}

	public bool SpecailLevelupShow1
	{
		get
		{
			if (_oSpecailLevelup1 != null)
			{
				return _oSpecailLevelup1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecailLevelupShow1 != value && _oSpecailLevelup1 != null)
			{
				_oSpecailLevelup1.SetObjectActive(value);
			}
		}
	}

	public bool SpecailLevelupShow2
	{
		get
		{
			if (_oSpecailLevelup2 != null)
			{
				return _oSpecailLevelup2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecailLevelupShow2 != value && _oSpecailLevelup2 != null)
			{
				_oSpecailLevelup2.SetObjectActive(value);
			}
		}
	}

	public bool SpecailLevelupShow3
	{
		get
		{
			if (_oSpecailLevelup3 != null)
			{
				return _oSpecailLevelup3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecailLevelupShow3 != value && _oSpecailLevelup3 != null)
			{
				_oSpecailLevelup3.SetObjectActive(value);
			}
		}
	}

	public string DiffSpecailLevelUpDesString1
	{
		get
		{
			if (_oDiffSpecailLevelUpDesText1 != null)
			{
				return _oDiffSpecailLevelUpDesText1.text;
			}
			return null;
		}
		set
		{
			if (DiffSpecailLevelUpDesString1 != value && _oDiffSpecailLevelUpDesText1 != null)
			{
				_oDiffSpecailLevelUpDesText1.text = value;
			}
		}
	}

	public string DiffSpecailLevelUpDesString2
	{
		get
		{
			if (_oDiffSpecailLevelUpDesText2 != null)
			{
				return _oDiffSpecailLevelUpDesText2.text;
			}
			return null;
		}
		set
		{
			if (DiffSpecailLevelUpDesString2 != value && _oDiffSpecailLevelUpDesText2 != null)
			{
				_oDiffSpecailLevelUpDesText2.text = value;
			}
		}
	}

	public string DiffSpecailLevelUpDesString3
	{
		get
		{
			if (_oDiffSpecailLevelUpDesText3 != null)
			{
				return _oDiffSpecailLevelUpDesText3.text;
			}
			return null;
		}
		set
		{
			if (DiffSpecailLevelUpDesString3 != value && _oDiffSpecailLevelUpDesText3 != null)
			{
				_oDiffSpecailLevelUpDesText3.text = value;
			}
		}
	}

	public string SpecailLevelUpDesString2
	{
		get
		{
			if (_oSpecailLevelUpDesText2 != null)
			{
				return _oSpecailLevelUpDesText2.text;
			}
			return null;
		}
		set
		{
			if (SpecailLevelUpDesString2 != value && _oSpecailLevelUpDesText2 != null)
			{
				_oSpecailLevelUpDesText2.text = value;
			}
		}
	}

	public string SpecailLevelUpDesString3
	{
		get
		{
			if (_oSpecailLevelUpDesText3 != null)
			{
				return _oSpecailLevelUpDesText3.text;
			}
			return null;
		}
		set
		{
			if (SpecailLevelUpDesString3 != value && _oSpecailLevelUpDesText3 != null)
			{
				_oSpecailLevelUpDesText3.text = value;
			}
		}
	}

	public bool NextLevelSpecailLevelupShow1
	{
		get
		{
			if (_oNextLevelSpecailLevelup1 != null)
			{
				return _oNextLevelSpecailLevelup1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NextLevelSpecailLevelupShow1 != value && _oNextLevelSpecailLevelup1 != null)
			{
				_oNextLevelSpecailLevelup1.SetObjectActive(value);
			}
		}
	}

	public bool NextLevelSpecailLevelupShow2
	{
		get
		{
			if (_oNextLevelSpecailLevelup2 != null)
			{
				return _oNextLevelSpecailLevelup2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NextLevelSpecailLevelupShow2 != value && _oNextLevelSpecailLevelup2 != null)
			{
				_oNextLevelSpecailLevelup2.SetObjectActive(value);
			}
		}
	}

	public bool NextLevelSpecailLevelupShow3
	{
		get
		{
			if (_oNextLevelSpecailLevelup3 != null)
			{
				return _oNextLevelSpecailLevelup3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NextLevelSpecailLevelupShow3 != value && _oNextLevelSpecailLevelup3 != null)
			{
				_oNextLevelSpecailLevelup3.SetObjectActive(value);
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
			case "TypeTitle":
				_oTypeTitle = transform.gameObject;
				_oTypeTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Page":
				_oPage = transform.gameObject;
				_oPageText = transform.gameObject.GetComponent<Text>();
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
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
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
			case "BeforeSingle":
				_oBeforeSingle = transform.gameObject;
				_oBeforeSingleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oBeforeSingleButton = transform.gameObject.GetComponent<Button>();
				break;
			case "NextAll":
				_oNextAll = transform.gameObject;
				_oNextAllEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oNextAllButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Cost":
				_oCost = transform.gameObject;
				_oCostText = transform.gameObject.GetComponent<Text>();
				break;
			case "CostCoin":
				_oCostCoin = transform.gameObject;
				break;
			case "CommonType":
				_oCommonType = transform.gameObject;
				break;
			case "CommonSignType":
				_oCommonSignType = transform.gameObject;
				_oCommonSignTypeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CommonLevelUpDes1":
				_oCommonLevelUpDes1 = transform.gameObject;
				_oCommonLevelUpDesText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CommonLevelUpDes2":
				_oCommonLevelUpDes2 = transform.gameObject;
				_oCommonLevelUpDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CommonLevelUpDes3":
				_oCommonLevelUpDes3 = transform.gameObject;
				_oCommonLevelUpDesText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CommonLevelUpBaiFen":
				_oCommonLevelUpBaiFen = transform.gameObject;
				break;
			case "NextLevelSignType":
				_oNextLevelSignType = transform.gameObject;
				_oNextLevelSignTypeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SpecailType":
				_oSpecailType = transform.gameObject;
				break;
			case "SpecailLevelup1":
				_oSpecailLevelup1 = transform.gameObject;
				break;
			case "SpecailLevelup2":
				_oSpecailLevelup2 = transform.gameObject;
				break;
			case "SpecailLevelup3":
				_oSpecailLevelup3 = transform.gameObject;
				break;
			case "DiffSpecailLevelUpDes1":
				_oDiffSpecailLevelUpDes1 = transform.gameObject;
				_oDiffSpecailLevelUpDesText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "DiffSpecailLevelUpDes2":
				_oDiffSpecailLevelUpDes2 = transform.gameObject;
				_oDiffSpecailLevelUpDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "DiffSpecailLevelUpDes3":
				_oDiffSpecailLevelUpDes3 = transform.gameObject;
				_oDiffSpecailLevelUpDesText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "SpecailLevelUpDes2":
				_oSpecailLevelUpDes2 = transform.gameObject;
				_oSpecailLevelUpDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SpecailLevelUpDes3":
				_oSpecailLevelUpDes3 = transform.gameObject;
				_oSpecailLevelUpDesText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "NextLevelSpecailLevelup1":
				_oNextLevelSpecailLevelup1 = transform.gameObject;
				break;
			case "NextLevelSpecailLevelup2":
				_oNextLevelSpecailLevelup2 = transform.gameObject;
				break;
			case "NextLevelSpecailLevelup3":
				_oNextLevelSpecailLevelup3 = transform.gameObject;
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

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
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

	private void CreateBeforeSingleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BeforeSingleTriggers, eventId, callback);
	}

	private void RemoveBeforeSingleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BeforeSingleTriggers, eventId);
	}

	private void CreateNextAllTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(NextAllTriggers, eventId, callback);
	}

	private void RemoveNextAllTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(NextAllTriggers, eventId);
	}

	public void CommonSignTypeNtvsize()
	{
		if (_oCommonSignTypeImage != null)
		{
			_oCommonSignTypeImage.SetNativeSize();
		}
	}

	public string GetCommonLevelUpDesString(int index)
	{
		return index switch
		{
			1 => CommonLevelUpDesString1, 
			2 => CommonLevelUpDesString2, 
			3 => CommonLevelUpDesString3, 
			_ => null, 
		};
	}

	public void SetCommonLevelUpDesString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CommonLevelUpDesString1 = value;
			break;
		case 2:
			CommonLevelUpDesString2 = value;
			break;
		case 3:
			CommonLevelUpDesString3 = value;
			break;
		}
	}

	public int GetCommonLevelUpDesCount()
	{
		return 3;
	}

	public void NextLevelSignTypeNtvsize()
	{
		if (_oNextLevelSignTypeImage != null)
		{
			_oNextLevelSignTypeImage.SetNativeSize();
		}
	}

	public bool GetSpecailLevelupShow(int index)
	{
		return index switch
		{
			1 => SpecailLevelupShow1, 
			2 => SpecailLevelupShow2, 
			3 => SpecailLevelupShow3, 
			_ => false, 
		};
	}

	public void SetSpecailLevelupShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SpecailLevelupShow1 = value;
			break;
		case 2:
			SpecailLevelupShow2 = value;
			break;
		case 3:
			SpecailLevelupShow3 = value;
			break;
		}
	}

	public int GetSpecailLevelupCount()
	{
		return 3;
	}

	public string GetDiffSpecailLevelUpDesString(int index)
	{
		return index switch
		{
			1 => DiffSpecailLevelUpDesString1, 
			2 => DiffSpecailLevelUpDesString2, 
			3 => DiffSpecailLevelUpDesString3, 
			_ => null, 
		};
	}

	public void SetDiffSpecailLevelUpDesString(int index, string value)
	{
		switch (index)
		{
		case 1:
			DiffSpecailLevelUpDesString1 = value;
			break;
		case 2:
			DiffSpecailLevelUpDesString2 = value;
			break;
		case 3:
			DiffSpecailLevelUpDesString3 = value;
			break;
		}
	}

	public int GetDiffSpecailLevelUpDesCount()
	{
		return 3;
	}

	public string GetSpecailLevelUpDesString(int index)
	{
		return index switch
		{
			2 => SpecailLevelUpDesString2, 
			3 => SpecailLevelUpDesString3, 
			_ => null, 
		};
	}

	public void SetSpecailLevelUpDesString(int index, string value)
	{
		switch (index)
		{
		case 2:
			SpecailLevelUpDesString2 = value;
			break;
		case 3:
			SpecailLevelUpDesString3 = value;
			break;
		}
	}

	public int GetSpecailLevelUpDesCount()
	{
		return 3;
	}

	public bool GetNextLevelSpecailLevelupShow(int index)
	{
		return index switch
		{
			1 => NextLevelSpecailLevelupShow1, 
			2 => NextLevelSpecailLevelupShow2, 
			3 => NextLevelSpecailLevelupShow3, 
			_ => false, 
		};
	}

	public void SetNextLevelSpecailLevelupShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NextLevelSpecailLevelupShow1 = value;
			break;
		case 2:
			NextLevelSpecailLevelupShow2 = value;
			break;
		case 3:
			NextLevelSpecailLevelupShow3 = value;
			break;
		}
	}

	public int GetNextLevelSpecailLevelupCount()
	{
		return 3;
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
