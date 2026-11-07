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
public class SniperCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSniperCross;

	private GameObject _oAwp;

	private Image _oAwpImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "SniperCross";

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

	public bool SniperCrossShow
	{
		get
		{
			if (_oSniperCross != null)
			{
				return _oSniperCross.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SniperCrossShow != value && _oSniperCross != null)
			{
				_oSniperCross.SetObjectActive(value);
			}
		}
	}

	public Sprite AwpSprite
	{
		get
		{
			if (_oAwpImage != null)
			{
				return _oAwpImage.sprite;
			}
			return null;
		}
		set
		{
			if (AwpSprite != value && _oAwpImage != null)
			{
				_oAwpImage.sprite = value;
			}
		}
	}

	public Image AwpImage
	{
		get
		{
			if (_oAwpImage != null)
			{
				return _oAwpImage;
			}
			return null;
		}
		set
		{
			if (AwpImage != value && _oAwpImage != null)
			{
				_oAwpImage = value;
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
			if (!(text == "SniperCross"))
			{
				if (text == "Awp")
				{
					_oAwp = transform.gameObject;
					_oAwpImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oSniperCross = transform.gameObject;
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
