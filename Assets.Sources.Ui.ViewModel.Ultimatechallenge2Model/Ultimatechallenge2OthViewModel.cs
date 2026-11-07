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

namespace Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2OthViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _osafeRate_progress;

	private Image _osafeRate_progressImage;

	private GameObject _osafeRate_progress_player;

	private Slider _osafeRate_progress_playerSlider;

	private GameObject _oairJumpInfo;

	private GameObject _oparachute_speed;

	private Text _oparachute_speedText;

	private GameObject _odaojishi;

	private GameObject _odaojishi_f;

	private Text _odaojishi_fText;

	private GameObject _odaojishi_m;

	private Text _odaojishi_mText;

	private GameObject _o_Number_roomInfo_FreeUI_FreeCanvas_;

	private Text _o_Number_roomInfo_FreeUI_FreeCanvas_Text;

	private GameObject _o_Number_killNum_FreeUI_FreeCanvas_;

	private Text _o_Number_killNum_FreeUI_FreeCanvas_Text;

	private GameObject _oskill_Icon1;

	private GameObject _oskill_Icon2;

	private Image _oskill_IconImage1;

	private Image _oskill_IconImage2;

	private GameObject _oskill_cd1;

	private GameObject _oskill_cd2;

	private Image _oskill_cdImage1;

	private Image _oskill_cdImage2;

	private GameObject _odirectionImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge2model";

	private string _resourceAssetName = "ultimatechallenge2oth";

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

	public float safeRate_progressFillamount
	{
		get
		{
			if (_osafeRate_progressImage != null)
			{
				return _osafeRate_progressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (safeRate_progressFillamount != value && _osafeRate_progressImage != null)
			{
				_osafeRate_progressImage.fillAmount = value;
			}
		}
	}

	public float safeRate_progress_playerSlidervalue
	{
		get
		{
			if (_osafeRate_progress_playerSlider != null)
			{
				return _osafeRate_progress_playerSlider.value;
			}
			return 0f;
		}
		set
		{
			if (safeRate_progress_playerSlidervalue != value && _osafeRate_progress_playerSlider != null)
			{
				_osafeRate_progress_playerSlider.value = value;
			}
		}
	}

	public bool airJumpInfoShow
	{
		get
		{
			if (_oairJumpInfo != null)
			{
				return _oairJumpInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (airJumpInfoShow != value && _oairJumpInfo != null)
			{
				_oairJumpInfo.SetObjectActive(value);
			}
		}
	}

	public string parachute_speedString
	{
		get
		{
			if (_oparachute_speedText != null)
			{
				return _oparachute_speedText.text;
			}
			return null;
		}
		set
		{
			if (parachute_speedString != value && _oparachute_speedText != null)
			{
				_oparachute_speedText.text = value;
			}
		}
	}

	public bool daojishiShow
	{
		get
		{
			if (_odaojishi != null)
			{
				return _odaojishi.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (daojishiShow != value && _odaojishi != null)
			{
				_odaojishi.SetObjectActive(value);
			}
		}
	}

	public string daojishi_fString
	{
		get
		{
			if (_odaojishi_fText != null)
			{
				return _odaojishi_fText.text;
			}
			return null;
		}
		set
		{
			if (daojishi_fString != value && _odaojishi_fText != null)
			{
				_odaojishi_fText.text = value;
			}
		}
	}

	public string daojishi_mString
	{
		get
		{
			if (_odaojishi_mText != null)
			{
				return _odaojishi_mText.text;
			}
			return null;
		}
		set
		{
			if (daojishi_mString != value && _odaojishi_mText != null)
			{
				_odaojishi_mText.text = value;
			}
		}
	}

	public string _Number_roomInfo_FreeUI_FreeCanvas_String
	{
		get
		{
			if (_o_Number_roomInfo_FreeUI_FreeCanvas_Text != null)
			{
				return _o_Number_roomInfo_FreeUI_FreeCanvas_Text.text;
			}
			return null;
		}
		set
		{
			if (_Number_roomInfo_FreeUI_FreeCanvas_String != value && _o_Number_roomInfo_FreeUI_FreeCanvas_Text != null)
			{
				_o_Number_roomInfo_FreeUI_FreeCanvas_Text.text = value;
			}
		}
	}

	public string _Number_killNum_FreeUI_FreeCanvas_String
	{
		get
		{
			if (_o_Number_killNum_FreeUI_FreeCanvas_Text != null)
			{
				return _o_Number_killNum_FreeUI_FreeCanvas_Text.text;
			}
			return null;
		}
		set
		{
			if (_Number_killNum_FreeUI_FreeCanvas_String != value && _o_Number_killNum_FreeUI_FreeCanvas_Text != null)
			{
				_o_Number_killNum_FreeUI_FreeCanvas_Text.text = value;
			}
		}
	}

	public Sprite skill_IconSprite1
	{
		get
		{
			if (_oskill_IconImage1 != null)
			{
				return _oskill_IconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skill_IconSprite1 != value && _oskill_IconImage1 != null)
			{
				_oskill_IconImage1.sprite = value;
			}
		}
	}

	public Sprite skill_IconSprite2
	{
		get
		{
			if (_oskill_IconImage2 != null)
			{
				return _oskill_IconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skill_IconSprite2 != value && _oskill_IconImage2 != null)
			{
				_oskill_IconImage2.sprite = value;
			}
		}
	}

	public float skill_cdFillamount1
	{
		get
		{
			if (_oskill_cdImage1 != null)
			{
				return _oskill_cdImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (skill_cdFillamount1 != value && _oskill_cdImage1 != null)
			{
				_oskill_cdImage1.fillAmount = value;
			}
		}
	}

	public float skill_cdFillamount2
	{
		get
		{
			if (_oskill_cdImage2 != null)
			{
				return _oskill_cdImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (skill_cdFillamount2 != value && _oskill_cdImage2 != null)
			{
				_oskill_cdImage2.fillAmount = value;
			}
		}
	}

	public GameObject directionImageObj => _odirectionImage;

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
			case "safeRate_progress":
				_osafeRate_progress = transform.gameObject;
				_osafeRate_progressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "safeRate_progress_player":
				_osafeRate_progress_player = transform.gameObject;
				_osafeRate_progress_playerSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "airJumpInfo":
				_oairJumpInfo = transform.gameObject;
				break;
			case "parachute_speed":
				_oparachute_speed = transform.gameObject;
				_oparachute_speedText = transform.gameObject.GetComponent<Text>();
				break;
			case "daojishi":
				_odaojishi = transform.gameObject;
				break;
			case "daojishi_f":
				_odaojishi_f = transform.gameObject;
				_odaojishi_fText = transform.gameObject.GetComponent<Text>();
				break;
			case "daojishi_m":
				_odaojishi_m = transform.gameObject;
				_odaojishi_mText = transform.gameObject.GetComponent<Text>();
				break;
			case "_Number_roomInfo_FreeUI_FreeCanvas_":
				_o_Number_roomInfo_FreeUI_FreeCanvas_ = transform.gameObject;
				_o_Number_roomInfo_FreeUI_FreeCanvas_Text = transform.gameObject.GetComponent<Text>();
				break;
			case "_Number_killNum_FreeUI_FreeCanvas_":
				_o_Number_killNum_FreeUI_FreeCanvas_ = transform.gameObject;
				_o_Number_killNum_FreeUI_FreeCanvas_Text = transform.gameObject.GetComponent<Text>();
				break;
			case "skill_Icon1":
				_oskill_Icon1 = transform.gameObject;
				_oskill_IconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skill_Icon2":
				_oskill_Icon2 = transform.gameObject;
				_oskill_IconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "skill_cd1":
				_oskill_cd1 = transform.gameObject;
				_oskill_cdImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skill_cd2":
				_oskill_cd2 = transform.gameObject;
				_oskill_cdImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "directionImage":
				_odirectionImage = transform.gameObject;
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

	public Sprite Getskill_IconSprite(int index)
	{
		return index switch
		{
			1 => skill_IconSprite1, 
			2 => skill_IconSprite2, 
			_ => null, 
		};
	}

	public void Setskill_IconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skill_IconSprite1 = value;
			break;
		case 2:
			skill_IconSprite2 = value;
			break;
		}
	}

	public int Getskill_IconCount()
	{
		return 2;
	}

	public float Getskill_cdFillamount(int index)
	{
		return index switch
		{
			1 => skill_cdFillamount1, 
			2 => skill_cdFillamount2, 
			_ => 0f, 
		};
	}

	public void Setskill_cdFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			skill_cdFillamount1 = value;
			break;
		case 2:
			skill_cdFillamount2 = value;
			break;
		}
	}

	public int Getskill_cdCount()
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
