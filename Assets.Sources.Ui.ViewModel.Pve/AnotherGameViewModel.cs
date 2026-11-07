using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class AnotherGameViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oAnotherGame;

	private GameObject _oAnotherGameBg;

	private GameObject _oButtonExit;

	private GameObject _oButtonContinue;

	private GameObject _oCountDown;

	private Text _oCountDownText;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string ButtonExitName = "ButtonExit";

	public const string ButtonContinueName = "ButtonContinue";

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "AnotherGame";

	public UiReferences UI => uiRef;

	public bool AnotherGameShow
	{
		get
		{
			if (_oAnotherGame != null)
			{
				return _oAnotherGame.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AnotherGameShow != value && _oAnotherGame != null)
			{
				_oAnotherGame.SetObjectActive(value);
			}
		}
	}

	public bool AnotherGameBgShow
	{
		get
		{
			if (_oAnotherGameBg != null)
			{
				return _oAnotherGameBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AnotherGameBgShow != value && _oAnotherGameBg != null)
			{
				_oAnotherGameBg.SetObjectActive(value);
			}
		}
	}

	public bool ButtonExitShow
	{
		get
		{
			if (_oButtonExit != null)
			{
				return _oButtonExit.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ButtonExitShow != value && _oButtonExit != null)
			{
				_oButtonExit.SetObjectActive(value);
			}
		}
	}

	public bool ButtonContinueShow
	{
		get
		{
			if (_oButtonContinue != null)
			{
				return _oButtonContinue.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ButtonContinueShow != value && _oButtonContinue != null)
			{
				_oButtonContinue.SetObjectActive(value);
			}
		}
	}

	public bool CountDownShow
	{
		get
		{
			if (_oCountDown != null)
			{
				return _oCountDown.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CountDownShow != value && _oCountDown != null)
			{
				_oCountDown.SetObjectActive(value);
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "AnotherGame":
				_oAnotherGame = transform.gameObject;
				uiRef.Set("AnotherGame", _oAnotherGame.transform);
				break;
			case "AnotherGameBg":
				_oAnotherGameBg = transform.gameObject;
				uiRef.Set("AnotherGameBg", _oAnotherGameBg.transform);
				break;
			case "ButtonExit":
				_oButtonExit = transform.gameObject;
				uiRef.Set("ButtonExit", _oButtonExit.transform);
				break;
			case "ButtonContinue":
				_oButtonContinue = transform.gameObject;
				uiRef.Set("ButtonContinue", _oButtonContinue.transform);
				break;
			case "CountDown":
				_oCountDown = transform.gameObject;
				uiRef.Set("CountDown", _oCountDown.transform);
				_oCountDownText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("CountDownText", _oCountDownText);
				break;
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
			Object.Destroy(_viewGameObject);
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
