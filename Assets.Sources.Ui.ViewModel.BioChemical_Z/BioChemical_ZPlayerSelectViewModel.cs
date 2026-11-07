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
public class BioChemical_ZPlayerSelectViewModel : ViewModelBase, IUiViewModel
{
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

	private GameObject _oLock1;

	private GameObject _oLock2;

	private GameObject _oLock3;

	private GameObject _oLock4;

	private GameObject _oLock5;

	private GameObject _oLock6;

	private GameObject _oLock7;

	private GameObject _oLock8;

	private GameObject _oLock9;

	private GameObject _oLv1;

	private GameObject _oLv2;

	private GameObject _oLv3;

	private GameObject _oLv4;

	private GameObject _oLv5;

	private GameObject _oLv6;

	private GameObject _oLv7;

	private GameObject _oLv8;

	private GameObject _oLv9;

	private Text _oLvText1;

	private Text _oLvText2;

	private Text _oLvText3;

	private Text _oLvText4;

	private Text _oLvText5;

	private Text _oLvText6;

	private Text _oLvText7;

	private Text _oLvText8;

	private Text _oLvText9;

	private GameObject _orbtn;

	private GameObject _olbtn;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zplayerselect";

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

	public Color PlayerIconColor1
	{
		get
		{
			if (_oPlayerIconImage1 != null)
			{
				return _oPlayerIconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor1 != value && _oPlayerIconImage1 != null)
			{
				_oPlayerIconImage1.color = value;
			}
		}
	}

	public Color PlayerIconColor2
	{
		get
		{
			if (_oPlayerIconImage2 != null)
			{
				return _oPlayerIconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor2 != value && _oPlayerIconImage2 != null)
			{
				_oPlayerIconImage2.color = value;
			}
		}
	}

	public Color PlayerIconColor3
	{
		get
		{
			if (_oPlayerIconImage3 != null)
			{
				return _oPlayerIconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor3 != value && _oPlayerIconImage3 != null)
			{
				_oPlayerIconImage3.color = value;
			}
		}
	}

	public Color PlayerIconColor4
	{
		get
		{
			if (_oPlayerIconImage4 != null)
			{
				return _oPlayerIconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor4 != value && _oPlayerIconImage4 != null)
			{
				_oPlayerIconImage4.color = value;
			}
		}
	}

	public Color PlayerIconColor5
	{
		get
		{
			if (_oPlayerIconImage5 != null)
			{
				return _oPlayerIconImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor5 != value && _oPlayerIconImage5 != null)
			{
				_oPlayerIconImage5.color = value;
			}
		}
	}

	public Color PlayerIconColor6
	{
		get
		{
			if (_oPlayerIconImage6 != null)
			{
				return _oPlayerIconImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor6 != value && _oPlayerIconImage6 != null)
			{
				_oPlayerIconImage6.color = value;
			}
		}
	}

	public Color PlayerIconColor7
	{
		get
		{
			if (_oPlayerIconImage7 != null)
			{
				return _oPlayerIconImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor7 != value && _oPlayerIconImage7 != null)
			{
				_oPlayerIconImage7.color = value;
			}
		}
	}

	public Color PlayerIconColor8
	{
		get
		{
			if (_oPlayerIconImage8 != null)
			{
				return _oPlayerIconImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor8 != value && _oPlayerIconImage8 != null)
			{
				_oPlayerIconImage8.color = value;
			}
		}
	}

	public Color PlayerIconColor9
	{
		get
		{
			if (_oPlayerIconImage9 != null)
			{
				return _oPlayerIconImage9.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerIconColor9 != value && _oPlayerIconImage9 != null)
			{
				_oPlayerIconImage9.color = value;
			}
		}
	}

	public bool LockShow1
	{
		get
		{
			if (_oLock1 != null)
			{
				return _oLock1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow1 != value && _oLock1 != null)
			{
				_oLock1.SetObjectActive(value);
			}
		}
	}

	public bool LockShow2
	{
		get
		{
			if (_oLock2 != null)
			{
				return _oLock2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow2 != value && _oLock2 != null)
			{
				_oLock2.SetObjectActive(value);
			}
		}
	}

	public bool LockShow3
	{
		get
		{
			if (_oLock3 != null)
			{
				return _oLock3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow3 != value && _oLock3 != null)
			{
				_oLock3.SetObjectActive(value);
			}
		}
	}

	public bool LockShow4
	{
		get
		{
			if (_oLock4 != null)
			{
				return _oLock4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow4 != value && _oLock4 != null)
			{
				_oLock4.SetObjectActive(value);
			}
		}
	}

	public bool LockShow5
	{
		get
		{
			if (_oLock5 != null)
			{
				return _oLock5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow5 != value && _oLock5 != null)
			{
				_oLock5.SetObjectActive(value);
			}
		}
	}

	public bool LockShow6
	{
		get
		{
			if (_oLock6 != null)
			{
				return _oLock6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow6 != value && _oLock6 != null)
			{
				_oLock6.SetObjectActive(value);
			}
		}
	}

	public bool LockShow7
	{
		get
		{
			if (_oLock7 != null)
			{
				return _oLock7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow7 != value && _oLock7 != null)
			{
				_oLock7.SetObjectActive(value);
			}
		}
	}

	public bool LockShow8
	{
		get
		{
			if (_oLock8 != null)
			{
				return _oLock8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow8 != value && _oLock8 != null)
			{
				_oLock8.SetObjectActive(value);
			}
		}
	}

	public bool LockShow9
	{
		get
		{
			if (_oLock9 != null)
			{
				return _oLock9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LockShow9 != value && _oLock9 != null)
			{
				_oLock9.SetObjectActive(value);
			}
		}
	}

	public string LvString1
	{
		get
		{
			if (_oLvText1 != null)
			{
				return _oLvText1.text;
			}
			return null;
		}
		set
		{
			if (LvString1 != value && _oLvText1 != null)
			{
				_oLvText1.text = value;
			}
		}
	}

	public string LvString2
	{
		get
		{
			if (_oLvText2 != null)
			{
				return _oLvText2.text;
			}
			return null;
		}
		set
		{
			if (LvString2 != value && _oLvText2 != null)
			{
				_oLvText2.text = value;
			}
		}
	}

	public string LvString3
	{
		get
		{
			if (_oLvText3 != null)
			{
				return _oLvText3.text;
			}
			return null;
		}
		set
		{
			if (LvString3 != value && _oLvText3 != null)
			{
				_oLvText3.text = value;
			}
		}
	}

	public string LvString4
	{
		get
		{
			if (_oLvText4 != null)
			{
				return _oLvText4.text;
			}
			return null;
		}
		set
		{
			if (LvString4 != value && _oLvText4 != null)
			{
				_oLvText4.text = value;
			}
		}
	}

	public string LvString5
	{
		get
		{
			if (_oLvText5 != null)
			{
				return _oLvText5.text;
			}
			return null;
		}
		set
		{
			if (LvString5 != value && _oLvText5 != null)
			{
				_oLvText5.text = value;
			}
		}
	}

	public string LvString6
	{
		get
		{
			if (_oLvText6 != null)
			{
				return _oLvText6.text;
			}
			return null;
		}
		set
		{
			if (LvString6 != value && _oLvText6 != null)
			{
				_oLvText6.text = value;
			}
		}
	}

	public string LvString7
	{
		get
		{
			if (_oLvText7 != null)
			{
				return _oLvText7.text;
			}
			return null;
		}
		set
		{
			if (LvString7 != value && _oLvText7 != null)
			{
				_oLvText7.text = value;
			}
		}
	}

	public string LvString8
	{
		get
		{
			if (_oLvText8 != null)
			{
				return _oLvText8.text;
			}
			return null;
		}
		set
		{
			if (LvString8 != value && _oLvText8 != null)
			{
				_oLvText8.text = value;
			}
		}
	}

	public string LvString9
	{
		get
		{
			if (_oLvText9 != null)
			{
				return _oLvText9.text;
			}
			return null;
		}
		set
		{
			if (LvString9 != value && _oLvText9 != null)
			{
				_oLvText9.text = value;
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
			case "Lock1":
				_oLock1 = transform.gameObject;
				break;
			case "Lock2":
				_oLock2 = transform.gameObject;
				break;
			case "Lock3":
				_oLock3 = transform.gameObject;
				break;
			case "Lock4":
				_oLock4 = transform.gameObject;
				break;
			case "Lock5":
				_oLock5 = transform.gameObject;
				break;
			case "Lock6":
				_oLock6 = transform.gameObject;
				break;
			case "Lock7":
				_oLock7 = transform.gameObject;
				break;
			case "Lock8":
				_oLock8 = transform.gameObject;
				break;
			case "Lock9":
				_oLock9 = transform.gameObject;
				break;
			case "Lv1":
				_oLv1 = transform.gameObject;
				_oLvText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv2":
				_oLv2 = transform.gameObject;
				_oLvText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv3":
				_oLv3 = transform.gameObject;
				_oLvText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv4":
				_oLv4 = transform.gameObject;
				_oLvText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv5":
				_oLv5 = transform.gameObject;
				_oLvText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv6":
				_oLv6 = transform.gameObject;
				_oLvText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv7":
				_oLv7 = transform.gameObject;
				_oLvText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv8":
				_oLv8 = transform.gameObject;
				_oLvText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv9":
				_oLv9 = transform.gameObject;
				_oLvText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "rbtn":
				_orbtn = transform.gameObject;
				break;
			case "lbtn":
				_olbtn = transform.gameObject;
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

	public Color GetPlayerIconColor(int index)
	{
		return index switch
		{
			1 => PlayerIconColor1, 
			2 => PlayerIconColor2, 
			3 => PlayerIconColor3, 
			4 => PlayerIconColor4, 
			5 => PlayerIconColor5, 
			6 => PlayerIconColor6, 
			7 => PlayerIconColor7, 
			8 => PlayerIconColor8, 
			9 => PlayerIconColor9, 
			_ => Color.white, 
		};
	}

	public void SetPlayerIconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			PlayerIconColor1 = value;
			break;
		case 2:
			PlayerIconColor2 = value;
			break;
		case 3:
			PlayerIconColor3 = value;
			break;
		case 4:
			PlayerIconColor4 = value;
			break;
		case 5:
			PlayerIconColor5 = value;
			break;
		case 6:
			PlayerIconColor6 = value;
			break;
		case 7:
			PlayerIconColor7 = value;
			break;
		case 8:
			PlayerIconColor8 = value;
			break;
		case 9:
			PlayerIconColor9 = value;
			break;
		}
	}

	public bool GetLockShow(int index)
	{
		return index switch
		{
			1 => LockShow1, 
			2 => LockShow2, 
			3 => LockShow3, 
			4 => LockShow4, 
			5 => LockShow5, 
			6 => LockShow6, 
			7 => LockShow7, 
			8 => LockShow8, 
			9 => LockShow9, 
			_ => false, 
		};
	}

	public void SetLockShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LockShow1 = value;
			break;
		case 2:
			LockShow2 = value;
			break;
		case 3:
			LockShow3 = value;
			break;
		case 4:
			LockShow4 = value;
			break;
		case 5:
			LockShow5 = value;
			break;
		case 6:
			LockShow6 = value;
			break;
		case 7:
			LockShow7 = value;
			break;
		case 8:
			LockShow8 = value;
			break;
		case 9:
			LockShow9 = value;
			break;
		}
	}

	public int GetLockCount()
	{
		return 9;
	}

	public string GetLvString(int index)
	{
		return index switch
		{
			1 => LvString1, 
			2 => LvString2, 
			3 => LvString3, 
			4 => LvString4, 
			5 => LvString5, 
			6 => LvString6, 
			7 => LvString7, 
			8 => LvString8, 
			9 => LvString9, 
			_ => null, 
		};
	}

	public void SetLvString(int index, string value)
	{
		switch (index)
		{
		case 1:
			LvString1 = value;
			break;
		case 2:
			LvString2 = value;
			break;
		case 3:
			LvString3 = value;
			break;
		case 4:
			LvString4 = value;
			break;
		case 5:
			LvString5 = value;
			break;
		case 6:
			LvString6 = value;
			break;
		case 7:
			LvString7 = value;
			break;
		case 8:
			LvString8 = value;
			break;
		case 9:
			LvString9 = value;
			break;
		}
	}

	public int GetLvCount()
	{
		return 9;
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
