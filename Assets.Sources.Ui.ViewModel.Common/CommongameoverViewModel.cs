using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class CommongameoverViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private CanvasGroup _oPanelCanvasGroup;

	private GameObject _oGameOverImage;

	private Image _oGameOverImageImage;

	private GameObject _oWinnerName;

	private Text _oWinnerNameText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Commongameover";

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

	public float PanelAlpha
	{
		get
		{
			if (_oPanelCanvasGroup != null)
			{
				return _oPanelCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (PanelAlpha != value && _oPanelCanvasGroup != null)
			{
				_oPanelCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite GameOverImageSprite
	{
		get
		{
			if (_oGameOverImageImage != null)
			{
				return _oGameOverImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (GameOverImageSprite != value && _oGameOverImageImage != null)
			{
				_oGameOverImageImage.sprite = value;
			}
		}
	}

	public bool WinnerNameShow
	{
		get
		{
			if (_oWinnerName != null)
			{
				return _oWinnerName.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WinnerNameShow != value && _oWinnerName != null)
			{
				_oWinnerName.SetObjectActive(value);
			}
		}
	}

	public string WinnerNameString
	{
		get
		{
			if (_oWinnerNameText != null)
			{
				return _oWinnerNameText.text;
			}
			return null;
		}
		set
		{
			if (WinnerNameString != value && _oWinnerNameText != null)
			{
				_oWinnerNameText.text = value;
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
				_oPanelCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "GameOverImage":
				_oGameOverImage = transform.gameObject;
				_oGameOverImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WinnerName":
				_oWinnerName = transform.gameObject;
				_oWinnerNameText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void GameOverImageNtvsize()
	{
		if (_oGameOverImageImage != null)
		{
			_oGameOverImageImage.SetNativeSize();
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
