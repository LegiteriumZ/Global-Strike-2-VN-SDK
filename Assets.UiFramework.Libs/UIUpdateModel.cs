using Assets.Sources.Framework;

namespace Assets.UiFramework.Libs;

public abstract class UIUpdateModel : AbstractModel, IPlaybackSystem
{
	public static int FirstTime;

	private int _lastTime = -1;

	private int _left;

	private const int Interval = 10;

	protected abstract void GameUpdate(int frameInterval);

	public virtual void OnPlayback()
	{
		if (_lastTime < 0)
		{
			_lastTime = _timeComponent.ServerTime;
			return;
		}
		int num = _timeComponent.ServerTime - _lastTime + _left;
		if (num > 10)
		{
			GameUpdate(10);
			num -= 10;
		}
		if (num > 0)
		{
			GameUpdate(num);
			num = 0;
		}
		_left = num;
		_lastTime = _timeComponent.ServerTime;
	}
}
