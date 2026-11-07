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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _obtnIcon1;

	private GameObject _obtnIcon2;

	private GameObject _obtnIcon3;

	private GameObject _obtnIcon4;

	private GameObject _obtnIcon5;

	private GameObject _oSkillCount;

	private Text _oSkillCountText;

	private GameObject _omoney;

	private Text _omoneyText;

	private GameObject _omoney_1;

	private GameObject _omoney_2;

	private GameObject _omoney_3;

	private GameObject _omoney_4;

	private GameObject _omoney_5;

	private GameObject _omoney_6;

	private GameObject _omoney_7;

	private GameObject _omoney_8;

	private Text _omoney_Text1;

	private Text _omoney_Text2;

	private Text _omoney_Text3;

	private Text _omoney_Text4;

	private Text _omoney_Text5;

	private Text _omoney_Text6;

	private Text _omoney_Text7;

	private Text _omoney_Text8;

	private CanvasGroup _omoney_CanvasGroup1;

	private CanvasGroup _omoney_CanvasGroup2;

	private CanvasGroup _omoney_CanvasGroup3;

	private CanvasGroup _omoney_CanvasGroup4;

	private CanvasGroup _omoney_CanvasGroup5;

	private CanvasGroup _omoney_CanvasGroup6;

	private CanvasGroup _omoney_CanvasGroup7;

	private CanvasGroup _omoney_CanvasGroup8;

	private GameObject _oplayerSelect;

	private GameObject _oPlayerbg1;

	private GameObject _oPlayerbg2;

	private GameObject _oPlayerbg3;

	private GameObject _oPlayerbg4;

	private GameObject _oPlayerbg5;

	private GameObject _oPlayerbg6;

	private GameObject _oPlayerbg7;

	private GameObject _oPlayerbg8;

	private GameObject _oPlayerbg9;

	private GameObject _oPlayerIcon1;

	private GameObject _oPlayerIcon2;

	private GameObject _oPlayerIcon3;

	private GameObject _oPlayerIcon4;

	private GameObject _oPlayerIcon5;

	private GameObject _oPlayerIcon6;

	private GameObject _oPlayerIcon7;

	private GameObject _oPlayerIcon8;

	private GameObject _oPlayerIcon9;

	private Image _oPlayerIconImage1;

	private Image _oPlayerIconImage2;

	private Image _oPlayerIconImage3;

	private Image _oPlayerIconImage4;

	private Image _oPlayerIconImage5;

	private Image _oPlayerIconImage6;

	private Image _oPlayerIconImage7;

	private Image _oPlayerIconImage8;

	private Image _oPlayerIconImage9;

	private GameObject _orbtn;

	private GameObject _olbtn;

	private GameObject _oplayerDes;

	private Image _oplayerDesImage;

	private GameObject _oSkillDes;

	private GameObject _oPIcon;

	private Image _oPIconImage;

	private GameObject _oLv;

	private Text _oLvText;

	private GameObject _oHP;

	private Image _oHPImage;

	private GameObject _oHD;

	private Image _oHDImage;

	private GameObject _oHP_2;

	private Text _oHP_Text2;

	private GameObject _oexpui;

	private GameObject _oexp;

	private Image _oexpImage;

	private GameObject _oys;

	private Text _oysText;

	private GameObject _oty;

	private Text _otyText;

	private GameObject _osh;

	private Text _oshText;

	private GameObject _oskillIcon;

	private Image _oskillIconImage;

	private GameObject _oLevelUpEffect;

	private GameObject _oLeft;

	private CanvasGroup _oLeftCanvasGroup;

	private GameObject _oRight;

	private CanvasGroup _oRightCanvasGroup;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_z";

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

	public bool btnIconShow1
	{
		get
		{
			if (_obtnIcon1 != null)
			{
				return _obtnIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow1 != value && _obtnIcon1 != null)
			{
				_obtnIcon1.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow2
	{
		get
		{
			if (_obtnIcon2 != null)
			{
				return _obtnIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow2 != value && _obtnIcon2 != null)
			{
				_obtnIcon2.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow3
	{
		get
		{
			if (_obtnIcon3 != null)
			{
				return _obtnIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow3 != value && _obtnIcon3 != null)
			{
				_obtnIcon3.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow4
	{
		get
		{
			if (_obtnIcon4 != null)
			{
				return _obtnIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow4 != value && _obtnIcon4 != null)
			{
				_obtnIcon4.SetObjectActive(value);
			}
		}
	}

	public bool btnIconShow5
	{
		get
		{
			if (_obtnIcon5 != null)
			{
				return _obtnIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (btnIconShow5 != value && _obtnIcon5 != null)
			{
				_obtnIcon5.SetObjectActive(value);
			}
		}
	}

	public string SkillCountString
	{
		get
		{
			if (_oSkillCountText != null)
			{
				return _oSkillCountText.text;
			}
			return null;
		}
		set
		{
			if (SkillCountString != value && _oSkillCountText != null)
			{
				_oSkillCountText.text = value;
			}
		}
	}

	public string moneyString
	{
		get
		{
			if (_omoneyText != null)
			{
				return _omoneyText.text;
			}
			return null;
		}
		set
		{
			if (moneyString != value && _omoneyText != null)
			{
				_omoneyText.text = value;
			}
		}
	}

	public GameObject money_Obj1 => _omoney_1;

	public GameObject money_Obj2 => _omoney_2;

	public GameObject money_Obj3 => _omoney_3;

	public GameObject money_Obj4 => _omoney_4;

	public GameObject money_Obj5 => _omoney_5;

	public GameObject money_Obj6 => _omoney_6;

	public GameObject money_Obj7 => _omoney_7;

	public GameObject money_Obj8 => _omoney_8;

	public bool money_Show1
	{
		get
		{
			if (_omoney_1 != null)
			{
				return _omoney_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show1 != value && _omoney_1 != null)
			{
				_omoney_1.SetObjectActive(value);
			}
		}
	}

	public bool money_Show2
	{
		get
		{
			if (_omoney_2 != null)
			{
				return _omoney_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show2 != value && _omoney_2 != null)
			{
				_omoney_2.SetObjectActive(value);
			}
		}
	}

	public bool money_Show3
	{
		get
		{
			if (_omoney_3 != null)
			{
				return _omoney_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show3 != value && _omoney_3 != null)
			{
				_omoney_3.SetObjectActive(value);
			}
		}
	}

	public bool money_Show4
	{
		get
		{
			if (_omoney_4 != null)
			{
				return _omoney_4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show4 != value && _omoney_4 != null)
			{
				_omoney_4.SetObjectActive(value);
			}
		}
	}

	public bool money_Show5
	{
		get
		{
			if (_omoney_5 != null)
			{
				return _omoney_5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show5 != value && _omoney_5 != null)
			{
				_omoney_5.SetObjectActive(value);
			}
		}
	}

	public bool money_Show6
	{
		get
		{
			if (_omoney_6 != null)
			{
				return _omoney_6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show6 != value && _omoney_6 != null)
			{
				_omoney_6.SetObjectActive(value);
			}
		}
	}

	public bool money_Show7
	{
		get
		{
			if (_omoney_7 != null)
			{
				return _omoney_7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show7 != value && _omoney_7 != null)
			{
				_omoney_7.SetObjectActive(value);
			}
		}
	}

	public bool money_Show8
	{
		get
		{
			if (_omoney_8 != null)
			{
				return _omoney_8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (money_Show8 != value && _omoney_8 != null)
			{
				_omoney_8.SetObjectActive(value);
			}
		}
	}

	public string money_String1
	{
		get
		{
			if (_omoney_Text1 != null)
			{
				return _omoney_Text1.text;
			}
			return null;
		}
		set
		{
			if (money_String1 != value && _omoney_Text1 != null)
			{
				_omoney_Text1.text = value;
			}
		}
	}

	public string money_String2
	{
		get
		{
			if (_omoney_Text2 != null)
			{
				return _omoney_Text2.text;
			}
			return null;
		}
		set
		{
			if (money_String2 != value && _omoney_Text2 != null)
			{
				_omoney_Text2.text = value;
			}
		}
	}

	public string money_String3
	{
		get
		{
			if (_omoney_Text3 != null)
			{
				return _omoney_Text3.text;
			}
			return null;
		}
		set
		{
			if (money_String3 != value && _omoney_Text3 != null)
			{
				_omoney_Text3.text = value;
			}
		}
	}

	public string money_String4
	{
		get
		{
			if (_omoney_Text4 != null)
			{
				return _omoney_Text4.text;
			}
			return null;
		}
		set
		{
			if (money_String4 != value && _omoney_Text4 != null)
			{
				_omoney_Text4.text = value;
			}
		}
	}

	public string money_String5
	{
		get
		{
			if (_omoney_Text5 != null)
			{
				return _omoney_Text5.text;
			}
			return null;
		}
		set
		{
			if (money_String5 != value && _omoney_Text5 != null)
			{
				_omoney_Text5.text = value;
			}
		}
	}

	public string money_String6
	{
		get
		{
			if (_omoney_Text6 != null)
			{
				return _omoney_Text6.text;
			}
			return null;
		}
		set
		{
			if (money_String6 != value && _omoney_Text6 != null)
			{
				_omoney_Text6.text = value;
			}
		}
	}

	public string money_String7
	{
		get
		{
			if (_omoney_Text7 != null)
			{
				return _omoney_Text7.text;
			}
			return null;
		}
		set
		{
			if (money_String7 != value && _omoney_Text7 != null)
			{
				_omoney_Text7.text = value;
			}
		}
	}

	public string money_String8
	{
		get
		{
			if (_omoney_Text8 != null)
			{
				return _omoney_Text8.text;
			}
			return null;
		}
		set
		{
			if (money_String8 != value && _omoney_Text8 != null)
			{
				_omoney_Text8.text = value;
			}
		}
	}

	public float money_Alpha1
	{
		get
		{
			if (_omoney_CanvasGroup1 != null)
			{
				return _omoney_CanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha1 != value && _omoney_CanvasGroup1 != null)
			{
				_omoney_CanvasGroup1.alpha = value;
			}
		}
	}

	public float money_Alpha2
	{
		get
		{
			if (_omoney_CanvasGroup2 != null)
			{
				return _omoney_CanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha2 != value && _omoney_CanvasGroup2 != null)
			{
				_omoney_CanvasGroup2.alpha = value;
			}
		}
	}

	public float money_Alpha3
	{
		get
		{
			if (_omoney_CanvasGroup3 != null)
			{
				return _omoney_CanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha3 != value && _omoney_CanvasGroup3 != null)
			{
				_omoney_CanvasGroup3.alpha = value;
			}
		}
	}

	public float money_Alpha4
	{
		get
		{
			if (_omoney_CanvasGroup4 != null)
			{
				return _omoney_CanvasGroup4.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha4 != value && _omoney_CanvasGroup4 != null)
			{
				_omoney_CanvasGroup4.alpha = value;
			}
		}
	}

	public float money_Alpha5
	{
		get
		{
			if (_omoney_CanvasGroup5 != null)
			{
				return _omoney_CanvasGroup5.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha5 != value && _omoney_CanvasGroup5 != null)
			{
				_omoney_CanvasGroup5.alpha = value;
			}
		}
	}

	public float money_Alpha6
	{
		get
		{
			if (_omoney_CanvasGroup6 != null)
			{
				return _omoney_CanvasGroup6.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha6 != value && _omoney_CanvasGroup6 != null)
			{
				_omoney_CanvasGroup6.alpha = value;
			}
		}
	}

	public float money_Alpha7
	{
		get
		{
			if (_omoney_CanvasGroup7 != null)
			{
				return _omoney_CanvasGroup7.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha7 != value && _omoney_CanvasGroup7 != null)
			{
				_omoney_CanvasGroup7.alpha = value;
			}
		}
	}

	public float money_Alpha8
	{
		get
		{
			if (_omoney_CanvasGroup8 != null)
			{
				return _omoney_CanvasGroup8.alpha;
			}
			return 0f;
		}
		set
		{
			if (money_Alpha8 != value && _omoney_CanvasGroup8 != null)
			{
				_omoney_CanvasGroup8.alpha = value;
			}
		}
	}

	public bool playerSelectShow
	{
		get
		{
			if (_oplayerSelect != null)
			{
				return _oplayerSelect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerSelectShow != value && _oplayerSelect != null)
			{
				_oplayerSelect.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow1
	{
		get
		{
			if (_oPlayerbg1 != null)
			{
				return _oPlayerbg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow1 != value && _oPlayerbg1 != null)
			{
				_oPlayerbg1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow2
	{
		get
		{
			if (_oPlayerbg2 != null)
			{
				return _oPlayerbg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow2 != value && _oPlayerbg2 != null)
			{
				_oPlayerbg2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow3
	{
		get
		{
			if (_oPlayerbg3 != null)
			{
				return _oPlayerbg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow3 != value && _oPlayerbg3 != null)
			{
				_oPlayerbg3.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow4
	{
		get
		{
			if (_oPlayerbg4 != null)
			{
				return _oPlayerbg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow4 != value && _oPlayerbg4 != null)
			{
				_oPlayerbg4.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow5
	{
		get
		{
			if (_oPlayerbg5 != null)
			{
				return _oPlayerbg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow5 != value && _oPlayerbg5 != null)
			{
				_oPlayerbg5.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow6
	{
		get
		{
			if (_oPlayerbg6 != null)
			{
				return _oPlayerbg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow6 != value && _oPlayerbg6 != null)
			{
				_oPlayerbg6.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow7
	{
		get
		{
			if (_oPlayerbg7 != null)
			{
				return _oPlayerbg7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow7 != value && _oPlayerbg7 != null)
			{
				_oPlayerbg7.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow8
	{
		get
		{
			if (_oPlayerbg8 != null)
			{
				return _oPlayerbg8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow8 != value && _oPlayerbg8 != null)
			{
				_oPlayerbg8.SetObjectActive(value);
			}
		}
	}

	public bool PlayerbgShow9
	{
		get
		{
			if (_oPlayerbg9 != null)
			{
				return _oPlayerbg9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerbgShow9 != value && _oPlayerbg9 != null)
			{
				_oPlayerbg9.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerIconSprite1
	{
		get
		{
			if (_oPlayerIconImage1 != null)
			{
				return _oPlayerIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite1 != value && _oPlayerIconImage1 != null)
			{
				_oPlayerIconImage1.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite2
	{
		get
		{
			if (_oPlayerIconImage2 != null)
			{
				return _oPlayerIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite2 != value && _oPlayerIconImage2 != null)
			{
				_oPlayerIconImage2.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite3
	{
		get
		{
			if (_oPlayerIconImage3 != null)
			{
				return _oPlayerIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite3 != value && _oPlayerIconImage3 != null)
			{
				_oPlayerIconImage3.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite4
	{
		get
		{
			if (_oPlayerIconImage4 != null)
			{
				return _oPlayerIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite4 != value && _oPlayerIconImage4 != null)
			{
				_oPlayerIconImage4.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite5
	{
		get
		{
			if (_oPlayerIconImage5 != null)
			{
				return _oPlayerIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite5 != value && _oPlayerIconImage5 != null)
			{
				_oPlayerIconImage5.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite6
	{
		get
		{
			if (_oPlayerIconImage6 != null)
			{
				return _oPlayerIconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite6 != value && _oPlayerIconImage6 != null)
			{
				_oPlayerIconImage6.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite7
	{
		get
		{
			if (_oPlayerIconImage7 != null)
			{
				return _oPlayerIconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite7 != value && _oPlayerIconImage7 != null)
			{
				_oPlayerIconImage7.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite8
	{
		get
		{
			if (_oPlayerIconImage8 != null)
			{
				return _oPlayerIconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite8 != value && _oPlayerIconImage8 != null)
			{
				_oPlayerIconImage8.sprite = value;
			}
		}
	}

	public Sprite PlayerIconSprite9
	{
		get
		{
			if (_oPlayerIconImage9 != null)
			{
				return _oPlayerIconImage9.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerIconSprite9 != value && _oPlayerIconImage9 != null)
			{
				_oPlayerIconImage9.sprite = value;
			}
		}
	}

	public bool rbtnShow
	{
		get
		{
			if (_orbtn != null)
			{
				return _orbtn.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (rbtnShow != value && _orbtn != null)
			{
				_orbtn.SetObjectActive(value);
			}
		}
	}

	public bool lbtnShow
	{
		get
		{
			if (_olbtn != null)
			{
				return _olbtn.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lbtnShow != value && _olbtn != null)
			{
				_olbtn.SetObjectActive(value);
			}
		}
	}

	public bool playerDesShow
	{
		get
		{
			if (_oplayerDes != null)
			{
				return _oplayerDes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerDesShow != value && _oplayerDes != null)
			{
				_oplayerDes.SetObjectActive(value);
			}
		}
	}

	public Sprite playerDesSprite
	{
		get
		{
			if (_oplayerDesImage != null)
			{
				return _oplayerDesImage.sprite;
			}
			return null;
		}
		set
		{
			if (playerDesSprite != value && _oplayerDesImage != null)
			{
				_oplayerDesImage.sprite = value;
			}
		}
	}

	public bool SkillDesShow
	{
		get
		{
			if (_oSkillDes != null)
			{
				return _oSkillDes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillDesShow != value && _oSkillDes != null)
			{
				_oSkillDes.SetObjectActive(value);
			}
		}
	}

	public Sprite PIconSprite
	{
		get
		{
			if (_oPIconImage != null)
			{
				return _oPIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (PIconSprite != value && _oPIconImage != null)
			{
				_oPIconImage.sprite = value;
			}
		}
	}

	public string LvString
	{
		get
		{
			if (_oLvText != null)
			{
				return _oLvText.text;
			}
			return null;
		}
		set
		{
			if (LvString != value && _oLvText != null)
			{
				_oLvText.text = value;
			}
		}
	}

	public float HPFillamount
	{
		get
		{
			if (_oHPImage != null)
			{
				return _oHPImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HPFillamount != value && _oHPImage != null)
			{
				_oHPImage.fillAmount = value;
			}
		}
	}

	public float HDFillamount
	{
		get
		{
			if (_oHDImage != null)
			{
				return _oHDImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HDFillamount != value && _oHDImage != null)
			{
				_oHDImage.fillAmount = value;
			}
		}
	}

	public string HP_String2
	{
		get
		{
			if (_oHP_Text2 != null)
			{
				return _oHP_Text2.text;
			}
			return null;
		}
		set
		{
			if (HP_String2 != value && _oHP_Text2 != null)
			{
				_oHP_Text2.text = value;
			}
		}
	}

	public bool expuiShow
	{
		get
		{
			if (_oexpui != null)
			{
				return _oexpui.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (expuiShow != value && _oexpui != null)
			{
				_oexpui.SetObjectActive(value);
			}
		}
	}

	public float expFillamount
	{
		get
		{
			if (_oexpImage != null)
			{
				return _oexpImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (expFillamount != value && _oexpImage != null)
			{
				_oexpImage.fillAmount = value;
			}
		}
	}

	public string ysString
	{
		get
		{
			if (_oysText != null)
			{
				return _oysText.text;
			}
			return null;
		}
		set
		{
			if (ysString != value && _oysText != null)
			{
				_oysText.text = value;
			}
		}
	}

	public string tyString
	{
		get
		{
			if (_otyText != null)
			{
				return _otyText.text;
			}
			return null;
		}
		set
		{
			if (tyString != value && _otyText != null)
			{
				_otyText.text = value;
			}
		}
	}

	public string shString
	{
		get
		{
			if (_oshText != null)
			{
				return _oshText.text;
			}
			return null;
		}
		set
		{
			if (shString != value && _oshText != null)
			{
				_oshText.text = value;
			}
		}
	}

	public bool skillIconShow
	{
		get
		{
			if (_oskillIcon != null)
			{
				return _oskillIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillIconShow != value && _oskillIcon != null)
			{
				_oskillIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite skillIconSprite
	{
		get
		{
			if (_oskillIconImage != null)
			{
				return _oskillIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (skillIconSprite != value && _oskillIconImage != null)
			{
				_oskillIconImage.sprite = value;
			}
		}
	}

	public bool LevelUpEffectShow
	{
		get
		{
			if (_oLevelUpEffect != null)
			{
				return _oLevelUpEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LevelUpEffectShow != value && _oLevelUpEffect != null)
			{
				_oLevelUpEffect.SetObjectActive(value);
			}
		}
	}

	public float LeftAlpha
	{
		get
		{
			if (_oLeftCanvasGroup != null)
			{
				return _oLeftCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (LeftAlpha != value && _oLeftCanvasGroup != null)
			{
				_oLeftCanvasGroup.alpha = value;
			}
		}
	}

	public float RightAlpha
	{
		get
		{
			if (_oRightCanvasGroup != null)
			{
				return _oRightCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (RightAlpha != value && _oRightCanvasGroup != null)
			{
				_oRightCanvasGroup.alpha = value;
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
			case "btnIcon1":
				_obtnIcon1 = transform.gameObject;
				break;
			case "btnIcon2":
				_obtnIcon2 = transform.gameObject;
				break;
			case "btnIcon3":
				_obtnIcon3 = transform.gameObject;
				break;
			case "btnIcon4":
				_obtnIcon4 = transform.gameObject;
				break;
			case "btnIcon5":
				_obtnIcon5 = transform.gameObject;
				break;
			case "SkillCount":
				_oSkillCount = transform.gameObject;
				_oSkillCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "money":
				_omoney = transform.gameObject;
				_omoneyText = transform.gameObject.GetComponent<Text>();
				break;
			case "money_1":
				_omoney_1 = transform.gameObject;
				_omoney_Text1 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_2":
				_omoney_2 = transform.gameObject;
				_omoney_Text2 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_3":
				_omoney_3 = transform.gameObject;
				_omoney_Text3 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_4":
				_omoney_4 = transform.gameObject;
				_omoney_Text4 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup4 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_5":
				_omoney_5 = transform.gameObject;
				_omoney_Text5 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup5 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_6":
				_omoney_6 = transform.gameObject;
				_omoney_Text6 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup6 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_7":
				_omoney_7 = transform.gameObject;
				_omoney_Text7 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup7 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "money_8":
				_omoney_8 = transform.gameObject;
				_omoney_Text8 = transform.gameObject.GetComponent<Text>();
				_omoney_CanvasGroup8 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "playerSelect":
				_oplayerSelect = transform.gameObject;
				break;
			case "Playerbg1":
				_oPlayerbg1 = transform.gameObject;
				break;
			case "Playerbg2":
				_oPlayerbg2 = transform.gameObject;
				break;
			case "Playerbg3":
				_oPlayerbg3 = transform.gameObject;
				break;
			case "Playerbg4":
				_oPlayerbg4 = transform.gameObject;
				break;
			case "Playerbg5":
				_oPlayerbg5 = transform.gameObject;
				break;
			case "Playerbg6":
				_oPlayerbg6 = transform.gameObject;
				break;
			case "Playerbg7":
				_oPlayerbg7 = transform.gameObject;
				break;
			case "Playerbg8":
				_oPlayerbg8 = transform.gameObject;
				break;
			case "Playerbg9":
				_oPlayerbg9 = transform.gameObject;
				break;
			case "PlayerIcon1":
				_oPlayerIcon1 = transform.gameObject;
				_oPlayerIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon2":
				_oPlayerIcon2 = transform.gameObject;
				_oPlayerIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon3":
				_oPlayerIcon3 = transform.gameObject;
				_oPlayerIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon4":
				_oPlayerIcon4 = transform.gameObject;
				_oPlayerIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon5":
				_oPlayerIcon5 = transform.gameObject;
				_oPlayerIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon6":
				_oPlayerIcon6 = transform.gameObject;
				_oPlayerIconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon7":
				_oPlayerIcon7 = transform.gameObject;
				_oPlayerIconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon8":
				_oPlayerIcon8 = transform.gameObject;
				_oPlayerIconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerIcon9":
				_oPlayerIcon9 = transform.gameObject;
				_oPlayerIconImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "rbtn":
				_orbtn = transform.gameObject;
				break;
			case "lbtn":
				_olbtn = transform.gameObject;
				break;
			case "playerDes":
				_oplayerDes = transform.gameObject;
				_oplayerDesImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillDes":
				_oSkillDes = transform.gameObject;
				break;
			case "PIcon":
				_oPIcon = transform.gameObject;
				_oPIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Lv":
				_oLv = transform.gameObject;
				_oLvText = transform.gameObject.GetComponent<Text>();
				break;
			case "HP":
				_oHP = transform.gameObject;
				_oHPImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HD":
				_oHD = transform.gameObject;
				_oHDImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HP_2":
				_oHP_2 = transform.gameObject;
				_oHP_Text2 = transform.gameObject.GetComponent<Text>();
				break;
			case "expui":
				_oexpui = transform.gameObject;
				break;
			case "exp":
				_oexp = transform.gameObject;
				_oexpImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ys":
				_oys = transform.gameObject;
				_oysText = transform.gameObject.GetComponent<Text>();
				break;
			case "ty":
				_oty = transform.gameObject;
				_otyText = transform.gameObject.GetComponent<Text>();
				break;
			case "sh":
				_osh = transform.gameObject;
				_oshText = transform.gameObject.GetComponent<Text>();
				break;
			case "skillIcon":
				_oskillIcon = transform.gameObject;
				_oskillIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LevelUpEffect":
				_oLevelUpEffect = transform.gameObject;
				break;
			case "Left":
				_oLeft = transform.gameObject;
				_oLeftCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Right":
				_oRight = transform.gameObject;
				_oRightCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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

	public bool GetbtnIconShow(int index)
	{
		return index switch
		{
			1 => btnIconShow1, 
			2 => btnIconShow2, 
			3 => btnIconShow3, 
			4 => btnIconShow4, 
			5 => btnIconShow5, 
			_ => false, 
		};
	}

	public void SetbtnIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			btnIconShow1 = value;
			break;
		case 2:
			btnIconShow2 = value;
			break;
		case 3:
			btnIconShow3 = value;
			break;
		case 4:
			btnIconShow4 = value;
			break;
		case 5:
			btnIconShow5 = value;
			break;
		}
	}

	public int GetbtnIconCount()
	{
		return 5;
	}

	public GameObject Getmoney_Obj(int index)
	{
		return index switch
		{
			1 => money_Obj1, 
			2 => money_Obj2, 
			3 => money_Obj3, 
			4 => money_Obj4, 
			5 => money_Obj5, 
			6 => money_Obj6, 
			7 => money_Obj7, 
			8 => money_Obj8, 
			_ => null, 
		};
	}

	public int Getmoney_Count()
	{
		return 8;
	}

	public bool Getmoney_Show(int index)
	{
		return index switch
		{
			1 => money_Show1, 
			2 => money_Show2, 
			3 => money_Show3, 
			4 => money_Show4, 
			5 => money_Show5, 
			6 => money_Show6, 
			7 => money_Show7, 
			8 => money_Show8, 
			_ => false, 
		};
	}

	public void Setmoney_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			money_Show1 = value;
			break;
		case 2:
			money_Show2 = value;
			break;
		case 3:
			money_Show3 = value;
			break;
		case 4:
			money_Show4 = value;
			break;
		case 5:
			money_Show5 = value;
			break;
		case 6:
			money_Show6 = value;
			break;
		case 7:
			money_Show7 = value;
			break;
		case 8:
			money_Show8 = value;
			break;
		}
	}

	public string Getmoney_String(int index)
	{
		return index switch
		{
			1 => money_String1, 
			2 => money_String2, 
			3 => money_String3, 
			4 => money_String4, 
			5 => money_String5, 
			6 => money_String6, 
			7 => money_String7, 
			8 => money_String8, 
			_ => null, 
		};
	}

	public void Setmoney_String(int index, string value)
	{
		switch (index)
		{
		case 1:
			money_String1 = value;
			break;
		case 2:
			money_String2 = value;
			break;
		case 3:
			money_String3 = value;
			break;
		case 4:
			money_String4 = value;
			break;
		case 5:
			money_String5 = value;
			break;
		case 6:
			money_String6 = value;
			break;
		case 7:
			money_String7 = value;
			break;
		case 8:
			money_String8 = value;
			break;
		}
	}

	public float Getmoney_Alpha(int index)
	{
		return index switch
		{
			1 => money_Alpha1, 
			2 => money_Alpha2, 
			3 => money_Alpha3, 
			4 => money_Alpha4, 
			5 => money_Alpha5, 
			6 => money_Alpha6, 
			7 => money_Alpha7, 
			8 => money_Alpha8, 
			_ => 0f, 
		};
	}

	public void Setmoney_Alpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			money_Alpha1 = value;
			break;
		case 2:
			money_Alpha2 = value;
			break;
		case 3:
			money_Alpha3 = value;
			break;
		case 4:
			money_Alpha4 = value;
			break;
		case 5:
			money_Alpha5 = value;
			break;
		case 6:
			money_Alpha6 = value;
			break;
		case 7:
			money_Alpha7 = value;
			break;
		case 8:
			money_Alpha8 = value;
			break;
		}
	}

	public bool GetPlayerbgShow(int index)
	{
		return index switch
		{
			1 => PlayerbgShow1, 
			2 => PlayerbgShow2, 
			3 => PlayerbgShow3, 
			4 => PlayerbgShow4, 
			5 => PlayerbgShow5, 
			6 => PlayerbgShow6, 
			7 => PlayerbgShow7, 
			8 => PlayerbgShow8, 
			9 => PlayerbgShow9, 
			_ => false, 
		};
	}

	public void SetPlayerbgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerbgShow1 = value;
			break;
		case 2:
			PlayerbgShow2 = value;
			break;
		case 3:
			PlayerbgShow3 = value;
			break;
		case 4:
			PlayerbgShow4 = value;
			break;
		case 5:
			PlayerbgShow5 = value;
			break;
		case 6:
			PlayerbgShow6 = value;
			break;
		case 7:
			PlayerbgShow7 = value;
			break;
		case 8:
			PlayerbgShow8 = value;
			break;
		case 9:
			PlayerbgShow9 = value;
			break;
		}
	}

	public int GetPlayerbgCount()
	{
		return 9;
	}

	public Sprite GetPlayerIconSprite(int index)
	{
		return index switch
		{
			1 => PlayerIconSprite1, 
			2 => PlayerIconSprite2, 
			3 => PlayerIconSprite3, 
			4 => PlayerIconSprite4, 
			5 => PlayerIconSprite5, 
			6 => PlayerIconSprite6, 
			7 => PlayerIconSprite7, 
			8 => PlayerIconSprite8, 
			9 => PlayerIconSprite9, 
			_ => null, 
		};
	}

	public void SetPlayerIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PlayerIconSprite1 = value;
			break;
		case 2:
			PlayerIconSprite2 = value;
			break;
		case 3:
			PlayerIconSprite3 = value;
			break;
		case 4:
			PlayerIconSprite4 = value;
			break;
		case 5:
			PlayerIconSprite5 = value;
			break;
		case 6:
			PlayerIconSprite6 = value;
			break;
		case 7:
			PlayerIconSprite7 = value;
			break;
		case 8:
			PlayerIconSprite8 = value;
			break;
		case 9:
			PlayerIconSprite9 = value;
			break;
		}
	}

	public int GetPlayerIconCount()
	{
		return 9;
	}

	public string GetHP_String(int index)
	{
		if (index == 2)
		{
			return HP_String2;
		}
		return null;
	}

	public void SetHP_String(int index, string value)
	{
		if (index == 2)
		{
			HP_String2 = value;
		}
	}

	public int GetHP_Count()
	{
		return 2;
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
