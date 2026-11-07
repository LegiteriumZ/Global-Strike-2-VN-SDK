using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class CommonCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oType1;

	private GameObject _oType2;

	private GameObject _oType3;

	private GameObject _oType4;

	private GameObject _oType5;

	private GameObject _oType6;

	private GameObject _oCenter1;

	private GameObject _oCenter2;

	private GameObject _oCenter3;

	private GameObject _oCenter4;

	private GameObject _oCenter5;

	private GameObject _oCenter6;

	private RectTransform _oCenterRectTransform1;

	private RectTransform _oCenterRectTransform2;

	private RectTransform _oCenterRectTransform3;

	private RectTransform _oCenterRectTransform4;

	private RectTransform _oCenterRectTransform5;

	private RectTransform _oCenterRectTransform6;

	private Image _oCenterImage1;

	private Image _oCenterImage2;

	private Image _oCenterImage3;

	private Image _oCenterImage4;

	private Image _oCenterImage5;

	private Image _oCenterImage6;

	private GameObject _oCycle1;

	private GameObject _oCycle2;

	private GameObject _oCycle3;

	private GameObject _oCycle4;

	private GameObject _oCycle5;

	private GameObject _oCycle6;

	private RectTransform _oCycleRectTransform1;

	private RectTransform _oCycleRectTransform2;

	private RectTransform _oCycleRectTransform3;

	private RectTransform _oCycleRectTransform4;

	private RectTransform _oCycleRectTransform5;

	private RectTransform _oCycleRectTransform6;

	private Image _oCycleImage1;

	private Image _oCycleImage2;

	private Image _oCycleImage3;

	private Image _oCycleImage4;

	private Image _oCycleImage5;

	private Image _oCycleImage6;

	private GameObject _oUp1;

	private GameObject _oUp2;

	private GameObject _oUp3;

	private GameObject _oUp4;

	private GameObject _oUp5;

	private GameObject _oUp6;

	private RectTransform _oUpRectTransform1;

	private RectTransform _oUpRectTransform2;

	private RectTransform _oUpRectTransform3;

	private RectTransform _oUpRectTransform4;

	private RectTransform _oUpRectTransform5;

	private RectTransform _oUpRectTransform6;

	private Image _oUpImage1;

	private Image _oUpImage2;

	private Image _oUpImage3;

	private Image _oUpImage4;

	private Image _oUpImage5;

	private Image _oUpImage6;

	private GameObject _oDown1;

	private GameObject _oDown2;

	private GameObject _oDown3;

	private GameObject _oDown4;

	private GameObject _oDown5;

	private GameObject _oDown6;

	private RectTransform _oDownRectTransform1;

	private RectTransform _oDownRectTransform2;

	private RectTransform _oDownRectTransform3;

	private RectTransform _oDownRectTransform4;

	private RectTransform _oDownRectTransform5;

	private RectTransform _oDownRectTransform6;

	private Image _oDownImage1;

	private Image _oDownImage2;

	private Image _oDownImage3;

	private Image _oDownImage4;

	private Image _oDownImage5;

	private Image _oDownImage6;

	private GameObject _oLeft1;

	private GameObject _oLeft2;

	private GameObject _oLeft3;

	private GameObject _oLeft4;

	private GameObject _oLeft5;

	private GameObject _oLeft6;

	private RectTransform _oLeftRectTransform1;

	private RectTransform _oLeftRectTransform2;

	private RectTransform _oLeftRectTransform3;

	private RectTransform _oLeftRectTransform4;

	private RectTransform _oLeftRectTransform5;

	private RectTransform _oLeftRectTransform6;

	private Image _oLeftImage1;

	private Image _oLeftImage2;

	private Image _oLeftImage3;

	private Image _oLeftImage4;

	private Image _oLeftImage5;

	private Image _oLeftImage6;

	private GameObject _oRight1;

	private GameObject _oRight2;

	private GameObject _oRight3;

	private GameObject _oRight4;

	private GameObject _oRight5;

	private GameObject _oRight6;

	private RectTransform _oRightRectTransform1;

	private RectTransform _oRightRectTransform2;

	private RectTransform _oRightRectTransform3;

	private RectTransform _oRightRectTransform4;

	private RectTransform _oRightRectTransform5;

	private RectTransform _oRightRectTransform6;

	private Image _oRightImage1;

	private Image _oRightImage2;

	private Image _oRightImage3;

	private Image _oRightImage4;

	private Image _oRightImage5;

	private Image _oRightImage6;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "CommonCross";

	public GameObject ShowObj => _oShow;

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

	public bool TypeShow4
	{
		get
		{
			if (_oType4 != null)
			{
				return _oType4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow4 != value && _oType4 != null)
			{
				_oType4.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow5
	{
		get
		{
			if (_oType5 != null)
			{
				return _oType5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow5 != value && _oType5 != null)
			{
				_oType5.SetObjectActive(value);
			}
		}
	}

	public bool TypeShow6
	{
		get
		{
			if (_oType6 != null)
			{
				return _oType6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TypeShow6 != value && _oType6 != null)
			{
				_oType6.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow1
	{
		get
		{
			if (_oCenter1 != null)
			{
				return _oCenter1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow1 != value && _oCenter1 != null)
			{
				_oCenter1.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow2
	{
		get
		{
			if (_oCenter2 != null)
			{
				return _oCenter2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow2 != value && _oCenter2 != null)
			{
				_oCenter2.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow3
	{
		get
		{
			if (_oCenter3 != null)
			{
				return _oCenter3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow3 != value && _oCenter3 != null)
			{
				_oCenter3.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow4
	{
		get
		{
			if (_oCenter4 != null)
			{
				return _oCenter4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow4 != value && _oCenter4 != null)
			{
				_oCenter4.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow5
	{
		get
		{
			if (_oCenter5 != null)
			{
				return _oCenter5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow5 != value && _oCenter5 != null)
			{
				_oCenter5.SetObjectActive(value);
			}
		}
	}

	public bool CenterShow6
	{
		get
		{
			if (_oCenter6 != null)
			{
				return _oCenter6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow6 != value && _oCenter6 != null)
			{
				_oCenter6.SetObjectActive(value);
			}
		}
	}

	public Vector3 CenterScale1
	{
		get
		{
			if (_oCenterRectTransform1 != null)
			{
				return _oCenterRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale1 != value && _oCenterRectTransform1 != null)
			{
				_oCenterRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 CenterScale2
	{
		get
		{
			if (_oCenterRectTransform2 != null)
			{
				return _oCenterRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale2 != value && _oCenterRectTransform2 != null)
			{
				_oCenterRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 CenterScale3
	{
		get
		{
			if (_oCenterRectTransform3 != null)
			{
				return _oCenterRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale3 != value && _oCenterRectTransform3 != null)
			{
				_oCenterRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 CenterScale4
	{
		get
		{
			if (_oCenterRectTransform4 != null)
			{
				return _oCenterRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale4 != value && _oCenterRectTransform4 != null)
			{
				_oCenterRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 CenterScale5
	{
		get
		{
			if (_oCenterRectTransform5 != null)
			{
				return _oCenterRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale5 != value && _oCenterRectTransform5 != null)
			{
				_oCenterRectTransform5.localScale = value;
			}
		}
	}

	public Vector3 CenterScale6
	{
		get
		{
			if (_oCenterRectTransform6 != null)
			{
				return _oCenterRectTransform6.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CenterScale6 != value && _oCenterRectTransform6 != null)
			{
				_oCenterRectTransform6.localScale = value;
			}
		}
	}

	public Color CenterColor1
	{
		get
		{
			if (_oCenterImage1 != null)
			{
				return _oCenterImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor1 != value && _oCenterImage1 != null)
			{
				_oCenterImage1.color = value;
			}
		}
	}

	public Color CenterColor2
	{
		get
		{
			if (_oCenterImage2 != null)
			{
				return _oCenterImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor2 != value && _oCenterImage2 != null)
			{
				_oCenterImage2.color = value;
			}
		}
	}

	public Color CenterColor3
	{
		get
		{
			if (_oCenterImage3 != null)
			{
				return _oCenterImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor3 != value && _oCenterImage3 != null)
			{
				_oCenterImage3.color = value;
			}
		}
	}

	public Color CenterColor4
	{
		get
		{
			if (_oCenterImage4 != null)
			{
				return _oCenterImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor4 != value && _oCenterImage4 != null)
			{
				_oCenterImage4.color = value;
			}
		}
	}

	public Color CenterColor5
	{
		get
		{
			if (_oCenterImage5 != null)
			{
				return _oCenterImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor5 != value && _oCenterImage5 != null)
			{
				_oCenterImage5.color = value;
			}
		}
	}

	public Color CenterColor6
	{
		get
		{
			if (_oCenterImage6 != null)
			{
				return _oCenterImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (CenterColor6 != value && _oCenterImage6 != null)
			{
				_oCenterImage6.color = value;
			}
		}
	}

	public bool CycleShow1
	{
		get
		{
			if (_oCycle1 != null)
			{
				return _oCycle1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow1 != value && _oCycle1 != null)
			{
				_oCycle1.SetObjectActive(value);
			}
		}
	}

	public bool CycleShow2
	{
		get
		{
			if (_oCycle2 != null)
			{
				return _oCycle2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow2 != value && _oCycle2 != null)
			{
				_oCycle2.SetObjectActive(value);
			}
		}
	}

	public bool CycleShow3
	{
		get
		{
			if (_oCycle3 != null)
			{
				return _oCycle3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow3 != value && _oCycle3 != null)
			{
				_oCycle3.SetObjectActive(value);
			}
		}
	}

	public bool CycleShow4
	{
		get
		{
			if (_oCycle4 != null)
			{
				return _oCycle4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow4 != value && _oCycle4 != null)
			{
				_oCycle4.SetObjectActive(value);
			}
		}
	}

	public bool CycleShow5
	{
		get
		{
			if (_oCycle5 != null)
			{
				return _oCycle5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow5 != value && _oCycle5 != null)
			{
				_oCycle5.SetObjectActive(value);
			}
		}
	}

	public bool CycleShow6
	{
		get
		{
			if (_oCycle6 != null)
			{
				return _oCycle6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CycleShow6 != value && _oCycle6 != null)
			{
				_oCycle6.SetObjectActive(value);
			}
		}
	}

	public Vector3 CycleScale1
	{
		get
		{
			if (_oCycleRectTransform1 != null)
			{
				return _oCycleRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale1 != value && _oCycleRectTransform1 != null)
			{
				_oCycleRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 CycleScale2
	{
		get
		{
			if (_oCycleRectTransform2 != null)
			{
				return _oCycleRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale2 != value && _oCycleRectTransform2 != null)
			{
				_oCycleRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 CycleScale3
	{
		get
		{
			if (_oCycleRectTransform3 != null)
			{
				return _oCycleRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale3 != value && _oCycleRectTransform3 != null)
			{
				_oCycleRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 CycleScale4
	{
		get
		{
			if (_oCycleRectTransform4 != null)
			{
				return _oCycleRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale4 != value && _oCycleRectTransform4 != null)
			{
				_oCycleRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 CycleScale5
	{
		get
		{
			if (_oCycleRectTransform5 != null)
			{
				return _oCycleRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale5 != value && _oCycleRectTransform5 != null)
			{
				_oCycleRectTransform5.localScale = value;
			}
		}
	}

	public Vector3 CycleScale6
	{
		get
		{
			if (_oCycleRectTransform6 != null)
			{
				return _oCycleRectTransform6.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CycleScale6 != value && _oCycleRectTransform6 != null)
			{
				_oCycleRectTransform6.localScale = value;
			}
		}
	}

	public Color CycleColor1
	{
		get
		{
			if (_oCycleImage1 != null)
			{
				return _oCycleImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor1 != value && _oCycleImage1 != null)
			{
				_oCycleImage1.color = value;
			}
		}
	}

	public Color CycleColor2
	{
		get
		{
			if (_oCycleImage2 != null)
			{
				return _oCycleImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor2 != value && _oCycleImage2 != null)
			{
				_oCycleImage2.color = value;
			}
		}
	}

	public Color CycleColor3
	{
		get
		{
			if (_oCycleImage3 != null)
			{
				return _oCycleImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor3 != value && _oCycleImage3 != null)
			{
				_oCycleImage3.color = value;
			}
		}
	}

	public Color CycleColor4
	{
		get
		{
			if (_oCycleImage4 != null)
			{
				return _oCycleImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor4 != value && _oCycleImage4 != null)
			{
				_oCycleImage4.color = value;
			}
		}
	}

	public Color CycleColor5
	{
		get
		{
			if (_oCycleImage5 != null)
			{
				return _oCycleImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor5 != value && _oCycleImage5 != null)
			{
				_oCycleImage5.color = value;
			}
		}
	}

	public Color CycleColor6
	{
		get
		{
			if (_oCycleImage6 != null)
			{
				return _oCycleImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (CycleColor6 != value && _oCycleImage6 != null)
			{
				_oCycleImage6.color = value;
			}
		}
	}

	public bool UpShow1
	{
		get
		{
			if (_oUp1 != null)
			{
				return _oUp1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow1 != value && _oUp1 != null)
			{
				_oUp1.SetObjectActive(value);
			}
		}
	}

	public bool UpShow2
	{
		get
		{
			if (_oUp2 != null)
			{
				return _oUp2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow2 != value && _oUp2 != null)
			{
				_oUp2.SetObjectActive(value);
			}
		}
	}

	public bool UpShow3
	{
		get
		{
			if (_oUp3 != null)
			{
				return _oUp3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow3 != value && _oUp3 != null)
			{
				_oUp3.SetObjectActive(value);
			}
		}
	}

	public bool UpShow4
	{
		get
		{
			if (_oUp4 != null)
			{
				return _oUp4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow4 != value && _oUp4 != null)
			{
				_oUp4.SetObjectActive(value);
			}
		}
	}

	public bool UpShow5
	{
		get
		{
			if (_oUp5 != null)
			{
				return _oUp5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow5 != value && _oUp5 != null)
			{
				_oUp5.SetObjectActive(value);
			}
		}
	}

	public bool UpShow6
	{
		get
		{
			if (_oUp6 != null)
			{
				return _oUp6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow6 != value && _oUp6 != null)
			{
				_oUp6.SetObjectActive(value);
			}
		}
	}

	public Vector3 UpPosition1
	{
		get
		{
			if (_oUpRectTransform1 != null)
			{
				return _oUpRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition1 != value && _oUpRectTransform1 != null)
			{
				_oUpRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 UpPosition2
	{
		get
		{
			if (_oUpRectTransform2 != null)
			{
				return _oUpRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition2 != value && _oUpRectTransform2 != null)
			{
				_oUpRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 UpPosition3
	{
		get
		{
			if (_oUpRectTransform3 != null)
			{
				return _oUpRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition3 != value && _oUpRectTransform3 != null)
			{
				_oUpRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 UpPosition4
	{
		get
		{
			if (_oUpRectTransform4 != null)
			{
				return _oUpRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition4 != value && _oUpRectTransform4 != null)
			{
				_oUpRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 UpPosition5
	{
		get
		{
			if (_oUpRectTransform5 != null)
			{
				return _oUpRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition5 != value && _oUpRectTransform5 != null)
			{
				_oUpRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 UpPosition6
	{
		get
		{
			if (_oUpRectTransform6 != null)
			{
				return _oUpRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (UpPosition6 != value && _oUpRectTransform6 != null)
			{
				_oUpRectTransform6.localPosition = value;
			}
		}
	}

	public Color UpColor1
	{
		get
		{
			if (_oUpImage1 != null)
			{
				return _oUpImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor1 != value && _oUpImage1 != null)
			{
				_oUpImage1.color = value;
			}
		}
	}

	public Color UpColor2
	{
		get
		{
			if (_oUpImage2 != null)
			{
				return _oUpImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor2 != value && _oUpImage2 != null)
			{
				_oUpImage2.color = value;
			}
		}
	}

	public Color UpColor3
	{
		get
		{
			if (_oUpImage3 != null)
			{
				return _oUpImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor3 != value && _oUpImage3 != null)
			{
				_oUpImage3.color = value;
			}
		}
	}

	public Color UpColor4
	{
		get
		{
			if (_oUpImage4 != null)
			{
				return _oUpImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor4 != value && _oUpImage4 != null)
			{
				_oUpImage4.color = value;
			}
		}
	}

	public Color UpColor5
	{
		get
		{
			if (_oUpImage5 != null)
			{
				return _oUpImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor5 != value && _oUpImage5 != null)
			{
				_oUpImage5.color = value;
			}
		}
	}

	public Color UpColor6
	{
		get
		{
			if (_oUpImage6 != null)
			{
				return _oUpImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (UpColor6 != value && _oUpImage6 != null)
			{
				_oUpImage6.color = value;
			}
		}
	}

	public bool DownShow1
	{
		get
		{
			if (_oDown1 != null)
			{
				return _oDown1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow1 != value && _oDown1 != null)
			{
				_oDown1.SetObjectActive(value);
			}
		}
	}

	public bool DownShow2
	{
		get
		{
			if (_oDown2 != null)
			{
				return _oDown2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow2 != value && _oDown2 != null)
			{
				_oDown2.SetObjectActive(value);
			}
		}
	}

	public bool DownShow3
	{
		get
		{
			if (_oDown3 != null)
			{
				return _oDown3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow3 != value && _oDown3 != null)
			{
				_oDown3.SetObjectActive(value);
			}
		}
	}

	public bool DownShow4
	{
		get
		{
			if (_oDown4 != null)
			{
				return _oDown4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow4 != value && _oDown4 != null)
			{
				_oDown4.SetObjectActive(value);
			}
		}
	}

	public bool DownShow5
	{
		get
		{
			if (_oDown5 != null)
			{
				return _oDown5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow5 != value && _oDown5 != null)
			{
				_oDown5.SetObjectActive(value);
			}
		}
	}

	public bool DownShow6
	{
		get
		{
			if (_oDown6 != null)
			{
				return _oDown6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow6 != value && _oDown6 != null)
			{
				_oDown6.SetObjectActive(value);
			}
		}
	}

	public Vector3 DownPosition1
	{
		get
		{
			if (_oDownRectTransform1 != null)
			{
				return _oDownRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition1 != value && _oDownRectTransform1 != null)
			{
				_oDownRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 DownPosition2
	{
		get
		{
			if (_oDownRectTransform2 != null)
			{
				return _oDownRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition2 != value && _oDownRectTransform2 != null)
			{
				_oDownRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 DownPosition3
	{
		get
		{
			if (_oDownRectTransform3 != null)
			{
				return _oDownRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition3 != value && _oDownRectTransform3 != null)
			{
				_oDownRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 DownPosition4
	{
		get
		{
			if (_oDownRectTransform4 != null)
			{
				return _oDownRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition4 != value && _oDownRectTransform4 != null)
			{
				_oDownRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 DownPosition5
	{
		get
		{
			if (_oDownRectTransform5 != null)
			{
				return _oDownRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition5 != value && _oDownRectTransform5 != null)
			{
				_oDownRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 DownPosition6
	{
		get
		{
			if (_oDownRectTransform6 != null)
			{
				return _oDownRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DownPosition6 != value && _oDownRectTransform6 != null)
			{
				_oDownRectTransform6.localPosition = value;
			}
		}
	}

	public Color DownColor1
	{
		get
		{
			if (_oDownImage1 != null)
			{
				return _oDownImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor1 != value && _oDownImage1 != null)
			{
				_oDownImage1.color = value;
			}
		}
	}

	public Color DownColor2
	{
		get
		{
			if (_oDownImage2 != null)
			{
				return _oDownImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor2 != value && _oDownImage2 != null)
			{
				_oDownImage2.color = value;
			}
		}
	}

	public Color DownColor3
	{
		get
		{
			if (_oDownImage3 != null)
			{
				return _oDownImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor3 != value && _oDownImage3 != null)
			{
				_oDownImage3.color = value;
			}
		}
	}

	public Color DownColor4
	{
		get
		{
			if (_oDownImage4 != null)
			{
				return _oDownImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor4 != value && _oDownImage4 != null)
			{
				_oDownImage4.color = value;
			}
		}
	}

	public Color DownColor5
	{
		get
		{
			if (_oDownImage5 != null)
			{
				return _oDownImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor5 != value && _oDownImage5 != null)
			{
				_oDownImage5.color = value;
			}
		}
	}

	public Color DownColor6
	{
		get
		{
			if (_oDownImage6 != null)
			{
				return _oDownImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (DownColor6 != value && _oDownImage6 != null)
			{
				_oDownImage6.color = value;
			}
		}
	}

	public bool LeftShow1
	{
		get
		{
			if (_oLeft1 != null)
			{
				return _oLeft1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow1 != value && _oLeft1 != null)
			{
				_oLeft1.SetObjectActive(value);
			}
		}
	}

	public bool LeftShow2
	{
		get
		{
			if (_oLeft2 != null)
			{
				return _oLeft2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow2 != value && _oLeft2 != null)
			{
				_oLeft2.SetObjectActive(value);
			}
		}
	}

	public bool LeftShow3
	{
		get
		{
			if (_oLeft3 != null)
			{
				return _oLeft3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow3 != value && _oLeft3 != null)
			{
				_oLeft3.SetObjectActive(value);
			}
		}
	}

	public bool LeftShow4
	{
		get
		{
			if (_oLeft4 != null)
			{
				return _oLeft4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow4 != value && _oLeft4 != null)
			{
				_oLeft4.SetObjectActive(value);
			}
		}
	}

	public bool LeftShow5
	{
		get
		{
			if (_oLeft5 != null)
			{
				return _oLeft5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow5 != value && _oLeft5 != null)
			{
				_oLeft5.SetObjectActive(value);
			}
		}
	}

	public bool LeftShow6
	{
		get
		{
			if (_oLeft6 != null)
			{
				return _oLeft6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow6 != value && _oLeft6 != null)
			{
				_oLeft6.SetObjectActive(value);
			}
		}
	}

	public Vector3 LeftPosition1
	{
		get
		{
			if (_oLeftRectTransform1 != null)
			{
				return _oLeftRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition1 != value && _oLeftRectTransform1 != null)
			{
				_oLeftRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 LeftPosition2
	{
		get
		{
			if (_oLeftRectTransform2 != null)
			{
				return _oLeftRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition2 != value && _oLeftRectTransform2 != null)
			{
				_oLeftRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 LeftPosition3
	{
		get
		{
			if (_oLeftRectTransform3 != null)
			{
				return _oLeftRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition3 != value && _oLeftRectTransform3 != null)
			{
				_oLeftRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 LeftPosition4
	{
		get
		{
			if (_oLeftRectTransform4 != null)
			{
				return _oLeftRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition4 != value && _oLeftRectTransform4 != null)
			{
				_oLeftRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 LeftPosition5
	{
		get
		{
			if (_oLeftRectTransform5 != null)
			{
				return _oLeftRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition5 != value && _oLeftRectTransform5 != null)
			{
				_oLeftRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 LeftPosition6
	{
		get
		{
			if (_oLeftRectTransform6 != null)
			{
				return _oLeftRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition6 != value && _oLeftRectTransform6 != null)
			{
				_oLeftRectTransform6.localPosition = value;
			}
		}
	}

	public Color LeftColor1
	{
		get
		{
			if (_oLeftImage1 != null)
			{
				return _oLeftImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor1 != value && _oLeftImage1 != null)
			{
				_oLeftImage1.color = value;
			}
		}
	}

	public Color LeftColor2
	{
		get
		{
			if (_oLeftImage2 != null)
			{
				return _oLeftImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor2 != value && _oLeftImage2 != null)
			{
				_oLeftImage2.color = value;
			}
		}
	}

	public Color LeftColor3
	{
		get
		{
			if (_oLeftImage3 != null)
			{
				return _oLeftImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor3 != value && _oLeftImage3 != null)
			{
				_oLeftImage3.color = value;
			}
		}
	}

	public Color LeftColor4
	{
		get
		{
			if (_oLeftImage4 != null)
			{
				return _oLeftImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor4 != value && _oLeftImage4 != null)
			{
				_oLeftImage4.color = value;
			}
		}
	}

	public Color LeftColor5
	{
		get
		{
			if (_oLeftImage5 != null)
			{
				return _oLeftImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor5 != value && _oLeftImage5 != null)
			{
				_oLeftImage5.color = value;
			}
		}
	}

	public Color LeftColor6
	{
		get
		{
			if (_oLeftImage6 != null)
			{
				return _oLeftImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (LeftColor6 != value && _oLeftImage6 != null)
			{
				_oLeftImage6.color = value;
			}
		}
	}

	public bool RightShow1
	{
		get
		{
			if (_oRight1 != null)
			{
				return _oRight1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow1 != value && _oRight1 != null)
			{
				_oRight1.SetObjectActive(value);
			}
		}
	}

	public bool RightShow2
	{
		get
		{
			if (_oRight2 != null)
			{
				return _oRight2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow2 != value && _oRight2 != null)
			{
				_oRight2.SetObjectActive(value);
			}
		}
	}

	public bool RightShow3
	{
		get
		{
			if (_oRight3 != null)
			{
				return _oRight3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow3 != value && _oRight3 != null)
			{
				_oRight3.SetObjectActive(value);
			}
		}
	}

	public bool RightShow4
	{
		get
		{
			if (_oRight4 != null)
			{
				return _oRight4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow4 != value && _oRight4 != null)
			{
				_oRight4.SetObjectActive(value);
			}
		}
	}

	public bool RightShow5
	{
		get
		{
			if (_oRight5 != null)
			{
				return _oRight5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow5 != value && _oRight5 != null)
			{
				_oRight5.SetObjectActive(value);
			}
		}
	}

	public bool RightShow6
	{
		get
		{
			if (_oRight6 != null)
			{
				return _oRight6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightShow6 != value && _oRight6 != null)
			{
				_oRight6.SetObjectActive(value);
			}
		}
	}

	public Vector3 RightPosition1
	{
		get
		{
			if (_oRightRectTransform1 != null)
			{
				return _oRightRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition1 != value && _oRightRectTransform1 != null)
			{
				_oRightRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition2
	{
		get
		{
			if (_oRightRectTransform2 != null)
			{
				return _oRightRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition2 != value && _oRightRectTransform2 != null)
			{
				_oRightRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition3
	{
		get
		{
			if (_oRightRectTransform3 != null)
			{
				return _oRightRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition3 != value && _oRightRectTransform3 != null)
			{
				_oRightRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition4
	{
		get
		{
			if (_oRightRectTransform4 != null)
			{
				return _oRightRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition4 != value && _oRightRectTransform4 != null)
			{
				_oRightRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition5
	{
		get
		{
			if (_oRightRectTransform5 != null)
			{
				return _oRightRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition5 != value && _oRightRectTransform5 != null)
			{
				_oRightRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition6
	{
		get
		{
			if (_oRightRectTransform6 != null)
			{
				return _oRightRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition6 != value && _oRightRectTransform6 != null)
			{
				_oRightRectTransform6.localPosition = value;
			}
		}
	}

	public Color RightColor1
	{
		get
		{
			if (_oRightImage1 != null)
			{
				return _oRightImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor1 != value && _oRightImage1 != null)
			{
				_oRightImage1.color = value;
			}
		}
	}

	public Color RightColor2
	{
		get
		{
			if (_oRightImage2 != null)
			{
				return _oRightImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor2 != value && _oRightImage2 != null)
			{
				_oRightImage2.color = value;
			}
		}
	}

	public Color RightColor3
	{
		get
		{
			if (_oRightImage3 != null)
			{
				return _oRightImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor3 != value && _oRightImage3 != null)
			{
				_oRightImage3.color = value;
			}
		}
	}

	public Color RightColor4
	{
		get
		{
			if (_oRightImage4 != null)
			{
				return _oRightImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor4 != value && _oRightImage4 != null)
			{
				_oRightImage4.color = value;
			}
		}
	}

	public Color RightColor5
	{
		get
		{
			if (_oRightImage5 != null)
			{
				return _oRightImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor5 != value && _oRightImage5 != null)
			{
				_oRightImage5.color = value;
			}
		}
	}

	public Color RightColor6
	{
		get
		{
			if (_oRightImage6 != null)
			{
				return _oRightImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (RightColor6 != value && _oRightImage6 != null)
			{
				_oRightImage6.color = value;
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
			case "Type1":
				_oType1 = transform.gameObject;
				break;
			case "Type2":
				_oType2 = transform.gameObject;
				break;
			case "Type3":
				_oType3 = transform.gameObject;
				break;
			case "Type4":
				_oType4 = transform.gameObject;
				break;
			case "Type5":
				_oType5 = transform.gameObject;
				break;
			case "Type6":
				_oType6 = transform.gameObject;
				break;
			case "Center1":
				_oCenter1 = transform.gameObject;
				_oCenterRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Center2":
				_oCenter2 = transform.gameObject;
				_oCenterRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Center3":
				_oCenter3 = transform.gameObject;
				_oCenterRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Center4":
				_oCenter4 = transform.gameObject;
				_oCenterRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Center5":
				_oCenter5 = transform.gameObject;
				_oCenterRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Center6":
				_oCenter6 = transform.gameObject;
				_oCenterRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oCenterImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle1":
				_oCycle1 = transform.gameObject;
				_oCycleRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle2":
				_oCycle2 = transform.gameObject;
				_oCycleRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle3":
				_oCycle3 = transform.gameObject;
				_oCycleRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle4":
				_oCycle4 = transform.gameObject;
				_oCycleRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle5":
				_oCycle5 = transform.gameObject;
				_oCycleRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cycle6":
				_oCycle6 = transform.gameObject;
				_oCycleRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oCycleImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up1":
				_oUp1 = transform.gameObject;
				_oUpRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up2":
				_oUp2 = transform.gameObject;
				_oUpRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up3":
				_oUp3 = transform.gameObject;
				_oUpRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up4":
				_oUp4 = transform.gameObject;
				_oUpRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up5":
				_oUp5 = transform.gameObject;
				_oUpRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Up6":
				_oUp6 = transform.gameObject;
				_oUpRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oUpImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down1":
				_oDown1 = transform.gameObject;
				_oDownRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down2":
				_oDown2 = transform.gameObject;
				_oDownRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down3":
				_oDown3 = transform.gameObject;
				_oDownRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down4":
				_oDown4 = transform.gameObject;
				_oDownRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down5":
				_oDown5 = transform.gameObject;
				_oDownRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Down6":
				_oDown6 = transform.gameObject;
				_oDownRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oDownImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left1":
				_oLeft1 = transform.gameObject;
				_oLeftRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left2":
				_oLeft2 = transform.gameObject;
				_oLeftRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left3":
				_oLeft3 = transform.gameObject;
				_oLeftRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left4":
				_oLeft4 = transform.gameObject;
				_oLeftRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left5":
				_oLeft5 = transform.gameObject;
				_oLeftRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Left6":
				_oLeft6 = transform.gameObject;
				_oLeftRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oLeftImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right1":
				_oRight1 = transform.gameObject;
				_oRightRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right2":
				_oRight2 = transform.gameObject;
				_oRightRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right3":
				_oRight3 = transform.gameObject;
				_oRightRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right4":
				_oRight4 = transform.gameObject;
				_oRightRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right5":
				_oRight5 = transform.gameObject;
				_oRightRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Right6":
				_oRight6 = transform.gameObject;
				_oRightRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oRightImage6 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetTypeShow(int index)
	{
		return index switch
		{
			1 => TypeShow1, 
			2 => TypeShow2, 
			3 => TypeShow3, 
			4 => TypeShow4, 
			5 => TypeShow5, 
			6 => TypeShow6, 
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
		case 4:
			TypeShow4 = value;
			break;
		case 5:
			TypeShow5 = value;
			break;
		case 6:
			TypeShow6 = value;
			break;
		}
	}

	public bool GetCenterShow(int index)
	{
		return index switch
		{
			1 => CenterShow1, 
			2 => CenterShow2, 
			3 => CenterShow3, 
			4 => CenterShow4, 
			5 => CenterShow5, 
			6 => CenterShow6, 
			_ => false, 
		};
	}

	public void SetCenterShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CenterShow1 = value;
			break;
		case 2:
			CenterShow2 = value;
			break;
		case 3:
			CenterShow3 = value;
			break;
		case 4:
			CenterShow4 = value;
			break;
		case 5:
			CenterShow5 = value;
			break;
		case 6:
			CenterShow6 = value;
			break;
		}
	}

	public Vector3 GetCenterScale(int index)
	{
		return index switch
		{
			1 => CenterScale1, 
			2 => CenterScale2, 
			3 => CenterScale3, 
			4 => CenterScale4, 
			5 => CenterScale5, 
			6 => CenterScale6, 
			_ => Vector3.zero, 
		};
	}

	public void SetCenterScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CenterScale1 = value;
			break;
		case 2:
			CenterScale2 = value;
			break;
		case 3:
			CenterScale3 = value;
			break;
		case 4:
			CenterScale4 = value;
			break;
		case 5:
			CenterScale5 = value;
			break;
		case 6:
			CenterScale6 = value;
			break;
		}
	}

	public Color GetCenterColor(int index)
	{
		return index switch
		{
			1 => CenterColor1, 
			2 => CenterColor2, 
			3 => CenterColor3, 
			4 => CenterColor4, 
			5 => CenterColor5, 
			6 => CenterColor6, 
			_ => Color.white, 
		};
	}

	public void SetCenterColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			CenterColor1 = value;
			break;
		case 2:
			CenterColor2 = value;
			break;
		case 3:
			CenterColor3 = value;
			break;
		case 4:
			CenterColor4 = value;
			break;
		case 5:
			CenterColor5 = value;
			break;
		case 6:
			CenterColor6 = value;
			break;
		}
	}

	public bool GetCycleShow(int index)
	{
		return index switch
		{
			1 => CycleShow1, 
			2 => CycleShow2, 
			3 => CycleShow3, 
			4 => CycleShow4, 
			5 => CycleShow5, 
			6 => CycleShow6, 
			_ => false, 
		};
	}

	public void SetCycleShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CycleShow1 = value;
			break;
		case 2:
			CycleShow2 = value;
			break;
		case 3:
			CycleShow3 = value;
			break;
		case 4:
			CycleShow4 = value;
			break;
		case 5:
			CycleShow5 = value;
			break;
		case 6:
			CycleShow6 = value;
			break;
		}
	}

	public Vector3 GetCycleScale(int index)
	{
		return index switch
		{
			1 => CycleScale1, 
			2 => CycleScale2, 
			3 => CycleScale3, 
			4 => CycleScale4, 
			5 => CycleScale5, 
			6 => CycleScale6, 
			_ => Vector3.zero, 
		};
	}

	public void SetCycleScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CycleScale1 = value;
			break;
		case 2:
			CycleScale2 = value;
			break;
		case 3:
			CycleScale3 = value;
			break;
		case 4:
			CycleScale4 = value;
			break;
		case 5:
			CycleScale5 = value;
			break;
		case 6:
			CycleScale6 = value;
			break;
		}
	}

	public Color GetCycleColor(int index)
	{
		return index switch
		{
			1 => CycleColor1, 
			2 => CycleColor2, 
			3 => CycleColor3, 
			4 => CycleColor4, 
			5 => CycleColor5, 
			6 => CycleColor6, 
			_ => Color.white, 
		};
	}

	public void SetCycleColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			CycleColor1 = value;
			break;
		case 2:
			CycleColor2 = value;
			break;
		case 3:
			CycleColor3 = value;
			break;
		case 4:
			CycleColor4 = value;
			break;
		case 5:
			CycleColor5 = value;
			break;
		case 6:
			CycleColor6 = value;
			break;
		}
	}

	public bool GetUpShow(int index)
	{
		return index switch
		{
			1 => UpShow1, 
			2 => UpShow2, 
			3 => UpShow3, 
			4 => UpShow4, 
			5 => UpShow5, 
			6 => UpShow6, 
			_ => false, 
		};
	}

	public void SetUpShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			UpShow1 = value;
			break;
		case 2:
			UpShow2 = value;
			break;
		case 3:
			UpShow3 = value;
			break;
		case 4:
			UpShow4 = value;
			break;
		case 5:
			UpShow5 = value;
			break;
		case 6:
			UpShow6 = value;
			break;
		}
	}

	public Vector3 GetUpPosition(int index)
	{
		return index switch
		{
			1 => UpPosition1, 
			2 => UpPosition2, 
			3 => UpPosition3, 
			4 => UpPosition4, 
			5 => UpPosition5, 
			6 => UpPosition6, 
			_ => Vector3.zero, 
		};
	}

	public void SetUpPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			UpPosition1 = value;
			break;
		case 2:
			UpPosition2 = value;
			break;
		case 3:
			UpPosition3 = value;
			break;
		case 4:
			UpPosition4 = value;
			break;
		case 5:
			UpPosition5 = value;
			break;
		case 6:
			UpPosition6 = value;
			break;
		}
	}

	public Color GetUpColor(int index)
	{
		return index switch
		{
			1 => UpColor1, 
			2 => UpColor2, 
			3 => UpColor3, 
			4 => UpColor4, 
			5 => UpColor5, 
			6 => UpColor6, 
			_ => Color.white, 
		};
	}

	public void SetUpColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			UpColor1 = value;
			break;
		case 2:
			UpColor2 = value;
			break;
		case 3:
			UpColor3 = value;
			break;
		case 4:
			UpColor4 = value;
			break;
		case 5:
			UpColor5 = value;
			break;
		case 6:
			UpColor6 = value;
			break;
		}
	}

	public bool GetDownShow(int index)
	{
		return index switch
		{
			1 => DownShow1, 
			2 => DownShow2, 
			3 => DownShow3, 
			4 => DownShow4, 
			5 => DownShow5, 
			6 => DownShow6, 
			_ => false, 
		};
	}

	public void SetDownShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DownShow1 = value;
			break;
		case 2:
			DownShow2 = value;
			break;
		case 3:
			DownShow3 = value;
			break;
		case 4:
			DownShow4 = value;
			break;
		case 5:
			DownShow5 = value;
			break;
		case 6:
			DownShow6 = value;
			break;
		}
	}

	public Vector3 GetDownPosition(int index)
	{
		return index switch
		{
			1 => DownPosition1, 
			2 => DownPosition2, 
			3 => DownPosition3, 
			4 => DownPosition4, 
			5 => DownPosition5, 
			6 => DownPosition6, 
			_ => Vector3.zero, 
		};
	}

	public void SetDownPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			DownPosition1 = value;
			break;
		case 2:
			DownPosition2 = value;
			break;
		case 3:
			DownPosition3 = value;
			break;
		case 4:
			DownPosition4 = value;
			break;
		case 5:
			DownPosition5 = value;
			break;
		case 6:
			DownPosition6 = value;
			break;
		}
	}

	public Color GetDownColor(int index)
	{
		return index switch
		{
			1 => DownColor1, 
			2 => DownColor2, 
			3 => DownColor3, 
			4 => DownColor4, 
			5 => DownColor5, 
			6 => DownColor6, 
			_ => Color.white, 
		};
	}

	public void SetDownColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			DownColor1 = value;
			break;
		case 2:
			DownColor2 = value;
			break;
		case 3:
			DownColor3 = value;
			break;
		case 4:
			DownColor4 = value;
			break;
		case 5:
			DownColor5 = value;
			break;
		case 6:
			DownColor6 = value;
			break;
		}
	}

	public bool GetLeftShow(int index)
	{
		return index switch
		{
			1 => LeftShow1, 
			2 => LeftShow2, 
			3 => LeftShow3, 
			4 => LeftShow4, 
			5 => LeftShow5, 
			6 => LeftShow6, 
			_ => false, 
		};
	}

	public void SetLeftShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LeftShow1 = value;
			break;
		case 2:
			LeftShow2 = value;
			break;
		case 3:
			LeftShow3 = value;
			break;
		case 4:
			LeftShow4 = value;
			break;
		case 5:
			LeftShow5 = value;
			break;
		case 6:
			LeftShow6 = value;
			break;
		}
	}

	public Vector3 GetLeftPosition(int index)
	{
		return index switch
		{
			1 => LeftPosition1, 
			2 => LeftPosition2, 
			3 => LeftPosition3, 
			4 => LeftPosition4, 
			5 => LeftPosition5, 
			6 => LeftPosition6, 
			_ => Vector3.zero, 
		};
	}

	public void SetLeftPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			LeftPosition1 = value;
			break;
		case 2:
			LeftPosition2 = value;
			break;
		case 3:
			LeftPosition3 = value;
			break;
		case 4:
			LeftPosition4 = value;
			break;
		case 5:
			LeftPosition5 = value;
			break;
		case 6:
			LeftPosition6 = value;
			break;
		}
	}

	public Color GetLeftColor(int index)
	{
		return index switch
		{
			1 => LeftColor1, 
			2 => LeftColor2, 
			3 => LeftColor3, 
			4 => LeftColor4, 
			5 => LeftColor5, 
			6 => LeftColor6, 
			_ => Color.white, 
		};
	}

	public void SetLeftColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			LeftColor1 = value;
			break;
		case 2:
			LeftColor2 = value;
			break;
		case 3:
			LeftColor3 = value;
			break;
		case 4:
			LeftColor4 = value;
			break;
		case 5:
			LeftColor5 = value;
			break;
		case 6:
			LeftColor6 = value;
			break;
		}
	}

	public bool GetRightShow(int index)
	{
		return index switch
		{
			1 => RightShow1, 
			2 => RightShow2, 
			3 => RightShow3, 
			4 => RightShow4, 
			5 => RightShow5, 
			6 => RightShow6, 
			_ => false, 
		};
	}

	public void SetRightShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RightShow1 = value;
			break;
		case 2:
			RightShow2 = value;
			break;
		case 3:
			RightShow3 = value;
			break;
		case 4:
			RightShow4 = value;
			break;
		case 5:
			RightShow5 = value;
			break;
		case 6:
			RightShow6 = value;
			break;
		}
	}

	public Vector3 GetRightPosition(int index)
	{
		return index switch
		{
			1 => RightPosition1, 
			2 => RightPosition2, 
			3 => RightPosition3, 
			4 => RightPosition4, 
			5 => RightPosition5, 
			6 => RightPosition6, 
			_ => Vector3.zero, 
		};
	}

	public void SetRightPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			RightPosition1 = value;
			break;
		case 2:
			RightPosition2 = value;
			break;
		case 3:
			RightPosition3 = value;
			break;
		case 4:
			RightPosition4 = value;
			break;
		case 5:
			RightPosition5 = value;
			break;
		case 6:
			RightPosition6 = value;
			break;
		}
	}

	public Color GetRightColor(int index)
	{
		return index switch
		{
			1 => RightColor1, 
			2 => RightColor2, 
			3 => RightColor3, 
			4 => RightColor4, 
			5 => RightColor5, 
			6 => RightColor6, 
			_ => Color.white, 
		};
	}

	public void SetRightColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			RightColor1 = value;
			break;
		case 2:
			RightColor2 = value;
			break;
		case 3:
			RightColor3 = value;
			break;
		case 4:
			RightColor4 = value;
			break;
		case 5:
			RightColor5 = value;
			break;
		case 6:
			RightColor6 = value;
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
