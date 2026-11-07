using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.Model;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.QuickTest;
using Assets.UiFramework.Libs;
using SSJJBase.Input;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.Ui.Mode;

public abstract class BaseUiMode
{
	protected readonly Contexts Contexts;

	private readonly List<IPlaybackSystem> _playbackSystems;

	private readonly List<AbstractModel> _models;

	private List<Type> _intertiaList;

	public void Clear()
	{
		if (_intertiaList != null)
		{
			_intertiaList.Clear();
		}
		if (_playbackSystems != null)
		{
			_playbackSystems.Clear();
		}
		if (_models != null)
		{
			_models.Clear();
		}
	}

	protected abstract bool IsMatchMode(int racetype);

	public BaseUiMode(Contexts contexts)
	{
		Contexts = contexts;
		_playbackSystems = new List<IPlaybackSystem>();
		_intertiaList = new List<Type>();
		_models = new List<AbstractModel>();
		if (Contexts.battleRoom.roomData.Data.IsPromise || Contexts.battleRoom.roomData.Data.IsMatch)
		{
			AddPlaybackSystem<PromiseMessageModel>();
		}
		if (NetRecordManager.Open)
		{
			AddPlaybackSystem<QuickTestModel>();
		}
		if (MultiPlayerServerManager.Open)
		{
			AddPlaybackSystem<QuickMultiPlayerModel>();
		}
		AddPlaybackSystem<KickOutUIModel>();
	}

	public IPlaybackSystem GetModel<T>()
	{
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			if (playbackSystem is T)
			{
				return playbackSystem;
			}
		}
		return null;
	}

	protected void AddPlaybackSystem<T>() where T : IPlaybackSystem, new()
	{
		if (_intertiaList == null)
		{
			_intertiaList = new List<Type>();
		}
		_intertiaList.Add(typeof(T));
	}

	protected void RemovePlaybackSystem<T>() where T : IPlaybackSystem, new()
	{
		if (_intertiaList != null)
		{
			_intertiaList.Remove(typeof(T));
		}
	}

	public void Initialize()
	{
		if (_intertiaList.Count <= 0)
		{
			return;
		}
		_playbackSystems.Clear();
		foreach (Type intertia in _intertiaList)
		{
			_playbackSystems.Add(Activator.CreateInstance(intertia) as IPlaybackSystem);
		}
		AbstractModel.LoadCount = _playbackSystems.Count;
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			InitializeSetter(playbackSystem);
			if (playbackSystem is AbstractModel)
			{
				AbstractModel abstractModel = playbackSystem as AbstractModel;
				abstractModel.Initialize();
				_models.Add(abstractModel);
			}
		}
		_intertiaList = null;
	}

	public void OnPlayback()
	{
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			try
			{
				playbackSystem.OnPlayback();
			}
			catch (Exception args)
			{
				this.LogErrorFormat("Ui Model OnPlayback Error : {0}", args);
			}
		}
	}

	private void InitializeSetter(object model)
	{
		if (model is ISetPlayerContext)
		{
			((ISetPlayerContext)model).SetPlayerContext(Contexts.player);
		}
		if (model is ISetBattleRoomContext)
		{
			((ISetBattleRoomContext)model).SetBattleRoomContext(Contexts.battleRoom);
		}
		if (model is ISetBattleServerContext)
		{
			((ISetBattleServerContext)model).SetBattleServerContext(Contexts.battleServer);
		}
		if (model is ISetPlayerBagContext)
		{
			((ISetPlayerBagContext)model).SetPlayerBagContext(Contexts.playerBag);
		}
		if (model is ISetWeaponContext)
		{
			((ISetWeaponContext)model).SetWeaponContext(Contexts.weapon);
		}
		if (model is ISetUserCommmandContext)
		{
			((ISetUserCommmandContext)model).SetUserCommandContext(Contexts.userCommand);
		}
		if (model is ISetGameRuleContext)
		{
			((ISetGameRuleContext)model).SetGameRuleContext(Contexts.gameRule);
		}
		if (model is ICursorControl)
		{
			Contexts.sharedInstance.userCommand.input.CursorControls.Add((ICursorControl)model);
		}
		if (model is IKeyboardResponder)
		{
			Contexts.userCommand.input.KeyboardResponders.Add((IKeyboardResponder)model);
		}
		if (model is ISetCameraContext)
		{
			((ISetCameraContext)model).SetCameraContext(Contexts.worldCamera);
		}
		if (model is ISetCrossContext)
		{
			((ISetCrossContext)model).SetCrossContext(Contexts.cross);
		}
		if (model is ISetSceneObjectContext setSceneObjectContext)
		{
			setSceneObjectContext.SetSceneObjectContext(Contexts.sceneObject);
		}
		if (model is ISetSnapShotContext setSnapShotContext)
		{
			setSnapShotContext.SetSnapShotContext(Contexts.snapshot);
		}
		if (model is ISetMessageContext)
		{
			((ISetMessageContext)model).SetMessageContext(Contexts.message);
		}
	}
}
