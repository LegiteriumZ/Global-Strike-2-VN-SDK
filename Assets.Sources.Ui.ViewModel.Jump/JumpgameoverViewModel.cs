using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Jump;

[GameUiTest]
public class JumpgameoverViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBaseBackImage;

	private CanvasGroup _oBaseBackImageCanvasGroup;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private CanvasGroup _oMinutesCanvasGroup;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oMilliseconds;

	private Text _oMillisecondsText;

	private GameObject _oSavePoint;

	private Text _oSavePointText;

	private GameObject _oReadPoint;

	private Text _oReadPointText;

	private GameObject _oPenaltyPoint;

	private Text _oPenaltyPointText;

	private GameObject _oSceneText;

	private Text _oSceneTextText;

	private GameObject _oTitleBack;

	private RectTransform _oTitleBackRectTransform;

	private GameObject _oTitleImage;

	private RectTransform _oTitleImageRectTransform;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/jump";

	private string _resourceAssetName = "Jumpgameover";

	public GameObject PanelObj => _oPanel;

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public float BaseBackImageAlpha
	{
		get
		{
			if (_oBaseBackImageCanvasGroup != null)
			{
				return _oBaseBackImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (BaseBackImageAlpha != value && _oBaseBackImageCanvasGroup != null)
			{
				_oBaseBackImageCanvasGroup.alpha = value;
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

	public float MinutesAlpha
	{
		get
		{
			if (_oMinutesCanvasGroup != null)
			{
				return _oMinutesCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (MinutesAlpha != value && _oMinutesCanvasGroup != null)
			{
				_oMinutesCanvasGroup.alpha = value;
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

	public string MillisecondsString
	{
		get
		{
			if (_oMillisecondsText != null)
			{
				return _oMillisecondsText.text;
			}
			return null;
		}
		set
		{
			if (MillisecondsString != value && _oMillisecondsText != null)
			{
				_oMillisecondsText.text = value;
			}
		}
	}

	public string SavePointString
	{
		get
		{
			if (_oSavePointText != null)
			{
				return _oSavePointText.text;
			}
			return null;
		}
		set
		{
			if (SavePointString != value && _oSavePointText != null)
			{
				_oSavePointText.text = value;
			}
		}
	}

	public string ReadPointString
	{
		get
		{
			if (_oReadPointText != null)
			{
				return _oReadPointText.text;
			}
			return null;
		}
		set
		{
			if (ReadPointString != value && _oReadPointText != null)
			{
				_oReadPointText.text = value;
			}
		}
	}

	public string PenaltyPointString
	{
		get
		{
			if (_oPenaltyPointText != null)
			{
				return _oPenaltyPointText.text;
			}
			return null;
		}
		set
		{
			if (PenaltyPointString != value && _oPenaltyPointText != null)
			{
				_oPenaltyPointText.text = value;
			}
		}
	}

	public string SceneTextString
	{
		get
		{
			if (_oSceneTextText != null)
			{
				return _oSceneTextText.text;
			}
			return null;
		}
		set
		{
			if (SceneTextString != value && _oSceneTextText != null)
			{
				_oSceneTextText.text = value;
			}
		}
	}

	public Vector3 TitleBackScale
	{
		get
		{
			if (_oTitleBackRectTransform != null)
			{
				return _oTitleBackRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (TitleBackScale != value && _oTitleBackRectTransform != null)
			{
				_oTitleBackRectTransform.localScale = value;
			}
		}
	}

	public Vector3 TitleImageScale
	{
		get
		{
			if (_oTitleImageRectTransform != null)
			{
				return _oTitleImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (TitleImageScale != value && _oTitleImageRectTransform != null)
			{
				_oTitleImageRectTransform.localScale = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "BaseBackImage":
				_oBaseBackImage = transform.gameObject;
				_oBaseBackImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				_oMinutesCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "Milliseconds":
				_oMilliseconds = transform.gameObject;
				_oMillisecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "SavePoint":
				_oSavePoint = transform.gameObject;
				_oSavePointText = transform.gameObject.GetComponent<Text>();
				break;
			case "ReadPoint":
				_oReadPoint = transform.gameObject;
				_oReadPointText = transform.gameObject.GetComponent<Text>();
				break;
			case "PenaltyPoint":
				_oPenaltyPoint = transform.gameObject;
				_oPenaltyPointText = transform.gameObject.GetComponent<Text>();
				break;
			case "SceneText":
				_oSceneText = transform.gameObject;
				_oSceneTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "TitleBack":
				_oTitleBack = transform.gameObject;
				_oTitleBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "TitleImage":
				_oTitleImage = transform.gameObject;
				_oTitleImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
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
