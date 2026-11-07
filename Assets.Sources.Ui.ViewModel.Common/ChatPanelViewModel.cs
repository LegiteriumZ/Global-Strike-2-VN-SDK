using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ChatPanelViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oChatPanel;

	private GameObject _oPanel;

	private GameObject _oInputPanel;

	private GameObject _oImage;

	private GameObject _oChatTypeText;

	private Text _oChatTypeTextText;

	private GameObject _oChatInputText;

	private InputField _oChatInputTextInputField;

	private GameObject _oText;

	private Text _oTextText;

	private GameObject _ogroup1;

	private GameObject _ogroup2;

	private GameObject _ogroup3;

	private GameObject _ogroup4;

	private GameObject _ogroup5;

	private GameObject _ogroup6;

	private CanvasGroup _ogroupCanvasGroup1;

	private CanvasGroup _ogroupCanvasGroup2;

	private CanvasGroup _ogroupCanvasGroup3;

	private CanvasGroup _ogroupCanvasGroup4;

	private CanvasGroup _ogroupCanvasGroup5;

	private CanvasGroup _ogroupCanvasGroup6;

	private GameObject _ovipicon1;

	private GameObject _ovipicon2;

	private GameObject _ovipicon3;

	private GameObject _ovipicon4;

	private GameObject _ovipicon5;

	private GameObject _ovipicon6;

	private Image _ovipiconImage1;

	private Image _ovipiconImage2;

	private Image _ovipiconImage3;

	private Image _ovipiconImage4;

	private Image _ovipiconImage5;

	private Image _ovipiconImage6;

	private GameObject _ochattext1;

	private GameObject _ochattext2;

	private GameObject _ochattext3;

	private GameObject _ochattext4;

	private GameObject _ochattext5;

	private GameObject _ochattext6;

	private RectTransform _ochattextRectTransform1;

	private RectTransform _ochattextRectTransform2;

	private RectTransform _ochattextRectTransform3;

	private RectTransform _ochattextRectTransform4;

	private RectTransform _ochattextRectTransform5;

	private RectTransform _ochattextRectTransform6;

	private Text _ochattextText1;

	private Text _ochattextText2;

	private Text _ochattextText3;

	private Text _ochattextText4;

	private Text _ochattextText5;

	private Text _ochattextText6;

	private GameObject _ohononaryGp1;

	private GameObject _ohononaryGp2;

	private GameObject _ohononaryGp3;

	private GameObject _ohononaryGp4;

	private CanvasGroup _ohononaryGpCanvasGroup1;

	private CanvasGroup _ohononaryGpCanvasGroup2;

	private CanvasGroup _ohononaryGpCanvasGroup3;

	private CanvasGroup _ohononaryGpCanvasGroup4;

	private GameObject _ohbg1;

	private GameObject _ohbg2;

	private GameObject _ohbg3;

	private GameObject _ohbg4;

	private Image _ohbgImage1;

	private Image _ohbgImage2;

	private Image _ohbgImage3;

	private Image _ohbgImage4;

	private GameObject _ohicon1;

	private GameObject _ohicon2;

	private GameObject _ohicon3;

	private GameObject _ohicon4;

	private RectTransform _ohiconRectTransform1;

	private RectTransform _ohiconRectTransform2;

	private RectTransform _ohiconRectTransform3;

	private RectTransform _ohiconRectTransform4;

	private Image _ohiconImage1;

	private Image _ohiconImage2;

	private Image _ohiconImage3;

	private Image _ohiconImage4;

	private GameObject _ohgtext1;

	private GameObject _ohgtext2;

	private GameObject _ohgtext3;

	private GameObject _ohgtext4;

	private RectTransform _ohgtextRectTransform1;

	private RectTransform _ohgtextRectTransform2;

	private RectTransform _ohgtextRectTransform3;

	private RectTransform _ohgtextRectTransform4;

	private Text _ohgtextText1;

	private Text _ohgtextText2;

	private Text _ohgtextText3;

	private Text _ohgtextText4;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ChatPanel";

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

	public UiReferences UI => uiRef;

	public bool ChatPanelShow
	{
		get
		{
			if (_oChatPanel != null)
			{
				return _oChatPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChatPanelShow != value && _oChatPanel != null)
			{
				_oChatPanel.SetObjectActive(value);
			}
		}
	}

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
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

	public bool ImageShow
	{
		get
		{
			if (_oImage != null)
			{
				return _oImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ImageShow != value && _oImage != null)
			{
				_oImage.SetObjectActive(value);
			}
		}
	}

	public bool ChatTypeTextShow
	{
		get
		{
			if (_oChatTypeText != null)
			{
				return _oChatTypeText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChatTypeTextShow != value && _oChatTypeText != null)
			{
				_oChatTypeText.SetObjectActive(value);
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

	public bool ChatInputTextShow
	{
		get
		{
			if (_oChatInputText != null)
			{
				return _oChatInputText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChatInputTextShow != value && _oChatInputText != null)
			{
				_oChatInputText.SetObjectActive(value);
			}
		}
	}

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

	public bool TextShow
	{
		get
		{
			if (_oText != null)
			{
				return _oText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextShow != value && _oText != null)
			{
				_oText.SetObjectActive(value);
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

	public Color TextTextcolor
	{
		get
		{
			if (_oTextText != null)
			{
				return _oTextText.color;
			}
			return Color.white;
		}
		set
		{
			if (TextTextcolor != value && _oTextText != null)
			{
				_oTextText.color = value;
			}
		}
	}

	public bool groupShow1
	{
		get
		{
			if (_ogroup1 != null)
			{
				return _ogroup1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow1 != value && _ogroup1 != null)
			{
				_ogroup1.SetObjectActive(value);
			}
		}
	}

	public bool groupShow2
	{
		get
		{
			if (_ogroup2 != null)
			{
				return _ogroup2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow2 != value && _ogroup2 != null)
			{
				_ogroup2.SetObjectActive(value);
			}
		}
	}

	public bool groupShow3
	{
		get
		{
			if (_ogroup3 != null)
			{
				return _ogroup3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow3 != value && _ogroup3 != null)
			{
				_ogroup3.SetObjectActive(value);
			}
		}
	}

	public bool groupShow4
	{
		get
		{
			if (_ogroup4 != null)
			{
				return _ogroup4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow4 != value && _ogroup4 != null)
			{
				_ogroup4.SetObjectActive(value);
			}
		}
	}

	public bool groupShow5
	{
		get
		{
			if (_ogroup5 != null)
			{
				return _ogroup5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow5 != value && _ogroup5 != null)
			{
				_ogroup5.SetObjectActive(value);
			}
		}
	}

	public bool groupShow6
	{
		get
		{
			if (_ogroup6 != null)
			{
				return _ogroup6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (groupShow6 != value && _ogroup6 != null)
			{
				_ogroup6.SetObjectActive(value);
			}
		}
	}

	public float groupAlpha1
	{
		get
		{
			if (_ogroupCanvasGroup1 != null)
			{
				return _ogroupCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha1 != value && _ogroupCanvasGroup1 != null)
			{
				_ogroupCanvasGroup1.alpha = value;
			}
		}
	}

	public float groupAlpha2
	{
		get
		{
			if (_ogroupCanvasGroup2 != null)
			{
				return _ogroupCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha2 != value && _ogroupCanvasGroup2 != null)
			{
				_ogroupCanvasGroup2.alpha = value;
			}
		}
	}

	public float groupAlpha3
	{
		get
		{
			if (_ogroupCanvasGroup3 != null)
			{
				return _ogroupCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha3 != value && _ogroupCanvasGroup3 != null)
			{
				_ogroupCanvasGroup3.alpha = value;
			}
		}
	}

	public float groupAlpha4
	{
		get
		{
			if (_ogroupCanvasGroup4 != null)
			{
				return _ogroupCanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha4 != value && _ogroupCanvasGroup4 != null)
			{
				_ogroupCanvasGroup4.alpha = value;
			}
		}
	}

	public float groupAlpha5
	{
		get
		{
			if (_ogroupCanvasGroup5 != null)
			{
				return _ogroupCanvasGroup5.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha5 != value && _ogroupCanvasGroup5 != null)
			{
				_ogroupCanvasGroup5.alpha = value;
			}
		}
	}

	public float groupAlpha6
	{
		get
		{
			if (_ogroupCanvasGroup6 != null)
			{
				return _ogroupCanvasGroup6.alpha;
			}
			return 0f;
		}
		set
		{
			if (groupAlpha6 != value && _ogroupCanvasGroup6 != null)
			{
				_ogroupCanvasGroup6.alpha = value;
			}
		}
	}

	public bool vipiconShow1
	{
		get
		{
			if (_ovipicon1 != null)
			{
				return _ovipicon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow1 != value && _ovipicon1 != null)
			{
				_ovipicon1.SetObjectActive(value);
			}
		}
	}

	public bool vipiconShow2
	{
		get
		{
			if (_ovipicon2 != null)
			{
				return _ovipicon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow2 != value && _ovipicon2 != null)
			{
				_ovipicon2.SetObjectActive(value);
			}
		}
	}

	public bool vipiconShow3
	{
		get
		{
			if (_ovipicon3 != null)
			{
				return _ovipicon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow3 != value && _ovipicon3 != null)
			{
				_ovipicon3.SetObjectActive(value);
			}
		}
	}

	public bool vipiconShow4
	{
		get
		{
			if (_ovipicon4 != null)
			{
				return _ovipicon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow4 != value && _ovipicon4 != null)
			{
				_ovipicon4.SetObjectActive(value);
			}
		}
	}

	public bool vipiconShow5
	{
		get
		{
			if (_ovipicon5 != null)
			{
				return _ovipicon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow5 != value && _ovipicon5 != null)
			{
				_ovipicon5.SetObjectActive(value);
			}
		}
	}

	public bool vipiconShow6
	{
		get
		{
			if (_ovipicon6 != null)
			{
				return _ovipicon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (vipiconShow6 != value && _ovipicon6 != null)
			{
				_ovipicon6.SetObjectActive(value);
			}
		}
	}

	public Color vipiconColor1
	{
		get
		{
			if (_ovipiconImage1 != null)
			{
				return _ovipiconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor1 != value && _ovipiconImage1 != null)
			{
				_ovipiconImage1.color = value;
			}
		}
	}

	public Color vipiconColor2
	{
		get
		{
			if (_ovipiconImage2 != null)
			{
				return _ovipiconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor2 != value && _ovipiconImage2 != null)
			{
				_ovipiconImage2.color = value;
			}
		}
	}

	public Color vipiconColor3
	{
		get
		{
			if (_ovipiconImage3 != null)
			{
				return _ovipiconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor3 != value && _ovipiconImage3 != null)
			{
				_ovipiconImage3.color = value;
			}
		}
	}

	public Color vipiconColor4
	{
		get
		{
			if (_ovipiconImage4 != null)
			{
				return _ovipiconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor4 != value && _ovipiconImage4 != null)
			{
				_ovipiconImage4.color = value;
			}
		}
	}

	public Color vipiconColor5
	{
		get
		{
			if (_ovipiconImage5 != null)
			{
				return _ovipiconImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor5 != value && _ovipiconImage5 != null)
			{
				_ovipiconImage5.color = value;
			}
		}
	}

	public Color vipiconColor6
	{
		get
		{
			if (_ovipiconImage6 != null)
			{
				return _ovipiconImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (vipiconColor6 != value && _ovipiconImage6 != null)
			{
				_ovipiconImage6.color = value;
			}
		}
	}

	public Image vipiconImage1
	{
		get
		{
			if (_ovipiconImage1 != null)
			{
				return _ovipiconImage1;
			}
			return null;
		}
		set
		{
			if (vipiconImage1 != value && _ovipiconImage1 != null)
			{
				_ovipiconImage1 = value;
			}
		}
	}

	public Image vipiconImage2
	{
		get
		{
			if (_ovipiconImage2 != null)
			{
				return _ovipiconImage2;
			}
			return null;
		}
		set
		{
			if (vipiconImage2 != value && _ovipiconImage2 != null)
			{
				_ovipiconImage2 = value;
			}
		}
	}

	public Image vipiconImage3
	{
		get
		{
			if (_ovipiconImage3 != null)
			{
				return _ovipiconImage3;
			}
			return null;
		}
		set
		{
			if (vipiconImage3 != value && _ovipiconImage3 != null)
			{
				_ovipiconImage3 = value;
			}
		}
	}

	public Image vipiconImage4
	{
		get
		{
			if (_ovipiconImage4 != null)
			{
				return _ovipiconImage4;
			}
			return null;
		}
		set
		{
			if (vipiconImage4 != value && _ovipiconImage4 != null)
			{
				_ovipiconImage4 = value;
			}
		}
	}

	public Image vipiconImage5
	{
		get
		{
			if (_ovipiconImage5 != null)
			{
				return _ovipiconImage5;
			}
			return null;
		}
		set
		{
			if (vipiconImage5 != value && _ovipiconImage5 != null)
			{
				_ovipiconImage5 = value;
			}
		}
	}

	public Image vipiconImage6
	{
		get
		{
			if (_ovipiconImage6 != null)
			{
				return _ovipiconImage6;
			}
			return null;
		}
		set
		{
			if (vipiconImage6 != value && _ovipiconImage6 != null)
			{
				_ovipiconImage6 = value;
			}
		}
	}

	public Vector3 chattextSize1
	{
		get
		{
			if (_ochattextRectTransform1 != null)
			{
				return _ochattextRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize1 != value && _ochattextRectTransform1 != null)
			{
				_ochattextRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 chattextSize2
	{
		get
		{
			if (_ochattextRectTransform2 != null)
			{
				return _ochattextRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize2 != value && _ochattextRectTransform2 != null)
			{
				_ochattextRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 chattextSize3
	{
		get
		{
			if (_ochattextRectTransform3 != null)
			{
				return _ochattextRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize3 != value && _ochattextRectTransform3 != null)
			{
				_ochattextRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 chattextSize4
	{
		get
		{
			if (_ochattextRectTransform4 != null)
			{
				return _ochattextRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize4 != value && _ochattextRectTransform4 != null)
			{
				_ochattextRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 chattextSize5
	{
		get
		{
			if (_ochattextRectTransform5 != null)
			{
				return _ochattextRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize5 != value && _ochattextRectTransform5 != null)
			{
				_ochattextRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 chattextSize6
	{
		get
		{
			if (_ochattextRectTransform6 != null)
			{
				return _ochattextRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (chattextSize6 != value && _ochattextRectTransform6 != null)
			{
				_ochattextRectTransform6.sizeDelta = value;
			}
		}
	}

	public string chattextString1
	{
		get
		{
			if (_ochattextText1 != null)
			{
				return _ochattextText1.text;
			}
			return null;
		}
		set
		{
			if (chattextString1 != value && _ochattextText1 != null)
			{
				_ochattextText1.text = value;
			}
		}
	}

	public string chattextString2
	{
		get
		{
			if (_ochattextText2 != null)
			{
				return _ochattextText2.text;
			}
			return null;
		}
		set
		{
			if (chattextString2 != value && _ochattextText2 != null)
			{
				_ochattextText2.text = value;
			}
		}
	}

	public string chattextString3
	{
		get
		{
			if (_ochattextText3 != null)
			{
				return _ochattextText3.text;
			}
			return null;
		}
		set
		{
			if (chattextString3 != value && _ochattextText3 != null)
			{
				_ochattextText3.text = value;
			}
		}
	}

	public string chattextString4
	{
		get
		{
			if (_ochattextText4 != null)
			{
				return _ochattextText4.text;
			}
			return null;
		}
		set
		{
			if (chattextString4 != value && _ochattextText4 != null)
			{
				_ochattextText4.text = value;
			}
		}
	}

	public string chattextString5
	{
		get
		{
			if (_ochattextText5 != null)
			{
				return _ochattextText5.text;
			}
			return null;
		}
		set
		{
			if (chattextString5 != value && _ochattextText5 != null)
			{
				_ochattextText5.text = value;
			}
		}
	}

	public string chattextString6
	{
		get
		{
			if (_ochattextText6 != null)
			{
				return _ochattextText6.text;
			}
			return null;
		}
		set
		{
			if (chattextString6 != value && _ochattextText6 != null)
			{
				_ochattextText6.text = value;
			}
		}
	}

	public Color chattextTextcolor1
	{
		get
		{
			if (_ochattextText1 != null)
			{
				return _ochattextText1.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor1 != value && _ochattextText1 != null)
			{
				_ochattextText1.color = value;
			}
		}
	}

	public Color chattextTextcolor2
	{
		get
		{
			if (_ochattextText2 != null)
			{
				return _ochattextText2.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor2 != value && _ochattextText2 != null)
			{
				_ochattextText2.color = value;
			}
		}
	}

	public Color chattextTextcolor3
	{
		get
		{
			if (_ochattextText3 != null)
			{
				return _ochattextText3.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor3 != value && _ochattextText3 != null)
			{
				_ochattextText3.color = value;
			}
		}
	}

	public Color chattextTextcolor4
	{
		get
		{
			if (_ochattextText4 != null)
			{
				return _ochattextText4.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor4 != value && _ochattextText4 != null)
			{
				_ochattextText4.color = value;
			}
		}
	}

	public Color chattextTextcolor5
	{
		get
		{
			if (_ochattextText5 != null)
			{
				return _ochattextText5.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor5 != value && _ochattextText5 != null)
			{
				_ochattextText5.color = value;
			}
		}
	}

	public Color chattextTextcolor6
	{
		get
		{
			if (_ochattextText6 != null)
			{
				return _ochattextText6.color;
			}
			return Color.white;
		}
		set
		{
			if (chattextTextcolor6 != value && _ochattextText6 != null)
			{
				_ochattextText6.color = value;
			}
		}
	}

	public float hononaryGpAlpha1
	{
		get
		{
			if (_ohononaryGpCanvasGroup1 != null)
			{
				return _ohononaryGpCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (hononaryGpAlpha1 != value && _ohononaryGpCanvasGroup1 != null)
			{
				_ohononaryGpCanvasGroup1.alpha = value;
			}
		}
	}

	public float hononaryGpAlpha2
	{
		get
		{
			if (_ohononaryGpCanvasGroup2 != null)
			{
				return _ohononaryGpCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (hononaryGpAlpha2 != value && _ohononaryGpCanvasGroup2 != null)
			{
				_ohononaryGpCanvasGroup2.alpha = value;
			}
		}
	}

	public float hononaryGpAlpha3
	{
		get
		{
			if (_ohononaryGpCanvasGroup3 != null)
			{
				return _ohononaryGpCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (hononaryGpAlpha3 != value && _ohononaryGpCanvasGroup3 != null)
			{
				_ohononaryGpCanvasGroup3.alpha = value;
			}
		}
	}

	public float hononaryGpAlpha4
	{
		get
		{
			if (_ohononaryGpCanvasGroup4 != null)
			{
				return _ohononaryGpCanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (hononaryGpAlpha4 != value && _ohononaryGpCanvasGroup4 != null)
			{
				_ohononaryGpCanvasGroup4.alpha = value;
			}
		}
	}

	public bool hbgShow1
	{
		get
		{
			if (_ohbg1 != null)
			{
				return _ohbg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hbgShow1 != value && _ohbg1 != null)
			{
				_ohbg1.SetObjectActive(value);
			}
		}
	}

	public bool hbgShow2
	{
		get
		{
			if (_ohbg2 != null)
			{
				return _ohbg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hbgShow2 != value && _ohbg2 != null)
			{
				_ohbg2.SetObjectActive(value);
			}
		}
	}

	public bool hbgShow3
	{
		get
		{
			if (_ohbg3 != null)
			{
				return _ohbg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hbgShow3 != value && _ohbg3 != null)
			{
				_ohbg3.SetObjectActive(value);
			}
		}
	}

	public bool hbgShow4
	{
		get
		{
			if (_ohbg4 != null)
			{
				return _ohbg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hbgShow4 != value && _ohbg4 != null)
			{
				_ohbg4.SetObjectActive(value);
			}
		}
	}

	public Color hbgColor1
	{
		get
		{
			if (_ohbgImage1 != null)
			{
				return _ohbgImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (hbgColor1 != value && _ohbgImage1 != null)
			{
				_ohbgImage1.color = value;
			}
		}
	}

	public Color hbgColor2
	{
		get
		{
			if (_ohbgImage2 != null)
			{
				return _ohbgImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (hbgColor2 != value && _ohbgImage2 != null)
			{
				_ohbgImage2.color = value;
			}
		}
	}

	public Color hbgColor3
	{
		get
		{
			if (_ohbgImage3 != null)
			{
				return _ohbgImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (hbgColor3 != value && _ohbgImage3 != null)
			{
				_ohbgImage3.color = value;
			}
		}
	}

	public Color hbgColor4
	{
		get
		{
			if (_ohbgImage4 != null)
			{
				return _ohbgImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (hbgColor4 != value && _ohbgImage4 != null)
			{
				_ohbgImage4.color = value;
			}
		}
	}

	public Image hbgImage1
	{
		get
		{
			if (_ohbgImage1 != null)
			{
				return _ohbgImage1;
			}
			return null;
		}
		set
		{
			if (hbgImage1 != value && _ohbgImage1 != null)
			{
				_ohbgImage1 = value;
			}
		}
	}

	public Image hbgImage2
	{
		get
		{
			if (_ohbgImage2 != null)
			{
				return _ohbgImage2;
			}
			return null;
		}
		set
		{
			if (hbgImage2 != value && _ohbgImage2 != null)
			{
				_ohbgImage2 = value;
			}
		}
	}

	public Image hbgImage3
	{
		get
		{
			if (_ohbgImage3 != null)
			{
				return _ohbgImage3;
			}
			return null;
		}
		set
		{
			if (hbgImage3 != value && _ohbgImage3 != null)
			{
				_ohbgImage3 = value;
			}
		}
	}

	public Image hbgImage4
	{
		get
		{
			if (_ohbgImage4 != null)
			{
				return _ohbgImage4;
			}
			return null;
		}
		set
		{
			if (hbgImage4 != value && _ohbgImage4 != null)
			{
				_ohbgImage4 = value;
			}
		}
	}

	public bool hiconShow1
	{
		get
		{
			if (_ohicon1 != null)
			{
				return _ohicon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hiconShow1 != value && _ohicon1 != null)
			{
				_ohicon1.SetObjectActive(value);
			}
		}
	}

	public bool hiconShow2
	{
		get
		{
			if (_ohicon2 != null)
			{
				return _ohicon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hiconShow2 != value && _ohicon2 != null)
			{
				_ohicon2.SetObjectActive(value);
			}
		}
	}

	public bool hiconShow3
	{
		get
		{
			if (_ohicon3 != null)
			{
				return _ohicon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hiconShow3 != value && _ohicon3 != null)
			{
				_ohicon3.SetObjectActive(value);
			}
		}
	}

	public bool hiconShow4
	{
		get
		{
			if (_ohicon4 != null)
			{
				return _ohicon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hiconShow4 != value && _ohicon4 != null)
			{
				_ohicon4.SetObjectActive(value);
			}
		}
	}

	public Vector2 hiconAnchoredposition1
	{
		get
		{
			if (_ohiconRectTransform1 != null)
			{
				return _ohiconRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hiconAnchoredposition1 != value && _ohiconRectTransform1 != null)
			{
				_ohiconRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 hiconAnchoredposition2
	{
		get
		{
			if (_ohiconRectTransform2 != null)
			{
				return _ohiconRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hiconAnchoredposition2 != value && _ohiconRectTransform2 != null)
			{
				_ohiconRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 hiconAnchoredposition3
	{
		get
		{
			if (_ohiconRectTransform3 != null)
			{
				return _ohiconRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hiconAnchoredposition3 != value && _ohiconRectTransform3 != null)
			{
				_ohiconRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 hiconAnchoredposition4
	{
		get
		{
			if (_ohiconRectTransform4 != null)
			{
				return _ohiconRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hiconAnchoredposition4 != value && _ohiconRectTransform4 != null)
			{
				_ohiconRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector3 hiconSize1
	{
		get
		{
			if (_ohiconRectTransform1 != null)
			{
				return _ohiconRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hiconSize1 != value && _ohiconRectTransform1 != null)
			{
				_ohiconRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 hiconSize2
	{
		get
		{
			if (_ohiconRectTransform2 != null)
			{
				return _ohiconRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hiconSize2 != value && _ohiconRectTransform2 != null)
			{
				_ohiconRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 hiconSize3
	{
		get
		{
			if (_ohiconRectTransform3 != null)
			{
				return _ohiconRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hiconSize3 != value && _ohiconRectTransform3 != null)
			{
				_ohiconRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 hiconSize4
	{
		get
		{
			if (_ohiconRectTransform4 != null)
			{
				return _ohiconRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hiconSize4 != value && _ohiconRectTransform4 != null)
			{
				_ohiconRectTransform4.sizeDelta = value;
			}
		}
	}

	public Color hiconColor1
	{
		get
		{
			if (_ohiconImage1 != null)
			{
				return _ohiconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (hiconColor1 != value && _ohiconImage1 != null)
			{
				_ohiconImage1.color = value;
			}
		}
	}

	public Color hiconColor2
	{
		get
		{
			if (_ohiconImage2 != null)
			{
				return _ohiconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (hiconColor2 != value && _ohiconImage2 != null)
			{
				_ohiconImage2.color = value;
			}
		}
	}

	public Color hiconColor3
	{
		get
		{
			if (_ohiconImage3 != null)
			{
				return _ohiconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (hiconColor3 != value && _ohiconImage3 != null)
			{
				_ohiconImage3.color = value;
			}
		}
	}

	public Color hiconColor4
	{
		get
		{
			if (_ohiconImage4 != null)
			{
				return _ohiconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (hiconColor4 != value && _ohiconImage4 != null)
			{
				_ohiconImage4.color = value;
			}
		}
	}

	public Image hiconImage1
	{
		get
		{
			if (_ohiconImage1 != null)
			{
				return _ohiconImage1;
			}
			return null;
		}
		set
		{
			if (hiconImage1 != value && _ohiconImage1 != null)
			{
				_ohiconImage1 = value;
			}
		}
	}

	public Image hiconImage2
	{
		get
		{
			if (_ohiconImage2 != null)
			{
				return _ohiconImage2;
			}
			return null;
		}
		set
		{
			if (hiconImage2 != value && _ohiconImage2 != null)
			{
				_ohiconImage2 = value;
			}
		}
	}

	public Image hiconImage3
	{
		get
		{
			if (_ohiconImage3 != null)
			{
				return _ohiconImage3;
			}
			return null;
		}
		set
		{
			if (hiconImage3 != value && _ohiconImage3 != null)
			{
				_ohiconImage3 = value;
			}
		}
	}

	public Image hiconImage4
	{
		get
		{
			if (_ohiconImage4 != null)
			{
				return _ohiconImage4;
			}
			return null;
		}
		set
		{
			if (hiconImage4 != value && _ohiconImage4 != null)
			{
				_ohiconImage4 = value;
			}
		}
	}

	public Vector2 hgtextAnchoredposition1
	{
		get
		{
			if (_ohgtextRectTransform1 != null)
			{
				return _ohgtextRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hgtextAnchoredposition1 != value && _ohgtextRectTransform1 != null)
			{
				_ohgtextRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 hgtextAnchoredposition2
	{
		get
		{
			if (_ohgtextRectTransform2 != null)
			{
				return _ohgtextRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hgtextAnchoredposition2 != value && _ohgtextRectTransform2 != null)
			{
				_ohgtextRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 hgtextAnchoredposition3
	{
		get
		{
			if (_ohgtextRectTransform3 != null)
			{
				return _ohgtextRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hgtextAnchoredposition3 != value && _ohgtextRectTransform3 != null)
			{
				_ohgtextRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 hgtextAnchoredposition4
	{
		get
		{
			if (_ohgtextRectTransform4 != null)
			{
				return _ohgtextRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hgtextAnchoredposition4 != value && _ohgtextRectTransform4 != null)
			{
				_ohgtextRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector3 hgtextSize1
	{
		get
		{
			if (_ohgtextRectTransform1 != null)
			{
				return _ohgtextRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hgtextSize1 != value && _ohgtextRectTransform1 != null)
			{
				_ohgtextRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 hgtextSize2
	{
		get
		{
			if (_ohgtextRectTransform2 != null)
			{
				return _ohgtextRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hgtextSize2 != value && _ohgtextRectTransform2 != null)
			{
				_ohgtextRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 hgtextSize3
	{
		get
		{
			if (_ohgtextRectTransform3 != null)
			{
				return _ohgtextRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hgtextSize3 != value && _ohgtextRectTransform3 != null)
			{
				_ohgtextRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 hgtextSize4
	{
		get
		{
			if (_ohgtextRectTransform4 != null)
			{
				return _ohgtextRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hgtextSize4 != value && _ohgtextRectTransform4 != null)
			{
				_ohgtextRectTransform4.sizeDelta = value;
			}
		}
	}

	public string hgtextString1
	{
		get
		{
			if (_ohgtextText1 != null)
			{
				return _ohgtextText1.text;
			}
			return null;
		}
		set
		{
			if (hgtextString1 != value && _ohgtextText1 != null)
			{
				_ohgtextText1.text = value;
			}
		}
	}

	public string hgtextString2
	{
		get
		{
			if (_ohgtextText2 != null)
			{
				return _ohgtextText2.text;
			}
			return null;
		}
		set
		{
			if (hgtextString2 != value && _ohgtextText2 != null)
			{
				_ohgtextText2.text = value;
			}
		}
	}

	public string hgtextString3
	{
		get
		{
			if (_ohgtextText3 != null)
			{
				return _ohgtextText3.text;
			}
			return null;
		}
		set
		{
			if (hgtextString3 != value && _ohgtextText3 != null)
			{
				_ohgtextText3.text = value;
			}
		}
	}

	public string hgtextString4
	{
		get
		{
			if (_ohgtextText4 != null)
			{
				return _ohgtextText4.text;
			}
			return null;
		}
		set
		{
			if (hgtextString4 != value && _ohgtextText4 != null)
			{
				_ohgtextText4.text = value;
			}
		}
	}

	public Color hgtextTextcolor1
	{
		get
		{
			if (_ohgtextText1 != null)
			{
				return _ohgtextText1.color;
			}
			return Color.white;
		}
		set
		{
			if (hgtextTextcolor1 != value && _ohgtextText1 != null)
			{
				_ohgtextText1.color = value;
			}
		}
	}

	public Color hgtextTextcolor2
	{
		get
		{
			if (_ohgtextText2 != null)
			{
				return _ohgtextText2.color;
			}
			return Color.white;
		}
		set
		{
			if (hgtextTextcolor2 != value && _ohgtextText2 != null)
			{
				_ohgtextText2.color = value;
			}
		}
	}

	public Color hgtextTextcolor3
	{
		get
		{
			if (_ohgtextText3 != null)
			{
				return _ohgtextText3.color;
			}
			return Color.white;
		}
		set
		{
			if (hgtextTextcolor3 != value && _ohgtextText3 != null)
			{
				_ohgtextText3.color = value;
			}
		}
	}

	public Color hgtextTextcolor4
	{
		get
		{
			if (_ohgtextText4 != null)
			{
				return _ohgtextText4.color;
			}
			return Color.white;
		}
		set
		{
			if (hgtextTextcolor4 != value && _ohgtextText4 != null)
			{
				_ohgtextText4.color = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "ChatPanel":
				_oChatPanel = transform.gameObject;
				uiRef.Set("ChatPanel", _oChatPanel.transform);
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				uiRef.Set("Panel", _oPanel.transform);
				break;
			case "InputPanel":
				_oInputPanel = transform.gameObject;
				uiRef.Set("InputPanel", _oInputPanel.transform);
				break;
			case "Image":
				_oImage = transform.gameObject;
				uiRef.Set("Image", _oImage.transform);
				break;
			case "ChatTypeText":
				_oChatTypeText = transform.gameObject;
				uiRef.Set("ChatTypeText", _oChatTypeText.transform);
				_oChatTypeTextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("ChatTypeTextText", _oChatTypeTextText);
				break;
			case "ChatInputText":
				_oChatInputText = transform.gameObject;
				uiRef.Set("ChatInputText", _oChatInputText.transform);
				_oChatInputTextInputField = transform.gameObject.GetComponent<InputField>();
				uiRef.Set("ChatInputTextInputField", _oChatInputTextInputField);
				break;
			case "Text":
				_oText = transform.gameObject;
				uiRef.Set("Text", _oText.transform);
				_oTextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("TextText", _oTextText);
				break;
			case "group1":
				_ogroup1 = transform.gameObject;
				uiRef.Set("group1", _ogroup1.transform);
				_ogroupCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup1", _ogroupCanvasGroup1);
				break;
			case "group2":
				_ogroup2 = transform.gameObject;
				uiRef.Set("group2", _ogroup2.transform);
				_ogroupCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup2", _ogroupCanvasGroup2);
				break;
			case "group3":
				_ogroup3 = transform.gameObject;
				uiRef.Set("group3", _ogroup3.transform);
				_ogroupCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup3", _ogroupCanvasGroup3);
				break;
			case "group4":
				_ogroup4 = transform.gameObject;
				uiRef.Set("group4", _ogroup4.transform);
				_ogroupCanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup4", _ogroupCanvasGroup4);
				break;
			case "group5":
				_ogroup5 = transform.gameObject;
				uiRef.Set("group5", _ogroup5.transform);
				_ogroupCanvasGroup5 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup5", _ogroupCanvasGroup5);
				break;
			case "group6":
				_ogroup6 = transform.gameObject;
				uiRef.Set("group6", _ogroup6.transform);
				_ogroupCanvasGroup6 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("groupCanvasGroup6", _ogroupCanvasGroup6);
				break;
			case "vipicon1":
				_ovipicon1 = transform.gameObject;
				uiRef.Set("vipicon1", _ovipicon1.transform);
				_ovipiconImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage1", _ovipiconImage1);
				break;
			case "vipicon2":
				_ovipicon2 = transform.gameObject;
				uiRef.Set("vipicon2", _ovipicon2.transform);
				_ovipiconImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage2", _ovipiconImage2);
				break;
			case "vipicon3":
				_ovipicon3 = transform.gameObject;
				uiRef.Set("vipicon3", _ovipicon3.transform);
				_ovipiconImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage3", _ovipiconImage3);
				break;
			case "vipicon4":
				_ovipicon4 = transform.gameObject;
				uiRef.Set("vipicon4", _ovipicon4.transform);
				_ovipiconImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage4", _ovipiconImage4);
				break;
			case "vipicon5":
				_ovipicon5 = transform.gameObject;
				uiRef.Set("vipicon5", _ovipicon5.transform);
				_ovipiconImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage5", _ovipiconImage5);
				break;
			case "vipicon6":
				_ovipicon6 = transform.gameObject;
				uiRef.Set("vipicon6", _ovipicon6.transform);
				_ovipiconImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("vipiconImage6", _ovipiconImage6);
				break;
			case "chattext1":
				_ochattext1 = transform.gameObject;
				uiRef.Set("chattext1", _ochattext1.transform);
				_ochattextRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform1", _ochattextRectTransform1);
				_ochattextText1 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText1", _ochattextText1);
				break;
			case "chattext2":
				_ochattext2 = transform.gameObject;
				uiRef.Set("chattext2", _ochattext2.transform);
				_ochattextRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform2", _ochattextRectTransform2);
				_ochattextText2 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText2", _ochattextText2);
				break;
			case "chattext3":
				_ochattext3 = transform.gameObject;
				uiRef.Set("chattext3", _ochattext3.transform);
				_ochattextRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform3", _ochattextRectTransform3);
				_ochattextText3 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText3", _ochattextText3);
				break;
			case "chattext4":
				_ochattext4 = transform.gameObject;
				uiRef.Set("chattext4", _ochattext4.transform);
				_ochattextRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform4", _ochattextRectTransform4);
				_ochattextText4 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText4", _ochattextText4);
				break;
			case "chattext5":
				_ochattext5 = transform.gameObject;
				uiRef.Set("chattext5", _ochattext5.transform);
				_ochattextRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform5", _ochattextRectTransform5);
				_ochattextText5 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText5", _ochattextText5);
				break;
			case "chattext6":
				_ochattext6 = transform.gameObject;
				uiRef.Set("chattext6", _ochattext6.transform);
				_ochattextRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("chattextRectTransform6", _ochattextRectTransform6);
				_ochattextText6 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("chattextText6", _ochattextText6);
				break;
			case "hononaryGp1":
				_ohononaryGp1 = transform.gameObject;
				uiRef.Set("hononaryGp1", _ohononaryGp1.transform);
				_ohononaryGpCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("hononaryGpCanvasGroup1", _ohononaryGpCanvasGroup1);
				break;
			case "hononaryGp2":
				_ohononaryGp2 = transform.gameObject;
				uiRef.Set("hononaryGp2", _ohononaryGp2.transform);
				_ohononaryGpCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("hononaryGpCanvasGroup2", _ohononaryGpCanvasGroup2);
				break;
			case "hononaryGp3":
				_ohononaryGp3 = transform.gameObject;
				uiRef.Set("hononaryGp3", _ohononaryGp3.transform);
				_ohononaryGpCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("hononaryGpCanvasGroup3", _ohononaryGpCanvasGroup3);
				break;
			case "hononaryGp4":
				_ohononaryGp4 = transform.gameObject;
				uiRef.Set("hononaryGp4", _ohononaryGp4.transform);
				_ohononaryGpCanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("hononaryGpCanvasGroup4", _ohononaryGpCanvasGroup4);
				break;
			case "hbg1":
				_ohbg1 = transform.gameObject;
				uiRef.Set("hbg1", _ohbg1.transform);
				_ohbgImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hbgImage1", _ohbgImage1);
				break;
			case "hbg2":
				_ohbg2 = transform.gameObject;
				uiRef.Set("hbg2", _ohbg2.transform);
				_ohbgImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hbgImage2", _ohbgImage2);
				break;
			case "hbg3":
				_ohbg3 = transform.gameObject;
				uiRef.Set("hbg3", _ohbg3.transform);
				_ohbgImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hbgImage3", _ohbgImage3);
				break;
			case "hbg4":
				_ohbg4 = transform.gameObject;
				uiRef.Set("hbg4", _ohbg4.transform);
				_ohbgImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hbgImage4", _ohbgImage4);
				break;
			case "hicon1":
				_ohicon1 = transform.gameObject;
				uiRef.Set("hicon1", _ohicon1.transform);
				_ohiconRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hiconRectTransform1", _ohiconRectTransform1);
				_ohiconImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hiconImage1", _ohiconImage1);
				break;
			case "hicon2":
				_ohicon2 = transform.gameObject;
				uiRef.Set("hicon2", _ohicon2.transform);
				_ohiconRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hiconRectTransform2", _ohiconRectTransform2);
				_ohiconImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hiconImage2", _ohiconImage2);
				break;
			case "hicon3":
				_ohicon3 = transform.gameObject;
				uiRef.Set("hicon3", _ohicon3.transform);
				_ohiconRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hiconRectTransform3", _ohiconRectTransform3);
				_ohiconImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hiconImage3", _ohiconImage3);
				break;
			case "hicon4":
				_ohicon4 = transform.gameObject;
				uiRef.Set("hicon4", _ohicon4.transform);
				_ohiconRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hiconRectTransform4", _ohiconRectTransform4);
				_ohiconImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hiconImage4", _ohiconImage4);
				break;
			case "hgtext1":
				_ohgtext1 = transform.gameObject;
				uiRef.Set("hgtext1", _ohgtext1.transform);
				_ohgtextRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hgtextRectTransform1", _ohgtextRectTransform1);
				_ohgtextText1 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("hgtextText1", _ohgtextText1);
				break;
			case "hgtext2":
				_ohgtext2 = transform.gameObject;
				uiRef.Set("hgtext2", _ohgtext2.transform);
				_ohgtextRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hgtextRectTransform2", _ohgtextRectTransform2);
				_ohgtextText2 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("hgtextText2", _ohgtextText2);
				break;
			case "hgtext3":
				_ohgtext3 = transform.gameObject;
				uiRef.Set("hgtext3", _ohgtext3.transform);
				_ohgtextRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hgtextRectTransform3", _ohgtextRectTransform3);
				_ohgtextText3 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("hgtextText3", _ohgtextText3);
				break;
			case "hgtext4":
				_ohgtext4 = transform.gameObject;
				uiRef.Set("hgtext4", _ohgtext4.transform);
				_ohgtextRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hgtextRectTransform4", _ohgtextRectTransform4);
				_ohgtextText4 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("hgtextText4", _ohgtextText4);
				break;
			}
		}
	}

	public bool GetgroupShow(int index)
	{
		return index switch
		{
			1 => groupShow1, 
			2 => groupShow2, 
			3 => groupShow3, 
			4 => groupShow4, 
			5 => groupShow5, 
			6 => groupShow6, 
			_ => false, 
		};
	}

	public void SetgroupShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			groupShow1 = value;
			break;
		case 2:
			groupShow2 = value;
			break;
		case 3:
			groupShow3 = value;
			break;
		case 4:
			groupShow4 = value;
			break;
		case 5:
			groupShow5 = value;
			break;
		case 6:
			groupShow6 = value;
			break;
		}
	}

	public float GetgroupAlpha(int index)
	{
		return index switch
		{
			1 => groupAlpha1, 
			2 => groupAlpha2, 
			3 => groupAlpha3, 
			4 => groupAlpha4, 
			5 => groupAlpha5, 
			6 => groupAlpha6, 
			_ => 0f, 
		};
	}

	public void SetgroupAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			groupAlpha1 = value;
			break;
		case 2:
			groupAlpha2 = value;
			break;
		case 3:
			groupAlpha3 = value;
			break;
		case 4:
			groupAlpha4 = value;
			break;
		case 5:
			groupAlpha5 = value;
			break;
		case 6:
			groupAlpha6 = value;
			break;
		}
	}

	public bool GetvipiconShow(int index)
	{
		return index switch
		{
			1 => vipiconShow1, 
			2 => vipiconShow2, 
			3 => vipiconShow3, 
			4 => vipiconShow4, 
			5 => vipiconShow5, 
			6 => vipiconShow6, 
			_ => false, 
		};
	}

	public void SetvipiconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			vipiconShow1 = value;
			break;
		case 2:
			vipiconShow2 = value;
			break;
		case 3:
			vipiconShow3 = value;
			break;
		case 4:
			vipiconShow4 = value;
			break;
		case 5:
			vipiconShow5 = value;
			break;
		case 6:
			vipiconShow6 = value;
			break;
		}
	}

	public Color GetvipiconColor(int index)
	{
		return index switch
		{
			1 => vipiconColor1, 
			2 => vipiconColor2, 
			3 => vipiconColor3, 
			4 => vipiconColor4, 
			5 => vipiconColor5, 
			6 => vipiconColor6, 
			_ => Color.white, 
		};
	}

	public void SetvipiconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			vipiconColor1 = value;
			break;
		case 2:
			vipiconColor2 = value;
			break;
		case 3:
			vipiconColor3 = value;
			break;
		case 4:
			vipiconColor4 = value;
			break;
		case 5:
			vipiconColor5 = value;
			break;
		case 6:
			vipiconColor6 = value;
			break;
		}
	}

	public Image GetvipiconImage(int index)
	{
		return index switch
		{
			1 => vipiconImage1, 
			2 => vipiconImage2, 
			3 => vipiconImage3, 
			4 => vipiconImage4, 
			5 => vipiconImage5, 
			6 => vipiconImage6, 
			_ => null, 
		};
	}

	public void SetvipiconImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			vipiconImage1 = value;
			break;
		case 2:
			vipiconImage2 = value;
			break;
		case 3:
			vipiconImage3 = value;
			break;
		case 4:
			vipiconImage4 = value;
			break;
		case 5:
			vipiconImage5 = value;
			break;
		case 6:
			vipiconImage6 = value;
			break;
		}
	}

	public Vector3 GetchattextSize(int index)
	{
		return index switch
		{
			1 => chattextSize1, 
			2 => chattextSize2, 
			3 => chattextSize3, 
			4 => chattextSize4, 
			5 => chattextSize5, 
			6 => chattextSize6, 
			_ => Vector3.zero, 
		};
	}

	public void SetchattextSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			chattextSize1 = value;
			break;
		case 2:
			chattextSize2 = value;
			break;
		case 3:
			chattextSize3 = value;
			break;
		case 4:
			chattextSize4 = value;
			break;
		case 5:
			chattextSize5 = value;
			break;
		case 6:
			chattextSize6 = value;
			break;
		}
	}

	public string GetchattextString(int index)
	{
		return index switch
		{
			1 => chattextString1, 
			2 => chattextString2, 
			3 => chattextString3, 
			4 => chattextString4, 
			5 => chattextString5, 
			6 => chattextString6, 
			_ => null, 
		};
	}

	public void SetchattextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			chattextString1 = value;
			break;
		case 2:
			chattextString2 = value;
			break;
		case 3:
			chattextString3 = value;
			break;
		case 4:
			chattextString4 = value;
			break;
		case 5:
			chattextString5 = value;
			break;
		case 6:
			chattextString6 = value;
			break;
		}
	}

	public Color GetchattextTextcolor(int index)
	{
		return index switch
		{
			1 => chattextTextcolor1, 
			2 => chattextTextcolor2, 
			3 => chattextTextcolor3, 
			4 => chattextTextcolor4, 
			5 => chattextTextcolor5, 
			6 => chattextTextcolor6, 
			_ => Color.white, 
		};
	}

	public void SetchattextTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			chattextTextcolor1 = value;
			break;
		case 2:
			chattextTextcolor2 = value;
			break;
		case 3:
			chattextTextcolor3 = value;
			break;
		case 4:
			chattextTextcolor4 = value;
			break;
		case 5:
			chattextTextcolor5 = value;
			break;
		case 6:
			chattextTextcolor6 = value;
			break;
		}
	}

	public float GethononaryGpAlpha(int index)
	{
		return index switch
		{
			1 => hononaryGpAlpha1, 
			2 => hononaryGpAlpha2, 
			3 => hononaryGpAlpha3, 
			4 => hononaryGpAlpha4, 
			_ => 0f, 
		};
	}

	public void SethononaryGpAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			hononaryGpAlpha1 = value;
			break;
		case 2:
			hononaryGpAlpha2 = value;
			break;
		case 3:
			hononaryGpAlpha3 = value;
			break;
		case 4:
			hononaryGpAlpha4 = value;
			break;
		}
	}

	public bool GethbgShow(int index)
	{
		return index switch
		{
			1 => hbgShow1, 
			2 => hbgShow2, 
			3 => hbgShow3, 
			4 => hbgShow4, 
			_ => false, 
		};
	}

	public void SethbgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			hbgShow1 = value;
			break;
		case 2:
			hbgShow2 = value;
			break;
		case 3:
			hbgShow3 = value;
			break;
		case 4:
			hbgShow4 = value;
			break;
		}
	}

	public Color GethbgColor(int index)
	{
		return index switch
		{
			1 => hbgColor1, 
			2 => hbgColor2, 
			3 => hbgColor3, 
			4 => hbgColor4, 
			_ => Color.white, 
		};
	}

	public void SethbgColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			hbgColor1 = value;
			break;
		case 2:
			hbgColor2 = value;
			break;
		case 3:
			hbgColor3 = value;
			break;
		case 4:
			hbgColor4 = value;
			break;
		}
	}

	public Image GethbgImage(int index)
	{
		return index switch
		{
			1 => hbgImage1, 
			2 => hbgImage2, 
			3 => hbgImage3, 
			4 => hbgImage4, 
			_ => null, 
		};
	}

	public void SethbgImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			hbgImage1 = value;
			break;
		case 2:
			hbgImage2 = value;
			break;
		case 3:
			hbgImage3 = value;
			break;
		case 4:
			hbgImage4 = value;
			break;
		}
	}

	public bool GethiconShow(int index)
	{
		return index switch
		{
			1 => hiconShow1, 
			2 => hiconShow2, 
			3 => hiconShow3, 
			4 => hiconShow4, 
			_ => false, 
		};
	}

	public void SethiconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			hiconShow1 = value;
			break;
		case 2:
			hiconShow2 = value;
			break;
		case 3:
			hiconShow3 = value;
			break;
		case 4:
			hiconShow4 = value;
			break;
		}
	}

	public Vector2 GethiconAnchoredposition(int index)
	{
		return index switch
		{
			1 => hiconAnchoredposition1, 
			2 => hiconAnchoredposition2, 
			3 => hiconAnchoredposition3, 
			4 => hiconAnchoredposition4, 
			_ => Vector2.zero, 
		};
	}

	public void SethiconAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			hiconAnchoredposition1 = value;
			break;
		case 2:
			hiconAnchoredposition2 = value;
			break;
		case 3:
			hiconAnchoredposition3 = value;
			break;
		case 4:
			hiconAnchoredposition4 = value;
			break;
		}
	}

	public Vector3 GethiconSize(int index)
	{
		return index switch
		{
			1 => hiconSize1, 
			2 => hiconSize2, 
			3 => hiconSize3, 
			4 => hiconSize4, 
			_ => Vector3.zero, 
		};
	}

	public void SethiconSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			hiconSize1 = value;
			break;
		case 2:
			hiconSize2 = value;
			break;
		case 3:
			hiconSize3 = value;
			break;
		case 4:
			hiconSize4 = value;
			break;
		}
	}

	public Color GethiconColor(int index)
	{
		return index switch
		{
			1 => hiconColor1, 
			2 => hiconColor2, 
			3 => hiconColor3, 
			4 => hiconColor4, 
			_ => Color.white, 
		};
	}

	public void SethiconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			hiconColor1 = value;
			break;
		case 2:
			hiconColor2 = value;
			break;
		case 3:
			hiconColor3 = value;
			break;
		case 4:
			hiconColor4 = value;
			break;
		}
	}

	public Image GethiconImage(int index)
	{
		return index switch
		{
			1 => hiconImage1, 
			2 => hiconImage2, 
			3 => hiconImage3, 
			4 => hiconImage4, 
			_ => null, 
		};
	}

	public void SethiconImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			hiconImage1 = value;
			break;
		case 2:
			hiconImage2 = value;
			break;
		case 3:
			hiconImage3 = value;
			break;
		case 4:
			hiconImage4 = value;
			break;
		}
	}

	public Vector2 GethgtextAnchoredposition(int index)
	{
		return index switch
		{
			1 => hgtextAnchoredposition1, 
			2 => hgtextAnchoredposition2, 
			3 => hgtextAnchoredposition3, 
			4 => hgtextAnchoredposition4, 
			_ => Vector2.zero, 
		};
	}

	public void SethgtextAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			hgtextAnchoredposition1 = value;
			break;
		case 2:
			hgtextAnchoredposition2 = value;
			break;
		case 3:
			hgtextAnchoredposition3 = value;
			break;
		case 4:
			hgtextAnchoredposition4 = value;
			break;
		}
	}

	public Vector3 GethgtextSize(int index)
	{
		return index switch
		{
			1 => hgtextSize1, 
			2 => hgtextSize2, 
			3 => hgtextSize3, 
			4 => hgtextSize4, 
			_ => Vector3.zero, 
		};
	}

	public void SethgtextSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			hgtextSize1 = value;
			break;
		case 2:
			hgtextSize2 = value;
			break;
		case 3:
			hgtextSize3 = value;
			break;
		case 4:
			hgtextSize4 = value;
			break;
		}
	}

	public string GethgtextString(int index)
	{
		return index switch
		{
			1 => hgtextString1, 
			2 => hgtextString2, 
			3 => hgtextString3, 
			4 => hgtextString4, 
			_ => null, 
		};
	}

	public void SethgtextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			hgtextString1 = value;
			break;
		case 2:
			hgtextString2 = value;
			break;
		case 3:
			hgtextString3 = value;
			break;
		case 4:
			hgtextString4 = value;
			break;
		}
	}

	public Color GethgtextTextcolor(int index)
	{
		return index switch
		{
			1 => hgtextTextcolor1, 
			2 => hgtextTextcolor2, 
			3 => hgtextTextcolor3, 
			4 => hgtextTextcolor4, 
			_ => Color.white, 
		};
	}

	public void SethgtextTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			hgtextTextcolor1 = value;
			break;
		case 2:
			hgtextTextcolor2 = value;
			break;
		case 3:
			hgtextTextcolor3 = value;
			break;
		case 4:
			hgtextTextcolor4 = value;
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
