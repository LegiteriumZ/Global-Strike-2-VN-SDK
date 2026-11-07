using System.Collections.Generic;
using SSJJBase.Logger;
using Sharpen;

namespace Assets.Sources.Utils.EventLogger;

internal class EventLogger
{
	private static EventLogger _instance;

	private Dictionary<string, LoggerAdapter> _loggers = new Dictionary<string, LoggerAdapter>();

	private IDictionary<string, object> ps = new Dictionary<string, object>();

	internal float leftFpsAvg;

	public static EventLogger Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new EventLogger();
			}
			return _instance;
		}
	}

	public void Logger(string logger, string message, IDictionary<string, object> ps)
	{
		if (!_loggers.ContainsKey(logger))
		{
			_loggers.Add(logger, new LoggerAdapter(logger));
		}
		GlobalProperties.Instance.LocalProperties.PutAll(ps);
		_loggers[logger].Info(message);
		GlobalProperties.Instance.LocalProperties.Clear();
	}

	public void StageLogger(string message, StartStageEnum stage)
	{
		ps["stage"] = stage;
		Logger("event.stage", message, ps);
		ps.Clear();
	}

	public void StageLogger(string message, StartStageEnum stage, string la)
	{
		ps["stage"] = stage;
		ps["la"] = la;
		Logger("event.stage", message, ps);
		ps.Clear();
	}

	internal void FrameLogger(float mFpsAvg, string raceInfo, bool isFullFrame, int sceneId)
	{
		if ((int)mFpsAvg == 60)
		{
			ps["avgFpg0"] = 60;
			leftFpsAvg += mFpsAvg - (float)(int)mFpsAvg;
		}
		else if ((float)(int)mFpsAvg < 60f)
		{
			if ((float)(int)(mFpsAvg + leftFpsAvg) > 60f)
			{
				ps["avgFpg0"] = 60;
				leftFpsAvg = mFpsAvg + leftFpsAvg - 60f;
			}
			else
			{
				ps["avgFpg0"] = (int)(mFpsAvg + leftFpsAvg);
				leftFpsAvg = mFpsAvg + leftFpsAvg - (float)(int)(mFpsAvg + leftFpsAvg);
			}
		}
		else
		{
			ps["avgFpg0"] = (int)mFpsAvg;
		}
		ps["avgFpsOrigin0"] = (int)mFpsAvg;
		if (isFullFrame)
		{
			ps["avgFullFpg0"] = (int)(mFpsAvg + leftFpsAvg);
		}
		if (leftFpsAvg < 0f)
		{
			leftFpsAvg = 0.01f;
		}
		ps["raceDataNew"] = raceInfo;
		ps["SceneId"] = sceneId;
		Logger("event.frame", "", ps);
		ps.Clear();
	}

	internal void StartLogger<T>(string key, T value)
	{
		ps[key] = value;
	}

	internal void EndLogger(string loggername)
	{
		Logger(loggername, "", ps);
		ps.Clear();
	}
}
