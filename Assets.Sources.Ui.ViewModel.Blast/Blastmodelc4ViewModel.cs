using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.Blast;

[GameUiTest]
public class Blastmodelc4ViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oC4IconImage;

	private GameObject _oPliersImage;

	private GameObject _oC4IconActiveImage;

	private CanvasGroup _oC4IconActiveImageCanvasGroup;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "Blastmodelc4";

	public bool C4IconImageShow
	{
		get
		{
			if (_oC4IconImage != null)
			{
				return _oC4IconImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4IconImageShow != value && _oC4IconImage != null)
			{
				_oC4IconImage.SetObjectActive(value);
			}
		}
	}

	public bool PliersImageShow
	{
		get
		{
			if (_oPliersImage != null)
			{
				return _oPliersImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PliersImageShow != value && _oPliersImage != null)
			{
				_oPliersImage.SetObjectActive(value);
			}
		}
	}

	public bool C4IconActiveImageShow
	{
		get
		{
			if (_oC4IconActiveImage != null)
			{
				return _oC4IconActiveImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4IconActiveImageShow != value && _oC4IconActiveImage != null)
			{
				_oC4IconActiveImage.SetObjectActive(value);
			}
		}
	}

	public float C4IconActiveImageAlpha
	{
		get
		{
			if (_oC4IconActiveImageCanvasGroup != null)
			{
				return _oC4IconActiveImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (C4IconActiveImageAlpha != value && _oC4IconActiveImageCanvasGroup != null)
			{
				_oC4IconActiveImageCanvasGroup.alpha = value;
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
			case "C4IconImage":
				_oC4IconImage = transform.gameObject;
				break;
			case "PliersImage":
				_oPliersImage = transform.gameObject;
				break;
			case "C4IconActiveImage":
				_oC4IconActiveImage = transform.gameObject;
				_oC4IconActiveImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
