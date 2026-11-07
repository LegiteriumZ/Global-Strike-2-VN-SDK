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

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class CrazyBigheadChooseWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSelect1;

	private GameObject _oSelect2;

	private GameObject _oSelect3;

	private GameObject _oSelect4;

	private GameObject _oSelect5;

	private GameObject _oSelect6;

	private GameObject _oUnSelect1;

	private GameObject _oUnSelect2;

	private GameObject _oUnSelect3;

	private GameObject _oUnSelect4;

	private GameObject _oUnSelect5;

	private GameObject _oUnSelect6;

	private GameObject _oWeapon1;

	private GameObject _oWeapon2;

	private GameObject _oWeapon3;

	private GameObject _oWeapon4;

	private GameObject _oWeapon5;

	private GameObject _oWeapon6;

	private RectTransform _oWeaponRectTransform1;

	private RectTransform _oWeaponRectTransform2;

	private RectTransform _oWeaponRectTransform3;

	private RectTransform _oWeaponRectTransform4;

	private RectTransform _oWeaponRectTransform5;

	private RectTransform _oWeaponRectTransform6;

	private Image _oWeaponImage1;

	private Image _oWeaponImage2;

	private Image _oWeaponImage3;

	private Image _oWeaponImage4;

	private Image _oWeaponImage5;

	private Image _oWeaponImage6;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "CrazyBigheadChooseWeapon";

	private List<RectTransform> _holdPosTrans;

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

	public bool SelectShow1
	{
		get
		{
			if (_oSelect1 != null)
			{
				return _oSelect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow1 != value && _oSelect1 != null)
			{
				_oSelect1.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow2
	{
		get
		{
			if (_oSelect2 != null)
			{
				return _oSelect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow2 != value && _oSelect2 != null)
			{
				_oSelect2.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow3
	{
		get
		{
			if (_oSelect3 != null)
			{
				return _oSelect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow3 != value && _oSelect3 != null)
			{
				_oSelect3.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow4
	{
		get
		{
			if (_oSelect4 != null)
			{
				return _oSelect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow4 != value && _oSelect4 != null)
			{
				_oSelect4.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow5
	{
		get
		{
			if (_oSelect5 != null)
			{
				return _oSelect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow5 != value && _oSelect5 != null)
			{
				_oSelect5.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow6
	{
		get
		{
			if (_oSelect6 != null)
			{
				return _oSelect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow6 != value && _oSelect6 != null)
			{
				_oSelect6.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow1
	{
		get
		{
			if (_oUnSelect1 != null)
			{
				return _oUnSelect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow1 != value && _oUnSelect1 != null)
			{
				_oUnSelect1.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow2
	{
		get
		{
			if (_oUnSelect2 != null)
			{
				return _oUnSelect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow2 != value && _oUnSelect2 != null)
			{
				_oUnSelect2.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow3
	{
		get
		{
			if (_oUnSelect3 != null)
			{
				return _oUnSelect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow3 != value && _oUnSelect3 != null)
			{
				_oUnSelect3.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow4
	{
		get
		{
			if (_oUnSelect4 != null)
			{
				return _oUnSelect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow4 != value && _oUnSelect4 != null)
			{
				_oUnSelect4.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow5
	{
		get
		{
			if (_oUnSelect5 != null)
			{
				return _oUnSelect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow5 != value && _oUnSelect5 != null)
			{
				_oUnSelect5.SetObjectActive(value);
			}
		}
	}

	public bool UnSelectShow6
	{
		get
		{
			if (_oUnSelect6 != null)
			{
				return _oUnSelect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnSelectShow6 != value && _oUnSelect6 != null)
			{
				_oUnSelect6.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow1
	{
		get
		{
			if (_oWeapon1 != null)
			{
				return _oWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow1 != value && _oWeapon1 != null)
			{
				_oWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow2
	{
		get
		{
			if (_oWeapon2 != null)
			{
				return _oWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow2 != value && _oWeapon2 != null)
			{
				_oWeapon2.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow3
	{
		get
		{
			if (_oWeapon3 != null)
			{
				return _oWeapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow3 != value && _oWeapon3 != null)
			{
				_oWeapon3.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow4
	{
		get
		{
			if (_oWeapon4 != null)
			{
				return _oWeapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow4 != value && _oWeapon4 != null)
			{
				_oWeapon4.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow5
	{
		get
		{
			if (_oWeapon5 != null)
			{
				return _oWeapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow5 != value && _oWeapon5 != null)
			{
				_oWeapon5.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow6
	{
		get
		{
			if (_oWeapon6 != null)
			{
				return _oWeapon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow6 != value && _oWeapon6 != null)
			{
				_oWeapon6.SetObjectActive(value);
			}
		}
	}

	public Vector3 WeaponScale1
	{
		get
		{
			if (_oWeaponRectTransform1 != null)
			{
				return _oWeaponRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale1 != value && _oWeaponRectTransform1 != null)
			{
				_oWeaponRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale2
	{
		get
		{
			if (_oWeaponRectTransform2 != null)
			{
				return _oWeaponRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale2 != value && _oWeaponRectTransform2 != null)
			{
				_oWeaponRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale3
	{
		get
		{
			if (_oWeaponRectTransform3 != null)
			{
				return _oWeaponRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale3 != value && _oWeaponRectTransform3 != null)
			{
				_oWeaponRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale4
	{
		get
		{
			if (_oWeaponRectTransform4 != null)
			{
				return _oWeaponRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale4 != value && _oWeaponRectTransform4 != null)
			{
				_oWeaponRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale5
	{
		get
		{
			if (_oWeaponRectTransform5 != null)
			{
				return _oWeaponRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale5 != value && _oWeaponRectTransform5 != null)
			{
				_oWeaponRectTransform5.localScale = value;
			}
		}
	}

	public Vector3 WeaponScale6
	{
		get
		{
			if (_oWeaponRectTransform6 != null)
			{
				return _oWeaponRectTransform6.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponScale6 != value && _oWeaponRectTransform6 != null)
			{
				_oWeaponRectTransform6.localScale = value;
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

	public Sprite WeaponSprite6
	{
		get
		{
			if (_oWeaponImage6 != null)
			{
				return _oWeaponImage6.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite6 != value && _oWeaponImage6 != null)
			{
				_oWeaponImage6.sprite = value;
			}
		}
	}

	public Image WeaponImage1
	{
		get
		{
			if (_oWeaponImage1 != null)
			{
				return _oWeaponImage1;
			}
			return null;
		}
		set
		{
			if (WeaponImage1 != value && _oWeaponImage1 != null)
			{
				_oWeaponImage1 = value;
			}
		}
	}

	public Image WeaponImage2
	{
		get
		{
			if (_oWeaponImage2 != null)
			{
				return _oWeaponImage2;
			}
			return null;
		}
		set
		{
			if (WeaponImage2 != value && _oWeaponImage2 != null)
			{
				_oWeaponImage2 = value;
			}
		}
	}

	public Image WeaponImage3
	{
		get
		{
			if (_oWeaponImage3 != null)
			{
				return _oWeaponImage3;
			}
			return null;
		}
		set
		{
			if (WeaponImage3 != value && _oWeaponImage3 != null)
			{
				_oWeaponImage3 = value;
			}
		}
	}

	public Image WeaponImage4
	{
		get
		{
			if (_oWeaponImage4 != null)
			{
				return _oWeaponImage4;
			}
			return null;
		}
		set
		{
			if (WeaponImage4 != value && _oWeaponImage4 != null)
			{
				_oWeaponImage4 = value;
			}
		}
	}

	public Image WeaponImage5
	{
		get
		{
			if (_oWeaponImage5 != null)
			{
				return _oWeaponImage5;
			}
			return null;
		}
		set
		{
			if (WeaponImage5 != value && _oWeaponImage5 != null)
			{
				_oWeaponImage5 = value;
			}
		}
	}

	public Image WeaponImage6
	{
		get
		{
			if (_oWeaponImage6 != null)
			{
				return _oWeaponImage6;
			}
			return null;
		}
		set
		{
			if (WeaponImage6 != value && _oWeaponImage6 != null)
			{
				_oWeaponImage6 = value;
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
			case "Select1":
				_oSelect1 = transform.gameObject;
				break;
			case "Select2":
				_oSelect2 = transform.gameObject;
				break;
			case "Select3":
				_oSelect3 = transform.gameObject;
				break;
			case "Select4":
				_oSelect4 = transform.gameObject;
				break;
			case "Select5":
				_oSelect5 = transform.gameObject;
				break;
			case "Select6":
				_oSelect6 = transform.gameObject;
				break;
			case "UnSelect1":
				_oUnSelect1 = transform.gameObject;
				break;
			case "UnSelect2":
				_oUnSelect2 = transform.gameObject;
				break;
			case "UnSelect3":
				_oUnSelect3 = transform.gameObject;
				break;
			case "UnSelect4":
				_oUnSelect4 = transform.gameObject;
				break;
			case "UnSelect5":
				_oUnSelect5 = transform.gameObject;
				break;
			case "UnSelect6":
				_oUnSelect6 = transform.gameObject;
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
			case "Weapon6":
				_oWeapon6 = transform.gameObject;
				_oWeaponRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oWeaponImage6 = transform.gameObject.GetComponent<Image>();
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

	public bool GetSelectShow(int index)
	{
		return index switch
		{
			1 => SelectShow1, 
			2 => SelectShow2, 
			3 => SelectShow3, 
			4 => SelectShow4, 
			5 => SelectShow5, 
			6 => SelectShow6, 
			_ => false, 
		};
	}

	public void SetSelectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectShow1 = value;
			break;
		case 2:
			SelectShow2 = value;
			break;
		case 3:
			SelectShow3 = value;
			break;
		case 4:
			SelectShow4 = value;
			break;
		case 5:
			SelectShow5 = value;
			break;
		case 6:
			SelectShow6 = value;
			break;
		}
	}

	public int GetSelectCount()
	{
		return 6;
	}

	public bool GetUnSelectShow(int index)
	{
		return index switch
		{
			1 => UnSelectShow1, 
			2 => UnSelectShow2, 
			3 => UnSelectShow3, 
			4 => UnSelectShow4, 
			5 => UnSelectShow5, 
			6 => UnSelectShow6, 
			_ => false, 
		};
	}

	public void SetUnSelectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			UnSelectShow1 = value;
			break;
		case 2:
			UnSelectShow2 = value;
			break;
		case 3:
			UnSelectShow3 = value;
			break;
		case 4:
			UnSelectShow4 = value;
			break;
		case 5:
			UnSelectShow5 = value;
			break;
		case 6:
			UnSelectShow6 = value;
			break;
		}
	}

	public int GetUnSelectCount()
	{
		return 6;
	}

	public bool GetWeaponShow(int index)
	{
		return index switch
		{
			1 => WeaponShow1, 
			2 => WeaponShow2, 
			3 => WeaponShow3, 
			4 => WeaponShow4, 
			5 => WeaponShow5, 
			6 => WeaponShow6, 
			_ => false, 
		};
	}

	public void SetWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponShow1 = value;
			break;
		case 2:
			WeaponShow2 = value;
			break;
		case 3:
			WeaponShow3 = value;
			break;
		case 4:
			WeaponShow4 = value;
			break;
		case 5:
			WeaponShow5 = value;
			break;
		case 6:
			WeaponShow6 = value;
			break;
		}
	}

	public int GetWeaponCount()
	{
		return 6;
	}

	public Vector3 GetWeaponScale(int index)
	{
		return index switch
		{
			1 => WeaponScale1, 
			2 => WeaponScale2, 
			3 => WeaponScale3, 
			4 => WeaponScale4, 
			5 => WeaponScale5, 
			6 => WeaponScale6, 
			_ => Vector3.zero, 
		};
	}

	public void SetWeaponScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			WeaponScale1 = value;
			break;
		case 2:
			WeaponScale2 = value;
			break;
		case 3:
			WeaponScale3 = value;
			break;
		case 4:
			WeaponScale4 = value;
			break;
		case 5:
			WeaponScale5 = value;
			break;
		case 6:
			WeaponScale6 = value;
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
			6 => WeaponSprite6, 
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
		case 6:
			WeaponSprite6 = value;
			break;
		}
	}

	public Image GetWeaponImage(int index)
	{
		return index switch
		{
			1 => WeaponImage1, 
			2 => WeaponImage2, 
			3 => WeaponImage3, 
			4 => WeaponImage4, 
			5 => WeaponImage5, 
			6 => WeaponImage6, 
			_ => null, 
		};
	}

	public void SetWeaponImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			WeaponImage1 = value;
			break;
		case 2:
			WeaponImage2 = value;
			break;
		case 3:
			WeaponImage3 = value;
			break;
		case 4:
			WeaponImage4 = value;
			break;
		case 5:
			WeaponImage5 = value;
			break;
		case 6:
			WeaponImage6 = value;
			break;
		}
	}

	public void WeaponNtvsize1()
	{
		if (_oWeaponImage1 != null)
		{
			_oWeaponImage1.SetNativeSize();
		}
	}

	public void WeaponNtvsize2()
	{
		if (_oWeaponImage2 != null)
		{
			_oWeaponImage2.SetNativeSize();
		}
	}

	public void WeaponNtvsize3()
	{
		if (_oWeaponImage3 != null)
		{
			_oWeaponImage3.SetNativeSize();
		}
	}

	public void WeaponNtvsize4()
	{
		if (_oWeaponImage4 != null)
		{
			_oWeaponImage4.SetNativeSize();
		}
	}

	public void WeaponNtvsize5()
	{
		if (_oWeaponImage5 != null)
		{
			_oWeaponImage5.SetNativeSize();
		}
	}

	public void WeaponNtvsize6()
	{
		if (_oWeaponImage6 != null)
		{
			_oWeaponImage6.SetNativeSize();
		}
	}

	public void CallWeaponNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			WeaponNtvsize1();
			break;
		case 2:
			WeaponNtvsize2();
			break;
		case 3:
			WeaponNtvsize3();
			break;
		case 4:
			WeaponNtvsize4();
			break;
		case 5:
			WeaponNtvsize5();
			break;
		case 6:
			WeaponNtvsize6();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		return _holdPosTrans;
	}
}
