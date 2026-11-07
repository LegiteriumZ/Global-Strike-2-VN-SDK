using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalnewvariantsgrowupViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oLvText;

	private Text _oLvTextText;

	private GameObject _oHpProgressImage;

	private Image _oHpProgressImageImage;

	private GameObject _oEffectBackImage;

	private CanvasGroup _oEffectBackImageCanvasGroup;

	private GameObject _oEffectImage;

	private RectTransform _oEffectImageRectTransform;

	private CanvasGroup _oEffectImageCanvasGroup;

	private Image _oEffectImageImage;

	private GameObject _oHpText;

	private Text _oHpTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalnewvariantsgrowup";

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public string LvTextString
	{
		get
		{
			if (_oLvTextText != null)
			{
				return _oLvTextText.text;
			}
			return null;
		}
		set
		{
			if (LvTextString != value && _oLvTextText != null)
			{
				_oLvTextText.text = value;
			}
		}
	}

	public float HpProgressImageFillamount
	{
		get
		{
			if (_oHpProgressImageImage != null)
			{
				return _oHpProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressImageFillamount != value && _oHpProgressImageImage != null)
			{
				_oHpProgressImageImage.fillAmount = value;
			}
		}
	}

	public bool EffectBackImageShow
	{
		get
		{
			if (_oEffectBackImage != null)
			{
				return _oEffectBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectBackImageShow != value && _oEffectBackImage != null)
			{
				_oEffectBackImage.SetObjectActive(value);
			}
		}
	}

	public float EffectBackImageAlpha
	{
		get
		{
			if (_oEffectBackImageCanvasGroup != null)
			{
				return _oEffectBackImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (EffectBackImageAlpha != value && _oEffectBackImageCanvasGroup != null)
			{
				_oEffectBackImageCanvasGroup.alpha = value;
			}
		}
	}

	public bool EffectImageShow
	{
		get
		{
			if (_oEffectImage != null)
			{
				return _oEffectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectImageShow != value && _oEffectImage != null)
			{
				_oEffectImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 EffectImageScale
	{
		get
		{
			if (_oEffectImageRectTransform != null)
			{
				return _oEffectImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectImageScale != value && _oEffectImageRectTransform != null)
			{
				_oEffectImageRectTransform.localScale = value;
			}
		}
	}

	public float EffectImageAlpha
	{
		get
		{
			if (_oEffectImageCanvasGroup != null)
			{
				return _oEffectImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (EffectImageAlpha != value && _oEffectImageCanvasGroup != null)
			{
				_oEffectImageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite EffectImageSprite
	{
		get
		{
			if (_oEffectImageImage != null)
			{
				return _oEffectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectImageSprite != value && _oEffectImageImage != null)
			{
				_oEffectImageImage.sprite = value;
			}
		}
	}

	public string HpTextString
	{
		get
		{
			if (_oHpTextText != null)
			{
				return _oHpTextText.text;
			}
			return null;
		}
		set
		{
			if (HpTextString != value && _oHpTextText != null)
			{
				_oHpTextText.text = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "LvText":
				_oLvText = transform.gameObject;
				_oLvTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "HpProgressImage":
				_oHpProgressImage = transform.gameObject;
				_oHpProgressImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectBackImage":
				_oEffectBackImage = transform.gameObject;
				_oEffectBackImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "EffectImage":
				_oEffectImage = transform.gameObject;
				_oEffectImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oEffectImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpText":
				_oHpText = transform.gameObject;
				_oHpTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
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
