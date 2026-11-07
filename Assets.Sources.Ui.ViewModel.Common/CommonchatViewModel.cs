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
public class CommonchatViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessage1;

	private GameObject _oMessage2;

	private GameObject _oMessage3;

	private GameObject _oMessage4;

	private GameObject _oMessage5;

	private GameObject _oMessage6;

	private GameObject _oMessage7;

	private GameObject _oMessage8;

	private GameObject _oMessage9;

	private GameObject _oMessage10;

	private Text _oMessageText1;

	private Text _oMessageText2;

	private Text _oMessageText3;

	private Text _oMessageText4;

	private Text _oMessageText5;

	private Text _oMessageText6;

	private Text _oMessageText7;

	private Text _oMessageText8;

	private Text _oMessageText9;

	private Text _oMessageText10;

	private CanvasGroup _oMessageCanvasGroup1;

	private CanvasGroup _oMessageCanvasGroup2;

	private CanvasGroup _oMessageCanvasGroup3;

	private CanvasGroup _oMessageCanvasGroup4;

	private CanvasGroup _oMessageCanvasGroup5;

	private CanvasGroup _oMessageCanvasGroup6;

	private CanvasGroup _oMessageCanvasGroup7;

	private CanvasGroup _oMessageCanvasGroup8;

	private CanvasGroup _oMessageCanvasGroup9;

	private CanvasGroup _oMessageCanvasGroup10;

	private GameObject _oMessageVip1;

	private GameObject _oMessageVip2;

	private GameObject _oMessageVip3;

	private GameObject _oMessageVip4;

	private GameObject _oMessageVip5;

	private GameObject _oMessageVip6;

	private Image _oMessageVipImage1;

	private Image _oMessageVipImage2;

	private Image _oMessageVipImage3;

	private Image _oMessageVipImage4;

	private Image _oMessageVipImage5;

	private Image _oMessageVipImage6;

	private GameObject _oHononaryBgImage7;

	private GameObject _oHononaryBgImage8;

	private GameObject _oHononaryBgImage9;

	private GameObject _oHononaryBgImage10;

	private CanvasGroup _oHononaryBgImageCanvasGroup7;

	private CanvasGroup _oHononaryBgImageCanvasGroup8;

	private CanvasGroup _oHononaryBgImageCanvasGroup9;

	private CanvasGroup _oHononaryBgImageCanvasGroup10;

	private Image _oHononaryBgImageImage7;

	private Image _oHononaryBgImageImage8;

	private Image _oHononaryBgImageImage9;

	private Image _oHononaryBgImageImage10;

	private GameObject _oHonoaryImage7;

	private GameObject _oHonoaryImage8;

	private GameObject _oHonoaryImage9;

	private GameObject _oHonoaryImage10;

	private Image _oHonoaryImageImage7;

	private Image _oHonoaryImageImage8;

	private Image _oHonoaryImageImage9;

	private Image _oHonoaryImageImage10;

	private GameObject _oInputPanel;

	private GameObject _oChatTypeText;

	private Text _oChatTypeTextText;

	private GameObject _oChatInputText;

	private InputField _oChatInputTextInputField;

	private GameObject _oText;

	private Text _oTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Commonchat";

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

	public bool MessageShow6
	{
		get
		{
			if (_oMessage6 != null)
			{
				return _oMessage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow6 != value && _oMessage6 != null)
			{
				_oMessage6.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow7
	{
		get
		{
			if (_oMessage7 != null)
			{
				return _oMessage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow7 != value && _oMessage7 != null)
			{
				_oMessage7.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow8
	{
		get
		{
			if (_oMessage8 != null)
			{
				return _oMessage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow8 != value && _oMessage8 != null)
			{
				_oMessage8.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow9
	{
		get
		{
			if (_oMessage9 != null)
			{
				return _oMessage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow9 != value && _oMessage9 != null)
			{
				_oMessage9.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow10
	{
		get
		{
			if (_oMessage10 != null)
			{
				return _oMessage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow10 != value && _oMessage10 != null)
			{
				_oMessage10.SetObjectActive(value);
			}
		}
	}

	public string MessageString1
	{
		get
		{
			if (_oMessageText1 != null)
			{
				return _oMessageText1.text;
			}
			return null;
		}
		set
		{
			if (MessageString1 != value && _oMessageText1 != null)
			{
				_oMessageText1.text = value;
			}
		}
	}

	public string MessageString2
	{
		get
		{
			if (_oMessageText2 != null)
			{
				return _oMessageText2.text;
			}
			return null;
		}
		set
		{
			if (MessageString2 != value && _oMessageText2 != null)
			{
				_oMessageText2.text = value;
			}
		}
	}

	public string MessageString3
	{
		get
		{
			if (_oMessageText3 != null)
			{
				return _oMessageText3.text;
			}
			return null;
		}
		set
		{
			if (MessageString3 != value && _oMessageText3 != null)
			{
				_oMessageText3.text = value;
			}
		}
	}

	public string MessageString4
	{
		get
		{
			if (_oMessageText4 != null)
			{
				return _oMessageText4.text;
			}
			return null;
		}
		set
		{
			if (MessageString4 != value && _oMessageText4 != null)
			{
				_oMessageText4.text = value;
			}
		}
	}

	public string MessageString5
	{
		get
		{
			if (_oMessageText5 != null)
			{
				return _oMessageText5.text;
			}
			return null;
		}
		set
		{
			if (MessageString5 != value && _oMessageText5 != null)
			{
				_oMessageText5.text = value;
			}
		}
	}

	public string MessageString6
	{
		get
		{
			if (_oMessageText6 != null)
			{
				return _oMessageText6.text;
			}
			return null;
		}
		set
		{
			if (MessageString6 != value && _oMessageText6 != null)
			{
				_oMessageText6.text = value;
			}
		}
	}

	public string MessageString7
	{
		get
		{
			if (_oMessageText7 != null)
			{
				return _oMessageText7.text;
			}
			return null;
		}
		set
		{
			if (MessageString7 != value && _oMessageText7 != null)
			{
				_oMessageText7.text = value;
			}
		}
	}

	public string MessageString8
	{
		get
		{
			if (_oMessageText8 != null)
			{
				return _oMessageText8.text;
			}
			return null;
		}
		set
		{
			if (MessageString8 != value && _oMessageText8 != null)
			{
				_oMessageText8.text = value;
			}
		}
	}

	public string MessageString9
	{
		get
		{
			if (_oMessageText9 != null)
			{
				return _oMessageText9.text;
			}
			return null;
		}
		set
		{
			if (MessageString9 != value && _oMessageText9 != null)
			{
				_oMessageText9.text = value;
			}
		}
	}

	public string MessageString10
	{
		get
		{
			if (_oMessageText10 != null)
			{
				return _oMessageText10.text;
			}
			return null;
		}
		set
		{
			if (MessageString10 != value && _oMessageText10 != null)
			{
				_oMessageText10.text = value;
			}
		}
	}

	public float MessageAlpha1
	{
		get
		{
			if (_oMessageCanvasGroup1 != null)
			{
				return _oMessageCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha1 != value && _oMessageCanvasGroup1 != null)
			{
				_oMessageCanvasGroup1.alpha = value;
			}
		}
	}

	public float MessageAlpha2
	{
		get
		{
			if (_oMessageCanvasGroup2 != null)
			{
				return _oMessageCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha2 != value && _oMessageCanvasGroup2 != null)
			{
				_oMessageCanvasGroup2.alpha = value;
			}
		}
	}

	public float MessageAlpha3
	{
		get
		{
			if (_oMessageCanvasGroup3 != null)
			{
				return _oMessageCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha3 != value && _oMessageCanvasGroup3 != null)
			{
				_oMessageCanvasGroup3.alpha = value;
			}
		}
	}

	public float MessageAlpha4
	{
		get
		{
			if (_oMessageCanvasGroup4 != null)
			{
				return _oMessageCanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha4 != value && _oMessageCanvasGroup4 != null)
			{
				_oMessageCanvasGroup4.alpha = value;
			}
		}
	}

	public float MessageAlpha5
	{
		get
		{
			if (_oMessageCanvasGroup5 != null)
			{
				return _oMessageCanvasGroup5.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha5 != value && _oMessageCanvasGroup5 != null)
			{
				_oMessageCanvasGroup5.alpha = value;
			}
		}
	}

	public float MessageAlpha6
	{
		get
		{
			if (_oMessageCanvasGroup6 != null)
			{
				return _oMessageCanvasGroup6.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha6 != value && _oMessageCanvasGroup6 != null)
			{
				_oMessageCanvasGroup6.alpha = value;
			}
		}
	}

	public float MessageAlpha7
	{
		get
		{
			if (_oMessageCanvasGroup7 != null)
			{
				return _oMessageCanvasGroup7.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha7 != value && _oMessageCanvasGroup7 != null)
			{
				_oMessageCanvasGroup7.alpha = value;
			}
		}
	}

	public float MessageAlpha8
	{
		get
		{
			if (_oMessageCanvasGroup8 != null)
			{
				return _oMessageCanvasGroup8.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha8 != value && _oMessageCanvasGroup8 != null)
			{
				_oMessageCanvasGroup8.alpha = value;
			}
		}
	}

	public float MessageAlpha9
	{
		get
		{
			if (_oMessageCanvasGroup9 != null)
			{
				return _oMessageCanvasGroup9.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha9 != value && _oMessageCanvasGroup9 != null)
			{
				_oMessageCanvasGroup9.alpha = value;
			}
		}
	}

	public float MessageAlpha10
	{
		get
		{
			if (_oMessageCanvasGroup10 != null)
			{
				return _oMessageCanvasGroup10.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha10 != value && _oMessageCanvasGroup10 != null)
			{
				_oMessageCanvasGroup10.alpha = value;
			}
		}
	}

	public bool MessageVipShow1
	{
		get
		{
			if (_oMessageVip1 != null)
			{
				return _oMessageVip1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow1 != value && _oMessageVip1 != null)
			{
				_oMessageVip1.SetObjectActive(value);
			}
		}
	}

	public bool MessageVipShow2
	{
		get
		{
			if (_oMessageVip2 != null)
			{
				return _oMessageVip2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow2 != value && _oMessageVip2 != null)
			{
				_oMessageVip2.SetObjectActive(value);
			}
		}
	}

	public bool MessageVipShow3
	{
		get
		{
			if (_oMessageVip3 != null)
			{
				return _oMessageVip3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow3 != value && _oMessageVip3 != null)
			{
				_oMessageVip3.SetObjectActive(value);
			}
		}
	}

	public bool MessageVipShow4
	{
		get
		{
			if (_oMessageVip4 != null)
			{
				return _oMessageVip4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow4 != value && _oMessageVip4 != null)
			{
				_oMessageVip4.SetObjectActive(value);
			}
		}
	}

	public bool MessageVipShow5
	{
		get
		{
			if (_oMessageVip5 != null)
			{
				return _oMessageVip5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow5 != value && _oMessageVip5 != null)
			{
				_oMessageVip5.SetObjectActive(value);
			}
		}
	}

	public bool MessageVipShow6
	{
		get
		{
			if (_oMessageVip6 != null)
			{
				return _oMessageVip6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageVipShow6 != value && _oMessageVip6 != null)
			{
				_oMessageVip6.SetObjectActive(value);
			}
		}
	}

	public Sprite MessageVipSprite1
	{
		get
		{
			if (_oMessageVipImage1 != null)
			{
				return _oMessageVipImage1.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite1 != value && _oMessageVipImage1 != null)
			{
				_oMessageVipImage1.sprite = value;
			}
		}
	}

	public Sprite MessageVipSprite2
	{
		get
		{
			if (_oMessageVipImage2 != null)
			{
				return _oMessageVipImage2.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite2 != value && _oMessageVipImage2 != null)
			{
				_oMessageVipImage2.sprite = value;
			}
		}
	}

	public Sprite MessageVipSprite3
	{
		get
		{
			if (_oMessageVipImage3 != null)
			{
				return _oMessageVipImage3.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite3 != value && _oMessageVipImage3 != null)
			{
				_oMessageVipImage3.sprite = value;
			}
		}
	}

	public Sprite MessageVipSprite4
	{
		get
		{
			if (_oMessageVipImage4 != null)
			{
				return _oMessageVipImage4.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite4 != value && _oMessageVipImage4 != null)
			{
				_oMessageVipImage4.sprite = value;
			}
		}
	}

	public Sprite MessageVipSprite5
	{
		get
		{
			if (_oMessageVipImage5 != null)
			{
				return _oMessageVipImage5.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite5 != value && _oMessageVipImage5 != null)
			{
				_oMessageVipImage5.sprite = value;
			}
		}
	}

	public Sprite MessageVipSprite6
	{
		get
		{
			if (_oMessageVipImage6 != null)
			{
				return _oMessageVipImage6.sprite;
			}
			return null;
		}
		set
		{
			if (MessageVipSprite6 != value && _oMessageVipImage6 != null)
			{
				_oMessageVipImage6.sprite = value;
			}
		}
	}

	public bool HononaryBgImageShow7
	{
		get
		{
			if (_oHononaryBgImage7 != null)
			{
				return _oHononaryBgImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HononaryBgImageShow7 != value && _oHononaryBgImage7 != null)
			{
				_oHononaryBgImage7.SetObjectActive(value);
			}
		}
	}

	public bool HononaryBgImageShow8
	{
		get
		{
			if (_oHononaryBgImage8 != null)
			{
				return _oHononaryBgImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HononaryBgImageShow8 != value && _oHononaryBgImage8 != null)
			{
				_oHononaryBgImage8.SetObjectActive(value);
			}
		}
	}

	public bool HononaryBgImageShow9
	{
		get
		{
			if (_oHononaryBgImage9 != null)
			{
				return _oHononaryBgImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HononaryBgImageShow9 != value && _oHononaryBgImage9 != null)
			{
				_oHononaryBgImage9.SetObjectActive(value);
			}
		}
	}

	public bool HononaryBgImageShow10
	{
		get
		{
			if (_oHononaryBgImage10 != null)
			{
				return _oHononaryBgImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HononaryBgImageShow10 != value && _oHononaryBgImage10 != null)
			{
				_oHononaryBgImage10.SetObjectActive(value);
			}
		}
	}

	public float HononaryBgImageAlpha7
	{
		get
		{
			if (_oHononaryBgImageCanvasGroup7 != null)
			{
				return _oHononaryBgImageCanvasGroup7.alpha;
			}
			return 0f;
		}
		set
		{
			if (HononaryBgImageAlpha7 != value && _oHononaryBgImageCanvasGroup7 != null)
			{
				_oHononaryBgImageCanvasGroup7.alpha = value;
			}
		}
	}

	public float HononaryBgImageAlpha8
	{
		get
		{
			if (_oHononaryBgImageCanvasGroup8 != null)
			{
				return _oHononaryBgImageCanvasGroup8.alpha;
			}
			return 0f;
		}
		set
		{
			if (HononaryBgImageAlpha8 != value && _oHononaryBgImageCanvasGroup8 != null)
			{
				_oHononaryBgImageCanvasGroup8.alpha = value;
			}
		}
	}

	public float HononaryBgImageAlpha9
	{
		get
		{
			if (_oHononaryBgImageCanvasGroup9 != null)
			{
				return _oHononaryBgImageCanvasGroup9.alpha;
			}
			return 0f;
		}
		set
		{
			if (HononaryBgImageAlpha9 != value && _oHononaryBgImageCanvasGroup9 != null)
			{
				_oHononaryBgImageCanvasGroup9.alpha = value;
			}
		}
	}

	public float HononaryBgImageAlpha10
	{
		get
		{
			if (_oHononaryBgImageCanvasGroup10 != null)
			{
				return _oHononaryBgImageCanvasGroup10.alpha;
			}
			return 0f;
		}
		set
		{
			if (HononaryBgImageAlpha10 != value && _oHononaryBgImageCanvasGroup10 != null)
			{
				_oHononaryBgImageCanvasGroup10.alpha = value;
			}
		}
	}

	public Sprite HononaryBgImageSprite7
	{
		get
		{
			if (_oHononaryBgImageImage7 != null)
			{
				return _oHononaryBgImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (HononaryBgImageSprite7 != value && _oHononaryBgImageImage7 != null)
			{
				_oHononaryBgImageImage7.sprite = value;
			}
		}
	}

	public Sprite HononaryBgImageSprite8
	{
		get
		{
			if (_oHononaryBgImageImage8 != null)
			{
				return _oHononaryBgImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (HononaryBgImageSprite8 != value && _oHononaryBgImageImage8 != null)
			{
				_oHononaryBgImageImage8.sprite = value;
			}
		}
	}

	public Sprite HononaryBgImageSprite9
	{
		get
		{
			if (_oHononaryBgImageImage9 != null)
			{
				return _oHononaryBgImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (HononaryBgImageSprite9 != value && _oHononaryBgImageImage9 != null)
			{
				_oHononaryBgImageImage9.sprite = value;
			}
		}
	}

	public Sprite HononaryBgImageSprite10
	{
		get
		{
			if (_oHononaryBgImageImage10 != null)
			{
				return _oHononaryBgImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (HononaryBgImageSprite10 != value && _oHononaryBgImageImage10 != null)
			{
				_oHononaryBgImageImage10.sprite = value;
			}
		}
	}

	public Sprite HonoaryImageSprite7
	{
		get
		{
			if (_oHonoaryImageImage7 != null)
			{
				return _oHonoaryImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (HonoaryImageSprite7 != value && _oHonoaryImageImage7 != null)
			{
				_oHonoaryImageImage7.sprite = value;
			}
		}
	}

	public Sprite HonoaryImageSprite8
	{
		get
		{
			if (_oHonoaryImageImage8 != null)
			{
				return _oHonoaryImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (HonoaryImageSprite8 != value && _oHonoaryImageImage8 != null)
			{
				_oHonoaryImageImage8.sprite = value;
			}
		}
	}

	public Sprite HonoaryImageSprite9
	{
		get
		{
			if (_oHonoaryImageImage9 != null)
			{
				return _oHonoaryImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (HonoaryImageSprite9 != value && _oHonoaryImageImage9 != null)
			{
				_oHonoaryImageImage9.sprite = value;
			}
		}
	}

	public Sprite HonoaryImageSprite10
	{
		get
		{
			if (_oHonoaryImageImage10 != null)
			{
				return _oHonoaryImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (HonoaryImageSprite10 != value && _oHonoaryImageImage10 != null)
			{
				_oHonoaryImageImage10.sprite = value;
			}
		}
	}

	public bool InputPanelShow
	{
		get
		{
			if (_oInputPanel != null)
			{
				return _oInputPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (InputPanelShow != value && _oInputPanel != null)
			{
				_oInputPanel.SetObjectActive(value);
			}
		}
	}

	public string ChatTypeTextString
	{
		get
		{
			if (_oChatTypeTextText != null)
			{
				return _oChatTypeTextText.text;
			}
			return null;
		}
		set
		{
			if (ChatTypeTextString != value && _oChatTypeTextText != null)
			{
				_oChatTypeTextText.text = value;
			}
		}
	}

	public Color ChatTypeTextTextcolor
	{
		get
		{
			if (_oChatTypeTextText != null)
			{
				return _oChatTypeTextText.color;
			}
			return Color.white;
		}
		set
		{
			if (ChatTypeTextTextcolor != value && _oChatTypeTextText != null)
			{
				_oChatTypeTextText.color = value;
			}
		}
	}

	public GameObject ChatInputTextObj => _oChatInputText;

	public string ChatInputTextText
	{
		get
		{
			if (_oChatInputTextInputField != null)
			{
				return _oChatInputTextInputField.text;
			}
			return "";
		}
		set
		{
			if (ChatInputTextText != value && _oChatInputTextInputField != null)
			{
				_oChatInputTextInputField.text = value;
			}
		}
	}

	public bool ChatInputTextInputactive
	{
		get
		{
			if (_oChatInputTextInputField != null)
			{
				return _oChatInputTextInputField.isFocused;
			}
			return false;
		}
		set
		{
			if (ChatInputTextInputactive != value && _oChatInputTextInputField != null)
			{
				if (value)
				{
					_oChatInputTextInputField.ActivateInputField();
				}
				else
				{
					_oChatInputTextInputField.DeactivateInputField();
				}
			}
		}
	}

	public InputField.OnChangeEvent ChatInputTextInputchanged
	{
		get
		{
			if (_oChatInputTextInputField != null)
			{
				return _oChatInputTextInputField.onValueChanged;
			}
			return null;
		}
		set
		{
			if (ChatInputTextInputchanged != value && _oChatInputTextInputField != null)
			{
				_oChatInputTextInputField.onValueChanged = value;
			}
		}
	}

	public string TextString
	{
		get
		{
			if (_oTextText != null)
			{
				return _oTextText.text;
			}
			return null;
		}
		set
		{
			if (TextString != value && _oTextText != null)
			{
				_oTextText.text = value;
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
				_oMessageText1 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message2":
				_oMessage2 = transform.gameObject;
				_oMessageText2 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message3":
				_oMessage3 = transform.gameObject;
				_oMessageText3 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message4":
				_oMessage4 = transform.gameObject;
				_oMessageText4 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message5":
				_oMessage5 = transform.gameObject;
				_oMessageText5 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup5 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message6":
				_oMessage6 = transform.gameObject;
				_oMessageText6 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup6 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message7":
				_oMessage7 = transform.gameObject;
				_oMessageText7 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup7 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message8":
				_oMessage8 = transform.gameObject;
				_oMessageText8 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup8 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message9":
				_oMessage9 = transform.gameObject;
				_oMessageText9 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup9 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Message10":
				_oMessage10 = transform.gameObject;
				_oMessageText10 = transform.gameObject.GetComponent<Text>();
				_oMessageCanvasGroup10 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "MessageVip1":
				_oMessageVip1 = transform.gameObject;
				_oMessageVipImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageVip2":
				_oMessageVip2 = transform.gameObject;
				_oMessageVipImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageVip3":
				_oMessageVip3 = transform.gameObject;
				_oMessageVipImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageVip4":
				_oMessageVip4 = transform.gameObject;
				_oMessageVipImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageVip5":
				_oMessageVip5 = transform.gameObject;
				_oMessageVipImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageVip6":
				_oMessageVip6 = transform.gameObject;
				_oMessageVipImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "HononaryBgImage7":
				_oHononaryBgImage7 = transform.gameObject;
				_oHononaryBgImageCanvasGroup7 = transform.gameObject.GetComponent<CanvasGroup>();
				_oHononaryBgImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "HononaryBgImage8":
				_oHononaryBgImage8 = transform.gameObject;
				_oHononaryBgImageCanvasGroup8 = transform.gameObject.GetComponent<CanvasGroup>();
				_oHononaryBgImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "HononaryBgImage9":
				_oHononaryBgImage9 = transform.gameObject;
				_oHononaryBgImageCanvasGroup9 = transform.gameObject.GetComponent<CanvasGroup>();
				_oHononaryBgImageImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "HononaryBgImage10":
				_oHononaryBgImage10 = transform.gameObject;
				_oHononaryBgImageCanvasGroup10 = transform.gameObject.GetComponent<CanvasGroup>();
				_oHononaryBgImageImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonoaryImage7":
				_oHonoaryImage7 = transform.gameObject;
				_oHonoaryImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonoaryImage8":
				_oHonoaryImage8 = transform.gameObject;
				_oHonoaryImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonoaryImage9":
				_oHonoaryImage9 = transform.gameObject;
				_oHonoaryImageImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonoaryImage10":
				_oHonoaryImage10 = transform.gameObject;
				_oHonoaryImageImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "InputPanel":
				_oInputPanel = transform.gameObject;
				break;
			case "ChatTypeText":
				_oChatTypeText = transform.gameObject;
				_oChatTypeTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ChatInputText":
				_oChatInputText = transform.gameObject;
				_oChatInputTextInputField = transform.gameObject.GetComponent<InputField>();
				break;
			case "Text":
				_oText = transform.gameObject;
				_oTextText = transform.gameObject.GetComponent<Text>();
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
			6 => MessageShow6, 
			7 => MessageShow7, 
			8 => MessageShow8, 
			9 => MessageShow9, 
			10 => MessageShow10, 
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
		case 6:
			MessageShow6 = value;
			break;
		case 7:
			MessageShow7 = value;
			break;
		case 8:
			MessageShow8 = value;
			break;
		case 9:
			MessageShow9 = value;
			break;
		case 10:
			MessageShow10 = value;
			break;
		}
	}

	public string GetMessageString(int index)
	{
		return index switch
		{
			1 => MessageString1, 
			2 => MessageString2, 
			3 => MessageString3, 
			4 => MessageString4, 
			5 => MessageString5, 
			6 => MessageString6, 
			7 => MessageString7, 
			8 => MessageString8, 
			9 => MessageString9, 
			10 => MessageString10, 
			_ => null, 
		};
	}

	public void SetMessageString(int index, string value)
	{
		switch (index)
		{
		case 1:
			MessageString1 = value;
			break;
		case 2:
			MessageString2 = value;
			break;
		case 3:
			MessageString3 = value;
			break;
		case 4:
			MessageString4 = value;
			break;
		case 5:
			MessageString5 = value;
			break;
		case 6:
			MessageString6 = value;
			break;
		case 7:
			MessageString7 = value;
			break;
		case 8:
			MessageString8 = value;
			break;
		case 9:
			MessageString9 = value;
			break;
		case 10:
			MessageString10 = value;
			break;
		}
	}

	public float GetMessageAlpha(int index)
	{
		return index switch
		{
			1 => MessageAlpha1, 
			2 => MessageAlpha2, 
			3 => MessageAlpha3, 
			4 => MessageAlpha4, 
			5 => MessageAlpha5, 
			6 => MessageAlpha6, 
			7 => MessageAlpha7, 
			8 => MessageAlpha8, 
			9 => MessageAlpha9, 
			10 => MessageAlpha10, 
			_ => 0f, 
		};
	}

	public void SetMessageAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			MessageAlpha1 = value;
			break;
		case 2:
			MessageAlpha2 = value;
			break;
		case 3:
			MessageAlpha3 = value;
			break;
		case 4:
			MessageAlpha4 = value;
			break;
		case 5:
			MessageAlpha5 = value;
			break;
		case 6:
			MessageAlpha6 = value;
			break;
		case 7:
			MessageAlpha7 = value;
			break;
		case 8:
			MessageAlpha8 = value;
			break;
		case 9:
			MessageAlpha9 = value;
			break;
		case 10:
			MessageAlpha10 = value;
			break;
		}
	}

	public bool GetMessageVipShow(int index)
	{
		return index switch
		{
			1 => MessageVipShow1, 
			2 => MessageVipShow2, 
			3 => MessageVipShow3, 
			4 => MessageVipShow4, 
			5 => MessageVipShow5, 
			6 => MessageVipShow6, 
			_ => false, 
		};
	}

	public void SetMessageVipShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MessageVipShow1 = value;
			break;
		case 2:
			MessageVipShow2 = value;
			break;
		case 3:
			MessageVipShow3 = value;
			break;
		case 4:
			MessageVipShow4 = value;
			break;
		case 5:
			MessageVipShow5 = value;
			break;
		case 6:
			MessageVipShow6 = value;
			break;
		}
	}

	public Sprite GetMessageVipSprite(int index)
	{
		return index switch
		{
			1 => MessageVipSprite1, 
			2 => MessageVipSprite2, 
			3 => MessageVipSprite3, 
			4 => MessageVipSprite4, 
			5 => MessageVipSprite5, 
			6 => MessageVipSprite6, 
			_ => null, 
		};
	}

	public void SetMessageVipSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			MessageVipSprite1 = value;
			break;
		case 2:
			MessageVipSprite2 = value;
			break;
		case 3:
			MessageVipSprite3 = value;
			break;
		case 4:
			MessageVipSprite4 = value;
			break;
		case 5:
			MessageVipSprite5 = value;
			break;
		case 6:
			MessageVipSprite6 = value;
			break;
		}
	}

	public bool GetHononaryBgImageShow(int index)
	{
		return index switch
		{
			7 => HononaryBgImageShow7, 
			8 => HononaryBgImageShow8, 
			9 => HononaryBgImageShow9, 
			10 => HononaryBgImageShow10, 
			_ => false, 
		};
	}

	public void SetHononaryBgImageShow(int index, bool value)
	{
		switch (index)
		{
		case 7:
			HononaryBgImageShow7 = value;
			break;
		case 8:
			HononaryBgImageShow8 = value;
			break;
		case 9:
			HononaryBgImageShow9 = value;
			break;
		case 10:
			HononaryBgImageShow10 = value;
			break;
		}
	}

	public float GetHononaryBgImageAlpha(int index)
	{
		return index switch
		{
			7 => HononaryBgImageAlpha7, 
			8 => HononaryBgImageAlpha8, 
			9 => HononaryBgImageAlpha9, 
			10 => HononaryBgImageAlpha10, 
			_ => 0f, 
		};
	}

	public void SetHononaryBgImageAlpha(int index, float value)
	{
		switch (index)
		{
		case 7:
			HononaryBgImageAlpha7 = value;
			break;
		case 8:
			HononaryBgImageAlpha8 = value;
			break;
		case 9:
			HononaryBgImageAlpha9 = value;
			break;
		case 10:
			HononaryBgImageAlpha10 = value;
			break;
		}
	}

	public Sprite GetHononaryBgImageSprite(int index)
	{
		return index switch
		{
			7 => HononaryBgImageSprite7, 
			8 => HononaryBgImageSprite8, 
			9 => HononaryBgImageSprite9, 
			10 => HononaryBgImageSprite10, 
			_ => null, 
		};
	}

	public void SetHononaryBgImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 7:
			HononaryBgImageSprite7 = value;
			break;
		case 8:
			HononaryBgImageSprite8 = value;
			break;
		case 9:
			HononaryBgImageSprite9 = value;
			break;
		case 10:
			HononaryBgImageSprite10 = value;
			break;
		}
	}

	public Sprite GetHonoaryImageSprite(int index)
	{
		return index switch
		{
			7 => HonoaryImageSprite7, 
			8 => HonoaryImageSprite8, 
			9 => HonoaryImageSprite9, 
			10 => HonoaryImageSprite10, 
			_ => null, 
		};
	}

	public void SetHonoaryImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 7:
			HonoaryImageSprite7 = value;
			break;
		case 8:
			HonoaryImageSprite8 = value;
			break;
		case 9:
			HonoaryImageSprite9 = value;
			break;
		case 10:
			HonoaryImageSprite10 = value;
			break;
		}
	}

	public void HonoaryImageNtvsize7()
	{
		if (_oHonoaryImageImage7 != null)
		{
			_oHonoaryImageImage7.SetNativeSize();
		}
	}

	public void HonoaryImageNtvsize8()
	{
		if (_oHonoaryImageImage8 != null)
		{
			_oHonoaryImageImage8.SetNativeSize();
		}
	}

	public void HonoaryImageNtvsize9()
	{
		if (_oHonoaryImageImage9 != null)
		{
			_oHonoaryImageImage9.SetNativeSize();
		}
	}

	public void HonoaryImageNtvsize10()
	{
		if (_oHonoaryImageImage10 != null)
		{
			_oHonoaryImageImage10.SetNativeSize();
		}
	}

	public void CallHonoaryImageNtvsize(int index)
	{
		switch (index)
		{
		case 7:
			HonoaryImageNtvsize7();
			break;
		case 8:
			HonoaryImageNtvsize8();
			break;
		case 9:
			HonoaryImageNtvsize9();
			break;
		case 10:
			HonoaryImageNtvsize10();
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
