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
public class InfiniteHandWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _obg1;

	private GameObject _obg2;

	private GameObject _obg3;

	private Image _obgImage1;

	private Image _obgImage2;

	private Image _obgImage3;

	private GameObject _ovImg;

	private Image _ovImgImage;

	private GameObject _oSkillProgress1;

	private GameObject _oSkillProgress2;

	private GameObject _oSkillProgress3;

	private Image _oSkillProgressImage1;

	private Image _oSkillProgressImage2;

	private Image _oSkillProgressImage3;

	private GameObject _oSelected1;

	private GameObject _oSelected2;

	private GameObject _oSelected3;

	private Image _oSelectedImage1;

	private Image _oSelectedImage2;

	private Image _oSelectedImage3;

	private GameObject _oWeakUse1;

	private GameObject _oWeakUse2;

	private GameObject _oWeakUse3;

	private Image _oWeakUseImage1;

	private Image _oWeakUseImage2;

	private Image _oWeakUseImage3;

	private GameObject _oWeakReady1;

	private GameObject _oWeakReady2;

	private GameObject _oWeakReady3;

	private Image _oWeakReadyImage1;

	private Image _oWeakReadyImage2;

	private Image _oWeakReadyImage3;

	private GameObject _oTips1;

	private GameObject _oTips2;

	private GameObject _oTips3;

	private Image _oTipsImage1;

	private Image _oTipsImage2;

	private Image _oTipsImage3;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "InfiniteHandWeapon";

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

	public Vector3 ShowPosition
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShowPosition != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localPosition = value;
			}
		}
	}

	public Image bgImage1
	{
		get
		{
			if (_obgImage1 != null)
			{
				return _obgImage1;
			}
			return null;
		}
		set
		{
			if (bgImage1 != value && _obgImage1 != null)
			{
				_obgImage1 = value;
			}
		}
	}

	public Image bgImage2
	{
		get
		{
			if (_obgImage2 != null)
			{
				return _obgImage2;
			}
			return null;
		}
		set
		{
			if (bgImage2 != value && _obgImage2 != null)
			{
				_obgImage2 = value;
			}
		}
	}

	public Image bgImage3
	{
		get
		{
			if (_obgImage3 != null)
			{
				return _obgImage3;
			}
			return null;
		}
		set
		{
			if (bgImage3 != value && _obgImage3 != null)
			{
				_obgImage3 = value;
			}
		}
	}

	public Image vImgImage
	{
		get
		{
			if (_ovImgImage != null)
			{
				return _ovImgImage;
			}
			return null;
		}
		set
		{
			if (vImgImage != value && _ovImgImage != null)
			{
				_ovImgImage = value;
			}
		}
	}

	public bool SkillProgressShow1
	{
		get
		{
			if (_oSkillProgress1 != null)
			{
				return _oSkillProgress1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillProgressShow1 != value && _oSkillProgress1 != null)
			{
				_oSkillProgress1.SetObjectActive(value);
			}
		}
	}

	public bool SkillProgressShow2
	{
		get
		{
			if (_oSkillProgress2 != null)
			{
				return _oSkillProgress2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillProgressShow2 != value && _oSkillProgress2 != null)
			{
				_oSkillProgress2.SetObjectActive(value);
			}
		}
	}

	public bool SkillProgressShow3
	{
		get
		{
			if (_oSkillProgress3 != null)
			{
				return _oSkillProgress3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillProgressShow3 != value && _oSkillProgress3 != null)
			{
				_oSkillProgress3.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillProgressSprite1
	{
		get
		{
			if (_oSkillProgressImage1 != null)
			{
				return _oSkillProgressImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillProgressSprite1 != value && _oSkillProgressImage1 != null)
			{
				_oSkillProgressImage1.sprite = value;
			}
		}
	}

	public Sprite SkillProgressSprite2
	{
		get
		{
			if (_oSkillProgressImage2 != null)
			{
				return _oSkillProgressImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillProgressSprite2 != value && _oSkillProgressImage2 != null)
			{
				_oSkillProgressImage2.sprite = value;
			}
		}
	}

	public Sprite SkillProgressSprite3
	{
		get
		{
			if (_oSkillProgressImage3 != null)
			{
				return _oSkillProgressImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SkillProgressSprite3 != value && _oSkillProgressImage3 != null)
			{
				_oSkillProgressImage3.sprite = value;
			}
		}
	}

	public float SkillProgressFillamount1
	{
		get
		{
			if (_oSkillProgressImage1 != null)
			{
				return _oSkillProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillProgressFillamount1 != value && _oSkillProgressImage1 != null)
			{
				_oSkillProgressImage1.fillAmount = value;
			}
		}
	}

	public float SkillProgressFillamount2
	{
		get
		{
			if (_oSkillProgressImage2 != null)
			{
				return _oSkillProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillProgressFillamount2 != value && _oSkillProgressImage2 != null)
			{
				_oSkillProgressImage2.fillAmount = value;
			}
		}
	}

	public float SkillProgressFillamount3
	{
		get
		{
			if (_oSkillProgressImage3 != null)
			{
				return _oSkillProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillProgressFillamount3 != value && _oSkillProgressImage3 != null)
			{
				_oSkillProgressImage3.fillAmount = value;
			}
		}
	}

	public Image SkillProgressImage1
	{
		get
		{
			if (_oSkillProgressImage1 != null)
			{
				return _oSkillProgressImage1;
			}
			return null;
		}
		set
		{
			if (SkillProgressImage1 != value && _oSkillProgressImage1 != null)
			{
				_oSkillProgressImage1 = value;
			}
		}
	}

	public Image SkillProgressImage2
	{
		get
		{
			if (_oSkillProgressImage2 != null)
			{
				return _oSkillProgressImage2;
			}
			return null;
		}
		set
		{
			if (SkillProgressImage2 != value && _oSkillProgressImage2 != null)
			{
				_oSkillProgressImage2 = value;
			}
		}
	}

	public Image SkillProgressImage3
	{
		get
		{
			if (_oSkillProgressImage3 != null)
			{
				return _oSkillProgressImage3;
			}
			return null;
		}
		set
		{
			if (SkillProgressImage3 != value && _oSkillProgressImage3 != null)
			{
				_oSkillProgressImage3 = value;
			}
		}
	}

	public bool SelectedShow1
	{
		get
		{
			if (_oSelected1 != null)
			{
				return _oSelected1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow1 != value && _oSelected1 != null)
			{
				_oSelected1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow2
	{
		get
		{
			if (_oSelected2 != null)
			{
				return _oSelected2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow2 != value && _oSelected2 != null)
			{
				_oSelected2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow3
	{
		get
		{
			if (_oSelected3 != null)
			{
				return _oSelected3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow3 != value && _oSelected3 != null)
			{
				_oSelected3.SetObjectActive(value);
			}
		}
	}

	public Image SelectedImage1
	{
		get
		{
			if (_oSelectedImage1 != null)
			{
				return _oSelectedImage1;
			}
			return null;
		}
		set
		{
			if (SelectedImage1 != value && _oSelectedImage1 != null)
			{
				_oSelectedImage1 = value;
			}
		}
	}

	public Image SelectedImage2
	{
		get
		{
			if (_oSelectedImage2 != null)
			{
				return _oSelectedImage2;
			}
			return null;
		}
		set
		{
			if (SelectedImage2 != value && _oSelectedImage2 != null)
			{
				_oSelectedImage2 = value;
			}
		}
	}

	public Image SelectedImage3
	{
		get
		{
			if (_oSelectedImage3 != null)
			{
				return _oSelectedImage3;
			}
			return null;
		}
		set
		{
			if (SelectedImage3 != value && _oSelectedImage3 != null)
			{
				_oSelectedImage3 = value;
			}
		}
	}

	public bool WeakUseShow1
	{
		get
		{
			if (_oWeakUse1 != null)
			{
				return _oWeakUse1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakUseShow1 != value && _oWeakUse1 != null)
			{
				_oWeakUse1.SetObjectActive(value);
			}
		}
	}

	public bool WeakUseShow2
	{
		get
		{
			if (_oWeakUse2 != null)
			{
				return _oWeakUse2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakUseShow2 != value && _oWeakUse2 != null)
			{
				_oWeakUse2.SetObjectActive(value);
			}
		}
	}

	public bool WeakUseShow3
	{
		get
		{
			if (_oWeakUse3 != null)
			{
				return _oWeakUse3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakUseShow3 != value && _oWeakUse3 != null)
			{
				_oWeakUse3.SetObjectActive(value);
			}
		}
	}

	public Sprite WeakUseSprite1
	{
		get
		{
			if (_oWeakUseImage1 != null)
			{
				return _oWeakUseImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeakUseSprite1 != value && _oWeakUseImage1 != null)
			{
				_oWeakUseImage1.sprite = value;
			}
		}
	}

	public Sprite WeakUseSprite2
	{
		get
		{
			if (_oWeakUseImage2 != null)
			{
				return _oWeakUseImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeakUseSprite2 != value && _oWeakUseImage2 != null)
			{
				_oWeakUseImage2.sprite = value;
			}
		}
	}

	public Sprite WeakUseSprite3
	{
		get
		{
			if (_oWeakUseImage3 != null)
			{
				return _oWeakUseImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeakUseSprite3 != value && _oWeakUseImage3 != null)
			{
				_oWeakUseImage3.sprite = value;
			}
		}
	}

	public Image WeakUseImage1
	{
		get
		{
			if (_oWeakUseImage1 != null)
			{
				return _oWeakUseImage1;
			}
			return null;
		}
		set
		{
			if (WeakUseImage1 != value && _oWeakUseImage1 != null)
			{
				_oWeakUseImage1 = value;
			}
		}
	}

	public Image WeakUseImage2
	{
		get
		{
			if (_oWeakUseImage2 != null)
			{
				return _oWeakUseImage2;
			}
			return null;
		}
		set
		{
			if (WeakUseImage2 != value && _oWeakUseImage2 != null)
			{
				_oWeakUseImage2 = value;
			}
		}
	}

	public Image WeakUseImage3
	{
		get
		{
			if (_oWeakUseImage3 != null)
			{
				return _oWeakUseImage3;
			}
			return null;
		}
		set
		{
			if (WeakUseImage3 != value && _oWeakUseImage3 != null)
			{
				_oWeakUseImage3 = value;
			}
		}
	}

	public bool WeakReadyShow1
	{
		get
		{
			if (_oWeakReady1 != null)
			{
				return _oWeakReady1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakReadyShow1 != value && _oWeakReady1 != null)
			{
				_oWeakReady1.SetObjectActive(value);
			}
		}
	}

	public bool WeakReadyShow2
	{
		get
		{
			if (_oWeakReady2 != null)
			{
				return _oWeakReady2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakReadyShow2 != value && _oWeakReady2 != null)
			{
				_oWeakReady2.SetObjectActive(value);
			}
		}
	}

	public bool WeakReadyShow3
	{
		get
		{
			if (_oWeakReady3 != null)
			{
				return _oWeakReady3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeakReadyShow3 != value && _oWeakReady3 != null)
			{
				_oWeakReady3.SetObjectActive(value);
			}
		}
	}

	public Sprite WeakReadySprite1
	{
		get
		{
			if (_oWeakReadyImage1 != null)
			{
				return _oWeakReadyImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WeakReadySprite1 != value && _oWeakReadyImage1 != null)
			{
				_oWeakReadyImage1.sprite = value;
			}
		}
	}

	public Sprite WeakReadySprite2
	{
		get
		{
			if (_oWeakReadyImage2 != null)
			{
				return _oWeakReadyImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WeakReadySprite2 != value && _oWeakReadyImage2 != null)
			{
				_oWeakReadyImage2.sprite = value;
			}
		}
	}

	public Sprite WeakReadySprite3
	{
		get
		{
			if (_oWeakReadyImage3 != null)
			{
				return _oWeakReadyImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WeakReadySprite3 != value && _oWeakReadyImage3 != null)
			{
				_oWeakReadyImage3.sprite = value;
			}
		}
	}

	public Image WeakReadyImage1
	{
		get
		{
			if (_oWeakReadyImage1 != null)
			{
				return _oWeakReadyImage1;
			}
			return null;
		}
		set
		{
			if (WeakReadyImage1 != value && _oWeakReadyImage1 != null)
			{
				_oWeakReadyImage1 = value;
			}
		}
	}

	public Image WeakReadyImage2
	{
		get
		{
			if (_oWeakReadyImage2 != null)
			{
				return _oWeakReadyImage2;
			}
			return null;
		}
		set
		{
			if (WeakReadyImage2 != value && _oWeakReadyImage2 != null)
			{
				_oWeakReadyImage2 = value;
			}
		}
	}

	public Image WeakReadyImage3
	{
		get
		{
			if (_oWeakReadyImage3 != null)
			{
				return _oWeakReadyImage3;
			}
			return null;
		}
		set
		{
			if (WeakReadyImage3 != value && _oWeakReadyImage3 != null)
			{
				_oWeakReadyImage3 = value;
			}
		}
	}

	public bool TipsShow1
	{
		get
		{
			if (_oTips1 != null)
			{
				return _oTips1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsShow1 != value && _oTips1 != null)
			{
				_oTips1.SetObjectActive(value);
			}
		}
	}

	public bool TipsShow2
	{
		get
		{
			if (_oTips2 != null)
			{
				return _oTips2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsShow2 != value && _oTips2 != null)
			{
				_oTips2.SetObjectActive(value);
			}
		}
	}

	public bool TipsShow3
	{
		get
		{
			if (_oTips3 != null)
			{
				return _oTips3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsShow3 != value && _oTips3 != null)
			{
				_oTips3.SetObjectActive(value);
			}
		}
	}

	public Sprite TipsSprite1
	{
		get
		{
			if (_oTipsImage1 != null)
			{
				return _oTipsImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite1 != value && _oTipsImage1 != null)
			{
				_oTipsImage1.sprite = value;
			}
		}
	}

	public Sprite TipsSprite2
	{
		get
		{
			if (_oTipsImage2 != null)
			{
				return _oTipsImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite2 != value && _oTipsImage2 != null)
			{
				_oTipsImage2.sprite = value;
			}
		}
	}

	public Sprite TipsSprite3
	{
		get
		{
			if (_oTipsImage3 != null)
			{
				return _oTipsImage3.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite3 != value && _oTipsImage3 != null)
			{
				_oTipsImage3.sprite = value;
			}
		}
	}

	public Image TipsImage1
	{
		get
		{
			if (_oTipsImage1 != null)
			{
				return _oTipsImage1;
			}
			return null;
		}
		set
		{
			if (TipsImage1 != value && _oTipsImage1 != null)
			{
				_oTipsImage1 = value;
			}
		}
	}

	public Image TipsImage2
	{
		get
		{
			if (_oTipsImage2 != null)
			{
				return _oTipsImage2;
			}
			return null;
		}
		set
		{
			if (TipsImage2 != value && _oTipsImage2 != null)
			{
				_oTipsImage2 = value;
			}
		}
	}

	public Image TipsImage3
	{
		get
		{
			if (_oTipsImage3 != null)
			{
				return _oTipsImage3;
			}
			return null;
		}
		set
		{
			if (TipsImage3 != value && _oTipsImage3 != null)
			{
				_oTipsImage3 = value;
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "bg1":
				_obg1 = transform.gameObject;
				_obgImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "bg2":
				_obg2 = transform.gameObject;
				_obgImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "bg3":
				_obg3 = transform.gameObject;
				_obgImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "vImg":
				_ovImg = transform.gameObject;
				_ovImgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillProgress1":
				_oSkillProgress1 = transform.gameObject;
				_oSkillProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillProgress2":
				_oSkillProgress2 = transform.gameObject;
				_oSkillProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillProgress3":
				_oSkillProgress3 = transform.gameObject;
				_oSkillProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Selected1":
				_oSelected1 = transform.gameObject;
				_oSelectedImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Selected2":
				_oSelected2 = transform.gameObject;
				_oSelectedImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Selected3":
				_oSelected3 = transform.gameObject;
				_oSelectedImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakUse1":
				_oWeakUse1 = transform.gameObject;
				_oWeakUseImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakUse2":
				_oWeakUse2 = transform.gameObject;
				_oWeakUseImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakUse3":
				_oWeakUse3 = transform.gameObject;
				_oWeakUseImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakReady1":
				_oWeakReady1 = transform.gameObject;
				_oWeakReadyImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakReady2":
				_oWeakReady2 = transform.gameObject;
				_oWeakReadyImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WeakReady3":
				_oWeakReady3 = transform.gameObject;
				_oWeakReadyImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Tips1":
				_oTips1 = transform.gameObject;
				_oTipsImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Tips2":
				_oTips2 = transform.gameObject;
				_oTipsImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Tips3":
				_oTips3 = transform.gameObject;
				_oTipsImage3 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public Image GetbgImage(int index)
	{
		return index switch
		{
			1 => bgImage1, 
			2 => bgImage2, 
			3 => bgImage3, 
			_ => null, 
		};
	}

	public void SetbgImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			bgImage1 = value;
			break;
		case 2:
			bgImage2 = value;
			break;
		case 3:
			bgImage3 = value;
			break;
		}
	}

	public bool GetSkillProgressShow(int index)
	{
		return index switch
		{
			1 => SkillProgressShow1, 
			2 => SkillProgressShow2, 
			3 => SkillProgressShow3, 
			_ => false, 
		};
	}

	public void SetSkillProgressShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillProgressShow1 = value;
			break;
		case 2:
			SkillProgressShow2 = value;
			break;
		case 3:
			SkillProgressShow3 = value;
			break;
		}
	}

	public Sprite GetSkillProgressSprite(int index)
	{
		return index switch
		{
			1 => SkillProgressSprite1, 
			2 => SkillProgressSprite2, 
			3 => SkillProgressSprite3, 
			_ => null, 
		};
	}

	public void SetSkillProgressSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillProgressSprite1 = value;
			break;
		case 2:
			SkillProgressSprite2 = value;
			break;
		case 3:
			SkillProgressSprite3 = value;
			break;
		}
	}

	public float GetSkillProgressFillamount(int index)
	{
		return index switch
		{
			1 => SkillProgressFillamount1, 
			2 => SkillProgressFillamount2, 
			3 => SkillProgressFillamount3, 
			_ => 0f, 
		};
	}

	public void SetSkillProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			SkillProgressFillamount1 = value;
			break;
		case 2:
			SkillProgressFillamount2 = value;
			break;
		case 3:
			SkillProgressFillamount3 = value;
			break;
		}
	}

	public Image GetSkillProgressImage(int index)
	{
		return index switch
		{
			1 => SkillProgressImage1, 
			2 => SkillProgressImage2, 
			3 => SkillProgressImage3, 
			_ => null, 
		};
	}

	public void SetSkillProgressImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			SkillProgressImage1 = value;
			break;
		case 2:
			SkillProgressImage2 = value;
			break;
		case 3:
			SkillProgressImage3 = value;
			break;
		}
	}

	public bool GetSelectedShow(int index)
	{
		return index switch
		{
			1 => SelectedShow1, 
			2 => SelectedShow2, 
			3 => SelectedShow3, 
			_ => false, 
		};
	}

	public void SetSelectedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedShow1 = value;
			break;
		case 2:
			SelectedShow2 = value;
			break;
		case 3:
			SelectedShow3 = value;
			break;
		}
	}

	public Image GetSelectedImage(int index)
	{
		return index switch
		{
			1 => SelectedImage1, 
			2 => SelectedImage2, 
			3 => SelectedImage3, 
			_ => null, 
		};
	}

	public void SetSelectedImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			SelectedImage1 = value;
			break;
		case 2:
			SelectedImage2 = value;
			break;
		case 3:
			SelectedImage3 = value;
			break;
		}
	}

	public bool GetWeakUseShow(int index)
	{
		return index switch
		{
			1 => WeakUseShow1, 
			2 => WeakUseShow2, 
			3 => WeakUseShow3, 
			_ => false, 
		};
	}

	public void SetWeakUseShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeakUseShow1 = value;
			break;
		case 2:
			WeakUseShow2 = value;
			break;
		case 3:
			WeakUseShow3 = value;
			break;
		}
	}

	public Sprite GetWeakUseSprite(int index)
	{
		return index switch
		{
			1 => WeakUseSprite1, 
			2 => WeakUseSprite2, 
			3 => WeakUseSprite3, 
			_ => null, 
		};
	}

	public void SetWeakUseSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeakUseSprite1 = value;
			break;
		case 2:
			WeakUseSprite2 = value;
			break;
		case 3:
			WeakUseSprite3 = value;
			break;
		}
	}

	public Image GetWeakUseImage(int index)
	{
		return index switch
		{
			1 => WeakUseImage1, 
			2 => WeakUseImage2, 
			3 => WeakUseImage3, 
			_ => null, 
		};
	}

	public void SetWeakUseImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			WeakUseImage1 = value;
			break;
		case 2:
			WeakUseImage2 = value;
			break;
		case 3:
			WeakUseImage3 = value;
			break;
		}
	}

	public bool GetWeakReadyShow(int index)
	{
		return index switch
		{
			1 => WeakReadyShow1, 
			2 => WeakReadyShow2, 
			3 => WeakReadyShow3, 
			_ => false, 
		};
	}

	public void SetWeakReadyShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeakReadyShow1 = value;
			break;
		case 2:
			WeakReadyShow2 = value;
			break;
		case 3:
			WeakReadyShow3 = value;
			break;
		}
	}

	public Sprite GetWeakReadySprite(int index)
	{
		return index switch
		{
			1 => WeakReadySprite1, 
			2 => WeakReadySprite2, 
			3 => WeakReadySprite3, 
			_ => null, 
		};
	}

	public void SetWeakReadySprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WeakReadySprite1 = value;
			break;
		case 2:
			WeakReadySprite2 = value;
			break;
		case 3:
			WeakReadySprite3 = value;
			break;
		}
	}

	public Image GetWeakReadyImage(int index)
	{
		return index switch
		{
			1 => WeakReadyImage1, 
			2 => WeakReadyImage2, 
			3 => WeakReadyImage3, 
			_ => null, 
		};
	}

	public void SetWeakReadyImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			WeakReadyImage1 = value;
			break;
		case 2:
			WeakReadyImage2 = value;
			break;
		case 3:
			WeakReadyImage3 = value;
			break;
		}
	}

	public bool GetTipsShow(int index)
	{
		return index switch
		{
			1 => TipsShow1, 
			2 => TipsShow2, 
			3 => TipsShow3, 
			_ => false, 
		};
	}

	public void SetTipsShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TipsShow1 = value;
			break;
		case 2:
			TipsShow2 = value;
			break;
		case 3:
			TipsShow3 = value;
			break;
		}
	}

	public Sprite GetTipsSprite(int index)
	{
		return index switch
		{
			1 => TipsSprite1, 
			2 => TipsSprite2, 
			3 => TipsSprite3, 
			_ => null, 
		};
	}

	public void SetTipsSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TipsSprite1 = value;
			break;
		case 2:
			TipsSprite2 = value;
			break;
		case 3:
			TipsSprite3 = value;
			break;
		}
	}

	public Image GetTipsImage(int index)
	{
		return index switch
		{
			1 => TipsImage1, 
			2 => TipsImage2, 
			3 => TipsImage3, 
			_ => null, 
		};
	}

	public void SetTipsImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			TipsImage1 = value;
			break;
		case 2:
			TipsImage2 = value;
			break;
		case 3:
			TipsImage3 = value;
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
