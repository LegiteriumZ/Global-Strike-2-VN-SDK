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
public class CommonIndividualScoreInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oRoomInfo;

	private RectTransform _oRoomInfoRectTransform;

	private Image _oRoomInfoImage;

	private GameObject _oRoom;

	private Text _oRoomText;

	private GameObject _oPlayerNumber;

	private Text _oPlayerNumberText;

	private GameObject _oTeamGrid1;

	private GameObject _oTeamGrid2;

	private GameObject _oTeamGrid3;

	private GameObject _oTeamGrid4;

	private GameObject _oTitle1;

	private GameObject _oTitle2;

	private Image _oTitleImage1;

	private Image _oTitleImage2;

	private GameObject _oResultBg;

	private GameObject _oCurrentExp;

	private Text _oCurrentExpText;

	private GameObject _oCurrentExpPercent;

	private Text _oCurrentExpPercentText;

	private GameObject _oCurrentGp;

	private Text _oCurrentGpText;

	private GameObject _oCurrentGpPercent;

	private Text _oCurrentGpPercentText;

	private GameObject _oCurrentCrystal;

	private Text _oCurrentCrystalText;

	private GameObject _oExtraExp1;

	private GameObject _oExtraExp2;

	private GameObject _oExtraExp3;

	private GameObject _oExtraExp4;

	private GameObject _oExtraExp5;

	private GameObject _oExtraExp6;

	private GameObject _oExtraExp7;

	private Text _oExtraExpText1;

	private Text _oExtraExpText2;

	private Text _oExtraExpText3;

	private Text _oExtraExpText4;

	private Text _oExtraExpText5;

	private Text _oExtraExpText6;

	private Text _oExtraExpText7;

	private GameObject _oVipExpTitle;

	private Image _oVipExpTitleImage;

	private GameObject _oExtraGp1;

	private GameObject _oExtraGp2;

	private GameObject _oExtraGp3;

	private GameObject _oExtraGp4;

	private Text _oExtraGpText1;

	private Text _oExtraGpText2;

	private Text _oExtraGpText3;

	private Text _oExtraGpText4;

	private GameObject _oResult;

	private GameObject _oButtonExit;

	private Button _oButtonExitButton;

	private GameObject _oButtonContinue;

	private Button _oButtonContinueButton;

	private GameObject _oCountDown;

	private Text _oCountDownText;

	private GameObject _oObserverBack;

	private GameObject _oObserver1;

	private GameObject _oObserver2;

	private GameObject _oObserver3;

	private GameObject _oObserver4;

	private GameObject _oObserver5;

	private GameObject _oObserver6;

	private GameObject _oObserver7;

	private GameObject _oObserver8;

	private GameObject _oObserver9;

	private GameObject _oObserver10;

	private GameObject _oObserver11;

	private GameObject _oObserver12;

	private GameObject _oObserver13;

	private GameObject _oObserver14;

	private GameObject _oObserver15;

	private Text _oObserverText1;

	private Text _oObserverText2;

	private Text _oObserverText3;

	private Text _oObserverText4;

	private Text _oObserverText5;

	private Text _oObserverText6;

	private Text _oObserverText7;

	private Text _oObserverText8;

	private Text _oObserverText9;

	private Text _oObserverText10;

	private Text _oObserverText11;

	private Text _oObserverText12;

	private Text _oObserverText13;

	private Text _oObserverText14;

	private Text _oObserverText15;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "commonindividualscoreinfo";

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

	public Vector3 RoomInfoPosition
	{
		get
		{
			if (_oRoomInfoRectTransform != null)
			{
				return _oRoomInfoRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RoomInfoPosition != value && _oRoomInfoRectTransform != null)
			{
				_oRoomInfoRectTransform.localPosition = value;
			}
		}
	}

	public Sprite RoomInfoSprite
	{
		get
		{
			if (_oRoomInfoImage != null)
			{
				return _oRoomInfoImage.sprite;
			}
			return null;
		}
		set
		{
			if (RoomInfoSprite != value && _oRoomInfoImage != null)
			{
				_oRoomInfoImage.sprite = value;
			}
		}
	}

	public string RoomString
	{
		get
		{
			if (_oRoomText != null)
			{
				return _oRoomText.text;
			}
			return null;
		}
		set
		{
			if (RoomString != value && _oRoomText != null)
			{
				_oRoomText.text = value;
			}
		}
	}

	public string PlayerNumberString
	{
		get
		{
			if (_oPlayerNumberText != null)
			{
				return _oPlayerNumberText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNumberString != value && _oPlayerNumberText != null)
			{
				_oPlayerNumberText.text = value;
			}
		}
	}

	public GameObject TeamGridObj1 => _oTeamGrid1;

	public GameObject TeamGridObj2 => _oTeamGrid2;

	public GameObject TeamGridObj3 => _oTeamGrid3;

	public GameObject TeamGridObj4 => _oTeamGrid4;

	public Sprite TitleSprite1
	{
		get
		{
			if (_oTitleImage1 != null)
			{
				return _oTitleImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite1 != value && _oTitleImage1 != null)
			{
				_oTitleImage1.sprite = value;
			}
		}
	}

	public Sprite TitleSprite2
	{
		get
		{
			if (_oTitleImage2 != null)
			{
				return _oTitleImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite2 != value && _oTitleImage2 != null)
			{
				_oTitleImage2.sprite = value;
			}
		}
	}

	public bool ResultBgShow
	{
		get
		{
			if (_oResultBg != null)
			{
				return _oResultBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ResultBgShow != value && _oResultBg != null)
			{
				_oResultBg.SetObjectActive(value);
			}
		}
	}

	public string CurrentExpString
	{
		get
		{
			if (_oCurrentExpText != null)
			{
				return _oCurrentExpText.text;
			}
			return null;
		}
		set
		{
			if (CurrentExpString != value && _oCurrentExpText != null)
			{
				_oCurrentExpText.text = value;
			}
		}
	}

	public string CurrentExpPercentString
	{
		get
		{
			if (_oCurrentExpPercentText != null)
			{
				return _oCurrentExpPercentText.text;
			}
			return null;
		}
		set
		{
			if (CurrentExpPercentString != value && _oCurrentExpPercentText != null)
			{
				_oCurrentExpPercentText.text = value;
			}
		}
	}

	public string CurrentGpString
	{
		get
		{
			if (_oCurrentGpText != null)
			{
				return _oCurrentGpText.text;
			}
			return null;
		}
		set
		{
			if (CurrentGpString != value && _oCurrentGpText != null)
			{
				_oCurrentGpText.text = value;
			}
		}
	}

	public string CurrentGpPercentString
	{
		get
		{
			if (_oCurrentGpPercentText != null)
			{
				return _oCurrentGpPercentText.text;
			}
			return null;
		}
		set
		{
			if (CurrentGpPercentString != value && _oCurrentGpPercentText != null)
			{
				_oCurrentGpPercentText.text = value;
			}
		}
	}

	public string CurrentCrystalString
	{
		get
		{
			if (_oCurrentCrystalText != null)
			{
				return _oCurrentCrystalText.text;
			}
			return null;
		}
		set
		{
			if (CurrentCrystalString != value && _oCurrentCrystalText != null)
			{
				_oCurrentCrystalText.text = value;
			}
		}
	}

	public bool ExtraExpShow1
	{
		get
		{
			if (_oExtraExp1 != null)
			{
				return _oExtraExp1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow1 != value && _oExtraExp1 != null)
			{
				_oExtraExp1.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow2
	{
		get
		{
			if (_oExtraExp2 != null)
			{
				return _oExtraExp2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow2 != value && _oExtraExp2 != null)
			{
				_oExtraExp2.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow3
	{
		get
		{
			if (_oExtraExp3 != null)
			{
				return _oExtraExp3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow3 != value && _oExtraExp3 != null)
			{
				_oExtraExp3.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow4
	{
		get
		{
			if (_oExtraExp4 != null)
			{
				return _oExtraExp4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow4 != value && _oExtraExp4 != null)
			{
				_oExtraExp4.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow5
	{
		get
		{
			if (_oExtraExp5 != null)
			{
				return _oExtraExp5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow5 != value && _oExtraExp5 != null)
			{
				_oExtraExp5.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow6
	{
		get
		{
			if (_oExtraExp6 != null)
			{
				return _oExtraExp6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow6 != value && _oExtraExp6 != null)
			{
				_oExtraExp6.SetObjectActive(value);
			}
		}
	}

	public bool ExtraExpShow7
	{
		get
		{
			if (_oExtraExp7 != null)
			{
				return _oExtraExp7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraExpShow7 != value && _oExtraExp7 != null)
			{
				_oExtraExp7.SetObjectActive(value);
			}
		}
	}

	public string ExtraExpString1
	{
		get
		{
			if (_oExtraExpText1 != null)
			{
				return _oExtraExpText1.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString1 != value && _oExtraExpText1 != null)
			{
				_oExtraExpText1.text = value;
			}
		}
	}

	public string ExtraExpString2
	{
		get
		{
			if (_oExtraExpText2 != null)
			{
				return _oExtraExpText2.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString2 != value && _oExtraExpText2 != null)
			{
				_oExtraExpText2.text = value;
			}
		}
	}

	public string ExtraExpString3
	{
		get
		{
			if (_oExtraExpText3 != null)
			{
				return _oExtraExpText3.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString3 != value && _oExtraExpText3 != null)
			{
				_oExtraExpText3.text = value;
			}
		}
	}

	public string ExtraExpString4
	{
		get
		{
			if (_oExtraExpText4 != null)
			{
				return _oExtraExpText4.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString4 != value && _oExtraExpText4 != null)
			{
				_oExtraExpText4.text = value;
			}
		}
	}

	public string ExtraExpString5
	{
		get
		{
			if (_oExtraExpText5 != null)
			{
				return _oExtraExpText5.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString5 != value && _oExtraExpText5 != null)
			{
				_oExtraExpText5.text = value;
			}
		}
	}

	public string ExtraExpString6
	{
		get
		{
			if (_oExtraExpText6 != null)
			{
				return _oExtraExpText6.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString6 != value && _oExtraExpText6 != null)
			{
				_oExtraExpText6.text = value;
			}
		}
	}

	public string ExtraExpString7
	{
		get
		{
			if (_oExtraExpText7 != null)
			{
				return _oExtraExpText7.text;
			}
			return null;
		}
		set
		{
			if (ExtraExpString7 != value && _oExtraExpText7 != null)
			{
				_oExtraExpText7.text = value;
			}
		}
	}

	public Sprite VipExpTitleSprite
	{
		get
		{
			if (_oVipExpTitleImage != null)
			{
				return _oVipExpTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (VipExpTitleSprite != value && _oVipExpTitleImage != null)
			{
				_oVipExpTitleImage.sprite = value;
			}
		}
	}

	public bool ExtraGpShow1
	{
		get
		{
			if (_oExtraGp1 != null)
			{
				return _oExtraGp1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraGpShow1 != value && _oExtraGp1 != null)
			{
				_oExtraGp1.SetObjectActive(value);
			}
		}
	}

	public bool ExtraGpShow2
	{
		get
		{
			if (_oExtraGp2 != null)
			{
				return _oExtraGp2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraGpShow2 != value && _oExtraGp2 != null)
			{
				_oExtraGp2.SetObjectActive(value);
			}
		}
	}

	public bool ExtraGpShow3
	{
		get
		{
			if (_oExtraGp3 != null)
			{
				return _oExtraGp3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraGpShow3 != value && _oExtraGp3 != null)
			{
				_oExtraGp3.SetObjectActive(value);
			}
		}
	}

	public bool ExtraGpShow4
	{
		get
		{
			if (_oExtraGp4 != null)
			{
				return _oExtraGp4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ExtraGpShow4 != value && _oExtraGp4 != null)
			{
				_oExtraGp4.SetObjectActive(value);
			}
		}
	}

	public string ExtraGpString1
	{
		get
		{
			if (_oExtraGpText1 != null)
			{
				return _oExtraGpText1.text;
			}
			return null;
		}
		set
		{
			if (ExtraGpString1 != value && _oExtraGpText1 != null)
			{
				_oExtraGpText1.text = value;
			}
		}
	}

	public string ExtraGpString2
	{
		get
		{
			if (_oExtraGpText2 != null)
			{
				return _oExtraGpText2.text;
			}
			return null;
		}
		set
		{
			if (ExtraGpString2 != value && _oExtraGpText2 != null)
			{
				_oExtraGpText2.text = value;
			}
		}
	}

	public string ExtraGpString3
	{
		get
		{
			if (_oExtraGpText3 != null)
			{
				return _oExtraGpText3.text;
			}
			return null;
		}
		set
		{
			if (ExtraGpString3 != value && _oExtraGpText3 != null)
			{
				_oExtraGpText3.text = value;
			}
		}
	}

	public string ExtraGpString4
	{
		get
		{
			if (_oExtraGpText4 != null)
			{
				return _oExtraGpText4.text;
			}
			return null;
		}
		set
		{
			if (ExtraGpString4 != value && _oExtraGpText4 != null)
			{
				_oExtraGpText4.text = value;
			}
		}
	}

	public bool ResultShow
	{
		get
		{
			if (_oResult != null)
			{
				return _oResult.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ResultShow != value && _oResult != null)
			{
				_oResult.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ButtonExitClicked
	{
		get
		{
			if (_oButtonExitButton != null)
			{
				return _oButtonExitButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonExitClicked != value && _oButtonExitButton != null)
			{
				_oButtonExitButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ButtonContinueClicked
	{
		get
		{
			if (_oButtonContinueButton != null)
			{
				return _oButtonContinueButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonContinueClicked != value && _oButtonContinueButton != null)
			{
				_oButtonContinueButton.onClick = value;
			}
		}
	}

	public string CountDownString
	{
		get
		{
			if (_oCountDownText != null)
			{
				return _oCountDownText.text;
			}
			return null;
		}
		set
		{
			if (CountDownString != value && _oCountDownText != null)
			{
				_oCountDownText.text = value;
			}
		}
	}

	public bool ObserverBackShow
	{
		get
		{
			if (_oObserverBack != null)
			{
				return _oObserverBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ObserverBackShow != value && _oObserverBack != null)
			{
				_oObserverBack.SetObjectActive(value);
			}
		}
	}

	public string ObserverString1
	{
		get
		{
			if (_oObserverText1 != null)
			{
				return _oObserverText1.text;
			}
			return null;
		}
		set
		{
			if (ObserverString1 != value && _oObserverText1 != null)
			{
				_oObserverText1.text = value;
			}
		}
	}

	public string ObserverString2
	{
		get
		{
			if (_oObserverText2 != null)
			{
				return _oObserverText2.text;
			}
			return null;
		}
		set
		{
			if (ObserverString2 != value && _oObserverText2 != null)
			{
				_oObserverText2.text = value;
			}
		}
	}

	public string ObserverString3
	{
		get
		{
			if (_oObserverText3 != null)
			{
				return _oObserverText3.text;
			}
			return null;
		}
		set
		{
			if (ObserverString3 != value && _oObserverText3 != null)
			{
				_oObserverText3.text = value;
			}
		}
	}

	public string ObserverString4
	{
		get
		{
			if (_oObserverText4 != null)
			{
				return _oObserverText4.text;
			}
			return null;
		}
		set
		{
			if (ObserverString4 != value && _oObserverText4 != null)
			{
				_oObserverText4.text = value;
			}
		}
	}

	public string ObserverString5
	{
		get
		{
			if (_oObserverText5 != null)
			{
				return _oObserverText5.text;
			}
			return null;
		}
		set
		{
			if (ObserverString5 != value && _oObserverText5 != null)
			{
				_oObserverText5.text = value;
			}
		}
	}

	public string ObserverString6
	{
		get
		{
			if (_oObserverText6 != null)
			{
				return _oObserverText6.text;
			}
			return null;
		}
		set
		{
			if (ObserverString6 != value && _oObserverText6 != null)
			{
				_oObserverText6.text = value;
			}
		}
	}

	public string ObserverString7
	{
		get
		{
			if (_oObserverText7 != null)
			{
				return _oObserverText7.text;
			}
			return null;
		}
		set
		{
			if (ObserverString7 != value && _oObserverText7 != null)
			{
				_oObserverText7.text = value;
			}
		}
	}

	public string ObserverString8
	{
		get
		{
			if (_oObserverText8 != null)
			{
				return _oObserverText8.text;
			}
			return null;
		}
		set
		{
			if (ObserverString8 != value && _oObserverText8 != null)
			{
				_oObserverText8.text = value;
			}
		}
	}

	public string ObserverString9
	{
		get
		{
			if (_oObserverText9 != null)
			{
				return _oObserverText9.text;
			}
			return null;
		}
		set
		{
			if (ObserverString9 != value && _oObserverText9 != null)
			{
				_oObserverText9.text = value;
			}
		}
	}

	public string ObserverString10
	{
		get
		{
			if (_oObserverText10 != null)
			{
				return _oObserverText10.text;
			}
			return null;
		}
		set
		{
			if (ObserverString10 != value && _oObserverText10 != null)
			{
				_oObserverText10.text = value;
			}
		}
	}

	public string ObserverString11
	{
		get
		{
			if (_oObserverText11 != null)
			{
				return _oObserverText11.text;
			}
			return null;
		}
		set
		{
			if (ObserverString11 != value && _oObserverText11 != null)
			{
				_oObserverText11.text = value;
			}
		}
	}

	public string ObserverString12
	{
		get
		{
			if (_oObserverText12 != null)
			{
				return _oObserverText12.text;
			}
			return null;
		}
		set
		{
			if (ObserverString12 != value && _oObserverText12 != null)
			{
				_oObserverText12.text = value;
			}
		}
	}

	public string ObserverString13
	{
		get
		{
			if (_oObserverText13 != null)
			{
				return _oObserverText13.text;
			}
			return null;
		}
		set
		{
			if (ObserverString13 != value && _oObserverText13 != null)
			{
				_oObserverText13.text = value;
			}
		}
	}

	public string ObserverString14
	{
		get
		{
			if (_oObserverText14 != null)
			{
				return _oObserverText14.text;
			}
			return null;
		}
		set
		{
			if (ObserverString14 != value && _oObserverText14 != null)
			{
				_oObserverText14.text = value;
			}
		}
	}

	public string ObserverString15
	{
		get
		{
			if (_oObserverText15 != null)
			{
				return _oObserverText15.text;
			}
			return null;
		}
		set
		{
			if (ObserverString15 != value && _oObserverText15 != null)
			{
				_oObserverText15.text = value;
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
			case "RoomInfo":
				_oRoomInfo = transform.gameObject;
				_oRoomInfoRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oRoomInfoImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Room":
				_oRoom = transform.gameObject;
				_oRoomText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerNumber":
				_oPlayerNumber = transform.gameObject;
				_oPlayerNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamGrid1":
				_oTeamGrid1 = transform.gameObject;
				break;
			case "TeamGrid2":
				_oTeamGrid2 = transform.gameObject;
				break;
			case "TeamGrid3":
				_oTeamGrid3 = transform.gameObject;
				break;
			case "TeamGrid4":
				_oTeamGrid4 = transform.gameObject;
				break;
			case "Title1":
				_oTitle1 = transform.gameObject;
				_oTitleImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Title2":
				_oTitle2 = transform.gameObject;
				_oTitleImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "ResultBg":
				_oResultBg = transform.gameObject;
				break;
			case "CurrentExp":
				_oCurrentExp = transform.gameObject;
				_oCurrentExpText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentExpPercent":
				_oCurrentExpPercent = transform.gameObject;
				_oCurrentExpPercentText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentGp":
				_oCurrentGp = transform.gameObject;
				_oCurrentGpText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentGpPercent":
				_oCurrentGpPercent = transform.gameObject;
				_oCurrentGpPercentText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentCrystal":
				_oCurrentCrystal = transform.gameObject;
				_oCurrentCrystalText = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp1":
				_oExtraExp1 = transform.gameObject;
				_oExtraExpText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp2":
				_oExtraExp2 = transform.gameObject;
				_oExtraExpText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp3":
				_oExtraExp3 = transform.gameObject;
				_oExtraExpText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp4":
				_oExtraExp4 = transform.gameObject;
				_oExtraExpText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp5":
				_oExtraExp5 = transform.gameObject;
				_oExtraExpText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp6":
				_oExtraExp6 = transform.gameObject;
				_oExtraExpText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraExp7":
				_oExtraExp7 = transform.gameObject;
				_oExtraExpText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "VipExpTitle":
				_oVipExpTitle = transform.gameObject;
				_oVipExpTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ExtraGp1":
				_oExtraGp1 = transform.gameObject;
				_oExtraGpText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraGp2":
				_oExtraGp2 = transform.gameObject;
				_oExtraGpText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraGp3":
				_oExtraGp3 = transform.gameObject;
				_oExtraGpText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExtraGp4":
				_oExtraGp4 = transform.gameObject;
				_oExtraGpText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Result":
				_oResult = transform.gameObject;
				break;
			case "ButtonExit":
				_oButtonExit = transform.gameObject;
				_oButtonExitButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ButtonContinue":
				_oButtonContinue = transform.gameObject;
				_oButtonContinueButton = transform.gameObject.GetComponent<Button>();
				break;
			case "CountDown":
				_oCountDown = transform.gameObject;
				_oCountDownText = transform.gameObject.GetComponent<Text>();
				break;
			case "ObserverBack":
				_oObserverBack = transform.gameObject;
				break;
			case "Observer1":
				_oObserver1 = transform.gameObject;
				_oObserverText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer2":
				_oObserver2 = transform.gameObject;
				_oObserverText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer3":
				_oObserver3 = transform.gameObject;
				_oObserverText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer4":
				_oObserver4 = transform.gameObject;
				_oObserverText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer5":
				_oObserver5 = transform.gameObject;
				_oObserverText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer6":
				_oObserver6 = transform.gameObject;
				_oObserverText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer7":
				_oObserver7 = transform.gameObject;
				_oObserverText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer8":
				_oObserver8 = transform.gameObject;
				_oObserverText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer9":
				_oObserver9 = transform.gameObject;
				_oObserverText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer10":
				_oObserver10 = transform.gameObject;
				_oObserverText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer11":
				_oObserver11 = transform.gameObject;
				_oObserverText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer12":
				_oObserver12 = transform.gameObject;
				_oObserverText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer13":
				_oObserver13 = transform.gameObject;
				_oObserverText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer14":
				_oObserver14 = transform.gameObject;
				_oObserverText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "Observer15":
				_oObserver15 = transform.gameObject;
				_oObserverText15 = transform.gameObject.GetComponent<Text>();
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

	public void RoomInfoNtvsize()
	{
		if (_oRoomInfoImage != null)
		{
			_oRoomInfoImage.SetNativeSize();
		}
	}

	public GameObject GetTeamGridObj(int index)
	{
		return index switch
		{
			1 => TeamGridObj1, 
			2 => TeamGridObj2, 
			3 => TeamGridObj3, 
			4 => TeamGridObj4, 
			_ => null, 
		};
	}

	public int GetTeamGridCount()
	{
		return 4;
	}

	public Sprite GetTitleSprite(int index)
	{
		return index switch
		{
			1 => TitleSprite1, 
			2 => TitleSprite2, 
			_ => null, 
		};
	}

	public void SetTitleSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TitleSprite1 = value;
			break;
		case 2:
			TitleSprite2 = value;
			break;
		}
	}

	public int GetTitleCount()
	{
		return 2;
	}

	public void TitleNtvsize1()
	{
		if (_oTitleImage1 != null)
		{
			_oTitleImage1.SetNativeSize();
		}
	}

	public void TitleNtvsize2()
	{
		if (_oTitleImage2 != null)
		{
			_oTitleImage2.SetNativeSize();
		}
	}

	public void CallTitleNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			TitleNtvsize1();
			break;
		case 2:
			TitleNtvsize2();
			break;
		}
	}

	public bool GetExtraExpShow(int index)
	{
		return index switch
		{
			1 => ExtraExpShow1, 
			2 => ExtraExpShow2, 
			3 => ExtraExpShow3, 
			4 => ExtraExpShow4, 
			5 => ExtraExpShow5, 
			6 => ExtraExpShow6, 
			7 => ExtraExpShow7, 
			_ => false, 
		};
	}

	public void SetExtraExpShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ExtraExpShow1 = value;
			break;
		case 2:
			ExtraExpShow2 = value;
			break;
		case 3:
			ExtraExpShow3 = value;
			break;
		case 4:
			ExtraExpShow4 = value;
			break;
		case 5:
			ExtraExpShow5 = value;
			break;
		case 6:
			ExtraExpShow6 = value;
			break;
		case 7:
			ExtraExpShow7 = value;
			break;
		}
	}

	public int GetExtraExpCount()
	{
		return 7;
	}

	public string GetExtraExpString(int index)
	{
		return index switch
		{
			1 => ExtraExpString1, 
			2 => ExtraExpString2, 
			3 => ExtraExpString3, 
			4 => ExtraExpString4, 
			5 => ExtraExpString5, 
			6 => ExtraExpString6, 
			7 => ExtraExpString7, 
			_ => null, 
		};
	}

	public void SetExtraExpString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ExtraExpString1 = value;
			break;
		case 2:
			ExtraExpString2 = value;
			break;
		case 3:
			ExtraExpString3 = value;
			break;
		case 4:
			ExtraExpString4 = value;
			break;
		case 5:
			ExtraExpString5 = value;
			break;
		case 6:
			ExtraExpString6 = value;
			break;
		case 7:
			ExtraExpString7 = value;
			break;
		}
	}

	public bool GetExtraGpShow(int index)
	{
		return index switch
		{
			1 => ExtraGpShow1, 
			2 => ExtraGpShow2, 
			3 => ExtraGpShow3, 
			4 => ExtraGpShow4, 
			_ => false, 
		};
	}

	public void SetExtraGpShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ExtraGpShow1 = value;
			break;
		case 2:
			ExtraGpShow2 = value;
			break;
		case 3:
			ExtraGpShow3 = value;
			break;
		case 4:
			ExtraGpShow4 = value;
			break;
		}
	}

	public int GetExtraGpCount()
	{
		return 4;
	}

	public string GetExtraGpString(int index)
	{
		return index switch
		{
			1 => ExtraGpString1, 
			2 => ExtraGpString2, 
			3 => ExtraGpString3, 
			4 => ExtraGpString4, 
			_ => null, 
		};
	}

	public void SetExtraGpString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ExtraGpString1 = value;
			break;
		case 2:
			ExtraGpString2 = value;
			break;
		case 3:
			ExtraGpString3 = value;
			break;
		case 4:
			ExtraGpString4 = value;
			break;
		}
	}

	public string GetObserverString(int index)
	{
		return index switch
		{
			1 => ObserverString1, 
			2 => ObserverString2, 
			3 => ObserverString3, 
			4 => ObserverString4, 
			5 => ObserverString5, 
			6 => ObserverString6, 
			7 => ObserverString7, 
			8 => ObserverString8, 
			9 => ObserverString9, 
			10 => ObserverString10, 
			11 => ObserverString11, 
			12 => ObserverString12, 
			13 => ObserverString13, 
			14 => ObserverString14, 
			15 => ObserverString15, 
			_ => null, 
		};
	}

	public void SetObserverString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ObserverString1 = value;
			break;
		case 2:
			ObserverString2 = value;
			break;
		case 3:
			ObserverString3 = value;
			break;
		case 4:
			ObserverString4 = value;
			break;
		case 5:
			ObserverString5 = value;
			break;
		case 6:
			ObserverString6 = value;
			break;
		case 7:
			ObserverString7 = value;
			break;
		case 8:
			ObserverString8 = value;
			break;
		case 9:
			ObserverString9 = value;
			break;
		case 10:
			ObserverString10 = value;
			break;
		case 11:
			ObserverString11 = value;
			break;
		case 12:
			ObserverString12 = value;
			break;
		case 13:
			ObserverString13 = value;
			break;
		case 14:
			ObserverString14 = value;
			break;
		case 15:
			ObserverString15 = value;
			break;
		}
	}

	public int GetObserverCount()
	{
		return 15;
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
