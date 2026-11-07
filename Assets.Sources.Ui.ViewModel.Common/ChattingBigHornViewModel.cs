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
public class ChattingBigHornViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBack;

	private RectTransform _oBackRectTransform;

	private GameObject _oLayout;

	private HorizontalLayoutGroup _oLayoutHorizontalLayoutGroup;

	private GameObject _oPlayerName;

	private RectTransform _oPlayerNameRectTransform;

	private Text _oPlayerNameText;

	private GameObject _oMask;

	private RectTransform _oMaskRectTransform;

	private GameObject _oChatText;

	private RectTransform _oChatTextRectTransform;

	private Text _oChatTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ChattingBigHorn";

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

	public Vector3 BackPosition
	{
		get
		{
			if (_oBackRectTransform != null)
			{
				return _oBackRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BackPosition != value && _oBackRectTransform != null)
			{
				_oBackRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 PlayerNameSize
	{
		get
		{
			if (_oPlayerNameRectTransform != null)
			{
				return _oPlayerNameRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PlayerNameSize != value && _oPlayerNameRectTransform != null)
			{
				_oPlayerNameRectTransform.sizeDelta = value;
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

	public Color PlayerNameTextcolor
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.color = value;
			}
		}
	}

	public Vector3 MaskSize
	{
		get
		{
			if (_oMaskRectTransform != null)
			{
				return _oMaskRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (MaskSize != value && _oMaskRectTransform != null)
			{
				_oMaskRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 ChatTextPosition
	{
		get
		{
			if (_oChatTextRectTransform != null)
			{
				return _oChatTextRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ChatTextPosition != value && _oChatTextRectTransform != null)
			{
				_oChatTextRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 ChatTextSize
	{
		get
		{
			if (_oChatTextRectTransform != null)
			{
				return _oChatTextRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ChatTextSize != value && _oChatTextRectTransform != null)
			{
				_oChatTextRectTransform.sizeDelta = value;
			}
		}
	}

	public string ChatTextString
	{
		get
		{
			if (_oChatTextText != null)
			{
				return _oChatTextText.text;
			}
			return null;
		}
		set
		{
			if (ChatTextString != value && _oChatTextText != null)
			{
				_oChatTextText.text = value;
			}
		}
	}

	public Color ChatTextTextcolor
	{
		get
		{
			if (_oChatTextText != null)
			{
				return _oChatTextText.color;
			}
			return Color.white;
		}
		set
		{
			if (ChatTextTextcolor != value && _oChatTextText != null)
			{
				_oChatTextText.color = value;
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
			case "Back":
				_oBack = transform.gameObject;
				_oBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Layout":
				_oLayout = transform.gameObject;
				_oLayoutHorizontalLayoutGroup = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Mask":
				_oMask = transform.gameObject;
				_oMaskRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ChatText":
				_oChatText = transform.gameObject;
				_oChatTextRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oChatTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void LayoutHlayoutupdate()
	{
		if (_oLayoutHorizontalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oLayout.GetComponent<RectTransform>());
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
