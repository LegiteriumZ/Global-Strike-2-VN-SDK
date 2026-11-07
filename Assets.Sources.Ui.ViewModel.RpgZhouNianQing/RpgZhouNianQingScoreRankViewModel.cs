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

namespace Assets.Sources.Ui.ViewModel.RpgZhouNianQing;

[GameUiTest]
public class RpgZhouNianQingScoreRankViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oPlayerName1;

	private GameObject _oPlayerName2;

	private GameObject _oPlayerName3;

	private GameObject _oPlayerName4;

	private GameObject _oPlayerName5;

	private GameObject _oPlayerName6;

	private GameObject _oPlayerName7;

	private GameObject _oPlayerName8;

	private GameObject _oPlayerName9;

	private GameObject _oPlayerName10;

	private Text _oPlayerNameText1;

	private Text _oPlayerNameText2;

	private Text _oPlayerNameText3;

	private Text _oPlayerNameText4;

	private Text _oPlayerNameText5;

	private Text _oPlayerNameText6;

	private Text _oPlayerNameText7;

	private Text _oPlayerNameText8;

	private Text _oPlayerNameText9;

	private Text _oPlayerNameText10;

	private GameObject _oScore1;

	private GameObject _oScore2;

	private GameObject _oScore3;

	private GameObject _oScore4;

	private GameObject _oScore5;

	private GameObject _oScore6;

	private GameObject _oScore7;

	private GameObject _oScore8;

	private GameObject _oScore9;

	private GameObject _oScore10;

	private Text _oScoreText1;

	private Text _oScoreText2;

	private Text _oScoreText3;

	private Text _oScoreText4;

	private Text _oScoreText5;

	private Text _oScoreText6;

	private Text _oScoreText7;

	private Text _oScoreText8;

	private Text _oScoreText9;

	private Text _oScoreText10;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgzhounianqing";

	private string _resourceAssetName = "RpgZhouNianQingScoreRank";

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

	public bool PlayerNameShow1
	{
		get
		{
			if (_oPlayerName1 != null)
			{
				return _oPlayerName1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow1 != value && _oPlayerName1 != null)
			{
				_oPlayerName1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow2
	{
		get
		{
			if (_oPlayerName2 != null)
			{
				return _oPlayerName2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow2 != value && _oPlayerName2 != null)
			{
				_oPlayerName2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow3
	{
		get
		{
			if (_oPlayerName3 != null)
			{
				return _oPlayerName3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow3 != value && _oPlayerName3 != null)
			{
				_oPlayerName3.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow4
	{
		get
		{
			if (_oPlayerName4 != null)
			{
				return _oPlayerName4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow4 != value && _oPlayerName4 != null)
			{
				_oPlayerName4.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow5
	{
		get
		{
			if (_oPlayerName5 != null)
			{
				return _oPlayerName5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow5 != value && _oPlayerName5 != null)
			{
				_oPlayerName5.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow6
	{
		get
		{
			if (_oPlayerName6 != null)
			{
				return _oPlayerName6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow6 != value && _oPlayerName6 != null)
			{
				_oPlayerName6.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow7
	{
		get
		{
			if (_oPlayerName7 != null)
			{
				return _oPlayerName7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow7 != value && _oPlayerName7 != null)
			{
				_oPlayerName7.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow8
	{
		get
		{
			if (_oPlayerName8 != null)
			{
				return _oPlayerName8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow8 != value && _oPlayerName8 != null)
			{
				_oPlayerName8.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow9
	{
		get
		{
			if (_oPlayerName9 != null)
			{
				return _oPlayerName9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow9 != value && _oPlayerName9 != null)
			{
				_oPlayerName9.SetObjectActive(value);
			}
		}
	}

	public bool PlayerNameShow10
	{
		get
		{
			if (_oPlayerName10 != null)
			{
				return _oPlayerName10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow10 != value && _oPlayerName10 != null)
			{
				_oPlayerName10.SetObjectActive(value);
			}
		}
	}

	public string PlayerNameString1
	{
		get
		{
			if (_oPlayerNameText1 != null)
			{
				return _oPlayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString1 != value && _oPlayerNameText1 != null)
			{
				_oPlayerNameText1.text = value;
			}
		}
	}

	public string PlayerNameString2
	{
		get
		{
			if (_oPlayerNameText2 != null)
			{
				return _oPlayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString2 != value && _oPlayerNameText2 != null)
			{
				_oPlayerNameText2.text = value;
			}
		}
	}

	public string PlayerNameString3
	{
		get
		{
			if (_oPlayerNameText3 != null)
			{
				return _oPlayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString3 != value && _oPlayerNameText3 != null)
			{
				_oPlayerNameText3.text = value;
			}
		}
	}

	public string PlayerNameString4
	{
		get
		{
			if (_oPlayerNameText4 != null)
			{
				return _oPlayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString4 != value && _oPlayerNameText4 != null)
			{
				_oPlayerNameText4.text = value;
			}
		}
	}

	public string PlayerNameString5
	{
		get
		{
			if (_oPlayerNameText5 != null)
			{
				return _oPlayerNameText5.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString5 != value && _oPlayerNameText5 != null)
			{
				_oPlayerNameText5.text = value;
			}
		}
	}

	public string PlayerNameString6
	{
		get
		{
			if (_oPlayerNameText6 != null)
			{
				return _oPlayerNameText6.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString6 != value && _oPlayerNameText6 != null)
			{
				_oPlayerNameText6.text = value;
			}
		}
	}

	public string PlayerNameString7
	{
		get
		{
			if (_oPlayerNameText7 != null)
			{
				return _oPlayerNameText7.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString7 != value && _oPlayerNameText7 != null)
			{
				_oPlayerNameText7.text = value;
			}
		}
	}

	public string PlayerNameString8
	{
		get
		{
			if (_oPlayerNameText8 != null)
			{
				return _oPlayerNameText8.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString8 != value && _oPlayerNameText8 != null)
			{
				_oPlayerNameText8.text = value;
			}
		}
	}

	public string PlayerNameString9
	{
		get
		{
			if (_oPlayerNameText9 != null)
			{
				return _oPlayerNameText9.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString9 != value && _oPlayerNameText9 != null)
			{
				_oPlayerNameText9.text = value;
			}
		}
	}

	public string PlayerNameString10
	{
		get
		{
			if (_oPlayerNameText10 != null)
			{
				return _oPlayerNameText10.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString10 != value && _oPlayerNameText10 != null)
			{
				_oPlayerNameText10.text = value;
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

	public string ScoreString3
	{
		get
		{
			if (_oScoreText3 != null)
			{
				return _oScoreText3.text;
			}
			return null;
		}
		set
		{
			if (ScoreString3 != value && _oScoreText3 != null)
			{
				_oScoreText3.text = value;
			}
		}
	}

	public string ScoreString4
	{
		get
		{
			if (_oScoreText4 != null)
			{
				return _oScoreText4.text;
			}
			return null;
		}
		set
		{
			if (ScoreString4 != value && _oScoreText4 != null)
			{
				_oScoreText4.text = value;
			}
		}
	}

	public string ScoreString5
	{
		get
		{
			if (_oScoreText5 != null)
			{
				return _oScoreText5.text;
			}
			return null;
		}
		set
		{
			if (ScoreString5 != value && _oScoreText5 != null)
			{
				_oScoreText5.text = value;
			}
		}
	}

	public string ScoreString6
	{
		get
		{
			if (_oScoreText6 != null)
			{
				return _oScoreText6.text;
			}
			return null;
		}
		set
		{
			if (ScoreString6 != value && _oScoreText6 != null)
			{
				_oScoreText6.text = value;
			}
		}
	}

	public string ScoreString7
	{
		get
		{
			if (_oScoreText7 != null)
			{
				return _oScoreText7.text;
			}
			return null;
		}
		set
		{
			if (ScoreString7 != value && _oScoreText7 != null)
			{
				_oScoreText7.text = value;
			}
		}
	}

	public string ScoreString8
	{
		get
		{
			if (_oScoreText8 != null)
			{
				return _oScoreText8.text;
			}
			return null;
		}
		set
		{
			if (ScoreString8 != value && _oScoreText8 != null)
			{
				_oScoreText8.text = value;
			}
		}
	}

	public string ScoreString9
	{
		get
		{
			if (_oScoreText9 != null)
			{
				return _oScoreText9.text;
			}
			return null;
		}
		set
		{
			if (ScoreString9 != value && _oScoreText9 != null)
			{
				_oScoreText9.text = value;
			}
		}
	}

	public string ScoreString10
	{
		get
		{
			if (_oScoreText10 != null)
			{
				return _oScoreText10.text;
			}
			return null;
		}
		set
		{
			if (ScoreString10 != value && _oScoreText10 != null)
			{
				_oScoreText10.text = value;
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
			case "PlayerName1":
				_oPlayerName1 = transform.gameObject;
				_oPlayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName2":
				_oPlayerName2 = transform.gameObject;
				_oPlayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName3":
				_oPlayerName3 = transform.gameObject;
				_oPlayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName4":
				_oPlayerName4 = transform.gameObject;
				_oPlayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName5":
				_oPlayerName5 = transform.gameObject;
				_oPlayerNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName6":
				_oPlayerName6 = transform.gameObject;
				_oPlayerNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName7":
				_oPlayerName7 = transform.gameObject;
				_oPlayerNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName8":
				_oPlayerName8 = transform.gameObject;
				_oPlayerNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName9":
				_oPlayerName9 = transform.gameObject;
				_oPlayerNameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName10":
				_oPlayerName10 = transform.gameObject;
				_oPlayerNameText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score1":
				_oScore1 = transform.gameObject;
				_oScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score2":
				_oScore2 = transform.gameObject;
				_oScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score3":
				_oScore3 = transform.gameObject;
				_oScoreText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score4":
				_oScore4 = transform.gameObject;
				_oScoreText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score5":
				_oScore5 = transform.gameObject;
				_oScoreText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score6":
				_oScore6 = transform.gameObject;
				_oScoreText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score7":
				_oScore7 = transform.gameObject;
				_oScoreText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score8":
				_oScore8 = transform.gameObject;
				_oScoreText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score9":
				_oScore9 = transform.gameObject;
				_oScoreText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score10":
				_oScore10 = transform.gameObject;
				_oScoreText10 = transform.gameObject.GetComponent<Text>();
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

	public bool GetPlayerNameShow(int index)
	{
		return index switch
		{
			1 => PlayerNameShow1, 
			2 => PlayerNameShow2, 
			3 => PlayerNameShow3, 
			4 => PlayerNameShow4, 
			5 => PlayerNameShow5, 
			6 => PlayerNameShow6, 
			7 => PlayerNameShow7, 
			8 => PlayerNameShow8, 
			9 => PlayerNameShow9, 
			10 => PlayerNameShow10, 
			_ => false, 
		};
	}

	public void SetPlayerNameShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerNameShow1 = value;
			break;
		case 2:
			PlayerNameShow2 = value;
			break;
		case 3:
			PlayerNameShow3 = value;
			break;
		case 4:
			PlayerNameShow4 = value;
			break;
		case 5:
			PlayerNameShow5 = value;
			break;
		case 6:
			PlayerNameShow6 = value;
			break;
		case 7:
			PlayerNameShow7 = value;
			break;
		case 8:
			PlayerNameShow8 = value;
			break;
		case 9:
			PlayerNameShow9 = value;
			break;
		case 10:
			PlayerNameShow10 = value;
			break;
		}
	}

	public string GetPlayerNameString(int index)
	{
		return index switch
		{
			1 => PlayerNameString1, 
			2 => PlayerNameString2, 
			3 => PlayerNameString3, 
			4 => PlayerNameString4, 
			5 => PlayerNameString5, 
			6 => PlayerNameString6, 
			7 => PlayerNameString7, 
			8 => PlayerNameString8, 
			9 => PlayerNameString9, 
			10 => PlayerNameString10, 
			_ => null, 
		};
	}

	public void SetPlayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerNameString1 = value;
			break;
		case 2:
			PlayerNameString2 = value;
			break;
		case 3:
			PlayerNameString3 = value;
			break;
		case 4:
			PlayerNameString4 = value;
			break;
		case 5:
			PlayerNameString5 = value;
			break;
		case 6:
			PlayerNameString6 = value;
			break;
		case 7:
			PlayerNameString7 = value;
			break;
		case 8:
			PlayerNameString8 = value;
			break;
		case 9:
			PlayerNameString9 = value;
			break;
		case 10:
			PlayerNameString10 = value;
			break;
		}
	}

	public string GetScoreString(int index)
	{
		return index switch
		{
			1 => ScoreString1, 
			2 => ScoreString2, 
			3 => ScoreString3, 
			4 => ScoreString4, 
			5 => ScoreString5, 
			6 => ScoreString6, 
			7 => ScoreString7, 
			8 => ScoreString8, 
			9 => ScoreString9, 
			10 => ScoreString10, 
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
		case 3:
			ScoreString3 = value;
			break;
		case 4:
			ScoreString4 = value;
			break;
		case 5:
			ScoreString5 = value;
			break;
		case 6:
			ScoreString6 = value;
			break;
		case 7:
			ScoreString7 = value;
			break;
		case 8:
			ScoreString8 = value;
			break;
		case 9:
			ScoreString9 = value;
			break;
		case 10:
			ScoreString10 = value;
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
