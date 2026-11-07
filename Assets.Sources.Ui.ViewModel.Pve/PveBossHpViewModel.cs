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
public class PveBossHpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPveBossHp;

	private GameObject _oBg;

	private RectTransform _oBgRectTransform;

	private Image _oBgImage;

	private GameObject _obossHPBackEffectImage;

	private RectTransform _obossHPBackEffectImageRectTransform;

	private Image _obossHPBackEffectImageImage;

	private GameObject _ohpProgress1;

	private GameObject _ohpProgress2;

	private RectTransform _ohpProgressRectTransform1;

	private RectTransform _ohpProgressRectTransform2;

	private Image _ohpProgressImage1;

	private Image _ohpProgressImage2;

	private GameObject _ohpeffect;

	private RectTransform _ohpeffectRectTransform;

	private Image _ohpeffectImage;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "PveBossHp";

	public UiReferences UI => uiRef;

	public GameObject PveBossHpObj => _oPveBossHp;

	public bool PveBossHpShow
	{
		get
		{
			if (_oPveBossHp != null)
			{
				return _oPveBossHp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PveBossHpShow != value && _oPveBossHp != null)
			{
				_oPveBossHp.SetObjectActive(value);
			}
		}
	}

	public bool BgShow
	{
		get
		{
			if (_oBg != null)
			{
				return _oBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BgShow != value && _oBg != null)
			{
				_oBg.SetObjectActive(value);
			}
		}
	}

	public Vector2 BgAnchoredposition
	{
		get
		{
			if (_oBgRectTransform != null)
			{
				return _oBgRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (BgAnchoredposition != value && _oBgRectTransform != null)
			{
				_oBgRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 BgSize
	{
		get
		{
			if (_oBgRectTransform != null)
			{
				return _oBgRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (BgSize != value && _oBgRectTransform != null)
			{
				_oBgRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite BgSprite
	{
		get
		{
			if (_oBgImage != null)
			{
				return _oBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (BgSprite != value && _oBgImage != null)
			{
				_oBgImage.sprite = value;
			}
		}
	}

	public float BgFillamount
	{
		get
		{
			if (_oBgImage != null)
			{
				return _oBgImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (BgFillamount != value && _oBgImage != null)
			{
				_oBgImage.fillAmount = value;
			}
		}
	}

	public Color BgColor
	{
		get
		{
			if (_oBgImage != null)
			{
				return _oBgImage.color;
			}
			return Color.white;
		}
		set
		{
			if (BgColor != value && _oBgImage != null)
			{
				_oBgImage.color = value;
			}
		}
	}

	public Image BgImage
	{
		get
		{
			if (_oBgImage != null)
			{
				return _oBgImage;
			}
			return null;
		}
		set
		{
			if (BgImage != value && _oBgImage != null)
			{
				_oBgImage = value;
			}
		}
	}

	public bool bossHPBackEffectImageShow
	{
		get
		{
			if (_obossHPBackEffectImage != null)
			{
				return _obossHPBackEffectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bossHPBackEffectImageShow != value && _obossHPBackEffectImage != null)
			{
				_obossHPBackEffectImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 bossHPBackEffectImageAnchoredposition
	{
		get
		{
			if (_obossHPBackEffectImageRectTransform != null)
			{
				return _obossHPBackEffectImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (bossHPBackEffectImageAnchoredposition != value && _obossHPBackEffectImageRectTransform != null)
			{
				_obossHPBackEffectImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 bossHPBackEffectImageSize
	{
		get
		{
			if (_obossHPBackEffectImageRectTransform != null)
			{
				return _obossHPBackEffectImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (bossHPBackEffectImageSize != value && _obossHPBackEffectImageRectTransform != null)
			{
				_obossHPBackEffectImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite bossHPBackEffectImageSprite
	{
		get
		{
			if (_obossHPBackEffectImageImage != null)
			{
				return _obossHPBackEffectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (bossHPBackEffectImageSprite != value && _obossHPBackEffectImageImage != null)
			{
				_obossHPBackEffectImageImage.sprite = value;
			}
		}
	}

	public float bossHPBackEffectImageFillamount
	{
		get
		{
			if (_obossHPBackEffectImageImage != null)
			{
				return _obossHPBackEffectImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (bossHPBackEffectImageFillamount != value && _obossHPBackEffectImageImage != null)
			{
				_obossHPBackEffectImageImage.fillAmount = value;
			}
		}
	}

	public Color bossHPBackEffectImageColor
	{
		get
		{
			if (_obossHPBackEffectImageImage != null)
			{
				return _obossHPBackEffectImageImage.color;
			}
			return Color.white;
		}
		set
		{
			if (bossHPBackEffectImageColor != value && _obossHPBackEffectImageImage != null)
			{
				_obossHPBackEffectImageImage.color = value;
			}
		}
	}

	public Image bossHPBackEffectImageImage
	{
		get
		{
			if (_obossHPBackEffectImageImage != null)
			{
				return _obossHPBackEffectImageImage;
			}
			return null;
		}
		set
		{
			if (bossHPBackEffectImageImage != value && _obossHPBackEffectImageImage != null)
			{
				_obossHPBackEffectImageImage = value;
			}
		}
	}

	public bool hpProgressShow1
	{
		get
		{
			if (_ohpProgress1 != null)
			{
				return _ohpProgress1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpProgressShow1 != value && _ohpProgress1 != null)
			{
				_ohpProgress1.SetObjectActive(value);
			}
		}
	}

	public bool hpProgressShow2
	{
		get
		{
			if (_ohpProgress2 != null)
			{
				return _ohpProgress2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpProgressShow2 != value && _ohpProgress2 != null)
			{
				_ohpProgress2.SetObjectActive(value);
			}
		}
	}

	public Vector2 hpProgressAnchoredposition1
	{
		get
		{
			if (_ohpProgressRectTransform1 != null)
			{
				return _ohpProgressRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hpProgressAnchoredposition1 != value && _ohpProgressRectTransform1 != null)
			{
				_ohpProgressRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 hpProgressAnchoredposition2
	{
		get
		{
			if (_ohpProgressRectTransform2 != null)
			{
				return _ohpProgressRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hpProgressAnchoredposition2 != value && _ohpProgressRectTransform2 != null)
			{
				_ohpProgressRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector3 hpProgressSize1
	{
		get
		{
			if (_ohpProgressRectTransform1 != null)
			{
				return _ohpProgressRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hpProgressSize1 != value && _ohpProgressRectTransform1 != null)
			{
				_ohpProgressRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 hpProgressSize2
	{
		get
		{
			if (_ohpProgressRectTransform2 != null)
			{
				return _ohpProgressRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hpProgressSize2 != value && _ohpProgressRectTransform2 != null)
			{
				_ohpProgressRectTransform2.sizeDelta = value;
			}
		}
	}

	public Sprite hpProgressSprite1
	{
		get
		{
			if (_ohpProgressImage1 != null)
			{
				return _ohpProgressImage1.sprite;
			}
			return null;
		}
		set
		{
			if (hpProgressSprite1 != value && _ohpProgressImage1 != null)
			{
				_ohpProgressImage1.sprite = value;
			}
		}
	}

	public Sprite hpProgressSprite2
	{
		get
		{
			if (_ohpProgressImage2 != null)
			{
				return _ohpProgressImage2.sprite;
			}
			return null;
		}
		set
		{
			if (hpProgressSprite2 != value && _ohpProgressImage2 != null)
			{
				_ohpProgressImage2.sprite = value;
			}
		}
	}

	public float hpProgressFillamount1
	{
		get
		{
			if (_ohpProgressImage1 != null)
			{
				return _ohpProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpProgressFillamount1 != value && _ohpProgressImage1 != null)
			{
				_ohpProgressImage1.fillAmount = value;
			}
		}
	}

	public float hpProgressFillamount2
	{
		get
		{
			if (_ohpProgressImage2 != null)
			{
				return _ohpProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpProgressFillamount2 != value && _ohpProgressImage2 != null)
			{
				_ohpProgressImage2.fillAmount = value;
			}
		}
	}

	public Color hpProgressColor1
	{
		get
		{
			if (_ohpProgressImage1 != null)
			{
				return _ohpProgressImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (hpProgressColor1 != value && _ohpProgressImage1 != null)
			{
				_ohpProgressImage1.color = value;
			}
		}
	}

	public Color hpProgressColor2
	{
		get
		{
			if (_ohpProgressImage2 != null)
			{
				return _ohpProgressImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (hpProgressColor2 != value && _ohpProgressImage2 != null)
			{
				_ohpProgressImage2.color = value;
			}
		}
	}

	public Image hpProgressImage1
	{
		get
		{
			if (_ohpProgressImage1 != null)
			{
				return _ohpProgressImage1;
			}
			return null;
		}
		set
		{
			if (hpProgressImage1 != value && _ohpProgressImage1 != null)
			{
				_ohpProgressImage1 = value;
			}
		}
	}

	public Image hpProgressImage2
	{
		get
		{
			if (_ohpProgressImage2 != null)
			{
				return _ohpProgressImage2;
			}
			return null;
		}
		set
		{
			if (hpProgressImage2 != value && _ohpProgressImage2 != null)
			{
				_ohpProgressImage2 = value;
			}
		}
	}

	public bool hpeffectShow
	{
		get
		{
			if (_ohpeffect != null)
			{
				return _ohpeffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpeffectShow != value && _ohpeffect != null)
			{
				_ohpeffect.SetObjectActive(value);
			}
		}
	}

	public Vector2 hpeffectAnchoredposition
	{
		get
		{
			if (_ohpeffectRectTransform != null)
			{
				return _ohpeffectRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (hpeffectAnchoredposition != value && _ohpeffectRectTransform != null)
			{
				_ohpeffectRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 hpeffectSize
	{
		get
		{
			if (_ohpeffectRectTransform != null)
			{
				return _ohpeffectRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (hpeffectSize != value && _ohpeffectRectTransform != null)
			{
				_ohpeffectRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite hpeffectSprite
	{
		get
		{
			if (_ohpeffectImage != null)
			{
				return _ohpeffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (hpeffectSprite != value && _ohpeffectImage != null)
			{
				_ohpeffectImage.sprite = value;
			}
		}
	}

	public float hpeffectFillamount
	{
		get
		{
			if (_ohpeffectImage != null)
			{
				return _ohpeffectImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpeffectFillamount != value && _ohpeffectImage != null)
			{
				_ohpeffectImage.fillAmount = value;
			}
		}
	}

	public Color hpeffectColor
	{
		get
		{
			if (_ohpeffectImage != null)
			{
				return _ohpeffectImage.color;
			}
			return Color.white;
		}
		set
		{
			if (hpeffectColor != value && _ohpeffectImage != null)
			{
				_ohpeffectImage.color = value;
			}
		}
	}

	public Image hpeffectImage
	{
		get
		{
			if (_ohpeffectImage != null)
			{
				return _ohpeffectImage;
			}
			return null;
		}
		set
		{
			if (hpeffectImage != value && _ohpeffectImage != null)
			{
				_ohpeffectImage = value;
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
			case "PveBossHp":
				_oPveBossHp = transform.gameObject;
				uiRef.Set("PveBossHp", _oPveBossHp.transform);
				break;
			case "Bg":
				_oBg = transform.gameObject;
				uiRef.Set("Bg", _oBg.transform);
				_oBgRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("BgRectTransform", _oBgRectTransform);
				_oBgImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("BgImage", _oBgImage);
				break;
			case "bossHPBackEffectImage":
				_obossHPBackEffectImage = transform.gameObject;
				uiRef.Set("bossHPBackEffectImage", _obossHPBackEffectImage.transform);
				_obossHPBackEffectImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("bossHPBackEffectImageRectTransform", _obossHPBackEffectImageRectTransform);
				_obossHPBackEffectImageImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("bossHPBackEffectImageImage", _obossHPBackEffectImageImage);
				break;
			case "hpProgress1":
				_ohpProgress1 = transform.gameObject;
				uiRef.Set("hpProgress1", _ohpProgress1.transform);
				_ohpProgressRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hpProgressRectTransform1", _ohpProgressRectTransform1);
				_ohpProgressImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hpProgressImage1", _ohpProgressImage1);
				break;
			case "hpProgress2":
				_ohpProgress2 = transform.gameObject;
				uiRef.Set("hpProgress2", _ohpProgress2.transform);
				_ohpProgressRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hpProgressRectTransform2", _ohpProgressRectTransform2);
				_ohpProgressImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hpProgressImage2", _ohpProgressImage2);
				break;
			case "hpeffect":
				_ohpeffect = transform.gameObject;
				uiRef.Set("hpeffect", _ohpeffect.transform);
				_ohpeffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("hpeffectRectTransform", _ohpeffectRectTransform);
				_ohpeffectImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("hpeffectImage", _ohpeffectImage);
				break;
			}
		}
	}

	public void BgNtvsize()
	{
		if (_oBgImage != null)
		{
			_oBgImage.SetNativeSize();
		}
	}

	public void bossHPBackEffectImageNtvsize()
	{
		if (_obossHPBackEffectImageImage != null)
		{
			_obossHPBackEffectImageImage.SetNativeSize();
		}
	}

	public bool GethpProgressShow(int index)
	{
		return index switch
		{
			1 => hpProgressShow1, 
			2 => hpProgressShow2, 
			_ => false, 
		};
	}

	public void SethpProgressShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			hpProgressShow1 = value;
			break;
		case 2:
			hpProgressShow2 = value;
			break;
		}
	}

	public Vector2 GethpProgressAnchoredposition(int index)
	{
		return index switch
		{
			1 => hpProgressAnchoredposition1, 
			2 => hpProgressAnchoredposition2, 
			_ => Vector2.zero, 
		};
	}

	public void SethpProgressAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			hpProgressAnchoredposition1 = value;
			break;
		case 2:
			hpProgressAnchoredposition2 = value;
			break;
		}
	}

	public Vector3 GethpProgressSize(int index)
	{
		return index switch
		{
			1 => hpProgressSize1, 
			2 => hpProgressSize2, 
			_ => Vector3.zero, 
		};
	}

	public void SethpProgressSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			hpProgressSize1 = value;
			break;
		case 2:
			hpProgressSize2 = value;
			break;
		}
	}

	public Sprite GethpProgressSprite(int index)
	{
		return index switch
		{
			1 => hpProgressSprite1, 
			2 => hpProgressSprite2, 
			_ => null, 
		};
	}

	public void SethpProgressSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			hpProgressSprite1 = value;
			break;
		case 2:
			hpProgressSprite2 = value;
			break;
		}
	}

	public float GethpProgressFillamount(int index)
	{
		return index switch
		{
			1 => hpProgressFillamount1, 
			2 => hpProgressFillamount2, 
			_ => 0f, 
		};
	}

	public void SethpProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			hpProgressFillamount1 = value;
			break;
		case 2:
			hpProgressFillamount2 = value;
			break;
		}
	}

	public Color GethpProgressColor(int index)
	{
		return index switch
		{
			1 => hpProgressColor1, 
			2 => hpProgressColor2, 
			_ => Color.white, 
		};
	}

	public void SethpProgressColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			hpProgressColor1 = value;
			break;
		case 2:
			hpProgressColor2 = value;
			break;
		}
	}

	public Image GethpProgressImage(int index)
	{
		return index switch
		{
			1 => hpProgressImage1, 
			2 => hpProgressImage2, 
			_ => null, 
		};
	}

	public void SethpProgressImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			hpProgressImage1 = value;
			break;
		case 2:
			hpProgressImage2 = value;
			break;
		}
	}

	public void hpProgressNtvsize1()
	{
		if (_ohpProgressImage1 != null)
		{
			_ohpProgressImage1.SetNativeSize();
		}
	}

	public void hpProgressNtvsize2()
	{
		if (_ohpProgressImage2 != null)
		{
			_ohpProgressImage2.SetNativeSize();
		}
	}

	public void CallhpProgressNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			hpProgressNtvsize1();
			break;
		case 2:
			hpProgressNtvsize2();
			break;
		}
	}

	public void hpeffectNtvsize()
	{
		if (_ohpeffectImage != null)
		{
			_ohpeffectImage.SetNativeSize();
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
