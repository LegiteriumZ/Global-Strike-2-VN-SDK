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

namespace Assets.Sources.Ui.ViewModel.Rpg2022newyeadMode;

[GameUiTest]
public class Rpg2022NewYeadgLeftViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _obuff1;

	private GameObject _obuff2;

	private GameObject _obuff3;

	private GameObject _obuff4;

	private GameObject _obuff5;

	private GameObject _obufficon1;

	private GameObject _obufficon2;

	private GameObject _obufficon3;

	private GameObject _obufficon4;

	private GameObject _obufficon5;

	private Image _obufficonImage1;

	private Image _obufficonImage2;

	private Image _obufficonImage3;

	private Image _obufficonImage4;

	private Image _obufficonImage5;

	private GameObject _obuffsum1;

	private GameObject _obuffsum2;

	private GameObject _obuffsum3;

	private GameObject _obuffsum4;

	private GameObject _obuffsum5;

	private Text _obuffsumText1;

	private Text _obuffsumText2;

	private Text _obuffsumText3;

	private Text _obuffsumText4;

	private Text _obuffsumText5;

	private GameObject _oGame_Tip;

	private GameObject _ogame_message;

	private Image _ogame_messageImage;

	private GameObject _ojf1;

	private GameObject _ojf2;

	private Text _ojfText1;

	private Text _ojfText2;

	private GameObject _ob1;

	private GameObject _ob2;

	private GameObject _ob3;

	private GameObject _ob4;

	private GameObject _ob5;

	private GameObject _ob6;

	private GameObject _ob7;

	private Image _obImage1;

	private Image _obImage2;

	private Image _obImage3;

	private Image _obImage4;

	private Image _obImage5;

	private Image _obImage6;

	private Image _obImage7;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg2022newyeadmode";

	private string _resourceAssetName = "rpg2022newyeadgleft";

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

	public Image game_messageImage
	{
		get
		{
			if (_ogame_messageImage != null)
			{
				return _ogame_messageImage;
			}
			return null;
		}
		set
		{
			if (game_messageImage != value && _ogame_messageImage != null)
			{
				_ogame_messageImage = value;
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

	public bool bShow1
	{
		get
		{
			if (_ob1 != null)
			{
				return _ob1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow1 != value && _ob1 != null)
			{
				_ob1.SetObjectActive(value);
			}
		}
	}

	public bool bShow2
	{
		get
		{
			if (_ob2 != null)
			{
				return _ob2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow2 != value && _ob2 != null)
			{
				_ob2.SetObjectActive(value);
			}
		}
	}

	public bool bShow3
	{
		get
		{
			if (_ob3 != null)
			{
				return _ob3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow3 != value && _ob3 != null)
			{
				_ob3.SetObjectActive(value);
			}
		}
	}

	public bool bShow4
	{
		get
		{
			if (_ob4 != null)
			{
				return _ob4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow4 != value && _ob4 != null)
			{
				_ob4.SetObjectActive(value);
			}
		}
	}

	public bool bShow5
	{
		get
		{
			if (_ob5 != null)
			{
				return _ob5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow5 != value && _ob5 != null)
			{
				_ob5.SetObjectActive(value);
			}
		}
	}

	public bool bShow6
	{
		get
		{
			if (_ob6 != null)
			{
				return _ob6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow6 != value && _ob6 != null)
			{
				_ob6.SetObjectActive(value);
			}
		}
	}

	public bool bShow7
	{
		get
		{
			if (_ob7 != null)
			{
				return _ob7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bShow7 != value && _ob7 != null)
			{
				_ob7.SetObjectActive(value);
			}
		}
	}

	public Sprite bSprite1
	{
		get
		{
			if (_obImage1 != null)
			{
				return _obImage1.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite1 != value && _obImage1 != null)
			{
				_obImage1.sprite = value;
			}
		}
	}

	public Sprite bSprite2
	{
		get
		{
			if (_obImage2 != null)
			{
				return _obImage2.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite2 != value && _obImage2 != null)
			{
				_obImage2.sprite = value;
			}
		}
	}

	public Sprite bSprite3
	{
		get
		{
			if (_obImage3 != null)
			{
				return _obImage3.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite3 != value && _obImage3 != null)
			{
				_obImage3.sprite = value;
			}
		}
	}

	public Sprite bSprite4
	{
		get
		{
			if (_obImage4 != null)
			{
				return _obImage4.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite4 != value && _obImage4 != null)
			{
				_obImage4.sprite = value;
			}
		}
	}

	public Sprite bSprite5
	{
		get
		{
			if (_obImage5 != null)
			{
				return _obImage5.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite5 != value && _obImage5 != null)
			{
				_obImage5.sprite = value;
			}
		}
	}

	public Sprite bSprite6
	{
		get
		{
			if (_obImage6 != null)
			{
				return _obImage6.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite6 != value && _obImage6 != null)
			{
				_obImage6.sprite = value;
			}
		}
	}

	public Sprite bSprite7
	{
		get
		{
			if (_obImage7 != null)
			{
				return _obImage7.sprite;
			}
			return null;
		}
		set
		{
			if (bSprite7 != value && _obImage7 != null)
			{
				_obImage7.sprite = value;
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
			case "Game_Tip":
				_oGame_Tip = transform.gameObject;
				break;
			case "game_message":
				_ogame_message = transform.gameObject;
				_ogame_messageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "jf1":
				_ojf1 = transform.gameObject;
				_ojfText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "jf2":
				_ojf2 = transform.gameObject;
				_ojfText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "b1":
				_ob1 = transform.gameObject;
				_obImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "b2":
				_ob2 = transform.gameObject;
				_obImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "b3":
				_ob3 = transform.gameObject;
				_obImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "b4":
				_ob4 = transform.gameObject;
				_obImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "b5":
				_ob5 = transform.gameObject;
				_obImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "b6":
				_ob6 = transform.gameObject;
				_obImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "b7":
				_ob7 = transform.gameObject;
				_obImage7 = transform.gameObject.GetComponent<Image>();
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
		}
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
		}
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
		}
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

	public bool GetbShow(int index)
	{
		return index switch
		{
			1 => bShow1, 
			2 => bShow2, 
			3 => bShow3, 
			4 => bShow4, 
			5 => bShow5, 
			6 => bShow6, 
			7 => bShow7, 
			_ => false, 
		};
	}

	public void SetbShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			bShow1 = value;
			break;
		case 2:
			bShow2 = value;
			break;
		case 3:
			bShow3 = value;
			break;
		case 4:
			bShow4 = value;
			break;
		case 5:
			bShow5 = value;
			break;
		case 6:
			bShow6 = value;
			break;
		case 7:
			bShow7 = value;
			break;
		}
	}

	public Sprite GetbSprite(int index)
	{
		return index switch
		{
			1 => bSprite1, 
			2 => bSprite2, 
			3 => bSprite3, 
			4 => bSprite4, 
			5 => bSprite5, 
			6 => bSprite6, 
			7 => bSprite7, 
			_ => null, 
		};
	}

	public void SetbSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			bSprite1 = value;
			break;
		case 2:
			bSprite2 = value;
			break;
		case 3:
			bSprite3 = value;
			break;
		case 4:
			bSprite4 = value;
			break;
		case 5:
			bSprite5 = value;
			break;
		case 6:
			bSprite6 = value;
			break;
		case 7:
			bSprite7 = value;
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
