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

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicaldamagescoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oDamageScoreImage1;

	private GameObject _oDamageScoreImage2;

	private GameObject _oDamageScoreImage3;

	private GameObject _oDamageScoreImage4;

	private GameObject _oDamageScoreImage5;

	private GameObject _oDamageScoreImage6;

	private GameObject _oDamageScoreImage7;

	private GameObject _oDamageScoreImage8;

	private GameObject _oDamageScoreImage9;

	private GameObject _oDamageScoreImage10;

	private GameObject _oDamageScoreImage11;

	private GameObject _oDamageScoreImage12;

	private GameObject _oDamageScoreImage13;

	private GameObject _oDamageScoreImage14;

	private GameObject _oDamageScoreImage15;

	private GameObject _oDamageScoreImage16;

	private GameObject _oDamageScoreImage17;

	private GameObject _oDamageScoreImage18;

	private GameObject _oDamageScoreImage19;

	private GameObject _oDamageScoreImage20;

	private Image _oDamageScoreImageImage1;

	private Image _oDamageScoreImageImage2;

	private Image _oDamageScoreImageImage3;

	private Image _oDamageScoreImageImage4;

	private Image _oDamageScoreImageImage5;

	private Image _oDamageScoreImageImage6;

	private Image _oDamageScoreImageImage7;

	private Image _oDamageScoreImageImage8;

	private Image _oDamageScoreImageImage9;

	private Image _oDamageScoreImageImage10;

	private Image _oDamageScoreImageImage11;

	private Image _oDamageScoreImageImage12;

	private Image _oDamageScoreImageImage13;

	private Image _oDamageScoreImageImage14;

	private Image _oDamageScoreImageImage15;

	private Image _oDamageScoreImageImage16;

	private Image _oDamageScoreImageImage17;

	private Image _oDamageScoreImageImage18;

	private Image _oDamageScoreImageImage19;

	private Image _oDamageScoreImageImage20;

	private GameObject _oDamageScoreEffectImage1;

	private GameObject _oDamageScoreEffectImage2;

	private GameObject _oDamageScoreEffectImage3;

	private GameObject _oDamageScoreEffectImage4;

	private GameObject _oDamageScoreEffectImage5;

	private GameObject _oDamageScoreEffectImage6;

	private GameObject _oDamageScoreEffectImage7;

	private GameObject _oDamageScoreEffectImage8;

	private GameObject _oDamageScoreEffectImage9;

	private GameObject _oDamageScoreEffectImage10;

	private GameObject _oDamageScoreEffectImage11;

	private GameObject _oDamageScoreEffectImage12;

	private GameObject _oDamageScoreEffectImage13;

	private GameObject _oDamageScoreEffectImage14;

	private GameObject _oDamageScoreEffectImage15;

	private GameObject _oDamageScoreEffectImage16;

	private GameObject _oDamageScoreEffectImage17;

	private GameObject _oDamageScoreEffectImage18;

	private GameObject _oDamageScoreEffectImage19;

	private GameObject _oDamageScoreEffectImage20;

	private Image _oDamageScoreEffectImageImage1;

	private Image _oDamageScoreEffectImageImage2;

	private Image _oDamageScoreEffectImageImage3;

	private Image _oDamageScoreEffectImageImage4;

	private Image _oDamageScoreEffectImageImage5;

	private Image _oDamageScoreEffectImageImage6;

	private Image _oDamageScoreEffectImageImage7;

	private Image _oDamageScoreEffectImageImage8;

	private Image _oDamageScoreEffectImageImage9;

	private Image _oDamageScoreEffectImageImage10;

	private Image _oDamageScoreEffectImageImage11;

	private Image _oDamageScoreEffectImageImage12;

	private Image _oDamageScoreEffectImageImage13;

	private Image _oDamageScoreEffectImageImage14;

	private Image _oDamageScoreEffectImageImage15;

	private Image _oDamageScoreEffectImageImage16;

	private Image _oDamageScoreEffectImageImage17;

	private Image _oDamageScoreEffectImageImage18;

	private Image _oDamageScoreEffectImageImage19;

	private Image _oDamageScoreEffectImageImage20;

	private GameObject _oDamageScoreImageFragment;

	private RectTransform _oDamageScoreImageFragmentRectTransform;

	private GameObject _oMoveDamageScoreImage1;

	private GameObject _oMoveDamageScoreImage2;

	private GameObject _oMoveDamageScoreImage3;

	private GameObject _oMoveDamageScoreImage4;

	private GameObject _oMoveDamageScoreImage5;

	private GameObject _oMoveDamageScoreImage6;

	private GameObject _oMoveDamageScoreImage7;

	private GameObject _oMoveDamageScoreImage8;

	private GameObject _oMoveDamageScoreImage9;

	private GameObject _oMoveDamageScoreImage10;

	private GameObject _oMoveDamageScoreImage11;

	private GameObject _oMoveDamageScoreImage12;

	private GameObject _oMoveDamageScoreImage13;

	private GameObject _oMoveDamageScoreImage14;

	private GameObject _oMoveDamageScoreImage15;

	private RectTransform _oMoveDamageScoreImageRectTransform1;

	private RectTransform _oMoveDamageScoreImageRectTransform2;

	private RectTransform _oMoveDamageScoreImageRectTransform3;

	private RectTransform _oMoveDamageScoreImageRectTransform4;

	private RectTransform _oMoveDamageScoreImageRectTransform5;

	private RectTransform _oMoveDamageScoreImageRectTransform6;

	private RectTransform _oMoveDamageScoreImageRectTransform7;

	private RectTransform _oMoveDamageScoreImageRectTransform8;

	private RectTransform _oMoveDamageScoreImageRectTransform9;

	private RectTransform _oMoveDamageScoreImageRectTransform10;

	private RectTransform _oMoveDamageScoreImageRectTransform11;

	private RectTransform _oMoveDamageScoreImageRectTransform12;

	private RectTransform _oMoveDamageScoreImageRectTransform13;

	private RectTransform _oMoveDamageScoreImageRectTransform14;

	private RectTransform _oMoveDamageScoreImageRectTransform15;

	private GameObject _oMoveDamageFragment;

	private RectTransform _oMoveDamageFragmentRectTransform;

	private GameObject _oWaitEffectMask;

	private RectTransform _oWaitEffectMaskRectTransform;

	private GameObject _oWaitEffectImage;

	private RectTransform _oWaitEffectImageRectTransform;

	private GameObject _oScoreEffectImage;

	private RectTransform _oScoreEffectImageRectTransform;

	private CanvasGroup _oScoreEffectImageCanvasGroup;

	private Image _oScoreEffectImageImage;

	private GameObject _oFragmentCount;

	private GameObject _oFragmentCountText;

	private Text _oFragmentCountTextText;

	private GameObject _oBioDamage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicaldamagescore";

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

	public bool DamageScoreImageShow1
	{
		get
		{
			if (_oDamageScoreImage1 != null)
			{
				return _oDamageScoreImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow1 != value && _oDamageScoreImage1 != null)
			{
				_oDamageScoreImage1.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow2
	{
		get
		{
			if (_oDamageScoreImage2 != null)
			{
				return _oDamageScoreImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow2 != value && _oDamageScoreImage2 != null)
			{
				_oDamageScoreImage2.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow3
	{
		get
		{
			if (_oDamageScoreImage3 != null)
			{
				return _oDamageScoreImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow3 != value && _oDamageScoreImage3 != null)
			{
				_oDamageScoreImage3.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow4
	{
		get
		{
			if (_oDamageScoreImage4 != null)
			{
				return _oDamageScoreImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow4 != value && _oDamageScoreImage4 != null)
			{
				_oDamageScoreImage4.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow5
	{
		get
		{
			if (_oDamageScoreImage5 != null)
			{
				return _oDamageScoreImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow5 != value && _oDamageScoreImage5 != null)
			{
				_oDamageScoreImage5.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow6
	{
		get
		{
			if (_oDamageScoreImage6 != null)
			{
				return _oDamageScoreImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow6 != value && _oDamageScoreImage6 != null)
			{
				_oDamageScoreImage6.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow7
	{
		get
		{
			if (_oDamageScoreImage7 != null)
			{
				return _oDamageScoreImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow7 != value && _oDamageScoreImage7 != null)
			{
				_oDamageScoreImage7.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow8
	{
		get
		{
			if (_oDamageScoreImage8 != null)
			{
				return _oDamageScoreImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow8 != value && _oDamageScoreImage8 != null)
			{
				_oDamageScoreImage8.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow9
	{
		get
		{
			if (_oDamageScoreImage9 != null)
			{
				return _oDamageScoreImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow9 != value && _oDamageScoreImage9 != null)
			{
				_oDamageScoreImage9.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow10
	{
		get
		{
			if (_oDamageScoreImage10 != null)
			{
				return _oDamageScoreImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow10 != value && _oDamageScoreImage10 != null)
			{
				_oDamageScoreImage10.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow11
	{
		get
		{
			if (_oDamageScoreImage11 != null)
			{
				return _oDamageScoreImage11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow11 != value && _oDamageScoreImage11 != null)
			{
				_oDamageScoreImage11.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow12
	{
		get
		{
			if (_oDamageScoreImage12 != null)
			{
				return _oDamageScoreImage12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow12 != value && _oDamageScoreImage12 != null)
			{
				_oDamageScoreImage12.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow13
	{
		get
		{
			if (_oDamageScoreImage13 != null)
			{
				return _oDamageScoreImage13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow13 != value && _oDamageScoreImage13 != null)
			{
				_oDamageScoreImage13.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow14
	{
		get
		{
			if (_oDamageScoreImage14 != null)
			{
				return _oDamageScoreImage14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow14 != value && _oDamageScoreImage14 != null)
			{
				_oDamageScoreImage14.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow15
	{
		get
		{
			if (_oDamageScoreImage15 != null)
			{
				return _oDamageScoreImage15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow15 != value && _oDamageScoreImage15 != null)
			{
				_oDamageScoreImage15.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow16
	{
		get
		{
			if (_oDamageScoreImage16 != null)
			{
				return _oDamageScoreImage16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow16 != value && _oDamageScoreImage16 != null)
			{
				_oDamageScoreImage16.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow17
	{
		get
		{
			if (_oDamageScoreImage17 != null)
			{
				return _oDamageScoreImage17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow17 != value && _oDamageScoreImage17 != null)
			{
				_oDamageScoreImage17.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow18
	{
		get
		{
			if (_oDamageScoreImage18 != null)
			{
				return _oDamageScoreImage18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow18 != value && _oDamageScoreImage18 != null)
			{
				_oDamageScoreImage18.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow19
	{
		get
		{
			if (_oDamageScoreImage19 != null)
			{
				return _oDamageScoreImage19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow19 != value && _oDamageScoreImage19 != null)
			{
				_oDamageScoreImage19.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreImageShow20
	{
		get
		{
			if (_oDamageScoreImage20 != null)
			{
				return _oDamageScoreImage20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageShow20 != value && _oDamageScoreImage20 != null)
			{
				_oDamageScoreImage20.SetObjectActive(value);
			}
		}
	}

	public Sprite DamageScoreImageSprite1
	{
		get
		{
			if (_oDamageScoreImageImage1 != null)
			{
				return _oDamageScoreImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite1 != value && _oDamageScoreImageImage1 != null)
			{
				_oDamageScoreImageImage1.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite2
	{
		get
		{
			if (_oDamageScoreImageImage2 != null)
			{
				return _oDamageScoreImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite2 != value && _oDamageScoreImageImage2 != null)
			{
				_oDamageScoreImageImage2.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite3
	{
		get
		{
			if (_oDamageScoreImageImage3 != null)
			{
				return _oDamageScoreImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite3 != value && _oDamageScoreImageImage3 != null)
			{
				_oDamageScoreImageImage3.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite4
	{
		get
		{
			if (_oDamageScoreImageImage4 != null)
			{
				return _oDamageScoreImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite4 != value && _oDamageScoreImageImage4 != null)
			{
				_oDamageScoreImageImage4.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite5
	{
		get
		{
			if (_oDamageScoreImageImage5 != null)
			{
				return _oDamageScoreImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite5 != value && _oDamageScoreImageImage5 != null)
			{
				_oDamageScoreImageImage5.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite6
	{
		get
		{
			if (_oDamageScoreImageImage6 != null)
			{
				return _oDamageScoreImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite6 != value && _oDamageScoreImageImage6 != null)
			{
				_oDamageScoreImageImage6.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite7
	{
		get
		{
			if (_oDamageScoreImageImage7 != null)
			{
				return _oDamageScoreImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite7 != value && _oDamageScoreImageImage7 != null)
			{
				_oDamageScoreImageImage7.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite8
	{
		get
		{
			if (_oDamageScoreImageImage8 != null)
			{
				return _oDamageScoreImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite8 != value && _oDamageScoreImageImage8 != null)
			{
				_oDamageScoreImageImage8.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite9
	{
		get
		{
			if (_oDamageScoreImageImage9 != null)
			{
				return _oDamageScoreImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite9 != value && _oDamageScoreImageImage9 != null)
			{
				_oDamageScoreImageImage9.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite10
	{
		get
		{
			if (_oDamageScoreImageImage10 != null)
			{
				return _oDamageScoreImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite10 != value && _oDamageScoreImageImage10 != null)
			{
				_oDamageScoreImageImage10.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite11
	{
		get
		{
			if (_oDamageScoreImageImage11 != null)
			{
				return _oDamageScoreImageImage11.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite11 != value && _oDamageScoreImageImage11 != null)
			{
				_oDamageScoreImageImage11.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite12
	{
		get
		{
			if (_oDamageScoreImageImage12 != null)
			{
				return _oDamageScoreImageImage12.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite12 != value && _oDamageScoreImageImage12 != null)
			{
				_oDamageScoreImageImage12.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite13
	{
		get
		{
			if (_oDamageScoreImageImage13 != null)
			{
				return _oDamageScoreImageImage13.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite13 != value && _oDamageScoreImageImage13 != null)
			{
				_oDamageScoreImageImage13.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite14
	{
		get
		{
			if (_oDamageScoreImageImage14 != null)
			{
				return _oDamageScoreImageImage14.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite14 != value && _oDamageScoreImageImage14 != null)
			{
				_oDamageScoreImageImage14.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite15
	{
		get
		{
			if (_oDamageScoreImageImage15 != null)
			{
				return _oDamageScoreImageImage15.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite15 != value && _oDamageScoreImageImage15 != null)
			{
				_oDamageScoreImageImage15.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite16
	{
		get
		{
			if (_oDamageScoreImageImage16 != null)
			{
				return _oDamageScoreImageImage16.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite16 != value && _oDamageScoreImageImage16 != null)
			{
				_oDamageScoreImageImage16.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite17
	{
		get
		{
			if (_oDamageScoreImageImage17 != null)
			{
				return _oDamageScoreImageImage17.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite17 != value && _oDamageScoreImageImage17 != null)
			{
				_oDamageScoreImageImage17.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite18
	{
		get
		{
			if (_oDamageScoreImageImage18 != null)
			{
				return _oDamageScoreImageImage18.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite18 != value && _oDamageScoreImageImage18 != null)
			{
				_oDamageScoreImageImage18.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite19
	{
		get
		{
			if (_oDamageScoreImageImage19 != null)
			{
				return _oDamageScoreImageImage19.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite19 != value && _oDamageScoreImageImage19 != null)
			{
				_oDamageScoreImageImage19.sprite = value;
			}
		}
	}

	public Sprite DamageScoreImageSprite20
	{
		get
		{
			if (_oDamageScoreImageImage20 != null)
			{
				return _oDamageScoreImageImage20.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreImageSprite20 != value && _oDamageScoreImageImage20 != null)
			{
				_oDamageScoreImageImage20.sprite = value;
			}
		}
	}

	public bool DamageScoreEffectImageShow1
	{
		get
		{
			if (_oDamageScoreEffectImage1 != null)
			{
				return _oDamageScoreEffectImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow1 != value && _oDamageScoreEffectImage1 != null)
			{
				_oDamageScoreEffectImage1.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow2
	{
		get
		{
			if (_oDamageScoreEffectImage2 != null)
			{
				return _oDamageScoreEffectImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow2 != value && _oDamageScoreEffectImage2 != null)
			{
				_oDamageScoreEffectImage2.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow3
	{
		get
		{
			if (_oDamageScoreEffectImage3 != null)
			{
				return _oDamageScoreEffectImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow3 != value && _oDamageScoreEffectImage3 != null)
			{
				_oDamageScoreEffectImage3.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow4
	{
		get
		{
			if (_oDamageScoreEffectImage4 != null)
			{
				return _oDamageScoreEffectImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow4 != value && _oDamageScoreEffectImage4 != null)
			{
				_oDamageScoreEffectImage4.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow5
	{
		get
		{
			if (_oDamageScoreEffectImage5 != null)
			{
				return _oDamageScoreEffectImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow5 != value && _oDamageScoreEffectImage5 != null)
			{
				_oDamageScoreEffectImage5.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow6
	{
		get
		{
			if (_oDamageScoreEffectImage6 != null)
			{
				return _oDamageScoreEffectImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow6 != value && _oDamageScoreEffectImage6 != null)
			{
				_oDamageScoreEffectImage6.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow7
	{
		get
		{
			if (_oDamageScoreEffectImage7 != null)
			{
				return _oDamageScoreEffectImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow7 != value && _oDamageScoreEffectImage7 != null)
			{
				_oDamageScoreEffectImage7.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow8
	{
		get
		{
			if (_oDamageScoreEffectImage8 != null)
			{
				return _oDamageScoreEffectImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow8 != value && _oDamageScoreEffectImage8 != null)
			{
				_oDamageScoreEffectImage8.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow9
	{
		get
		{
			if (_oDamageScoreEffectImage9 != null)
			{
				return _oDamageScoreEffectImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow9 != value && _oDamageScoreEffectImage9 != null)
			{
				_oDamageScoreEffectImage9.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow10
	{
		get
		{
			if (_oDamageScoreEffectImage10 != null)
			{
				return _oDamageScoreEffectImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow10 != value && _oDamageScoreEffectImage10 != null)
			{
				_oDamageScoreEffectImage10.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow11
	{
		get
		{
			if (_oDamageScoreEffectImage11 != null)
			{
				return _oDamageScoreEffectImage11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow11 != value && _oDamageScoreEffectImage11 != null)
			{
				_oDamageScoreEffectImage11.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow12
	{
		get
		{
			if (_oDamageScoreEffectImage12 != null)
			{
				return _oDamageScoreEffectImage12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow12 != value && _oDamageScoreEffectImage12 != null)
			{
				_oDamageScoreEffectImage12.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow13
	{
		get
		{
			if (_oDamageScoreEffectImage13 != null)
			{
				return _oDamageScoreEffectImage13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow13 != value && _oDamageScoreEffectImage13 != null)
			{
				_oDamageScoreEffectImage13.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow14
	{
		get
		{
			if (_oDamageScoreEffectImage14 != null)
			{
				return _oDamageScoreEffectImage14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow14 != value && _oDamageScoreEffectImage14 != null)
			{
				_oDamageScoreEffectImage14.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow15
	{
		get
		{
			if (_oDamageScoreEffectImage15 != null)
			{
				return _oDamageScoreEffectImage15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow15 != value && _oDamageScoreEffectImage15 != null)
			{
				_oDamageScoreEffectImage15.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow16
	{
		get
		{
			if (_oDamageScoreEffectImage16 != null)
			{
				return _oDamageScoreEffectImage16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow16 != value && _oDamageScoreEffectImage16 != null)
			{
				_oDamageScoreEffectImage16.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow17
	{
		get
		{
			if (_oDamageScoreEffectImage17 != null)
			{
				return _oDamageScoreEffectImage17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow17 != value && _oDamageScoreEffectImage17 != null)
			{
				_oDamageScoreEffectImage17.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow18
	{
		get
		{
			if (_oDamageScoreEffectImage18 != null)
			{
				return _oDamageScoreEffectImage18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow18 != value && _oDamageScoreEffectImage18 != null)
			{
				_oDamageScoreEffectImage18.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow19
	{
		get
		{
			if (_oDamageScoreEffectImage19 != null)
			{
				return _oDamageScoreEffectImage19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow19 != value && _oDamageScoreEffectImage19 != null)
			{
				_oDamageScoreEffectImage19.SetObjectActive(value);
			}
		}
	}

	public bool DamageScoreEffectImageShow20
	{
		get
		{
			if (_oDamageScoreEffectImage20 != null)
			{
				return _oDamageScoreEffectImage20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreEffectImageShow20 != value && _oDamageScoreEffectImage20 != null)
			{
				_oDamageScoreEffectImage20.SetObjectActive(value);
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite1
	{
		get
		{
			if (_oDamageScoreEffectImageImage1 != null)
			{
				return _oDamageScoreEffectImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite1 != value && _oDamageScoreEffectImageImage1 != null)
			{
				_oDamageScoreEffectImageImage1.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite2
	{
		get
		{
			if (_oDamageScoreEffectImageImage2 != null)
			{
				return _oDamageScoreEffectImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite2 != value && _oDamageScoreEffectImageImage2 != null)
			{
				_oDamageScoreEffectImageImage2.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite3
	{
		get
		{
			if (_oDamageScoreEffectImageImage3 != null)
			{
				return _oDamageScoreEffectImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite3 != value && _oDamageScoreEffectImageImage3 != null)
			{
				_oDamageScoreEffectImageImage3.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite4
	{
		get
		{
			if (_oDamageScoreEffectImageImage4 != null)
			{
				return _oDamageScoreEffectImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite4 != value && _oDamageScoreEffectImageImage4 != null)
			{
				_oDamageScoreEffectImageImage4.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite5
	{
		get
		{
			if (_oDamageScoreEffectImageImage5 != null)
			{
				return _oDamageScoreEffectImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite5 != value && _oDamageScoreEffectImageImage5 != null)
			{
				_oDamageScoreEffectImageImage5.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite6
	{
		get
		{
			if (_oDamageScoreEffectImageImage6 != null)
			{
				return _oDamageScoreEffectImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite6 != value && _oDamageScoreEffectImageImage6 != null)
			{
				_oDamageScoreEffectImageImage6.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite7
	{
		get
		{
			if (_oDamageScoreEffectImageImage7 != null)
			{
				return _oDamageScoreEffectImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite7 != value && _oDamageScoreEffectImageImage7 != null)
			{
				_oDamageScoreEffectImageImage7.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite8
	{
		get
		{
			if (_oDamageScoreEffectImageImage8 != null)
			{
				return _oDamageScoreEffectImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite8 != value && _oDamageScoreEffectImageImage8 != null)
			{
				_oDamageScoreEffectImageImage8.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite9
	{
		get
		{
			if (_oDamageScoreEffectImageImage9 != null)
			{
				return _oDamageScoreEffectImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite9 != value && _oDamageScoreEffectImageImage9 != null)
			{
				_oDamageScoreEffectImageImage9.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite10
	{
		get
		{
			if (_oDamageScoreEffectImageImage10 != null)
			{
				return _oDamageScoreEffectImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite10 != value && _oDamageScoreEffectImageImage10 != null)
			{
				_oDamageScoreEffectImageImage10.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite11
	{
		get
		{
			if (_oDamageScoreEffectImageImage11 != null)
			{
				return _oDamageScoreEffectImageImage11.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite11 != value && _oDamageScoreEffectImageImage11 != null)
			{
				_oDamageScoreEffectImageImage11.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite12
	{
		get
		{
			if (_oDamageScoreEffectImageImage12 != null)
			{
				return _oDamageScoreEffectImageImage12.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite12 != value && _oDamageScoreEffectImageImage12 != null)
			{
				_oDamageScoreEffectImageImage12.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite13
	{
		get
		{
			if (_oDamageScoreEffectImageImage13 != null)
			{
				return _oDamageScoreEffectImageImage13.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite13 != value && _oDamageScoreEffectImageImage13 != null)
			{
				_oDamageScoreEffectImageImage13.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite14
	{
		get
		{
			if (_oDamageScoreEffectImageImage14 != null)
			{
				return _oDamageScoreEffectImageImage14.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite14 != value && _oDamageScoreEffectImageImage14 != null)
			{
				_oDamageScoreEffectImageImage14.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite15
	{
		get
		{
			if (_oDamageScoreEffectImageImage15 != null)
			{
				return _oDamageScoreEffectImageImage15.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite15 != value && _oDamageScoreEffectImageImage15 != null)
			{
				_oDamageScoreEffectImageImage15.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite16
	{
		get
		{
			if (_oDamageScoreEffectImageImage16 != null)
			{
				return _oDamageScoreEffectImageImage16.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite16 != value && _oDamageScoreEffectImageImage16 != null)
			{
				_oDamageScoreEffectImageImage16.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite17
	{
		get
		{
			if (_oDamageScoreEffectImageImage17 != null)
			{
				return _oDamageScoreEffectImageImage17.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite17 != value && _oDamageScoreEffectImageImage17 != null)
			{
				_oDamageScoreEffectImageImage17.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite18
	{
		get
		{
			if (_oDamageScoreEffectImageImage18 != null)
			{
				return _oDamageScoreEffectImageImage18.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite18 != value && _oDamageScoreEffectImageImage18 != null)
			{
				_oDamageScoreEffectImageImage18.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite19
	{
		get
		{
			if (_oDamageScoreEffectImageImage19 != null)
			{
				return _oDamageScoreEffectImageImage19.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite19 != value && _oDamageScoreEffectImageImage19 != null)
			{
				_oDamageScoreEffectImageImage19.sprite = value;
			}
		}
	}

	public Sprite DamageScoreEffectImageSprite20
	{
		get
		{
			if (_oDamageScoreEffectImageImage20 != null)
			{
				return _oDamageScoreEffectImageImage20.sprite;
			}
			return null;
		}
		set
		{
			if (DamageScoreEffectImageSprite20 != value && _oDamageScoreEffectImageImage20 != null)
			{
				_oDamageScoreEffectImageImage20.sprite = value;
			}
		}
	}

	public bool DamageScoreImageFragmentShow
	{
		get
		{
			if (_oDamageScoreImageFragment != null)
			{
				return _oDamageScoreImageFragment.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DamageScoreImageFragmentShow != value && _oDamageScoreImageFragment != null)
			{
				_oDamageScoreImageFragment.SetObjectActive(value);
			}
		}
	}

	public Vector3 DamageScoreImageFragmentPosition
	{
		get
		{
			if (_oDamageScoreImageFragmentRectTransform != null)
			{
				return _oDamageScoreImageFragmentRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DamageScoreImageFragmentPosition != value && _oDamageScoreImageFragmentRectTransform != null)
			{
				_oDamageScoreImageFragmentRectTransform.localPosition = value;
			}
		}
	}

	public bool MoveDamageScoreImageShow1
	{
		get
		{
			if (_oMoveDamageScoreImage1 != null)
			{
				return _oMoveDamageScoreImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow1 != value && _oMoveDamageScoreImage1 != null)
			{
				_oMoveDamageScoreImage1.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow2
	{
		get
		{
			if (_oMoveDamageScoreImage2 != null)
			{
				return _oMoveDamageScoreImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow2 != value && _oMoveDamageScoreImage2 != null)
			{
				_oMoveDamageScoreImage2.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow3
	{
		get
		{
			if (_oMoveDamageScoreImage3 != null)
			{
				return _oMoveDamageScoreImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow3 != value && _oMoveDamageScoreImage3 != null)
			{
				_oMoveDamageScoreImage3.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow4
	{
		get
		{
			if (_oMoveDamageScoreImage4 != null)
			{
				return _oMoveDamageScoreImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow4 != value && _oMoveDamageScoreImage4 != null)
			{
				_oMoveDamageScoreImage4.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow5
	{
		get
		{
			if (_oMoveDamageScoreImage5 != null)
			{
				return _oMoveDamageScoreImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow5 != value && _oMoveDamageScoreImage5 != null)
			{
				_oMoveDamageScoreImage5.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow6
	{
		get
		{
			if (_oMoveDamageScoreImage6 != null)
			{
				return _oMoveDamageScoreImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow6 != value && _oMoveDamageScoreImage6 != null)
			{
				_oMoveDamageScoreImage6.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow7
	{
		get
		{
			if (_oMoveDamageScoreImage7 != null)
			{
				return _oMoveDamageScoreImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow7 != value && _oMoveDamageScoreImage7 != null)
			{
				_oMoveDamageScoreImage7.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow8
	{
		get
		{
			if (_oMoveDamageScoreImage8 != null)
			{
				return _oMoveDamageScoreImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow8 != value && _oMoveDamageScoreImage8 != null)
			{
				_oMoveDamageScoreImage8.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow9
	{
		get
		{
			if (_oMoveDamageScoreImage9 != null)
			{
				return _oMoveDamageScoreImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow9 != value && _oMoveDamageScoreImage9 != null)
			{
				_oMoveDamageScoreImage9.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow10
	{
		get
		{
			if (_oMoveDamageScoreImage10 != null)
			{
				return _oMoveDamageScoreImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow10 != value && _oMoveDamageScoreImage10 != null)
			{
				_oMoveDamageScoreImage10.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow11
	{
		get
		{
			if (_oMoveDamageScoreImage11 != null)
			{
				return _oMoveDamageScoreImage11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow11 != value && _oMoveDamageScoreImage11 != null)
			{
				_oMoveDamageScoreImage11.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow12
	{
		get
		{
			if (_oMoveDamageScoreImage12 != null)
			{
				return _oMoveDamageScoreImage12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow12 != value && _oMoveDamageScoreImage12 != null)
			{
				_oMoveDamageScoreImage12.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow13
	{
		get
		{
			if (_oMoveDamageScoreImage13 != null)
			{
				return _oMoveDamageScoreImage13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow13 != value && _oMoveDamageScoreImage13 != null)
			{
				_oMoveDamageScoreImage13.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow14
	{
		get
		{
			if (_oMoveDamageScoreImage14 != null)
			{
				return _oMoveDamageScoreImage14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow14 != value && _oMoveDamageScoreImage14 != null)
			{
				_oMoveDamageScoreImage14.SetObjectActive(value);
			}
		}
	}

	public bool MoveDamageScoreImageShow15
	{
		get
		{
			if (_oMoveDamageScoreImage15 != null)
			{
				return _oMoveDamageScoreImage15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageScoreImageShow15 != value && _oMoveDamageScoreImage15 != null)
			{
				_oMoveDamageScoreImage15.SetObjectActive(value);
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition1
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform1 != null)
			{
				return _oMoveDamageScoreImageRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition1 != value && _oMoveDamageScoreImageRectTransform1 != null)
			{
				_oMoveDamageScoreImageRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition2
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform2 != null)
			{
				return _oMoveDamageScoreImageRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition2 != value && _oMoveDamageScoreImageRectTransform2 != null)
			{
				_oMoveDamageScoreImageRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition3
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform3 != null)
			{
				return _oMoveDamageScoreImageRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition3 != value && _oMoveDamageScoreImageRectTransform3 != null)
			{
				_oMoveDamageScoreImageRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition4
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform4 != null)
			{
				return _oMoveDamageScoreImageRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition4 != value && _oMoveDamageScoreImageRectTransform4 != null)
			{
				_oMoveDamageScoreImageRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition5
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform5 != null)
			{
				return _oMoveDamageScoreImageRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition5 != value && _oMoveDamageScoreImageRectTransform5 != null)
			{
				_oMoveDamageScoreImageRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition6
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform6 != null)
			{
				return _oMoveDamageScoreImageRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition6 != value && _oMoveDamageScoreImageRectTransform6 != null)
			{
				_oMoveDamageScoreImageRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition7
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform7 != null)
			{
				return _oMoveDamageScoreImageRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition7 != value && _oMoveDamageScoreImageRectTransform7 != null)
			{
				_oMoveDamageScoreImageRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition8
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform8 != null)
			{
				return _oMoveDamageScoreImageRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition8 != value && _oMoveDamageScoreImageRectTransform8 != null)
			{
				_oMoveDamageScoreImageRectTransform8.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition9
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform9 != null)
			{
				return _oMoveDamageScoreImageRectTransform9.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition9 != value && _oMoveDamageScoreImageRectTransform9 != null)
			{
				_oMoveDamageScoreImageRectTransform9.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition10
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform10 != null)
			{
				return _oMoveDamageScoreImageRectTransform10.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition10 != value && _oMoveDamageScoreImageRectTransform10 != null)
			{
				_oMoveDamageScoreImageRectTransform10.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition11
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform11 != null)
			{
				return _oMoveDamageScoreImageRectTransform11.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition11 != value && _oMoveDamageScoreImageRectTransform11 != null)
			{
				_oMoveDamageScoreImageRectTransform11.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition12
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform12 != null)
			{
				return _oMoveDamageScoreImageRectTransform12.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition12 != value && _oMoveDamageScoreImageRectTransform12 != null)
			{
				_oMoveDamageScoreImageRectTransform12.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition13
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform13 != null)
			{
				return _oMoveDamageScoreImageRectTransform13.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition13 != value && _oMoveDamageScoreImageRectTransform13 != null)
			{
				_oMoveDamageScoreImageRectTransform13.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition14
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform14 != null)
			{
				return _oMoveDamageScoreImageRectTransform14.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition14 != value && _oMoveDamageScoreImageRectTransform14 != null)
			{
				_oMoveDamageScoreImageRectTransform14.localPosition = value;
			}
		}
	}

	public Vector3 MoveDamageScoreImagePosition15
	{
		get
		{
			if (_oMoveDamageScoreImageRectTransform15 != null)
			{
				return _oMoveDamageScoreImageRectTransform15.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageScoreImagePosition15 != value && _oMoveDamageScoreImageRectTransform15 != null)
			{
				_oMoveDamageScoreImageRectTransform15.localPosition = value;
			}
		}
	}

	public bool MoveDamageFragmentShow
	{
		get
		{
			if (_oMoveDamageFragment != null)
			{
				return _oMoveDamageFragment.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MoveDamageFragmentShow != value && _oMoveDamageFragment != null)
			{
				_oMoveDamageFragment.SetObjectActive(value);
			}
		}
	}

	public Vector3 MoveDamageFragmentPosition
	{
		get
		{
			if (_oMoveDamageFragmentRectTransform != null)
			{
				return _oMoveDamageFragmentRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MoveDamageFragmentPosition != value && _oMoveDamageFragmentRectTransform != null)
			{
				_oMoveDamageFragmentRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 WaitEffectMaskPosition
	{
		get
		{
			if (_oWaitEffectMaskRectTransform != null)
			{
				return _oWaitEffectMaskRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WaitEffectMaskPosition != value && _oWaitEffectMaskRectTransform != null)
			{
				_oWaitEffectMaskRectTransform.localPosition = value;
			}
		}
	}

	public bool WaitEffectImageShow
	{
		get
		{
			if (_oWaitEffectImage != null)
			{
				return _oWaitEffectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitEffectImageShow != value && _oWaitEffectImage != null)
			{
				_oWaitEffectImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 WaitEffectImagePosition
	{
		get
		{
			if (_oWaitEffectImageRectTransform != null)
			{
				return _oWaitEffectImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WaitEffectImagePosition != value && _oWaitEffectImageRectTransform != null)
			{
				_oWaitEffectImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 ScoreEffectImagePosition
	{
		get
		{
			if (_oScoreEffectImageRectTransform != null)
			{
				return _oScoreEffectImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScoreEffectImagePosition != value && _oScoreEffectImageRectTransform != null)
			{
				_oScoreEffectImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 ScoreEffectImageScale
	{
		get
		{
			if (_oScoreEffectImageRectTransform != null)
			{
				return _oScoreEffectImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScoreEffectImageScale != value && _oScoreEffectImageRectTransform != null)
			{
				_oScoreEffectImageRectTransform.localScale = value;
			}
		}
	}

	public float ScoreEffectImageAlpha
	{
		get
		{
			if (_oScoreEffectImageCanvasGroup != null)
			{
				return _oScoreEffectImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ScoreEffectImageAlpha != value && _oScoreEffectImageCanvasGroup != null)
			{
				_oScoreEffectImageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite ScoreEffectImageSprite
	{
		get
		{
			if (_oScoreEffectImageImage != null)
			{
				return _oScoreEffectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ScoreEffectImageSprite != value && _oScoreEffectImageImage != null)
			{
				_oScoreEffectImageImage.sprite = value;
			}
		}
	}

	public bool FragmentCountShow
	{
		get
		{
			if (_oFragmentCount != null)
			{
				return _oFragmentCount.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FragmentCountShow != value && _oFragmentCount != null)
			{
				_oFragmentCount.SetObjectActive(value);
			}
		}
	}

	public string FragmentCountTextString
	{
		get
		{
			if (_oFragmentCountTextText != null)
			{
				return _oFragmentCountTextText.text;
			}
			return null;
		}
		set
		{
			if (FragmentCountTextString != value && _oFragmentCountTextText != null)
			{
				_oFragmentCountTextText.text = value;
			}
		}
	}

	public bool BioDamageShow
	{
		get
		{
			if (_oBioDamage != null)
			{
				return _oBioDamage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BioDamageShow != value && _oBioDamage != null)
			{
				_oBioDamage.SetObjectActive(value);
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
			case "DamageScoreImage1":
				_oDamageScoreImage1 = transform.gameObject;
				_oDamageScoreImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage2":
				_oDamageScoreImage2 = transform.gameObject;
				_oDamageScoreImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage3":
				_oDamageScoreImage3 = transform.gameObject;
				_oDamageScoreImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage4":
				_oDamageScoreImage4 = transform.gameObject;
				_oDamageScoreImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage5":
				_oDamageScoreImage5 = transform.gameObject;
				_oDamageScoreImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage6":
				_oDamageScoreImage6 = transform.gameObject;
				_oDamageScoreImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage7":
				_oDamageScoreImage7 = transform.gameObject;
				_oDamageScoreImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage8":
				_oDamageScoreImage8 = transform.gameObject;
				_oDamageScoreImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage9":
				_oDamageScoreImage9 = transform.gameObject;
				_oDamageScoreImageImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage10":
				_oDamageScoreImage10 = transform.gameObject;
				_oDamageScoreImageImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage11":
				_oDamageScoreImage11 = transform.gameObject;
				_oDamageScoreImageImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage12":
				_oDamageScoreImage12 = transform.gameObject;
				_oDamageScoreImageImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage13":
				_oDamageScoreImage13 = transform.gameObject;
				_oDamageScoreImageImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage14":
				_oDamageScoreImage14 = transform.gameObject;
				_oDamageScoreImageImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage15":
				_oDamageScoreImage15 = transform.gameObject;
				_oDamageScoreImageImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage16":
				_oDamageScoreImage16 = transform.gameObject;
				_oDamageScoreImageImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage17":
				_oDamageScoreImage17 = transform.gameObject;
				_oDamageScoreImageImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage18":
				_oDamageScoreImage18 = transform.gameObject;
				_oDamageScoreImageImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage19":
				_oDamageScoreImage19 = transform.gameObject;
				_oDamageScoreImageImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImage20":
				_oDamageScoreImage20 = transform.gameObject;
				_oDamageScoreImageImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage1":
				_oDamageScoreEffectImage1 = transform.gameObject;
				_oDamageScoreEffectImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage2":
				_oDamageScoreEffectImage2 = transform.gameObject;
				_oDamageScoreEffectImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage3":
				_oDamageScoreEffectImage3 = transform.gameObject;
				_oDamageScoreEffectImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage4":
				_oDamageScoreEffectImage4 = transform.gameObject;
				_oDamageScoreEffectImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage5":
				_oDamageScoreEffectImage5 = transform.gameObject;
				_oDamageScoreEffectImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage6":
				_oDamageScoreEffectImage6 = transform.gameObject;
				_oDamageScoreEffectImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage7":
				_oDamageScoreEffectImage7 = transform.gameObject;
				_oDamageScoreEffectImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage8":
				_oDamageScoreEffectImage8 = transform.gameObject;
				_oDamageScoreEffectImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage9":
				_oDamageScoreEffectImage9 = transform.gameObject;
				_oDamageScoreEffectImageImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage10":
				_oDamageScoreEffectImage10 = transform.gameObject;
				_oDamageScoreEffectImageImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage11":
				_oDamageScoreEffectImage11 = transform.gameObject;
				_oDamageScoreEffectImageImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage12":
				_oDamageScoreEffectImage12 = transform.gameObject;
				_oDamageScoreEffectImageImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage13":
				_oDamageScoreEffectImage13 = transform.gameObject;
				_oDamageScoreEffectImageImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage14":
				_oDamageScoreEffectImage14 = transform.gameObject;
				_oDamageScoreEffectImageImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage15":
				_oDamageScoreEffectImage15 = transform.gameObject;
				_oDamageScoreEffectImageImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage16":
				_oDamageScoreEffectImage16 = transform.gameObject;
				_oDamageScoreEffectImageImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage17":
				_oDamageScoreEffectImage17 = transform.gameObject;
				_oDamageScoreEffectImageImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage18":
				_oDamageScoreEffectImage18 = transform.gameObject;
				_oDamageScoreEffectImageImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage19":
				_oDamageScoreEffectImage19 = transform.gameObject;
				_oDamageScoreEffectImageImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreEffectImage20":
				_oDamageScoreEffectImage20 = transform.gameObject;
				_oDamageScoreEffectImageImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageScoreImageFragment":
				_oDamageScoreImageFragment = transform.gameObject;
				_oDamageScoreImageFragmentRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage1":
				_oMoveDamageScoreImage1 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage2":
				_oMoveDamageScoreImage2 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage3":
				_oMoveDamageScoreImage3 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage4":
				_oMoveDamageScoreImage4 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage5":
				_oMoveDamageScoreImage5 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage6":
				_oMoveDamageScoreImage6 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage7":
				_oMoveDamageScoreImage7 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage8":
				_oMoveDamageScoreImage8 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage9":
				_oMoveDamageScoreImage9 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage10":
				_oMoveDamageScoreImage10 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage11":
				_oMoveDamageScoreImage11 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage12":
				_oMoveDamageScoreImage12 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage13":
				_oMoveDamageScoreImage13 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage14":
				_oMoveDamageScoreImage14 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform14 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageScoreImage15":
				_oMoveDamageScoreImage15 = transform.gameObject;
				_oMoveDamageScoreImageRectTransform15 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MoveDamageFragment":
				_oMoveDamageFragment = transform.gameObject;
				_oMoveDamageFragmentRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "WaitEffectMask":
				_oWaitEffectMask = transform.gameObject;
				_oWaitEffectMaskRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "WaitEffectImage":
				_oWaitEffectImage = transform.gameObject;
				_oWaitEffectImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ScoreEffectImage":
				_oScoreEffectImage = transform.gameObject;
				_oScoreEffectImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oScoreEffectImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oScoreEffectImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "FragmentCount":
				_oFragmentCount = transform.gameObject;
				break;
			case "FragmentCountText":
				_oFragmentCountText = transform.gameObject;
				_oFragmentCountTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "BioDamage":
				_oBioDamage = transform.gameObject;
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

	public bool GetDamageScoreImageShow(int index)
	{
		return index switch
		{
			1 => DamageScoreImageShow1, 
			2 => DamageScoreImageShow2, 
			3 => DamageScoreImageShow3, 
			4 => DamageScoreImageShow4, 
			5 => DamageScoreImageShow5, 
			6 => DamageScoreImageShow6, 
			7 => DamageScoreImageShow7, 
			8 => DamageScoreImageShow8, 
			9 => DamageScoreImageShow9, 
			10 => DamageScoreImageShow10, 
			11 => DamageScoreImageShow11, 
			12 => DamageScoreImageShow12, 
			13 => DamageScoreImageShow13, 
			14 => DamageScoreImageShow14, 
			15 => DamageScoreImageShow15, 
			16 => DamageScoreImageShow16, 
			17 => DamageScoreImageShow17, 
			18 => DamageScoreImageShow18, 
			19 => DamageScoreImageShow19, 
			20 => DamageScoreImageShow20, 
			_ => false, 
		};
	}

	public void SetDamageScoreImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DamageScoreImageShow1 = value;
			break;
		case 2:
			DamageScoreImageShow2 = value;
			break;
		case 3:
			DamageScoreImageShow3 = value;
			break;
		case 4:
			DamageScoreImageShow4 = value;
			break;
		case 5:
			DamageScoreImageShow5 = value;
			break;
		case 6:
			DamageScoreImageShow6 = value;
			break;
		case 7:
			DamageScoreImageShow7 = value;
			break;
		case 8:
			DamageScoreImageShow8 = value;
			break;
		case 9:
			DamageScoreImageShow9 = value;
			break;
		case 10:
			DamageScoreImageShow10 = value;
			break;
		case 11:
			DamageScoreImageShow11 = value;
			break;
		case 12:
			DamageScoreImageShow12 = value;
			break;
		case 13:
			DamageScoreImageShow13 = value;
			break;
		case 14:
			DamageScoreImageShow14 = value;
			break;
		case 15:
			DamageScoreImageShow15 = value;
			break;
		case 16:
			DamageScoreImageShow16 = value;
			break;
		case 17:
			DamageScoreImageShow17 = value;
			break;
		case 18:
			DamageScoreImageShow18 = value;
			break;
		case 19:
			DamageScoreImageShow19 = value;
			break;
		case 20:
			DamageScoreImageShow20 = value;
			break;
		}
	}

	public Sprite GetDamageScoreImageSprite(int index)
	{
		return index switch
		{
			1 => DamageScoreImageSprite1, 
			2 => DamageScoreImageSprite2, 
			3 => DamageScoreImageSprite3, 
			4 => DamageScoreImageSprite4, 
			5 => DamageScoreImageSprite5, 
			6 => DamageScoreImageSprite6, 
			7 => DamageScoreImageSprite7, 
			8 => DamageScoreImageSprite8, 
			9 => DamageScoreImageSprite9, 
			10 => DamageScoreImageSprite10, 
			11 => DamageScoreImageSprite11, 
			12 => DamageScoreImageSprite12, 
			13 => DamageScoreImageSprite13, 
			14 => DamageScoreImageSprite14, 
			15 => DamageScoreImageSprite15, 
			16 => DamageScoreImageSprite16, 
			17 => DamageScoreImageSprite17, 
			18 => DamageScoreImageSprite18, 
			19 => DamageScoreImageSprite19, 
			20 => DamageScoreImageSprite20, 
			_ => null, 
		};
	}

	public void SetDamageScoreImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			DamageScoreImageSprite1 = value;
			break;
		case 2:
			DamageScoreImageSprite2 = value;
			break;
		case 3:
			DamageScoreImageSprite3 = value;
			break;
		case 4:
			DamageScoreImageSprite4 = value;
			break;
		case 5:
			DamageScoreImageSprite5 = value;
			break;
		case 6:
			DamageScoreImageSprite6 = value;
			break;
		case 7:
			DamageScoreImageSprite7 = value;
			break;
		case 8:
			DamageScoreImageSprite8 = value;
			break;
		case 9:
			DamageScoreImageSprite9 = value;
			break;
		case 10:
			DamageScoreImageSprite10 = value;
			break;
		case 11:
			DamageScoreImageSprite11 = value;
			break;
		case 12:
			DamageScoreImageSprite12 = value;
			break;
		case 13:
			DamageScoreImageSprite13 = value;
			break;
		case 14:
			DamageScoreImageSprite14 = value;
			break;
		case 15:
			DamageScoreImageSprite15 = value;
			break;
		case 16:
			DamageScoreImageSprite16 = value;
			break;
		case 17:
			DamageScoreImageSprite17 = value;
			break;
		case 18:
			DamageScoreImageSprite18 = value;
			break;
		case 19:
			DamageScoreImageSprite19 = value;
			break;
		case 20:
			DamageScoreImageSprite20 = value;
			break;
		}
	}

	public bool GetDamageScoreEffectImageShow(int index)
	{
		return index switch
		{
			1 => DamageScoreEffectImageShow1, 
			2 => DamageScoreEffectImageShow2, 
			3 => DamageScoreEffectImageShow3, 
			4 => DamageScoreEffectImageShow4, 
			5 => DamageScoreEffectImageShow5, 
			6 => DamageScoreEffectImageShow6, 
			7 => DamageScoreEffectImageShow7, 
			8 => DamageScoreEffectImageShow8, 
			9 => DamageScoreEffectImageShow9, 
			10 => DamageScoreEffectImageShow10, 
			11 => DamageScoreEffectImageShow11, 
			12 => DamageScoreEffectImageShow12, 
			13 => DamageScoreEffectImageShow13, 
			14 => DamageScoreEffectImageShow14, 
			15 => DamageScoreEffectImageShow15, 
			16 => DamageScoreEffectImageShow16, 
			17 => DamageScoreEffectImageShow17, 
			18 => DamageScoreEffectImageShow18, 
			19 => DamageScoreEffectImageShow19, 
			20 => DamageScoreEffectImageShow20, 
			_ => false, 
		};
	}

	public void SetDamageScoreEffectImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DamageScoreEffectImageShow1 = value;
			break;
		case 2:
			DamageScoreEffectImageShow2 = value;
			break;
		case 3:
			DamageScoreEffectImageShow3 = value;
			break;
		case 4:
			DamageScoreEffectImageShow4 = value;
			break;
		case 5:
			DamageScoreEffectImageShow5 = value;
			break;
		case 6:
			DamageScoreEffectImageShow6 = value;
			break;
		case 7:
			DamageScoreEffectImageShow7 = value;
			break;
		case 8:
			DamageScoreEffectImageShow8 = value;
			break;
		case 9:
			DamageScoreEffectImageShow9 = value;
			break;
		case 10:
			DamageScoreEffectImageShow10 = value;
			break;
		case 11:
			DamageScoreEffectImageShow11 = value;
			break;
		case 12:
			DamageScoreEffectImageShow12 = value;
			break;
		case 13:
			DamageScoreEffectImageShow13 = value;
			break;
		case 14:
			DamageScoreEffectImageShow14 = value;
			break;
		case 15:
			DamageScoreEffectImageShow15 = value;
			break;
		case 16:
			DamageScoreEffectImageShow16 = value;
			break;
		case 17:
			DamageScoreEffectImageShow17 = value;
			break;
		case 18:
			DamageScoreEffectImageShow18 = value;
			break;
		case 19:
			DamageScoreEffectImageShow19 = value;
			break;
		case 20:
			DamageScoreEffectImageShow20 = value;
			break;
		}
	}

	public Sprite GetDamageScoreEffectImageSprite(int index)
	{
		return index switch
		{
			1 => DamageScoreEffectImageSprite1, 
			2 => DamageScoreEffectImageSprite2, 
			3 => DamageScoreEffectImageSprite3, 
			4 => DamageScoreEffectImageSprite4, 
			5 => DamageScoreEffectImageSprite5, 
			6 => DamageScoreEffectImageSprite6, 
			7 => DamageScoreEffectImageSprite7, 
			8 => DamageScoreEffectImageSprite8, 
			9 => DamageScoreEffectImageSprite9, 
			10 => DamageScoreEffectImageSprite10, 
			11 => DamageScoreEffectImageSprite11, 
			12 => DamageScoreEffectImageSprite12, 
			13 => DamageScoreEffectImageSprite13, 
			14 => DamageScoreEffectImageSprite14, 
			15 => DamageScoreEffectImageSprite15, 
			16 => DamageScoreEffectImageSprite16, 
			17 => DamageScoreEffectImageSprite17, 
			18 => DamageScoreEffectImageSprite18, 
			19 => DamageScoreEffectImageSprite19, 
			20 => DamageScoreEffectImageSprite20, 
			_ => null, 
		};
	}

	public void SetDamageScoreEffectImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			DamageScoreEffectImageSprite1 = value;
			break;
		case 2:
			DamageScoreEffectImageSprite2 = value;
			break;
		case 3:
			DamageScoreEffectImageSprite3 = value;
			break;
		case 4:
			DamageScoreEffectImageSprite4 = value;
			break;
		case 5:
			DamageScoreEffectImageSprite5 = value;
			break;
		case 6:
			DamageScoreEffectImageSprite6 = value;
			break;
		case 7:
			DamageScoreEffectImageSprite7 = value;
			break;
		case 8:
			DamageScoreEffectImageSprite8 = value;
			break;
		case 9:
			DamageScoreEffectImageSprite9 = value;
			break;
		case 10:
			DamageScoreEffectImageSprite10 = value;
			break;
		case 11:
			DamageScoreEffectImageSprite11 = value;
			break;
		case 12:
			DamageScoreEffectImageSprite12 = value;
			break;
		case 13:
			DamageScoreEffectImageSprite13 = value;
			break;
		case 14:
			DamageScoreEffectImageSprite14 = value;
			break;
		case 15:
			DamageScoreEffectImageSprite15 = value;
			break;
		case 16:
			DamageScoreEffectImageSprite16 = value;
			break;
		case 17:
			DamageScoreEffectImageSprite17 = value;
			break;
		case 18:
			DamageScoreEffectImageSprite18 = value;
			break;
		case 19:
			DamageScoreEffectImageSprite19 = value;
			break;
		case 20:
			DamageScoreEffectImageSprite20 = value;
			break;
		}
	}

	public bool GetMoveDamageScoreImageShow(int index)
	{
		return index switch
		{
			1 => MoveDamageScoreImageShow1, 
			2 => MoveDamageScoreImageShow2, 
			3 => MoveDamageScoreImageShow3, 
			4 => MoveDamageScoreImageShow4, 
			5 => MoveDamageScoreImageShow5, 
			6 => MoveDamageScoreImageShow6, 
			7 => MoveDamageScoreImageShow7, 
			8 => MoveDamageScoreImageShow8, 
			9 => MoveDamageScoreImageShow9, 
			10 => MoveDamageScoreImageShow10, 
			11 => MoveDamageScoreImageShow11, 
			12 => MoveDamageScoreImageShow12, 
			13 => MoveDamageScoreImageShow13, 
			14 => MoveDamageScoreImageShow14, 
			15 => MoveDamageScoreImageShow15, 
			_ => false, 
		};
	}

	public void SetMoveDamageScoreImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MoveDamageScoreImageShow1 = value;
			break;
		case 2:
			MoveDamageScoreImageShow2 = value;
			break;
		case 3:
			MoveDamageScoreImageShow3 = value;
			break;
		case 4:
			MoveDamageScoreImageShow4 = value;
			break;
		case 5:
			MoveDamageScoreImageShow5 = value;
			break;
		case 6:
			MoveDamageScoreImageShow6 = value;
			break;
		case 7:
			MoveDamageScoreImageShow7 = value;
			break;
		case 8:
			MoveDamageScoreImageShow8 = value;
			break;
		case 9:
			MoveDamageScoreImageShow9 = value;
			break;
		case 10:
			MoveDamageScoreImageShow10 = value;
			break;
		case 11:
			MoveDamageScoreImageShow11 = value;
			break;
		case 12:
			MoveDamageScoreImageShow12 = value;
			break;
		case 13:
			MoveDamageScoreImageShow13 = value;
			break;
		case 14:
			MoveDamageScoreImageShow14 = value;
			break;
		case 15:
			MoveDamageScoreImageShow15 = value;
			break;
		}
	}

	public Vector3 GetMoveDamageScoreImagePosition(int index)
	{
		return index switch
		{
			1 => MoveDamageScoreImagePosition1, 
			2 => MoveDamageScoreImagePosition2, 
			3 => MoveDamageScoreImagePosition3, 
			4 => MoveDamageScoreImagePosition4, 
			5 => MoveDamageScoreImagePosition5, 
			6 => MoveDamageScoreImagePosition6, 
			7 => MoveDamageScoreImagePosition7, 
			8 => MoveDamageScoreImagePosition8, 
			9 => MoveDamageScoreImagePosition9, 
			10 => MoveDamageScoreImagePosition10, 
			11 => MoveDamageScoreImagePosition11, 
			12 => MoveDamageScoreImagePosition12, 
			13 => MoveDamageScoreImagePosition13, 
			14 => MoveDamageScoreImagePosition14, 
			15 => MoveDamageScoreImagePosition15, 
			_ => Vector3.zero, 
		};
	}

	public void SetMoveDamageScoreImagePosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			MoveDamageScoreImagePosition1 = value;
			break;
		case 2:
			MoveDamageScoreImagePosition2 = value;
			break;
		case 3:
			MoveDamageScoreImagePosition3 = value;
			break;
		case 4:
			MoveDamageScoreImagePosition4 = value;
			break;
		case 5:
			MoveDamageScoreImagePosition5 = value;
			break;
		case 6:
			MoveDamageScoreImagePosition6 = value;
			break;
		case 7:
			MoveDamageScoreImagePosition7 = value;
			break;
		case 8:
			MoveDamageScoreImagePosition8 = value;
			break;
		case 9:
			MoveDamageScoreImagePosition9 = value;
			break;
		case 10:
			MoveDamageScoreImagePosition10 = value;
			break;
		case 11:
			MoveDamageScoreImagePosition11 = value;
			break;
		case 12:
			MoveDamageScoreImagePosition12 = value;
			break;
		case 13:
			MoveDamageScoreImagePosition13 = value;
			break;
		case 14:
			MoveDamageScoreImagePosition14 = value;
			break;
		case 15:
			MoveDamageScoreImagePosition15 = value;
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
