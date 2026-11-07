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
public class HitCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _oLu;

	private RectTransform _oLuRectTransform;

	private Image _oLuImage;

	private GameObject _oRu;

	private RectTransform _oRuRectTransform;

	private Image _oRuImage;

	private GameObject _oLd;

	private RectTransform _oLdRectTransform;

	private Image _oLdImage;

	private GameObject _oRd;

	private RectTransform _oRdRectTransform;

	private Image _oRdImage;

	private GameObject _viewGameObject;

	private bool _ShowHere = true;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "HitCross";

	public bool ShowHere
	{
		get
		{
			return _ShowHere;
		}
		set
		{
			if (ShowHere != value && _oShowRectTransform != null)
			{
				_ShowHere = value;
				if (value)
				{
					_oShowRectTransform.localPosition -= new Vector3(10000f, 10000f, 0f);
				}
				else
				{
					_oShowRectTransform.localPosition += new Vector3(10000f, 10000f, 0f);
				}
			}
		}
	}

	public Quaternion ShowRotation
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (ShowRotation != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localRotation = value;
			}
		}
	}

	public Vector3 LuPosition
	{
		get
		{
			if (_oLuRectTransform != null)
			{
				return _oLuRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LuPosition != value && _oLuRectTransform != null)
			{
				_oLuRectTransform.localPosition = value;
			}
		}
	}

	public Color LuColor
	{
		get
		{
			if (_oLuImage != null)
			{
				return _oLuImage.color;
			}
			return Color.white;
		}
		set
		{
			if (LuColor != value && _oLuImage != null)
			{
				_oLuImage.color = value;
			}
		}
	}

	public Vector3 RuPosition
	{
		get
		{
			if (_oRuRectTransform != null)
			{
				return _oRuRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RuPosition != value && _oRuRectTransform != null)
			{
				_oRuRectTransform.localPosition = value;
			}
		}
	}

	public Color RuColor
	{
		get
		{
			if (_oRuImage != null)
			{
				return _oRuImage.color;
			}
			return Color.white;
		}
		set
		{
			if (RuColor != value && _oRuImage != null)
			{
				_oRuImage.color = value;
			}
		}
	}

	public Vector3 LdPosition
	{
		get
		{
			if (_oLdRectTransform != null)
			{
				return _oLdRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LdPosition != value && _oLdRectTransform != null)
			{
				_oLdRectTransform.localPosition = value;
			}
		}
	}

	public Color LdColor
	{
		get
		{
			if (_oLdImage != null)
			{
				return _oLdImage.color;
			}
			return Color.white;
		}
		set
		{
			if (LdColor != value && _oLdImage != null)
			{
				_oLdImage.color = value;
			}
		}
	}

	public Vector3 RdPosition
	{
		get
		{
			if (_oRdRectTransform != null)
			{
				return _oRdRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RdPosition != value && _oRdRectTransform != null)
			{
				_oRdRectTransform.localPosition = value;
			}
		}
	}

	public Color RdColor
	{
		get
		{
			if (_oRdImage != null)
			{
				return _oRdImage.color;
			}
			return Color.white;
		}
		set
		{
			if (RdColor != value && _oRdImage != null)
			{
				_oRdImage.color = value;
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Lu":
				_oLu = transform.gameObject;
				_oLuRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oLuImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Ru":
				_oRu = transform.gameObject;
				_oRuRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oRuImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Ld":
				_oLd = transform.gameObject;
				_oLdRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oLdImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Rd":
				_oRd = transform.gameObject;
				_oRdRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oRdImage = transform.gameObject.GetComponent<Image>();
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
