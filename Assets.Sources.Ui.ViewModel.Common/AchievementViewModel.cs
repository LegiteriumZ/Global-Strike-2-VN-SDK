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
public class AchievementViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oAchievementItem1;

	private GameObject _oAchievementItem2;

	private GameObject _oAchievementItem3;

	private GameObject _oAchievementItem4;

	private GameObject _oAchievementItem5;

	private CanvasGroup _oAchievementItemCanvasGroup1;

	private CanvasGroup _oAchievementItemCanvasGroup2;

	private CanvasGroup _oAchievementItemCanvasGroup3;

	private CanvasGroup _oAchievementItemCanvasGroup4;

	private CanvasGroup _oAchievementItemCanvasGroup5;

	private GameObject _oBack1;

	private GameObject _oBack2;

	private GameObject _oBack3;

	private GameObject _oBack4;

	private GameObject _oBack5;

	private Image _oBackImage1;

	private Image _oBackImage2;

	private Image _oBackImage3;

	private Image _oBackImage4;

	private Image _oBackImage5;

	private GameObject _oTaskName1;

	private GameObject _oTaskName2;

	private GameObject _oTaskName3;

	private GameObject _oTaskName4;

	private GameObject _oTaskName5;

	private Text _oTaskNameText1;

	private Text _oTaskNameText2;

	private Text _oTaskNameText3;

	private Text _oTaskNameText4;

	private Text _oTaskNameText5;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private GameObject _oProgress4;

	private GameObject _oProgress5;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private Image _oProgressImage4;

	private Image _oProgressImage5;

	private GameObject _oCurr1;

	private GameObject _oCurr2;

	private GameObject _oCurr3;

	private GameObject _oCurr4;

	private GameObject _oCurr5;

	private Text _oCurrText1;

	private Text _oCurrText2;

	private Text _oCurrText3;

	private Text _oCurrText4;

	private Text _oCurrText5;

	private GameObject _oTotal1;

	private GameObject _oTotal2;

	private GameObject _oTotal3;

	private GameObject _oTotal4;

	private GameObject _oTotal5;

	private Text _oTotalText1;

	private Text _oTotalText2;

	private Text _oTotalText3;

	private Text _oTotalText4;

	private Text _oTotalText5;

	private GameObject _oMask1;

	private GameObject _oMask2;

	private GameObject _oMask3;

	private GameObject _oMask4;

	private GameObject _oMask5;

	private Image _oMaskImage1;

	private Image _oMaskImage2;

	private Image _oMaskImage3;

	private Image _oMaskImage4;

	private Image _oMaskImage5;

	private GameObject _oEffect1;

	private GameObject _oEffect2;

	private GameObject _oEffect3;

	private GameObject _oEffect4;

	private GameObject _oEffect5;

	private RectTransform _oEffectRectTransform1;

	private RectTransform _oEffectRectTransform2;

	private RectTransform _oEffectRectTransform3;

	private RectTransform _oEffectRectTransform4;

	private RectTransform _oEffectRectTransform5;

	private Image _oEffectImage1;

	private Image _oEffectImage2;

	private Image _oEffectImage3;

	private Image _oEffectImage4;

	private Image _oEffectImage5;

	private GameObject _oLimitedTimeReward;

	private RectTransform _oLimitedTimeRewardRectTransform;

	private Image _oLimitedTimeRewardImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Achievement";

	public bool AchievementItemShow1
	{
		get
		{
			if (_oAchievementItem1 != null)
			{
				return _oAchievementItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AchievementItemShow1 != value && _oAchievementItem1 != null)
			{
				_oAchievementItem1.SetObjectActive(value);
			}
		}
	}

	public bool AchievementItemShow2
	{
		get
		{
			if (_oAchievementItem2 != null)
			{
				return _oAchievementItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AchievementItemShow2 != value && _oAchievementItem2 != null)
			{
				_oAchievementItem2.SetObjectActive(value);
			}
		}
	}

	public bool AchievementItemShow3
	{
		get
		{
			if (_oAchievementItem3 != null)
			{
				return _oAchievementItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AchievementItemShow3 != value && _oAchievementItem3 != null)
			{
				_oAchievementItem3.SetObjectActive(value);
			}
		}
	}

	public bool AchievementItemShow4
	{
		get
		{
			if (_oAchievementItem4 != null)
			{
				return _oAchievementItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AchievementItemShow4 != value && _oAchievementItem4 != null)
			{
				_oAchievementItem4.SetObjectActive(value);
			}
		}
	}

	public bool AchievementItemShow5
	{
		get
		{
			if (_oAchievementItem5 != null)
			{
				return _oAchievementItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AchievementItemShow5 != value && _oAchievementItem5 != null)
			{
				_oAchievementItem5.SetObjectActive(value);
			}
		}
	}

	public float AchievementItemAlpha1
	{
		get
		{
			if (_oAchievementItemCanvasGroup1 != null)
			{
				return _oAchievementItemCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (AchievementItemAlpha1 != value && _oAchievementItemCanvasGroup1 != null)
			{
				_oAchievementItemCanvasGroup1.alpha = value;
			}
		}
	}

	public float AchievementItemAlpha2
	{
		get
		{
			if (_oAchievementItemCanvasGroup2 != null)
			{
				return _oAchievementItemCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (AchievementItemAlpha2 != value && _oAchievementItemCanvasGroup2 != null)
			{
				_oAchievementItemCanvasGroup2.alpha = value;
			}
		}
	}

	public float AchievementItemAlpha3
	{
		get
		{
			if (_oAchievementItemCanvasGroup3 != null)
			{
				return _oAchievementItemCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (AchievementItemAlpha3 != value && _oAchievementItemCanvasGroup3 != null)
			{
				_oAchievementItemCanvasGroup3.alpha = value;
			}
		}
	}

	public float AchievementItemAlpha4
	{
		get
		{
			if (_oAchievementItemCanvasGroup4 != null)
			{
				return _oAchievementItemCanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (AchievementItemAlpha4 != value && _oAchievementItemCanvasGroup4 != null)
			{
				_oAchievementItemCanvasGroup4.alpha = value;
			}
		}
	}

	public float AchievementItemAlpha5
	{
		get
		{
			if (_oAchievementItemCanvasGroup5 != null)
			{
				return _oAchievementItemCanvasGroup5.alpha;
			}
			return 0f;
		}
		set
		{
			if (AchievementItemAlpha5 != value && _oAchievementItemCanvasGroup5 != null)
			{
				_oAchievementItemCanvasGroup5.alpha = value;
			}
		}
	}

	public Sprite BackSprite1
	{
		get
		{
			if (_oBackImage1 != null)
			{
				return _oBackImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite1 != value && _oBackImage1 != null)
			{
				_oBackImage1.sprite = value;
			}
		}
	}

	public Sprite BackSprite2
	{
		get
		{
			if (_oBackImage2 != null)
			{
				return _oBackImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite2 != value && _oBackImage2 != null)
			{
				_oBackImage2.sprite = value;
			}
		}
	}

	public Sprite BackSprite3
	{
		get
		{
			if (_oBackImage3 != null)
			{
				return _oBackImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite3 != value && _oBackImage3 != null)
			{
				_oBackImage3.sprite = value;
			}
		}
	}

	public Sprite BackSprite4
	{
		get
		{
			if (_oBackImage4 != null)
			{
				return _oBackImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite4 != value && _oBackImage4 != null)
			{
				_oBackImage4.sprite = value;
			}
		}
	}

	public Sprite BackSprite5
	{
		get
		{
			if (_oBackImage5 != null)
			{
				return _oBackImage5.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite5 != value && _oBackImage5 != null)
			{
				_oBackImage5.sprite = value;
			}
		}
	}

	public Image BackImage1
	{
		get
		{
			if (_oBackImage1 != null)
			{
				return _oBackImage1;
			}
			return null;
		}
		set
		{
			if (BackImage1 != value && _oBackImage1 != null)
			{
				_oBackImage1 = value;
			}
		}
	}

	public Image BackImage2
	{
		get
		{
			if (_oBackImage2 != null)
			{
				return _oBackImage2;
			}
			return null;
		}
		set
		{
			if (BackImage2 != value && _oBackImage2 != null)
			{
				_oBackImage2 = value;
			}
		}
	}

	public Image BackImage3
	{
		get
		{
			if (_oBackImage3 != null)
			{
				return _oBackImage3;
			}
			return null;
		}
		set
		{
			if (BackImage3 != value && _oBackImage3 != null)
			{
				_oBackImage3 = value;
			}
		}
	}

	public Image BackImage4
	{
		get
		{
			if (_oBackImage4 != null)
			{
				return _oBackImage4;
			}
			return null;
		}
		set
		{
			if (BackImage4 != value && _oBackImage4 != null)
			{
				_oBackImage4 = value;
			}
		}
	}

	public Image BackImage5
	{
		get
		{
			if (_oBackImage5 != null)
			{
				return _oBackImage5;
			}
			return null;
		}
		set
		{
			if (BackImage5 != value && _oBackImage5 != null)
			{
				_oBackImage5 = value;
			}
		}
	}

	public string TaskNameString1
	{
		get
		{
			if (_oTaskNameText1 != null)
			{
				return _oTaskNameText1.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString1 != value && _oTaskNameText1 != null)
			{
				_oTaskNameText1.text = value;
			}
		}
	}

	public string TaskNameString2
	{
		get
		{
			if (_oTaskNameText2 != null)
			{
				return _oTaskNameText2.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString2 != value && _oTaskNameText2 != null)
			{
				_oTaskNameText2.text = value;
			}
		}
	}

	public string TaskNameString3
	{
		get
		{
			if (_oTaskNameText3 != null)
			{
				return _oTaskNameText3.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString3 != value && _oTaskNameText3 != null)
			{
				_oTaskNameText3.text = value;
			}
		}
	}

	public string TaskNameString4
	{
		get
		{
			if (_oTaskNameText4 != null)
			{
				return _oTaskNameText4.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString4 != value && _oTaskNameText4 != null)
			{
				_oTaskNameText4.text = value;
			}
		}
	}

	public string TaskNameString5
	{
		get
		{
			if (_oTaskNameText5 != null)
			{
				return _oTaskNameText5.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString5 != value && _oTaskNameText5 != null)
			{
				_oTaskNameText5.text = value;
			}
		}
	}

	public Sprite ProgressSprite1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite5
	{
		get
		{
			if (_oProgressImage5 != null)
			{
				return _oProgressImage5.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite5 != value && _oProgressImage5 != null)
			{
				_oProgressImage5.sprite = value;
			}
		}
	}

	public float ProgressFillamount1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount5
	{
		get
		{
			if (_oProgressImage5 != null)
			{
				return _oProgressImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount5 != value && _oProgressImage5 != null)
			{
				_oProgressImage5.fillAmount = value;
			}
		}
	}

	public Color ProgressColor1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (ProgressColor1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.color = value;
			}
		}
	}

	public Color ProgressColor2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (ProgressColor2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.color = value;
			}
		}
	}

	public Color ProgressColor3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (ProgressColor3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.color = value;
			}
		}
	}

	public Color ProgressColor4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (ProgressColor4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.color = value;
			}
		}
	}

	public Color ProgressColor5
	{
		get
		{
			if (_oProgressImage5 != null)
			{
				return _oProgressImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (ProgressColor5 != value && _oProgressImage5 != null)
			{
				_oProgressImage5.color = value;
			}
		}
	}

	public string CurrString1
	{
		get
		{
			if (_oCurrText1 != null)
			{
				return _oCurrText1.text;
			}
			return null;
		}
		set
		{
			if (CurrString1 != value && _oCurrText1 != null)
			{
				_oCurrText1.text = value;
			}
		}
	}

	public string CurrString2
	{
		get
		{
			if (_oCurrText2 != null)
			{
				return _oCurrText2.text;
			}
			return null;
		}
		set
		{
			if (CurrString2 != value && _oCurrText2 != null)
			{
				_oCurrText2.text = value;
			}
		}
	}

	public string CurrString3
	{
		get
		{
			if (_oCurrText3 != null)
			{
				return _oCurrText3.text;
			}
			return null;
		}
		set
		{
			if (CurrString3 != value && _oCurrText3 != null)
			{
				_oCurrText3.text = value;
			}
		}
	}

	public string CurrString4
	{
		get
		{
			if (_oCurrText4 != null)
			{
				return _oCurrText4.text;
			}
			return null;
		}
		set
		{
			if (CurrString4 != value && _oCurrText4 != null)
			{
				_oCurrText4.text = value;
			}
		}
	}

	public string CurrString5
	{
		get
		{
			if (_oCurrText5 != null)
			{
				return _oCurrText5.text;
			}
			return null;
		}
		set
		{
			if (CurrString5 != value && _oCurrText5 != null)
			{
				_oCurrText5.text = value;
			}
		}
	}

	public string TotalString1
	{
		get
		{
			if (_oTotalText1 != null)
			{
				return _oTotalText1.text;
			}
			return null;
		}
		set
		{
			if (TotalString1 != value && _oTotalText1 != null)
			{
				_oTotalText1.text = value;
			}
		}
	}

	public string TotalString2
	{
		get
		{
			if (_oTotalText2 != null)
			{
				return _oTotalText2.text;
			}
			return null;
		}
		set
		{
			if (TotalString2 != value && _oTotalText2 != null)
			{
				_oTotalText2.text = value;
			}
		}
	}

	public string TotalString3
	{
		get
		{
			if (_oTotalText3 != null)
			{
				return _oTotalText3.text;
			}
			return null;
		}
		set
		{
			if (TotalString3 != value && _oTotalText3 != null)
			{
				_oTotalText3.text = value;
			}
		}
	}

	public string TotalString4
	{
		get
		{
			if (_oTotalText4 != null)
			{
				return _oTotalText4.text;
			}
			return null;
		}
		set
		{
			if (TotalString4 != value && _oTotalText4 != null)
			{
				_oTotalText4.text = value;
			}
		}
	}

	public string TotalString5
	{
		get
		{
			if (_oTotalText5 != null)
			{
				return _oTotalText5.text;
			}
			return null;
		}
		set
		{
			if (TotalString5 != value && _oTotalText5 != null)
			{
				_oTotalText5.text = value;
			}
		}
	}

	public Sprite MaskSprite1
	{
		get
		{
			if (_oMaskImage1 != null)
			{
				return _oMaskImage1.sprite;
			}
			return null;
		}
		set
		{
			if (MaskSprite1 != value && _oMaskImage1 != null)
			{
				_oMaskImage1.sprite = value;
			}
		}
	}

	public Sprite MaskSprite2
	{
		get
		{
			if (_oMaskImage2 != null)
			{
				return _oMaskImage2.sprite;
			}
			return null;
		}
		set
		{
			if (MaskSprite2 != value && _oMaskImage2 != null)
			{
				_oMaskImage2.sprite = value;
			}
		}
	}

	public Sprite MaskSprite3
	{
		get
		{
			if (_oMaskImage3 != null)
			{
				return _oMaskImage3.sprite;
			}
			return null;
		}
		set
		{
			if (MaskSprite3 != value && _oMaskImage3 != null)
			{
				_oMaskImage3.sprite = value;
			}
		}
	}

	public Sprite MaskSprite4
	{
		get
		{
			if (_oMaskImage4 != null)
			{
				return _oMaskImage4.sprite;
			}
			return null;
		}
		set
		{
			if (MaskSprite4 != value && _oMaskImage4 != null)
			{
				_oMaskImage4.sprite = value;
			}
		}
	}

	public Sprite MaskSprite5
	{
		get
		{
			if (_oMaskImage5 != null)
			{
				return _oMaskImage5.sprite;
			}
			return null;
		}
		set
		{
			if (MaskSprite5 != value && _oMaskImage5 != null)
			{
				_oMaskImage5.sprite = value;
			}
		}
	}

	public float MaskFillamount1
	{
		get
		{
			if (_oMaskImage1 != null)
			{
				return _oMaskImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount1 != value && _oMaskImage1 != null)
			{
				_oMaskImage1.fillAmount = value;
			}
		}
	}

	public float MaskFillamount2
	{
		get
		{
			if (_oMaskImage2 != null)
			{
				return _oMaskImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount2 != value && _oMaskImage2 != null)
			{
				_oMaskImage2.fillAmount = value;
			}
		}
	}

	public float MaskFillamount3
	{
		get
		{
			if (_oMaskImage3 != null)
			{
				return _oMaskImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount3 != value && _oMaskImage3 != null)
			{
				_oMaskImage3.fillAmount = value;
			}
		}
	}

	public float MaskFillamount4
	{
		get
		{
			if (_oMaskImage4 != null)
			{
				return _oMaskImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount4 != value && _oMaskImage4 != null)
			{
				_oMaskImage4.fillAmount = value;
			}
		}
	}

	public float MaskFillamount5
	{
		get
		{
			if (_oMaskImage5 != null)
			{
				return _oMaskImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount5 != value && _oMaskImage5 != null)
			{
				_oMaskImage5.fillAmount = value;
			}
		}
	}

	public Vector3 EffectPosition1
	{
		get
		{
			if (_oEffectRectTransform1 != null)
			{
				return _oEffectRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition1 != value && _oEffectRectTransform1 != null)
			{
				_oEffectRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 EffectPosition2
	{
		get
		{
			if (_oEffectRectTransform2 != null)
			{
				return _oEffectRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition2 != value && _oEffectRectTransform2 != null)
			{
				_oEffectRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 EffectPosition3
	{
		get
		{
			if (_oEffectRectTransform3 != null)
			{
				return _oEffectRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition3 != value && _oEffectRectTransform3 != null)
			{
				_oEffectRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 EffectPosition4
	{
		get
		{
			if (_oEffectRectTransform4 != null)
			{
				return _oEffectRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition4 != value && _oEffectRectTransform4 != null)
			{
				_oEffectRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 EffectPosition5
	{
		get
		{
			if (_oEffectRectTransform5 != null)
			{
				return _oEffectRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition5 != value && _oEffectRectTransform5 != null)
			{
				_oEffectRectTransform5.localPosition = value;
			}
		}
	}

	public Sprite EffectSprite1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1.sprite = value;
			}
		}
	}

	public Sprite EffectSprite2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2.sprite = value;
			}
		}
	}

	public Sprite EffectSprite3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3.sprite = value;
			}
		}
	}

	public Sprite EffectSprite4
	{
		get
		{
			if (_oEffectImage4 != null)
			{
				return _oEffectImage4.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite4 != value && _oEffectImage4 != null)
			{
				_oEffectImage4.sprite = value;
			}
		}
	}

	public Sprite EffectSprite5
	{
		get
		{
			if (_oEffectImage5 != null)
			{
				return _oEffectImage5.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite5 != value && _oEffectImage5 != null)
			{
				_oEffectImage5.sprite = value;
			}
		}
	}

	public bool LimitedTimeRewardShow
	{
		get
		{
			if (_oLimitedTimeReward != null)
			{
				return _oLimitedTimeReward.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LimitedTimeRewardShow != value && _oLimitedTimeReward != null)
			{
				_oLimitedTimeReward.SetObjectActive(value);
			}
		}
	}

	public Vector3 LimitedTimeRewardPosition
	{
		get
		{
			if (_oLimitedTimeRewardRectTransform != null)
			{
				return _oLimitedTimeRewardRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LimitedTimeRewardPosition != value && _oLimitedTimeRewardRectTransform != null)
			{
				_oLimitedTimeRewardRectTransform.localPosition = value;
			}
		}
	}

	public Sprite LimitedTimeRewardSprite
	{
		get
		{
			if (_oLimitedTimeRewardImage != null)
			{
				return _oLimitedTimeRewardImage.sprite;
			}
			return null;
		}
		set
		{
			if (LimitedTimeRewardSprite != value && _oLimitedTimeRewardImage != null)
			{
				_oLimitedTimeRewardImage.sprite = value;
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
			case "AchievementItem1":
				_oAchievementItem1 = transform.gameObject;
				_oAchievementItemCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AchievementItem2":
				_oAchievementItem2 = transform.gameObject;
				_oAchievementItemCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AchievementItem3":
				_oAchievementItem3 = transform.gameObject;
				_oAchievementItemCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AchievementItem4":
				_oAchievementItem4 = transform.gameObject;
				_oAchievementItemCanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AchievementItem5":
				_oAchievementItem5 = transform.gameObject;
				_oAchievementItemCanvasGroup5 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Back1":
				_oBack1 = transform.gameObject;
				_oBackImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Back2":
				_oBack2 = transform.gameObject;
				_oBackImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Back3":
				_oBack3 = transform.gameObject;
				_oBackImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Back4":
				_oBack4 = transform.gameObject;
				_oBackImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Back5":
				_oBack5 = transform.gameObject;
				_oBackImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "TaskName1":
				_oTaskName1 = transform.gameObject;
				_oTaskNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName2":
				_oTaskName2 = transform.gameObject;
				_oTaskNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName3":
				_oTaskName3 = transform.gameObject;
				_oTaskNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName4":
				_oTaskName4 = transform.gameObject;
				_oTaskNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName5":
				_oTaskName5 = transform.gameObject;
				_oTaskNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Progress1":
				_oProgress1 = transform.gameObject;
				_oProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress2":
				_oProgress2 = transform.gameObject;
				_oProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress3":
				_oProgress3 = transform.gameObject;
				_oProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress4":
				_oProgress4 = transform.gameObject;
				_oProgressImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress5":
				_oProgress5 = transform.gameObject;
				_oProgressImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Curr1":
				_oCurr1 = transform.gameObject;
				_oCurrText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Curr2":
				_oCurr2 = transform.gameObject;
				_oCurrText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Curr3":
				_oCurr3 = transform.gameObject;
				_oCurrText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Curr4":
				_oCurr4 = transform.gameObject;
				_oCurrText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Curr5":
				_oCurr5 = transform.gameObject;
				_oCurrText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Total1":
				_oTotal1 = transform.gameObject;
				_oTotalText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Total2":
				_oTotal2 = transform.gameObject;
				_oTotalText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Total3":
				_oTotal3 = transform.gameObject;
				_oTotalText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Total4":
				_oTotal4 = transform.gameObject;
				_oTotalText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Total5":
				_oTotal5 = transform.gameObject;
				_oTotalText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Mask1":
				_oMask1 = transform.gameObject;
				_oMaskImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask2":
				_oMask2 = transform.gameObject;
				_oMaskImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask3":
				_oMask3 = transform.gameObject;
				_oMaskImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask4":
				_oMask4 = transform.gameObject;
				_oMaskImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask5":
				_oMask5 = transform.gameObject;
				_oMaskImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect1":
				_oEffect1 = transform.gameObject;
				_oEffectRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect2":
				_oEffect2 = transform.gameObject;
				_oEffectRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect3":
				_oEffect3 = transform.gameObject;
				_oEffectRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect4":
				_oEffect4 = transform.gameObject;
				_oEffectRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect5":
				_oEffect5 = transform.gameObject;
				_oEffectRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "LimitedTimeReward":
				_oLimitedTimeReward = transform.gameObject;
				_oLimitedTimeRewardRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oLimitedTimeRewardImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetAchievementItemShow(int index)
	{
		return index switch
		{
			1 => AchievementItemShow1, 
			2 => AchievementItemShow2, 
			3 => AchievementItemShow3, 
			4 => AchievementItemShow4, 
			5 => AchievementItemShow5, 
			_ => false, 
		};
	}

	public void SetAchievementItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AchievementItemShow1 = value;
			break;
		case 2:
			AchievementItemShow2 = value;
			break;
		case 3:
			AchievementItemShow3 = value;
			break;
		case 4:
			AchievementItemShow4 = value;
			break;
		case 5:
			AchievementItemShow5 = value;
			break;
		}
	}

	public float GetAchievementItemAlpha(int index)
	{
		return index switch
		{
			1 => AchievementItemAlpha1, 
			2 => AchievementItemAlpha2, 
			3 => AchievementItemAlpha3, 
			4 => AchievementItemAlpha4, 
			5 => AchievementItemAlpha5, 
			_ => 0f, 
		};
	}

	public void SetAchievementItemAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			AchievementItemAlpha1 = value;
			break;
		case 2:
			AchievementItemAlpha2 = value;
			break;
		case 3:
			AchievementItemAlpha3 = value;
			break;
		case 4:
			AchievementItemAlpha4 = value;
			break;
		case 5:
			AchievementItemAlpha5 = value;
			break;
		}
	}

	public Sprite GetBackSprite(int index)
	{
		return index switch
		{
			1 => BackSprite1, 
			2 => BackSprite2, 
			3 => BackSprite3, 
			4 => BackSprite4, 
			5 => BackSprite5, 
			_ => null, 
		};
	}

	public void SetBackSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BackSprite1 = value;
			break;
		case 2:
			BackSprite2 = value;
			break;
		case 3:
			BackSprite3 = value;
			break;
		case 4:
			BackSprite4 = value;
			break;
		case 5:
			BackSprite5 = value;
			break;
		}
	}

	public Image GetBackImage(int index)
	{
		return index switch
		{
			1 => BackImage1, 
			2 => BackImage2, 
			3 => BackImage3, 
			4 => BackImage4, 
			5 => BackImage5, 
			_ => null, 
		};
	}

	public void SetBackImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			BackImage1 = value;
			break;
		case 2:
			BackImage2 = value;
			break;
		case 3:
			BackImage3 = value;
			break;
		case 4:
			BackImage4 = value;
			break;
		case 5:
			BackImage5 = value;
			break;
		}
	}

	public void BackNtvsize1()
	{
		if (_oBackImage1 != null)
		{
			_oBackImage1.SetNativeSize();
		}
	}

	public void BackNtvsize2()
	{
		if (_oBackImage2 != null)
		{
			_oBackImage2.SetNativeSize();
		}
	}

	public void BackNtvsize3()
	{
		if (_oBackImage3 != null)
		{
			_oBackImage3.SetNativeSize();
		}
	}

	public void BackNtvsize4()
	{
		if (_oBackImage4 != null)
		{
			_oBackImage4.SetNativeSize();
		}
	}

	public void BackNtvsize5()
	{
		if (_oBackImage5 != null)
		{
			_oBackImage5.SetNativeSize();
		}
	}

	public void CallBackNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			BackNtvsize1();
			break;
		case 2:
			BackNtvsize2();
			break;
		case 3:
			BackNtvsize3();
			break;
		case 4:
			BackNtvsize4();
			break;
		case 5:
			BackNtvsize5();
			break;
		}
	}

	public string GetTaskNameString(int index)
	{
		return index switch
		{
			1 => TaskNameString1, 
			2 => TaskNameString2, 
			3 => TaskNameString3, 
			4 => TaskNameString4, 
			5 => TaskNameString5, 
			_ => null, 
		};
	}

	public void SetTaskNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TaskNameString1 = value;
			break;
		case 2:
			TaskNameString2 = value;
			break;
		case 3:
			TaskNameString3 = value;
			break;
		case 4:
			TaskNameString4 = value;
			break;
		case 5:
			TaskNameString5 = value;
			break;
		}
	}

	public Sprite GetProgressSprite(int index)
	{
		return index switch
		{
			1 => ProgressSprite1, 
			2 => ProgressSprite2, 
			3 => ProgressSprite3, 
			4 => ProgressSprite4, 
			5 => ProgressSprite5, 
			_ => null, 
		};
	}

	public void SetProgressSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ProgressSprite1 = value;
			break;
		case 2:
			ProgressSprite2 = value;
			break;
		case 3:
			ProgressSprite3 = value;
			break;
		case 4:
			ProgressSprite4 = value;
			break;
		case 5:
			ProgressSprite5 = value;
			break;
		}
	}

	public float GetProgressFillamount(int index)
	{
		return index switch
		{
			1 => ProgressFillamount1, 
			2 => ProgressFillamount2, 
			3 => ProgressFillamount3, 
			4 => ProgressFillamount4, 
			5 => ProgressFillamount5, 
			_ => 0f, 
		};
	}

	public void SetProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			ProgressFillamount1 = value;
			break;
		case 2:
			ProgressFillamount2 = value;
			break;
		case 3:
			ProgressFillamount3 = value;
			break;
		case 4:
			ProgressFillamount4 = value;
			break;
		case 5:
			ProgressFillamount5 = value;
			break;
		}
	}

	public Color GetProgressColor(int index)
	{
		return index switch
		{
			1 => ProgressColor1, 
			2 => ProgressColor2, 
			3 => ProgressColor3, 
			4 => ProgressColor4, 
			5 => ProgressColor5, 
			_ => Color.white, 
		};
	}

	public void SetProgressColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			ProgressColor1 = value;
			break;
		case 2:
			ProgressColor2 = value;
			break;
		case 3:
			ProgressColor3 = value;
			break;
		case 4:
			ProgressColor4 = value;
			break;
		case 5:
			ProgressColor5 = value;
			break;
		}
	}

	public string GetCurrString(int index)
	{
		return index switch
		{
			1 => CurrString1, 
			2 => CurrString2, 
			3 => CurrString3, 
			4 => CurrString4, 
			5 => CurrString5, 
			_ => null, 
		};
	}

	public void SetCurrString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CurrString1 = value;
			break;
		case 2:
			CurrString2 = value;
			break;
		case 3:
			CurrString3 = value;
			break;
		case 4:
			CurrString4 = value;
			break;
		case 5:
			CurrString5 = value;
			break;
		}
	}

	public string GetTotalString(int index)
	{
		return index switch
		{
			1 => TotalString1, 
			2 => TotalString2, 
			3 => TotalString3, 
			4 => TotalString4, 
			5 => TotalString5, 
			_ => null, 
		};
	}

	public void SetTotalString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TotalString1 = value;
			break;
		case 2:
			TotalString2 = value;
			break;
		case 3:
			TotalString3 = value;
			break;
		case 4:
			TotalString4 = value;
			break;
		case 5:
			TotalString5 = value;
			break;
		}
	}

	public Sprite GetMaskSprite(int index)
	{
		return index switch
		{
			1 => MaskSprite1, 
			2 => MaskSprite2, 
			3 => MaskSprite3, 
			4 => MaskSprite4, 
			5 => MaskSprite5, 
			_ => null, 
		};
	}

	public void SetMaskSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			MaskSprite1 = value;
			break;
		case 2:
			MaskSprite2 = value;
			break;
		case 3:
			MaskSprite3 = value;
			break;
		case 4:
			MaskSprite4 = value;
			break;
		case 5:
			MaskSprite5 = value;
			break;
		}
	}

	public float GetMaskFillamount(int index)
	{
		return index switch
		{
			1 => MaskFillamount1, 
			2 => MaskFillamount2, 
			3 => MaskFillamount3, 
			4 => MaskFillamount4, 
			5 => MaskFillamount5, 
			_ => 0f, 
		};
	}

	public void SetMaskFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			MaskFillamount1 = value;
			break;
		case 2:
			MaskFillamount2 = value;
			break;
		case 3:
			MaskFillamount3 = value;
			break;
		case 4:
			MaskFillamount4 = value;
			break;
		case 5:
			MaskFillamount5 = value;
			break;
		}
	}

	public Vector3 GetEffectPosition(int index)
	{
		return index switch
		{
			1 => EffectPosition1, 
			2 => EffectPosition2, 
			3 => EffectPosition3, 
			4 => EffectPosition4, 
			5 => EffectPosition5, 
			_ => Vector3.zero, 
		};
	}

	public void SetEffectPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			EffectPosition1 = value;
			break;
		case 2:
			EffectPosition2 = value;
			break;
		case 3:
			EffectPosition3 = value;
			break;
		case 4:
			EffectPosition4 = value;
			break;
		case 5:
			EffectPosition5 = value;
			break;
		}
	}

	public Sprite GetEffectSprite(int index)
	{
		return index switch
		{
			1 => EffectSprite1, 
			2 => EffectSprite2, 
			3 => EffectSprite3, 
			4 => EffectSprite4, 
			5 => EffectSprite5, 
			_ => null, 
		};
	}

	public void SetEffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			EffectSprite1 = value;
			break;
		case 2:
			EffectSprite2 = value;
			break;
		case 3:
			EffectSprite3 = value;
			break;
		case 4:
			EffectSprite4 = value;
			break;
		case 5:
			EffectSprite5 = value;
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
