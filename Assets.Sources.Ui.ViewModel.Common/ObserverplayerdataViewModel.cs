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

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ObserverplayerdataViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBackImage;

	private Image _oBackImageImage;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oTeamName;

	private Text _oTeamNameText;

	private GameObject _oKd;

	private Text _oKdText;

	private GameObject _oHeadKill;

	private Text _oHeadKillText;

	private GameObject _oRaceRankSectImage;

	private Image _oRaceRankSectImageImage;

	private GameObject _oRaceLvText;

	private Text _oRaceLvTextText;

	private GameObject _oRank;

	private Text _oRankText;

	private GameObject _oMVP;

	private Text _oMVPText;

	private GameObject _oSkillSoucre;

	private Text _oSkillSoucreText;

	private GameObject _oSuccess;

	private Text _oSuccessText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "observerplayerdata";

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

	public Sprite BackImageSprite
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite != value && _oBackImageImage != null)
			{
				_oBackImageImage.sprite = value;
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

	public string TeamNameString
	{
		get
		{
			if (_oTeamNameText != null)
			{
				return _oTeamNameText.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString != value && _oTeamNameText != null)
			{
				_oTeamNameText.text = value;
			}
		}
	}

	public string KdString
	{
		get
		{
			if (_oKdText != null)
			{
				return _oKdText.text;
			}
			return null;
		}
		set
		{
			if (KdString != value && _oKdText != null)
			{
				_oKdText.text = value;
			}
		}
	}

	public string HeadKillString
	{
		get
		{
			if (_oHeadKillText != null)
			{
				return _oHeadKillText.text;
			}
			return null;
		}
		set
		{
			if (HeadKillString != value && _oHeadKillText != null)
			{
				_oHeadKillText.text = value;
			}
		}
	}

	public bool RaceRankSectImageShow
	{
		get
		{
			if (_oRaceRankSectImage != null)
			{
				return _oRaceRankSectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceRankSectImageShow != value && _oRaceRankSectImage != null)
			{
				_oRaceRankSectImage.SetObjectActive(value);
			}
		}
	}

	public Sprite RaceRankSectImageSprite
	{
		get
		{
			if (_oRaceRankSectImageImage != null)
			{
				return _oRaceRankSectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (RaceRankSectImageSprite != value && _oRaceRankSectImageImage != null)
			{
				_oRaceRankSectImageImage.sprite = value;
			}
		}
	}

	public string RaceLvTextString
	{
		get
		{
			if (_oRaceLvTextText != null)
			{
				return _oRaceLvTextText.text;
			}
			return null;
		}
		set
		{
			if (RaceLvTextString != value && _oRaceLvTextText != null)
			{
				_oRaceLvTextText.text = value;
			}
		}
	}

	public string RankString
	{
		get
		{
			if (_oRankText != null)
			{
				return _oRankText.text;
			}
			return null;
		}
		set
		{
			if (RankString != value && _oRankText != null)
			{
				_oRankText.text = value;
			}
		}
	}

	public string MVPString
	{
		get
		{
			if (_oMVPText != null)
			{
				return _oMVPText.text;
			}
			return null;
		}
		set
		{
			if (MVPString != value && _oMVPText != null)
			{
				_oMVPText.text = value;
			}
		}
	}

	public string SkillSoucreString
	{
		get
		{
			if (_oSkillSoucreText != null)
			{
				return _oSkillSoucreText.text;
			}
			return null;
		}
		set
		{
			if (SkillSoucreString != value && _oSkillSoucreText != null)
			{
				_oSkillSoucreText.text = value;
			}
		}
	}

	public string SuccessString
	{
		get
		{
			if (_oSuccessText != null)
			{
				return _oSuccessText.text;
			}
			return null;
		}
		set
		{
			if (SuccessString != value && _oSuccessText != null)
			{
				_oSuccessText.text = value;
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
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName":
				_oTeamName = transform.gameObject;
				_oTeamNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Kd":
				_oKd = transform.gameObject;
				_oKdText = transform.gameObject.GetComponent<Text>();
				break;
			case "HeadKill":
				_oHeadKill = transform.gameObject;
				_oHeadKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceRankSectImage":
				_oRaceRankSectImage = transform.gameObject;
				_oRaceRankSectImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "RaceLvText":
				_oRaceLvText = transform.gameObject;
				_oRaceLvTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Rank":
				_oRank = transform.gameObject;
				_oRankText = transform.gameObject.GetComponent<Text>();
				break;
			case "MVP":
				_oMVP = transform.gameObject;
				_oMVPText = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillSoucre":
				_oSkillSoucre = transform.gameObject;
				_oSkillSoucreText = transform.gameObject.GetComponent<Text>();
				break;
			case "Success":
				_oSuccess = transform.gameObject;
				_oSuccessText = transform.gameObject.GetComponent<Text>();
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
