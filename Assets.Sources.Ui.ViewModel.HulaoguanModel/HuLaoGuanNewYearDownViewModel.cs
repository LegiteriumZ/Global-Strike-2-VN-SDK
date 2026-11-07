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

namespace Assets.Sources.Ui.ViewModel.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearDownViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSkill1;

	private GameObject _oSkill2;

	private GameObject _oicon1;

	private GameObject _oicon2;

	private Image _oiconImage1;

	private Image _oiconImage2;

	private GameObject _ocd1;

	private GameObject _ocd2;

	private Image _ocdImage1;

	private Image _ocdImage2;

	private GameObject _oeffect1;

	private GameObject _oeffect2;

	private Image _oeffectImage1;

	private Image _oeffectImage2;

	private GameObject _okjj1;

	private GameObject _okjj2;

	private Text _okjjText1;

	private Text _okjjText2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguannewyeardown";

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

	public bool SkillShow1
	{
		get
		{
			if (_oSkill1 != null)
			{
				return _oSkill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow1 != value && _oSkill1 != null)
			{
				_oSkill1.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow2
	{
		get
		{
			if (_oSkill2 != null)
			{
				return _oSkill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow2 != value && _oSkill2 != null)
			{
				_oSkill2.SetObjectActive(value);
			}
		}
	}

	public Sprite iconSprite1
	{
		get
		{
			if (_oiconImage1 != null)
			{
				return _oiconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (iconSprite1 != value && _oiconImage1 != null)
			{
				_oiconImage1.sprite = value;
			}
		}
	}

	public Sprite iconSprite2
	{
		get
		{
			if (_oiconImage2 != null)
			{
				return _oiconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (iconSprite2 != value && _oiconImage2 != null)
			{
				_oiconImage2.sprite = value;
			}
		}
	}

	public float cdFillamount1
	{
		get
		{
			if (_ocdImage1 != null)
			{
				return _ocdImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (cdFillamount1 != value && _ocdImage1 != null)
			{
				_ocdImage1.fillAmount = value;
			}
		}
	}

	public float cdFillamount2
	{
		get
		{
			if (_ocdImage2 != null)
			{
				return _ocdImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (cdFillamount2 != value && _ocdImage2 != null)
			{
				_ocdImage2.fillAmount = value;
			}
		}
	}

	public bool effectShow1
	{
		get
		{
			if (_oeffect1 != null)
			{
				return _oeffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (effectShow1 != value && _oeffect1 != null)
			{
				_oeffect1.SetObjectActive(value);
			}
		}
	}

	public bool effectShow2
	{
		get
		{
			if (_oeffect2 != null)
			{
				return _oeffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (effectShow2 != value && _oeffect2 != null)
			{
				_oeffect2.SetObjectActive(value);
			}
		}
	}

	public Sprite effectSprite1
	{
		get
		{
			if (_oeffectImage1 != null)
			{
				return _oeffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (effectSprite1 != value && _oeffectImage1 != null)
			{
				_oeffectImage1.sprite = value;
			}
		}
	}

	public Sprite effectSprite2
	{
		get
		{
			if (_oeffectImage2 != null)
			{
				return _oeffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (effectSprite2 != value && _oeffectImage2 != null)
			{
				_oeffectImage2.sprite = value;
			}
		}
	}

	public string kjjString1
	{
		get
		{
			if (_okjjText1 != null)
			{
				return _okjjText1.text;
			}
			return null;
		}
		set
		{
			if (kjjString1 != value && _okjjText1 != null)
			{
				_okjjText1.text = value;
			}
		}
	}

	public string kjjString2
	{
		get
		{
			if (_okjjText2 != null)
			{
				return _okjjText2.text;
			}
			return null;
		}
		set
		{
			if (kjjString2 != value && _okjjText2 != null)
			{
				_okjjText2.text = value;
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
			case "Skill1":
				_oSkill1 = transform.gameObject;
				break;
			case "Skill2":
				_oSkill2 = transform.gameObject;
				break;
			case "icon1":
				_oicon1 = transform.gameObject;
				_oiconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "icon2":
				_oicon2 = transform.gameObject;
				_oiconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "cd1":
				_ocd1 = transform.gameObject;
				_ocdImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "cd2":
				_ocd2 = transform.gameObject;
				_ocdImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "effect1":
				_oeffect1 = transform.gameObject;
				_oeffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "effect2":
				_oeffect2 = transform.gameObject;
				_oeffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "kjj1":
				_okjj1 = transform.gameObject;
				_okjjText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "kjj2":
				_okjj2 = transform.gameObject;
				_okjjText2 = transform.gameObject.GetComponent<Text>();
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

	public bool GetSkillShow(int index)
	{
		return index switch
		{
			1 => SkillShow1, 
			2 => SkillShow2, 
			_ => false, 
		};
	}

	public void SetSkillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillShow1 = value;
			break;
		case 2:
			SkillShow2 = value;
			break;
		}
	}

	public int GetSkillCount()
	{
		return 2;
	}

	public Sprite GeticonSprite(int index)
	{
		return index switch
		{
			1 => iconSprite1, 
			2 => iconSprite2, 
			_ => null, 
		};
	}

	public void SeticonSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			iconSprite1 = value;
			break;
		case 2:
			iconSprite2 = value;
			break;
		}
	}

	public int GeticonCount()
	{
		return 2;
	}

	public float GetcdFillamount(int index)
	{
		return index switch
		{
			1 => cdFillamount1, 
			2 => cdFillamount2, 
			_ => 0f, 
		};
	}

	public void SetcdFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			cdFillamount1 = value;
			break;
		case 2:
			cdFillamount2 = value;
			break;
		}
	}

	public int GetcdCount()
	{
		return 2;
	}

	public bool GeteffectShow(int index)
	{
		return index switch
		{
			1 => effectShow1, 
			2 => effectShow2, 
			_ => false, 
		};
	}

	public void SeteffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			effectShow1 = value;
			break;
		case 2:
			effectShow2 = value;
			break;
		}
	}

	public int GeteffectCount()
	{
		return 2;
	}

	public Sprite GeteffectSprite(int index)
	{
		return index switch
		{
			1 => effectSprite1, 
			2 => effectSprite2, 
			_ => null, 
		};
	}

	public void SeteffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			effectSprite1 = value;
			break;
		case 2:
			effectSprite2 = value;
			break;
		}
	}

	public string GetkjjString(int index)
	{
		return index switch
		{
			1 => kjjString1, 
			2 => kjjString2, 
			_ => null, 
		};
	}

	public void SetkjjString(int index, string value)
	{
		switch (index)
		{
		case 1:
			kjjString1 = value;
			break;
		case 2:
			kjjString2 = value;
			break;
		}
	}

	public int GetkjjCount()
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
