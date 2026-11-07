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

namespace Assets.Sources.Ui.ViewModel.HerofightingModel;

[GameUiTest]
public class HeroFightingLeftViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _obuff1;

	private GameObject _obuff2;

	private GameObject _obuff3;

	private GameObject _obuff4;

	private GameObject _obuff5;

	private GameObject _obuff6;

	private GameObject _obuff7;

	private GameObject _obuff8;

	private GameObject _obuff9;

	private GameObject _obuff10;

	private GameObject _obufficon1;

	private GameObject _obufficon2;

	private GameObject _obufficon3;

	private GameObject _obufficon4;

	private GameObject _obufficon5;

	private GameObject _obufficon6;

	private GameObject _obufficon7;

	private GameObject _obufficon8;

	private GameObject _obufficon9;

	private GameObject _obufficon10;

	private Image _obufficonImage1;

	private Image _obufficonImage2;

	private Image _obufficonImage3;

	private Image _obufficonImage4;

	private Image _obufficonImage5;

	private Image _obufficonImage6;

	private Image _obufficonImage7;

	private Image _obufficonImage8;

	private Image _obufficonImage9;

	private Image _obufficonImage10;

	private GameObject _obuffsum1;

	private GameObject _obuffsum2;

	private GameObject _obuffsum3;

	private GameObject _obuffsum4;

	private GameObject _obuffsum5;

	private GameObject _obuffsum6;

	private GameObject _obuffsum7;

	private GameObject _obuffsum8;

	private GameObject _obuffsum9;

	private GameObject _obuffsum10;

	private Text _obuffsumText1;

	private Text _obuffsumText2;

	private Text _obuffsumText3;

	private Text _obuffsumText4;

	private Text _obuffsumText5;

	private Text _obuffsumText6;

	private Text _obuffsumText7;

	private Text _obuffsumText8;

	private Text _obuffsumText9;

	private Text _obuffsumText10;

	private GameObject _oGame_Tip;

	private GameObject _ogame_message;

	private Image _ogame_messageImage;

	private GameObject _oPanel_Tip;

	private GameObject _omessage;

	private Image _omessageImage;

	private GameObject _oPanel_jifeng;

	private GameObject _ojf1;

	private GameObject _ojf2;

	private Text _ojfText1;

	private Text _ojfText2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/herofightingmodel";

	private string _resourceAssetName = "herofightingleft";

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

	public bool buffShow1
	{
		get
		{
			if (_obuff1 != null)
			{
				return _obuff1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow1 != value && _obuff1 != null)
			{
				_obuff1.SetObjectActive(value);
			}
		}
	}

	public bool buffShow2
	{
		get
		{
			if (_obuff2 != null)
			{
				return _obuff2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow2 != value && _obuff2 != null)
			{
				_obuff2.SetObjectActive(value);
			}
		}
	}

	public bool buffShow3
	{
		get
		{
			if (_obuff3 != null)
			{
				return _obuff3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow3 != value && _obuff3 != null)
			{
				_obuff3.SetObjectActive(value);
			}
		}
	}

	public bool buffShow4
	{
		get
		{
			if (_obuff4 != null)
			{
				return _obuff4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow4 != value && _obuff4 != null)
			{
				_obuff4.SetObjectActive(value);
			}
		}
	}

	public bool buffShow5
	{
		get
		{
			if (_obuff5 != null)
			{
				return _obuff5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow5 != value && _obuff5 != null)
			{
				_obuff5.SetObjectActive(value);
			}
		}
	}

	public bool buffShow6
	{
		get
		{
			if (_obuff6 != null)
			{
				return _obuff6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow6 != value && _obuff6 != null)
			{
				_obuff6.SetObjectActive(value);
			}
		}
	}

	public bool buffShow7
	{
		get
		{
			if (_obuff7 != null)
			{
				return _obuff7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow7 != value && _obuff7 != null)
			{
				_obuff7.SetObjectActive(value);
			}
		}
	}

	public bool buffShow8
	{
		get
		{
			if (_obuff8 != null)
			{
				return _obuff8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow8 != value && _obuff8 != null)
			{
				_obuff8.SetObjectActive(value);
			}
		}
	}

	public bool buffShow9
	{
		get
		{
			if (_obuff9 != null)
			{
				return _obuff9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow9 != value && _obuff9 != null)
			{
				_obuff9.SetObjectActive(value);
			}
		}
	}

	public bool buffShow10
	{
		get
		{
			if (_obuff10 != null)
			{
				return _obuff10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (buffShow10 != value && _obuff10 != null)
			{
				_obuff10.SetObjectActive(value);
			}
		}
	}

	public Sprite bufficonSprite1
	{
		get
		{
			if (_obufficonImage1 != null)
			{
				return _obufficonImage1.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite1 != value && _obufficonImage1 != null)
			{
				_obufficonImage1.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite2
	{
		get
		{
			if (_obufficonImage2 != null)
			{
				return _obufficonImage2.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite2 != value && _obufficonImage2 != null)
			{
				_obufficonImage2.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite3
	{
		get
		{
			if (_obufficonImage3 != null)
			{
				return _obufficonImage3.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite3 != value && _obufficonImage3 != null)
			{
				_obufficonImage3.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite4
	{
		get
		{
			if (_obufficonImage4 != null)
			{
				return _obufficonImage4.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite4 != value && _obufficonImage4 != null)
			{
				_obufficonImage4.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite5
	{
		get
		{
			if (_obufficonImage5 != null)
			{
				return _obufficonImage5.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite5 != value && _obufficonImage5 != null)
			{
				_obufficonImage5.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite6
	{
		get
		{
			if (_obufficonImage6 != null)
			{
				return _obufficonImage6.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite6 != value && _obufficonImage6 != null)
			{
				_obufficonImage6.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite7
	{
		get
		{
			if (_obufficonImage7 != null)
			{
				return _obufficonImage7.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite7 != value && _obufficonImage7 != null)
			{
				_obufficonImage7.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite8
	{
		get
		{
			if (_obufficonImage8 != null)
			{
				return _obufficonImage8.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite8 != value && _obufficonImage8 != null)
			{
				_obufficonImage8.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite9
	{
		get
		{
			if (_obufficonImage9 != null)
			{
				return _obufficonImage9.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite9 != value && _obufficonImage9 != null)
			{
				_obufficonImage9.sprite = value;
			}
		}
	}

	public Sprite bufficonSprite10
	{
		get
		{
			if (_obufficonImage10 != null)
			{
				return _obufficonImage10.sprite;
			}
			return null;
		}
		set
		{
			if (bufficonSprite10 != value && _obufficonImage10 != null)
			{
				_obufficonImage10.sprite = value;
			}
		}
	}

	public string buffsumString1
	{
		get
		{
			if (_obuffsumText1 != null)
			{
				return _obuffsumText1.text;
			}
			return null;
		}
		set
		{
			if (buffsumString1 != value && _obuffsumText1 != null)
			{
				_obuffsumText1.text = value;
			}
		}
	}

	public string buffsumString2
	{
		get
		{
			if (_obuffsumText2 != null)
			{
				return _obuffsumText2.text;
			}
			return null;
		}
		set
		{
			if (buffsumString2 != value && _obuffsumText2 != null)
			{
				_obuffsumText2.text = value;
			}
		}
	}

	public string buffsumString3
	{
		get
		{
			if (_obuffsumText3 != null)
			{
				return _obuffsumText3.text;
			}
			return null;
		}
		set
		{
			if (buffsumString3 != value && _obuffsumText3 != null)
			{
				_obuffsumText3.text = value;
			}
		}
	}

	public string buffsumString4
	{
		get
		{
			if (_obuffsumText4 != null)
			{
				return _obuffsumText4.text;
			}
			return null;
		}
		set
		{
			if (buffsumString4 != value && _obuffsumText4 != null)
			{
				_obuffsumText4.text = value;
			}
		}
	}

	public string buffsumString5
	{
		get
		{
			if (_obuffsumText5 != null)
			{
				return _obuffsumText5.text;
			}
			return null;
		}
		set
		{
			if (buffsumString5 != value && _obuffsumText5 != null)
			{
				_obuffsumText5.text = value;
			}
		}
	}

	public string buffsumString6
	{
		get
		{
			if (_obuffsumText6 != null)
			{
				return _obuffsumText6.text;
			}
			return null;
		}
		set
		{
			if (buffsumString6 != value && _obuffsumText6 != null)
			{
				_obuffsumText6.text = value;
			}
		}
	}

	public string buffsumString7
	{
		get
		{
			if (_obuffsumText7 != null)
			{
				return _obuffsumText7.text;
			}
			return null;
		}
		set
		{
			if (buffsumString7 != value && _obuffsumText7 != null)
			{
				_obuffsumText7.text = value;
			}
		}
	}

	public string buffsumString8
	{
		get
		{
			if (_obuffsumText8 != null)
			{
				return _obuffsumText8.text;
			}
			return null;
		}
		set
		{
			if (buffsumString8 != value && _obuffsumText8 != null)
			{
				_obuffsumText8.text = value;
			}
		}
	}

	public string buffsumString9
	{
		get
		{
			if (_obuffsumText9 != null)
			{
				return _obuffsumText9.text;
			}
			return null;
		}
		set
		{
			if (buffsumString9 != value && _obuffsumText9 != null)
			{
				_obuffsumText9.text = value;
			}
		}
	}

	public string buffsumString10
	{
		get
		{
			if (_obuffsumText10 != null)
			{
				return _obuffsumText10.text;
			}
			return null;
		}
		set
		{
			if (buffsumString10 != value && _obuffsumText10 != null)
			{
				_obuffsumText10.text = value;
			}
		}
	}

	public bool Game_TipShow
	{
		get
		{
			if (_oGame_Tip != null)
			{
				return _oGame_Tip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Game_TipShow != value && _oGame_Tip != null)
			{
				_oGame_Tip.SetObjectActive(value);
			}
		}
	}

	public Sprite game_messageSprite
	{
		get
		{
			if (_ogame_messageImage != null)
			{
				return _ogame_messageImage.sprite;
			}
			return null;
		}
		set
		{
			if (game_messageSprite != value && _ogame_messageImage != null)
			{
				_ogame_messageImage.sprite = value;
			}
		}
	}

	public bool Panel_TipShow
	{
		get
		{
			if (_oPanel_Tip != null)
			{
				return _oPanel_Tip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Panel_TipShow != value && _oPanel_Tip != null)
			{
				_oPanel_Tip.SetObjectActive(value);
			}
		}
	}

	public Sprite messageSprite
	{
		get
		{
			if (_omessageImage != null)
			{
				return _omessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (messageSprite != value && _omessageImage != null)
			{
				_omessageImage.sprite = value;
			}
		}
	}

	public Image messageImage
	{
		get
		{
			if (_omessageImage != null)
			{
				return _omessageImage;
			}
			return null;
		}
		set
		{
			if (messageImage != value && _omessageImage != null)
			{
				_omessageImage = value;
			}
		}
	}

	public bool Panel_jifengShow
	{
		get
		{
			if (_oPanel_jifeng != null)
			{
				return _oPanel_jifeng.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Panel_jifengShow != value && _oPanel_jifeng != null)
			{
				_oPanel_jifeng.SetObjectActive(value);
			}
		}
	}

	public string jfString1
	{
		get
		{
			if (_ojfText1 != null)
			{
				return _ojfText1.text;
			}
			return null;
		}
		set
		{
			if (jfString1 != value && _ojfText1 != null)
			{
				_ojfText1.text = value;
			}
		}
	}

	public string jfString2
	{
		get
		{
			if (_ojfText2 != null)
			{
				return _ojfText2.text;
			}
			return null;
		}
		set
		{
			if (jfString2 != value && _ojfText2 != null)
			{
				_ojfText2.text = value;
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
			case "buff1":
				_obuff1 = transform.gameObject;
				break;
			case "buff2":
				_obuff2 = transform.gameObject;
				break;
			case "buff3":
				_obuff3 = transform.gameObject;
				break;
			case "buff4":
				_obuff4 = transform.gameObject;
				break;
			case "buff5":
				_obuff5 = transform.gameObject;
				break;
			case "buff6":
				_obuff6 = transform.gameObject;
				break;
			case "buff7":
				_obuff7 = transform.gameObject;
				break;
			case "buff8":
				_obuff8 = transform.gameObject;
				break;
			case "buff9":
				_obuff9 = transform.gameObject;
				break;
			case "buff10":
				_obuff10 = transform.gameObject;
				break;
			case "bufficon1":
				_obufficon1 = transform.gameObject;
				_obufficonImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon2":
				_obufficon2 = transform.gameObject;
				_obufficonImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon3":
				_obufficon3 = transform.gameObject;
				_obufficonImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon4":
				_obufficon4 = transform.gameObject;
				_obufficonImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon5":
				_obufficon5 = transform.gameObject;
				_obufficonImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon6":
				_obufficon6 = transform.gameObject;
				_obufficonImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon7":
				_obufficon7 = transform.gameObject;
				_obufficonImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon8":
				_obufficon8 = transform.gameObject;
				_obufficonImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon9":
				_obufficon9 = transform.gameObject;
				_obufficonImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "bufficon10":
				_obufficon10 = transform.gameObject;
				_obufficonImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "buffsum1":
				_obuffsum1 = transform.gameObject;
				_obuffsumText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum2":
				_obuffsum2 = transform.gameObject;
				_obuffsumText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum3":
				_obuffsum3 = transform.gameObject;
				_obuffsumText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum4":
				_obuffsum4 = transform.gameObject;
				_obuffsumText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum5":
				_obuffsum5 = transform.gameObject;
				_obuffsumText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum6":
				_obuffsum6 = transform.gameObject;
				_obuffsumText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum7":
				_obuffsum7 = transform.gameObject;
				_obuffsumText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum8":
				_obuffsum8 = transform.gameObject;
				_obuffsumText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum9":
				_obuffsum9 = transform.gameObject;
				_obuffsumText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "buffsum10":
				_obuffsum10 = transform.gameObject;
				_obuffsumText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "Game_Tip":
				_oGame_Tip = transform.gameObject;
				break;
			case "game_message":
				_ogame_message = transform.gameObject;
				_ogame_messageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Panel_Tip":
				_oPanel_Tip = transform.gameObject;
				break;
			case "message":
				_omessage = transform.gameObject;
				_omessageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Panel_jifeng":
				_oPanel_jifeng = transform.gameObject;
				break;
			case "jf1":
				_ojf1 = transform.gameObject;
				_ojfText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "jf2":
				_ojf2 = transform.gameObject;
				_ojfText2 = transform.gameObject.GetComponent<Text>();
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

	public bool GetbuffShow(int index)
	{
		return index switch
		{
			1 => buffShow1, 
			2 => buffShow2, 
			3 => buffShow3, 
			4 => buffShow4, 
			5 => buffShow5, 
			6 => buffShow6, 
			7 => buffShow7, 
			8 => buffShow8, 
			9 => buffShow9, 
			10 => buffShow10, 
			_ => false, 
		};
	}

	public void SetbuffShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			buffShow1 = value;
			break;
		case 2:
			buffShow2 = value;
			break;
		case 3:
			buffShow3 = value;
			break;
		case 4:
			buffShow4 = value;
			break;
		case 5:
			buffShow5 = value;
			break;
		case 6:
			buffShow6 = value;
			break;
		case 7:
			buffShow7 = value;
			break;
		case 8:
			buffShow8 = value;
			break;
		case 9:
			buffShow9 = value;
			break;
		case 10:
			buffShow10 = value;
			break;
		}
	}

	public int GetbuffCount()
	{
		return 10;
	}

	public Sprite GetbufficonSprite(int index)
	{
		return index switch
		{
			1 => bufficonSprite1, 
			2 => bufficonSprite2, 
			3 => bufficonSprite3, 
			4 => bufficonSprite4, 
			5 => bufficonSprite5, 
			6 => bufficonSprite6, 
			7 => bufficonSprite7, 
			8 => bufficonSprite8, 
			9 => bufficonSprite9, 
			10 => bufficonSprite10, 
			_ => null, 
		};
	}

	public void SetbufficonSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			bufficonSprite1 = value;
			break;
		case 2:
			bufficonSprite2 = value;
			break;
		case 3:
			bufficonSprite3 = value;
			break;
		case 4:
			bufficonSprite4 = value;
			break;
		case 5:
			bufficonSprite5 = value;
			break;
		case 6:
			bufficonSprite6 = value;
			break;
		case 7:
			bufficonSprite7 = value;
			break;
		case 8:
			bufficonSprite8 = value;
			break;
		case 9:
			bufficonSprite9 = value;
			break;
		case 10:
			bufficonSprite10 = value;
			break;
		}
	}

	public int GetbufficonCount()
	{
		return 10;
	}

	public string GetbuffsumString(int index)
	{
		return index switch
		{
			1 => buffsumString1, 
			2 => buffsumString2, 
			3 => buffsumString3, 
			4 => buffsumString4, 
			5 => buffsumString5, 
			6 => buffsumString6, 
			7 => buffsumString7, 
			8 => buffsumString8, 
			9 => buffsumString9, 
			10 => buffsumString10, 
			_ => null, 
		};
	}

	public void SetbuffsumString(int index, string value)
	{
		switch (index)
		{
		case 1:
			buffsumString1 = value;
			break;
		case 2:
			buffsumString2 = value;
			break;
		case 3:
			buffsumString3 = value;
			break;
		case 4:
			buffsumString4 = value;
			break;
		case 5:
			buffsumString5 = value;
			break;
		case 6:
			buffsumString6 = value;
			break;
		case 7:
			buffsumString7 = value;
			break;
		case 8:
			buffsumString8 = value;
			break;
		case 9:
			buffsumString9 = value;
			break;
		case 10:
			buffsumString10 = value;
			break;
		}
	}

	public int GetbuffsumCount()
	{
		return 10;
	}

	public string GetjfString(int index)
	{
		return index switch
		{
			1 => jfString1, 
			2 => jfString2, 
			_ => null, 
		};
	}

	public void SetjfString(int index, string value)
	{
		switch (index)
		{
		case 1:
			jfString1 = value;
			break;
		case 2:
			jfString2 = value;
			break;
		}
	}

	public int GetjfCount()
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
