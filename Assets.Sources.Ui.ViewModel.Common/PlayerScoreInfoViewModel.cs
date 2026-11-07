using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerScoreInfoViewModel : IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _oSlot1;

	private GameObject _oSlot2;

	private GameObject _oSlot3;

	private GameObject _oSlot4;

	private GameObject _oSlot5;

	private GameObject _oSlot6;

	private GameObject _oSlot7;

	private GameObject _oSlot8;

	private GameObject _oSlot9;

	private GameObject _oSlot10;

	private GameObject _oSlot11;

	private GameObject _oSlot12;

	private GameObject _oSlot13;

	private GameObject _oSlot14;

	private GameObject _oSlot15;

	private GameObject _oSlot16;

	private GameObject _oSlot17;

	private GameObject _oSlot18;

	private GameObject _oSlot19;

	private GameObject _oSlot20;

	private GameObject _oSingleKill1;

	private GameObject _oSingleKill2;

	private GameObject _oSingleKill3;

	private GameObject _oSingleKill4;

	private GameObject _oSingleKill5;

	private GameObject _oSingleKill6;

	private GameObject _oSingleKill7;

	private GameObject _oSingleKill8;

	private GameObject _oSingleKill9;

	private GameObject _oSingleKill10;

	private GameObject _oSingleKill11;

	private GameObject _oSingleKill12;

	private GameObject _oSingleKill13;

	private GameObject _oSingleKill14;

	private GameObject _oSingleKill15;

	private GameObject _oSingleKill16;

	private GameObject _oSingleKill17;

	private GameObject _oSingleKill18;

	private GameObject _oSingleKill19;

	private GameObject _oSingleKill20;

	private Image _oSingleKillImage1;

	private Image _oSingleKillImage2;

	private Image _oSingleKillImage3;

	private Image _oSingleKillImage4;

	private Image _oSingleKillImage5;

	private Image _oSingleKillImage6;

	private Image _oSingleKillImage7;

	private Image _oSingleKillImage8;

	private Image _oSingleKillImage9;

	private Image _oSingleKillImage10;

	private Image _oSingleKillImage11;

	private Image _oSingleKillImage12;

	private Image _oSingleKillImage13;

	private Image _oSingleKillImage14;

	private Image _oSingleKillImage15;

	private Image _oSingleKillImage16;

	private Image _oSingleKillImage17;

	private Image _oSingleKillImage18;

	private Image _oSingleKillImage19;

	private Image _oSingleKillImage20;

	private GameObject _oHeadShot1;

	private GameObject _oHeadShot2;

	private GameObject _oHeadShot3;

	private GameObject _oHeadShot4;

	private GameObject _oHeadShot5;

	private GameObject _oHeadShot6;

	private GameObject _oHeadShot7;

	private GameObject _oHeadShot8;

	private GameObject _oHeadShot9;

	private GameObject _oHeadShot10;

	private GameObject _oHeadShot11;

	private GameObject _oHeadShot12;

	private GameObject _oHeadShot13;

	private GameObject _oHeadShot14;

	private GameObject _oHeadShot15;

	private GameObject _oHeadShot16;

	private GameObject _oHeadShot17;

	private GameObject _oHeadShot18;

	private GameObject _oHeadShot19;

	private GameObject _oHeadShot20;

	private Image _oHeadShotImage1;

	private Image _oHeadShotImage2;

	private Image _oHeadShotImage3;

	private Image _oHeadShotImage4;

	private Image _oHeadShotImage5;

	private Image _oHeadShotImage6;

	private Image _oHeadShotImage7;

	private Image _oHeadShotImage8;

	private Image _oHeadShotImage9;

	private Image _oHeadShotImage10;

	private Image _oHeadShotImage11;

	private Image _oHeadShotImage12;

	private Image _oHeadShotImage13;

	private Image _oHeadShotImage14;

	private Image _oHeadShotImage15;

	private Image _oHeadShotImage16;

	private Image _oHeadShotImage17;

	private Image _oHeadShotImage18;

	private Image _oHeadShotImage19;

	private Image _oHeadShotImage20;

	private GameObject _oFiveKill1;

	private GameObject _oFiveKill2;

	private GameObject _oFiveKill3;

	private GameObject _oFiveKill4;

	private GameObject _oFiveKill5;

	private GameObject _oFiveKill6;

	private GameObject _oFiveKill7;

	private GameObject _oFiveKill8;

	private GameObject _oFiveKill9;

	private GameObject _oFiveKill10;

	private GameObject _oFiveKill11;

	private GameObject _oFiveKill12;

	private GameObject _oFiveKill13;

	private GameObject _oFiveKill14;

	private GameObject _oFiveKill15;

	private GameObject _oFiveKill16;

	private GameObject _oFiveKill17;

	private GameObject _oFiveKill18;

	private GameObject _oFiveKill19;

	private GameObject _oFiveKill20;

	private Image _oFiveKillImage1;

	private Image _oFiveKillImage2;

	private Image _oFiveKillImage3;

	private Image _oFiveKillImage4;

	private Image _oFiveKillImage5;

	private Image _oFiveKillImage6;

	private Image _oFiveKillImage7;

	private Image _oFiveKillImage8;

	private Image _oFiveKillImage9;

	private Image _oFiveKillImage10;

	private Image _oFiveKillImage11;

	private Image _oFiveKillImage12;

	private Image _oFiveKillImage13;

	private Image _oFiveKillImage14;

	private Image _oFiveKillImage15;

	private Image _oFiveKillImage16;

	private Image _oFiveKillImage17;

	private Image _oFiveKillImage18;

	private Image _oFiveKillImage19;

	private Image _oFiveKillImage20;

	private GameObject _oTenKill1;

	private GameObject _oTenKill2;

	private GameObject _oTenKill3;

	private GameObject _oTenKill4;

	private GameObject _oTenKill5;

	private GameObject _oTenKill6;

	private GameObject _oTenKill7;

	private GameObject _oTenKill8;

	private GameObject _oTenKill9;

	private GameObject _oTenKill10;

	private GameObject _oTenKill11;

	private GameObject _oTenKill12;

	private GameObject _oTenKill13;

	private GameObject _oTenKill14;

	private GameObject _oTenKill15;

	private GameObject _oTenKill16;

	private GameObject _oTenKill17;

	private GameObject _oTenKill18;

	private GameObject _oTenKill19;

	private GameObject _oTenKill20;

	private Image _oTenKillImage1;

	private Image _oTenKillImage2;

	private Image _oTenKillImage3;

	private Image _oTenKillImage4;

	private Image _oTenKillImage5;

	private Image _oTenKillImage6;

	private Image _oTenKillImage7;

	private Image _oTenKillImage8;

	private Image _oTenKillImage9;

	private Image _oTenKillImage10;

	private Image _oTenKillImage11;

	private Image _oTenKillImage12;

	private Image _oTenKillImage13;

	private Image _oTenKillImage14;

	private Image _oTenKillImage15;

	private Image _oTenKillImage16;

	private Image _oTenKillImage17;

	private Image _oTenKillImage18;

	private Image _oTenKillImage19;

	private Image _oTenKillImage20;

	private GameObject _oFiftyKill1;

	private GameObject _oFiftyKill2;

	private GameObject _oFiftyKill3;

	private GameObject _oFiftyKill4;

	private GameObject _oFiftyKill5;

	private GameObject _oFiftyKill6;

	private GameObject _oFiftyKill7;

	private GameObject _oFiftyKill8;

	private GameObject _oFiftyKill9;

	private GameObject _oFiftyKill10;

	private GameObject _oFiftyKill11;

	private GameObject _oFiftyKill12;

	private GameObject _oFiftyKill13;

	private GameObject _oFiftyKill14;

	private GameObject _oFiftyKill15;

	private GameObject _oFiftyKill16;

	private GameObject _oFiftyKill17;

	private GameObject _oFiftyKill18;

	private GameObject _oFiftyKill19;

	private GameObject _oFiftyKill20;

	private Image _oFiftyKillImage1;

	private Image _oFiftyKillImage2;

	private Image _oFiftyKillImage3;

	private Image _oFiftyKillImage4;

	private Image _oFiftyKillImage5;

	private Image _oFiftyKillImage6;

	private Image _oFiftyKillImage7;

	private Image _oFiftyKillImage8;

	private Image _oFiftyKillImage9;

	private Image _oFiftyKillImage10;

	private Image _oFiftyKillImage11;

	private Image _oFiftyKillImage12;

	private Image _oFiftyKillImage13;

	private Image _oFiftyKillImage14;

	private Image _oFiftyKillImage15;

	private Image _oFiftyKillImage16;

	private Image _oFiftyKillImage17;

	private Image _oFiftyKillImage18;

	private Image _oFiftyKillImage19;

	private Image _oFiftyKillImage20;

	private GameObject _oHundredKill1;

	private GameObject _oHundredKill2;

	private GameObject _oHundredKill3;

	private GameObject _oHundredKill4;

	private GameObject _oHundredKill5;

	private GameObject _oHundredKill6;

	private GameObject _oHundredKill7;

	private GameObject _oHundredKill8;

	private GameObject _oHundredKill9;

	private GameObject _oHundredKill10;

	private GameObject _oHundredKill11;

	private GameObject _oHundredKill12;

	private GameObject _oHundredKill13;

	private GameObject _oHundredKill14;

	private GameObject _oHundredKill15;

	private GameObject _oHundredKill16;

	private GameObject _oHundredKill17;

	private GameObject _oHundredKill18;

	private GameObject _oHundredKill19;

	private GameObject _oHundredKill20;

	private Image _oHundredKillImage1;

	private Image _oHundredKillImage2;

	private Image _oHundredKillImage3;

	private Image _oHundredKillImage4;

	private Image _oHundredKillImage5;

	private Image _oHundredKillImage6;

	private Image _oHundredKillImage7;

	private Image _oHundredKillImage8;

	private Image _oHundredKillImage9;

	private Image _oHundredKillImage10;

	private Image _oHundredKillImage11;

	private Image _oHundredKillImage12;

	private Image _oHundredKillImage13;

	private Image _oHundredKillImage14;

	private Image _oHundredKillImage15;

	private Image _oHundredKillImage16;

	private Image _oHundredKillImage17;

	private Image _oHundredKillImage18;

	private Image _oHundredKillImage19;

	private Image _oHundredKillImage20;

	private GameObject _oSingleAssist1;

	private GameObject _oSingleAssist2;

	private GameObject _oSingleAssist3;

	private GameObject _oSingleAssist4;

	private GameObject _oSingleAssist5;

	private GameObject _oSingleAssist6;

	private GameObject _oSingleAssist7;

	private GameObject _oSingleAssist8;

	private GameObject _oSingleAssist9;

	private GameObject _oSingleAssist10;

	private GameObject _oSingleAssist11;

	private GameObject _oSingleAssist12;

	private GameObject _oSingleAssist13;

	private GameObject _oSingleAssist14;

	private GameObject _oSingleAssist15;

	private GameObject _oSingleAssist16;

	private GameObject _oSingleAssist17;

	private GameObject _oSingleAssist18;

	private GameObject _oSingleAssist19;

	private GameObject _oSingleAssist20;

	private Image _oSingleAssistImage1;

	private Image _oSingleAssistImage2;

	private Image _oSingleAssistImage3;

	private Image _oSingleAssistImage4;

	private Image _oSingleAssistImage5;

	private Image _oSingleAssistImage6;

	private Image _oSingleAssistImage7;

	private Image _oSingleAssistImage8;

	private Image _oSingleAssistImage9;

	private Image _oSingleAssistImage10;

	private Image _oSingleAssistImage11;

	private Image _oSingleAssistImage12;

	private Image _oSingleAssistImage13;

	private Image _oSingleAssistImage14;

	private Image _oSingleAssistImage15;

	private Image _oSingleAssistImage16;

	private Image _oSingleAssistImage17;

	private Image _oSingleAssistImage18;

	private Image _oSingleAssistImage19;

	private Image _oSingleAssistImage20;

	private GameObject _oFiveAssist1;

	private GameObject _oFiveAssist2;

	private GameObject _oFiveAssist3;

	private GameObject _oFiveAssist4;

	private GameObject _oFiveAssist5;

	private GameObject _oFiveAssist6;

	private GameObject _oFiveAssist7;

	private GameObject _oFiveAssist8;

	private GameObject _oFiveAssist9;

	private GameObject _oFiveAssist10;

	private GameObject _oFiveAssist11;

	private GameObject _oFiveAssist12;

	private GameObject _oFiveAssist13;

	private GameObject _oFiveAssist14;

	private GameObject _oFiveAssist15;

	private GameObject _oFiveAssist16;

	private GameObject _oFiveAssist17;

	private GameObject _oFiveAssist18;

	private GameObject _oFiveAssist19;

	private GameObject _oFiveAssist20;

	private Image _oFiveAssistImage1;

	private Image _oFiveAssistImage2;

	private Image _oFiveAssistImage3;

	private Image _oFiveAssistImage4;

	private Image _oFiveAssistImage5;

	private Image _oFiveAssistImage6;

	private Image _oFiveAssistImage7;

	private Image _oFiveAssistImage8;

	private Image _oFiveAssistImage9;

	private Image _oFiveAssistImage10;

	private Image _oFiveAssistImage11;

	private Image _oFiveAssistImage12;

	private Image _oFiveAssistImage13;

	private Image _oFiveAssistImage14;

	private Image _oFiveAssistImage15;

	private Image _oFiveAssistImage16;

	private Image _oFiveAssistImage17;

	private Image _oFiveAssistImage18;

	private Image _oFiveAssistImage19;

	private Image _oFiveAssistImage20;

	private GameObject _oTenAssist1;

	private GameObject _oTenAssist2;

	private GameObject _oTenAssist3;

	private GameObject _oTenAssist4;

	private GameObject _oTenAssist5;

	private GameObject _oTenAssist6;

	private GameObject _oTenAssist7;

	private GameObject _oTenAssist8;

	private GameObject _oTenAssist9;

	private GameObject _oTenAssist10;

	private GameObject _oTenAssist11;

	private GameObject _oTenAssist12;

	private GameObject _oTenAssist13;

	private GameObject _oTenAssist14;

	private GameObject _oTenAssist15;

	private GameObject _oTenAssist16;

	private GameObject _oTenAssist17;

	private GameObject _oTenAssist18;

	private GameObject _oTenAssist19;

	private GameObject _oTenAssist20;

	private Image _oTenAssistImage1;

	private Image _oTenAssistImage2;

	private Image _oTenAssistImage3;

	private Image _oTenAssistImage4;

	private Image _oTenAssistImage5;

	private Image _oTenAssistImage6;

	private Image _oTenAssistImage7;

	private Image _oTenAssistImage8;

	private Image _oTenAssistImage9;

	private Image _oTenAssistImage10;

	private Image _oTenAssistImage11;

	private Image _oTenAssistImage12;

	private Image _oTenAssistImage13;

	private Image _oTenAssistImage14;

	private Image _oTenAssistImage15;

	private Image _oTenAssistImage16;

	private Image _oTenAssistImage17;

	private Image _oTenAssistImage18;

	private Image _oTenAssistImage19;

	private Image _oTenAssistImage20;

	private GameObject _oFiftyAssist1;

	private GameObject _oFiftyAssist2;

	private GameObject _oFiftyAssist3;

	private GameObject _oFiftyAssist4;

	private GameObject _oFiftyAssist5;

	private GameObject _oFiftyAssist6;

	private GameObject _oFiftyAssist7;

	private GameObject _oFiftyAssist8;

	private GameObject _oFiftyAssist9;

	private GameObject _oFiftyAssist10;

	private GameObject _oFiftyAssist11;

	private GameObject _oFiftyAssist12;

	private GameObject _oFiftyAssist13;

	private GameObject _oFiftyAssist14;

	private GameObject _oFiftyAssist15;

	private GameObject _oFiftyAssist16;

	private GameObject _oFiftyAssist17;

	private GameObject _oFiftyAssist18;

	private GameObject _oFiftyAssist19;

	private GameObject _oFiftyAssist20;

	private Image _oFiftyAssistImage1;

	private Image _oFiftyAssistImage2;

	private Image _oFiftyAssistImage3;

	private Image _oFiftyAssistImage4;

	private Image _oFiftyAssistImage5;

	private Image _oFiftyAssistImage6;

	private Image _oFiftyAssistImage7;

	private Image _oFiftyAssistImage8;

	private Image _oFiftyAssistImage9;

	private Image _oFiftyAssistImage10;

	private Image _oFiftyAssistImage11;

	private Image _oFiftyAssistImage12;

	private Image _oFiftyAssistImage13;

	private Image _oFiftyAssistImage14;

	private Image _oFiftyAssistImage15;

	private Image _oFiftyAssistImage16;

	private Image _oFiftyAssistImage17;

	private Image _oFiftyAssistImage18;

	private Image _oFiftyAssistImage19;

	private Image _oFiftyAssistImage20;

	private GameObject _oHundredAssist1;

	private GameObject _oHundredAssist2;

	private GameObject _oHundredAssist3;

	private GameObject _oHundredAssist4;

	private GameObject _oHundredAssist5;

	private GameObject _oHundredAssist6;

	private GameObject _oHundredAssist7;

	private GameObject _oHundredAssist8;

	private GameObject _oHundredAssist9;

	private GameObject _oHundredAssist10;

	private GameObject _oHundredAssist11;

	private GameObject _oHundredAssist12;

	private GameObject _oHundredAssist13;

	private GameObject _oHundredAssist14;

	private GameObject _oHundredAssist15;

	private GameObject _oHundredAssist16;

	private GameObject _oHundredAssist17;

	private GameObject _oHundredAssist18;

	private GameObject _oHundredAssist19;

	private GameObject _oHundredAssist20;

	private Image _oHundredAssistImage1;

	private Image _oHundredAssistImage2;

	private Image _oHundredAssistImage3;

	private Image _oHundredAssistImage4;

	private Image _oHundredAssistImage5;

	private Image _oHundredAssistImage6;

	private Image _oHundredAssistImage7;

	private Image _oHundredAssistImage8;

	private Image _oHundredAssistImage9;

	private Image _oHundredAssistImage10;

	private Image _oHundredAssistImage11;

	private Image _oHundredAssistImage12;

	private Image _oHundredAssistImage13;

	private Image _oHundredAssistImage14;

	private Image _oHundredAssistImage15;

	private Image _oHundredAssistImage16;

	private Image _oHundredAssistImage17;

	private Image _oHundredAssistImage18;

	private Image _oHundredAssistImage19;

	private Image _oHundredAssistImage20;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "PlayerScoreInfo";

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

	public Vector2 ShowAnchoredposition
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (ShowAnchoredposition != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.anchoredPosition = value;
			}
		}
	}

	public bool SlotShow1
	{
		get
		{
			if (_oSlot1 != null)
			{
				return _oSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow1 != value && _oSlot1 != null)
			{
				_oSlot1.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow2
	{
		get
		{
			if (_oSlot2 != null)
			{
				return _oSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow2 != value && _oSlot2 != null)
			{
				_oSlot2.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow3
	{
		get
		{
			if (_oSlot3 != null)
			{
				return _oSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow3 != value && _oSlot3 != null)
			{
				_oSlot3.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow4
	{
		get
		{
			if (_oSlot4 != null)
			{
				return _oSlot4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow4 != value && _oSlot4 != null)
			{
				_oSlot4.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow5
	{
		get
		{
			if (_oSlot5 != null)
			{
				return _oSlot5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow5 != value && _oSlot5 != null)
			{
				_oSlot5.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow6
	{
		get
		{
			if (_oSlot6 != null)
			{
				return _oSlot6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow6 != value && _oSlot6 != null)
			{
				_oSlot6.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow7
	{
		get
		{
			if (_oSlot7 != null)
			{
				return _oSlot7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow7 != value && _oSlot7 != null)
			{
				_oSlot7.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow8
	{
		get
		{
			if (_oSlot8 != null)
			{
				return _oSlot8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow8 != value && _oSlot8 != null)
			{
				_oSlot8.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow9
	{
		get
		{
			if (_oSlot9 != null)
			{
				return _oSlot9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow9 != value && _oSlot9 != null)
			{
				_oSlot9.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow10
	{
		get
		{
			if (_oSlot10 != null)
			{
				return _oSlot10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow10 != value && _oSlot10 != null)
			{
				_oSlot10.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow11
	{
		get
		{
			if (_oSlot11 != null)
			{
				return _oSlot11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow11 != value && _oSlot11 != null)
			{
				_oSlot11.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow12
	{
		get
		{
			if (_oSlot12 != null)
			{
				return _oSlot12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow12 != value && _oSlot12 != null)
			{
				_oSlot12.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow13
	{
		get
		{
			if (_oSlot13 != null)
			{
				return _oSlot13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow13 != value && _oSlot13 != null)
			{
				_oSlot13.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow14
	{
		get
		{
			if (_oSlot14 != null)
			{
				return _oSlot14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow14 != value && _oSlot14 != null)
			{
				_oSlot14.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow15
	{
		get
		{
			if (_oSlot15 != null)
			{
				return _oSlot15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow15 != value && _oSlot15 != null)
			{
				_oSlot15.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow16
	{
		get
		{
			if (_oSlot16 != null)
			{
				return _oSlot16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow16 != value && _oSlot16 != null)
			{
				_oSlot16.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow17
	{
		get
		{
			if (_oSlot17 != null)
			{
				return _oSlot17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow17 != value && _oSlot17 != null)
			{
				_oSlot17.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow18
	{
		get
		{
			if (_oSlot18 != null)
			{
				return _oSlot18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow18 != value && _oSlot18 != null)
			{
				_oSlot18.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow19
	{
		get
		{
			if (_oSlot19 != null)
			{
				return _oSlot19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow19 != value && _oSlot19 != null)
			{
				_oSlot19.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow20
	{
		get
		{
			if (_oSlot20 != null)
			{
				return _oSlot20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow20 != value && _oSlot20 != null)
			{
				_oSlot20.SetObjectActive(value);
			}
		}
	}

	public bool SingleKillEnabled1
	{
		get
		{
			if (_oSingleKillImage1 != null)
			{
				return _oSingleKillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled1 != value && _oSingleKillImage1 != null)
			{
				_oSingleKillImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled2
	{
		get
		{
			if (_oSingleKillImage2 != null)
			{
				return _oSingleKillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled2 != value && _oSingleKillImage2 != null)
			{
				_oSingleKillImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled3
	{
		get
		{
			if (_oSingleKillImage3 != null)
			{
				return _oSingleKillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled3 != value && _oSingleKillImage3 != null)
			{
				_oSingleKillImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled4
	{
		get
		{
			if (_oSingleKillImage4 != null)
			{
				return _oSingleKillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled4 != value && _oSingleKillImage4 != null)
			{
				_oSingleKillImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled5
	{
		get
		{
			if (_oSingleKillImage5 != null)
			{
				return _oSingleKillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled5 != value && _oSingleKillImage5 != null)
			{
				_oSingleKillImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled6
	{
		get
		{
			if (_oSingleKillImage6 != null)
			{
				return _oSingleKillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled6 != value && _oSingleKillImage6 != null)
			{
				_oSingleKillImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled7
	{
		get
		{
			if (_oSingleKillImage7 != null)
			{
				return _oSingleKillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled7 != value && _oSingleKillImage7 != null)
			{
				_oSingleKillImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled8
	{
		get
		{
			if (_oSingleKillImage8 != null)
			{
				return _oSingleKillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled8 != value && _oSingleKillImage8 != null)
			{
				_oSingleKillImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled9
	{
		get
		{
			if (_oSingleKillImage9 != null)
			{
				return _oSingleKillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled9 != value && _oSingleKillImage9 != null)
			{
				_oSingleKillImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled10
	{
		get
		{
			if (_oSingleKillImage10 != null)
			{
				return _oSingleKillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled10 != value && _oSingleKillImage10 != null)
			{
				_oSingleKillImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled11
	{
		get
		{
			if (_oSingleKillImage11 != null)
			{
				return _oSingleKillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled11 != value && _oSingleKillImage11 != null)
			{
				_oSingleKillImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled12
	{
		get
		{
			if (_oSingleKillImage12 != null)
			{
				return _oSingleKillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled12 != value && _oSingleKillImage12 != null)
			{
				_oSingleKillImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled13
	{
		get
		{
			if (_oSingleKillImage13 != null)
			{
				return _oSingleKillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled13 != value && _oSingleKillImage13 != null)
			{
				_oSingleKillImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled14
	{
		get
		{
			if (_oSingleKillImage14 != null)
			{
				return _oSingleKillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled14 != value && _oSingleKillImage14 != null)
			{
				_oSingleKillImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled15
	{
		get
		{
			if (_oSingleKillImage15 != null)
			{
				return _oSingleKillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled15 != value && _oSingleKillImage15 != null)
			{
				_oSingleKillImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled16
	{
		get
		{
			if (_oSingleKillImage16 != null)
			{
				return _oSingleKillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled16 != value && _oSingleKillImage16 != null)
			{
				_oSingleKillImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled17
	{
		get
		{
			if (_oSingleKillImage17 != null)
			{
				return _oSingleKillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled17 != value && _oSingleKillImage17 != null)
			{
				_oSingleKillImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled18
	{
		get
		{
			if (_oSingleKillImage18 != null)
			{
				return _oSingleKillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled18 != value && _oSingleKillImage18 != null)
			{
				_oSingleKillImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled19
	{
		get
		{
			if (_oSingleKillImage19 != null)
			{
				return _oSingleKillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled19 != value && _oSingleKillImage19 != null)
			{
				_oSingleKillImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleKillEnabled20
	{
		get
		{
			if (_oSingleKillImage20 != null)
			{
				return _oSingleKillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (SingleKillEnabled20 != value && _oSingleKillImage20 != null)
			{
				_oSingleKillImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled1
	{
		get
		{
			if (_oHeadShotImage1 != null)
			{
				return _oHeadShotImage1.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled1 != value && _oHeadShotImage1 != null)
			{
				_oHeadShotImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled2
	{
		get
		{
			if (_oHeadShotImage2 != null)
			{
				return _oHeadShotImage2.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled2 != value && _oHeadShotImage2 != null)
			{
				_oHeadShotImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled3
	{
		get
		{
			if (_oHeadShotImage3 != null)
			{
				return _oHeadShotImage3.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled3 != value && _oHeadShotImage3 != null)
			{
				_oHeadShotImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled4
	{
		get
		{
			if (_oHeadShotImage4 != null)
			{
				return _oHeadShotImage4.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled4 != value && _oHeadShotImage4 != null)
			{
				_oHeadShotImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled5
	{
		get
		{
			if (_oHeadShotImage5 != null)
			{
				return _oHeadShotImage5.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled5 != value && _oHeadShotImage5 != null)
			{
				_oHeadShotImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled6
	{
		get
		{
			if (_oHeadShotImage6 != null)
			{
				return _oHeadShotImage6.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled6 != value && _oHeadShotImage6 != null)
			{
				_oHeadShotImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled7
	{
		get
		{
			if (_oHeadShotImage7 != null)
			{
				return _oHeadShotImage7.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled7 != value && _oHeadShotImage7 != null)
			{
				_oHeadShotImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled8
	{
		get
		{
			if (_oHeadShotImage8 != null)
			{
				return _oHeadShotImage8.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled8 != value && _oHeadShotImage8 != null)
			{
				_oHeadShotImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled9
	{
		get
		{
			if (_oHeadShotImage9 != null)
			{
				return _oHeadShotImage9.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled9 != value && _oHeadShotImage9 != null)
			{
				_oHeadShotImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled10
	{
		get
		{
			if (_oHeadShotImage10 != null)
			{
				return _oHeadShotImage10.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled10 != value && _oHeadShotImage10 != null)
			{
				_oHeadShotImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled11
	{
		get
		{
			if (_oHeadShotImage11 != null)
			{
				return _oHeadShotImage11.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled11 != value && _oHeadShotImage11 != null)
			{
				_oHeadShotImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled12
	{
		get
		{
			if (_oHeadShotImage12 != null)
			{
				return _oHeadShotImage12.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled12 != value && _oHeadShotImage12 != null)
			{
				_oHeadShotImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled13
	{
		get
		{
			if (_oHeadShotImage13 != null)
			{
				return _oHeadShotImage13.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled13 != value && _oHeadShotImage13 != null)
			{
				_oHeadShotImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled14
	{
		get
		{
			if (_oHeadShotImage14 != null)
			{
				return _oHeadShotImage14.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled14 != value && _oHeadShotImage14 != null)
			{
				_oHeadShotImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled15
	{
		get
		{
			if (_oHeadShotImage15 != null)
			{
				return _oHeadShotImage15.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled15 != value && _oHeadShotImage15 != null)
			{
				_oHeadShotImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled16
	{
		get
		{
			if (_oHeadShotImage16 != null)
			{
				return _oHeadShotImage16.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled16 != value && _oHeadShotImage16 != null)
			{
				_oHeadShotImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled17
	{
		get
		{
			if (_oHeadShotImage17 != null)
			{
				return _oHeadShotImage17.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled17 != value && _oHeadShotImage17 != null)
			{
				_oHeadShotImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled18
	{
		get
		{
			if (_oHeadShotImage18 != null)
			{
				return _oHeadShotImage18.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled18 != value && _oHeadShotImage18 != null)
			{
				_oHeadShotImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled19
	{
		get
		{
			if (_oHeadShotImage19 != null)
			{
				return _oHeadShotImage19.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled19 != value && _oHeadShotImage19 != null)
			{
				_oHeadShotImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HeadShotEnabled20
	{
		get
		{
			if (_oHeadShotImage20 != null)
			{
				return _oHeadShotImage20.enabled;
			}
			return false;
		}
		set
		{
			if (HeadShotEnabled20 != value && _oHeadShotImage20 != null)
			{
				_oHeadShotImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled1
	{
		get
		{
			if (_oFiveKillImage1 != null)
			{
				return _oFiveKillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled1 != value && _oFiveKillImage1 != null)
			{
				_oFiveKillImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled2
	{
		get
		{
			if (_oFiveKillImage2 != null)
			{
				return _oFiveKillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled2 != value && _oFiveKillImage2 != null)
			{
				_oFiveKillImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled3
	{
		get
		{
			if (_oFiveKillImage3 != null)
			{
				return _oFiveKillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled3 != value && _oFiveKillImage3 != null)
			{
				_oFiveKillImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled4
	{
		get
		{
			if (_oFiveKillImage4 != null)
			{
				return _oFiveKillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled4 != value && _oFiveKillImage4 != null)
			{
				_oFiveKillImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled5
	{
		get
		{
			if (_oFiveKillImage5 != null)
			{
				return _oFiveKillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled5 != value && _oFiveKillImage5 != null)
			{
				_oFiveKillImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled6
	{
		get
		{
			if (_oFiveKillImage6 != null)
			{
				return _oFiveKillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled6 != value && _oFiveKillImage6 != null)
			{
				_oFiveKillImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled7
	{
		get
		{
			if (_oFiveKillImage7 != null)
			{
				return _oFiveKillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled7 != value && _oFiveKillImage7 != null)
			{
				_oFiveKillImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled8
	{
		get
		{
			if (_oFiveKillImage8 != null)
			{
				return _oFiveKillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled8 != value && _oFiveKillImage8 != null)
			{
				_oFiveKillImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled9
	{
		get
		{
			if (_oFiveKillImage9 != null)
			{
				return _oFiveKillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled9 != value && _oFiveKillImage9 != null)
			{
				_oFiveKillImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled10
	{
		get
		{
			if (_oFiveKillImage10 != null)
			{
				return _oFiveKillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled10 != value && _oFiveKillImage10 != null)
			{
				_oFiveKillImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled11
	{
		get
		{
			if (_oFiveKillImage11 != null)
			{
				return _oFiveKillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled11 != value && _oFiveKillImage11 != null)
			{
				_oFiveKillImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled12
	{
		get
		{
			if (_oFiveKillImage12 != null)
			{
				return _oFiveKillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled12 != value && _oFiveKillImage12 != null)
			{
				_oFiveKillImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled13
	{
		get
		{
			if (_oFiveKillImage13 != null)
			{
				return _oFiveKillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled13 != value && _oFiveKillImage13 != null)
			{
				_oFiveKillImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled14
	{
		get
		{
			if (_oFiveKillImage14 != null)
			{
				return _oFiveKillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled14 != value && _oFiveKillImage14 != null)
			{
				_oFiveKillImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled15
	{
		get
		{
			if (_oFiveKillImage15 != null)
			{
				return _oFiveKillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled15 != value && _oFiveKillImage15 != null)
			{
				_oFiveKillImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled16
	{
		get
		{
			if (_oFiveKillImage16 != null)
			{
				return _oFiveKillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled16 != value && _oFiveKillImage16 != null)
			{
				_oFiveKillImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled17
	{
		get
		{
			if (_oFiveKillImage17 != null)
			{
				return _oFiveKillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled17 != value && _oFiveKillImage17 != null)
			{
				_oFiveKillImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled18
	{
		get
		{
			if (_oFiveKillImage18 != null)
			{
				return _oFiveKillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled18 != value && _oFiveKillImage18 != null)
			{
				_oFiveKillImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled19
	{
		get
		{
			if (_oFiveKillImage19 != null)
			{
				return _oFiveKillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled19 != value && _oFiveKillImage19 != null)
			{
				_oFiveKillImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveKillEnabled20
	{
		get
		{
			if (_oFiveKillImage20 != null)
			{
				return _oFiveKillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (FiveKillEnabled20 != value && _oFiveKillImage20 != null)
			{
				_oFiveKillImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled1
	{
		get
		{
			if (_oTenKillImage1 != null)
			{
				return _oTenKillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled1 != value && _oTenKillImage1 != null)
			{
				_oTenKillImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled2
	{
		get
		{
			if (_oTenKillImage2 != null)
			{
				return _oTenKillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled2 != value && _oTenKillImage2 != null)
			{
				_oTenKillImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled3
	{
		get
		{
			if (_oTenKillImage3 != null)
			{
				return _oTenKillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled3 != value && _oTenKillImage3 != null)
			{
				_oTenKillImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled4
	{
		get
		{
			if (_oTenKillImage4 != null)
			{
				return _oTenKillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled4 != value && _oTenKillImage4 != null)
			{
				_oTenKillImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled5
	{
		get
		{
			if (_oTenKillImage5 != null)
			{
				return _oTenKillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled5 != value && _oTenKillImage5 != null)
			{
				_oTenKillImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled6
	{
		get
		{
			if (_oTenKillImage6 != null)
			{
				return _oTenKillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled6 != value && _oTenKillImage6 != null)
			{
				_oTenKillImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled7
	{
		get
		{
			if (_oTenKillImage7 != null)
			{
				return _oTenKillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled7 != value && _oTenKillImage7 != null)
			{
				_oTenKillImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled8
	{
		get
		{
			if (_oTenKillImage8 != null)
			{
				return _oTenKillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled8 != value && _oTenKillImage8 != null)
			{
				_oTenKillImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled9
	{
		get
		{
			if (_oTenKillImage9 != null)
			{
				return _oTenKillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled9 != value && _oTenKillImage9 != null)
			{
				_oTenKillImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled10
	{
		get
		{
			if (_oTenKillImage10 != null)
			{
				return _oTenKillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled10 != value && _oTenKillImage10 != null)
			{
				_oTenKillImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled11
	{
		get
		{
			if (_oTenKillImage11 != null)
			{
				return _oTenKillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled11 != value && _oTenKillImage11 != null)
			{
				_oTenKillImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled12
	{
		get
		{
			if (_oTenKillImage12 != null)
			{
				return _oTenKillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled12 != value && _oTenKillImage12 != null)
			{
				_oTenKillImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled13
	{
		get
		{
			if (_oTenKillImage13 != null)
			{
				return _oTenKillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled13 != value && _oTenKillImage13 != null)
			{
				_oTenKillImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled14
	{
		get
		{
			if (_oTenKillImage14 != null)
			{
				return _oTenKillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled14 != value && _oTenKillImage14 != null)
			{
				_oTenKillImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled15
	{
		get
		{
			if (_oTenKillImage15 != null)
			{
				return _oTenKillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled15 != value && _oTenKillImage15 != null)
			{
				_oTenKillImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled16
	{
		get
		{
			if (_oTenKillImage16 != null)
			{
				return _oTenKillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled16 != value && _oTenKillImage16 != null)
			{
				_oTenKillImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled17
	{
		get
		{
			if (_oTenKillImage17 != null)
			{
				return _oTenKillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled17 != value && _oTenKillImage17 != null)
			{
				_oTenKillImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled18
	{
		get
		{
			if (_oTenKillImage18 != null)
			{
				return _oTenKillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled18 != value && _oTenKillImage18 != null)
			{
				_oTenKillImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled19
	{
		get
		{
			if (_oTenKillImage19 != null)
			{
				return _oTenKillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled19 != value && _oTenKillImage19 != null)
			{
				_oTenKillImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenKillEnabled20
	{
		get
		{
			if (_oTenKillImage20 != null)
			{
				return _oTenKillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (TenKillEnabled20 != value && _oTenKillImage20 != null)
			{
				_oTenKillImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled1
	{
		get
		{
			if (_oFiftyKillImage1 != null)
			{
				return _oFiftyKillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled1 != value && _oFiftyKillImage1 != null)
			{
				_oFiftyKillImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled2
	{
		get
		{
			if (_oFiftyKillImage2 != null)
			{
				return _oFiftyKillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled2 != value && _oFiftyKillImage2 != null)
			{
				_oFiftyKillImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled3
	{
		get
		{
			if (_oFiftyKillImage3 != null)
			{
				return _oFiftyKillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled3 != value && _oFiftyKillImage3 != null)
			{
				_oFiftyKillImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled4
	{
		get
		{
			if (_oFiftyKillImage4 != null)
			{
				return _oFiftyKillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled4 != value && _oFiftyKillImage4 != null)
			{
				_oFiftyKillImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled5
	{
		get
		{
			if (_oFiftyKillImage5 != null)
			{
				return _oFiftyKillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled5 != value && _oFiftyKillImage5 != null)
			{
				_oFiftyKillImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled6
	{
		get
		{
			if (_oFiftyKillImage6 != null)
			{
				return _oFiftyKillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled6 != value && _oFiftyKillImage6 != null)
			{
				_oFiftyKillImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled7
	{
		get
		{
			if (_oFiftyKillImage7 != null)
			{
				return _oFiftyKillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled7 != value && _oFiftyKillImage7 != null)
			{
				_oFiftyKillImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled8
	{
		get
		{
			if (_oFiftyKillImage8 != null)
			{
				return _oFiftyKillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled8 != value && _oFiftyKillImage8 != null)
			{
				_oFiftyKillImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled9
	{
		get
		{
			if (_oFiftyKillImage9 != null)
			{
				return _oFiftyKillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled9 != value && _oFiftyKillImage9 != null)
			{
				_oFiftyKillImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled10
	{
		get
		{
			if (_oFiftyKillImage10 != null)
			{
				return _oFiftyKillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled10 != value && _oFiftyKillImage10 != null)
			{
				_oFiftyKillImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled11
	{
		get
		{
			if (_oFiftyKillImage11 != null)
			{
				return _oFiftyKillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled11 != value && _oFiftyKillImage11 != null)
			{
				_oFiftyKillImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled12
	{
		get
		{
			if (_oFiftyKillImage12 != null)
			{
				return _oFiftyKillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled12 != value && _oFiftyKillImage12 != null)
			{
				_oFiftyKillImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled13
	{
		get
		{
			if (_oFiftyKillImage13 != null)
			{
				return _oFiftyKillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled13 != value && _oFiftyKillImage13 != null)
			{
				_oFiftyKillImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled14
	{
		get
		{
			if (_oFiftyKillImage14 != null)
			{
				return _oFiftyKillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled14 != value && _oFiftyKillImage14 != null)
			{
				_oFiftyKillImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled15
	{
		get
		{
			if (_oFiftyKillImage15 != null)
			{
				return _oFiftyKillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled15 != value && _oFiftyKillImage15 != null)
			{
				_oFiftyKillImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled16
	{
		get
		{
			if (_oFiftyKillImage16 != null)
			{
				return _oFiftyKillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled16 != value && _oFiftyKillImage16 != null)
			{
				_oFiftyKillImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled17
	{
		get
		{
			if (_oFiftyKillImage17 != null)
			{
				return _oFiftyKillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled17 != value && _oFiftyKillImage17 != null)
			{
				_oFiftyKillImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled18
	{
		get
		{
			if (_oFiftyKillImage18 != null)
			{
				return _oFiftyKillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled18 != value && _oFiftyKillImage18 != null)
			{
				_oFiftyKillImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled19
	{
		get
		{
			if (_oFiftyKillImage19 != null)
			{
				return _oFiftyKillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled19 != value && _oFiftyKillImage19 != null)
			{
				_oFiftyKillImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyKillEnabled20
	{
		get
		{
			if (_oFiftyKillImage20 != null)
			{
				return _oFiftyKillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyKillEnabled20 != value && _oFiftyKillImage20 != null)
			{
				_oFiftyKillImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled1
	{
		get
		{
			if (_oHundredKillImage1 != null)
			{
				return _oHundredKillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled1 != value && _oHundredKillImage1 != null)
			{
				_oHundredKillImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled2
	{
		get
		{
			if (_oHundredKillImage2 != null)
			{
				return _oHundredKillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled2 != value && _oHundredKillImage2 != null)
			{
				_oHundredKillImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled3
	{
		get
		{
			if (_oHundredKillImage3 != null)
			{
				return _oHundredKillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled3 != value && _oHundredKillImage3 != null)
			{
				_oHundredKillImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled4
	{
		get
		{
			if (_oHundredKillImage4 != null)
			{
				return _oHundredKillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled4 != value && _oHundredKillImage4 != null)
			{
				_oHundredKillImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled5
	{
		get
		{
			if (_oHundredKillImage5 != null)
			{
				return _oHundredKillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled5 != value && _oHundredKillImage5 != null)
			{
				_oHundredKillImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled6
	{
		get
		{
			if (_oHundredKillImage6 != null)
			{
				return _oHundredKillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled6 != value && _oHundredKillImage6 != null)
			{
				_oHundredKillImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled7
	{
		get
		{
			if (_oHundredKillImage7 != null)
			{
				return _oHundredKillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled7 != value && _oHundredKillImage7 != null)
			{
				_oHundredKillImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled8
	{
		get
		{
			if (_oHundredKillImage8 != null)
			{
				return _oHundredKillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled8 != value && _oHundredKillImage8 != null)
			{
				_oHundredKillImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled9
	{
		get
		{
			if (_oHundredKillImage9 != null)
			{
				return _oHundredKillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled9 != value && _oHundredKillImage9 != null)
			{
				_oHundredKillImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled10
	{
		get
		{
			if (_oHundredKillImage10 != null)
			{
				return _oHundredKillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled10 != value && _oHundredKillImage10 != null)
			{
				_oHundredKillImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled11
	{
		get
		{
			if (_oHundredKillImage11 != null)
			{
				return _oHundredKillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled11 != value && _oHundredKillImage11 != null)
			{
				_oHundredKillImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled12
	{
		get
		{
			if (_oHundredKillImage12 != null)
			{
				return _oHundredKillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled12 != value && _oHundredKillImage12 != null)
			{
				_oHundredKillImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled13
	{
		get
		{
			if (_oHundredKillImage13 != null)
			{
				return _oHundredKillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled13 != value && _oHundredKillImage13 != null)
			{
				_oHundredKillImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled14
	{
		get
		{
			if (_oHundredKillImage14 != null)
			{
				return _oHundredKillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled14 != value && _oHundredKillImage14 != null)
			{
				_oHundredKillImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled15
	{
		get
		{
			if (_oHundredKillImage15 != null)
			{
				return _oHundredKillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled15 != value && _oHundredKillImage15 != null)
			{
				_oHundredKillImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled16
	{
		get
		{
			if (_oHundredKillImage16 != null)
			{
				return _oHundredKillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled16 != value && _oHundredKillImage16 != null)
			{
				_oHundredKillImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled17
	{
		get
		{
			if (_oHundredKillImage17 != null)
			{
				return _oHundredKillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled17 != value && _oHundredKillImage17 != null)
			{
				_oHundredKillImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled18
	{
		get
		{
			if (_oHundredKillImage18 != null)
			{
				return _oHundredKillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled18 != value && _oHundredKillImage18 != null)
			{
				_oHundredKillImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled19
	{
		get
		{
			if (_oHundredKillImage19 != null)
			{
				return _oHundredKillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled19 != value && _oHundredKillImage19 != null)
			{
				_oHundredKillImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredKillEnabled20
	{
		get
		{
			if (_oHundredKillImage20 != null)
			{
				return _oHundredKillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (HundredKillEnabled20 != value && _oHundredKillImage20 != null)
			{
				_oHundredKillImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled1
	{
		get
		{
			if (_oSingleAssistImage1 != null)
			{
				return _oSingleAssistImage1.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled1 != value && _oSingleAssistImage1 != null)
			{
				_oSingleAssistImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled2
	{
		get
		{
			if (_oSingleAssistImage2 != null)
			{
				return _oSingleAssistImage2.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled2 != value && _oSingleAssistImage2 != null)
			{
				_oSingleAssistImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled3
	{
		get
		{
			if (_oSingleAssistImage3 != null)
			{
				return _oSingleAssistImage3.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled3 != value && _oSingleAssistImage3 != null)
			{
				_oSingleAssistImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled4
	{
		get
		{
			if (_oSingleAssistImage4 != null)
			{
				return _oSingleAssistImage4.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled4 != value && _oSingleAssistImage4 != null)
			{
				_oSingleAssistImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled5
	{
		get
		{
			if (_oSingleAssistImage5 != null)
			{
				return _oSingleAssistImage5.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled5 != value && _oSingleAssistImage5 != null)
			{
				_oSingleAssistImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled6
	{
		get
		{
			if (_oSingleAssistImage6 != null)
			{
				return _oSingleAssistImage6.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled6 != value && _oSingleAssistImage6 != null)
			{
				_oSingleAssistImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled7
	{
		get
		{
			if (_oSingleAssistImage7 != null)
			{
				return _oSingleAssistImage7.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled7 != value && _oSingleAssistImage7 != null)
			{
				_oSingleAssistImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled8
	{
		get
		{
			if (_oSingleAssistImage8 != null)
			{
				return _oSingleAssistImage8.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled8 != value && _oSingleAssistImage8 != null)
			{
				_oSingleAssistImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled9
	{
		get
		{
			if (_oSingleAssistImage9 != null)
			{
				return _oSingleAssistImage9.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled9 != value && _oSingleAssistImage9 != null)
			{
				_oSingleAssistImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled10
	{
		get
		{
			if (_oSingleAssistImage10 != null)
			{
				return _oSingleAssistImage10.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled10 != value && _oSingleAssistImage10 != null)
			{
				_oSingleAssistImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled11
	{
		get
		{
			if (_oSingleAssistImage11 != null)
			{
				return _oSingleAssistImage11.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled11 != value && _oSingleAssistImage11 != null)
			{
				_oSingleAssistImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled12
	{
		get
		{
			if (_oSingleAssistImage12 != null)
			{
				return _oSingleAssistImage12.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled12 != value && _oSingleAssistImage12 != null)
			{
				_oSingleAssistImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled13
	{
		get
		{
			if (_oSingleAssistImage13 != null)
			{
				return _oSingleAssistImage13.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled13 != value && _oSingleAssistImage13 != null)
			{
				_oSingleAssistImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled14
	{
		get
		{
			if (_oSingleAssistImage14 != null)
			{
				return _oSingleAssistImage14.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled14 != value && _oSingleAssistImage14 != null)
			{
				_oSingleAssistImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled15
	{
		get
		{
			if (_oSingleAssistImage15 != null)
			{
				return _oSingleAssistImage15.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled15 != value && _oSingleAssistImage15 != null)
			{
				_oSingleAssistImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled16
	{
		get
		{
			if (_oSingleAssistImage16 != null)
			{
				return _oSingleAssistImage16.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled16 != value && _oSingleAssistImage16 != null)
			{
				_oSingleAssistImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled17
	{
		get
		{
			if (_oSingleAssistImage17 != null)
			{
				return _oSingleAssistImage17.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled17 != value && _oSingleAssistImage17 != null)
			{
				_oSingleAssistImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled18
	{
		get
		{
			if (_oSingleAssistImage18 != null)
			{
				return _oSingleAssistImage18.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled18 != value && _oSingleAssistImage18 != null)
			{
				_oSingleAssistImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled19
	{
		get
		{
			if (_oSingleAssistImage19 != null)
			{
				return _oSingleAssistImage19.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled19 != value && _oSingleAssistImage19 != null)
			{
				_oSingleAssistImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SingleAssistEnabled20
	{
		get
		{
			if (_oSingleAssistImage20 != null)
			{
				return _oSingleAssistImage20.enabled;
			}
			return false;
		}
		set
		{
			if (SingleAssistEnabled20 != value && _oSingleAssistImage20 != null)
			{
				_oSingleAssistImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled1
	{
		get
		{
			if (_oFiveAssistImage1 != null)
			{
				return _oFiveAssistImage1.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled1 != value && _oFiveAssistImage1 != null)
			{
				_oFiveAssistImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled2
	{
		get
		{
			if (_oFiveAssistImage2 != null)
			{
				return _oFiveAssistImage2.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled2 != value && _oFiveAssistImage2 != null)
			{
				_oFiveAssistImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled3
	{
		get
		{
			if (_oFiveAssistImage3 != null)
			{
				return _oFiveAssistImage3.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled3 != value && _oFiveAssistImage3 != null)
			{
				_oFiveAssistImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled4
	{
		get
		{
			if (_oFiveAssistImage4 != null)
			{
				return _oFiveAssistImage4.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled4 != value && _oFiveAssistImage4 != null)
			{
				_oFiveAssistImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled5
	{
		get
		{
			if (_oFiveAssistImage5 != null)
			{
				return _oFiveAssistImage5.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled5 != value && _oFiveAssistImage5 != null)
			{
				_oFiveAssistImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled6
	{
		get
		{
			if (_oFiveAssistImage6 != null)
			{
				return _oFiveAssistImage6.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled6 != value && _oFiveAssistImage6 != null)
			{
				_oFiveAssistImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled7
	{
		get
		{
			if (_oFiveAssistImage7 != null)
			{
				return _oFiveAssistImage7.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled7 != value && _oFiveAssistImage7 != null)
			{
				_oFiveAssistImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled8
	{
		get
		{
			if (_oFiveAssistImage8 != null)
			{
				return _oFiveAssistImage8.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled8 != value && _oFiveAssistImage8 != null)
			{
				_oFiveAssistImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled9
	{
		get
		{
			if (_oFiveAssistImage9 != null)
			{
				return _oFiveAssistImage9.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled9 != value && _oFiveAssistImage9 != null)
			{
				_oFiveAssistImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled10
	{
		get
		{
			if (_oFiveAssistImage10 != null)
			{
				return _oFiveAssistImage10.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled10 != value && _oFiveAssistImage10 != null)
			{
				_oFiveAssistImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled11
	{
		get
		{
			if (_oFiveAssistImage11 != null)
			{
				return _oFiveAssistImage11.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled11 != value && _oFiveAssistImage11 != null)
			{
				_oFiveAssistImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled12
	{
		get
		{
			if (_oFiveAssistImage12 != null)
			{
				return _oFiveAssistImage12.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled12 != value && _oFiveAssistImage12 != null)
			{
				_oFiveAssistImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled13
	{
		get
		{
			if (_oFiveAssistImage13 != null)
			{
				return _oFiveAssistImage13.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled13 != value && _oFiveAssistImage13 != null)
			{
				_oFiveAssistImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled14
	{
		get
		{
			if (_oFiveAssistImage14 != null)
			{
				return _oFiveAssistImage14.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled14 != value && _oFiveAssistImage14 != null)
			{
				_oFiveAssistImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled15
	{
		get
		{
			if (_oFiveAssistImage15 != null)
			{
				return _oFiveAssistImage15.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled15 != value && _oFiveAssistImage15 != null)
			{
				_oFiveAssistImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled16
	{
		get
		{
			if (_oFiveAssistImage16 != null)
			{
				return _oFiveAssistImage16.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled16 != value && _oFiveAssistImage16 != null)
			{
				_oFiveAssistImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled17
	{
		get
		{
			if (_oFiveAssistImage17 != null)
			{
				return _oFiveAssistImage17.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled17 != value && _oFiveAssistImage17 != null)
			{
				_oFiveAssistImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled18
	{
		get
		{
			if (_oFiveAssistImage18 != null)
			{
				return _oFiveAssistImage18.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled18 != value && _oFiveAssistImage18 != null)
			{
				_oFiveAssistImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled19
	{
		get
		{
			if (_oFiveAssistImage19 != null)
			{
				return _oFiveAssistImage19.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled19 != value && _oFiveAssistImage19 != null)
			{
				_oFiveAssistImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiveAssistEnabled20
	{
		get
		{
			if (_oFiveAssistImage20 != null)
			{
				return _oFiveAssistImage20.enabled;
			}
			return false;
		}
		set
		{
			if (FiveAssistEnabled20 != value && _oFiveAssistImage20 != null)
			{
				_oFiveAssistImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled1
	{
		get
		{
			if (_oTenAssistImage1 != null)
			{
				return _oTenAssistImage1.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled1 != value && _oTenAssistImage1 != null)
			{
				_oTenAssistImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled2
	{
		get
		{
			if (_oTenAssistImage2 != null)
			{
				return _oTenAssistImage2.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled2 != value && _oTenAssistImage2 != null)
			{
				_oTenAssistImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled3
	{
		get
		{
			if (_oTenAssistImage3 != null)
			{
				return _oTenAssistImage3.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled3 != value && _oTenAssistImage3 != null)
			{
				_oTenAssistImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled4
	{
		get
		{
			if (_oTenAssistImage4 != null)
			{
				return _oTenAssistImage4.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled4 != value && _oTenAssistImage4 != null)
			{
				_oTenAssistImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled5
	{
		get
		{
			if (_oTenAssistImage5 != null)
			{
				return _oTenAssistImage5.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled5 != value && _oTenAssistImage5 != null)
			{
				_oTenAssistImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled6
	{
		get
		{
			if (_oTenAssistImage6 != null)
			{
				return _oTenAssistImage6.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled6 != value && _oTenAssistImage6 != null)
			{
				_oTenAssistImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled7
	{
		get
		{
			if (_oTenAssistImage7 != null)
			{
				return _oTenAssistImage7.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled7 != value && _oTenAssistImage7 != null)
			{
				_oTenAssistImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled8
	{
		get
		{
			if (_oTenAssistImage8 != null)
			{
				return _oTenAssistImage8.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled8 != value && _oTenAssistImage8 != null)
			{
				_oTenAssistImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled9
	{
		get
		{
			if (_oTenAssistImage9 != null)
			{
				return _oTenAssistImage9.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled9 != value && _oTenAssistImage9 != null)
			{
				_oTenAssistImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled10
	{
		get
		{
			if (_oTenAssistImage10 != null)
			{
				return _oTenAssistImage10.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled10 != value && _oTenAssistImage10 != null)
			{
				_oTenAssistImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled11
	{
		get
		{
			if (_oTenAssistImage11 != null)
			{
				return _oTenAssistImage11.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled11 != value && _oTenAssistImage11 != null)
			{
				_oTenAssistImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled12
	{
		get
		{
			if (_oTenAssistImage12 != null)
			{
				return _oTenAssistImage12.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled12 != value && _oTenAssistImage12 != null)
			{
				_oTenAssistImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled13
	{
		get
		{
			if (_oTenAssistImage13 != null)
			{
				return _oTenAssistImage13.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled13 != value && _oTenAssistImage13 != null)
			{
				_oTenAssistImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled14
	{
		get
		{
			if (_oTenAssistImage14 != null)
			{
				return _oTenAssistImage14.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled14 != value && _oTenAssistImage14 != null)
			{
				_oTenAssistImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled15
	{
		get
		{
			if (_oTenAssistImage15 != null)
			{
				return _oTenAssistImage15.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled15 != value && _oTenAssistImage15 != null)
			{
				_oTenAssistImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled16
	{
		get
		{
			if (_oTenAssistImage16 != null)
			{
				return _oTenAssistImage16.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled16 != value && _oTenAssistImage16 != null)
			{
				_oTenAssistImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled17
	{
		get
		{
			if (_oTenAssistImage17 != null)
			{
				return _oTenAssistImage17.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled17 != value && _oTenAssistImage17 != null)
			{
				_oTenAssistImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled18
	{
		get
		{
			if (_oTenAssistImage18 != null)
			{
				return _oTenAssistImage18.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled18 != value && _oTenAssistImage18 != null)
			{
				_oTenAssistImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled19
	{
		get
		{
			if (_oTenAssistImage19 != null)
			{
				return _oTenAssistImage19.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled19 != value && _oTenAssistImage19 != null)
			{
				_oTenAssistImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool TenAssistEnabled20
	{
		get
		{
			if (_oTenAssistImage20 != null)
			{
				return _oTenAssistImage20.enabled;
			}
			return false;
		}
		set
		{
			if (TenAssistEnabled20 != value && _oTenAssistImage20 != null)
			{
				_oTenAssistImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled1
	{
		get
		{
			if (_oFiftyAssistImage1 != null)
			{
				return _oFiftyAssistImage1.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled1 != value && _oFiftyAssistImage1 != null)
			{
				_oFiftyAssistImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled2
	{
		get
		{
			if (_oFiftyAssistImage2 != null)
			{
				return _oFiftyAssistImage2.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled2 != value && _oFiftyAssistImage2 != null)
			{
				_oFiftyAssistImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled3
	{
		get
		{
			if (_oFiftyAssistImage3 != null)
			{
				return _oFiftyAssistImage3.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled3 != value && _oFiftyAssistImage3 != null)
			{
				_oFiftyAssistImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled4
	{
		get
		{
			if (_oFiftyAssistImage4 != null)
			{
				return _oFiftyAssistImage4.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled4 != value && _oFiftyAssistImage4 != null)
			{
				_oFiftyAssistImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled5
	{
		get
		{
			if (_oFiftyAssistImage5 != null)
			{
				return _oFiftyAssistImage5.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled5 != value && _oFiftyAssistImage5 != null)
			{
				_oFiftyAssistImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled6
	{
		get
		{
			if (_oFiftyAssistImage6 != null)
			{
				return _oFiftyAssistImage6.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled6 != value && _oFiftyAssistImage6 != null)
			{
				_oFiftyAssistImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled7
	{
		get
		{
			if (_oFiftyAssistImage7 != null)
			{
				return _oFiftyAssistImage7.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled7 != value && _oFiftyAssistImage7 != null)
			{
				_oFiftyAssistImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled8
	{
		get
		{
			if (_oFiftyAssistImage8 != null)
			{
				return _oFiftyAssistImage8.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled8 != value && _oFiftyAssistImage8 != null)
			{
				_oFiftyAssistImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled9
	{
		get
		{
			if (_oFiftyAssistImage9 != null)
			{
				return _oFiftyAssistImage9.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled9 != value && _oFiftyAssistImage9 != null)
			{
				_oFiftyAssistImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled10
	{
		get
		{
			if (_oFiftyAssistImage10 != null)
			{
				return _oFiftyAssistImage10.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled10 != value && _oFiftyAssistImage10 != null)
			{
				_oFiftyAssistImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled11
	{
		get
		{
			if (_oFiftyAssistImage11 != null)
			{
				return _oFiftyAssistImage11.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled11 != value && _oFiftyAssistImage11 != null)
			{
				_oFiftyAssistImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled12
	{
		get
		{
			if (_oFiftyAssistImage12 != null)
			{
				return _oFiftyAssistImage12.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled12 != value && _oFiftyAssistImage12 != null)
			{
				_oFiftyAssistImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled13
	{
		get
		{
			if (_oFiftyAssistImage13 != null)
			{
				return _oFiftyAssistImage13.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled13 != value && _oFiftyAssistImage13 != null)
			{
				_oFiftyAssistImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled14
	{
		get
		{
			if (_oFiftyAssistImage14 != null)
			{
				return _oFiftyAssistImage14.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled14 != value && _oFiftyAssistImage14 != null)
			{
				_oFiftyAssistImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled15
	{
		get
		{
			if (_oFiftyAssistImage15 != null)
			{
				return _oFiftyAssistImage15.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled15 != value && _oFiftyAssistImage15 != null)
			{
				_oFiftyAssistImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled16
	{
		get
		{
			if (_oFiftyAssistImage16 != null)
			{
				return _oFiftyAssistImage16.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled16 != value && _oFiftyAssistImage16 != null)
			{
				_oFiftyAssistImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled17
	{
		get
		{
			if (_oFiftyAssistImage17 != null)
			{
				return _oFiftyAssistImage17.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled17 != value && _oFiftyAssistImage17 != null)
			{
				_oFiftyAssistImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled18
	{
		get
		{
			if (_oFiftyAssistImage18 != null)
			{
				return _oFiftyAssistImage18.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled18 != value && _oFiftyAssistImage18 != null)
			{
				_oFiftyAssistImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled19
	{
		get
		{
			if (_oFiftyAssistImage19 != null)
			{
				return _oFiftyAssistImage19.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled19 != value && _oFiftyAssistImage19 != null)
			{
				_oFiftyAssistImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool FiftyAssistEnabled20
	{
		get
		{
			if (_oFiftyAssistImage20 != null)
			{
				return _oFiftyAssistImage20.enabled;
			}
			return false;
		}
		set
		{
			if (FiftyAssistEnabled20 != value && _oFiftyAssistImage20 != null)
			{
				_oFiftyAssistImage20.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled1
	{
		get
		{
			if (_oHundredAssistImage1 != null)
			{
				return _oHundredAssistImage1.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled1 != value && _oHundredAssistImage1 != null)
			{
				_oHundredAssistImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled2
	{
		get
		{
			if (_oHundredAssistImage2 != null)
			{
				return _oHundredAssistImage2.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled2 != value && _oHundredAssistImage2 != null)
			{
				_oHundredAssistImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled3
	{
		get
		{
			if (_oHundredAssistImage3 != null)
			{
				return _oHundredAssistImage3.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled3 != value && _oHundredAssistImage3 != null)
			{
				_oHundredAssistImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled4
	{
		get
		{
			if (_oHundredAssistImage4 != null)
			{
				return _oHundredAssistImage4.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled4 != value && _oHundredAssistImage4 != null)
			{
				_oHundredAssistImage4.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled5
	{
		get
		{
			if (_oHundredAssistImage5 != null)
			{
				return _oHundredAssistImage5.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled5 != value && _oHundredAssistImage5 != null)
			{
				_oHundredAssistImage5.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled6
	{
		get
		{
			if (_oHundredAssistImage6 != null)
			{
				return _oHundredAssistImage6.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled6 != value && _oHundredAssistImage6 != null)
			{
				_oHundredAssistImage6.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled7
	{
		get
		{
			if (_oHundredAssistImage7 != null)
			{
				return _oHundredAssistImage7.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled7 != value && _oHundredAssistImage7 != null)
			{
				_oHundredAssistImage7.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled8
	{
		get
		{
			if (_oHundredAssistImage8 != null)
			{
				return _oHundredAssistImage8.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled8 != value && _oHundredAssistImage8 != null)
			{
				_oHundredAssistImage8.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled9
	{
		get
		{
			if (_oHundredAssistImage9 != null)
			{
				return _oHundredAssistImage9.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled9 != value && _oHundredAssistImage9 != null)
			{
				_oHundredAssistImage9.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled10
	{
		get
		{
			if (_oHundredAssistImage10 != null)
			{
				return _oHundredAssistImage10.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled10 != value && _oHundredAssistImage10 != null)
			{
				_oHundredAssistImage10.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled11
	{
		get
		{
			if (_oHundredAssistImage11 != null)
			{
				return _oHundredAssistImage11.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled11 != value && _oHundredAssistImage11 != null)
			{
				_oHundredAssistImage11.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled12
	{
		get
		{
			if (_oHundredAssistImage12 != null)
			{
				return _oHundredAssistImage12.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled12 != value && _oHundredAssistImage12 != null)
			{
				_oHundredAssistImage12.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled13
	{
		get
		{
			if (_oHundredAssistImage13 != null)
			{
				return _oHundredAssistImage13.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled13 != value && _oHundredAssistImage13 != null)
			{
				_oHundredAssistImage13.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled14
	{
		get
		{
			if (_oHundredAssistImage14 != null)
			{
				return _oHundredAssistImage14.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled14 != value && _oHundredAssistImage14 != null)
			{
				_oHundredAssistImage14.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled15
	{
		get
		{
			if (_oHundredAssistImage15 != null)
			{
				return _oHundredAssistImage15.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled15 != value && _oHundredAssistImage15 != null)
			{
				_oHundredAssistImage15.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled16
	{
		get
		{
			if (_oHundredAssistImage16 != null)
			{
				return _oHundredAssistImage16.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled16 != value && _oHundredAssistImage16 != null)
			{
				_oHundredAssistImage16.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled17
	{
		get
		{
			if (_oHundredAssistImage17 != null)
			{
				return _oHundredAssistImage17.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled17 != value && _oHundredAssistImage17 != null)
			{
				_oHundredAssistImage17.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled18
	{
		get
		{
			if (_oHundredAssistImage18 != null)
			{
				return _oHundredAssistImage18.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled18 != value && _oHundredAssistImage18 != null)
			{
				_oHundredAssistImage18.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled19
	{
		get
		{
			if (_oHundredAssistImage19 != null)
			{
				return _oHundredAssistImage19.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled19 != value && _oHundredAssistImage19 != null)
			{
				_oHundredAssistImage19.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool HundredAssistEnabled20
	{
		get
		{
			if (_oHundredAssistImage20 != null)
			{
				return _oHundredAssistImage20.enabled;
			}
			return false;
		}
		set
		{
			if (HundredAssistEnabled20 != value && _oHundredAssistImage20 != null)
			{
				_oHundredAssistImage20.NotifyUiDyLoadEnable(value);
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Slot1":
				_oSlot1 = transform.gameObject;
				break;
			case "Slot2":
				_oSlot2 = transform.gameObject;
				break;
			case "Slot3":
				_oSlot3 = transform.gameObject;
				break;
			case "Slot4":
				_oSlot4 = transform.gameObject;
				break;
			case "Slot5":
				_oSlot5 = transform.gameObject;
				break;
			case "Slot6":
				_oSlot6 = transform.gameObject;
				break;
			case "Slot7":
				_oSlot7 = transform.gameObject;
				break;
			case "Slot8":
				_oSlot8 = transform.gameObject;
				break;
			case "Slot9":
				_oSlot9 = transform.gameObject;
				break;
			case "Slot10":
				_oSlot10 = transform.gameObject;
				break;
			case "Slot11":
				_oSlot11 = transform.gameObject;
				break;
			case "Slot12":
				_oSlot12 = transform.gameObject;
				break;
			case "Slot13":
				_oSlot13 = transform.gameObject;
				break;
			case "Slot14":
				_oSlot14 = transform.gameObject;
				break;
			case "Slot15":
				_oSlot15 = transform.gameObject;
				break;
			case "Slot16":
				_oSlot16 = transform.gameObject;
				break;
			case "Slot17":
				_oSlot17 = transform.gameObject;
				break;
			case "Slot18":
				_oSlot18 = transform.gameObject;
				break;
			case "Slot19":
				_oSlot19 = transform.gameObject;
				break;
			case "Slot20":
				_oSlot20 = transform.gameObject;
				break;
			case "SingleKill1":
				_oSingleKill1 = transform.gameObject;
				_oSingleKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill2":
				_oSingleKill2 = transform.gameObject;
				_oSingleKillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill3":
				_oSingleKill3 = transform.gameObject;
				_oSingleKillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill4":
				_oSingleKill4 = transform.gameObject;
				_oSingleKillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill5":
				_oSingleKill5 = transform.gameObject;
				_oSingleKillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill6":
				_oSingleKill6 = transform.gameObject;
				_oSingleKillImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill7":
				_oSingleKill7 = transform.gameObject;
				_oSingleKillImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill8":
				_oSingleKill8 = transform.gameObject;
				_oSingleKillImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill9":
				_oSingleKill9 = transform.gameObject;
				_oSingleKillImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill10":
				_oSingleKill10 = transform.gameObject;
				_oSingleKillImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill11":
				_oSingleKill11 = transform.gameObject;
				_oSingleKillImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill12":
				_oSingleKill12 = transform.gameObject;
				_oSingleKillImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill13":
				_oSingleKill13 = transform.gameObject;
				_oSingleKillImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill14":
				_oSingleKill14 = transform.gameObject;
				_oSingleKillImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill15":
				_oSingleKill15 = transform.gameObject;
				_oSingleKillImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill16":
				_oSingleKill16 = transform.gameObject;
				_oSingleKillImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill17":
				_oSingleKill17 = transform.gameObject;
				_oSingleKillImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill18":
				_oSingleKill18 = transform.gameObject;
				_oSingleKillImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill19":
				_oSingleKill19 = transform.gameObject;
				_oSingleKillImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleKill20":
				_oSingleKill20 = transform.gameObject;
				_oSingleKillImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot1":
				_oHeadShot1 = transform.gameObject;
				_oHeadShotImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot2":
				_oHeadShot2 = transform.gameObject;
				_oHeadShotImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot3":
				_oHeadShot3 = transform.gameObject;
				_oHeadShotImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot4":
				_oHeadShot4 = transform.gameObject;
				_oHeadShotImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot5":
				_oHeadShot5 = transform.gameObject;
				_oHeadShotImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot6":
				_oHeadShot6 = transform.gameObject;
				_oHeadShotImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot7":
				_oHeadShot7 = transform.gameObject;
				_oHeadShotImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot8":
				_oHeadShot8 = transform.gameObject;
				_oHeadShotImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot9":
				_oHeadShot9 = transform.gameObject;
				_oHeadShotImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot10":
				_oHeadShot10 = transform.gameObject;
				_oHeadShotImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot11":
				_oHeadShot11 = transform.gameObject;
				_oHeadShotImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot12":
				_oHeadShot12 = transform.gameObject;
				_oHeadShotImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot13":
				_oHeadShot13 = transform.gameObject;
				_oHeadShotImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot14":
				_oHeadShot14 = transform.gameObject;
				_oHeadShotImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot15":
				_oHeadShot15 = transform.gameObject;
				_oHeadShotImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot16":
				_oHeadShot16 = transform.gameObject;
				_oHeadShotImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot17":
				_oHeadShot17 = transform.gameObject;
				_oHeadShotImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot18":
				_oHeadShot18 = transform.gameObject;
				_oHeadShotImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot19":
				_oHeadShot19 = transform.gameObject;
				_oHeadShotImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeadShot20":
				_oHeadShot20 = transform.gameObject;
				_oHeadShotImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill1":
				_oFiveKill1 = transform.gameObject;
				_oFiveKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill2":
				_oFiveKill2 = transform.gameObject;
				_oFiveKillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill3":
				_oFiveKill3 = transform.gameObject;
				_oFiveKillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill4":
				_oFiveKill4 = transform.gameObject;
				_oFiveKillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill5":
				_oFiveKill5 = transform.gameObject;
				_oFiveKillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill6":
				_oFiveKill6 = transform.gameObject;
				_oFiveKillImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill7":
				_oFiveKill7 = transform.gameObject;
				_oFiveKillImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill8":
				_oFiveKill8 = transform.gameObject;
				_oFiveKillImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill9":
				_oFiveKill9 = transform.gameObject;
				_oFiveKillImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill10":
				_oFiveKill10 = transform.gameObject;
				_oFiveKillImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill11":
				_oFiveKill11 = transform.gameObject;
				_oFiveKillImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill12":
				_oFiveKill12 = transform.gameObject;
				_oFiveKillImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill13":
				_oFiveKill13 = transform.gameObject;
				_oFiveKillImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill14":
				_oFiveKill14 = transform.gameObject;
				_oFiveKillImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill15":
				_oFiveKill15 = transform.gameObject;
				_oFiveKillImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill16":
				_oFiveKill16 = transform.gameObject;
				_oFiveKillImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill17":
				_oFiveKill17 = transform.gameObject;
				_oFiveKillImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill18":
				_oFiveKill18 = transform.gameObject;
				_oFiveKillImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill19":
				_oFiveKill19 = transform.gameObject;
				_oFiveKillImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveKill20":
				_oFiveKill20 = transform.gameObject;
				_oFiveKillImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill1":
				_oTenKill1 = transform.gameObject;
				_oTenKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill2":
				_oTenKill2 = transform.gameObject;
				_oTenKillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill3":
				_oTenKill3 = transform.gameObject;
				_oTenKillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill4":
				_oTenKill4 = transform.gameObject;
				_oTenKillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill5":
				_oTenKill5 = transform.gameObject;
				_oTenKillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill6":
				_oTenKill6 = transform.gameObject;
				_oTenKillImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill7":
				_oTenKill7 = transform.gameObject;
				_oTenKillImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill8":
				_oTenKill8 = transform.gameObject;
				_oTenKillImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill9":
				_oTenKill9 = transform.gameObject;
				_oTenKillImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill10":
				_oTenKill10 = transform.gameObject;
				_oTenKillImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill11":
				_oTenKill11 = transform.gameObject;
				_oTenKillImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill12":
				_oTenKill12 = transform.gameObject;
				_oTenKillImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill13":
				_oTenKill13 = transform.gameObject;
				_oTenKillImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill14":
				_oTenKill14 = transform.gameObject;
				_oTenKillImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill15":
				_oTenKill15 = transform.gameObject;
				_oTenKillImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill16":
				_oTenKill16 = transform.gameObject;
				_oTenKillImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill17":
				_oTenKill17 = transform.gameObject;
				_oTenKillImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill18":
				_oTenKill18 = transform.gameObject;
				_oTenKillImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill19":
				_oTenKill19 = transform.gameObject;
				_oTenKillImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenKill20":
				_oTenKill20 = transform.gameObject;
				_oTenKillImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill1":
				_oFiftyKill1 = transform.gameObject;
				_oFiftyKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill2":
				_oFiftyKill2 = transform.gameObject;
				_oFiftyKillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill3":
				_oFiftyKill3 = transform.gameObject;
				_oFiftyKillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill4":
				_oFiftyKill4 = transform.gameObject;
				_oFiftyKillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill5":
				_oFiftyKill5 = transform.gameObject;
				_oFiftyKillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill6":
				_oFiftyKill6 = transform.gameObject;
				_oFiftyKillImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill7":
				_oFiftyKill7 = transform.gameObject;
				_oFiftyKillImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill8":
				_oFiftyKill8 = transform.gameObject;
				_oFiftyKillImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill9":
				_oFiftyKill9 = transform.gameObject;
				_oFiftyKillImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill10":
				_oFiftyKill10 = transform.gameObject;
				_oFiftyKillImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill11":
				_oFiftyKill11 = transform.gameObject;
				_oFiftyKillImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill12":
				_oFiftyKill12 = transform.gameObject;
				_oFiftyKillImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill13":
				_oFiftyKill13 = transform.gameObject;
				_oFiftyKillImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill14":
				_oFiftyKill14 = transform.gameObject;
				_oFiftyKillImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill15":
				_oFiftyKill15 = transform.gameObject;
				_oFiftyKillImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill16":
				_oFiftyKill16 = transform.gameObject;
				_oFiftyKillImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill17":
				_oFiftyKill17 = transform.gameObject;
				_oFiftyKillImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill18":
				_oFiftyKill18 = transform.gameObject;
				_oFiftyKillImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill19":
				_oFiftyKill19 = transform.gameObject;
				_oFiftyKillImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyKill20":
				_oFiftyKill20 = transform.gameObject;
				_oFiftyKillImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill1":
				_oHundredKill1 = transform.gameObject;
				_oHundredKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill2":
				_oHundredKill2 = transform.gameObject;
				_oHundredKillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill3":
				_oHundredKill3 = transform.gameObject;
				_oHundredKillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill4":
				_oHundredKill4 = transform.gameObject;
				_oHundredKillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill5":
				_oHundredKill5 = transform.gameObject;
				_oHundredKillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill6":
				_oHundredKill6 = transform.gameObject;
				_oHundredKillImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill7":
				_oHundredKill7 = transform.gameObject;
				_oHundredKillImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill8":
				_oHundredKill8 = transform.gameObject;
				_oHundredKillImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill9":
				_oHundredKill9 = transform.gameObject;
				_oHundredKillImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill10":
				_oHundredKill10 = transform.gameObject;
				_oHundredKillImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill11":
				_oHundredKill11 = transform.gameObject;
				_oHundredKillImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill12":
				_oHundredKill12 = transform.gameObject;
				_oHundredKillImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill13":
				_oHundredKill13 = transform.gameObject;
				_oHundredKillImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill14":
				_oHundredKill14 = transform.gameObject;
				_oHundredKillImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill15":
				_oHundredKill15 = transform.gameObject;
				_oHundredKillImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill16":
				_oHundredKill16 = transform.gameObject;
				_oHundredKillImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill17":
				_oHundredKill17 = transform.gameObject;
				_oHundredKillImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill18":
				_oHundredKill18 = transform.gameObject;
				_oHundredKillImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill19":
				_oHundredKill19 = transform.gameObject;
				_oHundredKillImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredKill20":
				_oHundredKill20 = transform.gameObject;
				_oHundredKillImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist1":
				_oSingleAssist1 = transform.gameObject;
				_oSingleAssistImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist2":
				_oSingleAssist2 = transform.gameObject;
				_oSingleAssistImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist3":
				_oSingleAssist3 = transform.gameObject;
				_oSingleAssistImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist4":
				_oSingleAssist4 = transform.gameObject;
				_oSingleAssistImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist5":
				_oSingleAssist5 = transform.gameObject;
				_oSingleAssistImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist6":
				_oSingleAssist6 = transform.gameObject;
				_oSingleAssistImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist7":
				_oSingleAssist7 = transform.gameObject;
				_oSingleAssistImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist8":
				_oSingleAssist8 = transform.gameObject;
				_oSingleAssistImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist9":
				_oSingleAssist9 = transform.gameObject;
				_oSingleAssistImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist10":
				_oSingleAssist10 = transform.gameObject;
				_oSingleAssistImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist11":
				_oSingleAssist11 = transform.gameObject;
				_oSingleAssistImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist12":
				_oSingleAssist12 = transform.gameObject;
				_oSingleAssistImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist13":
				_oSingleAssist13 = transform.gameObject;
				_oSingleAssistImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist14":
				_oSingleAssist14 = transform.gameObject;
				_oSingleAssistImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist15":
				_oSingleAssist15 = transform.gameObject;
				_oSingleAssistImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist16":
				_oSingleAssist16 = transform.gameObject;
				_oSingleAssistImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist17":
				_oSingleAssist17 = transform.gameObject;
				_oSingleAssistImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist18":
				_oSingleAssist18 = transform.gameObject;
				_oSingleAssistImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist19":
				_oSingleAssist19 = transform.gameObject;
				_oSingleAssistImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "SingleAssist20":
				_oSingleAssist20 = transform.gameObject;
				_oSingleAssistImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist1":
				_oFiveAssist1 = transform.gameObject;
				_oFiveAssistImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist2":
				_oFiveAssist2 = transform.gameObject;
				_oFiveAssistImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist3":
				_oFiveAssist3 = transform.gameObject;
				_oFiveAssistImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist4":
				_oFiveAssist4 = transform.gameObject;
				_oFiveAssistImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist5":
				_oFiveAssist5 = transform.gameObject;
				_oFiveAssistImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist6":
				_oFiveAssist6 = transform.gameObject;
				_oFiveAssistImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist7":
				_oFiveAssist7 = transform.gameObject;
				_oFiveAssistImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist8":
				_oFiveAssist8 = transform.gameObject;
				_oFiveAssistImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist9":
				_oFiveAssist9 = transform.gameObject;
				_oFiveAssistImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist10":
				_oFiveAssist10 = transform.gameObject;
				_oFiveAssistImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist11":
				_oFiveAssist11 = transform.gameObject;
				_oFiveAssistImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist12":
				_oFiveAssist12 = transform.gameObject;
				_oFiveAssistImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist13":
				_oFiveAssist13 = transform.gameObject;
				_oFiveAssistImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist14":
				_oFiveAssist14 = transform.gameObject;
				_oFiveAssistImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist15":
				_oFiveAssist15 = transform.gameObject;
				_oFiveAssistImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist16":
				_oFiveAssist16 = transform.gameObject;
				_oFiveAssistImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist17":
				_oFiveAssist17 = transform.gameObject;
				_oFiveAssistImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist18":
				_oFiveAssist18 = transform.gameObject;
				_oFiveAssistImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist19":
				_oFiveAssist19 = transform.gameObject;
				_oFiveAssistImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiveAssist20":
				_oFiveAssist20 = transform.gameObject;
				_oFiveAssistImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist1":
				_oTenAssist1 = transform.gameObject;
				_oTenAssistImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist2":
				_oTenAssist2 = transform.gameObject;
				_oTenAssistImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist3":
				_oTenAssist3 = transform.gameObject;
				_oTenAssistImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist4":
				_oTenAssist4 = transform.gameObject;
				_oTenAssistImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist5":
				_oTenAssist5 = transform.gameObject;
				_oTenAssistImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist6":
				_oTenAssist6 = transform.gameObject;
				_oTenAssistImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist7":
				_oTenAssist7 = transform.gameObject;
				_oTenAssistImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist8":
				_oTenAssist8 = transform.gameObject;
				_oTenAssistImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist9":
				_oTenAssist9 = transform.gameObject;
				_oTenAssistImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist10":
				_oTenAssist10 = transform.gameObject;
				_oTenAssistImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist11":
				_oTenAssist11 = transform.gameObject;
				_oTenAssistImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist12":
				_oTenAssist12 = transform.gameObject;
				_oTenAssistImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist13":
				_oTenAssist13 = transform.gameObject;
				_oTenAssistImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist14":
				_oTenAssist14 = transform.gameObject;
				_oTenAssistImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist15":
				_oTenAssist15 = transform.gameObject;
				_oTenAssistImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist16":
				_oTenAssist16 = transform.gameObject;
				_oTenAssistImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist17":
				_oTenAssist17 = transform.gameObject;
				_oTenAssistImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist18":
				_oTenAssist18 = transform.gameObject;
				_oTenAssistImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist19":
				_oTenAssist19 = transform.gameObject;
				_oTenAssistImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "TenAssist20":
				_oTenAssist20 = transform.gameObject;
				_oTenAssistImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist1":
				_oFiftyAssist1 = transform.gameObject;
				_oFiftyAssistImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist2":
				_oFiftyAssist2 = transform.gameObject;
				_oFiftyAssistImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist3":
				_oFiftyAssist3 = transform.gameObject;
				_oFiftyAssistImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist4":
				_oFiftyAssist4 = transform.gameObject;
				_oFiftyAssistImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist5":
				_oFiftyAssist5 = transform.gameObject;
				_oFiftyAssistImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist6":
				_oFiftyAssist6 = transform.gameObject;
				_oFiftyAssistImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist7":
				_oFiftyAssist7 = transform.gameObject;
				_oFiftyAssistImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist8":
				_oFiftyAssist8 = transform.gameObject;
				_oFiftyAssistImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist9":
				_oFiftyAssist9 = transform.gameObject;
				_oFiftyAssistImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist10":
				_oFiftyAssist10 = transform.gameObject;
				_oFiftyAssistImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist11":
				_oFiftyAssist11 = transform.gameObject;
				_oFiftyAssistImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist12":
				_oFiftyAssist12 = transform.gameObject;
				_oFiftyAssistImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist13":
				_oFiftyAssist13 = transform.gameObject;
				_oFiftyAssistImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist14":
				_oFiftyAssist14 = transform.gameObject;
				_oFiftyAssistImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist15":
				_oFiftyAssist15 = transform.gameObject;
				_oFiftyAssistImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist16":
				_oFiftyAssist16 = transform.gameObject;
				_oFiftyAssistImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist17":
				_oFiftyAssist17 = transform.gameObject;
				_oFiftyAssistImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist18":
				_oFiftyAssist18 = transform.gameObject;
				_oFiftyAssistImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist19":
				_oFiftyAssist19 = transform.gameObject;
				_oFiftyAssistImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "FiftyAssist20":
				_oFiftyAssist20 = transform.gameObject;
				_oFiftyAssistImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist1":
				_oHundredAssist1 = transform.gameObject;
				_oHundredAssistImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist2":
				_oHundredAssist2 = transform.gameObject;
				_oHundredAssistImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist3":
				_oHundredAssist3 = transform.gameObject;
				_oHundredAssistImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist4":
				_oHundredAssist4 = transform.gameObject;
				_oHundredAssistImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist5":
				_oHundredAssist5 = transform.gameObject;
				_oHundredAssistImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist6":
				_oHundredAssist6 = transform.gameObject;
				_oHundredAssistImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist7":
				_oHundredAssist7 = transform.gameObject;
				_oHundredAssistImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist8":
				_oHundredAssist8 = transform.gameObject;
				_oHundredAssistImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist9":
				_oHundredAssist9 = transform.gameObject;
				_oHundredAssistImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist10":
				_oHundredAssist10 = transform.gameObject;
				_oHundredAssistImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist11":
				_oHundredAssist11 = transform.gameObject;
				_oHundredAssistImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist12":
				_oHundredAssist12 = transform.gameObject;
				_oHundredAssistImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist13":
				_oHundredAssist13 = transform.gameObject;
				_oHundredAssistImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist14":
				_oHundredAssist14 = transform.gameObject;
				_oHundredAssistImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist15":
				_oHundredAssist15 = transform.gameObject;
				_oHundredAssistImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist16":
				_oHundredAssist16 = transform.gameObject;
				_oHundredAssistImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist17":
				_oHundredAssist17 = transform.gameObject;
				_oHundredAssistImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist18":
				_oHundredAssist18 = transform.gameObject;
				_oHundredAssistImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist19":
				_oHundredAssist19 = transform.gameObject;
				_oHundredAssistImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "HundredAssist20":
				_oHundredAssist20 = transform.gameObject;
				_oHundredAssistImage20 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetSlotShow(int index)
	{
		return index switch
		{
			1 => SlotShow1, 
			2 => SlotShow2, 
			3 => SlotShow3, 
			4 => SlotShow4, 
			5 => SlotShow5, 
			6 => SlotShow6, 
			7 => SlotShow7, 
			8 => SlotShow8, 
			9 => SlotShow9, 
			10 => SlotShow10, 
			11 => SlotShow11, 
			12 => SlotShow12, 
			13 => SlotShow13, 
			14 => SlotShow14, 
			15 => SlotShow15, 
			16 => SlotShow16, 
			17 => SlotShow17, 
			18 => SlotShow18, 
			19 => SlotShow19, 
			20 => SlotShow20, 
			_ => false, 
		};
	}

	public void SetSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlotShow1 = value;
			break;
		case 2:
			SlotShow2 = value;
			break;
		case 3:
			SlotShow3 = value;
			break;
		case 4:
			SlotShow4 = value;
			break;
		case 5:
			SlotShow5 = value;
			break;
		case 6:
			SlotShow6 = value;
			break;
		case 7:
			SlotShow7 = value;
			break;
		case 8:
			SlotShow8 = value;
			break;
		case 9:
			SlotShow9 = value;
			break;
		case 10:
			SlotShow10 = value;
			break;
		case 11:
			SlotShow11 = value;
			break;
		case 12:
			SlotShow12 = value;
			break;
		case 13:
			SlotShow13 = value;
			break;
		case 14:
			SlotShow14 = value;
			break;
		case 15:
			SlotShow15 = value;
			break;
		case 16:
			SlotShow16 = value;
			break;
		case 17:
			SlotShow17 = value;
			break;
		case 18:
			SlotShow18 = value;
			break;
		case 19:
			SlotShow19 = value;
			break;
		case 20:
			SlotShow20 = value;
			break;
		}
	}

	public bool GetSingleKillEnabled(int index)
	{
		return index switch
		{
			1 => SingleKillEnabled1, 
			2 => SingleKillEnabled2, 
			3 => SingleKillEnabled3, 
			4 => SingleKillEnabled4, 
			5 => SingleKillEnabled5, 
			6 => SingleKillEnabled6, 
			7 => SingleKillEnabled7, 
			8 => SingleKillEnabled8, 
			9 => SingleKillEnabled9, 
			10 => SingleKillEnabled10, 
			11 => SingleKillEnabled11, 
			12 => SingleKillEnabled12, 
			13 => SingleKillEnabled13, 
			14 => SingleKillEnabled14, 
			15 => SingleKillEnabled15, 
			16 => SingleKillEnabled16, 
			17 => SingleKillEnabled17, 
			18 => SingleKillEnabled18, 
			19 => SingleKillEnabled19, 
			20 => SingleKillEnabled20, 
			_ => false, 
		};
	}

	public void SetSingleKillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SingleKillEnabled1 = value;
			break;
		case 2:
			SingleKillEnabled2 = value;
			break;
		case 3:
			SingleKillEnabled3 = value;
			break;
		case 4:
			SingleKillEnabled4 = value;
			break;
		case 5:
			SingleKillEnabled5 = value;
			break;
		case 6:
			SingleKillEnabled6 = value;
			break;
		case 7:
			SingleKillEnabled7 = value;
			break;
		case 8:
			SingleKillEnabled8 = value;
			break;
		case 9:
			SingleKillEnabled9 = value;
			break;
		case 10:
			SingleKillEnabled10 = value;
			break;
		case 11:
			SingleKillEnabled11 = value;
			break;
		case 12:
			SingleKillEnabled12 = value;
			break;
		case 13:
			SingleKillEnabled13 = value;
			break;
		case 14:
			SingleKillEnabled14 = value;
			break;
		case 15:
			SingleKillEnabled15 = value;
			break;
		case 16:
			SingleKillEnabled16 = value;
			break;
		case 17:
			SingleKillEnabled17 = value;
			break;
		case 18:
			SingleKillEnabled18 = value;
			break;
		case 19:
			SingleKillEnabled19 = value;
			break;
		case 20:
			SingleKillEnabled20 = value;
			break;
		}
	}

	public bool GetHeadShotEnabled(int index)
	{
		return index switch
		{
			1 => HeadShotEnabled1, 
			2 => HeadShotEnabled2, 
			3 => HeadShotEnabled3, 
			4 => HeadShotEnabled4, 
			5 => HeadShotEnabled5, 
			6 => HeadShotEnabled6, 
			7 => HeadShotEnabled7, 
			8 => HeadShotEnabled8, 
			9 => HeadShotEnabled9, 
			10 => HeadShotEnabled10, 
			11 => HeadShotEnabled11, 
			12 => HeadShotEnabled12, 
			13 => HeadShotEnabled13, 
			14 => HeadShotEnabled14, 
			15 => HeadShotEnabled15, 
			16 => HeadShotEnabled16, 
			17 => HeadShotEnabled17, 
			18 => HeadShotEnabled18, 
			19 => HeadShotEnabled19, 
			20 => HeadShotEnabled20, 
			_ => false, 
		};
	}

	public void SetHeadShotEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HeadShotEnabled1 = value;
			break;
		case 2:
			HeadShotEnabled2 = value;
			break;
		case 3:
			HeadShotEnabled3 = value;
			break;
		case 4:
			HeadShotEnabled4 = value;
			break;
		case 5:
			HeadShotEnabled5 = value;
			break;
		case 6:
			HeadShotEnabled6 = value;
			break;
		case 7:
			HeadShotEnabled7 = value;
			break;
		case 8:
			HeadShotEnabled8 = value;
			break;
		case 9:
			HeadShotEnabled9 = value;
			break;
		case 10:
			HeadShotEnabled10 = value;
			break;
		case 11:
			HeadShotEnabled11 = value;
			break;
		case 12:
			HeadShotEnabled12 = value;
			break;
		case 13:
			HeadShotEnabled13 = value;
			break;
		case 14:
			HeadShotEnabled14 = value;
			break;
		case 15:
			HeadShotEnabled15 = value;
			break;
		case 16:
			HeadShotEnabled16 = value;
			break;
		case 17:
			HeadShotEnabled17 = value;
			break;
		case 18:
			HeadShotEnabled18 = value;
			break;
		case 19:
			HeadShotEnabled19 = value;
			break;
		case 20:
			HeadShotEnabled20 = value;
			break;
		}
	}

	public bool GetFiveKillEnabled(int index)
	{
		return index switch
		{
			1 => FiveKillEnabled1, 
			2 => FiveKillEnabled2, 
			3 => FiveKillEnabled3, 
			4 => FiveKillEnabled4, 
			5 => FiveKillEnabled5, 
			6 => FiveKillEnabled6, 
			7 => FiveKillEnabled7, 
			8 => FiveKillEnabled8, 
			9 => FiveKillEnabled9, 
			10 => FiveKillEnabled10, 
			11 => FiveKillEnabled11, 
			12 => FiveKillEnabled12, 
			13 => FiveKillEnabled13, 
			14 => FiveKillEnabled14, 
			15 => FiveKillEnabled15, 
			16 => FiveKillEnabled16, 
			17 => FiveKillEnabled17, 
			18 => FiveKillEnabled18, 
			19 => FiveKillEnabled19, 
			20 => FiveKillEnabled20, 
			_ => false, 
		};
	}

	public void SetFiveKillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FiveKillEnabled1 = value;
			break;
		case 2:
			FiveKillEnabled2 = value;
			break;
		case 3:
			FiveKillEnabled3 = value;
			break;
		case 4:
			FiveKillEnabled4 = value;
			break;
		case 5:
			FiveKillEnabled5 = value;
			break;
		case 6:
			FiveKillEnabled6 = value;
			break;
		case 7:
			FiveKillEnabled7 = value;
			break;
		case 8:
			FiveKillEnabled8 = value;
			break;
		case 9:
			FiveKillEnabled9 = value;
			break;
		case 10:
			FiveKillEnabled10 = value;
			break;
		case 11:
			FiveKillEnabled11 = value;
			break;
		case 12:
			FiveKillEnabled12 = value;
			break;
		case 13:
			FiveKillEnabled13 = value;
			break;
		case 14:
			FiveKillEnabled14 = value;
			break;
		case 15:
			FiveKillEnabled15 = value;
			break;
		case 16:
			FiveKillEnabled16 = value;
			break;
		case 17:
			FiveKillEnabled17 = value;
			break;
		case 18:
			FiveKillEnabled18 = value;
			break;
		case 19:
			FiveKillEnabled19 = value;
			break;
		case 20:
			FiveKillEnabled20 = value;
			break;
		}
	}

	public bool GetTenKillEnabled(int index)
	{
		return index switch
		{
			1 => TenKillEnabled1, 
			2 => TenKillEnabled2, 
			3 => TenKillEnabled3, 
			4 => TenKillEnabled4, 
			5 => TenKillEnabled5, 
			6 => TenKillEnabled6, 
			7 => TenKillEnabled7, 
			8 => TenKillEnabled8, 
			9 => TenKillEnabled9, 
			10 => TenKillEnabled10, 
			11 => TenKillEnabled11, 
			12 => TenKillEnabled12, 
			13 => TenKillEnabled13, 
			14 => TenKillEnabled14, 
			15 => TenKillEnabled15, 
			16 => TenKillEnabled16, 
			17 => TenKillEnabled17, 
			18 => TenKillEnabled18, 
			19 => TenKillEnabled19, 
			20 => TenKillEnabled20, 
			_ => false, 
		};
	}

	public void SetTenKillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TenKillEnabled1 = value;
			break;
		case 2:
			TenKillEnabled2 = value;
			break;
		case 3:
			TenKillEnabled3 = value;
			break;
		case 4:
			TenKillEnabled4 = value;
			break;
		case 5:
			TenKillEnabled5 = value;
			break;
		case 6:
			TenKillEnabled6 = value;
			break;
		case 7:
			TenKillEnabled7 = value;
			break;
		case 8:
			TenKillEnabled8 = value;
			break;
		case 9:
			TenKillEnabled9 = value;
			break;
		case 10:
			TenKillEnabled10 = value;
			break;
		case 11:
			TenKillEnabled11 = value;
			break;
		case 12:
			TenKillEnabled12 = value;
			break;
		case 13:
			TenKillEnabled13 = value;
			break;
		case 14:
			TenKillEnabled14 = value;
			break;
		case 15:
			TenKillEnabled15 = value;
			break;
		case 16:
			TenKillEnabled16 = value;
			break;
		case 17:
			TenKillEnabled17 = value;
			break;
		case 18:
			TenKillEnabled18 = value;
			break;
		case 19:
			TenKillEnabled19 = value;
			break;
		case 20:
			TenKillEnabled20 = value;
			break;
		}
	}

	public bool GetFiftyKillEnabled(int index)
	{
		return index switch
		{
			1 => FiftyKillEnabled1, 
			2 => FiftyKillEnabled2, 
			3 => FiftyKillEnabled3, 
			4 => FiftyKillEnabled4, 
			5 => FiftyKillEnabled5, 
			6 => FiftyKillEnabled6, 
			7 => FiftyKillEnabled7, 
			8 => FiftyKillEnabled8, 
			9 => FiftyKillEnabled9, 
			10 => FiftyKillEnabled10, 
			11 => FiftyKillEnabled11, 
			12 => FiftyKillEnabled12, 
			13 => FiftyKillEnabled13, 
			14 => FiftyKillEnabled14, 
			15 => FiftyKillEnabled15, 
			16 => FiftyKillEnabled16, 
			17 => FiftyKillEnabled17, 
			18 => FiftyKillEnabled18, 
			19 => FiftyKillEnabled19, 
			20 => FiftyKillEnabled20, 
			_ => false, 
		};
	}

	public void SetFiftyKillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FiftyKillEnabled1 = value;
			break;
		case 2:
			FiftyKillEnabled2 = value;
			break;
		case 3:
			FiftyKillEnabled3 = value;
			break;
		case 4:
			FiftyKillEnabled4 = value;
			break;
		case 5:
			FiftyKillEnabled5 = value;
			break;
		case 6:
			FiftyKillEnabled6 = value;
			break;
		case 7:
			FiftyKillEnabled7 = value;
			break;
		case 8:
			FiftyKillEnabled8 = value;
			break;
		case 9:
			FiftyKillEnabled9 = value;
			break;
		case 10:
			FiftyKillEnabled10 = value;
			break;
		case 11:
			FiftyKillEnabled11 = value;
			break;
		case 12:
			FiftyKillEnabled12 = value;
			break;
		case 13:
			FiftyKillEnabled13 = value;
			break;
		case 14:
			FiftyKillEnabled14 = value;
			break;
		case 15:
			FiftyKillEnabled15 = value;
			break;
		case 16:
			FiftyKillEnabled16 = value;
			break;
		case 17:
			FiftyKillEnabled17 = value;
			break;
		case 18:
			FiftyKillEnabled18 = value;
			break;
		case 19:
			FiftyKillEnabled19 = value;
			break;
		case 20:
			FiftyKillEnabled20 = value;
			break;
		}
	}

	public bool GetHundredKillEnabled(int index)
	{
		return index switch
		{
			1 => HundredKillEnabled1, 
			2 => HundredKillEnabled2, 
			3 => HundredKillEnabled3, 
			4 => HundredKillEnabled4, 
			5 => HundredKillEnabled5, 
			6 => HundredKillEnabled6, 
			7 => HundredKillEnabled7, 
			8 => HundredKillEnabled8, 
			9 => HundredKillEnabled9, 
			10 => HundredKillEnabled10, 
			11 => HundredKillEnabled11, 
			12 => HundredKillEnabled12, 
			13 => HundredKillEnabled13, 
			14 => HundredKillEnabled14, 
			15 => HundredKillEnabled15, 
			16 => HundredKillEnabled16, 
			17 => HundredKillEnabled17, 
			18 => HundredKillEnabled18, 
			19 => HundredKillEnabled19, 
			20 => HundredKillEnabled20, 
			_ => false, 
		};
	}

	public void SetHundredKillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HundredKillEnabled1 = value;
			break;
		case 2:
			HundredKillEnabled2 = value;
			break;
		case 3:
			HundredKillEnabled3 = value;
			break;
		case 4:
			HundredKillEnabled4 = value;
			break;
		case 5:
			HundredKillEnabled5 = value;
			break;
		case 6:
			HundredKillEnabled6 = value;
			break;
		case 7:
			HundredKillEnabled7 = value;
			break;
		case 8:
			HundredKillEnabled8 = value;
			break;
		case 9:
			HundredKillEnabled9 = value;
			break;
		case 10:
			HundredKillEnabled10 = value;
			break;
		case 11:
			HundredKillEnabled11 = value;
			break;
		case 12:
			HundredKillEnabled12 = value;
			break;
		case 13:
			HundredKillEnabled13 = value;
			break;
		case 14:
			HundredKillEnabled14 = value;
			break;
		case 15:
			HundredKillEnabled15 = value;
			break;
		case 16:
			HundredKillEnabled16 = value;
			break;
		case 17:
			HundredKillEnabled17 = value;
			break;
		case 18:
			HundredKillEnabled18 = value;
			break;
		case 19:
			HundredKillEnabled19 = value;
			break;
		case 20:
			HundredKillEnabled20 = value;
			break;
		}
	}

	public bool GetSingleAssistEnabled(int index)
	{
		return index switch
		{
			1 => SingleAssistEnabled1, 
			2 => SingleAssistEnabled2, 
			3 => SingleAssistEnabled3, 
			4 => SingleAssistEnabled4, 
			5 => SingleAssistEnabled5, 
			6 => SingleAssistEnabled6, 
			7 => SingleAssistEnabled7, 
			8 => SingleAssistEnabled8, 
			9 => SingleAssistEnabled9, 
			10 => SingleAssistEnabled10, 
			11 => SingleAssistEnabled11, 
			12 => SingleAssistEnabled12, 
			13 => SingleAssistEnabled13, 
			14 => SingleAssistEnabled14, 
			15 => SingleAssistEnabled15, 
			16 => SingleAssistEnabled16, 
			17 => SingleAssistEnabled17, 
			18 => SingleAssistEnabled18, 
			19 => SingleAssistEnabled19, 
			20 => SingleAssistEnabled20, 
			_ => false, 
		};
	}

	public void SetSingleAssistEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SingleAssistEnabled1 = value;
			break;
		case 2:
			SingleAssistEnabled2 = value;
			break;
		case 3:
			SingleAssistEnabled3 = value;
			break;
		case 4:
			SingleAssistEnabled4 = value;
			break;
		case 5:
			SingleAssistEnabled5 = value;
			break;
		case 6:
			SingleAssistEnabled6 = value;
			break;
		case 7:
			SingleAssistEnabled7 = value;
			break;
		case 8:
			SingleAssistEnabled8 = value;
			break;
		case 9:
			SingleAssistEnabled9 = value;
			break;
		case 10:
			SingleAssistEnabled10 = value;
			break;
		case 11:
			SingleAssistEnabled11 = value;
			break;
		case 12:
			SingleAssistEnabled12 = value;
			break;
		case 13:
			SingleAssistEnabled13 = value;
			break;
		case 14:
			SingleAssistEnabled14 = value;
			break;
		case 15:
			SingleAssistEnabled15 = value;
			break;
		case 16:
			SingleAssistEnabled16 = value;
			break;
		case 17:
			SingleAssistEnabled17 = value;
			break;
		case 18:
			SingleAssistEnabled18 = value;
			break;
		case 19:
			SingleAssistEnabled19 = value;
			break;
		case 20:
			SingleAssistEnabled20 = value;
			break;
		}
	}

	public bool GetFiveAssistEnabled(int index)
	{
		return index switch
		{
			1 => FiveAssistEnabled1, 
			2 => FiveAssistEnabled2, 
			3 => FiveAssistEnabled3, 
			4 => FiveAssistEnabled4, 
			5 => FiveAssistEnabled5, 
			6 => FiveAssistEnabled6, 
			7 => FiveAssistEnabled7, 
			8 => FiveAssistEnabled8, 
			9 => FiveAssistEnabled9, 
			10 => FiveAssistEnabled10, 
			11 => FiveAssistEnabled11, 
			12 => FiveAssistEnabled12, 
			13 => FiveAssistEnabled13, 
			14 => FiveAssistEnabled14, 
			15 => FiveAssistEnabled15, 
			16 => FiveAssistEnabled16, 
			17 => FiveAssistEnabled17, 
			18 => FiveAssistEnabled18, 
			19 => FiveAssistEnabled19, 
			20 => FiveAssistEnabled20, 
			_ => false, 
		};
	}

	public void SetFiveAssistEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FiveAssistEnabled1 = value;
			break;
		case 2:
			FiveAssistEnabled2 = value;
			break;
		case 3:
			FiveAssistEnabled3 = value;
			break;
		case 4:
			FiveAssistEnabled4 = value;
			break;
		case 5:
			FiveAssistEnabled5 = value;
			break;
		case 6:
			FiveAssistEnabled6 = value;
			break;
		case 7:
			FiveAssistEnabled7 = value;
			break;
		case 8:
			FiveAssistEnabled8 = value;
			break;
		case 9:
			FiveAssistEnabled9 = value;
			break;
		case 10:
			FiveAssistEnabled10 = value;
			break;
		case 11:
			FiveAssistEnabled11 = value;
			break;
		case 12:
			FiveAssistEnabled12 = value;
			break;
		case 13:
			FiveAssistEnabled13 = value;
			break;
		case 14:
			FiveAssistEnabled14 = value;
			break;
		case 15:
			FiveAssistEnabled15 = value;
			break;
		case 16:
			FiveAssistEnabled16 = value;
			break;
		case 17:
			FiveAssistEnabled17 = value;
			break;
		case 18:
			FiveAssistEnabled18 = value;
			break;
		case 19:
			FiveAssistEnabled19 = value;
			break;
		case 20:
			FiveAssistEnabled20 = value;
			break;
		}
	}

	public bool GetTenAssistEnabled(int index)
	{
		return index switch
		{
			1 => TenAssistEnabled1, 
			2 => TenAssistEnabled2, 
			3 => TenAssistEnabled3, 
			4 => TenAssistEnabled4, 
			5 => TenAssistEnabled5, 
			6 => TenAssistEnabled6, 
			7 => TenAssistEnabled7, 
			8 => TenAssistEnabled8, 
			9 => TenAssistEnabled9, 
			10 => TenAssistEnabled10, 
			11 => TenAssistEnabled11, 
			12 => TenAssistEnabled12, 
			13 => TenAssistEnabled13, 
			14 => TenAssistEnabled14, 
			15 => TenAssistEnabled15, 
			16 => TenAssistEnabled16, 
			17 => TenAssistEnabled17, 
			18 => TenAssistEnabled18, 
			19 => TenAssistEnabled19, 
			20 => TenAssistEnabled20, 
			_ => false, 
		};
	}

	public void SetTenAssistEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TenAssistEnabled1 = value;
			break;
		case 2:
			TenAssistEnabled2 = value;
			break;
		case 3:
			TenAssistEnabled3 = value;
			break;
		case 4:
			TenAssistEnabled4 = value;
			break;
		case 5:
			TenAssistEnabled5 = value;
			break;
		case 6:
			TenAssistEnabled6 = value;
			break;
		case 7:
			TenAssistEnabled7 = value;
			break;
		case 8:
			TenAssistEnabled8 = value;
			break;
		case 9:
			TenAssistEnabled9 = value;
			break;
		case 10:
			TenAssistEnabled10 = value;
			break;
		case 11:
			TenAssistEnabled11 = value;
			break;
		case 12:
			TenAssistEnabled12 = value;
			break;
		case 13:
			TenAssistEnabled13 = value;
			break;
		case 14:
			TenAssistEnabled14 = value;
			break;
		case 15:
			TenAssistEnabled15 = value;
			break;
		case 16:
			TenAssistEnabled16 = value;
			break;
		case 17:
			TenAssistEnabled17 = value;
			break;
		case 18:
			TenAssistEnabled18 = value;
			break;
		case 19:
			TenAssistEnabled19 = value;
			break;
		case 20:
			TenAssistEnabled20 = value;
			break;
		}
	}

	public bool GetFiftyAssistEnabled(int index)
	{
		return index switch
		{
			1 => FiftyAssistEnabled1, 
			2 => FiftyAssistEnabled2, 
			3 => FiftyAssistEnabled3, 
			4 => FiftyAssistEnabled4, 
			5 => FiftyAssistEnabled5, 
			6 => FiftyAssistEnabled6, 
			7 => FiftyAssistEnabled7, 
			8 => FiftyAssistEnabled8, 
			9 => FiftyAssistEnabled9, 
			10 => FiftyAssistEnabled10, 
			11 => FiftyAssistEnabled11, 
			12 => FiftyAssistEnabled12, 
			13 => FiftyAssistEnabled13, 
			14 => FiftyAssistEnabled14, 
			15 => FiftyAssistEnabled15, 
			16 => FiftyAssistEnabled16, 
			17 => FiftyAssistEnabled17, 
			18 => FiftyAssistEnabled18, 
			19 => FiftyAssistEnabled19, 
			20 => FiftyAssistEnabled20, 
			_ => false, 
		};
	}

	public void SetFiftyAssistEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FiftyAssistEnabled1 = value;
			break;
		case 2:
			FiftyAssistEnabled2 = value;
			break;
		case 3:
			FiftyAssistEnabled3 = value;
			break;
		case 4:
			FiftyAssistEnabled4 = value;
			break;
		case 5:
			FiftyAssistEnabled5 = value;
			break;
		case 6:
			FiftyAssistEnabled6 = value;
			break;
		case 7:
			FiftyAssistEnabled7 = value;
			break;
		case 8:
			FiftyAssistEnabled8 = value;
			break;
		case 9:
			FiftyAssistEnabled9 = value;
			break;
		case 10:
			FiftyAssistEnabled10 = value;
			break;
		case 11:
			FiftyAssistEnabled11 = value;
			break;
		case 12:
			FiftyAssistEnabled12 = value;
			break;
		case 13:
			FiftyAssistEnabled13 = value;
			break;
		case 14:
			FiftyAssistEnabled14 = value;
			break;
		case 15:
			FiftyAssistEnabled15 = value;
			break;
		case 16:
			FiftyAssistEnabled16 = value;
			break;
		case 17:
			FiftyAssistEnabled17 = value;
			break;
		case 18:
			FiftyAssistEnabled18 = value;
			break;
		case 19:
			FiftyAssistEnabled19 = value;
			break;
		case 20:
			FiftyAssistEnabled20 = value;
			break;
		}
	}

	public bool GetHundredAssistEnabled(int index)
	{
		return index switch
		{
			1 => HundredAssistEnabled1, 
			2 => HundredAssistEnabled2, 
			3 => HundredAssistEnabled3, 
			4 => HundredAssistEnabled4, 
			5 => HundredAssistEnabled5, 
			6 => HundredAssistEnabled6, 
			7 => HundredAssistEnabled7, 
			8 => HundredAssistEnabled8, 
			9 => HundredAssistEnabled9, 
			10 => HundredAssistEnabled10, 
			11 => HundredAssistEnabled11, 
			12 => HundredAssistEnabled12, 
			13 => HundredAssistEnabled13, 
			14 => HundredAssistEnabled14, 
			15 => HundredAssistEnabled15, 
			16 => HundredAssistEnabled16, 
			17 => HundredAssistEnabled17, 
			18 => HundredAssistEnabled18, 
			19 => HundredAssistEnabled19, 
			20 => HundredAssistEnabled20, 
			_ => false, 
		};
	}

	public void SetHundredAssistEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HundredAssistEnabled1 = value;
			break;
		case 2:
			HundredAssistEnabled2 = value;
			break;
		case 3:
			HundredAssistEnabled3 = value;
			break;
		case 4:
			HundredAssistEnabled4 = value;
			break;
		case 5:
			HundredAssistEnabled5 = value;
			break;
		case 6:
			HundredAssistEnabled6 = value;
			break;
		case 7:
			HundredAssistEnabled7 = value;
			break;
		case 8:
			HundredAssistEnabled8 = value;
			break;
		case 9:
			HundredAssistEnabled9 = value;
			break;
		case 10:
			HundredAssistEnabled10 = value;
			break;
		case 11:
			HundredAssistEnabled11 = value;
			break;
		case 12:
			HundredAssistEnabled12 = value;
			break;
		case 13:
			HundredAssistEnabled13 = value;
			break;
		case 14:
			HundredAssistEnabled14 = value;
			break;
		case 15:
			HundredAssistEnabled15 = value;
			break;
		case 16:
			HundredAssistEnabled16 = value;
			break;
		case 17:
			HundredAssistEnabled17 = value;
			break;
		case 18:
			HundredAssistEnabled18 = value;
			break;
		case 19:
			HundredAssistEnabled19 = value;
			break;
		case 20:
			HundredAssistEnabled20 = value;
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
