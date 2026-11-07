using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class DiestrikeuitrasonicViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _odiestrikeuitrasonic;

	private GameObject _obackimg;

	private RectTransform _obackimgRectTransform;

	private Image _obackimgImage;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Diestrikeuitrasonic";

	public UiReferences UI => uiRef;

	public GameObject diestrikeuitrasonicObj => _odiestrikeuitrasonic;

	public bool diestrikeuitrasonicShow
	{
		get
		{
			if (_odiestrikeuitrasonic != null)
			{
				return _odiestrikeuitrasonic.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (diestrikeuitrasonicShow != value && _odiestrikeuitrasonic != null)
			{
				_odiestrikeuitrasonic.SetObjectActive(value);
			}
		}
	}

	public bool backimgShow
	{
		get
		{
			if (_obackimg != null)
			{
				return _obackimg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (backimgShow != value && _obackimg != null)
			{
				_obackimg.SetObjectActive(value);
			}
		}
	}

	public Vector2 backimgAnchoredposition
	{
		get
		{
			if (_obackimgRectTransform != null)
			{
				return _obackimgRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (backimgAnchoredposition != value && _obackimgRectTransform != null)
			{
				_obackimgRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 backimgSize
	{
		get
		{
			if (_obackimgRectTransform != null)
			{
				return _obackimgRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (backimgSize != value && _obackimgRectTransform != null)
			{
				_obackimgRectTransform.sizeDelta = value;
			}
		}
	}

	public Color backimgColor
	{
		get
		{
			if (_obackimgImage != null)
			{
				return _obackimgImage.color;
			}
			return Color.white;
		}
		set
		{
			if (backimgColor != value && _obackimgImage != null)
			{
				_obackimgImage.color = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			string text = transform.name.Replace("(Clone)", "");
			if (!(text == "diestrikeuitrasonic"))
			{
				if (text == "backimg")
				{
					_obackimg = transform.gameObject;
					uiRef.Set("backimg", _obackimg.transform);
					_obackimgRectTransform = transform.gameObject.GetComponent<RectTransform>();
					uiRef.Set("backimgRectTransform", _obackimgRectTransform);
					_obackimgImage = transform.gameObject.GetComponent<Image>();
					uiRef.Set("backimgImage", _obackimgImage);
				}
			}
			else
			{
				_odiestrikeuitrasonic = transform.gameObject;
				uiRef.Set("diestrikeuitrasonic", _odiestrikeuitrasonic.transform);
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
