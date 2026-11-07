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
public class PveAllKillInfoCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPlayerScore1;

	private GameObject _oPlayerScore2;

	private GameObject _oPlayerScore3;

	private GameObject _oPlayerScore4;

	private RectTransform _oPlayerScoreRectTransform1;

	private RectTransform _oPlayerScoreRectTransform2;

	private RectTransform _oPlayerScoreRectTransform3;

	private RectTransform _oPlayerScoreRectTransform4;

	private Text _oPlayerScoreText1;

	private Text _oPlayerScoreText2;

	private Text _oPlayerScoreText3;

	private Text _oPlayerScoreText4;

	private RectTransform[] _oScores;

	private Text[] _oScoreTexts;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/pvecommon";

	private string _resourceAssetName = "PveAllKillInfoCell";

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

	public Vector3 PlayerScorePosition1
	{
		get
		{
			if (_oPlayerScoreRectTransform1 != null)
			{
				return _oPlayerScoreRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PlayerScorePosition1 != value && _oPlayerScoreRectTransform1 != null)
			{
				_oPlayerScoreRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 PlayerScorePosition2
	{
		get
		{
			if (_oPlayerScoreRectTransform2 != null)
			{
				return _oPlayerScoreRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PlayerScorePosition2 != value && _oPlayerScoreRectTransform2 != null)
			{
				_oPlayerScoreRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 PlayerScorePosition3
	{
		get
		{
			if (_oPlayerScoreRectTransform3 != null)
			{
				return _oPlayerScoreRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PlayerScorePosition3 != value && _oPlayerScoreRectTransform3 != null)
			{
				_oPlayerScoreRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 PlayerScorePosition4
	{
		get
		{
			if (_oPlayerScoreRectTransform4 != null)
			{
				return _oPlayerScoreRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PlayerScorePosition4 != value && _oPlayerScoreRectTransform4 != null)
			{
				_oPlayerScoreRectTransform4.localPosition = value;
			}
		}
	}

	public string PlayerScoreString1
	{
		get
		{
			if (_oPlayerScoreText1 != null)
			{
				return _oPlayerScoreText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString1 != value && _oPlayerScoreText1 != null)
			{
				_oPlayerScoreText1.text = value;
			}
		}
	}

	public string PlayerScoreString2
	{
		get
		{
			if (_oPlayerScoreText2 != null)
			{
				return _oPlayerScoreText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString2 != value && _oPlayerScoreText2 != null)
			{
				_oPlayerScoreText2.text = value;
			}
		}
	}

	public string PlayerScoreString3
	{
		get
		{
			if (_oPlayerScoreText3 != null)
			{
				return _oPlayerScoreText3.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString3 != value && _oPlayerScoreText3 != null)
			{
				_oPlayerScoreText3.text = value;
			}
		}
	}

	public string PlayerScoreString4
	{
		get
		{
			if (_oPlayerScoreText4 != null)
			{
				return _oPlayerScoreText4.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString4 != value && _oPlayerScoreText4 != null)
			{
				_oPlayerScoreText4.text = value;
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
			case "PlayerScore1":
				_oPlayerScore1 = transform.gameObject;
				_oPlayerScoreRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore2":
				_oPlayerScore2 = transform.gameObject;
				_oPlayerScoreRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore3":
				_oPlayerScore3 = transform.gameObject;
				_oPlayerScoreRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerScoreText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore4":
				_oPlayerScore4 = transform.gameObject;
				_oPlayerScoreRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerScoreText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score":
				_oScores = transform.GetComponentsInChildren<RectTransform>();
				_oScoreTexts = transform.GetComponentsInChildren<Text>();
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

	public Vector3 GetPlayerScorePosition(int index)
	{
		return index switch
		{
			1 => PlayerScorePosition1, 
			2 => PlayerScorePosition2, 
			3 => PlayerScorePosition3, 
			4 => PlayerScorePosition4, 
			_ => Vector3.zero, 
		};
	}

	public void SetPlayerScorePosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			PlayerScorePosition1 = value;
			break;
		case 2:
			PlayerScorePosition2 = value;
			break;
		case 3:
			PlayerScorePosition3 = value;
			break;
		case 4:
			PlayerScorePosition4 = value;
			break;
		}
	}

	public int GetPlayerScoreCount()
	{
		return 4;
	}

	public string GetPlayerScoreString(int index)
	{
		return index switch
		{
			1 => PlayerScoreString1, 
			2 => PlayerScoreString2, 
			3 => PlayerScoreString3, 
			4 => PlayerScoreString4, 
			_ => null, 
		};
	}

	public void SetPlayerScoreString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerScoreString1 = value;
			break;
		case 2:
			PlayerScoreString2 = value;
			break;
		case 3:
			PlayerScoreString3 = value;
			break;
		case 4:
			PlayerScoreString4 = value;
			break;
		}
	}

	public void SetScoreShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScores.Length == 7)
		{
			for (int i = 1; i < _oScores.Length; i++)
			{
				_oScores[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScorePosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScores.Length == 7)
		{
			for (int i = 0; i < _oScores.Length; i++)
			{
				_oScores[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScoreTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScoreTexts.Length == 2)
		{
			_oScoreTexts[0].text = wholeStr;
			_oScoreTexts[1].text = decimalStr;
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
