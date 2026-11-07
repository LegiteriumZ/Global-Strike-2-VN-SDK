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
public class HuLaoGuanNewYearProfessionViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oicon;

	private Image _oiconImage;

	private GameObject _oName;

	private Text _oNameText;

	private GameObject _oJobDes;

	private Text _oJobDesText;

	private GameObject _oTips;

	private Image _oTipsImage;

	private GameObject _oSKill1;

	private Image _oSKillImage1;

	private GameObject _oDes1;

	private GameObject _oDes2;

	private Text _oDesText1;

	private Text _oDesText2;

	private GameObject _oSkill2;

	private Image _oSkillImage2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguannewyearprofession";

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

	public bool PanelShow
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
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public Sprite iconSprite
	{
		get
		{
			if (_oiconImage != null)
			{
				return _oiconImage.sprite;
			}
			return null;
		}
		set
		{
			if (iconSprite != value && _oiconImage != null)
			{
				_oiconImage.sprite = value;
			}
		}
	}

	public string NameString
	{
		get
		{
			if (_oNameText != null)
			{
				return _oNameText.text;
			}
			return null;
		}
		set
		{
			if (NameString != value && _oNameText != null)
			{
				_oNameText.text = value;
			}
		}
	}

	public string JobDesString
	{
		get
		{
			if (_oJobDesText != null)
			{
				return _oJobDesText.text;
			}
			return null;
		}
		set
		{
			if (JobDesString != value && _oJobDesText != null)
			{
				_oJobDesText.text = value;
			}
		}
	}

	public Sprite TipsSprite
	{
		get
		{
			if (_oTipsImage != null)
			{
				return _oTipsImage.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite != value && _oTipsImage != null)
			{
				_oTipsImage.sprite = value;
			}
		}
	}

	public Sprite SKillSprite1
	{
		get
		{
			if (_oSKillImage1 != null)
			{
				return _oSKillImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SKillSprite1 != value && _oSKillImage1 != null)
			{
				_oSKillImage1.sprite = value;
			}
		}
	}

	public string DesString1
	{
		get
		{
			if (_oDesText1 != null)
			{
				return _oDesText1.text;
			}
			return null;
		}
		set
		{
			if (DesString1 != value && _oDesText1 != null)
			{
				_oDesText1.text = value;
			}
		}
	}

	public string DesString2
	{
		get
		{
			if (_oDesText2 != null)
			{
				return _oDesText2.text;
			}
			return null;
		}
		set
		{
			if (DesString2 != value && _oDesText2 != null)
			{
				_oDesText2.text = value;
			}
		}
	}

	public Sprite SkillSprite2
	{
		get
		{
			if (_oSkillImage2 != null)
			{
				return _oSkillImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillSprite2 != value && _oSkillImage2 != null)
			{
				_oSkillImage2.sprite = value;
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
			case "icon":
				_oicon = transform.gameObject;
				_oiconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Name":
				_oName = transform.gameObject;
				_oNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "JobDes":
				_oJobDes = transform.gameObject;
				_oJobDesText = transform.gameObject.GetComponent<Text>();
				break;
			case "Tips":
				_oTips = transform.gameObject;
				_oTipsImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SKill1":
				_oSKill1 = transform.gameObject;
				_oSKillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Des1":
				_oDes1 = transform.gameObject;
				_oDesText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Des2":
				_oDes2 = transform.gameObject;
				_oDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Skill2":
				_oSkill2 = transform.gameObject;
				_oSkillImage2 = transform.gameObject.GetComponent<Image>();
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

	public Sprite GetSKillSprite(int index)
	{
		if (index == 1)
		{
			return SKillSprite1;
		}
		return null;
	}

	public void SetSKillSprite(int index, Sprite value)
	{
		if (index == 1)
		{
			SKillSprite1 = value;
		}
	}

	public int GetSKillCount()
	{
		return 1;
	}

	public string GetDesString(int index)
	{
		return index switch
		{
			1 => DesString1, 
			2 => DesString2, 
			_ => null, 
		};
	}

	public void SetDesString(int index, string value)
	{
		switch (index)
		{
		case 1:
			DesString1 = value;
			break;
		case 2:
			DesString2 = value;
			break;
		}
	}

	public int GetDesCount()
	{
		return 2;
	}

	public Sprite GetSkillSprite(int index)
	{
		if (index == 2)
		{
			return SkillSprite2;
		}
		return null;
	}

	public void SetSkillSprite(int index, Sprite value)
	{
		if (index == 2)
		{
			SkillSprite2 = value;
		}
	}

	public int GetSkillCount()
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
