using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model;
using Assets.UiFramework.Libs;
using SSJJBase.Input;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Ui.Weapon;

public class WeaponModelDelegate : IPlaybackSystem, IResourceInitSystem, IResourceLoadSystem
{
	private readonly Contexts _contexts;

	private readonly UiResourcesLoader _loader;

	private readonly Dictionary<string, AbstractModel> _modelDictionary = new Dictionary<string, AbstractModel>();

	private readonly Dictionary<string, IPlaybackSystem> _playerbackDictionary = new Dictionary<string, IPlaybackSystem>();

	private readonly WeaponContext _weaponContext;

	public WeaponModelDelegate(Contexts contexts)
	{
		_contexts = contexts;
		_weaponContext = contexts.weapon;
		_loader = new UiResourcesLoader(contexts);
	}

	public void OnPlayback()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return;
		}
		string[] uiModels = _weaponContext.currentWeaponEntity.basicInfo.Info.UiModels;
		if (_weaponContext.isCurrentWeapon)
		{
			CreateWeaponUi(uiModels);
		}
		foreach (KeyValuePair<string, AbstractModel> item in _modelDictionary)
		{
			bool flag = false;
			for (int i = 0; i < uiModels.Length; i++)
			{
				if (uiModels[i] == item.Key)
				{
					flag = true;
					break;
				}
			}
			item.Value.Visible(flag && !UiIEventCondition.Get_pveMessage_BossWarning());
		}
		string[] array = uiModels;
		foreach (string key in array)
		{
			if (_playerbackDictionary.ContainsKey(key))
			{
				_playerbackDictionary[key].OnPlayback();
			}
		}
	}

	public void OnInitResources()
	{
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		_loader.OnLoadResources(coRoutineManager);
	}

	private void CreateWeaponUi(string[] modelNames)
	{
		if (modelNames == null)
		{
			return;
		}
		foreach (string text in modelNames)
		{
			if (text.Length != 0 && !_modelDictionary.ContainsKey(text))
			{
				AbstractModel abstractModel = CreateModel(text);
				if (abstractModel != null)
				{
					Initialize(abstractModel);
					_modelDictionary[text] = abstractModel;
					_playerbackDictionary[text] = (IPlaybackSystem)abstractModel;
				}
			}
		}
	}

	private AbstractModel CreateModel(string modelName)
	{
		Type type = Type.GetType(string.Format("{0}.{1}Model", "Assets.Sources.Ui.Model.Weapon", modelName));
		if (type != null)
		{
			return (AbstractModel)Activator.CreateInstance(type);
		}
		return null;
	}

	private void Initialize(AbstractModel model)
	{
		if (model is ISetPlayerContext)
		{
			((ISetPlayerContext)model).SetPlayerContext(_contexts.player);
		}
		if (model is ISetBattleRoomContext)
		{
			((ISetBattleRoomContext)model).SetBattleRoomContext(_contexts.battleRoom);
		}
		if (model is ISetBattleServerContext)
		{
			((ISetBattleServerContext)model).SetBattleServerContext(_contexts.battleServer);
		}
		if (model is ISetPlayerBagContext)
		{
			((ISetPlayerBagContext)model).SetPlayerBagContext(_contexts.playerBag);
		}
		if (model is ISetWeaponContext)
		{
			((ISetWeaponContext)model).SetWeaponContext(_contexts.weapon);
		}
		if (model is ISetUserCommmandContext)
		{
			((ISetUserCommmandContext)model).SetUserCommandContext(_contexts.userCommand);
		}
		if (model is ISetGameRuleContext)
		{
			((ISetGameRuleContext)model).SetGameRuleContext(_contexts.gameRule);
		}
		if (model is ICursorControl)
		{
			Contexts.sharedInstance.userCommand.input.CursorControls.Add((ICursorControl)model);
		}
		if (model is IKeyboardResponder)
		{
			_contexts.userCommand.input.KeyboardResponders.Add((IKeyboardResponder)model);
		}
		if (model is ISetCameraContext)
		{
			((ISetCameraContext)model).SetCameraContext(_contexts.worldCamera);
		}
		if (model is ISetSceneObjectContext setSceneObjectContext)
		{
			setSceneObjectContext.SetSceneObjectContext(_contexts.sceneObject);
		}
		if (model is ISetSnapShotContext setSnapShotContext)
		{
			setSnapShotContext.SetSnapShotContext(_contexts.snapshot);
		}
		if (model is ISetMessageContext)
		{
			((ISetMessageContext)model).SetMessageContext(_contexts.message);
		}
		model.Initialize();
	}
}
