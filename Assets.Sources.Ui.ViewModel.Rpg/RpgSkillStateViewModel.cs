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

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgSkillStateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oAbsorbedProgress;

	private Image _oAbsorbedProgressImage;

	private GameObject _oAbsorbedCount;

	private Text _oAbsorbedCountText;

	private GameObject _oEnergyProgress;

	private Image _oEnergyProgressImage;

	private GameObject _oEnergyCount;

	private Text _oEnergyCountText;

	private GameObject _oDragoonSkillIcon;

	private Image _oDragoonSkillIconImage;

	private GameObject _oDragoonSkillMask;

	private Image _oDragoonSkillMaskImage;

	private GameObject _oDragoonSkillTime;

	private Text _oDragoonSkillTimeText;

	private GameObject _oDragoonSkillEffect;

	private Image _oDragoonSkillEffectImage;

	private GameObject _oAwakeSkillIcon;

	private Image _oAwakeSkillIconImage;

	private GameObject _oAwakeSkillMask;

	private Image _oAwakeSkillMaskImage;

	private GameObject _oAwakeSkillTime;

	private Text _oAwakeSkillTimeText;

	private GameObject _oAwakeSkillEffect;

	private Image _oAwakeSkillEffectImage;

	private GameObject _oSkillIcon1;

	private GameObject _oSkillIcon2;

	private GameObject _oSkillIcon3;

	private GameObject _oSkillIcon4;

	private GameObject _oSkillIcon5;

	private GameObject _oSkillIcon6;

	private GameObject _oSkillIcon7;

	private GameObject _oSkillIcon8;

	private Image _oSkillIconImage1;

	private Image _oSkillIconImage2;

	private Image _oSkillIconImage3;

	private Image _oSkillIconImage4;

	private Image _oSkillIconImage5;

	private Image _oSkillIconImage6;

	private Image _oSkillIconImage7;

	private Image _oSkillIconImage8;

	private GameObject _oSkillLv1;

	private GameObject _oSkillLv2;

	private GameObject _oSkillLv3;

	private GameObject _oSkillLv4;

	private GameObject _oSkillLv5;

	private GameObject _oSkillLv6;

	private GameObject _oSkillLv7;

	private GameObject _oSkillLv8;

	private Image _oSkillLvImage1;

	private Image _oSkillLvImage2;

	private Image _oSkillLvImage3;

	private Image _oSkillLvImage4;

	private Image _oSkillLvImage5;

	private Image _oSkillLvImage6;

	private Image _oSkillLvImage7;

	private Image _oSkillLvImage8;

	private GameObject _oSkillUseMpBack1;

	private GameObject _oSkillUseMpBack2;

	private GameObject _oSkillUseMpBack3;

	private GameObject _oSkillUseMpBack4;

	private GameObject _oSkillUseMpBack5;

	private GameObject _oSkillUseMpBack6;

	private GameObject _oSkillUseMpBack7;

	private GameObject _oSkillUseMpBack8;

	private GameObject _oSkillUseMp1;

	private GameObject _oSkillUseMp2;

	private GameObject _oSkillUseMp3;

	private GameObject _oSkillUseMp4;

	private GameObject _oSkillUseMp5;

	private GameObject _oSkillUseMp6;

	private GameObject _oSkillUseMp7;

	private GameObject _oSkillUseMp8;

	private Text _oSkillUseMpText1;

	private Text _oSkillUseMpText2;

	private Text _oSkillUseMpText3;

	private Text _oSkillUseMpText4;

	private Text _oSkillUseMpText5;

	private Text _oSkillUseMpText6;

	private Text _oSkillUseMpText7;

	private Text _oSkillUseMpText8;

	private GameObject _oSkillMask1;

	private GameObject _oSkillMask2;

	private GameObject _oSkillMask3;

	private GameObject _oSkillMask4;

	private GameObject _oSkillMask5;

	private GameObject _oSkillMask6;

	private GameObject _oSkillMask7;

	private GameObject _oSkillMask8;

	private Image _oSkillMaskImage1;

	private Image _oSkillMaskImage2;

	private Image _oSkillMaskImage3;

	private Image _oSkillMaskImage4;

	private Image _oSkillMaskImage5;

	private Image _oSkillMaskImage6;

	private Image _oSkillMaskImage7;

	private Image _oSkillMaskImage8;

	private GameObject _oSkillTime1;

	private GameObject _oSkillTime2;

	private GameObject _oSkillTime3;

	private GameObject _oSkillTime4;

	private GameObject _oSkillTime5;

	private GameObject _oSkillTime6;

	private GameObject _oSkillTime7;

	private GameObject _oSkillTime8;

	private Text _oSkillTimeText1;

	private Text _oSkillTimeText2;

	private Text _oSkillTimeText3;

	private Text _oSkillTimeText4;

	private Text _oSkillTimeText5;

	private Text _oSkillTimeText6;

	private Text _oSkillTimeText7;

	private Text _oSkillTimeText8;

	private GameObject _oSkillType1;

	private GameObject _oSkillType2;

	private GameObject _oSkillType3;

	private GameObject _oSkillType4;

	private GameObject _oSkillType5;

	private GameObject _oSkillType6;

	private GameObject _oSkillType7;

	private GameObject _oSkillType8;

	private Image _oSkillTypeImage1;

	private Image _oSkillTypeImage2;

	private Image _oSkillTypeImage3;

	private Image _oSkillTypeImage4;

	private Image _oSkillTypeImage5;

	private Image _oSkillTypeImage6;

	private Image _oSkillTypeImage7;

	private Image _oSkillTypeImage8;

	private GameObject _oSkillEffect1;

	private GameObject _oSkillEffect2;

	private GameObject _oSkillEffect3;

	private GameObject _oSkillEffect4;

	private GameObject _oSkillEffect5;

	private GameObject _oSkillEffect6;

	private GameObject _oSkillEffect7;

	private GameObject _oSkillEffect8;

	private Image _oSkillEffectImage1;

	private Image _oSkillEffectImage2;

	private Image _oSkillEffectImage3;

	private Image _oSkillEffectImage4;

	private Image _oSkillEffectImage5;

	private Image _oSkillEffectImage6;

	private Image _oSkillEffectImage7;

	private Image _oSkillEffectImage8;

	private GameObject _oFireShow;

	private GameObject _oFireEffect;

	private Image _oFireEffectImage;

	private GameObject _oDragoonBack;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgSkillState";

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

	public float AbsorbedProgressFillamount
	{
		get
		{
			if (_oAbsorbedProgressImage != null)
			{
				return _oAbsorbedProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (AbsorbedProgressFillamount != value && _oAbsorbedProgressImage != null)
			{
				_oAbsorbedProgressImage.fillAmount = value;
			}
		}
	}

	public string AbsorbedCountString
	{
		get
		{
			if (_oAbsorbedCountText != null)
			{
				return _oAbsorbedCountText.text;
			}
			return null;
		}
		set
		{
			if (AbsorbedCountString != value && _oAbsorbedCountText != null)
			{
				_oAbsorbedCountText.text = value;
			}
		}
	}

	public float EnergyProgressFillamount
	{
		get
		{
			if (_oEnergyProgressImage != null)
			{
				return _oEnergyProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EnergyProgressFillamount != value && _oEnergyProgressImage != null)
			{
				_oEnergyProgressImage.fillAmount = value;
			}
		}
	}

	public string EnergyCountString
	{
		get
		{
			if (_oEnergyCountText != null)
			{
				return _oEnergyCountText.text;
			}
			return null;
		}
		set
		{
			if (EnergyCountString != value && _oEnergyCountText != null)
			{
				_oEnergyCountText.text = value;
			}
		}
	}

	public bool DragoonSkillIconShow
	{
		get
		{
			if (_oDragoonSkillIcon != null)
			{
				return _oDragoonSkillIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DragoonSkillIconShow != value && _oDragoonSkillIcon != null)
			{
				_oDragoonSkillIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite DragoonSkillIconSprite
	{
		get
		{
			if (_oDragoonSkillIconImage != null)
			{
				return _oDragoonSkillIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (DragoonSkillIconSprite != value && _oDragoonSkillIconImage != null)
			{
				_oDragoonSkillIconImage.sprite = value;
			}
		}
	}

	public bool DragoonSkillMaskShow
	{
		get
		{
			if (_oDragoonSkillMask != null)
			{
				return _oDragoonSkillMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DragoonSkillMaskShow != value && _oDragoonSkillMask != null)
			{
				_oDragoonSkillMask.SetObjectActive(value);
			}
		}
	}

	public float DragoonSkillMaskFillamount
	{
		get
		{
			if (_oDragoonSkillMaskImage != null)
			{
				return _oDragoonSkillMaskImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (DragoonSkillMaskFillamount != value && _oDragoonSkillMaskImage != null)
			{
				_oDragoonSkillMaskImage.fillAmount = value;
			}
		}
	}

	public string DragoonSkillTimeString
	{
		get
		{
			if (_oDragoonSkillTimeText != null)
			{
				return _oDragoonSkillTimeText.text;
			}
			return null;
		}
		set
		{
			if (DragoonSkillTimeString != value && _oDragoonSkillTimeText != null)
			{
				_oDragoonSkillTimeText.text = value;
			}
		}
	}

	public bool DragoonSkillEffectShow
	{
		get
		{
			if (_oDragoonSkillEffect != null)
			{
				return _oDragoonSkillEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DragoonSkillEffectShow != value && _oDragoonSkillEffect != null)
			{
				_oDragoonSkillEffect.SetObjectActive(value);
			}
		}
	}

	public bool DragoonSkillEffectActualshow
	{
		get
		{
			if (_oDragoonSkillEffect != null)
			{
				return _oDragoonSkillEffect.activeInHierarchy;
			}
			return false;
		}
	}

	public Sprite DragoonSkillEffectSprite
	{
		get
		{
			if (_oDragoonSkillEffectImage != null)
			{
				return _oDragoonSkillEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (DragoonSkillEffectSprite != value && _oDragoonSkillEffectImage != null)
			{
				_oDragoonSkillEffectImage.sprite = value;
			}
		}
	}

	public bool AwakeSkillIconShow
	{
		get
		{
			if (_oAwakeSkillIcon != null)
			{
				return _oAwakeSkillIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AwakeSkillIconShow != value && _oAwakeSkillIcon != null)
			{
				_oAwakeSkillIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite AwakeSkillIconSprite
	{
		get
		{
			if (_oAwakeSkillIconImage != null)
			{
				return _oAwakeSkillIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (AwakeSkillIconSprite != value && _oAwakeSkillIconImage != null)
			{
				_oAwakeSkillIconImage.sprite = value;
			}
		}
	}

	public bool AwakeSkillMaskShow
	{
		get
		{
			if (_oAwakeSkillMask != null)
			{
				return _oAwakeSkillMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AwakeSkillMaskShow != value && _oAwakeSkillMask != null)
			{
				_oAwakeSkillMask.SetObjectActive(value);
			}
		}
	}

	public float AwakeSkillMaskFillamount
	{
		get
		{
			if (_oAwakeSkillMaskImage != null)
			{
				return _oAwakeSkillMaskImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (AwakeSkillMaskFillamount != value && _oAwakeSkillMaskImage != null)
			{
				_oAwakeSkillMaskImage.fillAmount = value;
			}
		}
	}

	public string AwakeSkillTimeString
	{
		get
		{
			if (_oAwakeSkillTimeText != null)
			{
				return _oAwakeSkillTimeText.text;
			}
			return null;
		}
		set
		{
			if (AwakeSkillTimeString != value && _oAwakeSkillTimeText != null)
			{
				_oAwakeSkillTimeText.text = value;
			}
		}
	}

	public bool AwakeSkillEffectShow
	{
		get
		{
			if (_oAwakeSkillEffect != null)
			{
				return _oAwakeSkillEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AwakeSkillEffectShow != value && _oAwakeSkillEffect != null)
			{
				_oAwakeSkillEffect.SetObjectActive(value);
			}
		}
	}

	public bool AwakeSkillEffectActualshow
	{
		get
		{
			if (_oAwakeSkillEffect != null)
			{
				return _oAwakeSkillEffect.activeInHierarchy;
			}
			return false;
		}
	}

	public Sprite AwakeSkillEffectSprite
	{
		get
		{
			if (_oAwakeSkillEffectImage != null)
			{
				return _oAwakeSkillEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (AwakeSkillEffectSprite != value && _oAwakeSkillEffectImage != null)
			{
				_oAwakeSkillEffectImage.sprite = value;
			}
		}
	}

	public bool SkillIconShow1
	{
		get
		{
			if (_oSkillIcon1 != null)
			{
				return _oSkillIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow1 != value && _oSkillIcon1 != null)
			{
				_oSkillIcon1.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow2
	{
		get
		{
			if (_oSkillIcon2 != null)
			{
				return _oSkillIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow2 != value && _oSkillIcon2 != null)
			{
				_oSkillIcon2.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow3
	{
		get
		{
			if (_oSkillIcon3 != null)
			{
				return _oSkillIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow3 != value && _oSkillIcon3 != null)
			{
				_oSkillIcon3.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow4
	{
		get
		{
			if (_oSkillIcon4 != null)
			{
				return _oSkillIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow4 != value && _oSkillIcon4 != null)
			{
				_oSkillIcon4.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow5
	{
		get
		{
			if (_oSkillIcon5 != null)
			{
				return _oSkillIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow5 != value && _oSkillIcon5 != null)
			{
				_oSkillIcon5.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow6
	{
		get
		{
			if (_oSkillIcon6 != null)
			{
				return _oSkillIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow6 != value && _oSkillIcon6 != null)
			{
				_oSkillIcon6.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow7
	{
		get
		{
			if (_oSkillIcon7 != null)
			{
				return _oSkillIcon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow7 != value && _oSkillIcon7 != null)
			{
				_oSkillIcon7.SetObjectActive(value);
			}
		}
	}

	public bool SkillIconShow8
	{
		get
		{
			if (_oSkillIcon8 != null)
			{
				return _oSkillIcon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillIconShow8 != value && _oSkillIcon8 != null)
			{
				_oSkillIcon8.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillIconSprite1
	{
		get
		{
			if (_oSkillIconImage1 != null)
			{
				return _oSkillIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite1 != value && _oSkillIconImage1 != null)
			{
				_oSkillIconImage1.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite2
	{
		get
		{
			if (_oSkillIconImage2 != null)
			{
				return _oSkillIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite2 != value && _oSkillIconImage2 != null)
			{
				_oSkillIconImage2.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite3
	{
		get
		{
			if (_oSkillIconImage3 != null)
			{
				return _oSkillIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite3 != value && _oSkillIconImage3 != null)
			{
				_oSkillIconImage3.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite4
	{
		get
		{
			if (_oSkillIconImage4 != null)
			{
				return _oSkillIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite4 != value && _oSkillIconImage4 != null)
			{
				_oSkillIconImage4.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite5
	{
		get
		{
			if (_oSkillIconImage5 != null)
			{
				return _oSkillIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite5 != value && _oSkillIconImage5 != null)
			{
				_oSkillIconImage5.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite6
	{
		get
		{
			if (_oSkillIconImage6 != null)
			{
				return _oSkillIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite6 != value && _oSkillIconImage6 != null)
			{
				_oSkillIconImage6.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite7
	{
		get
		{
			if (_oSkillIconImage7 != null)
			{
				return _oSkillIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite7 != value && _oSkillIconImage7 != null)
			{
				_oSkillIconImage7.sprite = value;
			}
		}
	}

	public Sprite SkillIconSprite8
	{
		get
		{
			if (_oSkillIconImage8 != null)
			{
				return _oSkillIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (SkillIconSprite8 != value && _oSkillIconImage8 != null)
			{
				_oSkillIconImage8.sprite = value;
			}
		}
	}

	public Image SkillIconImage1
	{
		get
		{
			if (_oSkillIconImage1 != null)
			{
				return _oSkillIconImage1;
			}
			return null;
		}
		set
		{
			if (SkillIconImage1 != value && _oSkillIconImage1 != null)
			{
				_oSkillIconImage1 = value;
			}
		}
	}

	public Image SkillIconImage2
	{
		get
		{
			if (_oSkillIconImage2 != null)
			{
				return _oSkillIconImage2;
			}
			return null;
		}
		set
		{
			if (SkillIconImage2 != value && _oSkillIconImage2 != null)
			{
				_oSkillIconImage2 = value;
			}
		}
	}

	public Image SkillIconImage3
	{
		get
		{
			if (_oSkillIconImage3 != null)
			{
				return _oSkillIconImage3;
			}
			return null;
		}
		set
		{
			if (SkillIconImage3 != value && _oSkillIconImage3 != null)
			{
				_oSkillIconImage3 = value;
			}
		}
	}

	public Image SkillIconImage4
	{
		get
		{
			if (_oSkillIconImage4 != null)
			{
				return _oSkillIconImage4;
			}
			return null;
		}
		set
		{
			if (SkillIconImage4 != value && _oSkillIconImage4 != null)
			{
				_oSkillIconImage4 = value;
			}
		}
	}

	public Image SkillIconImage5
	{
		get
		{
			if (_oSkillIconImage5 != null)
			{
				return _oSkillIconImage5;
			}
			return null;
		}
		set
		{
			if (SkillIconImage5 != value && _oSkillIconImage5 != null)
			{
				_oSkillIconImage5 = value;
			}
		}
	}

	public Image SkillIconImage6
	{
		get
		{
			if (_oSkillIconImage6 != null)
			{
				return _oSkillIconImage6;
			}
			return null;
		}
		set
		{
			if (SkillIconImage6 != value && _oSkillIconImage6 != null)
			{
				_oSkillIconImage6 = value;
			}
		}
	}

	public Image SkillIconImage7
	{
		get
		{
			if (_oSkillIconImage7 != null)
			{
				return _oSkillIconImage7;
			}
			return null;
		}
		set
		{
			if (SkillIconImage7 != value && _oSkillIconImage7 != null)
			{
				_oSkillIconImage7 = value;
			}
		}
	}

	public Image SkillIconImage8
	{
		get
		{
			if (_oSkillIconImage8 != null)
			{
				return _oSkillIconImage8;
			}
			return null;
		}
		set
		{
			if (SkillIconImage8 != value && _oSkillIconImage8 != null)
			{
				_oSkillIconImage8 = value;
			}
		}
	}

	public bool SkillLvShow1
	{
		get
		{
			if (_oSkillLv1 != null)
			{
				return _oSkillLv1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow1 != value && _oSkillLv1 != null)
			{
				_oSkillLv1.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow2
	{
		get
		{
			if (_oSkillLv2 != null)
			{
				return _oSkillLv2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow2 != value && _oSkillLv2 != null)
			{
				_oSkillLv2.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow3
	{
		get
		{
			if (_oSkillLv3 != null)
			{
				return _oSkillLv3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow3 != value && _oSkillLv3 != null)
			{
				_oSkillLv3.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow4
	{
		get
		{
			if (_oSkillLv4 != null)
			{
				return _oSkillLv4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow4 != value && _oSkillLv4 != null)
			{
				_oSkillLv4.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow5
	{
		get
		{
			if (_oSkillLv5 != null)
			{
				return _oSkillLv5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow5 != value && _oSkillLv5 != null)
			{
				_oSkillLv5.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow6
	{
		get
		{
			if (_oSkillLv6 != null)
			{
				return _oSkillLv6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow6 != value && _oSkillLv6 != null)
			{
				_oSkillLv6.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow7
	{
		get
		{
			if (_oSkillLv7 != null)
			{
				return _oSkillLv7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow7 != value && _oSkillLv7 != null)
			{
				_oSkillLv7.SetObjectActive(value);
			}
		}
	}

	public bool SkillLvShow8
	{
		get
		{
			if (_oSkillLv8 != null)
			{
				return _oSkillLv8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillLvShow8 != value && _oSkillLv8 != null)
			{
				_oSkillLv8.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillLvSprite1
	{
		get
		{
			if (_oSkillLvImage1 != null)
			{
				return _oSkillLvImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite1 != value && _oSkillLvImage1 != null)
			{
				_oSkillLvImage1.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite2
	{
		get
		{
			if (_oSkillLvImage2 != null)
			{
				return _oSkillLvImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite2 != value && _oSkillLvImage2 != null)
			{
				_oSkillLvImage2.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite3
	{
		get
		{
			if (_oSkillLvImage3 != null)
			{
				return _oSkillLvImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite3 != value && _oSkillLvImage3 != null)
			{
				_oSkillLvImage3.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite4
	{
		get
		{
			if (_oSkillLvImage4 != null)
			{
				return _oSkillLvImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite4 != value && _oSkillLvImage4 != null)
			{
				_oSkillLvImage4.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite5
	{
		get
		{
			if (_oSkillLvImage5 != null)
			{
				return _oSkillLvImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite5 != value && _oSkillLvImage5 != null)
			{
				_oSkillLvImage5.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite6
	{
		get
		{
			if (_oSkillLvImage6 != null)
			{
				return _oSkillLvImage6.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite6 != value && _oSkillLvImage6 != null)
			{
				_oSkillLvImage6.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite7
	{
		get
		{
			if (_oSkillLvImage7 != null)
			{
				return _oSkillLvImage7.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite7 != value && _oSkillLvImage7 != null)
			{
				_oSkillLvImage7.sprite = value;
			}
		}
	}

	public Sprite SkillLvSprite8
	{
		get
		{
			if (_oSkillLvImage8 != null)
			{
				return _oSkillLvImage8.sprite;
			}
			return null;
		}
		set
		{
			if (SkillLvSprite8 != value && _oSkillLvImage8 != null)
			{
				_oSkillLvImage8.sprite = value;
			}
		}
	}

	public bool SkillUseMpBackShow1
	{
		get
		{
			if (_oSkillUseMpBack1 != null)
			{
				return _oSkillUseMpBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow1 != value && _oSkillUseMpBack1 != null)
			{
				_oSkillUseMpBack1.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow2
	{
		get
		{
			if (_oSkillUseMpBack2 != null)
			{
				return _oSkillUseMpBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow2 != value && _oSkillUseMpBack2 != null)
			{
				_oSkillUseMpBack2.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow3
	{
		get
		{
			if (_oSkillUseMpBack3 != null)
			{
				return _oSkillUseMpBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow3 != value && _oSkillUseMpBack3 != null)
			{
				_oSkillUseMpBack3.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow4
	{
		get
		{
			if (_oSkillUseMpBack4 != null)
			{
				return _oSkillUseMpBack4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow4 != value && _oSkillUseMpBack4 != null)
			{
				_oSkillUseMpBack4.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow5
	{
		get
		{
			if (_oSkillUseMpBack5 != null)
			{
				return _oSkillUseMpBack5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow5 != value && _oSkillUseMpBack5 != null)
			{
				_oSkillUseMpBack5.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow6
	{
		get
		{
			if (_oSkillUseMpBack6 != null)
			{
				return _oSkillUseMpBack6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow6 != value && _oSkillUseMpBack6 != null)
			{
				_oSkillUseMpBack6.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow7
	{
		get
		{
			if (_oSkillUseMpBack7 != null)
			{
				return _oSkillUseMpBack7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow7 != value && _oSkillUseMpBack7 != null)
			{
				_oSkillUseMpBack7.SetObjectActive(value);
			}
		}
	}

	public bool SkillUseMpBackShow8
	{
		get
		{
			if (_oSkillUseMpBack8 != null)
			{
				return _oSkillUseMpBack8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillUseMpBackShow8 != value && _oSkillUseMpBack8 != null)
			{
				_oSkillUseMpBack8.SetObjectActive(value);
			}
		}
	}

	public string SkillUseMpString1
	{
		get
		{
			if (_oSkillUseMpText1 != null)
			{
				return _oSkillUseMpText1.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString1 != value && _oSkillUseMpText1 != null)
			{
				_oSkillUseMpText1.text = value;
			}
		}
	}

	public string SkillUseMpString2
	{
		get
		{
			if (_oSkillUseMpText2 != null)
			{
				return _oSkillUseMpText2.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString2 != value && _oSkillUseMpText2 != null)
			{
				_oSkillUseMpText2.text = value;
			}
		}
	}

	public string SkillUseMpString3
	{
		get
		{
			if (_oSkillUseMpText3 != null)
			{
				return _oSkillUseMpText3.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString3 != value && _oSkillUseMpText3 != null)
			{
				_oSkillUseMpText3.text = value;
			}
		}
	}

	public string SkillUseMpString4
	{
		get
		{
			if (_oSkillUseMpText4 != null)
			{
				return _oSkillUseMpText4.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString4 != value && _oSkillUseMpText4 != null)
			{
				_oSkillUseMpText4.text = value;
			}
		}
	}

	public string SkillUseMpString5
	{
		get
		{
			if (_oSkillUseMpText5 != null)
			{
				return _oSkillUseMpText5.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString5 != value && _oSkillUseMpText5 != null)
			{
				_oSkillUseMpText5.text = value;
			}
		}
	}

	public string SkillUseMpString6
	{
		get
		{
			if (_oSkillUseMpText6 != null)
			{
				return _oSkillUseMpText6.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString6 != value && _oSkillUseMpText6 != null)
			{
				_oSkillUseMpText6.text = value;
			}
		}
	}

	public string SkillUseMpString7
	{
		get
		{
			if (_oSkillUseMpText7 != null)
			{
				return _oSkillUseMpText7.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString7 != value && _oSkillUseMpText7 != null)
			{
				_oSkillUseMpText7.text = value;
			}
		}
	}

	public string SkillUseMpString8
	{
		get
		{
			if (_oSkillUseMpText8 != null)
			{
				return _oSkillUseMpText8.text;
			}
			return null;
		}
		set
		{
			if (SkillUseMpString8 != value && _oSkillUseMpText8 != null)
			{
				_oSkillUseMpText8.text = value;
			}
		}
	}

	public bool SkillMaskShow1
	{
		get
		{
			if (_oSkillMask1 != null)
			{
				return _oSkillMask1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow1 != value && _oSkillMask1 != null)
			{
				_oSkillMask1.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow2
	{
		get
		{
			if (_oSkillMask2 != null)
			{
				return _oSkillMask2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow2 != value && _oSkillMask2 != null)
			{
				_oSkillMask2.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow3
	{
		get
		{
			if (_oSkillMask3 != null)
			{
				return _oSkillMask3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow3 != value && _oSkillMask3 != null)
			{
				_oSkillMask3.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow4
	{
		get
		{
			if (_oSkillMask4 != null)
			{
				return _oSkillMask4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow4 != value && _oSkillMask4 != null)
			{
				_oSkillMask4.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow5
	{
		get
		{
			if (_oSkillMask5 != null)
			{
				return _oSkillMask5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow5 != value && _oSkillMask5 != null)
			{
				_oSkillMask5.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow6
	{
		get
		{
			if (_oSkillMask6 != null)
			{
				return _oSkillMask6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow6 != value && _oSkillMask6 != null)
			{
				_oSkillMask6.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow7
	{
		get
		{
			if (_oSkillMask7 != null)
			{
				return _oSkillMask7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow7 != value && _oSkillMask7 != null)
			{
				_oSkillMask7.SetObjectActive(value);
			}
		}
	}

	public bool SkillMaskShow8
	{
		get
		{
			if (_oSkillMask8 != null)
			{
				return _oSkillMask8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMaskShow8 != value && _oSkillMask8 != null)
			{
				_oSkillMask8.SetObjectActive(value);
			}
		}
	}

	public float SkillMaskFillamount1
	{
		get
		{
			if (_oSkillMaskImage1 != null)
			{
				return _oSkillMaskImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount1 != value && _oSkillMaskImage1 != null)
			{
				_oSkillMaskImage1.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount2
	{
		get
		{
			if (_oSkillMaskImage2 != null)
			{
				return _oSkillMaskImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount2 != value && _oSkillMaskImage2 != null)
			{
				_oSkillMaskImage2.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount3
	{
		get
		{
			if (_oSkillMaskImage3 != null)
			{
				return _oSkillMaskImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount3 != value && _oSkillMaskImage3 != null)
			{
				_oSkillMaskImage3.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount4
	{
		get
		{
			if (_oSkillMaskImage4 != null)
			{
				return _oSkillMaskImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount4 != value && _oSkillMaskImage4 != null)
			{
				_oSkillMaskImage4.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount5
	{
		get
		{
			if (_oSkillMaskImage5 != null)
			{
				return _oSkillMaskImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount5 != value && _oSkillMaskImage5 != null)
			{
				_oSkillMaskImage5.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount6
	{
		get
		{
			if (_oSkillMaskImage6 != null)
			{
				return _oSkillMaskImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount6 != value && _oSkillMaskImage6 != null)
			{
				_oSkillMaskImage6.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount7
	{
		get
		{
			if (_oSkillMaskImage7 != null)
			{
				return _oSkillMaskImage7.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount7 != value && _oSkillMaskImage7 != null)
			{
				_oSkillMaskImage7.fillAmount = value;
			}
		}
	}

	public float SkillMaskFillamount8
	{
		get
		{
			if (_oSkillMaskImage8 != null)
			{
				return _oSkillMaskImage8.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SkillMaskFillamount8 != value && _oSkillMaskImage8 != null)
			{
				_oSkillMaskImage8.fillAmount = value;
			}
		}
	}

	public string SkillTimeString1
	{
		get
		{
			if (_oSkillTimeText1 != null)
			{
				return _oSkillTimeText1.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString1 != value && _oSkillTimeText1 != null)
			{
				_oSkillTimeText1.text = value;
			}
		}
	}

	public string SkillTimeString2
	{
		get
		{
			if (_oSkillTimeText2 != null)
			{
				return _oSkillTimeText2.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString2 != value && _oSkillTimeText2 != null)
			{
				_oSkillTimeText2.text = value;
			}
		}
	}

	public string SkillTimeString3
	{
		get
		{
			if (_oSkillTimeText3 != null)
			{
				return _oSkillTimeText3.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString3 != value && _oSkillTimeText3 != null)
			{
				_oSkillTimeText3.text = value;
			}
		}
	}

	public string SkillTimeString4
	{
		get
		{
			if (_oSkillTimeText4 != null)
			{
				return _oSkillTimeText4.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString4 != value && _oSkillTimeText4 != null)
			{
				_oSkillTimeText4.text = value;
			}
		}
	}

	public string SkillTimeString5
	{
		get
		{
			if (_oSkillTimeText5 != null)
			{
				return _oSkillTimeText5.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString5 != value && _oSkillTimeText5 != null)
			{
				_oSkillTimeText5.text = value;
			}
		}
	}

	public string SkillTimeString6
	{
		get
		{
			if (_oSkillTimeText6 != null)
			{
				return _oSkillTimeText6.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString6 != value && _oSkillTimeText6 != null)
			{
				_oSkillTimeText6.text = value;
			}
		}
	}

	public string SkillTimeString7
	{
		get
		{
			if (_oSkillTimeText7 != null)
			{
				return _oSkillTimeText7.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString7 != value && _oSkillTimeText7 != null)
			{
				_oSkillTimeText7.text = value;
			}
		}
	}

	public string SkillTimeString8
	{
		get
		{
			if (_oSkillTimeText8 != null)
			{
				return _oSkillTimeText8.text;
			}
			return null;
		}
		set
		{
			if (SkillTimeString8 != value && _oSkillTimeText8 != null)
			{
				_oSkillTimeText8.text = value;
			}
		}
	}

	public Sprite SkillTypeSprite1
	{
		get
		{
			if (_oSkillTypeImage1 != null)
			{
				return _oSkillTypeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite1 != value && _oSkillTypeImage1 != null)
			{
				_oSkillTypeImage1.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite2
	{
		get
		{
			if (_oSkillTypeImage2 != null)
			{
				return _oSkillTypeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite2 != value && _oSkillTypeImage2 != null)
			{
				_oSkillTypeImage2.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite3
	{
		get
		{
			if (_oSkillTypeImage3 != null)
			{
				return _oSkillTypeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite3 != value && _oSkillTypeImage3 != null)
			{
				_oSkillTypeImage3.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite4
	{
		get
		{
			if (_oSkillTypeImage4 != null)
			{
				return _oSkillTypeImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite4 != value && _oSkillTypeImage4 != null)
			{
				_oSkillTypeImage4.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite5
	{
		get
		{
			if (_oSkillTypeImage5 != null)
			{
				return _oSkillTypeImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite5 != value && _oSkillTypeImage5 != null)
			{
				_oSkillTypeImage5.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite6
	{
		get
		{
			if (_oSkillTypeImage6 != null)
			{
				return _oSkillTypeImage6.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite6 != value && _oSkillTypeImage6 != null)
			{
				_oSkillTypeImage6.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite7
	{
		get
		{
			if (_oSkillTypeImage7 != null)
			{
				return _oSkillTypeImage7.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite7 != value && _oSkillTypeImage7 != null)
			{
				_oSkillTypeImage7.sprite = value;
			}
		}
	}

	public Sprite SkillTypeSprite8
	{
		get
		{
			if (_oSkillTypeImage8 != null)
			{
				return _oSkillTypeImage8.sprite;
			}
			return null;
		}
		set
		{
			if (SkillTypeSprite8 != value && _oSkillTypeImage8 != null)
			{
				_oSkillTypeImage8.sprite = value;
			}
		}
	}

	public bool SkillEffectShow1
	{
		get
		{
			if (_oSkillEffect1 != null)
			{
				return _oSkillEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow1 != value && _oSkillEffect1 != null)
			{
				_oSkillEffect1.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow2
	{
		get
		{
			if (_oSkillEffect2 != null)
			{
				return _oSkillEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow2 != value && _oSkillEffect2 != null)
			{
				_oSkillEffect2.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow3
	{
		get
		{
			if (_oSkillEffect3 != null)
			{
				return _oSkillEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow3 != value && _oSkillEffect3 != null)
			{
				_oSkillEffect3.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow4
	{
		get
		{
			if (_oSkillEffect4 != null)
			{
				return _oSkillEffect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow4 != value && _oSkillEffect4 != null)
			{
				_oSkillEffect4.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow5
	{
		get
		{
			if (_oSkillEffect5 != null)
			{
				return _oSkillEffect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow5 != value && _oSkillEffect5 != null)
			{
				_oSkillEffect5.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow6
	{
		get
		{
			if (_oSkillEffect6 != null)
			{
				return _oSkillEffect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow6 != value && _oSkillEffect6 != null)
			{
				_oSkillEffect6.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow7
	{
		get
		{
			if (_oSkillEffect7 != null)
			{
				return _oSkillEffect7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow7 != value && _oSkillEffect7 != null)
			{
				_oSkillEffect7.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectShow8
	{
		get
		{
			if (_oSkillEffect8 != null)
			{
				return _oSkillEffect8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEffectShow8 != value && _oSkillEffect8 != null)
			{
				_oSkillEffect8.SetObjectActive(value);
			}
		}
	}

	public bool SkillEffectActualshow1
	{
		get
		{
			if (_oSkillEffect1 != null)
			{
				return _oSkillEffect1.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow2
	{
		get
		{
			if (_oSkillEffect2 != null)
			{
				return _oSkillEffect2.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow3
	{
		get
		{
			if (_oSkillEffect3 != null)
			{
				return _oSkillEffect3.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow4
	{
		get
		{
			if (_oSkillEffect4 != null)
			{
				return _oSkillEffect4.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow5
	{
		get
		{
			if (_oSkillEffect5 != null)
			{
				return _oSkillEffect5.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow6
	{
		get
		{
			if (_oSkillEffect6 != null)
			{
				return _oSkillEffect6.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow7
	{
		get
		{
			if (_oSkillEffect7 != null)
			{
				return _oSkillEffect7.activeInHierarchy;
			}
			return false;
		}
	}

	public bool SkillEffectActualshow8
	{
		get
		{
			if (_oSkillEffect8 != null)
			{
				return _oSkillEffect8.activeInHierarchy;
			}
			return false;
		}
	}

	public Sprite SkillEffectSprite1
	{
		get
		{
			if (_oSkillEffectImage1 != null)
			{
				return _oSkillEffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite1 != value && _oSkillEffectImage1 != null)
			{
				_oSkillEffectImage1.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite2
	{
		get
		{
			if (_oSkillEffectImage2 != null)
			{
				return _oSkillEffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite2 != value && _oSkillEffectImage2 != null)
			{
				_oSkillEffectImage2.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite3
	{
		get
		{
			if (_oSkillEffectImage3 != null)
			{
				return _oSkillEffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite3 != value && _oSkillEffectImage3 != null)
			{
				_oSkillEffectImage3.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite4
	{
		get
		{
			if (_oSkillEffectImage4 != null)
			{
				return _oSkillEffectImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite4 != value && _oSkillEffectImage4 != null)
			{
				_oSkillEffectImage4.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite5
	{
		get
		{
			if (_oSkillEffectImage5 != null)
			{
				return _oSkillEffectImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite5 != value && _oSkillEffectImage5 != null)
			{
				_oSkillEffectImage5.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite6
	{
		get
		{
			if (_oSkillEffectImage6 != null)
			{
				return _oSkillEffectImage6.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite6 != value && _oSkillEffectImage6 != null)
			{
				_oSkillEffectImage6.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite7
	{
		get
		{
			if (_oSkillEffectImage7 != null)
			{
				return _oSkillEffectImage7.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite7 != value && _oSkillEffectImage7 != null)
			{
				_oSkillEffectImage7.sprite = value;
			}
		}
	}

	public Sprite SkillEffectSprite8
	{
		get
		{
			if (_oSkillEffectImage8 != null)
			{
				return _oSkillEffectImage8.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEffectSprite8 != value && _oSkillEffectImage8 != null)
			{
				_oSkillEffectImage8.sprite = value;
			}
		}
	}

	public bool DragonBackShow
	{
		get
		{
			if (_oDragoonBack != null)
			{
				return _oDragoonBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DragonBackShow != value && _oDragoonBack != null)
			{
				_oDragoonBack.SetObjectActive(value);
			}
		}
	}

	public bool FireShowShow
	{
		get
		{
			if (_oFireShow != null)
			{
				return _oFireShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FireShowShow != value && _oFireShow != null)
			{
				_oFireShow.SetObjectActive(value);
			}
		}
	}

	public bool FireShowActualshow
	{
		get
		{
			if (_oFireShow != null)
			{
				return _oFireShow.activeInHierarchy;
			}
			return false;
		}
	}

	public bool FireEffectShow
	{
		get
		{
			if (_oFireEffect != null)
			{
				return _oFireEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FireEffectShow != value && _oFireEffect != null)
			{
				_oFireEffect.SetObjectActive(value);
			}
		}
	}

	public bool FireEffectActualshow
	{
		get
		{
			if (_oFireEffect != null)
			{
				return _oFireEffect.activeInHierarchy;
			}
			return false;
		}
	}

	public Sprite FireEffectSprite
	{
		get
		{
			if (_oFireEffectImage != null)
			{
				return _oFireEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (FireEffectSprite != value && _oFireEffectImage != null)
			{
				_oFireEffectImage.sprite = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "AbsorbedProgress":
				_oAbsorbedProgress = transform.gameObject;
				_oAbsorbedProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AbsorbedCount":
				_oAbsorbedCount = transform.gameObject;
				_oAbsorbedCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "EnergyProgress":
				_oEnergyProgress = transform.gameObject;
				_oEnergyProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyCount":
				_oEnergyCount = transform.gameObject;
				_oEnergyCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "DragoonSkillIcon":
				_oDragoonSkillIcon = transform.gameObject;
				_oDragoonSkillIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DragoonSkillMask":
				_oDragoonSkillMask = transform.gameObject;
				_oDragoonSkillMaskImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DragoonBack":
				_oDragoonBack = transform.gameObject;
				break;
			case "DragoonSkillTime":
				_oDragoonSkillTime = transform.gameObject;
				_oDragoonSkillTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "DragoonSkillEffect":
				_oDragoonSkillEffect = transform.gameObject;
				_oDragoonSkillEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AwakeSkillIcon":
				_oAwakeSkillIcon = transform.gameObject;
				_oAwakeSkillIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AwakeSkillMask":
				_oAwakeSkillMask = transform.gameObject;
				_oAwakeSkillMaskImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AwakeSkillTime":
				_oAwakeSkillTime = transform.gameObject;
				_oAwakeSkillTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "AwakeSkillEffect":
				_oAwakeSkillEffect = transform.gameObject;
				_oAwakeSkillEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon1":
				_oSkillIcon1 = transform.gameObject;
				_oSkillIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon2":
				_oSkillIcon2 = transform.gameObject;
				_oSkillIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon3":
				_oSkillIcon3 = transform.gameObject;
				_oSkillIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon4":
				_oSkillIcon4 = transform.gameObject;
				_oSkillIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon5":
				_oSkillIcon5 = transform.gameObject;
				_oSkillIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon6":
				_oSkillIcon6 = transform.gameObject;
				_oSkillIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon7":
				_oSkillIcon7 = transform.gameObject;
				_oSkillIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillIcon8":
				_oSkillIcon8 = transform.gameObject;
				_oSkillIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv1":
				_oSkillLv1 = transform.gameObject;
				_oSkillLvImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv2":
				_oSkillLv2 = transform.gameObject;
				_oSkillLvImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv3":
				_oSkillLv3 = transform.gameObject;
				_oSkillLvImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv4":
				_oSkillLv4 = transform.gameObject;
				_oSkillLvImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv5":
				_oSkillLv5 = transform.gameObject;
				_oSkillLvImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv6":
				_oSkillLv6 = transform.gameObject;
				_oSkillLvImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv7":
				_oSkillLv7 = transform.gameObject;
				_oSkillLvImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillLv8":
				_oSkillLv8 = transform.gameObject;
				_oSkillLvImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillUseMpBack1":
				_oSkillUseMpBack1 = transform.gameObject;
				break;
			case "SkillUseMpBack2":
				_oSkillUseMpBack2 = transform.gameObject;
				break;
			case "SkillUseMpBack3":
				_oSkillUseMpBack3 = transform.gameObject;
				break;
			case "SkillUseMpBack4":
				_oSkillUseMpBack4 = transform.gameObject;
				break;
			case "SkillUseMpBack5":
				_oSkillUseMpBack5 = transform.gameObject;
				break;
			case "SkillUseMpBack6":
				_oSkillUseMpBack6 = transform.gameObject;
				break;
			case "SkillUseMpBack7":
				_oSkillUseMpBack7 = transform.gameObject;
				break;
			case "SkillUseMpBack8":
				_oSkillUseMpBack8 = transform.gameObject;
				break;
			case "SkillUseMp1":
				_oSkillUseMp1 = transform.gameObject;
				_oSkillUseMpText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp2":
				_oSkillUseMp2 = transform.gameObject;
				_oSkillUseMpText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp3":
				_oSkillUseMp3 = transform.gameObject;
				_oSkillUseMpText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp4":
				_oSkillUseMp4 = transform.gameObject;
				_oSkillUseMpText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp5":
				_oSkillUseMp5 = transform.gameObject;
				_oSkillUseMpText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp6":
				_oSkillUseMp6 = transform.gameObject;
				_oSkillUseMpText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp7":
				_oSkillUseMp7 = transform.gameObject;
				_oSkillUseMpText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillUseMp8":
				_oSkillUseMp8 = transform.gameObject;
				_oSkillUseMpText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillMask1":
				_oSkillMask1 = transform.gameObject;
				_oSkillMaskImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask2":
				_oSkillMask2 = transform.gameObject;
				_oSkillMaskImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask3":
				_oSkillMask3 = transform.gameObject;
				_oSkillMaskImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask4":
				_oSkillMask4 = transform.gameObject;
				_oSkillMaskImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask5":
				_oSkillMask5 = transform.gameObject;
				_oSkillMaskImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask6":
				_oSkillMask6 = transform.gameObject;
				_oSkillMaskImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask7":
				_oSkillMask7 = transform.gameObject;
				_oSkillMaskImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMask8":
				_oSkillMask8 = transform.gameObject;
				_oSkillMaskImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillTime1":
				_oSkillTime1 = transform.gameObject;
				_oSkillTimeText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime2":
				_oSkillTime2 = transform.gameObject;
				_oSkillTimeText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime3":
				_oSkillTime3 = transform.gameObject;
				_oSkillTimeText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime4":
				_oSkillTime4 = transform.gameObject;
				_oSkillTimeText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime5":
				_oSkillTime5 = transform.gameObject;
				_oSkillTimeText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime6":
				_oSkillTime6 = transform.gameObject;
				_oSkillTimeText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime7":
				_oSkillTime7 = transform.gameObject;
				_oSkillTimeText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillTime8":
				_oSkillTime8 = transform.gameObject;
				_oSkillTimeText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillType1":
				_oSkillType1 = transform.gameObject;
				_oSkillTypeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType2":
				_oSkillType2 = transform.gameObject;
				_oSkillTypeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType3":
				_oSkillType3 = transform.gameObject;
				_oSkillTypeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType4":
				_oSkillType4 = transform.gameObject;
				_oSkillTypeImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType5":
				_oSkillType5 = transform.gameObject;
				_oSkillTypeImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType6":
				_oSkillType6 = transform.gameObject;
				_oSkillTypeImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType7":
				_oSkillType7 = transform.gameObject;
				_oSkillTypeImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillType8":
				_oSkillType8 = transform.gameObject;
				_oSkillTypeImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect1":
				_oSkillEffect1 = transform.gameObject;
				_oSkillEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect2":
				_oSkillEffect2 = transform.gameObject;
				_oSkillEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect3":
				_oSkillEffect3 = transform.gameObject;
				_oSkillEffectImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect4":
				_oSkillEffect4 = transform.gameObject;
				_oSkillEffectImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect5":
				_oSkillEffect5 = transform.gameObject;
				_oSkillEffectImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect6":
				_oSkillEffect6 = transform.gameObject;
				_oSkillEffectImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect7":
				_oSkillEffect7 = transform.gameObject;
				_oSkillEffectImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEffect8":
				_oSkillEffect8 = transform.gameObject;
				_oSkillEffectImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "FireShow":
				_oFireShow = transform.gameObject;
				break;
			case "FireEffect":
				_oFireEffect = transform.gameObject;
				_oFireEffectImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetSkillIconShow(int index)
	{
		return index switch
		{
			1 => SkillIconShow1, 
			2 => SkillIconShow2, 
			3 => SkillIconShow3, 
			4 => SkillIconShow4, 
			5 => SkillIconShow5, 
			6 => SkillIconShow6, 
			7 => SkillIconShow7, 
			8 => SkillIconShow8, 
			_ => false, 
		};
	}

	public void SetSkillIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillIconShow1 = value;
			break;
		case 2:
			SkillIconShow2 = value;
			break;
		case 3:
			SkillIconShow3 = value;
			break;
		case 4:
			SkillIconShow4 = value;
			break;
		case 5:
			SkillIconShow5 = value;
			break;
		case 6:
			SkillIconShow6 = value;
			break;
		case 7:
			SkillIconShow7 = value;
			break;
		case 8:
			SkillIconShow8 = value;
			break;
		}
	}

	public int GetSkillIconCount()
	{
		return 8;
	}

	public Sprite GetSkillIconSprite(int index)
	{
		return index switch
		{
			1 => SkillIconSprite1, 
			2 => SkillIconSprite2, 
			3 => SkillIconSprite3, 
			4 => SkillIconSprite4, 
			5 => SkillIconSprite5, 
			6 => SkillIconSprite6, 
			7 => SkillIconSprite7, 
			8 => SkillIconSprite8, 
			_ => null, 
		};
	}

	public void SetSkillIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillIconSprite1 = value;
			break;
		case 2:
			SkillIconSprite2 = value;
			break;
		case 3:
			SkillIconSprite3 = value;
			break;
		case 4:
			SkillIconSprite4 = value;
			break;
		case 5:
			SkillIconSprite5 = value;
			break;
		case 6:
			SkillIconSprite6 = value;
			break;
		case 7:
			SkillIconSprite7 = value;
			break;
		case 8:
			SkillIconSprite8 = value;
			break;
		}
	}

	public Image GetSkillIconImage(int index)
	{
		return index switch
		{
			1 => SkillIconImage1, 
			2 => SkillIconImage2, 
			3 => SkillIconImage3, 
			4 => SkillIconImage4, 
			5 => SkillIconImage5, 
			6 => SkillIconImage6, 
			7 => SkillIconImage7, 
			8 => SkillIconImage8, 
			_ => null, 
		};
	}

	public void SetSkillIconImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			SkillIconImage1 = value;
			break;
		case 2:
			SkillIconImage2 = value;
			break;
		case 3:
			SkillIconImage3 = value;
			break;
		case 4:
			SkillIconImage4 = value;
			break;
		case 5:
			SkillIconImage5 = value;
			break;
		case 6:
			SkillIconImage6 = value;
			break;
		case 7:
			SkillIconImage7 = value;
			break;
		case 8:
			SkillIconImage8 = value;
			break;
		}
	}

	public bool GetSkillLvShow(int index)
	{
		return index switch
		{
			1 => SkillLvShow1, 
			2 => SkillLvShow2, 
			3 => SkillLvShow3, 
			4 => SkillLvShow4, 
			5 => SkillLvShow5, 
			6 => SkillLvShow6, 
			7 => SkillLvShow7, 
			8 => SkillLvShow8, 
			_ => false, 
		};
	}

	public void SetSkillLvShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillLvShow1 = value;
			break;
		case 2:
			SkillLvShow2 = value;
			break;
		case 3:
			SkillLvShow3 = value;
			break;
		case 4:
			SkillLvShow4 = value;
			break;
		case 5:
			SkillLvShow5 = value;
			break;
		case 6:
			SkillLvShow6 = value;
			break;
		case 7:
			SkillLvShow7 = value;
			break;
		case 8:
			SkillLvShow8 = value;
			break;
		}
	}

	public int GetSkillLvCount()
	{
		return 8;
	}

	public Sprite GetSkillLvSprite(int index)
	{
		return index switch
		{
			1 => SkillLvSprite1, 
			2 => SkillLvSprite2, 
			3 => SkillLvSprite3, 
			4 => SkillLvSprite4, 
			5 => SkillLvSprite5, 
			6 => SkillLvSprite6, 
			7 => SkillLvSprite7, 
			8 => SkillLvSprite8, 
			_ => null, 
		};
	}

	public void SetSkillLvSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillLvSprite1 = value;
			break;
		case 2:
			SkillLvSprite2 = value;
			break;
		case 3:
			SkillLvSprite3 = value;
			break;
		case 4:
			SkillLvSprite4 = value;
			break;
		case 5:
			SkillLvSprite5 = value;
			break;
		case 6:
			SkillLvSprite6 = value;
			break;
		case 7:
			SkillLvSprite7 = value;
			break;
		case 8:
			SkillLvSprite8 = value;
			break;
		}
	}

	public bool GetSkillUseMpBackShow(int index)
	{
		return index switch
		{
			1 => SkillUseMpBackShow1, 
			2 => SkillUseMpBackShow2, 
			3 => SkillUseMpBackShow3, 
			4 => SkillUseMpBackShow4, 
			5 => SkillUseMpBackShow5, 
			6 => SkillUseMpBackShow6, 
			7 => SkillUseMpBackShow7, 
			8 => SkillUseMpBackShow8, 
			_ => false, 
		};
	}

	public void SetSkillUseMpBackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillUseMpBackShow1 = value;
			break;
		case 2:
			SkillUseMpBackShow2 = value;
			break;
		case 3:
			SkillUseMpBackShow3 = value;
			break;
		case 4:
			SkillUseMpBackShow4 = value;
			break;
		case 5:
			SkillUseMpBackShow5 = value;
			break;
		case 6:
			SkillUseMpBackShow6 = value;
			break;
		case 7:
			SkillUseMpBackShow7 = value;
			break;
		case 8:
			SkillUseMpBackShow8 = value;
			break;
		}
	}

	public int GetSkillUseMpBackCount()
	{
		return 8;
	}

	public string GetSkillUseMpString(int index)
	{
		return index switch
		{
			1 => SkillUseMpString1, 
			2 => SkillUseMpString2, 
			3 => SkillUseMpString3, 
			4 => SkillUseMpString4, 
			5 => SkillUseMpString5, 
			6 => SkillUseMpString6, 
			7 => SkillUseMpString7, 
			8 => SkillUseMpString8, 
			_ => null, 
		};
	}

	public void SetSkillUseMpString(int index, string value)
	{
		switch (index)
		{
		case 1:
			SkillUseMpString1 = value;
			break;
		case 2:
			SkillUseMpString2 = value;
			break;
		case 3:
			SkillUseMpString3 = value;
			break;
		case 4:
			SkillUseMpString4 = value;
			break;
		case 5:
			SkillUseMpString5 = value;
			break;
		case 6:
			SkillUseMpString6 = value;
			break;
		case 7:
			SkillUseMpString7 = value;
			break;
		case 8:
			SkillUseMpString8 = value;
			break;
		}
	}

	public int GetSkillUseMpCount()
	{
		return 8;
	}

	public bool GetSkillMaskShow(int index)
	{
		return index switch
		{
			1 => SkillMaskShow1, 
			2 => SkillMaskShow2, 
			3 => SkillMaskShow3, 
			4 => SkillMaskShow4, 
			5 => SkillMaskShow5, 
			6 => SkillMaskShow6, 
			7 => SkillMaskShow7, 
			8 => SkillMaskShow8, 
			_ => false, 
		};
	}

	public void SetSkillMaskShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillMaskShow1 = value;
			break;
		case 2:
			SkillMaskShow2 = value;
			break;
		case 3:
			SkillMaskShow3 = value;
			break;
		case 4:
			SkillMaskShow4 = value;
			break;
		case 5:
			SkillMaskShow5 = value;
			break;
		case 6:
			SkillMaskShow6 = value;
			break;
		case 7:
			SkillMaskShow7 = value;
			break;
		case 8:
			SkillMaskShow8 = value;
			break;
		}
	}

	public int GetSkillMaskCount()
	{
		return 8;
	}

	public float GetSkillMaskFillamount(int index)
	{
		return index switch
		{
			1 => SkillMaskFillamount1, 
			2 => SkillMaskFillamount2, 
			3 => SkillMaskFillamount3, 
			4 => SkillMaskFillamount4, 
			5 => SkillMaskFillamount5, 
			6 => SkillMaskFillamount6, 
			7 => SkillMaskFillamount7, 
			8 => SkillMaskFillamount8, 
			_ => 0f, 
		};
	}

	public void SetSkillMaskFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			SkillMaskFillamount1 = value;
			break;
		case 2:
			SkillMaskFillamount2 = value;
			break;
		case 3:
			SkillMaskFillamount3 = value;
			break;
		case 4:
			SkillMaskFillamount4 = value;
			break;
		case 5:
			SkillMaskFillamount5 = value;
			break;
		case 6:
			SkillMaskFillamount6 = value;
			break;
		case 7:
			SkillMaskFillamount7 = value;
			break;
		case 8:
			SkillMaskFillamount8 = value;
			break;
		}
	}

	public string GetSkillTimeString(int index)
	{
		return index switch
		{
			1 => SkillTimeString1, 
			2 => SkillTimeString2, 
			3 => SkillTimeString3, 
			4 => SkillTimeString4, 
			5 => SkillTimeString5, 
			6 => SkillTimeString6, 
			7 => SkillTimeString7, 
			8 => SkillTimeString8, 
			_ => null, 
		};
	}

	public void SetSkillTimeString(int index, string value)
	{
		switch (index)
		{
		case 1:
			SkillTimeString1 = value;
			break;
		case 2:
			SkillTimeString2 = value;
			break;
		case 3:
			SkillTimeString3 = value;
			break;
		case 4:
			SkillTimeString4 = value;
			break;
		case 5:
			SkillTimeString5 = value;
			break;
		case 6:
			SkillTimeString6 = value;
			break;
		case 7:
			SkillTimeString7 = value;
			break;
		case 8:
			SkillTimeString8 = value;
			break;
		}
	}

	public int GetSkillTimeCount()
	{
		return 8;
	}

	public Sprite GetSkillTypeSprite(int index)
	{
		return index switch
		{
			1 => SkillTypeSprite1, 
			2 => SkillTypeSprite2, 
			3 => SkillTypeSprite3, 
			4 => SkillTypeSprite4, 
			5 => SkillTypeSprite5, 
			6 => SkillTypeSprite6, 
			7 => SkillTypeSprite7, 
			8 => SkillTypeSprite8, 
			_ => null, 
		};
	}

	public void SetSkillTypeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillTypeSprite1 = value;
			break;
		case 2:
			SkillTypeSprite2 = value;
			break;
		case 3:
			SkillTypeSprite3 = value;
			break;
		case 4:
			SkillTypeSprite4 = value;
			break;
		case 5:
			SkillTypeSprite5 = value;
			break;
		case 6:
			SkillTypeSprite6 = value;
			break;
		case 7:
			SkillTypeSprite7 = value;
			break;
		case 8:
			SkillTypeSprite8 = value;
			break;
		}
	}

	public int GetSkillTypeCount()
	{
		return 8;
	}

	public bool GetSkillEffectShow(int index)
	{
		return index switch
		{
			1 => SkillEffectShow1, 
			2 => SkillEffectShow2, 
			3 => SkillEffectShow3, 
			4 => SkillEffectShow4, 
			5 => SkillEffectShow5, 
			6 => SkillEffectShow6, 
			7 => SkillEffectShow7, 
			8 => SkillEffectShow8, 
			_ => false, 
		};
	}

	public void SetSkillEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillEffectShow1 = value;
			break;
		case 2:
			SkillEffectShow2 = value;
			break;
		case 3:
			SkillEffectShow3 = value;
			break;
		case 4:
			SkillEffectShow4 = value;
			break;
		case 5:
			SkillEffectShow5 = value;
			break;
		case 6:
			SkillEffectShow6 = value;
			break;
		case 7:
			SkillEffectShow7 = value;
			break;
		case 8:
			SkillEffectShow8 = value;
			break;
		}
	}

	public int GetSkillEffectCount()
	{
		return 8;
	}

	public bool GetSkillEffectActualshow(int index)
	{
		return index switch
		{
			1 => SkillEffectActualshow1, 
			2 => SkillEffectActualshow2, 
			3 => SkillEffectActualshow3, 
			4 => SkillEffectActualshow4, 
			5 => SkillEffectActualshow5, 
			6 => SkillEffectActualshow6, 
			7 => SkillEffectActualshow7, 
			8 => SkillEffectActualshow8, 
			_ => false, 
		};
	}

	public Sprite GetSkillEffectSprite(int index)
	{
		return index switch
		{
			1 => SkillEffectSprite1, 
			2 => SkillEffectSprite2, 
			3 => SkillEffectSprite3, 
			4 => SkillEffectSprite4, 
			5 => SkillEffectSprite5, 
			6 => SkillEffectSprite6, 
			7 => SkillEffectSprite7, 
			8 => SkillEffectSprite8, 
			_ => null, 
		};
	}

	public void SetSkillEffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillEffectSprite1 = value;
			break;
		case 2:
			SkillEffectSprite2 = value;
			break;
		case 3:
			SkillEffectSprite3 = value;
			break;
		case 4:
			SkillEffectSprite4 = value;
			break;
		case 5:
			SkillEffectSprite5 = value;
			break;
		case 6:
			SkillEffectSprite6 = value;
			break;
		case 7:
			SkillEffectSprite7 = value;
			break;
		case 8:
			SkillEffectSprite8 = value;
			break;
		}
	}

	public void FireEffectNtvsize()
	{
		if (_oFireEffectImage != null)
		{
			_oFireEffectImage.SetNativeSize();
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
