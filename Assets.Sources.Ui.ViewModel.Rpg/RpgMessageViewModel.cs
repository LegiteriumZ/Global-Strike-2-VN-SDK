using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessage1;

	private GameObject _oMessage2;

	private GameObject _oMessage3;

	private GameObject _oMessage4;

	private GameObject _oMessage5;

	private RectTransform _oMessageRectTransform1;

	private RectTransform _oMessageRectTransform2;

	private RectTransform _oMessageRectTransform3;

	private RectTransform _oMessageRectTransform4;

	private RectTransform _oMessageRectTransform5;

	private GameObject _oImage1;

	private GameObject _oImage2;

	private GameObject _oImage3;

	private GameObject _oImage4;

	private GameObject _oImage5;

	private Image _oImageImage1;

	private Image _oImageImage2;

	private Image _oImageImage3;

	private Image _oImageImage4;

	private Image _oImageImage5;

	private GameObject _oCountA1;

	private GameObject _oCountA2;

	private GameObject _oCountA3;

	private GameObject _oCountA4;

	private GameObject _oCountA5;

	private RectTransform _oCountARectTransform1;

	private RectTransform _oCountARectTransform2;

	private RectTransform _oCountARectTransform3;

	private RectTransform _oCountARectTransform4;

	private RectTransform _oCountARectTransform5;

	private Text _oCountAText1;

	private Text _oCountAText2;

	private Text _oCountAText3;

	private Text _oCountAText4;

	private Text _oCountAText5;

	private GameObject _oCountB1;

	private GameObject _oCountB2;

	private GameObject _oCountB3;

	private GameObject _oCountB4;

	private GameObject _oCountB5;

	private RectTransform _oCountBRectTransform1;

	private RectTransform _oCountBRectTransform2;

	private RectTransform _oCountBRectTransform3;

	private RectTransform _oCountBRectTransform4;

	private RectTransform _oCountBRectTransform5;

	private Text _oCountBText1;

	private Text _oCountBText2;

	private Text _oCountBText3;

	private Text _oCountBText4;

	private Text _oCountBText5;

	private GameObject _oCountC1;

	private GameObject _oCountC2;

	private GameObject _oCountC3;

	private GameObject _oCountC4;

	private GameObject _oCountC5;

	private RectTransform _oCountCRectTransform1;

	private RectTransform _oCountCRectTransform2;

	private RectTransform _oCountCRectTransform3;

	private RectTransform _oCountCRectTransform4;

	private RectTransform _oCountCRectTransform5;

	private Text _oCountCText1;

	private Text _oCountCText2;

	private Text _oCountCText3;

	private Text _oCountCText4;

	private Text _oCountCText5;

	private GameObject _oText1;

	private GameObject _oText2;

	private GameObject _oText3;

	private GameObject _oText4;

	private GameObject _oText5;

	private RectTransform _oTextRectTransform1;

	private RectTransform _oTextRectTransform2;

	private RectTransform _oTextRectTransform3;

	private RectTransform _oTextRectTransform4;

	private RectTransform _oTextRectTransform5;

	private Text _oTextText1;

	private Text _oTextText2;

	private Text _oTextText3;

	private Text _oTextText4;

	private Text _oTextText5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgMessage";

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

	public bool MessageShow1
	{
		get
		{
			if (_oMessage1 != null)
			{
				return _oMessage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow1 != value && _oMessage1 != null)
			{
				_oMessage1.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow2
	{
		get
		{
			if (_oMessage2 != null)
			{
				return _oMessage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow2 != value && _oMessage2 != null)
			{
				_oMessage2.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow3
	{
		get
		{
			if (_oMessage3 != null)
			{
				return _oMessage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow3 != value && _oMessage3 != null)
			{
				_oMessage3.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow4
	{
		get
		{
			if (_oMessage4 != null)
			{
				return _oMessage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow4 != value && _oMessage4 != null)
			{
				_oMessage4.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow5
	{
		get
		{
			if (_oMessage5 != null)
			{
				return _oMessage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow5 != value && _oMessage5 != null)
			{
				_oMessage5.SetObjectActive(value);
			}
		}
	}

	public Vector3 MessageScale1
	{
		get
		{
			if (_oMessageRectTransform1 != null)
			{
				return _oMessageRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessageScale1 != value && _oMessageRectTransform1 != null)
			{
				_oMessageRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 MessageScale2
	{
		get
		{
			if (_oMessageRectTransform2 != null)
			{
				return _oMessageRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessageScale2 != value && _oMessageRectTransform2 != null)
			{
				_oMessageRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 MessageScale3
	{
		get
		{
			if (_oMessageRectTransform3 != null)
			{
				return _oMessageRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessageScale3 != value && _oMessageRectTransform3 != null)
			{
				_oMessageRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 MessageScale4
	{
		get
		{
			if (_oMessageRectTransform4 != null)
			{
				return _oMessageRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessageScale4 != value && _oMessageRectTransform4 != null)
			{
				_oMessageRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 MessageScale5
	{
		get
		{
			if (_oMessageRectTransform5 != null)
			{
				return _oMessageRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessageScale5 != value && _oMessageRectTransform5 != null)
			{
				_oMessageRectTransform5.localScale = value;
			}
		}
	}

	public Sprite ImageSprite1
	{
		get
		{
			if (_oImageImage1 != null)
			{
				return _oImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite1 != value && _oImageImage1 != null)
			{
				_oImageImage1.sprite = value;
			}
		}
	}

	public Sprite ImageSprite2
	{
		get
		{
			if (_oImageImage2 != null)
			{
				return _oImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite2 != value && _oImageImage2 != null)
			{
				_oImageImage2.sprite = value;
			}
		}
	}

	public Sprite ImageSprite3
	{
		get
		{
			if (_oImageImage3 != null)
			{
				return _oImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite3 != value && _oImageImage3 != null)
			{
				_oImageImage3.sprite = value;
			}
		}
	}

	public Sprite ImageSprite4
	{
		get
		{
			if (_oImageImage4 != null)
			{
				return _oImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite4 != value && _oImageImage4 != null)
			{
				_oImageImage4.sprite = value;
			}
		}
	}

	public Sprite ImageSprite5
	{
		get
		{
			if (_oImageImage5 != null)
			{
				return _oImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite5 != value && _oImageImage5 != null)
			{
				_oImageImage5.sprite = value;
			}
		}
	}

	public Vector3 MessagePosition1
	{
		get
		{
			if (_oMessageRectTransform1 != null)
			{
				return _oMessageRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessagePosition1 != value && _oMessageRectTransform1 != null)
			{
				_oMessageRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 MessagePosition2
	{
		get
		{
			if (_oMessageRectTransform2 != null)
			{
				return _oMessageRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessagePosition2 != value && _oMessageRectTransform2 != null)
			{
				_oMessageRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 MessagePosition3
	{
		get
		{
			if (_oMessageRectTransform3 != null)
			{
				return _oMessageRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessagePosition3 != value && _oMessageRectTransform3 != null)
			{
				_oMessageRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 MessagePosition4
	{
		get
		{
			if (_oMessageRectTransform4 != null)
			{
				return _oMessageRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessagePosition4 != value && _oMessageRectTransform4 != null)
			{
				_oMessageRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 MessagePosition5
	{
		get
		{
			if (_oMessageRectTransform5 != null)
			{
				return _oMessageRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MessagePosition5 != value && _oMessageRectTransform5 != null)
			{
				_oMessageRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 CountAPosition1
	{
		get
		{
			if (_oCountARectTransform1 != null)
			{
				return _oCountARectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountAPosition1 != value && _oCountARectTransform1 != null)
			{
				_oCountARectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 CountAPosition2
	{
		get
		{
			if (_oCountARectTransform2 != null)
			{
				return _oCountARectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountAPosition2 != value && _oCountARectTransform2 != null)
			{
				_oCountARectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 CountAPosition3
	{
		get
		{
			if (_oCountARectTransform3 != null)
			{
				return _oCountARectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountAPosition3 != value && _oCountARectTransform3 != null)
			{
				_oCountARectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 CountAPosition4
	{
		get
		{
			if (_oCountARectTransform4 != null)
			{
				return _oCountARectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountAPosition4 != value && _oCountARectTransform4 != null)
			{
				_oCountARectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 CountAPosition5
	{
		get
		{
			if (_oCountARectTransform5 != null)
			{
				return _oCountARectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountAPosition5 != value && _oCountARectTransform5 != null)
			{
				_oCountARectTransform5.localPosition = value;
			}
		}
	}

	public string CountAString1
	{
		get
		{
			if (_oCountAText1 != null)
			{
				return _oCountAText1.text;
			}
			return null;
		}
		set
		{
			if (CountAString1 != value && _oCountAText1 != null)
			{
				_oCountAText1.text = value;
			}
		}
	}

	public string CountAString2
	{
		get
		{
			if (_oCountAText2 != null)
			{
				return _oCountAText2.text;
			}
			return null;
		}
		set
		{
			if (CountAString2 != value && _oCountAText2 != null)
			{
				_oCountAText2.text = value;
			}
		}
	}

	public string CountAString3
	{
		get
		{
			if (_oCountAText3 != null)
			{
				return _oCountAText3.text;
			}
			return null;
		}
		set
		{
			if (CountAString3 != value && _oCountAText3 != null)
			{
				_oCountAText3.text = value;
			}
		}
	}

	public string CountAString4
	{
		get
		{
			if (_oCountAText4 != null)
			{
				return _oCountAText4.text;
			}
			return null;
		}
		set
		{
			if (CountAString4 != value && _oCountAText4 != null)
			{
				_oCountAText4.text = value;
			}
		}
	}

	public string CountAString5
	{
		get
		{
			if (_oCountAText5 != null)
			{
				return _oCountAText5.text;
			}
			return null;
		}
		set
		{
			if (CountAString5 != value && _oCountAText5 != null)
			{
				_oCountAText5.text = value;
			}
		}
	}

	public Font CountATextfont1
	{
		get
		{
			if (_oCountAText1 != null)
			{
				return _oCountAText1.font;
			}
			return null;
		}
		set
		{
			if (CountATextfont1 != value && _oCountAText1 != null)
			{
				_oCountAText1.font = value;
			}
		}
	}

	public Font CountATextfont2
	{
		get
		{
			if (_oCountAText2 != null)
			{
				return _oCountAText2.font;
			}
			return null;
		}
		set
		{
			if (CountATextfont2 != value && _oCountAText2 != null)
			{
				_oCountAText2.font = value;
			}
		}
	}

	public Font CountATextfont3
	{
		get
		{
			if (_oCountAText3 != null)
			{
				return _oCountAText3.font;
			}
			return null;
		}
		set
		{
			if (CountATextfont3 != value && _oCountAText3 != null)
			{
				_oCountAText3.font = value;
			}
		}
	}

	public Font CountATextfont4
	{
		get
		{
			if (_oCountAText4 != null)
			{
				return _oCountAText4.font;
			}
			return null;
		}
		set
		{
			if (CountATextfont4 != value && _oCountAText4 != null)
			{
				_oCountAText4.font = value;
			}
		}
	}

	public Font CountATextfont5
	{
		get
		{
			if (_oCountAText5 != null)
			{
				return _oCountAText5.font;
			}
			return null;
		}
		set
		{
			if (CountATextfont5 != value && _oCountAText5 != null)
			{
				_oCountAText5.font = value;
			}
		}
	}

	public Vector3 CountBPosition1
	{
		get
		{
			if (_oCountBRectTransform1 != null)
			{
				return _oCountBRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountBPosition1 != value && _oCountBRectTransform1 != null)
			{
				_oCountBRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 CountBPosition2
	{
		get
		{
			if (_oCountBRectTransform2 != null)
			{
				return _oCountBRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountBPosition2 != value && _oCountBRectTransform2 != null)
			{
				_oCountBRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 CountBPosition3
	{
		get
		{
			if (_oCountBRectTransform3 != null)
			{
				return _oCountBRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountBPosition3 != value && _oCountBRectTransform3 != null)
			{
				_oCountBRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 CountBPosition4
	{
		get
		{
			if (_oCountBRectTransform4 != null)
			{
				return _oCountBRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountBPosition4 != value && _oCountBRectTransform4 != null)
			{
				_oCountBRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 CountBPosition5
	{
		get
		{
			if (_oCountBRectTransform5 != null)
			{
				return _oCountBRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountBPosition5 != value && _oCountBRectTransform5 != null)
			{
				_oCountBRectTransform5.localPosition = value;
			}
		}
	}

	public string CountBString1
	{
		get
		{
			if (_oCountBText1 != null)
			{
				return _oCountBText1.text;
			}
			return null;
		}
		set
		{
			if (CountBString1 != value && _oCountBText1 != null)
			{
				_oCountBText1.text = value;
			}
		}
	}

	public string CountBString2
	{
		get
		{
			if (_oCountBText2 != null)
			{
				return _oCountBText2.text;
			}
			return null;
		}
		set
		{
			if (CountBString2 != value && _oCountBText2 != null)
			{
				_oCountBText2.text = value;
			}
		}
	}

	public string CountBString3
	{
		get
		{
			if (_oCountBText3 != null)
			{
				return _oCountBText3.text;
			}
			return null;
		}
		set
		{
			if (CountBString3 != value && _oCountBText3 != null)
			{
				_oCountBText3.text = value;
			}
		}
	}

	public string CountBString4
	{
		get
		{
			if (_oCountBText4 != null)
			{
				return _oCountBText4.text;
			}
			return null;
		}
		set
		{
			if (CountBString4 != value && _oCountBText4 != null)
			{
				_oCountBText4.text = value;
			}
		}
	}

	public string CountBString5
	{
		get
		{
			if (_oCountBText5 != null)
			{
				return _oCountBText5.text;
			}
			return null;
		}
		set
		{
			if (CountBString5 != value && _oCountBText5 != null)
			{
				_oCountBText5.text = value;
			}
		}
	}

	public Font CountBTextfont1
	{
		get
		{
			if (_oCountBText1 != null)
			{
				return _oCountBText1.font;
			}
			return null;
		}
		set
		{
			if (CountBTextfont1 != value && _oCountBText1 != null)
			{
				_oCountBText1.font = value;
			}
		}
	}

	public Font CountBTextfont2
	{
		get
		{
			if (_oCountBText2 != null)
			{
				return _oCountBText2.font;
			}
			return null;
		}
		set
		{
			if (CountBTextfont2 != value && _oCountBText2 != null)
			{
				_oCountBText2.font = value;
			}
		}
	}

	public Font CountBTextfont3
	{
		get
		{
			if (_oCountBText3 != null)
			{
				return _oCountBText3.font;
			}
			return null;
		}
		set
		{
			if (CountBTextfont3 != value && _oCountBText3 != null)
			{
				_oCountBText3.font = value;
			}
		}
	}

	public Font CountBTextfont4
	{
		get
		{
			if (_oCountBText4 != null)
			{
				return _oCountBText4.font;
			}
			return null;
		}
		set
		{
			if (CountBTextfont4 != value && _oCountBText4 != null)
			{
				_oCountBText4.font = value;
			}
		}
	}

	public Font CountBTextfont5
	{
		get
		{
			if (_oCountBText5 != null)
			{
				return _oCountBText5.font;
			}
			return null;
		}
		set
		{
			if (CountBTextfont5 != value && _oCountBText5 != null)
			{
				_oCountBText5.font = value;
			}
		}
	}

	public Vector3 CountCPosition1
	{
		get
		{
			if (_oCountCRectTransform1 != null)
			{
				return _oCountCRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountCPosition1 != value && _oCountCRectTransform1 != null)
			{
				_oCountCRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 CountCPosition2
	{
		get
		{
			if (_oCountCRectTransform2 != null)
			{
				return _oCountCRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountCPosition2 != value && _oCountCRectTransform2 != null)
			{
				_oCountCRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 CountCPosition3
	{
		get
		{
			if (_oCountCRectTransform3 != null)
			{
				return _oCountCRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountCPosition3 != value && _oCountCRectTransform3 != null)
			{
				_oCountCRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 CountCPosition4
	{
		get
		{
			if (_oCountCRectTransform4 != null)
			{
				return _oCountCRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountCPosition4 != value && _oCountCRectTransform4 != null)
			{
				_oCountCRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 CountCPosition5
	{
		get
		{
			if (_oCountCRectTransform5 != null)
			{
				return _oCountCRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CountCPosition5 != value && _oCountCRectTransform5 != null)
			{
				_oCountCRectTransform5.localPosition = value;
			}
		}
	}

	public string CountCString1
	{
		get
		{
			if (_oCountCText1 != null)
			{
				return _oCountCText1.text;
			}
			return null;
		}
		set
		{
			if (CountCString1 != value && _oCountCText1 != null)
			{
				_oCountCText1.text = value;
			}
		}
	}

	public string CountCString2
	{
		get
		{
			if (_oCountCText2 != null)
			{
				return _oCountCText2.text;
			}
			return null;
		}
		set
		{
			if (CountCString2 != value && _oCountCText2 != null)
			{
				_oCountCText2.text = value;
			}
		}
	}

	public string CountCString3
	{
		get
		{
			if (_oCountCText3 != null)
			{
				return _oCountCText3.text;
			}
			return null;
		}
		set
		{
			if (CountCString3 != value && _oCountCText3 != null)
			{
				_oCountCText3.text = value;
			}
		}
	}

	public string CountCString4
	{
		get
		{
			if (_oCountCText4 != null)
			{
				return _oCountCText4.text;
			}
			return null;
		}
		set
		{
			if (CountCString4 != value && _oCountCText4 != null)
			{
				_oCountCText4.text = value;
			}
		}
	}

	public string CountCString5
	{
		get
		{
			if (_oCountCText5 != null)
			{
				return _oCountCText5.text;
			}
			return null;
		}
		set
		{
			if (CountCString5 != value && _oCountCText5 != null)
			{
				_oCountCText5.text = value;
			}
		}
	}

	public Font CountCTextfont1
	{
		get
		{
			if (_oCountCText1 != null)
			{
				return _oCountCText1.font;
			}
			return null;
		}
		set
		{
			if (CountCTextfont1 != value && _oCountCText1 != null)
			{
				_oCountCText1.font = value;
			}
		}
	}

	public Font CountCTextfont2
	{
		get
		{
			if (_oCountCText2 != null)
			{
				return _oCountCText2.font;
			}
			return null;
		}
		set
		{
			if (CountCTextfont2 != value && _oCountCText2 != null)
			{
				_oCountCText2.font = value;
			}
		}
	}

	public Font CountCTextfont3
	{
		get
		{
			if (_oCountCText3 != null)
			{
				return _oCountCText3.font;
			}
			return null;
		}
		set
		{
			if (CountCTextfont3 != value && _oCountCText3 != null)
			{
				_oCountCText3.font = value;
			}
		}
	}

	public Font CountCTextfont4
	{
		get
		{
			if (_oCountCText4 != null)
			{
				return _oCountCText4.font;
			}
			return null;
		}
		set
		{
			if (CountCTextfont4 != value && _oCountCText4 != null)
			{
				_oCountCText4.font = value;
			}
		}
	}

	public Font CountCTextfont5
	{
		get
		{
			if (_oCountCText5 != null)
			{
				return _oCountCText5.font;
			}
			return null;
		}
		set
		{
			if (CountCTextfont5 != value && _oCountCText5 != null)
			{
				_oCountCText5.font = value;
			}
		}
	}

	public Vector3 TextPosition1
	{
		get
		{
			if (_oTextRectTransform1 != null)
			{
				return _oTextRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TextPosition1 != value && _oTextRectTransform1 != null)
			{
				_oTextRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 TextPosition2
	{
		get
		{
			if (_oTextRectTransform2 != null)
			{
				return _oTextRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TextPosition2 != value && _oTextRectTransform2 != null)
			{
				_oTextRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 TextPosition3
	{
		get
		{
			if (_oTextRectTransform3 != null)
			{
				return _oTextRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TextPosition3 != value && _oTextRectTransform3 != null)
			{
				_oTextRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 TextPosition4
	{
		get
		{
			if (_oTextRectTransform4 != null)
			{
				return _oTextRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TextPosition4 != value && _oTextRectTransform4 != null)
			{
				_oTextRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 TextPosition5
	{
		get
		{
			if (_oTextRectTransform5 != null)
			{
				return _oTextRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TextPosition5 != value && _oTextRectTransform5 != null)
			{
				_oTextRectTransform5.localPosition = value;
			}
		}
	}

	public string TextString1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.text;
			}
			return null;
		}
		set
		{
			if (TextString1 != value && _oTextText1 != null)
			{
				_oTextText1.text = value;
			}
		}
	}

	public string TextString2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.text;
			}
			return null;
		}
		set
		{
			if (TextString2 != value && _oTextText2 != null)
			{
				_oTextText2.text = value;
			}
		}
	}

	public string TextString3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.text;
			}
			return null;
		}
		set
		{
			if (TextString3 != value && _oTextText3 != null)
			{
				_oTextText3.text = value;
			}
		}
	}

	public string TextString4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.text;
			}
			return null;
		}
		set
		{
			if (TextString4 != value && _oTextText4 != null)
			{
				_oTextText4.text = value;
			}
		}
	}

	public string TextString5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.text;
			}
			return null;
		}
		set
		{
			if (TextString5 != value && _oTextText5 != null)
			{
				_oTextText5.text = value;
			}
		}
	}

	public Color TextTextcolor1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor1 != value && _oTextText1 != null)
			{
				_oTextText1.color = value;
			}
		}
	}

	public Color TextTextcolor2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor2 != value && _oTextText2 != null)
			{
				_oTextText2.color = value;
			}
		}
	}

	public Color TextTextcolor3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor3 != value && _oTextText3 != null)
			{
				_oTextText3.color = value;
			}
		}
	}

	public Color TextTextcolor4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor4 != value && _oTextText4 != null)
			{
				_oTextText4.color = value;
			}
		}
	}

	public Color TextTextcolor5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor5 != value && _oTextText5 != null)
			{
				_oTextText5.color = value;
			}
		}
	}

	public Font TextTextfont1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.font;
			}
			return null;
		}
		set
		{
			if (TextTextfont1 != value && _oTextText1 != null)
			{
				_oTextText1.font = value;
			}
		}
	}

	public Font TextTextfont2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.font;
			}
			return null;
		}
		set
		{
			if (TextTextfont2 != value && _oTextText2 != null)
			{
				_oTextText2.font = value;
			}
		}
	}

	public Font TextTextfont3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.font;
			}
			return null;
		}
		set
		{
			if (TextTextfont3 != value && _oTextText3 != null)
			{
				_oTextText3.font = value;
			}
		}
	}

	public Font TextTextfont4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.font;
			}
			return null;
		}
		set
		{
			if (TextTextfont4 != value && _oTextText4 != null)
			{
				_oTextText4.font = value;
			}
		}
	}

	public Font TextTextfont5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.font;
			}
			return null;
		}
		set
		{
			if (TextTextfont5 != value && _oTextText5 != null)
			{
				_oTextText5.font = value;
			}
		}
	}

	public int TextFontsize1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.fontSize;
			}
			return 16;
		}
		set
		{
			if (TextFontsize1 != value && _oTextText1 != null)
			{
				_oTextText1.fontSize = value;
			}
		}
	}

	public int TextFontsize2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.fontSize;
			}
			return 16;
		}
		set
		{
			if (TextFontsize2 != value && _oTextText2 != null)
			{
				_oTextText2.fontSize = value;
			}
		}
	}

	public int TextFontsize3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.fontSize;
			}
			return 16;
		}
		set
		{
			if (TextFontsize3 != value && _oTextText3 != null)
			{
				_oTextText3.fontSize = value;
			}
		}
	}

	public int TextFontsize4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.fontSize;
			}
			return 16;
		}
		set
		{
			if (TextFontsize4 != value && _oTextText4 != null)
			{
				_oTextText4.fontSize = value;
			}
		}
	}

	public int TextFontsize5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.fontSize;
			}
			return 16;
		}
		set
		{
			if (TextFontsize5 != value && _oTextText5 != null)
			{
				_oTextText5.fontSize = value;
			}
		}
	}

	public TextAnchor TextAlignment1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.alignment;
			}
			return TextAnchor.MiddleCenter;
		}
		set
		{
			if (TextAlignment1 != value && _oTextText1 != null)
			{
				_oTextText1.alignment = value;
			}
		}
	}

	public TextAnchor TextAlignment2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.alignment;
			}
			return TextAnchor.MiddleCenter;
		}
		set
		{
			if (TextAlignment2 != value && _oTextText2 != null)
			{
				_oTextText2.alignment = value;
			}
		}
	}

	public TextAnchor TextAlignment3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.alignment;
			}
			return TextAnchor.MiddleCenter;
		}
		set
		{
			if (TextAlignment3 != value && _oTextText3 != null)
			{
				_oTextText3.alignment = value;
			}
		}
	}

	public TextAnchor TextAlignment4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.alignment;
			}
			return TextAnchor.MiddleCenter;
		}
		set
		{
			if (TextAlignment4 != value && _oTextText4 != null)
			{
				_oTextText4.alignment = value;
			}
		}
	}

	public TextAnchor TextAlignment5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.alignment;
			}
			return TextAnchor.MiddleCenter;
		}
		set
		{
			if (TextAlignment5 != value && _oTextText5 != null)
			{
				_oTextText5.alignment = value;
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
			case "Message1":
				_oMessage1 = transform.gameObject;
				_oMessageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Message2":
				_oMessage2 = transform.gameObject;
				_oMessageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Message3":
				_oMessage3 = transform.gameObject;
				_oMessageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Message4":
				_oMessage4 = transform.gameObject;
				_oMessageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Message5":
				_oMessage5 = transform.gameObject;
				_oMessageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Image1":
				_oImage1 = transform.gameObject;
				_oImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image2":
				_oImage2 = transform.gameObject;
				_oImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image3":
				_oImage3 = transform.gameObject;
				_oImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image4":
				_oImage4 = transform.gameObject;
				_oImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image5":
				_oImage5 = transform.gameObject;
				_oImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "CountA1":
				_oCountA1 = transform.gameObject;
				_oCountARectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oCountAText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountA2":
				_oCountA2 = transform.gameObject;
				_oCountARectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oCountAText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountA3":
				_oCountA3 = transform.gameObject;
				_oCountARectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oCountAText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountA4":
				_oCountA4 = transform.gameObject;
				_oCountARectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oCountAText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountA5":
				_oCountA5 = transform.gameObject;
				_oCountARectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oCountAText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountB1":
				_oCountB1 = transform.gameObject;
				_oCountBRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oCountBText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountB2":
				_oCountB2 = transform.gameObject;
				_oCountBRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oCountBText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountB3":
				_oCountB3 = transform.gameObject;
				_oCountBRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oCountBText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountB4":
				_oCountB4 = transform.gameObject;
				_oCountBRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oCountBText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountB5":
				_oCountB5 = transform.gameObject;
				_oCountBRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oCountBText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountC1":
				_oCountC1 = transform.gameObject;
				_oCountCRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oCountCText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountC2":
				_oCountC2 = transform.gameObject;
				_oCountCRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oCountCText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountC3":
				_oCountC3 = transform.gameObject;
				_oCountCRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oCountCText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountC4":
				_oCountC4 = transform.gameObject;
				_oCountCRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oCountCText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CountC5":
				_oCountC5 = transform.gameObject;
				_oCountCRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oCountCText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text1":
				_oText1 = transform.gameObject;
				_oTextRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text2":
				_oText2 = transform.gameObject;
				_oTextRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text3":
				_oText3 = transform.gameObject;
				_oTextRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text4":
				_oText4 = transform.gameObject;
				_oTextRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text5":
				_oText5 = transform.gameObject;
				_oTextRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetMessageShow(int index)
	{
		return index switch
		{
			1 => MessageShow1, 
			2 => MessageShow2, 
			3 => MessageShow3, 
			4 => MessageShow4, 
			5 => MessageShow5, 
			_ => false, 
		};
	}

	public void SetMessageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MessageShow1 = value;
			break;
		case 2:
			MessageShow2 = value;
			break;
		case 3:
			MessageShow3 = value;
			break;
		case 4:
			MessageShow4 = value;
			break;
		case 5:
			MessageShow5 = value;
			break;
		}
	}

	public Vector3 GetMessageScale(int index)
	{
		return index switch
		{
			1 => MessageScale1, 
			2 => MessageScale2, 
			3 => MessageScale3, 
			4 => MessageScale4, 
			5 => MessageScale5, 
			_ => Vector3.zero, 
		};
	}

	public void SetMessageScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			MessageScale1 = value;
			break;
		case 2:
			MessageScale2 = value;
			break;
		case 3:
			MessageScale3 = value;
			break;
		case 4:
			MessageScale4 = value;
			break;
		case 5:
			MessageScale5 = value;
			break;
		}
	}

	public Sprite GetImageSprite(int index)
	{
		return index switch
		{
			1 => ImageSprite1, 
			2 => ImageSprite2, 
			3 => ImageSprite3, 
			4 => ImageSprite4, 
			5 => ImageSprite5, 
			_ => null, 
		};
	}

	public void SetImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ImageSprite1 = value;
			break;
		case 2:
			ImageSprite2 = value;
			break;
		case 3:
			ImageSprite3 = value;
			break;
		case 4:
			ImageSprite4 = value;
			break;
		case 5:
			ImageSprite5 = value;
			break;
		}
	}

	public void SetMessagePosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			MessagePosition1 = value;
			break;
		case 2:
			MessagePosition2 = value;
			break;
		case 3:
			MessagePosition3 = value;
			break;
		case 4:
			MessagePosition4 = value;
			break;
		case 5:
			MessagePosition5 = value;
			break;
		}
	}

	public void ImageNtvsize1()
	{
		if (_oImageImage1 != null)
		{
			_oImageImage1.SetNativeSize();
		}
	}

	public void ImageNtvsize2()
	{
		if (_oImageImage2 != null)
		{
			_oImageImage2.SetNativeSize();
		}
	}

	public void ImageNtvsize3()
	{
		if (_oImageImage3 != null)
		{
			_oImageImage3.SetNativeSize();
		}
	}

	public void ImageNtvsize4()
	{
		if (_oImageImage4 != null)
		{
			_oImageImage4.SetNativeSize();
		}
	}

	public void ImageNtvsize5()
	{
		if (_oImageImage5 != null)
		{
			_oImageImage5.SetNativeSize();
		}
	}

	public void CallImageNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			ImageNtvsize1();
			break;
		case 2:
			ImageNtvsize2();
			break;
		case 3:
			ImageNtvsize3();
			break;
		case 4:
			ImageNtvsize4();
			break;
		case 5:
			ImageNtvsize5();
			break;
		}
	}

	public Vector3 GetCountAPosition(int index)
	{
		return index switch
		{
			1 => CountAPosition1, 
			2 => CountAPosition2, 
			3 => CountAPosition3, 
			4 => CountAPosition4, 
			5 => CountAPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetCountAPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CountAPosition1 = value;
			break;
		case 2:
			CountAPosition2 = value;
			break;
		case 3:
			CountAPosition3 = value;
			break;
		case 4:
			CountAPosition4 = value;
			break;
		case 5:
			CountAPosition5 = value;
			break;
		}
	}

	public string GetCountAString(int index)
	{
		return index switch
		{
			1 => CountAString1, 
			2 => CountAString2, 
			3 => CountAString3, 
			4 => CountAString4, 
			5 => CountAString5, 
			_ => null, 
		};
	}

	public void SetCountAString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CountAString1 = value;
			break;
		case 2:
			CountAString2 = value;
			break;
		case 3:
			CountAString3 = value;
			break;
		case 4:
			CountAString4 = value;
			break;
		case 5:
			CountAString5 = value;
			break;
		}
	}

	public Font GetCountATextfont(int index)
	{
		return index switch
		{
			1 => CountATextfont1, 
			2 => CountATextfont2, 
			3 => CountATextfont3, 
			4 => CountATextfont4, 
			5 => CountATextfont5, 
			_ => null, 
		};
	}

	public void SetCountATextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			CountATextfont1 = value;
			break;
		case 2:
			CountATextfont2 = value;
			break;
		case 3:
			CountATextfont3 = value;
			break;
		case 4:
			CountATextfont4 = value;
			break;
		case 5:
			CountATextfont5 = value;
			break;
		}
	}

	public Vector3 GetCountBPosition(int index)
	{
		return index switch
		{
			1 => CountBPosition1, 
			2 => CountBPosition2, 
			3 => CountBPosition3, 
			4 => CountBPosition4, 
			5 => CountBPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetCountBPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CountBPosition1 = value;
			break;
		case 2:
			CountBPosition2 = value;
			break;
		case 3:
			CountBPosition3 = value;
			break;
		case 4:
			CountBPosition4 = value;
			break;
		case 5:
			CountBPosition5 = value;
			break;
		}
	}

	public string GetCountBString(int index)
	{
		return index switch
		{
			1 => CountBString1, 
			2 => CountBString2, 
			3 => CountBString3, 
			4 => CountBString4, 
			5 => CountBString5, 
			_ => null, 
		};
	}

	public void SetCountBString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CountBString1 = value;
			break;
		case 2:
			CountBString2 = value;
			break;
		case 3:
			CountBString3 = value;
			break;
		case 4:
			CountBString4 = value;
			break;
		case 5:
			CountBString5 = value;
			break;
		}
	}

	public Font GetCountBTextfont(int index)
	{
		return index switch
		{
			1 => CountBTextfont1, 
			2 => CountBTextfont2, 
			3 => CountBTextfont3, 
			4 => CountBTextfont4, 
			5 => CountBTextfont5, 
			_ => null, 
		};
	}

	public void SetCountBTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			CountBTextfont1 = value;
			break;
		case 2:
			CountBTextfont2 = value;
			break;
		case 3:
			CountBTextfont3 = value;
			break;
		case 4:
			CountBTextfont4 = value;
			break;
		case 5:
			CountBTextfont5 = value;
			break;
		}
	}

	public Vector3 GetCountCPosition(int index)
	{
		return index switch
		{
			1 => CountCPosition1, 
			2 => CountCPosition2, 
			3 => CountCPosition3, 
			4 => CountCPosition4, 
			5 => CountCPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetCountCPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CountCPosition1 = value;
			break;
		case 2:
			CountCPosition2 = value;
			break;
		case 3:
			CountCPosition3 = value;
			break;
		case 4:
			CountCPosition4 = value;
			break;
		case 5:
			CountCPosition5 = value;
			break;
		}
	}

	public string GetCountCString(int index)
	{
		return index switch
		{
			1 => CountCString1, 
			2 => CountCString2, 
			3 => CountCString3, 
			4 => CountCString4, 
			5 => CountCString5, 
			_ => null, 
		};
	}

	public void SetCountCString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CountCString1 = value;
			break;
		case 2:
			CountCString2 = value;
			break;
		case 3:
			CountCString3 = value;
			break;
		case 4:
			CountCString4 = value;
			break;
		case 5:
			CountCString5 = value;
			break;
		}
	}

	public Font GetCountCTextfont(int index)
	{
		return index switch
		{
			1 => CountCTextfont1, 
			2 => CountCTextfont2, 
			3 => CountCTextfont3, 
			4 => CountCTextfont4, 
			5 => CountCTextfont5, 
			_ => null, 
		};
	}

	public void SetCountCTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			CountCTextfont1 = value;
			break;
		case 2:
			CountCTextfont2 = value;
			break;
		case 3:
			CountCTextfont3 = value;
			break;
		case 4:
			CountCTextfont4 = value;
			break;
		case 5:
			CountCTextfont5 = value;
			break;
		}
	}

	public Vector3 GetTextPosition(int index)
	{
		return index switch
		{
			1 => TextPosition1, 
			2 => TextPosition2, 
			3 => TextPosition3, 
			4 => TextPosition4, 
			5 => TextPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetTextPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			TextPosition1 = value;
			break;
		case 2:
			TextPosition2 = value;
			break;
		case 3:
			TextPosition3 = value;
			break;
		case 4:
			TextPosition4 = value;
			break;
		case 5:
			TextPosition5 = value;
			break;
		}
	}

	public string GetTextString(int index)
	{
		return index switch
		{
			1 => TextString1, 
			2 => TextString2, 
			3 => TextString3, 
			4 => TextString4, 
			5 => TextString5, 
			_ => null, 
		};
	}

	public void SetTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TextString1 = value;
			break;
		case 2:
			TextString2 = value;
			break;
		case 3:
			TextString3 = value;
			break;
		case 4:
			TextString4 = value;
			break;
		case 5:
			TextString5 = value;
			break;
		}
	}

	public Color GetTextTextcolor(int index)
	{
		return index switch
		{
			1 => TextTextcolor1, 
			2 => TextTextcolor2, 
			3 => TextTextcolor3, 
			4 => TextTextcolor4, 
			5 => TextTextcolor5, 
			_ => Color.white, 
		};
	}

	public void SetTextTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			TextTextcolor1 = value;
			break;
		case 2:
			TextTextcolor2 = value;
			break;
		case 3:
			TextTextcolor3 = value;
			break;
		case 4:
			TextTextcolor4 = value;
			break;
		case 5:
			TextTextcolor5 = value;
			break;
		}
	}

	public Font GetTextTextfont(int index)
	{
		return index switch
		{
			1 => TextTextfont1, 
			2 => TextTextfont2, 
			3 => TextTextfont3, 
			4 => TextTextfont4, 
			5 => TextTextfont5, 
			_ => null, 
		};
	}

	public void SetTextTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			TextTextfont1 = value;
			break;
		case 2:
			TextTextfont2 = value;
			break;
		case 3:
			TextTextfont3 = value;
			break;
		case 4:
			TextTextfont4 = value;
			break;
		case 5:
			TextTextfont5 = value;
			break;
		}
	}

	public int GetTextFontsize(int index)
	{
		return index switch
		{
			1 => TextFontsize1, 
			2 => TextFontsize2, 
			3 => TextFontsize3, 
			4 => TextFontsize4, 
			5 => TextFontsize5, 
			_ => 16, 
		};
	}

	public void SetTextFontsize(int index, int value)
	{
		switch (index)
		{
		case 1:
			TextFontsize1 = value;
			break;
		case 2:
			TextFontsize2 = value;
			break;
		case 3:
			TextFontsize3 = value;
			break;
		case 4:
			TextFontsize4 = value;
			break;
		case 5:
			TextFontsize5 = value;
			break;
		}
	}

	public TextAnchor GetTextAlignment(int index)
	{
		return index switch
		{
			1 => TextAlignment1, 
			2 => TextAlignment2, 
			3 => TextAlignment3, 
			4 => TextAlignment4, 
			5 => TextAlignment5, 
			_ => TextAnchor.MiddleCenter, 
		};
	}

	public void SetTextAlignment(int index, TextAnchor value)
	{
		switch (index)
		{
		case 1:
			TextAlignment1 = value;
			break;
		case 2:
			TextAlignment2 = value;
			break;
		case 3:
			TextAlignment3 = value;
			break;
		case 4:
			TextAlignment4 = value;
			break;
		case 5:
			TextAlignment5 = value;
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
