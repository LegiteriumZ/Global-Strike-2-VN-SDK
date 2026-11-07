using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ObserverAllKillInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oCtPlayer1;

	private GameObject _oCtPlayer2;

	private GameObject _oCtPlayer3;

	private GameObject _oCtPlayer4;

	private GameObject _oCtPlayer5;

	private GameObject _oCtPlayer6;

	private GameObject _oCtPlayer7;

	private GameObject _oCtPlayer8;

	private EventTrigger _oCtPlayerEventTrigger1;

	private EventTrigger _oCtPlayerEventTrigger2;

	private EventTrigger _oCtPlayerEventTrigger3;

	private EventTrigger _oCtPlayerEventTrigger4;

	private EventTrigger _oCtPlayerEventTrigger5;

	private EventTrigger _oCtPlayerEventTrigger6;

	private EventTrigger _oCtPlayerEventTrigger7;

	private EventTrigger _oCtPlayerEventTrigger8;

	private GameObject _oCtHpRecImage1;

	private GameObject _oCtHpRecImage2;

	private GameObject _oCtHpRecImage3;

	private GameObject _oCtHpRecImage4;

	private GameObject _oCtHpRecImage5;

	private GameObject _oCtHpRecImage6;

	private GameObject _oCtHpRecImage7;

	private GameObject _oCtHpRecImage8;

	private Image _oCtHpRecImageImage1;

	private Image _oCtHpRecImageImage2;

	private Image _oCtHpRecImageImage3;

	private Image _oCtHpRecImageImage4;

	private Image _oCtHpRecImageImage5;

	private Image _oCtHpRecImageImage6;

	private Image _oCtHpRecImageImage7;

	private Image _oCtHpRecImageImage8;

	private GameObject _oCtHpTriImage1;

	private GameObject _oCtHpTriImage2;

	private GameObject _oCtHpTriImage3;

	private GameObject _oCtHpTriImage4;

	private GameObject _oCtHpTriImage5;

	private GameObject _oCtHpTriImage6;

	private GameObject _oCtHpTriImage7;

	private GameObject _oCtHpTriImage8;

	private RectTransform _oCtHpTriImageRectTransform1;

	private RectTransform _oCtHpTriImageRectTransform2;

	private RectTransform _oCtHpTriImageRectTransform3;

	private RectTransform _oCtHpTriImageRectTransform4;

	private RectTransform _oCtHpTriImageRectTransform5;

	private RectTransform _oCtHpTriImageRectTransform6;

	private RectTransform _oCtHpTriImageRectTransform7;

	private RectTransform _oCtHpTriImageRectTransform8;

	private GameObject _oCtUnchecked1;

	private GameObject _oCtUnchecked2;

	private GameObject _oCtUnchecked3;

	private GameObject _oCtUnchecked4;

	private GameObject _oCtUnchecked5;

	private GameObject _oCtUnchecked6;

	private GameObject _oCtUnchecked7;

	private GameObject _oCtUnchecked8;

	private GameObject _oCtChecked1;

	private GameObject _oCtChecked2;

	private GameObject _oCtChecked3;

	private GameObject _oCtChecked4;

	private GameObject _oCtChecked5;

	private GameObject _oCtChecked6;

	private GameObject _oCtChecked7;

	private GameObject _oCtChecked8;

	private GameObject _oCtKillCount1;

	private GameObject _oCtKillCount2;

	private GameObject _oCtKillCount3;

	private GameObject _oCtKillCount4;

	private GameObject _oCtKillCount5;

	private GameObject _oCtKillCount6;

	private GameObject _oCtKillCount7;

	private GameObject _oCtKillCount8;

	private Text _oCtKillCountText1;

	private Text _oCtKillCountText2;

	private Text _oCtKillCountText3;

	private Text _oCtKillCountText4;

	private Text _oCtKillCountText5;

	private Text _oCtKillCountText6;

	private Text _oCtKillCountText7;

	private Text _oCtKillCountText8;

	private GameObject _oCtHpCount1;

	private GameObject _oCtHpCount2;

	private GameObject _oCtHpCount3;

	private GameObject _oCtHpCount4;

	private GameObject _oCtHpCount5;

	private GameObject _oCtHpCount6;

	private GameObject _oCtHpCount7;

	private GameObject _oCtHpCount8;

	private Text _oCtHpCountText1;

	private Text _oCtHpCountText2;

	private Text _oCtHpCountText3;

	private Text _oCtHpCountText4;

	private Text _oCtHpCountText5;

	private Text _oCtHpCountText6;

	private Text _oCtHpCountText7;

	private Text _oCtHpCountText8;

	private GameObject _oCtPlayerName1;

	private GameObject _oCtPlayerName2;

	private GameObject _oCtPlayerName3;

	private GameObject _oCtPlayerName4;

	private GameObject _oCtPlayerName5;

	private GameObject _oCtPlayerName6;

	private GameObject _oCtPlayerName7;

	private GameObject _oCtPlayerName8;

	private Text _oCtPlayerNameText1;

	private Text _oCtPlayerNameText2;

	private Text _oCtPlayerNameText3;

	private Text _oCtPlayerNameText4;

	private Text _oCtPlayerNameText5;

	private Text _oCtPlayerNameText6;

	private Text _oCtPlayerNameText7;

	private Text _oCtPlayerNameText8;

	private GameObject _oCtWeapon1;

	private GameObject _oCtWeapon2;

	private GameObject _oCtWeapon3;

	private GameObject _oCtWeapon4;

	private GameObject _oCtWeapon5;

	private GameObject _oCtWeapon6;

	private GameObject _oCtWeapon7;

	private GameObject _oCtWeapon8;

	private Image _oCtWeaponImage1;

	private Image _oCtWeaponImage2;

	private Image _oCtWeaponImage3;

	private Image _oCtWeaponImage4;

	private Image _oCtWeaponImage5;

	private Image _oCtWeaponImage6;

	private Image _oCtWeaponImage7;

	private Image _oCtWeaponImage8;

	private GameObject _oCtDoun1;

	private GameObject _oCtDoun2;

	private GameObject _oCtDoun3;

	private GameObject _oCtDoun4;

	private GameObject _oCtDoun5;

	private GameObject _oCtDoun6;

	private GameObject _oCtDoun7;

	private GameObject _oCtDoun8;

	private GameObject _oTPlayer1;

	private GameObject _oTPlayer2;

	private GameObject _oTPlayer3;

	private GameObject _oTPlayer4;

	private GameObject _oTPlayer5;

	private GameObject _oTPlayer6;

	private GameObject _oTPlayer7;

	private GameObject _oTPlayer8;

	private EventTrigger _oTPlayerEventTrigger1;

	private EventTrigger _oTPlayerEventTrigger2;

	private EventTrigger _oTPlayerEventTrigger3;

	private EventTrigger _oTPlayerEventTrigger4;

	private EventTrigger _oTPlayerEventTrigger5;

	private EventTrigger _oTPlayerEventTrigger6;

	private EventTrigger _oTPlayerEventTrigger7;

	private EventTrigger _oTPlayerEventTrigger8;

	private GameObject _oTHpRecImage1;

	private GameObject _oTHpRecImage2;

	private GameObject _oTHpRecImage3;

	private GameObject _oTHpRecImage4;

	private GameObject _oTHpRecImage5;

	private GameObject _oTHpRecImage6;

	private GameObject _oTHpRecImage7;

	private GameObject _oTHpRecImage8;

	private Image _oTHpRecImageImage1;

	private Image _oTHpRecImageImage2;

	private Image _oTHpRecImageImage3;

	private Image _oTHpRecImageImage4;

	private Image _oTHpRecImageImage5;

	private Image _oTHpRecImageImage6;

	private Image _oTHpRecImageImage7;

	private Image _oTHpRecImageImage8;

	private GameObject _oTHpTriImage1;

	private GameObject _oTHpTriImage2;

	private GameObject _oTHpTriImage3;

	private GameObject _oTHpTriImage4;

	private GameObject _oTHpTriImage5;

	private GameObject _oTHpTriImage6;

	private GameObject _oTHpTriImage7;

	private GameObject _oTHpTriImage8;

	private RectTransform _oTHpTriImageRectTransform1;

	private RectTransform _oTHpTriImageRectTransform2;

	private RectTransform _oTHpTriImageRectTransform3;

	private RectTransform _oTHpTriImageRectTransform4;

	private RectTransform _oTHpTriImageRectTransform5;

	private RectTransform _oTHpTriImageRectTransform6;

	private RectTransform _oTHpTriImageRectTransform7;

	private RectTransform _oTHpTriImageRectTransform8;

	private GameObject _oTUnchecked1;

	private GameObject _oTUnchecked2;

	private GameObject _oTUnchecked3;

	private GameObject _oTUnchecked4;

	private GameObject _oTUnchecked5;

	private GameObject _oTUnchecked6;

	private GameObject _oTUnchecked7;

	private GameObject _oTUnchecked8;

	private GameObject _oTChecked1;

	private GameObject _oTChecked2;

	private GameObject _oTChecked3;

	private GameObject _oTChecked4;

	private GameObject _oTChecked5;

	private GameObject _oTChecked6;

	private GameObject _oTChecked7;

	private GameObject _oTChecked8;

	private GameObject _oTKillCount1;

	private GameObject _oTKillCount2;

	private GameObject _oTKillCount3;

	private GameObject _oTKillCount4;

	private GameObject _oTKillCount5;

	private GameObject _oTKillCount6;

	private GameObject _oTKillCount7;

	private GameObject _oTKillCount8;

	private Text _oTKillCountText1;

	private Text _oTKillCountText2;

	private Text _oTKillCountText3;

	private Text _oTKillCountText4;

	private Text _oTKillCountText5;

	private Text _oTKillCountText6;

	private Text _oTKillCountText7;

	private Text _oTKillCountText8;

	private GameObject _oTHpCount1;

	private GameObject _oTHpCount2;

	private GameObject _oTHpCount3;

	private GameObject _oTHpCount4;

	private GameObject _oTHpCount5;

	private GameObject _oTHpCount6;

	private GameObject _oTHpCount7;

	private GameObject _oTHpCount8;

	private Text _oTHpCountText1;

	private Text _oTHpCountText2;

	private Text _oTHpCountText3;

	private Text _oTHpCountText4;

	private Text _oTHpCountText5;

	private Text _oTHpCountText6;

	private Text _oTHpCountText7;

	private Text _oTHpCountText8;

	private GameObject _oTPlayerName1;

	private GameObject _oTPlayerName2;

	private GameObject _oTPlayerName3;

	private GameObject _oTPlayerName4;

	private GameObject _oTPlayerName5;

	private GameObject _oTPlayerName6;

	private GameObject _oTPlayerName7;

	private GameObject _oTPlayerName8;

	private Text _oTPlayerNameText1;

	private Text _oTPlayerNameText2;

	private Text _oTPlayerNameText3;

	private Text _oTPlayerNameText4;

	private Text _oTPlayerNameText5;

	private Text _oTPlayerNameText6;

	private Text _oTPlayerNameText7;

	private Text _oTPlayerNameText8;

	private GameObject _oTWeapon1;

	private GameObject _oTWeapon2;

	private GameObject _oTWeapon3;

	private GameObject _oTWeapon4;

	private GameObject _oTWeapon5;

	private GameObject _oTWeapon6;

	private GameObject _oTWeapon7;

	private GameObject _oTWeapon8;

	private Image _oTWeaponImage1;

	private Image _oTWeaponImage2;

	private Image _oTWeaponImage3;

	private Image _oTWeaponImage4;

	private Image _oTWeaponImage5;

	private Image _oTWeaponImage6;

	private Image _oTWeaponImage7;

	private Image _oTWeaponImage8;

	private GameObject _oTDoun1;

	private GameObject _oTDoun2;

	private GameObject _oTDoun3;

	private GameObject _oTDoun4;

	private GameObject _oTDoun5;

	private GameObject _oTDoun6;

	private GameObject _oTDoun7;

	private GameObject _oTDoun8;

	private GameObject _oTC4Icon1;

	private GameObject _oTC4Icon2;

	private GameObject _oTC4Icon3;

	private GameObject _oTC4Icon4;

	private GameObject _oTC4Icon5;

	private GameObject _oTC4Icon6;

	private GameObject _oTC4Icon7;

	private GameObject _oTC4Icon8;

	private Image _oTC4IconImage1;

	private Image _oTC4IconImage2;

	private Image _oTC4IconImage3;

	private Image _oTC4IconImage4;

	private Image _oTC4IconImage5;

	private Image _oTC4IconImage6;

	private Image _oTC4IconImage7;

	private Image _oTC4IconImage8;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "observerallkillinfo";

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

	public bool PanelRootshow
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
			if (PanelRootshow == value || !(_oPanel != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oPanel.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow1
	{
		get
		{
			if (_oCtPlayer1 != null)
			{
				return _oCtPlayer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow1 != value && _oCtPlayer1 != null)
			{
				_oCtPlayer1.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow2
	{
		get
		{
			if (_oCtPlayer2 != null)
			{
				return _oCtPlayer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow2 != value && _oCtPlayer2 != null)
			{
				_oCtPlayer2.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow3
	{
		get
		{
			if (_oCtPlayer3 != null)
			{
				return _oCtPlayer3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow3 != value && _oCtPlayer3 != null)
			{
				_oCtPlayer3.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow4
	{
		get
		{
			if (_oCtPlayer4 != null)
			{
				return _oCtPlayer4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow4 != value && _oCtPlayer4 != null)
			{
				_oCtPlayer4.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow5
	{
		get
		{
			if (_oCtPlayer5 != null)
			{
				return _oCtPlayer5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow5 != value && _oCtPlayer5 != null)
			{
				_oCtPlayer5.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow6
	{
		get
		{
			if (_oCtPlayer6 != null)
			{
				return _oCtPlayer6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow6 != value && _oCtPlayer6 != null)
			{
				_oCtPlayer6.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow7
	{
		get
		{
			if (_oCtPlayer7 != null)
			{
				return _oCtPlayer7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow7 != value && _oCtPlayer7 != null)
			{
				_oCtPlayer7.SetObjectActive(value);
			}
		}
	}

	public bool CtPlayerShow8
	{
		get
		{
			if (_oCtPlayer8 != null)
			{
				return _oCtPlayer8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtPlayerShow8 != value && _oCtPlayer8 != null)
			{
				_oCtPlayer8.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers1
	{
		get
		{
			if (_oCtPlayerEventTrigger1 != null)
			{
				return _oCtPlayerEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers1 != value && _oCtPlayerEventTrigger1 != null)
			{
				_oCtPlayerEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers2
	{
		get
		{
			if (_oCtPlayerEventTrigger2 != null)
			{
				return _oCtPlayerEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers2 != value && _oCtPlayerEventTrigger2 != null)
			{
				_oCtPlayerEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers3
	{
		get
		{
			if (_oCtPlayerEventTrigger3 != null)
			{
				return _oCtPlayerEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers3 != value && _oCtPlayerEventTrigger3 != null)
			{
				_oCtPlayerEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers4
	{
		get
		{
			if (_oCtPlayerEventTrigger4 != null)
			{
				return _oCtPlayerEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers4 != value && _oCtPlayerEventTrigger4 != null)
			{
				_oCtPlayerEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers5
	{
		get
		{
			if (_oCtPlayerEventTrigger5 != null)
			{
				return _oCtPlayerEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers5 != value && _oCtPlayerEventTrigger5 != null)
			{
				_oCtPlayerEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers6
	{
		get
		{
			if (_oCtPlayerEventTrigger6 != null)
			{
				return _oCtPlayerEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers6 != value && _oCtPlayerEventTrigger6 != null)
			{
				_oCtPlayerEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers7
	{
		get
		{
			if (_oCtPlayerEventTrigger7 != null)
			{
				return _oCtPlayerEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers7 != value && _oCtPlayerEventTrigger7 != null)
			{
				_oCtPlayerEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CtPlayerTriggers8
	{
		get
		{
			if (_oCtPlayerEventTrigger8 != null)
			{
				return _oCtPlayerEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (CtPlayerTriggers8 != value && _oCtPlayerEventTrigger8 != null)
			{
				_oCtPlayerEventTrigger8.triggers = value;
			}
		}
	}

	public float CtHpRecImageFillamount1
	{
		get
		{
			if (_oCtHpRecImageImage1 != null)
			{
				return _oCtHpRecImageImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount1 != value && _oCtHpRecImageImage1 != null)
			{
				_oCtHpRecImageImage1.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount2
	{
		get
		{
			if (_oCtHpRecImageImage2 != null)
			{
				return _oCtHpRecImageImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount2 != value && _oCtHpRecImageImage2 != null)
			{
				_oCtHpRecImageImage2.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount3
	{
		get
		{
			if (_oCtHpRecImageImage3 != null)
			{
				return _oCtHpRecImageImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount3 != value && _oCtHpRecImageImage3 != null)
			{
				_oCtHpRecImageImage3.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount4
	{
		get
		{
			if (_oCtHpRecImageImage4 != null)
			{
				return _oCtHpRecImageImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount4 != value && _oCtHpRecImageImage4 != null)
			{
				_oCtHpRecImageImage4.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount5
	{
		get
		{
			if (_oCtHpRecImageImage5 != null)
			{
				return _oCtHpRecImageImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount5 != value && _oCtHpRecImageImage5 != null)
			{
				_oCtHpRecImageImage5.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount6
	{
		get
		{
			if (_oCtHpRecImageImage6 != null)
			{
				return _oCtHpRecImageImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount6 != value && _oCtHpRecImageImage6 != null)
			{
				_oCtHpRecImageImage6.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount7
	{
		get
		{
			if (_oCtHpRecImageImage7 != null)
			{
				return _oCtHpRecImageImage7.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount7 != value && _oCtHpRecImageImage7 != null)
			{
				_oCtHpRecImageImage7.fillAmount = value;
			}
		}
	}

	public float CtHpRecImageFillamount8
	{
		get
		{
			if (_oCtHpRecImageImage8 != null)
			{
				return _oCtHpRecImageImage8.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtHpRecImageFillamount8 != value && _oCtHpRecImageImage8 != null)
			{
				_oCtHpRecImageImage8.fillAmount = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition1
	{
		get
		{
			if (_oCtHpTriImageRectTransform1 != null)
			{
				return _oCtHpTriImageRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition1 != value && _oCtHpTriImageRectTransform1 != null)
			{
				_oCtHpTriImageRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition2
	{
		get
		{
			if (_oCtHpTriImageRectTransform2 != null)
			{
				return _oCtHpTriImageRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition2 != value && _oCtHpTriImageRectTransform2 != null)
			{
				_oCtHpTriImageRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition3
	{
		get
		{
			if (_oCtHpTriImageRectTransform3 != null)
			{
				return _oCtHpTriImageRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition3 != value && _oCtHpTriImageRectTransform3 != null)
			{
				_oCtHpTriImageRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition4
	{
		get
		{
			if (_oCtHpTriImageRectTransform4 != null)
			{
				return _oCtHpTriImageRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition4 != value && _oCtHpTriImageRectTransform4 != null)
			{
				_oCtHpTriImageRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition5
	{
		get
		{
			if (_oCtHpTriImageRectTransform5 != null)
			{
				return _oCtHpTriImageRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition5 != value && _oCtHpTriImageRectTransform5 != null)
			{
				_oCtHpTriImageRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition6
	{
		get
		{
			if (_oCtHpTriImageRectTransform6 != null)
			{
				return _oCtHpTriImageRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition6 != value && _oCtHpTriImageRectTransform6 != null)
			{
				_oCtHpTriImageRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition7
	{
		get
		{
			if (_oCtHpTriImageRectTransform7 != null)
			{
				return _oCtHpTriImageRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition7 != value && _oCtHpTriImageRectTransform7 != null)
			{
				_oCtHpTriImageRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 CtHpTriImagePosition8
	{
		get
		{
			if (_oCtHpTriImageRectTransform8 != null)
			{
				return _oCtHpTriImageRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CtHpTriImagePosition8 != value && _oCtHpTriImageRectTransform8 != null)
			{
				_oCtHpTriImageRectTransform8.localPosition = value;
			}
		}
	}

	public bool CtUncheckedShow1
	{
		get
		{
			if (_oCtUnchecked1 != null)
			{
				return _oCtUnchecked1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow1 != value && _oCtUnchecked1 != null)
			{
				_oCtUnchecked1.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow2
	{
		get
		{
			if (_oCtUnchecked2 != null)
			{
				return _oCtUnchecked2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow2 != value && _oCtUnchecked2 != null)
			{
				_oCtUnchecked2.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow3
	{
		get
		{
			if (_oCtUnchecked3 != null)
			{
				return _oCtUnchecked3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow3 != value && _oCtUnchecked3 != null)
			{
				_oCtUnchecked3.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow4
	{
		get
		{
			if (_oCtUnchecked4 != null)
			{
				return _oCtUnchecked4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow4 != value && _oCtUnchecked4 != null)
			{
				_oCtUnchecked4.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow5
	{
		get
		{
			if (_oCtUnchecked5 != null)
			{
				return _oCtUnchecked5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow5 != value && _oCtUnchecked5 != null)
			{
				_oCtUnchecked5.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow6
	{
		get
		{
			if (_oCtUnchecked6 != null)
			{
				return _oCtUnchecked6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow6 != value && _oCtUnchecked6 != null)
			{
				_oCtUnchecked6.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow7
	{
		get
		{
			if (_oCtUnchecked7 != null)
			{
				return _oCtUnchecked7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow7 != value && _oCtUnchecked7 != null)
			{
				_oCtUnchecked7.SetObjectActive(value);
			}
		}
	}

	public bool CtUncheckedShow8
	{
		get
		{
			if (_oCtUnchecked8 != null)
			{
				return _oCtUnchecked8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtUncheckedShow8 != value && _oCtUnchecked8 != null)
			{
				_oCtUnchecked8.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow1
	{
		get
		{
			if (_oCtChecked1 != null)
			{
				return _oCtChecked1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow1 != value && _oCtChecked1 != null)
			{
				_oCtChecked1.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow2
	{
		get
		{
			if (_oCtChecked2 != null)
			{
				return _oCtChecked2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow2 != value && _oCtChecked2 != null)
			{
				_oCtChecked2.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow3
	{
		get
		{
			if (_oCtChecked3 != null)
			{
				return _oCtChecked3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow3 != value && _oCtChecked3 != null)
			{
				_oCtChecked3.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow4
	{
		get
		{
			if (_oCtChecked4 != null)
			{
				return _oCtChecked4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow4 != value && _oCtChecked4 != null)
			{
				_oCtChecked4.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow5
	{
		get
		{
			if (_oCtChecked5 != null)
			{
				return _oCtChecked5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow5 != value && _oCtChecked5 != null)
			{
				_oCtChecked5.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow6
	{
		get
		{
			if (_oCtChecked6 != null)
			{
				return _oCtChecked6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow6 != value && _oCtChecked6 != null)
			{
				_oCtChecked6.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow7
	{
		get
		{
			if (_oCtChecked7 != null)
			{
				return _oCtChecked7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow7 != value && _oCtChecked7 != null)
			{
				_oCtChecked7.SetObjectActive(value);
			}
		}
	}

	public bool CtCheckedShow8
	{
		get
		{
			if (_oCtChecked8 != null)
			{
				return _oCtChecked8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtCheckedShow8 != value && _oCtChecked8 != null)
			{
				_oCtChecked8.SetObjectActive(value);
			}
		}
	}

	public string CtKillCountString1
	{
		get
		{
			if (_oCtKillCountText1 != null)
			{
				return _oCtKillCountText1.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString1 != value && _oCtKillCountText1 != null)
			{
				_oCtKillCountText1.text = value;
			}
		}
	}

	public string CtKillCountString2
	{
		get
		{
			if (_oCtKillCountText2 != null)
			{
				return _oCtKillCountText2.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString2 != value && _oCtKillCountText2 != null)
			{
				_oCtKillCountText2.text = value;
			}
		}
	}

	public string CtKillCountString3
	{
		get
		{
			if (_oCtKillCountText3 != null)
			{
				return _oCtKillCountText3.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString3 != value && _oCtKillCountText3 != null)
			{
				_oCtKillCountText3.text = value;
			}
		}
	}

	public string CtKillCountString4
	{
		get
		{
			if (_oCtKillCountText4 != null)
			{
				return _oCtKillCountText4.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString4 != value && _oCtKillCountText4 != null)
			{
				_oCtKillCountText4.text = value;
			}
		}
	}

	public string CtKillCountString5
	{
		get
		{
			if (_oCtKillCountText5 != null)
			{
				return _oCtKillCountText5.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString5 != value && _oCtKillCountText5 != null)
			{
				_oCtKillCountText5.text = value;
			}
		}
	}

	public string CtKillCountString6
	{
		get
		{
			if (_oCtKillCountText6 != null)
			{
				return _oCtKillCountText6.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString6 != value && _oCtKillCountText6 != null)
			{
				_oCtKillCountText6.text = value;
			}
		}
	}

	public string CtKillCountString7
	{
		get
		{
			if (_oCtKillCountText7 != null)
			{
				return _oCtKillCountText7.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString7 != value && _oCtKillCountText7 != null)
			{
				_oCtKillCountText7.text = value;
			}
		}
	}

	public string CtKillCountString8
	{
		get
		{
			if (_oCtKillCountText8 != null)
			{
				return _oCtKillCountText8.text;
			}
			return null;
		}
		set
		{
			if (CtKillCountString8 != value && _oCtKillCountText8 != null)
			{
				_oCtKillCountText8.text = value;
			}
		}
	}

	public string CtHpCountString1
	{
		get
		{
			if (_oCtHpCountText1 != null)
			{
				return _oCtHpCountText1.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString1 != value && _oCtHpCountText1 != null)
			{
				_oCtHpCountText1.text = value;
			}
		}
	}

	public string CtHpCountString2
	{
		get
		{
			if (_oCtHpCountText2 != null)
			{
				return _oCtHpCountText2.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString2 != value && _oCtHpCountText2 != null)
			{
				_oCtHpCountText2.text = value;
			}
		}
	}

	public string CtHpCountString3
	{
		get
		{
			if (_oCtHpCountText3 != null)
			{
				return _oCtHpCountText3.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString3 != value && _oCtHpCountText3 != null)
			{
				_oCtHpCountText3.text = value;
			}
		}
	}

	public string CtHpCountString4
	{
		get
		{
			if (_oCtHpCountText4 != null)
			{
				return _oCtHpCountText4.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString4 != value && _oCtHpCountText4 != null)
			{
				_oCtHpCountText4.text = value;
			}
		}
	}

	public string CtHpCountString5
	{
		get
		{
			if (_oCtHpCountText5 != null)
			{
				return _oCtHpCountText5.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString5 != value && _oCtHpCountText5 != null)
			{
				_oCtHpCountText5.text = value;
			}
		}
	}

	public string CtHpCountString6
	{
		get
		{
			if (_oCtHpCountText6 != null)
			{
				return _oCtHpCountText6.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString6 != value && _oCtHpCountText6 != null)
			{
				_oCtHpCountText6.text = value;
			}
		}
	}

	public string CtHpCountString7
	{
		get
		{
			if (_oCtHpCountText7 != null)
			{
				return _oCtHpCountText7.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString7 != value && _oCtHpCountText7 != null)
			{
				_oCtHpCountText7.text = value;
			}
		}
	}

	public string CtHpCountString8
	{
		get
		{
			if (_oCtHpCountText8 != null)
			{
				return _oCtHpCountText8.text;
			}
			return null;
		}
		set
		{
			if (CtHpCountString8 != value && _oCtHpCountText8 != null)
			{
				_oCtHpCountText8.text = value;
			}
		}
	}

	public string CtPlayerNameString1
	{
		get
		{
			if (_oCtPlayerNameText1 != null)
			{
				return _oCtPlayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString1 != value && _oCtPlayerNameText1 != null)
			{
				_oCtPlayerNameText1.text = value;
			}
		}
	}

	public string CtPlayerNameString2
	{
		get
		{
			if (_oCtPlayerNameText2 != null)
			{
				return _oCtPlayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString2 != value && _oCtPlayerNameText2 != null)
			{
				_oCtPlayerNameText2.text = value;
			}
		}
	}

	public string CtPlayerNameString3
	{
		get
		{
			if (_oCtPlayerNameText3 != null)
			{
				return _oCtPlayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString3 != value && _oCtPlayerNameText3 != null)
			{
				_oCtPlayerNameText3.text = value;
			}
		}
	}

	public string CtPlayerNameString4
	{
		get
		{
			if (_oCtPlayerNameText4 != null)
			{
				return _oCtPlayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString4 != value && _oCtPlayerNameText4 != null)
			{
				_oCtPlayerNameText4.text = value;
			}
		}
	}

	public string CtPlayerNameString5
	{
		get
		{
			if (_oCtPlayerNameText5 != null)
			{
				return _oCtPlayerNameText5.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString5 != value && _oCtPlayerNameText5 != null)
			{
				_oCtPlayerNameText5.text = value;
			}
		}
	}

	public string CtPlayerNameString6
	{
		get
		{
			if (_oCtPlayerNameText6 != null)
			{
				return _oCtPlayerNameText6.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString6 != value && _oCtPlayerNameText6 != null)
			{
				_oCtPlayerNameText6.text = value;
			}
		}
	}

	public string CtPlayerNameString7
	{
		get
		{
			if (_oCtPlayerNameText7 != null)
			{
				return _oCtPlayerNameText7.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString7 != value && _oCtPlayerNameText7 != null)
			{
				_oCtPlayerNameText7.text = value;
			}
		}
	}

	public string CtPlayerNameString8
	{
		get
		{
			if (_oCtPlayerNameText8 != null)
			{
				return _oCtPlayerNameText8.text;
			}
			return null;
		}
		set
		{
			if (CtPlayerNameString8 != value && _oCtPlayerNameText8 != null)
			{
				_oCtPlayerNameText8.text = value;
			}
		}
	}

	public Sprite CtWeaponSprite1
	{
		get
		{
			if (_oCtWeaponImage1 != null)
			{
				return _oCtWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite1 != value && _oCtWeaponImage1 != null)
			{
				_oCtWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite2
	{
		get
		{
			if (_oCtWeaponImage2 != null)
			{
				return _oCtWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite2 != value && _oCtWeaponImage2 != null)
			{
				_oCtWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite3
	{
		get
		{
			if (_oCtWeaponImage3 != null)
			{
				return _oCtWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite3 != value && _oCtWeaponImage3 != null)
			{
				_oCtWeaponImage3.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite4
	{
		get
		{
			if (_oCtWeaponImage4 != null)
			{
				return _oCtWeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite4 != value && _oCtWeaponImage4 != null)
			{
				_oCtWeaponImage4.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite5
	{
		get
		{
			if (_oCtWeaponImage5 != null)
			{
				return _oCtWeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite5 != value && _oCtWeaponImage5 != null)
			{
				_oCtWeaponImage5.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite6
	{
		get
		{
			if (_oCtWeaponImage6 != null)
			{
				return _oCtWeaponImage6.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite6 != value && _oCtWeaponImage6 != null)
			{
				_oCtWeaponImage6.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite7
	{
		get
		{
			if (_oCtWeaponImage7 != null)
			{
				return _oCtWeaponImage7.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite7 != value && _oCtWeaponImage7 != null)
			{
				_oCtWeaponImage7.sprite = value;
			}
		}
	}

	public Sprite CtWeaponSprite8
	{
		get
		{
			if (_oCtWeaponImage8 != null)
			{
				return _oCtWeaponImage8.sprite;
			}
			return null;
		}
		set
		{
			if (CtWeaponSprite8 != value && _oCtWeaponImage8 != null)
			{
				_oCtWeaponImage8.sprite = value;
			}
		}
	}

	public bool CtDounShow1
	{
		get
		{
			if (_oCtDoun1 != null)
			{
				return _oCtDoun1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow1 != value && _oCtDoun1 != null)
			{
				_oCtDoun1.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow2
	{
		get
		{
			if (_oCtDoun2 != null)
			{
				return _oCtDoun2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow2 != value && _oCtDoun2 != null)
			{
				_oCtDoun2.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow3
	{
		get
		{
			if (_oCtDoun3 != null)
			{
				return _oCtDoun3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow3 != value && _oCtDoun3 != null)
			{
				_oCtDoun3.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow4
	{
		get
		{
			if (_oCtDoun4 != null)
			{
				return _oCtDoun4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow4 != value && _oCtDoun4 != null)
			{
				_oCtDoun4.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow5
	{
		get
		{
			if (_oCtDoun5 != null)
			{
				return _oCtDoun5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow5 != value && _oCtDoun5 != null)
			{
				_oCtDoun5.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow6
	{
		get
		{
			if (_oCtDoun6 != null)
			{
				return _oCtDoun6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow6 != value && _oCtDoun6 != null)
			{
				_oCtDoun6.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow7
	{
		get
		{
			if (_oCtDoun7 != null)
			{
				return _oCtDoun7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow7 != value && _oCtDoun7 != null)
			{
				_oCtDoun7.SetObjectActive(value);
			}
		}
	}

	public bool CtDounShow8
	{
		get
		{
			if (_oCtDoun8 != null)
			{
				return _oCtDoun8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtDounShow8 != value && _oCtDoun8 != null)
			{
				_oCtDoun8.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow1
	{
		get
		{
			if (_oTPlayer1 != null)
			{
				return _oTPlayer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow1 != value && _oTPlayer1 != null)
			{
				_oTPlayer1.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow2
	{
		get
		{
			if (_oTPlayer2 != null)
			{
				return _oTPlayer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow2 != value && _oTPlayer2 != null)
			{
				_oTPlayer2.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow3
	{
		get
		{
			if (_oTPlayer3 != null)
			{
				return _oTPlayer3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow3 != value && _oTPlayer3 != null)
			{
				_oTPlayer3.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow4
	{
		get
		{
			if (_oTPlayer4 != null)
			{
				return _oTPlayer4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow4 != value && _oTPlayer4 != null)
			{
				_oTPlayer4.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow5
	{
		get
		{
			if (_oTPlayer5 != null)
			{
				return _oTPlayer5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow5 != value && _oTPlayer5 != null)
			{
				_oTPlayer5.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow6
	{
		get
		{
			if (_oTPlayer6 != null)
			{
				return _oTPlayer6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow6 != value && _oTPlayer6 != null)
			{
				_oTPlayer6.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow7
	{
		get
		{
			if (_oTPlayer7 != null)
			{
				return _oTPlayer7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow7 != value && _oTPlayer7 != null)
			{
				_oTPlayer7.SetObjectActive(value);
			}
		}
	}

	public bool TPlayerShow8
	{
		get
		{
			if (_oTPlayer8 != null)
			{
				return _oTPlayer8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TPlayerShow8 != value && _oTPlayer8 != null)
			{
				_oTPlayer8.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers1
	{
		get
		{
			if (_oTPlayerEventTrigger1 != null)
			{
				return _oTPlayerEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers1 != value && _oTPlayerEventTrigger1 != null)
			{
				_oTPlayerEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers2
	{
		get
		{
			if (_oTPlayerEventTrigger2 != null)
			{
				return _oTPlayerEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers2 != value && _oTPlayerEventTrigger2 != null)
			{
				_oTPlayerEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers3
	{
		get
		{
			if (_oTPlayerEventTrigger3 != null)
			{
				return _oTPlayerEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers3 != value && _oTPlayerEventTrigger3 != null)
			{
				_oTPlayerEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers4
	{
		get
		{
			if (_oTPlayerEventTrigger4 != null)
			{
				return _oTPlayerEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers4 != value && _oTPlayerEventTrigger4 != null)
			{
				_oTPlayerEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers5
	{
		get
		{
			if (_oTPlayerEventTrigger5 != null)
			{
				return _oTPlayerEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers5 != value && _oTPlayerEventTrigger5 != null)
			{
				_oTPlayerEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers6
	{
		get
		{
			if (_oTPlayerEventTrigger6 != null)
			{
				return _oTPlayerEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers6 != value && _oTPlayerEventTrigger6 != null)
			{
				_oTPlayerEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers7
	{
		get
		{
			if (_oTPlayerEventTrigger7 != null)
			{
				return _oTPlayerEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers7 != value && _oTPlayerEventTrigger7 != null)
			{
				_oTPlayerEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> TPlayerTriggers8
	{
		get
		{
			if (_oTPlayerEventTrigger8 != null)
			{
				return _oTPlayerEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (TPlayerTriggers8 != value && _oTPlayerEventTrigger8 != null)
			{
				_oTPlayerEventTrigger8.triggers = value;
			}
		}
	}

	public float THpRecImageFillamount1
	{
		get
		{
			if (_oTHpRecImageImage1 != null)
			{
				return _oTHpRecImageImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount1 != value && _oTHpRecImageImage1 != null)
			{
				_oTHpRecImageImage1.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount2
	{
		get
		{
			if (_oTHpRecImageImage2 != null)
			{
				return _oTHpRecImageImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount2 != value && _oTHpRecImageImage2 != null)
			{
				_oTHpRecImageImage2.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount3
	{
		get
		{
			if (_oTHpRecImageImage3 != null)
			{
				return _oTHpRecImageImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount3 != value && _oTHpRecImageImage3 != null)
			{
				_oTHpRecImageImage3.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount4
	{
		get
		{
			if (_oTHpRecImageImage4 != null)
			{
				return _oTHpRecImageImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount4 != value && _oTHpRecImageImage4 != null)
			{
				_oTHpRecImageImage4.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount5
	{
		get
		{
			if (_oTHpRecImageImage5 != null)
			{
				return _oTHpRecImageImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount5 != value && _oTHpRecImageImage5 != null)
			{
				_oTHpRecImageImage5.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount6
	{
		get
		{
			if (_oTHpRecImageImage6 != null)
			{
				return _oTHpRecImageImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount6 != value && _oTHpRecImageImage6 != null)
			{
				_oTHpRecImageImage6.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount7
	{
		get
		{
			if (_oTHpRecImageImage7 != null)
			{
				return _oTHpRecImageImage7.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount7 != value && _oTHpRecImageImage7 != null)
			{
				_oTHpRecImageImage7.fillAmount = value;
			}
		}
	}

	public float THpRecImageFillamount8
	{
		get
		{
			if (_oTHpRecImageImage8 != null)
			{
				return _oTHpRecImageImage8.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (THpRecImageFillamount8 != value && _oTHpRecImageImage8 != null)
			{
				_oTHpRecImageImage8.fillAmount = value;
			}
		}
	}

	public Vector3 THpTriImagePosition1
	{
		get
		{
			if (_oTHpTriImageRectTransform1 != null)
			{
				return _oTHpTriImageRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition1 != value && _oTHpTriImageRectTransform1 != null)
			{
				_oTHpTriImageRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition2
	{
		get
		{
			if (_oTHpTriImageRectTransform2 != null)
			{
				return _oTHpTriImageRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition2 != value && _oTHpTriImageRectTransform2 != null)
			{
				_oTHpTriImageRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition3
	{
		get
		{
			if (_oTHpTriImageRectTransform3 != null)
			{
				return _oTHpTriImageRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition3 != value && _oTHpTriImageRectTransform3 != null)
			{
				_oTHpTriImageRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition4
	{
		get
		{
			if (_oTHpTriImageRectTransform4 != null)
			{
				return _oTHpTriImageRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition4 != value && _oTHpTriImageRectTransform4 != null)
			{
				_oTHpTriImageRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition5
	{
		get
		{
			if (_oTHpTriImageRectTransform5 != null)
			{
				return _oTHpTriImageRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition5 != value && _oTHpTriImageRectTransform5 != null)
			{
				_oTHpTriImageRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition6
	{
		get
		{
			if (_oTHpTriImageRectTransform6 != null)
			{
				return _oTHpTriImageRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition6 != value && _oTHpTriImageRectTransform6 != null)
			{
				_oTHpTriImageRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition7
	{
		get
		{
			if (_oTHpTriImageRectTransform7 != null)
			{
				return _oTHpTriImageRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition7 != value && _oTHpTriImageRectTransform7 != null)
			{
				_oTHpTriImageRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 THpTriImagePosition8
	{
		get
		{
			if (_oTHpTriImageRectTransform8 != null)
			{
				return _oTHpTriImageRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (THpTriImagePosition8 != value && _oTHpTriImageRectTransform8 != null)
			{
				_oTHpTriImageRectTransform8.localPosition = value;
			}
		}
	}

	public bool TUncheckedShow1
	{
		get
		{
			if (_oTUnchecked1 != null)
			{
				return _oTUnchecked1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow1 != value && _oTUnchecked1 != null)
			{
				_oTUnchecked1.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow2
	{
		get
		{
			if (_oTUnchecked2 != null)
			{
				return _oTUnchecked2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow2 != value && _oTUnchecked2 != null)
			{
				_oTUnchecked2.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow3
	{
		get
		{
			if (_oTUnchecked3 != null)
			{
				return _oTUnchecked3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow3 != value && _oTUnchecked3 != null)
			{
				_oTUnchecked3.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow4
	{
		get
		{
			if (_oTUnchecked4 != null)
			{
				return _oTUnchecked4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow4 != value && _oTUnchecked4 != null)
			{
				_oTUnchecked4.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow5
	{
		get
		{
			if (_oTUnchecked5 != null)
			{
				return _oTUnchecked5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow5 != value && _oTUnchecked5 != null)
			{
				_oTUnchecked5.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow6
	{
		get
		{
			if (_oTUnchecked6 != null)
			{
				return _oTUnchecked6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow6 != value && _oTUnchecked6 != null)
			{
				_oTUnchecked6.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow7
	{
		get
		{
			if (_oTUnchecked7 != null)
			{
				return _oTUnchecked7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow7 != value && _oTUnchecked7 != null)
			{
				_oTUnchecked7.SetObjectActive(value);
			}
		}
	}

	public bool TUncheckedShow8
	{
		get
		{
			if (_oTUnchecked8 != null)
			{
				return _oTUnchecked8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TUncheckedShow8 != value && _oTUnchecked8 != null)
			{
				_oTUnchecked8.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow1
	{
		get
		{
			if (_oTChecked1 != null)
			{
				return _oTChecked1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow1 != value && _oTChecked1 != null)
			{
				_oTChecked1.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow2
	{
		get
		{
			if (_oTChecked2 != null)
			{
				return _oTChecked2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow2 != value && _oTChecked2 != null)
			{
				_oTChecked2.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow3
	{
		get
		{
			if (_oTChecked3 != null)
			{
				return _oTChecked3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow3 != value && _oTChecked3 != null)
			{
				_oTChecked3.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow4
	{
		get
		{
			if (_oTChecked4 != null)
			{
				return _oTChecked4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow4 != value && _oTChecked4 != null)
			{
				_oTChecked4.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow5
	{
		get
		{
			if (_oTChecked5 != null)
			{
				return _oTChecked5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow5 != value && _oTChecked5 != null)
			{
				_oTChecked5.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow6
	{
		get
		{
			if (_oTChecked6 != null)
			{
				return _oTChecked6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow6 != value && _oTChecked6 != null)
			{
				_oTChecked6.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow7
	{
		get
		{
			if (_oTChecked7 != null)
			{
				return _oTChecked7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow7 != value && _oTChecked7 != null)
			{
				_oTChecked7.SetObjectActive(value);
			}
		}
	}

	public bool TCheckedShow8
	{
		get
		{
			if (_oTChecked8 != null)
			{
				return _oTChecked8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TCheckedShow8 != value && _oTChecked8 != null)
			{
				_oTChecked8.SetObjectActive(value);
			}
		}
	}

	public string TKillCountString1
	{
		get
		{
			if (_oTKillCountText1 != null)
			{
				return _oTKillCountText1.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString1 != value && _oTKillCountText1 != null)
			{
				_oTKillCountText1.text = value;
			}
		}
	}

	public string TKillCountString2
	{
		get
		{
			if (_oTKillCountText2 != null)
			{
				return _oTKillCountText2.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString2 != value && _oTKillCountText2 != null)
			{
				_oTKillCountText2.text = value;
			}
		}
	}

	public string TKillCountString3
	{
		get
		{
			if (_oTKillCountText3 != null)
			{
				return _oTKillCountText3.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString3 != value && _oTKillCountText3 != null)
			{
				_oTKillCountText3.text = value;
			}
		}
	}

	public string TKillCountString4
	{
		get
		{
			if (_oTKillCountText4 != null)
			{
				return _oTKillCountText4.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString4 != value && _oTKillCountText4 != null)
			{
				_oTKillCountText4.text = value;
			}
		}
	}

	public string TKillCountString5
	{
		get
		{
			if (_oTKillCountText5 != null)
			{
				return _oTKillCountText5.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString5 != value && _oTKillCountText5 != null)
			{
				_oTKillCountText5.text = value;
			}
		}
	}

	public string TKillCountString6
	{
		get
		{
			if (_oTKillCountText6 != null)
			{
				return _oTKillCountText6.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString6 != value && _oTKillCountText6 != null)
			{
				_oTKillCountText6.text = value;
			}
		}
	}

	public string TKillCountString7
	{
		get
		{
			if (_oTKillCountText7 != null)
			{
				return _oTKillCountText7.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString7 != value && _oTKillCountText7 != null)
			{
				_oTKillCountText7.text = value;
			}
		}
	}

	public string TKillCountString8
	{
		get
		{
			if (_oTKillCountText8 != null)
			{
				return _oTKillCountText8.text;
			}
			return null;
		}
		set
		{
			if (TKillCountString8 != value && _oTKillCountText8 != null)
			{
				_oTKillCountText8.text = value;
			}
		}
	}

	public string THpCountString1
	{
		get
		{
			if (_oTHpCountText1 != null)
			{
				return _oTHpCountText1.text;
			}
			return null;
		}
		set
		{
			if (THpCountString1 != value && _oTHpCountText1 != null)
			{
				_oTHpCountText1.text = value;
			}
		}
	}

	public string THpCountString2
	{
		get
		{
			if (_oTHpCountText2 != null)
			{
				return _oTHpCountText2.text;
			}
			return null;
		}
		set
		{
			if (THpCountString2 != value && _oTHpCountText2 != null)
			{
				_oTHpCountText2.text = value;
			}
		}
	}

	public string THpCountString3
	{
		get
		{
			if (_oTHpCountText3 != null)
			{
				return _oTHpCountText3.text;
			}
			return null;
		}
		set
		{
			if (THpCountString3 != value && _oTHpCountText3 != null)
			{
				_oTHpCountText3.text = value;
			}
		}
	}

	public string THpCountString4
	{
		get
		{
			if (_oTHpCountText4 != null)
			{
				return _oTHpCountText4.text;
			}
			return null;
		}
		set
		{
			if (THpCountString4 != value && _oTHpCountText4 != null)
			{
				_oTHpCountText4.text = value;
			}
		}
	}

	public string THpCountString5
	{
		get
		{
			if (_oTHpCountText5 != null)
			{
				return _oTHpCountText5.text;
			}
			return null;
		}
		set
		{
			if (THpCountString5 != value && _oTHpCountText5 != null)
			{
				_oTHpCountText5.text = value;
			}
		}
	}

	public string THpCountString6
	{
		get
		{
			if (_oTHpCountText6 != null)
			{
				return _oTHpCountText6.text;
			}
			return null;
		}
		set
		{
			if (THpCountString6 != value && _oTHpCountText6 != null)
			{
				_oTHpCountText6.text = value;
			}
		}
	}

	public string THpCountString7
	{
		get
		{
			if (_oTHpCountText7 != null)
			{
				return _oTHpCountText7.text;
			}
			return null;
		}
		set
		{
			if (THpCountString7 != value && _oTHpCountText7 != null)
			{
				_oTHpCountText7.text = value;
			}
		}
	}

	public string THpCountString8
	{
		get
		{
			if (_oTHpCountText8 != null)
			{
				return _oTHpCountText8.text;
			}
			return null;
		}
		set
		{
			if (THpCountString8 != value && _oTHpCountText8 != null)
			{
				_oTHpCountText8.text = value;
			}
		}
	}

	public string TPlayerNameString1
	{
		get
		{
			if (_oTPlayerNameText1 != null)
			{
				return _oTPlayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString1 != value && _oTPlayerNameText1 != null)
			{
				_oTPlayerNameText1.text = value;
			}
		}
	}

	public string TPlayerNameString2
	{
		get
		{
			if (_oTPlayerNameText2 != null)
			{
				return _oTPlayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString2 != value && _oTPlayerNameText2 != null)
			{
				_oTPlayerNameText2.text = value;
			}
		}
	}

	public string TPlayerNameString3
	{
		get
		{
			if (_oTPlayerNameText3 != null)
			{
				return _oTPlayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString3 != value && _oTPlayerNameText3 != null)
			{
				_oTPlayerNameText3.text = value;
			}
		}
	}

	public string TPlayerNameString4
	{
		get
		{
			if (_oTPlayerNameText4 != null)
			{
				return _oTPlayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString4 != value && _oTPlayerNameText4 != null)
			{
				_oTPlayerNameText4.text = value;
			}
		}
	}

	public string TPlayerNameString5
	{
		get
		{
			if (_oTPlayerNameText5 != null)
			{
				return _oTPlayerNameText5.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString5 != value && _oTPlayerNameText5 != null)
			{
				_oTPlayerNameText5.text = value;
			}
		}
	}

	public string TPlayerNameString6
	{
		get
		{
			if (_oTPlayerNameText6 != null)
			{
				return _oTPlayerNameText6.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString6 != value && _oTPlayerNameText6 != null)
			{
				_oTPlayerNameText6.text = value;
			}
		}
	}

	public string TPlayerNameString7
	{
		get
		{
			if (_oTPlayerNameText7 != null)
			{
				return _oTPlayerNameText7.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString7 != value && _oTPlayerNameText7 != null)
			{
				_oTPlayerNameText7.text = value;
			}
		}
	}

	public string TPlayerNameString8
	{
		get
		{
			if (_oTPlayerNameText8 != null)
			{
				return _oTPlayerNameText8.text;
			}
			return null;
		}
		set
		{
			if (TPlayerNameString8 != value && _oTPlayerNameText8 != null)
			{
				_oTPlayerNameText8.text = value;
			}
		}
	}

	public Sprite TWeaponSprite1
	{
		get
		{
			if (_oTWeaponImage1 != null)
			{
				return _oTWeaponImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite1 != value && _oTWeaponImage1 != null)
			{
				_oTWeaponImage1.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite2
	{
		get
		{
			if (_oTWeaponImage2 != null)
			{
				return _oTWeaponImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite2 != value && _oTWeaponImage2 != null)
			{
				_oTWeaponImage2.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite3
	{
		get
		{
			if (_oTWeaponImage3 != null)
			{
				return _oTWeaponImage3.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite3 != value && _oTWeaponImage3 != null)
			{
				_oTWeaponImage3.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite4
	{
		get
		{
			if (_oTWeaponImage4 != null)
			{
				return _oTWeaponImage4.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite4 != value && _oTWeaponImage4 != null)
			{
				_oTWeaponImage4.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite5
	{
		get
		{
			if (_oTWeaponImage5 != null)
			{
				return _oTWeaponImage5.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite5 != value && _oTWeaponImage5 != null)
			{
				_oTWeaponImage5.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite6
	{
		get
		{
			if (_oTWeaponImage6 != null)
			{
				return _oTWeaponImage6.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite6 != value && _oTWeaponImage6 != null)
			{
				_oTWeaponImage6.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite7
	{
		get
		{
			if (_oTWeaponImage7 != null)
			{
				return _oTWeaponImage7.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite7 != value && _oTWeaponImage7 != null)
			{
				_oTWeaponImage7.sprite = value;
			}
		}
	}

	public Sprite TWeaponSprite8
	{
		get
		{
			if (_oTWeaponImage8 != null)
			{
				return _oTWeaponImage8.sprite;
			}
			return null;
		}
		set
		{
			if (TWeaponSprite8 != value && _oTWeaponImage8 != null)
			{
				_oTWeaponImage8.sprite = value;
			}
		}
	}

	public bool TDounShow1
	{
		get
		{
			if (_oTDoun1 != null)
			{
				return _oTDoun1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow1 != value && _oTDoun1 != null)
			{
				_oTDoun1.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow2
	{
		get
		{
			if (_oTDoun2 != null)
			{
				return _oTDoun2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow2 != value && _oTDoun2 != null)
			{
				_oTDoun2.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow3
	{
		get
		{
			if (_oTDoun3 != null)
			{
				return _oTDoun3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow3 != value && _oTDoun3 != null)
			{
				_oTDoun3.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow4
	{
		get
		{
			if (_oTDoun4 != null)
			{
				return _oTDoun4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow4 != value && _oTDoun4 != null)
			{
				_oTDoun4.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow5
	{
		get
		{
			if (_oTDoun5 != null)
			{
				return _oTDoun5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow5 != value && _oTDoun5 != null)
			{
				_oTDoun5.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow6
	{
		get
		{
			if (_oTDoun6 != null)
			{
				return _oTDoun6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow6 != value && _oTDoun6 != null)
			{
				_oTDoun6.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow7
	{
		get
		{
			if (_oTDoun7 != null)
			{
				return _oTDoun7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow7 != value && _oTDoun7 != null)
			{
				_oTDoun7.SetObjectActive(value);
			}
		}
	}

	public bool TDounShow8
	{
		get
		{
			if (_oTDoun8 != null)
			{
				return _oTDoun8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TDounShow8 != value && _oTDoun8 != null)
			{
				_oTDoun8.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow1
	{
		get
		{
			if (_oTC4Icon1 != null)
			{
				return _oTC4Icon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow1 != value && _oTC4Icon1 != null)
			{
				_oTC4Icon1.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow2
	{
		get
		{
			if (_oTC4Icon2 != null)
			{
				return _oTC4Icon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow2 != value && _oTC4Icon2 != null)
			{
				_oTC4Icon2.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow3
	{
		get
		{
			if (_oTC4Icon3 != null)
			{
				return _oTC4Icon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow3 != value && _oTC4Icon3 != null)
			{
				_oTC4Icon3.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow4
	{
		get
		{
			if (_oTC4Icon4 != null)
			{
				return _oTC4Icon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow4 != value && _oTC4Icon4 != null)
			{
				_oTC4Icon4.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow5
	{
		get
		{
			if (_oTC4Icon5 != null)
			{
				return _oTC4Icon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow5 != value && _oTC4Icon5 != null)
			{
				_oTC4Icon5.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow6
	{
		get
		{
			if (_oTC4Icon6 != null)
			{
				return _oTC4Icon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow6 != value && _oTC4Icon6 != null)
			{
				_oTC4Icon6.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow7
	{
		get
		{
			if (_oTC4Icon7 != null)
			{
				return _oTC4Icon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow7 != value && _oTC4Icon7 != null)
			{
				_oTC4Icon7.SetObjectActive(value);
			}
		}
	}

	public bool TC4IconShow8
	{
		get
		{
			if (_oTC4Icon8 != null)
			{
				return _oTC4Icon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TC4IconShow8 != value && _oTC4Icon8 != null)
			{
				_oTC4Icon8.SetObjectActive(value);
			}
		}
	}

	public Sprite TC4IconSprite1
	{
		get
		{
			if (_oTC4IconImage1 != null)
			{
				return _oTC4IconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite1 != value && _oTC4IconImage1 != null)
			{
				_oTC4IconImage1.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite2
	{
		get
		{
			if (_oTC4IconImage2 != null)
			{
				return _oTC4IconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite2 != value && _oTC4IconImage2 != null)
			{
				_oTC4IconImage2.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite3
	{
		get
		{
			if (_oTC4IconImage3 != null)
			{
				return _oTC4IconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite3 != value && _oTC4IconImage3 != null)
			{
				_oTC4IconImage3.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite4
	{
		get
		{
			if (_oTC4IconImage4 != null)
			{
				return _oTC4IconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite4 != value && _oTC4IconImage4 != null)
			{
				_oTC4IconImage4.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite5
	{
		get
		{
			if (_oTC4IconImage5 != null)
			{
				return _oTC4IconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite5 != value && _oTC4IconImage5 != null)
			{
				_oTC4IconImage5.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite6
	{
		get
		{
			if (_oTC4IconImage6 != null)
			{
				return _oTC4IconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite6 != value && _oTC4IconImage6 != null)
			{
				_oTC4IconImage6.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite7
	{
		get
		{
			if (_oTC4IconImage7 != null)
			{
				return _oTC4IconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite7 != value && _oTC4IconImage7 != null)
			{
				_oTC4IconImage7.sprite = value;
			}
		}
	}

	public Sprite TC4IconSprite8
	{
		get
		{
			if (_oTC4IconImage8 != null)
			{
				return _oTC4IconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (TC4IconSprite8 != value && _oTC4IconImage8 != null)
			{
				_oTC4IconImage8.sprite = value;
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
			case "CtPlayer1":
				_oCtPlayer1 = transform.gameObject;
				_oCtPlayerEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer2":
				_oCtPlayer2 = transform.gameObject;
				_oCtPlayerEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer3":
				_oCtPlayer3 = transform.gameObject;
				_oCtPlayerEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer4":
				_oCtPlayer4 = transform.gameObject;
				_oCtPlayerEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer5":
				_oCtPlayer5 = transform.gameObject;
				_oCtPlayerEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer6":
				_oCtPlayer6 = transform.gameObject;
				_oCtPlayerEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer7":
				_oCtPlayer7 = transform.gameObject;
				_oCtPlayerEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtPlayer8":
				_oCtPlayer8 = transform.gameObject;
				_oCtPlayerEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "CtHpRecImage1":
				_oCtHpRecImage1 = transform.gameObject;
				_oCtHpRecImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage2":
				_oCtHpRecImage2 = transform.gameObject;
				_oCtHpRecImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage3":
				_oCtHpRecImage3 = transform.gameObject;
				_oCtHpRecImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage4":
				_oCtHpRecImage4 = transform.gameObject;
				_oCtHpRecImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage5":
				_oCtHpRecImage5 = transform.gameObject;
				_oCtHpRecImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage6":
				_oCtHpRecImage6 = transform.gameObject;
				_oCtHpRecImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage7":
				_oCtHpRecImage7 = transform.gameObject;
				_oCtHpRecImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpRecImage8":
				_oCtHpRecImage8 = transform.gameObject;
				_oCtHpRecImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtHpTriImage1":
				_oCtHpTriImage1 = transform.gameObject;
				_oCtHpTriImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage2":
				_oCtHpTriImage2 = transform.gameObject;
				_oCtHpTriImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage3":
				_oCtHpTriImage3 = transform.gameObject;
				_oCtHpTriImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage4":
				_oCtHpTriImage4 = transform.gameObject;
				_oCtHpTriImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage5":
				_oCtHpTriImage5 = transform.gameObject;
				_oCtHpTriImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage6":
				_oCtHpTriImage6 = transform.gameObject;
				_oCtHpTriImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage7":
				_oCtHpTriImage7 = transform.gameObject;
				_oCtHpTriImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtHpTriImage8":
				_oCtHpTriImage8 = transform.gameObject;
				_oCtHpTriImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CtUnchecked1":
				_oCtUnchecked1 = transform.gameObject;
				break;
			case "CtUnchecked2":
				_oCtUnchecked2 = transform.gameObject;
				break;
			case "CtUnchecked3":
				_oCtUnchecked3 = transform.gameObject;
				break;
			case "CtUnchecked4":
				_oCtUnchecked4 = transform.gameObject;
				break;
			case "CtUnchecked5":
				_oCtUnchecked5 = transform.gameObject;
				break;
			case "CtUnchecked6":
				_oCtUnchecked6 = transform.gameObject;
				break;
			case "CtUnchecked7":
				_oCtUnchecked7 = transform.gameObject;
				break;
			case "CtUnchecked8":
				_oCtUnchecked8 = transform.gameObject;
				break;
			case "CtChecked1":
				_oCtChecked1 = transform.gameObject;
				break;
			case "CtChecked2":
				_oCtChecked2 = transform.gameObject;
				break;
			case "CtChecked3":
				_oCtChecked3 = transform.gameObject;
				break;
			case "CtChecked4":
				_oCtChecked4 = transform.gameObject;
				break;
			case "CtChecked5":
				_oCtChecked5 = transform.gameObject;
				break;
			case "CtChecked6":
				_oCtChecked6 = transform.gameObject;
				break;
			case "CtChecked7":
				_oCtChecked7 = transform.gameObject;
				break;
			case "CtChecked8":
				_oCtChecked8 = transform.gameObject;
				break;
			case "CtKillCount1":
				_oCtKillCount1 = transform.gameObject;
				_oCtKillCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount2":
				_oCtKillCount2 = transform.gameObject;
				_oCtKillCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount3":
				_oCtKillCount3 = transform.gameObject;
				_oCtKillCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount4":
				_oCtKillCount4 = transform.gameObject;
				_oCtKillCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount5":
				_oCtKillCount5 = transform.gameObject;
				_oCtKillCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount6":
				_oCtKillCount6 = transform.gameObject;
				_oCtKillCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount7":
				_oCtKillCount7 = transform.gameObject;
				_oCtKillCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtKillCount8":
				_oCtKillCount8 = transform.gameObject;
				_oCtKillCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount1":
				_oCtHpCount1 = transform.gameObject;
				_oCtHpCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount2":
				_oCtHpCount2 = transform.gameObject;
				_oCtHpCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount3":
				_oCtHpCount3 = transform.gameObject;
				_oCtHpCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount4":
				_oCtHpCount4 = transform.gameObject;
				_oCtHpCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount5":
				_oCtHpCount5 = transform.gameObject;
				_oCtHpCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount6":
				_oCtHpCount6 = transform.gameObject;
				_oCtHpCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount7":
				_oCtHpCount7 = transform.gameObject;
				_oCtHpCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtHpCount8":
				_oCtHpCount8 = transform.gameObject;
				_oCtHpCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName1":
				_oCtPlayerName1 = transform.gameObject;
				_oCtPlayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName2":
				_oCtPlayerName2 = transform.gameObject;
				_oCtPlayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName3":
				_oCtPlayerName3 = transform.gameObject;
				_oCtPlayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName4":
				_oCtPlayerName4 = transform.gameObject;
				_oCtPlayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName5":
				_oCtPlayerName5 = transform.gameObject;
				_oCtPlayerNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName6":
				_oCtPlayerName6 = transform.gameObject;
				_oCtPlayerNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName7":
				_oCtPlayerName7 = transform.gameObject;
				_oCtPlayerNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtPlayerName8":
				_oCtPlayerName8 = transform.gameObject;
				_oCtPlayerNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CtWeapon1":
				_oCtWeapon1 = transform.gameObject;
				_oCtWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon2":
				_oCtWeapon2 = transform.gameObject;
				_oCtWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon3":
				_oCtWeapon3 = transform.gameObject;
				_oCtWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon4":
				_oCtWeapon4 = transform.gameObject;
				_oCtWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon5":
				_oCtWeapon5 = transform.gameObject;
				_oCtWeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon6":
				_oCtWeapon6 = transform.gameObject;
				_oCtWeaponImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon7":
				_oCtWeapon7 = transform.gameObject;
				_oCtWeaponImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtWeapon8":
				_oCtWeapon8 = transform.gameObject;
				_oCtWeaponImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "CtDoun1":
				_oCtDoun1 = transform.gameObject;
				break;
			case "CtDoun2":
				_oCtDoun2 = transform.gameObject;
				break;
			case "CtDoun3":
				_oCtDoun3 = transform.gameObject;
				break;
			case "CtDoun4":
				_oCtDoun4 = transform.gameObject;
				break;
			case "CtDoun5":
				_oCtDoun5 = transform.gameObject;
				break;
			case "CtDoun6":
				_oCtDoun6 = transform.gameObject;
				break;
			case "CtDoun7":
				_oCtDoun7 = transform.gameObject;
				break;
			case "CtDoun8":
				_oCtDoun8 = transform.gameObject;
				break;
			case "TPlayer1":
				_oTPlayer1 = transform.gameObject;
				_oTPlayerEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer2":
				_oTPlayer2 = transform.gameObject;
				_oTPlayerEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer3":
				_oTPlayer3 = transform.gameObject;
				_oTPlayerEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer4":
				_oTPlayer4 = transform.gameObject;
				_oTPlayerEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer5":
				_oTPlayer5 = transform.gameObject;
				_oTPlayerEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer6":
				_oTPlayer6 = transform.gameObject;
				_oTPlayerEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer7":
				_oTPlayer7 = transform.gameObject;
				_oTPlayerEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "TPlayer8":
				_oTPlayer8 = transform.gameObject;
				_oTPlayerEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "THpRecImage1":
				_oTHpRecImage1 = transform.gameObject;
				_oTHpRecImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage2":
				_oTHpRecImage2 = transform.gameObject;
				_oTHpRecImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage3":
				_oTHpRecImage3 = transform.gameObject;
				_oTHpRecImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage4":
				_oTHpRecImage4 = transform.gameObject;
				_oTHpRecImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage5":
				_oTHpRecImage5 = transform.gameObject;
				_oTHpRecImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage6":
				_oTHpRecImage6 = transform.gameObject;
				_oTHpRecImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage7":
				_oTHpRecImage7 = transform.gameObject;
				_oTHpRecImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpRecImage8":
				_oTHpRecImage8 = transform.gameObject;
				_oTHpRecImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "THpTriImage1":
				_oTHpTriImage1 = transform.gameObject;
				_oTHpTriImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage2":
				_oTHpTriImage2 = transform.gameObject;
				_oTHpTriImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage3":
				_oTHpTriImage3 = transform.gameObject;
				_oTHpTriImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage4":
				_oTHpTriImage4 = transform.gameObject;
				_oTHpTriImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage5":
				_oTHpTriImage5 = transform.gameObject;
				_oTHpTriImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage6":
				_oTHpTriImage6 = transform.gameObject;
				_oTHpTriImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage7":
				_oTHpTriImage7 = transform.gameObject;
				_oTHpTriImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "THpTriImage8":
				_oTHpTriImage8 = transform.gameObject;
				_oTHpTriImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "TUnchecked1":
				_oTUnchecked1 = transform.gameObject;
				break;
			case "TUnchecked2":
				_oTUnchecked2 = transform.gameObject;
				break;
			case "TUnchecked3":
				_oTUnchecked3 = transform.gameObject;
				break;
			case "TUnchecked4":
				_oTUnchecked4 = transform.gameObject;
				break;
			case "TUnchecked5":
				_oTUnchecked5 = transform.gameObject;
				break;
			case "TUnchecked6":
				_oTUnchecked6 = transform.gameObject;
				break;
			case "TUnchecked7":
				_oTUnchecked7 = transform.gameObject;
				break;
			case "TUnchecked8":
				_oTUnchecked8 = transform.gameObject;
				break;
			case "TChecked1":
				_oTChecked1 = transform.gameObject;
				break;
			case "TChecked2":
				_oTChecked2 = transform.gameObject;
				break;
			case "TChecked3":
				_oTChecked3 = transform.gameObject;
				break;
			case "TChecked4":
				_oTChecked4 = transform.gameObject;
				break;
			case "TChecked5":
				_oTChecked5 = transform.gameObject;
				break;
			case "TChecked6":
				_oTChecked6 = transform.gameObject;
				break;
			case "TChecked7":
				_oTChecked7 = transform.gameObject;
				break;
			case "TChecked8":
				_oTChecked8 = transform.gameObject;
				break;
			case "TKillCount1":
				_oTKillCount1 = transform.gameObject;
				_oTKillCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount2":
				_oTKillCount2 = transform.gameObject;
				_oTKillCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount3":
				_oTKillCount3 = transform.gameObject;
				_oTKillCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount4":
				_oTKillCount4 = transform.gameObject;
				_oTKillCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount5":
				_oTKillCount5 = transform.gameObject;
				_oTKillCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount6":
				_oTKillCount6 = transform.gameObject;
				_oTKillCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount7":
				_oTKillCount7 = transform.gameObject;
				_oTKillCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "TKillCount8":
				_oTKillCount8 = transform.gameObject;
				_oTKillCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount1":
				_oTHpCount1 = transform.gameObject;
				_oTHpCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount2":
				_oTHpCount2 = transform.gameObject;
				_oTHpCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount3":
				_oTHpCount3 = transform.gameObject;
				_oTHpCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount4":
				_oTHpCount4 = transform.gameObject;
				_oTHpCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount5":
				_oTHpCount5 = transform.gameObject;
				_oTHpCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount6":
				_oTHpCount6 = transform.gameObject;
				_oTHpCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount7":
				_oTHpCount7 = transform.gameObject;
				_oTHpCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "THpCount8":
				_oTHpCount8 = transform.gameObject;
				_oTHpCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName1":
				_oTPlayerName1 = transform.gameObject;
				_oTPlayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName2":
				_oTPlayerName2 = transform.gameObject;
				_oTPlayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName3":
				_oTPlayerName3 = transform.gameObject;
				_oTPlayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName4":
				_oTPlayerName4 = transform.gameObject;
				_oTPlayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName5":
				_oTPlayerName5 = transform.gameObject;
				_oTPlayerNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName6":
				_oTPlayerName6 = transform.gameObject;
				_oTPlayerNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName7":
				_oTPlayerName7 = transform.gameObject;
				_oTPlayerNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "TPlayerName8":
				_oTPlayerName8 = transform.gameObject;
				_oTPlayerNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "TWeapon1":
				_oTWeapon1 = transform.gameObject;
				_oTWeaponImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon2":
				_oTWeapon2 = transform.gameObject;
				_oTWeaponImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon3":
				_oTWeapon3 = transform.gameObject;
				_oTWeaponImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon4":
				_oTWeapon4 = transform.gameObject;
				_oTWeaponImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon5":
				_oTWeapon5 = transform.gameObject;
				_oTWeaponImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon6":
				_oTWeapon6 = transform.gameObject;
				_oTWeaponImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon7":
				_oTWeapon7 = transform.gameObject;
				_oTWeaponImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "TWeapon8":
				_oTWeapon8 = transform.gameObject;
				_oTWeaponImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "TDoun1":
				_oTDoun1 = transform.gameObject;
				break;
			case "TDoun2":
				_oTDoun2 = transform.gameObject;
				break;
			case "TDoun3":
				_oTDoun3 = transform.gameObject;
				break;
			case "TDoun4":
				_oTDoun4 = transform.gameObject;
				break;
			case "TDoun5":
				_oTDoun5 = transform.gameObject;
				break;
			case "TDoun6":
				_oTDoun6 = transform.gameObject;
				break;
			case "TDoun7":
				_oTDoun7 = transform.gameObject;
				break;
			case "TDoun8":
				_oTDoun8 = transform.gameObject;
				break;
			case "TC4Icon1":
				_oTC4Icon1 = transform.gameObject;
				_oTC4IconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon2":
				_oTC4Icon2 = transform.gameObject;
				_oTC4IconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon3":
				_oTC4Icon3 = transform.gameObject;
				_oTC4IconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon4":
				_oTC4Icon4 = transform.gameObject;
				_oTC4IconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon5":
				_oTC4Icon5 = transform.gameObject;
				_oTC4IconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon6":
				_oTC4Icon6 = transform.gameObject;
				_oTC4IconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon7":
				_oTC4Icon7 = transform.gameObject;
				_oTC4IconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "TC4Icon8":
				_oTC4Icon8 = transform.gameObject;
				_oTC4IconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
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

	public bool GetCtPlayerShow(int index)
	{
		return index switch
		{
			1 => CtPlayerShow1, 
			2 => CtPlayerShow2, 
			3 => CtPlayerShow3, 
			4 => CtPlayerShow4, 
			5 => CtPlayerShow5, 
			6 => CtPlayerShow6, 
			7 => CtPlayerShow7, 
			8 => CtPlayerShow8, 
			_ => false, 
		};
	}

	public void SetCtPlayerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtPlayerShow1 = value;
			break;
		case 2:
			CtPlayerShow2 = value;
			break;
		case 3:
			CtPlayerShow3 = value;
			break;
		case 4:
			CtPlayerShow4 = value;
			break;
		case 5:
			CtPlayerShow5 = value;
			break;
		case 6:
			CtPlayerShow6 = value;
			break;
		case 7:
			CtPlayerShow7 = value;
			break;
		case 8:
			CtPlayerShow8 = value;
			break;
		}
	}

	public int GetCtPlayerCount()
	{
		return 8;
	}

	private void CreateCtPlayerTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers1, eventId, callback);
	}

	private void RemoveCtPlayerTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers1, eventId);
	}

	private void CreateCtPlayerTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers2, eventId, callback);
	}

	private void RemoveCtPlayerTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers2, eventId);
	}

	private void CreateCtPlayerTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers3, eventId, callback);
	}

	private void RemoveCtPlayerTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers3, eventId);
	}

	private void CreateCtPlayerTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers4, eventId, callback);
	}

	private void RemoveCtPlayerTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers4, eventId);
	}

	private void CreateCtPlayerTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers5, eventId, callback);
	}

	private void RemoveCtPlayerTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers5, eventId);
	}

	private void CreateCtPlayerTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers6, eventId, callback);
	}

	private void RemoveCtPlayerTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers6, eventId);
	}

	private void CreateCtPlayerTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers7, eventId, callback);
	}

	private void RemoveCtPlayerTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers7, eventId);
	}

	private void CreateCtPlayerTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CtPlayerTriggers8, eventId, callback);
	}

	private void RemoveCtPlayerTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CtPlayerTriggers8, eventId);
	}

	public List<EventTrigger.Entry> GetCtPlayerTriggers(int index)
	{
		return index switch
		{
			1 => CtPlayerTriggers1, 
			2 => CtPlayerTriggers2, 
			3 => CtPlayerTriggers3, 
			4 => CtPlayerTriggers4, 
			5 => CtPlayerTriggers5, 
			6 => CtPlayerTriggers6, 
			7 => CtPlayerTriggers7, 
			8 => CtPlayerTriggers8, 
			_ => null, 
		};
	}

	public void SetCtPlayerTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			CtPlayerTriggers1 = value;
			break;
		case 2:
			CtPlayerTriggers2 = value;
			break;
		case 3:
			CtPlayerTriggers3 = value;
			break;
		case 4:
			CtPlayerTriggers4 = value;
			break;
		case 5:
			CtPlayerTriggers5 = value;
			break;
		case 6:
			CtPlayerTriggers6 = value;
			break;
		case 7:
			CtPlayerTriggers7 = value;
			break;
		case 8:
			CtPlayerTriggers8 = value;
			break;
		}
	}

	private void CreateCtPlayerTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetCtPlayerTriggers(index), eventId, callback);
	}

	private void RemoveCtPlayerTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetCtPlayerTriggers(index), eventId);
	}

	public float GetCtHpRecImageFillamount(int index)
	{
		return index switch
		{
			1 => CtHpRecImageFillamount1, 
			2 => CtHpRecImageFillamount2, 
			3 => CtHpRecImageFillamount3, 
			4 => CtHpRecImageFillamount4, 
			5 => CtHpRecImageFillamount5, 
			6 => CtHpRecImageFillamount6, 
			7 => CtHpRecImageFillamount7, 
			8 => CtHpRecImageFillamount8, 
			_ => 0f, 
		};
	}

	public void SetCtHpRecImageFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			CtHpRecImageFillamount1 = value;
			break;
		case 2:
			CtHpRecImageFillamount2 = value;
			break;
		case 3:
			CtHpRecImageFillamount3 = value;
			break;
		case 4:
			CtHpRecImageFillamount4 = value;
			break;
		case 5:
			CtHpRecImageFillamount5 = value;
			break;
		case 6:
			CtHpRecImageFillamount6 = value;
			break;
		case 7:
			CtHpRecImageFillamount7 = value;
			break;
		case 8:
			CtHpRecImageFillamount8 = value;
			break;
		}
	}

	public int GetCtHpRecImageCount()
	{
		return 8;
	}

	public Vector3 GetCtHpTriImagePosition(int index)
	{
		return index switch
		{
			1 => CtHpTriImagePosition1, 
			2 => CtHpTriImagePosition2, 
			3 => CtHpTriImagePosition3, 
			4 => CtHpTriImagePosition4, 
			5 => CtHpTriImagePosition5, 
			6 => CtHpTriImagePosition6, 
			7 => CtHpTriImagePosition7, 
			8 => CtHpTriImagePosition8, 
			_ => Vector3.zero, 
		};
	}

	public void SetCtHpTriImagePosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CtHpTriImagePosition1 = value;
			break;
		case 2:
			CtHpTriImagePosition2 = value;
			break;
		case 3:
			CtHpTriImagePosition3 = value;
			break;
		case 4:
			CtHpTriImagePosition4 = value;
			break;
		case 5:
			CtHpTriImagePosition5 = value;
			break;
		case 6:
			CtHpTriImagePosition6 = value;
			break;
		case 7:
			CtHpTriImagePosition7 = value;
			break;
		case 8:
			CtHpTriImagePosition8 = value;
			break;
		}
	}

	public int GetCtHpTriImageCount()
	{
		return 8;
	}

	public bool GetCtUncheckedShow(int index)
	{
		return index switch
		{
			1 => CtUncheckedShow1, 
			2 => CtUncheckedShow2, 
			3 => CtUncheckedShow3, 
			4 => CtUncheckedShow4, 
			5 => CtUncheckedShow5, 
			6 => CtUncheckedShow6, 
			7 => CtUncheckedShow7, 
			8 => CtUncheckedShow8, 
			_ => false, 
		};
	}

	public void SetCtUncheckedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtUncheckedShow1 = value;
			break;
		case 2:
			CtUncheckedShow2 = value;
			break;
		case 3:
			CtUncheckedShow3 = value;
			break;
		case 4:
			CtUncheckedShow4 = value;
			break;
		case 5:
			CtUncheckedShow5 = value;
			break;
		case 6:
			CtUncheckedShow6 = value;
			break;
		case 7:
			CtUncheckedShow7 = value;
			break;
		case 8:
			CtUncheckedShow8 = value;
			break;
		}
	}

	public int GetCtUncheckedCount()
	{
		return 8;
	}

	public bool GetCtCheckedShow(int index)
	{
		return index switch
		{
			1 => CtCheckedShow1, 
			2 => CtCheckedShow2, 
			3 => CtCheckedShow3, 
			4 => CtCheckedShow4, 
			5 => CtCheckedShow5, 
			6 => CtCheckedShow6, 
			7 => CtCheckedShow7, 
			8 => CtCheckedShow8, 
			_ => false, 
		};
	}

	public void SetCtCheckedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtCheckedShow1 = value;
			break;
		case 2:
			CtCheckedShow2 = value;
			break;
		case 3:
			CtCheckedShow3 = value;
			break;
		case 4:
			CtCheckedShow4 = value;
			break;
		case 5:
			CtCheckedShow5 = value;
			break;
		case 6:
			CtCheckedShow6 = value;
			break;
		case 7:
			CtCheckedShow7 = value;
			break;
		case 8:
			CtCheckedShow8 = value;
			break;
		}
	}

	public int GetCtCheckedCount()
	{
		return 8;
	}

	public string GetCtKillCountString(int index)
	{
		return index switch
		{
			1 => CtKillCountString1, 
			2 => CtKillCountString2, 
			3 => CtKillCountString3, 
			4 => CtKillCountString4, 
			5 => CtKillCountString5, 
			6 => CtKillCountString6, 
			7 => CtKillCountString7, 
			8 => CtKillCountString8, 
			_ => null, 
		};
	}

	public void SetCtKillCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CtKillCountString1 = value;
			break;
		case 2:
			CtKillCountString2 = value;
			break;
		case 3:
			CtKillCountString3 = value;
			break;
		case 4:
			CtKillCountString4 = value;
			break;
		case 5:
			CtKillCountString5 = value;
			break;
		case 6:
			CtKillCountString6 = value;
			break;
		case 7:
			CtKillCountString7 = value;
			break;
		case 8:
			CtKillCountString8 = value;
			break;
		}
	}

	public int GetCtKillCountCount()
	{
		return 8;
	}

	public string GetCtHpCountString(int index)
	{
		return index switch
		{
			1 => CtHpCountString1, 
			2 => CtHpCountString2, 
			3 => CtHpCountString3, 
			4 => CtHpCountString4, 
			5 => CtHpCountString5, 
			6 => CtHpCountString6, 
			7 => CtHpCountString7, 
			8 => CtHpCountString8, 
			_ => null, 
		};
	}

	public void SetCtHpCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CtHpCountString1 = value;
			break;
		case 2:
			CtHpCountString2 = value;
			break;
		case 3:
			CtHpCountString3 = value;
			break;
		case 4:
			CtHpCountString4 = value;
			break;
		case 5:
			CtHpCountString5 = value;
			break;
		case 6:
			CtHpCountString6 = value;
			break;
		case 7:
			CtHpCountString7 = value;
			break;
		case 8:
			CtHpCountString8 = value;
			break;
		}
	}

	public int GetCtHpCountCount()
	{
		return 8;
	}

	public string GetCtPlayerNameString(int index)
	{
		return index switch
		{
			1 => CtPlayerNameString1, 
			2 => CtPlayerNameString2, 
			3 => CtPlayerNameString3, 
			4 => CtPlayerNameString4, 
			5 => CtPlayerNameString5, 
			6 => CtPlayerNameString6, 
			7 => CtPlayerNameString7, 
			8 => CtPlayerNameString8, 
			_ => null, 
		};
	}

	public void SetCtPlayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CtPlayerNameString1 = value;
			break;
		case 2:
			CtPlayerNameString2 = value;
			break;
		case 3:
			CtPlayerNameString3 = value;
			break;
		case 4:
			CtPlayerNameString4 = value;
			break;
		case 5:
			CtPlayerNameString5 = value;
			break;
		case 6:
			CtPlayerNameString6 = value;
			break;
		case 7:
			CtPlayerNameString7 = value;
			break;
		case 8:
			CtPlayerNameString8 = value;
			break;
		}
	}

	public int GetCtPlayerNameCount()
	{
		return 8;
	}

	public Sprite GetCtWeaponSprite(int index)
	{
		return index switch
		{
			1 => CtWeaponSprite1, 
			2 => CtWeaponSprite2, 
			3 => CtWeaponSprite3, 
			4 => CtWeaponSprite4, 
			5 => CtWeaponSprite5, 
			6 => CtWeaponSprite6, 
			7 => CtWeaponSprite7, 
			8 => CtWeaponSprite8, 
			_ => null, 
		};
	}

	public void SetCtWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			CtWeaponSprite1 = value;
			break;
		case 2:
			CtWeaponSprite2 = value;
			break;
		case 3:
			CtWeaponSprite3 = value;
			break;
		case 4:
			CtWeaponSprite4 = value;
			break;
		case 5:
			CtWeaponSprite5 = value;
			break;
		case 6:
			CtWeaponSprite6 = value;
			break;
		case 7:
			CtWeaponSprite7 = value;
			break;
		case 8:
			CtWeaponSprite8 = value;
			break;
		}
	}

	public int GetCtWeaponCount()
	{
		return 8;
	}

	public bool GetCtDounShow(int index)
	{
		return index switch
		{
			1 => CtDounShow1, 
			2 => CtDounShow2, 
			3 => CtDounShow3, 
			4 => CtDounShow4, 
			5 => CtDounShow5, 
			6 => CtDounShow6, 
			7 => CtDounShow7, 
			8 => CtDounShow8, 
			_ => false, 
		};
	}

	public void SetCtDounShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CtDounShow1 = value;
			break;
		case 2:
			CtDounShow2 = value;
			break;
		case 3:
			CtDounShow3 = value;
			break;
		case 4:
			CtDounShow4 = value;
			break;
		case 5:
			CtDounShow5 = value;
			break;
		case 6:
			CtDounShow6 = value;
			break;
		case 7:
			CtDounShow7 = value;
			break;
		case 8:
			CtDounShow8 = value;
			break;
		}
	}

	public int GetCtDounCount()
	{
		return 8;
	}

	public bool GetTPlayerShow(int index)
	{
		return index switch
		{
			1 => TPlayerShow1, 
			2 => TPlayerShow2, 
			3 => TPlayerShow3, 
			4 => TPlayerShow4, 
			5 => TPlayerShow5, 
			6 => TPlayerShow6, 
			7 => TPlayerShow7, 
			8 => TPlayerShow8, 
			_ => false, 
		};
	}

	public void SetTPlayerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TPlayerShow1 = value;
			break;
		case 2:
			TPlayerShow2 = value;
			break;
		case 3:
			TPlayerShow3 = value;
			break;
		case 4:
			TPlayerShow4 = value;
			break;
		case 5:
			TPlayerShow5 = value;
			break;
		case 6:
			TPlayerShow6 = value;
			break;
		case 7:
			TPlayerShow7 = value;
			break;
		case 8:
			TPlayerShow8 = value;
			break;
		}
	}

	public int GetTPlayerCount()
	{
		return 8;
	}

	private void CreateTPlayerTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers1, eventId, callback);
	}

	private void RemoveTPlayerTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers1, eventId);
	}

	private void CreateTPlayerTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers2, eventId, callback);
	}

	private void RemoveTPlayerTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers2, eventId);
	}

	private void CreateTPlayerTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers3, eventId, callback);
	}

	private void RemoveTPlayerTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers3, eventId);
	}

	private void CreateTPlayerTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers4, eventId, callback);
	}

	private void RemoveTPlayerTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers4, eventId);
	}

	private void CreateTPlayerTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers5, eventId, callback);
	}

	private void RemoveTPlayerTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers5, eventId);
	}

	private void CreateTPlayerTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers6, eventId, callback);
	}

	private void RemoveTPlayerTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers6, eventId);
	}

	private void CreateTPlayerTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers7, eventId, callback);
	}

	private void RemoveTPlayerTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers7, eventId);
	}

	private void CreateTPlayerTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(TPlayerTriggers8, eventId, callback);
	}

	private void RemoveTPlayerTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(TPlayerTriggers8, eventId);
	}

	public List<EventTrigger.Entry> GetTPlayerTriggers(int index)
	{
		return index switch
		{
			1 => TPlayerTriggers1, 
			2 => TPlayerTriggers2, 
			3 => TPlayerTriggers3, 
			4 => TPlayerTriggers4, 
			5 => TPlayerTriggers5, 
			6 => TPlayerTriggers6, 
			7 => TPlayerTriggers7, 
			8 => TPlayerTriggers8, 
			_ => null, 
		};
	}

	public void SetTPlayerTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			TPlayerTriggers1 = value;
			break;
		case 2:
			TPlayerTriggers2 = value;
			break;
		case 3:
			TPlayerTriggers3 = value;
			break;
		case 4:
			TPlayerTriggers4 = value;
			break;
		case 5:
			TPlayerTriggers5 = value;
			break;
		case 6:
			TPlayerTriggers6 = value;
			break;
		case 7:
			TPlayerTriggers7 = value;
			break;
		case 8:
			TPlayerTriggers8 = value;
			break;
		}
	}

	private void CreateTPlayerTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetTPlayerTriggers(index), eventId, callback);
	}

	private void RemoveTPlayerTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetTPlayerTriggers(index), eventId);
	}

	public float GetTHpRecImageFillamount(int index)
	{
		return index switch
		{
			1 => THpRecImageFillamount1, 
			2 => THpRecImageFillamount2, 
			3 => THpRecImageFillamount3, 
			4 => THpRecImageFillamount4, 
			5 => THpRecImageFillamount5, 
			6 => THpRecImageFillamount6, 
			7 => THpRecImageFillamount7, 
			8 => THpRecImageFillamount8, 
			_ => 0f, 
		};
	}

	public void SetTHpRecImageFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			THpRecImageFillamount1 = value;
			break;
		case 2:
			THpRecImageFillamount2 = value;
			break;
		case 3:
			THpRecImageFillamount3 = value;
			break;
		case 4:
			THpRecImageFillamount4 = value;
			break;
		case 5:
			THpRecImageFillamount5 = value;
			break;
		case 6:
			THpRecImageFillamount6 = value;
			break;
		case 7:
			THpRecImageFillamount7 = value;
			break;
		case 8:
			THpRecImageFillamount8 = value;
			break;
		}
	}

	public int GetTHpRecImageCount()
	{
		return 8;
	}

	public Vector3 GetTHpTriImagePosition(int index)
	{
		return index switch
		{
			1 => THpTriImagePosition1, 
			2 => THpTriImagePosition2, 
			3 => THpTriImagePosition3, 
			4 => THpTriImagePosition4, 
			5 => THpTriImagePosition5, 
			6 => THpTriImagePosition6, 
			7 => THpTriImagePosition7, 
			8 => THpTriImagePosition8, 
			_ => Vector3.zero, 
		};
	}

	public void SetTHpTriImagePosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			THpTriImagePosition1 = value;
			break;
		case 2:
			THpTriImagePosition2 = value;
			break;
		case 3:
			THpTriImagePosition3 = value;
			break;
		case 4:
			THpTriImagePosition4 = value;
			break;
		case 5:
			THpTriImagePosition5 = value;
			break;
		case 6:
			THpTriImagePosition6 = value;
			break;
		case 7:
			THpTriImagePosition7 = value;
			break;
		case 8:
			THpTriImagePosition8 = value;
			break;
		}
	}

	public int GetTHpTriImageCount()
	{
		return 8;
	}

	public bool GetTUncheckedShow(int index)
	{
		return index switch
		{
			1 => TUncheckedShow1, 
			2 => TUncheckedShow2, 
			3 => TUncheckedShow3, 
			4 => TUncheckedShow4, 
			5 => TUncheckedShow5, 
			6 => TUncheckedShow6, 
			7 => TUncheckedShow7, 
			8 => TUncheckedShow8, 
			_ => false, 
		};
	}

	public void SetTUncheckedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TUncheckedShow1 = value;
			break;
		case 2:
			TUncheckedShow2 = value;
			break;
		case 3:
			TUncheckedShow3 = value;
			break;
		case 4:
			TUncheckedShow4 = value;
			break;
		case 5:
			TUncheckedShow5 = value;
			break;
		case 6:
			TUncheckedShow6 = value;
			break;
		case 7:
			TUncheckedShow7 = value;
			break;
		case 8:
			TUncheckedShow8 = value;
			break;
		}
	}

	public int GetTUncheckedCount()
	{
		return 8;
	}

	public bool GetTCheckedShow(int index)
	{
		return index switch
		{
			1 => TCheckedShow1, 
			2 => TCheckedShow2, 
			3 => TCheckedShow3, 
			4 => TCheckedShow4, 
			5 => TCheckedShow5, 
			6 => TCheckedShow6, 
			7 => TCheckedShow7, 
			8 => TCheckedShow8, 
			_ => false, 
		};
	}

	public void SetTCheckedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TCheckedShow1 = value;
			break;
		case 2:
			TCheckedShow2 = value;
			break;
		case 3:
			TCheckedShow3 = value;
			break;
		case 4:
			TCheckedShow4 = value;
			break;
		case 5:
			TCheckedShow5 = value;
			break;
		case 6:
			TCheckedShow6 = value;
			break;
		case 7:
			TCheckedShow7 = value;
			break;
		case 8:
			TCheckedShow8 = value;
			break;
		}
	}

	public int GetTCheckedCount()
	{
		return 8;
	}

	public string GetTKillCountString(int index)
	{
		return index switch
		{
			1 => TKillCountString1, 
			2 => TKillCountString2, 
			3 => TKillCountString3, 
			4 => TKillCountString4, 
			5 => TKillCountString5, 
			6 => TKillCountString6, 
			7 => TKillCountString7, 
			8 => TKillCountString8, 
			_ => null, 
		};
	}

	public void SetTKillCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TKillCountString1 = value;
			break;
		case 2:
			TKillCountString2 = value;
			break;
		case 3:
			TKillCountString3 = value;
			break;
		case 4:
			TKillCountString4 = value;
			break;
		case 5:
			TKillCountString5 = value;
			break;
		case 6:
			TKillCountString6 = value;
			break;
		case 7:
			TKillCountString7 = value;
			break;
		case 8:
			TKillCountString8 = value;
			break;
		}
	}

	public int GetTKillCountCount()
	{
		return 8;
	}

	public string GetTHpCountString(int index)
	{
		return index switch
		{
			1 => THpCountString1, 
			2 => THpCountString2, 
			3 => THpCountString3, 
			4 => THpCountString4, 
			5 => THpCountString5, 
			6 => THpCountString6, 
			7 => THpCountString7, 
			8 => THpCountString8, 
			_ => null, 
		};
	}

	public void SetTHpCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			THpCountString1 = value;
			break;
		case 2:
			THpCountString2 = value;
			break;
		case 3:
			THpCountString3 = value;
			break;
		case 4:
			THpCountString4 = value;
			break;
		case 5:
			THpCountString5 = value;
			break;
		case 6:
			THpCountString6 = value;
			break;
		case 7:
			THpCountString7 = value;
			break;
		case 8:
			THpCountString8 = value;
			break;
		}
	}

	public int GetTHpCountCount()
	{
		return 8;
	}

	public string GetTPlayerNameString(int index)
	{
		return index switch
		{
			1 => TPlayerNameString1, 
			2 => TPlayerNameString2, 
			3 => TPlayerNameString3, 
			4 => TPlayerNameString4, 
			5 => TPlayerNameString5, 
			6 => TPlayerNameString6, 
			7 => TPlayerNameString7, 
			8 => TPlayerNameString8, 
			_ => null, 
		};
	}

	public void SetTPlayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TPlayerNameString1 = value;
			break;
		case 2:
			TPlayerNameString2 = value;
			break;
		case 3:
			TPlayerNameString3 = value;
			break;
		case 4:
			TPlayerNameString4 = value;
			break;
		case 5:
			TPlayerNameString5 = value;
			break;
		case 6:
			TPlayerNameString6 = value;
			break;
		case 7:
			TPlayerNameString7 = value;
			break;
		case 8:
			TPlayerNameString8 = value;
			break;
		}
	}

	public int GetTPlayerNameCount()
	{
		return 8;
	}

	public Sprite GetTWeaponSprite(int index)
	{
		return index switch
		{
			1 => TWeaponSprite1, 
			2 => TWeaponSprite2, 
			3 => TWeaponSprite3, 
			4 => TWeaponSprite4, 
			5 => TWeaponSprite5, 
			6 => TWeaponSprite6, 
			7 => TWeaponSprite7, 
			8 => TWeaponSprite8, 
			_ => null, 
		};
	}

	public void SetTWeaponSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TWeaponSprite1 = value;
			break;
		case 2:
			TWeaponSprite2 = value;
			break;
		case 3:
			TWeaponSprite3 = value;
			break;
		case 4:
			TWeaponSprite4 = value;
			break;
		case 5:
			TWeaponSprite5 = value;
			break;
		case 6:
			TWeaponSprite6 = value;
			break;
		case 7:
			TWeaponSprite7 = value;
			break;
		case 8:
			TWeaponSprite8 = value;
			break;
		}
	}

	public int GetTWeaponCount()
	{
		return 8;
	}

	public bool GetTDounShow(int index)
	{
		return index switch
		{
			1 => TDounShow1, 
			2 => TDounShow2, 
			3 => TDounShow3, 
			4 => TDounShow4, 
			5 => TDounShow5, 
			6 => TDounShow6, 
			7 => TDounShow7, 
			8 => TDounShow8, 
			_ => false, 
		};
	}

	public void SetTDounShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TDounShow1 = value;
			break;
		case 2:
			TDounShow2 = value;
			break;
		case 3:
			TDounShow3 = value;
			break;
		case 4:
			TDounShow4 = value;
			break;
		case 5:
			TDounShow5 = value;
			break;
		case 6:
			TDounShow6 = value;
			break;
		case 7:
			TDounShow7 = value;
			break;
		case 8:
			TDounShow8 = value;
			break;
		}
	}

	public int GetTDounCount()
	{
		return 8;
	}

	public bool GetTC4IconShow(int index)
	{
		return index switch
		{
			1 => TC4IconShow1, 
			2 => TC4IconShow2, 
			3 => TC4IconShow3, 
			4 => TC4IconShow4, 
			5 => TC4IconShow5, 
			6 => TC4IconShow6, 
			7 => TC4IconShow7, 
			8 => TC4IconShow8, 
			_ => false, 
		};
	}

	public void SetTC4IconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TC4IconShow1 = value;
			break;
		case 2:
			TC4IconShow2 = value;
			break;
		case 3:
			TC4IconShow3 = value;
			break;
		case 4:
			TC4IconShow4 = value;
			break;
		case 5:
			TC4IconShow5 = value;
			break;
		case 6:
			TC4IconShow6 = value;
			break;
		case 7:
			TC4IconShow7 = value;
			break;
		case 8:
			TC4IconShow8 = value;
			break;
		}
	}

	public int GetTC4IconCount()
	{
		return 8;
	}

	public Sprite GetTC4IconSprite(int index)
	{
		return index switch
		{
			1 => TC4IconSprite1, 
			2 => TC4IconSprite2, 
			3 => TC4IconSprite3, 
			4 => TC4IconSprite4, 
			5 => TC4IconSprite5, 
			6 => TC4IconSprite6, 
			7 => TC4IconSprite7, 
			8 => TC4IconSprite8, 
			_ => null, 
		};
	}

	public void SetTC4IconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TC4IconSprite1 = value;
			break;
		case 2:
			TC4IconSprite2 = value;
			break;
		case 3:
			TC4IconSprite3 = value;
			break;
		case 4:
			TC4IconSprite4 = value;
			break;
		case 5:
			TC4IconSprite5 = value;
			break;
		case 6:
			TC4IconSprite6 = value;
			break;
		case 7:
			TC4IconSprite7 = value;
			break;
		case 8:
			TC4IconSprite8 = value;
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
