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

namespace Assets.Sources.Ui.ViewModel.QuickTest;

[GameUiTest]
public class QuickMultiPlayerViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oScreen;

	private GameObject _oHideScreen;

	private Button _oHideScreenButton;

	private GameObject _oText1;

	private GameObject _oText2;

	private GameObject _oText3;

	private GameObject _oText4;

	private GameObject _oText5;

	private GameObject _oText6;

	private GameObject _oText7;

	private GameObject _oText8;

	private GameObject _oText9;

	private GameObject _oText10;

	private GameObject _oText11;

	private GameObject _oText12;

	private GameObject _oText13;

	private GameObject _oText14;

	private GameObject _oText15;

	private GameObject _oText16;

	private Text _oTextText1;

	private Text _oTextText2;

	private Text _oTextText3;

	private Text _oTextText4;

	private Text _oTextText5;

	private Text _oTextText6;

	private Text _oTextText7;

	private Text _oTextText8;

	private Text _oTextText9;

	private Text _oTextText10;

	private Text _oTextText11;

	private Text _oTextText12;

	private Text _oTextText13;

	private Text _oTextText14;

	private Text _oTextText15;

	private Text _oTextText16;

	private GameObject _oUI;

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

	private GameObject _oPlayer11;

	private GameObject _oPlayer12;

	private GameObject _oPlayer13;

	private GameObject _oPlayer14;

	private GameObject _oPlayer15;

	private GameObject _oPlayer16;

	private Button _oPlayerButton1;

	private Button _oPlayerButton2;

	private Button _oPlayerButton3;

	private Button _oPlayerButton4;

	private Button _oPlayerButton5;

	private Button _oPlayerButton6;

	private Button _oPlayerButton7;

	private Button _oPlayerButton8;

	private Button _oPlayerButton9;

	private Button _oPlayerButton10;

	private Button _oPlayerButton11;

	private Button _oPlayerButton12;

	private Button _oPlayerButton13;

	private Button _oPlayerButton14;

	private Button _oPlayerButton15;

	private Button _oPlayerButton16;

	private GameObject _oNameText1;

	private GameObject _oNameText2;

	private GameObject _oNameText3;

	private GameObject _oNameText4;

	private GameObject _oNameText5;

	private GameObject _oNameText6;

	private GameObject _oNameText7;

	private GameObject _oNameText8;

	private GameObject _oNameText9;

	private GameObject _oNameText10;

	private GameObject _oNameText11;

	private GameObject _oNameText12;

	private GameObject _oNameText13;

	private GameObject _oNameText14;

	private GameObject _oNameText15;

	private GameObject _oNameText16;

	private Text _oNameTextText1;

	private Text _oNameTextText2;

	private Text _oNameTextText3;

	private Text _oNameTextText4;

	private Text _oNameTextText5;

	private Text _oNameTextText6;

	private Text _oNameTextText7;

	private Text _oNameTextText8;

	private Text _oNameTextText9;

	private Text _oNameTextText10;

	private Text _oNameTextText11;

	private Text _oNameTextText12;

	private Text _oNameTextText13;

	private Text _oNameTextText14;

	private Text _oNameTextText15;

	private Text _oNameTextText16;

	private GameObject _oLeave1;

	private GameObject _oLeave2;

	private GameObject _oLeave3;

	private GameObject _oLeave4;

	private GameObject _oLeave5;

	private GameObject _oLeave6;

	private GameObject _oLeave7;

	private GameObject _oLeave8;

	private GameObject _oLeave9;

	private GameObject _oLeave10;

	private GameObject _oLeave11;

	private GameObject _oLeave12;

	private GameObject _oLeave13;

	private GameObject _oLeave14;

	private GameObject _oLeave15;

	private GameObject _oLeave16;

	private Button _oLeaveButton1;

	private Button _oLeaveButton2;

	private Button _oLeaveButton3;

	private Button _oLeaveButton4;

	private Button _oLeaveButton5;

	private Button _oLeaveButton6;

	private Button _oLeaveButton7;

	private Button _oLeaveButton8;

	private Button _oLeaveButton9;

	private Button _oLeaveButton10;

	private Button _oLeaveButton11;

	private Button _oLeaveButton12;

	private Button _oLeaveButton13;

	private Button _oLeaveButton14;

	private Button _oLeaveButton15;

	private Button _oLeaveButton16;

	private GameObject _oSelected1;

	private GameObject _oSelected2;

	private GameObject _oSelected3;

	private GameObject _oSelected4;

	private GameObject _oSelected5;

	private GameObject _oSelected6;

	private GameObject _oSelected7;

	private GameObject _oSelected8;

	private GameObject _oSelected9;

	private GameObject _oSelected10;

	private GameObject _oSelected11;

	private GameObject _oSelected12;

	private GameObject _oSelected13;

	private GameObject _oSelected14;

	private GameObject _oSelected15;

	private GameObject _oSelected16;

	private GameObject _oShowScreen;

	private Button _oShowScreenButton;

	private GameObject _oCloseBtn;

	private Button _oCloseBtnButton;

	private GameObject _oAdd;

	private Button _oAddButton;

	private GameObject _oMyself;

	private Button _oMyselfButton;

	private GameObject _oAllSelect;

	private Button _oAllSelectButton;

	private GameObject _oSimpleCopy;

	private Toggle _oSimpleCopyToggle;

	private GameObject _oSelfOperate;

	private Toggle _oSelfOperateToggle;

	private GameObject _oPosition;

	private GameObject _oPos1;

	private GameObject _oPos2;

	private GameObject _oPos3;

	private GameObject _oPos4;

	private GameObject _oPos5;

	private GameObject _oPos6;

	private GameObject _oPos7;

	private GameObject _oPos8;

	private GameObject _oPos9;

	private GameObject _oPos10;

	private GameObject _oPos11;

	private GameObject _oPos12;

	private GameObject _oPos13;

	private GameObject _oPos14;

	private GameObject _oPos15;

	private GameObject _oPos16;

	private RectTransform _oPosRectTransform1;

	private RectTransform _oPosRectTransform2;

	private RectTransform _oPosRectTransform3;

	private RectTransform _oPosRectTransform4;

	private RectTransform _oPosRectTransform5;

	private RectTransform _oPosRectTransform6;

	private RectTransform _oPosRectTransform7;

	private RectTransform _oPosRectTransform8;

	private RectTransform _oPosRectTransform9;

	private RectTransform _oPosRectTransform10;

	private RectTransform _oPosRectTransform11;

	private RectTransform _oPosRectTransform12;

	private RectTransform _oPosRectTransform13;

	private RectTransform _oPosRectTransform14;

	private RectTransform _oPosRectTransform15;

	private RectTransform _oPosRectTransform16;

	private Text _oPosText1;

	private Text _oPosText2;

	private Text _oPosText3;

	private Text _oPosText4;

	private Text _oPosText5;

	private Text _oPosText6;

	private Text _oPosText7;

	private Text _oPosText8;

	private Text _oPosText9;

	private Text _oPosText10;

	private Text _oPosText11;

	private Text _oPosText12;

	private Text _oPosText13;

	private Text _oPosText14;

	private Text _oPosText15;

	private Text _oPosText16;

	private GameObject _oFlag1;

	private GameObject _oFlag2;

	private GameObject _oFlag3;

	private GameObject _oFlag4;

	private GameObject _oFlag5;

	private GameObject _oFlag6;

	private GameObject _oFlag7;

	private GameObject _oFlag8;

	private GameObject _oFlag9;

	private GameObject _oFlag10;

	private GameObject _oFlag11;

	private GameObject _oFlag12;

	private GameObject _oFlag13;

	private GameObject _oFlag14;

	private GameObject _oFlag15;

	private GameObject _oFlag16;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/quicktest";

	private string _resourceAssetName = "QuickMultiPlayer";

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

	public GameObject ScreenObj => _oScreen;

	public bool ScreenShow
	{
		get
		{
			if (_oScreen != null)
			{
				return _oScreen.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ScreenShow != value && _oScreen != null)
			{
				_oScreen.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent HideScreenClicked
	{
		get
		{
			if (_oHideScreenButton != null)
			{
				return _oHideScreenButton.onClick;
			}
			return null;
		}
		set
		{
			if (HideScreenClicked != value && _oHideScreenButton != null)
			{
				_oHideScreenButton.onClick = value;
			}
		}
	}

	public string TextString1
	{
		get
		{
			if (_oTextText1 != null)
			{
				return _oTextText1.text;
			}
			return null;
		}
		set
		{
			if (TextString1 != value && _oTextText1 != null)
			{
				_oTextText1.text = value;
			}
		}
	}

	public string TextString2
	{
		get
		{
			if (_oTextText2 != null)
			{
				return _oTextText2.text;
			}
			return null;
		}
		set
		{
			if (TextString2 != value && _oTextText2 != null)
			{
				_oTextText2.text = value;
			}
		}
	}

	public string TextString3
	{
		get
		{
			if (_oTextText3 != null)
			{
				return _oTextText3.text;
			}
			return null;
		}
		set
		{
			if (TextString3 != value && _oTextText3 != null)
			{
				_oTextText3.text = value;
			}
		}
	}

	public string TextString4
	{
		get
		{
			if (_oTextText4 != null)
			{
				return _oTextText4.text;
			}
			return null;
		}
		set
		{
			if (TextString4 != value && _oTextText4 != null)
			{
				_oTextText4.text = value;
			}
		}
	}

	public string TextString5
	{
		get
		{
			if (_oTextText5 != null)
			{
				return _oTextText5.text;
			}
			return null;
		}
		set
		{
			if (TextString5 != value && _oTextText5 != null)
			{
				_oTextText5.text = value;
			}
		}
	}

	public string TextString6
	{
		get
		{
			if (_oTextText6 != null)
			{
				return _oTextText6.text;
			}
			return null;
		}
		set
		{
			if (TextString6 != value && _oTextText6 != null)
			{
				_oTextText6.text = value;
			}
		}
	}

	public string TextString7
	{
		get
		{
			if (_oTextText7 != null)
			{
				return _oTextText7.text;
			}
			return null;
		}
		set
		{
			if (TextString7 != value && _oTextText7 != null)
			{
				_oTextText7.text = value;
			}
		}
	}

	public string TextString8
	{
		get
		{
			if (_oTextText8 != null)
			{
				return _oTextText8.text;
			}
			return null;
		}
		set
		{
			if (TextString8 != value && _oTextText8 != null)
			{
				_oTextText8.text = value;
			}
		}
	}

	public string TextString9
	{
		get
		{
			if (_oTextText9 != null)
			{
				return _oTextText9.text;
			}
			return null;
		}
		set
		{
			if (TextString9 != value && _oTextText9 != null)
			{
				_oTextText9.text = value;
			}
		}
	}

	public string TextString10
	{
		get
		{
			if (_oTextText10 != null)
			{
				return _oTextText10.text;
			}
			return null;
		}
		set
		{
			if (TextString10 != value && _oTextText10 != null)
			{
				_oTextText10.text = value;
			}
		}
	}

	public string TextString11
	{
		get
		{
			if (_oTextText11 != null)
			{
				return _oTextText11.text;
			}
			return null;
		}
		set
		{
			if (TextString11 != value && _oTextText11 != null)
			{
				_oTextText11.text = value;
			}
		}
	}

	public string TextString12
	{
		get
		{
			if (_oTextText12 != null)
			{
				return _oTextText12.text;
			}
			return null;
		}
		set
		{
			if (TextString12 != value && _oTextText12 != null)
			{
				_oTextText12.text = value;
			}
		}
	}

	public string TextString13
	{
		get
		{
			if (_oTextText13 != null)
			{
				return _oTextText13.text;
			}
			return null;
		}
		set
		{
			if (TextString13 != value && _oTextText13 != null)
			{
				_oTextText13.text = value;
			}
		}
	}

	public string TextString14
	{
		get
		{
			if (_oTextText14 != null)
			{
				return _oTextText14.text;
			}
			return null;
		}
		set
		{
			if (TextString14 != value && _oTextText14 != null)
			{
				_oTextText14.text = value;
			}
		}
	}

	public string TextString15
	{
		get
		{
			if (_oTextText15 != null)
			{
				return _oTextText15.text;
			}
			return null;
		}
		set
		{
			if (TextString15 != value && _oTextText15 != null)
			{
				_oTextText15.text = value;
			}
		}
	}

	public string TextString16
	{
		get
		{
			if (_oTextText16 != null)
			{
				return _oTextText16.text;
			}
			return null;
		}
		set
		{
			if (TextString16 != value && _oTextText16 != null)
			{
				_oTextText16.text = value;
			}
		}
	}

	public bool UIShow
	{
		get
		{
			if (_oUI != null)
			{
				return _oUI.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UIShow != value && _oUI != null)
			{
				_oUI.SetObjectActive(value);
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

	public bool PlayerShow11
	{
		get
		{
			if (_oPlayer11 != null)
			{
				return _oPlayer11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow11 != value && _oPlayer11 != null)
			{
				_oPlayer11.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow12
	{
		get
		{
			if (_oPlayer12 != null)
			{
				return _oPlayer12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow12 != value && _oPlayer12 != null)
			{
				_oPlayer12.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow13
	{
		get
		{
			if (_oPlayer13 != null)
			{
				return _oPlayer13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow13 != value && _oPlayer13 != null)
			{
				_oPlayer13.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow14
	{
		get
		{
			if (_oPlayer14 != null)
			{
				return _oPlayer14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow14 != value && _oPlayer14 != null)
			{
				_oPlayer14.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow15
	{
		get
		{
			if (_oPlayer15 != null)
			{
				return _oPlayer15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow15 != value && _oPlayer15 != null)
			{
				_oPlayer15.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow16
	{
		get
		{
			if (_oPlayer16 != null)
			{
				return _oPlayer16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow16 != value && _oPlayer16 != null)
			{
				_oPlayer16.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked1
	{
		get
		{
			if (_oPlayerButton1 != null)
			{
				return _oPlayerButton1.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked1 != value && _oPlayerButton1 != null)
			{
				_oPlayerButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked2
	{
		get
		{
			if (_oPlayerButton2 != null)
			{
				return _oPlayerButton2.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked2 != value && _oPlayerButton2 != null)
			{
				_oPlayerButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked3
	{
		get
		{
			if (_oPlayerButton3 != null)
			{
				return _oPlayerButton3.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked3 != value && _oPlayerButton3 != null)
			{
				_oPlayerButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked4
	{
		get
		{
			if (_oPlayerButton4 != null)
			{
				return _oPlayerButton4.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked4 != value && _oPlayerButton4 != null)
			{
				_oPlayerButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked5
	{
		get
		{
			if (_oPlayerButton5 != null)
			{
				return _oPlayerButton5.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked5 != value && _oPlayerButton5 != null)
			{
				_oPlayerButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked6
	{
		get
		{
			if (_oPlayerButton6 != null)
			{
				return _oPlayerButton6.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked6 != value && _oPlayerButton6 != null)
			{
				_oPlayerButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked7
	{
		get
		{
			if (_oPlayerButton7 != null)
			{
				return _oPlayerButton7.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked7 != value && _oPlayerButton7 != null)
			{
				_oPlayerButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked8
	{
		get
		{
			if (_oPlayerButton8 != null)
			{
				return _oPlayerButton8.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked8 != value && _oPlayerButton8 != null)
			{
				_oPlayerButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked9
	{
		get
		{
			if (_oPlayerButton9 != null)
			{
				return _oPlayerButton9.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked9 != value && _oPlayerButton9 != null)
			{
				_oPlayerButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked10
	{
		get
		{
			if (_oPlayerButton10 != null)
			{
				return _oPlayerButton10.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked10 != value && _oPlayerButton10 != null)
			{
				_oPlayerButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked11
	{
		get
		{
			if (_oPlayerButton11 != null)
			{
				return _oPlayerButton11.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked11 != value && _oPlayerButton11 != null)
			{
				_oPlayerButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked12
	{
		get
		{
			if (_oPlayerButton12 != null)
			{
				return _oPlayerButton12.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked12 != value && _oPlayerButton12 != null)
			{
				_oPlayerButton12.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked13
	{
		get
		{
			if (_oPlayerButton13 != null)
			{
				return _oPlayerButton13.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked13 != value && _oPlayerButton13 != null)
			{
				_oPlayerButton13.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked14
	{
		get
		{
			if (_oPlayerButton14 != null)
			{
				return _oPlayerButton14.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked14 != value && _oPlayerButton14 != null)
			{
				_oPlayerButton14.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked15
	{
		get
		{
			if (_oPlayerButton15 != null)
			{
				return _oPlayerButton15.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked15 != value && _oPlayerButton15 != null)
			{
				_oPlayerButton15.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PlayerClicked16
	{
		get
		{
			if (_oPlayerButton16 != null)
			{
				return _oPlayerButton16.onClick;
			}
			return null;
		}
		set
		{
			if (PlayerClicked16 != value && _oPlayerButton16 != null)
			{
				_oPlayerButton16.onClick = value;
			}
		}
	}

	public string NameTextString1
	{
		get
		{
			if (_oNameTextText1 != null)
			{
				return _oNameTextText1.text;
			}
			return null;
		}
		set
		{
			if (NameTextString1 != value && _oNameTextText1 != null)
			{
				_oNameTextText1.text = value;
			}
		}
	}

	public string NameTextString2
	{
		get
		{
			if (_oNameTextText2 != null)
			{
				return _oNameTextText2.text;
			}
			return null;
		}
		set
		{
			if (NameTextString2 != value && _oNameTextText2 != null)
			{
				_oNameTextText2.text = value;
			}
		}
	}

	public string NameTextString3
	{
		get
		{
			if (_oNameTextText3 != null)
			{
				return _oNameTextText3.text;
			}
			return null;
		}
		set
		{
			if (NameTextString3 != value && _oNameTextText3 != null)
			{
				_oNameTextText3.text = value;
			}
		}
	}

	public string NameTextString4
	{
		get
		{
			if (_oNameTextText4 != null)
			{
				return _oNameTextText4.text;
			}
			return null;
		}
		set
		{
			if (NameTextString4 != value && _oNameTextText4 != null)
			{
				_oNameTextText4.text = value;
			}
		}
	}

	public string NameTextString5
	{
		get
		{
			if (_oNameTextText5 != null)
			{
				return _oNameTextText5.text;
			}
			return null;
		}
		set
		{
			if (NameTextString5 != value && _oNameTextText5 != null)
			{
				_oNameTextText5.text = value;
			}
		}
	}

	public string NameTextString6
	{
		get
		{
			if (_oNameTextText6 != null)
			{
				return _oNameTextText6.text;
			}
			return null;
		}
		set
		{
			if (NameTextString6 != value && _oNameTextText6 != null)
			{
				_oNameTextText6.text = value;
			}
		}
	}

	public string NameTextString7
	{
		get
		{
			if (_oNameTextText7 != null)
			{
				return _oNameTextText7.text;
			}
			return null;
		}
		set
		{
			if (NameTextString7 != value && _oNameTextText7 != null)
			{
				_oNameTextText7.text = value;
			}
		}
	}

	public string NameTextString8
	{
		get
		{
			if (_oNameTextText8 != null)
			{
				return _oNameTextText8.text;
			}
			return null;
		}
		set
		{
			if (NameTextString8 != value && _oNameTextText8 != null)
			{
				_oNameTextText8.text = value;
			}
		}
	}

	public string NameTextString9
	{
		get
		{
			if (_oNameTextText9 != null)
			{
				return _oNameTextText9.text;
			}
			return null;
		}
		set
		{
			if (NameTextString9 != value && _oNameTextText9 != null)
			{
				_oNameTextText9.text = value;
			}
		}
	}

	public string NameTextString10
	{
		get
		{
			if (_oNameTextText10 != null)
			{
				return _oNameTextText10.text;
			}
			return null;
		}
		set
		{
			if (NameTextString10 != value && _oNameTextText10 != null)
			{
				_oNameTextText10.text = value;
			}
		}
	}

	public string NameTextString11
	{
		get
		{
			if (_oNameTextText11 != null)
			{
				return _oNameTextText11.text;
			}
			return null;
		}
		set
		{
			if (NameTextString11 != value && _oNameTextText11 != null)
			{
				_oNameTextText11.text = value;
			}
		}
	}

	public string NameTextString12
	{
		get
		{
			if (_oNameTextText12 != null)
			{
				return _oNameTextText12.text;
			}
			return null;
		}
		set
		{
			if (NameTextString12 != value && _oNameTextText12 != null)
			{
				_oNameTextText12.text = value;
			}
		}
	}

	public string NameTextString13
	{
		get
		{
			if (_oNameTextText13 != null)
			{
				return _oNameTextText13.text;
			}
			return null;
		}
		set
		{
			if (NameTextString13 != value && _oNameTextText13 != null)
			{
				_oNameTextText13.text = value;
			}
		}
	}

	public string NameTextString14
	{
		get
		{
			if (_oNameTextText14 != null)
			{
				return _oNameTextText14.text;
			}
			return null;
		}
		set
		{
			if (NameTextString14 != value && _oNameTextText14 != null)
			{
				_oNameTextText14.text = value;
			}
		}
	}

	public string NameTextString15
	{
		get
		{
			if (_oNameTextText15 != null)
			{
				return _oNameTextText15.text;
			}
			return null;
		}
		set
		{
			if (NameTextString15 != value && _oNameTextText15 != null)
			{
				_oNameTextText15.text = value;
			}
		}
	}

	public string NameTextString16
	{
		get
		{
			if (_oNameTextText16 != null)
			{
				return _oNameTextText16.text;
			}
			return null;
		}
		set
		{
			if (NameTextString16 != value && _oNameTextText16 != null)
			{
				_oNameTextText16.text = value;
			}
		}
	}

	public Color NameTextTextcolor1
	{
		get
		{
			if (_oNameTextText1 != null)
			{
				return _oNameTextText1.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor1 != value && _oNameTextText1 != null)
			{
				_oNameTextText1.color = value;
			}
		}
	}

	public Color NameTextTextcolor2
	{
		get
		{
			if (_oNameTextText2 != null)
			{
				return _oNameTextText2.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor2 != value && _oNameTextText2 != null)
			{
				_oNameTextText2.color = value;
			}
		}
	}

	public Color NameTextTextcolor3
	{
		get
		{
			if (_oNameTextText3 != null)
			{
				return _oNameTextText3.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor3 != value && _oNameTextText3 != null)
			{
				_oNameTextText3.color = value;
			}
		}
	}

	public Color NameTextTextcolor4
	{
		get
		{
			if (_oNameTextText4 != null)
			{
				return _oNameTextText4.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor4 != value && _oNameTextText4 != null)
			{
				_oNameTextText4.color = value;
			}
		}
	}

	public Color NameTextTextcolor5
	{
		get
		{
			if (_oNameTextText5 != null)
			{
				return _oNameTextText5.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor5 != value && _oNameTextText5 != null)
			{
				_oNameTextText5.color = value;
			}
		}
	}

	public Color NameTextTextcolor6
	{
		get
		{
			if (_oNameTextText6 != null)
			{
				return _oNameTextText6.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor6 != value && _oNameTextText6 != null)
			{
				_oNameTextText6.color = value;
			}
		}
	}

	public Color NameTextTextcolor7
	{
		get
		{
			if (_oNameTextText7 != null)
			{
				return _oNameTextText7.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor7 != value && _oNameTextText7 != null)
			{
				_oNameTextText7.color = value;
			}
		}
	}

	public Color NameTextTextcolor8
	{
		get
		{
			if (_oNameTextText8 != null)
			{
				return _oNameTextText8.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor8 != value && _oNameTextText8 != null)
			{
				_oNameTextText8.color = value;
			}
		}
	}

	public Color NameTextTextcolor9
	{
		get
		{
			if (_oNameTextText9 != null)
			{
				return _oNameTextText9.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor9 != value && _oNameTextText9 != null)
			{
				_oNameTextText9.color = value;
			}
		}
	}

	public Color NameTextTextcolor10
	{
		get
		{
			if (_oNameTextText10 != null)
			{
				return _oNameTextText10.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor10 != value && _oNameTextText10 != null)
			{
				_oNameTextText10.color = value;
			}
		}
	}

	public Color NameTextTextcolor11
	{
		get
		{
			if (_oNameTextText11 != null)
			{
				return _oNameTextText11.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor11 != value && _oNameTextText11 != null)
			{
				_oNameTextText11.color = value;
			}
		}
	}

	public Color NameTextTextcolor12
	{
		get
		{
			if (_oNameTextText12 != null)
			{
				return _oNameTextText12.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor12 != value && _oNameTextText12 != null)
			{
				_oNameTextText12.color = value;
			}
		}
	}

	public Color NameTextTextcolor13
	{
		get
		{
			if (_oNameTextText13 != null)
			{
				return _oNameTextText13.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor13 != value && _oNameTextText13 != null)
			{
				_oNameTextText13.color = value;
			}
		}
	}

	public Color NameTextTextcolor14
	{
		get
		{
			if (_oNameTextText14 != null)
			{
				return _oNameTextText14.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor14 != value && _oNameTextText14 != null)
			{
				_oNameTextText14.color = value;
			}
		}
	}

	public Color NameTextTextcolor15
	{
		get
		{
			if (_oNameTextText15 != null)
			{
				return _oNameTextText15.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor15 != value && _oNameTextText15 != null)
			{
				_oNameTextText15.color = value;
			}
		}
	}

	public Color NameTextTextcolor16
	{
		get
		{
			if (_oNameTextText16 != null)
			{
				return _oNameTextText16.color;
			}
			return Color.white;
		}
		set
		{
			if (NameTextTextcolor16 != value && _oNameTextText16 != null)
			{
				_oNameTextText16.color = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked1
	{
		get
		{
			if (_oLeaveButton1 != null)
			{
				return _oLeaveButton1.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked1 != value && _oLeaveButton1 != null)
			{
				_oLeaveButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked2
	{
		get
		{
			if (_oLeaveButton2 != null)
			{
				return _oLeaveButton2.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked2 != value && _oLeaveButton2 != null)
			{
				_oLeaveButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked3
	{
		get
		{
			if (_oLeaveButton3 != null)
			{
				return _oLeaveButton3.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked3 != value && _oLeaveButton3 != null)
			{
				_oLeaveButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked4
	{
		get
		{
			if (_oLeaveButton4 != null)
			{
				return _oLeaveButton4.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked4 != value && _oLeaveButton4 != null)
			{
				_oLeaveButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked5
	{
		get
		{
			if (_oLeaveButton5 != null)
			{
				return _oLeaveButton5.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked5 != value && _oLeaveButton5 != null)
			{
				_oLeaveButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked6
	{
		get
		{
			if (_oLeaveButton6 != null)
			{
				return _oLeaveButton6.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked6 != value && _oLeaveButton6 != null)
			{
				_oLeaveButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked7
	{
		get
		{
			if (_oLeaveButton7 != null)
			{
				return _oLeaveButton7.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked7 != value && _oLeaveButton7 != null)
			{
				_oLeaveButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked8
	{
		get
		{
			if (_oLeaveButton8 != null)
			{
				return _oLeaveButton8.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked8 != value && _oLeaveButton8 != null)
			{
				_oLeaveButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked9
	{
		get
		{
			if (_oLeaveButton9 != null)
			{
				return _oLeaveButton9.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked9 != value && _oLeaveButton9 != null)
			{
				_oLeaveButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked10
	{
		get
		{
			if (_oLeaveButton10 != null)
			{
				return _oLeaveButton10.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked10 != value && _oLeaveButton10 != null)
			{
				_oLeaveButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked11
	{
		get
		{
			if (_oLeaveButton11 != null)
			{
				return _oLeaveButton11.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked11 != value && _oLeaveButton11 != null)
			{
				_oLeaveButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked12
	{
		get
		{
			if (_oLeaveButton12 != null)
			{
				return _oLeaveButton12.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked12 != value && _oLeaveButton12 != null)
			{
				_oLeaveButton12.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked13
	{
		get
		{
			if (_oLeaveButton13 != null)
			{
				return _oLeaveButton13.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked13 != value && _oLeaveButton13 != null)
			{
				_oLeaveButton13.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked14
	{
		get
		{
			if (_oLeaveButton14 != null)
			{
				return _oLeaveButton14.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked14 != value && _oLeaveButton14 != null)
			{
				_oLeaveButton14.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked15
	{
		get
		{
			if (_oLeaveButton15 != null)
			{
				return _oLeaveButton15.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked15 != value && _oLeaveButton15 != null)
			{
				_oLeaveButton15.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent LeaveClicked16
	{
		get
		{
			if (_oLeaveButton16 != null)
			{
				return _oLeaveButton16.onClick;
			}
			return null;
		}
		set
		{
			if (LeaveClicked16 != value && _oLeaveButton16 != null)
			{
				_oLeaveButton16.onClick = value;
			}
		}
	}

	public bool SelectedShow1
	{
		get
		{
			if (_oSelected1 != null)
			{
				return _oSelected1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow1 != value && _oSelected1 != null)
			{
				_oSelected1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow2
	{
		get
		{
			if (_oSelected2 != null)
			{
				return _oSelected2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow2 != value && _oSelected2 != null)
			{
				_oSelected2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow3
	{
		get
		{
			if (_oSelected3 != null)
			{
				return _oSelected3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow3 != value && _oSelected3 != null)
			{
				_oSelected3.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow4
	{
		get
		{
			if (_oSelected4 != null)
			{
				return _oSelected4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow4 != value && _oSelected4 != null)
			{
				_oSelected4.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow5
	{
		get
		{
			if (_oSelected5 != null)
			{
				return _oSelected5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow5 != value && _oSelected5 != null)
			{
				_oSelected5.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow6
	{
		get
		{
			if (_oSelected6 != null)
			{
				return _oSelected6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow6 != value && _oSelected6 != null)
			{
				_oSelected6.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow7
	{
		get
		{
			if (_oSelected7 != null)
			{
				return _oSelected7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow7 != value && _oSelected7 != null)
			{
				_oSelected7.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow8
	{
		get
		{
			if (_oSelected8 != null)
			{
				return _oSelected8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow8 != value && _oSelected8 != null)
			{
				_oSelected8.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow9
	{
		get
		{
			if (_oSelected9 != null)
			{
				return _oSelected9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow9 != value && _oSelected9 != null)
			{
				_oSelected9.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow10
	{
		get
		{
			if (_oSelected10 != null)
			{
				return _oSelected10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow10 != value && _oSelected10 != null)
			{
				_oSelected10.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow11
	{
		get
		{
			if (_oSelected11 != null)
			{
				return _oSelected11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow11 != value && _oSelected11 != null)
			{
				_oSelected11.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow12
	{
		get
		{
			if (_oSelected12 != null)
			{
				return _oSelected12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow12 != value && _oSelected12 != null)
			{
				_oSelected12.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow13
	{
		get
		{
			if (_oSelected13 != null)
			{
				return _oSelected13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow13 != value && _oSelected13 != null)
			{
				_oSelected13.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow14
	{
		get
		{
			if (_oSelected14 != null)
			{
				return _oSelected14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow14 != value && _oSelected14 != null)
			{
				_oSelected14.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow15
	{
		get
		{
			if (_oSelected15 != null)
			{
				return _oSelected15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow15 != value && _oSelected15 != null)
			{
				_oSelected15.SetObjectActive(value);
			}
		}
	}

	public bool SelectedShow16
	{
		get
		{
			if (_oSelected16 != null)
			{
				return _oSelected16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow16 != value && _oSelected16 != null)
			{
				_oSelected16.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ShowScreenClicked
	{
		get
		{
			if (_oShowScreenButton != null)
			{
				return _oShowScreenButton.onClick;
			}
			return null;
		}
		set
		{
			if (ShowScreenClicked != value && _oShowScreenButton != null)
			{
				_oShowScreenButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent CloseBtnClicked
	{
		get
		{
			if (_oCloseBtnButton != null)
			{
				return _oCloseBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (CloseBtnClicked != value && _oCloseBtnButton != null)
			{
				_oCloseBtnButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent AddClicked
	{
		get
		{
			if (_oAddButton != null)
			{
				return _oAddButton.onClick;
			}
			return null;
		}
		set
		{
			if (AddClicked != value && _oAddButton != null)
			{
				_oAddButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent MyselfClicked
	{
		get
		{
			if (_oMyselfButton != null)
			{
				return _oMyselfButton.onClick;
			}
			return null;
		}
		set
		{
			if (MyselfClicked != value && _oMyselfButton != null)
			{
				_oMyselfButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent AllSelectClicked
	{
		get
		{
			if (_oAllSelectButton != null)
			{
				return _oAllSelectButton.onClick;
			}
			return null;
		}
		set
		{
			if (AllSelectClicked != value && _oAllSelectButton != null)
			{
				_oAllSelectButton.onClick = value;
			}
		}
	}

	public Toggle.ToggleEvent SimpleCopyTogglechanged
	{
		get
		{
			if (_oSimpleCopyToggle != null)
			{
				return _oSimpleCopyToggle.onValueChanged;
			}
			return null;
		}
		set
		{
			if (SimpleCopyTogglechanged != value && _oSimpleCopyToggle != null)
			{
				_oSimpleCopyToggle.onValueChanged = value;
			}
		}
	}

	public bool SimpleCopyOn
	{
		get
		{
			if (_oSimpleCopyToggle != null)
			{
				return _oSimpleCopyToggle.isOn;
			}
			return false;
		}
		set
		{
			if (SimpleCopyOn != value && _oSimpleCopyToggle != null)
			{
				_oSimpleCopyToggle.isOn = value;
			}
		}
	}

	public Toggle.ToggleEvent SelfOperateTogglechanged
	{
		get
		{
			if (_oSelfOperateToggle != null)
			{
				return _oSelfOperateToggle.onValueChanged;
			}
			return null;
		}
		set
		{
			if (SelfOperateTogglechanged != value && _oSelfOperateToggle != null)
			{
				_oSelfOperateToggle.onValueChanged = value;
			}
		}
	}

	public bool PositionShow
	{
		get
		{
			if (_oPosition != null)
			{
				return _oPosition.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PositionShow != value && _oPosition != null)
			{
				_oPosition.SetObjectActive(value);
			}
		}
	}

	public bool PosShow1
	{
		get
		{
			if (_oPos1 != null)
			{
				return _oPos1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow1 != value && _oPos1 != null)
			{
				_oPos1.SetObjectActive(value);
			}
		}
	}

	public bool PosShow2
	{
		get
		{
			if (_oPos2 != null)
			{
				return _oPos2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow2 != value && _oPos2 != null)
			{
				_oPos2.SetObjectActive(value);
			}
		}
	}

	public bool PosShow3
	{
		get
		{
			if (_oPos3 != null)
			{
				return _oPos3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow3 != value && _oPos3 != null)
			{
				_oPos3.SetObjectActive(value);
			}
		}
	}

	public bool PosShow4
	{
		get
		{
			if (_oPos4 != null)
			{
				return _oPos4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow4 != value && _oPos4 != null)
			{
				_oPos4.SetObjectActive(value);
			}
		}
	}

	public bool PosShow5
	{
		get
		{
			if (_oPos5 != null)
			{
				return _oPos5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow5 != value && _oPos5 != null)
			{
				_oPos5.SetObjectActive(value);
			}
		}
	}

	public bool PosShow6
	{
		get
		{
			if (_oPos6 != null)
			{
				return _oPos6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow6 != value && _oPos6 != null)
			{
				_oPos6.SetObjectActive(value);
			}
		}
	}

	public bool PosShow7
	{
		get
		{
			if (_oPos7 != null)
			{
				return _oPos7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow7 != value && _oPos7 != null)
			{
				_oPos7.SetObjectActive(value);
			}
		}
	}

	public bool PosShow8
	{
		get
		{
			if (_oPos8 != null)
			{
				return _oPos8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow8 != value && _oPos8 != null)
			{
				_oPos8.SetObjectActive(value);
			}
		}
	}

	public bool PosShow9
	{
		get
		{
			if (_oPos9 != null)
			{
				return _oPos9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow9 != value && _oPos9 != null)
			{
				_oPos9.SetObjectActive(value);
			}
		}
	}

	public bool PosShow10
	{
		get
		{
			if (_oPos10 != null)
			{
				return _oPos10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow10 != value && _oPos10 != null)
			{
				_oPos10.SetObjectActive(value);
			}
		}
	}

	public bool PosShow11
	{
		get
		{
			if (_oPos11 != null)
			{
				return _oPos11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow11 != value && _oPos11 != null)
			{
				_oPos11.SetObjectActive(value);
			}
		}
	}

	public bool PosShow12
	{
		get
		{
			if (_oPos12 != null)
			{
				return _oPos12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow12 != value && _oPos12 != null)
			{
				_oPos12.SetObjectActive(value);
			}
		}
	}

	public bool PosShow13
	{
		get
		{
			if (_oPos13 != null)
			{
				return _oPos13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow13 != value && _oPos13 != null)
			{
				_oPos13.SetObjectActive(value);
			}
		}
	}

	public bool PosShow14
	{
		get
		{
			if (_oPos14 != null)
			{
				return _oPos14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow14 != value && _oPos14 != null)
			{
				_oPos14.SetObjectActive(value);
			}
		}
	}

	public bool PosShow15
	{
		get
		{
			if (_oPos15 != null)
			{
				return _oPos15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow15 != value && _oPos15 != null)
			{
				_oPos15.SetObjectActive(value);
			}
		}
	}

	public bool PosShow16
	{
		get
		{
			if (_oPos16 != null)
			{
				return _oPos16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PosShow16 != value && _oPos16 != null)
			{
				_oPos16.SetObjectActive(value);
			}
		}
	}

	public Vector3 PosPosition1
	{
		get
		{
			if (_oPosRectTransform1 != null)
			{
				return _oPosRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition1 != value && _oPosRectTransform1 != null)
			{
				_oPosRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition2
	{
		get
		{
			if (_oPosRectTransform2 != null)
			{
				return _oPosRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition2 != value && _oPosRectTransform2 != null)
			{
				_oPosRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition3
	{
		get
		{
			if (_oPosRectTransform3 != null)
			{
				return _oPosRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition3 != value && _oPosRectTransform3 != null)
			{
				_oPosRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition4
	{
		get
		{
			if (_oPosRectTransform4 != null)
			{
				return _oPosRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition4 != value && _oPosRectTransform4 != null)
			{
				_oPosRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition5
	{
		get
		{
			if (_oPosRectTransform5 != null)
			{
				return _oPosRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition5 != value && _oPosRectTransform5 != null)
			{
				_oPosRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition6
	{
		get
		{
			if (_oPosRectTransform6 != null)
			{
				return _oPosRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition6 != value && _oPosRectTransform6 != null)
			{
				_oPosRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition7
	{
		get
		{
			if (_oPosRectTransform7 != null)
			{
				return _oPosRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition7 != value && _oPosRectTransform7 != null)
			{
				_oPosRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition8
	{
		get
		{
			if (_oPosRectTransform8 != null)
			{
				return _oPosRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition8 != value && _oPosRectTransform8 != null)
			{
				_oPosRectTransform8.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition9
	{
		get
		{
			if (_oPosRectTransform9 != null)
			{
				return _oPosRectTransform9.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition9 != value && _oPosRectTransform9 != null)
			{
				_oPosRectTransform9.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition10
	{
		get
		{
			if (_oPosRectTransform10 != null)
			{
				return _oPosRectTransform10.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition10 != value && _oPosRectTransform10 != null)
			{
				_oPosRectTransform10.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition11
	{
		get
		{
			if (_oPosRectTransform11 != null)
			{
				return _oPosRectTransform11.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition11 != value && _oPosRectTransform11 != null)
			{
				_oPosRectTransform11.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition12
	{
		get
		{
			if (_oPosRectTransform12 != null)
			{
				return _oPosRectTransform12.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition12 != value && _oPosRectTransform12 != null)
			{
				_oPosRectTransform12.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition13
	{
		get
		{
			if (_oPosRectTransform13 != null)
			{
				return _oPosRectTransform13.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition13 != value && _oPosRectTransform13 != null)
			{
				_oPosRectTransform13.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition14
	{
		get
		{
			if (_oPosRectTransform14 != null)
			{
				return _oPosRectTransform14.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition14 != value && _oPosRectTransform14 != null)
			{
				_oPosRectTransform14.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition15
	{
		get
		{
			if (_oPosRectTransform15 != null)
			{
				return _oPosRectTransform15.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition15 != value && _oPosRectTransform15 != null)
			{
				_oPosRectTransform15.localPosition = value;
			}
		}
	}

	public Vector3 PosPosition16
	{
		get
		{
			if (_oPosRectTransform16 != null)
			{
				return _oPosRectTransform16.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosPosition16 != value && _oPosRectTransform16 != null)
			{
				_oPosRectTransform16.localPosition = value;
			}
		}
	}

	public Vector3 PosSize1
	{
		get
		{
			if (_oPosRectTransform1 != null)
			{
				return _oPosRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize1 != value && _oPosRectTransform1 != null)
			{
				_oPosRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize2
	{
		get
		{
			if (_oPosRectTransform2 != null)
			{
				return _oPosRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize2 != value && _oPosRectTransform2 != null)
			{
				_oPosRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize3
	{
		get
		{
			if (_oPosRectTransform3 != null)
			{
				return _oPosRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize3 != value && _oPosRectTransform3 != null)
			{
				_oPosRectTransform3.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize4
	{
		get
		{
			if (_oPosRectTransform4 != null)
			{
				return _oPosRectTransform4.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize4 != value && _oPosRectTransform4 != null)
			{
				_oPosRectTransform4.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize5
	{
		get
		{
			if (_oPosRectTransform5 != null)
			{
				return _oPosRectTransform5.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize5 != value && _oPosRectTransform5 != null)
			{
				_oPosRectTransform5.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize6
	{
		get
		{
			if (_oPosRectTransform6 != null)
			{
				return _oPosRectTransform6.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize6 != value && _oPosRectTransform6 != null)
			{
				_oPosRectTransform6.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize7
	{
		get
		{
			if (_oPosRectTransform7 != null)
			{
				return _oPosRectTransform7.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize7 != value && _oPosRectTransform7 != null)
			{
				_oPosRectTransform7.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize8
	{
		get
		{
			if (_oPosRectTransform8 != null)
			{
				return _oPosRectTransform8.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize8 != value && _oPosRectTransform8 != null)
			{
				_oPosRectTransform8.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize9
	{
		get
		{
			if (_oPosRectTransform9 != null)
			{
				return _oPosRectTransform9.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize9 != value && _oPosRectTransform9 != null)
			{
				_oPosRectTransform9.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize10
	{
		get
		{
			if (_oPosRectTransform10 != null)
			{
				return _oPosRectTransform10.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize10 != value && _oPosRectTransform10 != null)
			{
				_oPosRectTransform10.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize11
	{
		get
		{
			if (_oPosRectTransform11 != null)
			{
				return _oPosRectTransform11.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize11 != value && _oPosRectTransform11 != null)
			{
				_oPosRectTransform11.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize12
	{
		get
		{
			if (_oPosRectTransform12 != null)
			{
				return _oPosRectTransform12.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize12 != value && _oPosRectTransform12 != null)
			{
				_oPosRectTransform12.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize13
	{
		get
		{
			if (_oPosRectTransform13 != null)
			{
				return _oPosRectTransform13.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize13 != value && _oPosRectTransform13 != null)
			{
				_oPosRectTransform13.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize14
	{
		get
		{
			if (_oPosRectTransform14 != null)
			{
				return _oPosRectTransform14.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize14 != value && _oPosRectTransform14 != null)
			{
				_oPosRectTransform14.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize15
	{
		get
		{
			if (_oPosRectTransform15 != null)
			{
				return _oPosRectTransform15.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize15 != value && _oPosRectTransform15 != null)
			{
				_oPosRectTransform15.sizeDelta = value;
			}
		}
	}

	public Vector3 PosSize16
	{
		get
		{
			if (_oPosRectTransform16 != null)
			{
				return _oPosRectTransform16.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (PosSize16 != value && _oPosRectTransform16 != null)
			{
				_oPosRectTransform16.sizeDelta = value;
			}
		}
	}

	public string PosString1
	{
		get
		{
			if (_oPosText1 != null)
			{
				return _oPosText1.text;
			}
			return null;
		}
		set
		{
			if (PosString1 != value && _oPosText1 != null)
			{
				_oPosText1.text = value;
			}
		}
	}

	public string PosString2
	{
		get
		{
			if (_oPosText2 != null)
			{
				return _oPosText2.text;
			}
			return null;
		}
		set
		{
			if (PosString2 != value && _oPosText2 != null)
			{
				_oPosText2.text = value;
			}
		}
	}

	public string PosString3
	{
		get
		{
			if (_oPosText3 != null)
			{
				return _oPosText3.text;
			}
			return null;
		}
		set
		{
			if (PosString3 != value && _oPosText3 != null)
			{
				_oPosText3.text = value;
			}
		}
	}

	public string PosString4
	{
		get
		{
			if (_oPosText4 != null)
			{
				return _oPosText4.text;
			}
			return null;
		}
		set
		{
			if (PosString4 != value && _oPosText4 != null)
			{
				_oPosText4.text = value;
			}
		}
	}

	public string PosString5
	{
		get
		{
			if (_oPosText5 != null)
			{
				return _oPosText5.text;
			}
			return null;
		}
		set
		{
			if (PosString5 != value && _oPosText5 != null)
			{
				_oPosText5.text = value;
			}
		}
	}

	public string PosString6
	{
		get
		{
			if (_oPosText6 != null)
			{
				return _oPosText6.text;
			}
			return null;
		}
		set
		{
			if (PosString6 != value && _oPosText6 != null)
			{
				_oPosText6.text = value;
			}
		}
	}

	public string PosString7
	{
		get
		{
			if (_oPosText7 != null)
			{
				return _oPosText7.text;
			}
			return null;
		}
		set
		{
			if (PosString7 != value && _oPosText7 != null)
			{
				_oPosText7.text = value;
			}
		}
	}

	public string PosString8
	{
		get
		{
			if (_oPosText8 != null)
			{
				return _oPosText8.text;
			}
			return null;
		}
		set
		{
			if (PosString8 != value && _oPosText8 != null)
			{
				_oPosText8.text = value;
			}
		}
	}

	public string PosString9
	{
		get
		{
			if (_oPosText9 != null)
			{
				return _oPosText9.text;
			}
			return null;
		}
		set
		{
			if (PosString9 != value && _oPosText9 != null)
			{
				_oPosText9.text = value;
			}
		}
	}

	public string PosString10
	{
		get
		{
			if (_oPosText10 != null)
			{
				return _oPosText10.text;
			}
			return null;
		}
		set
		{
			if (PosString10 != value && _oPosText10 != null)
			{
				_oPosText10.text = value;
			}
		}
	}

	public string PosString11
	{
		get
		{
			if (_oPosText11 != null)
			{
				return _oPosText11.text;
			}
			return null;
		}
		set
		{
			if (PosString11 != value && _oPosText11 != null)
			{
				_oPosText11.text = value;
			}
		}
	}

	public string PosString12
	{
		get
		{
			if (_oPosText12 != null)
			{
				return _oPosText12.text;
			}
			return null;
		}
		set
		{
			if (PosString12 != value && _oPosText12 != null)
			{
				_oPosText12.text = value;
			}
		}
	}

	public string PosString13
	{
		get
		{
			if (_oPosText13 != null)
			{
				return _oPosText13.text;
			}
			return null;
		}
		set
		{
			if (PosString13 != value && _oPosText13 != null)
			{
				_oPosText13.text = value;
			}
		}
	}

	public string PosString14
	{
		get
		{
			if (_oPosText14 != null)
			{
				return _oPosText14.text;
			}
			return null;
		}
		set
		{
			if (PosString14 != value && _oPosText14 != null)
			{
				_oPosText14.text = value;
			}
		}
	}

	public string PosString15
	{
		get
		{
			if (_oPosText15 != null)
			{
				return _oPosText15.text;
			}
			return null;
		}
		set
		{
			if (PosString15 != value && _oPosText15 != null)
			{
				_oPosText15.text = value;
			}
		}
	}

	public string PosString16
	{
		get
		{
			if (_oPosText16 != null)
			{
				return _oPosText16.text;
			}
			return null;
		}
		set
		{
			if (PosString16 != value && _oPosText16 != null)
			{
				_oPosText16.text = value;
			}
		}
	}

	public Color PosTextcolor1
	{
		get
		{
			if (_oPosText1 != null)
			{
				return _oPosText1.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor1 != value && _oPosText1 != null)
			{
				_oPosText1.color = value;
			}
		}
	}

	public Color PosTextcolor2
	{
		get
		{
			if (_oPosText2 != null)
			{
				return _oPosText2.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor2 != value && _oPosText2 != null)
			{
				_oPosText2.color = value;
			}
		}
	}

	public Color PosTextcolor3
	{
		get
		{
			if (_oPosText3 != null)
			{
				return _oPosText3.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor3 != value && _oPosText3 != null)
			{
				_oPosText3.color = value;
			}
		}
	}

	public Color PosTextcolor4
	{
		get
		{
			if (_oPosText4 != null)
			{
				return _oPosText4.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor4 != value && _oPosText4 != null)
			{
				_oPosText4.color = value;
			}
		}
	}

	public Color PosTextcolor5
	{
		get
		{
			if (_oPosText5 != null)
			{
				return _oPosText5.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor5 != value && _oPosText5 != null)
			{
				_oPosText5.color = value;
			}
		}
	}

	public Color PosTextcolor6
	{
		get
		{
			if (_oPosText6 != null)
			{
				return _oPosText6.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor6 != value && _oPosText6 != null)
			{
				_oPosText6.color = value;
			}
		}
	}

	public Color PosTextcolor7
	{
		get
		{
			if (_oPosText7 != null)
			{
				return _oPosText7.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor7 != value && _oPosText7 != null)
			{
				_oPosText7.color = value;
			}
		}
	}

	public Color PosTextcolor8
	{
		get
		{
			if (_oPosText8 != null)
			{
				return _oPosText8.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor8 != value && _oPosText8 != null)
			{
				_oPosText8.color = value;
			}
		}
	}

	public Color PosTextcolor9
	{
		get
		{
			if (_oPosText9 != null)
			{
				return _oPosText9.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor9 != value && _oPosText9 != null)
			{
				_oPosText9.color = value;
			}
		}
	}

	public Color PosTextcolor10
	{
		get
		{
			if (_oPosText10 != null)
			{
				return _oPosText10.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor10 != value && _oPosText10 != null)
			{
				_oPosText10.color = value;
			}
		}
	}

	public Color PosTextcolor11
	{
		get
		{
			if (_oPosText11 != null)
			{
				return _oPosText11.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor11 != value && _oPosText11 != null)
			{
				_oPosText11.color = value;
			}
		}
	}

	public Color PosTextcolor12
	{
		get
		{
			if (_oPosText12 != null)
			{
				return _oPosText12.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor12 != value && _oPosText12 != null)
			{
				_oPosText12.color = value;
			}
		}
	}

	public Color PosTextcolor13
	{
		get
		{
			if (_oPosText13 != null)
			{
				return _oPosText13.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor13 != value && _oPosText13 != null)
			{
				_oPosText13.color = value;
			}
		}
	}

	public Color PosTextcolor14
	{
		get
		{
			if (_oPosText14 != null)
			{
				return _oPosText14.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor14 != value && _oPosText14 != null)
			{
				_oPosText14.color = value;
			}
		}
	}

	public Color PosTextcolor15
	{
		get
		{
			if (_oPosText15 != null)
			{
				return _oPosText15.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor15 != value && _oPosText15 != null)
			{
				_oPosText15.color = value;
			}
		}
	}

	public Color PosTextcolor16
	{
		get
		{
			if (_oPosText16 != null)
			{
				return _oPosText16.color;
			}
			return Color.white;
		}
		set
		{
			if (PosTextcolor16 != value && _oPosText16 != null)
			{
				_oPosText16.color = value;
			}
		}
	}

	public bool FlagShow1
	{
		get
		{
			if (_oFlag1 != null)
			{
				return _oFlag1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow1 != value && _oFlag1 != null)
			{
				_oFlag1.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow2
	{
		get
		{
			if (_oFlag2 != null)
			{
				return _oFlag2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow2 != value && _oFlag2 != null)
			{
				_oFlag2.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow3
	{
		get
		{
			if (_oFlag3 != null)
			{
				return _oFlag3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow3 != value && _oFlag3 != null)
			{
				_oFlag3.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow4
	{
		get
		{
			if (_oFlag4 != null)
			{
				return _oFlag4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow4 != value && _oFlag4 != null)
			{
				_oFlag4.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow5
	{
		get
		{
			if (_oFlag5 != null)
			{
				return _oFlag5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow5 != value && _oFlag5 != null)
			{
				_oFlag5.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow6
	{
		get
		{
			if (_oFlag6 != null)
			{
				return _oFlag6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow6 != value && _oFlag6 != null)
			{
				_oFlag6.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow7
	{
		get
		{
			if (_oFlag7 != null)
			{
				return _oFlag7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow7 != value && _oFlag7 != null)
			{
				_oFlag7.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow8
	{
		get
		{
			if (_oFlag8 != null)
			{
				return _oFlag8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow8 != value && _oFlag8 != null)
			{
				_oFlag8.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow9
	{
		get
		{
			if (_oFlag9 != null)
			{
				return _oFlag9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow9 != value && _oFlag9 != null)
			{
				_oFlag9.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow10
	{
		get
		{
			if (_oFlag10 != null)
			{
				return _oFlag10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow10 != value && _oFlag10 != null)
			{
				_oFlag10.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow11
	{
		get
		{
			if (_oFlag11 != null)
			{
				return _oFlag11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow11 != value && _oFlag11 != null)
			{
				_oFlag11.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow12
	{
		get
		{
			if (_oFlag12 != null)
			{
				return _oFlag12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow12 != value && _oFlag12 != null)
			{
				_oFlag12.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow13
	{
		get
		{
			if (_oFlag13 != null)
			{
				return _oFlag13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow13 != value && _oFlag13 != null)
			{
				_oFlag13.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow14
	{
		get
		{
			if (_oFlag14 != null)
			{
				return _oFlag14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow14 != value && _oFlag14 != null)
			{
				_oFlag14.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow15
	{
		get
		{
			if (_oFlag15 != null)
			{
				return _oFlag15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow15 != value && _oFlag15 != null)
			{
				_oFlag15.SetObjectActive(value);
			}
		}
	}

	public bool FlagShow16
	{
		get
		{
			if (_oFlag16 != null)
			{
				return _oFlag16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlagShow16 != value && _oFlag16 != null)
			{
				_oFlag16.SetObjectActive(value);
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
			case "Screen":
				_oScreen = transform.gameObject;
				break;
			case "HideScreen":
				_oHideScreen = transform.gameObject;
				_oHideScreenButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Text1":
				_oText1 = transform.gameObject;
				_oTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text2":
				_oText2 = transform.gameObject;
				_oTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text3":
				_oText3 = transform.gameObject;
				_oTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text4":
				_oText4 = transform.gameObject;
				_oTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text5":
				_oText5 = transform.gameObject;
				_oTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text6":
				_oText6 = transform.gameObject;
				_oTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text7":
				_oText7 = transform.gameObject;
				_oTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text8":
				_oText8 = transform.gameObject;
				_oTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text9":
				_oText9 = transform.gameObject;
				_oTextText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text10":
				_oText10 = transform.gameObject;
				_oTextText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text11":
				_oText11 = transform.gameObject;
				_oTextText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text12":
				_oText12 = transform.gameObject;
				_oTextText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text13":
				_oText13 = transform.gameObject;
				_oTextText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text14":
				_oText14 = transform.gameObject;
				_oTextText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text15":
				_oText15 = transform.gameObject;
				_oTextText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "Text16":
				_oText16 = transform.gameObject;
				_oTextText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "UI":
				_oUI = transform.gameObject;
				break;
			case "Player1":
				_oPlayer1 = transform.gameObject;
				_oPlayerButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player2":
				_oPlayer2 = transform.gameObject;
				_oPlayerButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player3":
				_oPlayer3 = transform.gameObject;
				_oPlayerButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player4":
				_oPlayer4 = transform.gameObject;
				_oPlayerButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player5":
				_oPlayer5 = transform.gameObject;
				_oPlayerButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player6":
				_oPlayer6 = transform.gameObject;
				_oPlayerButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player7":
				_oPlayer7 = transform.gameObject;
				_oPlayerButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player8":
				_oPlayer8 = transform.gameObject;
				_oPlayerButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player9":
				_oPlayer9 = transform.gameObject;
				_oPlayerButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player10":
				_oPlayer10 = transform.gameObject;
				_oPlayerButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player11":
				_oPlayer11 = transform.gameObject;
				_oPlayerButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player12":
				_oPlayer12 = transform.gameObject;
				_oPlayerButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player13":
				_oPlayer13 = transform.gameObject;
				_oPlayerButton13 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player14":
				_oPlayer14 = transform.gameObject;
				_oPlayerButton14 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player15":
				_oPlayer15 = transform.gameObject;
				_oPlayerButton15 = transform.gameObject.GetComponent<Button>();
				break;
			case "Player16":
				_oPlayer16 = transform.gameObject;
				_oPlayerButton16 = transform.gameObject.GetComponent<Button>();
				break;
			case "NameText1":
				_oNameText1 = transform.gameObject;
				_oNameTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText2":
				_oNameText2 = transform.gameObject;
				_oNameTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText3":
				_oNameText3 = transform.gameObject;
				_oNameTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText4":
				_oNameText4 = transform.gameObject;
				_oNameTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText5":
				_oNameText5 = transform.gameObject;
				_oNameTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText6":
				_oNameText6 = transform.gameObject;
				_oNameTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText7":
				_oNameText7 = transform.gameObject;
				_oNameTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText8":
				_oNameText8 = transform.gameObject;
				_oNameTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText9":
				_oNameText9 = transform.gameObject;
				_oNameTextText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText10":
				_oNameText10 = transform.gameObject;
				_oNameTextText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText11":
				_oNameText11 = transform.gameObject;
				_oNameTextText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText12":
				_oNameText12 = transform.gameObject;
				_oNameTextText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText13":
				_oNameText13 = transform.gameObject;
				_oNameTextText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText14":
				_oNameText14 = transform.gameObject;
				_oNameTextText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText15":
				_oNameText15 = transform.gameObject;
				_oNameTextText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "NameText16":
				_oNameText16 = transform.gameObject;
				_oNameTextText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "Leave1":
				_oLeave1 = transform.gameObject;
				_oLeaveButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave2":
				_oLeave2 = transform.gameObject;
				_oLeaveButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave3":
				_oLeave3 = transform.gameObject;
				_oLeaveButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave4":
				_oLeave4 = transform.gameObject;
				_oLeaveButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave5":
				_oLeave5 = transform.gameObject;
				_oLeaveButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave6":
				_oLeave6 = transform.gameObject;
				_oLeaveButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave7":
				_oLeave7 = transform.gameObject;
				_oLeaveButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave8":
				_oLeave8 = transform.gameObject;
				_oLeaveButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave9":
				_oLeave9 = transform.gameObject;
				_oLeaveButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave10":
				_oLeave10 = transform.gameObject;
				_oLeaveButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave11":
				_oLeave11 = transform.gameObject;
				_oLeaveButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave12":
				_oLeave12 = transform.gameObject;
				_oLeaveButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave13":
				_oLeave13 = transform.gameObject;
				_oLeaveButton13 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave14":
				_oLeave14 = transform.gameObject;
				_oLeaveButton14 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave15":
				_oLeave15 = transform.gameObject;
				_oLeaveButton15 = transform.gameObject.GetComponent<Button>();
				break;
			case "Leave16":
				_oLeave16 = transform.gameObject;
				_oLeaveButton16 = transform.gameObject.GetComponent<Button>();
				break;
			case "Selected1":
				_oSelected1 = transform.gameObject;
				break;
			case "Selected2":
				_oSelected2 = transform.gameObject;
				break;
			case "Selected3":
				_oSelected3 = transform.gameObject;
				break;
			case "Selected4":
				_oSelected4 = transform.gameObject;
				break;
			case "Selected5":
				_oSelected5 = transform.gameObject;
				break;
			case "Selected6":
				_oSelected6 = transform.gameObject;
				break;
			case "Selected7":
				_oSelected7 = transform.gameObject;
				break;
			case "Selected8":
				_oSelected8 = transform.gameObject;
				break;
			case "Selected9":
				_oSelected9 = transform.gameObject;
				break;
			case "Selected10":
				_oSelected10 = transform.gameObject;
				break;
			case "Selected11":
				_oSelected11 = transform.gameObject;
				break;
			case "Selected12":
				_oSelected12 = transform.gameObject;
				break;
			case "Selected13":
				_oSelected13 = transform.gameObject;
				break;
			case "Selected14":
				_oSelected14 = transform.gameObject;
				break;
			case "Selected15":
				_oSelected15 = transform.gameObject;
				break;
			case "Selected16":
				_oSelected16 = transform.gameObject;
				break;
			case "ShowScreen":
				_oShowScreen = transform.gameObject;
				_oShowScreenButton = transform.gameObject.GetComponent<Button>();
				break;
			case "CloseBtn":
				_oCloseBtn = transform.gameObject;
				_oCloseBtnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Add":
				_oAdd = transform.gameObject;
				_oAddButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Myself":
				_oMyself = transform.gameObject;
				_oMyselfButton = transform.gameObject.GetComponent<Button>();
				break;
			case "AllSelect":
				_oAllSelect = transform.gameObject;
				_oAllSelectButton = transform.gameObject.GetComponent<Button>();
				break;
			case "SimpleCopy":
				_oSimpleCopy = transform.gameObject;
				_oSimpleCopyToggle = transform.gameObject.GetComponent<Toggle>();
				break;
			case "SelfOperate":
				_oSelfOperate = transform.gameObject;
				_oSelfOperateToggle = transform.gameObject.GetComponent<Toggle>();
				break;
			case "Position":
				_oPosition = transform.gameObject;
				break;
			case "Pos1":
				_oPos1 = transform.gameObject;
				_oPosRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos2":
				_oPos2 = transform.gameObject;
				_oPosRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos3":
				_oPos3 = transform.gameObject;
				_oPosRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos4":
				_oPos4 = transform.gameObject;
				_oPosRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos5":
				_oPos5 = transform.gameObject;
				_oPosRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos6":
				_oPos6 = transform.gameObject;
				_oPosRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos7":
				_oPos7 = transform.gameObject;
				_oPosRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos8":
				_oPos8 = transform.gameObject;
				_oPosRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos9":
				_oPos9 = transform.gameObject;
				_oPosRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos10":
				_oPos10 = transform.gameObject;
				_oPosRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos11":
				_oPos11 = transform.gameObject;
				_oPosRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos12":
				_oPos12 = transform.gameObject;
				_oPosRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos13":
				_oPos13 = transform.gameObject;
				_oPosRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos14":
				_oPos14 = transform.gameObject;
				_oPosRectTransform14 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos15":
				_oPos15 = transform.gameObject;
				_oPosRectTransform15 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "Pos16":
				_oPos16 = transform.gameObject;
				_oPosRectTransform16 = transform.gameObject.GetComponent<RectTransform>();
				_oPosText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "Flag1":
				_oFlag1 = transform.gameObject;
				break;
			case "Flag2":
				_oFlag2 = transform.gameObject;
				break;
			case "Flag3":
				_oFlag3 = transform.gameObject;
				break;
			case "Flag4":
				_oFlag4 = transform.gameObject;
				break;
			case "Flag5":
				_oFlag5 = transform.gameObject;
				break;
			case "Flag6":
				_oFlag6 = transform.gameObject;
				break;
			case "Flag7":
				_oFlag7 = transform.gameObject;
				break;
			case "Flag8":
				_oFlag8 = transform.gameObject;
				break;
			case "Flag9":
				_oFlag9 = transform.gameObject;
				break;
			case "Flag10":
				_oFlag10 = transform.gameObject;
				break;
			case "Flag11":
				_oFlag11 = transform.gameObject;
				break;
			case "Flag12":
				_oFlag12 = transform.gameObject;
				break;
			case "Flag13":
				_oFlag13 = transform.gameObject;
				break;
			case "Flag14":
				_oFlag14 = transform.gameObject;
				break;
			case "Flag15":
				_oFlag15 = transform.gameObject;
				break;
			case "Flag16":
				_oFlag16 = transform.gameObject;
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

	public string GetTextString(int index)
	{
		return index switch
		{
			1 => TextString1, 
			2 => TextString2, 
			3 => TextString3, 
			4 => TextString4, 
			5 => TextString5, 
			6 => TextString6, 
			7 => TextString7, 
			8 => TextString8, 
			9 => TextString9, 
			10 => TextString10, 
			11 => TextString11, 
			12 => TextString12, 
			13 => TextString13, 
			14 => TextString14, 
			15 => TextString15, 
			16 => TextString16, 
			_ => null, 
		};
	}

	public void SetTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TextString1 = value;
			break;
		case 2:
			TextString2 = value;
			break;
		case 3:
			TextString3 = value;
			break;
		case 4:
			TextString4 = value;
			break;
		case 5:
			TextString5 = value;
			break;
		case 6:
			TextString6 = value;
			break;
		case 7:
			TextString7 = value;
			break;
		case 8:
			TextString8 = value;
			break;
		case 9:
			TextString9 = value;
			break;
		case 10:
			TextString10 = value;
			break;
		case 11:
			TextString11 = value;
			break;
		case 12:
			TextString12 = value;
			break;
		case 13:
			TextString13 = value;
			break;
		case 14:
			TextString14 = value;
			break;
		case 15:
			TextString15 = value;
			break;
		case 16:
			TextString16 = value;
			break;
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
			11 => PlayerShow11, 
			12 => PlayerShow12, 
			13 => PlayerShow13, 
			14 => PlayerShow14, 
			15 => PlayerShow15, 
			16 => PlayerShow16, 
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
		case 11:
			PlayerShow11 = value;
			break;
		case 12:
			PlayerShow12 = value;
			break;
		case 13:
			PlayerShow13 = value;
			break;
		case 14:
			PlayerShow14 = value;
			break;
		case 15:
			PlayerShow15 = value;
			break;
		case 16:
			PlayerShow16 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetPlayerClicked(int index)
	{
		return index switch
		{
			1 => PlayerClicked1, 
			2 => PlayerClicked2, 
			3 => PlayerClicked3, 
			4 => PlayerClicked4, 
			5 => PlayerClicked5, 
			6 => PlayerClicked6, 
			7 => PlayerClicked7, 
			8 => PlayerClicked8, 
			9 => PlayerClicked9, 
			10 => PlayerClicked10, 
			11 => PlayerClicked11, 
			12 => PlayerClicked12, 
			13 => PlayerClicked13, 
			14 => PlayerClicked14, 
			15 => PlayerClicked15, 
			16 => PlayerClicked16, 
			_ => null, 
		};
	}

	public void SetPlayerClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			PlayerClicked1 = value;
			break;
		case 2:
			PlayerClicked2 = value;
			break;
		case 3:
			PlayerClicked3 = value;
			break;
		case 4:
			PlayerClicked4 = value;
			break;
		case 5:
			PlayerClicked5 = value;
			break;
		case 6:
			PlayerClicked6 = value;
			break;
		case 7:
			PlayerClicked7 = value;
			break;
		case 8:
			PlayerClicked8 = value;
			break;
		case 9:
			PlayerClicked9 = value;
			break;
		case 10:
			PlayerClicked10 = value;
			break;
		case 11:
			PlayerClicked11 = value;
			break;
		case 12:
			PlayerClicked12 = value;
			break;
		case 13:
			PlayerClicked13 = value;
			break;
		case 14:
			PlayerClicked14 = value;
			break;
		case 15:
			PlayerClicked15 = value;
			break;
		case 16:
			PlayerClicked16 = value;
			break;
		}
	}

	public string GetNameTextString(int index)
	{
		return index switch
		{
			1 => NameTextString1, 
			2 => NameTextString2, 
			3 => NameTextString3, 
			4 => NameTextString4, 
			5 => NameTextString5, 
			6 => NameTextString6, 
			7 => NameTextString7, 
			8 => NameTextString8, 
			9 => NameTextString9, 
			10 => NameTextString10, 
			11 => NameTextString11, 
			12 => NameTextString12, 
			13 => NameTextString13, 
			14 => NameTextString14, 
			15 => NameTextString15, 
			16 => NameTextString16, 
			_ => null, 
		};
	}

	public void SetNameTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NameTextString1 = value;
			break;
		case 2:
			NameTextString2 = value;
			break;
		case 3:
			NameTextString3 = value;
			break;
		case 4:
			NameTextString4 = value;
			break;
		case 5:
			NameTextString5 = value;
			break;
		case 6:
			NameTextString6 = value;
			break;
		case 7:
			NameTextString7 = value;
			break;
		case 8:
			NameTextString8 = value;
			break;
		case 9:
			NameTextString9 = value;
			break;
		case 10:
			NameTextString10 = value;
			break;
		case 11:
			NameTextString11 = value;
			break;
		case 12:
			NameTextString12 = value;
			break;
		case 13:
			NameTextString13 = value;
			break;
		case 14:
			NameTextString14 = value;
			break;
		case 15:
			NameTextString15 = value;
			break;
		case 16:
			NameTextString16 = value;
			break;
		}
	}

	public Color GetNameTextTextcolor(int index)
	{
		return index switch
		{
			1 => NameTextTextcolor1, 
			2 => NameTextTextcolor2, 
			3 => NameTextTextcolor3, 
			4 => NameTextTextcolor4, 
			5 => NameTextTextcolor5, 
			6 => NameTextTextcolor6, 
			7 => NameTextTextcolor7, 
			8 => NameTextTextcolor8, 
			9 => NameTextTextcolor9, 
			10 => NameTextTextcolor10, 
			11 => NameTextTextcolor11, 
			12 => NameTextTextcolor12, 
			13 => NameTextTextcolor13, 
			14 => NameTextTextcolor14, 
			15 => NameTextTextcolor15, 
			16 => NameTextTextcolor16, 
			_ => Color.white, 
		};
	}

	public void SetNameTextTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			NameTextTextcolor1 = value;
			break;
		case 2:
			NameTextTextcolor2 = value;
			break;
		case 3:
			NameTextTextcolor3 = value;
			break;
		case 4:
			NameTextTextcolor4 = value;
			break;
		case 5:
			NameTextTextcolor5 = value;
			break;
		case 6:
			NameTextTextcolor6 = value;
			break;
		case 7:
			NameTextTextcolor7 = value;
			break;
		case 8:
			NameTextTextcolor8 = value;
			break;
		case 9:
			NameTextTextcolor9 = value;
			break;
		case 10:
			NameTextTextcolor10 = value;
			break;
		case 11:
			NameTextTextcolor11 = value;
			break;
		case 12:
			NameTextTextcolor12 = value;
			break;
		case 13:
			NameTextTextcolor13 = value;
			break;
		case 14:
			NameTextTextcolor14 = value;
			break;
		case 15:
			NameTextTextcolor15 = value;
			break;
		case 16:
			NameTextTextcolor16 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetLeaveClicked(int index)
	{
		return index switch
		{
			1 => LeaveClicked1, 
			2 => LeaveClicked2, 
			3 => LeaveClicked3, 
			4 => LeaveClicked4, 
			5 => LeaveClicked5, 
			6 => LeaveClicked6, 
			7 => LeaveClicked7, 
			8 => LeaveClicked8, 
			9 => LeaveClicked9, 
			10 => LeaveClicked10, 
			11 => LeaveClicked11, 
			12 => LeaveClicked12, 
			13 => LeaveClicked13, 
			14 => LeaveClicked14, 
			15 => LeaveClicked15, 
			16 => LeaveClicked16, 
			_ => null, 
		};
	}

	public void SetLeaveClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			LeaveClicked1 = value;
			break;
		case 2:
			LeaveClicked2 = value;
			break;
		case 3:
			LeaveClicked3 = value;
			break;
		case 4:
			LeaveClicked4 = value;
			break;
		case 5:
			LeaveClicked5 = value;
			break;
		case 6:
			LeaveClicked6 = value;
			break;
		case 7:
			LeaveClicked7 = value;
			break;
		case 8:
			LeaveClicked8 = value;
			break;
		case 9:
			LeaveClicked9 = value;
			break;
		case 10:
			LeaveClicked10 = value;
			break;
		case 11:
			LeaveClicked11 = value;
			break;
		case 12:
			LeaveClicked12 = value;
			break;
		case 13:
			LeaveClicked13 = value;
			break;
		case 14:
			LeaveClicked14 = value;
			break;
		case 15:
			LeaveClicked15 = value;
			break;
		case 16:
			LeaveClicked16 = value;
			break;
		}
	}

	public bool GetSelectedShow(int index)
	{
		return index switch
		{
			1 => SelectedShow1, 
			2 => SelectedShow2, 
			3 => SelectedShow3, 
			4 => SelectedShow4, 
			5 => SelectedShow5, 
			6 => SelectedShow6, 
			7 => SelectedShow7, 
			8 => SelectedShow8, 
			9 => SelectedShow9, 
			10 => SelectedShow10, 
			11 => SelectedShow11, 
			12 => SelectedShow12, 
			13 => SelectedShow13, 
			14 => SelectedShow14, 
			15 => SelectedShow15, 
			16 => SelectedShow16, 
			_ => false, 
		};
	}

	public void SetSelectedShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedShow1 = value;
			break;
		case 2:
			SelectedShow2 = value;
			break;
		case 3:
			SelectedShow3 = value;
			break;
		case 4:
			SelectedShow4 = value;
			break;
		case 5:
			SelectedShow5 = value;
			break;
		case 6:
			SelectedShow6 = value;
			break;
		case 7:
			SelectedShow7 = value;
			break;
		case 8:
			SelectedShow8 = value;
			break;
		case 9:
			SelectedShow9 = value;
			break;
		case 10:
			SelectedShow10 = value;
			break;
		case 11:
			SelectedShow11 = value;
			break;
		case 12:
			SelectedShow12 = value;
			break;
		case 13:
			SelectedShow13 = value;
			break;
		case 14:
			SelectedShow14 = value;
			break;
		case 15:
			SelectedShow15 = value;
			break;
		case 16:
			SelectedShow16 = value;
			break;
		}
	}

	public bool GetPosShow(int index)
	{
		return index switch
		{
			1 => PosShow1, 
			2 => PosShow2, 
			3 => PosShow3, 
			4 => PosShow4, 
			5 => PosShow5, 
			6 => PosShow6, 
			7 => PosShow7, 
			8 => PosShow8, 
			9 => PosShow9, 
			10 => PosShow10, 
			11 => PosShow11, 
			12 => PosShow12, 
			13 => PosShow13, 
			14 => PosShow14, 
			15 => PosShow15, 
			16 => PosShow16, 
			_ => false, 
		};
	}

	public void SetPosShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PosShow1 = value;
			break;
		case 2:
			PosShow2 = value;
			break;
		case 3:
			PosShow3 = value;
			break;
		case 4:
			PosShow4 = value;
			break;
		case 5:
			PosShow5 = value;
			break;
		case 6:
			PosShow6 = value;
			break;
		case 7:
			PosShow7 = value;
			break;
		case 8:
			PosShow8 = value;
			break;
		case 9:
			PosShow9 = value;
			break;
		case 10:
			PosShow10 = value;
			break;
		case 11:
			PosShow11 = value;
			break;
		case 12:
			PosShow12 = value;
			break;
		case 13:
			PosShow13 = value;
			break;
		case 14:
			PosShow14 = value;
			break;
		case 15:
			PosShow15 = value;
			break;
		case 16:
			PosShow16 = value;
			break;
		}
	}

	public Vector3 GetPosPosition(int index)
	{
		return index switch
		{
			1 => PosPosition1, 
			2 => PosPosition2, 
			3 => PosPosition3, 
			4 => PosPosition4, 
			5 => PosPosition5, 
			6 => PosPosition6, 
			7 => PosPosition7, 
			8 => PosPosition8, 
			9 => PosPosition9, 
			10 => PosPosition10, 
			11 => PosPosition11, 
			12 => PosPosition12, 
			13 => PosPosition13, 
			14 => PosPosition14, 
			15 => PosPosition15, 
			16 => PosPosition16, 
			_ => Vector3.zero, 
		};
	}

	public void SetPosPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			PosPosition1 = value;
			break;
		case 2:
			PosPosition2 = value;
			break;
		case 3:
			PosPosition3 = value;
			break;
		case 4:
			PosPosition4 = value;
			break;
		case 5:
			PosPosition5 = value;
			break;
		case 6:
			PosPosition6 = value;
			break;
		case 7:
			PosPosition7 = value;
			break;
		case 8:
			PosPosition8 = value;
			break;
		case 9:
			PosPosition9 = value;
			break;
		case 10:
			PosPosition10 = value;
			break;
		case 11:
			PosPosition11 = value;
			break;
		case 12:
			PosPosition12 = value;
			break;
		case 13:
			PosPosition13 = value;
			break;
		case 14:
			PosPosition14 = value;
			break;
		case 15:
			PosPosition15 = value;
			break;
		case 16:
			PosPosition16 = value;
			break;
		}
	}

	public Vector3 GetPosSize(int index)
	{
		return index switch
		{
			1 => PosSize1, 
			2 => PosSize2, 
			3 => PosSize3, 
			4 => PosSize4, 
			5 => PosSize5, 
			6 => PosSize6, 
			7 => PosSize7, 
			8 => PosSize8, 
			9 => PosSize9, 
			10 => PosSize10, 
			11 => PosSize11, 
			12 => PosSize12, 
			13 => PosSize13, 
			14 => PosSize14, 
			15 => PosSize15, 
			16 => PosSize16, 
			_ => Vector3.zero, 
		};
	}

	public void SetPosSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			PosSize1 = value;
			break;
		case 2:
			PosSize2 = value;
			break;
		case 3:
			PosSize3 = value;
			break;
		case 4:
			PosSize4 = value;
			break;
		case 5:
			PosSize5 = value;
			break;
		case 6:
			PosSize6 = value;
			break;
		case 7:
			PosSize7 = value;
			break;
		case 8:
			PosSize8 = value;
			break;
		case 9:
			PosSize9 = value;
			break;
		case 10:
			PosSize10 = value;
			break;
		case 11:
			PosSize11 = value;
			break;
		case 12:
			PosSize12 = value;
			break;
		case 13:
			PosSize13 = value;
			break;
		case 14:
			PosSize14 = value;
			break;
		case 15:
			PosSize15 = value;
			break;
		case 16:
			PosSize16 = value;
			break;
		}
	}

	public string GetPosString(int index)
	{
		return index switch
		{
			1 => PosString1, 
			2 => PosString2, 
			3 => PosString3, 
			4 => PosString4, 
			5 => PosString5, 
			6 => PosString6, 
			7 => PosString7, 
			8 => PosString8, 
			9 => PosString9, 
			10 => PosString10, 
			11 => PosString11, 
			12 => PosString12, 
			13 => PosString13, 
			14 => PosString14, 
			15 => PosString15, 
			16 => PosString16, 
			_ => null, 
		};
	}

	public void SetPosString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PosString1 = value;
			break;
		case 2:
			PosString2 = value;
			break;
		case 3:
			PosString3 = value;
			break;
		case 4:
			PosString4 = value;
			break;
		case 5:
			PosString5 = value;
			break;
		case 6:
			PosString6 = value;
			break;
		case 7:
			PosString7 = value;
			break;
		case 8:
			PosString8 = value;
			break;
		case 9:
			PosString9 = value;
			break;
		case 10:
			PosString10 = value;
			break;
		case 11:
			PosString11 = value;
			break;
		case 12:
			PosString12 = value;
			break;
		case 13:
			PosString13 = value;
			break;
		case 14:
			PosString14 = value;
			break;
		case 15:
			PosString15 = value;
			break;
		case 16:
			PosString16 = value;
			break;
		}
	}

	public Color GetPosTextcolor(int index)
	{
		return index switch
		{
			1 => PosTextcolor1, 
			2 => PosTextcolor2, 
			3 => PosTextcolor3, 
			4 => PosTextcolor4, 
			5 => PosTextcolor5, 
			6 => PosTextcolor6, 
			7 => PosTextcolor7, 
			8 => PosTextcolor8, 
			9 => PosTextcolor9, 
			10 => PosTextcolor10, 
			11 => PosTextcolor11, 
			12 => PosTextcolor12, 
			13 => PosTextcolor13, 
			14 => PosTextcolor14, 
			15 => PosTextcolor15, 
			16 => PosTextcolor16, 
			_ => Color.white, 
		};
	}

	public void SetPosTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			PosTextcolor1 = value;
			break;
		case 2:
			PosTextcolor2 = value;
			break;
		case 3:
			PosTextcolor3 = value;
			break;
		case 4:
			PosTextcolor4 = value;
			break;
		case 5:
			PosTextcolor5 = value;
			break;
		case 6:
			PosTextcolor6 = value;
			break;
		case 7:
			PosTextcolor7 = value;
			break;
		case 8:
			PosTextcolor8 = value;
			break;
		case 9:
			PosTextcolor9 = value;
			break;
		case 10:
			PosTextcolor10 = value;
			break;
		case 11:
			PosTextcolor11 = value;
			break;
		case 12:
			PosTextcolor12 = value;
			break;
		case 13:
			PosTextcolor13 = value;
			break;
		case 14:
			PosTextcolor14 = value;
			break;
		case 15:
			PosTextcolor15 = value;
			break;
		case 16:
			PosTextcolor16 = value;
			break;
		}
	}

	public bool GetFlagShow(int index)
	{
		return index switch
		{
			1 => FlagShow1, 
			2 => FlagShow2, 
			3 => FlagShow3, 
			4 => FlagShow4, 
			5 => FlagShow5, 
			6 => FlagShow6, 
			7 => FlagShow7, 
			8 => FlagShow8, 
			9 => FlagShow9, 
			10 => FlagShow10, 
			11 => FlagShow11, 
			12 => FlagShow12, 
			13 => FlagShow13, 
			14 => FlagShow14, 
			15 => FlagShow15, 
			16 => FlagShow16, 
			_ => false, 
		};
	}

	public void SetFlagShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FlagShow1 = value;
			break;
		case 2:
			FlagShow2 = value;
			break;
		case 3:
			FlagShow3 = value;
			break;
		case 4:
			FlagShow4 = value;
			break;
		case 5:
			FlagShow5 = value;
			break;
		case 6:
			FlagShow6 = value;
			break;
		case 7:
			FlagShow7 = value;
			break;
		case 8:
			FlagShow8 = value;
			break;
		case 9:
			FlagShow9 = value;
			break;
		case 10:
			FlagShow10 = value;
			break;
		case 11:
			FlagShow11 = value;
			break;
		case 12:
			FlagShow12 = value;
			break;
		case 13:
			FlagShow13 = value;
			break;
		case 14:
			FlagShow14 = value;
			break;
		case 15:
			FlagShow15 = value;
			break;
		case 16:
			FlagShow16 = value;
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
