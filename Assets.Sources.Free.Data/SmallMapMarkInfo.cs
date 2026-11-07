using System.Collections.Generic;

namespace Assets.Sources.Free.Data;

public class SmallMapMarkInfo
{
	public bool PlayerSpecifiedMarkPositionChanged;

	public Dictionary<long, int> PlayerResDic = new Dictionary<long, int>();

	public int GetImageIndexForPlayer(long number)
	{
		if (PlayerResDic.TryGetValue(number, out var value))
		{
			return value;
		}
		return -1;
	}

	public void SetImageIndexForPlayer(long playerId, int imageIndex)
	{
		PlayerResDic[playerId] = imageIndex;
	}
}
