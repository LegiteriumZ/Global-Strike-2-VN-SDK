using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Jump;

[GameUiTest]
public class JumpteamscoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBackImage;

	private Image _oBackImageImage;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oMilliseconds;

	private Text _oMillisecondsText;

	private GameObject _oPenaltyText;

	private Text _oPenaltyTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/jump";

	private string _resourceAssetName = "Jumpteamscore";

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

	public bool MinutesShow
	{
		get
		{
			if (_oMinutes != null)
			{
				return _oMinutes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MinutesShow != value && _oMinutes != null)
			{
				_oMinutes.SetObjectActive(value);
			}
		}
	}

	public string MinutesString
	{
		get
		{
			if (_oMinutesText != null)
			{
				return _oMinutesText.text;
			}
			return null;
		}
		set
		{
			if (MinutesString != value && _oMinutesText != null)
			{
				_oMinutesText.text = value;
			}
		}
	}

	public string SecondsString
	{
		get
		{
			if (_oSecondsText != null)
			{
				return _oSecondsText.text;
			}
			return null;
		}
		set
		{
			if (SecondsString != value && _oSecondsText != null)
			{
				_oSecondsText.text = value;
			}
		}
	}

	public string MillisecondsString
	{
		get
		{
			if (_oMillisecondsText != null)
			{
				return _oMillisecondsText.text;
			}
			return null;
		}
		set
		{
			if (MillisecondsString != value && _oMillisecondsText != null)
			{
				_oMillisecondsText.text = value;
			}
		}
	}

	public bool PenaltyTextShow
	{
		get
		{
			if (_oPenaltyText != null)
			{
				return _oPenaltyText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PenaltyTextShow != value && _oPenaltyText != null)
			{
				_oPenaltyText.SetObjectActive(value);
			}
		}
	}

	public string PenaltyTextString
	{
		get
		{
			if (_oPenaltyTextText != null)
			{
				return _oPenaltyTextText.text;
			}
			return null;
		}
		set
		{
			if (PenaltyTextString != value && _oPenaltyTextText != null)
			{
				_oPenaltyTextText.text = value;
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
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "Milliseconds":
				_oMilliseconds = transform.gameObject;
				_oMillisecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "PenaltyText":
				_oPenaltyText = transform.gameObject;
				_oPenaltyTextText = transform.gameObject.GetComponent<Text>();
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
