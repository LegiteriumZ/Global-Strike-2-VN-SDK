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

namespace Assets.Sources.Ui.ViewModel.UltimateChallenge;

[GameUiTest]
public class SelfExtremewipeoutScoreCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSelfExtremewipeoutScoreCell;

	private RectTransform _oSelfExtremewipeoutScoreCellRectTransform;

	private GameObject _orankNum;

	private Text _orankNumText;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerHurt;

	private Text _oPlayerHurtText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _oPlayerScore1;

	private GameObject _oPlayerScore2;

	private GameObject _oPlayerScore3;

	private Text _oPlayerScoreText1;

	private Text _oPlayerScoreText2;

	private Text _oPlayerScoreText3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge";

	private string _resourceAssetName = "SelfExtremewipeoutScoreCell";

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

	public Vector3 SelfExtremewipeoutScoreCellPosition
	{
		get
		{
			if (_oSelfExtremewipeoutScoreCellRectTransform != null)
			{
				return _oSelfExtremewipeoutScoreCellRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SelfExtremewipeoutScoreCellPosition != value && _oSelfExtremewipeoutScoreCellRectTransform != null)
			{
				_oSelfExtremewipeoutScoreCellRectTransform.localPosition = value;
			}
		}
	}

	public string rankNumString
	{
		get
		{
			if (_orankNumText != null)
			{
				return _orankNumText.text;
			}
			return null;
		}
		set
		{
			if (rankNumString != value && _orankNumText != null)
			{
				_orankNumText.text = value;
			}
		}
	}

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
			}
		}
	}

	public string PlayerHurtString
	{
		get
		{
			if (_oPlayerHurtText != null)
			{
				return _oPlayerHurtText.text;
			}
			return null;
		}
		set
		{
			if (PlayerHurtString != value && _oPlayerHurtText != null)
			{
				_oPlayerHurtText.text = value;
			}
		}
	}

	public string PlayerPingString
	{
		get
		{
			if (_oPlayerPingText != null)
			{
				return _oPlayerPingText.text;
			}
			return null;
		}
		set
		{
			if (PlayerPingString != value && _oPlayerPingText != null)
			{
				_oPlayerPingText.text = value;
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
			case "SelfExtremewipeoutScoreCell":
				_oSelfExtremewipeoutScoreCell = transform.gameObject;
				_oSelfExtremewipeoutScoreCellRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "rankNum":
				_orankNum = transform.gameObject;
				_orankNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerHurt":
				_oPlayerHurt = transform.gameObject;
				_oPlayerHurtText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore1":
				_oPlayerScore1 = transform.gameObject;
				_oPlayerScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore2":
				_oPlayerScore2 = transform.gameObject;
				_oPlayerScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore3":
				_oPlayerScore3 = transform.gameObject;
				_oPlayerScoreText3 = transform.gameObject.GetComponent<Text>();
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

	public string GetPlayerScoreString(int index)
	{
		return index switch
		{
			1 => PlayerScoreString1, 
			2 => PlayerScoreString2, 
			3 => PlayerScoreString3, 
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
