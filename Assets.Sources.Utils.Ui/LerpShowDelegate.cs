using System;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

internal class LerpShowDelegate : ILerpShowModel
{
	private class LerpShow
	{
		private enum State
		{
			Prepare,
			Running,
			PreEnd,
			End
		}

		private int _hideTime;

		private State _state;

		private ILerpShowModel _model;

		private int _showTime;

		public LerpShow(ILerpShowModel model, int showTime)
		{
			if (model != null)
			{
				_model = model;
				_state = State.Prepare;
				_showTime = showTime;
			}
		}

		public void ReStart()
		{
			if (_model != null)
			{
				_state = State.Prepare;
			}
		}

		public void OnPlayback(int clientTime)
		{
			if (_model != null)
			{
				switch (_state)
				{
				case State.Prepare:
					Prepare(clientTime);
					break;
				case State.Running:
					Running(clientTime);
					break;
				case State.PreEnd:
					PreEnd();
					break;
				case State.End:
					break;
				}
			}
		}

		private void Prepare(int clientTime)
		{
			_showTime = Mathf.Max(1, _showTime);
			_hideTime = clientTime + _showTime;
			_state = State.Running;
		}

		private void Running(int clientTime)
		{
			int num = _hideTime - clientTime;
			if (num < 0)
			{
				num = 0;
				_state = State.PreEnd;
			}
			float percent = (float)num / (float)_showTime;
			_model.OnLerp(percent);
		}

		public void PreEnd()
		{
			_model.OnFinish();
			_state = State.End;
		}
	}

	private Action<float> _onLerpAction;

	private Action _onFinishAction;

	private LerpShow _lerpShow;

	public string Name;

	public LerpShowDelegate(int showTime, Action<float> onLerp, Action onFinish)
	{
		_lerpShow = new LerpShow(this, showTime);
		_onLerpAction = onLerp;
		_onFinishAction = onFinish;
	}

	public void OnPlayback(int clientTime)
	{
		_lerpShow.OnPlayback(clientTime);
	}

	public void ReStart()
	{
		if (_lerpShow != null)
		{
			_lerpShow.ReStart();
		}
	}

	public void Stop()
	{
		if (_lerpShow != null)
		{
			_lerpShow.PreEnd();
		}
	}

	public void OnLerp(float percent)
	{
		if (_onLerpAction != null)
		{
			_onLerpAction(percent);
		}
	}

	public void OnFinish()
	{
		if (_onFinishAction != null)
		{
			_onFinishAction();
		}
	}
}
