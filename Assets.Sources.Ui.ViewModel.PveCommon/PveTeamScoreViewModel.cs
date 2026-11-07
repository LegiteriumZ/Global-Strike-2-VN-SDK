using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.PveCommon;

[GameUiTest]
public class PveTeamScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPveTeamScore;

	private GameObject _oScore;

	private RectTransform _oScoreRectTransform;

	private RectTransform[] _oScoreCounters;

	private Text[] _oScoreCounterTexts;

	private GameObject _oBotCounter;

	private Text _oBotCounterText;

	private GameObject _oAllRoundCounter;

	private Text _oAllRoundCounterText;

	private GameObject _oCurRoundCounter;

	private Text _oCurRoundCounterText;

	private GameObject _oMinuteCounter;

	private Text _oMinuteCounterText;

	private GameObject _oSecondCounter;

	private Text _oSecondCounterText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/pvecommon";

	private string _resourceAssetName = "PveTeamScore";

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

	public bool PveTeamScoreShow
	{
		get
		{
			if (_oPveTeamScore != null)
			{
				return _oPveTeamScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PveTeamScoreShow != value && _oPveTeamScore != null)
			{
				_oPveTeamScore.SetObjectActive(value);
			}
		}
	}

	public Vector3 ScorePosition
	{
		get
		{
			if (_oScoreRectTransform != null)
			{
				return _oScoreRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ScorePosition != value && _oScoreRectTransform != null)
			{
				_oScoreRectTransform.localPosition = value;
			}
		}
	}

	public string BotCounterString
	{
		get
		{
			if (_oBotCounterText != null)
			{
				return _oBotCounterText.text;
			}
			return null;
		}
		set
		{
			if (BotCounterString != value && _oBotCounterText != null)
			{
				_oBotCounterText.text = value;
			}
		}
	}

	public string AllRoundCounterString
	{
		get
		{
			if (_oAllRoundCounterText != null)
			{
				return _oAllRoundCounterText.text;
			}
			return null;
		}
		set
		{
			if (AllRoundCounterString != value && _oAllRoundCounterText != null)
			{
				_oAllRoundCounterText.text = value;
			}
		}
	}

	public string CurRoundCounterString
	{
		get
		{
			if (_oCurRoundCounterText != null)
			{
				return _oCurRoundCounterText.text;
			}
			return null;
		}
		set
		{
			if (CurRoundCounterString != value && _oCurRoundCounterText != null)
			{
				_oCurRoundCounterText.text = value;
			}
		}
	}

	public string MinuteCounterString
	{
		get
		{
			if (_oMinuteCounterText != null)
			{
				return _oMinuteCounterText.text;
			}
			return null;
		}
		set
		{
			if (MinuteCounterString != value && _oMinuteCounterText != null)
			{
				_oMinuteCounterText.text = value;
			}
		}
	}

	public string SecondCounterString
	{
		get
		{
			if (_oSecondCounterText != null)
			{
				return _oSecondCounterText.text;
			}
			return null;
		}
		set
		{
			if (SecondCounterString != value && _oSecondCounterText != null)
			{
				_oSecondCounterText.text = value;
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
			case "PveTeamScore":
				_oPveTeamScore = transform.gameObject;
				break;
			case "Score":
				_oScore = transform.gameObject;
				_oScoreRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ScoreCounter":
				_oScoreCounters = transform.GetComponentsInChildren<RectTransform>();
				_oScoreCounterTexts = transform.GetComponentsInChildren<Text>();
				break;
			case "BotCounter":
				_oBotCounter = transform.gameObject;
				_oBotCounterText = transform.gameObject.GetComponent<Text>();
				break;
			case "AllRoundCounter":
				_oAllRoundCounter = transform.gameObject;
				_oAllRoundCounterText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurRoundCounter":
				_oCurRoundCounter = transform.gameObject;
				_oCurRoundCounterText = transform.gameObject.GetComponent<Text>();
				break;
			case "MinuteCounter":
				_oMinuteCounter = transform.gameObject;
				_oMinuteCounterText = transform.gameObject.GetComponent<Text>();
				break;
			case "SecondCounter":
				_oSecondCounter = transform.gameObject;
				_oSecondCounterText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}

	public void SetScoreCounterShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScoreCounters.Length == 7)
		{
			for (int i = 1; i < _oScoreCounters.Length; i++)
			{
				_oScoreCounters[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScoreCounterPosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScoreCounters.Length == 7)
		{
			for (int i = 0; i < _oScoreCounters.Length; i++)
			{
				_oScoreCounters[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScoreCounterTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScoreCounterTexts.Length == 2)
		{
			_oScoreCounterTexts[0].text = wholeStr;
			_oScoreCounterTexts[1].text = decimalStr;
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
			UnityEngine.Object.Destroy(_viewGameObject);
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
