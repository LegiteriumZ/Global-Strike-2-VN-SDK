using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgStateProgressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oLight;

	private RectTransform _oLightRectTransform;

	private GameObject _oGrid;

	private HorizontalLayoutGroup _oGridHorizontalLayoutGroup;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oText;

	private Text _oTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgStateProgress";

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

	public Vector3 LightPosition
	{
		get
		{
			if (_oLightRectTransform != null)
			{
				return _oLightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LightPosition != value && _oLightRectTransform != null)
			{
				_oLightRectTransform.localPosition = value;
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

	public string TextString
	{
		get
		{
			if (_oTextText != null)
			{
				return _oTextText.text;
			}
			return null;
		}
		set
		{
			if (TextString != value && _oTextText != null)
			{
				_oTextText.text = value;
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
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Light":
				_oLight = transform.gameObject;
				_oLightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				_oGridHorizontalLayoutGroup = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Text":
				_oText = transform.gameObject;
				_oTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void GridHlayoutupdate()
	{
		if (_oGridHorizontalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oGrid.GetComponent<RectTransform>());
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
