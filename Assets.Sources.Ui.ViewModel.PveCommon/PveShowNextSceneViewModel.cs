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

namespace Assets.Sources.Ui.ViewModel.PveCommon;

[GameUiTest]
public class PveShowNextSceneViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oResult;

	private GameObject _oButtonExit;

	private Button _oButtonExitButton;

	private GameObject _oButtonContinue;

	private Button _oButtonContinueButton;

	private GameObject _oCountDown;

	private Text _oCountDownText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/pvecommon";

	private string _resourceAssetName = "pveshownextscene";

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

	public bool ResultShow
	{
		get
		{
			if (_oResult != null)
			{
				return _oResult.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ResultShow != value && _oResult != null)
			{
				_oResult.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ButtonExitClicked
	{
		get
		{
			if (_oButtonExitButton != null)
			{
				return _oButtonExitButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonExitClicked != value && _oButtonExitButton != null)
			{
				_oButtonExitButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ButtonContinueClicked
	{
		get
		{
			if (_oButtonContinueButton != null)
			{
				return _oButtonContinueButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonContinueClicked != value && _oButtonContinueButton != null)
			{
				_oButtonContinueButton.onClick = value;
			}
		}
	}

	public string CountDownString
	{
		get
		{
			if (_oCountDownText != null)
			{
				return _oCountDownText.text;
			}
			return null;
		}
		set
		{
			if (CountDownString != value && _oCountDownText != null)
			{
				_oCountDownText.text = value;
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
			case "Result":
				_oResult = transform.gameObject;
				break;
			case "ButtonExit":
				_oButtonExit = transform.gameObject;
				_oButtonExitButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ButtonContinue":
				_oButtonContinue = transform.gameObject;
				_oButtonContinueButton = transform.gameObject.GetComponent<Button>();
				break;
			case "CountDown":
				_oCountDown = transform.gameObject;
				_oCountDownText = transform.gameObject.GetComponent<Text>();
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
}
