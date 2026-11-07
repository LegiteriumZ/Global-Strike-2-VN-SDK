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

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgTabWindowViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTeamInfo;

	private GameObject _oGrid;

	private GameObject _oTeamInfoButton;

	private Image _oTeamInfoButtonImage;

	private EventTrigger _oTeamInfoButtonEventTrigger;

	private GameObject _oTeamInfoSelectedText;

	private GameObject _oTeamInfoHighlightText;

	private GameObject _oTeamInfoCommonText;

	private GameObject _oPowerUpInfo;

	private GameObject _oPowerUpNumber;

	private Text _oPowerUpNumberText;

	private GameObject _oContent;

	private RectTransform _oContentRectTransform;

	private GameObject _oPowerUpIcon;

	private Image _oPowerUpIconImage;

	private Button _oPowerUpIconButton;

	private GameObject _oPowerUpIntroName;

	private Text _oPowerUpIntroNameText;

	private GameObject _oPowerUpIntroIcon;

	private Image _oPowerUpIntroIconImage;

	private GameObject _oPowerUpIntroText;

	private Text _oPowerUpIntroTextText;

	private GameObject _oPowerUpInfoButton;

	private Image _oPowerUpInfoButtonImage;

	private EventTrigger _oPowerUpInfoButtonEventTrigger;

	private GameObject _oPowerUpInfoSelectedText;

	private GameObject _oPowerUpInfoHighlightText;

	private GameObject _oPowerUpInfoCommonText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgtabwindow";

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

	public bool TeamInfoShow
	{
		get
		{
			if (_oTeamInfo != null)
			{
				return _oTeamInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TeamInfoShow != value && _oTeamInfo != null)
			{
				_oTeamInfo.SetObjectActive(value);
			}
		}
	}

	public GameObject GridObj => _oGrid;

	public Image TeamInfoButtonImage
	{
		get
		{
			if (_oTeamInfoButtonImage != null)
			{
				return _oTeamInfoButtonImage;
			}
			return null;
		}
		set
		{
			if (TeamInfoButtonImage != value && _oTeamInfoButtonImage != null)
			{
				_oTeamInfoButtonImage = value;
			}
		}
	}

	public List<EventTrigger.Entry> TeamInfoButtonTriggers
	{
		get
		{
			if (_oTeamInfoButtonEventTrigger != null)
			{
				return _oTeamInfoButtonEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (TeamInfoButtonTriggers != value && _oTeamInfoButtonEventTrigger != null)
			{
				_oTeamInfoButtonEventTrigger.triggers = value;
			}
		}
	}

	public bool TeamInfoSelectedTextShow
	{
		get
		{
			if (_oTeamInfoSelectedText != null)
			{
				return _oTeamInfoSelectedText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TeamInfoSelectedTextShow != value && _oTeamInfoSelectedText != null)
			{
				_oTeamInfoSelectedText.SetObjectActive(value);
			}
		}
	}

	public bool TeamInfoHighlightTextShow
	{
		get
		{
			if (_oTeamInfoHighlightText != null)
			{
				return _oTeamInfoHighlightText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TeamInfoHighlightTextShow != value && _oTeamInfoHighlightText != null)
			{
				_oTeamInfoHighlightText.SetObjectActive(value);
			}
		}
	}

	public bool TeamInfoCommonTextShow
	{
		get
		{
			if (_oTeamInfoCommonText != null)
			{
				return _oTeamInfoCommonText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TeamInfoCommonTextShow != value && _oTeamInfoCommonText != null)
			{
				_oTeamInfoCommonText.SetObjectActive(value);
			}
		}
	}

	public bool PowerUpInfoShow
	{
		get
		{
			if (_oPowerUpInfo != null)
			{
				return _oPowerUpInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerUpInfoShow != value && _oPowerUpInfo != null)
			{
				_oPowerUpInfo.SetObjectActive(value);
			}
		}
	}

	public string PowerUpNumberString
	{
		get
		{
			if (_oPowerUpNumberText != null)
			{
				return _oPowerUpNumberText.text;
			}
			return null;
		}
		set
		{
			if (PowerUpNumberString != value && _oPowerUpNumberText != null)
			{
				_oPowerUpNumberText.text = value;
			}
		}
	}

	public GameObject ContentObj => _oContent;

	public Vector3 ContentSize
	{
		get
		{
			if (_oContentRectTransform != null)
			{
				return _oContentRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ContentSize != value && _oContentRectTransform != null)
			{
				_oContentRectTransform.sizeDelta = value;
			}
		}
	}

	public Rect ContentRect
	{
		get
		{
			if (_oContentRectTransform != null)
			{
				return _oContentRectTransform.rect;
			}
			return Rect.zero;
		}
	}

	public GameObject PowerUpIconObj => _oPowerUpIcon;

	public Image PowerUpIconImage
	{
		get
		{
			if (_oPowerUpIconImage != null)
			{
				return _oPowerUpIconImage;
			}
			return null;
		}
		set
		{
			if (PowerUpIconImage != value && _oPowerUpIconImage != null)
			{
				_oPowerUpIconImage = value;
			}
		}
	}

	public Button PowerUpIconButton
	{
		get
		{
			if (_oPowerUpIconButton != null)
			{
				return _oPowerUpIconButton;
			}
			return null;
		}
		set
		{
			if (PowerUpIconButton != value && _oPowerUpIconButton != null)
			{
				_oPowerUpIconButton = value;
			}
		}
	}

	public string PowerUpIntroNameString
	{
		get
		{
			if (_oPowerUpIntroNameText != null)
			{
				return _oPowerUpIntroNameText.text;
			}
			return null;
		}
		set
		{
			if (PowerUpIntroNameString != value && _oPowerUpIntroNameText != null)
			{
				_oPowerUpIntroNameText.text = value;
			}
		}
	}

	public Image PowerUpIntroIconImage
	{
		get
		{
			if (_oPowerUpIntroIconImage != null)
			{
				return _oPowerUpIntroIconImage;
			}
			return null;
		}
		set
		{
			if (PowerUpIntroIconImage != value && _oPowerUpIntroIconImage != null)
			{
				_oPowerUpIntroIconImage = value;
			}
		}
	}

	public string PowerUpIntroTextString
	{
		get
		{
			if (_oPowerUpIntroTextText != null)
			{
				return _oPowerUpIntroTextText.text;
			}
			return null;
		}
		set
		{
			if (PowerUpIntroTextString != value && _oPowerUpIntroTextText != null)
			{
				_oPowerUpIntroTextText.text = value;
			}
		}
	}

	public Image PowerUpInfoButtonImage
	{
		get
		{
			if (_oPowerUpInfoButtonImage != null)
			{
				return _oPowerUpInfoButtonImage;
			}
			return null;
		}
		set
		{
			if (PowerUpInfoButtonImage != value && _oPowerUpInfoButtonImage != null)
			{
				_oPowerUpInfoButtonImage = value;
			}
		}
	}

	public List<EventTrigger.Entry> PowerUpInfoButtonTriggers
	{
		get
		{
			if (_oPowerUpInfoButtonEventTrigger != null)
			{
				return _oPowerUpInfoButtonEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (PowerUpInfoButtonTriggers != value && _oPowerUpInfoButtonEventTrigger != null)
			{
				_oPowerUpInfoButtonEventTrigger.triggers = value;
			}
		}
	}

	public bool PowerUpInfoSelectedTextShow
	{
		get
		{
			if (_oPowerUpInfoSelectedText != null)
			{
				return _oPowerUpInfoSelectedText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerUpInfoSelectedTextShow != value && _oPowerUpInfoSelectedText != null)
			{
				_oPowerUpInfoSelectedText.SetObjectActive(value);
			}
		}
	}

	public bool PowerUpInfoHighlightTextShow
	{
		get
		{
			if (_oPowerUpInfoHighlightText != null)
			{
				return _oPowerUpInfoHighlightText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerUpInfoHighlightTextShow != value && _oPowerUpInfoHighlightText != null)
			{
				_oPowerUpInfoHighlightText.SetObjectActive(value);
			}
		}
	}

	public bool PowerUpInfoCommonTextShow
	{
		get
		{
			if (_oPowerUpInfoCommonText != null)
			{
				return _oPowerUpInfoCommonText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerUpInfoCommonTextShow != value && _oPowerUpInfoCommonText != null)
			{
				_oPowerUpInfoCommonText.SetObjectActive(value);
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
			case "TeamInfo":
				_oTeamInfo = transform.gameObject;
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				break;
			case "TeamInfoButton":
				_oTeamInfoButton = transform.gameObject;
				_oTeamInfoButtonImage = transform.gameObject.GetComponent<Image>();
				_oTeamInfoButtonEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TeamInfoSelectedText":
				_oTeamInfoSelectedText = transform.gameObject;
				break;
			case "TeamInfoHighlightText":
				_oTeamInfoHighlightText = transform.gameObject;
				break;
			case "TeamInfoCommonText":
				_oTeamInfoCommonText = transform.gameObject;
				break;
			case "PowerUpInfo":
				_oPowerUpInfo = transform.gameObject;
				break;
			case "PowerUpNumber":
				_oPowerUpNumber = transform.gameObject;
				_oPowerUpNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "Content":
				_oContent = transform.gameObject;
				_oContentRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "PowerUpIcon":
				_oPowerUpIcon = transform.gameObject;
				_oPowerUpIconImage = transform.gameObject.GetComponent<Image>();
				_oPowerUpIconButton = transform.gameObject.GetComponent<Button>();
				break;
			case "PowerUpIntroName":
				_oPowerUpIntroName = transform.gameObject;
				_oPowerUpIntroNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PowerUpIntroIcon":
				_oPowerUpIntroIcon = transform.gameObject;
				_oPowerUpIntroIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUpIntroText":
				_oPowerUpIntroText = transform.gameObject;
				_oPowerUpIntroTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "PowerUpInfoButton":
				_oPowerUpInfoButton = transform.gameObject;
				_oPowerUpInfoButtonImage = transform.gameObject.GetComponent<Image>();
				_oPowerUpInfoButtonEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "PowerUpInfoSelectedText":
				_oPowerUpInfoSelectedText = transform.gameObject;
				break;
			case "PowerUpInfoHighlightText":
				_oPowerUpInfoHighlightText = transform.gameObject;
				break;
			case "PowerUpInfoCommonText":
				_oPowerUpInfoCommonText = transform.gameObject;
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

	private void CreateTeamInfoButtonTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TeamInfoButtonTriggers, eventId, callback);
	}

	private void RemoveTeamInfoButtonTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TeamInfoButtonTriggers, eventId);
	}

	private void CreatePowerUpInfoButtonTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(PowerUpInfoButtonTriggers, eventId, callback);
	}

	private void RemovePowerUpInfoButtonTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(PowerUpInfoButtonTriggers, eventId);
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
