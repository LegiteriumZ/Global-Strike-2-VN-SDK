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

namespace Assets.Sources.Ui.ViewModel.Blast;

[GameUiTest]
public class BlastmodelteamscoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBackboard;

	private Image _oBackboardImage;

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

	private GameObject _oLive1;

	private GameObject _oLive2;

	private GameObject _oLive3;

	private GameObject _oLive4;

	private GameObject _oLive5;

	private GameObject _oLive6;

	private GameObject _oLive7;

	private GameObject _oLive8;

	private GameObject _oDead1;

	private GameObject _oDead2;

	private GameObject _oDead3;

	private GameObject _oDead4;

	private GameObject _oDead5;

	private GameObject _oDead6;

	private GameObject _oDead7;

	private GameObject _oDead8;

	private GameObject _oCtLive1;

	private GameObject _oCtLive2;

	private GameObject _oCtLive3;

	private GameObject _oCtLive4;

	private GameObject _oCtLive5;

	private GameObject _oCtLive6;

	private GameObject _oCtLive7;

	private GameObject _oCtLive8;

	private GameObject _oCtDead1;

	private GameObject _oCtDead2;

	private GameObject _oCtDead3;

	private GameObject _oCtDead4;

	private GameObject _oCtDead5;

	private GameObject _oCtDead6;

	private GameObject _oCtDead7;

	private GameObject _oCtDead8;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "Blastmodelteamscore";

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

	public bool MinutesShow
	{
		get
		{
			if (_oMinutes != null)
			{
				return _oMinutes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MinutesShow != value && _oMinutes != null)
			{
				_oMinutes.SetObjectActive(value);
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

	public bool SecondsShow
	{
		get
		{
			if (_oSeconds != null)
			{
				return _oSeconds.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondsShow != value && _oSeconds != null)
			{
				_oSeconds.SetObjectActive(value);
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

	public bool LiveShow1
	{
		get
		{
			if (_oLive1 != null)
			{
				return _oLive1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow1 != value && _oLive1 != null)
			{
				_oLive1.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow2
	{
		get
		{
			if (_oLive2 != null)
			{
				return _oLive2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow2 != value && _oLive2 != null)
			{
				_oLive2.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow3
	{
		get
		{
			if (_oLive3 != null)
			{
				return _oLive3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow3 != value && _oLive3 != null)
			{
				_oLive3.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow4
	{
		get
		{
			if (_oLive4 != null)
			{
				return _oLive4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow4 != value && _oLive4 != null)
			{
				_oLive4.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow5
	{
		get
		{
			if (_oLive5 != null)
			{
				return _oLive5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow5 != value && _oLive5 != null)
			{
				_oLive5.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow6
	{
		get
		{
			if (_oLive6 != null)
			{
				return _oLive6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow6 != value && _oLive6 != null)
			{
				_oLive6.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow7
	{
		get
		{
			if (_oLive7 != null)
			{
				return _oLive7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow7 != value && _oLive7 != null)
			{
				_oLive7.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow8
	{
		get
		{
			if (_oLive8 != null)
			{
				return _oLive8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow8 != value && _oLive8 != null)
			{
				_oLive8.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow1
	{
		get
		{
			if (_oDead1 != null)
			{
				return _oDead1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow1 != value && _oDead1 != null)
			{
				_oDead1.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow2
	{
		get
		{
			if (_oDead2 != null)
			{
				return _oDead2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow2 != value && _oDead2 != null)
			{
				_oDead2.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow3
	{
		get
		{
			if (_oDead3 != null)
			{
				return _oDead3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow3 != value && _oDead3 != null)
			{
				_oDead3.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow4
	{
		get
		{
			if (_oDead4 != null)
			{
				return _oDead4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow4 != value && _oDead4 != null)
			{
				_oDead4.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow5
	{
		get
		{
			if (_oDead5 != null)
			{
				return _oDead5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow5 != value && _oDead5 != null)
			{
				_oDead5.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow6
	{
		get
		{
			if (_oDead6 != null)
			{
				return _oDead6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow6 != value && _oDead6 != null)
			{
				_oDead6.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow7
	{
		get
		{
			if (_oDead7 != null)
			{
				return _oDead7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow7 != value && _oDead7 != null)
			{
				_oDead7.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow8
	{
		get
		{
			if (_oDead8 != null)
			{
				return _oDead8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow8 != value && _oDead8 != null)
			{
				_oDead8.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow1
	{
		get
		{
			if (_oCtLive1 != null)
			{
				return _oCtLive1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow1 != value && _oCtLive1 != null)
			{
				_oCtLive1.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow2
	{
		get
		{
			if (_oCtLive2 != null)
			{
				return _oCtLive2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow2 != value && _oCtLive2 != null)
			{
				_oCtLive2.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow3
	{
		get
		{
			if (_oCtLive3 != null)
			{
				return _oCtLive3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow3 != value && _oCtLive3 != null)
			{
				_oCtLive3.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow4
	{
		get
		{
			if (_oCtLive4 != null)
			{
				return _oCtLive4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow4 != value && _oCtLive4 != null)
			{
				_oCtLive4.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow5
	{
		get
		{
			if (_oCtLive5 != null)
			{
				return _oCtLive5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow5 != value && _oCtLive5 != null)
			{
				_oCtLive5.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow6
	{
		get
		{
			if (_oCtLive6 != null)
			{
				return _oCtLive6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow6 != value && _oCtLive6 != null)
			{
				_oCtLive6.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow7
	{
		get
		{
			if (_oCtLive7 != null)
			{
				return _oCtLive7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow7 != value && _oCtLive7 != null)
			{
				_oCtLive7.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow8
	{
		get
		{
			if (_oCtLive8 != null)
			{
				return _oCtLive8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow8 != value && _oCtLive8 != null)
			{
				_oCtLive8.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow1
	{
		get
		{
			if (_oCtDead1 != null)
			{
				return _oCtDead1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow1 != value && _oCtDead1 != null)
			{
				_oCtDead1.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow2
	{
		get
		{
			if (_oCtDead2 != null)
			{
				return _oCtDead2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow2 != value && _oCtDead2 != null)
			{
				_oCtDead2.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow3
	{
		get
		{
			if (_oCtDead3 != null)
			{
				return _oCtDead3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow3 != value && _oCtDead3 != null)
			{
				_oCtDead3.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow4
	{
		get
		{
			if (_oCtDead4 != null)
			{
				return _oCtDead4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow4 != value && _oCtDead4 != null)
			{
				_oCtDead4.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow5
	{
		get
		{
			if (_oCtDead5 != null)
			{
				return _oCtDead5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow5 != value && _oCtDead5 != null)
			{
				_oCtDead5.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow6
	{
		get
		{
			if (_oCtDead6 != null)
			{
				return _oCtDead6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow6 != value && _oCtDead6 != null)
			{
				_oCtDead6.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow7
	{
		get
		{
			if (_oCtDead7 != null)
			{
				return _oCtDead7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow7 != value && _oCtDead7 != null)
			{
				_oCtDead7.SetObjectActive(value);
			}
		}
	}

	public bool CtDeadShow8
	{
		get
		{
			if (_oCtDead8 != null)
			{
				return _oCtDead8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDeadShow8 != value && _oCtDead8 != null)
			{
				_oCtDead8.SetObjectActive(value);
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
			case "Live1":
				_oLive1 = transform.gameObject;
				break;
			case "Live2":
				_oLive2 = transform.gameObject;
				break;
			case "Live3":
				_oLive3 = transform.gameObject;
				break;
			case "Live4":
				_oLive4 = transform.gameObject;
				break;
			case "Live5":
				_oLive5 = transform.gameObject;
				break;
			case "Live6":
				_oLive6 = transform.gameObject;
				break;
			case "Live7":
				_oLive7 = transform.gameObject;
				break;
			case "Live8":
				_oLive8 = transform.gameObject;
				break;
			case "Dead1":
				_oDead1 = transform.gameObject;
				break;
			case "Dead2":
				_oDead2 = transform.gameObject;
				break;
			case "Dead3":
				_oDead3 = transform.gameObject;
				break;
			case "Dead4":
				_oDead4 = transform.gameObject;
				break;
			case "Dead5":
				_oDead5 = transform.gameObject;
				break;
			case "Dead6":
				_oDead6 = transform.gameObject;
				break;
			case "Dead7":
				_oDead7 = transform.gameObject;
				break;
			case "Dead8":
				_oDead8 = transform.gameObject;
				break;
			case "CtLive1":
				_oCtLive1 = transform.gameObject;
				break;
			case "CtLive2":
				_oCtLive2 = transform.gameObject;
				break;
			case "CtLive3":
				_oCtLive3 = transform.gameObject;
				break;
			case "CtLive4":
				_oCtLive4 = transform.gameObject;
				break;
			case "CtLive5":
				_oCtLive5 = transform.gameObject;
				break;
			case "CtLive6":
				_oCtLive6 = transform.gameObject;
				break;
			case "CtLive7":
				_oCtLive7 = transform.gameObject;
				break;
			case "CtLive8":
				_oCtLive8 = transform.gameObject;
				break;
			case "CtDead1":
				_oCtDead1 = transform.gameObject;
				break;
			case "CtDead2":
				_oCtDead2 = transform.gameObject;
				break;
			case "CtDead3":
				_oCtDead3 = transform.gameObject;
				break;
			case "CtDead4":
				_oCtDead4 = transform.gameObject;
				break;
			case "CtDead5":
				_oCtDead5 = transform.gameObject;
				break;
			case "CtDead6":
				_oCtDead6 = transform.gameObject;
				break;
			case "CtDead7":
				_oCtDead7 = transform.gameObject;
				break;
			case "CtDead8":
				_oCtDead8 = transform.gameObject;
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

	public bool GetLiveShow(int index)
	{
		return index switch
		{
			1 => LiveShow1, 
			2 => LiveShow2, 
			3 => LiveShow3, 
			4 => LiveShow4, 
			5 => LiveShow5, 
			6 => LiveShow6, 
			7 => LiveShow7, 
			8 => LiveShow8, 
			_ => false, 
		};
	}

	public void SetLiveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LiveShow1 = value;
			break;
		case 2:
			LiveShow2 = value;
			break;
		case 3:
			LiveShow3 = value;
			break;
		case 4:
			LiveShow4 = value;
			break;
		case 5:
			LiveShow5 = value;
			break;
		case 6:
			LiveShow6 = value;
			break;
		case 7:
			LiveShow7 = value;
			break;
		case 8:
			LiveShow8 = value;
			break;
		}
	}

	public int GetLiveCount()
	{
		return 8;
	}

	public bool GetDeadShow(int index)
	{
		return index switch
		{
			1 => DeadShow1, 
			2 => DeadShow2, 
			3 => DeadShow3, 
			4 => DeadShow4, 
			5 => DeadShow5, 
			6 => DeadShow6, 
			7 => DeadShow7, 
			8 => DeadShow8, 
			_ => false, 
		};
	}

	public void SetDeadShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DeadShow1 = value;
			break;
		case 2:
			DeadShow2 = value;
			break;
		case 3:
			DeadShow3 = value;
			break;
		case 4:
			DeadShow4 = value;
			break;
		case 5:
			DeadShow5 = value;
			break;
		case 6:
			DeadShow6 = value;
			break;
		case 7:
			DeadShow7 = value;
			break;
		case 8:
			DeadShow8 = value;
			break;
		}
	}

	public int GetDeadCount()
	{
		return 8;
	}

	public bool GetCtLiveShow(int index)
	{
		return index switch
		{
			1 => CtLiveShow1, 
			2 => CtLiveShow2, 
			3 => CtLiveShow3, 
			4 => CtLiveShow4, 
			5 => CtLiveShow5, 
			6 => CtLiveShow6, 
			7 => CtLiveShow7, 
			8 => CtLiveShow8, 
			_ => false, 
		};
	}

	public void SetCtLiveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtLiveShow1 = value;
			break;
		case 2:
			CtLiveShow2 = value;
			break;
		case 3:
			CtLiveShow3 = value;
			break;
		case 4:
			CtLiveShow4 = value;
			break;
		case 5:
			CtLiveShow5 = value;
			break;
		case 6:
			CtLiveShow6 = value;
			break;
		case 7:
			CtLiveShow7 = value;
			break;
		case 8:
			CtLiveShow8 = value;
			break;
		}
	}

	public int GetCtLiveCount()
	{
		return 8;
	}

	public bool GetCtDeadShow(int index)
	{
		return index switch
		{
			1 => CtDeadShow1, 
			2 => CtDeadShow2, 
			3 => CtDeadShow3, 
			4 => CtDeadShow4, 
			5 => CtDeadShow5, 
			6 => CtDeadShow6, 
			7 => CtDeadShow7, 
			8 => CtDeadShow8, 
			_ => false, 
		};
	}

	public void SetCtDeadShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtDeadShow1 = value;
			break;
		case 2:
			CtDeadShow2 = value;
			break;
		case 3:
			CtDeadShow3 = value;
			break;
		case 4:
			CtDeadShow4 = value;
			break;
		case 5:
			CtDeadShow5 = value;
			break;
		case 6:
			CtDeadShow6 = value;
			break;
		case 7:
			CtDeadShow7 = value;
			break;
		case 8:
			CtDeadShow8 = value;
			break;
		}
	}

	public int GetCtDeadCount()
	{
		return 8;
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
		if (_oTeamScoreText1 != null)
		{
			_holdPosTrans.Add(_oTeamScoreText1.GetComponent<RectTransform>());
		}
		if (_oTeamScoreText2 != null)
		{
			_holdPosTrans.Add(_oTeamScoreText2.GetComponent<RectTransform>());
		}
		if (_oMinutesText != null)
		{
			_holdPosTrans.Add(_oMinutesText.GetComponent<RectTransform>());
		}
		if (_oSecondsText != null)
		{
			_holdPosTrans.Add(_oSecondsText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
