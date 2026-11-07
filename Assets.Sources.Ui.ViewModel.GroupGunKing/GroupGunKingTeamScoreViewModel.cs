using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GroupGunKing;

[GameUiTest]
public class GroupGunKingTeamScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCtBar;

	private Image _oCtBarImage;

	private GameObject _oCtLight;

	private RectTransform _oCtLightRectTransform;

	private GameObject _oCtBarEnd;

	private RectTransform _oCtBarEndRectTransform;

	private GameObject _oCtEffect;

	private Image _oCtEffectImage;

	private GameObject _oTBar;

	private Image _oTBarImage;

	private GameObject _oTLight;

	private RectTransform _oTLightRectTransform;

	private GameObject _oTBarEnd;

	private RectTransform _oTBarEndRectTransform;

	private GameObject _oTEffect;

	private Image _oTEffectImage;

	private GameObject _oPhaseScore;

	private Text _oPhaseScoreText;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oCtScore;

	private Text _oCtScoreText;

	private GameObject _oTScore;

	private Text _oTScoreText;

	private GameObject _oTKill;

	private Text _oTKillText;

	private GameObject _oCtKill;

	private Text _oCtKillText;

	private GameObject _oWeapon;

	private Image _oWeaponImage;

	private GameObject _oWeaponEffect;

	private RectTransform _oWeaponEffectRectTransform;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/groupgunking";

	private string _resourceAssetName = "GroupGunKingTeamScore";

	public float CtBarFillamount
	{
		get
		{
			if (_oCtBarImage != null)
			{
				return _oCtBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtBarFillamount != value && _oCtBarImage != null)
			{
				_oCtBarImage.fillAmount = value;
			}
		}
	}

	public Vector3 CtLightPosition
	{
		get
		{
			if (_oCtLightRectTransform != null)
			{
				return _oCtLightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtLightPosition != value && _oCtLightRectTransform != null)
			{
				_oCtLightRectTransform.localPosition = value;
			}
		}
	}

	public bool CtBarEndShow
	{
		get
		{
			if (_oCtBarEnd != null)
			{
				return _oCtBarEnd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtBarEndShow != value && _oCtBarEnd != null)
			{
				_oCtBarEnd.SetObjectActive(value);
			}
		}
	}

	public Vector3 CtBarEndPosition
	{
		get
		{
			if (_oCtBarEndRectTransform != null)
			{
				return _oCtBarEndRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtBarEndPosition != value && _oCtBarEndRectTransform != null)
			{
				_oCtBarEndRectTransform.localPosition = value;
			}
		}
	}

	public bool CtEffectShow
	{
		get
		{
			if (_oCtEffect != null)
			{
				return _oCtEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtEffectShow != value && _oCtEffect != null)
			{
				_oCtEffect.SetObjectActive(value);
			}
		}
	}

	public Sprite CtEffectSprite
	{
		get
		{
			if (_oCtEffectImage != null)
			{
				return _oCtEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (CtEffectSprite != value && _oCtEffectImage != null)
			{
				_oCtEffectImage.sprite = value;
			}
		}
	}

	public float TBarFillamount
	{
		get
		{
			if (_oTBarImage != null)
			{
				return _oTBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (TBarFillamount != value && _oTBarImage != null)
			{
				_oTBarImage.fillAmount = value;
			}
		}
	}

	public Vector3 TLightPosition
	{
		get
		{
			if (_oTLightRectTransform != null)
			{
				return _oTLightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TLightPosition != value && _oTLightRectTransform != null)
			{
				_oTLightRectTransform.localPosition = value;
			}
		}
	}

	public bool TBarEndShow
	{
		get
		{
			if (_oTBarEnd != null)
			{
				return _oTBarEnd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TBarEndShow != value && _oTBarEnd != null)
			{
				_oTBarEnd.SetObjectActive(value);
			}
		}
	}

	public Vector3 TBarEndPosition
	{
		get
		{
			if (_oTBarEndRectTransform != null)
			{
				return _oTBarEndRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TBarEndPosition != value && _oTBarEndRectTransform != null)
			{
				_oTBarEndRectTransform.localPosition = value;
			}
		}
	}

	public bool TEffectShow
	{
		get
		{
			if (_oTEffect != null)
			{
				return _oTEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TEffectShow != value && _oTEffect != null)
			{
				_oTEffect.SetObjectActive(value);
			}
		}
	}

	public Sprite TEffectSprite
	{
		get
		{
			if (_oTEffectImage != null)
			{
				return _oTEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (TEffectSprite != value && _oTEffectImage != null)
			{
				_oTEffectImage.sprite = value;
			}
		}
	}

	public string PhaseScoreString
	{
		get
		{
			if (_oPhaseScoreText != null)
			{
				return _oPhaseScoreText.text;
			}
			return null;
		}
		set
		{
			if (PhaseScoreString != value && _oPhaseScoreText != null)
			{
				_oPhaseScoreText.text = value;
			}
		}
	}

	public string MinutesString
	{
		get
		{
			if (_oMinutesText != null)
			{
				return _oMinutesText.text;
			}
			return null;
		}
		set
		{
			if (MinutesString != value && _oMinutesText != null)
			{
				_oMinutesText.text = value;
			}
		}
	}

	public string SecondsString
	{
		get
		{
			if (_oSecondsText != null)
			{
				return _oSecondsText.text;
			}
			return null;
		}
		set
		{
			if (SecondsString != value && _oSecondsText != null)
			{
				_oSecondsText.text = value;
			}
		}
	}

	public string CtScoreString
	{
		get
		{
			if (_oCtScoreText != null)
			{
				return _oCtScoreText.text;
			}
			return null;
		}
		set
		{
			if (CtScoreString != value && _oCtScoreText != null)
			{
				_oCtScoreText.text = value;
			}
		}
	}

	public string TScoreString
	{
		get
		{
			if (_oTScoreText != null)
			{
				return _oTScoreText.text;
			}
			return null;
		}
		set
		{
			if (TScoreString != value && _oTScoreText != null)
			{
				_oTScoreText.text = value;
			}
		}
	}

	public string TKillString
	{
		get
		{
			if (_oTKillText != null)
			{
				return _oTKillText.text;
			}
			return null;
		}
		set
		{
			if (TKillString != value && _oTKillText != null)
			{
				_oTKillText.text = value;
			}
		}
	}

	public string CtKillString
	{
		get
		{
			if (_oCtKillText != null)
			{
				return _oCtKillText.text;
			}
			return null;
		}
		set
		{
			if (CtKillString != value && _oCtKillText != null)
			{
				_oCtKillText.text = value;
			}
		}
	}

	public Sprite WeaponSprite
	{
		get
		{
			if (_oWeaponImage != null)
			{
				return _oWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite != value && _oWeaponImage != null)
			{
				_oWeaponImage.sprite = value;
			}
		}
	}

	public Vector3 WeaponEffectPosition
	{
		get
		{
			if (_oWeaponEffectRectTransform != null)
			{
				return _oWeaponEffectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (WeaponEffectPosition != value && _oWeaponEffectRectTransform != null)
			{
				_oWeaponEffectRectTransform.localPosition = value;
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
			case "CtBar":
				_oCtBar = transform.gameObject;
				_oCtBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CtLight":
				_oCtLight = transform.gameObject;
				_oCtLightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtBarEnd":
				_oCtBarEnd = transform.gameObject;
				_oCtBarEndRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtEffect":
				_oCtEffect = transform.gameObject;
				_oCtEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TBar":
				_oTBar = transform.gameObject;
				_oTBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TLight":
				_oTLight = transform.gameObject;
				_oTLightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "TBarEnd":
				_oTBarEnd = transform.gameObject;
				_oTBarEndRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "TEffect":
				_oTEffect = transform.gameObject;
				_oTEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PhaseScore":
				_oPhaseScore = transform.gameObject;
				_oPhaseScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "CtScore":
				_oCtScore = transform.gameObject;
				_oCtScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "TScore":
				_oTScore = transform.gameObject;
				_oTScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "TKill":
				_oTKill = transform.gameObject;
				_oTKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKill":
				_oCtKill = transform.gameObject;
				_oCtKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponEffect":
				_oWeaponEffect = transform.gameObject;
				_oWeaponEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			}
		}
	}

	public void WeaponNtvsize()
	{
		if (_oWeaponImage != null)
		{
			_oWeaponImage.SetNativeSize();
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
