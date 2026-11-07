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

namespace Assets.Sources.Ui.ViewModel.BioEvolution;

[GameUiTest]
public class BioEvolutionShortcutKeyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oencourage;

	private GameObject _oencourageEffect;

	private RectTransform _oencourageEffectRectTransform;

	private CanvasGroup _oencourageEffectCanvasGroup;

	private GameObject _ogiveweapon;

	private GameObject _ogiveweaponEffect;

	private RectTransform _ogiveweaponEffectRectTransform;

	private CanvasGroup _ogiveweaponEffectCanvasGroup;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bioevolution";

	private string _resourceAssetName = "BioEvolutionShortcutKey";

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

	public bool encourageShow
	{
		get
		{
			if (_oencourage != null)
			{
				return _oencourage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (encourageShow != value && _oencourage != null)
			{
				_oencourage.SetObjectActive(value);
			}
		}
	}

	public bool encourageEffectShow
	{
		get
		{
			if (_oencourageEffect != null)
			{
				return _oencourageEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (encourageEffectShow != value && _oencourageEffect != null)
			{
				_oencourageEffect.SetObjectActive(value);
			}
		}
	}

	public Vector3 encourageEffectScale
	{
		get
		{
			if (_oencourageEffectRectTransform != null)
			{
				return _oencourageEffectRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (encourageEffectScale != value && _oencourageEffectRectTransform != null)
			{
				_oencourageEffectRectTransform.localScale = value;
			}
		}
	}

	public float encourageEffectAlpha
	{
		get
		{
			if (_oencourageEffectCanvasGroup != null)
			{
				return _oencourageEffectCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (encourageEffectAlpha != value && _oencourageEffectCanvasGroup != null)
			{
				_oencourageEffectCanvasGroup.alpha = value;
			}
		}
	}

	public bool giveweaponShow
	{
		get
		{
			if (_ogiveweapon != null)
			{
				return _ogiveweapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (giveweaponShow != value && _ogiveweapon != null)
			{
				_ogiveweapon.SetObjectActive(value);
			}
		}
	}

	public bool giveweaponEffectShow
	{
		get
		{
			if (_ogiveweaponEffect != null)
			{
				return _ogiveweaponEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (giveweaponEffectShow != value && _ogiveweaponEffect != null)
			{
				_ogiveweaponEffect.SetObjectActive(value);
			}
		}
	}

	public Vector3 giveweaponEffectScale
	{
		get
		{
			if (_ogiveweaponEffectRectTransform != null)
			{
				return _ogiveweaponEffectRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (giveweaponEffectScale != value && _ogiveweaponEffectRectTransform != null)
			{
				_ogiveweaponEffectRectTransform.localScale = value;
			}
		}
	}

	public float giveweaponEffectAlpha
	{
		get
		{
			if (_ogiveweaponEffectCanvasGroup != null)
			{
				return _ogiveweaponEffectCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (giveweaponEffectAlpha != value && _ogiveweaponEffectCanvasGroup != null)
			{
				_ogiveweaponEffectCanvasGroup.alpha = value;
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
			case "encourage":
				_oencourage = transform.gameObject;
				break;
			case "encourageEffect":
				_oencourageEffect = transform.gameObject;
				_oencourageEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oencourageEffectCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "giveweapon":
				_ogiveweapon = transform.gameObject;
				break;
			case "giveweaponEffect":
				_ogiveweaponEffect = transform.gameObject;
				_ogiveweaponEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_ogiveweaponEffectCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
