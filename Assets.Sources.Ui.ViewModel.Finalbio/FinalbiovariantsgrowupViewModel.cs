using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Finalbio;

[GameUiTest]
public class FinalbiovariantsgrowupViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oProgressImage;

	private Image _oProgressImageImage;

	private GameObject _oGenerationImage;

	private RectTransform _oGenerationImageRectTransform;

	private GameObject _oFragmentImage;

	private RectTransform _oFragmentImageRectTransform;

	private CanvasGroup _oFragmentImageCanvasGroup;

	private GameObject _oTextImage;

	private Image _oTextImageImage;

	private GameObject _oSlotImage1;

	private GameObject _oSlotImage2;

	private GameObject _oSlotImage3;

	private GameObject _oSlotImage4;

	private GameObject _oSlotImage5;

	private GameObject _oHeroText;

	private Text _oHeroTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/finalbio";

	private string _resourceAssetName = "Finalbiovariantsgrowup";

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public bool ProgressImageShow
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressImageShow != value && _oProgressImage != null)
			{
				_oProgressImage.SetObjectActive(value);
			}
		}
	}

	public float ProgressImageFillamount
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressImageFillamount != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillAmount = value;
			}
		}
	}

	public bool GenerationImageShow
	{
		get
		{
			if (_oGenerationImage != null)
			{
				return _oGenerationImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GenerationImageShow != value && _oGenerationImage != null)
			{
				_oGenerationImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 GenerationImageScale
	{
		get
		{
			if (_oGenerationImageRectTransform != null)
			{
				return _oGenerationImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (GenerationImageScale != value && _oGenerationImageRectTransform != null)
			{
				_oGenerationImageRectTransform.localScale = value;
			}
		}
	}

	public bool FragmentImageShow
	{
		get
		{
			if (_oFragmentImage != null)
			{
				return _oFragmentImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FragmentImageShow != value && _oFragmentImage != null)
			{
				_oFragmentImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 FragmentImageScale
	{
		get
		{
			if (_oFragmentImageRectTransform != null)
			{
				return _oFragmentImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (FragmentImageScale != value && _oFragmentImageRectTransform != null)
			{
				_oFragmentImageRectTransform.localScale = value;
			}
		}
	}

	public float FragmentImageAlpha
	{
		get
		{
			if (_oFragmentImageCanvasGroup != null)
			{
				return _oFragmentImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (FragmentImageAlpha != value && _oFragmentImageCanvasGroup != null)
			{
				_oFragmentImageCanvasGroup.alpha = value;
			}
		}
	}

	public bool TextImageShow
	{
		get
		{
			if (_oTextImage != null)
			{
				return _oTextImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TextImageShow != value && _oTextImage != null)
			{
				_oTextImage.SetObjectActive(value);
			}
		}
	}

	public Sprite TextImageSprite
	{
		get
		{
			if (_oTextImageImage != null)
			{
				return _oTextImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (TextImageSprite != value && _oTextImageImage != null)
			{
				_oTextImageImage.sprite = value;
			}
		}
	}

	public bool SlotImageShow1
	{
		get
		{
			if (_oSlotImage1 != null)
			{
				return _oSlotImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotImageShow1 != value && _oSlotImage1 != null)
			{
				_oSlotImage1.SetObjectActive(value);
			}
		}
	}

	public bool SlotImageShow2
	{
		get
		{
			if (_oSlotImage2 != null)
			{
				return _oSlotImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotImageShow2 != value && _oSlotImage2 != null)
			{
				_oSlotImage2.SetObjectActive(value);
			}
		}
	}

	public bool SlotImageShow3
	{
		get
		{
			if (_oSlotImage3 != null)
			{
				return _oSlotImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotImageShow3 != value && _oSlotImage3 != null)
			{
				_oSlotImage3.SetObjectActive(value);
			}
		}
	}

	public bool SlotImageShow4
	{
		get
		{
			if (_oSlotImage4 != null)
			{
				return _oSlotImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotImageShow4 != value && _oSlotImage4 != null)
			{
				_oSlotImage4.SetObjectActive(value);
			}
		}
	}

	public bool SlotImageShow5
	{
		get
		{
			if (_oSlotImage5 != null)
			{
				return _oSlotImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotImageShow5 != value && _oSlotImage5 != null)
			{
				_oSlotImage5.SetObjectActive(value);
			}
		}
	}

	public string HeroTextString
	{
		get
		{
			if (_oHeroTextText != null)
			{
				return _oHeroTextText.text;
			}
			return null;
		}
		set
		{
			if (HeroTextString != value && _oHeroTextText != null)
			{
				_oHeroTextText.text = value;
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "ProgressImage":
				_oProgressImage = transform.gameObject;
				_oProgressImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "GenerationImage":
				_oGenerationImage = transform.gameObject;
				_oGenerationImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "FragmentImage":
				_oFragmentImage = transform.gameObject;
				_oFragmentImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oFragmentImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "TextImage":
				_oTextImage = transform.gameObject;
				_oTextImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SlotImage1":
				_oSlotImage1 = transform.gameObject;
				break;
			case "SlotImage2":
				_oSlotImage2 = transform.gameObject;
				break;
			case "SlotImage3":
				_oSlotImage3 = transform.gameObject;
				break;
			case "SlotImage4":
				_oSlotImage4 = transform.gameObject;
				break;
			case "SlotImage5":
				_oSlotImage5 = transform.gameObject;
				break;
			case "HeroText":
				_oHeroText = transform.gameObject;
				_oHeroTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void TextImageNtvsize()
	{
		if (_oTextImageImage != null)
		{
			_oTextImageImage.SetNativeSize();
		}
	}

	public bool GetSlotImageShow(int index)
	{
		return index switch
		{
			1 => SlotImageShow1, 
			2 => SlotImageShow2, 
			3 => SlotImageShow3, 
			4 => SlotImageShow4, 
			5 => SlotImageShow5, 
			_ => false, 
		};
	}

	public void SetSlotImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlotImageShow1 = value;
			break;
		case 2:
			SlotImageShow2 = value;
			break;
		case 3:
			SlotImageShow3 = value;
			break;
		case 4:
			SlotImageShow4 = value;
			break;
		case 5:
			SlotImageShow5 = value;
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
