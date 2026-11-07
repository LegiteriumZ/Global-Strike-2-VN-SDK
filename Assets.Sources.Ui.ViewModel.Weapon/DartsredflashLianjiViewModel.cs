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
public class DartsredflashLianjiViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _oProgessBack;

	private Image _oProgessBackImage;

	private GameObject _oProgess;

	private Image _oProgessImage;

	private GameObject _oCountItem1;

	private GameObject _oCountItem2;

	private GameObject _oCountItem3;

	private GameObject _oCountItem4;

	private GameObject _oCountItem5;

	private GameObject _oCountItem6;

	private GameObject _oCountItem7;

	private GameObject _oCountItem8;

	private GameObject _oCountItem9;

	private GameObject _oCountItem10;

	private GameObject _oCountItem11;

	private GameObject _oCountItem12;

	private GameObject _oCountItem13;

	private GameObject _oCountItem14;

	private GameObject _oCountItem15;

	private GameObject _oCountItem16;

	private GameObject _oCountItem17;

	private GameObject _oCountItem18;

	private GameObject _oCountItem19;

	private GameObject _oCountItem20;

	private Image _oCountItemImage1;

	private Image _oCountItemImage2;

	private Image _oCountItemImage3;

	private Image _oCountItemImage4;

	private Image _oCountItemImage5;

	private Image _oCountItemImage6;

	private Image _oCountItemImage7;

	private Image _oCountItemImage8;

	private Image _oCountItemImage9;

	private Image _oCountItemImage10;

	private Image _oCountItemImage11;

	private Image _oCountItemImage12;

	private Image _oCountItemImage13;

	private Image _oCountItemImage14;

	private Image _oCountItemImage15;

	private Image _oCountItemImage16;

	private Image _oCountItemImage17;

	private Image _oCountItemImage18;

	private Image _oCountItemImage19;

	private Image _oCountItemImage20;

	private GameObject _oCount1;

	private GameObject _oCount2;

	private GameObject _oCount3;

	private GameObject _oCount4;

	private GameObject _oCount5;

	private GameObject _oCount6;

	private GameObject _oCount7;

	private GameObject _oCount8;

	private GameObject _oCount9;

	private GameObject _oCount10;

	private GameObject _oCount11;

	private GameObject _oCount12;

	private GameObject _oCount13;

	private GameObject _oCount14;

	private GameObject _oCount15;

	private GameObject _oCount16;

	private GameObject _oCount17;

	private GameObject _oCount18;

	private GameObject _oCount19;

	private GameObject _oCount20;

	private Image _oCountImage1;

	private Image _oCountImage2;

	private Image _oCountImage3;

	private Image _oCountImage4;

	private Image _oCountImage5;

	private Image _oCountImage6;

	private Image _oCountImage7;

	private Image _oCountImage8;

	private Image _oCountImage9;

	private Image _oCountImage10;

	private Image _oCountImage11;

	private Image _oCountImage12;

	private Image _oCountImage13;

	private Image _oCountImage14;

	private Image _oCountImage15;

	private Image _oCountImage16;

	private Image _oCountImage17;

	private Image _oCountImage18;

	private Image _oCountImage19;

	private Image _oCountImage20;

	private GameObject _oFail;

	private Image _oFailImage;

	private GameObject _oSuccess;

	private Image _oSuccessImage;

	private GameObject _oNumber;

	private RectTransform _oNumberRectTransform;

	private Text _oNumberText;

	private GameObject _oEffect;

	private Image _oEffectImage;

	private GameObject _viewGameObject;

	private bool _ShowHere = true;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "DartsredflashLianji";

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

	public bool ShowHere
	{
		get
		{
			return _ShowHere;
		}
		set
		{
			if (ShowHere != value && _oShowRectTransform != null)
			{
				_ShowHere = value;
				if (value)
				{
					_oShowRectTransform.localPosition -= new Vector3(10000f, 10000f, 0f);
				}
				else
				{
					_oShowRectTransform.localPosition += new Vector3(10000f, 10000f, 0f);
				}
			}
		}
	}

	public Sprite ProgessBackSprite
	{
		get
		{
			if (_oProgessBackImage != null)
			{
				return _oProgessBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessBackSprite != value && _oProgessBackImage != null)
			{
				_oProgessBackImage.sprite = value;
			}
		}
	}

	public Sprite ProgessSprite
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessSprite != value && _oProgessImage != null)
			{
				_oProgessImage.sprite = value;
			}
		}
	}

	public float ProgessFillamount
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgessFillamount != value && _oProgessImage != null)
			{
				_oProgessImage.fillAmount = value;
			}
		}
	}

	public Sprite CountItemSprite1
	{
		get
		{
			if (_oCountItemImage1 != null)
			{
				return _oCountItemImage1.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite1 != value && _oCountItemImage1 != null)
			{
				_oCountItemImage1.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite2
	{
		get
		{
			if (_oCountItemImage2 != null)
			{
				return _oCountItemImage2.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite2 != value && _oCountItemImage2 != null)
			{
				_oCountItemImage2.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite3
	{
		get
		{
			if (_oCountItemImage3 != null)
			{
				return _oCountItemImage3.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite3 != value && _oCountItemImage3 != null)
			{
				_oCountItemImage3.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite4
	{
		get
		{
			if (_oCountItemImage4 != null)
			{
				return _oCountItemImage4.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite4 != value && _oCountItemImage4 != null)
			{
				_oCountItemImage4.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite5
	{
		get
		{
			if (_oCountItemImage5 != null)
			{
				return _oCountItemImage5.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite5 != value && _oCountItemImage5 != null)
			{
				_oCountItemImage5.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite6
	{
		get
		{
			if (_oCountItemImage6 != null)
			{
				return _oCountItemImage6.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite6 != value && _oCountItemImage6 != null)
			{
				_oCountItemImage6.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite7
	{
		get
		{
			if (_oCountItemImage7 != null)
			{
				return _oCountItemImage7.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite7 != value && _oCountItemImage7 != null)
			{
				_oCountItemImage7.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite8
	{
		get
		{
			if (_oCountItemImage8 != null)
			{
				return _oCountItemImage8.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite8 != value && _oCountItemImage8 != null)
			{
				_oCountItemImage8.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite9
	{
		get
		{
			if (_oCountItemImage9 != null)
			{
				return _oCountItemImage9.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite9 != value && _oCountItemImage9 != null)
			{
				_oCountItemImage9.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite10
	{
		get
		{
			if (_oCountItemImage10 != null)
			{
				return _oCountItemImage10.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite10 != value && _oCountItemImage10 != null)
			{
				_oCountItemImage10.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite11
	{
		get
		{
			if (_oCountItemImage11 != null)
			{
				return _oCountItemImage11.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite11 != value && _oCountItemImage11 != null)
			{
				_oCountItemImage11.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite12
	{
		get
		{
			if (_oCountItemImage12 != null)
			{
				return _oCountItemImage12.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite12 != value && _oCountItemImage12 != null)
			{
				_oCountItemImage12.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite13
	{
		get
		{
			if (_oCountItemImage13 != null)
			{
				return _oCountItemImage13.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite13 != value && _oCountItemImage13 != null)
			{
				_oCountItemImage13.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite14
	{
		get
		{
			if (_oCountItemImage14 != null)
			{
				return _oCountItemImage14.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite14 != value && _oCountItemImage14 != null)
			{
				_oCountItemImage14.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite15
	{
		get
		{
			if (_oCountItemImage15 != null)
			{
				return _oCountItemImage15.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite15 != value && _oCountItemImage15 != null)
			{
				_oCountItemImage15.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite16
	{
		get
		{
			if (_oCountItemImage16 != null)
			{
				return _oCountItemImage16.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite16 != value && _oCountItemImage16 != null)
			{
				_oCountItemImage16.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite17
	{
		get
		{
			if (_oCountItemImage17 != null)
			{
				return _oCountItemImage17.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite17 != value && _oCountItemImage17 != null)
			{
				_oCountItemImage17.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite18
	{
		get
		{
			if (_oCountItemImage18 != null)
			{
				return _oCountItemImage18.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite18 != value && _oCountItemImage18 != null)
			{
				_oCountItemImage18.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite19
	{
		get
		{
			if (_oCountItemImage19 != null)
			{
				return _oCountItemImage19.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite19 != value && _oCountItemImage19 != null)
			{
				_oCountItemImage19.sprite = value;
			}
		}
	}

	public Sprite CountItemSprite20
	{
		get
		{
			if (_oCountItemImage20 != null)
			{
				return _oCountItemImage20.sprite;
			}
			return null;
		}
		set
		{
			if (CountItemSprite20 != value && _oCountItemImage20 != null)
			{
				_oCountItemImage20.sprite = value;
			}
		}
	}

	public bool CountShow1
	{
		get
		{
			if (_oCount1 != null)
			{
				return _oCount1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow1 != value && _oCount1 != null)
			{
				_oCount1.SetObjectActive(value);
			}
		}
	}

	public bool CountShow2
	{
		get
		{
			if (_oCount2 != null)
			{
				return _oCount2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow2 != value && _oCount2 != null)
			{
				_oCount2.SetObjectActive(value);
			}
		}
	}

	public bool CountShow3
	{
		get
		{
			if (_oCount3 != null)
			{
				return _oCount3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow3 != value && _oCount3 != null)
			{
				_oCount3.SetObjectActive(value);
			}
		}
	}

	public bool CountShow4
	{
		get
		{
			if (_oCount4 != null)
			{
				return _oCount4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow4 != value && _oCount4 != null)
			{
				_oCount4.SetObjectActive(value);
			}
		}
	}

	public bool CountShow5
	{
		get
		{
			if (_oCount5 != null)
			{
				return _oCount5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow5 != value && _oCount5 != null)
			{
				_oCount5.SetObjectActive(value);
			}
		}
	}

	public bool CountShow6
	{
		get
		{
			if (_oCount6 != null)
			{
				return _oCount6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow6 != value && _oCount6 != null)
			{
				_oCount6.SetObjectActive(value);
			}
		}
	}

	public bool CountShow7
	{
		get
		{
			if (_oCount7 != null)
			{
				return _oCount7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow7 != value && _oCount7 != null)
			{
				_oCount7.SetObjectActive(value);
			}
		}
	}

	public bool CountShow8
	{
		get
		{
			if (_oCount8 != null)
			{
				return _oCount8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow8 != value && _oCount8 != null)
			{
				_oCount8.SetObjectActive(value);
			}
		}
	}

	public bool CountShow9
	{
		get
		{
			if (_oCount9 != null)
			{
				return _oCount9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow9 != value && _oCount9 != null)
			{
				_oCount9.SetObjectActive(value);
			}
		}
	}

	public bool CountShow10
	{
		get
		{
			if (_oCount10 != null)
			{
				return _oCount10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow10 != value && _oCount10 != null)
			{
				_oCount10.SetObjectActive(value);
			}
		}
	}

	public bool CountShow11
	{
		get
		{
			if (_oCount11 != null)
			{
				return _oCount11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow11 != value && _oCount11 != null)
			{
				_oCount11.SetObjectActive(value);
			}
		}
	}

	public bool CountShow12
	{
		get
		{
			if (_oCount12 != null)
			{
				return _oCount12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow12 != value && _oCount12 != null)
			{
				_oCount12.SetObjectActive(value);
			}
		}
	}

	public bool CountShow13
	{
		get
		{
			if (_oCount13 != null)
			{
				return _oCount13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow13 != value && _oCount13 != null)
			{
				_oCount13.SetObjectActive(value);
			}
		}
	}

	public bool CountShow14
	{
		get
		{
			if (_oCount14 != null)
			{
				return _oCount14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow14 != value && _oCount14 != null)
			{
				_oCount14.SetObjectActive(value);
			}
		}
	}

	public bool CountShow15
	{
		get
		{
			if (_oCount15 != null)
			{
				return _oCount15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow15 != value && _oCount15 != null)
			{
				_oCount15.SetObjectActive(value);
			}
		}
	}

	public bool CountShow16
	{
		get
		{
			if (_oCount16 != null)
			{
				return _oCount16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow16 != value && _oCount16 != null)
			{
				_oCount16.SetObjectActive(value);
			}
		}
	}

	public bool CountShow17
	{
		get
		{
			if (_oCount17 != null)
			{
				return _oCount17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow17 != value && _oCount17 != null)
			{
				_oCount17.SetObjectActive(value);
			}
		}
	}

	public bool CountShow18
	{
		get
		{
			if (_oCount18 != null)
			{
				return _oCount18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow18 != value && _oCount18 != null)
			{
				_oCount18.SetObjectActive(value);
			}
		}
	}

	public bool CountShow19
	{
		get
		{
			if (_oCount19 != null)
			{
				return _oCount19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow19 != value && _oCount19 != null)
			{
				_oCount19.SetObjectActive(value);
			}
		}
	}

	public bool CountShow20
	{
		get
		{
			if (_oCount20 != null)
			{
				return _oCount20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow20 != value && _oCount20 != null)
			{
				_oCount20.SetObjectActive(value);
			}
		}
	}

	public Sprite CountSprite1
	{
		get
		{
			if (_oCountImage1 != null)
			{
				return _oCountImage1.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite1 != value && _oCountImage1 != null)
			{
				_oCountImage1.sprite = value;
			}
		}
	}

	public Sprite CountSprite2
	{
		get
		{
			if (_oCountImage2 != null)
			{
				return _oCountImage2.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite2 != value && _oCountImage2 != null)
			{
				_oCountImage2.sprite = value;
			}
		}
	}

	public Sprite CountSprite3
	{
		get
		{
			if (_oCountImage3 != null)
			{
				return _oCountImage3.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite3 != value && _oCountImage3 != null)
			{
				_oCountImage3.sprite = value;
			}
		}
	}

	public Sprite CountSprite4
	{
		get
		{
			if (_oCountImage4 != null)
			{
				return _oCountImage4.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite4 != value && _oCountImage4 != null)
			{
				_oCountImage4.sprite = value;
			}
		}
	}

	public Sprite CountSprite5
	{
		get
		{
			if (_oCountImage5 != null)
			{
				return _oCountImage5.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite5 != value && _oCountImage5 != null)
			{
				_oCountImage5.sprite = value;
			}
		}
	}

	public Sprite CountSprite6
	{
		get
		{
			if (_oCountImage6 != null)
			{
				return _oCountImage6.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite6 != value && _oCountImage6 != null)
			{
				_oCountImage6.sprite = value;
			}
		}
	}

	public Sprite CountSprite7
	{
		get
		{
			if (_oCountImage7 != null)
			{
				return _oCountImage7.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite7 != value && _oCountImage7 != null)
			{
				_oCountImage7.sprite = value;
			}
		}
	}

	public Sprite CountSprite8
	{
		get
		{
			if (_oCountImage8 != null)
			{
				return _oCountImage8.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite8 != value && _oCountImage8 != null)
			{
				_oCountImage8.sprite = value;
			}
		}
	}

	public Sprite CountSprite9
	{
		get
		{
			if (_oCountImage9 != null)
			{
				return _oCountImage9.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite9 != value && _oCountImage9 != null)
			{
				_oCountImage9.sprite = value;
			}
		}
	}

	public Sprite CountSprite10
	{
		get
		{
			if (_oCountImage10 != null)
			{
				return _oCountImage10.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite10 != value && _oCountImage10 != null)
			{
				_oCountImage10.sprite = value;
			}
		}
	}

	public Sprite CountSprite11
	{
		get
		{
			if (_oCountImage11 != null)
			{
				return _oCountImage11.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite11 != value && _oCountImage11 != null)
			{
				_oCountImage11.sprite = value;
			}
		}
	}

	public Sprite CountSprite12
	{
		get
		{
			if (_oCountImage12 != null)
			{
				return _oCountImage12.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite12 != value && _oCountImage12 != null)
			{
				_oCountImage12.sprite = value;
			}
		}
	}

	public Sprite CountSprite13
	{
		get
		{
			if (_oCountImage13 != null)
			{
				return _oCountImage13.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite13 != value && _oCountImage13 != null)
			{
				_oCountImage13.sprite = value;
			}
		}
	}

	public Sprite CountSprite14
	{
		get
		{
			if (_oCountImage14 != null)
			{
				return _oCountImage14.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite14 != value && _oCountImage14 != null)
			{
				_oCountImage14.sprite = value;
			}
		}
	}

	public Sprite CountSprite15
	{
		get
		{
			if (_oCountImage15 != null)
			{
				return _oCountImage15.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite15 != value && _oCountImage15 != null)
			{
				_oCountImage15.sprite = value;
			}
		}
	}

	public Sprite CountSprite16
	{
		get
		{
			if (_oCountImage16 != null)
			{
				return _oCountImage16.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite16 != value && _oCountImage16 != null)
			{
				_oCountImage16.sprite = value;
			}
		}
	}

	public Sprite CountSprite17
	{
		get
		{
			if (_oCountImage17 != null)
			{
				return _oCountImage17.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite17 != value && _oCountImage17 != null)
			{
				_oCountImage17.sprite = value;
			}
		}
	}

	public Sprite CountSprite18
	{
		get
		{
			if (_oCountImage18 != null)
			{
				return _oCountImage18.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite18 != value && _oCountImage18 != null)
			{
				_oCountImage18.sprite = value;
			}
		}
	}

	public Sprite CountSprite19
	{
		get
		{
			if (_oCountImage19 != null)
			{
				return _oCountImage19.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite19 != value && _oCountImage19 != null)
			{
				_oCountImage19.sprite = value;
			}
		}
	}

	public Sprite CountSprite20
	{
		get
		{
			if (_oCountImage20 != null)
			{
				return _oCountImage20.sprite;
			}
			return null;
		}
		set
		{
			if (CountSprite20 != value && _oCountImage20 != null)
			{
				_oCountImage20.sprite = value;
			}
		}
	}

	public bool FailShow
	{
		get
		{
			if (_oFail != null)
			{
				return _oFail.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FailShow != value && _oFail != null)
			{
				_oFail.SetObjectActive(value);
			}
		}
	}

	public Sprite FailSprite
	{
		get
		{
			if (_oFailImage != null)
			{
				return _oFailImage.sprite;
			}
			return null;
		}
		set
		{
			if (FailSprite != value && _oFailImage != null)
			{
				_oFailImage.sprite = value;
			}
		}
	}

	public bool SuccessShow
	{
		get
		{
			if (_oSuccess != null)
			{
				return _oSuccess.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SuccessShow != value && _oSuccess != null)
			{
				_oSuccess.SetObjectActive(value);
			}
		}
	}

	public Sprite SuccessSprite
	{
		get
		{
			if (_oSuccessImage != null)
			{
				return _oSuccessImage.sprite;
			}
			return null;
		}
		set
		{
			if (SuccessSprite != value && _oSuccessImage != null)
			{
				_oSuccessImage.sprite = value;
			}
		}
	}

	public Vector3 NumberScale
	{
		get
		{
			if (_oNumberRectTransform != null)
			{
				return _oNumberRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (NumberScale != value && _oNumberRectTransform != null)
			{
				_oNumberRectTransform.localScale = value;
			}
		}
	}

	public string NumberString
	{
		get
		{
			if (_oNumberText != null)
			{
				return _oNumberText.text;
			}
			return null;
		}
		set
		{
			if (NumberString != value && _oNumberText != null)
			{
				_oNumberText.text = value;
			}
		}
	}

	public bool EffectShow
	{
		get
		{
			if (_oEffect != null)
			{
				return _oEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow != value && _oEffect != null)
			{
				_oEffect.SetObjectActive(value);
			}
		}
	}

	public Sprite EffectSprite
	{
		get
		{
			if (_oEffectImage != null)
			{
				return _oEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite != value && _oEffectImage != null)
			{
				_oEffectImage.sprite = value;
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
			case "ProgessBack":
				_oProgessBack = transform.gameObject;
				_oProgessBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progess":
				_oProgess = transform.gameObject;
				_oProgessImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem1":
				_oCountItem1 = transform.gameObject;
				_oCountItemImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem2":
				_oCountItem2 = transform.gameObject;
				_oCountItemImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem3":
				_oCountItem3 = transform.gameObject;
				_oCountItemImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem4":
				_oCountItem4 = transform.gameObject;
				_oCountItemImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem5":
				_oCountItem5 = transform.gameObject;
				_oCountItemImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem6":
				_oCountItem6 = transform.gameObject;
				_oCountItemImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem7":
				_oCountItem7 = transform.gameObject;
				_oCountItemImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem8":
				_oCountItem8 = transform.gameObject;
				_oCountItemImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem9":
				_oCountItem9 = transform.gameObject;
				_oCountItemImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem10":
				_oCountItem10 = transform.gameObject;
				_oCountItemImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem11":
				_oCountItem11 = transform.gameObject;
				_oCountItemImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem12":
				_oCountItem12 = transform.gameObject;
				_oCountItemImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem13":
				_oCountItem13 = transform.gameObject;
				_oCountItemImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem14":
				_oCountItem14 = transform.gameObject;
				_oCountItemImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem15":
				_oCountItem15 = transform.gameObject;
				_oCountItemImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem16":
				_oCountItem16 = transform.gameObject;
				_oCountItemImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem17":
				_oCountItem17 = transform.gameObject;
				_oCountItemImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem18":
				_oCountItem18 = transform.gameObject;
				_oCountItemImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem19":
				_oCountItem19 = transform.gameObject;
				_oCountItemImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountItem20":
				_oCountItem20 = transform.gameObject;
				_oCountItemImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count1":
				_oCount1 = transform.gameObject;
				_oCountImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count2":
				_oCount2 = transform.gameObject;
				_oCountImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count3":
				_oCount3 = transform.gameObject;
				_oCountImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count4":
				_oCount4 = transform.gameObject;
				_oCountImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count5":
				_oCount5 = transform.gameObject;
				_oCountImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count6":
				_oCount6 = transform.gameObject;
				_oCountImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count7":
				_oCount7 = transform.gameObject;
				_oCountImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count8":
				_oCount8 = transform.gameObject;
				_oCountImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count9":
				_oCount9 = transform.gameObject;
				_oCountImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count10":
				_oCount10 = transform.gameObject;
				_oCountImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count11":
				_oCount11 = transform.gameObject;
				_oCountImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count12":
				_oCount12 = transform.gameObject;
				_oCountImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count13":
				_oCount13 = transform.gameObject;
				_oCountImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count14":
				_oCount14 = transform.gameObject;
				_oCountImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count15":
				_oCount15 = transform.gameObject;
				_oCountImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count16":
				_oCount16 = transform.gameObject;
				_oCountImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count17":
				_oCount17 = transform.gameObject;
				_oCountImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count18":
				_oCount18 = transform.gameObject;
				_oCountImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count19":
				_oCount19 = transform.gameObject;
				_oCountImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count20":
				_oCount20 = transform.gameObject;
				_oCountImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "Fail":
				_oFail = transform.gameObject;
				_oFailImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Success":
				_oSuccess = transform.gameObject;
				_oSuccessImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Number":
				_oNumber = transform.gameObject;
				_oNumberRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "Effect":
				_oEffect = transform.gameObject;
				_oEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public Sprite GetCountItemSprite(int index)
	{
		return index switch
		{
			1 => CountItemSprite1, 
			2 => CountItemSprite2, 
			3 => CountItemSprite3, 
			4 => CountItemSprite4, 
			5 => CountItemSprite5, 
			6 => CountItemSprite6, 
			7 => CountItemSprite7, 
			8 => CountItemSprite8, 
			9 => CountItemSprite9, 
			10 => CountItemSprite10, 
			11 => CountItemSprite11, 
			12 => CountItemSprite12, 
			13 => CountItemSprite13, 
			14 => CountItemSprite14, 
			15 => CountItemSprite15, 
			16 => CountItemSprite16, 
			17 => CountItemSprite17, 
			18 => CountItemSprite18, 
			19 => CountItemSprite19, 
			20 => CountItemSprite20, 
			_ => null, 
		};
	}

	public void SetCountItemSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			CountItemSprite1 = value;
			break;
		case 2:
			CountItemSprite2 = value;
			break;
		case 3:
			CountItemSprite3 = value;
			break;
		case 4:
			CountItemSprite4 = value;
			break;
		case 5:
			CountItemSprite5 = value;
			break;
		case 6:
			CountItemSprite6 = value;
			break;
		case 7:
			CountItemSprite7 = value;
			break;
		case 8:
			CountItemSprite8 = value;
			break;
		case 9:
			CountItemSprite9 = value;
			break;
		case 10:
			CountItemSprite10 = value;
			break;
		case 11:
			CountItemSprite11 = value;
			break;
		case 12:
			CountItemSprite12 = value;
			break;
		case 13:
			CountItemSprite13 = value;
			break;
		case 14:
			CountItemSprite14 = value;
			break;
		case 15:
			CountItemSprite15 = value;
			break;
		case 16:
			CountItemSprite16 = value;
			break;
		case 17:
			CountItemSprite17 = value;
			break;
		case 18:
			CountItemSprite18 = value;
			break;
		case 19:
			CountItemSprite19 = value;
			break;
		case 20:
			CountItemSprite20 = value;
			break;
		}
	}

	public bool GetCountShow(int index)
	{
		return index switch
		{
			1 => CountShow1, 
			2 => CountShow2, 
			3 => CountShow3, 
			4 => CountShow4, 
			5 => CountShow5, 
			6 => CountShow6, 
			7 => CountShow7, 
			8 => CountShow8, 
			9 => CountShow9, 
			10 => CountShow10, 
			11 => CountShow11, 
			12 => CountShow12, 
			13 => CountShow13, 
			14 => CountShow14, 
			15 => CountShow15, 
			16 => CountShow16, 
			17 => CountShow17, 
			18 => CountShow18, 
			19 => CountShow19, 
			20 => CountShow20, 
			_ => false, 
		};
	}

	public void SetCountShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CountShow1 = value;
			break;
		case 2:
			CountShow2 = value;
			break;
		case 3:
			CountShow3 = value;
			break;
		case 4:
			CountShow4 = value;
			break;
		case 5:
			CountShow5 = value;
			break;
		case 6:
			CountShow6 = value;
			break;
		case 7:
			CountShow7 = value;
			break;
		case 8:
			CountShow8 = value;
			break;
		case 9:
			CountShow9 = value;
			break;
		case 10:
			CountShow10 = value;
			break;
		case 11:
			CountShow11 = value;
			break;
		case 12:
			CountShow12 = value;
			break;
		case 13:
			CountShow13 = value;
			break;
		case 14:
			CountShow14 = value;
			break;
		case 15:
			CountShow15 = value;
			break;
		case 16:
			CountShow16 = value;
			break;
		case 17:
			CountShow17 = value;
			break;
		case 18:
			CountShow18 = value;
			break;
		case 19:
			CountShow19 = value;
			break;
		case 20:
			CountShow20 = value;
			break;
		}
	}

	public Sprite GetCountSprite(int index)
	{
		return index switch
		{
			1 => CountSprite1, 
			2 => CountSprite2, 
			3 => CountSprite3, 
			4 => CountSprite4, 
			5 => CountSprite5, 
			6 => CountSprite6, 
			7 => CountSprite7, 
			8 => CountSprite8, 
			9 => CountSprite9, 
			10 => CountSprite10, 
			11 => CountSprite11, 
			12 => CountSprite12, 
			13 => CountSprite13, 
			14 => CountSprite14, 
			15 => CountSprite15, 
			16 => CountSprite16, 
			17 => CountSprite17, 
			18 => CountSprite18, 
			19 => CountSprite19, 
			20 => CountSprite20, 
			_ => null, 
		};
	}

	public void SetCountSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			CountSprite1 = value;
			break;
		case 2:
			CountSprite2 = value;
			break;
		case 3:
			CountSprite3 = value;
			break;
		case 4:
			CountSprite4 = value;
			break;
		case 5:
			CountSprite5 = value;
			break;
		case 6:
			CountSprite6 = value;
			break;
		case 7:
			CountSprite7 = value;
			break;
		case 8:
			CountSprite8 = value;
			break;
		case 9:
			CountSprite9 = value;
			break;
		case 10:
			CountSprite10 = value;
			break;
		case 11:
			CountSprite11 = value;
			break;
		case 12:
			CountSprite12 = value;
			break;
		case 13:
			CountSprite13 = value;
			break;
		case 14:
			CountSprite14 = value;
			break;
		case 15:
			CountSprite15 = value;
			break;
		case 16:
			CountSprite16 = value;
			break;
		case 17:
			CountSprite17 = value;
			break;
		case 18:
			CountSprite18 = value;
			break;
		case 19:
			CountSprite19 = value;
			break;
		case 20:
			CountSprite20 = value;
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
