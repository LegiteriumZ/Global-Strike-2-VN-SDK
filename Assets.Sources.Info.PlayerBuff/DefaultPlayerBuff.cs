using Assets.Sources.Components.Interface.Info.PlayerBuff;

namespace Assets.Sources.Info.PlayerBuff;

public class DefaultPlayerBuff : IPlayerBuff
{
	private int _cdTime;

	public string Name { get; private set; }

	public DefaultPlayerBuff(string name, int cdTime)
	{
		_cdTime = cdTime;
		Name = name;
	}

	public void Reset(int cdTime)
	{
		_cdTime = cdTime;
	}

	public bool IsActive()
	{
		return _cdTime > 0;
	}

	public void Update(int interval)
	{
		_cdTime -= interval;
	}
}
