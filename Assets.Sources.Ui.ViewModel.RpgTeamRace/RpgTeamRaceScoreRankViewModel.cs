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

namespace Assets.Sources.Ui.ViewModel.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceScoreRankViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oProgressBar1;

	private GameObject _oProgressBar2;

	private GameObject _oProgressBar3;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private GameObject _oBattleFlag1;

	private GameObject _oBattleFlag2;

	private GameObject _oBattleFlag3;

	private RectTransform _oBattleFlagRectTransform1;

	private RectTransform _oBattleFlagRectTransform2;

	private RectTransform _oBattleFlagRectTransform3;

	private Image _oBattleFlagImage1;

	private Image _oBattleFlagImage2;

	private Image _oBattleFlagImage3;

	private GameObject _oScore1;

	private GameObject _oScore2;

	private GameObject _oScore3;

	private Text _oScoreText1;

	private Text _oScoreText2;

	private Text _oScoreText3;

	private GameObject _oNeedKill1;

	private GameObject _oNeedKill2;

	private GameObject _oNeedKill3;

	private Text _oNeedKillText1;

	private Text _oNeedKillText2;

	private Text _oNeedKillText3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgteamrace";

	private string _resourceAssetName = "RpgTeamRaceScoreRank";

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

	public bool ProgressBarShow1
	{
		get
		{
			if (_oProgressBar1 != null)
			{
				return _oProgressBar1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressBarShow1 != value && _oProgressBar1 != null)
			{
				_oProgressBar1.SetObjectActive(value);
			}
		}
	}

	public bool ProgressBarShow2
	{
		get
		{
			if (_oProgressBar2 != null)
			{
				return _oProgressBar2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressBarShow2 != value && _oProgressBar2 != null)
			{
				_oProgressBar2.SetObjectActive(value);
			}
		}
	}

	public bool ProgressBarShow3
	{
		get
		{
			if (_oProgressBar3 != null)
			{
				return _oProgressBar3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressBarShow3 != value && _oProgressBar3 != null)
			{
				_oProgressBar3.SetObjectActive(value);
			}
		}
	}

	public float ProgressFillamount1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.fillAmount = value;
			}
		}
	}

	public Vector3 BattleFlagPosition1
	{
		get
		{
			if (_oBattleFlagRectTransform1 != null)
			{
				return _oBattleFlagRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BattleFlagPosition1 != value && _oBattleFlagRectTransform1 != null)
			{
				_oBattleFlagRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 BattleFlagPosition2
	{
		get
		{
			if (_oBattleFlagRectTransform2 != null)
			{
				return _oBattleFlagRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BattleFlagPosition2 != value && _oBattleFlagRectTransform2 != null)
			{
				_oBattleFlagRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 BattleFlagPosition3
	{
		get
		{
			if (_oBattleFlagRectTransform3 != null)
			{
				return _oBattleFlagRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BattleFlagPosition3 != value && _oBattleFlagRectTransform3 != null)
			{
				_oBattleFlagRectTransform3.localPosition = value;
			}
		}
	}

	public Sprite BattleFlagSprite1
	{
		get
		{
			if (_oBattleFlagImage1 != null)
			{
				return _oBattleFlagImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BattleFlagSprite1 != value && _oBattleFlagImage1 != null)
			{
				_oBattleFlagImage1.sprite = value;
			}
		}
	}

	public Sprite BattleFlagSprite2
	{
		get
		{
			if (_oBattleFlagImage2 != null)
			{
				return _oBattleFlagImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BattleFlagSprite2 != value && _oBattleFlagImage2 != null)
			{
				_oBattleFlagImage2.sprite = value;
			}
		}
	}

	public Sprite BattleFlagSprite3
	{
		get
		{
			if (_oBattleFlagImage3 != null)
			{
				return _oBattleFlagImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BattleFlagSprite3 != value && _oBattleFlagImage3 != null)
			{
				_oBattleFlagImage3.sprite = value;
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

	public Font ScoreTextfont1
	{
		get
		{
			if (_oScoreText1 != null)
			{
				return _oScoreText1.font;
			}
			return null;
		}
		set
		{
			if (ScoreTextfont1 != value && _oScoreText1 != null)
			{
				_oScoreText1.font = value;
			}
		}
	}

	public Font ScoreTextfont2
	{
		get
		{
			if (_oScoreText2 != null)
			{
				return _oScoreText2.font;
			}
			return null;
		}
		set
		{
			if (ScoreTextfont2 != value && _oScoreText2 != null)
			{
				_oScoreText2.font = value;
			}
		}
	}

	public Font ScoreTextfont3
	{
		get
		{
			if (_oScoreText3 != null)
			{
				return _oScoreText3.font;
			}
			return null;
		}
		set
		{
			if (ScoreTextfont3 != value && _oScoreText3 != null)
			{
				_oScoreText3.font = value;
			}
		}
	}

	public string NeedKillString1
	{
		get
		{
			if (_oNeedKillText1 != null)
			{
				return _oNeedKillText1.text;
			}
			return null;
		}
		set
		{
			if (NeedKillString1 != value && _oNeedKillText1 != null)
			{
				_oNeedKillText1.text = value;
			}
		}
	}

	public string NeedKillString2
	{
		get
		{
			if (_oNeedKillText2 != null)
			{
				return _oNeedKillText2.text;
			}
			return null;
		}
		set
		{
			if (NeedKillString2 != value && _oNeedKillText2 != null)
			{
				_oNeedKillText2.text = value;
			}
		}
	}

	public string NeedKillString3
	{
		get
		{
			if (_oNeedKillText3 != null)
			{
				return _oNeedKillText3.text;
			}
			return null;
		}
		set
		{
			if (NeedKillString3 != value && _oNeedKillText3 != null)
			{
				_oNeedKillText3.text = value;
			}
		}
	}

	public Font NeedKillTextfont1
	{
		get
		{
			if (_oNeedKillText1 != null)
			{
				return _oNeedKillText1.font;
			}
			return null;
		}
		set
		{
			if (NeedKillTextfont1 != value && _oNeedKillText1 != null)
			{
				_oNeedKillText1.font = value;
			}
		}
	}

	public Font NeedKillTextfont2
	{
		get
		{
			if (_oNeedKillText2 != null)
			{
				return _oNeedKillText2.font;
			}
			return null;
		}
		set
		{
			if (NeedKillTextfont2 != value && _oNeedKillText2 != null)
			{
				_oNeedKillText2.font = value;
			}
		}
	}

	public Font NeedKillTextfont3
	{
		get
		{
			if (_oNeedKillText3 != null)
			{
				return _oNeedKillText3.font;
			}
			return null;
		}
		set
		{
			if (NeedKillTextfont3 != value && _oNeedKillText3 != null)
			{
				_oNeedKillText3.font = value;
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
			case "ProgressBar1":
				_oProgressBar1 = transform.gameObject;
				break;
			case "ProgressBar2":
				_oProgressBar2 = transform.gameObject;
				break;
			case "ProgressBar3":
				_oProgressBar3 = transform.gameObject;
				break;
			case "Progress1":
				_oProgress1 = transform.gameObject;
				_oProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress2":
				_oProgress2 = transform.gameObject;
				_oProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress3":
				_oProgress3 = transform.gameObject;
				_oProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "BattleFlag1":
				_oBattleFlag1 = transform.gameObject;
				_oBattleFlagRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oBattleFlagImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "BattleFlag2":
				_oBattleFlag2 = transform.gameObject;
				_oBattleFlagRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oBattleFlagImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BattleFlag3":
				_oBattleFlag3 = transform.gameObject;
				_oBattleFlagRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oBattleFlagImage3 = transform.gameObject.GetComponent<Image>();
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
			case "NeedKill1":
				_oNeedKill1 = transform.gameObject;
				_oNeedKillText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "NeedKill2":
				_oNeedKill2 = transform.gameObject;
				_oNeedKillText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "NeedKill3":
				_oNeedKill3 = transform.gameObject;
				_oNeedKillText3 = transform.gameObject.GetComponent<Text>();
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

	public bool GetProgressBarShow(int index)
	{
		return index switch
		{
			1 => ProgressBarShow1, 
			2 => ProgressBarShow2, 
			3 => ProgressBarShow3, 
			_ => false, 
		};
	}

	public void SetProgressBarShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ProgressBarShow1 = value;
			break;
		case 2:
			ProgressBarShow2 = value;
			break;
		case 3:
			ProgressBarShow3 = value;
			break;
		}
	}

	public float GetProgressFillamount(int index)
	{
		return index switch
		{
			1 => ProgressFillamount1, 
			2 => ProgressFillamount2, 
			3 => ProgressFillamount3, 
			_ => 0f, 
		};
	}

	public void SetProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			ProgressFillamount1 = value;
			break;
		case 2:
			ProgressFillamount2 = value;
			break;
		case 3:
			ProgressFillamount3 = value;
			break;
		}
	}

	public Vector3 GetBattleFlagPosition(int index)
	{
		return index switch
		{
			1 => BattleFlagPosition1, 
			2 => BattleFlagPosition2, 
			3 => BattleFlagPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetBattleFlagPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			BattleFlagPosition1 = value;
			break;
		case 2:
			BattleFlagPosition2 = value;
			break;
		case 3:
			BattleFlagPosition3 = value;
			break;
		}
	}

	public Sprite GetBattleFlagSprite(int index)
	{
		return index switch
		{
			1 => BattleFlagSprite1, 
			2 => BattleFlagSprite2, 
			3 => BattleFlagSprite3, 
			_ => null, 
		};
	}

	public void SetBattleFlagSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BattleFlagSprite1 = value;
			break;
		case 2:
			BattleFlagSprite2 = value;
			break;
		case 3:
			BattleFlagSprite3 = value;
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
		}
	}

	public Font GetScoreTextfont(int index)
	{
		return index switch
		{
			1 => ScoreTextfont1, 
			2 => ScoreTextfont2, 
			3 => ScoreTextfont3, 
			_ => null, 
		};
	}

	public void SetScoreTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			ScoreTextfont1 = value;
			break;
		case 2:
			ScoreTextfont2 = value;
			break;
		case 3:
			ScoreTextfont3 = value;
			break;
		}
	}

	public string GetNeedKillString(int index)
	{
		return index switch
		{
			1 => NeedKillString1, 
			2 => NeedKillString2, 
			3 => NeedKillString3, 
			_ => null, 
		};
	}

	public void SetNeedKillString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NeedKillString1 = value;
			break;
		case 2:
			NeedKillString2 = value;
			break;
		case 3:
			NeedKillString3 = value;
			break;
		}
	}

	public Font GetNeedKillTextfont(int index)
	{
		return index switch
		{
			1 => NeedKillTextfont1, 
			2 => NeedKillTextfont2, 
			3 => NeedKillTextfont3, 
			_ => null, 
		};
	}

	public void SetNeedKillTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			NeedKillTextfont1 = value;
			break;
		case 2:
			NeedKillTextfont2 = value;
			break;
		case 3:
			NeedKillTextfont3 = value;
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
