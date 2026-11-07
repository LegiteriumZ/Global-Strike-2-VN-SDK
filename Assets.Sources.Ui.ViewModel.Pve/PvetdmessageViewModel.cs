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

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PvetdmessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opvetdmessage;

	private GameObject _omessageImage;

	private RectTransform _omessageImageRectTransform;

	private Image _omessageImageImage;

	private GameObject _ostateImage;

	private RectTransform _ostateImageRectTransform;

	private Image _ostateImageImage;

	private GameObject _oselfMessageImage;

	private RectTransform _oselfMessageImageRectTransform;

	private Image _oselfMessageImageImage;

	private GameObject _owavetext;

	private RectTransform _owavetextRectTransform;

	private Text _owavetextText;

	private GameObject _ocountDowntext;

	private RectTransform _ocountDowntextRectTransform;

	private Text _ocountDowntextText;

	private GameObject _oreadytext;

	private RectTransform _oreadytextRectTransform;

	private Text _oreadytextText;

	private GameObject _oleveltext;

	private RectTransform _oleveltextRectTransform;

	private Text _oleveltextText;

	private GameObject _orelivetxt;

	private RectTransform _orelivetxtRectTransform;

	private Text _orelivetxtText;

	private GameObject _ocountDownSecondText;

	private RectTransform _ocountDownSecondTextRectTransform;

	private Text _ocountDownSecondTextText;

	private GameObject _ocountDownRandomText;

	private RectTransform _ocountDownRandomTextRectTransform;

	private Text _ocountDownRandomTextText;

	private GameObject _onameImage;

	private RectTransform _onameImageRectTransform;

	private Image _onameImageImage;

	private GameObject _oboss;

	private GameObject _owarningdown;

	private Image _owarningdownImage;

	private GameObject _owarningup;

	private Image _owarningupImage;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string messageImageName = "messageImage";

	public const string stateImageName = "stateImage";

	public const string selfMessageImageName = "selfMessageImage";

	public const string wavetextName = "wavetext";

	public const string countDowntextName = "countDowntext";

	public const string readytextName = "readytext";

	public const string leveltextName = "leveltext";

	public const string relivetxtName = "relivetxt";

	public const string countDownSecondTextName = "countDownSecondText";

	public const string countDownRandomTextName = "countDownRandomText";

	public const string warningupName = "warningup";

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pvetdmessage";

	public UiReferences UI => uiRef;

	public bool pvetdmessageShow
	{
		get
		{
			if (_opvetdmessage != null)
			{
				return _opvetdmessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pvetdmessageShow != value && _opvetdmessage != null)
			{
				_opvetdmessage.SetObjectActive(value);
			}
		}
	}

	public bool messageImageShow
	{
		get
		{
			if (_omessageImage != null)
			{
				return _omessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (messageImageShow != value && _omessageImage != null)
			{
				_omessageImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 messageImageAnchoredposition
	{
		get
		{
			if (_omessageImageRectTransform != null)
			{
				return _omessageImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (messageImageAnchoredposition != value && _omessageImageRectTransform != null)
			{
				_omessageImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 messageImagePosition
	{
		get
		{
			if (_omessageImageRectTransform != null)
			{
				return _omessageImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (messageImagePosition != value && _omessageImageRectTransform != null)
			{
				_omessageImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 messageImageSize
	{
		get
		{
			if (_omessageImageRectTransform != null)
			{
				return _omessageImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (messageImageSize != value && _omessageImageRectTransform != null)
			{
				_omessageImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite messageImageSprite
	{
		get
		{
			if (_omessageImageImage != null)
			{
				return _omessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (messageImageSprite != value && _omessageImageImage != null)
			{
				_omessageImageImage.sprite = value;
			}
		}
	}

	public Color messageImageColor
	{
		get
		{
			if (_omessageImageImage != null)
			{
				return _omessageImageImage.color;
			}
			return Color.white;
		}
		set
		{
			if (messageImageColor != value && _omessageImageImage != null)
			{
				_omessageImageImage.color = value;
			}
		}
	}

	public bool stateImageShow
	{
		get
		{
			if (_ostateImage != null)
			{
				return _ostateImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (stateImageShow != value && _ostateImage != null)
			{
				_ostateImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 stateImageAnchoredposition
	{
		get
		{
			if (_ostateImageRectTransform != null)
			{
				return _ostateImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (stateImageAnchoredposition != value && _ostateImageRectTransform != null)
			{
				_ostateImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 stateImagePosition
	{
		get
		{
			if (_ostateImageRectTransform != null)
			{
				return _ostateImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (stateImagePosition != value && _ostateImageRectTransform != null)
			{
				_ostateImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 stateImageSize
	{
		get
		{
			if (_ostateImageRectTransform != null)
			{
				return _ostateImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (stateImageSize != value && _ostateImageRectTransform != null)
			{
				_ostateImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite stateImageSprite
	{
		get
		{
			if (_ostateImageImage != null)
			{
				return _ostateImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (stateImageSprite != value && _ostateImageImage != null)
			{
				_ostateImageImage.sprite = value;
			}
		}
	}

	public bool selfMessageImageShow
	{
		get
		{
			if (_oselfMessageImage != null)
			{
				return _oselfMessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selfMessageImageShow != value && _oselfMessageImage != null)
			{
				_oselfMessageImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 selfMessageImageAnchoredposition
	{
		get
		{
			if (_oselfMessageImageRectTransform != null)
			{
				return _oselfMessageImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (selfMessageImageAnchoredposition != value && _oselfMessageImageRectTransform != null)
			{
				_oselfMessageImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 selfMessageImagePosition
	{
		get
		{
			if (_oselfMessageImageRectTransform != null)
			{
				return _oselfMessageImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (selfMessageImagePosition != value && _oselfMessageImageRectTransform != null)
			{
				_oselfMessageImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 selfMessageImageSize
	{
		get
		{
			if (_oselfMessageImageRectTransform != null)
			{
				return _oselfMessageImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (selfMessageImageSize != value && _oselfMessageImageRectTransform != null)
			{
				_oselfMessageImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite selfMessageImageSprite
	{
		get
		{
			if (_oselfMessageImageImage != null)
			{
				return _oselfMessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (selfMessageImageSprite != value && _oselfMessageImageImage != null)
			{
				_oselfMessageImageImage.sprite = value;
			}
		}
	}

	public bool wavetextShow
	{
		get
		{
			if (_owavetext != null)
			{
				return _owavetext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (wavetextShow != value && _owavetext != null)
			{
				_owavetext.SetObjectActive(value);
			}
		}
	}

	public Vector2 wavetextAnchoredposition
	{
		get
		{
			if (_owavetextRectTransform != null)
			{
				return _owavetextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (wavetextAnchoredposition != value && _owavetextRectTransform != null)
			{
				_owavetextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string wavetextString
	{
		get
		{
			if (_owavetextText != null)
			{
				return _owavetextText.text;
			}
			return null;
		}
		set
		{
			if (wavetextString != value && _owavetextText != null)
			{
				_owavetextText.text = value;
			}
		}
	}

	public Font wavetextTextfont
	{
		get
		{
			if (_owavetextText != null)
			{
				return _owavetextText.font;
			}
			return null;
		}
		set
		{
			if (wavetextTextfont != value && _owavetextText != null)
			{
				_owavetextText.font = value;
			}
		}
	}

	public bool countDowntextShow
	{
		get
		{
			if (_ocountDowntext != null)
			{
				return _ocountDowntext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (countDowntextShow != value && _ocountDowntext != null)
			{
				_ocountDowntext.SetObjectActive(value);
			}
		}
	}

	public Vector2 countDowntextAnchoredposition
	{
		get
		{
			if (_ocountDowntextRectTransform != null)
			{
				return _ocountDowntextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (countDowntextAnchoredposition != value && _ocountDowntextRectTransform != null)
			{
				_ocountDowntextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string countDowntextString
	{
		get
		{
			if (_ocountDowntextText != null)
			{
				return _ocountDowntextText.text;
			}
			return null;
		}
		set
		{
			if (countDowntextString != value && _ocountDowntextText != null)
			{
				_ocountDowntextText.text = value;
			}
		}
	}

	public Font countDowntextTextfont
	{
		get
		{
			if (_ocountDowntextText != null)
			{
				return _ocountDowntextText.font;
			}
			return null;
		}
		set
		{
			if (countDowntextTextfont != value && _ocountDowntextText != null)
			{
				_ocountDowntextText.font = value;
			}
		}
	}

	public bool readytextShow
	{
		get
		{
			if (_oreadytext != null)
			{
				return _oreadytext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (readytextShow != value && _oreadytext != null)
			{
				_oreadytext.SetObjectActive(value);
			}
		}
	}

	public Vector2 readytextAnchoredposition
	{
		get
		{
			if (_oreadytextRectTransform != null)
			{
				return _oreadytextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (readytextAnchoredposition != value && _oreadytextRectTransform != null)
			{
				_oreadytextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string readytextString
	{
		get
		{
			if (_oreadytextText != null)
			{
				return _oreadytextText.text;
			}
			return null;
		}
		set
		{
			if (readytextString != value && _oreadytextText != null)
			{
				_oreadytextText.text = value;
			}
		}
	}

	public Font readytextTextfont
	{
		get
		{
			if (_oreadytextText != null)
			{
				return _oreadytextText.font;
			}
			return null;
		}
		set
		{
			if (readytextTextfont != value && _oreadytextText != null)
			{
				_oreadytextText.font = value;
			}
		}
	}

	public bool leveltextShow
	{
		get
		{
			if (_oleveltext != null)
			{
				return _oleveltext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (leveltextShow != value && _oleveltext != null)
			{
				_oleveltext.SetObjectActive(value);
			}
		}
	}

	public Vector2 leveltextAnchoredposition
	{
		get
		{
			if (_oleveltextRectTransform != null)
			{
				return _oleveltextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (leveltextAnchoredposition != value && _oleveltextRectTransform != null)
			{
				_oleveltextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string leveltextString
	{
		get
		{
			if (_oleveltextText != null)
			{
				return _oleveltextText.text;
			}
			return null;
		}
		set
		{
			if (leveltextString != value && _oleveltextText != null)
			{
				_oleveltextText.text = value;
			}
		}
	}

	public Font leveltextTextfont
	{
		get
		{
			if (_oleveltextText != null)
			{
				return _oleveltextText.font;
			}
			return null;
		}
		set
		{
			if (leveltextTextfont != value && _oleveltextText != null)
			{
				_oleveltextText.font = value;
			}
		}
	}

	public bool relivetxtShow
	{
		get
		{
			if (_orelivetxt != null)
			{
				return _orelivetxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (relivetxtShow != value && _orelivetxt != null)
			{
				_orelivetxt.SetObjectActive(value);
			}
		}
	}

	public Vector2 relivetxtAnchoredposition
	{
		get
		{
			if (_orelivetxtRectTransform != null)
			{
				return _orelivetxtRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (relivetxtAnchoredposition != value && _orelivetxtRectTransform != null)
			{
				_orelivetxtRectTransform.anchoredPosition = value;
			}
		}
	}

	public string relivetxtString
	{
		get
		{
			if (_orelivetxtText != null)
			{
				return _orelivetxtText.text;
			}
			return null;
		}
		set
		{
			if (relivetxtString != value && _orelivetxtText != null)
			{
				_orelivetxtText.text = value;
			}
		}
	}

	public Font relivetxtTextfont
	{
		get
		{
			if (_orelivetxtText != null)
			{
				return _orelivetxtText.font;
			}
			return null;
		}
		set
		{
			if (relivetxtTextfont != value && _orelivetxtText != null)
			{
				_orelivetxtText.font = value;
			}
		}
	}

	public bool countDownSecondTextShow
	{
		get
		{
			if (_ocountDownSecondText != null)
			{
				return _ocountDownSecondText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (countDownSecondTextShow != value && _ocountDownSecondText != null)
			{
				_ocountDownSecondText.SetObjectActive(value);
			}
		}
	}

	public Vector2 countDownSecondTextAnchoredposition
	{
		get
		{
			if (_ocountDownSecondTextRectTransform != null)
			{
				return _ocountDownSecondTextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (countDownSecondTextAnchoredposition != value && _ocountDownSecondTextRectTransform != null)
			{
				_ocountDownSecondTextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string countDownSecondTextString
	{
		get
		{
			if (_ocountDownSecondTextText != null)
			{
				return _ocountDownSecondTextText.text;
			}
			return null;
		}
		set
		{
			if (countDownSecondTextString != value && _ocountDownSecondTextText != null)
			{
				_ocountDownSecondTextText.text = value;
			}
		}
	}

	public Font countDownSecondTextTextfont
	{
		get
		{
			if (_ocountDownSecondTextText != null)
			{
				return _ocountDownSecondTextText.font;
			}
			return null;
		}
		set
		{
			if (countDownSecondTextTextfont != value && _ocountDownSecondTextText != null)
			{
				_ocountDownSecondTextText.font = value;
			}
		}
	}

	public bool countDownRandomTextShow
	{
		get
		{
			if (_ocountDownRandomText != null)
			{
				return _ocountDownRandomText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (countDownRandomTextShow != value && _ocountDownRandomText != null)
			{
				_ocountDownRandomText.SetObjectActive(value);
			}
		}
	}

	public Vector2 countDownRandomTextAnchoredposition
	{
		get
		{
			if (_ocountDownRandomTextRectTransform != null)
			{
				return _ocountDownRandomTextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (countDownRandomTextAnchoredposition != value && _ocountDownRandomTextRectTransform != null)
			{
				_ocountDownRandomTextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string countDownRandomTextString
	{
		get
		{
			if (_ocountDownRandomTextText != null)
			{
				return _ocountDownRandomTextText.text;
			}
			return null;
		}
		set
		{
			if (countDownRandomTextString != value && _ocountDownRandomTextText != null)
			{
				_ocountDownRandomTextText.text = value;
			}
		}
	}

	public Font countDownRandomTextTextfont
	{
		get
		{
			if (_ocountDownRandomTextText != null)
			{
				return _ocountDownRandomTextText.font;
			}
			return null;
		}
		set
		{
			if (countDownRandomTextTextfont != value && _ocountDownRandomTextText != null)
			{
				_ocountDownRandomTextText.font = value;
			}
		}
	}

	public bool nameImageShow
	{
		get
		{
			if (_onameImage != null)
			{
				return _onameImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (nameImageShow != value && _onameImage != null)
			{
				_onameImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 nameImageAnchoredposition
	{
		get
		{
			if (_onameImageRectTransform != null)
			{
				return _onameImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (nameImageAnchoredposition != value && _onameImageRectTransform != null)
			{
				_onameImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite nameImageSprite
	{
		get
		{
			if (_onameImageImage != null)
			{
				return _onameImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (nameImageSprite != value && _onameImageImage != null)
			{
				_onameImageImage.sprite = value;
			}
		}
	}

	public GameObject bossObj => _oboss;

	public bool bossShow
	{
		get
		{
			if (_oboss != null)
			{
				return _oboss.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bossShow != value && _oboss != null)
			{
				_oboss.SetObjectActive(value);
			}
		}
	}

	public bool warningdownShow
	{
		get
		{
			if (_owarningdown != null)
			{
				return _owarningdown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (warningdownShow != value && _owarningdown != null)
			{
				_owarningdown.SetObjectActive(value);
			}
		}
	}

	public Sprite warningdownSprite
	{
		get
		{
			if (_owarningdownImage != null)
			{
				return _owarningdownImage.sprite;
			}
			return null;
		}
		set
		{
			if (warningdownSprite != value && _owarningdownImage != null)
			{
				_owarningdownImage.sprite = value;
			}
		}
	}

	public float warningdownFillamount
	{
		get
		{
			if (_owarningdownImage != null)
			{
				return _owarningdownImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (warningdownFillamount != value && _owarningdownImage != null)
			{
				_owarningdownImage.fillAmount = value;
			}
		}
	}

	public Color warningdownColor
	{
		get
		{
			if (_owarningdownImage != null)
			{
				return _owarningdownImage.color;
			}
			return Color.white;
		}
		set
		{
			if (warningdownColor != value && _owarningdownImage != null)
			{
				_owarningdownImage.color = value;
			}
		}
	}

	public bool warningupShow
	{
		get
		{
			if (_owarningup != null)
			{
				return _owarningup.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (warningupShow != value && _owarningup != null)
			{
				_owarningup.SetObjectActive(value);
			}
		}
	}

	public Sprite warningupSprite
	{
		get
		{
			if (_owarningupImage != null)
			{
				return _owarningupImage.sprite;
			}
			return null;
		}
		set
		{
			if (warningupSprite != value && _owarningupImage != null)
			{
				_owarningupImage.sprite = value;
			}
		}
	}

	public float warningupFillamount
	{
		get
		{
			if (_owarningupImage != null)
			{
				return _owarningupImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (warningupFillamount != value && _owarningupImage != null)
			{
				_owarningupImage.fillAmount = value;
			}
		}
	}

	public Color warningupColor
	{
		get
		{
			if (_owarningupImage != null)
			{
				return _owarningupImage.color;
			}
			return Color.white;
		}
		set
		{
			if (warningupColor != value && _owarningupImage != null)
			{
				_owarningupImage.color = value;
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
			case "pvetdmessage":
				_opvetdmessage = transform.gameObject;
				uiRef.Set("pvetdmessage", _opvetdmessage.transform);
				break;
			case "messageImage":
				_omessageImage = transform.gameObject;
				uiRef.Set("messageImage", _omessageImage.transform);
				_omessageImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("messageImageRectTransform", _omessageImageRectTransform);
				_omessageImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("messageImageImage", _omessageImageImage);
				break;
			case "stateImage":
				_ostateImage = transform.gameObject;
				uiRef.Set("stateImage", _ostateImage.transform);
				_ostateImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("stateImageRectTransform", _ostateImageRectTransform);
				_ostateImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("stateImageImage", _ostateImageImage);
				break;
			case "selfMessageImage":
				_oselfMessageImage = transform.gameObject;
				uiRef.Set("selfMessageImage", _oselfMessageImage.transform);
				_oselfMessageImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("selfMessageImageRectTransform", _oselfMessageImageRectTransform);
				_oselfMessageImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("selfMessageImageImage", _oselfMessageImageImage);
				break;
			case "wavetext":
				_owavetext = transform.gameObject;
				uiRef.Set("wavetext", _owavetext.transform);
				_owavetextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("wavetextRectTransform", _owavetextRectTransform);
				_owavetextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("wavetextText", _owavetextText);
				break;
			case "countDowntext":
				_ocountDowntext = transform.gameObject;
				uiRef.Set("countDowntext", _ocountDowntext.transform);
				_ocountDowntextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("countDowntextRectTransform", _ocountDowntextRectTransform);
				_ocountDowntextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("countDowntextText", _ocountDowntextText);
				break;
			case "readytext":
				_oreadytext = transform.gameObject;
				uiRef.Set("readytext", _oreadytext.transform);
				_oreadytextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("readytextRectTransform", _oreadytextRectTransform);
				_oreadytextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("readytextText", _oreadytextText);
				break;
			case "leveltext":
				_oleveltext = transform.gameObject;
				uiRef.Set("leveltext", _oleveltext.transform);
				_oleveltextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("leveltextRectTransform", _oleveltextRectTransform);
				_oleveltextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("leveltextText", _oleveltextText);
				break;
			case "relivetxt":
				_orelivetxt = transform.gameObject;
				uiRef.Set("relivetxt", _orelivetxt.transform);
				_orelivetxtRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("relivetxtRectTransform", _orelivetxtRectTransform);
				_orelivetxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("relivetxtText", _orelivetxtText);
				break;
			case "countDownSecondText":
				_ocountDownSecondText = transform.gameObject;
				uiRef.Set("countDownSecondText", _ocountDownSecondText.transform);
				_ocountDownSecondTextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("countDownSecondTextRectTransform", _ocountDownSecondTextRectTransform);
				_ocountDownSecondTextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("countDownSecondTextText", _ocountDownSecondTextText);
				break;
			case "countDownRandomText":
				_ocountDownRandomText = transform.gameObject;
				uiRef.Set("countDownRandomText", _ocountDownRandomText.transform);
				_ocountDownRandomTextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("countDownRandomTextRectTransform", _ocountDownRandomTextRectTransform);
				_ocountDownRandomTextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("countDownRandomTextText", _ocountDownRandomTextText);
				break;
			case "nameImage":
				_onameImage = transform.gameObject;
				uiRef.Set("nameImage", _onameImage.transform);
				_onameImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("nameImageRectTransform", _onameImageRectTransform);
				_onameImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("nameImageImage", _onameImageImage);
				break;
			case "boss":
				_oboss = transform.gameObject;
				uiRef.Set("boss", _oboss.transform);
				break;
			case "warningdown":
				_owarningdown = transform.gameObject;
				uiRef.Set("warningdown", _owarningdown.transform);
				_owarningdownImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("warningdownImage", _owarningdownImage);
				break;
			case "warningup":
				_owarningup = transform.gameObject;
				uiRef.Set("warningup", _owarningup.transform);
				_owarningupImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("warningupImage", _owarningupImage);
				break;
			}
		}
	}

	public void messageImageNtvsize()
	{
		if (_omessageImageImage != null)
		{
			_omessageImageImage.SetNativeSize();
		}
	}

	public void stateImageNtvsize()
	{
		if (_ostateImageImage != null)
		{
			_ostateImageImage.SetNativeSize();
		}
	}

	public void selfMessageImageNtvsize()
	{
		if (_oselfMessageImageImage != null)
		{
			_oselfMessageImageImage.SetNativeSize();
		}
	}

	public void nameImageNtvsize()
	{
		if (_onameImageImage != null)
		{
			_onameImageImage.SetNativeSize();
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
