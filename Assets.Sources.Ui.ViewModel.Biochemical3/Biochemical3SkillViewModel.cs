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

namespace Assets.Sources.Ui.ViewModel.Biochemical3;

[GameUiTest]
public class Biochemical3SkillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessage;

	private CanvasGroup _oMessageCanvasGroup;

	private Image _oMessageImage;

	private GameObject _oShow;

	private GameObject _oItem1;

	private GameObject _oItem2;

	private GameObject _oItem3;

	private GameObject _oItem4;

	private GameObject _oItem5;

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

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private GameObject _oIcon4;

	private GameObject _oIcon5;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private Image _oIconImage4;

	private Image _oIconImage5;

	private GameObject _oKey1;

	private GameObject _oKey2;

	private GameObject _oKey3;

	private GameObject _oKey4;

	private GameObject _oKey5;

	private Image _oKeyImage1;

	private Image _oKeyImage2;

	private Image _oKeyImage3;

	private Image _oKeyImage4;

	private Image _oKeyImage5;

	private GameObject _oCount1;

	private GameObject _oCount2;

	private GameObject _oCount3;

	private GameObject _oCount4;

	private GameObject _oCount5;

	private Text _oCountText1;

	private Text _oCountText2;

	private Text _oCountText3;

	private Text _oCountText4;

	private Text _oCountText5;

	private GameObject _oEffect1;

	private GameObject _oEffect2;

	private GameObject _oEffect3;

	private GameObject _oEffect4;

	private GameObject _oEffect5;

	private Image _oEffectImage1;

	private Image _oEffectImage2;

	private Image _oEffectImage3;

	private Image _oEffectImage4;

	private Image _oEffectImage5;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3Skill";

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

	public bool ItemShow1
	{
		get
		{
			if (_oItem1 != null)
			{
				return _oItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow1 != value && _oItem1 != null)
			{
				_oItem1.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow2
	{
		get
		{
			if (_oItem2 != null)
			{
				return _oItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow2 != value && _oItem2 != null)
			{
				_oItem2.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow3
	{
		get
		{
			if (_oItem3 != null)
			{
				return _oItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow3 != value && _oItem3 != null)
			{
				_oItem3.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow4
	{
		get
		{
			if (_oItem4 != null)
			{
				return _oItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow4 != value && _oItem4 != null)
			{
				_oItem4.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow5
	{
		get
		{
			if (_oItem5 != null)
			{
				return _oItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow5 != value && _oItem5 != null)
			{
				_oItem5.SetObjectActive(value);
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

	public bool IconShow1
	{
		get
		{
			if (_oIcon1 != null)
			{
				return _oIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow1 != value && _oIcon1 != null)
			{
				_oIcon1.SetObjectActive(value);
			}
		}
	}

	public bool IconShow2
	{
		get
		{
			if (_oIcon2 != null)
			{
				return _oIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow2 != value && _oIcon2 != null)
			{
				_oIcon2.SetObjectActive(value);
			}
		}
	}

	public bool IconShow3
	{
		get
		{
			if (_oIcon3 != null)
			{
				return _oIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow3 != value && _oIcon3 != null)
			{
				_oIcon3.SetObjectActive(value);
			}
		}
	}

	public bool IconShow4
	{
		get
		{
			if (_oIcon4 != null)
			{
				return _oIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow4 != value && _oIcon4 != null)
			{
				_oIcon4.SetObjectActive(value);
			}
		}
	}

	public bool IconShow5
	{
		get
		{
			if (_oIcon5 != null)
			{
				return _oIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow5 != value && _oIcon5 != null)
			{
				_oIcon5.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite1 != value && _oIconImage1 != null)
			{
				_oIconImage1.sprite = value;
			}
		}
	}

	public Sprite IconSprite2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite2 != value && _oIconImage2 != null)
			{
				_oIconImage2.sprite = value;
			}
		}
	}

	public Sprite IconSprite3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite3 != value && _oIconImage3 != null)
			{
				_oIconImage3.sprite = value;
			}
		}
	}

	public Sprite IconSprite4
	{
		get
		{
			if (_oIconImage4 != null)
			{
				return _oIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite4 != value && _oIconImage4 != null)
			{
				_oIconImage4.sprite = value;
			}
		}
	}

	public Sprite IconSprite5
	{
		get
		{
			if (_oIconImage5 != null)
			{
				return _oIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite5 != value && _oIconImage5 != null)
			{
				_oIconImage5.sprite = value;
			}
		}
	}

	public float IconFillamount1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (IconFillamount1 != value && _oIconImage1 != null)
			{
				_oIconImage1.fillAmount = value;
			}
		}
	}

	public float IconFillamount2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (IconFillamount2 != value && _oIconImage2 != null)
			{
				_oIconImage2.fillAmount = value;
			}
		}
	}

	public float IconFillamount3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (IconFillamount3 != value && _oIconImage3 != null)
			{
				_oIconImage3.fillAmount = value;
			}
		}
	}

	public float IconFillamount4
	{
		get
		{
			if (_oIconImage4 != null)
			{
				return _oIconImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (IconFillamount4 != value && _oIconImage4 != null)
			{
				_oIconImage4.fillAmount = value;
			}
		}
	}

	public float IconFillamount5
	{
		get
		{
			if (_oIconImage5 != null)
			{
				return _oIconImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (IconFillamount5 != value && _oIconImage5 != null)
			{
				_oIconImage5.fillAmount = value;
			}
		}
	}

	public Sprite KeySprite1
	{
		get
		{
			if (_oKeyImage1 != null)
			{
				return _oKeyImage1.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite1 != value && _oKeyImage1 != null)
			{
				_oKeyImage1.sprite = value;
			}
		}
	}

	public Sprite KeySprite2
	{
		get
		{
			if (_oKeyImage2 != null)
			{
				return _oKeyImage2.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite2 != value && _oKeyImage2 != null)
			{
				_oKeyImage2.sprite = value;
			}
		}
	}

	public Sprite KeySprite3
	{
		get
		{
			if (_oKeyImage3 != null)
			{
				return _oKeyImage3.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite3 != value && _oKeyImage3 != null)
			{
				_oKeyImage3.sprite = value;
			}
		}
	}

	public Sprite KeySprite4
	{
		get
		{
			if (_oKeyImage4 != null)
			{
				return _oKeyImage4.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite4 != value && _oKeyImage4 != null)
			{
				_oKeyImage4.sprite = value;
			}
		}
	}

	public Sprite KeySprite5
	{
		get
		{
			if (_oKeyImage5 != null)
			{
				return _oKeyImage5.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite5 != value && _oKeyImage5 != null)
			{
				_oKeyImage5.sprite = value;
			}
		}
	}

	public bool CountShow1
	{
		get
		{
			if (_oCount1 != null)
			{
				return _oCount1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow1 != value && _oCount1 != null)
			{
				_oCount1.SetObjectActive(value);
			}
		}
	}

	public bool CountShow2
	{
		get
		{
			if (_oCount2 != null)
			{
				return _oCount2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow2 != value && _oCount2 != null)
			{
				_oCount2.SetObjectActive(value);
			}
		}
	}

	public bool CountShow3
	{
		get
		{
			if (_oCount3 != null)
			{
				return _oCount3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow3 != value && _oCount3 != null)
			{
				_oCount3.SetObjectActive(value);
			}
		}
	}

	public bool CountShow4
	{
		get
		{
			if (_oCount4 != null)
			{
				return _oCount4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow4 != value && _oCount4 != null)
			{
				_oCount4.SetObjectActive(value);
			}
		}
	}

	public bool CountShow5
	{
		get
		{
			if (_oCount5 != null)
			{
				return _oCount5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountShow5 != value && _oCount5 != null)
			{
				_oCount5.SetObjectActive(value);
			}
		}
	}

	public string CountString1
	{
		get
		{
			if (_oCountText1 != null)
			{
				return _oCountText1.text;
			}
			return null;
		}
		set
		{
			if (CountString1 != value && _oCountText1 != null)
			{
				_oCountText1.text = value;
			}
		}
	}

	public string CountString2
	{
		get
		{
			if (_oCountText2 != null)
			{
				return _oCountText2.text;
			}
			return null;
		}
		set
		{
			if (CountString2 != value && _oCountText2 != null)
			{
				_oCountText2.text = value;
			}
		}
	}

	public string CountString3
	{
		get
		{
			if (_oCountText3 != null)
			{
				return _oCountText3.text;
			}
			return null;
		}
		set
		{
			if (CountString3 != value && _oCountText3 != null)
			{
				_oCountText3.text = value;
			}
		}
	}

	public string CountString4
	{
		get
		{
			if (_oCountText4 != null)
			{
				return _oCountText4.text;
			}
			return null;
		}
		set
		{
			if (CountString4 != value && _oCountText4 != null)
			{
				_oCountText4.text = value;
			}
		}
	}

	public string CountString5
	{
		get
		{
			if (_oCountText5 != null)
			{
				return _oCountText5.text;
			}
			return null;
		}
		set
		{
			if (CountString5 != value && _oCountText5 != null)
			{
				_oCountText5.text = value;
			}
		}
	}

	public bool EffectShow1
	{
		get
		{
			if (_oEffect1 != null)
			{
				return _oEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow1 != value && _oEffect1 != null)
			{
				_oEffect1.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow2
	{
		get
		{
			if (_oEffect2 != null)
			{
				return _oEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow2 != value && _oEffect2 != null)
			{
				_oEffect2.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow3
	{
		get
		{
			if (_oEffect3 != null)
			{
				return _oEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow3 != value && _oEffect3 != null)
			{
				_oEffect3.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow4
	{
		get
		{
			if (_oEffect4 != null)
			{
				return _oEffect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow4 != value && _oEffect4 != null)
			{
				_oEffect4.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow5
	{
		get
		{
			if (_oEffect5 != null)
			{
				return _oEffect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow5 != value && _oEffect5 != null)
			{
				_oEffect5.SetObjectActive(value);
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
			case "Message":
				_oMessage = transform.gameObject;
				_oMessageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oMessageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "Item1":
				_oItem1 = transform.gameObject;
				break;
			case "Item2":
				_oItem2 = transform.gameObject;
				break;
			case "Item3":
				_oItem3 = transform.gameObject;
				break;
			case "Item4":
				_oItem4 = transform.gameObject;
				break;
			case "Item5":
				_oItem5 = transform.gameObject;
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
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				_oIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon4":
				_oIcon4 = transform.gameObject;
				_oIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon5":
				_oIcon5 = transform.gameObject;
				_oIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key1":
				_oKey1 = transform.gameObject;
				_oKeyImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key2":
				_oKey2 = transform.gameObject;
				_oKeyImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key3":
				_oKey3 = transform.gameObject;
				_oKeyImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key4":
				_oKey4 = transform.gameObject;
				_oKeyImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key5":
				_oKey5 = transform.gameObject;
				_oKeyImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Count1":
				_oCount1 = transform.gameObject;
				_oCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count2":
				_oCount2 = transform.gameObject;
				_oCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count3":
				_oCount3 = transform.gameObject;
				_oCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count4":
				_oCount4 = transform.gameObject;
				_oCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count5":
				_oCount5 = transform.gameObject;
				_oCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Effect1":
				_oEffect1 = transform.gameObject;
				_oEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect2":
				_oEffect2 = transform.gameObject;
				_oEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect3":
				_oEffect3 = transform.gameObject;
				_oEffectImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect4":
				_oEffect4 = transform.gameObject;
				_oEffectImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect5":
				_oEffect5 = transform.gameObject;
				_oEffectImage5 = transform.gameObject.GetComponent<Image>();
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

	public void MessageNtvsize()
	{
		if (_oMessageImage != null)
		{
			_oMessageImage.SetNativeSize();
		}
	}

	public bool GetItemShow(int index)
	{
		return index switch
		{
			1 => ItemShow1, 
			2 => ItemShow2, 
			3 => ItemShow3, 
			4 => ItemShow4, 
			5 => ItemShow5, 
			_ => false, 
		};
	}

	public void SetItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemShow1 = value;
			break;
		case 2:
			ItemShow2 = value;
			break;
		case 3:
			ItemShow3 = value;
			break;
		case 4:
			ItemShow4 = value;
			break;
		case 5:
			ItemShow5 = value;
			break;
		}
	}

	public int GetItemCount()
	{
		return 5;
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

	public int GetBackCount()
	{
		return 5;
	}

	public bool GetIconShow(int index)
	{
		return index switch
		{
			1 => IconShow1, 
			2 => IconShow2, 
			3 => IconShow3, 
			4 => IconShow4, 
			5 => IconShow5, 
			_ => false, 
		};
	}

	public void SetIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			IconShow1 = value;
			break;
		case 2:
			IconShow2 = value;
			break;
		case 3:
			IconShow3 = value;
			break;
		case 4:
			IconShow4 = value;
			break;
		case 5:
			IconShow5 = value;
			break;
		}
	}

	public int GetIconCount()
	{
		return 5;
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			1 => IconSprite1, 
			2 => IconSprite2, 
			3 => IconSprite3, 
			4 => IconSprite4, 
			5 => IconSprite5, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		case 3:
			IconSprite3 = value;
			break;
		case 4:
			IconSprite4 = value;
			break;
		case 5:
			IconSprite5 = value;
			break;
		}
	}

	public float GetIconFillamount(int index)
	{
		return index switch
		{
			1 => IconFillamount1, 
			2 => IconFillamount2, 
			3 => IconFillamount3, 
			4 => IconFillamount4, 
			5 => IconFillamount5, 
			_ => 0f, 
		};
	}

	public void SetIconFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			IconFillamount1 = value;
			break;
		case 2:
			IconFillamount2 = value;
			break;
		case 3:
			IconFillamount3 = value;
			break;
		case 4:
			IconFillamount4 = value;
			break;
		case 5:
			IconFillamount5 = value;
			break;
		}
	}

	public Sprite GetKeySprite(int index)
	{
		return index switch
		{
			1 => KeySprite1, 
			2 => KeySprite2, 
			3 => KeySprite3, 
			4 => KeySprite4, 
			5 => KeySprite5, 
			_ => null, 
		};
	}

	public void SetKeySprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			KeySprite1 = value;
			break;
		case 2:
			KeySprite2 = value;
			break;
		case 3:
			KeySprite3 = value;
			break;
		case 4:
			KeySprite4 = value;
			break;
		case 5:
			KeySprite5 = value;
			break;
		}
	}

	public int GetKeyCount()
	{
		return 5;
	}

	public bool GetCountShow(int index)
	{
		return index switch
		{
			1 => CountShow1, 
			2 => CountShow2, 
			3 => CountShow3, 
			4 => CountShow4, 
			5 => CountShow5, 
			_ => false, 
		};
	}

	public void SetCountShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CountShow1 = value;
			break;
		case 2:
			CountShow2 = value;
			break;
		case 3:
			CountShow3 = value;
			break;
		case 4:
			CountShow4 = value;
			break;
		case 5:
			CountShow5 = value;
			break;
		}
	}

	public int GetCountCount()
	{
		return 5;
	}

	public string GetCountString(int index)
	{
		return index switch
		{
			1 => CountString1, 
			2 => CountString2, 
			3 => CountString3, 
			4 => CountString4, 
			5 => CountString5, 
			_ => null, 
		};
	}

	public void SetCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CountString1 = value;
			break;
		case 2:
			CountString2 = value;
			break;
		case 3:
			CountString3 = value;
			break;
		case 4:
			CountString4 = value;
			break;
		case 5:
			CountString5 = value;
			break;
		}
	}

	public bool GetEffectShow(int index)
	{
		return index switch
		{
			1 => EffectShow1, 
			2 => EffectShow2, 
			3 => EffectShow3, 
			4 => EffectShow4, 
			5 => EffectShow5, 
			_ => false, 
		};
	}

	public void SetEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			EffectShow1 = value;
			break;
		case 2:
			EffectShow2 = value;
			break;
		case 3:
			EffectShow3 = value;
			break;
		case 4:
			EffectShow4 = value;
			break;
		case 5:
			EffectShow5 = value;
			break;
		}
	}

	public int GetEffectCount()
	{
		return 5;
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
