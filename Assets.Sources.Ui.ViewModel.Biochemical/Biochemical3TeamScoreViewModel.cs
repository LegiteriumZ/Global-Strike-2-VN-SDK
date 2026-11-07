using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class Biochemical3TeamScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oWinCondition1;

	private GameObject _oWinCondition2;

	private Text _oWinConditionText1;

	private Text _oWinConditionText2;

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

	private GameObject _oLive9;

	private GameObject _oLive10;

	private GameObject _oLive11;

	private GameObject _oLive12;

	private GameObject _oLive13;

	private GameObject _oLive14;

	private GameObject _oLive15;

	private GameObject _oLive16;

	private GameObject _oLive17;

	private GameObject _oLive18;

	private GameObject _oLive19;

	private GameObject _oLive20;

	private GameObject _oLive21;

	private GameObject _oLive22;

	private GameObject _oLive23;

	private GameObject _oLive24;

	private GameObject _oCtLive1;

	private GameObject _oCtLive2;

	private GameObject _oCtLive3;

	private GameObject _oCtLive4;

	private GameObject _oCtLive5;

	private GameObject _oCtLive6;

	private GameObject _oCtLive7;

	private GameObject _oCtLive8;

	private GameObject _oCtLive9;

	private GameObject _oCtLive10;

	private GameObject _oCtLive11;

	private GameObject _oCtLive12;

	private GameObject _oCtLive13;

	private GameObject _oCtLive14;

	private GameObject _oCtLive15;

	private GameObject _oCtLive16;

	private GameObject _oCtLive17;

	private GameObject _oCtLive18;

	private GameObject _oCtLive19;

	private GameObject _oCtLive20;

	private GameObject _oCtLive21;

	private GameObject _oCtLive22;

	private GameObject _oCtLive23;

	private GameObject _oCtLive24;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3TeamScore";

	public string WinConditionString1
	{
		get
		{
			if (_oWinConditionText1 != null)
			{
				return _oWinConditionText1.text;
			}
			return null;
		}
		set
		{
			if (WinConditionString1 != value && _oWinConditionText1 != null)
			{
				_oWinConditionText1.text = value;
			}
		}
	}

	public string WinConditionString2
	{
		get
		{
			if (_oWinConditionText2 != null)
			{
				return _oWinConditionText2.text;
			}
			return null;
		}
		set
		{
			if (WinConditionString2 != value && _oWinConditionText2 != null)
			{
				_oWinConditionText2.text = value;
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

	public bool LiveShow9
	{
		get
		{
			if (_oLive9 != null)
			{
				return _oLive9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow9 != value && _oLive9 != null)
			{
				_oLive9.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow10
	{
		get
		{
			if (_oLive10 != null)
			{
				return _oLive10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow10 != value && _oLive10 != null)
			{
				_oLive10.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow11
	{
		get
		{
			if (_oLive11 != null)
			{
				return _oLive11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow11 != value && _oLive11 != null)
			{
				_oLive11.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow12
	{
		get
		{
			if (_oLive12 != null)
			{
				return _oLive12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow12 != value && _oLive12 != null)
			{
				_oLive12.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow13
	{
		get
		{
			if (_oLive13 != null)
			{
				return _oLive13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow13 != value && _oLive13 != null)
			{
				_oLive13.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow14
	{
		get
		{
			if (_oLive14 != null)
			{
				return _oLive14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow14 != value && _oLive14 != null)
			{
				_oLive14.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow15
	{
		get
		{
			if (_oLive15 != null)
			{
				return _oLive15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow15 != value && _oLive15 != null)
			{
				_oLive15.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow16
	{
		get
		{
			if (_oLive16 != null)
			{
				return _oLive16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow16 != value && _oLive16 != null)
			{
				_oLive16.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow17
	{
		get
		{
			if (_oLive17 != null)
			{
				return _oLive17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow17 != value && _oLive17 != null)
			{
				_oLive17.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow18
	{
		get
		{
			if (_oLive18 != null)
			{
				return _oLive18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow18 != value && _oLive18 != null)
			{
				_oLive18.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow19
	{
		get
		{
			if (_oLive19 != null)
			{
				return _oLive19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow19 != value && _oLive19 != null)
			{
				_oLive19.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow20
	{
		get
		{
			if (_oLive20 != null)
			{
				return _oLive20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow20 != value && _oLive20 != null)
			{
				_oLive20.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow21
	{
		get
		{
			if (_oLive21 != null)
			{
				return _oLive21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow21 != value && _oLive21 != null)
			{
				_oLive21.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow22
	{
		get
		{
			if (_oLive22 != null)
			{
				return _oLive22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow22 != value && _oLive22 != null)
			{
				_oLive22.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow23
	{
		get
		{
			if (_oLive23 != null)
			{
				return _oLive23.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow23 != value && _oLive23 != null)
			{
				_oLive23.SetObjectActive(value);
			}
		}
	}

	public bool LiveShow24
	{
		get
		{
			if (_oLive24 != null)
			{
				return _oLive24.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LiveShow24 != value && _oLive24 != null)
			{
				_oLive24.SetObjectActive(value);
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

	public bool CtLiveShow9
	{
		get
		{
			if (_oCtLive9 != null)
			{
				return _oCtLive9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow9 != value && _oCtLive9 != null)
			{
				_oCtLive9.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow10
	{
		get
		{
			if (_oCtLive10 != null)
			{
				return _oCtLive10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow10 != value && _oCtLive10 != null)
			{
				_oCtLive10.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow11
	{
		get
		{
			if (_oCtLive11 != null)
			{
				return _oCtLive11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow11 != value && _oCtLive11 != null)
			{
				_oCtLive11.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow12
	{
		get
		{
			if (_oCtLive12 != null)
			{
				return _oCtLive12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow12 != value && _oCtLive12 != null)
			{
				_oCtLive12.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow13
	{
		get
		{
			if (_oCtLive13 != null)
			{
				return _oCtLive13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow13 != value && _oCtLive13 != null)
			{
				_oCtLive13.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow14
	{
		get
		{
			if (_oCtLive14 != null)
			{
				return _oCtLive14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow14 != value && _oCtLive14 != null)
			{
				_oCtLive14.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow15
	{
		get
		{
			if (_oCtLive15 != null)
			{
				return _oCtLive15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow15 != value && _oCtLive15 != null)
			{
				_oCtLive15.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow16
	{
		get
		{
			if (_oCtLive16 != null)
			{
				return _oCtLive16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow16 != value && _oCtLive16 != null)
			{
				_oCtLive16.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow17
	{
		get
		{
			if (_oCtLive17 != null)
			{
				return _oCtLive17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow17 != value && _oCtLive17 != null)
			{
				_oCtLive17.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow18
	{
		get
		{
			if (_oCtLive18 != null)
			{
				return _oCtLive18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow18 != value && _oCtLive18 != null)
			{
				_oCtLive18.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow19
	{
		get
		{
			if (_oCtLive19 != null)
			{
				return _oCtLive19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow19 != value && _oCtLive19 != null)
			{
				_oCtLive19.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow20
	{
		get
		{
			if (_oCtLive20 != null)
			{
				return _oCtLive20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow20 != value && _oCtLive20 != null)
			{
				_oCtLive20.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow21
	{
		get
		{
			if (_oCtLive21 != null)
			{
				return _oCtLive21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow21 != value && _oCtLive21 != null)
			{
				_oCtLive21.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow22
	{
		get
		{
			if (_oCtLive22 != null)
			{
				return _oCtLive22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow22 != value && _oCtLive22 != null)
			{
				_oCtLive22.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow23
	{
		get
		{
			if (_oCtLive23 != null)
			{
				return _oCtLive23.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow23 != value && _oCtLive23 != null)
			{
				_oCtLive23.SetObjectActive(value);
			}
		}
	}

	public bool CtLiveShow24
	{
		get
		{
			if (_oCtLive24 != null)
			{
				return _oCtLive24.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtLiveShow24 != value && _oCtLive24 != null)
			{
				_oCtLive24.SetObjectActive(value);
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
			case "WinCondition1":
				_oWinCondition1 = transform.gameObject;
				_oWinConditionText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "WinCondition2":
				_oWinCondition2 = transform.gameObject;
				_oWinConditionText2 = transform.gameObject.GetComponent<Text>();
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
			case "Live9":
				_oLive9 = transform.gameObject;
				break;
			case "Live10":
				_oLive10 = transform.gameObject;
				break;
			case "Live11":
				_oLive11 = transform.gameObject;
				break;
			case "Live12":
				_oLive12 = transform.gameObject;
				break;
			case "Live13":
				_oLive13 = transform.gameObject;
				break;
			case "Live14":
				_oLive14 = transform.gameObject;
				break;
			case "Live15":
				_oLive15 = transform.gameObject;
				break;
			case "Live16":
				_oLive16 = transform.gameObject;
				break;
			case "Live17":
				_oLive17 = transform.gameObject;
				break;
			case "Live18":
				_oLive18 = transform.gameObject;
				break;
			case "Live19":
				_oLive19 = transform.gameObject;
				break;
			case "Live20":
				_oLive20 = transform.gameObject;
				break;
			case "Live21":
				_oLive21 = transform.gameObject;
				break;
			case "Live22":
				_oLive22 = transform.gameObject;
				break;
			case "Live23":
				_oLive23 = transform.gameObject;
				break;
			case "Live24":
				_oLive24 = transform.gameObject;
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
			case "CtLive9":
				_oCtLive9 = transform.gameObject;
				break;
			case "CtLive10":
				_oCtLive10 = transform.gameObject;
				break;
			case "CtLive11":
				_oCtLive11 = transform.gameObject;
				break;
			case "CtLive12":
				_oCtLive12 = transform.gameObject;
				break;
			case "CtLive13":
				_oCtLive13 = transform.gameObject;
				break;
			case "CtLive14":
				_oCtLive14 = transform.gameObject;
				break;
			case "CtLive15":
				_oCtLive15 = transform.gameObject;
				break;
			case "CtLive16":
				_oCtLive16 = transform.gameObject;
				break;
			case "CtLive17":
				_oCtLive17 = transform.gameObject;
				break;
			case "CtLive18":
				_oCtLive18 = transform.gameObject;
				break;
			case "CtLive19":
				_oCtLive19 = transform.gameObject;
				break;
			case "CtLive20":
				_oCtLive20 = transform.gameObject;
				break;
			case "CtLive21":
				_oCtLive21 = transform.gameObject;
				break;
			case "CtLive22":
				_oCtLive22 = transform.gameObject;
				break;
			case "CtLive23":
				_oCtLive23 = transform.gameObject;
				break;
			case "CtLive24":
				_oCtLive24 = transform.gameObject;
				break;
			}
		}
	}

	public string GetWinConditionString(int index)
	{
		return index switch
		{
			1 => WinConditionString1, 
			2 => WinConditionString2, 
			_ => null, 
		};
	}

	public void SetWinConditionString(int index, string value)
	{
		switch (index)
		{
		case 1:
			WinConditionString1 = value;
			break;
		case 2:
			WinConditionString2 = value;
			break;
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
			9 => LiveShow9, 
			10 => LiveShow10, 
			11 => LiveShow11, 
			12 => LiveShow12, 
			13 => LiveShow13, 
			14 => LiveShow14, 
			15 => LiveShow15, 
			16 => LiveShow16, 
			17 => LiveShow17, 
			18 => LiveShow18, 
			19 => LiveShow19, 
			20 => LiveShow20, 
			21 => LiveShow21, 
			22 => LiveShow22, 
			23 => LiveShow23, 
			24 => LiveShow24, 
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
		case 9:
			LiveShow9 = value;
			break;
		case 10:
			LiveShow10 = value;
			break;
		case 11:
			LiveShow11 = value;
			break;
		case 12:
			LiveShow12 = value;
			break;
		case 13:
			LiveShow13 = value;
			break;
		case 14:
			LiveShow14 = value;
			break;
		case 15:
			LiveShow15 = value;
			break;
		case 16:
			LiveShow16 = value;
			break;
		case 17:
			LiveShow17 = value;
			break;
		case 18:
			LiveShow18 = value;
			break;
		case 19:
			LiveShow19 = value;
			break;
		case 20:
			LiveShow20 = value;
			break;
		case 21:
			LiveShow21 = value;
			break;
		case 22:
			LiveShow22 = value;
			break;
		case 23:
			LiveShow23 = value;
			break;
		case 24:
			LiveShow24 = value;
			break;
		}
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
			9 => CtLiveShow9, 
			10 => CtLiveShow10, 
			11 => CtLiveShow11, 
			12 => CtLiveShow12, 
			13 => CtLiveShow13, 
			14 => CtLiveShow14, 
			15 => CtLiveShow15, 
			16 => CtLiveShow16, 
			17 => CtLiveShow17, 
			18 => CtLiveShow18, 
			19 => CtLiveShow19, 
			20 => CtLiveShow20, 
			21 => CtLiveShow21, 
			22 => CtLiveShow22, 
			23 => CtLiveShow23, 
			24 => CtLiveShow24, 
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
		case 9:
			CtLiveShow9 = value;
			break;
		case 10:
			CtLiveShow10 = value;
			break;
		case 11:
			CtLiveShow11 = value;
			break;
		case 12:
			CtLiveShow12 = value;
			break;
		case 13:
			CtLiveShow13 = value;
			break;
		case 14:
			CtLiveShow14 = value;
			break;
		case 15:
			CtLiveShow15 = value;
			break;
		case 16:
			CtLiveShow16 = value;
			break;
		case 17:
			CtLiveShow17 = value;
			break;
		case 18:
			CtLiveShow18 = value;
			break;
		case 19:
			CtLiveShow19 = value;
			break;
		case 20:
			CtLiveShow20 = value;
			break;
		case 21:
			CtLiveShow21 = value;
			break;
		case 22:
			CtLiveShow22 = value;
			break;
		case 23:
			CtLiveShow23 = value;
			break;
		case 24:
			CtLiveShow24 = value;
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
