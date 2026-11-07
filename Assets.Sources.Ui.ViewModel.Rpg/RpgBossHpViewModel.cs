using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgBossHpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBossIcon;

	private Image _oBossIconImage;

	private GameObject _oBottomHpImage;

	private Image _oBottomHpImageImage;

	private GameObject _oEffectProgressBar;

	private Image _oEffectProgressBarImage;

	private GameObject _oCurHpProgressBar;

	private Image _oCurHpProgressBarImage;

	private GameObject _oFollowImage;

	private RectTransform _oFollowImageRectTransform;

	private GameObject _oextraLifeNum;

	private GameObject _onum;

	private Text _onumText;

	private GameObject _oHpPercent;

	private Text _oHpPercentText;

	private GameObject _oShieldBg;

	private GameObject _oShieldPercentBg;

	private Image _oShieldPercentBgImage;

	private GameObject _oNameLabel;

	private Text _oNameLabelText;

	private GameObject _oAttributeImage1;

	private GameObject _oAttributeImage2;

	private GameObject _oAttributeImage3;

	private GameObject _oAttributeImage4;

	private Image _oAttributeImageImage1;

	private Image _oAttributeImageImage2;

	private Image _oAttributeImageImage3;

	private Image _oAttributeImageImage4;

	private GameObject _oLvLabel;

	private Text _oLvLabelText;

	private GameObject _oKulouImage;

	private GameObject _oRace1;

	private GameObject _oRace2;

	private GameObject _oRace3;

	private GameObject _oRace4;

	private GameObject _oRace5;

	private GameObject _oRaceName1;

	private GameObject _oRaceName2;

	private GameObject _oRaceName3;

	private GameObject _oRaceName4;

	private GameObject _oRaceName5;

	private Text _oRaceNameText1;

	private Text _oRaceNameText2;

	private Text _oRaceNameText3;

	private Text _oRaceNameText4;

	private Text _oRaceNameText5;

	private GameObject _oAttack1;

	private GameObject _oAttack2;

	private GameObject _oAttackType1;

	private GameObject _oAttackType2;

	private Text _oAttackTypeText1;

	private Text _oAttackTypeText2;

	private GameObject _oMonterPanel;

	private GameObject _oBottommHpImage;

	private GameObject _oEffectmHpProgressBar;

	private Image _oEffectmHpProgressBarImage;

	private GameObject _oCurmHpProgressBar;

	private Image _oCurmHpProgressBarImage;

	private GameObject _oBottomHdImage;

	private GameObject _oEffectHdProgressBar;

	private Image _oEffectHdProgressBarImage;

	private GameObject _oCurHdProgressBar;

	private Image _oCurHdProgressBarImage;

	private GameObject _oBottomZjImage;

	private GameObject _oEffectZjProgressBar;

	private Image _oEffectZjProgressBarImage;

	private GameObject _oCurZjProgressBar;

	private Image _oCurZjProgressBarImage;

	private GameObject _olockHp;

	private GameObject _olockl;

	private Image _olocklImage;

	private GameObject _olockr;

	private Image _olockrImage;

	private GameObject _oeffeect;

	private Image _oeffeectImage;

	private GameObject _olockmsg;

	private Image _olockmsgImage;

	private GameObject _olockeffect;

	private Image _olockeffectImage;

	private GameObject _oAddResis;

	private GameObject _obg;

	private Image _obgImage;

	private GameObject _obsadd;

	private GameObject _obladd;

	private GameObject _oYanHpImage;

	private Image _oYanHpImageImage;

	private GameObject _oYinHpImage;

	private Image _oYinHpImageImage;

	private GameObject _obuff1;

	private GameObject _obuff2;

	private GameObject _obuff3;

	private GameObject _obuff4;

	private GameObject _obuff5;

	private GameObject _obuff6;

	private GameObject _obufficon1;

	private GameObject _obufficon2;

	private GameObject _obufficon3;

	private GameObject _obufficon4;

	private GameObject _obufficon5;

	private GameObject _obufficon6;

	private Image _obufficonImage1;

	private Image _obufficonImage2;

	private Image _obufficonImage3;

	private Image _obufficonImage4;

	private Image _obufficonImage5;

	private Image _obufficonImage6;

	private GameObject _obuffValue1;

	private GameObject _obuffValue2;

	private GameObject _obuffValue3;

	private GameObject _obuffValue4;

	private GameObject _obuffValue5;

	private GameObject _obuffValue6;

	private Text _obuffValueText1;

	private Text _obuffValueText2;

	private Text _obuffValueText3;

	private Text _obuffValueText4;

	private Text _obuffValueText5;

	private Text _obuffValueText6;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgbosshp";

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

	public bool PanelRootshow
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
			if (PanelRootshow == value || !(_oPanel != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oPanel.SetObjectActive(!value);
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oPanel.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public Sprite BossIconSprite
	{
		get
		{
			if (_oBossIconImage != null)
			{
				return _oBossIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (BossIconSprite != value && _oBossIconImage != null)
			{
				_oBossIconImage.sprite = value;
			}
		}
	}

	public bool BottomHpImageShow
	{
		get
		{
			if (_oBottomHpImage != null)
			{
				return _oBottomHpImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomHpImageShow != value && _oBottomHpImage != null)
			{
				_oBottomHpImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BottomHpImageSprite
	{
		get
		{
			if (_oBottomHpImageImage != null)
			{
				return _oBottomHpImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BottomHpImageSprite != value && _oBottomHpImageImage != null)
			{
				_oBottomHpImageImage.sprite = value;
			}
		}
	}

	public Image BottomHpImageImage
	{
		get
		{
			if (_oBottomHpImageImage != null)
			{
				return _oBottomHpImageImage;
			}
			return null;
		}
		set
		{
			if (BottomHpImageImage != value && _oBottomHpImageImage != null)
			{
				_oBottomHpImageImage = value;
			}
		}
	}

	public float EffectProgressBarFillamount
	{
		get
		{
			if (_oEffectProgressBarImage != null)
			{
				return _oEffectProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EffectProgressBarFillamount != value && _oEffectProgressBarImage != null)
			{
				_oEffectProgressBarImage.fillAmount = value;
			}
		}
	}

	public Sprite CurHpProgressBarSprite
	{
		get
		{
			if (_oCurHpProgressBarImage != null)
			{
				return _oCurHpProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (CurHpProgressBarSprite != value && _oCurHpProgressBarImage != null)
			{
				_oCurHpProgressBarImage.sprite = value;
			}
		}
	}

	public float CurHpProgressBarFillamount
	{
		get
		{
			if (_oCurHpProgressBarImage != null)
			{
				return _oCurHpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CurHpProgressBarFillamount != value && _oCurHpProgressBarImage != null)
			{
				_oCurHpProgressBarImage.fillAmount = value;
			}
		}
	}

	public Vector3 FollowImagePosition
	{
		get
		{
			if (_oFollowImageRectTransform != null)
			{
				return _oFollowImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FollowImagePosition != value && _oFollowImageRectTransform != null)
			{
				_oFollowImageRectTransform.localPosition = value;
			}
		}
	}

	public bool extraLifeNumShow
	{
		get
		{
			if (_oextraLifeNum != null)
			{
				return _oextraLifeNum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (extraLifeNumShow != value && _oextraLifeNum != null)
			{
				_oextraLifeNum.SetObjectActive(value);
			}
		}
	}

	public string numString
	{
		get
		{
			if (_onumText != null)
			{
				return _onumText.text;
			}
			return null;
		}
		set
		{
			if (numString != value && _onumText != null)
			{
				_onumText.text = value;
			}
		}
	}

	public string HpPercentString
	{
		get
		{
			if (_oHpPercentText != null)
			{
				return _oHpPercentText.text;
			}
			return null;
		}
		set
		{
			if (HpPercentString != value && _oHpPercentText != null)
			{
				_oHpPercentText.text = value;
			}
		}
	}

	public bool ShieldBgShow
	{
		get
		{
			if (_oShieldBg != null)
			{
				return _oShieldBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShieldBgShow != value && _oShieldBg != null)
			{
				_oShieldBg.SetObjectActive(value);
			}
		}
	}

	public float ShieldPercentBgFillamount
	{
		get
		{
			if (_oShieldPercentBgImage != null)
			{
				return _oShieldPercentBgImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ShieldPercentBgFillamount != value && _oShieldPercentBgImage != null)
			{
				_oShieldPercentBgImage.fillAmount = value;
			}
		}
	}

	public string NameLabelString
	{
		get
		{
			if (_oNameLabelText != null)
			{
				return _oNameLabelText.text;
			}
			return null;
		}
		set
		{
			if (NameLabelString != value && _oNameLabelText != null)
			{
				_oNameLabelText.text = value;
			}
		}
	}

	public Color NameLabelTextcolor
	{
		get
		{
			if (_oNameLabelText != null)
			{
				return _oNameLabelText.color;
			}
			return Color.white;
		}
		set
		{
			if (NameLabelTextcolor != value && _oNameLabelText != null)
			{
				_oNameLabelText.color = value;
			}
		}
	}

	public bool AttributeImageShow1
	{
		get
		{
			if (_oAttributeImage1 != null)
			{
				return _oAttributeImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow1 != value && _oAttributeImage1 != null)
			{
				_oAttributeImage1.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow2
	{
		get
		{
			if (_oAttributeImage2 != null)
			{
				return _oAttributeImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow2 != value && _oAttributeImage2 != null)
			{
				_oAttributeImage2.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow3
	{
		get
		{
			if (_oAttributeImage3 != null)
			{
				return _oAttributeImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow3 != value && _oAttributeImage3 != null)
			{
				_oAttributeImage3.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow4
	{
		get
		{
			if (_oAttributeImage4 != null)
			{
				return _oAttributeImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow4 != value && _oAttributeImage4 != null)
			{
				_oAttributeImage4.SetObjectActive(value);
			}
		}
	}

	public Sprite AttributeImageSprite1
	{
		get
		{
			if (_oAttributeImageImage1 != null)
			{
				return _oAttributeImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite1 != value && _oAttributeImageImage1 != null)
			{
				_oAttributeImageImage1.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite2
	{
		get
		{
			if (_oAttributeImageImage2 != null)
			{
				return _oAttributeImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite2 != value && _oAttributeImageImage2 != null)
			{
				_oAttributeImageImage2.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite3
	{
		get
		{
			if (_oAttributeImageImage3 != null)
			{
				return _oAttributeImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite3 != value && _oAttributeImageImage3 != null)
			{
				_oAttributeImageImage3.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite4
	{
		get
		{
			if (_oAttributeImageImage4 != null)
			{
				return _oAttributeImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite4 != value && _oAttributeImageImage4 != null)
			{
				_oAttributeImageImage4.sprite = value;
			}
		}
	}

	public string LvLabelString
	{
		get
		{
			if (_oLvLabelText != null)
			{
				return _oLvLabelText.text;
			}
			return null;
		}
		set
		{
			if (LvLabelString != value && _oLvLabelText != null)
			{
				_oLvLabelText.text = value;
			}
		}
	}

	public Color LvLabelTextcolor
	{
		get
		{
			if (_oLvLabelText != null)
			{
				return _oLvLabelText.color;
			}
			return Color.white;
		}
		set
		{
			if (LvLabelTextcolor != value && _oLvLabelText != null)
			{
				_oLvLabelText.color = value;
			}
		}
	}

	public bool KulouImageShow
	{
		get
		{
			if (_oKulouImage != null)
			{
				return _oKulouImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KulouImageShow != value && _oKulouImage != null)
			{
				_oKulouImage.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow1
	{
		get
		{
			if (_oRace1 != null)
			{
				return _oRace1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow1 != value && _oRace1 != null)
			{
				_oRace1.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow2
	{
		get
		{
			if (_oRace2 != null)
			{
				return _oRace2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow2 != value && _oRace2 != null)
			{
				_oRace2.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow3
	{
		get
		{
			if (_oRace3 != null)
			{
				return _oRace3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow3 != value && _oRace3 != null)
			{
				_oRace3.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow4
	{
		get
		{
			if (_oRace4 != null)
			{
				return _oRace4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow4 != value && _oRace4 != null)
			{
				_oRace4.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow5
	{
		get
		{
			if (_oRace5 != null)
			{
				return _oRace5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow5 != value && _oRace5 != null)
			{
				_oRace5.SetObjectActive(value);
			}
		}
	}

	public string RaceNameString1
	{
		get
		{
			if (_oRaceNameText1 != null)
			{
				return _oRaceNameText1.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString1 != value && _oRaceNameText1 != null)
			{
				_oRaceNameText1.text = value;
			}
		}
	}

	public string RaceNameString2
	{
		get
		{
			if (_oRaceNameText2 != null)
			{
				return _oRaceNameText2.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString2 != value && _oRaceNameText2 != null)
			{
				_oRaceNameText2.text = value;
			}
		}
	}

	public string RaceNameString3
	{
		get
		{
			if (_oRaceNameText3 != null)
			{
				return _oRaceNameText3.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString3 != value && _oRaceNameText3 != null)
			{
				_oRaceNameText3.text = value;
			}
		}
	}

	public string RaceNameString4
	{
		get
		{
			if (_oRaceNameText4 != null)
			{
				return _oRaceNameText4.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString4 != value && _oRaceNameText4 != null)
			{
				_oRaceNameText4.text = value;
			}
		}
	}

	public string RaceNameString5
	{
		get
		{
			if (_oRaceNameText5 != null)
			{
				return _oRaceNameText5.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString5 != value && _oRaceNameText5 != null)
			{
				_oRaceNameText5.text = value;
			}
		}
	}

	public bool AttackShow1
	{
		get
		{
			if (_oAttack1 != null)
			{
				return _oAttack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttackShow1 != value && _oAttack1 != null)
			{
				_oAttack1.SetObjectActive(value);
			}
		}
	}

	public bool AttackShow2
	{
		get
		{
			if (_oAttack2 != null)
			{
				return _oAttack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttackShow2 != value && _oAttack2 != null)
			{
				_oAttack2.SetObjectActive(value);
			}
		}
	}

	public string AttackTypeString1
	{
		get
		{
			if (_oAttackTypeText1 != null)
			{
				return _oAttackTypeText1.text;
			}
			return null;
		}
		set
		{
			if (AttackTypeString1 != value && _oAttackTypeText1 != null)
			{
				_oAttackTypeText1.text = value;
			}
		}
	}

	public string AttackTypeString2
	{
		get
		{
			if (_oAttackTypeText2 != null)
			{
				return _oAttackTypeText2.text;
			}
			return null;
		}
		set
		{
			if (AttackTypeString2 != value && _oAttackTypeText2 != null)
			{
				_oAttackTypeText2.text = value;
			}
		}
	}

	public bool MonterPanelShow
	{
		get
		{
			if (_oMonterPanel != null)
			{
				return _oMonterPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MonterPanelShow != value && _oMonterPanel != null)
			{
				_oMonterPanel.SetObjectActive(value);
			}
		}
	}

	public bool BottommHpImageShow
	{
		get
		{
			if (_oBottommHpImage != null)
			{
				return _oBottommHpImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottommHpImageShow != value && _oBottommHpImage != null)
			{
				_oBottommHpImage.SetObjectActive(value);
			}
		}
	}

	public float EffectmHpProgressBarFillamount
	{
		get
		{
			if (_oEffectmHpProgressBarImage != null)
			{
				return _oEffectmHpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EffectmHpProgressBarFillamount != value && _oEffectmHpProgressBarImage != null)
			{
				_oEffectmHpProgressBarImage.fillAmount = value;
			}
		}
	}

	public Sprite CurmHpProgressBarSprite
	{
		get
		{
			if (_oCurmHpProgressBarImage != null)
			{
				return _oCurmHpProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (CurmHpProgressBarSprite != value && _oCurmHpProgressBarImage != null)
			{
				_oCurmHpProgressBarImage.sprite = value;
			}
		}
	}

	public float CurmHpProgressBarFillamount
	{
		get
		{
			if (_oCurmHpProgressBarImage != null)
			{
				return _oCurmHpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CurmHpProgressBarFillamount != value && _oCurmHpProgressBarImage != null)
			{
				_oCurmHpProgressBarImage.fillAmount = value;
			}
		}
	}

	public bool BottomHdImageShow
	{
		get
		{
			if (_oBottomHdImage != null)
			{
				return _oBottomHdImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomHdImageShow != value && _oBottomHdImage != null)
			{
				_oBottomHdImage.SetObjectActive(value);
			}
		}
	}

	public float EffectHdProgressBarFillamount
	{
		get
		{
			if (_oEffectHdProgressBarImage != null)
			{
				return _oEffectHdProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EffectHdProgressBarFillamount != value && _oEffectHdProgressBarImage != null)
			{
				_oEffectHdProgressBarImage.fillAmount = value;
			}
		}
	}

	public Sprite CurHdProgressBarSprite
	{
		get
		{
			if (_oCurHdProgressBarImage != null)
			{
				return _oCurHdProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (CurHdProgressBarSprite != value && _oCurHdProgressBarImage != null)
			{
				_oCurHdProgressBarImage.sprite = value;
			}
		}
	}

	public float CurHdProgressBarFillamount
	{
		get
		{
			if (_oCurHdProgressBarImage != null)
			{
				return _oCurHdProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CurHdProgressBarFillamount != value && _oCurHdProgressBarImage != null)
			{
				_oCurHdProgressBarImage.fillAmount = value;
			}
		}
	}

	public bool BottomZjImageShow
	{
		get
		{
			if (_oBottomZjImage != null)
			{
				return _oBottomZjImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomZjImageShow != value && _oBottomZjImage != null)
			{
				_oBottomZjImage.SetObjectActive(value);
			}
		}
	}

	public float EffectZjProgressBarFillamount
	{
		get
		{
			if (_oEffectZjProgressBarImage != null)
			{
				return _oEffectZjProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EffectZjProgressBarFillamount != value && _oEffectZjProgressBarImage != null)
			{
				_oEffectZjProgressBarImage.fillAmount = value;
			}
		}
	}

	public Sprite CurZjProgressBarSprite
	{
		get
		{
			if (_oCurZjProgressBarImage != null)
			{
				return _oCurZjProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (CurZjProgressBarSprite != value && _oCurZjProgressBarImage != null)
			{
				_oCurZjProgressBarImage.sprite = value;
			}
		}
	}

	public float CurZjProgressBarFillamount
	{
		get
		{
			if (_oCurZjProgressBarImage != null)
			{
				return _oCurZjProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CurZjProgressBarFillamount != value && _oCurZjProgressBarImage != null)
			{
				_oCurZjProgressBarImage.fillAmount = value;
			}
		}
	}

	public bool lockHpShow
	{
		get
		{
			if (_olockHp != null)
			{
				return _olockHp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lockHpShow != value && _olockHp != null)
			{
				_olockHp.SetObjectActive(value);
			}
		}
	}

	public float locklFillamount
	{
		get
		{
			if (_olocklImage != null)
			{
				return _olocklImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (locklFillamount != value && _olocklImage != null)
			{
				_olocklImage.fillAmount = value;
			}
		}
	}

	public float lockrFillamount
	{
		get
		{
			if (_olockrImage != null)
			{
				return _olockrImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (lockrFillamount != value && _olockrImage != null)
			{
				_olockrImage.fillAmount = value;
			}
		}
	}

	public Sprite effeectSprite
	{
		get
		{
			if (_oeffeectImage != null)
			{
				return _oeffeectImage.sprite;
			}
			return null;
		}
		set
		{
			if (effeectSprite != value && _oeffeectImage != null)
			{
				_oeffeectImage.sprite = value;
			}
		}
	}

	public Sprite lockmsgSprite
	{
		get
		{
			if (_olockmsgImage != null)
			{
				return _olockmsgImage.sprite;
			}
			return null;
		}
		set
		{
			if (lockmsgSprite != value && _olockmsgImage != null)
			{
				_olockmsgImage.sprite = value;
			}
		}
	}

	public bool lockeffectShow
	{
		get
		{
			if (_olockeffect != null)
			{
				return _olockeffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lockeffectShow != value && _olockeffect != null)
			{
				_olockeffect.SetObjectActive(value);
			}
		}
	}

	public Sprite lockeffectSprite
	{
		get
		{
			if (_olockeffectImage != null)
			{
				return _olockeffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (lockeffectSprite != value && _olockeffectImage != null)
			{
				_olockeffectImage.sprite = value;
			}
		}
	}

	public bool AddResisShow
	{
		get
		{
			if (_oAddResis != null)
			{
				return _oAddResis.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AddResisShow != value && _oAddResis != null)
			{
				_oAddResis.SetObjectActive(value);
			}
		}
	}

	public Sprite bgSprite
	{
		get
		{
			if (_obgImage != null)
			{
				return _obgImage.sprite;
			}
			return null;
		}
		set
		{
			if (bgSprite != value && _obgImage != null)
			{
				_obgImage.sprite = value;
			}
		}
	}

	public bool bsaddShow
	{
		get
		{
			if (_obsadd != null)
			{
				return _obsadd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bsaddShow != value && _obsadd != null)
			{
				_obsadd.SetObjectActive(value);
			}
		}
	}

	public bool bladdShow
	{
		get
		{
			if (_obladd != null)
			{
				return _obladd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bladdShow != value && _obladd != null)
			{
				_obladd.SetObjectActive(value);
			}
		}
	}

	public float YanHpImageFillamount
	{
		get
		{
			if (_oYanHpImageImage != null)
			{
				return _oYanHpImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (YanHpImageFillamount != value && _oYanHpImageImage != null)
			{
				_oYanHpImageImage.fillAmount = value;
			}
		}
	}

	public float YinHpImageFillamount
	{
		get
		{
			if (_oYinHpImageImage != null)
			{
				return _oYinHpImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (YinHpImageFillamount != value && _oYinHpImageImage != null)
			{
				_oYinHpImageImage.fillAmount = value;
			}
		}
	}

	public bool buffShow1
	{
		get
		{
			if (_obuff1 != null)
			{
				return _obuff1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow1 != value && _obuff1 != null)
			{
				_obuff1.SetObjectActive(value);
			}
		}
	}

	public bool buffShow2
	{
		get
		{
			if (_obuff2 != null)
			{
				return _obuff2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow2 != value && _obuff2 != null)
			{
				_obuff2.SetObjectActive(value);
			}
		}
	}

	public bool buffShow3
	{
		get
		{
			if (_obuff3 != null)
			{
				return _obuff3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow3 != value && _obuff3 != null)
			{
				_obuff3.SetObjectActive(value);
			}
		}
	}

	public bool buffShow4
	{
		get
		{
			if (_obuff4 != null)
			{
				return _obuff4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow4 != value && _obuff4 != null)
			{
				_obuff4.SetObjectActive(value);
			}
		}
	}

	public bool buffShow5
	{
		get
		{
			if (_obuff5 != null)
			{
				return _obuff5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow5 != value && _obuff5 != null)
			{
				_obuff5.SetObjectActive(value);
			}
		}
	}

	public bool buffShow6
	{
		get
		{
			if (_obuff6 != null)
			{
				return _obuff6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow6 != value && _obuff6 != null)
			{
				_obuff6.SetObjectActive(value);
			}
		}
	}

	public Sprite bufficonSprite1
	{
		get
		{
			if (_obufficonImage1 != null)
			{
				return _obufficonImage1.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite1 != value && _obufficonImage1 != null)
			{
				_obufficonImage1.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite2
	{
		get
		{
			if (_obufficonImage2 != null)
			{
				return _obufficonImage2.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite2 != value && _obufficonImage2 != null)
			{
				_obufficonImage2.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite3
	{
		get
		{
			if (_obufficonImage3 != null)
			{
				return _obufficonImage3.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite3 != value && _obufficonImage3 != null)
			{
				_obufficonImage3.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite4
	{
		get
		{
			if (_obufficonImage4 != null)
			{
				return _obufficonImage4.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite4 != value && _obufficonImage4 != null)
			{
				_obufficonImage4.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite5
	{
		get
		{
			if (_obufficonImage5 != null)
			{
				return _obufficonImage5.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite5 != value && _obufficonImage5 != null)
			{
				_obufficonImage5.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite6
	{
		get
		{
			if (_obufficonImage6 != null)
			{
				return _obufficonImage6.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite6 != value && _obufficonImage6 != null)
			{
				_obufficonImage6.sprite = value;
			}
		}
	}

	public string buffValueString1
	{
		get
		{
			if (_obuffValueText1 != null)
			{
				return _obuffValueText1.text;
			}
			return null;
		}
		set
		{
			if (buffValueString1 != value && _obuffValueText1 != null)
			{
				_obuffValueText1.text = value;
			}
		}
	}

	public string buffValueString2
	{
		get
		{
			if (_obuffValueText2 != null)
			{
				return _obuffValueText2.text;
			}
			return null;
		}
		set
		{
			if (buffValueString2 != value && _obuffValueText2 != null)
			{
				_obuffValueText2.text = value;
			}
		}
	}

	public string buffValueString3
	{
		get
		{
			if (_obuffValueText3 != null)
			{
				return _obuffValueText3.text;
			}
			return null;
		}
		set
		{
			if (buffValueString3 != value && _obuffValueText3 != null)
			{
				_obuffValueText3.text = value;
			}
		}
	}

	public string buffValueString4
	{
		get
		{
			if (_obuffValueText4 != null)
			{
				return _obuffValueText4.text;
			}
			return null;
		}
		set
		{
			if (buffValueString4 != value && _obuffValueText4 != null)
			{
				_obuffValueText4.text = value;
			}
		}
	}

	public string buffValueString5
	{
		get
		{
			if (_obuffValueText5 != null)
			{
				return _obuffValueText5.text;
			}
			return null;
		}
		set
		{
			if (buffValueString5 != value && _obuffValueText5 != null)
			{
				_obuffValueText5.text = value;
			}
		}
	}

	public string buffValueString6
	{
		get
		{
			if (_obuffValueText6 != null)
			{
				return _obuffValueText6.text;
			}
			return null;
		}
		set
		{
			if (buffValueString6 != value && _obuffValueText6 != null)
			{
				_obuffValueText6.text = value;
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
			case "BossIcon":
				_oBossIcon = transform.gameObject;
				_oBossIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BottomHpImage":
				_oBottomHpImage = transform.gameObject;
				_oBottomHpImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectProgressBar":
				_oEffectProgressBar = transform.gameObject;
				_oEffectProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CurHpProgressBar":
				_oCurHpProgressBar = transform.gameObject;
				_oCurHpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "FollowImage":
				_oFollowImage = transform.gameObject;
				_oFollowImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "extraLifeNum":
				_oextraLifeNum = transform.gameObject;
				break;
			case "num":
				_onum = transform.gameObject;
				_onumText = transform.gameObject.GetComponent<Text>();
				break;
			case "HpPercent":
				_oHpPercent = transform.gameObject;
				_oHpPercentText = transform.gameObject.GetComponent<Text>();
				break;
			case "ShieldBg":
				_oShieldBg = transform.gameObject;
				break;
			case "ShieldPercentBg":
				_oShieldPercentBg = transform.gameObject;
				_oShieldPercentBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NameLabel":
				_oNameLabel = transform.gameObject;
				_oNameLabelText = transform.gameObject.GetComponent<Text>();
				break;
			case "AttributeImage1":
				_oAttributeImage1 = transform.gameObject;
				_oAttributeImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage2":
				_oAttributeImage2 = transform.gameObject;
				_oAttributeImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage3":
				_oAttributeImage3 = transform.gameObject;
				_oAttributeImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage4":
				_oAttributeImage4 = transform.gameObject;
				_oAttributeImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "LvLabel":
				_oLvLabel = transform.gameObject;
				_oLvLabelText = transform.gameObject.GetComponent<Text>();
				break;
			case "KulouImage":
				_oKulouImage = transform.gameObject;
				break;
			case "Race1":
				_oRace1 = transform.gameObject;
				break;
			case "Race2":
				_oRace2 = transform.gameObject;
				break;
			case "Race3":
				_oRace3 = transform.gameObject;
				break;
			case "Race4":
				_oRace4 = transform.gameObject;
				break;
			case "Race5":
				_oRace5 = transform.gameObject;
				break;
			case "RaceName1":
				_oRaceName1 = transform.gameObject;
				_oRaceNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName2":
				_oRaceName2 = transform.gameObject;
				_oRaceNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName3":
				_oRaceName3 = transform.gameObject;
				_oRaceNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName4":
				_oRaceName4 = transform.gameObject;
				_oRaceNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName5":
				_oRaceName5 = transform.gameObject;
				_oRaceNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Attack1":
				_oAttack1 = transform.gameObject;
				break;
			case "Attack2":
				_oAttack2 = transform.gameObject;
				break;
			case "AttackType1":
				_oAttackType1 = transform.gameObject;
				_oAttackTypeText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "AttackType2":
				_oAttackType2 = transform.gameObject;
				_oAttackTypeText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "MonterPanel":
				_oMonterPanel = transform.gameObject;
				break;
			case "BottommHpImage":
				_oBottommHpImage = transform.gameObject;
				break;
			case "EffectmHpProgressBar":
				_oEffectmHpProgressBar = transform.gameObject;
				_oEffectmHpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CurmHpProgressBar":
				_oCurmHpProgressBar = transform.gameObject;
				_oCurmHpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BottomHdImage":
				_oBottomHdImage = transform.gameObject;
				break;
			case "EffectHdProgressBar":
				_oEffectHdProgressBar = transform.gameObject;
				_oEffectHdProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CurHdProgressBar":
				_oCurHdProgressBar = transform.gameObject;
				_oCurHdProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BottomZjImage":
				_oBottomZjImage = transform.gameObject;
				break;
			case "EffectZjProgressBar":
				_oEffectZjProgressBar = transform.gameObject;
				_oEffectZjProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CurZjProgressBar":
				_oCurZjProgressBar = transform.gameObject;
				_oCurZjProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lockHp":
				_olockHp = transform.gameObject;
				break;
			case "lockl":
				_olockl = transform.gameObject;
				_olocklImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lockr":
				_olockr = transform.gameObject;
				_olockrImage = transform.gameObject.GetComponent<Image>();
				break;
			case "effeect":
				_oeffeect = transform.gameObject;
				_oeffeectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lockmsg":
				_olockmsg = transform.gameObject;
				_olockmsgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lockeffect":
				_olockeffect = transform.gameObject;
				_olockeffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AddResis":
				_oAddResis = transform.gameObject;
				break;
			case "bg":
				_obg = transform.gameObject;
				_obgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "bsadd":
				_obsadd = transform.gameObject;
				break;
			case "bladd":
				_obladd = transform.gameObject;
				break;
			case "YanHpImage":
				_oYanHpImage = transform.gameObject;
				_oYanHpImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "YinHpImage":
				_oYinHpImage = transform.gameObject;
				_oYinHpImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "buff1":
				_obuff1 = transform.gameObject;
				break;
			case "buff2":
				_obuff2 = transform.gameObject;
				break;
			case "buff3":
				_obuff3 = transform.gameObject;
				break;
			case "buff4":
				_obuff4 = transform.gameObject;
				break;
			case "buff5":
				_obuff5 = transform.gameObject;
				break;
			case "buff6":
				_obuff6 = transform.gameObject;
				break;
			case "bufficon1":
				_obufficon1 = transform.gameObject;
				_obufficonImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon2":
				_obufficon2 = transform.gameObject;
				_obufficonImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon3":
				_obufficon3 = transform.gameObject;
				_obufficonImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon4":
				_obufficon4 = transform.gameObject;
				_obufficonImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon5":
				_obufficon5 = transform.gameObject;
				_obufficonImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon6":
				_obufficon6 = transform.gameObject;
				_obufficonImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "buffValue1":
				_obuffValue1 = transform.gameObject;
				_obuffValueText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffValue2":
				_obuffValue2 = transform.gameObject;
				_obuffValueText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffValue3":
				_obuffValue3 = transform.gameObject;
				_obuffValueText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffValue4":
				_obuffValue4 = transform.gameObject;
				_obuffValueText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffValue5":
				_obuffValue5 = transform.gameObject;
				_obuffValueText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffValue6":
				_obuffValue6 = transform.gameObject;
				_obuffValueText6 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
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

	public void BossIconNtvsize()
	{
		if (_oBossIconImage != null)
		{
			_oBossIconImage.SetNativeSize();
		}
	}

	public bool GetAttributeImageShow(int index)
	{
		return index switch
		{
			1 => AttributeImageShow1, 
			2 => AttributeImageShow2, 
			3 => AttributeImageShow3, 
			4 => AttributeImageShow4, 
			_ => false, 
		};
	}

	public void SetAttributeImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AttributeImageShow1 = value;
			break;
		case 2:
			AttributeImageShow2 = value;
			break;
		case 3:
			AttributeImageShow3 = value;
			break;
		case 4:
			AttributeImageShow4 = value;
			break;
		}
	}

	public int GetAttributeImageCount()
	{
		return 4;
	}

	public Sprite GetAttributeImageSprite(int index)
	{
		return index switch
		{
			1 => AttributeImageSprite1, 
			2 => AttributeImageSprite2, 
			3 => AttributeImageSprite3, 
			4 => AttributeImageSprite4, 
			_ => null, 
		};
	}

	public void SetAttributeImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			AttributeImageSprite1 = value;
			break;
		case 2:
			AttributeImageSprite2 = value;
			break;
		case 3:
			AttributeImageSprite3 = value;
			break;
		case 4:
			AttributeImageSprite4 = value;
			break;
		}
	}

	public bool GetRaceShow(int index)
	{
		return index switch
		{
			1 => RaceShow1, 
			2 => RaceShow2, 
			3 => RaceShow3, 
			4 => RaceShow4, 
			5 => RaceShow5, 
			_ => false, 
		};
	}

	public void SetRaceShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RaceShow1 = value;
			break;
		case 2:
			RaceShow2 = value;
			break;
		case 3:
			RaceShow3 = value;
			break;
		case 4:
			RaceShow4 = value;
			break;
		case 5:
			RaceShow5 = value;
			break;
		}
	}

	public int GetRaceCount()
	{
		return 5;
	}

	public string GetRaceNameString(int index)
	{
		return index switch
		{
			1 => RaceNameString1, 
			2 => RaceNameString2, 
			3 => RaceNameString3, 
			4 => RaceNameString4, 
			5 => RaceNameString5, 
			_ => null, 
		};
	}

	public void SetRaceNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			RaceNameString1 = value;
			break;
		case 2:
			RaceNameString2 = value;
			break;
		case 3:
			RaceNameString3 = value;
			break;
		case 4:
			RaceNameString4 = value;
			break;
		case 5:
			RaceNameString5 = value;
			break;
		}
	}

	public int GetRaceNameCount()
	{
		return 5;
	}

	public bool GetAttackShow(int index)
	{
		return index switch
		{
			1 => AttackShow1, 
			2 => AttackShow2, 
			_ => false, 
		};
	}

	public void SetAttackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AttackShow1 = value;
			break;
		case 2:
			AttackShow2 = value;
			break;
		}
	}

	public int GetAttackCount()
	{
		return 2;
	}

	public string GetAttackTypeString(int index)
	{
		return index switch
		{
			1 => AttackTypeString1, 
			2 => AttackTypeString2, 
			_ => null, 
		};
	}

	public void SetAttackTypeString(int index, string value)
	{
		switch (index)
		{
		case 1:
			AttackTypeString1 = value;
			break;
		case 2:
			AttackTypeString2 = value;
			break;
		}
	}

	public int GetAttackTypeCount()
	{
		return 2;
	}

	public bool GetbuffShow(int index)
	{
		return index switch
		{
			1 => buffShow1, 
			2 => buffShow2, 
			3 => buffShow3, 
			4 => buffShow4, 
			5 => buffShow5, 
			6 => buffShow6, 
			_ => false, 
		};
	}

	public void SetbuffShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			buffShow1 = value;
			break;
		case 2:
			buffShow2 = value;
			break;
		case 3:
			buffShow3 = value;
			break;
		case 4:
			buffShow4 = value;
			break;
		case 5:
			buffShow5 = value;
			break;
		case 6:
			buffShow6 = value;
			break;
		}
	}

	public int GetbuffCount()
	{
		return 6;
	}

	public Sprite GetbufficonSprite(int index)
	{
		return index switch
		{
			1 => bufficonSprite1, 
			2 => bufficonSprite2, 
			3 => bufficonSprite3, 
			4 => bufficonSprite4, 
			5 => bufficonSprite5, 
			6 => bufficonSprite6, 
			_ => null, 
		};
	}

	public void SetbufficonSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			bufficonSprite1 = value;
			break;
		case 2:
			bufficonSprite2 = value;
			break;
		case 3:
			bufficonSprite3 = value;
			break;
		case 4:
			bufficonSprite4 = value;
			break;
		case 5:
			bufficonSprite5 = value;
			break;
		case 6:
			bufficonSprite6 = value;
			break;
		}
	}

	public int GetbufficonCount()
	{
		return 6;
	}

	public string GetbuffValueString(int index)
	{
		return index switch
		{
			1 => buffValueString1, 
			2 => buffValueString2, 
			3 => buffValueString3, 
			4 => buffValueString4, 
			5 => buffValueString5, 
			6 => buffValueString6, 
			_ => null, 
		};
	}

	public void SetbuffValueString(int index, string value)
	{
		switch (index)
		{
		case 1:
			buffValueString1 = value;
			break;
		case 2:
			buffValueString2 = value;
			break;
		case 3:
			buffValueString3 = value;
			break;
		case 4:
			buffValueString4 = value;
			break;
		case 5:
			buffValueString5 = value;
			break;
		case 6:
			buffValueString6 = value;
			break;
		}
	}

	public int GetbuffValueCount()
	{
		return 6;
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
