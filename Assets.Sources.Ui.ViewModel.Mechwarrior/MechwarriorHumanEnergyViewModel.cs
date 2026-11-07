using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Mechwarrior;

[GameUiTest]
public class MechwarriorHumanEnergyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oEnergyMessage;

	private GameObject _oFullImage;

	private GameObject _oEnergyText;

	private Text _oEnergyTextText;

	private GameObject _oGiftMessage;

	private Image _oGiftMessageImage;

	private GameObject _oMessageTime;

	private Text _oMessageTimeText;

	private GameObject _oEffect;

	private Image _oEffectImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorHumanEnergy";

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

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public bool EnergyMessageShow
	{
		get
		{
			if (_oEnergyMessage != null)
			{
				return _oEnergyMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EnergyMessageShow != value && _oEnergyMessage != null)
			{
				_oEnergyMessage.SetObjectActive(value);
			}
		}
	}

	public bool FullImageShow
	{
		get
		{
			if (_oFullImage != null)
			{
				return _oFullImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FullImageShow != value && _oFullImage != null)
			{
				_oFullImage.SetObjectActive(value);
			}
		}
	}

	public string EnergyTextString
	{
		get
		{
			if (_oEnergyTextText != null)
			{
				return _oEnergyTextText.text;
			}
			return null;
		}
		set
		{
			if (EnergyTextString != value && _oEnergyTextText != null)
			{
				_oEnergyTextText.text = value;
			}
		}
	}

	public bool GiftMessageShow
	{
		get
		{
			if (_oGiftMessage != null)
			{
				return _oGiftMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftMessageShow != value && _oGiftMessage != null)
			{
				_oGiftMessage.SetObjectActive(value);
			}
		}
	}

	public Sprite GiftMessageSprite
	{
		get
		{
			if (_oGiftMessageImage != null)
			{
				return _oGiftMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (GiftMessageSprite != value && _oGiftMessageImage != null)
			{
				_oGiftMessageImage.sprite = value;
			}
		}
	}

	public string MessageTimeString
	{
		get
		{
			if (_oMessageTimeText != null)
			{
				return _oMessageTimeText.text;
			}
			return null;
		}
		set
		{
			if (MessageTimeString != value && _oMessageTimeText != null)
			{
				_oMessageTimeText.text = value;
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyMessage":
				_oEnergyMessage = transform.gameObject;
				break;
			case "FullImage":
				_oFullImage = transform.gameObject;
				break;
			case "EnergyText":
				_oEnergyText = transform.gameObject;
				_oEnergyTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftMessage":
				_oGiftMessage = transform.gameObject;
				_oGiftMessageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageTime":
				_oMessageTime = transform.gameObject;
				_oMessageTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "Effect":
				_oEffect = transform.gameObject;
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
