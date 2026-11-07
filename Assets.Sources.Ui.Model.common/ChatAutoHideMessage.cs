using System;
using Assets.Sources.Chat;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

internal class ChatAutoHideMessage
{
	public const int HideCostFrame = 100;

	private Action<int, float> _changeFunc;

	private ChatAutoHideMessage()
	{
	}

	public ChatAutoHideMessage(Action<int, float> changeFunc)
	{
		_changeFunc = changeFunc;
	}

	private void SetAlpha(int idx, float value)
	{
		_changeFunc(idx, value);
	}

	public void Update(int index, ref ChatHideAnimData data, int frameinterval)
	{
		if (data.RemainTime > 0)
		{
			data.RemainTime -= frameinterval;
			SetAlpha(index, 1f);
		}
		else if (data.AlphaRemainTime > 0)
		{
			float value = Mathf.Lerp(0f, 1f, (float)Mathf.Max(data.AlphaRemainTime, 0) / 100f);
			data.AlphaRemainTime -= frameinterval;
			SetAlpha(index, value);
		}
		else if (data.AlphaRemainTime <= 0)
		{
			SetAlpha(index, 0f);
		}
	}
}
