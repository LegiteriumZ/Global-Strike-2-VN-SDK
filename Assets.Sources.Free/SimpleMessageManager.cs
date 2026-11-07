using System;
using System.Collections.Generic;
using Assets.Sources.Free.Effect;
using Assets.Sources.Free.Entity;
using Assets.Sources.Free.Scene;
using Assets.Sources.Free.Sound;
using Assets.Sources.Free.UI;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Free;

public class SimpleMessageManager
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(SimpleMessageManager));

	private static SimpleMessageManager _instance;

	private List<ISimpleMesssageHandler> _handlers;

	public static SimpleMessageManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SimpleMessageManager();
				_instance.Init();
			}
			return _instance;
		}
	}

	private void Init()
	{
		_handlers = new List<ISimpleMesssageHandler>();
		_handlers.Add(new UiCreateMessageHandler());
		_handlers.Add(new UIShowMessageHandler());
		_handlers.Add(new UIDeleteMessageHandler());
		_handlers.Add(new UIDeleteAllMessageHandler());
		_handlers.Add(new EffectCreateHandler(Contexts.sharedInstance));
		_handlers.Add(new EffectShowHandler(Contexts.sharedInstance));
		_handlers.Add(new EffectUpdateHandler());
		_handlers.Add(new EffectDeleteHandler());
		_handlers.Add(new TipsMessageHandler());
		_handlers.Add(new PlayerStateHandler());
		_handlers.Add(new SeeAllHandler());
		_handlers.Add(new AllowMouseKeysHandler());
		_handlers.Add(new FogHandler());
		_handlers.Add(new SkyBoxHandler());
		_handlers.Add(new SceneLightHandler());
		_handlers.Add(new ClosePvsHandler());
		_handlers.Add(new BloodSprayHandler());
		_handlers.Add(new UIRemoveAllHandler());
		_handlers.Add(new PlaySoundHandler());
		_handlers.Add(new EntityStatusHandler());
	}

	public void Handle(SimpleProto data)
	{
		try
		{
			for (int i = 0; i < _handlers.Count; i++)
			{
				ISimpleMesssageHandler simpleMesssageHandler = _handlers[i];
				if (simpleMesssageHandler.CanHandle(data.Key))
				{
					simpleMesssageHandler.Handle(data);
				}
			}
		}
		catch (Exception args)
		{
			_logger.LogErrorFormat("Free Ui Error :{0}", args);
		}
	}
}
