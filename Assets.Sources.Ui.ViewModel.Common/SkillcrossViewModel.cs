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
public class SkillcrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oCrossBack;

	private RectTransform _oCrossBackRectTransform;

	private Image _oCrossBackImage;

	private GameObject _oLockCross;

	private RectTransform _oLockCrossRectTransform;

	private CanvasGroup _oLockCrossCanvasGroup;

	private Image _oLockCrossImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Skillcross";

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

	public Quaternion CrossBackRotation
	{
		get
		{
			if (_oCrossBackRectTransform != null)
			{
				return _oCrossBackRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (CrossBackRotation != value && _oCrossBackRectTransform != null)
			{
				_oCrossBackRectTransform.localRotation = value;
			}
		}
	}

	public Sprite CrossBackSprite
	{
		get
		{
			if (_oCrossBackImage != null)
			{
				return _oCrossBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (CrossBackSprite != value && _oCrossBackImage != null)
			{
				_oCrossBackImage.sprite = value;
			}
		}
	}

	public Vector3 LockCrossScale
	{
		get
		{
			if (_oLockCrossRectTransform != null)
			{
				return _oLockCrossRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LockCrossScale != value && _oLockCrossRectTransform != null)
			{
				_oLockCrossRectTransform.localScale = value;
			}
		}
	}

	public float LockCrossAlpha
	{
		get
		{
			if (_oLockCrossCanvasGroup != null)
			{
				return _oLockCrossCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (LockCrossAlpha != value && _oLockCrossCanvasGroup != null)
			{
				_oLockCrossCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite LockCrossSprite
	{
		get
		{
			if (_oLockCrossImage != null)
			{
				return _oLockCrossImage.sprite;
			}
			return null;
		}
		set
		{
			if (LockCrossSprite != value && _oLockCrossImage != null)
			{
				_oLockCrossImage.sprite = value;
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
			case "CrossBack":
				_oCrossBack = transform.gameObject;
				_oCrossBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oCrossBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LockCross":
				_oLockCross = transform.gameObject;
				_oLockCrossRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oLockCrossCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oLockCrossImage = transform.gameObject.GetComponent<Image>();
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
