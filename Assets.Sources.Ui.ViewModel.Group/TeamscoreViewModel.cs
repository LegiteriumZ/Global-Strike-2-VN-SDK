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

namespace Assets.Sources.Ui.ViewModel.Group;

[GameUiTest]
public class TeamscoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBackboard;

	private Image _oBackboardImage;

	private GameObject _oWinCondition;

	private Text _oWinConditionText;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oTeamScore1;

	private GameObject _oTeamScore2;

	private Text _oTeamScoreText1;

	private Text _oTeamScoreText2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/group";

	private string _resourceAssetName = "Teamscore";

	private List<RectTransform> _holdPosTrans;

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

	public Sprite BackboardSprite
	{
		get
		{
			if (_oBackboardImage != null)
			{
				return _oBackboardImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackboardSprite != value && _oBackboardImage != null)
			{
				_oBackboardImage.sprite = value;
			}
		}
	}

	public Image BackboardImage
	{
		get
		{
			if (_oBackboardImage != null)
			{
				return _oBackboardImage;
			}
			return null;
		}
		set
		{
			if (BackboardImage != value && _oBackboardImage != null)
			{
				_oBackboardImage = value;
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
			case "Backboard":
				_oBackboard = transform.gameObject;
				_oBackboardImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WinCondition":
				_oWinCondition = transform.gameObject;
				_oWinConditionText = transform.gameObject.GetComponent<Text>();
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamScore1":
				_oTeamScore1 = transform.gameObject;
				_oTeamScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamScore2":
				_oTeamScore2 = transform.gameObject;
				_oTeamScoreText2 = transform.gameObject.GetComponent<Text>();
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

	public int GetTeamScoreCount()
	{
		return 2;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oWinConditionText != null)
		{
			_holdPosTrans.Add(_oWinConditionText.GetComponent<RectTransform>());
		}
		if (_oMinutesText != null)
		{
			_holdPosTrans.Add(_oMinutesText.GetComponent<RectTransform>());
		}
		if (_oSecondsText != null)
		{
			_holdPosTrans.Add(_oSecondsText.GetComponent<RectTransform>());
		}
		if (_oTeamScoreText1 != null)
		{
			_holdPosTrans.Add(_oTeamScoreText1.GetComponent<RectTransform>());
		}
		if (_oTeamScoreText2 != null)
		{
			_holdPosTrans.Add(_oTeamScoreText2.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
