using System.Collections.Generic;
using Assets.Sources.Free.Effect;
using NetData;

namespace Assets.Sources.Free.UI;

public class ShowSimpleStyle : IShowStyle
{
	private readonly List<UITimeChange> _changes;

	public ShowSimpleStyle()
	{
		_changes = new List<UITimeChange>();
	}

	public IShowStyle Parse(SimpleProto simpleProto)
	{
		if (simpleProto.Ks[1] == 1)
		{
			ShowSimpleStyle showSimpleStyle = new ShowSimpleStyle();
			for (int i = 0; i < simpleProto.Ss.Count - 1; i++)
			{
				showSimpleStyle._changes.Add(new UITimeChange(simpleProto.Ins[i * 2], simpleProto.Ins[i * 2 + 1], simpleProto.Fs[i * 2], simpleProto.Fs[i * 2 + 1], simpleProto.Ss[i + 1]));
			}
			return showSimpleStyle;
		}
		return null;
	}

	public void Show(SimpleFreeUI sprite, int currentTime, int totalTime)
	{
		if (currentTime < totalTime || totalTime == 0)
		{
			sprite.Visible = true;
			for (int i = 0; i < _changes.Count; i++)
			{
				_changes[i].SetValue(currentTime, totalTime, sprite);
			}
			return;
		}
		sprite.Visible = false;
		sprite.X = sprite.OrignalX;
		sprite.Y = sprite.OrignalY;
		sprite.Width = sprite.OrignalWidth;
		sprite.Height = sprite.OrignalHeight;
		sprite.ScaleX = 1f;
		sprite.ScaleY = 1f;
		sprite.Alpha = 1f;
	}

	public void ShowEffect(FreeRenderObject effect, int currentTime, int totalTime)
	{
		if (currentTime < totalTime || totalTime <= 0)
		{
			effect.Visible = true;
		}
		else
		{
			effect.Visible = false;
		}
	}
}
