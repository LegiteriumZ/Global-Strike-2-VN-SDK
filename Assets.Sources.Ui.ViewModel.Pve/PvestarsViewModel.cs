using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PvestarsViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oStarnum;

	private Text _oStarnumText;

	private GameObject _ostareffect;

	private RectTransform _ostareffectRectTransform;

	private Image _ostareffectImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pvestars";

	public string StarnumString
	{
		get
		{
			if (_oStarnumText != null)
			{
				return _oStarnumText.text;
			}
			return null;
		}
		set
		{
			if (StarnumString != value && _oStarnumText != null)
			{
				_oStarnumText.text = value;
			}
		}
	}

	public bool stareffectShow
	{
		get
		{
			if (_ostareffect != null)
			{
				return _ostareffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (stareffectShow != value && _ostareffect != null)
			{
				_ostareffect.SetObjectActive(value);
			}
		}
	}

	public Vector2 stareffectAnchoredposition
	{
		get
		{
			if (_ostareffectRectTransform != null)
			{
				return _ostareffectRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (stareffectAnchoredposition != value && _ostareffectRectTransform != null)
			{
				_ostareffectRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 stareffectPosition
	{
		get
		{
			if (_ostareffectRectTransform != null)
			{
				return _ostareffectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (stareffectPosition != value && _ostareffectRectTransform != null)
			{
				_ostareffectRectTransform.localPosition = value;
			}
		}
	}

	public Image stareffectImage
	{
		get
		{
			if (_ostareffectImage != null)
			{
				return _ostareffectImage;
			}
			return null;
		}
		set
		{
			if (stareffectImage != value && _ostareffectImage != null)
			{
				_ostareffectImage = value;
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
			if (!(text == "Starnum"))
			{
				if (text == "stareffect")
				{
					_ostareffect = transform.gameObject;
					_ostareffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
					_ostareffectImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oStarnum = transform.gameObject;
				_oStarnumText = transform.gameObject.GetComponent<Text>();
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
