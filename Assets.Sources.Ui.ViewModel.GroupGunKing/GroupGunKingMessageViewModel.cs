using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GroupGunKing;

[GameUiTest]
public class GroupGunKingMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oTop;

	private GameObject _oMessage;

	private GameObject _oPhase0;

	private GameObject _oPhase1;

	private GameObject _oPhase2;

	private GameObject _oPhase3;

	private GameObject _oPhase4;

	private GameObject _oPhase5;

	private GameObject _oPhaseEnd;

	private GameObject _oPhaseScore;

	private Text _oPhaseScoreText;

	private GameObject _oTWinScore;

	private Text _oTWinScoreText;

	private GameObject _oCtWinScore;

	private Text _oCtWinScoreText;

	private GameObject _oTLoseScore;

	private Text _oTLoseScoreText;

	private GameObject _oCtLoseScore;

	private Text _oCtLoseScoreText;

	private GameObject _oWinTeam;

	private Image _oWinTeamImage;

	private GameObject _oNextPhase;

	private Image _oNextPhaseImage;

	private GameObject _oCenter;

	private GameObject _oStartGame;

	private Image _oStartGameImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/groupgunking";

	private string _resourceAssetName = "GroupGunKingMessage";

	public bool TopShow
	{
		get
		{
			if (_oTop != null)
			{
				return _oTop.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TopShow != value && _oTop != null)
			{
				_oTop.SetObjectActive(value);
			}
		}
	}

	public bool MessageShow
	{
		get
		{
			if (_oMessage != null)
			{
				return _oMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow != value && _oMessage != null)
			{
				_oMessage.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow0
	{
		get
		{
			if (_oPhase0 != null)
			{
				return _oPhase0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow0 != value && _oPhase0 != null)
			{
				_oPhase0.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow1
	{
		get
		{
			if (_oPhase1 != null)
			{
				return _oPhase1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow1 != value && _oPhase1 != null)
			{
				_oPhase1.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow2
	{
		get
		{
			if (_oPhase2 != null)
			{
				return _oPhase2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow2 != value && _oPhase2 != null)
			{
				_oPhase2.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow3
	{
		get
		{
			if (_oPhase3 != null)
			{
				return _oPhase3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow3 != value && _oPhase3 != null)
			{
				_oPhase3.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow4
	{
		get
		{
			if (_oPhase4 != null)
			{
				return _oPhase4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow4 != value && _oPhase4 != null)
			{
				_oPhase4.SetObjectActive(value);
			}
		}
	}

	public bool PhaseShow5
	{
		get
		{
			if (_oPhase5 != null)
			{
				return _oPhase5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseShow5 != value && _oPhase5 != null)
			{
				_oPhase5.SetObjectActive(value);
			}
		}
	}

	public bool PhaseEndShow
	{
		get
		{
			if (_oPhaseEnd != null)
			{
				return _oPhaseEnd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PhaseEndShow != value && _oPhaseEnd != null)
			{
				_oPhaseEnd.SetObjectActive(value);
			}
		}
	}

	public string PhaseScoreString
	{
		get
		{
			if (_oPhaseScoreText != null)
			{
				return _oPhaseScoreText.text;
			}
			return null;
		}
		set
		{
			if (PhaseScoreString != value && _oPhaseScoreText != null)
			{
				_oPhaseScoreText.text = value;
			}
		}
	}

	public bool TWinScoreShow
	{
		get
		{
			if (_oTWinScore != null)
			{
				return _oTWinScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TWinScoreShow != value && _oTWinScore != null)
			{
				_oTWinScore.SetObjectActive(value);
			}
		}
	}

	public string TWinScoreString
	{
		get
		{
			if (_oTWinScoreText != null)
			{
				return _oTWinScoreText.text;
			}
			return null;
		}
		set
		{
			if (TWinScoreString != value && _oTWinScoreText != null)
			{
				_oTWinScoreText.text = value;
			}
		}
	}

	public bool CtWinScoreShow
	{
		get
		{
			if (_oCtWinScore != null)
			{
				return _oCtWinScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtWinScoreShow != value && _oCtWinScore != null)
			{
				_oCtWinScore.SetObjectActive(value);
			}
		}
	}

	public string CtWinScoreString
	{
		get
		{
			if (_oCtWinScoreText != null)
			{
				return _oCtWinScoreText.text;
			}
			return null;
		}
		set
		{
			if (CtWinScoreString != value && _oCtWinScoreText != null)
			{
				_oCtWinScoreText.text = value;
			}
		}
	}

	public bool TLoseScoreShow
	{
		get
		{
			if (_oTLoseScore != null)
			{
				return _oTLoseScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TLoseScoreShow != value && _oTLoseScore != null)
			{
				_oTLoseScore.SetObjectActive(value);
			}
		}
	}

	public string TLoseScoreString
	{
		get
		{
			if (_oTLoseScoreText != null)
			{
				return _oTLoseScoreText.text;
			}
			return null;
		}
		set
		{
			if (TLoseScoreString != value && _oTLoseScoreText != null)
			{
				_oTLoseScoreText.text = value;
			}
		}
	}

	public bool CtLoseScoreShow
	{
		get
		{
			if (_oCtLoseScore != null)
			{
				return _oCtLoseScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLoseScoreShow != value && _oCtLoseScore != null)
			{
				_oCtLoseScore.SetObjectActive(value);
			}
		}
	}

	public string CtLoseScoreString
	{
		get
		{
			if (_oCtLoseScoreText != null)
			{
				return _oCtLoseScoreText.text;
			}
			return null;
		}
		set
		{
			if (CtLoseScoreString != value && _oCtLoseScoreText != null)
			{
				_oCtLoseScoreText.text = value;
			}
		}
	}

	public Sprite WinTeamSprite
	{
		get
		{
			if (_oWinTeamImage != null)
			{
				return _oWinTeamImage.sprite;
			}
			return null;
		}
		set
		{
			if (WinTeamSprite != value && _oWinTeamImage != null)
			{
				_oWinTeamImage.sprite = value;
			}
		}
	}

	public Sprite NextPhaseSprite
	{
		get
		{
			if (_oNextPhaseImage != null)
			{
				return _oNextPhaseImage.sprite;
			}
			return null;
		}
		set
		{
			if (NextPhaseSprite != value && _oNextPhaseImage != null)
			{
				_oNextPhaseImage.sprite = value;
			}
		}
	}

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public bool StartGameShow
	{
		get
		{
			if (_oStartGame != null)
			{
				return _oStartGame.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StartGameShow != value && _oStartGame != null)
			{
				_oStartGame.SetObjectActive(value);
			}
		}
	}

	public Sprite StartGameSprite
	{
		get
		{
			if (_oStartGameImage != null)
			{
				return _oStartGameImage.sprite;
			}
			return null;
		}
		set
		{
			if (StartGameSprite != value && _oStartGameImage != null)
			{
				_oStartGameImage.sprite = value;
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
			case "Top":
				_oTop = transform.gameObject;
				break;
			case "Message":
				_oMessage = transform.gameObject;
				break;
			case "Phase0":
				_oPhase0 = transform.gameObject;
				break;
			case "Phase1":
				_oPhase1 = transform.gameObject;
				break;
			case "Phase2":
				_oPhase2 = transform.gameObject;
				break;
			case "Phase3":
				_oPhase3 = transform.gameObject;
				break;
			case "Phase4":
				_oPhase4 = transform.gameObject;
				break;
			case "Phase5":
				_oPhase5 = transform.gameObject;
				break;
			case "PhaseEnd":
				_oPhaseEnd = transform.gameObject;
				break;
			case "PhaseScore":
				_oPhaseScore = transform.gameObject;
				_oPhaseScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "TWinScore":
				_oTWinScore = transform.gameObject;
				_oTWinScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "CtWinScore":
				_oCtWinScore = transform.gameObject;
				_oCtWinScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "TLoseScore":
				_oTLoseScore = transform.gameObject;
				_oTLoseScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "CtLoseScore":
				_oCtLoseScore = transform.gameObject;
				_oCtLoseScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "WinTeam":
				_oWinTeam = transform.gameObject;
				_oWinTeamImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NextPhase":
				_oNextPhase = transform.gameObject;
				_oNextPhaseImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "StartGame":
				_oStartGame = transform.gameObject;
				_oStartGameImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetPhaseShow(int index)
	{
		return index switch
		{
			0 => PhaseShow0, 
			1 => PhaseShow1, 
			2 => PhaseShow2, 
			3 => PhaseShow3, 
			4 => PhaseShow4, 
			5 => PhaseShow5, 
			_ => false, 
		};
	}

	public void SetPhaseShow(int index, bool value)
	{
		switch (index)
		{
		case 0:
			PhaseShow0 = value;
			break;
		case 1:
			PhaseShow1 = value;
			break;
		case 2:
			PhaseShow2 = value;
			break;
		case 3:
			PhaseShow3 = value;
			break;
		case 4:
			PhaseShow4 = value;
			break;
		case 5:
			PhaseShow5 = value;
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
