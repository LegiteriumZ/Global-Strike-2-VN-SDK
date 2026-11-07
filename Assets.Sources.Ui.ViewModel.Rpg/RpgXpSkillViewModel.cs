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
public class RpgXpSkillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBlue;

	private Image _oBlueImage;

	private GameObject _oWhite;

	private Image _oWhiteImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgXpSkill";

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public bool BlueShow
	{
		get
		{
			if (_oBlue != null)
			{
				return _oBlue.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BlueShow != value && _oBlue != null)
			{
				_oBlue.SetObjectActive(value);
			}
		}
	}

	public Color BlueColor
	{
		get
		{
			if (_oBlueImage != null)
			{
				return _oBlueImage.color;
			}
			return Color.white;
		}
		set
		{
			if (BlueColor != value && _oBlueImage != null)
			{
				_oBlueImage.color = value;
			}
		}
	}

	public bool WhiteShow
	{
		get
		{
			if (_oWhite != null)
			{
				return _oWhite.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WhiteShow != value && _oWhite != null)
			{
				_oWhite.SetObjectActive(value);
			}
		}
	}

	public Color WhiteColor
	{
		get
		{
			if (_oWhiteImage != null)
			{
				return _oWhiteImage.color;
			}
			return Color.white;
		}
		set
		{
			if (WhiteColor != value && _oWhiteImage != null)
			{
				_oWhiteImage.color = value;
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
				break;
			case "Blue":
				_oBlue = transform.gameObject;
				_oBlueImage = transform.gameObject.GetComponent<Image>();
				break;
			case "White":
				_oWhite = transform.gameObject;
				_oWhiteImage = transform.gameObject.GetComponent<Image>();
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
