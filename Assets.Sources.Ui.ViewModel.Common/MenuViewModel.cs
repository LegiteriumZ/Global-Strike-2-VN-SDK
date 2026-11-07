using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class MenuViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImageBG;

	private RectTransform _oImageBGRectTransform;

	private GameObject _oSetup;

	private RectTransform _oSetupRectTransform;

	private EventTrigger _oSetupEventTrigger;

	private GameObject _oHowToPlay;

	private Image _oHowToPlayImage;

	private EventTrigger _oHowToPlayEventTrigger;

	private Button _oHowToPlayButton;

	private GameObject _oShield;

	private RectTransform _oShieldRectTransform;

	private Image _oShieldImage;

	private EventTrigger _oShieldEventTrigger;

	private Button _oShieldButton;

	private GameObject _oShieldLight;

	private GameObject _oReport;

	private Button _oReportButton;

	private GameObject _oResumeGame;

	private RectTransform _oResumeGameRectTransform;

	private EventTrigger _oResumeGameEventTrigger;

	private GameObject _oBackLobby;

	private RectTransform _oBackLobbyRectTransform;

	private EventTrigger _oBackLobbyEventTrigger;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Menu";

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

	public Vector3 ImageBGSize
	{
		get
		{
			if (_oImageBGRectTransform != null)
			{
				return _oImageBGRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageBGSize != value && _oImageBGRectTransform != null)
			{
				_oImageBGRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector2 SetupAnchoredposition
	{
		get
		{
			if (_oSetupRectTransform != null)
			{
				return _oSetupRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (SetupAnchoredposition != value && _oSetupRectTransform != null)
			{
				_oSetupRectTransform.anchoredPosition = value;
			}
		}
	}

	public List<EventTrigger.Entry> SetupTriggers
	{
		get
		{
			if (_oSetupEventTrigger != null)
			{
				return _oSetupEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (SetupTriggers != value && _oSetupEventTrigger != null)
			{
				_oSetupEventTrigger.triggers = value;
			}
		}
	}

	public bool HowToPlayEnabled
	{
		get
		{
			if (_oHowToPlayImage != null)
			{
				return _oHowToPlayImage.enabled;
			}
			return false;
		}
		set
		{
			if (HowToPlayEnabled != value && _oHowToPlayImage != null)
			{
				_oHowToPlayImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public List<EventTrigger.Entry> HowToPlayTriggers
	{
		get
		{
			if (_oHowToPlayEventTrigger != null)
			{
				return _oHowToPlayEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (HowToPlayTriggers != value && _oHowToPlayEventTrigger != null)
			{
				_oHowToPlayEventTrigger.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent HowToPlayClicked
	{
		get
		{
			if (_oHowToPlayButton != null)
			{
				return _oHowToPlayButton.onClick;
			}
			return null;
		}
		set
		{
			if (HowToPlayClicked != value && _oHowToPlayButton != null)
			{
				_oHowToPlayButton.onClick = value;
			}
		}
	}

	public bool HowToPlayButtonable
	{
		get
		{
			if (_oHowToPlayButton != null)
			{
				return _oHowToPlayButton.interactable;
			}
			return true;
		}
		set
		{
			if (HowToPlayButtonable != value && _oHowToPlayButton != null)
			{
				_oHowToPlayButton.interactable = value;
			}
		}
	}

	public bool ShieldShow
	{
		get
		{
			if (_oShield != null)
			{
				return _oShield.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShieldShow != value && _oShield != null)
			{
				_oShield.SetObjectActive(value);
			}
		}
	}

	public Vector2 ShieldAnchoredposition
	{
		get
		{
			if (_oShieldRectTransform != null)
			{
				return _oShieldRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (ShieldAnchoredposition != value && _oShieldRectTransform != null)
			{
				_oShieldRectTransform.anchoredPosition = value;
			}
		}
	}

	public bool ShieldEnabled
	{
		get
		{
			if (_oShieldImage != null)
			{
				return _oShieldImage.enabled;
			}
			return false;
		}
		set
		{
			if (ShieldEnabled != value && _oShieldImage != null)
			{
				_oShieldImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public List<EventTrigger.Entry> ShieldTriggers
	{
		get
		{
			if (_oShieldEventTrigger != null)
			{
				return _oShieldEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ShieldTriggers != value && _oShieldEventTrigger != null)
			{
				_oShieldEventTrigger.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent ShieldClicked
	{
		get
		{
			if (_oShieldButton != null)
			{
				return _oShieldButton.onClick;
			}
			return null;
		}
		set
		{
			if (ShieldClicked != value && _oShieldButton != null)
			{
				_oShieldButton.onClick = value;
			}
		}
	}

	public bool ShieldButtonable
	{
		get
		{
			if (_oShieldButton != null)
			{
				return _oShieldButton.interactable;
			}
			return true;
		}
		set
		{
			if (ShieldButtonable != value && _oShieldButton != null)
			{
				_oShieldButton.interactable = value;
			}
		}
	}

	public bool ShieldLightShow
	{
		get
		{
			if (_oShieldLight != null)
			{
				return _oShieldLight.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShieldLightShow != value && _oShieldLight != null)
			{
				_oShieldLight.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ReportClicked
	{
		get
		{
			if (_oReportButton != null)
			{
				return _oReportButton.onClick;
			}
			return null;
		}
		set
		{
			if (ReportClicked != value && _oReportButton != null)
			{
				_oReportButton.onClick = value;
			}
		}
	}

	public bool ReportButtonable
	{
		get
		{
			if (_oReportButton != null)
			{
				return _oReportButton.interactable;
			}
			return true;
		}
		set
		{
			if (ReportButtonable != value && _oReportButton != null)
			{
				_oReportButton.interactable = value;
			}
		}
	}

	public Vector2 ResumeGameAnchoredposition
	{
		get
		{
			if (_oResumeGameRectTransform != null)
			{
				return _oResumeGameRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (ResumeGameAnchoredposition != value && _oResumeGameRectTransform != null)
			{
				_oResumeGameRectTransform.anchoredPosition = value;
			}
		}
	}

	public List<EventTrigger.Entry> ResumeGameTriggers
	{
		get
		{
			if (_oResumeGameEventTrigger != null)
			{
				return _oResumeGameEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ResumeGameTriggers != value && _oResumeGameEventTrigger != null)
			{
				_oResumeGameEventTrigger.triggers = value;
			}
		}
	}

	public Vector2 BackLobbyAnchoredposition
	{
		get
		{
			if (_oBackLobbyRectTransform != null)
			{
				return _oBackLobbyRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (BackLobbyAnchoredposition != value && _oBackLobbyRectTransform != null)
			{
				_oBackLobbyRectTransform.anchoredPosition = value;
			}
		}
	}

	public List<EventTrigger.Entry> BackLobbyTriggers
	{
		get
		{
			if (_oBackLobbyEventTrigger != null)
			{
				return _oBackLobbyEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (BackLobbyTriggers != value && _oBackLobbyEventTrigger != null)
			{
				_oBackLobbyEventTrigger.triggers = value;
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
			case "ImageBG":
				_oImageBG = transform.gameObject;
				_oImageBGRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Setup":
				_oSetup = transform.gameObject;
				_oSetupRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oSetupEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "HowToPlay":
				_oHowToPlay = transform.gameObject;
				_oHowToPlayImage = transform.gameObject.GetComponent<Image>();
				_oHowToPlayEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oHowToPlayButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Shield":
				_oShield = transform.gameObject;
				_oShieldRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oShieldImage = transform.gameObject.GetComponent<Image>();
				_oShieldEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oShieldButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ShieldLight":
				_oShieldLight = transform.gameObject;
				break;
			case "Report":
				_oReport = transform.gameObject;
				_oReportButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ResumeGame":
				_oResumeGame = transform.gameObject;
				_oResumeGameRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oResumeGameEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "BackLobby":
				_oBackLobby = transform.gameObject;
				_oBackLobbyRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBackLobbyEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			}
		}
	}

	public void HowToPlayNtvsize()
	{
		if (_oHowToPlayImage != null)
		{
			_oHowToPlayImage.SetNativeSize();
		}
	}

	public void ShieldNtvsize()
	{
		if (_oShieldImage != null)
		{
			_oShieldImage.SetNativeSize();
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
