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

namespace Assets.Sources.Ui.ViewModel.Biochemical3;

[GameUiTest]
public class Biochemical3VariantPlayerStateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBioChemicalSerum;

	private GameObject _oBioClip;

	private GameObject _oHaveBh;

	private GameObject _oHaveBv;

	private GameObject _oHpProgress;

	private Image _oHpProgressImage;

	private GameObject _oHp;

	private Text _oHpText;

	private GameObject _oShieldProgress;

	private Image _oShieldProgressImage;

	private GameObject _oCareer;

	private Image _oCareerImage;

	private GameObject _oLvBack;

	private GameObject _oLv;

	private Text _oLvText;

	private GameObject _oElite;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3VariantPlayerState";

	private List<RectTransform> _holdPosTrans;

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

	public bool BioChemicalSerumShow
	{
		get
		{
			if (_oBioChemicalSerum != null)
			{
				return _oBioChemicalSerum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BioChemicalSerumShow != value && _oBioChemicalSerum != null)
			{
				_oBioChemicalSerum.SetObjectActive(value);
			}
		}
	}

	public bool BioClipShow
	{
		get
		{
			if (_oBioClip != null)
			{
				return _oBioClip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BioClipShow != value && _oBioClip != null)
			{
				_oBioClip.SetObjectActive(value);
			}
		}
	}

	public bool HaveBhShow
	{
		get
		{
			if (_oHaveBh != null)
			{
				return _oHaveBh.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HaveBhShow != value && _oHaveBh != null)
			{
				_oHaveBh.SetObjectActive(value);
			}
		}
	}

	public bool HaveBvShow
	{
		get
		{
			if (_oHaveBv != null)
			{
				return _oHaveBv.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HaveBvShow != value && _oHaveBv != null)
			{
				_oHaveBv.SetObjectActive(value);
			}
		}
	}

	public float HpProgressFillamount
	{
		get
		{
			if (_oHpProgressImage != null)
			{
				return _oHpProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressFillamount != value && _oHpProgressImage != null)
			{
				_oHpProgressImage.fillAmount = value;
			}
		}
	}

	public string HpString
	{
		get
		{
			if (_oHpText != null)
			{
				return _oHpText.text;
			}
			return null;
		}
		set
		{
			if (HpString != value && _oHpText != null)
			{
				_oHpText.text = value;
			}
		}
	}

	public float ShieldProgressFillamount
	{
		get
		{
			if (_oShieldProgressImage != null)
			{
				return _oShieldProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ShieldProgressFillamount != value && _oShieldProgressImage != null)
			{
				_oShieldProgressImage.fillAmount = value;
			}
		}
	}

	public Sprite CareerSprite
	{
		get
		{
			if (_oCareerImage != null)
			{
				return _oCareerImage.sprite;
			}
			return null;
		}
		set
		{
			if (CareerSprite != value && _oCareerImage != null)
			{
				_oCareerImage.sprite = value;
			}
		}
	}

	public bool LvBackShow
	{
		get
		{
			if (_oLvBack != null)
			{
				return _oLvBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvBackShow != value && _oLvBack != null)
			{
				_oLvBack.SetObjectActive(value);
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

	public bool EliteShow
	{
		get
		{
			if (_oElite != null)
			{
				return _oElite.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EliteShow != value && _oElite != null)
			{
				_oElite.SetObjectActive(value);
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
			case "BioChemicalSerum":
				_oBioChemicalSerum = transform.gameObject;
				break;
			case "BioClip":
				_oBioClip = transform.gameObject;
				break;
			case "HaveBh":
				_oHaveBh = transform.gameObject;
				break;
			case "HaveBv":
				_oHaveBv = transform.gameObject;
				break;
			case "HpProgress":
				_oHpProgress = transform.gameObject;
				_oHpProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Hp":
				_oHp = transform.gameObject;
				_oHpText = transform.gameObject.GetComponent<Text>();
				break;
			case "ShieldProgress":
				_oShieldProgress = transform.gameObject;
				_oShieldProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Career":
				_oCareer = transform.gameObject;
				_oCareerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LvBack":
				_oLvBack = transform.gameObject;
				break;
			case "Lv":
				_oLv = transform.gameObject;
				_oLvText = transform.gameObject.GetComponent<Text>();
				break;
			case "Elite":
				_oElite = transform.gameObject;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oHpText != null)
		{
			_holdPosTrans.Add(_oHpText.GetComponent<RectTransform>());
		}
		if (_oLvText != null)
		{
			_holdPosTrans.Add(_oLvText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
