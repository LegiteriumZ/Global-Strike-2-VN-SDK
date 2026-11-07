using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class Ak47heroViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow1;

	private GameObject _oLineImage1;

	private GameObject _oLineImage2;

	private Image _oLineImageImage1;

	private Image _oLineImageImage2;

	private GameObject _oInfoBackImage1;

	private GameObject _oInfoBackImage2;

	private CanvasGroup _oInfoBackImageCanvasGroup1;

	private CanvasGroup _oInfoBackImageCanvasGroup2;

	private Image _oInfoBackImageImage1;

	private Image _oInfoBackImageImage2;

	private GameObject _oKillText1;

	private GameObject _oKillText2;

	private Text _oKillTextText1;

	private Text _oKillTextText2;

	private GameObject _oHeadKillTenText1;

	private GameObject _oHeadKillTenText2;

	private Text _oHeadKillTenTextText1;

	private Text _oHeadKillTenTextText2;

	private GameObject _oHeadKillBitText1;

	private GameObject _oHeadKillBitText2;

	private Text _oHeadKillBitTextText1;

	private Text _oHeadKillBitTextText2;

	private GameObject _oSecondKillText1;

	private GameObject _oSecondKillText2;

	private Text _oSecondKillTextText1;

	private Text _oSecondKillTextText2;

	private GameObject _oBioKillText1;

	private GameObject _oBioKillText2;

	private Text _oBioKillTextText1;

	private Text _oBioKillTextText2;

	private GameObject _oBioDamageText1;

	private GameObject _oBioDamageText2;

	private Text _oBioDamageTextText1;

	private Text _oBioDamageTextText2;

	private GameObject _oDamageImage1;

	private GameObject _oDamageImage2;

	private Image _oDamageImageImage1;

	private Image _oDamageImageImage2;

	private GameObject _oBioSecondKillText1;

	private GameObject _oBioSecondKillText2;

	private Text _oBioSecondKillTextText1;

	private Text _oBioSecondKillTextText2;

	private GameObject _oPveSecondKillText1;

	private GameObject _oPveSecondKillText2;

	private Text _oPveSecondKillTextText1;

	private Text _oPveSecondKillTextText2;

	private GameObject _oPveHeadKillBitText1;

	private GameObject _oPveHeadKillBitText2;

	private Text _oPveHeadKillBitTextText1;

	private Text _oPveHeadKillBitTextText2;

	private GameObject _oPveHeadKillTenText1;

	private GameObject _oPveHeadKillTenText2;

	private Text _oPveHeadKillTenTextText1;

	private Text _oPveHeadKillTenTextText2;

	private GameObject _oPveKillText1;

	private GameObject _oPveKillText2;

	private Text _oPveKillTextText1;

	private Text _oPveKillTextText2;

	private GameObject _oOtherShow2;

	private RectTransform _oOtherShowRectTransform2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Ak47hero";

	public bool ShowShow1
	{
		get
		{
			if (_oShow1 != null)
			{
				return _oShow1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow1 != value && _oShow1 != null)
			{
				_oShow1.SetObjectActive(value);
			}
		}
	}

	public Sprite LineImageSprite1
	{
		get
		{
			if (_oLineImageImage1 != null)
			{
				return _oLineImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (LineImageSprite1 != value && _oLineImageImage1 != null)
			{
				_oLineImageImage1.sprite = value;
			}
		}
	}

	public Sprite LineImageSprite2
	{
		get
		{
			if (_oLineImageImage2 != null)
			{
				return _oLineImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (LineImageSprite2 != value && _oLineImageImage2 != null)
			{
				_oLineImageImage2.sprite = value;
			}
		}
	}

	public float LineImageFillamount1
	{
		get
		{
			if (_oLineImageImage1 != null)
			{
				return _oLineImageImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LineImageFillamount1 != value && _oLineImageImage1 != null)
			{
				_oLineImageImage1.fillAmount = value;
			}
		}
	}

	public float LineImageFillamount2
	{
		get
		{
			if (_oLineImageImage2 != null)
			{
				return _oLineImageImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LineImageFillamount2 != value && _oLineImageImage2 != null)
			{
				_oLineImageImage2.fillAmount = value;
			}
		}
	}

	public float InfoBackImageAlpha1
	{
		get
		{
			if (_oInfoBackImageCanvasGroup1 != null)
			{
				return _oInfoBackImageCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (InfoBackImageAlpha1 != value && _oInfoBackImageCanvasGroup1 != null)
			{
				_oInfoBackImageCanvasGroup1.alpha = value;
			}
		}
	}

	public float InfoBackImageAlpha2
	{
		get
		{
			if (_oInfoBackImageCanvasGroup2 != null)
			{
				return _oInfoBackImageCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (InfoBackImageAlpha2 != value && _oInfoBackImageCanvasGroup2 != null)
			{
				_oInfoBackImageCanvasGroup2.alpha = value;
			}
		}
	}

	public Sprite InfoBackImageSprite1
	{
		get
		{
			if (_oInfoBackImageImage1 != null)
			{
				return _oInfoBackImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (InfoBackImageSprite1 != value && _oInfoBackImageImage1 != null)
			{
				_oInfoBackImageImage1.sprite = value;
			}
		}
	}

	public Sprite InfoBackImageSprite2
	{
		get
		{
			if (_oInfoBackImageImage2 != null)
			{
				return _oInfoBackImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (InfoBackImageSprite2 != value && _oInfoBackImageImage2 != null)
			{
				_oInfoBackImageImage2.sprite = value;
			}
		}
	}

	public string KillTextString1
	{
		get
		{
			if (_oKillTextText1 != null)
			{
				return _oKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (KillTextString1 != value && _oKillTextText1 != null)
			{
				_oKillTextText1.text = value;
			}
		}
	}

	public string KillTextString2
	{
		get
		{
			if (_oKillTextText2 != null)
			{
				return _oKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (KillTextString2 != value && _oKillTextText2 != null)
			{
				_oKillTextText2.text = value;
			}
		}
	}

	public string HeadKillTenTextString1
	{
		get
		{
			if (_oHeadKillTenTextText1 != null)
			{
				return _oHeadKillTenTextText1.text;
			}
			return null;
		}
		set
		{
			if (HeadKillTenTextString1 != value && _oHeadKillTenTextText1 != null)
			{
				_oHeadKillTenTextText1.text = value;
			}
		}
	}

	public string HeadKillTenTextString2
	{
		get
		{
			if (_oHeadKillTenTextText2 != null)
			{
				return _oHeadKillTenTextText2.text;
			}
			return null;
		}
		set
		{
			if (HeadKillTenTextString2 != value && _oHeadKillTenTextText2 != null)
			{
				_oHeadKillTenTextText2.text = value;
			}
		}
	}

	public string HeadKillBitTextString1
	{
		get
		{
			if (_oHeadKillBitTextText1 != null)
			{
				return _oHeadKillBitTextText1.text;
			}
			return null;
		}
		set
		{
			if (HeadKillBitTextString1 != value && _oHeadKillBitTextText1 != null)
			{
				_oHeadKillBitTextText1.text = value;
			}
		}
	}

	public string HeadKillBitTextString2
	{
		get
		{
			if (_oHeadKillBitTextText2 != null)
			{
				return _oHeadKillBitTextText2.text;
			}
			return null;
		}
		set
		{
			if (HeadKillBitTextString2 != value && _oHeadKillBitTextText2 != null)
			{
				_oHeadKillBitTextText2.text = value;
			}
		}
	}

	public string SecondKillTextString1
	{
		get
		{
			if (_oSecondKillTextText1 != null)
			{
				return _oSecondKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (SecondKillTextString1 != value && _oSecondKillTextText1 != null)
			{
				_oSecondKillTextText1.text = value;
			}
		}
	}

	public string SecondKillTextString2
	{
		get
		{
			if (_oSecondKillTextText2 != null)
			{
				return _oSecondKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (SecondKillTextString2 != value && _oSecondKillTextText2 != null)
			{
				_oSecondKillTextText2.text = value;
			}
		}
	}

	public string BioKillTextString1
	{
		get
		{
			if (_oBioKillTextText1 != null)
			{
				return _oBioKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (BioKillTextString1 != value && _oBioKillTextText1 != null)
			{
				_oBioKillTextText1.text = value;
			}
		}
	}

	public string BioKillTextString2
	{
		get
		{
			if (_oBioKillTextText2 != null)
			{
				return _oBioKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (BioKillTextString2 != value && _oBioKillTextText2 != null)
			{
				_oBioKillTextText2.text = value;
			}
		}
	}

	public string BioDamageTextString1
	{
		get
		{
			if (_oBioDamageTextText1 != null)
			{
				return _oBioDamageTextText1.text;
			}
			return null;
		}
		set
		{
			if (BioDamageTextString1 != value && _oBioDamageTextText1 != null)
			{
				_oBioDamageTextText1.text = value;
			}
		}
	}

	public string BioDamageTextString2
	{
		get
		{
			if (_oBioDamageTextText2 != null)
			{
				return _oBioDamageTextText2.text;
			}
			return null;
		}
		set
		{
			if (BioDamageTextString2 != value && _oBioDamageTextText2 != null)
			{
				_oBioDamageTextText2.text = value;
			}
		}
	}

	public Sprite DamageImageSprite1
	{
		get
		{
			if (_oDamageImageImage1 != null)
			{
				return _oDamageImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (DamageImageSprite1 != value && _oDamageImageImage1 != null)
			{
				_oDamageImageImage1.sprite = value;
			}
		}
	}

	public Sprite DamageImageSprite2
	{
		get
		{
			if (_oDamageImageImage2 != null)
			{
				return _oDamageImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (DamageImageSprite2 != value && _oDamageImageImage2 != null)
			{
				_oDamageImageImage2.sprite = value;
			}
		}
	}

	public string BioSecondKillTextString1
	{
		get
		{
			if (_oBioSecondKillTextText1 != null)
			{
				return _oBioSecondKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (BioSecondKillTextString1 != value && _oBioSecondKillTextText1 != null)
			{
				_oBioSecondKillTextText1.text = value;
			}
		}
	}

	public string BioSecondKillTextString2
	{
		get
		{
			if (_oBioSecondKillTextText2 != null)
			{
				return _oBioSecondKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (BioSecondKillTextString2 != value && _oBioSecondKillTextText2 != null)
			{
				_oBioSecondKillTextText2.text = value;
			}
		}
	}

	public string PveSecondKillTextString1
	{
		get
		{
			if (_oPveSecondKillTextText1 != null)
			{
				return _oPveSecondKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (PveSecondKillTextString1 != value && _oPveSecondKillTextText1 != null)
			{
				_oPveSecondKillTextText1.text = value;
			}
		}
	}

	public string PveSecondKillTextString2
	{
		get
		{
			if (_oPveSecondKillTextText2 != null)
			{
				return _oPveSecondKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (PveSecondKillTextString2 != value && _oPveSecondKillTextText2 != null)
			{
				_oPveSecondKillTextText2.text = value;
			}
		}
	}

	public string PveHeadKillBitTextString1
	{
		get
		{
			if (_oPveHeadKillBitTextText1 != null)
			{
				return _oPveHeadKillBitTextText1.text;
			}
			return null;
		}
		set
		{
			if (PveHeadKillBitTextString1 != value && _oPveHeadKillBitTextText1 != null)
			{
				_oPveHeadKillBitTextText1.text = value;
			}
		}
	}

	public string PveHeadKillBitTextString2
	{
		get
		{
			if (_oPveHeadKillBitTextText2 != null)
			{
				return _oPveHeadKillBitTextText2.text;
			}
			return null;
		}
		set
		{
			if (PveHeadKillBitTextString2 != value && _oPveHeadKillBitTextText2 != null)
			{
				_oPveHeadKillBitTextText2.text = value;
			}
		}
	}

	public string PveHeadKillTenTextString1
	{
		get
		{
			if (_oPveHeadKillTenTextText1 != null)
			{
				return _oPveHeadKillTenTextText1.text;
			}
			return null;
		}
		set
		{
			if (PveHeadKillTenTextString1 != value && _oPveHeadKillTenTextText1 != null)
			{
				_oPveHeadKillTenTextText1.text = value;
			}
		}
	}

	public string PveHeadKillTenTextString2
	{
		get
		{
			if (_oPveHeadKillTenTextText2 != null)
			{
				return _oPveHeadKillTenTextText2.text;
			}
			return null;
		}
		set
		{
			if (PveHeadKillTenTextString2 != value && _oPveHeadKillTenTextText2 != null)
			{
				_oPveHeadKillTenTextText2.text = value;
			}
		}
	}

	public string PveKillTextString1
	{
		get
		{
			if (_oPveKillTextText1 != null)
			{
				return _oPveKillTextText1.text;
			}
			return null;
		}
		set
		{
			if (PveKillTextString1 != value && _oPveKillTextText1 != null)
			{
				_oPveKillTextText1.text = value;
			}
		}
	}

	public string PveKillTextString2
	{
		get
		{
			if (_oPveKillTextText2 != null)
			{
				return _oPveKillTextText2.text;
			}
			return null;
		}
		set
		{
			if (PveKillTextString2 != value && _oPveKillTextText2 != null)
			{
				_oPveKillTextText2.text = value;
			}
		}
	}

	public bool OtherShowShow2
	{
		get
		{
			if (_oOtherShow2 != null)
			{
				return _oOtherShow2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OtherShowShow2 != value && _oOtherShow2 != null)
			{
				_oOtherShow2.SetObjectActive(value);
			}
		}
	}

	public Vector3 OtherShowGposition2
	{
		get
		{
			if (_oOtherShowRectTransform2 != null)
			{
				return _oOtherShowRectTransform2.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (OtherShowGposition2 != value && _oOtherShowRectTransform2 != null)
			{
				_oOtherShowRectTransform2.position = value;
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
			case "Show1":
				_oShow1 = transform.gameObject;
				break;
			case "LineImage1":
				_oLineImage1 = transform.gameObject;
				_oLineImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "LineImage2":
				_oLineImage2 = transform.gameObject;
				_oLineImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "InfoBackImage1":
				_oInfoBackImage1 = transform.gameObject;
				_oInfoBackImageCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				_oInfoBackImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "InfoBackImage2":
				_oInfoBackImage2 = transform.gameObject;
				_oInfoBackImageCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				_oInfoBackImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "KillText1":
				_oKillText1 = transform.gameObject;
				_oKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "KillText2":
				_oKillText2 = transform.gameObject;
				_oKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "HeadKillTenText1":
				_oHeadKillTenText1 = transform.gameObject;
				_oHeadKillTenTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "HeadKillTenText2":
				_oHeadKillTenText2 = transform.gameObject;
				_oHeadKillTenTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "HeadKillBitText1":
				_oHeadKillBitText1 = transform.gameObject;
				_oHeadKillBitTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "HeadKillBitText2":
				_oHeadKillBitText2 = transform.gameObject;
				_oHeadKillBitTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SecondKillText1":
				_oSecondKillText1 = transform.gameObject;
				_oSecondKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "SecondKillText2":
				_oSecondKillText2 = transform.gameObject;
				_oSecondKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "BioKillText1":
				_oBioKillText1 = transform.gameObject;
				_oBioKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "BioKillText2":
				_oBioKillText2 = transform.gameObject;
				_oBioKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "BioDamageText1":
				_oBioDamageText1 = transform.gameObject;
				_oBioDamageTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "BioDamageText2":
				_oBioDamageText2 = transform.gameObject;
				_oBioDamageTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "DamageImage1":
				_oDamageImage1 = transform.gameObject;
				_oDamageImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "DamageImage2":
				_oDamageImage2 = transform.gameObject;
				_oDamageImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BioSecondKillText1":
				_oBioSecondKillText1 = transform.gameObject;
				_oBioSecondKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "BioSecondKillText2":
				_oBioSecondKillText2 = transform.gameObject;
				_oBioSecondKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveSecondKillText1":
				_oPveSecondKillText1 = transform.gameObject;
				_oPveSecondKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveSecondKillText2":
				_oPveSecondKillText2 = transform.gameObject;
				_oPveSecondKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveHeadKillBitText1":
				_oPveHeadKillBitText1 = transform.gameObject;
				_oPveHeadKillBitTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveHeadKillBitText2":
				_oPveHeadKillBitText2 = transform.gameObject;
				_oPveHeadKillBitTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveHeadKillTenText1":
				_oPveHeadKillTenText1 = transform.gameObject;
				_oPveHeadKillTenTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveHeadKillTenText2":
				_oPveHeadKillTenText2 = transform.gameObject;
				_oPveHeadKillTenTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveKillText1":
				_oPveKillText1 = transform.gameObject;
				_oPveKillTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PveKillText2":
				_oPveKillText2 = transform.gameObject;
				_oPveKillTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "OtherShow2":
				_oOtherShow2 = transform.gameObject;
				_oOtherShowRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			}
		}
	}

	public bool GetShowShow(int index)
	{
		if (index == 1)
		{
			return ShowShow1;
		}
		return false;
	}

	public void SetShowShow(int index, bool value)
	{
		if (index == 1)
		{
			ShowShow1 = value;
		}
	}

	public Sprite GetLineImageSprite(int index)
	{
		return index switch
		{
			1 => LineImageSprite1, 
			2 => LineImageSprite2, 
			_ => null, 
		};
	}

	public void SetLineImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			LineImageSprite1 = value;
			break;
		case 2:
			LineImageSprite2 = value;
			break;
		}
	}

	public float GetLineImageFillamount(int index)
	{
		return index switch
		{
			1 => LineImageFillamount1, 
			2 => LineImageFillamount2, 
			_ => 0f, 
		};
	}

	public void SetLineImageFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			LineImageFillamount1 = value;
			break;
		case 2:
			LineImageFillamount2 = value;
			break;
		}
	}

	public float GetInfoBackImageAlpha(int index)
	{
		return index switch
		{
			1 => InfoBackImageAlpha1, 
			2 => InfoBackImageAlpha2, 
			_ => 0f, 
		};
	}

	public void SetInfoBackImageAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			InfoBackImageAlpha1 = value;
			break;
		case 2:
			InfoBackImageAlpha2 = value;
			break;
		}
	}

	public Sprite GetInfoBackImageSprite(int index)
	{
		return index switch
		{
			1 => InfoBackImageSprite1, 
			2 => InfoBackImageSprite2, 
			_ => null, 
		};
	}

	public void SetInfoBackImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			InfoBackImageSprite1 = value;
			break;
		case 2:
			InfoBackImageSprite2 = value;
			break;
		}
	}

	public string GetKillTextString(int index)
	{
		return index switch
		{
			1 => KillTextString1, 
			2 => KillTextString2, 
			_ => null, 
		};
	}

	public void SetKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KillTextString1 = value;
			break;
		case 2:
			KillTextString2 = value;
			break;
		}
	}

	public string GetHeadKillTenTextString(int index)
	{
		return index switch
		{
			1 => HeadKillTenTextString1, 
			2 => HeadKillTenTextString2, 
			_ => null, 
		};
	}

	public void SetHeadKillTenTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			HeadKillTenTextString1 = value;
			break;
		case 2:
			HeadKillTenTextString2 = value;
			break;
		}
	}

	public string GetHeadKillBitTextString(int index)
	{
		return index switch
		{
			1 => HeadKillBitTextString1, 
			2 => HeadKillBitTextString2, 
			_ => null, 
		};
	}

	public void SetHeadKillBitTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			HeadKillBitTextString1 = value;
			break;
		case 2:
			HeadKillBitTextString2 = value;
			break;
		}
	}

	public string GetSecondKillTextString(int index)
	{
		return index switch
		{
			1 => SecondKillTextString1, 
			2 => SecondKillTextString2, 
			_ => null, 
		};
	}

	public void SetSecondKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			SecondKillTextString1 = value;
			break;
		case 2:
			SecondKillTextString2 = value;
			break;
		}
	}

	public string GetBioKillTextString(int index)
	{
		return index switch
		{
			1 => BioKillTextString1, 
			2 => BioKillTextString2, 
			_ => null, 
		};
	}

	public void SetBioKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			BioKillTextString1 = value;
			break;
		case 2:
			BioKillTextString2 = value;
			break;
		}
	}

	public string GetBioDamageTextString(int index)
	{
		return index switch
		{
			1 => BioDamageTextString1, 
			2 => BioDamageTextString2, 
			_ => null, 
		};
	}

	public void SetBioDamageTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			BioDamageTextString1 = value;
			break;
		case 2:
			BioDamageTextString2 = value;
			break;
		}
	}

	public Sprite GetDamageImageSprite(int index)
	{
		return index switch
		{
			1 => DamageImageSprite1, 
			2 => DamageImageSprite2, 
			_ => null, 
		};
	}

	public void SetDamageImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			DamageImageSprite1 = value;
			break;
		case 2:
			DamageImageSprite2 = value;
			break;
		}
	}

	public string GetBioSecondKillTextString(int index)
	{
		return index switch
		{
			1 => BioSecondKillTextString1, 
			2 => BioSecondKillTextString2, 
			_ => null, 
		};
	}

	public void SetBioSecondKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			BioSecondKillTextString1 = value;
			break;
		case 2:
			BioSecondKillTextString2 = value;
			break;
		}
	}

	public string GetPveSecondKillTextString(int index)
	{
		return index switch
		{
			1 => PveSecondKillTextString1, 
			2 => PveSecondKillTextString2, 
			_ => null, 
		};
	}

	public void SetPveSecondKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PveSecondKillTextString1 = value;
			break;
		case 2:
			PveSecondKillTextString2 = value;
			break;
		}
	}

	public string GetPveHeadKillBitTextString(int index)
	{
		return index switch
		{
			1 => PveHeadKillBitTextString1, 
			2 => PveHeadKillBitTextString2, 
			_ => null, 
		};
	}

	public void SetPveHeadKillBitTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PveHeadKillBitTextString1 = value;
			break;
		case 2:
			PveHeadKillBitTextString2 = value;
			break;
		}
	}

	public string GetPveHeadKillTenTextString(int index)
	{
		return index switch
		{
			1 => PveHeadKillTenTextString1, 
			2 => PveHeadKillTenTextString2, 
			_ => null, 
		};
	}

	public void SetPveHeadKillTenTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PveHeadKillTenTextString1 = value;
			break;
		case 2:
			PveHeadKillTenTextString2 = value;
			break;
		}
	}

	public string GetPveKillTextString(int index)
	{
		return index switch
		{
			1 => PveKillTextString1, 
			2 => PveKillTextString2, 
			_ => null, 
		};
	}

	public void SetPveKillTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PveKillTextString1 = value;
			break;
		case 2:
			PveKillTextString2 = value;
			break;
		}
	}

	public bool GetOtherShowShow(int index)
	{
		if (index == 2)
		{
			return OtherShowShow2;
		}
		return false;
	}

	public void SetOtherShowShow(int index, bool value)
	{
		if (index == 2)
		{
			OtherShowShow2 = value;
		}
	}

	public Vector3 GetOtherShowGposition(int index)
	{
		if (index == 2)
		{
			return OtherShowGposition2;
		}
		return Vector3.zero;
	}

	public void SetOtherShowGposition(int index, Vector3 value)
	{
		if (index == 2)
		{
			OtherShowGposition2 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
