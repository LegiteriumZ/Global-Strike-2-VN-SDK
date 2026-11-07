using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearBuffersViewModel : IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBuffersBackground;

	private GameObject _oIcon;

	private Image _oIconImage;

	private GameObject _oNum;

	private Text _oNumText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearBuffers";

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

	public GameObject BuffersBackgroundObj => _oBuffersBackground;

	public bool BuffersBackgroundShow
	{
		get
		{
			if (_oBuffersBackground != null)
			{
				return _oBuffersBackground.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffersBackgroundShow != value && _oBuffersBackground != null)
			{
				_oBuffersBackground.SetObjectActive(value);
			}
		}
	}

	public bool IconShow
	{
		get
		{
			if (_oIcon != null)
			{
				return _oIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow != value && _oIcon != null)
			{
				_oIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite != value && _oIconImage != null)
			{
				_oIconImage.sprite = value;
			}
		}
	}

	public bool NumShow
	{
		get
		{
			if (_oNum != null)
			{
				return _oNum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumShow != value && _oNum != null)
			{
				_oNum.SetObjectActive(value);
			}
		}
	}

	public string NumString
	{
		get
		{
			if (_oNumText != null)
			{
				return _oNumText.text;
			}
			return null;
		}
		set
		{
			if (NumString != value && _oNumText != null)
			{
				_oNumText.text = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "BuffersBackground":
				_oBuffersBackground = transform.gameObject;
				break;
			case "Icon":
				_oIcon = transform.gameObject;
				_oIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Num":
				_oNum = transform.gameObject;
				_oNumText = transform.gameObject.GetComponent<Text>();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
