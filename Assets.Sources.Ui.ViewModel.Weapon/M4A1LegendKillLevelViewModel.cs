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
public class M4A1LegendKillLevelViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oProgessBack;

	private Image _oProgessBackImage;

	private GameObject _oProgess;

	private Image _oProgessImage;

	private GameObject _oNumber;

	private Image _oNumberImage;

	private GameObject _oEffect;

	private RectTransform _oEffectRectTransform;

	private Image _oEffectImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "M4A1LegendKillLevel";

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

	public Sprite ProgessBackSprite
	{
		get
		{
			if (_oProgessBackImage != null)
			{
				return _oProgessBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessBackSprite != value && _oProgessBackImage != null)
			{
				_oProgessBackImage.sprite = value;
			}
		}
	}

	public Sprite ProgessSprite
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessSprite != value && _oProgessImage != null)
			{
				_oProgessImage.sprite = value;
			}
		}
	}

	public float ProgessFillamount
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgessFillamount != value && _oProgessImage != null)
			{
				_oProgessImage.fillAmount = value;
			}
		}
	}

	public Sprite NumberSprite
	{
		get
		{
			if (_oNumberImage != null)
			{
				return _oNumberImage.sprite;
			}
			return null;
		}
		set
		{
			if (NumberSprite != value && _oNumberImage != null)
			{
				_oNumberImage.sprite = value;
			}
		}
	}

	public bool EffectShow
	{
		get
		{
			if (_oEffect != null)
			{
				return _oEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow != value && _oEffect != null)
			{
				_oEffect.SetObjectActive(value);
			}
		}
	}

	public Vector3 EffectPosition
	{
		get
		{
			if (_oEffectRectTransform != null)
			{
				return _oEffectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition != value && _oEffectRectTransform != null)
			{
				_oEffectRectTransform.localPosition = value;
			}
		}
	}

	public Sprite EffectSprite
	{
		get
		{
			if (_oEffectImage != null)
			{
				return _oEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite != value && _oEffectImage != null)
			{
				_oEffectImage.sprite = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "ProgessBack":
				_oProgessBack = transform.gameObject;
				_oProgessBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progess":
				_oProgess = transform.gameObject;
				_oProgessImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Number":
				_oNumber = transform.gameObject;
				_oNumberImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect":
				_oEffect = transform.gameObject;
				_oEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage = transform.gameObject.GetComponent<Image>();
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
