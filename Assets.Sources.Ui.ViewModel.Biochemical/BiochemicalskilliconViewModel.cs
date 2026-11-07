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

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalskilliconViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSkill1;

	private GameObject _oSkill2;

	private GameObject _oSkill3;

	private GameObject _oSkill4;

	private GameObject _oBackImage1;

	private GameObject _oBackImage2;

	private GameObject _oBackImage3;

	private GameObject _oBackImage4;

	private Image _oBackImageImage1;

	private Image _oBackImageImage2;

	private Image _oBackImageImage3;

	private Image _oBackImageImage4;

	private GameObject _oWaitImage1;

	private GameObject _oWaitImage2;

	private GameObject _oWaitImage3;

	private GameObject _oWaitImage4;

	private Image _oWaitImageImage1;

	private Image _oWaitImageImage2;

	private Image _oWaitImageImage3;

	private Image _oWaitImageImage4;

	private GameObject _oMaskImage1;

	private GameObject _oMaskImage2;

	private GameObject _oMaskImage3;

	private GameObject _oMaskImage4;

	private Image _oMaskImageImage1;

	private Image _oMaskImageImage2;

	private Image _oMaskImageImage3;

	private Image _oMaskImageImage4;

	private GameObject _oTimeText1;

	private GameObject _oTimeText2;

	private GameObject _oTimeText3;

	private GameObject _oTimeText4;

	private Text _oTimeTextText1;

	private Text _oTimeTextText2;

	private Text _oTimeTextText3;

	private Text _oTimeTextText4;

	private GameObject _oMpText1;

	private GameObject _oMpText2;

	private GameObject _oMpText3;

	private GameObject _oMpText4;

	private Text _oMpTextText1;

	private Text _oMpTextText2;

	private Text _oMpTextText3;

	private Text _oMpTextText4;

	private GameObject _oEffectImage1;

	private GameObject _oEffectImage2;

	private GameObject _oEffectImage3;

	private GameObject _oEffectImage4;

	private Image _oEffectImageImage1;

	private Image _oEffectImageImage2;

	private Image _oEffectImageImage3;

	private Image _oEffectImageImage4;

	private GameObject _oMessage;

	private CanvasGroup _oMessageCanvasGroup;

	private Image _oMessageImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalskillicon";

	private List<RectTransform> _holdPosTrans;

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

	public bool SkillShow1
	{
		get
		{
			if (_oSkill1 != null)
			{
				return _oSkill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow1 != value && _oSkill1 != null)
			{
				_oSkill1.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow2
	{
		get
		{
			if (_oSkill2 != null)
			{
				return _oSkill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow2 != value && _oSkill2 != null)
			{
				_oSkill2.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow3
	{
		get
		{
			if (_oSkill3 != null)
			{
				return _oSkill3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow3 != value && _oSkill3 != null)
			{
				_oSkill3.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow4
	{
		get
		{
			if (_oSkill4 != null)
			{
				return _oSkill4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow4 != value && _oSkill4 != null)
			{
				_oSkill4.SetObjectActive(value);
			}
		}
	}

	public bool BackImageShow1
	{
		get
		{
			if (_oBackImage1 != null)
			{
				return _oBackImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackImageShow1 != value && _oBackImage1 != null)
			{
				_oBackImage1.SetObjectActive(value);
			}
		}
	}

	public bool BackImageShow2
	{
		get
		{
			if (_oBackImage2 != null)
			{
				return _oBackImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackImageShow2 != value && _oBackImage2 != null)
			{
				_oBackImage2.SetObjectActive(value);
			}
		}
	}

	public bool BackImageShow3
	{
		get
		{
			if (_oBackImage3 != null)
			{
				return _oBackImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackImageShow3 != value && _oBackImage3 != null)
			{
				_oBackImage3.SetObjectActive(value);
			}
		}
	}

	public bool BackImageShow4
	{
		get
		{
			if (_oBackImage4 != null)
			{
				return _oBackImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackImageShow4 != value && _oBackImage4 != null)
			{
				_oBackImage4.SetObjectActive(value);
			}
		}
	}

	public Sprite BackImageSprite1
	{
		get
		{
			if (_oBackImageImage1 != null)
			{
				return _oBackImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite1 != value && _oBackImageImage1 != null)
			{
				_oBackImageImage1.sprite = value;
			}
		}
	}

	public Sprite BackImageSprite2
	{
		get
		{
			if (_oBackImageImage2 != null)
			{
				return _oBackImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite2 != value && _oBackImageImage2 != null)
			{
				_oBackImageImage2.sprite = value;
			}
		}
	}

	public Sprite BackImageSprite3
	{
		get
		{
			if (_oBackImageImage3 != null)
			{
				return _oBackImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite3 != value && _oBackImageImage3 != null)
			{
				_oBackImageImage3.sprite = value;
			}
		}
	}

	public Sprite BackImageSprite4
	{
		get
		{
			if (_oBackImageImage4 != null)
			{
				return _oBackImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite4 != value && _oBackImageImage4 != null)
			{
				_oBackImageImage4.sprite = value;
			}
		}
	}

	public bool WaitImageShow1
	{
		get
		{
			if (_oWaitImage1 != null)
			{
				return _oWaitImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitImageShow1 != value && _oWaitImage1 != null)
			{
				_oWaitImage1.SetObjectActive(value);
			}
		}
	}

	public bool WaitImageShow2
	{
		get
		{
			if (_oWaitImage2 != null)
			{
				return _oWaitImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitImageShow2 != value && _oWaitImage2 != null)
			{
				_oWaitImage2.SetObjectActive(value);
			}
		}
	}

	public bool WaitImageShow3
	{
		get
		{
			if (_oWaitImage3 != null)
			{
				return _oWaitImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitImageShow3 != value && _oWaitImage3 != null)
			{
				_oWaitImage3.SetObjectActive(value);
			}
		}
	}

	public bool WaitImageShow4
	{
		get
		{
			if (_oWaitImage4 != null)
			{
				return _oWaitImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitImageShow4 != value && _oWaitImage4 != null)
			{
				_oWaitImage4.SetObjectActive(value);
			}
		}
	}

	public Sprite WaitImageSprite1
	{
		get
		{
			if (_oWaitImageImage1 != null)
			{
				return _oWaitImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WaitImageSprite1 != value && _oWaitImageImage1 != null)
			{
				_oWaitImageImage1.sprite = value;
			}
		}
	}

	public Sprite WaitImageSprite2
	{
		get
		{
			if (_oWaitImageImage2 != null)
			{
				return _oWaitImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WaitImageSprite2 != value && _oWaitImageImage2 != null)
			{
				_oWaitImageImage2.sprite = value;
			}
		}
	}

	public Sprite WaitImageSprite3
	{
		get
		{
			if (_oWaitImageImage3 != null)
			{
				return _oWaitImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WaitImageSprite3 != value && _oWaitImageImage3 != null)
			{
				_oWaitImageImage3.sprite = value;
			}
		}
	}

	public Sprite WaitImageSprite4
	{
		get
		{
			if (_oWaitImageImage4 != null)
			{
				return _oWaitImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WaitImageSprite4 != value && _oWaitImageImage4 != null)
			{
				_oWaitImageImage4.sprite = value;
			}
		}
	}

	public float MaskImageFillamount1
	{
		get
		{
			if (_oMaskImageImage1 != null)
			{
				return _oMaskImageImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskImageFillamount1 != value && _oMaskImageImage1 != null)
			{
				_oMaskImageImage1.fillAmount = value;
			}
		}
	}

	public float MaskImageFillamount2
	{
		get
		{
			if (_oMaskImageImage2 != null)
			{
				return _oMaskImageImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskImageFillamount2 != value && _oMaskImageImage2 != null)
			{
				_oMaskImageImage2.fillAmount = value;
			}
		}
	}

	public float MaskImageFillamount3
	{
		get
		{
			if (_oMaskImageImage3 != null)
			{
				return _oMaskImageImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskImageFillamount3 != value && _oMaskImageImage3 != null)
			{
				_oMaskImageImage3.fillAmount = value;
			}
		}
	}

	public float MaskImageFillamount4
	{
		get
		{
			if (_oMaskImageImage4 != null)
			{
				return _oMaskImageImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskImageFillamount4 != value && _oMaskImageImage4 != null)
			{
				_oMaskImageImage4.fillAmount = value;
			}
		}
	}

	public bool TimeTextShow1
	{
		get
		{
			if (_oTimeText1 != null)
			{
				return _oTimeText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimeTextShow1 != value && _oTimeText1 != null)
			{
				_oTimeText1.SetObjectActive(value);
			}
		}
	}

	public bool TimeTextShow2
	{
		get
		{
			if (_oTimeText2 != null)
			{
				return _oTimeText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimeTextShow2 != value && _oTimeText2 != null)
			{
				_oTimeText2.SetObjectActive(value);
			}
		}
	}

	public bool TimeTextShow3
	{
		get
		{
			if (_oTimeText3 != null)
			{
				return _oTimeText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimeTextShow3 != value && _oTimeText3 != null)
			{
				_oTimeText3.SetObjectActive(value);
			}
		}
	}

	public bool TimeTextShow4
	{
		get
		{
			if (_oTimeText4 != null)
			{
				return _oTimeText4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimeTextShow4 != value && _oTimeText4 != null)
			{
				_oTimeText4.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString1
	{
		get
		{
			if (_oTimeTextText1 != null)
			{
				return _oTimeTextText1.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString1 != value && _oTimeTextText1 != null)
			{
				_oTimeTextText1.text = value;
			}
		}
	}

	public string TimeTextString2
	{
		get
		{
			if (_oTimeTextText2 != null)
			{
				return _oTimeTextText2.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString2 != value && _oTimeTextText2 != null)
			{
				_oTimeTextText2.text = value;
			}
		}
	}

	public string TimeTextString3
	{
		get
		{
			if (_oTimeTextText3 != null)
			{
				return _oTimeTextText3.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString3 != value && _oTimeTextText3 != null)
			{
				_oTimeTextText3.text = value;
			}
		}
	}

	public string TimeTextString4
	{
		get
		{
			if (_oTimeTextText4 != null)
			{
				return _oTimeTextText4.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString4 != value && _oTimeTextText4 != null)
			{
				_oTimeTextText4.text = value;
			}
		}
	}

	public bool MpTextShow1
	{
		get
		{
			if (_oMpText1 != null)
			{
				return _oMpText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MpTextShow1 != value && _oMpText1 != null)
			{
				_oMpText1.SetObjectActive(value);
			}
		}
	}

	public bool MpTextShow2
	{
		get
		{
			if (_oMpText2 != null)
			{
				return _oMpText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MpTextShow2 != value && _oMpText2 != null)
			{
				_oMpText2.SetObjectActive(value);
			}
		}
	}

	public bool MpTextShow3
	{
		get
		{
			if (_oMpText3 != null)
			{
				return _oMpText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MpTextShow3 != value && _oMpText3 != null)
			{
				_oMpText3.SetObjectActive(value);
			}
		}
	}

	public bool MpTextShow4
	{
		get
		{
			if (_oMpText4 != null)
			{
				return _oMpText4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MpTextShow4 != value && _oMpText4 != null)
			{
				_oMpText4.SetObjectActive(value);
			}
		}
	}

	public string MpTextString1
	{
		get
		{
			if (_oMpTextText1 != null)
			{
				return _oMpTextText1.text;
			}
			return null;
		}
		set
		{
			if (MpTextString1 != value && _oMpTextText1 != null)
			{
				_oMpTextText1.text = value;
			}
		}
	}

	public string MpTextString2
	{
		get
		{
			if (_oMpTextText2 != null)
			{
				return _oMpTextText2.text;
			}
			return null;
		}
		set
		{
			if (MpTextString2 != value && _oMpTextText2 != null)
			{
				_oMpTextText2.text = value;
			}
		}
	}

	public string MpTextString3
	{
		get
		{
			if (_oMpTextText3 != null)
			{
				return _oMpTextText3.text;
			}
			return null;
		}
		set
		{
			if (MpTextString3 != value && _oMpTextText3 != null)
			{
				_oMpTextText3.text = value;
			}
		}
	}

	public string MpTextString4
	{
		get
		{
			if (_oMpTextText4 != null)
			{
				return _oMpTextText4.text;
			}
			return null;
		}
		set
		{
			if (MpTextString4 != value && _oMpTextText4 != null)
			{
				_oMpTextText4.text = value;
			}
		}
	}

	public bool EffectImageShow1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1.SetObjectActive(value);
			}
		}
	}

	public bool EffectImageShow2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2.SetObjectActive(value);
			}
		}
	}

	public bool EffectImageShow3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3.SetObjectActive(value);
			}
		}
	}

	public bool EffectImageShow4
	{
		get
		{
			if (_oEffectImage4 != null)
			{
				return _oEffectImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow4 != value && _oEffectImage4 != null)
			{
				_oEffectImage4.SetObjectActive(value);
			}
		}
	}

	public Sprite EffectImageSprite1
	{
		get
		{
			if (_oEffectImageImage1 != null)
			{
				return _oEffectImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite1 != value && _oEffectImageImage1 != null)
			{
				_oEffectImageImage1.sprite = value;
			}
		}
	}

	public Sprite EffectImageSprite2
	{
		get
		{
			if (_oEffectImageImage2 != null)
			{
				return _oEffectImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite2 != value && _oEffectImageImage2 != null)
			{
				_oEffectImageImage2.sprite = value;
			}
		}
	}

	public Sprite EffectImageSprite3
	{
		get
		{
			if (_oEffectImageImage3 != null)
			{
				return _oEffectImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite3 != value && _oEffectImageImage3 != null)
			{
				_oEffectImageImage3.sprite = value;
			}
		}
	}

	public Sprite EffectImageSprite4
	{
		get
		{
			if (_oEffectImageImage4 != null)
			{
				return _oEffectImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite4 != value && _oEffectImageImage4 != null)
			{
				_oEffectImageImage4.sprite = value;
			}
		}
	}

	public float MessageAlpha
	{
		get
		{
			if (_oMessageCanvasGroup != null)
			{
				return _oMessageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (MessageAlpha != value && _oMessageCanvasGroup != null)
			{
				_oMessageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite MessageSprite
	{
		get
		{
			if (_oMessageImage != null)
			{
				return _oMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MessageSprite != value && _oMessageImage != null)
			{
				_oMessageImage.sprite = value;
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
			case "Skill1":
				_oSkill1 = transform.gameObject;
				break;
			case "Skill2":
				_oSkill2 = transform.gameObject;
				break;
			case "Skill3":
				_oSkill3 = transform.gameObject;
				break;
			case "Skill4":
				_oSkill4 = transform.gameObject;
				break;
			case "BackImage1":
				_oBackImage1 = transform.gameObject;
				_oBackImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "BackImage2":
				_oBackImage2 = transform.gameObject;
				_oBackImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BackImage3":
				_oBackImage3 = transform.gameObject;
				_oBackImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "BackImage4":
				_oBackImage4 = transform.gameObject;
				_oBackImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "WaitImage1":
				_oWaitImage1 = transform.gameObject;
				_oWaitImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "WaitImage2":
				_oWaitImage2 = transform.gameObject;
				_oWaitImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "WaitImage3":
				_oWaitImage3 = transform.gameObject;
				_oWaitImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "WaitImage4":
				_oWaitImage4 = transform.gameObject;
				_oWaitImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "MaskImage1":
				_oMaskImage1 = transform.gameObject;
				_oMaskImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "MaskImage2":
				_oMaskImage2 = transform.gameObject;
				_oMaskImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "MaskImage3":
				_oMaskImage3 = transform.gameObject;
				_oMaskImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "MaskImage4":
				_oMaskImage4 = transform.gameObject;
				_oMaskImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TimeText1":
				_oTimeText1 = transform.gameObject;
				_oTimeTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TimeText2":
				_oTimeText2 = transform.gameObject;
				_oTimeTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TimeText3":
				_oTimeText3 = transform.gameObject;
				_oTimeTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TimeText4":
				_oTimeText4 = transform.gameObject;
				_oTimeTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "MpText1":
				_oMpText1 = transform.gameObject;
				_oMpTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "MpText2":
				_oMpText2 = transform.gameObject;
				_oMpTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "MpText3":
				_oMpText3 = transform.gameObject;
				_oMpTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "MpText4":
				_oMpText4 = transform.gameObject;
				_oMpTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "EffectImage1":
				_oEffectImage1 = transform.gameObject;
				_oEffectImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectImage2":
				_oEffectImage2 = transform.gameObject;
				_oEffectImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectImage3":
				_oEffectImage3 = transform.gameObject;
				_oEffectImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectImage4":
				_oEffectImage4 = transform.gameObject;
				_oEffectImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Message":
				_oMessage = transform.gameObject;
				_oMessageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oMessageImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetSkillShow(int index)
	{
		return index switch
		{
			1 => SkillShow1, 
			2 => SkillShow2, 
			3 => SkillShow3, 
			4 => SkillShow4, 
			_ => false, 
		};
	}

	public void SetSkillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillShow1 = value;
			break;
		case 2:
			SkillShow2 = value;
			break;
		case 3:
			SkillShow3 = value;
			break;
		case 4:
			SkillShow4 = value;
			break;
		}
	}

	public int GetSkillCount()
	{
		return 4;
	}

	public bool GetBackImageShow(int index)
	{
		return index switch
		{
			1 => BackImageShow1, 
			2 => BackImageShow2, 
			3 => BackImageShow3, 
			4 => BackImageShow4, 
			_ => false, 
		};
	}

	public void SetBackImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BackImageShow1 = value;
			break;
		case 2:
			BackImageShow2 = value;
			break;
		case 3:
			BackImageShow3 = value;
			break;
		case 4:
			BackImageShow4 = value;
			break;
		}
	}

	public int GetBackImageCount()
	{
		return 4;
	}

	public Sprite GetBackImageSprite(int index)
	{
		return index switch
		{
			1 => BackImageSprite1, 
			2 => BackImageSprite2, 
			3 => BackImageSprite3, 
			4 => BackImageSprite4, 
			_ => null, 
		};
	}

	public void SetBackImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BackImageSprite1 = value;
			break;
		case 2:
			BackImageSprite2 = value;
			break;
		case 3:
			BackImageSprite3 = value;
			break;
		case 4:
			BackImageSprite4 = value;
			break;
		}
	}

	public bool GetWaitImageShow(int index)
	{
		return index switch
		{
			1 => WaitImageShow1, 
			2 => WaitImageShow2, 
			3 => WaitImageShow3, 
			4 => WaitImageShow4, 
			_ => false, 
		};
	}

	public void SetWaitImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WaitImageShow1 = value;
			break;
		case 2:
			WaitImageShow2 = value;
			break;
		case 3:
			WaitImageShow3 = value;
			break;
		case 4:
			WaitImageShow4 = value;
			break;
		}
	}

	public int GetWaitImageCount()
	{
		return 4;
	}

	public Sprite GetWaitImageSprite(int index)
	{
		return index switch
		{
			1 => WaitImageSprite1, 
			2 => WaitImageSprite2, 
			3 => WaitImageSprite3, 
			4 => WaitImageSprite4, 
			_ => null, 
		};
	}

	public void SetWaitImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WaitImageSprite1 = value;
			break;
		case 2:
			WaitImageSprite2 = value;
			break;
		case 3:
			WaitImageSprite3 = value;
			break;
		case 4:
			WaitImageSprite4 = value;
			break;
		}
	}

	public float GetMaskImageFillamount(int index)
	{
		return index switch
		{
			1 => MaskImageFillamount1, 
			2 => MaskImageFillamount2, 
			3 => MaskImageFillamount3, 
			4 => MaskImageFillamount4, 
			_ => 0f, 
		};
	}

	public void SetMaskImageFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			MaskImageFillamount1 = value;
			break;
		case 2:
			MaskImageFillamount2 = value;
			break;
		case 3:
			MaskImageFillamount3 = value;
			break;
		case 4:
			MaskImageFillamount4 = value;
			break;
		}
	}

	public int GetMaskImageCount()
	{
		return 4;
	}

	public bool GetTimeTextShow(int index)
	{
		return index switch
		{
			1 => TimeTextShow1, 
			2 => TimeTextShow2, 
			3 => TimeTextShow3, 
			4 => TimeTextShow4, 
			_ => false, 
		};
	}

	public void SetTimeTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TimeTextShow1 = value;
			break;
		case 2:
			TimeTextShow2 = value;
			break;
		case 3:
			TimeTextShow3 = value;
			break;
		case 4:
			TimeTextShow4 = value;
			break;
		}
	}

	public int GetTimeTextCount()
	{
		return 4;
	}

	public string GetTimeTextString(int index)
	{
		return index switch
		{
			1 => TimeTextString1, 
			2 => TimeTextString2, 
			3 => TimeTextString3, 
			4 => TimeTextString4, 
			_ => null, 
		};
	}

	public void SetTimeTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TimeTextString1 = value;
			break;
		case 2:
			TimeTextString2 = value;
			break;
		case 3:
			TimeTextString3 = value;
			break;
		case 4:
			TimeTextString4 = value;
			break;
		}
	}

	public bool GetMpTextShow(int index)
	{
		return index switch
		{
			1 => MpTextShow1, 
			2 => MpTextShow2, 
			3 => MpTextShow3, 
			4 => MpTextShow4, 
			_ => false, 
		};
	}

	public void SetMpTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MpTextShow1 = value;
			break;
		case 2:
			MpTextShow2 = value;
			break;
		case 3:
			MpTextShow3 = value;
			break;
		case 4:
			MpTextShow4 = value;
			break;
		}
	}

	public int GetMpTextCount()
	{
		return 4;
	}

	public string GetMpTextString(int index)
	{
		return index switch
		{
			1 => MpTextString1, 
			2 => MpTextString2, 
			3 => MpTextString3, 
			4 => MpTextString4, 
			_ => null, 
		};
	}

	public void SetMpTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			MpTextString1 = value;
			break;
		case 2:
			MpTextString2 = value;
			break;
		case 3:
			MpTextString3 = value;
			break;
		case 4:
			MpTextString4 = value;
			break;
		}
	}

	public bool GetEffectImageShow(int index)
	{
		return index switch
		{
			1 => EffectImageShow1, 
			2 => EffectImageShow2, 
			3 => EffectImageShow3, 
			4 => EffectImageShow4, 
			_ => false, 
		};
	}

	public void SetEffectImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			EffectImageShow1 = value;
			break;
		case 2:
			EffectImageShow2 = value;
			break;
		case 3:
			EffectImageShow3 = value;
			break;
		case 4:
			EffectImageShow4 = value;
			break;
		}
	}

	public int GetEffectImageCount()
	{
		return 4;
	}

	public Sprite GetEffectImageSprite(int index)
	{
		return index switch
		{
			1 => EffectImageSprite1, 
			2 => EffectImageSprite2, 
			3 => EffectImageSprite3, 
			4 => EffectImageSprite4, 
			_ => null, 
		};
	}

	public void SetEffectImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			EffectImageSprite1 = value;
			break;
		case 2:
			EffectImageSprite2 = value;
			break;
		case 3:
			EffectImageSprite3 = value;
			break;
		case 4:
			EffectImageSprite4 = value;
			break;
		}
	}

	public void MessageNtvsize()
	{
		if (_oMessageImage != null)
		{
			_oMessageImage.SetNativeSize();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oTimeTextText1 != null)
		{
			_holdPosTrans.Add(_oTimeTextText1.GetComponent<RectTransform>());
		}
		if (_oTimeTextText2 != null)
		{
			_holdPosTrans.Add(_oTimeTextText2.GetComponent<RectTransform>());
		}
		if (_oTimeTextText3 != null)
		{
			_holdPosTrans.Add(_oTimeTextText3.GetComponent<RectTransform>());
		}
		if (_oTimeTextText4 != null)
		{
			_holdPosTrans.Add(_oTimeTextText4.GetComponent<RectTransform>());
		}
		if (_oMpTextText1 != null)
		{
			_holdPosTrans.Add(_oMpTextText1.GetComponent<RectTransform>());
		}
		if (_oMpTextText2 != null)
		{
			_holdPosTrans.Add(_oMpTextText2.GetComponent<RectTransform>());
		}
		if (_oMpTextText3 != null)
		{
			_holdPosTrans.Add(_oMpTextText3.GetComponent<RectTransform>());
		}
		if (_oMpTextText4 != null)
		{
			_holdPosTrans.Add(_oMpTextText4.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
