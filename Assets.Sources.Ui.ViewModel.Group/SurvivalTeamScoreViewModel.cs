using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Group;

[GameUiTest]
public class SurvivalTeamScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSurvivalTeamScore;

	private GameObject _oWinCondition;

	private Text _oWinConditionText;

	private GameObject _oTeamScore1;

	private GameObject _oTeamScore2;

	private Text _oTeamScoreText1;

	private Text _oTeamScoreText2;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/group";

	private string _resourceAssetName = "SurvivalTeamScore";

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

	public bool SurvivalTeamScoreShow
	{
		get
		{
			if (_oSurvivalTeamScore != null)
			{
				return _oSurvivalTeamScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SurvivalTeamScoreShow != value && _oSurvivalTeamScore != null)
			{
				_oSurvivalTeamScore.SetObjectActive(value);
			}
		}
	}

	public string WinConditionString
	{
		get
		{
			if (_oWinConditionText != null)
			{
				return _oWinConditionText.text;
			}
			return null;
		}
		set
		{
			if (WinConditionString != value && _oWinConditionText != null)
			{
				_oWinConditionText.text = value;
			}
		}
	}

	public string TeamScoreString1
	{
		get
		{
			if (_oTeamScoreText1 != null)
			{
				return _oTeamScoreText1.text;
			}
			return null;
		}
		set
		{
			if (TeamScoreString1 != value && _oTeamScoreText1 != null)
			{
				_oTeamScoreText1.text = value;
			}
		}
	}

	public string TeamScoreString2
	{
		get
		{
			if (_oTeamScoreText2 != null)
			{
				return _oTeamScoreText2.text;
			}
			return null;
		}
		set
		{
			if (TeamScoreString2 != value && _oTeamScoreText2 != null)
			{
				_oTeamScoreText2.text = value;
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
			case "SurvivalTeamScore":
				_oSurvivalTeamScore = transform.gameObject;
				break;
			case "WinCondition":
				_oWinCondition = transform.gameObject;
				_oWinConditionText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamScore1":
				_oTeamScore1 = transform.gameObject;
				_oTeamScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamScore2":
				_oTeamScore2 = transform.gameObject;
				_oTeamScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public string GetTeamScoreString(int index)
	{
		return index switch
		{
			1 => TeamScoreString1, 
			2 => TeamScoreString2, 
			_ => null, 
		};
	}

	public void SetTeamScoreString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TeamScoreString1 = value;
			break;
		case 2:
			TeamScoreString2 = value;
			break;
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
