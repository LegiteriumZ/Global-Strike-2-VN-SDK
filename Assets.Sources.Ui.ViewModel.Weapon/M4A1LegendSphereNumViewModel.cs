using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class M4A1LegendSphereNumViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBack;

	private RectTransform _oBackRectTransform;

	private Image _oBackImage;

	private GameObject _oGrid;

	private RectTransform _oGridRectTransform;

	private HorizontalLayoutGroup _oGridHorizontalLayoutGroup;

	private GameObject _oItem1;

	private GameObject _oItem2;

	private GameObject _oItem3;

	private GameObject _oItem4;

	private GameObject _oItem5;

	private GameObject _oItem6;

	private GameObject _oItem7;

	private GameObject _oItem8;

	private GameObject _oItem9;

	private GameObject _oItem10;

	private Image _oItemImage1;

	private Image _oItemImage2;

	private Image _oItemImage3;

	private Image _oItemImage4;

	private Image _oItemImage5;

	private Image _oItemImage6;

	private Image _oItemImage7;

	private Image _oItemImage8;

	private Image _oItemImage9;

	private Image _oItemImage10;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private GameObject _oIcon4;

	private GameObject _oIcon5;

	private GameObject _oIcon6;

	private GameObject _oIcon7;

	private GameObject _oIcon8;

	private GameObject _oIcon9;

	private GameObject _oIcon10;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private Image _oIconImage4;

	private Image _oIconImage5;

	private Image _oIconImage6;

	private Image _oIconImage7;

	private Image _oIconImage8;

	private Image _oIconImage9;

	private Image _oIconImage10;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "M4A1LegendSphereNum";

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

	public Vector3 BackPosition
	{
		get
		{
			if (_oBackRectTransform != null)
			{
				return _oBackRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BackPosition != value && _oBackRectTransform != null)
			{
				_oBackRectTransform.localPosition = value;
			}
		}
	}

	public bool BackEnabled
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.enabled;
			}
			return false;
		}
		set
		{
			if (BackEnabled != value && _oBackImage != null)
			{
				_oBackImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public Vector3 GridPosition
	{
		get
		{
			if (_oGridRectTransform != null)
			{
				return _oGridRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (GridPosition != value && _oGridRectTransform != null)
			{
				_oGridRectTransform.localPosition = value;
			}
		}
	}

	public float GridHspacing
	{
		get
		{
			if (_oGridHorizontalLayoutGroup != null)
			{
				return _oGridHorizontalLayoutGroup.spacing;
			}
			return 0f;
		}
		set
		{
			if (GridHspacing != value && _oGridHorizontalLayoutGroup != null)
			{
				_oGridHorizontalLayoutGroup.spacing = value;
			}
		}
	}

	public bool ItemShow1
	{
		get
		{
			if (_oItem1 != null)
			{
				return _oItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow1 != value && _oItem1 != null)
			{
				_oItem1.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow2
	{
		get
		{
			if (_oItem2 != null)
			{
				return _oItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow2 != value && _oItem2 != null)
			{
				_oItem2.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow3
	{
		get
		{
			if (_oItem3 != null)
			{
				return _oItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow3 != value && _oItem3 != null)
			{
				_oItem3.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow4
	{
		get
		{
			if (_oItem4 != null)
			{
				return _oItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow4 != value && _oItem4 != null)
			{
				_oItem4.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow5
	{
		get
		{
			if (_oItem5 != null)
			{
				return _oItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow5 != value && _oItem5 != null)
			{
				_oItem5.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow6
	{
		get
		{
			if (_oItem6 != null)
			{
				return _oItem6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow6 != value && _oItem6 != null)
			{
				_oItem6.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow7
	{
		get
		{
			if (_oItem7 != null)
			{
				return _oItem7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow7 != value && _oItem7 != null)
			{
				_oItem7.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow8
	{
		get
		{
			if (_oItem8 != null)
			{
				return _oItem8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow8 != value && _oItem8 != null)
			{
				_oItem8.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow9
	{
		get
		{
			if (_oItem9 != null)
			{
				return _oItem9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow9 != value && _oItem9 != null)
			{
				_oItem9.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow10
	{
		get
		{
			if (_oItem10 != null)
			{
				return _oItem10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow10 != value && _oItem10 != null)
			{
				_oItem10.SetObjectActive(value);
			}
		}
	}

	public Sprite ItemSprite1
	{
		get
		{
			if (_oItemImage1 != null)
			{
				return _oItemImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite1 != value && _oItemImage1 != null)
			{
				_oItemImage1.sprite = value;
			}
		}
	}

	public Sprite ItemSprite2
	{
		get
		{
			if (_oItemImage2 != null)
			{
				return _oItemImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite2 != value && _oItemImage2 != null)
			{
				_oItemImage2.sprite = value;
			}
		}
	}

	public Sprite ItemSprite3
	{
		get
		{
			if (_oItemImage3 != null)
			{
				return _oItemImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite3 != value && _oItemImage3 != null)
			{
				_oItemImage3.sprite = value;
			}
		}
	}

	public Sprite ItemSprite4
	{
		get
		{
			if (_oItemImage4 != null)
			{
				return _oItemImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite4 != value && _oItemImage4 != null)
			{
				_oItemImage4.sprite = value;
			}
		}
	}

	public Sprite ItemSprite5
	{
		get
		{
			if (_oItemImage5 != null)
			{
				return _oItemImage5.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite5 != value && _oItemImage5 != null)
			{
				_oItemImage5.sprite = value;
			}
		}
	}

	public Sprite ItemSprite6
	{
		get
		{
			if (_oItemImage6 != null)
			{
				return _oItemImage6.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite6 != value && _oItemImage6 != null)
			{
				_oItemImage6.sprite = value;
			}
		}
	}

	public Sprite ItemSprite7
	{
		get
		{
			if (_oItemImage7 != null)
			{
				return _oItemImage7.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite7 != value && _oItemImage7 != null)
			{
				_oItemImage7.sprite = value;
			}
		}
	}

	public Sprite ItemSprite8
	{
		get
		{
			if (_oItemImage8 != null)
			{
				return _oItemImage8.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite8 != value && _oItemImage8 != null)
			{
				_oItemImage8.sprite = value;
			}
		}
	}

	public Sprite ItemSprite9
	{
		get
		{
			if (_oItemImage9 != null)
			{
				return _oItemImage9.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite9 != value && _oItemImage9 != null)
			{
				_oItemImage9.sprite = value;
			}
		}
	}

	public Sprite ItemSprite10
	{
		get
		{
			if (_oItemImage10 != null)
			{
				return _oItemImage10.sprite;
			}
			return null;
		}
		set
		{
			if (ItemSprite10 != value && _oItemImage10 != null)
			{
				_oItemImage10.sprite = value;
			}
		}
	}

	public bool IconShow1
	{
		get
		{
			if (_oIcon1 != null)
			{
				return _oIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow1 != value && _oIcon1 != null)
			{
				_oIcon1.SetObjectActive(value);
			}
		}
	}

	public bool IconShow2
	{
		get
		{
			if (_oIcon2 != null)
			{
				return _oIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow2 != value && _oIcon2 != null)
			{
				_oIcon2.SetObjectActive(value);
			}
		}
	}

	public bool IconShow3
	{
		get
		{
			if (_oIcon3 != null)
			{
				return _oIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow3 != value && _oIcon3 != null)
			{
				_oIcon3.SetObjectActive(value);
			}
		}
	}

	public bool IconShow4
	{
		get
		{
			if (_oIcon4 != null)
			{
				return _oIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow4 != value && _oIcon4 != null)
			{
				_oIcon4.SetObjectActive(value);
			}
		}
	}

	public bool IconShow5
	{
		get
		{
			if (_oIcon5 != null)
			{
				return _oIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow5 != value && _oIcon5 != null)
			{
				_oIcon5.SetObjectActive(value);
			}
		}
	}

	public bool IconShow6
	{
		get
		{
			if (_oIcon6 != null)
			{
				return _oIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow6 != value && _oIcon6 != null)
			{
				_oIcon6.SetObjectActive(value);
			}
		}
	}

	public bool IconShow7
	{
		get
		{
			if (_oIcon7 != null)
			{
				return _oIcon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow7 != value && _oIcon7 != null)
			{
				_oIcon7.SetObjectActive(value);
			}
		}
	}

	public bool IconShow8
	{
		get
		{
			if (_oIcon8 != null)
			{
				return _oIcon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow8 != value && _oIcon8 != null)
			{
				_oIcon8.SetObjectActive(value);
			}
		}
	}

	public bool IconShow9
	{
		get
		{
			if (_oIcon9 != null)
			{
				return _oIcon9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow9 != value && _oIcon9 != null)
			{
				_oIcon9.SetObjectActive(value);
			}
		}
	}

	public bool IconShow10
	{
		get
		{
			if (_oIcon10 != null)
			{
				return _oIcon10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow10 != value && _oIcon10 != null)
			{
				_oIcon10.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite1 != value && _oIconImage1 != null)
			{
				_oIconImage1.sprite = value;
			}
		}
	}

	public Sprite IconSprite2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite2 != value && _oIconImage2 != null)
			{
				_oIconImage2.sprite = value;
			}
		}
	}

	public Sprite IconSprite3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite3 != value && _oIconImage3 != null)
			{
				_oIconImage3.sprite = value;
			}
		}
	}

	public Sprite IconSprite4
	{
		get
		{
			if (_oIconImage4 != null)
			{
				return _oIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite4 != value && _oIconImage4 != null)
			{
				_oIconImage4.sprite = value;
			}
		}
	}

	public Sprite IconSprite5
	{
		get
		{
			if (_oIconImage5 != null)
			{
				return _oIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite5 != value && _oIconImage5 != null)
			{
				_oIconImage5.sprite = value;
			}
		}
	}

	public Sprite IconSprite6
	{
		get
		{
			if (_oIconImage6 != null)
			{
				return _oIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite6 != value && _oIconImage6 != null)
			{
				_oIconImage6.sprite = value;
			}
		}
	}

	public Sprite IconSprite7
	{
		get
		{
			if (_oIconImage7 != null)
			{
				return _oIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite7 != value && _oIconImage7 != null)
			{
				_oIconImage7.sprite = value;
			}
		}
	}

	public Sprite IconSprite8
	{
		get
		{
			if (_oIconImage8 != null)
			{
				return _oIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite8 != value && _oIconImage8 != null)
			{
				_oIconImage8.sprite = value;
			}
		}
	}

	public Sprite IconSprite9
	{
		get
		{
			if (_oIconImage9 != null)
			{
				return _oIconImage9.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite9 != value && _oIconImage9 != null)
			{
				_oIconImage9.sprite = value;
			}
		}
	}

	public Sprite IconSprite10
	{
		get
		{
			if (_oIconImage10 != null)
			{
				return _oIconImage10.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite10 != value && _oIconImage10 != null)
			{
				_oIconImage10.sprite = value;
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
			case "Back":
				_oBack = transform.gameObject;
				_oBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				_oGridRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oGridHorizontalLayoutGroup = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Item1":
				_oItem1 = transform.gameObject;
				_oItemImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item2":
				_oItem2 = transform.gameObject;
				_oItemImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item3":
				_oItem3 = transform.gameObject;
				_oItemImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item4":
				_oItem4 = transform.gameObject;
				_oItemImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item5":
				_oItem5 = transform.gameObject;
				_oItemImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item6":
				_oItem6 = transform.gameObject;
				_oItemImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item7":
				_oItem7 = transform.gameObject;
				_oItemImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item8":
				_oItem8 = transform.gameObject;
				_oItemImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item9":
				_oItem9 = transform.gameObject;
				_oItemImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Item10":
				_oItem10 = transform.gameObject;
				_oItemImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				_oIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon4":
				_oIcon4 = transform.gameObject;
				_oIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon5":
				_oIcon5 = transform.gameObject;
				_oIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon6":
				_oIcon6 = transform.gameObject;
				_oIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon7":
				_oIcon7 = transform.gameObject;
				_oIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon8":
				_oIcon8 = transform.gameObject;
				_oIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon9":
				_oIcon9 = transform.gameObject;
				_oIconImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon10":
				_oIcon10 = transform.gameObject;
				_oIconImage10 = transform.gameObject.GetComponent<Image>();
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

	public void BackNtvsize()
	{
		if (_oBackImage != null)
		{
			_oBackImage.SetNativeSize();
		}
	}

	public bool GetItemShow(int index)
	{
		return index switch
		{
			1 => ItemShow1, 
			2 => ItemShow2, 
			3 => ItemShow3, 
			4 => ItemShow4, 
			5 => ItemShow5, 
			6 => ItemShow6, 
			7 => ItemShow7, 
			8 => ItemShow8, 
			9 => ItemShow9, 
			10 => ItemShow10, 
			_ => false, 
		};
	}

	public void SetItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemShow1 = value;
			break;
		case 2:
			ItemShow2 = value;
			break;
		case 3:
			ItemShow3 = value;
			break;
		case 4:
			ItemShow4 = value;
			break;
		case 5:
			ItemShow5 = value;
			break;
		case 6:
			ItemShow6 = value;
			break;
		case 7:
			ItemShow7 = value;
			break;
		case 8:
			ItemShow8 = value;
			break;
		case 9:
			ItemShow9 = value;
			break;
		case 10:
			ItemShow10 = value;
			break;
		}
	}

	public Sprite GetItemSprite(int index)
	{
		return index switch
		{
			1 => ItemSprite1, 
			2 => ItemSprite2, 
			3 => ItemSprite3, 
			4 => ItemSprite4, 
			5 => ItemSprite5, 
			6 => ItemSprite6, 
			7 => ItemSprite7, 
			8 => ItemSprite8, 
			9 => ItemSprite9, 
			10 => ItemSprite10, 
			_ => null, 
		};
	}

	public void SetItemSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ItemSprite1 = value;
			break;
		case 2:
			ItemSprite2 = value;
			break;
		case 3:
			ItemSprite3 = value;
			break;
		case 4:
			ItemSprite4 = value;
			break;
		case 5:
			ItemSprite5 = value;
			break;
		case 6:
			ItemSprite6 = value;
			break;
		case 7:
			ItemSprite7 = value;
			break;
		case 8:
			ItemSprite8 = value;
			break;
		case 9:
			ItemSprite9 = value;
			break;
		case 10:
			ItemSprite10 = value;
			break;
		}
	}

	public void ItemNtvsize1()
	{
		if (_oItemImage1 != null)
		{
			_oItemImage1.SetNativeSize();
		}
	}

	public void ItemNtvsize2()
	{
		if (_oItemImage2 != null)
		{
			_oItemImage2.SetNativeSize();
		}
	}

	public void ItemNtvsize3()
	{
		if (_oItemImage3 != null)
		{
			_oItemImage3.SetNativeSize();
		}
	}

	public void ItemNtvsize4()
	{
		if (_oItemImage4 != null)
		{
			_oItemImage4.SetNativeSize();
		}
	}

	public void ItemNtvsize5()
	{
		if (_oItemImage5 != null)
		{
			_oItemImage5.SetNativeSize();
		}
	}

	public void ItemNtvsize6()
	{
		if (_oItemImage6 != null)
		{
			_oItemImage6.SetNativeSize();
		}
	}

	public void ItemNtvsize7()
	{
		if (_oItemImage7 != null)
		{
			_oItemImage7.SetNativeSize();
		}
	}

	public void ItemNtvsize8()
	{
		if (_oItemImage8 != null)
		{
			_oItemImage8.SetNativeSize();
		}
	}

	public void ItemNtvsize9()
	{
		if (_oItemImage9 != null)
		{
			_oItemImage9.SetNativeSize();
		}
	}

	public void ItemNtvsize10()
	{
		if (_oItemImage10 != null)
		{
			_oItemImage10.SetNativeSize();
		}
	}

	public void CallItemNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			ItemNtvsize1();
			break;
		case 2:
			ItemNtvsize2();
			break;
		case 3:
			ItemNtvsize3();
			break;
		case 4:
			ItemNtvsize4();
			break;
		case 5:
			ItemNtvsize5();
			break;
		case 6:
			ItemNtvsize6();
			break;
		case 7:
			ItemNtvsize7();
			break;
		case 8:
			ItemNtvsize8();
			break;
		case 9:
			ItemNtvsize9();
			break;
		case 10:
			ItemNtvsize10();
			break;
		}
	}

	public bool GetIconShow(int index)
	{
		return index switch
		{
			1 => IconShow1, 
			2 => IconShow2, 
			3 => IconShow3, 
			4 => IconShow4, 
			5 => IconShow5, 
			6 => IconShow6, 
			7 => IconShow7, 
			8 => IconShow8, 
			9 => IconShow9, 
			10 => IconShow10, 
			_ => false, 
		};
	}

	public void SetIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			IconShow1 = value;
			break;
		case 2:
			IconShow2 = value;
			break;
		case 3:
			IconShow3 = value;
			break;
		case 4:
			IconShow4 = value;
			break;
		case 5:
			IconShow5 = value;
			break;
		case 6:
			IconShow6 = value;
			break;
		case 7:
			IconShow7 = value;
			break;
		case 8:
			IconShow8 = value;
			break;
		case 9:
			IconShow9 = value;
			break;
		case 10:
			IconShow10 = value;
			break;
		}
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			1 => IconSprite1, 
			2 => IconSprite2, 
			3 => IconSprite3, 
			4 => IconSprite4, 
			5 => IconSprite5, 
			6 => IconSprite6, 
			7 => IconSprite7, 
			8 => IconSprite8, 
			9 => IconSprite9, 
			10 => IconSprite10, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		case 3:
			IconSprite3 = value;
			break;
		case 4:
			IconSprite4 = value;
			break;
		case 5:
			IconSprite5 = value;
			break;
		case 6:
			IconSprite6 = value;
			break;
		case 7:
			IconSprite7 = value;
			break;
		case 8:
			IconSprite8 = value;
			break;
		case 9:
			IconSprite9 = value;
			break;
		case 10:
			IconSprite10 = value;
			break;
		}
	}

	public void IconNtvsize1()
	{
		if (_oIconImage1 != null)
		{
			_oIconImage1.SetNativeSize();
		}
	}

	public void IconNtvsize2()
	{
		if (_oIconImage2 != null)
		{
			_oIconImage2.SetNativeSize();
		}
	}

	public void IconNtvsize3()
	{
		if (_oIconImage3 != null)
		{
			_oIconImage3.SetNativeSize();
		}
	}

	public void IconNtvsize4()
	{
		if (_oIconImage4 != null)
		{
			_oIconImage4.SetNativeSize();
		}
	}

	public void IconNtvsize5()
	{
		if (_oIconImage5 != null)
		{
			_oIconImage5.SetNativeSize();
		}
	}

	public void IconNtvsize6()
	{
		if (_oIconImage6 != null)
		{
			_oIconImage6.SetNativeSize();
		}
	}

	public void IconNtvsize7()
	{
		if (_oIconImage7 != null)
		{
			_oIconImage7.SetNativeSize();
		}
	}

	public void IconNtvsize8()
	{
		if (_oIconImage8 != null)
		{
			_oIconImage8.SetNativeSize();
		}
	}

	public void IconNtvsize9()
	{
		if (_oIconImage9 != null)
		{
			_oIconImage9.SetNativeSize();
		}
	}

	public void IconNtvsize10()
	{
		if (_oIconImage10 != null)
		{
			_oIconImage10.SetNativeSize();
		}
	}

	public void CallIconNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			IconNtvsize1();
			break;
		case 2:
			IconNtvsize2();
			break;
		case 3:
			IconNtvsize3();
			break;
		case 4:
			IconNtvsize4();
			break;
		case 5:
			IconNtvsize5();
			break;
		case 6:
			IconNtvsize6();
			break;
		case 7:
			IconNtvsize7();
			break;
		case 8:
			IconNtvsize8();
			break;
		case 9:
			IconNtvsize9();
			break;
		case 10:
			IconNtvsize10();
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
