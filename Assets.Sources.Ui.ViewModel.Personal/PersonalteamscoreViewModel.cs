using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Personal;

[GameUiTest]
public class PersonalteamscoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oScoreText;

	private Text _oScoreTextText;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oAceText;

	private Text _oAceTextText;

	private GameObject _oConditionText;

	private Text _oConditionTextText;

	private GameObject _oConditionType;

	private Image _oConditionTypeImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/personal";

	private string _resourceAssetName = "Personalteamscore";

	public string ScoreTextString
	{
		get
		{
			if (_oScoreTextText != null)
			{
				return _oScoreTextText.text;
			}
			return null;
		}
		set
		{
			if (ScoreTextString != value && _oScoreTextText != null)
			{
				_oScoreTextText.text = value;
			}
		}
	}

	public string RankTextString
	{
		get
		{
			if (_oRankTextText != null)
			{
				return _oRankTextText.text;
			}
			return null;
		}
		set
		{
			if (RankTextString != value && _oRankTextText != null)
			{
				_oRankTextText.text = value;
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

	public string AceTextString
	{
		get
		{
			if (_oAceTextText != null)
			{
				return _oAceTextText.text;
			}
			return null;
		}
		set
		{
			if (AceTextString != value && _oAceTextText != null)
			{
				_oAceTextText.text = value;
			}
		}
	}

	public string ConditionTextString
	{
		get
		{
			if (_oConditionTextText != null)
			{
				return _oConditionTextText.text;
			}
			return null;
		}
		set
		{
			if (ConditionTextString != value && _oConditionTextText != null)
			{
				_oConditionTextText.text = value;
			}
		}
	}

	public Sprite ConditionTypeSprite
	{
		get
		{
			if (_oConditionTypeImage != null)
			{
				return _oConditionTypeImage.sprite;
			}
			return null;
		}
		set
		{
			if (ConditionTypeSprite != value && _oConditionTypeImage != null)
			{
				_oConditionTypeImage.sprite = value;
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
			case "ScoreText":
				_oScoreText = transform.gameObject;
				_oScoreTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "RankText":
				_oRankText = transform.gameObject;
				_oRankTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "AceText":
				_oAceText = transform.gameObject;
				_oAceTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ConditionText":
				_oConditionText = transform.gameObject;
				_oConditionTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ConditionType":
				_oConditionType = transform.gameObject;
				_oConditionTypeImage = transform.gameObject.GetComponent<Image>();
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
