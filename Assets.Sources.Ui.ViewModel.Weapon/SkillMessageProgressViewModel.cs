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
public class SkillMessageProgressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _odun;

	private Image _odunImage;

	private GameObject _oDunProgress;

	private Image _oDunProgressImage;

	private GameObject _oSkillMessage;

	private Image _oSkillMessageImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "SkillMessageProgress";

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

	public bool dunShow
	{
		get
		{
			if (_odun != null)
			{
				return _odun.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow != value && _odun != null)
			{
				_odun.SetObjectActive(value);
			}
		}
	}

	public Sprite dunSprite
	{
		get
		{
			if (_odunImage != null)
			{
				return _odunImage.sprite;
			}
			return null;
		}
		set
		{
			if (dunSprite != value && _odunImage != null)
			{
				_odunImage.sprite = value;
			}
		}
	}

	public Sprite DunProgressSprite
	{
		get
		{
			if (_oDunProgressImage != null)
			{
				return _oDunProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (DunProgressSprite != value && _oDunProgressImage != null)
			{
				_oDunProgressImage.sprite = value;
			}
		}
	}

	public float DunProgressFillamount
	{
		get
		{
			if (_oDunProgressImage != null)
			{
				return _oDunProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (DunProgressFillamount != value && _oDunProgressImage != null)
			{
				_oDunProgressImage.fillAmount = value;
			}
		}
	}

	public bool SkillMessageShow
	{
		get
		{
			if (_oSkillMessage != null)
			{
				return _oSkillMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillMessageShow != value && _oSkillMessage != null)
			{
				_oSkillMessage.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillMessageSprite
	{
		get
		{
			if (_oSkillMessageImage != null)
			{
				return _oSkillMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillMessageSprite != value && _oSkillMessageImage != null)
			{
				_oSkillMessageImage.sprite = value;
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
			case "dun":
				_odun = transform.gameObject;
				_odunImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DunProgress":
				_oDunProgress = transform.gameObject;
				_oDunProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillMessage":
				_oSkillMessage = transform.gameObject;
				_oSkillMessageImage = transform.gameObject.GetComponent<Image>();
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

	public void dunNtvsize()
	{
		if (_odunImage != null)
		{
			_odunImage.SetNativeSize();
		}
	}

	public void DunProgressNtvsize()
	{
		if (_oDunProgressImage != null)
		{
			_oDunProgressImage.SetNativeSize();
		}
	}

	public void SkillMessageNtvsize()
	{
		if (_oSkillMessageImage != null)
		{
			_oSkillMessageImage.SetNativeSize();
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
