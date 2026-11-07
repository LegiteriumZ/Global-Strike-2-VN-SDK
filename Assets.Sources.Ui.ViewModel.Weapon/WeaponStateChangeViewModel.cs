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
public class WeaponStateChangeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _oSkillDisable;

	private Image _oSkillDisableImage;

	private GameObject _oSkillEnable;

	private Image _oSkillEnableImage;

	private GameObject _oSkillSpecialEnable;

	private Image _oSkillSpecialEnableImage;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "WeaponStateChange";

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

	public Sprite SkillDisableSprite
	{
		get
		{
			if (_oSkillDisableImage != null)
			{
				return _oSkillDisableImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillDisableSprite != value && _oSkillDisableImage != null)
			{
				_oSkillDisableImage.sprite = value;
			}
		}
	}

	public bool SkillEnableShow
	{
		get
		{
			if (_oSkillEnable != null)
			{
				return _oSkillEnable.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillEnableShow != value && _oSkillEnable != null)
			{
				_oSkillEnable.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillEnableSprite
	{
		get
		{
			if (_oSkillEnableImage != null)
			{
				return _oSkillEnableImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillEnableSprite != value && _oSkillEnableImage != null)
			{
				_oSkillEnableImage.sprite = value;
			}
		}
	}

	public bool SkillSpecialEnableShow
	{
		get
		{
			if (_oSkillSpecialEnable != null)
			{
				return _oSkillSpecialEnable.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillSpecialEnableShow != value && _oSkillSpecialEnable != null)
			{
				_oSkillSpecialEnable.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillSpecialEnableSprite
	{
		get
		{
			if (_oSkillSpecialEnableImage != null)
			{
				return _oSkillSpecialEnableImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillSpecialEnableSprite != value && _oSkillSpecialEnableImage != null)
			{
				_oSkillSpecialEnableImage.sprite = value;
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
			case "SkillDisable":
				_oSkillDisable = transform.gameObject;
				_oSkillDisableImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillEnable":
				_oSkillEnable = transform.gameObject;
				_oSkillEnableImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillSpecialEnable":
				_oSkillSpecialEnable = transform.gameObject;
				_oSkillSpecialEnableImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
