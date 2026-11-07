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

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class MikadukiSwordDklViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _oUnactiveBg;

	private Image _oUnactiveBgImage;

	private GameObject _oActiveBg;

	private Image _oActiveBgImage;

	private GameObject _oUnactiveBgSpecial;

	private Image _oUnactiveBgSpecialImage;

	private GameObject _oActiveBgSpecial;

	private Image _oActiveBgSpecialImage;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oEnergyBg;

	private Image _oEnergyBgImage;

	private GameObject _oEnergyProgress;

	private Image _oEnergyProgressImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "MikadukiSwordDkl";

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

	public bool RightBottomShow
	{
		get
		{
			if (_oRightBottom != null)
			{
				return _oRightBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightBottomShow != value && _oRightBottom != null)
			{
				_oRightBottom.SetObjectActive(value);
			}
		}
	}

	public bool UnactiveBgShow
	{
		get
		{
			if (_oUnactiveBg != null)
			{
				return _oUnactiveBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnactiveBgShow != value && _oUnactiveBg != null)
			{
				_oUnactiveBg.SetObjectActive(value);
			}
		}
	}

	public Sprite UnactiveBgSprite
	{
		get
		{
			if (_oUnactiveBgImage != null)
			{
				return _oUnactiveBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (UnactiveBgSprite != value && _oUnactiveBgImage != null)
			{
				_oUnactiveBgImage.sprite = value;
			}
		}
	}

	public bool ActiveBgShow
	{
		get
		{
			if (_oActiveBg != null)
			{
				return _oActiveBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ActiveBgShow != value && _oActiveBg != null)
			{
				_oActiveBg.SetObjectActive(value);
			}
		}
	}

	public Sprite ActiveBgSprite
	{
		get
		{
			if (_oActiveBgImage != null)
			{
				return _oActiveBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (ActiveBgSprite != value && _oActiveBgImage != null)
			{
				_oActiveBgImage.sprite = value;
			}
		}
	}

	public bool UnactiveBgSpecialShow
	{
		get
		{
			if (_oUnactiveBgSpecial != null)
			{
				return _oUnactiveBgSpecial.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnactiveBgSpecialShow != value && _oUnactiveBgSpecial != null)
			{
				_oUnactiveBgSpecial.SetObjectActive(value);
			}
		}
	}

	public Sprite UnactiveBgSpecialSprite
	{
		get
		{
			if (_oUnactiveBgSpecialImage != null)
			{
				return _oUnactiveBgSpecialImage.sprite;
			}
			return null;
		}
		set
		{
			if (UnactiveBgSpecialSprite != value && _oUnactiveBgSpecialImage != null)
			{
				_oUnactiveBgSpecialImage.sprite = value;
			}
		}
	}

	public bool ActiveBgSpecialShow
	{
		get
		{
			if (_oActiveBgSpecial != null)
			{
				return _oActiveBgSpecial.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ActiveBgSpecialShow != value && _oActiveBgSpecial != null)
			{
				_oActiveBgSpecial.SetObjectActive(value);
			}
		}
	}

	public Sprite ActiveBgSpecialSprite
	{
		get
		{
			if (_oActiveBgSpecialImage != null)
			{
				return _oActiveBgSpecialImage.sprite;
			}
			return null;
		}
		set
		{
			if (ActiveBgSpecialSprite != value && _oActiveBgSpecialImage != null)
			{
				_oActiveBgSpecialImage.sprite = value;
			}
		}
	}

	public bool ProgressShow
	{
		get
		{
			if (_oProgress != null)
			{
				return _oProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow != value && _oProgress != null)
			{
				_oProgress.SetObjectActive(value);
			}
		}
	}

	public Sprite ProgressSprite
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite != value && _oProgressImage != null)
			{
				_oProgressImage.sprite = value;
			}
		}
	}

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public bool EnergyBgShow
	{
		get
		{
			if (_oEnergyBg != null)
			{
				return _oEnergyBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EnergyBgShow != value && _oEnergyBg != null)
			{
				_oEnergyBg.SetObjectActive(value);
			}
		}
	}

	public Sprite EnergyBgSprite
	{
		get
		{
			if (_oEnergyBgImage != null)
			{
				return _oEnergyBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (EnergyBgSprite != value && _oEnergyBgImage != null)
			{
				_oEnergyBgImage.sprite = value;
			}
		}
	}

	public bool EnergyProgressShow
	{
		get
		{
			if (_oEnergyProgress != null)
			{
				return _oEnergyProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EnergyProgressShow != value && _oEnergyProgress != null)
			{
				_oEnergyProgress.SetObjectActive(value);
			}
		}
	}

	public Sprite EnergyProgressSprite
	{
		get
		{
			if (_oEnergyProgressImage != null)
			{
				return _oEnergyProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (EnergyProgressSprite != value && _oEnergyProgressImage != null)
			{
				_oEnergyProgressImage.sprite = value;
			}
		}
	}

	public float EnergyProgressFillamount
	{
		get
		{
			if (_oEnergyProgressImage != null)
			{
				return _oEnergyProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (EnergyProgressFillamount != value && _oEnergyProgressImage != null)
			{
				_oEnergyProgressImage.fillAmount = value;
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
			case "RightBottom":
				_oRightBottom = transform.gameObject;
				break;
			case "UnactiveBg":
				_oUnactiveBg = transform.gameObject;
				_oUnactiveBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ActiveBg":
				_oActiveBg = transform.gameObject;
				_oActiveBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "UnactiveBgSpecial":
				_oUnactiveBgSpecial = transform.gameObject;
				_oUnactiveBgSpecialImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ActiveBgSpecial":
				_oActiveBgSpecial = transform.gameObject;
				_oActiveBgSpecialImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyBg":
				_oEnergyBg = transform.gameObject;
				_oEnergyBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnergyProgress":
				_oEnergyProgress = transform.gameObject;
				_oEnergyProgressImage = transform.gameObject.GetComponent<Image>();
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
		return _holdPosTrans;
	}
}
