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

namespace Assets.Sources.Ui.ViewModel.RpgRescue;

[GameUiTest]
public class RpgRescueScoreRankViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPveScoreRank;

	private GameObject _oPanel;

	private GameObject _oItem1;

	private GameObject _oItem2;

	private GameObject _oItem3;

	private GameObject _oItem4;

	private GameObject _oItem5;

	private GameObject _oItem6;

	private GameObject _oItem7;

	private GameObject _oItem8;

	private GameObject _oItem9;

	private GameObject _oItem10;

	private GameObject _oRelieveBg1;

	private GameObject _oRelieveBg2;

	private GameObject _oRelieveBg3;

	private GameObject _oRelieveBg4;

	private GameObject _oRelieveBg5;

	private GameObject _oRelieveBg6;

	private GameObject _oRelieveBg7;

	private GameObject _oRelieveBg8;

	private GameObject _oRelieveBg9;

	private GameObject _oRelieveBg10;

	private GameObject _oReleiveProgress1;

	private GameObject _oReleiveProgress2;

	private GameObject _oReleiveProgress3;

	private GameObject _oReleiveProgress4;

	private GameObject _oReleiveProgress5;

	private GameObject _oReleiveProgress6;

	private GameObject _oReleiveProgress7;

	private GameObject _oReleiveProgress8;

	private GameObject _oReleiveProgress9;

	private GameObject _oReleiveProgress10;

	private Image _oReleiveProgressImage1;

	private Image _oReleiveProgressImage2;

	private Image _oReleiveProgressImage3;

	private Image _oReleiveProgressImage4;

	private Image _oReleiveProgressImage5;

	private Image _oReleiveProgressImage6;

	private Image _oReleiveProgressImage7;

	private Image _oReleiveProgressImage8;

	private Image _oReleiveProgressImage9;

	private Image _oReleiveProgressImage10;

	private GameObject _oWet1;

	private GameObject _oWet2;

	private GameObject _oWet3;

	private GameObject _oWet4;

	private GameObject _oWet5;

	private GameObject _oWet6;

	private GameObject _oWet7;

	private GameObject _oWet8;

	private GameObject _oWet9;

	private GameObject _oWet10;

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

	private RectTransform[] _oScore1s;

	private RectTransform[] _oScore2s;

	private RectTransform[] _oScore3s;

	private RectTransform[] _oScore4s;

	private RectTransform[] _oScore5s;

	private RectTransform[] _oScore6s;

	private RectTransform[] _oScore7s;

	private RectTransform[] _oScore8s;

	private RectTransform[] _oScore9s;

	private RectTransform[] _oScore10s;

	private Text[] _oScore1Texts;

	private Text[] _oScore2Texts;

	private Text[] _oScore3Texts;

	private Text[] _oScore4Texts;

	private Text[] _oScore5Texts;

	private Text[] _oScore6Texts;

	private Text[] _oScore7Texts;

	private Text[] _oScore8Texts;

	private Text[] _oScore9Texts;

	private Text[] _oScore10Texts;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgRescue";

	private string _resourceAssetName = "RpgRescueScoreRank";

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

	public bool PveScoreRankShow
	{
		get
		{
			if (_oPveScoreRank != null)
			{
				return _oPveScoreRank.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PveScoreRankShow != value && _oPveScoreRank != null)
			{
				_oPveScoreRank.SetObjectActive(value);
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

	public bool ItemShow1
	{
		get
		{
			if (_oItem1 != null)
			{
				return _oItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow1 != value && _oItem1 != null)
			{
				_oItem1.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow2
	{
		get
		{
			if (_oItem2 != null)
			{
				return _oItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow2 != value && _oItem2 != null)
			{
				_oItem2.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow3
	{
		get
		{
			if (_oItem3 != null)
			{
				return _oItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow3 != value && _oItem3 != null)
			{
				_oItem3.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow4
	{
		get
		{
			if (_oItem4 != null)
			{
				return _oItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow4 != value && _oItem4 != null)
			{
				_oItem4.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow5
	{
		get
		{
			if (_oItem5 != null)
			{
				return _oItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow5 != value && _oItem5 != null)
			{
				_oItem5.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow6
	{
		get
		{
			if (_oItem6 != null)
			{
				return _oItem6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow6 != value && _oItem6 != null)
			{
				_oItem6.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow7
	{
		get
		{
			if (_oItem7 != null)
			{
				return _oItem7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow7 != value && _oItem7 != null)
			{
				_oItem7.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow8
	{
		get
		{
			if (_oItem8 != null)
			{
				return _oItem8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow8 != value && _oItem8 != null)
			{
				_oItem8.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow9
	{
		get
		{
			if (_oItem9 != null)
			{
				return _oItem9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow9 != value && _oItem9 != null)
			{
				_oItem9.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow10
	{
		get
		{
			if (_oItem10 != null)
			{
				return _oItem10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow10 != value && _oItem10 != null)
			{
				_oItem10.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow1
	{
		get
		{
			if (_oRelieveBg1 != null)
			{
				return _oRelieveBg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow1 != value && _oRelieveBg1 != null)
			{
				_oRelieveBg1.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow2
	{
		get
		{
			if (_oRelieveBg2 != null)
			{
				return _oRelieveBg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow2 != value && _oRelieveBg2 != null)
			{
				_oRelieveBg2.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow3
	{
		get
		{
			if (_oRelieveBg3 != null)
			{
				return _oRelieveBg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow3 != value && _oRelieveBg3 != null)
			{
				_oRelieveBg3.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow4
	{
		get
		{
			if (_oRelieveBg4 != null)
			{
				return _oRelieveBg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow4 != value && _oRelieveBg4 != null)
			{
				_oRelieveBg4.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow5
	{
		get
		{
			if (_oRelieveBg5 != null)
			{
				return _oRelieveBg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow5 != value && _oRelieveBg5 != null)
			{
				_oRelieveBg5.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow6
	{
		get
		{
			if (_oRelieveBg6 != null)
			{
				return _oRelieveBg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow6 != value && _oRelieveBg6 != null)
			{
				_oRelieveBg6.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow7
	{
		get
		{
			if (_oRelieveBg7 != null)
			{
				return _oRelieveBg7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow7 != value && _oRelieveBg7 != null)
			{
				_oRelieveBg7.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow8
	{
		get
		{
			if (_oRelieveBg8 != null)
			{
				return _oRelieveBg8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow8 != value && _oRelieveBg8 != null)
			{
				_oRelieveBg8.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow9
	{
		get
		{
			if (_oRelieveBg9 != null)
			{
				return _oRelieveBg9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow9 != value && _oRelieveBg9 != null)
			{
				_oRelieveBg9.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow10
	{
		get
		{
			if (_oRelieveBg10 != null)
			{
				return _oRelieveBg10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow10 != value && _oRelieveBg10 != null)
			{
				_oRelieveBg10.SetObjectActive(value);
			}
		}
	}

	public float ReleiveProgressFillamount1
	{
		get
		{
			if (_oReleiveProgressImage1 != null)
			{
				return _oReleiveProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount1 != value && _oReleiveProgressImage1 != null)
			{
				_oReleiveProgressImage1.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount2
	{
		get
		{
			if (_oReleiveProgressImage2 != null)
			{
				return _oReleiveProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount2 != value && _oReleiveProgressImage2 != null)
			{
				_oReleiveProgressImage2.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount3
	{
		get
		{
			if (_oReleiveProgressImage3 != null)
			{
				return _oReleiveProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount3 != value && _oReleiveProgressImage3 != null)
			{
				_oReleiveProgressImage3.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount4
	{
		get
		{
			if (_oReleiveProgressImage4 != null)
			{
				return _oReleiveProgressImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount4 != value && _oReleiveProgressImage4 != null)
			{
				_oReleiveProgressImage4.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount5
	{
		get
		{
			if (_oReleiveProgressImage5 != null)
			{
				return _oReleiveProgressImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount5 != value && _oReleiveProgressImage5 != null)
			{
				_oReleiveProgressImage5.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount6
	{
		get
		{
			if (_oReleiveProgressImage6 != null)
			{
				return _oReleiveProgressImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount6 != value && _oReleiveProgressImage6 != null)
			{
				_oReleiveProgressImage6.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount7
	{
		get
		{
			if (_oReleiveProgressImage7 != null)
			{
				return _oReleiveProgressImage7.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount7 != value && _oReleiveProgressImage7 != null)
			{
				_oReleiveProgressImage7.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount8
	{
		get
		{
			if (_oReleiveProgressImage8 != null)
			{
				return _oReleiveProgressImage8.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount8 != value && _oReleiveProgressImage8 != null)
			{
				_oReleiveProgressImage8.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount9
	{
		get
		{
			if (_oReleiveProgressImage9 != null)
			{
				return _oReleiveProgressImage9.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount9 != value && _oReleiveProgressImage9 != null)
			{
				_oReleiveProgressImage9.fillAmount = value;
			}
		}
	}

	public float ReleiveProgressFillamount10
	{
		get
		{
			if (_oReleiveProgressImage10 != null)
			{
				return _oReleiveProgressImage10.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ReleiveProgressFillamount10 != value && _oReleiveProgressImage10 != null)
			{
				_oReleiveProgressImage10.fillAmount = value;
			}
		}
	}

	public bool WetShow1
	{
		get
		{
			if (_oWet1 != null)
			{
				return _oWet1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow1 != value && _oWet1 != null)
			{
				_oWet1.SetObjectActive(value);
			}
		}
	}

	public bool WetShow2
	{
		get
		{
			if (_oWet2 != null)
			{
				return _oWet2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow2 != value && _oWet2 != null)
			{
				_oWet2.SetObjectActive(value);
			}
		}
	}

	public bool WetShow3
	{
		get
		{
			if (_oWet3 != null)
			{
				return _oWet3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow3 != value && _oWet3 != null)
			{
				_oWet3.SetObjectActive(value);
			}
		}
	}

	public bool WetShow4
	{
		get
		{
			if (_oWet4 != null)
			{
				return _oWet4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow4 != value && _oWet4 != null)
			{
				_oWet4.SetObjectActive(value);
			}
		}
	}

	public bool WetShow5
	{
		get
		{
			if (_oWet5 != null)
			{
				return _oWet5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow5 != value && _oWet5 != null)
			{
				_oWet5.SetObjectActive(value);
			}
		}
	}

	public bool WetShow6
	{
		get
		{
			if (_oWet6 != null)
			{
				return _oWet6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow6 != value && _oWet6 != null)
			{
				_oWet6.SetObjectActive(value);
			}
		}
	}

	public bool WetShow7
	{
		get
		{
			if (_oWet7 != null)
			{
				return _oWet7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow7 != value && _oWet7 != null)
			{
				_oWet7.SetObjectActive(value);
			}
		}
	}

	public bool WetShow8
	{
		get
		{
			if (_oWet8 != null)
			{
				return _oWet8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow8 != value && _oWet8 != null)
			{
				_oWet8.SetObjectActive(value);
			}
		}
	}

	public bool WetShow9
	{
		get
		{
			if (_oWet9 != null)
			{
				return _oWet9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow9 != value && _oWet9 != null)
			{
				_oWet9.SetObjectActive(value);
			}
		}
	}

	public bool WetShow10
	{
		get
		{
			if (_oWet10 != null)
			{
				return _oWet10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WetShow10 != value && _oWet10 != null)
			{
				_oWet10.SetObjectActive(value);
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

	public Color PlayerNameTextcolor1
	{
		get
		{
			if (_oPlayerNameText1 != null)
			{
				return _oPlayerNameText1.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor1 != value && _oPlayerNameText1 != null)
			{
				_oPlayerNameText1.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor2
	{
		get
		{
			if (_oPlayerNameText2 != null)
			{
				return _oPlayerNameText2.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor2 != value && _oPlayerNameText2 != null)
			{
				_oPlayerNameText2.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor3
	{
		get
		{
			if (_oPlayerNameText3 != null)
			{
				return _oPlayerNameText3.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor3 != value && _oPlayerNameText3 != null)
			{
				_oPlayerNameText3.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor4
	{
		get
		{
			if (_oPlayerNameText4 != null)
			{
				return _oPlayerNameText4.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor4 != value && _oPlayerNameText4 != null)
			{
				_oPlayerNameText4.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor5
	{
		get
		{
			if (_oPlayerNameText5 != null)
			{
				return _oPlayerNameText5.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor5 != value && _oPlayerNameText5 != null)
			{
				_oPlayerNameText5.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor6
	{
		get
		{
			if (_oPlayerNameText6 != null)
			{
				return _oPlayerNameText6.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor6 != value && _oPlayerNameText6 != null)
			{
				_oPlayerNameText6.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor7
	{
		get
		{
			if (_oPlayerNameText7 != null)
			{
				return _oPlayerNameText7.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor7 != value && _oPlayerNameText7 != null)
			{
				_oPlayerNameText7.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor8
	{
		get
		{
			if (_oPlayerNameText8 != null)
			{
				return _oPlayerNameText8.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor8 != value && _oPlayerNameText8 != null)
			{
				_oPlayerNameText8.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor9
	{
		get
		{
			if (_oPlayerNameText9 != null)
			{
				return _oPlayerNameText9.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor9 != value && _oPlayerNameText9 != null)
			{
				_oPlayerNameText9.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor10
	{
		get
		{
			if (_oPlayerNameText10 != null)
			{
				return _oPlayerNameText10.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor10 != value && _oPlayerNameText10 != null)
			{
				_oPlayerNameText10.color = value;
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
			case "PveScoreRank":
				_oPveScoreRank = transform.gameObject;
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "Item1":
				_oItem1 = transform.gameObject;
				break;
			case "Item2":
				_oItem2 = transform.gameObject;
				break;
			case "Item3":
				_oItem3 = transform.gameObject;
				break;
			case "Item4":
				_oItem4 = transform.gameObject;
				break;
			case "Item5":
				_oItem5 = transform.gameObject;
				break;
			case "Item6":
				_oItem6 = transform.gameObject;
				break;
			case "Item7":
				_oItem7 = transform.gameObject;
				break;
			case "Item8":
				_oItem8 = transform.gameObject;
				break;
			case "Item9":
				_oItem9 = transform.gameObject;
				break;
			case "Item10":
				_oItem10 = transform.gameObject;
				break;
			case "RelieveBg1":
				_oRelieveBg1 = transform.gameObject;
				break;
			case "RelieveBg2":
				_oRelieveBg2 = transform.gameObject;
				break;
			case "RelieveBg3":
				_oRelieveBg3 = transform.gameObject;
				break;
			case "RelieveBg4":
				_oRelieveBg4 = transform.gameObject;
				break;
			case "RelieveBg5":
				_oRelieveBg5 = transform.gameObject;
				break;
			case "RelieveBg6":
				_oRelieveBg6 = transform.gameObject;
				break;
			case "RelieveBg7":
				_oRelieveBg7 = transform.gameObject;
				break;
			case "RelieveBg8":
				_oRelieveBg8 = transform.gameObject;
				break;
			case "RelieveBg9":
				_oRelieveBg9 = transform.gameObject;
				break;
			case "RelieveBg10":
				_oRelieveBg10 = transform.gameObject;
				break;
			case "ReleiveProgress1":
				_oReleiveProgress1 = transform.gameObject;
				_oReleiveProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress2":
				_oReleiveProgress2 = transform.gameObject;
				_oReleiveProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress3":
				_oReleiveProgress3 = transform.gameObject;
				_oReleiveProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress4":
				_oReleiveProgress4 = transform.gameObject;
				_oReleiveProgressImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress5":
				_oReleiveProgress5 = transform.gameObject;
				_oReleiveProgressImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress6":
				_oReleiveProgress6 = transform.gameObject;
				_oReleiveProgressImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress7":
				_oReleiveProgress7 = transform.gameObject;
				_oReleiveProgressImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress8":
				_oReleiveProgress8 = transform.gameObject;
				_oReleiveProgressImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress9":
				_oReleiveProgress9 = transform.gameObject;
				_oReleiveProgressImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "ReleiveProgress10":
				_oReleiveProgress10 = transform.gameObject;
				_oReleiveProgressImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "Wet1":
				_oWet1 = transform.gameObject;
				break;
			case "Wet2":
				_oWet2 = transform.gameObject;
				break;
			case "Wet3":
				_oWet3 = transform.gameObject;
				break;
			case "Wet4":
				_oWet4 = transform.gameObject;
				break;
			case "Wet5":
				_oWet5 = transform.gameObject;
				break;
			case "Wet6":
				_oWet6 = transform.gameObject;
				break;
			case "Wet7":
				_oWet7 = transform.gameObject;
				break;
			case "Wet8":
				_oWet8 = transform.gameObject;
				break;
			case "Wet9":
				_oWet9 = transform.gameObject;
				break;
			case "Wet10":
				_oWet10 = transform.gameObject;
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
				_oScore1s = transform.GetComponentsInChildren<RectTransform>();
				_oScore1Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score2":
				_oScore2s = transform.GetComponentsInChildren<RectTransform>();
				_oScore2Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score3":
				_oScore3s = transform.GetComponentsInChildren<RectTransform>();
				_oScore3Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score4":
				_oScore4s = transform.GetComponentsInChildren<RectTransform>();
				_oScore4Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score5":
				_oScore5s = transform.GetComponentsInChildren<RectTransform>();
				_oScore5Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score6":
				_oScore6s = transform.GetComponentsInChildren<RectTransform>();
				_oScore6Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score7":
				_oScore7s = transform.GetComponentsInChildren<RectTransform>();
				_oScore7Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score8":
				_oScore8s = transform.GetComponentsInChildren<RectTransform>();
				_oScore8Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score9":
				_oScore9s = transform.GetComponentsInChildren<RectTransform>();
				_oScore9Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "Score10":
				_oScore10s = transform.GetComponentsInChildren<RectTransform>();
				_oScore10Texts = transform.GetComponentsInChildren<Text>();
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

	public bool GetItemShow(int index)
	{
		return index switch
		{
			1 => ItemShow1, 
			2 => ItemShow2, 
			3 => ItemShow3, 
			4 => ItemShow4, 
			5 => ItemShow5, 
			6 => ItemShow6, 
			7 => ItemShow7, 
			8 => ItemShow8, 
			9 => ItemShow9, 
			10 => ItemShow10, 
			_ => false, 
		};
	}

	public void SetItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemShow1 = value;
			break;
		case 2:
			ItemShow2 = value;
			break;
		case 3:
			ItemShow3 = value;
			break;
		case 4:
			ItemShow4 = value;
			break;
		case 5:
			ItemShow5 = value;
			break;
		case 6:
			ItemShow6 = value;
			break;
		case 7:
			ItemShow7 = value;
			break;
		case 8:
			ItemShow8 = value;
			break;
		case 9:
			ItemShow9 = value;
			break;
		case 10:
			ItemShow10 = value;
			break;
		}
	}

	public int GetItemCount()
	{
		return 10;
	}

	public bool GetRelieveBgShow(int index)
	{
		return index switch
		{
			1 => RelieveBgShow1, 
			2 => RelieveBgShow2, 
			3 => RelieveBgShow3, 
			4 => RelieveBgShow4, 
			5 => RelieveBgShow5, 
			6 => RelieveBgShow6, 
			7 => RelieveBgShow7, 
			8 => RelieveBgShow8, 
			9 => RelieveBgShow9, 
			10 => RelieveBgShow10, 
			_ => false, 
		};
	}

	public void SetRelieveBgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RelieveBgShow1 = value;
			break;
		case 2:
			RelieveBgShow2 = value;
			break;
		case 3:
			RelieveBgShow3 = value;
			break;
		case 4:
			RelieveBgShow4 = value;
			break;
		case 5:
			RelieveBgShow5 = value;
			break;
		case 6:
			RelieveBgShow6 = value;
			break;
		case 7:
			RelieveBgShow7 = value;
			break;
		case 8:
			RelieveBgShow8 = value;
			break;
		case 9:
			RelieveBgShow9 = value;
			break;
		case 10:
			RelieveBgShow10 = value;
			break;
		}
	}

	public int GetRelieveBgCount()
	{
		return 10;
	}

	public float GetReleiveProgressFillamount(int index)
	{
		return index switch
		{
			1 => ReleiveProgressFillamount1, 
			2 => ReleiveProgressFillamount2, 
			3 => ReleiveProgressFillamount3, 
			4 => ReleiveProgressFillamount4, 
			5 => ReleiveProgressFillamount5, 
			6 => ReleiveProgressFillamount6, 
			7 => ReleiveProgressFillamount7, 
			8 => ReleiveProgressFillamount8, 
			9 => ReleiveProgressFillamount9, 
			10 => ReleiveProgressFillamount10, 
			_ => 0f, 
		};
	}

	public void SetReleiveProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			ReleiveProgressFillamount1 = value;
			break;
		case 2:
			ReleiveProgressFillamount2 = value;
			break;
		case 3:
			ReleiveProgressFillamount3 = value;
			break;
		case 4:
			ReleiveProgressFillamount4 = value;
			break;
		case 5:
			ReleiveProgressFillamount5 = value;
			break;
		case 6:
			ReleiveProgressFillamount6 = value;
			break;
		case 7:
			ReleiveProgressFillamount7 = value;
			break;
		case 8:
			ReleiveProgressFillamount8 = value;
			break;
		case 9:
			ReleiveProgressFillamount9 = value;
			break;
		case 10:
			ReleiveProgressFillamount10 = value;
			break;
		}
	}

	public int GetReleiveProgressCount()
	{
		return 6;
	}

	public bool GetWetShow(int index)
	{
		return index switch
		{
			1 => WetShow1, 
			2 => WetShow2, 
			3 => WetShow3, 
			4 => WetShow4, 
			5 => WetShow5, 
			6 => WetShow6, 
			7 => WetShow7, 
			8 => WetShow8, 
			9 => WetShow9, 
			10 => WetShow10, 
			_ => false, 
		};
	}

	public void SetWetShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WetShow1 = value;
			break;
		case 2:
			WetShow2 = value;
			break;
		case 3:
			WetShow3 = value;
			break;
		case 4:
			WetShow4 = value;
			break;
		case 5:
			WetShow5 = value;
			break;
		case 6:
			WetShow6 = value;
			break;
		case 7:
			WetShow7 = value;
			break;
		case 8:
			WetShow8 = value;
			break;
		case 9:
			WetShow9 = value;
			break;
		case 10:
			WetShow10 = value;
			break;
		}
	}

	public int GetWetCount()
	{
		return 10;
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

	public int GetPlayerNameCount()
	{
		return 10;
	}

	public Color GetPlayerNameTextcolor(int index)
	{
		return index switch
		{
			1 => PlayerNameTextcolor1, 
			2 => PlayerNameTextcolor2, 
			3 => PlayerNameTextcolor3, 
			4 => PlayerNameTextcolor4, 
			5 => PlayerNameTextcolor5, 
			6 => PlayerNameTextcolor6, 
			7 => PlayerNameTextcolor7, 
			8 => PlayerNameTextcolor8, 
			9 => PlayerNameTextcolor9, 
			10 => PlayerNameTextcolor10, 
			_ => Color.white, 
		};
	}

	public void SetPlayerNameTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			PlayerNameTextcolor1 = value;
			break;
		case 2:
			PlayerNameTextcolor2 = value;
			break;
		case 3:
			PlayerNameTextcolor3 = value;
			break;
		case 4:
			PlayerNameTextcolor4 = value;
			break;
		case 5:
			PlayerNameTextcolor5 = value;
			break;
		case 6:
			PlayerNameTextcolor6 = value;
			break;
		case 7:
			PlayerNameTextcolor7 = value;
			break;
		case 8:
			PlayerNameTextcolor8 = value;
			break;
		case 9:
			PlayerNameTextcolor9 = value;
			break;
		case 10:
			PlayerNameTextcolor10 = value;
			break;
		}
	}

	public void SetScore1ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore1s.Length == 7)
		{
			for (int i = 1; i < _oScore1s.Length; i++)
			{
				_oScore1s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore1PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore1s.Length == 7)
		{
			for (int i = 0; i < _oScore1s.Length; i++)
			{
				_oScore1s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore1TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore1Texts.Length == 2)
		{
			_oScore1Texts[0].text = wholeStr;
			_oScore1Texts[1].text = decimalStr;
		}
	}

	public void SetScore2ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore2s.Length == 7)
		{
			for (int i = 1; i < _oScore2s.Length; i++)
			{
				_oScore2s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore2PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore2s.Length == 7)
		{
			for (int i = 0; i < _oScore2s.Length; i++)
			{
				_oScore2s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore2TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore2Texts.Length == 2)
		{
			_oScore2Texts[0].text = wholeStr;
			_oScore2Texts[1].text = decimalStr;
		}
	}

	public void SetScore3ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore3s.Length == 7)
		{
			for (int i = 1; i < _oScore3s.Length; i++)
			{
				_oScore3s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore3PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore3s.Length == 7)
		{
			for (int i = 0; i < _oScore3s.Length; i++)
			{
				_oScore3s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore3TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore3Texts.Length == 2)
		{
			_oScore3Texts[0].text = wholeStr;
			_oScore3Texts[1].text = decimalStr;
		}
	}

	public void SetScore4ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore4s.Length == 7)
		{
			for (int i = 1; i < _oScore4s.Length; i++)
			{
				_oScore4s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore4PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore4s.Length == 7)
		{
			for (int i = 0; i < _oScore4s.Length; i++)
			{
				_oScore4s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore4TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore4Texts.Length == 2)
		{
			_oScore4Texts[0].text = wholeStr;
			_oScore4Texts[1].text = decimalStr;
		}
	}

	public void SetScore5ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore5s.Length == 7)
		{
			for (int i = 1; i < _oScore5s.Length; i++)
			{
				_oScore5s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore5PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore5s.Length == 7)
		{
			for (int i = 0; i < _oScore5s.Length; i++)
			{
				_oScore5s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore5TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore5Texts.Length == 2)
		{
			_oScore5Texts[0].text = wholeStr;
			_oScore5Texts[1].text = decimalStr;
		}
	}

	public void SetScore6ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore6s.Length == 7)
		{
			for (int i = 1; i < _oScore6s.Length; i++)
			{
				_oScore6s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore6PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore6s.Length == 7)
		{
			for (int i = 0; i < _oScore6s.Length; i++)
			{
				_oScore6s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore6TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore6Texts.Length == 2)
		{
			_oScore6Texts[0].text = wholeStr;
			_oScore6Texts[1].text = decimalStr;
		}
	}

	public void SetScore7ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore7s.Length == 7)
		{
			for (int i = 1; i < _oScore7s.Length; i++)
			{
				_oScore7s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore7PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore7s.Length == 7)
		{
			for (int i = 0; i < _oScore7s.Length; i++)
			{
				_oScore7s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore7TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore7Texts.Length == 2)
		{
			_oScore7Texts[0].text = wholeStr;
			_oScore7Texts[1].text = decimalStr;
		}
	}

	public void SetScore8ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore8s.Length == 7)
		{
			for (int i = 1; i < _oScore8s.Length; i++)
			{
				_oScore8s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore8PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore8s.Length == 7)
		{
			for (int i = 0; i < _oScore8s.Length; i++)
			{
				_oScore8s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore8TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore8Texts.Length == 2)
		{
			_oScore8Texts[0].text = wholeStr;
			_oScore8Texts[1].text = decimalStr;
		}
	}

	public void SetScore9ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore9s.Length == 7)
		{
			for (int i = 1; i < _oScore9s.Length; i++)
			{
				_oScore9s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore9PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore9s.Length == 7)
		{
			for (int i = 0; i < _oScore9s.Length; i++)
			{
				_oScore9s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore9TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore9Texts.Length == 2)
		{
			_oScore9Texts[0].text = wholeStr;
			_oScore9Texts[1].text = decimalStr;
		}
	}

	public void SetScore10ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 6 || _oScore10s.Length == 7)
		{
			for (int i = 1; i < _oScore10s.Length; i++)
			{
				_oScore10s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetScore10PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oScore10s.Length == 7)
		{
			for (int i = 0; i < _oScore10s.Length; i++)
			{
				_oScore10s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetScore10TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oScore10Texts.Length == 2)
		{
			_oScore10Texts[0].text = wholeStr;
			_oScore10Texts[1].text = decimalStr;
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
