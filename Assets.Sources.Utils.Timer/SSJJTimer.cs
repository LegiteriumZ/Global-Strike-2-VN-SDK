using Assets.Sources.Components.Interface;

namespace Assets.Sources.Utils.Timer;

public class SSJJTimer : ISSJJTimer
{
	public int LeftTime { get; set; }

	public int Length { get; set; }

	public bool UsingServerTime { get; set; }

	public bool TimeEnded { get; set; }

	public SSJJTimer(int length)
	{
		LeftTime = length;
		Length = length;
		TimeEnded = false;
	}

	public SSJJTimer(int length, int leftTime)
	{
		LeftTime = leftTime;
		Length = length;
		TimeEnded = false;
	}

	public void ResetTimer()
	{
		LeftTime = Length;
		TimeEnded = false;
	}

	public void AddTime(int deltaTime)
	{
		LeftTime -= deltaTime;
		TimeEnded = LeftTime < 0;
	}

	public int GetPassedTime()
	{
		return Length - LeftTime;
	}
}
