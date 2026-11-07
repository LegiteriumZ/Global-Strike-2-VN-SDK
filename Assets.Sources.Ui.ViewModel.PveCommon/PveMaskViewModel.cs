using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.PveCommon;

[GameUiTest]
public class PveMaskViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oImage;

	private CanvasGroup _oImageCanvasGroup;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pvecommon";

	private string _resourceAssetName = "PveMask";

	public bool ImageShow
	{
		get
		{
			if (_oImage != null)
			{
				return _oImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ImageShow != value && _oImage != null)
			{
				_oImage.SetObjectActive(value);
			}
		}
	}

	public float ImageAlpha
	{
		get
		{
			if (_oImageCanvasGroup != null)
			{
				return _oImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ImageAlpha != value && _oImageCanvasGroup != null)
			{
				_oImageCanvasGroup.alpha = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (text == "Image")
			{
				_oImage = transform.gameObject;
				_oImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
