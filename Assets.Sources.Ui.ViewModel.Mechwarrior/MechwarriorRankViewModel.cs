using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Mechwarrior;

[GameUiTest]
public class MechwarriorRankViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oPlayer1;

	private GameObject _oPlayer2;

	private Text _oPlayerText1;

	private Text _oPlayerText2;

	private GameObject _oScore1;

	private GameObject _oScore2;

	private Text _oScoreText1;

	private Text _oScoreText2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorRank";

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow1
	{
		get
		{
			if (_oPlayer1 != null)
			{
				return _oPlayer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow1 != value && _oPlayer1 != null)
			{
				_oPlayer1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow2
	{
		get
		{
			if (_oPlayer2 != null)
			{
				return _oPlayer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow2 != value && _oPlayer2 != null)
			{
				_oPlayer2.SetObjectActive(value);
			}
		}
	}

	public string PlayerString1
	{
		get
		{
			if (_oPlayerText1 != null)
			{
				return _oPlayerText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerString1 != value && _oPlayerText1 != null)
			{
				_oPlayerText1.text = value;
			}
		}
	}

	public string PlayerString2
	{
		get
		{
			if (_oPlayerText2 != null)
			{
				return _oPlayerText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerString2 != value && _oPlayerText2 != null)
			{
				_oPlayerText2.text = value;
			}
		}
	}

	public string ScoreString1
	{
		get
		{
			if (_oScoreText1 != null)
			{
				return _oScoreText1.text;
			}
			return null;
		}
		set
		{
			if (ScoreString1 != value && _oScoreText1 != null)
			{
				_oScoreText1.text = value;
			}
		}
	}

	public string ScoreString2
	{
		get
		{
			if (_oScoreText2 != null)
			{
				return _oScoreText2.text;
			}
			return null;
		}
		set
		{
			if (ScoreString2 != value && _oScoreText2 != null)
			{
				_oScoreText2.text = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "Player1":
				_oPlayer1 = transform.gameObject;
				_oPlayerText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Player2":
				_oPlayer2 = transform.gameObject;
				_oPlayerText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score1":
				_oScore1 = transform.gameObject;
				_oScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score2":
				_oScore2 = transform.gameObject;
				_oScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetPlayerShow(int index)
	{
		return index switch
		{
			1 => PlayerShow1, 
			2 => PlayerShow2, 
			_ => false, 
		};
	}

	public void SetPlayerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerShow1 = value;
			break;
		case 2:
			PlayerShow2 = value;
			break;
		}
	}

	public string GetPlayerString(int index)
	{
		return index switch
		{
			1 => PlayerString1, 
			2 => PlayerString2, 
			_ => null, 
		};
	}

	public void SetPlayerString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerString1 = value;
			break;
		case 2:
			PlayerString2 = value;
			break;
		}
	}

	public string GetScoreString(int index)
	{
		return index switch
		{
			1 => ScoreString1, 
			2 => ScoreString2, 
			_ => null, 
		};
	}

	public void SetScoreString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ScoreString1 = value;
			break;
		case 2:
			ScoreString2 = value;
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
