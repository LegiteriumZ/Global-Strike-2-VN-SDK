using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.RpgRescue;

[GameUiTest]
public class RpgRescueAllKillInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oRoomName;

	private Text _oRoomNameText;

	private GameObject _oPlayerCount;

	private Text _oPlayerCountText;

	private GameObject _oPlayer1;

	private GameObject _oPlayer2;

	private GameObject _oPlayer3;

	private GameObject _oPlayer4;

	private GameObject _oPlayer5;

	private GameObject _oPlayer6;

	private GameObject _oPlayer7;

	private GameObject _oPlayer8;

	private GameObject _oPlayer9;

	private GameObject _oPlayer10;

	private GameObject _oSelfBack1;

	private GameObject _oSelfBack2;

	private GameObject _oSelfBack3;

	private GameObject _oSelfBack4;

	private GameObject _oSelfBack5;

	private GameObject _oSelfBack6;

	private GameObject _oSelfBack7;

	private GameObject _oSelfBack8;

	private GameObject _oSelfBack9;

	private GameObject _oSelfBack10;

	private GameObject _oSelfTeam1;

	private GameObject _oSelfTeam2;

	private GameObject _oSelfTeam3;

	private GameObject _oSelfTeam4;

	private GameObject _oSelfTeam5;

	private GameObject _oSelfTeam6;

	private GameObject _oSelfTeam7;

	private GameObject _oSelfTeam8;

	private GameObject _oSelfTeam9;

	private GameObject _oSelfTeam10;

	private GameObject _oUnityFlag1;

	private GameObject _oUnityFlag2;

	private GameObject _oUnityFlag3;

	private GameObject _oUnityFlag4;

	private GameObject _oUnityFlag5;

	private GameObject _oUnityFlag6;

	private GameObject _oUnityFlag7;

	private GameObject _oUnityFlag8;

	private GameObject _oUnityFlag9;

	private GameObject _oUnityFlag10;

	private GameObject _oHonorary1;

	private GameObject _oHonorary2;

	private GameObject _oHonorary3;

	private GameObject _oHonorary4;

	private GameObject _oHonorary5;

	private GameObject _oHonorary6;

	private GameObject _oHonorary7;

	private GameObject _oHonorary8;

	private GameObject _oHonorary9;

	private GameObject _oHonorary10;

	private Image _oHonoraryImage1;

	private Image _oHonoraryImage2;

	private Image _oHonoraryImage3;

	private Image _oHonoraryImage4;

	private Image _oHonoraryImage5;

	private Image _oHonoraryImage6;

	private Image _oHonoraryImage7;

	private Image _oHonoraryImage8;

	private Image _oHonoraryImage9;

	private Image _oHonoraryImage10;

	private GameObject _oVip1;

	private GameObject _oVip2;

	private GameObject _oVip3;

	private GameObject _oVip4;

	private GameObject _oVip5;

	private GameObject _oVip6;

	private GameObject _oVip7;

	private GameObject _oVip8;

	private GameObject _oVip9;

	private GameObject _oVip10;

	private Image _oVipImage1;

	private Image _oVipImage2;

	private Image _oVipImage3;

	private Image _oVipImage4;

	private Image _oVipImage5;

	private Image _oVipImage6;

	private Image _oVipImage7;

	private Image _oVipImage8;

	private Image _oVipImage9;

	private Image _oVipImage10;

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

	private GameObject _oDead1;

	private GameObject _oDead2;

	private GameObject _oDead3;

	private GameObject _oDead4;

	private GameObject _oDead5;

	private GameObject _oDead6;

	private GameObject _oDead7;

	private GameObject _oDead8;

	private GameObject _oDead9;

	private GameObject _oDead10;

	private GameObject _oTeamName1;

	private GameObject _oTeamName2;

	private GameObject _oTeamName3;

	private GameObject _oTeamName4;

	private GameObject _oTeamName5;

	private GameObject _oTeamName6;

	private GameObject _oTeamName7;

	private GameObject _oTeamName8;

	private GameObject _oTeamName9;

	private GameObject _oTeamName10;

	private Text _oTeamNameText1;

	private Text _oTeamNameText2;

	private Text _oTeamNameText3;

	private Text _oTeamNameText4;

	private Text _oTeamNameText5;

	private Text _oTeamNameText6;

	private Text _oTeamNameText7;

	private Text _oTeamNameText8;

	private Text _oTeamNameText9;

	private Text _oTeamNameText10;

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

	private GameObject _oKill1;

	private GameObject _oKill2;

	private GameObject _oKill3;

	private GameObject _oKill4;

	private GameObject _oKill5;

	private GameObject _oKill6;

	private GameObject _oKill7;

	private GameObject _oKill8;

	private GameObject _oKill9;

	private GameObject _oKill10;

	private Text _oKillText1;

	private Text _oKillText2;

	private Text _oKillText3;

	private Text _oKillText4;

	private Text _oKillText5;

	private Text _oKillText6;

	private Text _oKillText7;

	private Text _oKillText8;

	private Text _oKillText9;

	private Text _oKillText10;

	private GameObject _oKnifeKill1;

	private GameObject _oKnifeKill2;

	private GameObject _oKnifeKill3;

	private GameObject _oKnifeKill4;

	private GameObject _oKnifeKill5;

	private GameObject _oKnifeKill6;

	private GameObject _oKnifeKill7;

	private GameObject _oKnifeKill8;

	private GameObject _oKnifeKill9;

	private GameObject _oKnifeKill10;

	private Text _oKnifeKillText1;

	private Text _oKnifeKillText2;

	private Text _oKnifeKillText3;

	private Text _oKnifeKillText4;

	private Text _oKnifeKillText5;

	private Text _oKnifeKillText6;

	private Text _oKnifeKillText7;

	private Text _oKnifeKillText8;

	private Text _oKnifeKillText9;

	private Text _oKnifeKillText10;

	private GameObject _oPing1;

	private GameObject _oPing2;

	private GameObject _oPing3;

	private GameObject _oPing4;

	private GameObject _oPing5;

	private GameObject _oPing6;

	private GameObject _oPing7;

	private GameObject _oPing8;

	private GameObject _oPing9;

	private GameObject _oPing10;

	private Text _oPingText1;

	private Text _oPingText2;

	private Text _oPingText3;

	private Text _oPingText4;

	private Text _oPingText5;

	private Text _oPingText6;

	private Text _oPingText7;

	private Text _oPingText8;

	private Text _oPingText9;

	private Text _oPingText10;

	private GameObject _oLevel1;

	private GameObject _oLevel2;

	private GameObject _oLevel3;

	private GameObject _oLevel4;

	private GameObject _oLevel5;

	private GameObject _oLevel6;

	private GameObject _oLevel7;

	private GameObject _oLevel8;

	private GameObject _oLevel9;

	private GameObject _oLevel10;

	private Text _oLevelText1;

	private Text _oLevelText2;

	private Text _oLevelText3;

	private Text _oLevelText4;

	private Text _oLevelText5;

	private Text _oLevelText6;

	private Text _oLevelText7;

	private Text _oLevelText8;

	private Text _oLevelText9;

	private Text _oLevelText10;

	private GameObject _oLoot1;

	private GameObject _oLoot2;

	private GameObject _oLoot3;

	private GameObject _oLoot4;

	private Image _oLootImage1;

	private Image _oLootImage2;

	private Image _oLootImage3;

	private Image _oLootImage4;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpgrescue";

	private string _resourceAssetName = "RpgRescueAllKillInfo";

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

	public string RoomNameString
	{
		get
		{
			if (_oRoomNameText != null)
			{
				return _oRoomNameText.text;
			}
			return null;
		}
		set
		{
			if (RoomNameString != value && _oRoomNameText != null)
			{
				_oRoomNameText.text = value;
			}
		}
	}

	public string PlayerCountString
	{
		get
		{
			if (_oPlayerCountText != null)
			{
				return _oPlayerCountText.text;
			}
			return null;
		}
		set
		{
			if (PlayerCountString != value && _oPlayerCountText != null)
			{
				_oPlayerCountText.text = value;
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

	public bool PlayerShow3
	{
		get
		{
			if (_oPlayer3 != null)
			{
				return _oPlayer3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow3 != value && _oPlayer3 != null)
			{
				_oPlayer3.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow4
	{
		get
		{
			if (_oPlayer4 != null)
			{
				return _oPlayer4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow4 != value && _oPlayer4 != null)
			{
				_oPlayer4.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow5
	{
		get
		{
			if (_oPlayer5 != null)
			{
				return _oPlayer5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow5 != value && _oPlayer5 != null)
			{
				_oPlayer5.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow6
	{
		get
		{
			if (_oPlayer6 != null)
			{
				return _oPlayer6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow6 != value && _oPlayer6 != null)
			{
				_oPlayer6.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow7
	{
		get
		{
			if (_oPlayer7 != null)
			{
				return _oPlayer7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow7 != value && _oPlayer7 != null)
			{
				_oPlayer7.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow8
	{
		get
		{
			if (_oPlayer8 != null)
			{
				return _oPlayer8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow8 != value && _oPlayer8 != null)
			{
				_oPlayer8.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow9
	{
		get
		{
			if (_oPlayer9 != null)
			{
				return _oPlayer9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow9 != value && _oPlayer9 != null)
			{
				_oPlayer9.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow10
	{
		get
		{
			if (_oPlayer10 != null)
			{
				return _oPlayer10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow10 != value && _oPlayer10 != null)
			{
				_oPlayer10.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow1
	{
		get
		{
			if (_oSelfBack1 != null)
			{
				return _oSelfBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow1 != value && _oSelfBack1 != null)
			{
				_oSelfBack1.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow2
	{
		get
		{
			if (_oSelfBack2 != null)
			{
				return _oSelfBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow2 != value && _oSelfBack2 != null)
			{
				_oSelfBack2.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow3
	{
		get
		{
			if (_oSelfBack3 != null)
			{
				return _oSelfBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow3 != value && _oSelfBack3 != null)
			{
				_oSelfBack3.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow4
	{
		get
		{
			if (_oSelfBack4 != null)
			{
				return _oSelfBack4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow4 != value && _oSelfBack4 != null)
			{
				_oSelfBack4.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow5
	{
		get
		{
			if (_oSelfBack5 != null)
			{
				return _oSelfBack5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow5 != value && _oSelfBack5 != null)
			{
				_oSelfBack5.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow6
	{
		get
		{
			if (_oSelfBack6 != null)
			{
				return _oSelfBack6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow6 != value && _oSelfBack6 != null)
			{
				_oSelfBack6.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow7
	{
		get
		{
			if (_oSelfBack7 != null)
			{
				return _oSelfBack7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow7 != value && _oSelfBack7 != null)
			{
				_oSelfBack7.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow8
	{
		get
		{
			if (_oSelfBack8 != null)
			{
				return _oSelfBack8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow8 != value && _oSelfBack8 != null)
			{
				_oSelfBack8.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow9
	{
		get
		{
			if (_oSelfBack9 != null)
			{
				return _oSelfBack9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow9 != value && _oSelfBack9 != null)
			{
				_oSelfBack9.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow10
	{
		get
		{
			if (_oSelfBack10 != null)
			{
				return _oSelfBack10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow10 != value && _oSelfBack10 != null)
			{
				_oSelfBack10.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow1
	{
		get
		{
			if (_oSelfTeam1 != null)
			{
				return _oSelfTeam1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow1 != value && _oSelfTeam1 != null)
			{
				_oSelfTeam1.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow2
	{
		get
		{
			if (_oSelfTeam2 != null)
			{
				return _oSelfTeam2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow2 != value && _oSelfTeam2 != null)
			{
				_oSelfTeam2.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow3
	{
		get
		{
			if (_oSelfTeam3 != null)
			{
				return _oSelfTeam3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow3 != value && _oSelfTeam3 != null)
			{
				_oSelfTeam3.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow4
	{
		get
		{
			if (_oSelfTeam4 != null)
			{
				return _oSelfTeam4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow4 != value && _oSelfTeam4 != null)
			{
				_oSelfTeam4.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow5
	{
		get
		{
			if (_oSelfTeam5 != null)
			{
				return _oSelfTeam5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow5 != value && _oSelfTeam5 != null)
			{
				_oSelfTeam5.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow6
	{
		get
		{
			if (_oSelfTeam6 != null)
			{
				return _oSelfTeam6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow6 != value && _oSelfTeam6 != null)
			{
				_oSelfTeam6.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow7
	{
		get
		{
			if (_oSelfTeam7 != null)
			{
				return _oSelfTeam7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow7 != value && _oSelfTeam7 != null)
			{
				_oSelfTeam7.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow8
	{
		get
		{
			if (_oSelfTeam8 != null)
			{
				return _oSelfTeam8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow8 != value && _oSelfTeam8 != null)
			{
				_oSelfTeam8.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow9
	{
		get
		{
			if (_oSelfTeam9 != null)
			{
				return _oSelfTeam9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow9 != value && _oSelfTeam9 != null)
			{
				_oSelfTeam9.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamShow10
	{
		get
		{
			if (_oSelfTeam10 != null)
			{
				return _oSelfTeam10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamShow10 != value && _oSelfTeam10 != null)
			{
				_oSelfTeam10.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow1
	{
		get
		{
			if (_oUnityFlag1 != null)
			{
				return _oUnityFlag1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow1 != value && _oUnityFlag1 != null)
			{
				_oUnityFlag1.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow2
	{
		get
		{
			if (_oUnityFlag2 != null)
			{
				return _oUnityFlag2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow2 != value && _oUnityFlag2 != null)
			{
				_oUnityFlag2.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow3
	{
		get
		{
			if (_oUnityFlag3 != null)
			{
				return _oUnityFlag3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow3 != value && _oUnityFlag3 != null)
			{
				_oUnityFlag3.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow4
	{
		get
		{
			if (_oUnityFlag4 != null)
			{
				return _oUnityFlag4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow4 != value && _oUnityFlag4 != null)
			{
				_oUnityFlag4.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow5
	{
		get
		{
			if (_oUnityFlag5 != null)
			{
				return _oUnityFlag5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow5 != value && _oUnityFlag5 != null)
			{
				_oUnityFlag5.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow6
	{
		get
		{
			if (_oUnityFlag6 != null)
			{
				return _oUnityFlag6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow6 != value && _oUnityFlag6 != null)
			{
				_oUnityFlag6.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow7
	{
		get
		{
			if (_oUnityFlag7 != null)
			{
				return _oUnityFlag7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow7 != value && _oUnityFlag7 != null)
			{
				_oUnityFlag7.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow8
	{
		get
		{
			if (_oUnityFlag8 != null)
			{
				return _oUnityFlag8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow8 != value && _oUnityFlag8 != null)
			{
				_oUnityFlag8.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow9
	{
		get
		{
			if (_oUnityFlag9 != null)
			{
				return _oUnityFlag9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow9 != value && _oUnityFlag9 != null)
			{
				_oUnityFlag9.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow10
	{
		get
		{
			if (_oUnityFlag10 != null)
			{
				return _oUnityFlag10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow10 != value && _oUnityFlag10 != null)
			{
				_oUnityFlag10.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow1
	{
		get
		{
			if (_oHonorary1 != null)
			{
				return _oHonorary1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow1 != value && _oHonorary1 != null)
			{
				_oHonorary1.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow2
	{
		get
		{
			if (_oHonorary2 != null)
			{
				return _oHonorary2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow2 != value && _oHonorary2 != null)
			{
				_oHonorary2.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow3
	{
		get
		{
			if (_oHonorary3 != null)
			{
				return _oHonorary3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow3 != value && _oHonorary3 != null)
			{
				_oHonorary3.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow4
	{
		get
		{
			if (_oHonorary4 != null)
			{
				return _oHonorary4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow4 != value && _oHonorary4 != null)
			{
				_oHonorary4.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow5
	{
		get
		{
			if (_oHonorary5 != null)
			{
				return _oHonorary5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow5 != value && _oHonorary5 != null)
			{
				_oHonorary5.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow6
	{
		get
		{
			if (_oHonorary6 != null)
			{
				return _oHonorary6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow6 != value && _oHonorary6 != null)
			{
				_oHonorary6.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow7
	{
		get
		{
			if (_oHonorary7 != null)
			{
				return _oHonorary7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow7 != value && _oHonorary7 != null)
			{
				_oHonorary7.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow8
	{
		get
		{
			if (_oHonorary8 != null)
			{
				return _oHonorary8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow8 != value && _oHonorary8 != null)
			{
				_oHonorary8.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow9
	{
		get
		{
			if (_oHonorary9 != null)
			{
				return _oHonorary9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow9 != value && _oHonorary9 != null)
			{
				_oHonorary9.SetObjectActive(value);
			}
		}
	}

	public bool HonoraryShow10
	{
		get
		{
			if (_oHonorary10 != null)
			{
				return _oHonorary10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonoraryShow10 != value && _oHonorary10 != null)
			{
				_oHonorary10.SetObjectActive(value);
			}
		}
	}

	public Sprite HonorarySprite1
	{
		get
		{
			if (_oHonoraryImage1 != null)
			{
				return _oHonoraryImage1.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite1 != value && _oHonoraryImage1 != null)
			{
				_oHonoraryImage1.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite2
	{
		get
		{
			if (_oHonoraryImage2 != null)
			{
				return _oHonoraryImage2.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite2 != value && _oHonoraryImage2 != null)
			{
				_oHonoraryImage2.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite3
	{
		get
		{
			if (_oHonoraryImage3 != null)
			{
				return _oHonoraryImage3.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite3 != value && _oHonoraryImage3 != null)
			{
				_oHonoraryImage3.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite4
	{
		get
		{
			if (_oHonoraryImage4 != null)
			{
				return _oHonoraryImage4.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite4 != value && _oHonoraryImage4 != null)
			{
				_oHonoraryImage4.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite5
	{
		get
		{
			if (_oHonoraryImage5 != null)
			{
				return _oHonoraryImage5.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite5 != value && _oHonoraryImage5 != null)
			{
				_oHonoraryImage5.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite6
	{
		get
		{
			if (_oHonoraryImage6 != null)
			{
				return _oHonoraryImage6.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite6 != value && _oHonoraryImage6 != null)
			{
				_oHonoraryImage6.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite7
	{
		get
		{
			if (_oHonoraryImage7 != null)
			{
				return _oHonoraryImage7.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite7 != value && _oHonoraryImage7 != null)
			{
				_oHonoraryImage7.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite8
	{
		get
		{
			if (_oHonoraryImage8 != null)
			{
				return _oHonoraryImage8.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite8 != value && _oHonoraryImage8 != null)
			{
				_oHonoraryImage8.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite9
	{
		get
		{
			if (_oHonoraryImage9 != null)
			{
				return _oHonoraryImage9.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite9 != value && _oHonoraryImage9 != null)
			{
				_oHonoraryImage9.sprite = value;
			}
		}
	}

	public Sprite HonorarySprite10
	{
		get
		{
			if (_oHonoraryImage10 != null)
			{
				return _oHonoraryImage10.sprite;
			}
			return null;
		}
		set
		{
			if (HonorarySprite10 != value && _oHonoraryImage10 != null)
			{
				_oHonoraryImage10.sprite = value;
			}
		}
	}

	public bool VipShow1
	{
		get
		{
			if (_oVip1 != null)
			{
				return _oVip1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow1 != value && _oVip1 != null)
			{
				_oVip1.SetObjectActive(value);
			}
		}
	}

	public bool VipShow2
	{
		get
		{
			if (_oVip2 != null)
			{
				return _oVip2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow2 != value && _oVip2 != null)
			{
				_oVip2.SetObjectActive(value);
			}
		}
	}

	public bool VipShow3
	{
		get
		{
			if (_oVip3 != null)
			{
				return _oVip3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow3 != value && _oVip3 != null)
			{
				_oVip3.SetObjectActive(value);
			}
		}
	}

	public bool VipShow4
	{
		get
		{
			if (_oVip4 != null)
			{
				return _oVip4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow4 != value && _oVip4 != null)
			{
				_oVip4.SetObjectActive(value);
			}
		}
	}

	public bool VipShow5
	{
		get
		{
			if (_oVip5 != null)
			{
				return _oVip5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow5 != value && _oVip5 != null)
			{
				_oVip5.SetObjectActive(value);
			}
		}
	}

	public bool VipShow6
	{
		get
		{
			if (_oVip6 != null)
			{
				return _oVip6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow6 != value && _oVip6 != null)
			{
				_oVip6.SetObjectActive(value);
			}
		}
	}

	public bool VipShow7
	{
		get
		{
			if (_oVip7 != null)
			{
				return _oVip7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow7 != value && _oVip7 != null)
			{
				_oVip7.SetObjectActive(value);
			}
		}
	}

	public bool VipShow8
	{
		get
		{
			if (_oVip8 != null)
			{
				return _oVip8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow8 != value && _oVip8 != null)
			{
				_oVip8.SetObjectActive(value);
			}
		}
	}

	public bool VipShow9
	{
		get
		{
			if (_oVip9 != null)
			{
				return _oVip9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow9 != value && _oVip9 != null)
			{
				_oVip9.SetObjectActive(value);
			}
		}
	}

	public bool VipShow10
	{
		get
		{
			if (_oVip10 != null)
			{
				return _oVip10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow10 != value && _oVip10 != null)
			{
				_oVip10.SetObjectActive(value);
			}
		}
	}

	public Sprite VipSprite1
	{
		get
		{
			if (_oVipImage1 != null)
			{
				return _oVipImage1.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite1 != value && _oVipImage1 != null)
			{
				_oVipImage1.sprite = value;
			}
		}
	}

	public Sprite VipSprite2
	{
		get
		{
			if (_oVipImage2 != null)
			{
				return _oVipImage2.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite2 != value && _oVipImage2 != null)
			{
				_oVipImage2.sprite = value;
			}
		}
	}

	public Sprite VipSprite3
	{
		get
		{
			if (_oVipImage3 != null)
			{
				return _oVipImage3.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite3 != value && _oVipImage3 != null)
			{
				_oVipImage3.sprite = value;
			}
		}
	}

	public Sprite VipSprite4
	{
		get
		{
			if (_oVipImage4 != null)
			{
				return _oVipImage4.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite4 != value && _oVipImage4 != null)
			{
				_oVipImage4.sprite = value;
			}
		}
	}

	public Sprite VipSprite5
	{
		get
		{
			if (_oVipImage5 != null)
			{
				return _oVipImage5.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite5 != value && _oVipImage5 != null)
			{
				_oVipImage5.sprite = value;
			}
		}
	}

	public Sprite VipSprite6
	{
		get
		{
			if (_oVipImage6 != null)
			{
				return _oVipImage6.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite6 != value && _oVipImage6 != null)
			{
				_oVipImage6.sprite = value;
			}
		}
	}

	public Sprite VipSprite7
	{
		get
		{
			if (_oVipImage7 != null)
			{
				return _oVipImage7.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite7 != value && _oVipImage7 != null)
			{
				_oVipImage7.sprite = value;
			}
		}
	}

	public Sprite VipSprite8
	{
		get
		{
			if (_oVipImage8 != null)
			{
				return _oVipImage8.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite8 != value && _oVipImage8 != null)
			{
				_oVipImage8.sprite = value;
			}
		}
	}

	public Sprite VipSprite9
	{
		get
		{
			if (_oVipImage9 != null)
			{
				return _oVipImage9.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite9 != value && _oVipImage9 != null)
			{
				_oVipImage9.sprite = value;
			}
		}
	}

	public Sprite VipSprite10
	{
		get
		{
			if (_oVipImage10 != null)
			{
				return _oVipImage10.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite10 != value && _oVipImage10 != null)
			{
				_oVipImage10.sprite = value;
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

	public bool DeadShow9
	{
		get
		{
			if (_oDead9 != null)
			{
				return _oDead9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow9 != value && _oDead9 != null)
			{
				_oDead9.SetObjectActive(value);
			}
		}
	}

	public bool DeadShow10
	{
		get
		{
			if (_oDead10 != null)
			{
				return _oDead10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadShow10 != value && _oDead10 != null)
			{
				_oDead10.SetObjectActive(value);
			}
		}
	}

	public string TeamNameString1
	{
		get
		{
			if (_oTeamNameText1 != null)
			{
				return _oTeamNameText1.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString1 != value && _oTeamNameText1 != null)
			{
				_oTeamNameText1.text = value;
			}
		}
	}

	public string TeamNameString2
	{
		get
		{
			if (_oTeamNameText2 != null)
			{
				return _oTeamNameText2.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString2 != value && _oTeamNameText2 != null)
			{
				_oTeamNameText2.text = value;
			}
		}
	}

	public string TeamNameString3
	{
		get
		{
			if (_oTeamNameText3 != null)
			{
				return _oTeamNameText3.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString3 != value && _oTeamNameText3 != null)
			{
				_oTeamNameText3.text = value;
			}
		}
	}

	public string TeamNameString4
	{
		get
		{
			if (_oTeamNameText4 != null)
			{
				return _oTeamNameText4.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString4 != value && _oTeamNameText4 != null)
			{
				_oTeamNameText4.text = value;
			}
		}
	}

	public string TeamNameString5
	{
		get
		{
			if (_oTeamNameText5 != null)
			{
				return _oTeamNameText5.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString5 != value && _oTeamNameText5 != null)
			{
				_oTeamNameText5.text = value;
			}
		}
	}

	public string TeamNameString6
	{
		get
		{
			if (_oTeamNameText6 != null)
			{
				return _oTeamNameText6.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString6 != value && _oTeamNameText6 != null)
			{
				_oTeamNameText6.text = value;
			}
		}
	}

	public string TeamNameString7
	{
		get
		{
			if (_oTeamNameText7 != null)
			{
				return _oTeamNameText7.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString7 != value && _oTeamNameText7 != null)
			{
				_oTeamNameText7.text = value;
			}
		}
	}

	public string TeamNameString8
	{
		get
		{
			if (_oTeamNameText8 != null)
			{
				return _oTeamNameText8.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString8 != value && _oTeamNameText8 != null)
			{
				_oTeamNameText8.text = value;
			}
		}
	}

	public string TeamNameString9
	{
		get
		{
			if (_oTeamNameText9 != null)
			{
				return _oTeamNameText9.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString9 != value && _oTeamNameText9 != null)
			{
				_oTeamNameText9.text = value;
			}
		}
	}

	public string TeamNameString10
	{
		get
		{
			if (_oTeamNameText10 != null)
			{
				return _oTeamNameText10.text;
			}
			return null;
		}
		set
		{
			if (TeamNameString10 != value && _oTeamNameText10 != null)
			{
				_oTeamNameText10.text = value;
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

	public string KillString1
	{
		get
		{
			if (_oKillText1 != null)
			{
				return _oKillText1.text;
			}
			return null;
		}
		set
		{
			if (KillString1 != value && _oKillText1 != null)
			{
				_oKillText1.text = value;
			}
		}
	}

	public string KillString2
	{
		get
		{
			if (_oKillText2 != null)
			{
				return _oKillText2.text;
			}
			return null;
		}
		set
		{
			if (KillString2 != value && _oKillText2 != null)
			{
				_oKillText2.text = value;
			}
		}
	}

	public string KillString3
	{
		get
		{
			if (_oKillText3 != null)
			{
				return _oKillText3.text;
			}
			return null;
		}
		set
		{
			if (KillString3 != value && _oKillText3 != null)
			{
				_oKillText3.text = value;
			}
		}
	}

	public string KillString4
	{
		get
		{
			if (_oKillText4 != null)
			{
				return _oKillText4.text;
			}
			return null;
		}
		set
		{
			if (KillString4 != value && _oKillText4 != null)
			{
				_oKillText4.text = value;
			}
		}
	}

	public string KillString5
	{
		get
		{
			if (_oKillText5 != null)
			{
				return _oKillText5.text;
			}
			return null;
		}
		set
		{
			if (KillString5 != value && _oKillText5 != null)
			{
				_oKillText5.text = value;
			}
		}
	}

	public string KillString6
	{
		get
		{
			if (_oKillText6 != null)
			{
				return _oKillText6.text;
			}
			return null;
		}
		set
		{
			if (KillString6 != value && _oKillText6 != null)
			{
				_oKillText6.text = value;
			}
		}
	}

	public string KillString7
	{
		get
		{
			if (_oKillText7 != null)
			{
				return _oKillText7.text;
			}
			return null;
		}
		set
		{
			if (KillString7 != value && _oKillText7 != null)
			{
				_oKillText7.text = value;
			}
		}
	}

	public string KillString8
	{
		get
		{
			if (_oKillText8 != null)
			{
				return _oKillText8.text;
			}
			return null;
		}
		set
		{
			if (KillString8 != value && _oKillText8 != null)
			{
				_oKillText8.text = value;
			}
		}
	}

	public string KillString9
	{
		get
		{
			if (_oKillText9 != null)
			{
				return _oKillText9.text;
			}
			return null;
		}
		set
		{
			if (KillString9 != value && _oKillText9 != null)
			{
				_oKillText9.text = value;
			}
		}
	}

	public string KillString10
	{
		get
		{
			if (_oKillText10 != null)
			{
				return _oKillText10.text;
			}
			return null;
		}
		set
		{
			if (KillString10 != value && _oKillText10 != null)
			{
				_oKillText10.text = value;
			}
		}
	}

	public string KnifeKillString1
	{
		get
		{
			if (_oKnifeKillText1 != null)
			{
				return _oKnifeKillText1.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString1 != value && _oKnifeKillText1 != null)
			{
				_oKnifeKillText1.text = value;
			}
		}
	}

	public string KnifeKillString2
	{
		get
		{
			if (_oKnifeKillText2 != null)
			{
				return _oKnifeKillText2.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString2 != value && _oKnifeKillText2 != null)
			{
				_oKnifeKillText2.text = value;
			}
		}
	}

	public string KnifeKillString3
	{
		get
		{
			if (_oKnifeKillText3 != null)
			{
				return _oKnifeKillText3.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString3 != value && _oKnifeKillText3 != null)
			{
				_oKnifeKillText3.text = value;
			}
		}
	}

	public string KnifeKillString4
	{
		get
		{
			if (_oKnifeKillText4 != null)
			{
				return _oKnifeKillText4.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString4 != value && _oKnifeKillText4 != null)
			{
				_oKnifeKillText4.text = value;
			}
		}
	}

	public string KnifeKillString5
	{
		get
		{
			if (_oKnifeKillText5 != null)
			{
				return _oKnifeKillText5.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString5 != value && _oKnifeKillText5 != null)
			{
				_oKnifeKillText5.text = value;
			}
		}
	}

	public string KnifeKillString6
	{
		get
		{
			if (_oKnifeKillText6 != null)
			{
				return _oKnifeKillText6.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString6 != value && _oKnifeKillText6 != null)
			{
				_oKnifeKillText6.text = value;
			}
		}
	}

	public string KnifeKillString7
	{
		get
		{
			if (_oKnifeKillText7 != null)
			{
				return _oKnifeKillText7.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString7 != value && _oKnifeKillText7 != null)
			{
				_oKnifeKillText7.text = value;
			}
		}
	}

	public string KnifeKillString8
	{
		get
		{
			if (_oKnifeKillText8 != null)
			{
				return _oKnifeKillText8.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString8 != value && _oKnifeKillText8 != null)
			{
				_oKnifeKillText8.text = value;
			}
		}
	}

	public string KnifeKillString9
	{
		get
		{
			if (_oKnifeKillText9 != null)
			{
				return _oKnifeKillText9.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString9 != value && _oKnifeKillText9 != null)
			{
				_oKnifeKillText9.text = value;
			}
		}
	}

	public string KnifeKillString10
	{
		get
		{
			if (_oKnifeKillText10 != null)
			{
				return _oKnifeKillText10.text;
			}
			return null;
		}
		set
		{
			if (KnifeKillString10 != value && _oKnifeKillText10 != null)
			{
				_oKnifeKillText10.text = value;
			}
		}
	}

	public string PingString1
	{
		get
		{
			if (_oPingText1 != null)
			{
				return _oPingText1.text;
			}
			return null;
		}
		set
		{
			if (PingString1 != value && _oPingText1 != null)
			{
				_oPingText1.text = value;
			}
		}
	}

	public string PingString2
	{
		get
		{
			if (_oPingText2 != null)
			{
				return _oPingText2.text;
			}
			return null;
		}
		set
		{
			if (PingString2 != value && _oPingText2 != null)
			{
				_oPingText2.text = value;
			}
		}
	}

	public string PingString3
	{
		get
		{
			if (_oPingText3 != null)
			{
				return _oPingText3.text;
			}
			return null;
		}
		set
		{
			if (PingString3 != value && _oPingText3 != null)
			{
				_oPingText3.text = value;
			}
		}
	}

	public string PingString4
	{
		get
		{
			if (_oPingText4 != null)
			{
				return _oPingText4.text;
			}
			return null;
		}
		set
		{
			if (PingString4 != value && _oPingText4 != null)
			{
				_oPingText4.text = value;
			}
		}
	}

	public string PingString5
	{
		get
		{
			if (_oPingText5 != null)
			{
				return _oPingText5.text;
			}
			return null;
		}
		set
		{
			if (PingString5 != value && _oPingText5 != null)
			{
				_oPingText5.text = value;
			}
		}
	}

	public string PingString6
	{
		get
		{
			if (_oPingText6 != null)
			{
				return _oPingText6.text;
			}
			return null;
		}
		set
		{
			if (PingString6 != value && _oPingText6 != null)
			{
				_oPingText6.text = value;
			}
		}
	}

	public string PingString7
	{
		get
		{
			if (_oPingText7 != null)
			{
				return _oPingText7.text;
			}
			return null;
		}
		set
		{
			if (PingString7 != value && _oPingText7 != null)
			{
				_oPingText7.text = value;
			}
		}
	}

	public string PingString8
	{
		get
		{
			if (_oPingText8 != null)
			{
				return _oPingText8.text;
			}
			return null;
		}
		set
		{
			if (PingString8 != value && _oPingText8 != null)
			{
				_oPingText8.text = value;
			}
		}
	}

	public string PingString9
	{
		get
		{
			if (_oPingText9 != null)
			{
				return _oPingText9.text;
			}
			return null;
		}
		set
		{
			if (PingString9 != value && _oPingText9 != null)
			{
				_oPingText9.text = value;
			}
		}
	}

	public string PingString10
	{
		get
		{
			if (_oPingText10 != null)
			{
				return _oPingText10.text;
			}
			return null;
		}
		set
		{
			if (PingString10 != value && _oPingText10 != null)
			{
				_oPingText10.text = value;
			}
		}
	}

	public string LevelString1
	{
		get
		{
			if (_oLevelText1 != null)
			{
				return _oLevelText1.text;
			}
			return null;
		}
		set
		{
			if (LevelString1 != value && _oLevelText1 != null)
			{
				_oLevelText1.text = value;
			}
		}
	}

	public string LevelString2
	{
		get
		{
			if (_oLevelText2 != null)
			{
				return _oLevelText2.text;
			}
			return null;
		}
		set
		{
			if (LevelString2 != value && _oLevelText2 != null)
			{
				_oLevelText2.text = value;
			}
		}
	}

	public string LevelString3
	{
		get
		{
			if (_oLevelText3 != null)
			{
				return _oLevelText3.text;
			}
			return null;
		}
		set
		{
			if (LevelString3 != value && _oLevelText3 != null)
			{
				_oLevelText3.text = value;
			}
		}
	}

	public string LevelString4
	{
		get
		{
			if (_oLevelText4 != null)
			{
				return _oLevelText4.text;
			}
			return null;
		}
		set
		{
			if (LevelString4 != value && _oLevelText4 != null)
			{
				_oLevelText4.text = value;
			}
		}
	}

	public string LevelString5
	{
		get
		{
			if (_oLevelText5 != null)
			{
				return _oLevelText5.text;
			}
			return null;
		}
		set
		{
			if (LevelString5 != value && _oLevelText5 != null)
			{
				_oLevelText5.text = value;
			}
		}
	}

	public string LevelString6
	{
		get
		{
			if (_oLevelText6 != null)
			{
				return _oLevelText6.text;
			}
			return null;
		}
		set
		{
			if (LevelString6 != value && _oLevelText6 != null)
			{
				_oLevelText6.text = value;
			}
		}
	}

	public string LevelString7
	{
		get
		{
			if (_oLevelText7 != null)
			{
				return _oLevelText7.text;
			}
			return null;
		}
		set
		{
			if (LevelString7 != value && _oLevelText7 != null)
			{
				_oLevelText7.text = value;
			}
		}
	}

	public string LevelString8
	{
		get
		{
			if (_oLevelText8 != null)
			{
				return _oLevelText8.text;
			}
			return null;
		}
		set
		{
			if (LevelString8 != value && _oLevelText8 != null)
			{
				_oLevelText8.text = value;
			}
		}
	}

	public string LevelString9
	{
		get
		{
			if (_oLevelText9 != null)
			{
				return _oLevelText9.text;
			}
			return null;
		}
		set
		{
			if (LevelString9 != value && _oLevelText9 != null)
			{
				_oLevelText9.text = value;
			}
		}
	}

	public string LevelString10
	{
		get
		{
			if (_oLevelText10 != null)
			{
				return _oLevelText10.text;
			}
			return null;
		}
		set
		{
			if (LevelString10 != value && _oLevelText10 != null)
			{
				_oLevelText10.text = value;
			}
		}
	}

	public bool LootShow1
	{
		get
		{
			if (_oLoot1 != null)
			{
				return _oLoot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow1 != value && _oLoot1 != null)
			{
				_oLoot1.SetObjectActive(value);
			}
		}
	}

	public bool LootShow2
	{
		get
		{
			if (_oLoot2 != null)
			{
				return _oLoot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow2 != value && _oLoot2 != null)
			{
				_oLoot2.SetObjectActive(value);
			}
		}
	}

	public bool LootShow3
	{
		get
		{
			if (_oLoot3 != null)
			{
				return _oLoot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow3 != value && _oLoot3 != null)
			{
				_oLoot3.SetObjectActive(value);
			}
		}
	}

	public bool LootShow4
	{
		get
		{
			if (_oLoot4 != null)
			{
				return _oLoot4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow4 != value && _oLoot4 != null)
			{
				_oLoot4.SetObjectActive(value);
			}
		}
	}

	public Sprite LootSprite1
	{
		get
		{
			if (_oLootImage1 != null)
			{
				return _oLootImage1.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite1 != value && _oLootImage1 != null)
			{
				_oLootImage1.sprite = value;
			}
		}
	}

	public Sprite LootSprite2
	{
		get
		{
			if (_oLootImage2 != null)
			{
				return _oLootImage2.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite2 != value && _oLootImage2 != null)
			{
				_oLootImage2.sprite = value;
			}
		}
	}

	public Sprite LootSprite3
	{
		get
		{
			if (_oLootImage3 != null)
			{
				return _oLootImage3.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite3 != value && _oLootImage3 != null)
			{
				_oLootImage3.sprite = value;
			}
		}
	}

	public Sprite LootSprite4
	{
		get
		{
			if (_oLootImage4 != null)
			{
				return _oLootImage4.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite4 != value && _oLootImage4 != null)
			{
				_oLootImage4.sprite = value;
			}
		}
	}

	public Sprite TitleSprite
	{
		get
		{
			if (_oTitleImage != null)
			{
				return _oTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite != value && _oTitleImage != null)
			{
				_oTitleImage.sprite = value;
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
			case "RoomName":
				_oRoomName = transform.gameObject;
				_oRoomNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerCount":
				_oPlayerCount = transform.gameObject;
				_oPlayerCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "Player1":
				_oPlayer1 = transform.gameObject;
				break;
			case "Player2":
				_oPlayer2 = transform.gameObject;
				break;
			case "Player3":
				_oPlayer3 = transform.gameObject;
				break;
			case "Player4":
				_oPlayer4 = transform.gameObject;
				break;
			case "Player5":
				_oPlayer5 = transform.gameObject;
				break;
			case "Player6":
				_oPlayer6 = transform.gameObject;
				break;
			case "Player7":
				_oPlayer7 = transform.gameObject;
				break;
			case "Player8":
				_oPlayer8 = transform.gameObject;
				break;
			case "Player9":
				_oPlayer9 = transform.gameObject;
				break;
			case "Player10":
				_oPlayer10 = transform.gameObject;
				break;
			case "SelfBack1":
				_oSelfBack1 = transform.gameObject;
				break;
			case "SelfBack2":
				_oSelfBack2 = transform.gameObject;
				break;
			case "SelfBack3":
				_oSelfBack3 = transform.gameObject;
				break;
			case "SelfBack4":
				_oSelfBack4 = transform.gameObject;
				break;
			case "SelfBack5":
				_oSelfBack5 = transform.gameObject;
				break;
			case "SelfBack6":
				_oSelfBack6 = transform.gameObject;
				break;
			case "SelfBack7":
				_oSelfBack7 = transform.gameObject;
				break;
			case "SelfBack8":
				_oSelfBack8 = transform.gameObject;
				break;
			case "SelfBack9":
				_oSelfBack9 = transform.gameObject;
				break;
			case "SelfBack10":
				_oSelfBack10 = transform.gameObject;
				break;
			case "SelfTeam1":
				_oSelfTeam1 = transform.gameObject;
				break;
			case "SelfTeam2":
				_oSelfTeam2 = transform.gameObject;
				break;
			case "SelfTeam3":
				_oSelfTeam3 = transform.gameObject;
				break;
			case "SelfTeam4":
				_oSelfTeam4 = transform.gameObject;
				break;
			case "SelfTeam5":
				_oSelfTeam5 = transform.gameObject;
				break;
			case "SelfTeam6":
				_oSelfTeam6 = transform.gameObject;
				break;
			case "SelfTeam7":
				_oSelfTeam7 = transform.gameObject;
				break;
			case "SelfTeam8":
				_oSelfTeam8 = transform.gameObject;
				break;
			case "SelfTeam9":
				_oSelfTeam9 = transform.gameObject;
				break;
			case "SelfTeam10":
				_oSelfTeam10 = transform.gameObject;
				break;
			case "UnityFlag1":
				_oUnityFlag1 = transform.gameObject;
				break;
			case "UnityFlag2":
				_oUnityFlag2 = transform.gameObject;
				break;
			case "UnityFlag3":
				_oUnityFlag3 = transform.gameObject;
				break;
			case "UnityFlag4":
				_oUnityFlag4 = transform.gameObject;
				break;
			case "UnityFlag5":
				_oUnityFlag5 = transform.gameObject;
				break;
			case "UnityFlag6":
				_oUnityFlag6 = transform.gameObject;
				break;
			case "UnityFlag7":
				_oUnityFlag7 = transform.gameObject;
				break;
			case "UnityFlag8":
				_oUnityFlag8 = transform.gameObject;
				break;
			case "UnityFlag9":
				_oUnityFlag9 = transform.gameObject;
				break;
			case "UnityFlag10":
				_oUnityFlag10 = transform.gameObject;
				break;
			case "Honorary1":
				_oHonorary1 = transform.gameObject;
				_oHonoraryImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary2":
				_oHonorary2 = transform.gameObject;
				_oHonoraryImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary3":
				_oHonorary3 = transform.gameObject;
				_oHonoraryImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary4":
				_oHonorary4 = transform.gameObject;
				_oHonoraryImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary5":
				_oHonorary5 = transform.gameObject;
				_oHonoraryImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary6":
				_oHonorary6 = transform.gameObject;
				_oHonoraryImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary7":
				_oHonorary7 = transform.gameObject;
				_oHonoraryImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary8":
				_oHonorary8 = transform.gameObject;
				_oHonoraryImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary9":
				_oHonorary9 = transform.gameObject;
				_oHonoraryImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Honorary10":
				_oHonorary10 = transform.gameObject;
				_oHonoraryImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip1":
				_oVip1 = transform.gameObject;
				_oVipImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip2":
				_oVip2 = transform.gameObject;
				_oVipImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip3":
				_oVip3 = transform.gameObject;
				_oVipImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip4":
				_oVip4 = transform.gameObject;
				_oVipImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip5":
				_oVip5 = transform.gameObject;
				_oVipImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip6":
				_oVip6 = transform.gameObject;
				_oVipImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip7":
				_oVip7 = transform.gameObject;
				_oVipImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip8":
				_oVip8 = transform.gameObject;
				_oVipImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip9":
				_oVip9 = transform.gameObject;
				_oVipImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip10":
				_oVip10 = transform.gameObject;
				_oVipImage10 = transform.gameObject.GetComponent<Image>();
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
			case "Dead9":
				_oDead9 = transform.gameObject;
				break;
			case "Dead10":
				_oDead10 = transform.gameObject;
				break;
			case "TeamName1":
				_oTeamName1 = transform.gameObject;
				_oTeamNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName2":
				_oTeamName2 = transform.gameObject;
				_oTeamNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName3":
				_oTeamName3 = transform.gameObject;
				_oTeamNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName4":
				_oTeamName4 = transform.gameObject;
				_oTeamNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName5":
				_oTeamName5 = transform.gameObject;
				_oTeamNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName6":
				_oTeamName6 = transform.gameObject;
				_oTeamNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName7":
				_oTeamName7 = transform.gameObject;
				_oTeamNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName8":
				_oTeamName8 = transform.gameObject;
				_oTeamNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName9":
				_oTeamName9 = transform.gameObject;
				_oTeamNameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamName10":
				_oTeamName10 = transform.gameObject;
				_oTeamNameText10 = transform.gameObject.GetComponent<Text>();
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
			case "Kill1":
				_oKill1 = transform.gameObject;
				_oKillText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill2":
				_oKill2 = transform.gameObject;
				_oKillText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill3":
				_oKill3 = transform.gameObject;
				_oKillText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill4":
				_oKill4 = transform.gameObject;
				_oKillText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill5":
				_oKill5 = transform.gameObject;
				_oKillText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill6":
				_oKill6 = transform.gameObject;
				_oKillText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill7":
				_oKill7 = transform.gameObject;
				_oKillText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill8":
				_oKill8 = transform.gameObject;
				_oKillText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill9":
				_oKill9 = transform.gameObject;
				_oKillText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Kill10":
				_oKill10 = transform.gameObject;
				_oKillText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill1":
				_oKnifeKill1 = transform.gameObject;
				_oKnifeKillText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill2":
				_oKnifeKill2 = transform.gameObject;
				_oKnifeKillText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill3":
				_oKnifeKill3 = transform.gameObject;
				_oKnifeKillText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill4":
				_oKnifeKill4 = transform.gameObject;
				_oKnifeKillText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill5":
				_oKnifeKill5 = transform.gameObject;
				_oKnifeKillText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill6":
				_oKnifeKill6 = transform.gameObject;
				_oKnifeKillText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill7":
				_oKnifeKill7 = transform.gameObject;
				_oKnifeKillText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill8":
				_oKnifeKill8 = transform.gameObject;
				_oKnifeKillText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill9":
				_oKnifeKill9 = transform.gameObject;
				_oKnifeKillText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "KnifeKill10":
				_oKnifeKill10 = transform.gameObject;
				_oKnifeKillText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping1":
				_oPing1 = transform.gameObject;
				_oPingText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping2":
				_oPing2 = transform.gameObject;
				_oPingText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping3":
				_oPing3 = transform.gameObject;
				_oPingText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping4":
				_oPing4 = transform.gameObject;
				_oPingText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping5":
				_oPing5 = transform.gameObject;
				_oPingText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping6":
				_oPing6 = transform.gameObject;
				_oPingText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping7":
				_oPing7 = transform.gameObject;
				_oPingText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping8":
				_oPing8 = transform.gameObject;
				_oPingText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping9":
				_oPing9 = transform.gameObject;
				_oPingText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Ping10":
				_oPing10 = transform.gameObject;
				_oPingText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level1":
				_oLevel1 = transform.gameObject;
				_oLevelText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level2":
				_oLevel2 = transform.gameObject;
				_oLevelText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level3":
				_oLevel3 = transform.gameObject;
				_oLevelText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level4":
				_oLevel4 = transform.gameObject;
				_oLevelText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level5":
				_oLevel5 = transform.gameObject;
				_oLevelText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level6":
				_oLevel6 = transform.gameObject;
				_oLevelText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level7":
				_oLevel7 = transform.gameObject;
				_oLevelText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level8":
				_oLevel8 = transform.gameObject;
				_oLevelText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level9":
				_oLevel9 = transform.gameObject;
				_oLevelText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Level10":
				_oLevel10 = transform.gameObject;
				_oLevelText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Loot1":
				_oLoot1 = transform.gameObject;
				_oLootImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot2":
				_oLoot2 = transform.gameObject;
				_oLootImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot3":
				_oLoot3 = transform.gameObject;
				_oLootImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot4":
				_oLoot4 = transform.gameObject;
				_oLootImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
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
			3 => PlayerShow3, 
			4 => PlayerShow4, 
			5 => PlayerShow5, 
			6 => PlayerShow6, 
			7 => PlayerShow7, 
			8 => PlayerShow8, 
			9 => PlayerShow9, 
			10 => PlayerShow10, 
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
		case 3:
			PlayerShow3 = value;
			break;
		case 4:
			PlayerShow4 = value;
			break;
		case 5:
			PlayerShow5 = value;
			break;
		case 6:
			PlayerShow6 = value;
			break;
		case 7:
			PlayerShow7 = value;
			break;
		case 8:
			PlayerShow8 = value;
			break;
		case 9:
			PlayerShow9 = value;
			break;
		case 10:
			PlayerShow10 = value;
			break;
		}
	}

	public bool GetSelfBackShow(int index)
	{
		return index switch
		{
			1 => SelfBackShow1, 
			2 => SelfBackShow2, 
			3 => SelfBackShow3, 
			4 => SelfBackShow4, 
			5 => SelfBackShow5, 
			6 => SelfBackShow6, 
			7 => SelfBackShow7, 
			8 => SelfBackShow8, 
			9 => SelfBackShow9, 
			10 => SelfBackShow10, 
			_ => false, 
		};
	}

	public void SetSelfBackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelfBackShow1 = value;
			break;
		case 2:
			SelfBackShow2 = value;
			break;
		case 3:
			SelfBackShow3 = value;
			break;
		case 4:
			SelfBackShow4 = value;
			break;
		case 5:
			SelfBackShow5 = value;
			break;
		case 6:
			SelfBackShow6 = value;
			break;
		case 7:
			SelfBackShow7 = value;
			break;
		case 8:
			SelfBackShow8 = value;
			break;
		case 9:
			SelfBackShow9 = value;
			break;
		case 10:
			SelfBackShow10 = value;
			break;
		}
	}

	public bool GetSelfTeamShow(int index)
	{
		return index switch
		{
			1 => SelfTeamShow1, 
			2 => SelfTeamShow2, 
			3 => SelfTeamShow3, 
			4 => SelfTeamShow4, 
			5 => SelfTeamShow5, 
			6 => SelfTeamShow6, 
			7 => SelfTeamShow7, 
			8 => SelfTeamShow8, 
			9 => SelfTeamShow9, 
			10 => SelfTeamShow10, 
			_ => false, 
		};
	}

	public void SetSelfTeamShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelfTeamShow1 = value;
			break;
		case 2:
			SelfTeamShow2 = value;
			break;
		case 3:
			SelfTeamShow3 = value;
			break;
		case 4:
			SelfTeamShow4 = value;
			break;
		case 5:
			SelfTeamShow5 = value;
			break;
		case 6:
			SelfTeamShow6 = value;
			break;
		case 7:
			SelfTeamShow7 = value;
			break;
		case 8:
			SelfTeamShow8 = value;
			break;
		case 9:
			SelfTeamShow9 = value;
			break;
		case 10:
			SelfTeamShow10 = value;
			break;
		}
	}

	public bool GetUnityFlagShow(int index)
	{
		return index switch
		{
			1 => UnityFlagShow1, 
			2 => UnityFlagShow2, 
			3 => UnityFlagShow3, 
			4 => UnityFlagShow4, 
			5 => UnityFlagShow5, 
			6 => UnityFlagShow6, 
			7 => UnityFlagShow7, 
			8 => UnityFlagShow8, 
			9 => UnityFlagShow9, 
			10 => UnityFlagShow10, 
			_ => false, 
		};
	}

	public void SetUnityFlagShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			UnityFlagShow1 = value;
			break;
		case 2:
			UnityFlagShow2 = value;
			break;
		case 3:
			UnityFlagShow3 = value;
			break;
		case 4:
			UnityFlagShow4 = value;
			break;
		case 5:
			UnityFlagShow5 = value;
			break;
		case 6:
			UnityFlagShow6 = value;
			break;
		case 7:
			UnityFlagShow7 = value;
			break;
		case 8:
			UnityFlagShow8 = value;
			break;
		case 9:
			UnityFlagShow9 = value;
			break;
		case 10:
			UnityFlagShow10 = value;
			break;
		}
	}

	public bool GetHonoraryShow(int index)
	{
		return index switch
		{
			1 => HonoraryShow1, 
			2 => HonoraryShow2, 
			3 => HonoraryShow3, 
			4 => HonoraryShow4, 
			5 => HonoraryShow5, 
			6 => HonoraryShow6, 
			7 => HonoraryShow7, 
			8 => HonoraryShow8, 
			9 => HonoraryShow9, 
			10 => HonoraryShow10, 
			_ => false, 
		};
	}

	public void SetHonoraryShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HonoraryShow1 = value;
			break;
		case 2:
			HonoraryShow2 = value;
			break;
		case 3:
			HonoraryShow3 = value;
			break;
		case 4:
			HonoraryShow4 = value;
			break;
		case 5:
			HonoraryShow5 = value;
			break;
		case 6:
			HonoraryShow6 = value;
			break;
		case 7:
			HonoraryShow7 = value;
			break;
		case 8:
			HonoraryShow8 = value;
			break;
		case 9:
			HonoraryShow9 = value;
			break;
		case 10:
			HonoraryShow10 = value;
			break;
		}
	}

	public Sprite GetHonorarySprite(int index)
	{
		return index switch
		{
			1 => HonorarySprite1, 
			2 => HonorarySprite2, 
			3 => HonorarySprite3, 
			4 => HonorarySprite4, 
			5 => HonorarySprite5, 
			6 => HonorarySprite6, 
			7 => HonorarySprite7, 
			8 => HonorarySprite8, 
			9 => HonorarySprite9, 
			10 => HonorarySprite10, 
			_ => null, 
		};
	}

	public void SetHonorarySprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			HonorarySprite1 = value;
			break;
		case 2:
			HonorarySprite2 = value;
			break;
		case 3:
			HonorarySprite3 = value;
			break;
		case 4:
			HonorarySprite4 = value;
			break;
		case 5:
			HonorarySprite5 = value;
			break;
		case 6:
			HonorarySprite6 = value;
			break;
		case 7:
			HonorarySprite7 = value;
			break;
		case 8:
			HonorarySprite8 = value;
			break;
		case 9:
			HonorarySprite9 = value;
			break;
		case 10:
			HonorarySprite10 = value;
			break;
		}
	}

	public bool GetVipShow(int index)
	{
		return index switch
		{
			1 => VipShow1, 
			2 => VipShow2, 
			3 => VipShow3, 
			4 => VipShow4, 
			5 => VipShow5, 
			6 => VipShow6, 
			7 => VipShow7, 
			8 => VipShow8, 
			9 => VipShow9, 
			10 => VipShow10, 
			_ => false, 
		};
	}

	public void SetVipShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			VipShow1 = value;
			break;
		case 2:
			VipShow2 = value;
			break;
		case 3:
			VipShow3 = value;
			break;
		case 4:
			VipShow4 = value;
			break;
		case 5:
			VipShow5 = value;
			break;
		case 6:
			VipShow6 = value;
			break;
		case 7:
			VipShow7 = value;
			break;
		case 8:
			VipShow8 = value;
			break;
		case 9:
			VipShow9 = value;
			break;
		case 10:
			VipShow10 = value;
			break;
		}
	}

	public Sprite GetVipSprite(int index)
	{
		return index switch
		{
			1 => VipSprite1, 
			2 => VipSprite2, 
			3 => VipSprite3, 
			4 => VipSprite4, 
			5 => VipSprite5, 
			6 => VipSprite6, 
			7 => VipSprite7, 
			8 => VipSprite8, 
			9 => VipSprite9, 
			10 => VipSprite10, 
			_ => null, 
		};
	}

	public void SetVipSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			VipSprite1 = value;
			break;
		case 2:
			VipSprite2 = value;
			break;
		case 3:
			VipSprite3 = value;
			break;
		case 4:
			VipSprite4 = value;
			break;
		case 5:
			VipSprite5 = value;
			break;
		case 6:
			VipSprite6 = value;
			break;
		case 7:
			VipSprite7 = value;
			break;
		case 8:
			VipSprite8 = value;
			break;
		case 9:
			VipSprite9 = value;
			break;
		case 10:
			VipSprite10 = value;
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
			9 => DeadShow9, 
			10 => DeadShow10, 
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
		case 9:
			DeadShow9 = value;
			break;
		case 10:
			DeadShow10 = value;
			break;
		}
	}

	public string GetTeamNameString(int index)
	{
		return index switch
		{
			1 => TeamNameString1, 
			2 => TeamNameString2, 
			3 => TeamNameString3, 
			4 => TeamNameString4, 
			5 => TeamNameString5, 
			6 => TeamNameString6, 
			7 => TeamNameString7, 
			8 => TeamNameString8, 
			9 => TeamNameString9, 
			10 => TeamNameString10, 
			_ => null, 
		};
	}

	public void SetTeamNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TeamNameString1 = value;
			break;
		case 2:
			TeamNameString2 = value;
			break;
		case 3:
			TeamNameString3 = value;
			break;
		case 4:
			TeamNameString4 = value;
			break;
		case 5:
			TeamNameString5 = value;
			break;
		case 6:
			TeamNameString6 = value;
			break;
		case 7:
			TeamNameString7 = value;
			break;
		case 8:
			TeamNameString8 = value;
			break;
		case 9:
			TeamNameString9 = value;
			break;
		case 10:
			TeamNameString10 = value;
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

	public string GetKillString(int index)
	{
		return index switch
		{
			1 => KillString1, 
			2 => KillString2, 
			3 => KillString3, 
			4 => KillString4, 
			5 => KillString5, 
			6 => KillString6, 
			7 => KillString7, 
			8 => KillString8, 
			9 => KillString9, 
			10 => KillString10, 
			_ => null, 
		};
	}

	public void SetKillString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KillString1 = value;
			break;
		case 2:
			KillString2 = value;
			break;
		case 3:
			KillString3 = value;
			break;
		case 4:
			KillString4 = value;
			break;
		case 5:
			KillString5 = value;
			break;
		case 6:
			KillString6 = value;
			break;
		case 7:
			KillString7 = value;
			break;
		case 8:
			KillString8 = value;
			break;
		case 9:
			KillString9 = value;
			break;
		case 10:
			KillString10 = value;
			break;
		}
	}

	public string GetKnifeKillString(int index)
	{
		return index switch
		{
			1 => KnifeKillString1, 
			2 => KnifeKillString2, 
			3 => KnifeKillString3, 
			4 => KnifeKillString4, 
			5 => KnifeKillString5, 
			6 => KnifeKillString6, 
			7 => KnifeKillString7, 
			8 => KnifeKillString8, 
			9 => KnifeKillString9, 
			10 => KnifeKillString10, 
			_ => null, 
		};
	}

	public void SetKnifeKillString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KnifeKillString1 = value;
			break;
		case 2:
			KnifeKillString2 = value;
			break;
		case 3:
			KnifeKillString3 = value;
			break;
		case 4:
			KnifeKillString4 = value;
			break;
		case 5:
			KnifeKillString5 = value;
			break;
		case 6:
			KnifeKillString6 = value;
			break;
		case 7:
			KnifeKillString7 = value;
			break;
		case 8:
			KnifeKillString8 = value;
			break;
		case 9:
			KnifeKillString9 = value;
			break;
		case 10:
			KnifeKillString10 = value;
			break;
		}
	}

	public string GetPingString(int index)
	{
		return index switch
		{
			1 => PingString1, 
			2 => PingString2, 
			3 => PingString3, 
			4 => PingString4, 
			5 => PingString5, 
			6 => PingString6, 
			7 => PingString7, 
			8 => PingString8, 
			9 => PingString9, 
			10 => PingString10, 
			_ => null, 
		};
	}

	public void SetPingString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PingString1 = value;
			break;
		case 2:
			PingString2 = value;
			break;
		case 3:
			PingString3 = value;
			break;
		case 4:
			PingString4 = value;
			break;
		case 5:
			PingString5 = value;
			break;
		case 6:
			PingString6 = value;
			break;
		case 7:
			PingString7 = value;
			break;
		case 8:
			PingString8 = value;
			break;
		case 9:
			PingString9 = value;
			break;
		case 10:
			PingString10 = value;
			break;
		}
	}

	public string GetLevelString(int index)
	{
		return index switch
		{
			1 => LevelString1, 
			2 => LevelString2, 
			3 => LevelString3, 
			4 => LevelString4, 
			5 => LevelString5, 
			6 => LevelString6, 
			7 => LevelString7, 
			8 => LevelString8, 
			9 => LevelString9, 
			10 => LevelString10, 
			_ => null, 
		};
	}

	public void SetLevelString(int index, string value)
	{
		switch (index)
		{
		case 1:
			LevelString1 = value;
			break;
		case 2:
			LevelString2 = value;
			break;
		case 3:
			LevelString3 = value;
			break;
		case 4:
			LevelString4 = value;
			break;
		case 5:
			LevelString5 = value;
			break;
		case 6:
			LevelString6 = value;
			break;
		case 7:
			LevelString7 = value;
			break;
		case 8:
			LevelString8 = value;
			break;
		case 9:
			LevelString9 = value;
			break;
		case 10:
			LevelString10 = value;
			break;
		}
	}

	public bool GetLootShow(int index)
	{
		return index switch
		{
			1 => LootShow1, 
			2 => LootShow2, 
			3 => LootShow3, 
			4 => LootShow4, 
			_ => false, 
		};
	}

	public void SetLootShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LootShow1 = value;
			break;
		case 2:
			LootShow2 = value;
			break;
		case 3:
			LootShow3 = value;
			break;
		case 4:
			LootShow4 = value;
			break;
		}
	}

	public Sprite GetLootSprite(int index)
	{
		return index switch
		{
			1 => LootSprite1, 
			2 => LootSprite2, 
			3 => LootSprite3, 
			4 => LootSprite4, 
			_ => null, 
		};
	}

	public void SetLootSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			LootSprite1 = value;
			break;
		case 2:
			LootSprite2 = value;
			break;
		case 3:
			LootSprite3 = value;
			break;
		case 4:
			LootSprite4 = value;
			break;
		}
	}

	public void LootNtvsize1()
	{
		if (_oLootImage1 != null)
		{
			_oLootImage1.SetNativeSize();
		}
	}

	public void LootNtvsize2()
	{
		if (_oLootImage2 != null)
		{
			_oLootImage2.SetNativeSize();
		}
	}

	public void LootNtvsize3()
	{
		if (_oLootImage3 != null)
		{
			_oLootImage3.SetNativeSize();
		}
	}

	public void LootNtvsize4()
	{
		if (_oLootImage4 != null)
		{
			_oLootImage4.SetNativeSize();
		}
	}

	public void CallLootNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			LootNtvsize1();
			break;
		case 2:
			LootNtvsize2();
			break;
		case 3:
			LootNtvsize3();
			break;
		case 4:
			LootNtvsize4();
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
