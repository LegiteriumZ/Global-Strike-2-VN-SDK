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

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ObtainSuppliesViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private Image _oCenterImage;

	private GameObject _oShow;

	private CanvasGroup _oShowCanvasGroup;

	private GameObject _oLt;

	private Image _oLtImage;

	private GameObject _oLb;

	private Image _oLbImage;

	private GameObject _oRt;

	private Image _oRtImage;

	private GameObject _oRb;

	private Image _oRbImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ObtainSupplies";

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

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public Sprite CenterSprite
	{
		get
		{
			if (_oCenterImage != null)
			{
				return _oCenterImage.sprite;
			}
			return null;
		}
		set
		{
			if (CenterSprite != value && _oCenterImage != null)
			{
				_oCenterImage.sprite = value;
			}
		}
	}

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public float ShowAlpha
	{
		get
		{
			if (_oShowCanvasGroup != null)
			{
				return _oShowCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ShowAlpha != value && _oShowCanvasGroup != null)
			{
				_oShowCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite LtSprite
	{
		get
		{
			if (_oLtImage != null)
			{
				return _oLtImage.sprite;
			}
			return null;
		}
		set
		{
			if (LtSprite != value && _oLtImage != null)
			{
				_oLtImage.sprite = value;
			}
		}
	}

	public Color LtColor
	{
		get
		{
			if (_oLtImage != null)
			{
				return _oLtImage.color;
			}
			return Color.white;
		}
		set
		{
			if (LtColor != value && _oLtImage != null)
			{
				_oLtImage.color = value;
			}
		}
	}

	public Sprite LbSprite
	{
		get
		{
			if (_oLbImage != null)
			{
				return _oLbImage.sprite;
			}
			return null;
		}
		set
		{
			if (LbSprite != value && _oLbImage != null)
			{
				_oLbImage.sprite = value;
			}
		}
	}

	public Color LbColor
	{
		get
		{
			if (_oLbImage != null)
			{
				return _oLbImage.color;
			}
			return Color.white;
		}
		set
		{
			if (LbColor != value && _oLbImage != null)
			{
				_oLbImage.color = value;
			}
		}
	}

	public Sprite RtSprite
	{
		get
		{
			if (_oRtImage != null)
			{
				return _oRtImage.sprite;
			}
			return null;
		}
		set
		{
			if (RtSprite != value && _oRtImage != null)
			{
				_oRtImage.sprite = value;
			}
		}
	}

	public Color RtColor
	{
		get
		{
			if (_oRtImage != null)
			{
				return _oRtImage.color;
			}
			return Color.white;
		}
		set
		{
			if (RtColor != value && _oRtImage != null)
			{
				_oRtImage.color = value;
			}
		}
	}

	public Sprite RbSprite
	{
		get
		{
			if (_oRbImage != null)
			{
				return _oRbImage.sprite;
			}
			return null;
		}
		set
		{
			if (RbSprite != value && _oRbImage != null)
			{
				_oRbImage.sprite = value;
			}
		}
	}

	public Color RbColor
	{
		get
		{
			if (_oRbImage != null)
			{
				return _oRbImage.color;
			}
			return Color.white;
		}
		set
		{
			if (RbColor != value && _oRbImage != null)
			{
				_oRbImage.color = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				_oCenterImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Show":
				_oShow = transform.gameObject;
				_oShowCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Lt":
				_oLt = transform.gameObject;
				_oLtImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Lb":
				_oLb = transform.gameObject;
				_oLbImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Rt":
				_oRt = transform.gameObject;
				_oRtImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Rb":
				_oRb = transform.gameObject;
				_oRbImage = transform.gameObject.GetComponent<Image>();
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

	public void CenterNtvsize()
	{
		if (_oCenterImage != null)
		{
			_oCenterImage.SetNativeSize();
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
