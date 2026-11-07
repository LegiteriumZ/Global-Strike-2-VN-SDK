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
public class PvetdskilltreeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opvetdskilltree;

	private GameObject _oskillBackImage;

	private Image _oskillBackImageImage;

	private GameObject _oweaponSkillImage;

	private RectTransform _oweaponSkillImageRectTransform;

	private Image _oweaponSkillImageImage;

	private GameObject _oplayerMoneytext;

	private RectTransform _oplayerMoneytextRectTransform;

	private Text _oplayerMoneytextText;

	private GameObject _oplayerLvtext;

	private RectTransform _oplayerLvtextRectTransform;

	private Text _oplayerLvtextText;

	private GameObject _oexpProgressImage;

	private Image _oexpProgressImageImage;

	private GameObject _oaddDamagertext;

	private Text _oaddDamagertextText;

	private GameObject _oplayerGptext;

	private Text _oplayerGptextText;

	private GameObject _oskillImage1;

	private GameObject _oskillImage2;

	private GameObject _oskillImage3;

	private GameObject _oskillImage4;

	private GameObject _oskillImage5;

	private GameObject _oskillImage6;

	private GameObject _oskillImage7;

	private GameObject _oskillImage8;

	private GameObject _oskillImage9;

	private GameObject _oskillImage10;

	private GameObject _oskillImage11;

	private GameObject _oskillImage12;

	private GameObject _oskillImage13;

	private RectTransform _oskillImageRectTransform1;

	private RectTransform _oskillImageRectTransform2;

	private RectTransform _oskillImageRectTransform3;

	private RectTransform _oskillImageRectTransform4;

	private RectTransform _oskillImageRectTransform5;

	private RectTransform _oskillImageRectTransform6;

	private RectTransform _oskillImageRectTransform7;

	private RectTransform _oskillImageRectTransform8;

	private RectTransform _oskillImageRectTransform9;

	private RectTransform _oskillImageRectTransform10;

	private RectTransform _oskillImageRectTransform11;

	private RectTransform _oskillImageRectTransform12;

	private RectTransform _oskillImageRectTransform13;

	private Image _oskillImageImage1;

	private Image _oskillImageImage2;

	private Image _oskillImageImage3;

	private Image _oskillImageImage4;

	private Image _oskillImageImage5;

	private Image _oskillImageImage6;

	private Image _oskillImageImage7;

	private Image _oskillImageImage8;

	private Image _oskillImageImage9;

	private Image _oskillImageImage10;

	private Image _oskillImageImage11;

	private Image _oskillImageImage12;

	private Image _oskillImageImage13;

	private GameObject _oskillbackimg1;

	private GameObject _oskillbackimg2;

	private GameObject _oskillbackimg3;

	private GameObject _oskillbackimg4;

	private GameObject _oskillbackimg5;

	private GameObject _oskillbackimg6;

	private GameObject _oskillbackimg7;

	private GameObject _oskillbackimg8;

	private GameObject _oskillbackimg9;

	private GameObject _oskillbackimg10;

	private GameObject _oskillbackimg11;

	private GameObject _oskillbackimg12;

	private GameObject _oskillbackimg13;

	private RectTransform _oskillbackimgRectTransform1;

	private RectTransform _oskillbackimgRectTransform2;

	private RectTransform _oskillbackimgRectTransform3;

	private RectTransform _oskillbackimgRectTransform4;

	private RectTransform _oskillbackimgRectTransform5;

	private RectTransform _oskillbackimgRectTransform6;

	private RectTransform _oskillbackimgRectTransform7;

	private RectTransform _oskillbackimgRectTransform8;

	private RectTransform _oskillbackimgRectTransform9;

	private RectTransform _oskillbackimgRectTransform10;

	private RectTransform _oskillbackimgRectTransform11;

	private RectTransform _oskillbackimgRectTransform12;

	private RectTransform _oskillbackimgRectTransform13;

	private Image _oskillbackimgImage1;

	private Image _oskillbackimgImage2;

	private Image _oskillbackimgImage3;

	private Image _oskillbackimgImage4;

	private Image _oskillbackimgImage5;

	private Image _oskillbackimgImage6;

	private Image _oskillbackimgImage7;

	private Image _oskillbackimgImage8;

	private Image _oskillbackimgImage9;

	private Image _oskillbackimgImage10;

	private Image _oskillbackimgImage11;

	private Image _oskillbackimgImage12;

	private Image _oskillbackimgImage13;

	private GameObject _oskillmaxImg1;

	private GameObject _oskillmaxImg2;

	private GameObject _oskillmaxImg3;

	private GameObject _oskillmaxImg4;

	private GameObject _oskillmaxImg5;

	private GameObject _oskillmaxImg6;

	private GameObject _oskillmaxImg7;

	private GameObject _oskillmaxImg8;

	private GameObject _oskillmaxImg9;

	private GameObject _oskillmaxImg10;

	private GameObject _oskillmaxImg11;

	private GameObject _oskillmaxImg12;

	private GameObject _oskillmaxImg13;

	private RectTransform _oskillmaxImgRectTransform1;

	private RectTransform _oskillmaxImgRectTransform2;

	private RectTransform _oskillmaxImgRectTransform3;

	private RectTransform _oskillmaxImgRectTransform4;

	private RectTransform _oskillmaxImgRectTransform5;

	private RectTransform _oskillmaxImgRectTransform6;

	private RectTransform _oskillmaxImgRectTransform7;

	private RectTransform _oskillmaxImgRectTransform8;

	private RectTransform _oskillmaxImgRectTransform9;

	private RectTransform _oskillmaxImgRectTransform10;

	private RectTransform _oskillmaxImgRectTransform11;

	private RectTransform _oskillmaxImgRectTransform12;

	private RectTransform _oskillmaxImgRectTransform13;

	private Image _oskillmaxImgImage1;

	private Image _oskillmaxImgImage2;

	private Image _oskillmaxImgImage3;

	private Image _oskillmaxImgImage4;

	private Image _oskillmaxImgImage5;

	private Image _oskillmaxImgImage6;

	private Image _oskillmaxImgImage7;

	private Image _oskillmaxImgImage8;

	private Image _oskillmaxImgImage9;

	private Image _oskillmaxImgImage10;

	private Image _oskillmaxImgImage11;

	private Image _oskillmaxImgImage12;

	private Image _oskillmaxImgImage13;

	private GameObject _oskillimagestudio1;

	private GameObject _oskillimagestudio2;

	private GameObject _oskillimagestudio3;

	private GameObject _oskillimagestudio4;

	private GameObject _oskillimagestudio5;

	private GameObject _oskillimagestudio6;

	private GameObject _oskillimagestudio7;

	private GameObject _oskillimagestudio8;

	private GameObject _oskillimagestudio9;

	private GameObject _oskillimagestudio10;

	private GameObject _oskillimagestudio11;

	private GameObject _oskillimagestudio12;

	private GameObject _oskillimagestudio13;

	private RectTransform _oskillimagestudioRectTransform1;

	private RectTransform _oskillimagestudioRectTransform2;

	private RectTransform _oskillimagestudioRectTransform3;

	private RectTransform _oskillimagestudioRectTransform4;

	private RectTransform _oskillimagestudioRectTransform5;

	private RectTransform _oskillimagestudioRectTransform6;

	private RectTransform _oskillimagestudioRectTransform7;

	private RectTransform _oskillimagestudioRectTransform8;

	private RectTransform _oskillimagestudioRectTransform9;

	private RectTransform _oskillimagestudioRectTransform10;

	private RectTransform _oskillimagestudioRectTransform11;

	private RectTransform _oskillimagestudioRectTransform12;

	private RectTransform _oskillimagestudioRectTransform13;

	private Image _oskillimagestudioImage1;

	private Image _oskillimagestudioImage2;

	private Image _oskillimagestudioImage3;

	private Image _oskillimagestudioImage4;

	private Image _oskillimagestudioImage5;

	private Image _oskillimagestudioImage6;

	private Image _oskillimagestudioImage7;

	private Image _oskillimagestudioImage8;

	private Image _oskillimagestudioImage9;

	private Image _oskillimagestudioImage10;

	private Image _oskillimagestudioImage11;

	private Image _oskillimagestudioImage12;

	private Image _oskillimagestudioImage13;

	private GameObject _oskilleffect1;

	private GameObject _oskilleffect2;

	private GameObject _oskilleffect3;

	private GameObject _oskilleffect4;

	private GameObject _oskilleffect5;

	private GameObject _oskilleffect6;

	private GameObject _oskilleffect7;

	private GameObject _oskilleffect8;

	private GameObject _oskilleffect9;

	private GameObject _oskilleffect10;

	private GameObject _oskilleffect11;

	private GameObject _oskilleffect12;

	private GameObject _oskilleffect13;

	private RectTransform _oskilleffectRectTransform1;

	private RectTransform _oskilleffectRectTransform2;

	private RectTransform _oskilleffectRectTransform3;

	private RectTransform _oskilleffectRectTransform4;

	private RectTransform _oskilleffectRectTransform5;

	private RectTransform _oskilleffectRectTransform6;

	private RectTransform _oskilleffectRectTransform7;

	private RectTransform _oskilleffectRectTransform8;

	private RectTransform _oskilleffectRectTransform9;

	private RectTransform _oskilleffectRectTransform10;

	private RectTransform _oskilleffectRectTransform11;

	private RectTransform _oskilleffectRectTransform12;

	private RectTransform _oskilleffectRectTransform13;

	private Image _oskilleffectImage1;

	private Image _oskilleffectImage2;

	private Image _oskilleffectImage3;

	private Image _oskilleffectImage4;

	private Image _oskilleffectImage5;

	private Image _oskilleffectImage6;

	private Image _oskilleffectImage7;

	private Image _oskilleffectImage8;

	private Image _oskilleffectImage9;

	private Image _oskilleffectImage10;

	private Image _oskilleffectImage11;

	private Image _oskilleffectImage12;

	private Image _oskilleffectImage13;

	private GameObject _oskillBoundImage1;

	private GameObject _oskillBoundImage2;

	private GameObject _oskillBoundImage3;

	private GameObject _oskillBoundImage4;

	private GameObject _oskillBoundImage5;

	private GameObject _oskillBoundImage6;

	private GameObject _oskillBoundImage7;

	private GameObject _oskillBoundImage8;

	private GameObject _oskillBoundImage9;

	private GameObject _oskillBoundImage10;

	private GameObject _oskillBoundImage11;

	private GameObject _oskillBoundImage12;

	private GameObject _oskillBoundImage13;

	private RectTransform _oskillBoundImageRectTransform1;

	private RectTransform _oskillBoundImageRectTransform2;

	private RectTransform _oskillBoundImageRectTransform3;

	private RectTransform _oskillBoundImageRectTransform4;

	private RectTransform _oskillBoundImageRectTransform5;

	private RectTransform _oskillBoundImageRectTransform6;

	private RectTransform _oskillBoundImageRectTransform7;

	private RectTransform _oskillBoundImageRectTransform8;

	private RectTransform _oskillBoundImageRectTransform9;

	private RectTransform _oskillBoundImageRectTransform10;

	private RectTransform _oskillBoundImageRectTransform11;

	private RectTransform _oskillBoundImageRectTransform12;

	private RectTransform _oskillBoundImageRectTransform13;

	private Image _oskillBoundImageImage1;

	private Image _oskillBoundImageImage2;

	private Image _oskillBoundImageImage3;

	private Image _oskillBoundImageImage4;

	private Image _oskillBoundImageImage5;

	private Image _oskillBoundImageImage6;

	private Image _oskillBoundImageImage7;

	private Image _oskillBoundImageImage8;

	private Image _oskillBoundImageImage9;

	private Image _oskillBoundImageImage10;

	private Image _oskillBoundImageImage11;

	private Image _oskillBoundImageImage12;

	private Image _oskillBoundImageImage13;

	private GameObject _oskilllv1;

	private GameObject _oskilllv2;

	private GameObject _oskilllv3;

	private GameObject _oskilllv4;

	private GameObject _oskilllv5;

	private GameObject _oskilllv6;

	private GameObject _oskilllv7;

	private GameObject _oskilllv8;

	private GameObject _oskilllv9;

	private GameObject _oskilllv10;

	private GameObject _oskilllv11;

	private GameObject _oskilllv12;

	private GameObject _oskilllv13;

	private Text _oskilllvText1;

	private Text _oskilllvText2;

	private Text _oskilllvText3;

	private Text _oskilllvText4;

	private Text _oskilllvText5;

	private Text _oskilllvText6;

	private Text _oskilllvText7;

	private Text _oskilllvText8;

	private Text _oskilllvText9;

	private Text _oskilllvText10;

	private Text _oskilllvText11;

	private Text _oskilllvText12;

	private Text _oskilllvText13;

	private GameObject _oskillTipBackImage;

	private RectTransform _oskillTipBackImageRectTransform;

	private Image _oskillTipBackImageImage;

	private GameObject _oskillnolvImage;

	private RectTransform _oskillnolvImageRectTransform;

	private Image _oskillnolvImageImage;

	private GameObject _onoMoneyImage;

	private RectTransform _onoMoneyImageRectTransform;

	private Image _onoMoneyImageImage;

	private GameObject _onoFrontSkillImage;

	private RectTransform _onoFrontSkillImageRectTransform;

	private Image _onoFrontSkillImageImage;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string skillImage1Name = "skillImage1";

	public const string skillImage2Name = "skillImage2";

	public const string skillImage3Name = "skillImage3";

	public const string skillImage4Name = "skillImage4";

	public const string skillImage5Name = "skillImage5";

	public const string skillImage6Name = "skillImage6";

	public const string skillImage7Name = "skillImage7";

	public const string skillImage8Name = "skillImage8";

	public const string skillImage9Name = "skillImage9";

	public const string skillImage10Name = "skillImage10";

	public const string skillImage11Name = "skillImage11";

	public const string skillImage12Name = "skillImage12";

	public const string skillImage13Name = "skillImage13";

	public const string skillbackimg1Name = "skillbackimg1";

	public const string skillbackimg2Name = "skillbackimg2";

	public const string skillbackimg3Name = "skillbackimg3";

	public const string skillbackimg4Name = "skillbackimg4";

	public const string skillbackimg5Name = "skillbackimg5";

	public const string skillbackimg6Name = "skillbackimg6";

	public const string skillbackimg7Name = "skillbackimg7";

	public const string skillbackimg8Name = "skillbackimg8";

	public const string skillbackimg9Name = "skillbackimg9";

	public const string skillbackimg10Name = "skillbackimg10";

	public const string skillbackimg11Name = "skillbackimg11";

	public const string skillbackimg12Name = "skillbackimg12";

	public const string skillbackimg13Name = "skillbackimg13";

	public const string skillmaxImg1Name = "skillmaxImg1";

	public const string skillmaxImg2Name = "skillmaxImg2";

	public const string skillmaxImg3Name = "skillmaxImg3";

	public const string skillmaxImg4Name = "skillmaxImg4";

	public const string skillmaxImg5Name = "skillmaxImg5";

	public const string skillmaxImg6Name = "skillmaxImg6";

	public const string skillmaxImg7Name = "skillmaxImg7";

	public const string skillmaxImg8Name = "skillmaxImg8";

	public const string skillmaxImg9Name = "skillmaxImg9";

	public const string skillmaxImg10Name = "skillmaxImg10";

	public const string skillmaxImg11Name = "skillmaxImg11";

	public const string skillmaxImg12Name = "skillmaxImg12";

	public const string skillmaxImg13Name = "skillmaxImg13";

	public const string skillimagestudio1Name = "skillimagestudio1";

	public const string skillimagestudio2Name = "skillimagestudio2";

	public const string skillimagestudio3Name = "skillimagestudio3";

	public const string skillimagestudio4Name = "skillimagestudio4";

	public const string skillimagestudio5Name = "skillimagestudio5";

	public const string skillimagestudio6Name = "skillimagestudio6";

	public const string skillimagestudio7Name = "skillimagestudio7";

	public const string skillimagestudio8Name = "skillimagestudio8";

	public const string skillimagestudio9Name = "skillimagestudio9";

	public const string skillimagestudio10Name = "skillimagestudio10";

	public const string skillimagestudio11Name = "skillimagestudio11";

	public const string skillimagestudio12Name = "skillimagestudio12";

	public const string skillimagestudio13Name = "skillimagestudio13";

	public const string skilleffect1Name = "skilleffect1";

	public const string skilleffect2Name = "skilleffect2";

	public const string skilleffect3Name = "skilleffect3";

	public const string skilleffect4Name = "skilleffect4";

	public const string skilleffect5Name = "skilleffect5";

	public const string skilleffect6Name = "skilleffect6";

	public const string skilleffect7Name = "skilleffect7";

	public const string skilleffect8Name = "skilleffect8";

	public const string skilleffect9Name = "skilleffect9";

	public const string skilleffect10Name = "skilleffect10";

	public const string skilleffect11Name = "skilleffect11";

	public const string skilleffect12Name = "skilleffect12";

	public const string skilleffect13Name = "skilleffect13";

	public const string skillBoundImage1Name = "skillBoundImage1";

	public const string skillBoundImage2Name = "skillBoundImage2";

	public const string skillBoundImage3Name = "skillBoundImage3";

	public const string skillBoundImage4Name = "skillBoundImage4";

	public const string skillBoundImage5Name = "skillBoundImage5";

	public const string skillBoundImage6Name = "skillBoundImage6";

	public const string skillBoundImage7Name = "skillBoundImage7";

	public const string skillBoundImage8Name = "skillBoundImage8";

	public const string skillBoundImage9Name = "skillBoundImage9";

	public const string skillBoundImage10Name = "skillBoundImage10";

	public const string skillBoundImage11Name = "skillBoundImage11";

	public const string skillBoundImage12Name = "skillBoundImage12";

	public const string skillBoundImage13Name = "skillBoundImage13";

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pvetdskilltree";

	public UiReferences UI => uiRef;

	public GameObject pvetdskilltreeObj => _opvetdskilltree;

	public bool pvetdskilltreeShow
	{
		get
		{
			if (_opvetdskilltree != null)
			{
				return _opvetdskilltree.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pvetdskilltreeShow != value && _opvetdskilltree != null)
			{
				_opvetdskilltree.SetObjectActive(value);
			}
		}
	}

	public Sprite skillBackImageSprite
	{
		get
		{
			if (_oskillBackImageImage != null)
			{
				return _oskillBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (skillBackImageSprite != value && _oskillBackImageImage != null)
			{
				_oskillBackImageImage.sprite = value;
			}
		}
	}

	public bool weaponSkillImageShow
	{
		get
		{
			if (_oweaponSkillImage != null)
			{
				return _oweaponSkillImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (weaponSkillImageShow != value && _oweaponSkillImage != null)
			{
				_oweaponSkillImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 weaponSkillImageAnchoredposition
	{
		get
		{
			if (_oweaponSkillImageRectTransform != null)
			{
				return _oweaponSkillImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (weaponSkillImageAnchoredposition != value && _oweaponSkillImageRectTransform != null)
			{
				_oweaponSkillImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite weaponSkillImageSprite
	{
		get
		{
			if (_oweaponSkillImageImage != null)
			{
				return _oweaponSkillImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (weaponSkillImageSprite != value && _oweaponSkillImageImage != null)
			{
				_oweaponSkillImageImage.sprite = value;
			}
		}
	}

	public bool playerMoneytextShow
	{
		get
		{
			if (_oplayerMoneytext != null)
			{
				return _oplayerMoneytext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerMoneytextShow != value && _oplayerMoneytext != null)
			{
				_oplayerMoneytext.SetObjectActive(value);
			}
		}
	}

	public Vector2 playerMoneytextAnchoredposition
	{
		get
		{
			if (_oplayerMoneytextRectTransform != null)
			{
				return _oplayerMoneytextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (playerMoneytextAnchoredposition != value && _oplayerMoneytextRectTransform != null)
			{
				_oplayerMoneytextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string playerMoneytextString
	{
		get
		{
			if (_oplayerMoneytextText != null)
			{
				return _oplayerMoneytextText.text;
			}
			return null;
		}
		set
		{
			if (playerMoneytextString != value && _oplayerMoneytextText != null)
			{
				_oplayerMoneytextText.text = value;
			}
		}
	}

	public Font playerMoneytextTextfont
	{
		get
		{
			if (_oplayerMoneytextText != null)
			{
				return _oplayerMoneytextText.font;
			}
			return null;
		}
		set
		{
			if (playerMoneytextTextfont != value && _oplayerMoneytextText != null)
			{
				_oplayerMoneytextText.font = value;
			}
		}
	}

	public bool playerLvtextShow
	{
		get
		{
			if (_oplayerLvtext != null)
			{
				return _oplayerLvtext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerLvtextShow != value && _oplayerLvtext != null)
			{
				_oplayerLvtext.SetObjectActive(value);
			}
		}
	}

	public Vector2 playerLvtextAnchoredposition
	{
		get
		{
			if (_oplayerLvtextRectTransform != null)
			{
				return _oplayerLvtextRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (playerLvtextAnchoredposition != value && _oplayerLvtextRectTransform != null)
			{
				_oplayerLvtextRectTransform.anchoredPosition = value;
			}
		}
	}

	public string playerLvtextString
	{
		get
		{
			if (_oplayerLvtextText != null)
			{
				return _oplayerLvtextText.text;
			}
			return null;
		}
		set
		{
			if (playerLvtextString != value && _oplayerLvtextText != null)
			{
				_oplayerLvtextText.text = value;
			}
		}
	}

	public Font playerLvtextTextfont
	{
		get
		{
			if (_oplayerLvtextText != null)
			{
				return _oplayerLvtextText.font;
			}
			return null;
		}
		set
		{
			if (playerLvtextTextfont != value && _oplayerLvtextText != null)
			{
				_oplayerLvtextText.font = value;
			}
		}
	}

	public bool expProgressImageShow
	{
		get
		{
			if (_oexpProgressImage != null)
			{
				return _oexpProgressImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (expProgressImageShow != value && _oexpProgressImage != null)
			{
				_oexpProgressImage.SetObjectActive(value);
			}
		}
	}

	public float expProgressImageFillamount
	{
		get
		{
			if (_oexpProgressImageImage != null)
			{
				return _oexpProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (expProgressImageFillamount != value && _oexpProgressImageImage != null)
			{
				_oexpProgressImageImage.fillAmount = value;
			}
		}
	}

	public bool addDamagertextShow
	{
		get
		{
			if (_oaddDamagertext != null)
			{
				return _oaddDamagertext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (addDamagertextShow != value && _oaddDamagertext != null)
			{
				_oaddDamagertext.SetObjectActive(value);
			}
		}
	}

	public string addDamagertextString
	{
		get
		{
			if (_oaddDamagertextText != null)
			{
				return _oaddDamagertextText.text;
			}
			return null;
		}
		set
		{
			if (addDamagertextString != value && _oaddDamagertextText != null)
			{
				_oaddDamagertextText.text = value;
			}
		}
	}

	public Font addDamagertextTextfont
	{
		get
		{
			if (_oaddDamagertextText != null)
			{
				return _oaddDamagertextText.font;
			}
			return null;
		}
		set
		{
			if (addDamagertextTextfont != value && _oaddDamagertextText != null)
			{
				_oaddDamagertextText.font = value;
			}
		}
	}

	public bool playerGptextShow
	{
		get
		{
			if (_oplayerGptext != null)
			{
				return _oplayerGptext.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerGptextShow != value && _oplayerGptext != null)
			{
				_oplayerGptext.SetObjectActive(value);
			}
		}
	}

	public string playerGptextString
	{
		get
		{
			if (_oplayerGptextText != null)
			{
				return _oplayerGptextText.text;
			}
			return null;
		}
		set
		{
			if (playerGptextString != value && _oplayerGptextText != null)
			{
				_oplayerGptextText.text = value;
			}
		}
	}

	public Font playerGptextTextfont
	{
		get
		{
			if (_oplayerGptextText != null)
			{
				return _oplayerGptextText.font;
			}
			return null;
		}
		set
		{
			if (playerGptextTextfont != value && _oplayerGptextText != null)
			{
				_oplayerGptextText.font = value;
			}
		}
	}

	public GameObject skillImageObj1 => _oskillImage1;

	public GameObject skillImageObj2 => _oskillImage2;

	public GameObject skillImageObj3 => _oskillImage3;

	public GameObject skillImageObj4 => _oskillImage4;

	public GameObject skillImageObj5 => _oskillImage5;

	public GameObject skillImageObj6 => _oskillImage6;

	public GameObject skillImageObj7 => _oskillImage7;

	public GameObject skillImageObj8 => _oskillImage8;

	public GameObject skillImageObj9 => _oskillImage9;

	public GameObject skillImageObj10 => _oskillImage10;

	public GameObject skillImageObj11 => _oskillImage11;

	public GameObject skillImageObj12 => _oskillImage12;

	public GameObject skillImageObj13 => _oskillImage13;

	public bool skillImageShow1
	{
		get
		{
			if (_oskillImage1 != null)
			{
				return _oskillImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow1 != value && _oskillImage1 != null)
			{
				_oskillImage1.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow2
	{
		get
		{
			if (_oskillImage2 != null)
			{
				return _oskillImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow2 != value && _oskillImage2 != null)
			{
				_oskillImage2.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow3
	{
		get
		{
			if (_oskillImage3 != null)
			{
				return _oskillImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow3 != value && _oskillImage3 != null)
			{
				_oskillImage3.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow4
	{
		get
		{
			if (_oskillImage4 != null)
			{
				return _oskillImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow4 != value && _oskillImage4 != null)
			{
				_oskillImage4.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow5
	{
		get
		{
			if (_oskillImage5 != null)
			{
				return _oskillImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow5 != value && _oskillImage5 != null)
			{
				_oskillImage5.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow6
	{
		get
		{
			if (_oskillImage6 != null)
			{
				return _oskillImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow6 != value && _oskillImage6 != null)
			{
				_oskillImage6.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow7
	{
		get
		{
			if (_oskillImage7 != null)
			{
				return _oskillImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow7 != value && _oskillImage7 != null)
			{
				_oskillImage7.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow8
	{
		get
		{
			if (_oskillImage8 != null)
			{
				return _oskillImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow8 != value && _oskillImage8 != null)
			{
				_oskillImage8.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow9
	{
		get
		{
			if (_oskillImage9 != null)
			{
				return _oskillImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow9 != value && _oskillImage9 != null)
			{
				_oskillImage9.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow10
	{
		get
		{
			if (_oskillImage10 != null)
			{
				return _oskillImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow10 != value && _oskillImage10 != null)
			{
				_oskillImage10.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow11
	{
		get
		{
			if (_oskillImage11 != null)
			{
				return _oskillImage11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow11 != value && _oskillImage11 != null)
			{
				_oskillImage11.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow12
	{
		get
		{
			if (_oskillImage12 != null)
			{
				return _oskillImage12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow12 != value && _oskillImage12 != null)
			{
				_oskillImage12.SetObjectActive(value);
			}
		}
	}

	public bool skillImageShow13
	{
		get
		{
			if (_oskillImage13 != null)
			{
				return _oskillImage13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillImageShow13 != value && _oskillImage13 != null)
			{
				_oskillImage13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillImageAnchoredposition1
	{
		get
		{
			if (_oskillImageRectTransform1 != null)
			{
				return _oskillImageRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition1 != value && _oskillImageRectTransform1 != null)
			{
				_oskillImageRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition2
	{
		get
		{
			if (_oskillImageRectTransform2 != null)
			{
				return _oskillImageRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition2 != value && _oskillImageRectTransform2 != null)
			{
				_oskillImageRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition3
	{
		get
		{
			if (_oskillImageRectTransform3 != null)
			{
				return _oskillImageRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition3 != value && _oskillImageRectTransform3 != null)
			{
				_oskillImageRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition4
	{
		get
		{
			if (_oskillImageRectTransform4 != null)
			{
				return _oskillImageRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition4 != value && _oskillImageRectTransform4 != null)
			{
				_oskillImageRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition5
	{
		get
		{
			if (_oskillImageRectTransform5 != null)
			{
				return _oskillImageRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition5 != value && _oskillImageRectTransform5 != null)
			{
				_oskillImageRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition6
	{
		get
		{
			if (_oskillImageRectTransform6 != null)
			{
				return _oskillImageRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition6 != value && _oskillImageRectTransform6 != null)
			{
				_oskillImageRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition7
	{
		get
		{
			if (_oskillImageRectTransform7 != null)
			{
				return _oskillImageRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition7 != value && _oskillImageRectTransform7 != null)
			{
				_oskillImageRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition8
	{
		get
		{
			if (_oskillImageRectTransform8 != null)
			{
				return _oskillImageRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition8 != value && _oskillImageRectTransform8 != null)
			{
				_oskillImageRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition9
	{
		get
		{
			if (_oskillImageRectTransform9 != null)
			{
				return _oskillImageRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition9 != value && _oskillImageRectTransform9 != null)
			{
				_oskillImageRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition10
	{
		get
		{
			if (_oskillImageRectTransform10 != null)
			{
				return _oskillImageRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition10 != value && _oskillImageRectTransform10 != null)
			{
				_oskillImageRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition11
	{
		get
		{
			if (_oskillImageRectTransform11 != null)
			{
				return _oskillImageRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition11 != value && _oskillImageRectTransform11 != null)
			{
				_oskillImageRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition12
	{
		get
		{
			if (_oskillImageRectTransform12 != null)
			{
				return _oskillImageRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition12 != value && _oskillImageRectTransform12 != null)
			{
				_oskillImageRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillImageAnchoredposition13
	{
		get
		{
			if (_oskillImageRectTransform13 != null)
			{
				return _oskillImageRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillImageAnchoredposition13 != value && _oskillImageRectTransform13 != null)
			{
				_oskillImageRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillImageSize1
	{
		get
		{
			if (_oskillImageRectTransform1 != null)
			{
				return _oskillImageRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize1 != value && _oskillImageRectTransform1 != null)
			{
				_oskillImageRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize2
	{
		get
		{
			if (_oskillImageRectTransform2 != null)
			{
				return _oskillImageRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize2 != value && _oskillImageRectTransform2 != null)
			{
				_oskillImageRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize3
	{
		get
		{
			if (_oskillImageRectTransform3 != null)
			{
				return _oskillImageRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize3 != value && _oskillImageRectTransform3 != null)
			{
				_oskillImageRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize4
	{
		get
		{
			if (_oskillImageRectTransform4 != null)
			{
				return _oskillImageRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize4 != value && _oskillImageRectTransform4 != null)
			{
				_oskillImageRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize5
	{
		get
		{
			if (_oskillImageRectTransform5 != null)
			{
				return _oskillImageRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize5 != value && _oskillImageRectTransform5 != null)
			{
				_oskillImageRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize6
	{
		get
		{
			if (_oskillImageRectTransform6 != null)
			{
				return _oskillImageRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize6 != value && _oskillImageRectTransform6 != null)
			{
				_oskillImageRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize7
	{
		get
		{
			if (_oskillImageRectTransform7 != null)
			{
				return _oskillImageRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize7 != value && _oskillImageRectTransform7 != null)
			{
				_oskillImageRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize8
	{
		get
		{
			if (_oskillImageRectTransform8 != null)
			{
				return _oskillImageRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize8 != value && _oskillImageRectTransform8 != null)
			{
				_oskillImageRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize9
	{
		get
		{
			if (_oskillImageRectTransform9 != null)
			{
				return _oskillImageRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize9 != value && _oskillImageRectTransform9 != null)
			{
				_oskillImageRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize10
	{
		get
		{
			if (_oskillImageRectTransform10 != null)
			{
				return _oskillImageRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize10 != value && _oskillImageRectTransform10 != null)
			{
				_oskillImageRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize11
	{
		get
		{
			if (_oskillImageRectTransform11 != null)
			{
				return _oskillImageRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize11 != value && _oskillImageRectTransform11 != null)
			{
				_oskillImageRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize12
	{
		get
		{
			if (_oskillImageRectTransform12 != null)
			{
				return _oskillImageRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize12 != value && _oskillImageRectTransform12 != null)
			{
				_oskillImageRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skillImageSize13
	{
		get
		{
			if (_oskillImageRectTransform13 != null)
			{
				return _oskillImageRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillImageSize13 != value && _oskillImageRectTransform13 != null)
			{
				_oskillImageRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skillImageSprite1
	{
		get
		{
			if (_oskillImageImage1 != null)
			{
				return _oskillImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite1 != value && _oskillImageImage1 != null)
			{
				_oskillImageImage1.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite2
	{
		get
		{
			if (_oskillImageImage2 != null)
			{
				return _oskillImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite2 != value && _oskillImageImage2 != null)
			{
				_oskillImageImage2.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite3
	{
		get
		{
			if (_oskillImageImage3 != null)
			{
				return _oskillImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite3 != value && _oskillImageImage3 != null)
			{
				_oskillImageImage3.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite4
	{
		get
		{
			if (_oskillImageImage4 != null)
			{
				return _oskillImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite4 != value && _oskillImageImage4 != null)
			{
				_oskillImageImage4.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite5
	{
		get
		{
			if (_oskillImageImage5 != null)
			{
				return _oskillImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite5 != value && _oskillImageImage5 != null)
			{
				_oskillImageImage5.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite6
	{
		get
		{
			if (_oskillImageImage6 != null)
			{
				return _oskillImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite6 != value && _oskillImageImage6 != null)
			{
				_oskillImageImage6.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite7
	{
		get
		{
			if (_oskillImageImage7 != null)
			{
				return _oskillImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite7 != value && _oskillImageImage7 != null)
			{
				_oskillImageImage7.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite8
	{
		get
		{
			if (_oskillImageImage8 != null)
			{
				return _oskillImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite8 != value && _oskillImageImage8 != null)
			{
				_oskillImageImage8.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite9
	{
		get
		{
			if (_oskillImageImage9 != null)
			{
				return _oskillImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite9 != value && _oskillImageImage9 != null)
			{
				_oskillImageImage9.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite10
	{
		get
		{
			if (_oskillImageImage10 != null)
			{
				return _oskillImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite10 != value && _oskillImageImage10 != null)
			{
				_oskillImageImage10.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite11
	{
		get
		{
			if (_oskillImageImage11 != null)
			{
				return _oskillImageImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite11 != value && _oskillImageImage11 != null)
			{
				_oskillImageImage11.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite12
	{
		get
		{
			if (_oskillImageImage12 != null)
			{
				return _oskillImageImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite12 != value && _oskillImageImage12 != null)
			{
				_oskillImageImage12.sprite = value;
			}
		}
	}

	public Sprite skillImageSprite13
	{
		get
		{
			if (_oskillImageImage13 != null)
			{
				return _oskillImageImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skillImageSprite13 != value && _oskillImageImage13 != null)
			{
				_oskillImageImage13.sprite = value;
			}
		}
	}

	public bool skillbackimgShow1
	{
		get
		{
			if (_oskillbackimg1 != null)
			{
				return _oskillbackimg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow1 != value && _oskillbackimg1 != null)
			{
				_oskillbackimg1.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow2
	{
		get
		{
			if (_oskillbackimg2 != null)
			{
				return _oskillbackimg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow2 != value && _oskillbackimg2 != null)
			{
				_oskillbackimg2.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow3
	{
		get
		{
			if (_oskillbackimg3 != null)
			{
				return _oskillbackimg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow3 != value && _oskillbackimg3 != null)
			{
				_oskillbackimg3.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow4
	{
		get
		{
			if (_oskillbackimg4 != null)
			{
				return _oskillbackimg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow4 != value && _oskillbackimg4 != null)
			{
				_oskillbackimg4.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow5
	{
		get
		{
			if (_oskillbackimg5 != null)
			{
				return _oskillbackimg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow5 != value && _oskillbackimg5 != null)
			{
				_oskillbackimg5.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow6
	{
		get
		{
			if (_oskillbackimg6 != null)
			{
				return _oskillbackimg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow6 != value && _oskillbackimg6 != null)
			{
				_oskillbackimg6.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow7
	{
		get
		{
			if (_oskillbackimg7 != null)
			{
				return _oskillbackimg7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow7 != value && _oskillbackimg7 != null)
			{
				_oskillbackimg7.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow8
	{
		get
		{
			if (_oskillbackimg8 != null)
			{
				return _oskillbackimg8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow8 != value && _oskillbackimg8 != null)
			{
				_oskillbackimg8.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow9
	{
		get
		{
			if (_oskillbackimg9 != null)
			{
				return _oskillbackimg9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow9 != value && _oskillbackimg9 != null)
			{
				_oskillbackimg9.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow10
	{
		get
		{
			if (_oskillbackimg10 != null)
			{
				return _oskillbackimg10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow10 != value && _oskillbackimg10 != null)
			{
				_oskillbackimg10.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow11
	{
		get
		{
			if (_oskillbackimg11 != null)
			{
				return _oskillbackimg11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow11 != value && _oskillbackimg11 != null)
			{
				_oskillbackimg11.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow12
	{
		get
		{
			if (_oskillbackimg12 != null)
			{
				return _oskillbackimg12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow12 != value && _oskillbackimg12 != null)
			{
				_oskillbackimg12.SetObjectActive(value);
			}
		}
	}

	public bool skillbackimgShow13
	{
		get
		{
			if (_oskillbackimg13 != null)
			{
				return _oskillbackimg13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillbackimgShow13 != value && _oskillbackimg13 != null)
			{
				_oskillbackimg13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition1
	{
		get
		{
			if (_oskillbackimgRectTransform1 != null)
			{
				return _oskillbackimgRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition1 != value && _oskillbackimgRectTransform1 != null)
			{
				_oskillbackimgRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition2
	{
		get
		{
			if (_oskillbackimgRectTransform2 != null)
			{
				return _oskillbackimgRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition2 != value && _oskillbackimgRectTransform2 != null)
			{
				_oskillbackimgRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition3
	{
		get
		{
			if (_oskillbackimgRectTransform3 != null)
			{
				return _oskillbackimgRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition3 != value && _oskillbackimgRectTransform3 != null)
			{
				_oskillbackimgRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition4
	{
		get
		{
			if (_oskillbackimgRectTransform4 != null)
			{
				return _oskillbackimgRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition4 != value && _oskillbackimgRectTransform4 != null)
			{
				_oskillbackimgRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition5
	{
		get
		{
			if (_oskillbackimgRectTransform5 != null)
			{
				return _oskillbackimgRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition5 != value && _oskillbackimgRectTransform5 != null)
			{
				_oskillbackimgRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition6
	{
		get
		{
			if (_oskillbackimgRectTransform6 != null)
			{
				return _oskillbackimgRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition6 != value && _oskillbackimgRectTransform6 != null)
			{
				_oskillbackimgRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition7
	{
		get
		{
			if (_oskillbackimgRectTransform7 != null)
			{
				return _oskillbackimgRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition7 != value && _oskillbackimgRectTransform7 != null)
			{
				_oskillbackimgRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition8
	{
		get
		{
			if (_oskillbackimgRectTransform8 != null)
			{
				return _oskillbackimgRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition8 != value && _oskillbackimgRectTransform8 != null)
			{
				_oskillbackimgRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition9
	{
		get
		{
			if (_oskillbackimgRectTransform9 != null)
			{
				return _oskillbackimgRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition9 != value && _oskillbackimgRectTransform9 != null)
			{
				_oskillbackimgRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition10
	{
		get
		{
			if (_oskillbackimgRectTransform10 != null)
			{
				return _oskillbackimgRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition10 != value && _oskillbackimgRectTransform10 != null)
			{
				_oskillbackimgRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition11
	{
		get
		{
			if (_oskillbackimgRectTransform11 != null)
			{
				return _oskillbackimgRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition11 != value && _oskillbackimgRectTransform11 != null)
			{
				_oskillbackimgRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition12
	{
		get
		{
			if (_oskillbackimgRectTransform12 != null)
			{
				return _oskillbackimgRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition12 != value && _oskillbackimgRectTransform12 != null)
			{
				_oskillbackimgRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillbackimgAnchoredposition13
	{
		get
		{
			if (_oskillbackimgRectTransform13 != null)
			{
				return _oskillbackimgRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillbackimgAnchoredposition13 != value && _oskillbackimgRectTransform13 != null)
			{
				_oskillbackimgRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillbackimgSize1
	{
		get
		{
			if (_oskillbackimgRectTransform1 != null)
			{
				return _oskillbackimgRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize1 != value && _oskillbackimgRectTransform1 != null)
			{
				_oskillbackimgRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize2
	{
		get
		{
			if (_oskillbackimgRectTransform2 != null)
			{
				return _oskillbackimgRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize2 != value && _oskillbackimgRectTransform2 != null)
			{
				_oskillbackimgRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize3
	{
		get
		{
			if (_oskillbackimgRectTransform3 != null)
			{
				return _oskillbackimgRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize3 != value && _oskillbackimgRectTransform3 != null)
			{
				_oskillbackimgRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize4
	{
		get
		{
			if (_oskillbackimgRectTransform4 != null)
			{
				return _oskillbackimgRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize4 != value && _oskillbackimgRectTransform4 != null)
			{
				_oskillbackimgRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize5
	{
		get
		{
			if (_oskillbackimgRectTransform5 != null)
			{
				return _oskillbackimgRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize5 != value && _oskillbackimgRectTransform5 != null)
			{
				_oskillbackimgRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize6
	{
		get
		{
			if (_oskillbackimgRectTransform6 != null)
			{
				return _oskillbackimgRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize6 != value && _oskillbackimgRectTransform6 != null)
			{
				_oskillbackimgRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize7
	{
		get
		{
			if (_oskillbackimgRectTransform7 != null)
			{
				return _oskillbackimgRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize7 != value && _oskillbackimgRectTransform7 != null)
			{
				_oskillbackimgRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize8
	{
		get
		{
			if (_oskillbackimgRectTransform8 != null)
			{
				return _oskillbackimgRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize8 != value && _oskillbackimgRectTransform8 != null)
			{
				_oskillbackimgRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize9
	{
		get
		{
			if (_oskillbackimgRectTransform9 != null)
			{
				return _oskillbackimgRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize9 != value && _oskillbackimgRectTransform9 != null)
			{
				_oskillbackimgRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize10
	{
		get
		{
			if (_oskillbackimgRectTransform10 != null)
			{
				return _oskillbackimgRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize10 != value && _oskillbackimgRectTransform10 != null)
			{
				_oskillbackimgRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize11
	{
		get
		{
			if (_oskillbackimgRectTransform11 != null)
			{
				return _oskillbackimgRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize11 != value && _oskillbackimgRectTransform11 != null)
			{
				_oskillbackimgRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize12
	{
		get
		{
			if (_oskillbackimgRectTransform12 != null)
			{
				return _oskillbackimgRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize12 != value && _oskillbackimgRectTransform12 != null)
			{
				_oskillbackimgRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skillbackimgSize13
	{
		get
		{
			if (_oskillbackimgRectTransform13 != null)
			{
				return _oskillbackimgRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillbackimgSize13 != value && _oskillbackimgRectTransform13 != null)
			{
				_oskillbackimgRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skillbackimgSprite1
	{
		get
		{
			if (_oskillbackimgImage1 != null)
			{
				return _oskillbackimgImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite1 != value && _oskillbackimgImage1 != null)
			{
				_oskillbackimgImage1.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite2
	{
		get
		{
			if (_oskillbackimgImage2 != null)
			{
				return _oskillbackimgImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite2 != value && _oskillbackimgImage2 != null)
			{
				_oskillbackimgImage2.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite3
	{
		get
		{
			if (_oskillbackimgImage3 != null)
			{
				return _oskillbackimgImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite3 != value && _oskillbackimgImage3 != null)
			{
				_oskillbackimgImage3.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite4
	{
		get
		{
			if (_oskillbackimgImage4 != null)
			{
				return _oskillbackimgImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite4 != value && _oskillbackimgImage4 != null)
			{
				_oskillbackimgImage4.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite5
	{
		get
		{
			if (_oskillbackimgImage5 != null)
			{
				return _oskillbackimgImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite5 != value && _oskillbackimgImage5 != null)
			{
				_oskillbackimgImage5.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite6
	{
		get
		{
			if (_oskillbackimgImage6 != null)
			{
				return _oskillbackimgImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite6 != value && _oskillbackimgImage6 != null)
			{
				_oskillbackimgImage6.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite7
	{
		get
		{
			if (_oskillbackimgImage7 != null)
			{
				return _oskillbackimgImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite7 != value && _oskillbackimgImage7 != null)
			{
				_oskillbackimgImage7.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite8
	{
		get
		{
			if (_oskillbackimgImage8 != null)
			{
				return _oskillbackimgImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite8 != value && _oskillbackimgImage8 != null)
			{
				_oskillbackimgImage8.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite9
	{
		get
		{
			if (_oskillbackimgImage9 != null)
			{
				return _oskillbackimgImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite9 != value && _oskillbackimgImage9 != null)
			{
				_oskillbackimgImage9.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite10
	{
		get
		{
			if (_oskillbackimgImage10 != null)
			{
				return _oskillbackimgImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite10 != value && _oskillbackimgImage10 != null)
			{
				_oskillbackimgImage10.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite11
	{
		get
		{
			if (_oskillbackimgImage11 != null)
			{
				return _oskillbackimgImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite11 != value && _oskillbackimgImage11 != null)
			{
				_oskillbackimgImage11.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite12
	{
		get
		{
			if (_oskillbackimgImage12 != null)
			{
				return _oskillbackimgImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite12 != value && _oskillbackimgImage12 != null)
			{
				_oskillbackimgImage12.sprite = value;
			}
		}
	}

	public Sprite skillbackimgSprite13
	{
		get
		{
			if (_oskillbackimgImage13 != null)
			{
				return _oskillbackimgImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skillbackimgSprite13 != value && _oskillbackimgImage13 != null)
			{
				_oskillbackimgImage13.sprite = value;
			}
		}
	}

	public bool skillmaxImgShow1
	{
		get
		{
			if (_oskillmaxImg1 != null)
			{
				return _oskillmaxImg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow1 != value && _oskillmaxImg1 != null)
			{
				_oskillmaxImg1.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow2
	{
		get
		{
			if (_oskillmaxImg2 != null)
			{
				return _oskillmaxImg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow2 != value && _oskillmaxImg2 != null)
			{
				_oskillmaxImg2.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow3
	{
		get
		{
			if (_oskillmaxImg3 != null)
			{
				return _oskillmaxImg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow3 != value && _oskillmaxImg3 != null)
			{
				_oskillmaxImg3.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow4
	{
		get
		{
			if (_oskillmaxImg4 != null)
			{
				return _oskillmaxImg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow4 != value && _oskillmaxImg4 != null)
			{
				_oskillmaxImg4.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow5
	{
		get
		{
			if (_oskillmaxImg5 != null)
			{
				return _oskillmaxImg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow5 != value && _oskillmaxImg5 != null)
			{
				_oskillmaxImg5.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow6
	{
		get
		{
			if (_oskillmaxImg6 != null)
			{
				return _oskillmaxImg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow6 != value && _oskillmaxImg6 != null)
			{
				_oskillmaxImg6.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow7
	{
		get
		{
			if (_oskillmaxImg7 != null)
			{
				return _oskillmaxImg7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow7 != value && _oskillmaxImg7 != null)
			{
				_oskillmaxImg7.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow8
	{
		get
		{
			if (_oskillmaxImg8 != null)
			{
				return _oskillmaxImg8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow8 != value && _oskillmaxImg8 != null)
			{
				_oskillmaxImg8.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow9
	{
		get
		{
			if (_oskillmaxImg9 != null)
			{
				return _oskillmaxImg9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow9 != value && _oskillmaxImg9 != null)
			{
				_oskillmaxImg9.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow10
	{
		get
		{
			if (_oskillmaxImg10 != null)
			{
				return _oskillmaxImg10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow10 != value && _oskillmaxImg10 != null)
			{
				_oskillmaxImg10.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow11
	{
		get
		{
			if (_oskillmaxImg11 != null)
			{
				return _oskillmaxImg11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow11 != value && _oskillmaxImg11 != null)
			{
				_oskillmaxImg11.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow12
	{
		get
		{
			if (_oskillmaxImg12 != null)
			{
				return _oskillmaxImg12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow12 != value && _oskillmaxImg12 != null)
			{
				_oskillmaxImg12.SetObjectActive(value);
			}
		}
	}

	public bool skillmaxImgShow13
	{
		get
		{
			if (_oskillmaxImg13 != null)
			{
				return _oskillmaxImg13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillmaxImgShow13 != value && _oskillmaxImg13 != null)
			{
				_oskillmaxImg13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition1
	{
		get
		{
			if (_oskillmaxImgRectTransform1 != null)
			{
				return _oskillmaxImgRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition1 != value && _oskillmaxImgRectTransform1 != null)
			{
				_oskillmaxImgRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition2
	{
		get
		{
			if (_oskillmaxImgRectTransform2 != null)
			{
				return _oskillmaxImgRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition2 != value && _oskillmaxImgRectTransform2 != null)
			{
				_oskillmaxImgRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition3
	{
		get
		{
			if (_oskillmaxImgRectTransform3 != null)
			{
				return _oskillmaxImgRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition3 != value && _oskillmaxImgRectTransform3 != null)
			{
				_oskillmaxImgRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition4
	{
		get
		{
			if (_oskillmaxImgRectTransform4 != null)
			{
				return _oskillmaxImgRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition4 != value && _oskillmaxImgRectTransform4 != null)
			{
				_oskillmaxImgRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition5
	{
		get
		{
			if (_oskillmaxImgRectTransform5 != null)
			{
				return _oskillmaxImgRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition5 != value && _oskillmaxImgRectTransform5 != null)
			{
				_oskillmaxImgRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition6
	{
		get
		{
			if (_oskillmaxImgRectTransform6 != null)
			{
				return _oskillmaxImgRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition6 != value && _oskillmaxImgRectTransform6 != null)
			{
				_oskillmaxImgRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition7
	{
		get
		{
			if (_oskillmaxImgRectTransform7 != null)
			{
				return _oskillmaxImgRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition7 != value && _oskillmaxImgRectTransform7 != null)
			{
				_oskillmaxImgRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition8
	{
		get
		{
			if (_oskillmaxImgRectTransform8 != null)
			{
				return _oskillmaxImgRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition8 != value && _oskillmaxImgRectTransform8 != null)
			{
				_oskillmaxImgRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition9
	{
		get
		{
			if (_oskillmaxImgRectTransform9 != null)
			{
				return _oskillmaxImgRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition9 != value && _oskillmaxImgRectTransform9 != null)
			{
				_oskillmaxImgRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition10
	{
		get
		{
			if (_oskillmaxImgRectTransform10 != null)
			{
				return _oskillmaxImgRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition10 != value && _oskillmaxImgRectTransform10 != null)
			{
				_oskillmaxImgRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition11
	{
		get
		{
			if (_oskillmaxImgRectTransform11 != null)
			{
				return _oskillmaxImgRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition11 != value && _oskillmaxImgRectTransform11 != null)
			{
				_oskillmaxImgRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition12
	{
		get
		{
			if (_oskillmaxImgRectTransform12 != null)
			{
				return _oskillmaxImgRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition12 != value && _oskillmaxImgRectTransform12 != null)
			{
				_oskillmaxImgRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillmaxImgAnchoredposition13
	{
		get
		{
			if (_oskillmaxImgRectTransform13 != null)
			{
				return _oskillmaxImgRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillmaxImgAnchoredposition13 != value && _oskillmaxImgRectTransform13 != null)
			{
				_oskillmaxImgRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillmaxImgSize1
	{
		get
		{
			if (_oskillmaxImgRectTransform1 != null)
			{
				return _oskillmaxImgRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize1 != value && _oskillmaxImgRectTransform1 != null)
			{
				_oskillmaxImgRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize2
	{
		get
		{
			if (_oskillmaxImgRectTransform2 != null)
			{
				return _oskillmaxImgRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize2 != value && _oskillmaxImgRectTransform2 != null)
			{
				_oskillmaxImgRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize3
	{
		get
		{
			if (_oskillmaxImgRectTransform3 != null)
			{
				return _oskillmaxImgRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize3 != value && _oskillmaxImgRectTransform3 != null)
			{
				_oskillmaxImgRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize4
	{
		get
		{
			if (_oskillmaxImgRectTransform4 != null)
			{
				return _oskillmaxImgRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize4 != value && _oskillmaxImgRectTransform4 != null)
			{
				_oskillmaxImgRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize5
	{
		get
		{
			if (_oskillmaxImgRectTransform5 != null)
			{
				return _oskillmaxImgRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize5 != value && _oskillmaxImgRectTransform5 != null)
			{
				_oskillmaxImgRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize6
	{
		get
		{
			if (_oskillmaxImgRectTransform6 != null)
			{
				return _oskillmaxImgRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize6 != value && _oskillmaxImgRectTransform6 != null)
			{
				_oskillmaxImgRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize7
	{
		get
		{
			if (_oskillmaxImgRectTransform7 != null)
			{
				return _oskillmaxImgRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize7 != value && _oskillmaxImgRectTransform7 != null)
			{
				_oskillmaxImgRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize8
	{
		get
		{
			if (_oskillmaxImgRectTransform8 != null)
			{
				return _oskillmaxImgRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize8 != value && _oskillmaxImgRectTransform8 != null)
			{
				_oskillmaxImgRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize9
	{
		get
		{
			if (_oskillmaxImgRectTransform9 != null)
			{
				return _oskillmaxImgRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize9 != value && _oskillmaxImgRectTransform9 != null)
			{
				_oskillmaxImgRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize10
	{
		get
		{
			if (_oskillmaxImgRectTransform10 != null)
			{
				return _oskillmaxImgRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize10 != value && _oskillmaxImgRectTransform10 != null)
			{
				_oskillmaxImgRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize11
	{
		get
		{
			if (_oskillmaxImgRectTransform11 != null)
			{
				return _oskillmaxImgRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize11 != value && _oskillmaxImgRectTransform11 != null)
			{
				_oskillmaxImgRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize12
	{
		get
		{
			if (_oskillmaxImgRectTransform12 != null)
			{
				return _oskillmaxImgRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize12 != value && _oskillmaxImgRectTransform12 != null)
			{
				_oskillmaxImgRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skillmaxImgSize13
	{
		get
		{
			if (_oskillmaxImgRectTransform13 != null)
			{
				return _oskillmaxImgRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillmaxImgSize13 != value && _oskillmaxImgRectTransform13 != null)
			{
				_oskillmaxImgRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skillmaxImgSprite1
	{
		get
		{
			if (_oskillmaxImgImage1 != null)
			{
				return _oskillmaxImgImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite1 != value && _oskillmaxImgImage1 != null)
			{
				_oskillmaxImgImage1.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite2
	{
		get
		{
			if (_oskillmaxImgImage2 != null)
			{
				return _oskillmaxImgImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite2 != value && _oskillmaxImgImage2 != null)
			{
				_oskillmaxImgImage2.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite3
	{
		get
		{
			if (_oskillmaxImgImage3 != null)
			{
				return _oskillmaxImgImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite3 != value && _oskillmaxImgImage3 != null)
			{
				_oskillmaxImgImage3.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite4
	{
		get
		{
			if (_oskillmaxImgImage4 != null)
			{
				return _oskillmaxImgImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite4 != value && _oskillmaxImgImage4 != null)
			{
				_oskillmaxImgImage4.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite5
	{
		get
		{
			if (_oskillmaxImgImage5 != null)
			{
				return _oskillmaxImgImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite5 != value && _oskillmaxImgImage5 != null)
			{
				_oskillmaxImgImage5.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite6
	{
		get
		{
			if (_oskillmaxImgImage6 != null)
			{
				return _oskillmaxImgImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite6 != value && _oskillmaxImgImage6 != null)
			{
				_oskillmaxImgImage6.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite7
	{
		get
		{
			if (_oskillmaxImgImage7 != null)
			{
				return _oskillmaxImgImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite7 != value && _oskillmaxImgImage7 != null)
			{
				_oskillmaxImgImage7.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite8
	{
		get
		{
			if (_oskillmaxImgImage8 != null)
			{
				return _oskillmaxImgImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite8 != value && _oskillmaxImgImage8 != null)
			{
				_oskillmaxImgImage8.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite9
	{
		get
		{
			if (_oskillmaxImgImage9 != null)
			{
				return _oskillmaxImgImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite9 != value && _oskillmaxImgImage9 != null)
			{
				_oskillmaxImgImage9.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite10
	{
		get
		{
			if (_oskillmaxImgImage10 != null)
			{
				return _oskillmaxImgImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite10 != value && _oskillmaxImgImage10 != null)
			{
				_oskillmaxImgImage10.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite11
	{
		get
		{
			if (_oskillmaxImgImage11 != null)
			{
				return _oskillmaxImgImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite11 != value && _oskillmaxImgImage11 != null)
			{
				_oskillmaxImgImage11.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite12
	{
		get
		{
			if (_oskillmaxImgImage12 != null)
			{
				return _oskillmaxImgImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite12 != value && _oskillmaxImgImage12 != null)
			{
				_oskillmaxImgImage12.sprite = value;
			}
		}
	}

	public Sprite skillmaxImgSprite13
	{
		get
		{
			if (_oskillmaxImgImage13 != null)
			{
				return _oskillmaxImgImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skillmaxImgSprite13 != value && _oskillmaxImgImage13 != null)
			{
				_oskillmaxImgImage13.sprite = value;
			}
		}
	}

	public bool skillimagestudioShow1
	{
		get
		{
			if (_oskillimagestudio1 != null)
			{
				return _oskillimagestudio1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow1 != value && _oskillimagestudio1 != null)
			{
				_oskillimagestudio1.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow2
	{
		get
		{
			if (_oskillimagestudio2 != null)
			{
				return _oskillimagestudio2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow2 != value && _oskillimagestudio2 != null)
			{
				_oskillimagestudio2.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow3
	{
		get
		{
			if (_oskillimagestudio3 != null)
			{
				return _oskillimagestudio3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow3 != value && _oskillimagestudio3 != null)
			{
				_oskillimagestudio3.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow4
	{
		get
		{
			if (_oskillimagestudio4 != null)
			{
				return _oskillimagestudio4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow4 != value && _oskillimagestudio4 != null)
			{
				_oskillimagestudio4.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow5
	{
		get
		{
			if (_oskillimagestudio5 != null)
			{
				return _oskillimagestudio5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow5 != value && _oskillimagestudio5 != null)
			{
				_oskillimagestudio5.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow6
	{
		get
		{
			if (_oskillimagestudio6 != null)
			{
				return _oskillimagestudio6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow6 != value && _oskillimagestudio6 != null)
			{
				_oskillimagestudio6.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow7
	{
		get
		{
			if (_oskillimagestudio7 != null)
			{
				return _oskillimagestudio7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow7 != value && _oskillimagestudio7 != null)
			{
				_oskillimagestudio7.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow8
	{
		get
		{
			if (_oskillimagestudio8 != null)
			{
				return _oskillimagestudio8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow8 != value && _oskillimagestudio8 != null)
			{
				_oskillimagestudio8.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow9
	{
		get
		{
			if (_oskillimagestudio9 != null)
			{
				return _oskillimagestudio9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow9 != value && _oskillimagestudio9 != null)
			{
				_oskillimagestudio9.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow10
	{
		get
		{
			if (_oskillimagestudio10 != null)
			{
				return _oskillimagestudio10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow10 != value && _oskillimagestudio10 != null)
			{
				_oskillimagestudio10.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow11
	{
		get
		{
			if (_oskillimagestudio11 != null)
			{
				return _oskillimagestudio11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow11 != value && _oskillimagestudio11 != null)
			{
				_oskillimagestudio11.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow12
	{
		get
		{
			if (_oskillimagestudio12 != null)
			{
				return _oskillimagestudio12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow12 != value && _oskillimagestudio12 != null)
			{
				_oskillimagestudio12.SetObjectActive(value);
			}
		}
	}

	public bool skillimagestudioShow13
	{
		get
		{
			if (_oskillimagestudio13 != null)
			{
				return _oskillimagestudio13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillimagestudioShow13 != value && _oskillimagestudio13 != null)
			{
				_oskillimagestudio13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition1
	{
		get
		{
			if (_oskillimagestudioRectTransform1 != null)
			{
				return _oskillimagestudioRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition1 != value && _oskillimagestudioRectTransform1 != null)
			{
				_oskillimagestudioRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition2
	{
		get
		{
			if (_oskillimagestudioRectTransform2 != null)
			{
				return _oskillimagestudioRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition2 != value && _oskillimagestudioRectTransform2 != null)
			{
				_oskillimagestudioRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition3
	{
		get
		{
			if (_oskillimagestudioRectTransform3 != null)
			{
				return _oskillimagestudioRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition3 != value && _oskillimagestudioRectTransform3 != null)
			{
				_oskillimagestudioRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition4
	{
		get
		{
			if (_oskillimagestudioRectTransform4 != null)
			{
				return _oskillimagestudioRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition4 != value && _oskillimagestudioRectTransform4 != null)
			{
				_oskillimagestudioRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition5
	{
		get
		{
			if (_oskillimagestudioRectTransform5 != null)
			{
				return _oskillimagestudioRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition5 != value && _oskillimagestudioRectTransform5 != null)
			{
				_oskillimagestudioRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition6
	{
		get
		{
			if (_oskillimagestudioRectTransform6 != null)
			{
				return _oskillimagestudioRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition6 != value && _oskillimagestudioRectTransform6 != null)
			{
				_oskillimagestudioRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition7
	{
		get
		{
			if (_oskillimagestudioRectTransform7 != null)
			{
				return _oskillimagestudioRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition7 != value && _oskillimagestudioRectTransform7 != null)
			{
				_oskillimagestudioRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition8
	{
		get
		{
			if (_oskillimagestudioRectTransform8 != null)
			{
				return _oskillimagestudioRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition8 != value && _oskillimagestudioRectTransform8 != null)
			{
				_oskillimagestudioRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition9
	{
		get
		{
			if (_oskillimagestudioRectTransform9 != null)
			{
				return _oskillimagestudioRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition9 != value && _oskillimagestudioRectTransform9 != null)
			{
				_oskillimagestudioRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition10
	{
		get
		{
			if (_oskillimagestudioRectTransform10 != null)
			{
				return _oskillimagestudioRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition10 != value && _oskillimagestudioRectTransform10 != null)
			{
				_oskillimagestudioRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition11
	{
		get
		{
			if (_oskillimagestudioRectTransform11 != null)
			{
				return _oskillimagestudioRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition11 != value && _oskillimagestudioRectTransform11 != null)
			{
				_oskillimagestudioRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition12
	{
		get
		{
			if (_oskillimagestudioRectTransform12 != null)
			{
				return _oskillimagestudioRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition12 != value && _oskillimagestudioRectTransform12 != null)
			{
				_oskillimagestudioRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillimagestudioAnchoredposition13
	{
		get
		{
			if (_oskillimagestudioRectTransform13 != null)
			{
				return _oskillimagestudioRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillimagestudioAnchoredposition13 != value && _oskillimagestudioRectTransform13 != null)
			{
				_oskillimagestudioRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillimagestudioScale1
	{
		get
		{
			if (_oskillimagestudioRectTransform1 != null)
			{
				return _oskillimagestudioRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale1 != value && _oskillimagestudioRectTransform1 != null)
			{
				_oskillimagestudioRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale2
	{
		get
		{
			if (_oskillimagestudioRectTransform2 != null)
			{
				return _oskillimagestudioRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale2 != value && _oskillimagestudioRectTransform2 != null)
			{
				_oskillimagestudioRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale3
	{
		get
		{
			if (_oskillimagestudioRectTransform3 != null)
			{
				return _oskillimagestudioRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale3 != value && _oskillimagestudioRectTransform3 != null)
			{
				_oskillimagestudioRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale4
	{
		get
		{
			if (_oskillimagestudioRectTransform4 != null)
			{
				return _oskillimagestudioRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale4 != value && _oskillimagestudioRectTransform4 != null)
			{
				_oskillimagestudioRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale5
	{
		get
		{
			if (_oskillimagestudioRectTransform5 != null)
			{
				return _oskillimagestudioRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale5 != value && _oskillimagestudioRectTransform5 != null)
			{
				_oskillimagestudioRectTransform5.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale6
	{
		get
		{
			if (_oskillimagestudioRectTransform6 != null)
			{
				return _oskillimagestudioRectTransform6.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale6 != value && _oskillimagestudioRectTransform6 != null)
			{
				_oskillimagestudioRectTransform6.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale7
	{
		get
		{
			if (_oskillimagestudioRectTransform7 != null)
			{
				return _oskillimagestudioRectTransform7.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale7 != value && _oskillimagestudioRectTransform7 != null)
			{
				_oskillimagestudioRectTransform7.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale8
	{
		get
		{
			if (_oskillimagestudioRectTransform8 != null)
			{
				return _oskillimagestudioRectTransform8.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale8 != value && _oskillimagestudioRectTransform8 != null)
			{
				_oskillimagestudioRectTransform8.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale9
	{
		get
		{
			if (_oskillimagestudioRectTransform9 != null)
			{
				return _oskillimagestudioRectTransform9.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale9 != value && _oskillimagestudioRectTransform9 != null)
			{
				_oskillimagestudioRectTransform9.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale10
	{
		get
		{
			if (_oskillimagestudioRectTransform10 != null)
			{
				return _oskillimagestudioRectTransform10.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale10 != value && _oskillimagestudioRectTransform10 != null)
			{
				_oskillimagestudioRectTransform10.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale11
	{
		get
		{
			if (_oskillimagestudioRectTransform11 != null)
			{
				return _oskillimagestudioRectTransform11.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale11 != value && _oskillimagestudioRectTransform11 != null)
			{
				_oskillimagestudioRectTransform11.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale12
	{
		get
		{
			if (_oskillimagestudioRectTransform12 != null)
			{
				return _oskillimagestudioRectTransform12.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale12 != value && _oskillimagestudioRectTransform12 != null)
			{
				_oskillimagestudioRectTransform12.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioScale13
	{
		get
		{
			if (_oskillimagestudioRectTransform13 != null)
			{
				return _oskillimagestudioRectTransform13.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioScale13 != value && _oskillimagestudioRectTransform13 != null)
			{
				_oskillimagestudioRectTransform13.localScale = value;
			}
		}
	}

	public Vector3 skillimagestudioSize1
	{
		get
		{
			if (_oskillimagestudioRectTransform1 != null)
			{
				return _oskillimagestudioRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize1 != value && _oskillimagestudioRectTransform1 != null)
			{
				_oskillimagestudioRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize2
	{
		get
		{
			if (_oskillimagestudioRectTransform2 != null)
			{
				return _oskillimagestudioRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize2 != value && _oskillimagestudioRectTransform2 != null)
			{
				_oskillimagestudioRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize3
	{
		get
		{
			if (_oskillimagestudioRectTransform3 != null)
			{
				return _oskillimagestudioRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize3 != value && _oskillimagestudioRectTransform3 != null)
			{
				_oskillimagestudioRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize4
	{
		get
		{
			if (_oskillimagestudioRectTransform4 != null)
			{
				return _oskillimagestudioRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize4 != value && _oskillimagestudioRectTransform4 != null)
			{
				_oskillimagestudioRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize5
	{
		get
		{
			if (_oskillimagestudioRectTransform5 != null)
			{
				return _oskillimagestudioRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize5 != value && _oskillimagestudioRectTransform5 != null)
			{
				_oskillimagestudioRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize6
	{
		get
		{
			if (_oskillimagestudioRectTransform6 != null)
			{
				return _oskillimagestudioRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize6 != value && _oskillimagestudioRectTransform6 != null)
			{
				_oskillimagestudioRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize7
	{
		get
		{
			if (_oskillimagestudioRectTransform7 != null)
			{
				return _oskillimagestudioRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize7 != value && _oskillimagestudioRectTransform7 != null)
			{
				_oskillimagestudioRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize8
	{
		get
		{
			if (_oskillimagestudioRectTransform8 != null)
			{
				return _oskillimagestudioRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize8 != value && _oskillimagestudioRectTransform8 != null)
			{
				_oskillimagestudioRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize9
	{
		get
		{
			if (_oskillimagestudioRectTransform9 != null)
			{
				return _oskillimagestudioRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize9 != value && _oskillimagestudioRectTransform9 != null)
			{
				_oskillimagestudioRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize10
	{
		get
		{
			if (_oskillimagestudioRectTransform10 != null)
			{
				return _oskillimagestudioRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize10 != value && _oskillimagestudioRectTransform10 != null)
			{
				_oskillimagestudioRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize11
	{
		get
		{
			if (_oskillimagestudioRectTransform11 != null)
			{
				return _oskillimagestudioRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize11 != value && _oskillimagestudioRectTransform11 != null)
			{
				_oskillimagestudioRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize12
	{
		get
		{
			if (_oskillimagestudioRectTransform12 != null)
			{
				return _oskillimagestudioRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize12 != value && _oskillimagestudioRectTransform12 != null)
			{
				_oskillimagestudioRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skillimagestudioSize13
	{
		get
		{
			if (_oskillimagestudioRectTransform13 != null)
			{
				return _oskillimagestudioRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillimagestudioSize13 != value && _oskillimagestudioRectTransform13 != null)
			{
				_oskillimagestudioRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skillimagestudioSprite1
	{
		get
		{
			if (_oskillimagestudioImage1 != null)
			{
				return _oskillimagestudioImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite1 != value && _oskillimagestudioImage1 != null)
			{
				_oskillimagestudioImage1.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite2
	{
		get
		{
			if (_oskillimagestudioImage2 != null)
			{
				return _oskillimagestudioImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite2 != value && _oskillimagestudioImage2 != null)
			{
				_oskillimagestudioImage2.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite3
	{
		get
		{
			if (_oskillimagestudioImage3 != null)
			{
				return _oskillimagestudioImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite3 != value && _oskillimagestudioImage3 != null)
			{
				_oskillimagestudioImage3.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite4
	{
		get
		{
			if (_oskillimagestudioImage4 != null)
			{
				return _oskillimagestudioImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite4 != value && _oskillimagestudioImage4 != null)
			{
				_oskillimagestudioImage4.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite5
	{
		get
		{
			if (_oskillimagestudioImage5 != null)
			{
				return _oskillimagestudioImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite5 != value && _oskillimagestudioImage5 != null)
			{
				_oskillimagestudioImage5.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite6
	{
		get
		{
			if (_oskillimagestudioImage6 != null)
			{
				return _oskillimagestudioImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite6 != value && _oskillimagestudioImage6 != null)
			{
				_oskillimagestudioImage6.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite7
	{
		get
		{
			if (_oskillimagestudioImage7 != null)
			{
				return _oskillimagestudioImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite7 != value && _oskillimagestudioImage7 != null)
			{
				_oskillimagestudioImage7.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite8
	{
		get
		{
			if (_oskillimagestudioImage8 != null)
			{
				return _oskillimagestudioImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite8 != value && _oskillimagestudioImage8 != null)
			{
				_oskillimagestudioImage8.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite9
	{
		get
		{
			if (_oskillimagestudioImage9 != null)
			{
				return _oskillimagestudioImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite9 != value && _oskillimagestudioImage9 != null)
			{
				_oskillimagestudioImage9.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite10
	{
		get
		{
			if (_oskillimagestudioImage10 != null)
			{
				return _oskillimagestudioImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite10 != value && _oskillimagestudioImage10 != null)
			{
				_oskillimagestudioImage10.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite11
	{
		get
		{
			if (_oskillimagestudioImage11 != null)
			{
				return _oskillimagestudioImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite11 != value && _oskillimagestudioImage11 != null)
			{
				_oskillimagestudioImage11.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite12
	{
		get
		{
			if (_oskillimagestudioImage12 != null)
			{
				return _oskillimagestudioImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite12 != value && _oskillimagestudioImage12 != null)
			{
				_oskillimagestudioImage12.sprite = value;
			}
		}
	}

	public Sprite skillimagestudioSprite13
	{
		get
		{
			if (_oskillimagestudioImage13 != null)
			{
				return _oskillimagestudioImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skillimagestudioSprite13 != value && _oskillimagestudioImage13 != null)
			{
				_oskillimagestudioImage13.sprite = value;
			}
		}
	}

	public bool skilleffectShow1
	{
		get
		{
			if (_oskilleffect1 != null)
			{
				return _oskilleffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow1 != value && _oskilleffect1 != null)
			{
				_oskilleffect1.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow2
	{
		get
		{
			if (_oskilleffect2 != null)
			{
				return _oskilleffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow2 != value && _oskilleffect2 != null)
			{
				_oskilleffect2.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow3
	{
		get
		{
			if (_oskilleffect3 != null)
			{
				return _oskilleffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow3 != value && _oskilleffect3 != null)
			{
				_oskilleffect3.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow4
	{
		get
		{
			if (_oskilleffect4 != null)
			{
				return _oskilleffect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow4 != value && _oskilleffect4 != null)
			{
				_oskilleffect4.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow5
	{
		get
		{
			if (_oskilleffect5 != null)
			{
				return _oskilleffect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow5 != value && _oskilleffect5 != null)
			{
				_oskilleffect5.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow6
	{
		get
		{
			if (_oskilleffect6 != null)
			{
				return _oskilleffect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow6 != value && _oskilleffect6 != null)
			{
				_oskilleffect6.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow7
	{
		get
		{
			if (_oskilleffect7 != null)
			{
				return _oskilleffect7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow7 != value && _oskilleffect7 != null)
			{
				_oskilleffect7.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow8
	{
		get
		{
			if (_oskilleffect8 != null)
			{
				return _oskilleffect8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow8 != value && _oskilleffect8 != null)
			{
				_oskilleffect8.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow9
	{
		get
		{
			if (_oskilleffect9 != null)
			{
				return _oskilleffect9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow9 != value && _oskilleffect9 != null)
			{
				_oskilleffect9.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow10
	{
		get
		{
			if (_oskilleffect10 != null)
			{
				return _oskilleffect10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow10 != value && _oskilleffect10 != null)
			{
				_oskilleffect10.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow11
	{
		get
		{
			if (_oskilleffect11 != null)
			{
				return _oskilleffect11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow11 != value && _oskilleffect11 != null)
			{
				_oskilleffect11.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow12
	{
		get
		{
			if (_oskilleffect12 != null)
			{
				return _oskilleffect12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow12 != value && _oskilleffect12 != null)
			{
				_oskilleffect12.SetObjectActive(value);
			}
		}
	}

	public bool skilleffectShow13
	{
		get
		{
			if (_oskilleffect13 != null)
			{
				return _oskilleffect13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilleffectShow13 != value && _oskilleffect13 != null)
			{
				_oskilleffect13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skilleffectAnchoredposition1
	{
		get
		{
			if (_oskilleffectRectTransform1 != null)
			{
				return _oskilleffectRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition1 != value && _oskilleffectRectTransform1 != null)
			{
				_oskilleffectRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition2
	{
		get
		{
			if (_oskilleffectRectTransform2 != null)
			{
				return _oskilleffectRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition2 != value && _oskilleffectRectTransform2 != null)
			{
				_oskilleffectRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition3
	{
		get
		{
			if (_oskilleffectRectTransform3 != null)
			{
				return _oskilleffectRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition3 != value && _oskilleffectRectTransform3 != null)
			{
				_oskilleffectRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition4
	{
		get
		{
			if (_oskilleffectRectTransform4 != null)
			{
				return _oskilleffectRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition4 != value && _oskilleffectRectTransform4 != null)
			{
				_oskilleffectRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition5
	{
		get
		{
			if (_oskilleffectRectTransform5 != null)
			{
				return _oskilleffectRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition5 != value && _oskilleffectRectTransform5 != null)
			{
				_oskilleffectRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition6
	{
		get
		{
			if (_oskilleffectRectTransform6 != null)
			{
				return _oskilleffectRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition6 != value && _oskilleffectRectTransform6 != null)
			{
				_oskilleffectRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition7
	{
		get
		{
			if (_oskilleffectRectTransform7 != null)
			{
				return _oskilleffectRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition7 != value && _oskilleffectRectTransform7 != null)
			{
				_oskilleffectRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition8
	{
		get
		{
			if (_oskilleffectRectTransform8 != null)
			{
				return _oskilleffectRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition8 != value && _oskilleffectRectTransform8 != null)
			{
				_oskilleffectRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition9
	{
		get
		{
			if (_oskilleffectRectTransform9 != null)
			{
				return _oskilleffectRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition9 != value && _oskilleffectRectTransform9 != null)
			{
				_oskilleffectRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition10
	{
		get
		{
			if (_oskilleffectRectTransform10 != null)
			{
				return _oskilleffectRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition10 != value && _oskilleffectRectTransform10 != null)
			{
				_oskilleffectRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition11
	{
		get
		{
			if (_oskilleffectRectTransform11 != null)
			{
				return _oskilleffectRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition11 != value && _oskilleffectRectTransform11 != null)
			{
				_oskilleffectRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition12
	{
		get
		{
			if (_oskilleffectRectTransform12 != null)
			{
				return _oskilleffectRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition12 != value && _oskilleffectRectTransform12 != null)
			{
				_oskilleffectRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skilleffectAnchoredposition13
	{
		get
		{
			if (_oskilleffectRectTransform13 != null)
			{
				return _oskilleffectRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skilleffectAnchoredposition13 != value && _oskilleffectRectTransform13 != null)
			{
				_oskilleffectRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skilleffectSize1
	{
		get
		{
			if (_oskilleffectRectTransform1 != null)
			{
				return _oskilleffectRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize1 != value && _oskilleffectRectTransform1 != null)
			{
				_oskilleffectRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize2
	{
		get
		{
			if (_oskilleffectRectTransform2 != null)
			{
				return _oskilleffectRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize2 != value && _oskilleffectRectTransform2 != null)
			{
				_oskilleffectRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize3
	{
		get
		{
			if (_oskilleffectRectTransform3 != null)
			{
				return _oskilleffectRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize3 != value && _oskilleffectRectTransform3 != null)
			{
				_oskilleffectRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize4
	{
		get
		{
			if (_oskilleffectRectTransform4 != null)
			{
				return _oskilleffectRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize4 != value && _oskilleffectRectTransform4 != null)
			{
				_oskilleffectRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize5
	{
		get
		{
			if (_oskilleffectRectTransform5 != null)
			{
				return _oskilleffectRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize5 != value && _oskilleffectRectTransform5 != null)
			{
				_oskilleffectRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize6
	{
		get
		{
			if (_oskilleffectRectTransform6 != null)
			{
				return _oskilleffectRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize6 != value && _oskilleffectRectTransform6 != null)
			{
				_oskilleffectRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize7
	{
		get
		{
			if (_oskilleffectRectTransform7 != null)
			{
				return _oskilleffectRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize7 != value && _oskilleffectRectTransform7 != null)
			{
				_oskilleffectRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize8
	{
		get
		{
			if (_oskilleffectRectTransform8 != null)
			{
				return _oskilleffectRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize8 != value && _oskilleffectRectTransform8 != null)
			{
				_oskilleffectRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize9
	{
		get
		{
			if (_oskilleffectRectTransform9 != null)
			{
				return _oskilleffectRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize9 != value && _oskilleffectRectTransform9 != null)
			{
				_oskilleffectRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize10
	{
		get
		{
			if (_oskilleffectRectTransform10 != null)
			{
				return _oskilleffectRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize10 != value && _oskilleffectRectTransform10 != null)
			{
				_oskilleffectRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize11
	{
		get
		{
			if (_oskilleffectRectTransform11 != null)
			{
				return _oskilleffectRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize11 != value && _oskilleffectRectTransform11 != null)
			{
				_oskilleffectRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize12
	{
		get
		{
			if (_oskilleffectRectTransform12 != null)
			{
				return _oskilleffectRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize12 != value && _oskilleffectRectTransform12 != null)
			{
				_oskilleffectRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skilleffectSize13
	{
		get
		{
			if (_oskilleffectRectTransform13 != null)
			{
				return _oskilleffectRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skilleffectSize13 != value && _oskilleffectRectTransform13 != null)
			{
				_oskilleffectRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skilleffectSprite1
	{
		get
		{
			if (_oskilleffectImage1 != null)
			{
				return _oskilleffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite1 != value && _oskilleffectImage1 != null)
			{
				_oskilleffectImage1.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite2
	{
		get
		{
			if (_oskilleffectImage2 != null)
			{
				return _oskilleffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite2 != value && _oskilleffectImage2 != null)
			{
				_oskilleffectImage2.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite3
	{
		get
		{
			if (_oskilleffectImage3 != null)
			{
				return _oskilleffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite3 != value && _oskilleffectImage3 != null)
			{
				_oskilleffectImage3.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite4
	{
		get
		{
			if (_oskilleffectImage4 != null)
			{
				return _oskilleffectImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite4 != value && _oskilleffectImage4 != null)
			{
				_oskilleffectImage4.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite5
	{
		get
		{
			if (_oskilleffectImage5 != null)
			{
				return _oskilleffectImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite5 != value && _oskilleffectImage5 != null)
			{
				_oskilleffectImage5.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite6
	{
		get
		{
			if (_oskilleffectImage6 != null)
			{
				return _oskilleffectImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite6 != value && _oskilleffectImage6 != null)
			{
				_oskilleffectImage6.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite7
	{
		get
		{
			if (_oskilleffectImage7 != null)
			{
				return _oskilleffectImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite7 != value && _oskilleffectImage7 != null)
			{
				_oskilleffectImage7.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite8
	{
		get
		{
			if (_oskilleffectImage8 != null)
			{
				return _oskilleffectImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite8 != value && _oskilleffectImage8 != null)
			{
				_oskilleffectImage8.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite9
	{
		get
		{
			if (_oskilleffectImage9 != null)
			{
				return _oskilleffectImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite9 != value && _oskilleffectImage9 != null)
			{
				_oskilleffectImage9.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite10
	{
		get
		{
			if (_oskilleffectImage10 != null)
			{
				return _oskilleffectImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite10 != value && _oskilleffectImage10 != null)
			{
				_oskilleffectImage10.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite11
	{
		get
		{
			if (_oskilleffectImage11 != null)
			{
				return _oskilleffectImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite11 != value && _oskilleffectImage11 != null)
			{
				_oskilleffectImage11.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite12
	{
		get
		{
			if (_oskilleffectImage12 != null)
			{
				return _oskilleffectImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite12 != value && _oskilleffectImage12 != null)
			{
				_oskilleffectImage12.sprite = value;
			}
		}
	}

	public Sprite skilleffectSprite13
	{
		get
		{
			if (_oskilleffectImage13 != null)
			{
				return _oskilleffectImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skilleffectSprite13 != value && _oskilleffectImage13 != null)
			{
				_oskilleffectImage13.sprite = value;
			}
		}
	}

	public bool skillBoundImageShow1
	{
		get
		{
			if (_oskillBoundImage1 != null)
			{
				return _oskillBoundImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow1 != value && _oskillBoundImage1 != null)
			{
				_oskillBoundImage1.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow2
	{
		get
		{
			if (_oskillBoundImage2 != null)
			{
				return _oskillBoundImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow2 != value && _oskillBoundImage2 != null)
			{
				_oskillBoundImage2.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow3
	{
		get
		{
			if (_oskillBoundImage3 != null)
			{
				return _oskillBoundImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow3 != value && _oskillBoundImage3 != null)
			{
				_oskillBoundImage3.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow4
	{
		get
		{
			if (_oskillBoundImage4 != null)
			{
				return _oskillBoundImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow4 != value && _oskillBoundImage4 != null)
			{
				_oskillBoundImage4.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow5
	{
		get
		{
			if (_oskillBoundImage5 != null)
			{
				return _oskillBoundImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow5 != value && _oskillBoundImage5 != null)
			{
				_oskillBoundImage5.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow6
	{
		get
		{
			if (_oskillBoundImage6 != null)
			{
				return _oskillBoundImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow6 != value && _oskillBoundImage6 != null)
			{
				_oskillBoundImage6.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow7
	{
		get
		{
			if (_oskillBoundImage7 != null)
			{
				return _oskillBoundImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow7 != value && _oskillBoundImage7 != null)
			{
				_oskillBoundImage7.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow8
	{
		get
		{
			if (_oskillBoundImage8 != null)
			{
				return _oskillBoundImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow8 != value && _oskillBoundImage8 != null)
			{
				_oskillBoundImage8.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow9
	{
		get
		{
			if (_oskillBoundImage9 != null)
			{
				return _oskillBoundImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow9 != value && _oskillBoundImage9 != null)
			{
				_oskillBoundImage9.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow10
	{
		get
		{
			if (_oskillBoundImage10 != null)
			{
				return _oskillBoundImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow10 != value && _oskillBoundImage10 != null)
			{
				_oskillBoundImage10.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow11
	{
		get
		{
			if (_oskillBoundImage11 != null)
			{
				return _oskillBoundImage11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow11 != value && _oskillBoundImage11 != null)
			{
				_oskillBoundImage11.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow12
	{
		get
		{
			if (_oskillBoundImage12 != null)
			{
				return _oskillBoundImage12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow12 != value && _oskillBoundImage12 != null)
			{
				_oskillBoundImage12.SetObjectActive(value);
			}
		}
	}

	public bool skillBoundImageShow13
	{
		get
		{
			if (_oskillBoundImage13 != null)
			{
				return _oskillBoundImage13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBoundImageShow13 != value && _oskillBoundImage13 != null)
			{
				_oskillBoundImage13.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition1
	{
		get
		{
			if (_oskillBoundImageRectTransform1 != null)
			{
				return _oskillBoundImageRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition1 != value && _oskillBoundImageRectTransform1 != null)
			{
				_oskillBoundImageRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition2
	{
		get
		{
			if (_oskillBoundImageRectTransform2 != null)
			{
				return _oskillBoundImageRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition2 != value && _oskillBoundImageRectTransform2 != null)
			{
				_oskillBoundImageRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition3
	{
		get
		{
			if (_oskillBoundImageRectTransform3 != null)
			{
				return _oskillBoundImageRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition3 != value && _oskillBoundImageRectTransform3 != null)
			{
				_oskillBoundImageRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition4
	{
		get
		{
			if (_oskillBoundImageRectTransform4 != null)
			{
				return _oskillBoundImageRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition4 != value && _oskillBoundImageRectTransform4 != null)
			{
				_oskillBoundImageRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition5
	{
		get
		{
			if (_oskillBoundImageRectTransform5 != null)
			{
				return _oskillBoundImageRectTransform5.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition5 != value && _oskillBoundImageRectTransform5 != null)
			{
				_oskillBoundImageRectTransform5.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition6
	{
		get
		{
			if (_oskillBoundImageRectTransform6 != null)
			{
				return _oskillBoundImageRectTransform6.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition6 != value && _oskillBoundImageRectTransform6 != null)
			{
				_oskillBoundImageRectTransform6.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition7
	{
		get
		{
			if (_oskillBoundImageRectTransform7 != null)
			{
				return _oskillBoundImageRectTransform7.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition7 != value && _oskillBoundImageRectTransform7 != null)
			{
				_oskillBoundImageRectTransform7.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition8
	{
		get
		{
			if (_oskillBoundImageRectTransform8 != null)
			{
				return _oskillBoundImageRectTransform8.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition8 != value && _oskillBoundImageRectTransform8 != null)
			{
				_oskillBoundImageRectTransform8.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition9
	{
		get
		{
			if (_oskillBoundImageRectTransform9 != null)
			{
				return _oskillBoundImageRectTransform9.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition9 != value && _oskillBoundImageRectTransform9 != null)
			{
				_oskillBoundImageRectTransform9.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition10
	{
		get
		{
			if (_oskillBoundImageRectTransform10 != null)
			{
				return _oskillBoundImageRectTransform10.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition10 != value && _oskillBoundImageRectTransform10 != null)
			{
				_oskillBoundImageRectTransform10.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition11
	{
		get
		{
			if (_oskillBoundImageRectTransform11 != null)
			{
				return _oskillBoundImageRectTransform11.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition11 != value && _oskillBoundImageRectTransform11 != null)
			{
				_oskillBoundImageRectTransform11.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition12
	{
		get
		{
			if (_oskillBoundImageRectTransform12 != null)
			{
				return _oskillBoundImageRectTransform12.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition12 != value && _oskillBoundImageRectTransform12 != null)
			{
				_oskillBoundImageRectTransform12.anchoredPosition = value;
			}
		}
	}

	public Vector2 skillBoundImageAnchoredposition13
	{
		get
		{
			if (_oskillBoundImageRectTransform13 != null)
			{
				return _oskillBoundImageRectTransform13.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillBoundImageAnchoredposition13 != value && _oskillBoundImageRectTransform13 != null)
			{
				_oskillBoundImageRectTransform13.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillBoundImageSize1
	{
		get
		{
			if (_oskillBoundImageRectTransform1 != null)
			{
				return _oskillBoundImageRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize1 != value && _oskillBoundImageRectTransform1 != null)
			{
				_oskillBoundImageRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize2
	{
		get
		{
			if (_oskillBoundImageRectTransform2 != null)
			{
				return _oskillBoundImageRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize2 != value && _oskillBoundImageRectTransform2 != null)
			{
				_oskillBoundImageRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize3
	{
		get
		{
			if (_oskillBoundImageRectTransform3 != null)
			{
				return _oskillBoundImageRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize3 != value && _oskillBoundImageRectTransform3 != null)
			{
				_oskillBoundImageRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize4
	{
		get
		{
			if (_oskillBoundImageRectTransform4 != null)
			{
				return _oskillBoundImageRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize4 != value && _oskillBoundImageRectTransform4 != null)
			{
				_oskillBoundImageRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize5
	{
		get
		{
			if (_oskillBoundImageRectTransform5 != null)
			{
				return _oskillBoundImageRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize5 != value && _oskillBoundImageRectTransform5 != null)
			{
				_oskillBoundImageRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize6
	{
		get
		{
			if (_oskillBoundImageRectTransform6 != null)
			{
				return _oskillBoundImageRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize6 != value && _oskillBoundImageRectTransform6 != null)
			{
				_oskillBoundImageRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize7
	{
		get
		{
			if (_oskillBoundImageRectTransform7 != null)
			{
				return _oskillBoundImageRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize7 != value && _oskillBoundImageRectTransform7 != null)
			{
				_oskillBoundImageRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize8
	{
		get
		{
			if (_oskillBoundImageRectTransform8 != null)
			{
				return _oskillBoundImageRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize8 != value && _oskillBoundImageRectTransform8 != null)
			{
				_oskillBoundImageRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize9
	{
		get
		{
			if (_oskillBoundImageRectTransform9 != null)
			{
				return _oskillBoundImageRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize9 != value && _oskillBoundImageRectTransform9 != null)
			{
				_oskillBoundImageRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize10
	{
		get
		{
			if (_oskillBoundImageRectTransform10 != null)
			{
				return _oskillBoundImageRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize10 != value && _oskillBoundImageRectTransform10 != null)
			{
				_oskillBoundImageRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize11
	{
		get
		{
			if (_oskillBoundImageRectTransform11 != null)
			{
				return _oskillBoundImageRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize11 != value && _oskillBoundImageRectTransform11 != null)
			{
				_oskillBoundImageRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize12
	{
		get
		{
			if (_oskillBoundImageRectTransform12 != null)
			{
				return _oskillBoundImageRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize12 != value && _oskillBoundImageRectTransform12 != null)
			{
				_oskillBoundImageRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 skillBoundImageSize13
	{
		get
		{
			if (_oskillBoundImageRectTransform13 != null)
			{
				return _oskillBoundImageRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillBoundImageSize13 != value && _oskillBoundImageRectTransform13 != null)
			{
				_oskillBoundImageRectTransform13.sizeDelta = value;
			}
		}
	}

	public Sprite skillBoundImageSprite1
	{
		get
		{
			if (_oskillBoundImageImage1 != null)
			{
				return _oskillBoundImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite1 != value && _oskillBoundImageImage1 != null)
			{
				_oskillBoundImageImage1.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite2
	{
		get
		{
			if (_oskillBoundImageImage2 != null)
			{
				return _oskillBoundImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite2 != value && _oskillBoundImageImage2 != null)
			{
				_oskillBoundImageImage2.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite3
	{
		get
		{
			if (_oskillBoundImageImage3 != null)
			{
				return _oskillBoundImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite3 != value && _oskillBoundImageImage3 != null)
			{
				_oskillBoundImageImage3.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite4
	{
		get
		{
			if (_oskillBoundImageImage4 != null)
			{
				return _oskillBoundImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite4 != value && _oskillBoundImageImage4 != null)
			{
				_oskillBoundImageImage4.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite5
	{
		get
		{
			if (_oskillBoundImageImage5 != null)
			{
				return _oskillBoundImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite5 != value && _oskillBoundImageImage5 != null)
			{
				_oskillBoundImageImage5.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite6
	{
		get
		{
			if (_oskillBoundImageImage6 != null)
			{
				return _oskillBoundImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite6 != value && _oskillBoundImageImage6 != null)
			{
				_oskillBoundImageImage6.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite7
	{
		get
		{
			if (_oskillBoundImageImage7 != null)
			{
				return _oskillBoundImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite7 != value && _oskillBoundImageImage7 != null)
			{
				_oskillBoundImageImage7.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite8
	{
		get
		{
			if (_oskillBoundImageImage8 != null)
			{
				return _oskillBoundImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite8 != value && _oskillBoundImageImage8 != null)
			{
				_oskillBoundImageImage8.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite9
	{
		get
		{
			if (_oskillBoundImageImage9 != null)
			{
				return _oskillBoundImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite9 != value && _oskillBoundImageImage9 != null)
			{
				_oskillBoundImageImage9.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite10
	{
		get
		{
			if (_oskillBoundImageImage10 != null)
			{
				return _oskillBoundImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite10 != value && _oskillBoundImageImage10 != null)
			{
				_oskillBoundImageImage10.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite11
	{
		get
		{
			if (_oskillBoundImageImage11 != null)
			{
				return _oskillBoundImageImage11.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite11 != value && _oskillBoundImageImage11 != null)
			{
				_oskillBoundImageImage11.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite12
	{
		get
		{
			if (_oskillBoundImageImage12 != null)
			{
				return _oskillBoundImageImage12.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite12 != value && _oskillBoundImageImage12 != null)
			{
				_oskillBoundImageImage12.sprite = value;
			}
		}
	}

	public Sprite skillBoundImageSprite13
	{
		get
		{
			if (_oskillBoundImageImage13 != null)
			{
				return _oskillBoundImageImage13.sprite;
			}
			return null;
		}
		set
		{
			if (skillBoundImageSprite13 != value && _oskillBoundImageImage13 != null)
			{
				_oskillBoundImageImage13.sprite = value;
			}
		}
	}

	public Color skillBoundImageColor1
	{
		get
		{
			if (_oskillBoundImageImage1 != null)
			{
				return _oskillBoundImageImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor1 != value && _oskillBoundImageImage1 != null)
			{
				_oskillBoundImageImage1.color = value;
			}
		}
	}

	public Color skillBoundImageColor2
	{
		get
		{
			if (_oskillBoundImageImage2 != null)
			{
				return _oskillBoundImageImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor2 != value && _oskillBoundImageImage2 != null)
			{
				_oskillBoundImageImage2.color = value;
			}
		}
	}

	public Color skillBoundImageColor3
	{
		get
		{
			if (_oskillBoundImageImage3 != null)
			{
				return _oskillBoundImageImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor3 != value && _oskillBoundImageImage3 != null)
			{
				_oskillBoundImageImage3.color = value;
			}
		}
	}

	public Color skillBoundImageColor4
	{
		get
		{
			if (_oskillBoundImageImage4 != null)
			{
				return _oskillBoundImageImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor4 != value && _oskillBoundImageImage4 != null)
			{
				_oskillBoundImageImage4.color = value;
			}
		}
	}

	public Color skillBoundImageColor5
	{
		get
		{
			if (_oskillBoundImageImage5 != null)
			{
				return _oskillBoundImageImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor5 != value && _oskillBoundImageImage5 != null)
			{
				_oskillBoundImageImage5.color = value;
			}
		}
	}

	public Color skillBoundImageColor6
	{
		get
		{
			if (_oskillBoundImageImage6 != null)
			{
				return _oskillBoundImageImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor6 != value && _oskillBoundImageImage6 != null)
			{
				_oskillBoundImageImage6.color = value;
			}
		}
	}

	public Color skillBoundImageColor7
	{
		get
		{
			if (_oskillBoundImageImage7 != null)
			{
				return _oskillBoundImageImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor7 != value && _oskillBoundImageImage7 != null)
			{
				_oskillBoundImageImage7.color = value;
			}
		}
	}

	public Color skillBoundImageColor8
	{
		get
		{
			if (_oskillBoundImageImage8 != null)
			{
				return _oskillBoundImageImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor8 != value && _oskillBoundImageImage8 != null)
			{
				_oskillBoundImageImage8.color = value;
			}
		}
	}

	public Color skillBoundImageColor9
	{
		get
		{
			if (_oskillBoundImageImage9 != null)
			{
				return _oskillBoundImageImage9.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor9 != value && _oskillBoundImageImage9 != null)
			{
				_oskillBoundImageImage9.color = value;
			}
		}
	}

	public Color skillBoundImageColor10
	{
		get
		{
			if (_oskillBoundImageImage10 != null)
			{
				return _oskillBoundImageImage10.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor10 != value && _oskillBoundImageImage10 != null)
			{
				_oskillBoundImageImage10.color = value;
			}
		}
	}

	public Color skillBoundImageColor11
	{
		get
		{
			if (_oskillBoundImageImage11 != null)
			{
				return _oskillBoundImageImage11.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor11 != value && _oskillBoundImageImage11 != null)
			{
				_oskillBoundImageImage11.color = value;
			}
		}
	}

	public Color skillBoundImageColor12
	{
		get
		{
			if (_oskillBoundImageImage12 != null)
			{
				return _oskillBoundImageImage12.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor12 != value && _oskillBoundImageImage12 != null)
			{
				_oskillBoundImageImage12.color = value;
			}
		}
	}

	public Color skillBoundImageColor13
	{
		get
		{
			if (_oskillBoundImageImage13 != null)
			{
				return _oskillBoundImageImage13.color;
			}
			return Color.white;
		}
		set
		{
			if (skillBoundImageColor13 != value && _oskillBoundImageImage13 != null)
			{
				_oskillBoundImageImage13.color = value;
			}
		}
	}

	public bool skilllvShow1
	{
		get
		{
			if (_oskilllv1 != null)
			{
				return _oskilllv1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow1 != value && _oskilllv1 != null)
			{
				_oskilllv1.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow2
	{
		get
		{
			if (_oskilllv2 != null)
			{
				return _oskilllv2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow2 != value && _oskilllv2 != null)
			{
				_oskilllv2.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow3
	{
		get
		{
			if (_oskilllv3 != null)
			{
				return _oskilllv3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow3 != value && _oskilllv3 != null)
			{
				_oskilllv3.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow4
	{
		get
		{
			if (_oskilllv4 != null)
			{
				return _oskilllv4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow4 != value && _oskilllv4 != null)
			{
				_oskilllv4.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow5
	{
		get
		{
			if (_oskilllv5 != null)
			{
				return _oskilllv5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow5 != value && _oskilllv5 != null)
			{
				_oskilllv5.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow6
	{
		get
		{
			if (_oskilllv6 != null)
			{
				return _oskilllv6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow6 != value && _oskilllv6 != null)
			{
				_oskilllv6.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow7
	{
		get
		{
			if (_oskilllv7 != null)
			{
				return _oskilllv7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow7 != value && _oskilllv7 != null)
			{
				_oskilllv7.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow8
	{
		get
		{
			if (_oskilllv8 != null)
			{
				return _oskilllv8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow8 != value && _oskilllv8 != null)
			{
				_oskilllv8.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow9
	{
		get
		{
			if (_oskilllv9 != null)
			{
				return _oskilllv9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow9 != value && _oskilllv9 != null)
			{
				_oskilllv9.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow10
	{
		get
		{
			if (_oskilllv10 != null)
			{
				return _oskilllv10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow10 != value && _oskilllv10 != null)
			{
				_oskilllv10.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow11
	{
		get
		{
			if (_oskilllv11 != null)
			{
				return _oskilllv11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow11 != value && _oskilllv11 != null)
			{
				_oskilllv11.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow12
	{
		get
		{
			if (_oskilllv12 != null)
			{
				return _oskilllv12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow12 != value && _oskilllv12 != null)
			{
				_oskilllv12.SetObjectActive(value);
			}
		}
	}

	public bool skilllvShow13
	{
		get
		{
			if (_oskilllv13 != null)
			{
				return _oskilllv13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilllvShow13 != value && _oskilllv13 != null)
			{
				_oskilllv13.SetObjectActive(value);
			}
		}
	}

	public string skilllvString1
	{
		get
		{
			if (_oskilllvText1 != null)
			{
				return _oskilllvText1.text;
			}
			return null;
		}
		set
		{
			if (skilllvString1 != value && _oskilllvText1 != null)
			{
				_oskilllvText1.text = value;
			}
		}
	}

	public string skilllvString2
	{
		get
		{
			if (_oskilllvText2 != null)
			{
				return _oskilllvText2.text;
			}
			return null;
		}
		set
		{
			if (skilllvString2 != value && _oskilllvText2 != null)
			{
				_oskilllvText2.text = value;
			}
		}
	}

	public string skilllvString3
	{
		get
		{
			if (_oskilllvText3 != null)
			{
				return _oskilllvText3.text;
			}
			return null;
		}
		set
		{
			if (skilllvString3 != value && _oskilllvText3 != null)
			{
				_oskilllvText3.text = value;
			}
		}
	}

	public string skilllvString4
	{
		get
		{
			if (_oskilllvText4 != null)
			{
				return _oskilllvText4.text;
			}
			return null;
		}
		set
		{
			if (skilllvString4 != value && _oskilllvText4 != null)
			{
				_oskilllvText4.text = value;
			}
		}
	}

	public string skilllvString5
	{
		get
		{
			if (_oskilllvText5 != null)
			{
				return _oskilllvText5.text;
			}
			return null;
		}
		set
		{
			if (skilllvString5 != value && _oskilllvText5 != null)
			{
				_oskilllvText5.text = value;
			}
		}
	}

	public string skilllvString6
	{
		get
		{
			if (_oskilllvText6 != null)
			{
				return _oskilllvText6.text;
			}
			return null;
		}
		set
		{
			if (skilllvString6 != value && _oskilllvText6 != null)
			{
				_oskilllvText6.text = value;
			}
		}
	}

	public string skilllvString7
	{
		get
		{
			if (_oskilllvText7 != null)
			{
				return _oskilllvText7.text;
			}
			return null;
		}
		set
		{
			if (skilllvString7 != value && _oskilllvText7 != null)
			{
				_oskilllvText7.text = value;
			}
		}
	}

	public string skilllvString8
	{
		get
		{
			if (_oskilllvText8 != null)
			{
				return _oskilllvText8.text;
			}
			return null;
		}
		set
		{
			if (skilllvString8 != value && _oskilllvText8 != null)
			{
				_oskilllvText8.text = value;
			}
		}
	}

	public string skilllvString9
	{
		get
		{
			if (_oskilllvText9 != null)
			{
				return _oskilllvText9.text;
			}
			return null;
		}
		set
		{
			if (skilllvString9 != value && _oskilllvText9 != null)
			{
				_oskilllvText9.text = value;
			}
		}
	}

	public string skilllvString10
	{
		get
		{
			if (_oskilllvText10 != null)
			{
				return _oskilllvText10.text;
			}
			return null;
		}
		set
		{
			if (skilllvString10 != value && _oskilllvText10 != null)
			{
				_oskilllvText10.text = value;
			}
		}
	}

	public string skilllvString11
	{
		get
		{
			if (_oskilllvText11 != null)
			{
				return _oskilllvText11.text;
			}
			return null;
		}
		set
		{
			if (skilllvString11 != value && _oskilllvText11 != null)
			{
				_oskilllvText11.text = value;
			}
		}
	}

	public string skilllvString12
	{
		get
		{
			if (_oskilllvText12 != null)
			{
				return _oskilllvText12.text;
			}
			return null;
		}
		set
		{
			if (skilllvString12 != value && _oskilllvText12 != null)
			{
				_oskilllvText12.text = value;
			}
		}
	}

	public string skilllvString13
	{
		get
		{
			if (_oskilllvText13 != null)
			{
				return _oskilllvText13.text;
			}
			return null;
		}
		set
		{
			if (skilllvString13 != value && _oskilllvText13 != null)
			{
				_oskilllvText13.text = value;
			}
		}
	}

	public Color skilllvTextcolor1
	{
		get
		{
			if (_oskilllvText1 != null)
			{
				return _oskilllvText1.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor1 != value && _oskilllvText1 != null)
			{
				_oskilllvText1.color = value;
			}
		}
	}

	public Color skilllvTextcolor2
	{
		get
		{
			if (_oskilllvText2 != null)
			{
				return _oskilllvText2.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor2 != value && _oskilllvText2 != null)
			{
				_oskilllvText2.color = value;
			}
		}
	}

	public Color skilllvTextcolor3
	{
		get
		{
			if (_oskilllvText3 != null)
			{
				return _oskilllvText3.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor3 != value && _oskilllvText3 != null)
			{
				_oskilllvText3.color = value;
			}
		}
	}

	public Color skilllvTextcolor4
	{
		get
		{
			if (_oskilllvText4 != null)
			{
				return _oskilllvText4.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor4 != value && _oskilllvText4 != null)
			{
				_oskilllvText4.color = value;
			}
		}
	}

	public Color skilllvTextcolor5
	{
		get
		{
			if (_oskilllvText5 != null)
			{
				return _oskilllvText5.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor5 != value && _oskilllvText5 != null)
			{
				_oskilllvText5.color = value;
			}
		}
	}

	public Color skilllvTextcolor6
	{
		get
		{
			if (_oskilllvText6 != null)
			{
				return _oskilllvText6.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor6 != value && _oskilllvText6 != null)
			{
				_oskilllvText6.color = value;
			}
		}
	}

	public Color skilllvTextcolor7
	{
		get
		{
			if (_oskilllvText7 != null)
			{
				return _oskilllvText7.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor7 != value && _oskilllvText7 != null)
			{
				_oskilllvText7.color = value;
			}
		}
	}

	public Color skilllvTextcolor8
	{
		get
		{
			if (_oskilllvText8 != null)
			{
				return _oskilllvText8.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor8 != value && _oskilllvText8 != null)
			{
				_oskilllvText8.color = value;
			}
		}
	}

	public Color skilllvTextcolor9
	{
		get
		{
			if (_oskilllvText9 != null)
			{
				return _oskilllvText9.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor9 != value && _oskilllvText9 != null)
			{
				_oskilllvText9.color = value;
			}
		}
	}

	public Color skilllvTextcolor10
	{
		get
		{
			if (_oskilllvText10 != null)
			{
				return _oskilllvText10.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor10 != value && _oskilllvText10 != null)
			{
				_oskilllvText10.color = value;
			}
		}
	}

	public Color skilllvTextcolor11
	{
		get
		{
			if (_oskilllvText11 != null)
			{
				return _oskilllvText11.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor11 != value && _oskilllvText11 != null)
			{
				_oskilllvText11.color = value;
			}
		}
	}

	public Color skilllvTextcolor12
	{
		get
		{
			if (_oskilllvText12 != null)
			{
				return _oskilllvText12.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor12 != value && _oskilllvText12 != null)
			{
				_oskilllvText12.color = value;
			}
		}
	}

	public Color skilllvTextcolor13
	{
		get
		{
			if (_oskilllvText13 != null)
			{
				return _oskilllvText13.color;
			}
			return Color.white;
		}
		set
		{
			if (skilllvTextcolor13 != value && _oskilllvText13 != null)
			{
				_oskilllvText13.color = value;
			}
		}
	}

	public GameObject skillTipBackImageObj => _oskillTipBackImage;

	public bool skillTipBackImageShow
	{
		get
		{
			if (_oskillTipBackImage != null)
			{
				return _oskillTipBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillTipBackImageShow != value && _oskillTipBackImage != null)
			{
				_oskillTipBackImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillTipBackImageAnchoredposition
	{
		get
		{
			if (_oskillTipBackImageRectTransform != null)
			{
				return _oskillTipBackImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillTipBackImageAnchoredposition != value && _oskillTipBackImageRectTransform != null)
			{
				_oskillTipBackImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillTipBackImagePosition
	{
		get
		{
			if (_oskillTipBackImageRectTransform != null)
			{
				return _oskillTipBackImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillTipBackImagePosition != value && _oskillTipBackImageRectTransform != null)
			{
				_oskillTipBackImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 skillTipBackImageSize
	{
		get
		{
			if (_oskillTipBackImageRectTransform != null)
			{
				return _oskillTipBackImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillTipBackImageSize != value && _oskillTipBackImageRectTransform != null)
			{
				_oskillTipBackImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite skillTipBackImageSprite
	{
		get
		{
			if (_oskillTipBackImageImage != null)
			{
				return _oskillTipBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (skillTipBackImageSprite != value && _oskillTipBackImageImage != null)
			{
				_oskillTipBackImageImage.sprite = value;
			}
		}
	}

	public bool skillnolvImageShow
	{
		get
		{
			if (_oskillnolvImage != null)
			{
				return _oskillnolvImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillnolvImageShow != value && _oskillnolvImage != null)
			{
				_oskillnolvImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 skillnolvImageAnchoredposition
	{
		get
		{
			if (_oskillnolvImageRectTransform != null)
			{
				return _oskillnolvImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (skillnolvImageAnchoredposition != value && _oskillnolvImageRectTransform != null)
			{
				_oskillnolvImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 skillnolvImageSize
	{
		get
		{
			if (_oskillnolvImageRectTransform != null)
			{
				return _oskillnolvImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (skillnolvImageSize != value && _oskillnolvImageRectTransform != null)
			{
				_oskillnolvImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite skillnolvImageSprite
	{
		get
		{
			if (_oskillnolvImageImage != null)
			{
				return _oskillnolvImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (skillnolvImageSprite != value && _oskillnolvImageImage != null)
			{
				_oskillnolvImageImage.sprite = value;
			}
		}
	}

	public bool noMoneyImageShow
	{
		get
		{
			if (_onoMoneyImage != null)
			{
				return _onoMoneyImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (noMoneyImageShow != value && _onoMoneyImage != null)
			{
				_onoMoneyImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 noMoneyImageAnchoredposition
	{
		get
		{
			if (_onoMoneyImageRectTransform != null)
			{
				return _onoMoneyImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (noMoneyImageAnchoredposition != value && _onoMoneyImageRectTransform != null)
			{
				_onoMoneyImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 noMoneyImageSize
	{
		get
		{
			if (_onoMoneyImageRectTransform != null)
			{
				return _onoMoneyImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (noMoneyImageSize != value && _onoMoneyImageRectTransform != null)
			{
				_onoMoneyImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite noMoneyImageSprite
	{
		get
		{
			if (_onoMoneyImageImage != null)
			{
				return _onoMoneyImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (noMoneyImageSprite != value && _onoMoneyImageImage != null)
			{
				_onoMoneyImageImage.sprite = value;
			}
		}
	}

	public bool noFrontSkillImageShow
	{
		get
		{
			if (_onoFrontSkillImage != null)
			{
				return _onoFrontSkillImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (noFrontSkillImageShow != value && _onoFrontSkillImage != null)
			{
				_onoFrontSkillImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 noFrontSkillImageAnchoredposition
	{
		get
		{
			if (_onoFrontSkillImageRectTransform != null)
			{
				return _onoFrontSkillImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (noFrontSkillImageAnchoredposition != value && _onoFrontSkillImageRectTransform != null)
			{
				_onoFrontSkillImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 noFrontSkillImageSize
	{
		get
		{
			if (_onoFrontSkillImageRectTransform != null)
			{
				return _onoFrontSkillImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (noFrontSkillImageSize != value && _onoFrontSkillImageRectTransform != null)
			{
				_onoFrontSkillImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite noFrontSkillImageSprite
	{
		get
		{
			if (_onoFrontSkillImageImage != null)
			{
				return _onoFrontSkillImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (noFrontSkillImageSprite != value && _onoFrontSkillImageImage != null)
			{
				_onoFrontSkillImageImage.sprite = value;
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
			case "pvetdskilltree":
				_opvetdskilltree = transform.gameObject;
				uiRef.Set("pvetdskilltree", _opvetdskilltree.transform);
				break;
			case "skillBackImage":
				_oskillBackImage = transform.gameObject;
				uiRef.Set("skillBackImage", _oskillBackImage.transform);
				_oskillBackImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBackImageImage", _oskillBackImageImage);
				break;
			case "weaponSkillImage":
				_oweaponSkillImage = transform.gameObject;
				uiRef.Set("weaponSkillImage", _oweaponSkillImage.transform);
				_oweaponSkillImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("weaponSkillImageRectTransform", _oweaponSkillImageRectTransform);
				_oweaponSkillImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("weaponSkillImageImage", _oweaponSkillImageImage);
				break;
			case "playerMoneytext":
				_oplayerMoneytext = transform.gameObject;
				uiRef.Set("playerMoneytext", _oplayerMoneytext.transform);
				_oplayerMoneytextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("playerMoneytextRectTransform", _oplayerMoneytextRectTransform);
				_oplayerMoneytextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("playerMoneytextText", _oplayerMoneytextText);
				break;
			case "playerLvtext":
				_oplayerLvtext = transform.gameObject;
				uiRef.Set("playerLvtext", _oplayerLvtext.transform);
				_oplayerLvtextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("playerLvtextRectTransform", _oplayerLvtextRectTransform);
				_oplayerLvtextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("playerLvtextText", _oplayerLvtextText);
				break;
			case "expProgressImage":
				_oexpProgressImage = transform.gameObject;
				uiRef.Set("expProgressImage", _oexpProgressImage.transform);
				_oexpProgressImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("expProgressImageImage", _oexpProgressImageImage);
				break;
			case "addDamagertext":
				_oaddDamagertext = transform.gameObject;
				uiRef.Set("addDamagertext", _oaddDamagertext.transform);
				_oaddDamagertextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("addDamagertextText", _oaddDamagertextText);
				break;
			case "playerGptext":
				_oplayerGptext = transform.gameObject;
				uiRef.Set("playerGptext", _oplayerGptext.transform);
				_oplayerGptextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("playerGptextText", _oplayerGptextText);
				break;
			case "skillImage1":
				_oskillImage1 = transform.gameObject;
				uiRef.Set("skillImage1", _oskillImage1.transform);
				_oskillImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform1", _oskillImageRectTransform1);
				_oskillImageImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage1", _oskillImageImage1);
				break;
			case "skillImage2":
				_oskillImage2 = transform.gameObject;
				uiRef.Set("skillImage2", _oskillImage2.transform);
				_oskillImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform2", _oskillImageRectTransform2);
				_oskillImageImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage2", _oskillImageImage2);
				break;
			case "skillImage3":
				_oskillImage3 = transform.gameObject;
				uiRef.Set("skillImage3", _oskillImage3.transform);
				_oskillImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform3", _oskillImageRectTransform3);
				_oskillImageImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage3", _oskillImageImage3);
				break;
			case "skillImage4":
				_oskillImage4 = transform.gameObject;
				uiRef.Set("skillImage4", _oskillImage4.transform);
				_oskillImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform4", _oskillImageRectTransform4);
				_oskillImageImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage4", _oskillImageImage4);
				break;
			case "skillImage5":
				_oskillImage5 = transform.gameObject;
				uiRef.Set("skillImage5", _oskillImage5.transform);
				_oskillImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform5", _oskillImageRectTransform5);
				_oskillImageImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage5", _oskillImageImage5);
				break;
			case "skillImage6":
				_oskillImage6 = transform.gameObject;
				uiRef.Set("skillImage6", _oskillImage6.transform);
				_oskillImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform6", _oskillImageRectTransform6);
				_oskillImageImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage6", _oskillImageImage6);
				break;
			case "skillImage7":
				_oskillImage7 = transform.gameObject;
				uiRef.Set("skillImage7", _oskillImage7.transform);
				_oskillImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform7", _oskillImageRectTransform7);
				_oskillImageImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage7", _oskillImageImage7);
				break;
			case "skillImage8":
				_oskillImage8 = transform.gameObject;
				uiRef.Set("skillImage8", _oskillImage8.transform);
				_oskillImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform8", _oskillImageRectTransform8);
				_oskillImageImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage8", _oskillImageImage8);
				break;
			case "skillImage9":
				_oskillImage9 = transform.gameObject;
				uiRef.Set("skillImage9", _oskillImage9.transform);
				_oskillImageRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform9", _oskillImageRectTransform9);
				_oskillImageImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage9", _oskillImageImage9);
				break;
			case "skillImage10":
				_oskillImage10 = transform.gameObject;
				uiRef.Set("skillImage10", _oskillImage10.transform);
				_oskillImageRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform10", _oskillImageRectTransform10);
				_oskillImageImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage10", _oskillImageImage10);
				break;
			case "skillImage11":
				_oskillImage11 = transform.gameObject;
				uiRef.Set("skillImage11", _oskillImage11.transform);
				_oskillImageRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform11", _oskillImageRectTransform11);
				_oskillImageImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage11", _oskillImageImage11);
				break;
			case "skillImage12":
				_oskillImage12 = transform.gameObject;
				uiRef.Set("skillImage12", _oskillImage12.transform);
				_oskillImageRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform12", _oskillImageRectTransform12);
				_oskillImageImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage12", _oskillImageImage12);
				break;
			case "skillImage13":
				_oskillImage13 = transform.gameObject;
				uiRef.Set("skillImage13", _oskillImage13.transform);
				_oskillImageRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillImageRectTransform13", _oskillImageRectTransform13);
				_oskillImageImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillImageImage13", _oskillImageImage13);
				break;
			case "skillbackimg1":
				_oskillbackimg1 = transform.gameObject;
				uiRef.Set("skillbackimg1", _oskillbackimg1.transform);
				_oskillbackimgRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform1", _oskillbackimgRectTransform1);
				_oskillbackimgImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage1", _oskillbackimgImage1);
				break;
			case "skillbackimg2":
				_oskillbackimg2 = transform.gameObject;
				uiRef.Set("skillbackimg2", _oskillbackimg2.transform);
				_oskillbackimgRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform2", _oskillbackimgRectTransform2);
				_oskillbackimgImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage2", _oskillbackimgImage2);
				break;
			case "skillbackimg3":
				_oskillbackimg3 = transform.gameObject;
				uiRef.Set("skillbackimg3", _oskillbackimg3.transform);
				_oskillbackimgRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform3", _oskillbackimgRectTransform3);
				_oskillbackimgImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage3", _oskillbackimgImage3);
				break;
			case "skillbackimg4":
				_oskillbackimg4 = transform.gameObject;
				uiRef.Set("skillbackimg4", _oskillbackimg4.transform);
				_oskillbackimgRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform4", _oskillbackimgRectTransform4);
				_oskillbackimgImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage4", _oskillbackimgImage4);
				break;
			case "skillbackimg5":
				_oskillbackimg5 = transform.gameObject;
				uiRef.Set("skillbackimg5", _oskillbackimg5.transform);
				_oskillbackimgRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform5", _oskillbackimgRectTransform5);
				_oskillbackimgImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage5", _oskillbackimgImage5);
				break;
			case "skillbackimg6":
				_oskillbackimg6 = transform.gameObject;
				uiRef.Set("skillbackimg6", _oskillbackimg6.transform);
				_oskillbackimgRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform6", _oskillbackimgRectTransform6);
				_oskillbackimgImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage6", _oskillbackimgImage6);
				break;
			case "skillbackimg7":
				_oskillbackimg7 = transform.gameObject;
				uiRef.Set("skillbackimg7", _oskillbackimg7.transform);
				_oskillbackimgRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform7", _oskillbackimgRectTransform7);
				_oskillbackimgImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage7", _oskillbackimgImage7);
				break;
			case "skillbackimg8":
				_oskillbackimg8 = transform.gameObject;
				uiRef.Set("skillbackimg8", _oskillbackimg8.transform);
				_oskillbackimgRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform8", _oskillbackimgRectTransform8);
				_oskillbackimgImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage8", _oskillbackimgImage8);
				break;
			case "skillbackimg9":
				_oskillbackimg9 = transform.gameObject;
				uiRef.Set("skillbackimg9", _oskillbackimg9.transform);
				_oskillbackimgRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform9", _oskillbackimgRectTransform9);
				_oskillbackimgImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage9", _oskillbackimgImage9);
				break;
			case "skillbackimg10":
				_oskillbackimg10 = transform.gameObject;
				uiRef.Set("skillbackimg10", _oskillbackimg10.transform);
				_oskillbackimgRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform10", _oskillbackimgRectTransform10);
				_oskillbackimgImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage10", _oskillbackimgImage10);
				break;
			case "skillbackimg11":
				_oskillbackimg11 = transform.gameObject;
				uiRef.Set("skillbackimg11", _oskillbackimg11.transform);
				_oskillbackimgRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform11", _oskillbackimgRectTransform11);
				_oskillbackimgImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage11", _oskillbackimgImage11);
				break;
			case "skillbackimg12":
				_oskillbackimg12 = transform.gameObject;
				uiRef.Set("skillbackimg12", _oskillbackimg12.transform);
				_oskillbackimgRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform12", _oskillbackimgRectTransform12);
				_oskillbackimgImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage12", _oskillbackimgImage12);
				break;
			case "skillbackimg13":
				_oskillbackimg13 = transform.gameObject;
				uiRef.Set("skillbackimg13", _oskillbackimg13.transform);
				_oskillbackimgRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillbackimgRectTransform13", _oskillbackimgRectTransform13);
				_oskillbackimgImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillbackimgImage13", _oskillbackimgImage13);
				break;
			case "skillmaxImg1":
				_oskillmaxImg1 = transform.gameObject;
				uiRef.Set("skillmaxImg1", _oskillmaxImg1.transform);
				_oskillmaxImgRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform1", _oskillmaxImgRectTransform1);
				_oskillmaxImgImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage1", _oskillmaxImgImage1);
				break;
			case "skillmaxImg2":
				_oskillmaxImg2 = transform.gameObject;
				uiRef.Set("skillmaxImg2", _oskillmaxImg2.transform);
				_oskillmaxImgRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform2", _oskillmaxImgRectTransform2);
				_oskillmaxImgImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage2", _oskillmaxImgImage2);
				break;
			case "skillmaxImg3":
				_oskillmaxImg3 = transform.gameObject;
				uiRef.Set("skillmaxImg3", _oskillmaxImg3.transform);
				_oskillmaxImgRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform3", _oskillmaxImgRectTransform3);
				_oskillmaxImgImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage3", _oskillmaxImgImage3);
				break;
			case "skillmaxImg4":
				_oskillmaxImg4 = transform.gameObject;
				uiRef.Set("skillmaxImg4", _oskillmaxImg4.transform);
				_oskillmaxImgRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform4", _oskillmaxImgRectTransform4);
				_oskillmaxImgImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage4", _oskillmaxImgImage4);
				break;
			case "skillmaxImg5":
				_oskillmaxImg5 = transform.gameObject;
				uiRef.Set("skillmaxImg5", _oskillmaxImg5.transform);
				_oskillmaxImgRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform5", _oskillmaxImgRectTransform5);
				_oskillmaxImgImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage5", _oskillmaxImgImage5);
				break;
			case "skillmaxImg6":
				_oskillmaxImg6 = transform.gameObject;
				uiRef.Set("skillmaxImg6", _oskillmaxImg6.transform);
				_oskillmaxImgRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform6", _oskillmaxImgRectTransform6);
				_oskillmaxImgImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage6", _oskillmaxImgImage6);
				break;
			case "skillmaxImg7":
				_oskillmaxImg7 = transform.gameObject;
				uiRef.Set("skillmaxImg7", _oskillmaxImg7.transform);
				_oskillmaxImgRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform7", _oskillmaxImgRectTransform7);
				_oskillmaxImgImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage7", _oskillmaxImgImage7);
				break;
			case "skillmaxImg8":
				_oskillmaxImg8 = transform.gameObject;
				uiRef.Set("skillmaxImg8", _oskillmaxImg8.transform);
				_oskillmaxImgRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform8", _oskillmaxImgRectTransform8);
				_oskillmaxImgImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage8", _oskillmaxImgImage8);
				break;
			case "skillmaxImg9":
				_oskillmaxImg9 = transform.gameObject;
				uiRef.Set("skillmaxImg9", _oskillmaxImg9.transform);
				_oskillmaxImgRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform9", _oskillmaxImgRectTransform9);
				_oskillmaxImgImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage9", _oskillmaxImgImage9);
				break;
			case "skillmaxImg10":
				_oskillmaxImg10 = transform.gameObject;
				uiRef.Set("skillmaxImg10", _oskillmaxImg10.transform);
				_oskillmaxImgRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform10", _oskillmaxImgRectTransform10);
				_oskillmaxImgImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage10", _oskillmaxImgImage10);
				break;
			case "skillmaxImg11":
				_oskillmaxImg11 = transform.gameObject;
				uiRef.Set("skillmaxImg11", _oskillmaxImg11.transform);
				_oskillmaxImgRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform11", _oskillmaxImgRectTransform11);
				_oskillmaxImgImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage11", _oskillmaxImgImage11);
				break;
			case "skillmaxImg12":
				_oskillmaxImg12 = transform.gameObject;
				uiRef.Set("skillmaxImg12", _oskillmaxImg12.transform);
				_oskillmaxImgRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform12", _oskillmaxImgRectTransform12);
				_oskillmaxImgImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage12", _oskillmaxImgImage12);
				break;
			case "skillmaxImg13":
				_oskillmaxImg13 = transform.gameObject;
				uiRef.Set("skillmaxImg13", _oskillmaxImg13.transform);
				_oskillmaxImgRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillmaxImgRectTransform13", _oskillmaxImgRectTransform13);
				_oskillmaxImgImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillmaxImgImage13", _oskillmaxImgImage13);
				break;
			case "skillimagestudio1":
				_oskillimagestudio1 = transform.gameObject;
				uiRef.Set("skillimagestudio1", _oskillimagestudio1.transform);
				_oskillimagestudioRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform1", _oskillimagestudioRectTransform1);
				_oskillimagestudioImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage1", _oskillimagestudioImage1);
				break;
			case "skillimagestudio2":
				_oskillimagestudio2 = transform.gameObject;
				uiRef.Set("skillimagestudio2", _oskillimagestudio2.transform);
				_oskillimagestudioRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform2", _oskillimagestudioRectTransform2);
				_oskillimagestudioImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage2", _oskillimagestudioImage2);
				break;
			case "skillimagestudio3":
				_oskillimagestudio3 = transform.gameObject;
				uiRef.Set("skillimagestudio3", _oskillimagestudio3.transform);
				_oskillimagestudioRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform3", _oskillimagestudioRectTransform3);
				_oskillimagestudioImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage3", _oskillimagestudioImage3);
				break;
			case "skillimagestudio4":
				_oskillimagestudio4 = transform.gameObject;
				uiRef.Set("skillimagestudio4", _oskillimagestudio4.transform);
				_oskillimagestudioRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform4", _oskillimagestudioRectTransform4);
				_oskillimagestudioImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage4", _oskillimagestudioImage4);
				break;
			case "skillimagestudio5":
				_oskillimagestudio5 = transform.gameObject;
				uiRef.Set("skillimagestudio5", _oskillimagestudio5.transform);
				_oskillimagestudioRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform5", _oskillimagestudioRectTransform5);
				_oskillimagestudioImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage5", _oskillimagestudioImage5);
				break;
			case "skillimagestudio6":
				_oskillimagestudio6 = transform.gameObject;
				uiRef.Set("skillimagestudio6", _oskillimagestudio6.transform);
				_oskillimagestudioRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform6", _oskillimagestudioRectTransform6);
				_oskillimagestudioImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage6", _oskillimagestudioImage6);
				break;
			case "skillimagestudio7":
				_oskillimagestudio7 = transform.gameObject;
				uiRef.Set("skillimagestudio7", _oskillimagestudio7.transform);
				_oskillimagestudioRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform7", _oskillimagestudioRectTransform7);
				_oskillimagestudioImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage7", _oskillimagestudioImage7);
				break;
			case "skillimagestudio8":
				_oskillimagestudio8 = transform.gameObject;
				uiRef.Set("skillimagestudio8", _oskillimagestudio8.transform);
				_oskillimagestudioRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform8", _oskillimagestudioRectTransform8);
				_oskillimagestudioImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage8", _oskillimagestudioImage8);
				break;
			case "skillimagestudio9":
				_oskillimagestudio9 = transform.gameObject;
				uiRef.Set("skillimagestudio9", _oskillimagestudio9.transform);
				_oskillimagestudioRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform9", _oskillimagestudioRectTransform9);
				_oskillimagestudioImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage9", _oskillimagestudioImage9);
				break;
			case "skillimagestudio10":
				_oskillimagestudio10 = transform.gameObject;
				uiRef.Set("skillimagestudio10", _oskillimagestudio10.transform);
				_oskillimagestudioRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform10", _oskillimagestudioRectTransform10);
				_oskillimagestudioImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage10", _oskillimagestudioImage10);
				break;
			case "skillimagestudio11":
				_oskillimagestudio11 = transform.gameObject;
				uiRef.Set("skillimagestudio11", _oskillimagestudio11.transform);
				_oskillimagestudioRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform11", _oskillimagestudioRectTransform11);
				_oskillimagestudioImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage11", _oskillimagestudioImage11);
				break;
			case "skillimagestudio12":
				_oskillimagestudio12 = transform.gameObject;
				uiRef.Set("skillimagestudio12", _oskillimagestudio12.transform);
				_oskillimagestudioRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform12", _oskillimagestudioRectTransform12);
				_oskillimagestudioImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage12", _oskillimagestudioImage12);
				break;
			case "skillimagestudio13":
				_oskillimagestudio13 = transform.gameObject;
				uiRef.Set("skillimagestudio13", _oskillimagestudio13.transform);
				_oskillimagestudioRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillimagestudioRectTransform13", _oskillimagestudioRectTransform13);
				_oskillimagestudioImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillimagestudioImage13", _oskillimagestudioImage13);
				break;
			case "skilleffect1":
				_oskilleffect1 = transform.gameObject;
				uiRef.Set("skilleffect1", _oskilleffect1.transform);
				_oskilleffectRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform1", _oskilleffectRectTransform1);
				_oskilleffectImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage1", _oskilleffectImage1);
				break;
			case "skilleffect2":
				_oskilleffect2 = transform.gameObject;
				uiRef.Set("skilleffect2", _oskilleffect2.transform);
				_oskilleffectRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform2", _oskilleffectRectTransform2);
				_oskilleffectImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage2", _oskilleffectImage2);
				break;
			case "skilleffect3":
				_oskilleffect3 = transform.gameObject;
				uiRef.Set("skilleffect3", _oskilleffect3.transform);
				_oskilleffectRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform3", _oskilleffectRectTransform3);
				_oskilleffectImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage3", _oskilleffectImage3);
				break;
			case "skilleffect4":
				_oskilleffect4 = transform.gameObject;
				uiRef.Set("skilleffect4", _oskilleffect4.transform);
				_oskilleffectRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform4", _oskilleffectRectTransform4);
				_oskilleffectImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage4", _oskilleffectImage4);
				break;
			case "skilleffect5":
				_oskilleffect5 = transform.gameObject;
				uiRef.Set("skilleffect5", _oskilleffect5.transform);
				_oskilleffectRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform5", _oskilleffectRectTransform5);
				_oskilleffectImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage5", _oskilleffectImage5);
				break;
			case "skilleffect6":
				_oskilleffect6 = transform.gameObject;
				uiRef.Set("skilleffect6", _oskilleffect6.transform);
				_oskilleffectRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform6", _oskilleffectRectTransform6);
				_oskilleffectImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage6", _oskilleffectImage6);
				break;
			case "skilleffect7":
				_oskilleffect7 = transform.gameObject;
				uiRef.Set("skilleffect7", _oskilleffect7.transform);
				_oskilleffectRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform7", _oskilleffectRectTransform7);
				_oskilleffectImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage7", _oskilleffectImage7);
				break;
			case "skilleffect8":
				_oskilleffect8 = transform.gameObject;
				uiRef.Set("skilleffect8", _oskilleffect8.transform);
				_oskilleffectRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform8", _oskilleffectRectTransform8);
				_oskilleffectImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage8", _oskilleffectImage8);
				break;
			case "skilleffect9":
				_oskilleffect9 = transform.gameObject;
				uiRef.Set("skilleffect9", _oskilleffect9.transform);
				_oskilleffectRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform9", _oskilleffectRectTransform9);
				_oskilleffectImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage9", _oskilleffectImage9);
				break;
			case "skilleffect10":
				_oskilleffect10 = transform.gameObject;
				uiRef.Set("skilleffect10", _oskilleffect10.transform);
				_oskilleffectRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform10", _oskilleffectRectTransform10);
				_oskilleffectImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage10", _oskilleffectImage10);
				break;
			case "skilleffect11":
				_oskilleffect11 = transform.gameObject;
				uiRef.Set("skilleffect11", _oskilleffect11.transform);
				_oskilleffectRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform11", _oskilleffectRectTransform11);
				_oskilleffectImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage11", _oskilleffectImage11);
				break;
			case "skilleffect12":
				_oskilleffect12 = transform.gameObject;
				uiRef.Set("skilleffect12", _oskilleffect12.transform);
				_oskilleffectRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform12", _oskilleffectRectTransform12);
				_oskilleffectImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage12", _oskilleffectImage12);
				break;
			case "skilleffect13":
				_oskilleffect13 = transform.gameObject;
				uiRef.Set("skilleffect13", _oskilleffect13.transform);
				_oskilleffectRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skilleffectRectTransform13", _oskilleffectRectTransform13);
				_oskilleffectImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skilleffectImage13", _oskilleffectImage13);
				break;
			case "skillBoundImage1":
				_oskillBoundImage1 = transform.gameObject;
				uiRef.Set("skillBoundImage1", _oskillBoundImage1.transform);
				_oskillBoundImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform1", _oskillBoundImageRectTransform1);
				_oskillBoundImageImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage1", _oskillBoundImageImage1);
				break;
			case "skillBoundImage2":
				_oskillBoundImage2 = transform.gameObject;
				uiRef.Set("skillBoundImage2", _oskillBoundImage2.transform);
				_oskillBoundImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform2", _oskillBoundImageRectTransform2);
				_oskillBoundImageImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage2", _oskillBoundImageImage2);
				break;
			case "skillBoundImage3":
				_oskillBoundImage3 = transform.gameObject;
				uiRef.Set("skillBoundImage3", _oskillBoundImage3.transform);
				_oskillBoundImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform3", _oskillBoundImageRectTransform3);
				_oskillBoundImageImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage3", _oskillBoundImageImage3);
				break;
			case "skillBoundImage4":
				_oskillBoundImage4 = transform.gameObject;
				uiRef.Set("skillBoundImage4", _oskillBoundImage4.transform);
				_oskillBoundImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform4", _oskillBoundImageRectTransform4);
				_oskillBoundImageImage4 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage4", _oskillBoundImageImage4);
				break;
			case "skillBoundImage5":
				_oskillBoundImage5 = transform.gameObject;
				uiRef.Set("skillBoundImage5", _oskillBoundImage5.transform);
				_oskillBoundImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform5", _oskillBoundImageRectTransform5);
				_oskillBoundImageImage5 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage5", _oskillBoundImageImage5);
				break;
			case "skillBoundImage6":
				_oskillBoundImage6 = transform.gameObject;
				uiRef.Set("skillBoundImage6", _oskillBoundImage6.transform);
				_oskillBoundImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform6", _oskillBoundImageRectTransform6);
				_oskillBoundImageImage6 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage6", _oskillBoundImageImage6);
				break;
			case "skillBoundImage7":
				_oskillBoundImage7 = transform.gameObject;
				uiRef.Set("skillBoundImage7", _oskillBoundImage7.transform);
				_oskillBoundImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform7", _oskillBoundImageRectTransform7);
				_oskillBoundImageImage7 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage7", _oskillBoundImageImage7);
				break;
			case "skillBoundImage8":
				_oskillBoundImage8 = transform.gameObject;
				uiRef.Set("skillBoundImage8", _oskillBoundImage8.transform);
				_oskillBoundImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform8", _oskillBoundImageRectTransform8);
				_oskillBoundImageImage8 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage8", _oskillBoundImageImage8);
				break;
			case "skillBoundImage9":
				_oskillBoundImage9 = transform.gameObject;
				uiRef.Set("skillBoundImage9", _oskillBoundImage9.transform);
				_oskillBoundImageRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform9", _oskillBoundImageRectTransform9);
				_oskillBoundImageImage9 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage9", _oskillBoundImageImage9);
				break;
			case "skillBoundImage10":
				_oskillBoundImage10 = transform.gameObject;
				uiRef.Set("skillBoundImage10", _oskillBoundImage10.transform);
				_oskillBoundImageRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform10", _oskillBoundImageRectTransform10);
				_oskillBoundImageImage10 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage10", _oskillBoundImageImage10);
				break;
			case "skillBoundImage11":
				_oskillBoundImage11 = transform.gameObject;
				uiRef.Set("skillBoundImage11", _oskillBoundImage11.transform);
				_oskillBoundImageRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform11", _oskillBoundImageRectTransform11);
				_oskillBoundImageImage11 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage11", _oskillBoundImageImage11);
				break;
			case "skillBoundImage12":
				_oskillBoundImage12 = transform.gameObject;
				uiRef.Set("skillBoundImage12", _oskillBoundImage12.transform);
				_oskillBoundImageRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform12", _oskillBoundImageRectTransform12);
				_oskillBoundImageImage12 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage12", _oskillBoundImageImage12);
				break;
			case "skillBoundImage13":
				_oskillBoundImage13 = transform.gameObject;
				uiRef.Set("skillBoundImage13", _oskillBoundImage13.transform);
				_oskillBoundImageRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillBoundImageRectTransform13", _oskillBoundImageRectTransform13);
				_oskillBoundImageImage13 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillBoundImageImage13", _oskillBoundImageImage13);
				break;
			case "skilllv1":
				_oskilllv1 = transform.gameObject;
				uiRef.Set("skilllv1", _oskilllv1.transform);
				_oskilllvText1 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText1", _oskilllvText1);
				break;
			case "skilllv2":
				_oskilllv2 = transform.gameObject;
				uiRef.Set("skilllv2", _oskilllv2.transform);
				_oskilllvText2 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText2", _oskilllvText2);
				break;
			case "skilllv3":
				_oskilllv3 = transform.gameObject;
				uiRef.Set("skilllv3", _oskilllv3.transform);
				_oskilllvText3 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText3", _oskilllvText3);
				break;
			case "skilllv4":
				_oskilllv4 = transform.gameObject;
				uiRef.Set("skilllv4", _oskilllv4.transform);
				_oskilllvText4 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText4", _oskilllvText4);
				break;
			case "skilllv5":
				_oskilllv5 = transform.gameObject;
				uiRef.Set("skilllv5", _oskilllv5.transform);
				_oskilllvText5 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText5", _oskilllvText5);
				break;
			case "skilllv6":
				_oskilllv6 = transform.gameObject;
				uiRef.Set("skilllv6", _oskilllv6.transform);
				_oskilllvText6 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText6", _oskilllvText6);
				break;
			case "skilllv7":
				_oskilllv7 = transform.gameObject;
				uiRef.Set("skilllv7", _oskilllv7.transform);
				_oskilllvText7 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText7", _oskilllvText7);
				break;
			case "skilllv8":
				_oskilllv8 = transform.gameObject;
				uiRef.Set("skilllv8", _oskilllv8.transform);
				_oskilllvText8 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText8", _oskilllvText8);
				break;
			case "skilllv9":
				_oskilllv9 = transform.gameObject;
				uiRef.Set("skilllv9", _oskilllv9.transform);
				_oskilllvText9 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText9", _oskilllvText9);
				break;
			case "skilllv10":
				_oskilllv10 = transform.gameObject;
				uiRef.Set("skilllv10", _oskilllv10.transform);
				_oskilllvText10 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText10", _oskilllvText10);
				break;
			case "skilllv11":
				_oskilllv11 = transform.gameObject;
				uiRef.Set("skilllv11", _oskilllv11.transform);
				_oskilllvText11 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText11", _oskilllvText11);
				break;
			case "skilllv12":
				_oskilllv12 = transform.gameObject;
				uiRef.Set("skilllv12", _oskilllv12.transform);
				_oskilllvText12 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText12", _oskilllvText12);
				break;
			case "skilllv13":
				_oskilllv13 = transform.gameObject;
				uiRef.Set("skilllv13", _oskilllv13.transform);
				_oskilllvText13 = transform.gameObject.GetComponent<Text>();
				uiRef.Set("skilllvText13", _oskilllvText13);
				break;
			case "skillTipBackImage":
				_oskillTipBackImage = transform.gameObject;
				uiRef.Set("skillTipBackImage", _oskillTipBackImage.transform);
				_oskillTipBackImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillTipBackImageRectTransform", _oskillTipBackImageRectTransform);
				_oskillTipBackImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillTipBackImageImage", _oskillTipBackImageImage);
				break;
			case "skillnolvImage":
				_oskillnolvImage = transform.gameObject;
				uiRef.Set("skillnolvImage", _oskillnolvImage.transform);
				_oskillnolvImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("skillnolvImageRectTransform", _oskillnolvImageRectTransform);
				_oskillnolvImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("skillnolvImageImage", _oskillnolvImageImage);
				break;
			case "noMoneyImage":
				_onoMoneyImage = transform.gameObject;
				uiRef.Set("noMoneyImage", _onoMoneyImage.transform);
				_onoMoneyImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("noMoneyImageRectTransform", _onoMoneyImageRectTransform);
				_onoMoneyImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("noMoneyImageImage", _onoMoneyImageImage);
				break;
			case "noFrontSkillImage":
				_onoFrontSkillImage = transform.gameObject;
				uiRef.Set("noFrontSkillImage", _onoFrontSkillImage.transform);
				_onoFrontSkillImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("noFrontSkillImageRectTransform", _onoFrontSkillImageRectTransform);
				_onoFrontSkillImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("noFrontSkillImageImage", _onoFrontSkillImageImage);
				break;
			}
		}
	}

	public GameObject GetskillImageObj(int index)
	{
		return index switch
		{
			1 => skillImageObj1, 
			2 => skillImageObj2, 
			3 => skillImageObj3, 
			4 => skillImageObj4, 
			5 => skillImageObj5, 
			6 => skillImageObj6, 
			7 => skillImageObj7, 
			8 => skillImageObj8, 
			9 => skillImageObj9, 
			10 => skillImageObj10, 
			11 => skillImageObj11, 
			12 => skillImageObj12, 
			13 => skillImageObj13, 
			_ => null, 
		};
	}

	public string GetskillImageName(int index)
	{
		return index switch
		{
			1 => "skillImage1", 
			2 => "skillImage2", 
			3 => "skillImage3", 
			4 => "skillImage4", 
			5 => "skillImage5", 
			6 => "skillImage6", 
			7 => "skillImage7", 
			8 => "skillImage8", 
			9 => "skillImage9", 
			10 => "skillImage10", 
			11 => "skillImage11", 
			12 => "skillImage12", 
			13 => "skillImage13", 
			_ => null, 
		};
	}

	public bool GetskillImageShow(int index)
	{
		return index switch
		{
			1 => skillImageShow1, 
			2 => skillImageShow2, 
			3 => skillImageShow3, 
			4 => skillImageShow4, 
			5 => skillImageShow5, 
			6 => skillImageShow6, 
			7 => skillImageShow7, 
			8 => skillImageShow8, 
			9 => skillImageShow9, 
			10 => skillImageShow10, 
			11 => skillImageShow11, 
			12 => skillImageShow12, 
			13 => skillImageShow13, 
			_ => false, 
		};
	}

	public void SetskillImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillImageShow1 = value;
			break;
		case 2:
			skillImageShow2 = value;
			break;
		case 3:
			skillImageShow3 = value;
			break;
		case 4:
			skillImageShow4 = value;
			break;
		case 5:
			skillImageShow5 = value;
			break;
		case 6:
			skillImageShow6 = value;
			break;
		case 7:
			skillImageShow7 = value;
			break;
		case 8:
			skillImageShow8 = value;
			break;
		case 9:
			skillImageShow9 = value;
			break;
		case 10:
			skillImageShow10 = value;
			break;
		case 11:
			skillImageShow11 = value;
			break;
		case 12:
			skillImageShow12 = value;
			break;
		case 13:
			skillImageShow13 = value;
			break;
		}
	}

	public Vector2 GetskillImageAnchoredposition(int index)
	{
		return index switch
		{
			1 => skillImageAnchoredposition1, 
			2 => skillImageAnchoredposition2, 
			3 => skillImageAnchoredposition3, 
			4 => skillImageAnchoredposition4, 
			5 => skillImageAnchoredposition5, 
			6 => skillImageAnchoredposition6, 
			7 => skillImageAnchoredposition7, 
			8 => skillImageAnchoredposition8, 
			9 => skillImageAnchoredposition9, 
			10 => skillImageAnchoredposition10, 
			11 => skillImageAnchoredposition11, 
			12 => skillImageAnchoredposition12, 
			13 => skillImageAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskillImageAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skillImageAnchoredposition1 = value;
			break;
		case 2:
			skillImageAnchoredposition2 = value;
			break;
		case 3:
			skillImageAnchoredposition3 = value;
			break;
		case 4:
			skillImageAnchoredposition4 = value;
			break;
		case 5:
			skillImageAnchoredposition5 = value;
			break;
		case 6:
			skillImageAnchoredposition6 = value;
			break;
		case 7:
			skillImageAnchoredposition7 = value;
			break;
		case 8:
			skillImageAnchoredposition8 = value;
			break;
		case 9:
			skillImageAnchoredposition9 = value;
			break;
		case 10:
			skillImageAnchoredposition10 = value;
			break;
		case 11:
			skillImageAnchoredposition11 = value;
			break;
		case 12:
			skillImageAnchoredposition12 = value;
			break;
		case 13:
			skillImageAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskillImageSize(int index)
	{
		return index switch
		{
			1 => skillImageSize1, 
			2 => skillImageSize2, 
			3 => skillImageSize3, 
			4 => skillImageSize4, 
			5 => skillImageSize5, 
			6 => skillImageSize6, 
			7 => skillImageSize7, 
			8 => skillImageSize8, 
			9 => skillImageSize9, 
			10 => skillImageSize10, 
			11 => skillImageSize11, 
			12 => skillImageSize12, 
			13 => skillImageSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillImageSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillImageSize1 = value;
			break;
		case 2:
			skillImageSize2 = value;
			break;
		case 3:
			skillImageSize3 = value;
			break;
		case 4:
			skillImageSize4 = value;
			break;
		case 5:
			skillImageSize5 = value;
			break;
		case 6:
			skillImageSize6 = value;
			break;
		case 7:
			skillImageSize7 = value;
			break;
		case 8:
			skillImageSize8 = value;
			break;
		case 9:
			skillImageSize9 = value;
			break;
		case 10:
			skillImageSize10 = value;
			break;
		case 11:
			skillImageSize11 = value;
			break;
		case 12:
			skillImageSize12 = value;
			break;
		case 13:
			skillImageSize13 = value;
			break;
		}
	}

	public Sprite GetskillImageSprite(int index)
	{
		return index switch
		{
			1 => skillImageSprite1, 
			2 => skillImageSprite2, 
			3 => skillImageSprite3, 
			4 => skillImageSprite4, 
			5 => skillImageSprite5, 
			6 => skillImageSprite6, 
			7 => skillImageSprite7, 
			8 => skillImageSprite8, 
			9 => skillImageSprite9, 
			10 => skillImageSprite10, 
			11 => skillImageSprite11, 
			12 => skillImageSprite12, 
			13 => skillImageSprite13, 
			_ => null, 
		};
	}

	public void SetskillImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillImageSprite1 = value;
			break;
		case 2:
			skillImageSprite2 = value;
			break;
		case 3:
			skillImageSprite3 = value;
			break;
		case 4:
			skillImageSprite4 = value;
			break;
		case 5:
			skillImageSprite5 = value;
			break;
		case 6:
			skillImageSprite6 = value;
			break;
		case 7:
			skillImageSprite7 = value;
			break;
		case 8:
			skillImageSprite8 = value;
			break;
		case 9:
			skillImageSprite9 = value;
			break;
		case 10:
			skillImageSprite10 = value;
			break;
		case 11:
			skillImageSprite11 = value;
			break;
		case 12:
			skillImageSprite12 = value;
			break;
		case 13:
			skillImageSprite13 = value;
			break;
		}
	}

	public string GetskillbackimgName(int index)
	{
		return index switch
		{
			1 => "skillbackimg1", 
			2 => "skillbackimg2", 
			3 => "skillbackimg3", 
			4 => "skillbackimg4", 
			5 => "skillbackimg5", 
			6 => "skillbackimg6", 
			7 => "skillbackimg7", 
			8 => "skillbackimg8", 
			9 => "skillbackimg9", 
			10 => "skillbackimg10", 
			11 => "skillbackimg11", 
			12 => "skillbackimg12", 
			13 => "skillbackimg13", 
			_ => null, 
		};
	}

	public bool GetskillbackimgShow(int index)
	{
		return index switch
		{
			1 => skillbackimgShow1, 
			2 => skillbackimgShow2, 
			3 => skillbackimgShow3, 
			4 => skillbackimgShow4, 
			5 => skillbackimgShow5, 
			6 => skillbackimgShow6, 
			7 => skillbackimgShow7, 
			8 => skillbackimgShow8, 
			9 => skillbackimgShow9, 
			10 => skillbackimgShow10, 
			11 => skillbackimgShow11, 
			12 => skillbackimgShow12, 
			13 => skillbackimgShow13, 
			_ => false, 
		};
	}

	public void SetskillbackimgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillbackimgShow1 = value;
			break;
		case 2:
			skillbackimgShow2 = value;
			break;
		case 3:
			skillbackimgShow3 = value;
			break;
		case 4:
			skillbackimgShow4 = value;
			break;
		case 5:
			skillbackimgShow5 = value;
			break;
		case 6:
			skillbackimgShow6 = value;
			break;
		case 7:
			skillbackimgShow7 = value;
			break;
		case 8:
			skillbackimgShow8 = value;
			break;
		case 9:
			skillbackimgShow9 = value;
			break;
		case 10:
			skillbackimgShow10 = value;
			break;
		case 11:
			skillbackimgShow11 = value;
			break;
		case 12:
			skillbackimgShow12 = value;
			break;
		case 13:
			skillbackimgShow13 = value;
			break;
		}
	}

	public Vector2 GetskillbackimgAnchoredposition(int index)
	{
		return index switch
		{
			1 => skillbackimgAnchoredposition1, 
			2 => skillbackimgAnchoredposition2, 
			3 => skillbackimgAnchoredposition3, 
			4 => skillbackimgAnchoredposition4, 
			5 => skillbackimgAnchoredposition5, 
			6 => skillbackimgAnchoredposition6, 
			7 => skillbackimgAnchoredposition7, 
			8 => skillbackimgAnchoredposition8, 
			9 => skillbackimgAnchoredposition9, 
			10 => skillbackimgAnchoredposition10, 
			11 => skillbackimgAnchoredposition11, 
			12 => skillbackimgAnchoredposition12, 
			13 => skillbackimgAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskillbackimgAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skillbackimgAnchoredposition1 = value;
			break;
		case 2:
			skillbackimgAnchoredposition2 = value;
			break;
		case 3:
			skillbackimgAnchoredposition3 = value;
			break;
		case 4:
			skillbackimgAnchoredposition4 = value;
			break;
		case 5:
			skillbackimgAnchoredposition5 = value;
			break;
		case 6:
			skillbackimgAnchoredposition6 = value;
			break;
		case 7:
			skillbackimgAnchoredposition7 = value;
			break;
		case 8:
			skillbackimgAnchoredposition8 = value;
			break;
		case 9:
			skillbackimgAnchoredposition9 = value;
			break;
		case 10:
			skillbackimgAnchoredposition10 = value;
			break;
		case 11:
			skillbackimgAnchoredposition11 = value;
			break;
		case 12:
			skillbackimgAnchoredposition12 = value;
			break;
		case 13:
			skillbackimgAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskillbackimgSize(int index)
	{
		return index switch
		{
			1 => skillbackimgSize1, 
			2 => skillbackimgSize2, 
			3 => skillbackimgSize3, 
			4 => skillbackimgSize4, 
			5 => skillbackimgSize5, 
			6 => skillbackimgSize6, 
			7 => skillbackimgSize7, 
			8 => skillbackimgSize8, 
			9 => skillbackimgSize9, 
			10 => skillbackimgSize10, 
			11 => skillbackimgSize11, 
			12 => skillbackimgSize12, 
			13 => skillbackimgSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillbackimgSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillbackimgSize1 = value;
			break;
		case 2:
			skillbackimgSize2 = value;
			break;
		case 3:
			skillbackimgSize3 = value;
			break;
		case 4:
			skillbackimgSize4 = value;
			break;
		case 5:
			skillbackimgSize5 = value;
			break;
		case 6:
			skillbackimgSize6 = value;
			break;
		case 7:
			skillbackimgSize7 = value;
			break;
		case 8:
			skillbackimgSize8 = value;
			break;
		case 9:
			skillbackimgSize9 = value;
			break;
		case 10:
			skillbackimgSize10 = value;
			break;
		case 11:
			skillbackimgSize11 = value;
			break;
		case 12:
			skillbackimgSize12 = value;
			break;
		case 13:
			skillbackimgSize13 = value;
			break;
		}
	}

	public Sprite GetskillbackimgSprite(int index)
	{
		return index switch
		{
			1 => skillbackimgSprite1, 
			2 => skillbackimgSprite2, 
			3 => skillbackimgSprite3, 
			4 => skillbackimgSprite4, 
			5 => skillbackimgSprite5, 
			6 => skillbackimgSprite6, 
			7 => skillbackimgSprite7, 
			8 => skillbackimgSprite8, 
			9 => skillbackimgSprite9, 
			10 => skillbackimgSprite10, 
			11 => skillbackimgSprite11, 
			12 => skillbackimgSprite12, 
			13 => skillbackimgSprite13, 
			_ => null, 
		};
	}

	public void SetskillbackimgSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillbackimgSprite1 = value;
			break;
		case 2:
			skillbackimgSprite2 = value;
			break;
		case 3:
			skillbackimgSprite3 = value;
			break;
		case 4:
			skillbackimgSprite4 = value;
			break;
		case 5:
			skillbackimgSprite5 = value;
			break;
		case 6:
			skillbackimgSprite6 = value;
			break;
		case 7:
			skillbackimgSprite7 = value;
			break;
		case 8:
			skillbackimgSprite8 = value;
			break;
		case 9:
			skillbackimgSprite9 = value;
			break;
		case 10:
			skillbackimgSprite10 = value;
			break;
		case 11:
			skillbackimgSprite11 = value;
			break;
		case 12:
			skillbackimgSprite12 = value;
			break;
		case 13:
			skillbackimgSprite13 = value;
			break;
		}
	}

	public void skillbackimgNtvsize1()
	{
		if (_oskillbackimgImage1 != null)
		{
			_oskillbackimgImage1.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize2()
	{
		if (_oskillbackimgImage2 != null)
		{
			_oskillbackimgImage2.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize3()
	{
		if (_oskillbackimgImage3 != null)
		{
			_oskillbackimgImage3.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize4()
	{
		if (_oskillbackimgImage4 != null)
		{
			_oskillbackimgImage4.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize5()
	{
		if (_oskillbackimgImage5 != null)
		{
			_oskillbackimgImage5.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize6()
	{
		if (_oskillbackimgImage6 != null)
		{
			_oskillbackimgImage6.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize7()
	{
		if (_oskillbackimgImage7 != null)
		{
			_oskillbackimgImage7.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize8()
	{
		if (_oskillbackimgImage8 != null)
		{
			_oskillbackimgImage8.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize9()
	{
		if (_oskillbackimgImage9 != null)
		{
			_oskillbackimgImage9.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize10()
	{
		if (_oskillbackimgImage10 != null)
		{
			_oskillbackimgImage10.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize11()
	{
		if (_oskillbackimgImage11 != null)
		{
			_oskillbackimgImage11.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize12()
	{
		if (_oskillbackimgImage12 != null)
		{
			_oskillbackimgImage12.SetNativeSize();
		}
	}

	public void skillbackimgNtvsize13()
	{
		if (_oskillbackimgImage13 != null)
		{
			_oskillbackimgImage13.SetNativeSize();
		}
	}

	public void CallskillbackimgNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			skillbackimgNtvsize1();
			break;
		case 2:
			skillbackimgNtvsize2();
			break;
		case 3:
			skillbackimgNtvsize3();
			break;
		case 4:
			skillbackimgNtvsize4();
			break;
		case 5:
			skillbackimgNtvsize5();
			break;
		case 6:
			skillbackimgNtvsize6();
			break;
		case 7:
			skillbackimgNtvsize7();
			break;
		case 8:
			skillbackimgNtvsize8();
			break;
		case 9:
			skillbackimgNtvsize9();
			break;
		case 10:
			skillbackimgNtvsize10();
			break;
		case 11:
			skillbackimgNtvsize11();
			break;
		case 12:
			skillbackimgNtvsize12();
			break;
		case 13:
			skillbackimgNtvsize13();
			break;
		}
	}

	public string GetskillmaxImgName(int index)
	{
		return index switch
		{
			1 => "skillmaxImg1", 
			2 => "skillmaxImg2", 
			3 => "skillmaxImg3", 
			4 => "skillmaxImg4", 
			5 => "skillmaxImg5", 
			6 => "skillmaxImg6", 
			7 => "skillmaxImg7", 
			8 => "skillmaxImg8", 
			9 => "skillmaxImg9", 
			10 => "skillmaxImg10", 
			11 => "skillmaxImg11", 
			12 => "skillmaxImg12", 
			13 => "skillmaxImg13", 
			_ => null, 
		};
	}

	public bool GetskillmaxImgShow(int index)
	{
		return index switch
		{
			1 => skillmaxImgShow1, 
			2 => skillmaxImgShow2, 
			3 => skillmaxImgShow3, 
			4 => skillmaxImgShow4, 
			5 => skillmaxImgShow5, 
			6 => skillmaxImgShow6, 
			7 => skillmaxImgShow7, 
			8 => skillmaxImgShow8, 
			9 => skillmaxImgShow9, 
			10 => skillmaxImgShow10, 
			11 => skillmaxImgShow11, 
			12 => skillmaxImgShow12, 
			13 => skillmaxImgShow13, 
			_ => false, 
		};
	}

	public void SetskillmaxImgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillmaxImgShow1 = value;
			break;
		case 2:
			skillmaxImgShow2 = value;
			break;
		case 3:
			skillmaxImgShow3 = value;
			break;
		case 4:
			skillmaxImgShow4 = value;
			break;
		case 5:
			skillmaxImgShow5 = value;
			break;
		case 6:
			skillmaxImgShow6 = value;
			break;
		case 7:
			skillmaxImgShow7 = value;
			break;
		case 8:
			skillmaxImgShow8 = value;
			break;
		case 9:
			skillmaxImgShow9 = value;
			break;
		case 10:
			skillmaxImgShow10 = value;
			break;
		case 11:
			skillmaxImgShow11 = value;
			break;
		case 12:
			skillmaxImgShow12 = value;
			break;
		case 13:
			skillmaxImgShow13 = value;
			break;
		}
	}

	public Vector2 GetskillmaxImgAnchoredposition(int index)
	{
		return index switch
		{
			1 => skillmaxImgAnchoredposition1, 
			2 => skillmaxImgAnchoredposition2, 
			3 => skillmaxImgAnchoredposition3, 
			4 => skillmaxImgAnchoredposition4, 
			5 => skillmaxImgAnchoredposition5, 
			6 => skillmaxImgAnchoredposition6, 
			7 => skillmaxImgAnchoredposition7, 
			8 => skillmaxImgAnchoredposition8, 
			9 => skillmaxImgAnchoredposition9, 
			10 => skillmaxImgAnchoredposition10, 
			11 => skillmaxImgAnchoredposition11, 
			12 => skillmaxImgAnchoredposition12, 
			13 => skillmaxImgAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskillmaxImgAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skillmaxImgAnchoredposition1 = value;
			break;
		case 2:
			skillmaxImgAnchoredposition2 = value;
			break;
		case 3:
			skillmaxImgAnchoredposition3 = value;
			break;
		case 4:
			skillmaxImgAnchoredposition4 = value;
			break;
		case 5:
			skillmaxImgAnchoredposition5 = value;
			break;
		case 6:
			skillmaxImgAnchoredposition6 = value;
			break;
		case 7:
			skillmaxImgAnchoredposition7 = value;
			break;
		case 8:
			skillmaxImgAnchoredposition8 = value;
			break;
		case 9:
			skillmaxImgAnchoredposition9 = value;
			break;
		case 10:
			skillmaxImgAnchoredposition10 = value;
			break;
		case 11:
			skillmaxImgAnchoredposition11 = value;
			break;
		case 12:
			skillmaxImgAnchoredposition12 = value;
			break;
		case 13:
			skillmaxImgAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskillmaxImgSize(int index)
	{
		return index switch
		{
			1 => skillmaxImgSize1, 
			2 => skillmaxImgSize2, 
			3 => skillmaxImgSize3, 
			4 => skillmaxImgSize4, 
			5 => skillmaxImgSize5, 
			6 => skillmaxImgSize6, 
			7 => skillmaxImgSize7, 
			8 => skillmaxImgSize8, 
			9 => skillmaxImgSize9, 
			10 => skillmaxImgSize10, 
			11 => skillmaxImgSize11, 
			12 => skillmaxImgSize12, 
			13 => skillmaxImgSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillmaxImgSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillmaxImgSize1 = value;
			break;
		case 2:
			skillmaxImgSize2 = value;
			break;
		case 3:
			skillmaxImgSize3 = value;
			break;
		case 4:
			skillmaxImgSize4 = value;
			break;
		case 5:
			skillmaxImgSize5 = value;
			break;
		case 6:
			skillmaxImgSize6 = value;
			break;
		case 7:
			skillmaxImgSize7 = value;
			break;
		case 8:
			skillmaxImgSize8 = value;
			break;
		case 9:
			skillmaxImgSize9 = value;
			break;
		case 10:
			skillmaxImgSize10 = value;
			break;
		case 11:
			skillmaxImgSize11 = value;
			break;
		case 12:
			skillmaxImgSize12 = value;
			break;
		case 13:
			skillmaxImgSize13 = value;
			break;
		}
	}

	public Sprite GetskillmaxImgSprite(int index)
	{
		return index switch
		{
			1 => skillmaxImgSprite1, 
			2 => skillmaxImgSprite2, 
			3 => skillmaxImgSprite3, 
			4 => skillmaxImgSprite4, 
			5 => skillmaxImgSprite5, 
			6 => skillmaxImgSprite6, 
			7 => skillmaxImgSprite7, 
			8 => skillmaxImgSprite8, 
			9 => skillmaxImgSprite9, 
			10 => skillmaxImgSprite10, 
			11 => skillmaxImgSprite11, 
			12 => skillmaxImgSprite12, 
			13 => skillmaxImgSprite13, 
			_ => null, 
		};
	}

	public void SetskillmaxImgSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillmaxImgSprite1 = value;
			break;
		case 2:
			skillmaxImgSprite2 = value;
			break;
		case 3:
			skillmaxImgSprite3 = value;
			break;
		case 4:
			skillmaxImgSprite4 = value;
			break;
		case 5:
			skillmaxImgSprite5 = value;
			break;
		case 6:
			skillmaxImgSprite6 = value;
			break;
		case 7:
			skillmaxImgSprite7 = value;
			break;
		case 8:
			skillmaxImgSprite8 = value;
			break;
		case 9:
			skillmaxImgSprite9 = value;
			break;
		case 10:
			skillmaxImgSprite10 = value;
			break;
		case 11:
			skillmaxImgSprite11 = value;
			break;
		case 12:
			skillmaxImgSprite12 = value;
			break;
		case 13:
			skillmaxImgSprite13 = value;
			break;
		}
	}

	public string GetskillimagestudioName(int index)
	{
		return index switch
		{
			1 => "skillimagestudio1", 
			2 => "skillimagestudio2", 
			3 => "skillimagestudio3", 
			4 => "skillimagestudio4", 
			5 => "skillimagestudio5", 
			6 => "skillimagestudio6", 
			7 => "skillimagestudio7", 
			8 => "skillimagestudio8", 
			9 => "skillimagestudio9", 
			10 => "skillimagestudio10", 
			11 => "skillimagestudio11", 
			12 => "skillimagestudio12", 
			13 => "skillimagestudio13", 
			_ => null, 
		};
	}

	public bool GetskillimagestudioShow(int index)
	{
		return index switch
		{
			1 => skillimagestudioShow1, 
			2 => skillimagestudioShow2, 
			3 => skillimagestudioShow3, 
			4 => skillimagestudioShow4, 
			5 => skillimagestudioShow5, 
			6 => skillimagestudioShow6, 
			7 => skillimagestudioShow7, 
			8 => skillimagestudioShow8, 
			9 => skillimagestudioShow9, 
			10 => skillimagestudioShow10, 
			11 => skillimagestudioShow11, 
			12 => skillimagestudioShow12, 
			13 => skillimagestudioShow13, 
			_ => false, 
		};
	}

	public void SetskillimagestudioShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillimagestudioShow1 = value;
			break;
		case 2:
			skillimagestudioShow2 = value;
			break;
		case 3:
			skillimagestudioShow3 = value;
			break;
		case 4:
			skillimagestudioShow4 = value;
			break;
		case 5:
			skillimagestudioShow5 = value;
			break;
		case 6:
			skillimagestudioShow6 = value;
			break;
		case 7:
			skillimagestudioShow7 = value;
			break;
		case 8:
			skillimagestudioShow8 = value;
			break;
		case 9:
			skillimagestudioShow9 = value;
			break;
		case 10:
			skillimagestudioShow10 = value;
			break;
		case 11:
			skillimagestudioShow11 = value;
			break;
		case 12:
			skillimagestudioShow12 = value;
			break;
		case 13:
			skillimagestudioShow13 = value;
			break;
		}
	}

	public Vector2 GetskillimagestudioAnchoredposition(int index)
	{
		return index switch
		{
			1 => skillimagestudioAnchoredposition1, 
			2 => skillimagestudioAnchoredposition2, 
			3 => skillimagestudioAnchoredposition3, 
			4 => skillimagestudioAnchoredposition4, 
			5 => skillimagestudioAnchoredposition5, 
			6 => skillimagestudioAnchoredposition6, 
			7 => skillimagestudioAnchoredposition7, 
			8 => skillimagestudioAnchoredposition8, 
			9 => skillimagestudioAnchoredposition9, 
			10 => skillimagestudioAnchoredposition10, 
			11 => skillimagestudioAnchoredposition11, 
			12 => skillimagestudioAnchoredposition12, 
			13 => skillimagestudioAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskillimagestudioAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skillimagestudioAnchoredposition1 = value;
			break;
		case 2:
			skillimagestudioAnchoredposition2 = value;
			break;
		case 3:
			skillimagestudioAnchoredposition3 = value;
			break;
		case 4:
			skillimagestudioAnchoredposition4 = value;
			break;
		case 5:
			skillimagestudioAnchoredposition5 = value;
			break;
		case 6:
			skillimagestudioAnchoredposition6 = value;
			break;
		case 7:
			skillimagestudioAnchoredposition7 = value;
			break;
		case 8:
			skillimagestudioAnchoredposition8 = value;
			break;
		case 9:
			skillimagestudioAnchoredposition9 = value;
			break;
		case 10:
			skillimagestudioAnchoredposition10 = value;
			break;
		case 11:
			skillimagestudioAnchoredposition11 = value;
			break;
		case 12:
			skillimagestudioAnchoredposition12 = value;
			break;
		case 13:
			skillimagestudioAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskillimagestudioScale(int index)
	{
		return index switch
		{
			1 => skillimagestudioScale1, 
			2 => skillimagestudioScale2, 
			3 => skillimagestudioScale3, 
			4 => skillimagestudioScale4, 
			5 => skillimagestudioScale5, 
			6 => skillimagestudioScale6, 
			7 => skillimagestudioScale7, 
			8 => skillimagestudioScale8, 
			9 => skillimagestudioScale9, 
			10 => skillimagestudioScale10, 
			11 => skillimagestudioScale11, 
			12 => skillimagestudioScale12, 
			13 => skillimagestudioScale13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillimagestudioScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillimagestudioScale1 = value;
			break;
		case 2:
			skillimagestudioScale2 = value;
			break;
		case 3:
			skillimagestudioScale3 = value;
			break;
		case 4:
			skillimagestudioScale4 = value;
			break;
		case 5:
			skillimagestudioScale5 = value;
			break;
		case 6:
			skillimagestudioScale6 = value;
			break;
		case 7:
			skillimagestudioScale7 = value;
			break;
		case 8:
			skillimagestudioScale8 = value;
			break;
		case 9:
			skillimagestudioScale9 = value;
			break;
		case 10:
			skillimagestudioScale10 = value;
			break;
		case 11:
			skillimagestudioScale11 = value;
			break;
		case 12:
			skillimagestudioScale12 = value;
			break;
		case 13:
			skillimagestudioScale13 = value;
			break;
		}
	}

	public Vector3 GetskillimagestudioSize(int index)
	{
		return index switch
		{
			1 => skillimagestudioSize1, 
			2 => skillimagestudioSize2, 
			3 => skillimagestudioSize3, 
			4 => skillimagestudioSize4, 
			5 => skillimagestudioSize5, 
			6 => skillimagestudioSize6, 
			7 => skillimagestudioSize7, 
			8 => skillimagestudioSize8, 
			9 => skillimagestudioSize9, 
			10 => skillimagestudioSize10, 
			11 => skillimagestudioSize11, 
			12 => skillimagestudioSize12, 
			13 => skillimagestudioSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillimagestudioSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillimagestudioSize1 = value;
			break;
		case 2:
			skillimagestudioSize2 = value;
			break;
		case 3:
			skillimagestudioSize3 = value;
			break;
		case 4:
			skillimagestudioSize4 = value;
			break;
		case 5:
			skillimagestudioSize5 = value;
			break;
		case 6:
			skillimagestudioSize6 = value;
			break;
		case 7:
			skillimagestudioSize7 = value;
			break;
		case 8:
			skillimagestudioSize8 = value;
			break;
		case 9:
			skillimagestudioSize9 = value;
			break;
		case 10:
			skillimagestudioSize10 = value;
			break;
		case 11:
			skillimagestudioSize11 = value;
			break;
		case 12:
			skillimagestudioSize12 = value;
			break;
		case 13:
			skillimagestudioSize13 = value;
			break;
		}
	}

	public Sprite GetskillimagestudioSprite(int index)
	{
		return index switch
		{
			1 => skillimagestudioSprite1, 
			2 => skillimagestudioSprite2, 
			3 => skillimagestudioSprite3, 
			4 => skillimagestudioSprite4, 
			5 => skillimagestudioSprite5, 
			6 => skillimagestudioSprite6, 
			7 => skillimagestudioSprite7, 
			8 => skillimagestudioSprite8, 
			9 => skillimagestudioSprite9, 
			10 => skillimagestudioSprite10, 
			11 => skillimagestudioSprite11, 
			12 => skillimagestudioSprite12, 
			13 => skillimagestudioSprite13, 
			_ => null, 
		};
	}

	public void SetskillimagestudioSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillimagestudioSprite1 = value;
			break;
		case 2:
			skillimagestudioSprite2 = value;
			break;
		case 3:
			skillimagestudioSprite3 = value;
			break;
		case 4:
			skillimagestudioSprite4 = value;
			break;
		case 5:
			skillimagestudioSprite5 = value;
			break;
		case 6:
			skillimagestudioSprite6 = value;
			break;
		case 7:
			skillimagestudioSprite7 = value;
			break;
		case 8:
			skillimagestudioSprite8 = value;
			break;
		case 9:
			skillimagestudioSprite9 = value;
			break;
		case 10:
			skillimagestudioSprite10 = value;
			break;
		case 11:
			skillimagestudioSprite11 = value;
			break;
		case 12:
			skillimagestudioSprite12 = value;
			break;
		case 13:
			skillimagestudioSprite13 = value;
			break;
		}
	}

	public string GetskilleffectName(int index)
	{
		return index switch
		{
			1 => "skilleffect1", 
			2 => "skilleffect2", 
			3 => "skilleffect3", 
			4 => "skilleffect4", 
			5 => "skilleffect5", 
			6 => "skilleffect6", 
			7 => "skilleffect7", 
			8 => "skilleffect8", 
			9 => "skilleffect9", 
			10 => "skilleffect10", 
			11 => "skilleffect11", 
			12 => "skilleffect12", 
			13 => "skilleffect13", 
			_ => null, 
		};
	}

	public bool GetskilleffectShow(int index)
	{
		return index switch
		{
			1 => skilleffectShow1, 
			2 => skilleffectShow2, 
			3 => skilleffectShow3, 
			4 => skilleffectShow4, 
			5 => skilleffectShow5, 
			6 => skilleffectShow6, 
			7 => skilleffectShow7, 
			8 => skilleffectShow8, 
			9 => skilleffectShow9, 
			10 => skilleffectShow10, 
			11 => skilleffectShow11, 
			12 => skilleffectShow12, 
			13 => skilleffectShow13, 
			_ => false, 
		};
	}

	public void SetskilleffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skilleffectShow1 = value;
			break;
		case 2:
			skilleffectShow2 = value;
			break;
		case 3:
			skilleffectShow3 = value;
			break;
		case 4:
			skilleffectShow4 = value;
			break;
		case 5:
			skilleffectShow5 = value;
			break;
		case 6:
			skilleffectShow6 = value;
			break;
		case 7:
			skilleffectShow7 = value;
			break;
		case 8:
			skilleffectShow8 = value;
			break;
		case 9:
			skilleffectShow9 = value;
			break;
		case 10:
			skilleffectShow10 = value;
			break;
		case 11:
			skilleffectShow11 = value;
			break;
		case 12:
			skilleffectShow12 = value;
			break;
		case 13:
			skilleffectShow13 = value;
			break;
		}
	}

	public Vector2 GetskilleffectAnchoredposition(int index)
	{
		return index switch
		{
			1 => skilleffectAnchoredposition1, 
			2 => skilleffectAnchoredposition2, 
			3 => skilleffectAnchoredposition3, 
			4 => skilleffectAnchoredposition4, 
			5 => skilleffectAnchoredposition5, 
			6 => skilleffectAnchoredposition6, 
			7 => skilleffectAnchoredposition7, 
			8 => skilleffectAnchoredposition8, 
			9 => skilleffectAnchoredposition9, 
			10 => skilleffectAnchoredposition10, 
			11 => skilleffectAnchoredposition11, 
			12 => skilleffectAnchoredposition12, 
			13 => skilleffectAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskilleffectAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skilleffectAnchoredposition1 = value;
			break;
		case 2:
			skilleffectAnchoredposition2 = value;
			break;
		case 3:
			skilleffectAnchoredposition3 = value;
			break;
		case 4:
			skilleffectAnchoredposition4 = value;
			break;
		case 5:
			skilleffectAnchoredposition5 = value;
			break;
		case 6:
			skilleffectAnchoredposition6 = value;
			break;
		case 7:
			skilleffectAnchoredposition7 = value;
			break;
		case 8:
			skilleffectAnchoredposition8 = value;
			break;
		case 9:
			skilleffectAnchoredposition9 = value;
			break;
		case 10:
			skilleffectAnchoredposition10 = value;
			break;
		case 11:
			skilleffectAnchoredposition11 = value;
			break;
		case 12:
			skilleffectAnchoredposition12 = value;
			break;
		case 13:
			skilleffectAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskilleffectSize(int index)
	{
		return index switch
		{
			1 => skilleffectSize1, 
			2 => skilleffectSize2, 
			3 => skilleffectSize3, 
			4 => skilleffectSize4, 
			5 => skilleffectSize5, 
			6 => skilleffectSize6, 
			7 => skilleffectSize7, 
			8 => skilleffectSize8, 
			9 => skilleffectSize9, 
			10 => skilleffectSize10, 
			11 => skilleffectSize11, 
			12 => skilleffectSize12, 
			13 => skilleffectSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskilleffectSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skilleffectSize1 = value;
			break;
		case 2:
			skilleffectSize2 = value;
			break;
		case 3:
			skilleffectSize3 = value;
			break;
		case 4:
			skilleffectSize4 = value;
			break;
		case 5:
			skilleffectSize5 = value;
			break;
		case 6:
			skilleffectSize6 = value;
			break;
		case 7:
			skilleffectSize7 = value;
			break;
		case 8:
			skilleffectSize8 = value;
			break;
		case 9:
			skilleffectSize9 = value;
			break;
		case 10:
			skilleffectSize10 = value;
			break;
		case 11:
			skilleffectSize11 = value;
			break;
		case 12:
			skilleffectSize12 = value;
			break;
		case 13:
			skilleffectSize13 = value;
			break;
		}
	}

	public Sprite GetskilleffectSprite(int index)
	{
		return index switch
		{
			1 => skilleffectSprite1, 
			2 => skilleffectSprite2, 
			3 => skilleffectSprite3, 
			4 => skilleffectSprite4, 
			5 => skilleffectSprite5, 
			6 => skilleffectSprite6, 
			7 => skilleffectSprite7, 
			8 => skilleffectSprite8, 
			9 => skilleffectSprite9, 
			10 => skilleffectSprite10, 
			11 => skilleffectSprite11, 
			12 => skilleffectSprite12, 
			13 => skilleffectSprite13, 
			_ => null, 
		};
	}

	public void SetskilleffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skilleffectSprite1 = value;
			break;
		case 2:
			skilleffectSprite2 = value;
			break;
		case 3:
			skilleffectSprite3 = value;
			break;
		case 4:
			skilleffectSprite4 = value;
			break;
		case 5:
			skilleffectSprite5 = value;
			break;
		case 6:
			skilleffectSprite6 = value;
			break;
		case 7:
			skilleffectSprite7 = value;
			break;
		case 8:
			skilleffectSprite8 = value;
			break;
		case 9:
			skilleffectSprite9 = value;
			break;
		case 10:
			skilleffectSprite10 = value;
			break;
		case 11:
			skilleffectSprite11 = value;
			break;
		case 12:
			skilleffectSprite12 = value;
			break;
		case 13:
			skilleffectSprite13 = value;
			break;
		}
	}

	public string GetskillBoundImageName(int index)
	{
		return index switch
		{
			1 => "skillBoundImage1", 
			2 => "skillBoundImage2", 
			3 => "skillBoundImage3", 
			4 => "skillBoundImage4", 
			5 => "skillBoundImage5", 
			6 => "skillBoundImage6", 
			7 => "skillBoundImage7", 
			8 => "skillBoundImage8", 
			9 => "skillBoundImage9", 
			10 => "skillBoundImage10", 
			11 => "skillBoundImage11", 
			12 => "skillBoundImage12", 
			13 => "skillBoundImage13", 
			_ => null, 
		};
	}

	public bool GetskillBoundImageShow(int index)
	{
		return index switch
		{
			1 => skillBoundImageShow1, 
			2 => skillBoundImageShow2, 
			3 => skillBoundImageShow3, 
			4 => skillBoundImageShow4, 
			5 => skillBoundImageShow5, 
			6 => skillBoundImageShow6, 
			7 => skillBoundImageShow7, 
			8 => skillBoundImageShow8, 
			9 => skillBoundImageShow9, 
			10 => skillBoundImageShow10, 
			11 => skillBoundImageShow11, 
			12 => skillBoundImageShow12, 
			13 => skillBoundImageShow13, 
			_ => false, 
		};
	}

	public void SetskillBoundImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillBoundImageShow1 = value;
			break;
		case 2:
			skillBoundImageShow2 = value;
			break;
		case 3:
			skillBoundImageShow3 = value;
			break;
		case 4:
			skillBoundImageShow4 = value;
			break;
		case 5:
			skillBoundImageShow5 = value;
			break;
		case 6:
			skillBoundImageShow6 = value;
			break;
		case 7:
			skillBoundImageShow7 = value;
			break;
		case 8:
			skillBoundImageShow8 = value;
			break;
		case 9:
			skillBoundImageShow9 = value;
			break;
		case 10:
			skillBoundImageShow10 = value;
			break;
		case 11:
			skillBoundImageShow11 = value;
			break;
		case 12:
			skillBoundImageShow12 = value;
			break;
		case 13:
			skillBoundImageShow13 = value;
			break;
		}
	}

	public Vector2 GetskillBoundImageAnchoredposition(int index)
	{
		return index switch
		{
			1 => skillBoundImageAnchoredposition1, 
			2 => skillBoundImageAnchoredposition2, 
			3 => skillBoundImageAnchoredposition3, 
			4 => skillBoundImageAnchoredposition4, 
			5 => skillBoundImageAnchoredposition5, 
			6 => skillBoundImageAnchoredposition6, 
			7 => skillBoundImageAnchoredposition7, 
			8 => skillBoundImageAnchoredposition8, 
			9 => skillBoundImageAnchoredposition9, 
			10 => skillBoundImageAnchoredposition10, 
			11 => skillBoundImageAnchoredposition11, 
			12 => skillBoundImageAnchoredposition12, 
			13 => skillBoundImageAnchoredposition13, 
			_ => Vector2.zero, 
		};
	}

	public void SetskillBoundImageAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			skillBoundImageAnchoredposition1 = value;
			break;
		case 2:
			skillBoundImageAnchoredposition2 = value;
			break;
		case 3:
			skillBoundImageAnchoredposition3 = value;
			break;
		case 4:
			skillBoundImageAnchoredposition4 = value;
			break;
		case 5:
			skillBoundImageAnchoredposition5 = value;
			break;
		case 6:
			skillBoundImageAnchoredposition6 = value;
			break;
		case 7:
			skillBoundImageAnchoredposition7 = value;
			break;
		case 8:
			skillBoundImageAnchoredposition8 = value;
			break;
		case 9:
			skillBoundImageAnchoredposition9 = value;
			break;
		case 10:
			skillBoundImageAnchoredposition10 = value;
			break;
		case 11:
			skillBoundImageAnchoredposition11 = value;
			break;
		case 12:
			skillBoundImageAnchoredposition12 = value;
			break;
		case 13:
			skillBoundImageAnchoredposition13 = value;
			break;
		}
	}

	public Vector3 GetskillBoundImageSize(int index)
	{
		return index switch
		{
			1 => skillBoundImageSize1, 
			2 => skillBoundImageSize2, 
			3 => skillBoundImageSize3, 
			4 => skillBoundImageSize4, 
			5 => skillBoundImageSize5, 
			6 => skillBoundImageSize6, 
			7 => skillBoundImageSize7, 
			8 => skillBoundImageSize8, 
			9 => skillBoundImageSize9, 
			10 => skillBoundImageSize10, 
			11 => skillBoundImageSize11, 
			12 => skillBoundImageSize12, 
			13 => skillBoundImageSize13, 
			_ => Vector3.zero, 
		};
	}

	public void SetskillBoundImageSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			skillBoundImageSize1 = value;
			break;
		case 2:
			skillBoundImageSize2 = value;
			break;
		case 3:
			skillBoundImageSize3 = value;
			break;
		case 4:
			skillBoundImageSize4 = value;
			break;
		case 5:
			skillBoundImageSize5 = value;
			break;
		case 6:
			skillBoundImageSize6 = value;
			break;
		case 7:
			skillBoundImageSize7 = value;
			break;
		case 8:
			skillBoundImageSize8 = value;
			break;
		case 9:
			skillBoundImageSize9 = value;
			break;
		case 10:
			skillBoundImageSize10 = value;
			break;
		case 11:
			skillBoundImageSize11 = value;
			break;
		case 12:
			skillBoundImageSize12 = value;
			break;
		case 13:
			skillBoundImageSize13 = value;
			break;
		}
	}

	public Sprite GetskillBoundImageSprite(int index)
	{
		return index switch
		{
			1 => skillBoundImageSprite1, 
			2 => skillBoundImageSprite2, 
			3 => skillBoundImageSprite3, 
			4 => skillBoundImageSprite4, 
			5 => skillBoundImageSprite5, 
			6 => skillBoundImageSprite6, 
			7 => skillBoundImageSprite7, 
			8 => skillBoundImageSprite8, 
			9 => skillBoundImageSprite9, 
			10 => skillBoundImageSprite10, 
			11 => skillBoundImageSprite11, 
			12 => skillBoundImageSprite12, 
			13 => skillBoundImageSprite13, 
			_ => null, 
		};
	}

	public void SetskillBoundImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skillBoundImageSprite1 = value;
			break;
		case 2:
			skillBoundImageSprite2 = value;
			break;
		case 3:
			skillBoundImageSprite3 = value;
			break;
		case 4:
			skillBoundImageSprite4 = value;
			break;
		case 5:
			skillBoundImageSprite5 = value;
			break;
		case 6:
			skillBoundImageSprite6 = value;
			break;
		case 7:
			skillBoundImageSprite7 = value;
			break;
		case 8:
			skillBoundImageSprite8 = value;
			break;
		case 9:
			skillBoundImageSprite9 = value;
			break;
		case 10:
			skillBoundImageSprite10 = value;
			break;
		case 11:
			skillBoundImageSprite11 = value;
			break;
		case 12:
			skillBoundImageSprite12 = value;
			break;
		case 13:
			skillBoundImageSprite13 = value;
			break;
		}
	}

	public Color GetskillBoundImageColor(int index)
	{
		return index switch
		{
			1 => skillBoundImageColor1, 
			2 => skillBoundImageColor2, 
			3 => skillBoundImageColor3, 
			4 => skillBoundImageColor4, 
			5 => skillBoundImageColor5, 
			6 => skillBoundImageColor6, 
			7 => skillBoundImageColor7, 
			8 => skillBoundImageColor8, 
			9 => skillBoundImageColor9, 
			10 => skillBoundImageColor10, 
			11 => skillBoundImageColor11, 
			12 => skillBoundImageColor12, 
			13 => skillBoundImageColor13, 
			_ => Color.white, 
		};
	}

	public void SetskillBoundImageColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			skillBoundImageColor1 = value;
			break;
		case 2:
			skillBoundImageColor2 = value;
			break;
		case 3:
			skillBoundImageColor3 = value;
			break;
		case 4:
			skillBoundImageColor4 = value;
			break;
		case 5:
			skillBoundImageColor5 = value;
			break;
		case 6:
			skillBoundImageColor6 = value;
			break;
		case 7:
			skillBoundImageColor7 = value;
			break;
		case 8:
			skillBoundImageColor8 = value;
			break;
		case 9:
			skillBoundImageColor9 = value;
			break;
		case 10:
			skillBoundImageColor10 = value;
			break;
		case 11:
			skillBoundImageColor11 = value;
			break;
		case 12:
			skillBoundImageColor12 = value;
			break;
		case 13:
			skillBoundImageColor13 = value;
			break;
		}
	}

	public bool GetskilllvShow(int index)
	{
		return index switch
		{
			1 => skilllvShow1, 
			2 => skilllvShow2, 
			3 => skilllvShow3, 
			4 => skilllvShow4, 
			5 => skilllvShow5, 
			6 => skilllvShow6, 
			7 => skilllvShow7, 
			8 => skilllvShow8, 
			9 => skilllvShow9, 
			10 => skilllvShow10, 
			11 => skilllvShow11, 
			12 => skilllvShow12, 
			13 => skilllvShow13, 
			_ => false, 
		};
	}

	public void SetskilllvShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skilllvShow1 = value;
			break;
		case 2:
			skilllvShow2 = value;
			break;
		case 3:
			skilllvShow3 = value;
			break;
		case 4:
			skilllvShow4 = value;
			break;
		case 5:
			skilllvShow5 = value;
			break;
		case 6:
			skilllvShow6 = value;
			break;
		case 7:
			skilllvShow7 = value;
			break;
		case 8:
			skilllvShow8 = value;
			break;
		case 9:
			skilllvShow9 = value;
			break;
		case 10:
			skilllvShow10 = value;
			break;
		case 11:
			skilllvShow11 = value;
			break;
		case 12:
			skilllvShow12 = value;
			break;
		case 13:
			skilllvShow13 = value;
			break;
		}
	}

	public string GetskilllvString(int index)
	{
		return index switch
		{
			1 => skilllvString1, 
			2 => skilllvString2, 
			3 => skilllvString3, 
			4 => skilllvString4, 
			5 => skilllvString5, 
			6 => skilllvString6, 
			7 => skilllvString7, 
			8 => skilllvString8, 
			9 => skilllvString9, 
			10 => skilllvString10, 
			11 => skilllvString11, 
			12 => skilllvString12, 
			13 => skilllvString13, 
			_ => null, 
		};
	}

	public void SetskilllvString(int index, string value)
	{
		switch (index)
		{
		case 1:
			skilllvString1 = value;
			break;
		case 2:
			skilllvString2 = value;
			break;
		case 3:
			skilllvString3 = value;
			break;
		case 4:
			skilllvString4 = value;
			break;
		case 5:
			skilllvString5 = value;
			break;
		case 6:
			skilllvString6 = value;
			break;
		case 7:
			skilllvString7 = value;
			break;
		case 8:
			skilllvString8 = value;
			break;
		case 9:
			skilllvString9 = value;
			break;
		case 10:
			skilllvString10 = value;
			break;
		case 11:
			skilllvString11 = value;
			break;
		case 12:
			skilllvString12 = value;
			break;
		case 13:
			skilllvString13 = value;
			break;
		}
	}

	public Color GetskilllvTextcolor(int index)
	{
		return index switch
		{
			1 => skilllvTextcolor1, 
			2 => skilllvTextcolor2, 
			3 => skilllvTextcolor3, 
			4 => skilllvTextcolor4, 
			5 => skilllvTextcolor5, 
			6 => skilllvTextcolor6, 
			7 => skilllvTextcolor7, 
			8 => skilllvTextcolor8, 
			9 => skilllvTextcolor9, 
			10 => skilllvTextcolor10, 
			11 => skilllvTextcolor11, 
			12 => skilllvTextcolor12, 
			13 => skilllvTextcolor13, 
			_ => Color.white, 
		};
	}

	public void SetskilllvTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			skilllvTextcolor1 = value;
			break;
		case 2:
			skilllvTextcolor2 = value;
			break;
		case 3:
			skilllvTextcolor3 = value;
			break;
		case 4:
			skilllvTextcolor4 = value;
			break;
		case 5:
			skilllvTextcolor5 = value;
			break;
		case 6:
			skilllvTextcolor6 = value;
			break;
		case 7:
			skilllvTextcolor7 = value;
			break;
		case 8:
			skilllvTextcolor8 = value;
			break;
		case 9:
			skilllvTextcolor9 = value;
			break;
		case 10:
			skilllvTextcolor10 = value;
			break;
		case 11:
			skilllvTextcolor11 = value;
			break;
		case 12:
			skilllvTextcolor12 = value;
			break;
		case 13:
			skilllvTextcolor13 = value;
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
