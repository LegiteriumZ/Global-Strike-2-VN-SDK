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
public class MechwarriorHeroGrowupViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oEnergyProgress;

	private Image _oEnergyProgressImage;

	private GameObject _oEnergyText;

	private Text _oEnergyTextText;

	private GameObject _oGetEnergyEffect;

	private RectTransform _oGetEnergyEffectRectTransform;

	private CanvasGroup _oGetEnergyEffectCanvasGroup;

	private GameObject _oExpProgress;

	private Image _oExpProgressImage;

	private GameObject _oEffect;

	private Image _oEffectImage;

	private GameObject _oExpText;

	private Text _oExpTextText;

	private GameObject _oMaxExpText;

	private Text _oMaxExpTextText;

	private GameObject _oLevelText;

	private Text _oLevelTextText;

	private GameObject _oSkillImage;

	private RectTransform _oSkillImageRectTransform;

	private Image _oSkillImageImage;

	private GameObject _oMessage;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorHeroGrowup";

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

	public float EnergyProgressFillamount
	{
		get
		{
			if (_oEnergyProgressImage != null)
			{
				return _oEnergyProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EnergyProgressFillamount != value && _oEnergyProgressImage != null)
			{
				_oEnergyProgressImage.fillAmount = value;
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

	public bool GetEnergyEffectShow
	{
		get
		{
			if (_oGetEnergyEffect != null)
			{
				return _oGetEnergyEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GetEnergyEffectShow != value && _oGetEnergyEffect != null)
			{
				_oGetEnergyEffect.SetObjectActive(value);
			}
		}
	}

	public Quaternion GetEnergyEffectRotation
	{
		get
		{
			if (_oGetEnergyEffectRectTransform != null)
			{
				return _oGetEnergyEffectRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (GetEnergyEffectRotation != value && _oGetEnergyEffectRectTransform != null)
			{
				_oGetEnergyEffectRectTransform.localRotation = value;
			}
		}
	}

	public Vector3 GetEnergyEffectScale
	{
		get
		{
			if (_oGetEnergyEffectRectTransform != null)
			{
				return _oGetEnergyEffectRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (GetEnergyEffectScale != value && _oGetEnergyEffectRectTransform != null)
			{
				_oGetEnergyEffectRectTransform.localScale = value;
			}
		}
	}

	public float GetEnergyEffectAlpha
	{
		get
		{
			if (_oGetEnergyEffectCanvasGroup != null)
			{
				return _oGetEnergyEffectCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (GetEnergyEffectAlpha != value && _oGetEnergyEffectCanvasGroup != null)
			{
				_oGetEnergyEffectCanvasGroup.alpha = value;
			}
		}
	}

	public float ExpProgressFillamount
	{
		get
		{
			if (_oExpProgressImage != null)
			{
				return _oExpProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ExpProgressFillamount != value && _oExpProgressImage != null)
			{
				_oExpProgressImage.fillAmount = value;
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

	public string ExpTextString
	{
		get
		{
			if (_oExpTextText != null)
			{
				return _oExpTextText.text;
			}
			return null;
		}
		set
		{
			if (ExpTextString != value && _oExpTextText != null)
			{
				_oExpTextText.text = value;
			}
		}
	}

	public string MaxExpTextString
	{
		get
		{
			if (_oMaxExpTextText != null)
			{
				return _oMaxExpTextText.text;
			}
			return null;
		}
		set
		{
			if (MaxExpTextString != value && _oMaxExpTextText != null)
			{
				_oMaxExpTextText.text = value;
			}
		}
	}

	public string LevelTextString
	{
		get
		{
			if (_oLevelTextText != null)
			{
				return _oLevelTextText.text;
			}
			return null;
		}
		set
		{
			if (LevelTextString != value && _oLevelTextText != null)
			{
				_oLevelTextText.text = value;
			}
		}
	}

	public Vector3 SkillImageScale
	{
		get
		{
			if (_oSkillImageRectTransform != null)
			{
				return _oSkillImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillImageScale != value && _oSkillImageRectTransform != null)
			{
				_oSkillImageRectTransform.localScale = value;
			}
		}
	}

	public Sprite SkillImageSprite
	{
		get
		{
			if (_oSkillImageImage != null)
			{
				return _oSkillImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillImageSprite != value && _oSkillImageImage != null)
			{
				_oSkillImageImage.sprite = value;
			}
		}
	}

	public bool MessageShow
	{
		get
		{
			if (_oMessage != null)
			{
				return _oMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow != value && _oMessage != null)
			{
				_oMessage.SetObjectActive(value);
			}
		}
	}

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
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
			case "EnergyProgress":
				_oEnergyProgress = transform.gameObject;
				_oEnergyProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyText":
				_oEnergyText = transform.gameObject;
				_oEnergyTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "GetEnergyEffect":
				_oGetEnergyEffect = transform.gameObject;
				_oGetEnergyEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oGetEnergyEffectCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "ExpProgress":
				_oExpProgress = transform.gameObject;
				_oExpProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect":
				_oEffect = transform.gameObject;
				_oEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ExpText":
				_oExpText = transform.gameObject;
				_oExpTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "MaxExpText":
				_oMaxExpText = transform.gameObject;
				_oMaxExpTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "LevelText":
				_oLevelText = transform.gameObject;
				_oLevelTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillImage":
				_oSkillImage = transform.gameObject;
				_oSkillImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Message":
				_oMessage = transform.gameObject;
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
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
