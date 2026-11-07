using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class PotentialViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _oBackImage;

	private Image _oBackImageImage;

	private GameObject _oKillCount;

	private Text _oKillCountText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Potential";

	public bool RightBottomShow
	{
		get
		{
			if (_oRightBottom != null)
			{
				return _oRightBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightBottomShow != value && _oRightBottom != null)
			{
				_oRightBottom.SetObjectActive(value);
			}
		}
	}

	public Sprite BackImageSprite
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite != value && _oBackImageImage != null)
			{
				_oBackImageImage.sprite = value;
			}
		}
	}

	public string KillCountString
	{
		get
		{
			if (_oKillCountText != null)
			{
				return _oKillCountText.text;
			}
			return null;
		}
		set
		{
			if (KillCountString != value && _oKillCountText != null)
			{
				_oKillCountText.text = value;
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
			case "RightBottom":
				_oRightBottom = transform.gameObject;
				break;
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCount":
				_oKillCount = transform.gameObject;
				_oKillCountText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void BackImageNtvsize()
	{
		if (_oBackImageImage != null)
		{
			_oBackImageImage.SetNativeSize();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
