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
public class SkillprogressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private RectTransform _oRightBottomRectTransform;

	private GameObject _oBackImage;

	private RectTransform _oBackImageRectTransform;

	private Image _oBackImageImage;

	private GameObject _oGrid;

	private RectTransform _oGridRectTransform;

	private GameObject _oProgressItem1;

	private GameObject _oProgressItem2;

	private GameObject _oProgressItem3;

	private GameObject _oProgressItem4;

	private GameObject _oProgressItem5;

	private GameObject _oProgressItem6;

	private GameObject _oProgressItem7;

	private GameObject _oProgressItem8;

	private GameObject _oProgressItem9;

	private GameObject _oProgressItem10;

	private Image _oProgressItemImage1;

	private Image _oProgressItemImage2;

	private Image _oProgressItemImage3;

	private Image _oProgressItemImage4;

	private Image _oProgressItemImage5;

	private Image _oProgressItemImage6;

	private Image _oProgressItemImage7;

	private Image _oProgressItemImage8;

	private Image _oProgressItemImage9;

	private Image _oProgressItemImage10;

	private GameObject _oProgressImage;

	private RectTransform _oProgressImageRectTransform;

	private Image _oProgressImageImage;

	private GameObject _oIconImage;

	private RectTransform _oIconImageRectTransform;

	private CanvasGroup _oIconImageCanvasGroup;

	private Image _oIconImageImage;

	private GameObject _oEffectImage;

	private RectTransform _oEffectImageRectTransform;

	private Image _oEffectImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Skillprogress";

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

	public bool RightBottomShow
	{
		get
		{
			if (_oRightBottom != null)
			{
				return _oRightBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightBottomShow != value && _oRightBottom != null)
			{
				_oRightBottom.SetObjectActive(value);
			}
		}
	}

	public Vector3 RightBottomPosition
	{
		get
		{
			if (_oRightBottomRectTransform != null)
			{
				return _oRightBottomRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightBottomPosition != value && _oRightBottomRectTransform != null)
			{
				_oRightBottomRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 BackImagePosition
	{
		get
		{
			if (_oBackImageRectTransform != null)
			{
				return _oBackImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BackImagePosition != value && _oBackImageRectTransform != null)
			{
				_oBackImageRectTransform.localPosition = value;
			}
		}
	}

	public Sprite BackImageSprite
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite != value && _oBackImageImage != null)
			{
				_oBackImageImage.sprite = value;
			}
		}
	}

	public Image BackImageImage
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage;
			}
			return null;
		}
		set
		{
			if (BackImageImage != value && _oBackImageImage != null)
			{
				_oBackImageImage = value;
			}
		}
	}

	public GameObject GridObj => _oGrid;

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

	public Quaternion GridRotation
	{
		get
		{
			if (_oGridRectTransform != null)
			{
				return _oGridRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (GridRotation != value && _oGridRectTransform != null)
			{
				_oGridRectTransform.localRotation = value;
			}
		}
	}

	public bool ProgressItemShow1
	{
		get
		{
			if (_oProgressItem1 != null)
			{
				return _oProgressItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow1 != value && _oProgressItem1 != null)
			{
				_oProgressItem1.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow2
	{
		get
		{
			if (_oProgressItem2 != null)
			{
				return _oProgressItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow2 != value && _oProgressItem2 != null)
			{
				_oProgressItem2.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow3
	{
		get
		{
			if (_oProgressItem3 != null)
			{
				return _oProgressItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow3 != value && _oProgressItem3 != null)
			{
				_oProgressItem3.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow4
	{
		get
		{
			if (_oProgressItem4 != null)
			{
				return _oProgressItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow4 != value && _oProgressItem4 != null)
			{
				_oProgressItem4.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow5
	{
		get
		{
			if (_oProgressItem5 != null)
			{
				return _oProgressItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow5 != value && _oProgressItem5 != null)
			{
				_oProgressItem5.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow6
	{
		get
		{
			if (_oProgressItem6 != null)
			{
				return _oProgressItem6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow6 != value && _oProgressItem6 != null)
			{
				_oProgressItem6.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow7
	{
		get
		{
			if (_oProgressItem7 != null)
			{
				return _oProgressItem7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow7 != value && _oProgressItem7 != null)
			{
				_oProgressItem7.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow8
	{
		get
		{
			if (_oProgressItem8 != null)
			{
				return _oProgressItem8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow8 != value && _oProgressItem8 != null)
			{
				_oProgressItem8.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow9
	{
		get
		{
			if (_oProgressItem9 != null)
			{
				return _oProgressItem9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow9 != value && _oProgressItem9 != null)
			{
				_oProgressItem9.SetObjectActive(value);
			}
		}
	}

	public bool ProgressItemShow10
	{
		get
		{
			if (_oProgressItem10 != null)
			{
				return _oProgressItem10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressItemShow10 != value && _oProgressItem10 != null)
			{
				_oProgressItem10.SetObjectActive(value);
			}
		}
	}

	public Sprite ProgressItemSprite1
	{
		get
		{
			if (_oProgressItemImage1 != null)
			{
				return _oProgressItemImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite1 != value && _oProgressItemImage1 != null)
			{
				_oProgressItemImage1.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite2
	{
		get
		{
			if (_oProgressItemImage2 != null)
			{
				return _oProgressItemImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite2 != value && _oProgressItemImage2 != null)
			{
				_oProgressItemImage2.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite3
	{
		get
		{
			if (_oProgressItemImage3 != null)
			{
				return _oProgressItemImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite3 != value && _oProgressItemImage3 != null)
			{
				_oProgressItemImage3.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite4
	{
		get
		{
			if (_oProgressItemImage4 != null)
			{
				return _oProgressItemImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite4 != value && _oProgressItemImage4 != null)
			{
				_oProgressItemImage4.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite5
	{
		get
		{
			if (_oProgressItemImage5 != null)
			{
				return _oProgressItemImage5.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite5 != value && _oProgressItemImage5 != null)
			{
				_oProgressItemImage5.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite6
	{
		get
		{
			if (_oProgressItemImage6 != null)
			{
				return _oProgressItemImage6.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite6 != value && _oProgressItemImage6 != null)
			{
				_oProgressItemImage6.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite7
	{
		get
		{
			if (_oProgressItemImage7 != null)
			{
				return _oProgressItemImage7.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite7 != value && _oProgressItemImage7 != null)
			{
				_oProgressItemImage7.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite8
	{
		get
		{
			if (_oProgressItemImage8 != null)
			{
				return _oProgressItemImage8.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite8 != value && _oProgressItemImage8 != null)
			{
				_oProgressItemImage8.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite9
	{
		get
		{
			if (_oProgressItemImage9 != null)
			{
				return _oProgressItemImage9.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite9 != value && _oProgressItemImage9 != null)
			{
				_oProgressItemImage9.sprite = value;
			}
		}
	}

	public Sprite ProgressItemSprite10
	{
		get
		{
			if (_oProgressItemImage10 != null)
			{
				return _oProgressItemImage10.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressItemSprite10 != value && _oProgressItemImage10 != null)
			{
				_oProgressItemImage10.sprite = value;
			}
		}
	}

	public Image ProgressItemImage1
	{
		get
		{
			if (_oProgressItemImage1 != null)
			{
				return _oProgressItemImage1;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage1 != value && _oProgressItemImage1 != null)
			{
				_oProgressItemImage1 = value;
			}
		}
	}

	public Image ProgressItemImage2
	{
		get
		{
			if (_oProgressItemImage2 != null)
			{
				return _oProgressItemImage2;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage2 != value && _oProgressItemImage2 != null)
			{
				_oProgressItemImage2 = value;
			}
		}
	}

	public Image ProgressItemImage3
	{
		get
		{
			if (_oProgressItemImage3 != null)
			{
				return _oProgressItemImage3;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage3 != value && _oProgressItemImage3 != null)
			{
				_oProgressItemImage3 = value;
			}
		}
	}

	public Image ProgressItemImage4
	{
		get
		{
			if (_oProgressItemImage4 != null)
			{
				return _oProgressItemImage4;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage4 != value && _oProgressItemImage4 != null)
			{
				_oProgressItemImage4 = value;
			}
		}
	}

	public Image ProgressItemImage5
	{
		get
		{
			if (_oProgressItemImage5 != null)
			{
				return _oProgressItemImage5;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage5 != value && _oProgressItemImage5 != null)
			{
				_oProgressItemImage5 = value;
			}
		}
	}

	public Image ProgressItemImage6
	{
		get
		{
			if (_oProgressItemImage6 != null)
			{
				return _oProgressItemImage6;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage6 != value && _oProgressItemImage6 != null)
			{
				_oProgressItemImage6 = value;
			}
		}
	}

	public Image ProgressItemImage7
	{
		get
		{
			if (_oProgressItemImage7 != null)
			{
				return _oProgressItemImage7;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage7 != value && _oProgressItemImage7 != null)
			{
				_oProgressItemImage7 = value;
			}
		}
	}

	public Image ProgressItemImage8
	{
		get
		{
			if (_oProgressItemImage8 != null)
			{
				return _oProgressItemImage8;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage8 != value && _oProgressItemImage8 != null)
			{
				_oProgressItemImage8 = value;
			}
		}
	}

	public Image ProgressItemImage9
	{
		get
		{
			if (_oProgressItemImage9 != null)
			{
				return _oProgressItemImage9;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage9 != value && _oProgressItemImage9 != null)
			{
				_oProgressItemImage9 = value;
			}
		}
	}

	public Image ProgressItemImage10
	{
		get
		{
			if (_oProgressItemImage10 != null)
			{
				return _oProgressItemImage10;
			}
			return null;
		}
		set
		{
			if (ProgressItemImage10 != value && _oProgressItemImage10 != null)
			{
				_oProgressItemImage10 = value;
			}
		}
	}

	public bool ProgressImageShow
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressImageShow != value && _oProgressImage != null)
			{
				_oProgressImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 ProgressImagePosition
	{
		get
		{
			if (_oProgressImageRectTransform != null)
			{
				return _oProgressImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ProgressImagePosition != value && _oProgressImageRectTransform != null)
			{
				_oProgressImageRectTransform.localPosition = value;
			}
		}
	}

	public Quaternion ProgressImageRotation
	{
		get
		{
			if (_oProgressImageRectTransform != null)
			{
				return _oProgressImageRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (ProgressImageRotation != value && _oProgressImageRectTransform != null)
			{
				_oProgressImageRectTransform.localRotation = value;
			}
		}
	}

	public Sprite ProgressImageSprite
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressImageSprite != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.sprite = value;
			}
		}
	}

	public Image.FillMethod ProgressImageFillmethod
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (ProgressImageFillmethod != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillMethod = value;
			}
		}
	}

	public int ProgressImageFillorigin
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillOrigin;
			}
			return 0;
		}
		set
		{
			if (ProgressImageFillorigin != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillOrigin = value;
			}
		}
	}

	public float ProgressImageFillamount
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressImageFillamount != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillAmount = value;
			}
		}
	}

	public bool ProgressImageClockwise
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillClockwise;
			}
			return false;
		}
		set
		{
			if (ProgressImageClockwise != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillClockwise = value;
			}
		}
	}

	public Image ProgressImageImage
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage;
			}
			return null;
		}
		set
		{
			if (ProgressImageImage != value && _oProgressImageImage != null)
			{
				_oProgressImageImage = value;
			}
		}
	}

	public bool IconImageShow
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconImageShow != value && _oIconImage != null)
			{
				_oIconImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 IconImagePosition
	{
		get
		{
			if (_oIconImageRectTransform != null)
			{
				return _oIconImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (IconImagePosition != value && _oIconImageRectTransform != null)
			{
				_oIconImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 IconImageScale
	{
		get
		{
			if (_oIconImageRectTransform != null)
			{
				return _oIconImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (IconImageScale != value && _oIconImageRectTransform != null)
			{
				_oIconImageRectTransform.localScale = value;
			}
		}
	}

	public float IconImageAlpha
	{
		get
		{
			if (_oIconImageCanvasGroup != null)
			{
				return _oIconImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (IconImageAlpha != value && _oIconImageCanvasGroup != null)
			{
				_oIconImageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite IconImageSprite
	{
		get
		{
			if (_oIconImageImage != null)
			{
				return _oIconImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconImageSprite != value && _oIconImageImage != null)
			{
				_oIconImageImage.sprite = value;
			}
		}
	}

	public Image IconImageImage
	{
		get
		{
			if (_oIconImageImage != null)
			{
				return _oIconImageImage;
			}
			return null;
		}
		set
		{
			if (IconImageImage != value && _oIconImageImage != null)
			{
				_oIconImageImage = value;
			}
		}
	}

	public bool EffectImageShow
	{
		get
		{
			if (_oEffectImage != null)
			{
				return _oEffectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow != value && _oEffectImage != null)
			{
				_oEffectImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 EffectImagePosition
	{
		get
		{
			if (_oEffectImageRectTransform != null)
			{
				return _oEffectImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectImagePosition != value && _oEffectImageRectTransform != null)
			{
				_oEffectImageRectTransform.localPosition = value;
			}
		}
	}

	public Quaternion EffectImageRotation
	{
		get
		{
			if (_oEffectImageRectTransform != null)
			{
				return _oEffectImageRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (EffectImageRotation != value && _oEffectImageRectTransform != null)
			{
				_oEffectImageRectTransform.localRotation = value;
			}
		}
	}

	public Sprite EffectImageSprite
	{
		get
		{
			if (_oEffectImageImage != null)
			{
				return _oEffectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite != value && _oEffectImageImage != null)
			{
				_oEffectImageImage.sprite = value;
			}
		}
	}

	public Image EffectImageImage
	{
		get
		{
			if (_oEffectImageImage != null)
			{
				return _oEffectImageImage;
			}
			return null;
		}
		set
		{
			if (EffectImageImage != value && _oEffectImageImage != null)
			{
				_oEffectImageImage = value;
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
			case "RightBottom":
				_oRightBottom = transform.gameObject;
				_oRightBottomRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				_oGridRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ProgressItem1":
				_oProgressItem1 = transform.gameObject;
				_oProgressItemImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem2":
				_oProgressItem2 = transform.gameObject;
				_oProgressItemImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem3":
				_oProgressItem3 = transform.gameObject;
				_oProgressItemImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem4":
				_oProgressItem4 = transform.gameObject;
				_oProgressItemImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem5":
				_oProgressItem5 = transform.gameObject;
				_oProgressItemImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem6":
				_oProgressItem6 = transform.gameObject;
				_oProgressItemImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem7":
				_oProgressItem7 = transform.gameObject;
				_oProgressItemImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem8":
				_oProgressItem8 = transform.gameObject;
				_oProgressItemImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem9":
				_oProgressItem9 = transform.gameObject;
				_oProgressItemImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressItem10":
				_oProgressItem10 = transform.gameObject;
				_oProgressItemImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressImage":
				_oProgressImage = transform.gameObject;
				_oProgressImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oProgressImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "IconImage":
				_oIconImage = transform.gameObject;
				_oIconImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oIconImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oIconImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectImage":
				_oEffectImage = transform.gameObject;
				_oEffectImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void BackImageNtvsize()
	{
		if (_oBackImageImage != null)
		{
			_oBackImageImage.SetNativeSize();
		}
	}

	public bool GetProgressItemShow(int index)
	{
		return index switch
		{
			1 => ProgressItemShow1, 
			2 => ProgressItemShow2, 
			3 => ProgressItemShow3, 
			4 => ProgressItemShow4, 
			5 => ProgressItemShow5, 
			6 => ProgressItemShow6, 
			7 => ProgressItemShow7, 
			8 => ProgressItemShow8, 
			9 => ProgressItemShow9, 
			10 => ProgressItemShow10, 
			_ => false, 
		};
	}

	public void SetProgressItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ProgressItemShow1 = value;
			break;
		case 2:
			ProgressItemShow2 = value;
			break;
		case 3:
			ProgressItemShow3 = value;
			break;
		case 4:
			ProgressItemShow4 = value;
			break;
		case 5:
			ProgressItemShow5 = value;
			break;
		case 6:
			ProgressItemShow6 = value;
			break;
		case 7:
			ProgressItemShow7 = value;
			break;
		case 8:
			ProgressItemShow8 = value;
			break;
		case 9:
			ProgressItemShow9 = value;
			break;
		case 10:
			ProgressItemShow10 = value;
			break;
		}
	}

	public Sprite GetProgressItemSprite(int index)
	{
		return index switch
		{
			1 => ProgressItemSprite1, 
			2 => ProgressItemSprite2, 
			3 => ProgressItemSprite3, 
			4 => ProgressItemSprite4, 
			5 => ProgressItemSprite5, 
			6 => ProgressItemSprite6, 
			7 => ProgressItemSprite7, 
			8 => ProgressItemSprite8, 
			9 => ProgressItemSprite9, 
			10 => ProgressItemSprite10, 
			_ => null, 
		};
	}

	public void SetProgressItemSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ProgressItemSprite1 = value;
			break;
		case 2:
			ProgressItemSprite2 = value;
			break;
		case 3:
			ProgressItemSprite3 = value;
			break;
		case 4:
			ProgressItemSprite4 = value;
			break;
		case 5:
			ProgressItemSprite5 = value;
			break;
		case 6:
			ProgressItemSprite6 = value;
			break;
		case 7:
			ProgressItemSprite7 = value;
			break;
		case 8:
			ProgressItemSprite8 = value;
			break;
		case 9:
			ProgressItemSprite9 = value;
			break;
		case 10:
			ProgressItemSprite10 = value;
			break;
		}
	}

	public Image GetProgressItemImage(int index)
	{
		return index switch
		{
			1 => ProgressItemImage1, 
			2 => ProgressItemImage2, 
			3 => ProgressItemImage3, 
			4 => ProgressItemImage4, 
			5 => ProgressItemImage5, 
			6 => ProgressItemImage6, 
			7 => ProgressItemImage7, 
			8 => ProgressItemImage8, 
			9 => ProgressItemImage9, 
			10 => ProgressItemImage10, 
			_ => null, 
		};
	}

	public void SetProgressItemImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			ProgressItemImage1 = value;
			break;
		case 2:
			ProgressItemImage2 = value;
			break;
		case 3:
			ProgressItemImage3 = value;
			break;
		case 4:
			ProgressItemImage4 = value;
			break;
		case 5:
			ProgressItemImage5 = value;
			break;
		case 6:
			ProgressItemImage6 = value;
			break;
		case 7:
			ProgressItemImage7 = value;
			break;
		case 8:
			ProgressItemImage8 = value;
			break;
		case 9:
			ProgressItemImage9 = value;
			break;
		case 10:
			ProgressItemImage10 = value;
			break;
		}
	}

	public void ProgressItemNtvsize1()
	{
		if (_oProgressItemImage1 != null)
		{
			_oProgressItemImage1.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize2()
	{
		if (_oProgressItemImage2 != null)
		{
			_oProgressItemImage2.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize3()
	{
		if (_oProgressItemImage3 != null)
		{
			_oProgressItemImage3.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize4()
	{
		if (_oProgressItemImage4 != null)
		{
			_oProgressItemImage4.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize5()
	{
		if (_oProgressItemImage5 != null)
		{
			_oProgressItemImage5.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize6()
	{
		if (_oProgressItemImage6 != null)
		{
			_oProgressItemImage6.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize7()
	{
		if (_oProgressItemImage7 != null)
		{
			_oProgressItemImage7.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize8()
	{
		if (_oProgressItemImage8 != null)
		{
			_oProgressItemImage8.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize9()
	{
		if (_oProgressItemImage9 != null)
		{
			_oProgressItemImage9.SetNativeSize();
		}
	}

	public void ProgressItemNtvsize10()
	{
		if (_oProgressItemImage10 != null)
		{
			_oProgressItemImage10.SetNativeSize();
		}
	}

	public void CallProgressItemNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			ProgressItemNtvsize1();
			break;
		case 2:
			ProgressItemNtvsize2();
			break;
		case 3:
			ProgressItemNtvsize3();
			break;
		case 4:
			ProgressItemNtvsize4();
			break;
		case 5:
			ProgressItemNtvsize5();
			break;
		case 6:
			ProgressItemNtvsize6();
			break;
		case 7:
			ProgressItemNtvsize7();
			break;
		case 8:
			ProgressItemNtvsize8();
			break;
		case 9:
			ProgressItemNtvsize9();
			break;
		case 10:
			ProgressItemNtvsize10();
			break;
		}
	}

	public void ProgressImageNtvsize()
	{
		if (_oProgressImageImage != null)
		{
			_oProgressImageImage.SetNativeSize();
		}
	}

	public void IconImageNtvsize()
	{
		if (_oIconImageImage != null)
		{
			_oIconImageImage.SetNativeSize();
		}
	}

	public void EffectImageNtvsize()
	{
		if (_oEffectImageImage != null)
		{
			_oEffectImageImage.SetNativeSize();
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
