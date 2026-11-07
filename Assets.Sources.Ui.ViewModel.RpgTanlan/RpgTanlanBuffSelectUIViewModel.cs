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

namespace Assets.Sources.Ui.ViewModel.RpgTanlan;

[GameUiTest]
public class RpgTanlanBuffSelectUIViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oimgLabelSuccess;

	private GameObject _otxtTotalWeight;

	private Text _otxtTotalWeightText;

	private GameObject _otxtRefreshCount;

	private Text _otxtRefreshCountText;

	private GameObject _obtnRefresh;

	private Button _obtnRefreshButton;

	private GameObject _orewardContent;

	private GameObject _onextRewardContent;

	private GameObject _omyBuffContent;

	private GameObject _oimgSelect;

	private RectTransform _oimgSelectRectTransform;

	private GameObject _otxtTipDesc;

	private Text _otxtTipDescText;

	private GameObject _oselectBuffContainer;

	private GameObject _oselectBuffContent;

	private RectTransform _oselectBuffContentRectTransform;

	private GameObject _obtnReturn;

	private Button _obtnReturnButton;

	private GameObject _obtnContinue;

	private Button _obtnContinueButton;

	private GameObject _otxtTimeDown;

	private Text _otxtTimeDownText;

	private GameObject _obtnNextRewardRefresh;

	private Button _obtnNextRewardRefreshButton;

	private GameObject _otxtNextRewardRefreshCount;

	private Text _otxtNextRewardRefreshCountText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtanlan";

	private string _resourceAssetName = "rpgtanlanbuffselectui";

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

	public bool imgLabelSuccessShow
	{
		get
		{
			if (_oimgLabelSuccess != null)
			{
				return _oimgLabelSuccess.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (imgLabelSuccessShow != value && _oimgLabelSuccess != null)
			{
				_oimgLabelSuccess.SetObjectActive(value);
			}
		}
	}

	public string txtTotalWeightString
	{
		get
		{
			if (_otxtTotalWeightText != null)
			{
				return _otxtTotalWeightText.text;
			}
			return null;
		}
		set
		{
			if (txtTotalWeightString != value && _otxtTotalWeightText != null)
			{
				_otxtTotalWeightText.text = value;
			}
		}
	}

	public string txtRefreshCountString
	{
		get
		{
			if (_otxtRefreshCountText != null)
			{
				return _otxtRefreshCountText.text;
			}
			return null;
		}
		set
		{
			if (txtRefreshCountString != value && _otxtRefreshCountText != null)
			{
				_otxtRefreshCountText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnRefreshClicked
	{
		get
		{
			if (_obtnRefreshButton != null)
			{
				return _obtnRefreshButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnRefreshClicked != value && _obtnRefreshButton != null)
			{
				_obtnRefreshButton.onClick = value;
			}
		}
	}

	public bool btnRefreshButtonable
	{
		get
		{
			if (_obtnRefreshButton != null)
			{
				return _obtnRefreshButton.interactable;
			}
			return true;
		}
		set
		{
			if (btnRefreshButtonable != value && _obtnRefreshButton != null)
			{
				_obtnRefreshButton.interactable = value;
			}
		}
	}

	public GameObject rewardContentObj => _orewardContent;

	public GameObject nextRewardContentObj => _onextRewardContent;

	public GameObject myBuffContentObj => _omyBuffContent;

	public bool imgSelectShow
	{
		get
		{
			if (_oimgSelect != null)
			{
				return _oimgSelect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (imgSelectShow != value && _oimgSelect != null)
			{
				_oimgSelect.SetObjectActive(value);
			}
		}
	}

	public Vector3 imgSelectPosition
	{
		get
		{
			if (_oimgSelectRectTransform != null)
			{
				return _oimgSelectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (imgSelectPosition != value && _oimgSelectRectTransform != null)
			{
				_oimgSelectRectTransform.localPosition = value;
			}
		}
	}

	public string txtTipDescString
	{
		get
		{
			if (_otxtTipDescText != null)
			{
				return _otxtTipDescText.text;
			}
			return null;
		}
		set
		{
			if (txtTipDescString != value && _otxtTipDescText != null)
			{
				_otxtTipDescText.text = value;
			}
		}
	}

	public GameObject selectBuffContainerObj => _oselectBuffContainer;

	public bool selectBuffContainerShow
	{
		get
		{
			if (_oselectBuffContainer != null)
			{
				return _oselectBuffContainer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectBuffContainerShow != value && _oselectBuffContainer != null)
			{
				_oselectBuffContainer.SetObjectActive(value);
			}
		}
	}

	public GameObject selectBuffContentObj => _oselectBuffContent;

	public Vector3 selectBuffContentPosition
	{
		get
		{
			if (_oselectBuffContentRectTransform != null)
			{
				return _oselectBuffContentRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (selectBuffContentPosition != value && _oselectBuffContentRectTransform != null)
			{
				_oselectBuffContentRectTransform.localPosition = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnReturnClicked
	{
		get
		{
			if (_obtnReturnButton != null)
			{
				return _obtnReturnButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnReturnClicked != value && _obtnReturnButton != null)
			{
				_obtnReturnButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnContinueClicked
	{
		get
		{
			if (_obtnContinueButton != null)
			{
				return _obtnContinueButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnContinueClicked != value && _obtnContinueButton != null)
			{
				_obtnContinueButton.onClick = value;
			}
		}
	}

	public string txtTimeDownString
	{
		get
		{
			if (_otxtTimeDownText != null)
			{
				return _otxtTimeDownText.text;
			}
			return null;
		}
		set
		{
			if (txtTimeDownString != value && _otxtTimeDownText != null)
			{
				_otxtTimeDownText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnNextRewardRefreshClicked
	{
		get
		{
			if (_obtnNextRewardRefreshButton != null)
			{
				return _obtnNextRewardRefreshButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnNextRewardRefreshClicked != value && _obtnNextRewardRefreshButton != null)
			{
				_obtnNextRewardRefreshButton.onClick = value;
			}
		}
	}

	public bool btnNextRewardRefreshButtonable
	{
		get
		{
			if (_obtnNextRewardRefreshButton != null)
			{
				return _obtnNextRewardRefreshButton.interactable;
			}
			return true;
		}
		set
		{
			if (btnNextRewardRefreshButtonable != value && _obtnNextRewardRefreshButton != null)
			{
				_obtnNextRewardRefreshButton.interactable = value;
			}
		}
	}

	public string txtNextRewardRefreshCountString
	{
		get
		{
			if (_otxtNextRewardRefreshCountText != null)
			{
				return _otxtNextRewardRefreshCountText.text;
			}
			return null;
		}
		set
		{
			if (txtNextRewardRefreshCountString != value && _otxtNextRewardRefreshCountText != null)
			{
				_otxtNextRewardRefreshCountText.text = value;
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
			case "imgLabelSuccess":
				_oimgLabelSuccess = transform.gameObject;
				break;
			case "txtTotalWeight":
				_otxtTotalWeight = transform.gameObject;
				_otxtTotalWeightText = transform.gameObject.GetComponent<Text>();
				break;
			case "txtRefreshCount":
				_otxtRefreshCount = transform.gameObject;
				_otxtRefreshCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "btnRefresh":
				_obtnRefresh = transform.gameObject;
				_obtnRefreshButton = transform.gameObject.GetComponent<Button>();
				break;
			case "rewardContent":
				_orewardContent = transform.gameObject;
				break;
			case "nextRewardContent":
				_onextRewardContent = transform.gameObject;
				break;
			case "myBuffContent":
				_omyBuffContent = transform.gameObject;
				break;
			case "imgSelect":
				_oimgSelect = transform.gameObject;
				_oimgSelectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "txtTipDesc":
				_otxtTipDesc = transform.gameObject;
				_otxtTipDescText = transform.gameObject.GetComponent<Text>();
				break;
			case "selectBuffContainer":
				_oselectBuffContainer = transform.gameObject;
				break;
			case "selectBuffContent":
				_oselectBuffContent = transform.gameObject;
				_oselectBuffContentRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "btnReturn":
				_obtnReturn = transform.gameObject;
				_obtnReturnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "btnContinue":
				_obtnContinue = transform.gameObject;
				_obtnContinueButton = transform.gameObject.GetComponent<Button>();
				break;
			case "txtTimeDown":
				_otxtTimeDown = transform.gameObject;
				_otxtTimeDownText = transform.gameObject.GetComponent<Text>();
				break;
			case "btnNextRewardRefresh":
				_obtnNextRewardRefresh = transform.gameObject;
				_obtnNextRewardRefreshButton = transform.gameObject.GetComponent<Button>();
				break;
			case "txtNextRewardRefreshCount":
				_otxtNextRewardRefreshCount = transform.gameObject;
				_otxtNextRewardRefreshCountText = transform.gameObject.GetComponent<Text>();
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
